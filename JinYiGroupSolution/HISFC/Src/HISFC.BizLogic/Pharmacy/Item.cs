using System;
using System.Collections;
using System.Collections.Generic;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.FrameWork.Function;
using PPRObject = Neusoft.HISFC.Models.Preparation;
using Neusoft.HISFC.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.BizLogic.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品进销存管理类]<br></br>
    /// [创 建 者: Cuip]<br></br>
    /// [创建时间: 2005-02]<br></br>
    /// <修改记录>
    ///     1、2007-12-10 修改ApproveInput函数 入库核准时屏蔽对申请数据状态的更新
    ///     2、2010-8-24 写临时日志（仅用于各种测试使用） by Sunjh {5182824E-9F42-493c-B985-F5803AA5FC9E}
    ///     3、获取库存方法性能优化 by Sunjh 2010-8-30 {C2BF59BC-9C07-4b0a-A5E2-797426CCDE81}
    ///     4、住院摆药性能优化【修改撤销，为了不影响住院摆药之外的出库库存判断】 by Sunjh 2010-8-30 {32F6FA1C-0B8E-4b9c-83B6-F9626397AC7C}
    ///     5、删除某条未生效的药品调价信息 by Sunjh 2010-8-31 {B56F6FDF-E7D0-4afd-953A-3006AFE257C1}
    ///     6、兼容住院集中发药相关 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
    /// </修改记录>
    /// </summary>
    public class Item : Neusoft.FrameWork.Management.Database, IMAInManager, IMAOutManager
    {
        public Item()
        {

        }

        #region 静态量
        /// <summary>
        /// 是否允许扣除负库存
        /// </summary>
        public static bool MinusStore
        {
            get
            {
                Neusoft.FrameWork.Management.ControlParam ctrlManager = new Neusoft.FrameWork.Management.ControlParam();
                ctrlManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                //negativeStore 1 负库存管理 0 不允许负库存管理
                string negativeStore = ctrlManager.QueryControlerInfo("S00024", false);

                return Neusoft.FrameWork.Function.NConvert.ToBoolean(negativeStore);
            }
        }

        /// <summary>
        /// 是否已初始化收费窗口
        /// </summary>
        private static bool isInitSendWindow = false;

        /// <summary>
        /// 收费窗口
        /// </summary>
        private static string feeWindowNO = "";

        #endregion

        #region 取流水号

        /// <summary>
        /// 取药品出库单流水号
        /// </summary>
        /// <returns>失败返回null 非空返回新流水号</returns>
        public string GetNewOutputNO()
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetNewOutputID", ref strSQL) == -1)
                return null;
            string strReturn = this.ExecSqlReturnOne(strSQL);
            if (strReturn == "-1")
            {
                this.Err = "取药品出库单流水号时出错！" + this.Err;
                return null;
            }
            return strReturn;
        }

        /// <summary>
        /// 取摆药单流水号
        /// </summary>
        /// <returns>失败返回null 非空返回新流水号</returns>
        public string GetNewDrugBillNO()
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetNewDrugBillID", ref strSQL) == -1)
                return null;
            string strReturn = this.ExecSqlReturnOne(strSQL);
            if (strReturn == "-1")
            {
                this.Err = "取摆药单流水号时出错！" + this.Err;
                return null;
            }
            return strReturn;
        }

        /// <summary>
        /// 取新库存批次流水号
        /// </summary>
        /// <returns>成功返回新批次 失败返回null</returns>
        public string GetNewGroupNO()
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetNewGroupID", ref strSQL) == -1)
                return null;
            string strReturn = this.ExecSqlReturnOne(strSQL);
            if (strReturn == "-1")
            {
                this.Err = "取批次流水号时出错！" + this.Err;
                return null;
            }
            return strReturn;
        }

        /// <summary>
        /// 取供货商结存付款序号
        /// </summary>
        /// <returns>成功返回新付款序号 失败返回null</returns>
        public string GetNewPayNO()
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetPayNO", ref strSQL) == -1) return null;
            string strReturn = this.ExecSqlReturnOne(strSQL);
            if (strReturn == "-1")
            {
                this.Err = "取批次流水号时出错！" + this.Err;
                return null;
            }
            return strReturn;
        }

        /// <summary>
        /// 获取新配置批次流水号
        /// </summary>
        /// <returns></returns>
        public string GetNewCompoundGroup()
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetNewCompoundGroup", ref strSQL) == -1)
                return null;
            string strReturn = this.ExecSqlReturnOne(strSQL);
            if (strReturn == "-1")
            {
                this.Err = "获取新配置批次流水号时出错！" + this.Err;
                return null;
            }
            return strReturn;
        }

        #endregion

        #region 调用存储过程

        /// <summary>
        /// 药品调价 存储过程调用
        /// </summary>
        /// <returns> -1 失败 1 成功</returns>
        public int ExecProcedureChangPrice()
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Procedure.pkg_pha.prc_change_price", ref strSQL) == -1)
            {
                this.Err = "找不到存储过程执行语句Pharmacy.Procedure.pkg_pha.prc_change_price";
                return -1;
            }

            string strReturn = "No Return";
            if (this.ExecEvent(strSQL, ref strReturn) == -1)
            {
                this.Err = strReturn + "执行存储过程出错!prc_change_price:" + this.Err;
                this.ErrCode = "PRC_GET_INVOICE";
                this.WriteErr();
                return -1;

            };
            return 1;
        }

        /// <summary>
        /// 执行盘点结存存储过程
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <param name="isBatch">是否按批号盘点</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int ExecProcedurgCheckCStore(string deptCode, string checkCode, bool isBatch)
        {
            //获取是否按批号盘点标志
            string batchFlag;
            if (isBatch)
                batchFlag = "1";
            else
                batchFlag = "0";
            //操作员
            string operCode = this.Operator.ID;
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Procedure.pkg_pha.prc_check_cstore", ref strSQL) == -1)
            {
                this.Err = "找不到存储过程执行语句Pharmacy.Procedure.pkg_pha.prc_check_cstore";
                return -1;
            }

            string sqlErr = "";
            int sqlCode = 0;
            try
            {
                strSQL = string.Format(strSQL, deptCode, checkCode, batchFlag, operCode, sqlCode, sqlErr);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            string strReturn = "";
            if (this.ExecEvent(strSQL, ref strReturn) == -1)
            {
                this.Err = strReturn + "执行存储过程出错!prc_check_cstore:" + this.Err;
                this.ErrCode = "prc_check_cstore";
                this.WriteErr();
                return -1;
            };
            if (strReturn != "")
            {
                string[] strParam = strReturn.Split(',');
                if (strParam.Length > 1)
                {
                    if (strParam[0] == "-1")
                    {
                        this.Err = this.Err + strParam[1];
                        return -1;
                    }
                }
            }

            return 1;
        }

        /// <summary>
        /// 执行月结存储过程
        /// </summary>
        /// <param name="operCode">月结操作员</param>
        /// <returns>成功执行返回1 失败返回-1</returns>
        public int ExecMonthStore(string operCode)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Procedure.pkg_pha.prc_month_store", ref strSQL) == -1)
            {
                this.Err = "找不到存储过程执行语句Pharmacy.Procedure.pkg_pha.prc_month_store";
                return -1;
            }

            string sqlErr = "";
            int sqlCode = 0;
            try
            {
                strSQL = string.Format(strSQL, operCode, sqlCode, sqlErr);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            string strReturn = "";
            if (this.ExecEvent(strSQL, ref strReturn) == -1)
            {
                this.Err = strReturn + "执行存储过程出错!prc_month_store:" + this.Err;
                this.ErrCode = "prc_month_store";
                this.WriteErr();
                return -1;

            };
            return 1;
        }

        /// <summary>
        /// 执行日结存储过程
        /// </summary>
        /// <param name="deptCode">日结科室</param>
        /// <param name="begintTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="privOper">操作人</param>
        /// <returns>成功执行返回1 失败返回-1</returns>
        public int ExecDayStore(string deptCode, DateTime begintTime, DateTime endTime, string privOper)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Procedure.pkg_pha.prc_month_store_daily", ref strSQL) == -1)
            {
                this.Err = "找不到存储过程执行语句Pharmacy.Procedure.pkg_pha.prc_month_store_daliy";
                return -1;
            }

            string sqlErr = "";
            int sqlCode = 0;
            try
            {
                strSQL = string.Format(strSQL, deptCode, begintTime.ToString(), endTime.ToString(), privOper, sqlCode, sqlErr);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            string strReturn = "";
            if (this.ExecEvent(strSQL, ref strReturn) == -1)
            {
                this.Err = strReturn + "执行存储过程出错!prc_month_store_daily:" + this.Err;
                this.ErrCode = "prc_month_store_daily";
                this.WriteErr();
                return -1;

            };
            return 1;
        }

        #endregion

        #region 药品基本信息

        #region 基础增、删、改操作

        /// <summary>
        /// 取药品部分基本信息列表，可能是一条或者多条药品记录
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>成功返回药品对象数组 失败返回null</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.Item> myGetItemSimple(string SQLString)
        {
            List<Neusoft.HISFC.Models.Pharmacy.Item> al = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            Neusoft.HISFC.Models.Pharmacy.Item Item; //返回数组中的药品信息类

            try
            {
                this.ExecQuery(SQLString);

                while (this.Reader.Read())
                {
                    Item = new Neusoft.HISFC.Models.Pharmacy.Item();
                    #region "接口说明"
                    //  0 药品编码        1 商品名称        2 拼音码          3 五笔码          4 自定义码 
                    //  5 包装数量        6 规格            7 系统类别编码    8 最小费用代码    9 药品通用名     
                    // 10 通用名拼音码   11 通用名五笔码   12 学名           13 学名拼音码     14 学名五笔码     
                    // 15 别名           16 英文商品名     17 英文通用名     18 英文别名       19 国际编码
                    // 20 国家编码       21 包装单位       22 最小单位       23 基本剂量       24 剂量单位       
                    // 25 剂型编码       26 药品类别编码   27 药品性质编码   28 零售价	        29 批发价         
                    // 30 购入价         31 最高零售价     32 药理作用(一级) 33 储藏条件       34 使用方法       
                    // 35 一次用量       36 频次		    37 生产厂家编码   38 批准文号       39 注册商标       
                    // 40 价格形式编码   41 是否停用       42 是否自制       43 是否GMP        44 是否OTC（处方药） 
                    // 45 是否新药       46 是否缺药       47 是否大屏幕显示 48 是否附材       49 注意事项       
                    // 50 药品等级       51 条形码         52 产地           53 最新供货公司   54 有效成份       
                    // 55 中药执行标准   56 药品简介       57 药品说明书内容 58 二级药理作用   59 三级药理作用   
                    // 60 是否是招标用药 61 中标价         62 采购合同编号   63 采购开始周期   64 采购结束周期   
                    // 65 采购单位编码   66 备注           67 操作员代码     68 操作时间       69 别名拼音码     
                    // 70 别名五笔码     71 别名自定义码   72 通用名自定义码 73 学名自定义码   74 是否需要试敏
                    #endregion
                    try
                    {
                        Item.ID = this.Reader[0].ToString();                                  //0  药品编码
                        Item.Name = this.Reader[1].ToString();                                //1  商品名称
                        Item.PackQty = NConvert.ToDecimal(this.Reader[5].ToString());         //5  包装数量
                        Item.Specs = this.Reader[6].ToString();                               //6  规格
                        Item.SysClass.ID = this.Reader[7].ToString();                         //7  系统类别编码
                        Item.MinFee.ID = this.Reader[8].ToString();                           //8  最小费用代码
                        Item.PackUnit = this.Reader[21].ToString();                           //21 包装单位
                        Item.MinUnit = this.Reader[22].ToString();                            //22 最小单位
                        Item.Type.ID = this.Reader[26].ToString();                            //26 药品类别编码
                        Item.Quality.ID = this.Reader[27].ToString();                         //27 药品性质编码
                        Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[28].ToString());    //28 零售价
                        Item.Product.Producer.ID = this.Reader[37].ToString();                        //37 生产厂家编码

                        Item.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(NConvert.ToInt32(this.Reader[41]));
                        // Item.IsStop = NConvert.ToBoolean( this.Reader[ 41 ].ToString( ) );         //41 是否停用
                        Item.IsValid = !Item.IsStop;
                        //if (Item.IsStop)
                        //    Item.ValidState = "0";
                        //else
                        //    Item.ValidState = "1";

                        Item.SpellCode = this.Reader[2].ToString();                          //2  拼音码  
                        Item.WBCode = this.Reader[3].ToString();                             //3  五笔码
                        Item.UserCode = this.Reader[4].ToString();                           //4  自定义码
                        Item.NameCollection.RegularName = this.Reader[9].ToString();                         //9  药品通用名
                        Item.NameCollection.RegularSpell.SpellCode = this.Reader[10].ToString();        //10 通用名拼音码
                        Item.NameCollection.RegularSpell.WBCode = this.Reader[11].ToString();           //11 通用名五笔码
                        Item.NameCollection.RegularSpell.UserCode = this.Reader[72].ToString();         //72 通用名自定义码
                        Item.NameCollection.EnglishName = this.Reader[16].ToString();                        //16 英文商品名 
                        Item.IsNostrum = NConvert.ToBoolean(this.Reader[85].ToString());                     //85  协定处方标志
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得药品基本信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }

                    al.Add(Item);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得药品基本信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return al;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 取药品基本信息列表，可能是一条或者多条药品记录
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>成功返回药品对象数组 失败返回null</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.Item> myGetItem(string SQLString)
        {
            List<Neusoft.HISFC.Models.Pharmacy.Item> al = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            Neusoft.HISFC.Models.Pharmacy.Item Item; //返回数组中的药品信息类

            try
            {
                this.ExecQuery(SQLString);

                while (this.Reader.Read())
                {
                    Item = new Neusoft.HISFC.Models.Pharmacy.Item();
                    #region "接口说明"
                    //  0 药品编码        1 商品名称        2 拼音码          3 五笔码          4 自定义码 
                    //  5 包装数量        6 规格            7 系统类别编码    8 最小费用代码    9 药品通用名     
                    // 10 通用名拼音码   11 通用名五笔码   12 学名           13 学名拼音码     14 学名五笔码     
                    // 15 别名           16 英文商品名     17 英文通用名     18 英文别名       19 国际编码
                    // 20 国家编码       21 包装单位       22 最小单位       23 基本剂量       24 剂量单位       
                    // 25 剂型编码       26 药品类别编码   27 药品性质编码   28 零售价	        29 批发价         
                    // 30 购入价         31 最高零售价     32 药理作用(一级) 33 储藏条件       34 使用方法       
                    // 35 一次用量       36 频次		    37 生产厂家编码   38 批准文号       39 注册商标       
                    // 40 价格形式编码   41 是否停用       42 是否自制       43 是否GMP        44 是否OTC（处方药） 
                    // 45 是否新药       46 是否缺药       47 是否大屏幕显示 48 是否附材       49 注意事项       
                    // 50 药品等级       51 条形码         52 产地           53 最新供货公司   54 有效成份       
                    // 55 中药执行标准   56 药品简介       57 药品说明书内容 58 二级药理作用   59 三级药理作用   
                    // 60 是否是招标用药 61 中标价         62 采购合同编号   63 采购开始周期   64 采购结束周期   
                    // 65 采购单位编码   66 备注           67 操作员代码     68 操作时间       69 别名拼音码     
                    // 70 别名五笔码     71 别名自定义码   72 通用名自定义码 73 学名自定义码   74 是否需要试敏
                    // 75 省限制         76市限制          77自费项目        78特殊标记        79 特殊标记
                    // 80 旧系统药品编码 81数据变动类型	   82数据变动时间	 83数据变动原因    84 门诊拆分属性
                    // 85 协定处方标志
                    #endregion
                    Item.ID = this.Reader[0].ToString();
                    Item.Name = this.Reader[1].ToString();
                    Item.SpellCode = this.Reader[2].ToString();
                    Item.WBCode = this.Reader[3].ToString();
                    Item.UserCode = this.Reader[4].ToString();
                    Item.PackQty = NConvert.ToDecimal(this.Reader[5].ToString());
                    Item.Specs = this.Reader[6].ToString();
                    Item.SysClass.ID = this.Reader[7].ToString();
                    Item.MinFee.ID = this.Reader[8].ToString();
                    Item.NameCollection.RegularName = this.Reader[9].ToString();
                    Item.NameCollection.RegularSpell.SpellCode = this.Reader[10].ToString();
                    Item.NameCollection.RegularSpell.WBCode = this.Reader[11].ToString();
                    Item.NameCollection.FormalName = this.Reader[12].ToString();
                    Item.NameCollection.FormalSpell.SpellCode = this.Reader[13].ToString();
                    Item.NameCollection.FormalSpell.WBCode = this.Reader[14].ToString();
                    Item.NameCollection.OtherName = this.Reader[15].ToString();
                    Item.NameCollection.EnglishName = this.Reader[16].ToString();
                    Item.NameCollection.EnglishRegularName = this.Reader[17].ToString();
                    Item.NameCollection.EnglishOtherName = this.Reader[18].ToString();
                    Item.NameCollection.InternationalCode = this.Reader[19].ToString();
                    Item.NameCollection.GbCode = this.Reader[20].ToString();
                    Item.PackUnit = this.Reader[21].ToString();
                    Item.MinUnit = this.Reader[22].ToString();
                    Item.BaseDose = NConvert.ToDecimal(this.Reader[23].ToString());
                    Item.DoseUnit = this.Reader[24].ToString();
                    Item.DosageForm.ID = this.Reader[25].ToString();
                    Item.Type.ID = this.Reader[26].ToString();
                    Item.Quality.ID = this.Reader[27].ToString();
                    Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[28].ToString());
                    Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[29].ToString());
                    Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[30].ToString());
                    Item.PriceCollection.TopRetailPrice = NConvert.ToDecimal(this.Reader[31].ToString());
                    Item.PhyFunction1.ID = this.Reader[32].ToString();
                    Item.Product.StoreCondition = this.Reader[33].ToString();
                    Item.Usage.ID = this.Reader[34].ToString();
                    Item.OnceDose = NConvert.ToDecimal(this.Reader[35].ToString());
                    Item.Frequency.ID = this.Reader[36].ToString();
                    Item.Product.Producer.ID = this.Reader[37].ToString();
                    Item.Product.ApprovalInfo = this.Reader[38].ToString();
                    Item.Product.Label = this.Reader[39].ToString();
                    Item.PriceCollection.PriceForm.ID = this.Reader[40].ToString();

                    //有效性 1 有效 0 无效 2 废弃
                    Item.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(NConvert.ToInt32(this.Reader[41]));
                    //Item.IsStop = NConvert.ToBoolean( this.Reader[ 41 ].ToString( ) );
                    Item.IsValid = !Item.IsStop;
                    //if (Item.IsStop)
                    //    Item.ValidState = "0";
                    //else
                    //    Item.ValidState = "1";

                    Item.Product.IsSelfMade = NConvert.ToBoolean(this.Reader[42].ToString());
                    Item.IsGMP = NConvert.ToBoolean(this.Reader[43].ToString());
                    Item.IsOTC = NConvert.ToBoolean(this.Reader[44].ToString());
                    Item.IsNew = NConvert.ToBoolean(this.Reader[45].ToString());
                    Item.IsLack = NConvert.ToBoolean(this.Reader[46].ToString());
                    Item.IsShow = true;//modified by zlw 2006-6-5
                    Item.IsShow = NConvert.ToBoolean(this.Reader[47].ToString());
                    Item.IsSubtbl = NConvert.ToBoolean(this.Reader[48].ToString());
                    Item.Product.Caution = this.Reader[49].ToString();
                    Item.Grade = this.Reader[50].ToString();
                    Item.Product.BarCode = this.Reader[51].ToString();
                    Item.Product.ProducingArea = this.Reader[52].ToString();
                    Item.Product.Company.ID = this.Reader[53].ToString();
                    Item.Ingredient = this.Reader[54].ToString();
                    Item.ExecuteStandard = this.Reader[55].ToString();
                    Item.Product.BriefIntroduction = this.Reader[56].ToString();
                    Item.Product.Manual = this.Reader[57].ToString();
                    Item.PhyFunction2.ID = this.Reader[58].ToString();
                    Item.PhyFunction3.ID = this.Reader[59].ToString();
                    Item.TenderOffer.IsTenderOffer = NConvert.ToBoolean(this.Reader[60].ToString());
                    Item.TenderOffer.Price = NConvert.ToDecimal(this.Reader[61].ToString());
                    Item.TenderOffer.ContractNO = this.Reader[62].ToString();
                    Item.TenderOffer.BeginTime = NConvert.ToDateTime(this.Reader[63].ToString());
                    Item.TenderOffer.EndTime = NConvert.ToDateTime(this.Reader[64].ToString());
                    Item.TenderOffer.Company.ID = this.Reader[65].ToString();
                    Item.Memo = this.Reader[66].ToString();
                    Item.Oper.ID = this.Reader[67].ToString();
                    Item.Oper.OperTime = NConvert.ToDateTime(this.Reader[68].ToString());
                    Item.NameCollection.OtherSpell.SpellCode = this.Reader[69].ToString();
                    Item.NameCollection.OtherSpell.WBCode = this.Reader[70].ToString();
                    Item.NameCollection.OtherSpell.UserCode = this.Reader[71].ToString();
                    Item.NameCollection.RegularSpell.UserCode = this.Reader[72].ToString();
                    Item.NameCollection.FormalSpell.UserCode = this.Reader[73].ToString();
                    Item.IsAllergy = NConvert.ToBoolean(this.Reader[74].ToString());
                    Item.SpecialFlag = this.Reader[75].ToString();		//75省限标记
                    Item.SpecialFlag1 = this.Reader[76].ToString();		//76市限标记
                    Item.SpecialFlag2 = this.Reader[77].ToString();		//77自费项目
                    Item.SpecialFlag3 = this.Reader[78].ToString();		//78特殊标记
                    Item.SpecialFlag4 = this.Reader[79].ToString();		//79特殊标记
                    Item.OldDrugID = this.Reader[80].ToString();		//80旧系统药品编码
                    Item.ShiftType.ID = this.Reader[81].ToString();		//81数据变动类型
                    Item.ShiftTime = NConvert.ToDateTime(this.Reader[82].ToString());//82数据变动日期
                    Item.ShiftMark = this.Reader[83].ToString();		//83数据变动原因
                    Item.SplitType = this.Reader[84].ToString();     //84拆分类型 0 可拆分 1 不可拆分
                    Item.ShowState = this.Reader[47].ToString();     //显示 属性 0全院 1 住院处 2 门诊
                    Item.IsNostrum = NConvert.ToBoolean(this.Reader[85].ToString()); //85协定处方标志

                    //{8ADD2D48-2427-48aa-A521-4B17EECBC8B4}  新增字段
                    if (this.Reader.FieldCount > 86)
                    {
                        Item.ExtendData1 = this.Reader[86].ToString();
                        Item.ExtendData2 = this.Reader[87].ToString();
                        Item.CreateTime = NConvert.ToDateTime( this.Reader[88] );
                    }

                    al.Add(Item);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得药品基本信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return al;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 获得update或者insert药品字典表的传入参数数组
        /// </summary>
        /// <param name="Item">药品基本信息</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private string[] myGetParmItem(Neusoft.HISFC.Models.Pharmacy.Item Item)
        {
            #region "接口说明"
            //  0 药品编码        1 商品名称        2 拼音码          3 五笔码          4 自定义码 
            //  5 规格            6 最小费用代码    7 系统类别编码    8 包装数量        9 国际编码     
            // 10 药品类别编码   11 药品通用名     12 通用名拼音码   13 通用名五笔码   14 储藏条件 
            // 15 药品性质编码   16 学名           17 学名拼音码     18 学名五笔码     19 频次
            // 20 别名           21 英文商品名     22 英文通用名     23 英文别名       24 国家编码
            // 25 包装单位       26 最小单位       27 基本剂量       28 剂量单位       29 剂型编码
            // 30 生产厂家编码   31 批文信息       32 零售价         33 批发价         34 购入价       
            // 35 使用方法编码   36 注册商标       37 药理作用编码   38 二级药理作用   39 三级药理作用       
            // 40 备注           41 价格形式编码   42 是否停用       43 是否自制       44 是否新药
            // 45 是否GMP        46 是否OTC－处方药47 是否缺药       48 是否大屏幕显示 49 是否附材            
            // 50 注意事项       51 有效成份       52 一次用量       53 中药执行标准   54 药品简介
            // 55 药品等级       56 条形码         57 产地           58 最新供货公司   59 最高零售价       
            // 60 药品说明书内容 61 操作员代码     62 操作时间       63 是否需要试敏,  64 是否招标药品
            // 65 采购单位编码   66 中标价         67 采购合同编号   68 采购开始周期   69 采购结束周期
            // 70 别名拼音码     71 别名五笔码     72 别名自定义码   73 通用名自定义码 74 学名自定义码  
            // 75 省限制         76市限制          77自费项目        78特殊标记        79 特殊标记
            // 80 旧系统药品编码 81数据变动类型	   82数据变动时间	 83数据变动原因    84 拆分类型
            // 85 协定处方标志   86 扩展数据1      87扩展数据2       88字典建立时间
            #endregion

            //{8ADD2D48-2427-48aa-A521-4B17EECBC8B4} 新增字段：扩展数据1 扩展数据2 字典建立时间

            string[] strParm ={   Item.ID,              Item.Name,             Item.SpellCode,                  Item.WBCode,                   Item.UserCode,        
								  Item.Specs,           Item.MinFee.ID,        Item.SysClass.ID.ToString(),     Item.PackQty.ToString(),       Item.NameCollection.InternationalCode,	   
								  Item.Type.ID,         Item.NameCollection.RegularName,      Item.NameCollection.RegularSpell.SpellCode, Item.NameCollection.RegularSpell.WBCode,  Item.Product.StoreCondition,    
								  Item.Quality.ID.ToString(), Item.NameCollection.FormalName, Item.NameCollection.FormalSpell.SpellCode,  Item.NameCollection.FormalSpell.WBCode,   Item.Frequency.ID,
								  Item.NameCollection.OtherName,       Item.NameCollection.EnglishName,      Item.NameCollection.EnglishRegularName,          Item.NameCollection.EnglishOtherName,          Item.NameCollection.GbCode,
								  Item.PackUnit,        Item.MinUnit,          Item.BaseDose.ToString(),         Item.DoseUnit,                  Item.DosageForm.ID,                           
								  Item.Product.Producer.ID,     Item.Product.ApprovalInfo,     Item.PriceCollection.RetailPrice.ToString(),      Item.PriceCollection.WholeSalePrice.ToString(), Item.PriceCollection.PurchasePrice.ToString(),  
								  Item.Usage.ID,        Item.Product.Label,            Item.PhyFunction1.ID,             Item.PhyFunction2.ID,           Item.PhyFunction3.ID,
								  Item.Memo,            Item.PriceCollection.PriceForm.ID,     ((int)Item.ValidState).ToString(),  NConvert.ToInt32(Item.Product.IsSelfMade).ToString(),NConvert.ToInt32(Item.IsNew).ToString(),
								  NConvert.ToInt32(Item.IsGMP).ToString(),NConvert.ToInt32(Item.IsOTC).ToString(), NConvert.ToInt32(Item.IsLack).ToString(),  NConvert.ToInt32(Item.IsShow).ToString() /*Item.ShowState*/,NConvert.ToInt32(Item.IsSubtbl).ToString(),
								  Item.Product.Caution,         Item.Ingredient,       Item.OnceDose.ToString(),         Item.ExecuteStandard,           Item.Product.BriefIntroduction,         
								  Item.Grade,           Item.Product.BarCode,          Item.Product.ProducingArea,               Item.Product.Company.ID,                Item.PriceCollection.TopRetailPrice.ToString(),
								  Item.Product.Manual,          this.Operator.ID,      Item.Oper.OperTime.ToString(),         NConvert.ToInt32(Item.IsAllergy).ToString(),	   NConvert.ToInt32(Item.TenderOffer.IsTenderOffer).ToString(),  
								  Item.TenderOffer.Company.ID, Item.TenderOffer.Price.ToString(), Item.TenderOffer.ContractNO, Item.TenderOffer.BeginTime.ToString(), Item.TenderOffer.EndTime.ToString(), 
								  Item.NameCollection.OtherSpell.SpellCode, Item.NameCollection.OtherSpell.WBCode, Item.NameCollection.OtherSpell.UserCode, Item.NameCollection.RegularSpell.UserCode, Item.NameCollection.FormalSpell.UserCode,
								  Item.SpecialFlag,     Item.SpecialFlag1,     Item.SpecialFlag2,                Item.SpecialFlag3,              Item.SpecialFlag4,
								  Item.OldDrugID,	   Item.ShiftType.ID.ToString(), Item.ShiftTime.ToString(),		Item.ShiftMark.ToString()  ,Item.SplitType , NConvert.ToInt32(Item.IsNostrum).ToString(),
                                  Item.ExtendData1,    Item.ExtendData2,       Item.CreateTime.ToString()
							 };

            return strParm;
        }

        /// <summary>
        /// 向药品字典表中插入一条记录，药品编码采用oracle中的序列号
        /// </summary>
        /// <param name="item">药品基本信息</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertItem(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertItem", ref strSQL) == -1) return -1;
            string[] strParm;
            try
            {
                //取药品流水号
                item.ID = this.GetSequence("Pharmacy.Item.GetNewItemID");
                if (item.ID == null) return -1;
                item.ID = "Y" + item.ID.PadLeft(11, '0');

                strParm = myGetParmItem(item);  //取参数列表
                //strSQL = string.Format( strSQL , strParm );    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSQL, strParm);
        }

        /// <summary>
        /// 更新药品信息，以药品编码为主键
        /// </summary>
        /// <param name="item">药品基本信息</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateItem(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateItem", ref strSQL) == -1) return -1;
            string[] strParm;

            try
            {
                strParm = myGetParmItem(item);  //取参数列表
                //strSQL = string.Format( strSQL , strParm );    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL, strParm);
        }

        /// <summary>
        /// 删除药品信息
        /// </summary>
        /// <param name="ID">药品编码</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int DeleteItem(string ID)
        {
            string strSQL = ""; //根据药品编码删除某一药品信息的DELETE语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteItem", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, ID);
            }
            catch
            {
                this.Err = "传入参数不对！Pharmacy.Item.DeleteItem";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 保存药品数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
        /// </summary>
        /// <param name="item">药品实体</param>
        /// <returns>1成功 -1失败</returns>
        public int SetItem(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            int parm;
            //执行更新操作
            parm = UpdateItem(item);

            //如果没有找到可以更新的数据，则插入一条新记录
            if (parm == 0)
            {
                parm = InsertItem(item);
            }
            return parm;
        }

        #endregion

        #region 内部使用

        /// <summary>
        /// 取全部药品信息列表
        /// </summary>
        /// <returns>药品类数组</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemList()
        {
            string strSelect = "";  //获得全部药品信息的SELECT语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetItem(strSelect);
        }

        /// <summary>
        /// 根据药品类别取药品信息列表
        /// </summary>
        /// <param name="drugType">药品类别</param>
        /// <returns>成功返回对应药品信息数组 出错返回null</returns>
        [Obsolete("重构函数名称为QueryItemListForCheck", false)]
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemListForCheck(string drugType)
        {
            string strSelect = "";  //获得全部药品信息的SELECT语句
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.OrderInfo字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetList.ForCheck", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetList.ForCheck字段!";
                return null;
            }
            try
            {
                strSelect = strSelect + strWhere;
                strSelect = string.Format(strSelect, drugType);
            }
            catch
            {
                this.Err = "SQL参数初始化失败";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetItem(strSelect);
        }

        /// <summary>
        /// 获得全部药品信息列表，根据参数判断是否显示简单数据列
        /// </summary>
        /// <param name="IsShowSimple">是否显示简单数据列</param>
        /// <returns>成功返回药品信息简略数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemList(bool IsShowSimple)
        {
            string strSelect = "";  //获得全部药品信息的SELECT语句
            //string strWhere  ="";  //获得全部药品信息的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            if (IsShowSimple)
                return this.myGetItemSimple(strSelect);
            else
                return this.myGetItem(strSelect);
        }

        /// <summary>
        /// 通过自定义码获取是否存在有效的药品信息
        /// </summary>
        /// <param name="CustomCode">药品自定义码</param>
        /// <returns>成功返回药品数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryValidDrugByCustomCode(string CustomCode)
        {
            string strSelect = "";  //获得全部药品信息的SELECT语句
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetList.IfHaveValid", ref strWhere) == -1)
            {

                this.Err = "没有找到Pharmacy.Item.GetList.IfHaveValid字段!";
                return null;
            }
            try
            {
                strSelect = strSelect + strWhere;
                strSelect = string.Format(strSelect, CustomCode);
            }
            catch
            {
                this.Err = "SQL参数初始化失败";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetItem(strSelect);
        }

        /// <summary>
        /// 获得可用药品信息列表
        /// </summary>
        /// <returns>成功返回药品信息数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemAvailableList()
        {
            string strSelect = "";  //获得药品信息的SELECT语句
            string strWhere = "";  //获得可用药品信息的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAvailableList.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAvailableList.Where字段!";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetItemSimple(strSelect + " " + strWhere);
        }

        /// <summary>
        /// 获得可用科常用药品信息列表
        /// </summary>
        /// <returns>成功返回药科常用品信息数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemAvailableListDept(string dept)
        {
            string strSelect = "";  //获得药品信息的SELECT语句
            string strWhere = "";  //获得可用药品信息的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Fee.Item.GetDeptAlwaysUsedItemdrug", ref strSelect) == -1)
            {
                this.Err = "没有找到Fee.Item.GetDeptAlwaysUsedItemdrug字段!";
                return null;
            }
            //格式化SQL语句
            try
            {
                strSelect = string.Format(strSelect, dept);
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                return null;
            }


            //根据SQL语句取药品类数组并返回数组
            return this.myGetItemSimple(strSelect);
        }

        /// <summary>
        /// 获得可用药品信息列表
        /// 可以通过参数选择是否显示部分基本信息字段
        /// </summary>
        /// <param name="IsShowSimple">是否显示简单信息</param>
        /// <returns>成功返回药品信息数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemAvailableList(bool IsShowSimple)
        {
            string strSelect = "";  //获得药品信息的SELECT语句
            string strWhere = "";  //获得可用药品信息的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAvailableList.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAvailableList.Where字段!";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            if (IsShowSimple)
                return this.myGetItemSimple(strSelect + " " + strWhere);
            else
                return this.myGetItem(strSelect + " " + strWhere);
        }

        /// <summary>
        /// 获得可用药品信息列表
        /// </summary>
        /// <returns>成功返回药品信息 失败返回null</returns>
        public System.Data.DataSet QueryItemValidList()
        {
            string strSelect = "";  //获得药品信息的SELECT语句
            string strWhere = "";  //获得可用药品信息的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAvailableList.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAvailableList.Where字段!";
                return null;
            }

            System.Data.DataSet ds = new System.Data.DataSet();

            this.ExecQuery(strSelect + " " + strWhere, ref ds);

            if (ds == null || ds.Tables.Count <= 0)
                return null;
            else
                return ds;
        }

        /// <summary>
        /// 根据自定义码获取药品项目信息
        /// </summary>
        /// <param name="userCode">项目自定义码</param>
        /// <returns>成功返回药品项目实体 失败返回null</returns>
        public Neusoft.HISFC.Models.Pharmacy.Item GetItemByUserCode(string userCode)
        {
            Neusoft.HISFC.Models.Pharmacy.Item Item;
            List<Neusoft.HISFC.Models.Pharmacy.Item> alItem = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            string strSelect = "";  //获得药品信息的SELECT语句
            string strWhere = "";  //根据药品编码获得某一药品信息的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetItem.Where.UserCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetItem.Where.UserCode字段!";
                return null;
            }

            try
            {
                strWhere = string.Format(strWhere, userCode);
            }
            catch
            {
                return null;
            }

            //根据SQL语句取药品类数组并返回数组中的首条记录
            try
            {
                alItem = this.myGetItem(strSelect + " " + strWhere);
                Item = (Neusoft.HISFC.Models.Pharmacy.Item)alItem[0];
                return Item;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据最新一次核准入库信息更新字典表内相关信息
        /// </summary>
        /// <param name="input">入库信息实体</param>
        /// <returns>更新成功返回1 无记录返回0 出错返回-1</returns>
        public int UpdateItemInputInfo(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateItemInputInfo", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, input.Item.ID, input.Item.PriceCollection.PurchasePrice, input.Company.ID);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 对外提供

        /// <summary>
        /// 获取药品最新零售价
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="drugPrice">药品零售价</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int GetNowPrice(string drugCode, ref decimal drugPrice)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetNowPrice", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetNowPrice字段";
                return -1;
            }

            strSql = string.Format(strSql, drugCode);
            try
            {
                this.ExecQuery(strSql);
                if (this.Reader.Read())
                {
                    drugPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                this.Err = "获取最新药品零售价出错" + ex.Message;
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }
            return 1;
        }

        /// <summary>
        /// 根据药品编码获得某一药品信息
        /// </summary>
        /// <param name="ID">药品编码</param>
        /// <returns>成功返回药品实体 失败返回null</returns>
        public Neusoft.HISFC.Models.Pharmacy.Item GetItem(string ID)
        {
            Neusoft.HISFC.Models.Pharmacy.Item Item;
            List<Neusoft.HISFC.Models.Pharmacy.Item> alItem = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            string strSelect = "";  //获得药品信息的SELECT语句
            string strWhere = "";  //根据药品编码获得某一药品信息的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetItem.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetItem.Where字段!";
                return null;
            }

            try
            {
                strWhere = string.Format(strWhere, ID);
            }
            catch
            {
                return null;
            }

            //根据SQL语句取药品类数组并返回数组中的首条记录
            try
            {
                alItem = this.myGetItem(strSelect + " " + strWhere);
                //如果没有取到数据，则返回新实体
                Item = (Neusoft.HISFC.Models.Pharmacy.Item)alItem[0];
                return Item;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据药品编码和患者科室，获取住院医嘱、收费使用的药品数据
        /// </summary>
        /// <param name="deptCode">患者科室</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>药品库存实体 返回Null 发生错误 返回空实体 药房无该药品或库存为零</returns>
        [Obsolete("重构整合 更改返回值类型为Storage", false)]
        public Neusoft.HISFC.Models.Pharmacy.Storage GetItemForInpatient(string deptCode, string drugCode)
        {
            #region 根据索引获取Sql语句

            string SQLString = "";  //获得药品信息的SELECT语句
            string strWhere = "";   //获得药品信息的where语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAvailableList.Inpatient", ref SQLString) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAvailableList.Inpatient字段!";
                return null;
            }

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAvailableList.Inpatient.ByDrugCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAvailableList.Inpatient.ByDrugCode字段!";
                return null;
            }

            #endregion

            SQLString = string.Format(SQLString + " " + strWhere, deptCode, drugCode);

            //根据SQL语句取药品类数组并返回数组
            //Neusoft.HISFC.Models.Pharmacy.Item Item = new Neusoft.HISFC.Models.Pharmacy.Item( ); //返回数组中的药品信息类
            Neusoft.HISFC.Models.Pharmacy.Storage storage = new Storage();

            try
            {
                this.ExecQuery(SQLString);

                if (this.Reader.Read())
                {
                    storage.Item.ID = this.Reader[0].ToString();                               //0  药品编码
                    storage.Item.Name = this.Reader[1].ToString();                                //1  商品名称
                    storage.Item.PackQty = NConvert.ToDecimal(this.Reader[2].ToString());         //2  包装数量
                    storage.Item.Specs = this.Reader[3].ToString();                               //3  规格
                    storage.Item.MinFee.ID = this.Reader[4].ToString();                           //4  最小费用代码
                    storage.Item.SysClass.ID = this.Reader[5].ToString();                         //5  系统类别
                    storage.Item.PackUnit = this.Reader[6].ToString();                            //6  包装单位
                    storage.Item.MinUnit = this.Reader[7].ToString();                             //7  最小单位
                    storage.Item.Type.ID = this.Reader[8].ToString();                             //8  药品类别编码
                    storage.Item.Quality.ID = this.Reader[9].ToString();                          //9  药品性质编码
                    storage.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[10].ToString());    //10 零售价
                    storage.Item.Product.Producer.ID = this.Reader[11].ToString();                //11 生产厂家编码
                    storage.Item.SpellCode = this.Reader[12].ToString();                          //12 拼音码  
                    storage.Item.WBCode = this.Reader[13].ToString();                             //13 五笔码
                    storage.Item.UserCode = this.Reader[14].ToString();                           //14 自定义码
                    storage.Item.NameCollection.RegularName = this.Reader[15].ToString();         //15 药品通用名
                    storage.Item.NameCollection.RegularSpell.SpellCode = this.Reader[16].ToString();        //16 通用名拼音码
                    storage.Item.NameCollection.RegularSpell.WBCode = this.Reader[17].ToString(); //17 通用名五笔码
                    storage.Item.NameCollection.OtherSpell.SpellCode = this.Reader[18].ToString();//18 别名拼音码
                    storage.Item.NameCollection.EnglishName = this.Reader[19].ToString();         //19 英文商品名 

                    //storage.Item.User01 = this.Reader[20].ToString();                            //20 库存可用数量
                    //storage.Item.User02 = this.Reader[21].ToString();                            //21 药房编码
                    storage.StoreQty = NConvert.ToDecimal(this.Reader[20].ToString());
                    storage.StockDept.ID = this.Reader[21].ToString();

                    storage.Item.DoseUnit = this.Reader[22].ToString();                            //22 剂量单位
                    storage.Item.BaseDose = NConvert.ToDecimal(this.Reader[23].ToString());        //23 基本剂量
                    storage.Item.DosageForm.ID = this.Reader[24].ToString();					   //24 剂型编码
                    storage.Item.Usage.ID = this.Reader[25].ToString();							   //25 用法编码
                    storage.Item.Frequency.ID = this.Reader[26].ToString();						   //26 频次编码	
                    storage.Item.Grade = this.Reader[27].ToString();						       //27 药品等级：甲乙类
                    storage.Item.SpecialFlag = this.Reader[28].ToString();						   //28 省限
                    storage.Item.SpecialFlag1 = this.Reader[29].ToString();						   //29 市限	
                    storage.Item.SpecialFlag2 = this.Reader[30].ToString();					   //30 自费	
                    storage.Item.SpecialFlag3 = this.Reader[31].ToString();						   //31 特殊项目	

                    if (this.Reader.FieldCount > 32)
                    {
                        storage.Item.SplitType = this.Reader[32].ToString();//门诊可拆分属性
                    }
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得药品库存信息时，执行SQL语句出错！" + ex.Message;
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return storage;
        }

        /// <summary>
        /// 获取门诊医嘱、收费使用的药品数据
        /// </summary>
        /// <param name="deptCode">取药病区</param>
        /// <returns>成功返回药品数组 失败返回null</returns>
        public ArrayList QueryItemAvailableListForClinic(string deptCode)
        {
            string SQLString = "";  //获得药品信息的SELECT语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAvailableList.OutPatient", ref SQLString) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAvailableList.OutPatient字段!";
                return null;
            }

            SQLString = string.Format(SQLString, deptCode);
            //根据SQL语句取药品类数组并返回数组
            Neusoft.HISFC.Models.Pharmacy.Item Item; //返回数组中的药品信息类
            ArrayList al = new ArrayList();

            try
            {
                this.ExecQuery(SQLString);

                while (this.Reader.Read())
                {
                    Item = new Neusoft.HISFC.Models.Pharmacy.Item();

                    Item.ID = this.Reader[0].ToString();                                  //0  药品编码
                    Item.Name = this.Reader[1].ToString();                                //1  商品名称
                    Item.PackQty = NConvert.ToDecimal(this.Reader[2].ToString());         //2  包装数量
                    Item.Specs = this.Reader[3].ToString();                               //3  规格
                    Item.MinFee.ID = this.Reader[4].ToString();                           //4  最小费用代码
                    Item.SysClass.ID = this.Reader[5].ToString();                         //5  系统类别
                    Item.PackUnit = this.Reader[6].ToString();                            //6  包装单位
                    Item.MinUnit = this.Reader[7].ToString();                             //7  最小单位
                    Item.Type.ID = this.Reader[8].ToString();                             //8  药品类别编码
                    Item.Quality.ID = this.Reader[9].ToString();                          //9  药品性质编码
                    Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[10].ToString());    //10 零售价
                    Item.Product.Producer.ID = this.Reader[11].ToString();                        //11 生产厂家编码
                    Item.SpellCode = this.Reader[12].ToString();                         //12 拼音码  
                    Item.WBCode = this.Reader[13].ToString();                            //13 五笔码
                    Item.UserCode = this.Reader[14].ToString();                          //14 自定义码
                    Item.NameCollection.RegularName = this.Reader[15].ToString();                        //15 药品通用名
                    Item.NameCollection.RegularSpell.SpellCode = this.Reader[16].ToString();        //16 通用名拼音码
                    Item.NameCollection.RegularSpell.WBCode = this.Reader[17].ToString();           //17 通用名五笔码
                    Item.NameCollection.OtherSpell.SpellCode = this.Reader[18].ToString();          //18 别名拼音码
                    Item.NameCollection.EnglishName = this.Reader[19].ToString();                        //19 英文商品名 
                    Item.User01 = this.Reader[20].ToString();                             //20 库存可用数量
                    Item.User02 = this.Reader[21].ToString();                             //21 药房编码
                    Item.DoseUnit = this.Reader[22].ToString();                           //22 剂量单位
                    Item.BaseDose = NConvert.ToDecimal(this.Reader[23].ToString());       //23 基本剂量
                    Item.DosageForm.ID = this.Reader[24].ToString();					  //24 剂型编码
                    Item.Usage.ID = this.Reader[25].ToString();							  //25 用法编码
                    Item.Frequency.ID = this.Reader[26].ToString();						  //26 频次编码
                    //Item.Grade = this.Reader[27].ToString();						      //27 药品等级：甲乙类
                    Item.SpecialFlag = this.Reader[28].ToString();						  //28 省限
                    Item.SpecialFlag1 = this.Reader[29].ToString();						  //29 市限	
                    Item.SpecialFlag2 = this.Reader[30].ToString();						  //30 自费	
                    Item.SpecialFlag3 = this.Reader[31].ToString();						  //31 特殊项目	
                    Item.PhyFunction1.ID = this.Reader[32].ToString();                       //32 药理作用		

                    al.Add(Item);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获得药品基本信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获取科常用的药品数据
        /// </summary>
        /// <param name="deptCode">取药病区</param>
        /// <returns>成功返回药品数组 失败返回null</returns>
        public ArrayList QueryDeptAlwaysUsedItem(string deptCode)
        {
            string SQLString = "";  //获得药品信息的SELECT语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDeptAlwaysUsedDurg", ref SQLString) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDeptAlwaysUsedDurg字段!";
                return null;
            }

            SQLString = string.Format(SQLString, deptCode);
            //根据SQL语句取药品类数组并返回数组
            Neusoft.HISFC.Models.Pharmacy.Item Item; //返回数组中的药品信息类
            ArrayList al = new ArrayList();

            try
            {
                this.ExecQuery(SQLString);

                while (this.Reader.Read())
                {
                    Item = new Neusoft.HISFC.Models.Pharmacy.Item();

                    Item.ID = this.Reader[0].ToString();                                  //0  药品编码
                    Item.Name = this.Reader[1].ToString();                                //1  商品名称
                    Item.PackQty = NConvert.ToDecimal(this.Reader[2].ToString());         //2  包装数量
                    Item.Specs = this.Reader[3].ToString();                               //3  规格
                    Item.MinFee.ID = this.Reader[4].ToString();                           //4  最小费用代码
                    Item.SysClass.ID = this.Reader[5].ToString();                         //5  系统类别
                    Item.PackUnit = this.Reader[6].ToString();                            //6  包装单位
                    Item.MinUnit = this.Reader[7].ToString();                             //7  最小单位
                    Item.Type.ID = this.Reader[8].ToString();                             //8  药品类别编码
                    Item.Quality.ID = this.Reader[9].ToString();                          //9  药品性质编码
                    Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[10].ToString());    //10 零售价
                    Item.Product.Producer.ID = this.Reader[11].ToString();                        //11 生产厂家编码
                    Item.SpellCode = this.Reader[12].ToString();                         //12 拼音码  
                    Item.WBCode = this.Reader[13].ToString();                            //13 五笔码
                    Item.UserCode = this.Reader[14].ToString();                          //14 自定义码
                    Item.NameCollection.RegularName = this.Reader[15].ToString();                        //15 药品通用名
                    Item.NameCollection.RegularSpell.SpellCode = this.Reader[16].ToString();        //16 通用名拼音码
                    Item.NameCollection.RegularSpell.WBCode = this.Reader[17].ToString();           //17 通用名五笔码
                    Item.NameCollection.OtherSpell.SpellCode = this.Reader[18].ToString();          //18 别名拼音码
                    Item.NameCollection.EnglishName = this.Reader[19].ToString();                        //19 英文商品名 
                    Item.User01 = this.Reader[20].ToString();                             //20 库存可用数量
                    Item.User02 = this.Reader[21].ToString();                             //21 药房编码
                    Item.DoseUnit = this.Reader[22].ToString();                           //22 剂量单位
                    Item.BaseDose = NConvert.ToDecimal(this.Reader[23].ToString());       //23 基本剂量
                    Item.DosageForm.ID = this.Reader[24].ToString();					  //24 剂型编码
                    Item.Usage.ID = this.Reader[25].ToString();							  //25 用法编码
                    Item.Frequency.ID = this.Reader[26].ToString();						  //26 频次编码
                    //Item.Grade = this.Reader[27].ToString();						      //27 药品等级：甲乙类
                    Item.SpecialFlag = this.Reader[28].ToString();						  //28 省限
                    Item.SpecialFlag1 = this.Reader[29].ToString();						  //29 市限	
                    Item.SpecialFlag2 = this.Reader[30].ToString();						  //30 自费	
                    Item.SpecialFlag3 = this.Reader[31].ToString();						  //31 特殊项目	

                    al.Add(Item);
                }
                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得药品基本信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获取住院医嘱、收费使用的药品数据
        /// </summary>
        /// <param name="deptCode">取药病区</param>
        /// <returns>成功返回药品数组 失败返回null</returns>
        public ArrayList QueryItemAvailableList(string deptCode)
        {
            string SQLString = "";  //获得药品信息的SELECT语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAvailableList.Inpatient", ref SQLString) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAvailableList.Inpatient字段!";
                return null;
            }

            SQLString = string.Format(SQLString, deptCode);
            //根据SQL语句取药品类数组并返回数组
            Neusoft.HISFC.Models.Pharmacy.Item Item; //返回数组中的药品信息类

            ArrayList al = new ArrayList();

            try
            {
                this.ExecQuery(SQLString);

                while (this.Reader.Read())
                {
                    Item = new Neusoft.HISFC.Models.Pharmacy.Item();

                    Item.ID = this.Reader[0].ToString();                                  //0  药品编码
                    Item.Name = this.Reader[1].ToString();                                //1  商品名称
                    Item.PackQty = NConvert.ToDecimal(this.Reader[2].ToString());         //2  包装数量
                    Item.Specs = this.Reader[3].ToString();                               //3  规格
                    Item.MinFee.ID = this.Reader[4].ToString();                           //4  最小费用代码
                    Item.SysClass.ID = this.Reader[5].ToString();                         //5  系统类别
                    Item.PackUnit = this.Reader[6].ToString();                            //6  包装单位
                    Item.MinUnit = this.Reader[7].ToString();                             //7  最小单位
                    Item.Type.ID = this.Reader[8].ToString();                             //8  药品类别编码
                    Item.Quality.ID = this.Reader[9].ToString();                          //9  药品性质编码
                    Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[10].ToString());    //10 零售价
                    Item.Product.Producer.ID = this.Reader[11].ToString();                        //11 生产厂家编码
                    Item.SpellCode = this.Reader[12].ToString();                         //12 拼音码  
                    Item.WBCode = this.Reader[13].ToString();                            //13 五笔码
                    Item.UserCode = this.Reader[14].ToString();                          //14 自定义码
                    Item.NameCollection.RegularName = this.Reader[15].ToString();                        //15 药品通用名
                    Item.NameCollection.RegularSpell.SpellCode = this.Reader[16].ToString();        //16 通用名拼音码
                    Item.NameCollection.RegularSpell.WBCode = this.Reader[17].ToString();           //17 通用名五笔码
                    Item.NameCollection.OtherSpell.SpellCode = this.Reader[18].ToString();          //18 别名拼音码
                    Item.NameCollection.EnglishName = this.Reader[19].ToString();                        //19 英文商品名 
                    Item.User01 = this.Reader[20].ToString();                             //20 库存可用数量
                    Item.User02 = this.Reader[21].ToString();                             //21 药房编码
                    Item.DoseUnit = this.Reader[22].ToString();                           //22 剂量单位
                    Item.BaseDose = NConvert.ToDecimal(this.Reader[23].ToString());       //23 基本剂量
                    Item.DosageForm.ID = this.Reader[24].ToString();					  //24 剂型编码
                    Item.Usage.ID = this.Reader[25].ToString();							  //25 用法编码
                    Item.Frequency.ID = this.Reader[26].ToString();						  //26 频次编码
                    //Item.Grade = this.Reader[27].ToString();						      //27 药品等级：甲乙类
                    Item.SpecialFlag = this.Reader[28].ToString();						  //28 省限
                    Item.SpecialFlag1 = this.Reader[29].ToString();						  //29 市限	
                    Item.SpecialFlag2 = this.Reader[30].ToString();						  //30 自费	
                    Item.SpecialFlag3 = this.Reader[31].ToString();						  //31 特殊项目	

                    al.Add(Item);
                }
                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得药品基本信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获取住院医嘱、收费使用的某一类别的药品数据
        /// </summary>
        /// <param name="deptCode">取药病区</param>
        /// <param name="drugType">药品类别 传入ALL获取全部药品类别</param>
        /// <returns>成功返回药品列表 失败返回null</returns>
        public ArrayList QueryItemAvailableList(string deptCode, string drugType)
        {
            string SQLString = "";  //获得药品信息的SELECT语句
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAvailableList.Inpatient", ref SQLString) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAvailableList.Inpatient字段!";
                return null;
            }
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAvailableList.Inpatient.ByDrugType", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAvailableList.Inpatient.ByDrugType字段!";
                return null;
            }
            SQLString = string.Format(SQLString + " " + strWhere, deptCode, drugType);
            //根据SQL语句取药品类数组并返回数组
            Neusoft.HISFC.Models.Pharmacy.Item Item; //返回数组中的药品信息类

            ArrayList al = new ArrayList();
            try
            {
                this.ExecQuery(SQLString);

                while (this.Reader.Read())
                {
                    Item = new Neusoft.HISFC.Models.Pharmacy.Item();

                    Item.ID = this.Reader[0].ToString();                                  //0  药品编码
                    Item.Name = this.Reader[1].ToString();                                //1  商品名称
                    Item.PackQty = NConvert.ToDecimal(this.Reader[2].ToString());         //2  包装数量
                    Item.Specs = this.Reader[3].ToString();                               //3  规格
                    Item.MinFee.ID = this.Reader[4].ToString();                           //4  最小费用代码
                    Item.SysClass.ID = this.Reader[5].ToString();                         //5  系统类别
                    Item.PackUnit = this.Reader[6].ToString();                            //6  包装单位
                    Item.MinUnit = this.Reader[7].ToString();                             //7  最小单位
                    Item.Type.ID = this.Reader[8].ToString();                             //8  药品类别编码
                    Item.Quality.ID = this.Reader[9].ToString();                          //9  药品性质编码
                    Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[10].ToString());    //10 零售价
                    Item.Product.Producer.ID = this.Reader[11].ToString();                        //11 生产厂家编码
                    Item.SpellCode = this.Reader[12].ToString();                         //12 拼音码  
                    Item.WBCode = this.Reader[13].ToString();                            //13 五笔码
                    Item.UserCode = this.Reader[14].ToString();                          //14 自定义码
                    Item.NameCollection.RegularName = this.Reader[15].ToString();                        //15 药品通用名
                    Item.NameCollection.RegularSpell.SpellCode = this.Reader[16].ToString();        //16 通用名拼音码
                    Item.NameCollection.RegularSpell.WBCode = this.Reader[17].ToString();           //17 通用名五笔码
                    Item.NameCollection.RegularSpell.UserCode = this.Reader[18].ToString();         //18 通用名自定义码
                    Item.NameCollection.EnglishName = this.Reader[19].ToString();                        //19 英文商品名 
                    Item.User01 = this.Reader[20].ToString();                             //20 库存可用数量
                    Item.User02 = this.Reader[21].ToString();                             //21 药房编码
                    Item.DoseUnit = this.Reader[22].ToString();                           //22 剂量单位
                    Item.BaseDose = NConvert.ToDecimal(this.Reader[23].ToString());       //23 基本剂量
                    Item.DosageForm.ID = this.Reader[24].ToString();					  //24 剂型编码
                    Item.Usage.ID = this.Reader[25].ToString();							  //25 用法编码
                    Item.Frequency.ID = this.Reader[26].ToString();						  //26 频次编码
                    //Item.Grade = this.Reader[27].ToString();						      //27 药品等级：甲乙类
                    Item.SpecialFlag = this.Reader[28].ToString();						  //28 省限
                    Item.SpecialFlag1 = this.Reader[29].ToString();						  //29 市限	
                    Item.SpecialFlag2 = this.Reader[30].ToString();						  //30 自费	
                    Item.SpecialFlag3 = this.Reader[31].ToString();						  //31 特殊项目	

                    al.Add(Item);
                }
                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得药品基本信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        #endregion

        #endregion

        #region 入库申请表操作

        #region 基础增、删、改操作

        /// <summary>
        /// 获取入库申请数据
        /// </summary>
        /// <param name="strSql">执行的SQL语句</param>
        /// <returns>成功返回Input数组 失败返回null</returns>
        private ArrayList myGetApplyIn(string strSql)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Input applyIn;

            //执行查询语句
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "获得入库申请明细信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    applyIn = new Input();

                    applyIn.ID = this.Reader[0].ToString();										//0 申请流水号
                    applyIn.StockDept.ID = this.Reader[1].ToString();								//1 申请科室 管理库存的科室					
                    applyIn.InListNO = this.Reader[2].ToString();								//2 申请单据号
                    applyIn.Item.ID = this.Reader[3].ToString();								//3 药品编码
                    applyIn.Item.Name = this.Reader[4].ToString();								//4 药品商品名
                    applyIn.Item.Type.ID = this.Reader[5].ToString();							//5 药品类别
                    applyIn.Item.Quality.ID = this.Reader[6].ToString();						//6 药品性质
                    applyIn.Item.Specs = this.Reader[7].ToString();								//7 规格
                    applyIn.Item.PackUnit = this.Reader[8].ToString();							//8 包装单位
                    applyIn.Item.PackQty = NConvert.ToDecimal(this.Reader[9].ToString());		//9 包装数量
                    applyIn.Item.MinUnit = this.Reader[10].ToString();							//10 最小单位
                    applyIn.ShowState = this.Reader[11].ToString();								//11 显示单位标记
                    applyIn.ShowUnit = this.Reader[12].ToString();								//12 显示单位
                    applyIn.BatchNO = this.Reader[13].ToString();								//13 批号
                    applyIn.ValidTime = NConvert.ToDateTime(this.Reader[14].ToString());		//14 有效期
                    applyIn.Producer.ID = this.Reader[15].ToString();							//15 生产厂家
                    applyIn.Company.ID = this.Reader[16].ToString();							//16 供货单位
                    applyIn.TargetDept.ID = applyIn.Company.ID;
                    applyIn.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[17].ToString());	//17 零售价
                    applyIn.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[18].ToString());	//18 批发价
                    applyIn.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[19].ToString());	//19 购入价
                    applyIn.RetailCost = NConvert.ToDecimal(this.Reader[20].ToString());		//20 零售金额
                    applyIn.WholeSaleCost = NConvert.ToDecimal(this.Reader[21].ToString());		//21 批发金额
                    applyIn.PurchaseCost = NConvert.ToDecimal(this.Reader[22].ToString());		//22 购入金额
                    applyIn.Operation.ApplyOper.ID = this.Reader[23].ToString();							//23 申请人
                    applyIn.Operation.ApplyOper.OperTime = NConvert.ToDateTime(this.Reader[24].ToString());	    //24 申请日期
                    applyIn.State = this.Reader[25].ToString();									//25 入库状态0 申请 1 审批 2 核准
                    applyIn.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[26].ToString());			//26 申请数量					
                    applyIn.Operation.ExamQty = NConvert.ToDecimal(this.Reader[27].ToString());			//27 入库数量
                    applyIn.Operation.ExamOper.ID = this.Reader[28].ToString();							//28 入库人
                    applyIn.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[29].ToString());			//29 入库日期
                    applyIn.PlaceNO = this.Reader[30].ToString();								//30 货位号
                    applyIn.MedNO = this.Reader[31].ToString();									//31 制剂序号
                    applyIn.InvoiceNO = this.Reader[32].ToString();								//32 发票号
                    applyIn.DeliveryNO = this.Reader[33].ToString();							//33 送货单号
                    applyIn.TenderNO = this.Reader[34].ToString();								//34 招标单序号
                    applyIn.ActualRate = NConvert.ToDecimal(this.Reader[35].ToString());		//35 实际扣率
                    applyIn.Operation.Oper.ID = this.Reader[36].ToString();								//36 操作员
                    applyIn.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[37].ToString());			//37 操作时间
                    applyIn.Memo = this.Reader[38].ToString();									//38 备注
                    applyIn.User01 = this.Reader[39].ToString();								//39 扩展字段
                    applyIn.User02 = this.Reader[40].ToString();								//40 扩展字段1
                    applyIn.User03 = this.Reader[41].ToString();								//41 扩展字段2

                    al.Add(applyIn);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获取入库申请明细信息时出错" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 获得update或者insert入库申请表的传入参数数组
        /// </summary>
        /// <param name="applyIn">入库申请类</param>
        /// <returns>成功返回字符串数组 失败返回null</returns>
        private string[] myGetParmApplyIn(Neusoft.HISFC.Models.Pharmacy.Input applyIn)
        {
            try
            {
                //获取统计金额
                if (applyIn.Item.PackQty == 0)
                    applyIn.Item.PackQty = 1;
                decimal retailCost = applyIn.Operation.ApplyQty / applyIn.Item.PackQty * applyIn.Item.PriceCollection.RetailPrice;
                decimal wholesaleCost = applyIn.Operation.ApplyQty / applyIn.Item.PackQty * applyIn.Item.PriceCollection.WholeSalePrice;
                decimal purchaseCost = applyIn.Operation.ApplyQty / applyIn.Item.PackQty * applyIn.Item.PriceCollection.PurchasePrice;
                string[] strParm ={
									 applyIn.ID,									//0 申请流水号
									 applyIn.StockDept.ID,								//1 申请科室 管理库存的科室									 
									 applyIn.InListNO,							//2 申请单据号
									 applyIn.Item.ID,								//3 药品编码
									 applyIn.Item.Name,								//4 药品商品名
									 applyIn.Item.Type.ID,							//5 药品类别
									 applyIn.Item.Quality.ID.ToString(),			//6 药品性质
									 applyIn.Item.Specs,							//7 规格
									 applyIn.Item.PackUnit,							//8 包装单位
									 applyIn.Item.PackQty.ToString(),				//9 包装数量
									 applyIn.Item.MinUnit,							//10 最小单位
									 applyIn.ShowState,								//11 显示单位标记
									 applyIn.ShowUnit,								//12 显示单位
									 applyIn.BatchNO,								//13 批号
									 applyIn.ValidTime.ToString(),					//14 有效期
									 applyIn.Producer.ID,							//15 生产厂家
									 applyIn.Company.ID,							//16 供货单位
									 applyIn.Item.PriceCollection.RetailPrice.ToString(),			//17 零售价
									 applyIn.Item.PriceCollection.WholeSalePrice.ToString(),		//18 批发价
									 applyIn.Item.PriceCollection.PurchasePrice.ToString(),			//19 购入价
									 System.Math.Round(retailCost,2).ToString(),	//20 零售金额
									 System.Math.Round(wholesaleCost,2).ToString(),	//21 批发金额
									 System.Math.Round(purchaseCost,2).ToString(),	//22 购入金额
									 applyIn.Operation.ApplyOper.ID,							//23 申请人
									 applyIn.Operation.ApplyOper.OperTime.ToString(),					//24 申请日期
									 applyIn.State,									//25 申请状态0 申请 1 审批 2 核准
									 applyIn.Operation.ApplyQty.ToString(),					//26 申请数量
									 applyIn.Operation.ExamQty.ToString(),					//27 入库数量
									 applyIn.Operation.ExamOper.ID,							//28 入库人
									 applyIn.Operation.ExamOper.OperTime.ToString(),					//29 入库日期
									 applyIn.PlaceNO,								//30 货位号
									 applyIn.MedNO,									//31 制剂序号
									 applyIn.InvoiceNO,								//32 发票号
									 applyIn.DeliveryNO,							//33 送货单号
									 applyIn.TenderNO,								//34 招标单序号
									 applyIn.ActualRate.ToString(),					//35 实际扣率
									 this.Operator.ID,								//36 操作员
									 //操作时间 由SQL取得
									 applyIn.Memo,									//37 备注
									 applyIn.User01,								//38 扩展字段
									 applyIn.User02,								//39 扩展字段1
									 applyIn.User03									//40 扩展字段2
								 };

                return strParm;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 插入一条入库申请记录
        /// </summary>
        /// <param name="applyIn">申请入库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertApplyIn(Neusoft.HISFC.Models.Pharmacy.Input applyIn)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertApplyIn", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = myGetParmApplyIn(applyIn);    //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "插入入库申请SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新入库申请记录
        /// </summary>
        /// <param name="applyIn">入库申请记录</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateApplyIn(Neusoft.HISFC.Models.Pharmacy.Input applyIn)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyIn", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = myGetParmApplyIn(applyIn);	  //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新入库申请SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除入库申请记录
        /// </summary>
        /// <param name="ID">入库申请记录流水号</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int DeleteApplyIn(string ID)
        {
            string strSQL = "";
            //根据入库申请流水号删除某一条入库申请记录的DELETE语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteApplyIn", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, ID);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.DeleteApplyIn";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 内部使用

        /// <summary>
        /// 取某一申请科室未被核准的申请列表	
        /// </summary>
        /// <param name="applyDept">申请科室</param>
        /// <param name="targetDept">被申请科室 目标科室 AAAA 查询全部</param>
        /// <param name="state">单据状态</param>
        /// <returns>成功返回申请单据列表 失败返回null</returns>
        public ArrayList QueryApplyInList(string applyDept, string targetDept, string state)
        {
            string strSelect = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyInList.ApplyDept", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyInList.ApplyDept字段!";
                return null;
            }
            try
            {
                string[] strParm = { applyDept, targetDept, state };
                strSelect = string.Format(strSelect, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            //执行查询语句
            if (this.ExecQuery(strSelect) == -1)
            {
                this.Err = "获得入库申请单据列表信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            ArrayList al = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.Input input;
                while (this.Reader.Read())
                {
                    //单据号、供货单位科室、供货单位名称、送货单流水号、操作时间
                    input = new Input();
                    input.ID = this.Reader[0].ToString();			//申请单据号
                    input.Name = this.Reader[1].ToString();			//供货单位名称
                    input.Memo = this.Reader[2].ToString();			//供货单位编码					
                    input.User01 = this.Reader[3].ToString();		//送货单号
                    //操作时间  只取日期
                    input.User02 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString()).Date.ToString();

                    al.Add(input);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获取入库申请单据信息时失败" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 获取指定科室、指定状态的外部申请信息
        /// </summary>
        /// <param name="deptCode">申请科室</param>
        /// <param name="listCode">单据号</param>
        /// <param name="state">状态</param>
        /// <returns>成功返回实体 失败返回null 无数据返回空实体</returns>
        public ArrayList QueryApplyIn(string deptCode, string listCode, string state)
        {
            string strSelect = "";
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyIn", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyIn字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyIn.DeptListCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyIn.DeptListCode字段!";
                return null;
            }

            try
            {
                string[] strParm = { deptCode, listCode, state };
                strSelect = string.Format(strSelect + " " + strWhere, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyIn(strSelect);
        }

        /// <summary>
        /// 外部申请入库 先进行更新操作 更新不成功则进行插入操作
        /// </summary>
        /// <returns>成功返回受影响数据条目数 失败返回null</returns>
        public int SetApplyIn(Neusoft.HISFC.Models.Pharmacy.Input applyIn)
        {
            if (applyIn.ID == "")
            {
                return this.InsertApplyIn(applyIn);
            }
            int parm;
            parm = this.UpdateApplyIn(applyIn);
            if (parm == -1)
                return parm;
            if (parm == 0)
            {
                parm = this.InsertApplyIn(applyIn);
            }
            return parm;
        }

        /// <summary>
        /// 申请核准
        /// 对外部入库申请来说 一般入库时进行调用 更新状态为 2 
        /// </summary>
        /// <param name="applyIn">入库申请记录</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int ApproveApplyIn(Neusoft.HISFC.Models.Pharmacy.Input applyIn)
        {
            string strSQL = "";
            //核准入库申请单信息，更新申请状态，核准数量，核准人，核准日期
            if (this.Sql.GetSql("Pharmacy.Item.ApproveApplyIn", ref strSQL) == -1) return -1;
            try
            {
                //取参数列表
                string[] strParm = {
									   applyIn.ID,
									   applyIn.Operation.ExamQty.ToString(),
									   applyIn.Operation.ExamOper.ID,
									   applyIn.Operation.ExamOper.OperTime.ToString()
								   };


                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新入库申请SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #endregion

        #region 入库操作

        #region 基础增、删、改操作

        /// <summary>
        /// 获得update或者insert入库就表的传入参数数组
        /// </summary>
        /// <param name="input">入库记录类</param>
        /// <returns>成功返回字符串数组 失败返回null</returns>
        protected string[] myGetParmInput(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            try
            {

                //获取统计金额
                if (input.Item.PackQty == 0)
                    input.Item.PackQty = 1;
                decimal retailCost = input.Quantity / input.Item.PackQty * input.Item.PriceCollection.RetailPrice;
                decimal wholesaleCost = input.Quantity / input.Item.PackQty * input.Item.PriceCollection.WholeSalePrice;
                decimal purchaseCost = input.Quantity / input.Item.PackQty * input.Item.PriceCollection.PurchasePrice;

                string isTenderOffer="0";
                if(input.Item.TenderOffer.IsTenderOffer==true)
                {
                    isTenderOffer="1";
                }
                else
                {
                    isTenderOffer="0";
                }
                string[] strParm ={
									 input.StockDept.ID,								//0 申请科室 管理库存的科室
									 input.ID,									//1 入库流水号
									 input.SerialNO.ToString(),					//2 单内序号
									 input.GroupNO.ToString(),					//3 批次号
									 input.InListNO,							//4 入库单据号
									 input.PrivType,							//6 入库分类  0310
									 input.SystemType,							//5 入库类型  三级权限码一般入库 特殊入库等
									 input.OutBillNO,							//7 出库单流水号
									 input.OutSerialNO.ToString(),				//8 出库单内序号
									 input.OutListNO,							//9 出库单据号
									 input.Item.ID,								//10 药品编码
									 input.Item.Name,							//11 药品商品名
									 input.Item.Type.ID,						//12 药品类别
									 input.Item.Quality.ID.ToString(),			//13 药品性质
									 input.Item.Specs,							//14 规格
									 input.Item.PackUnit,						//15 包装单位
									 input.Item.PackQty.ToString(),				//16 包装数量
									 input.Item.MinUnit,						//17 最小单位
									 input.ShowState,							//18 显示单位标记
									 input.ShowUnit,							//19 显示单位
									 input.BatchNO,								//20 批号
									 input.ValidTime.ToString(),				//21 有效期
									 input.Producer.ID,							//22 生产厂家
									 input.Company.ID,							//23 供货单位
									 input.Item.PriceCollection.RetailPrice.ToString(),			//24 零售价
									 input.Item.PriceCollection.WholeSalePrice.ToString(),		//25 批发价
									 input.Item.PriceCollection.PurchasePrice.ToString(),		//26 购入价
									 input.Quantity.ToString(),					//27 入库数量
                                     //不再进行舍入，保持与myGetParmOutput一致，避免出库与入库金额不等{2C227FDD-4B0A-4a0a-9F98-40B51BCD9F10}
                                     //System.Math.Round(retailCost,2).ToString(),//28 零售金额
                                     //System.Math.Round(wholesaleCost,2).ToString(),	//29 批发金额
                                     //System.Math.Round(purchaseCost,2).ToString(),	//30 购入金额
                                     retailCost.ToString(),//28 零售金额
                                     wholesaleCost.ToString(),	//29 批发金额
                                     purchaseCost.ToString(),	//30 购入金额

									 input.StoreQty.ToString(),					//31 入库后库存数量
									 input.StoreCost.ToString(),				//32 入库后库存金额
									 input.SpecialFlag,							//33 特殊标记 1 是 0 否
									 input.State,								//34 入库状态0 申请 1 审批 2 核准
									 input.Operation.ApplyQty.ToString(),					//35 申请数量
									 input.Operation.ApplyOper.ID,						//36 申请人
									 input.Operation.ApplyOper.OperTime.ToString(),			    //37 申请日期
									 input.Operation.ExamQty.ToString(),					//38 审批数量
									 input.Operation.ExamOper.ID,						//39 审核人
									 input.Operation.ExamOper.OperTime.ToString(),					//40 审核日期
									 input.Operation.ApproveOper.ID,						//41 核准人
									 input.Operation.ApproveOper.OperTime.ToString(),				//42 核准日期
									 input.PlaceNO,							//43 货位号
									 input.Operation.ReturnQty.ToString(),				//44 退库数量
									 input.MedNO,								//45 制剂序号
									 input.InvoiceNO,							//46 发票号
									 input.DeliveryNO,							//47 送货单号
									 input.TenderNO,							//48 招标单序号
									 input.ActualRate.ToString(),				//49 实际扣率
									 input.CashFlag,							//50 扣现金标志
									 input.PayState,							//51 供货商结存状态
									 this.Operator.ID,							//52 操作员
									 //操作时间 由SQL取得
									 input.Memo,								//53 备注
									 input.User01,								//54 扩展字段1
									 input.User02,								//55 扩展字段2
									 input.User03,								//56 扩展字段3
                                     isTenderOffer,                             //57招标标记{D28CC3CF-C502-4987-BC01-1AEBF2F9D17F} sel 增加下面三个字段的插入
                                     input.CommonPurchasePrice.ToString(),      //58一般入库时的购入价
                                     input.InvoiceDate.ToString(),               //59发票上的发票时间
                                     input.InDate.ToString(),                   //{24E12384-34F7-40c1-8E2A-3967CECAF615} 增加入库时间、供货单位类型字段
                                     input.SourceCompanyType
								 };

                return strParm;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取入库数据
        /// </summary>
        /// <param name="strSQL">执行的SQL语句</param>
        /// <returns>成功返回Input数组 失败返回null</returns>
        protected ArrayList myGetInput(string strSQL)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Input input;

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得入库明细信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    input = new Input();

                    input.StockDept.ID = this.Reader[0].ToString();								//0 申请科室 管理库存的科室
                    input.ID = this.Reader[1].ToString();									//1 入库流水号
                    input.SerialNO = NConvert.ToInt32(this.Reader[2].ToString());			//2 单内序号
                    input.GroupNO = NConvert.ToDecimal(this.Reader[3].ToString());			//3 批次号
                    input.InListNO = this.Reader[4].ToString();							//4 入库单据号
                    input.PrivType = this.Reader[5].ToString();								//6 入库分类 0310
                    input.SystemType = this.Reader[6].ToString();							//5 系统类型 三级权限码
                    input.OutBillNO = this.Reader[7].ToString();							//7 出库单流水号
                    input.OutSerialNO = NConvert.ToInt32(this.Reader[8].ToString());		//8 出库单内序号
                    input.OutListNO = this.Reader[9].ToString();							//9 出库单据号
                    input.Item.ID = this.Reader[10].ToString();								//10 药品编码
                    input.Item.Name = this.Reader[11].ToString();							//11 药品商品名
                    input.Item.Type.ID = this.Reader[12].ToString();						//12 药品类别
                    input.Item.Quality.ID = this.Reader[13].ToString();						//13 药品性质
                    input.Item.Specs = this.Reader[14].ToString();							//14 规格
                    input.Item.PackUnit = this.Reader[15].ToString();						//15 包装单位
                    input.Item.PackQty = NConvert.ToDecimal(this.Reader[16].ToString());	//16 包装数量
                    input.Item.MinUnit = this.Reader[17].ToString();						//17 最小单位
                    input.ShowState = this.Reader[18].ToString();							//18 显示单位标记
                    input.ShowUnit = this.Reader[19].ToString();							//19 显示单位
                    input.BatchNO = this.Reader[20].ToString();								//20 批号
                    input.ValidTime = NConvert.ToDateTime(this.Reader[21].ToString());		//21 有效期
                    input.Producer.ID = this.Reader[22].ToString();							//22 生产厂家
                    input.Company.ID = this.Reader[23].ToString();							//23 供货单位
                    input.TargetDept.ID = input.Company.ID;
                    input.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[24].ToString());//24 零售价
                    input.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[25].ToString());	//25 批发价
                    input.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[26].ToString());	//26 购入价
                    input.Quantity = NConvert.ToDecimal(this.Reader[27].ToString());		//27 入库数量
                    input.RetailCost = NConvert.ToDecimal(this.Reader[28].ToString());		//28 零售金额
                    input.WholeSaleCost = NConvert.ToDecimal(this.Reader[29].ToString());	//29 批发金额
                    input.PurchaseCost = NConvert.ToDecimal(this.Reader[30].ToString());	//30 购入金额
                    input.StoreQty = NConvert.ToDecimal(this.Reader[31].ToString());		//31 入库后库存数量
                    input.StoreCost = NConvert.ToDecimal(this.Reader[32].ToString());		//32 入库后库存金额
                    input.SpecialFlag = this.Reader[33].ToString();							//33 特殊标记 1 是 0 否
                    input.State = this.Reader[34].ToString();								//34 入库状态0 申请 1 审批 2 核准
                    input.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[35].ToString());		//35 申请数量
                    input.Operation.ApplyOper.ID = this.Reader[36].ToString();						//36 申请人
                    input.Operation.ApplyOper.OperTime = NConvert.ToDateTime(this.Reader[37].ToString());	    //37 申请日期
                    input.Operation.ExamQty = NConvert.ToDecimal(this.Reader[38].ToString());			//38 审批数量
                    input.Operation.ExamOper.ID = this.Reader[39].ToString();						//39 审核人
                    input.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[40].ToString());		//40 审核日期
                    input.Operation.ApproveOper.ID = this.Reader[41].ToString();						//41 核准人
                    input.Operation.ApproveOper.OperTime = NConvert.ToDateTime(this.Reader[42].ToString());	//42 核准日期
                    input.PlaceNO = this.Reader[43].ToString();							//43 货位号
                    input.Operation.ReturnQty = NConvert.ToDecimal(this.Reader[44].ToString());		//44 退库数量
                    input.User01 = this.Reader[45].ToString();								//45 申请序号
                    input.MedNO = this.Reader[46].ToString();								//46 制剂序号
                    input.InvoiceNO = this.Reader[47].ToString();							//47 发票号
                    input.DeliveryNO = this.Reader[48].ToString();							//48 送货单号
                    input.TenderNO = this.Reader[49].ToString();							//49 招标单序号
                    input.ActualRate = NConvert.ToDecimal(this.Reader[50].ToString());		//50 实际扣率
                    input.CashFlag = this.Reader[51].ToString();							//51 扣现金标志
                    input.PayState = this.Reader[52].ToString();							//52 供货商结存状态
                    input.Operation.Oper.ID = this.Reader[53].ToString();							//53 操作员
                    input.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[54].ToString());		//54 操作时间
                    input.Memo = this.Reader[55].ToString();								//55 备注
                    input.User01 = this.Reader[56].ToString();								//56 扩展字段1
                    input.User02 = this.Reader[57].ToString();								//57 扩展字段2
                    input.User03 = this.Reader[58].ToString();								//58 扩展字段3 

                    //{24E12384-34F7-40c1-8E2A-3967CECAF615} 增加入库时间、供货单位类型字段
                    if (this.Reader.FieldCount > 59)
                    {
                        input.CommonPurchasePrice = NConvert.ToDecimal( this.Reader[59] );
                        input.Item.TenderOffer.IsTenderOffer = NConvert.ToBoolean( this.Reader[60] );
                        input.InvoiceDate = NConvert.ToDateTime( this.Reader[61] );

                        input.InDate = NConvert.ToDateTime( this.Reader[62] );
                        input.SourceCompanyType = this.Reader[63].ToString();
                    }

                    al.Add(input);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获取入库计划明细信息时出错" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 插入一条入库记录
        /// </summary>
        /// <param name="Input">入库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertInput(Neusoft.HISFC.Models.Pharmacy.Input Input)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertInput", ref strSQL) == -1) return -1;
            try
            {
                //获取入库流水号
                Input.ID = this.GetSequence("Pharmacy.Item.GetInputBillID");
                if (Input.ID == "")
                {
                    this.Err = "获取入库流水号出错！";
                    return -1;
                }

                //{24E12384-34F7-40c1-8E2A-3967CECAF615} 数据赋值
                DateTime sysDate = this.GetDateTimeFromSysDateTime();
                Input.InDate = sysDate;
                if (string.IsNullOrEmpty( Input.SourceCompanyType ) == true)
                {
                    Input.SourceCompanyType = "1";          //1 院内科室 2 供货单位 3 扩展
                }

                string[] strParm = myGetParmInput(Input); //取参数列表
                strSQL = string.Format(strSQL, strParm);      //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "插入入库记录的SQl参数赋值时出错！Pharmacy.Item.InsertInput" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新一条入库记录
        /// </summary>
        /// <param name="Input">入库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateInput(Neusoft.HISFC.Models.Pharmacy.Input Input)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateInput", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = myGetParmInput(Input);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新入库记录的SQl参数赋值时出错！Pharmacy.Item.UpdateInput" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除入库记录
        /// </summary>
        /// <param name="ID">入库记录流水号</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int DeleteInput(string ID)
        {
            string strSQL = "";
            //根据入库记录流水号删除某一条入库记录的DELETE语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteInput", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, ID);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.DeleteInput";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 内部使用

        /// <summary>
        /// 根据科室、状态由入库表内获取药品列表
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="inState">状态标志</param>
        /// <param name="offerCompanyID">供货单位编码 "AAAA"忽略供货单位</param>
        /// <returns>成功返回Item动态数组 失败返回null</returns>
        public ArrayList QueryPharmacyListForInput(string deptCode, string inState, string offerCompanyID)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetPharmacyListForInput", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetPharmacyListForInput字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptCode, inState, offerCompanyID);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetPharmacyListForInput:" + ex.Message;
                return null;
            }

            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Item item;

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得申请入库信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    item = new Neusoft.HISFC.Models.Pharmacy.Item();

                    item.ID = this.Reader[0].ToString();							//药品编码
                    item.Name = this.Reader[1].ToString();   						//药品名称
                    item.Specs = this.Reader[2].ToString();							//规格
                    item.User01 = this.Reader[3].ToString();						//供货单位	
                    item.User02 = this.Reader[4].ToString();						//入库数量
                    item.User03 = this.Reader[5].ToString();						//入库流水号
                    item.SpellCode = this.Reader[6].ToString();					//拼音码
                    item.WBCode = this.Reader[7].ToString();						//五笔码
                    item.NameCollection.RegularSpell.SpellCode = this.Reader[8].ToString();   //通用名拼音码
                    item.NameCollection.RegularSpell.WBCode = this.Reader[9].ToString();		//通用名五笔码

                    al.Add(item);
                }

            }
            catch (Exception ex)
            {
                this.Err = "获取入库列表信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 获取入库单号
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <returns>成功返回入库单据号 yymmdd＋三位流水号</returns>
        public string GetListCode(string deptCode)
        {
            string strSQL = "";
            string temp1, temp2;
            string newListCode;
            //系统时间 yymmdd
            temp1 = this.GetSysDateNoBar().Substring(2, 6);
            //取最大入库计划单号
            if (this.Sql.GetSql("Pharmacy.Item.GetMaxInListCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetMaxInputListCode字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptCode, temp1);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetMaxInListCode:" + ex.Message;
                return null;
            }

            temp2 = this.ExecSqlReturnOne(strSQL);
            if (temp2.ToString() == "-1" || temp2.ToString() == "")
            {
                temp2 = "001";
            }
            else
            {
                decimal i = NConvert.ToDecimal(temp2.Substring(6, 3)) + 1;
                temp2 = i.ToString().PadLeft(3, '0');
            }
            newListCode = temp1 + temp2;

            return newListCode;
        }

        /// <summary>
        /// 更新一条入库记录中的"已退库数量"字段（加操作）
        /// </summary>
        /// <param name="inputBillCode">入库单号</param>
        /// <param name="SerialNO">单内序号</param>
        /// <param name="returnNum">退库数量</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateInputReturnNum(string inputBillCode, int SerialNO, decimal returnNum)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateInputReturnNum", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Item.UpdateInputReturnNum";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   inputBillCode, 
									   SerialNO.ToString(), 
									   returnNum.ToString(),
									   this.Operator.ID
								   };
                strSQL = string.Format(strSQL, strParm);              //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新退库数量的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #region 获取各库房入库单据情况、发票情况

        /// <summary>
        /// 获取出库单据列表 供入库核准
        /// </summary>
        /// <param name="outDeptCode">出库科室</param>
        /// <param name="storageDept">领药科室</param>
        /// <param name="class3MeaningCode">三级权限码 "A"忽略权限信息</param>
        /// <returns>成功返回neuobject数组 Id 单据号 Name 出库科室 Memo 出库科室编码 失败返回null</returns>
        public ArrayList QueryOutputListForApproveInput(string outDeptCode, string storageDept, string class3MeaningCode)
        {
            ArrayList al = new ArrayList();
            string strSQL = "";
            string strString = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutListForApproveInput", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutListForApproveInput字段!";
                return null;
            }
            try
            {
                strString = string.Format(strSQL, outDeptCode, storageDept, class3MeaningCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            Neusoft.FrameWork.Models.NeuObject info;
            if (this.ExecQuery(strString) == -1)
            {
                this.Err = "获得出库信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();		//单据号
                    info.Name = this.Reader[1].ToString();		//出库单位名称
                    info.Memo = this.Reader[2].ToString();		//出库单位编码
                    info.User01 = this.Reader[3].ToString();	//审批人

                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获取出库列表信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获取某科室入库数据列表、不包含详细数据
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="inPrivType">入库分类 三级权限码 'AAAA'忽略该参数</param>
        /// <param name="inState">入库状态 0 申请 1 审批 2 核准 'AAAA'忽略该参数</param>
        /// <returns>成功返回入库实体数组 失败返回null</returns>
        public ArrayList QueryInputList(string deptCode, string inPrivType, string inState)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetInputList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetInputList字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptCode, inPrivType, inState);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetInputList:" + ex.Message;
                return null;
            }

            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Input input;

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得入库列表信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    input = new Input();
                    input.StockDept.ID = this.Reader[0].ToString();							//申请科室编码
                    input.InListNO = this.Reader[1].ToString();						//入库单据号
                    input.PrivType = this.Reader[2].ToString();							//入库分类 0310
                    input.SystemType = this.Reader[3].ToString();						//三级权限码
                    input.OutListNO = this.Reader[4].ToString();						//出库单据号
                    input.Company.ID = this.Reader[5].ToString();						//供货单位编码
                    input.TargetDept.ID = input.Company.ID;
                    input.SpecialFlag = this.Reader[6].ToString();						//特殊标记 1 是  0 否
                    input.State = this.Reader[7].ToString();							//入库状态 0 申请 1 审批 2 核准
                    input.Operation.ApplyOper.ID = this.Reader[8].ToString();					//申请操作员
                    input.Operation.ApplyOper.OperTime = NConvert.ToDateTime(this.Reader[9].ToString());	//申请时间
                    input.Operation.ExamOper.ID = this.Reader[10].ToString();					//审批人
                    input.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[11].ToString());	//审批时间
                    input.Operation.ApproveOper.ID = this.Reader[12].ToString();					//核准人
                    input.Operation.ApproveOper.OperTime = NConvert.ToDateTime(this.Reader[13].ToString());//核准时间
                    input.InvoiceNO = this.Reader[14].ToString();						//发票号
                    input.PayState = this.Reader[15].ToString();						//供货商结存状态
                    input.DeliveryNO = this.Reader[16].ToString();						//送货单号
                    //					input.Memo = this.Reader[16].ToString();							//备注
                    al.Add(input);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获取入库列表信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 获取某科室入库数据列表 不保护详细数据
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="inPrivType">入库分类 AAAA 检索所有分类</param>
        /// <param name="inState">入库状态 0 申请 1 审批 2 核准</param>
        /// <param name="dtBegin">查询起始时间</param>
        /// <param name="dtEnd">查询终止时间</param>
        /// <returns>成功返回入库实体数组 失败返回null</returns>
        public ArrayList QueryInputList(string deptCode, string inPrivType, string inState, DateTime dtBegin, DateTime dtEnd)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetInputList.OperTime", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetInputList.OperTime字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptCode, inPrivType, inState, dtBegin.ToString(), dtEnd.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetInputList.OperTime:" + ex.Message;
                return null;
            }

            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Input input;

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得入库列表信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    input = new Input();
                    input.StockDept.ID = this.Reader[0].ToString();							//申请科室编码
                    input.InListNO = this.Reader[1].ToString();						//入库单据号
                    input.PrivType = this.Reader[2].ToString();							//入库分类 0310
                    input.SystemType = this.Reader[3].ToString();						//三级权限码
                    input.OutListNO = this.Reader[4].ToString();						//出库单据号
                    input.Company.ID = this.Reader[5].ToString();						//供货单位编码
                    input.TargetDept.ID = input.Company.ID;
                    input.SpecialFlag = this.Reader[6].ToString();						//特殊标记 1 是  0 否
                    input.State = this.Reader[7].ToString();							//入库状态 0 申请 1 审批 2 核准
                    input.Operation.ApplyOper.ID = this.Reader[8].ToString();					//申请操作员
                    input.Operation.ApplyOper.OperTime = NConvert.ToDateTime(this.Reader[9].ToString());	//申请时间
                    input.Operation.ExamOper.ID = this.Reader[10].ToString();					//审批人
                    input.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[11].ToString());	//审批时间
                    input.Operation.ApproveOper.ID = this.Reader[12].ToString();					//核准人
                    input.Operation.ApproveOper.OperTime = NConvert.ToDateTime(this.Reader[13].ToString());//核准时间
                    input.InvoiceNO = this.Reader[14].ToString();						//发票号
                    input.PayState = this.Reader[15].ToString();						//供货商结存状态
                    input.DeliveryNO = this.Reader[16].ToString();						//送货单号
                    al.Add(input);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获取入库列表信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 根据供货单位获取库存药品列表
        /// </summary>
        /// <param name="deptCode">库存科室库房编码</param>
        /// <param name="offerCompanyID">供货单位编码</param>
        /// <returns>成功返回Item数组 失败返回null</returns>
        public ArrayList QueryStorageListForBackInput(string deptCode, string offerCompanyID)
        {
            ArrayList al = new ArrayList();

            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageListForBackInput", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageListForBackInput字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptCode, offerCompanyID);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetStorageListForBackInput:" + ex.Message;
                return null;
            }
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得库存明细信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            //流水号、药品商品名、规格、购入价、发票号
            Neusoft.HISFC.Models.Pharmacy.Item item;
            try
            {
                while (this.Reader.Read())
                {
                    item = new Neusoft.HISFC.Models.Pharmacy.Item();
                    item.ID = this.Reader[0].ToString();								//入库流水号
                    item.Name = this.Reader[1].ToString();								//药品商品名
                    item.Specs = this.Reader[2].ToString();								//规格
                    item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[3].ToString());	//购入价
                    item.User01 = this.Reader[4].ToString();							//发票号
                    item.SpellCode = this.Reader[5].ToString();						//拼音码
                    item.WBCode = this.Reader[6].ToString();							//五笔码
                    item.NameCollection.RegularSpell.SpellCode = this.Reader[7].ToString();		//通用名拼音码
                    item.NameCollection.RegularSpell.WBCode = this.Reader[8].ToString();			//通用名五笔码

                    al.Add(item);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 根据发票号获取入库明细信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="invoiceNo">发票号</param>
        /// <param name="inState">入库状态 0 申请 1 审批 2 核准 A 检索全部状态</param>
        /// <returns>成功返回入库实体数组。失败返回null</returns>
        public ArrayList QueryInputInfoByInvoice(string deptCode, string invoiceNo, string inState)
        {
            string strSelect = "";
            string strWhere = "";
            //取Select语句
            if (this.Sql.GetSql("Pharmacy.Item.GetInput", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetInput字段Sql";
                return null;
            }
            //取Where语句
            if (this.Sql.GetSql("Pharmacy.Item.GetInput.Invoice", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetInput.Invoice字段Sql";
                return null;
            }
            //格式化SQL语句
            try
            {
                strSelect = string.Format(strSelect + strWhere, deptCode, invoiceNo, inState);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetInputInfoByInvoice:" + ex.Message;
                return null;
            }

            return this.myGetInput(strSelect);
        }

        /// <summary>
        /// 根据入库单据号获取指定供货单位入库明细信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="inListCode">入库单据号</param>
        /// <param name="offerCompany">供货单位编码 传"AAAA"则忽略该参数，查询所有供货单位</param>
        /// <param name="inState">入库单状态 "AAAA"则忽略该参数</param>
        /// <returns>成功返回入库实体数组 失败返回null</returns>
        public ArrayList QueryInputInfoByListID(string deptCode, string inListCode, string offerCompany, string inState)
        {
            string strSelect = "";
            string strWhere = "";
            //取Select语句
            if (this.Sql.GetSql("Pharmacy.Item.GetInput", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetInput字段Sql";
                return null;
            }
            //取Where语句
            if (this.Sql.GetSql("Pharmacy.Item.GetInput.ListID", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetInput.ListID字段Sql";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSelect = string.Format(strSelect + strWhere, deptCode, inListCode, offerCompany, inState);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetInputInfoByListID:" + ex.Message;
                return null;
            }
            return this.myGetInput(strSelect);
        }

        /// <summary>
        /// 根据入库流水号获取入库明细信息
        /// </summary>
        /// <param name="inBillCode">入库流水号</param>
        /// <returns>成功返回入库实体 失败返回null</returns>
        public Neusoft.HISFC.Models.Pharmacy.Input GetInputInfoByID(string inBillCode)
        {
            string strSelect = "";
            string strWhere = "";
            //取Select语句
            if (this.Sql.GetSql("Pharmacy.Item.GetInput", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetInput字段Sql";
                return null;
            }
            //取Where语句
            if (this.Sql.GetSql("Pharmacy.Item.GetInput.ID", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetInput.ID字段Sql";
                return null;
            }
            //格式化SQL语句
            try
            {
                strSelect = string.Format(strSelect + strWhere, inBillCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetInputInfoByID:" + ex.Message;
                return null;
            }

            ArrayList al = this.myGetInput(strSelect);
            if (al == null)
            {
                return null;
            }
            if (al.Count == 0)
            {
                this.Err = "数据发生变动！";
                return null;
            }
            return al[0] as Neusoft.HISFC.Models.Pharmacy.Input;
        }

        #endregion

        #region 入库保存

        /// <summary>
        /// 根据入库申请信息直接入库
        /// </summary>
        /// <param name="preparation">制剂主实体</param>
        /// <param name="groupNO">批次</param>
        /// <param name="pprDept">制剂科室</param>
        /// <param name="stockDept">库存科室(入库目标科室)</param>
        /// <param name="isApply">是否入库申请</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int Input(PPRObject.Preparation preparation, int groupNO, Neusoft.FrameWork.Models.NeuObject pprDept, Neusoft.FrameWork.Models.NeuObject stockDept, bool isApply)
        {
            Input input = new Input();

            #region 实体赋值

            input.Class2Type = "0310";
            input.SystemType = Neusoft.HISFC.Models.Base.EnumIMAInTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAInType.ProduceInput);                            //系统类型＝出库申请类型;				//"R1" 制剂管理类型
            input.PrivType = input.SystemType;					//制剂管理类型
            input.InListNO = preparation.PlanNO;

            input.Item = preparation.Drug;

            input.StockDept = pprDept;
            input.Company = pprDept;
            input.Producer = pprDept;

            input.TargetDept = stockDept;

            input.BatchNO = preparation.BatchNO;
            input.GroupNO = groupNO;
            input.Quantity = preparation.InputQty;
            input.Operation.ApplyQty = input.Quantity;
            input.Operation.ExamQty = input.Quantity;

            input.ValidTime = preparation.ValidDate;

            input.Operation.ApplyOper = preparation.OperEnv;

            input.Memo = preparation.Memo;

            #endregion

            if (isApply)		//需要入库申请
            {
                input.State = "0";
                if (this.SetApplyIn(input) == -1)
                {
                    return -1;
                }
            }
            else				//不需入库申请 直接入库
            {
                input.State = "2";
                input.Operation.ExamOper.ID = input.Operation.ApplyOper.ID;
                input.Operation.ExamOper.OperTime = input.Operation.ApplyOper.OperTime;
                input.Operation.ApproveOper.ID = input.Operation.ApplyOper.ID;
                input.Operation.ApproveOper.OperTime = input.Operation.ApplyOper.OperTime;

                if (this.Input(input, "1") == -1)
                {
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 审核入库信息（药库发票入库）只用于状态更新
        /// </summary>
        /// <param name="Input">入库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int ExamInput(Neusoft.HISFC.Models.Pharmacy.Input Input)
        {
            string strSQL = "";
            //审批入库信息（药库发票入库），更新入库状态为'1'			
            try
            {
                decimal purchaseCost = System.Math.Round(Input.Quantity / Input.Item.PackQty * Input.Item.PriceCollection.PurchasePrice, 2);
                //取参数列表
                string[] strParm = {
									   Input.ID,								//0 入库流水号
									   Input.Operation.ExamQty.ToString(),				//1 审批数量
									   Input.Operation.ExamOper.ID,						//2 审批人
									   Input.Operation.ExamOper.OperTime.ToString(),				//3 审批日期
									   Input.InvoiceNO,							//4 发票号码
									   Input.Item.PriceCollection.PurchasePrice.ToString(),		//5 购入价
									   purchaseCost.ToString(),					//6 购入金额
									   this.Operator.ID,						//7 操作人
									   Input.Item.ID,							//8 药品编码
									   Input.GroupNO.ToString(),				//9 批次
				};
                int parm;
                //更新本条入库信息
                if (this.Sql.GetSql("Pharmacy.Item.ExamInput", ref strSQL) == -1) return -1;
                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
                parm = this.ExecNoQuery(strSQL);
                if (parm == -1)
                {
                    this.Err = "更新药品入库审批出错！";
                    return -1;
                }
                if (parm == 0)
                {
                    this.Err = "本记录已被核准！无法再次修改审批";
                    return 0;
                }

                return 1;
            }
            catch (Exception ex)
            {
                this.Err = "审批入库记录的SQl参数赋值出错！Pharmacy.Item.ExamInput" + ex.Message;
                this.WriteErr();
                return -1;
            }
        }

        /// <summary>
        /// 核准入库信息（发票核准） 0 不更新库存 1 更新库存
        /// </summary>
        /// <param name="Input">入库记录类</param>
        /// <param name="updateStorageFlag">是否更新库存 0 不更新 1 更新</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int ApproveInput(Neusoft.HISFC.Models.Pharmacy.Input Input, string updateStorageFlag)
        {
            string strSQL = "";
            int parm;
            //入库流水号不为空 说明已有入库记录 直接进行状态更新操作
            if (Input.ID != "")
            {
                #region 入库流水号不为空 对入库记录直接进行更新操作 更新库存信息状态
                //核准入库信息（发票核准），更新申请状态为'2'。
                if (this.Sql.GetSql("Pharmacy.Item.ApproveInput", ref strSQL) == -1) return -1;
                try
                {
                    //取参数列表
                    string[] strParm = {
										   Input.ID,                        //入库流水号
										   Input.Quantity.ToString(),       //核准数量
										   Input.Operation.ApproveOper.ID,           //核准人
										   Input.Operation.ApproveOper.OperTime.ToString(),    //核准日期
                                           Input.InvoiceNO,                 //发票号
                                           Input.Item.PriceCollection.PurchasePrice.ToString(),      //购入价
										   this.Operator.ID,                //操作人                  
					};
                    strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
                    parm = this.ExecNoQuery(strSQL);
                    if (parm == -1)
                    {
                        this.Err = "核准入库记录执行出错！";
                        return -1;
                    }
                    //更新库存记录的库存状态 0暂入库 1 正式入库
                    Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase = Input.Clone() as Neusoft.HISFC.Models.Pharmacy.StorageBase;
                    if (storageBase == null)
                    {
                        this.Err = "处理库存时候 发生数据类型转换错误";
                        return -1;
                    }

                    storageBase.Class2Type = Input.Class2Type;
                    storageBase.PrivType = Input.PrivType;

                    if (updateStorageFlag == "0")			//不更新
                        parm = this.UpdateStorageState(storageBase, "1", false);
                    else									//更新
                        parm = this.UpdateStorageState(storageBase, "1", true);
                    if (parm == -1)
                    {
                        this.Err = "更新申请科室库存数据入库状态时出错！";
                        return -1;
                    }
                    if (parm == 0)
                    {
                        storageBase.State = "1";		//库存状态
                        parm = this.InsertStorage(storageBase);
                        if (parm == -1)
                        {
                            this.Err = "对申请科室增加库存出错！";
                            return -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Err = "核准入库记录的SQl参数赋值时出错！Pharmacy.Item.ApproveInput" + ex.Message;
                    this.WriteErr();
                    return -1;
                }
                #endregion
            }
            else	//如无入库记录，则插入一条入库记录
            {
                parm = this.Input(Input, updateStorageFlag, "1");
                if (parm == -1)
                {
                    return -1;
                }
            }
            //处理申请数据 更新状态
            if (Input.OutListNO != "")
            {
                //不进行申请数据状态更新。该状态更新由外部操作完成
                //if( this.UpdateApplyOutState( Input.StockDept.ID , Input.OutListNO , "2" ) == -1 )
                //{
                //    return -1;
                //}
            }
            //如存在对应的出库记录 则更新出库状态为 2
            if (Input.OutBillNO != "" && Input.OutBillNO != "0")
            {
                #region 处理出库记录
                ArrayList alOutput;
                Neusoft.HISFC.Models.Pharmacy.Output output;
                //全部更新导致多条出库记录对应一条入库
                //alOutput = this.QueryOutputList( Input.OutBillNO );                
                //if( alOutput == null )
                //{
                //    this.Err = "更新出库记录过程中 获取出库记录出错！";
                //    return -1;
                //}
                //for( int i = 0 ; i < alOutput.Count ; i++ )
                //{
                //    output = alOutput[ i ] as Neusoft.HISFC.Models.Pharmacy.Output;
                //    if( output == null )
                //    {
                //        this.Err = "更新出库记录过程中 数据类型转换出错！";
                //        return -1;
                //    }
                //    output.State = "2";
                //    output.InListNO = Input.InListNO;
                //    output.InBillNO = Input.ID;

                //    parm = this.UpdateOutput( output );
                //    if( parm == -1 )
                //    {
                //        this.Err = "更新出库记录执行出错！" + this.Err;
                //        return -1;
                //    }
                //}

                output = this.GetOutputDetail(Input.OutBillNO, Input.GroupNO.ToString());
                if (output == null)
                {
                    this.Err = "更新出库记录过程中 获取出库记录出错！";
                    return -1;
                }
                if (output.State == "2")
                {
                    this.Err = "该数据已进行过核准 无法重复核准入库";
                    return -1;
                }

                output.State = "2";
                output.InListNO = Input.InListNO;
                output.InBillNO = Input.ID;
                output.InSerialNO = Input.SerialNO;
                output.Operation.ApproveOper = Input.Operation.Oper;

                parm = this.UpdateOutput(output);
                if (parm == -1)
                {
                    this.Err = "更新出库记录执行出错！" + this.Err;
                    return -1;
                }
                #endregion
            }

            if (Input.StockDept.Memo == "PI")		//标志是药库的入库核准  
            {
                #region 对全院库存更新购入价、发票信息
                decimal purchaseCost = System.Math.Round(Input.Quantity / Input.Item.PackQty * Input.Item.PriceCollection.PurchasePrice, 2);
                //取参数列表
                string[] strParmPrice = {
											Input.ID,								//0 入库流水号
											Input.Operation.ExamQty.ToString(),				//1 审批数量
											Input.Operation.ExamOper.ID,						//2 审批人
											Input.Operation.ExamOper.OperTime.ToString(),				//3 审批日期
											Input.InvoiceNO,						//4 发票号码
											Input.Item.PriceCollection.PurchasePrice.ToString(),	//5 购入价
											purchaseCost.ToString(),				//6 购入金额
											this.Operator.ID,						//7 操作人
											Input.Item.ID,							//8 药品编码
											Input.GroupNO.ToString(),				//9 批次
				};
                //更新全院药品库存购入价、入库发票号
                if (this.Sql.GetSql("Pharmacy.Item.UpdatePriceStorage", ref strSQL) == -1) return -1;
                strSQL = string.Format(strSQL, strParmPrice);        //替换SQL语句中的参数。
                parm = this.ExecNoQuery(strSQL);
                if (parm == -1)
                {
                    this.Err = "更新库存表购入价时出错！";
                    return -1;
                }

                //更新全院药品出库购入价
                if (this.Sql.GetSql("Pharmacy.Item.UpdatePriceOutput", ref strSQL) == -1) return -1;
                strSQL = string.Format(strSQL, strParmPrice);        //替换SQL语句中的参数。
                parm = this.ExecNoQuery(strSQL);
                if (parm == -1)
                {
                    this.Err = "更新药品出库表购入价时出错！";
                    return -1;
                }
                #endregion

                //设定控制参数是否对此进行更新 更新药品字典内 信息
                //控制参数为 1 更新药品字典信息
                Neusoft.FrameWork.Management.ControlParam ctrlManager = new Neusoft.FrameWork.Management.ControlParam();
                ctrlManager.SetTrans(this.Trans);
                //string approveUpdateBaseFlag = ctrlManager.QueryControlerInfo("510002");
                string approveUpdateBaseFlag = ctrlManager.QueryControlerInfo("P00572");
                if (approveUpdateBaseFlag == "1")
                {
                    parm = this.UpdateItemInputInfo(Input);
                    if (parm == -1)
                    {
                        this.Err = "更新药品字典表内信息出错" + this.Err;
                        return -1;
                    }
                }

                #region 生成供货商结存信息

                if (Input.Item.PackQty == 0)
                    Input.Item.PackQty = 1;

                Input.RetailCost = System.Math.Round((Input.Quantity / Input.Item.PackQty * Input.Item.PriceCollection.RetailPrice), 2);
                Input.WholeSaleCost = System.Math.Round((Input.Quantity / Input.Item.PackQty * Input.Item.PriceCollection.WholeSalePrice), 2);
                Input.PurchaseCost = System.Math.Round((Input.Quantity / Input.Item.PackQty * Input.Item.PriceCollection.PurchasePrice), 2);

                if (this.Pay(Input) == -1)
                {
                    this.Err = "供货商结存信息生成错误" + this.Err;
                    return -1;
                }

                #endregion
            }
            return parm;
        }

        /// <summary>
        /// 根据入库信息更新药品字典信息
        /// 
        /// //{476ED544-49A6-4070-9ACB-C581F403347D} 对字典记录进行入库信息更新
        /// </summary>
        /// <param name="input">药品字典</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateBaseItemWithInputInfo(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            //设定控制参数是否对此进行更新 更新药品字典内 信息
            //控制参数为 1 更新药品字典信息
            Neusoft.FrameWork.Management.ControlParam ctrlManager = new Neusoft.FrameWork.Management.ControlParam();
            string approveUpdateBaseFlag = ctrlManager.QueryControlerInfo("P00572");
            if (approveUpdateBaseFlag == "1")
            {
                int parm = this.UpdateItemInputInfo(input);
                if (parm == -1)
                {
                    this.Err = "更新药品字典表内信息出错" + this.Err;
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 同时更新入库审批（发票入库）、入库核准（发票核准）信息、更新状态为"2"
        /// </summary>
        /// <param name="Input">入库记录类</param>
        /// <param name="updateStorageFlag">是否同步更新库存 0 不更新 1 更新库存</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int SetInput(Neusoft.HISFC.Models.Pharmacy.Input Input, string updateStorageFlag)
        {
            int parm;
            //进行入库审批操作
            parm = this.ExamInput(Input);
            if (parm == -1)
                return -1;
            //入库核准操作
            return this.ApproveInput(Input, updateStorageFlag);
        }

        /// <summary>
        /// 对生产入库进行处理、同步扣除原材料的库存
        /// </summary>
        /// <param name="input">入库实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ProduceInput(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            return 1;
        }

        /// <summary>
        /// 对一般入库、特殊入库进行处理 根据是否同步更新库存、库存 入库状态为暂入库 0 
        /// </summary>
        /// <param name="input">入库实体</param>
        /// <param name="updateStorageFlag">是否更新库存 0 不更新 1 更新</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int Input(Neusoft.HISFC.Models.Pharmacy.Input input, string updateStorageFlag)
        {
            return Input(input, updateStorageFlag, "0");
        }

        /// <summary>
        /// 对一般入库、特殊入库进行处理 根据是否同步更新库存、库存
        /// </summary>
        /// <param name="input">入库实体</param>
        /// <param name="updateStorageFlag">是否更新库存 0 不更新 1 更新</param>
        /// <param name="storageState">库存状态 0 暂入库 1 正式入库</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int Input(Neusoft.HISFC.Models.Pharmacy.Input input, string updateStorageFlag, string storageState)
        {
            //对入库退库进行处理 插入负记录 更新原记录 退库数量
            if (input.SystemType == "19")
            {
                #region 入库退库
                if (input.ID != "")
                {
                    //更新原入库记录退库数量
                    if (this.UpdateInputReturnNum(input.ID, input.SerialNO, -input.Quantity) != 1)
                    {
                        this.Err = this.Err + "更新入库记录退库数量出错！";
                        return -1;
                    }
                }

                //插入负记录
                input.ID = "";
                if (this.InsertInput(input) == -1)
                {
                    return -1;
                }
                #endregion
            }
            else	//对其他类型直接进行插入操作
            {
                if (this.InsertInput(input) == -1)
                {
                    return -1;
                }
            }
            //需要更新库存
            if (updateStorageFlag == "1")
            {
                if (input.SystemType == EnumIMAInTypeService.GetNameFromEnum(EnumIMAInType.CommonInput) || input.SystemType == EnumIMAInTypeService.GetNameFromEnum(EnumIMAInType.SpecialInput))
                {
                    //...一般入库、特殊入库不进行价格判断。
                }
                else
                {
                    #region  判断入库价格与库存价格(当前最新价格)是否一致 不一致处理调价记录
                    decimal dNowPrice = 0;
                    DateTime sysTime = this.GetDateTimeFromSysDateTime();
                    if (this.GetNowPrice(input.Item.ID, ref dNowPrice) == -1)
                    {
                        this.Err = "处理入库记录退库过程中 获取药品" + input.Item.Name + "零售价出错";
                        return -1;
                    }
                    if (input.Item.PriceCollection.RetailPrice != dNowPrice)    //此条件判断  是否在核准前/退库前做过调价，不是用于判断单科调价
                    {
                        //{39EBA591-1666-4ab5-B3F3-5B273DA4A623}     入库后，单科调价，退库 此时不应形成调价盈亏 造成账目不平
                        if (input.SystemType == "19")                //只对入库退库的情况 进行判断 
                        {
                            Neusoft.HISFC.Models.Pharmacy.Storage tempStorage = this.GetStockInfoByDrugCode( input.StockDept.ID, input.Item.ID );
                            if (tempStorage == null)
                            {
                                this.Err = "入库退库时进行单科调价校验 获取库存汇总信息发生错误" + this.Err;
                                return -1;
                            }
                            if (tempStorage.Item.PriceCollection.RetailPrice == dNowPrice)          //库存与字典价格一致 说明没有进行单科调价 形成调价盈亏
                            {
                                #region 调价盈亏处理

                                string adjustPriceID = this.GetSequence( "Pharmacy.Item.GetNewAdjustPriceID" );
                                if (adjustPriceID == null)
                                {
                                    this.Err = "入库退库药品已发生调价 插入调价盈亏记录过程中获取调价单号出错！";
                                    return -1;
                                }
                                Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice = new AdjustPrice();
                                adjustPrice.ID = adjustPriceID;								//调价单号
                                adjustPrice.SerialNO = 0;									//调价单内序号
                                adjustPrice.Item = input.Item;
                                adjustPrice.StockDept.ID = input.StockDept.ID;						//调价科室 
                                adjustPrice.State = "1";									//调价状态 1 已调价
                                adjustPrice.StoreQty = input.Quantity;
                                adjustPrice.Operation.ID = this.Operator.ID;
                                adjustPrice.Operation.Name = this.Operator.Name;
                                adjustPrice.Operation.Oper.OperTime = sysTime;
                                adjustPrice.InureTime = sysTime;
                                adjustPrice.AfterRetailPrice = dNowPrice;					//调价后零售价
                                if (dNowPrice - input.Item.PriceCollection.RetailPrice > 0)
                                    adjustPrice.ProfitFlag = "1";							//调盈
                                else
                                    adjustPrice.ProfitFlag = "0";							//调亏

                                adjustPrice.Memo = "入库退库补调价盈亏";
                                if (this.InsertAdjustPriceInfo( adjustPrice ) == -1)
                                {
                                    return -1;
                                }
                                if (this.InsertAdjustPriceDetail( adjustPrice ) == -1)
                                {
                                    return -1;
                                }

                                #endregion
                            }                        
                        }
                        else
                        {
                            #region 调价盈亏处理

                            string adjustPriceID = this.GetSequence( "Pharmacy.Item.GetNewAdjustPriceID" );
                            if (adjustPriceID == null)
                            {
                                this.Err = "入库核准药品已发生调价 插入调价盈亏记录过程中获取调价单号出错！";
                                return -1;
                            }
                            Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice = new AdjustPrice();
                            adjustPrice.ID = adjustPriceID;								//调价单号
                            adjustPrice.SerialNO = 0;									//调价单内序号
                            adjustPrice.Item = input.Item;
                            adjustPrice.StockDept.ID = input.StockDept.ID;						//调价科室 
                            adjustPrice.State = "1";									//调价状态 1 已调价
                            adjustPrice.StoreQty = input.Quantity;
                            adjustPrice.Operation.ID = this.Operator.ID;
                            adjustPrice.Operation.Name = this.Operator.Name;
                            adjustPrice.Operation.Oper.OperTime = sysTime;
                            adjustPrice.InureTime = sysTime;
                            adjustPrice.AfterRetailPrice = dNowPrice;					//调价后零售价
                            if (dNowPrice - input.Item.PriceCollection.RetailPrice > 0)
                                adjustPrice.ProfitFlag = "1";							//调盈
                            else
                                adjustPrice.ProfitFlag = "0";							//调亏

                            adjustPrice.Memo = "入库核准补调价盈亏";
                            if (this.InsertAdjustPriceInfo( adjustPrice ) == -1)
                            {
                                return -1;
                            }
                            if (this.InsertAdjustPriceDetail( adjustPrice ) == -1)
                            {
                                return -1;
                            }

                            #endregion
                        }
                        //{39EBA591-1666-4ab5-B3F3-5B273DA4A623}     入库后，单科调价，退库 此时不应形成调价盈亏 造成账目不平
                    }
                    #endregion
                }

                #region 库存更新
                if (this.UpdateStorageForInput(input, storageState) == -1)
                    return -1;

                #endregion
            }
            //更新药品字典表内信息
            //----
            return 1;
        }

        #endregion

        #endregion

        #endregion

        #region 出库申请表操作

        #region 内部使用

        #region 住院药房调用

        /// <summary>
        /// 根据处方号与处方内项目流水号获取 未核准申请信息 状态为 '0' '1'
        /// </summary>
        ///<param name="recipeNo">处方号</param>
        /// <param name="sequenceNo">项目流水号</param>
        /// <returns>成功返回摆药实体 失败返回null 无数据返回空实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.ApplyOut GetApplyOut(string recipeNo, int sequenceNo)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByRecipeNo", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByRecipeNo字段!";
                return null;
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, recipeNo, sequenceNo.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            ArrayList al = this.myGetApplyOut(strSelect);
            if (al == null) return null;

            if (al.Count == 0)
                return new ApplyOut();
            else
                return al[0] as ApplyOut;
        }

        /// <summary>
        /// 根据执行档流水号获取 未核准的申请信息 状态为 '0' '1'
        /// </summary>
        /// <param name="orderExecNO">执行档流水号</param>
        /// <returns>成功返回出库申请实体信息 失败返回null 无数据返回空实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.ApplyOut GetApplyOutByExecNO(string orderExecNO)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByOrderExecNO", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByOrderExecNO字段!";
                return null;
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, orderExecNO);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            ArrayList al = this.myGetApplyOut(strSelect);
            if (al == null) return null;

            if (al.Count == 0)
                return new ApplyOut();
            else
                return al[0] as ApplyOut;
        }

        /// <summary>
        /// 根据流水号获取申请信息
        /// </summary>
        /// <param name="applyOutID">执行档流水号</param>
        /// <returns>成功返回出库申请实体信息 失败返回null 无数据返回空实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.ApplyOut GetApplyOutByID(string applyOutID)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByID", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByID字段!";
                return null;
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, applyOutID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            ArrayList al = this.myGetApplyOut(strSelect);
            if (al == null) return null;

            if (al.Count == 0)
                return new ApplyOut();
            else
                return al[0] as ApplyOut;
        }

        /// <summary>
        /// 取某一处方号所有未核准的申请列表
        /// </summary>
        /// <param name="recipeNo">处方号</param>
        /// <returns>成功返回出库申请数据数组 失败返回null</returns>
        public ArrayList QueryApplyOut(string recipeNo)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByRecipeNo.1", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByRecipeNo.1字段!";
                return null;
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, recipeNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            ArrayList al = this.myGetApplyOut(strSelect);
            if (al == null) return null;
            return al;
        }

        /// <summary>
        /// 获取所有满足条件的申请明细信息	
        /// </summary>
        ///<param name="recipeNo">处方号</param>
        /// <param name="sequenceNo">项目流水号</param>
        /// <returns>成功返回摆药实体数组 失败返回null 无数据返回空实体</returns>
        public ArrayList QueryApplyOut(string recipeNo, int sequenceNo)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByRecipeNo", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByRecipeNo字段!";
                return null;
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, recipeNo, sequenceNo.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSelect);
        }

        #region addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
        /// <summary>
        /// 获取满足条件的单条申请明细信息	
        /// </summary>
        ///<param name="recipeNo">处方号</param>
        /// <param name="sequenceNo">项目流水号</param>
        /// <returns>成功返回摆药实体 失败返回null 无数据返回空实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.ApplyOut QueryApplyOutNew(string recipeNo, int sequenceNo)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句
            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyoutInfo = null;
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByRecipeNoNew", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByRecipeNo字段!";
                return null;
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, recipeNo, sequenceNo.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            ArrayList alApplys = this.myGetApplyOut(strSelect);
            if (alApplys == null)
            {
                return null;
            }

            applyoutInfo = new ApplyOut();
            if (alApplys.Count > 0)
            {
                applyoutInfo = alApplys[0] as ApplyOut;
            }

            return applyoutInfo;
        } 
        #endregion

        /// <summary>
        /// 取某一申请科室未被核准的申请列表	状态为 0
        /// </summary>
        /// <param name="applyDeptCode">申请科室编码</param>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryApplyOutList(string applyDeptCode)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByApplyDept", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByApplyDept字段!";
                return null;
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, applyDeptCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSelect);
        }

        /// <summary>
        /// 取某一药房，某一摆药通知中待摆药数据列表
        /// 传入参数前，需要将摆药台中的SendType赋给通知实体
        /// </summary>
        /// <param name="drugMessage">摆药通知信息</param>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryApplyOutList(DrugMessage drugMessage)
        {
            string strSQL = "";  //取某一药房中某一中摆药单、某一科室待摆药数据的SQL语句
            string strWhere = "";  //取某一药房中某一中摆药单、某一科室待摆药数据的WHERE语句
            //如果摆药通知类型为集中或者临时，则取相应的出库申请数据。
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Patient", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
                return null;
            }
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByMessage", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByMessage字段!";
                return null;
            }

            try
            {
                string[] strParm = { drugMessage.ApplyDept.ID, drugMessage.StockDept.ID, drugMessage.DrugBillClass.ID, drugMessage.SendType.ToString(), };
                strSQL = string.Format(strSQL + strWhere, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSQL);
        }

        /// <summary>
        /// 取某一药房，某一摆药通知中待摆药数据列表
        /// 传入参数前，需要将摆药台中的SendType赋给通知实体
        /// </summary>
        /// <param name="drugMessage">摆药通知信息</param>
        /// <param name="dtBgn">查询起始时间</param>
        /// <param name="dtEnd">查询终止时间</param>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryApplyOutListByTime(DrugMessage drugMessage, DateTime dtBgn, DateTime dtEnd)
        {
            string strSQL = "";  //取某一药房中某一中摆药单、某一科室待摆药数据的SQL语句
            string strWhere = "";  //取某一药房中某一中摆药单、某一科室待摆药数据的WHERE语句
            string strWhereIndex = "";
            //如果摆药通知类型为集中或者临时，则取相应的出库申请数据。
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Patient", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
                return null;
            }
            if (drugMessage.SendType == 1)
                strWhereIndex = "Pharmacy.Item.GetApplyOutList.ByTime.1";
            else
                strWhereIndex = "Pharmacy.Item.GetApplyOutList.ByTime.2";
            //取WHERE语句
            if (this.Sql.GetSql(strWhereIndex, ref strWhere) == -1)
            {
                this.Err = "没有找到 " + strWhereIndex + " 字段!";
                return null;
            }

            try
            {
                string[] strParm = {drugMessage.ApplyDept.ID, drugMessage.StockDept.ID, drugMessage.DrugBillClass.ID, drugMessage.SendType.ToString(),
									   dtBgn.ToString(),dtEnd.ToString()};
                strSQL = string.Format(strSQL + strWhere, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSQL);
        }

        /// <summary>
        /// 取某一药房，某一摆药通知中某一患者待摆药数据列表
        /// 传入参数前，需要将摆药台中的SendType赋给通知实体
        /// 患者信息住院流水号User01，姓名User02，床号User03
        /// </summary>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryApplyOutListByPatient(DrugMessage drugMessage)
        {
            string strSQL = "";  //取某一药房，某一摆药通知中某一患者待摆药数据列表的SQL语句
            string strWhere = "";  //取某一药房，某一摆药通知中某一患者待摆药数据列表的WHERE语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Patient", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
                return null;
            }
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutListByPatient", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutListByPatient字段!";
                return null;
            }

            try
            {
                string[] strParm = {
									   drugMessage.ApplyDept.ID,             //0申请科室
									   drugMessage.StockDept.ID,              //1药房编码
									   drugMessage.DrugBillClass.ID,        //2摆药单分类编码
									   drugMessage.SendType.ToString(),     //3发送类型
									   drugMessage.User01                   //4患者住院流水号
								   };
                strSQL = string.Format(strSQL + strWhere, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSQL);
        }

        /// <summary>
        /// 取某一张摆药单中的摆药数据
        /// </summary>
        /// <param name="billCode">摆药单号</param>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryApplyOutListByBill(string billCode)
        {
            string strSQL = "";  //取某一药房，某一张摆药单中的摆药数据的SQL语句
            string strWhere = "";  //取某一药房，某一张摆药单中的摆药数据的WHERE语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Patient", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
                return null;
            }
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutListByBill.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutListByBill.Where字段!";
                return null;
            }

            if (billCode.IndexOf("'") == -1)
            {
                billCode = "'" + billCode + "'";
            }

            try
            {
                strSQL = string.Format(strSQL + strWhere, billCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            //根据SQL语句取摆药数据数组并返回数组
            return this.myGetApplyOut(strSQL);
        }

        /// <summary>
        /// 护士站领药单明细打印{B22172AC-5DE2-4897-9923-598503E86E2A}
        /// </summary>
        /// <param name="billCode">摆药单号</param>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryApplyOutListDetailByBillClassCode(string billClassCode, string deptCode, string startDate, string endDate, string drugedType)
        {
            #region 屏蔽
            //string strSQL = "";  //取某一药房，某一张摆药单中的摆药数据的SQL语句
            //string strWhere = "";  //取某一药房，某一张摆药单中的摆药数据的WHERE语句

            ////取SELECT语句
            //if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Patient", ref strSQL) == -1)
            //{
            //    this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
            //    return null;
            //}
            ////取WHERE语句
            //if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutListByBillClassCode.Where", ref strWhere) == -1)
            //{
            //    this.Err = "没有找到Pharmacy.Item.GetApplyOutListByBillClassCode.Where字段!";
            //    return null;
            //}

            ////if (billCode.IndexOf("'") == -1)
            ////{
            ////    billCode = "'" + billCode + "'";
            ////}

            //try
            //{
            //    strSQL = string.Format(strSQL + strWhere, billClassCode, deptCode, startDate, endDate, drugedType);
            //}
            //catch (Exception ex)
            //{
            //    this.Err = ex.Message;
            //    return null;
            //}
            ////根据SQL语句取摆药数据数组并返回数组
            //return this.myGetApplyOut(strSQL);
            #endregion
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutListDetailByBillClassCode", ref strSQL) == -1)//{19858F06-C495-45cf-A21C-85E855241034}
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugBillDetail字段!";
                return null;
            }

            //if (drugBillCode.IndexOf("'") == -1)
            //{
            //    drugBillCode = "'" + drugBillCode + "'";
            //}

            strSQL = string.Format(strSQL, billClassCode, deptCode, startDate, endDate, drugedType);

            //根据SQL语句取数组并返回数组
            ArrayList arrayObject = new ArrayList();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取明细摆药单时出错：" + this.Err;
                return null;
            }
            try
            {
                ApplyOut obj; //患者信息科室编码User01，摆药单号User02

                while (this.Reader.Read())
                {
                    obj = new ApplyOut();
                    obj.ApplyDept.ID = this.Reader[0].ToString();                   //0申请部门编码（科室或者病区）
                    obj.StockDept.Name = this.Reader[1].ToString();                  //1发药部门编码 
                    obj.Item.ID = this.Reader[2].ToString();                        //2药品编码
                    obj.Item.Name = this.Reader[3].ToString();                      //3药品商品名
                    obj.Item.Specs = this.Reader[4].ToString();                     //4规格
                    obj.Item.PackUnit = this.Reader[5].ToString();                  //5包装单位
                    obj.Item.PackQty = NConvert.ToDecimal(this.Reader[6].ToString());//6包装数
                    obj.Item.MinUnit = this.Reader[7].ToString();                   //7最小单位
                    obj.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString()); //8零售价
                    obj.Days = NConvert.ToDecimal(this.Reader[9].ToString());       //9付数
                    obj.User01 = this.Reader[10].ToString();                        //10患者姓名
                    obj.User02 = this.Reader[11].ToString();                        //11床号
                    obj.DoseOnce = NConvert.ToDecimal(this.Reader[12].ToString());  //12每次剂量
                    obj.Item.DoseUnit = this.Reader[13].ToString();                 //13剂量单位
                    obj.Usage.ID = this.Reader[14].ToString();                      //14用法代码
                    obj.Usage.Name = this.Reader[15].ToString();                    //15用法名称
                    obj.Frequency.ID = this.Reader[16].ToString();                  //16频次代码
                    obj.Frequency.Name = this.Reader[17].ToString();                //17频次名称
                    obj.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[18].ToString());  //18申请出库量
                    obj.DrugNO = this.Reader[19].ToString();                      //19摆药单号
                    obj.PrintState = this.Reader[20].ToString();                    //20打印状态（0未打印，1已打印）
                    obj.Operation.ExamOper.ID = this.Reader[21].ToString();                  //21打印人
                    obj.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[22].ToString()); //22打印日期
                    obj.CombNO = this.Reader[23].ToString();						//23组合序号
                    obj.Memo = this.Reader[24].ToString();							//24医嘱备注
                    obj.PlaceNO = this.Reader[25].ToString();						//25货位号
                    obj.User03 = this.Reader[26].ToString();
                    obj.OrderNO = this.Reader[27].ToString();					//医嘱流水号
                    obj.SendType = NConvert.ToInt32(this.Reader[28].ToString());//发送类型 1 集中 2 临时 0 全部
                    obj.State = this.Reader[29].ToString();				//单据状态                    
                    arrayObject.Add(obj);
                }
                return arrayObject;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得明细摆药单时，执行SQL语句出错！GetDrugBillDetail" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }


        /// <summary>
        /// 护士站领药单汇总打印{CC985758-A2AE-41da-9394-34AFCEB0E30E}
        /// </summary>
        /// <param name="billCode">摆药单号</param>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryApplyOutListTotByBillClassCode(string billClassCode, string deptCode, string startDate, string endDate, string drugedType)
        {
            string strSQL = "";  //取某一药房，某一张摆药单中的摆药数据的SQL语句
            string strWhere = "";  //取某一药房，某一张摆药单中的摆药数据的WHERE语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutListTotByBillClassCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
                return null;
            }
            //取WHERE语句
            //if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutListByBillClassCode.Where", ref strWhere) == -1)
            //{
            //    this.Err = "没有找到Pharmacy.Item.GetApplyOutListByBillClassCode.Where字段!";
            //    return null;
            //}

            //if (billCode.IndexOf("'") == -1)
            //{
            //    billCode = "'" + billCode + "'";
            //}

            try
            {
                strSQL = string.Format(strSQL, billClassCode, deptCode, startDate, endDate, drugedType);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            ArrayList arrayObject = new ArrayList();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取汇总摆药单时出错：" + this.Err;
                return null;
            }
            try
            {
                ApplyOut obj = null;
                while (this.Reader.Read())
                {
                    obj = new ApplyOut();
                    obj.ApplyDept.ID = this.Reader[0].ToString();                        //0申请部门编码（科室或者病区）
                    obj.StockDept.Name = this.Reader[1].ToString();                     //1发药部门编码 
                    obj.Item.ID = this.Reader[2].ToString();                             //2药品编码
                    obj.Item.Name = this.Reader[3].ToString();                           //3药品商品名
                    obj.Item.Specs = this.Reader[4].ToString();                          //4规格
                    obj.Item.PackUnit = this.Reader[5].ToString();                       //5包装单位
                    obj.Item.PackQty = NConvert.ToDecimal(this.Reader[6].ToString());    //6包装数
                    obj.Item.MinUnit = this.Reader[7].ToString();                        //7最小单位
                    obj.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString());//8零售价
                    obj.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[9].ToString());        //9申请出库量
                    obj.DrugNO = this.Reader[10].ToString();                           //10摆药单号
                    obj.PrintState = this.Reader[11].ToString();                         //11打印状态（0未打印，1已打印）
                    obj.Operation.ExamOper.ID = this.Reader[12].ToString();                       //12打印人
                    obj.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[13].ToString());      //13打印日期
                    obj.PlaceNO = this.Reader[14].ToString();							 //14货位号
                    obj.SendType = NConvert.ToInt32(this.Reader[15].ToString());	//15 发送标志                    
                    arrayObject.Add(obj);
                }
                return arrayObject;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得汇总摆药单时，执行SQL语句出错！GetDrugBillTotal" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            //根据SQL语句取摆药数据数组并返回数组
            //return this.myGetApplyOut(strSQL);
        }

        /// <summary>
        /// 取某一药房，某一摆药通知中待摆药的患者列表
        /// 传入参数前，需要将摆药台中的SendType赋给通知实体
        /// 如果摆药通知类型为集中或者临时，则取相应的出库申请数据
        /// </summary>
        /// <returns>neuObject数组，患者信息住院流水号ID，姓名Name，床号Memo 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryApplyOutPatientList(DrugMessage drugMessage)
        {
            string strSQL = "";  //取某一药房中某一中摆药单、某一科室待摆药患者列表的SQL语句

            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutPatientList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutPatientList字段!";
                return null;
            }
            string[] strParm = {
								   drugMessage.ApplyDept.ID,             //0申请科室
								   drugMessage.StockDept.ID,              //1药房编码
								   drugMessage.DrugBillClass.ID,        //2摆药单分类编码
								   drugMessage.SendType.ToString(),     //3发送类型
			};
            strSQL = string.Format(strSQL, strParm);

            //根据SQL语句取数组并返回数组
            List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = new List<Neusoft.FrameWork.Models.NeuObject>();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取待摆药患者列表时出错：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj; //患者信息住院流水号ID，姓名Name，床号Memo	
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();                   //住院流水号
                    obj.Name = this.Reader[1].ToString();                 //姓名
                    obj.Memo = this.Reader[2].ToString();                 //床号

                    neuObjectList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得待摆药患者列表时，执行SQL语句出错！myGetDrugBillClass" + ex.Message;
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return neuObjectList;
        }

        /// <summary>
        /// 取某一药房，某一天的摆药单列表
        /// 摆药单分类，摆药单号，
        /// </summary>
        /// <param name="deptCode">药房编码</param>
        /// <param name="dateTime">日期</param>
        /// <returns>成功返回摆药单列表 失败返回null</returns>
        public ArrayList QueryDrugBillByDay(string deptCode, DateTime dateTime)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDrugBillByDay", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugBillByDay字段!";
                return null;
            }
            string[] strParm = {
								   deptCode,             //0摆药科室编码
								   dateTime.ToString()   //1日期
							   };
            strSQL = string.Format(strSQL, strParm);

            //根据SQL语句取数组并返回数组
            ArrayList arrayObject = new ArrayList();

            this.ProgressBarText = "正在检索患者信息...";
            this.ProgressBarValue = 0;

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取待摆药患者列表时出错：" + this.Err;
                return null;
            }
            try
            {
                DrugBillClass obj;
                while (this.Reader.Read())
                {
                    obj = new DrugBillClass();
                    obj.ID = this.Reader[0].ToString();                 //摆药单分类编码
                    obj.Name = this.Reader[1].ToString();               //摆药单分类名称
                    obj.PrintType.ID = this.Reader[2].ToString();       //打印类型
                    obj.Oper.ID = this.Reader[3].ToString();            //配药核准人编码
                    obj.Oper.OperTime = NConvert.ToDateTime(this.Reader[4].ToString());//打印摆药单时间
                    obj.DrugBillNO = this.Reader[5].ToString();         //摆药单号
                    obj.ApplyState = this.Reader[6].ToString();         //申请状态
                    obj.ApplyDept.Name = this.Reader[7].ToString();     //发送科室名称
                    this.ProgressBarValue++;
                    arrayObject.Add(obj);
                }
                return arrayObject;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得待摆药患者列表时，执行SQL语句出错！myGetDrugBillClass" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

        }

        /// <summary>
        /// 取汇总摆药单
        /// </summary>
        /// <param name="drugBillCode">摆药单号</param>
        /// <returns>成功返回摆药申请信息 失败返回null</returns>
        public ArrayList QueryDrugBillTotal(string drugBillCode)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDrugBillTotal", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugBillTotal字段!";
                return null;
            }

            if (drugBillCode.IndexOf("'") == -1)
            {
                drugBillCode = "'" + drugBillCode + "'";
            }

            strSQL = string.Format(strSQL, drugBillCode);

            //根据SQL语句取数组并返回数组
            ArrayList arrayObject = new ArrayList();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取汇总摆药单时出错：" + this.Err;
                return null;
            }
            try
            {
                ApplyOut obj = null;
                while (this.Reader.Read())
                {
                    obj = new ApplyOut();
                    obj.ApplyDept.ID = this.Reader[0].ToString();                        //0申请部门编码（科室或者病区）
                    obj.StockDept.Name = this.Reader[1].ToString();                     //1发药部门编码 
                    obj.Item.ID = this.Reader[2].ToString();                             //2药品编码
                    obj.Item.Name = this.Reader[3].ToString();                           //3药品商品名
                    obj.Item.Specs = this.Reader[4].ToString();                          //4规格
                    obj.Item.PackUnit = this.Reader[5].ToString();                       //5包装单位
                    obj.Item.PackQty = NConvert.ToDecimal(this.Reader[6].ToString());    //6包装数
                    obj.Item.MinUnit = this.Reader[7].ToString();                        //7最小单位
                    obj.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString());//8零售价
                    obj.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[9].ToString());        //9申请出库量
                    obj.DrugNO = this.Reader[10].ToString();                           //10摆药单号
                    obj.PrintState = this.Reader[11].ToString();                         //11打印状态（0未打印，1已打印）
                    obj.Operation.ExamOper.ID = this.Reader[12].ToString();                       //12打印人
                    obj.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[13].ToString());      //13打印日期
                    obj.PlaceNO = this.Reader[14].ToString();							 //14货位号
                    obj.SendType = NConvert.ToInt32(this.Reader[15].ToString());	//15 发送标志
                    arrayObject.Add(obj);
                }
                return arrayObject;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得汇总摆药单时，执行SQL语句出错！GetDrugBillTotal" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 取明细摆药单
        /// //患者信息科室编码User01，摆药单号User02
        /// </summary>
        /// <param name="drugBillCode">摆药单号</param>
        /// <returns>成功返回摆药申请信息 失败返回null</returns>
        public ArrayList QueryDrugBillDetail(string drugBillCode)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDrugBillDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugBillDetail字段!";
                return null;
            }

            if (drugBillCode.IndexOf("'") == -1)
            {
                drugBillCode = "'" + drugBillCode + "'";
            }

            strSQL = string.Format(strSQL, drugBillCode);

            //根据SQL语句取数组并返回数组
            ArrayList arrayObject = new ArrayList();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取明细摆药单时出错：" + this.Err;
                return null;
            }
            try
            {
                ApplyOut obj; //患者信息科室编码User01，摆药单号User02

                while (this.Reader.Read())
                {
                    obj = new ApplyOut();
                    obj.ApplyDept.ID = this.Reader[0].ToString();                   //0申请部门编码（科室或者病区）
                    obj.StockDept.Name = this.Reader[1].ToString();                  //1发药部门编码 
                    obj.Item.ID = this.Reader[2].ToString();                        //2药品编码
                    obj.Item.Name = this.Reader[3].ToString();                      //3药品商品名
                    obj.Item.Specs = this.Reader[4].ToString();                     //4规格
                    obj.Item.PackUnit = this.Reader[5].ToString();                  //5包装单位
                    obj.Item.PackQty = NConvert.ToDecimal(this.Reader[6].ToString());//6包装数
                    obj.Item.MinUnit = this.Reader[7].ToString();                   //7最小单位
                    obj.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString()); //8零售价
                    obj.Days = NConvert.ToDecimal(this.Reader[9].ToString());       //9付数
                    obj.User01 = this.Reader[10].ToString();                        //10患者姓名
                    obj.User02 = this.Reader[11].ToString();                        //11床号
                    obj.DoseOnce = NConvert.ToDecimal(this.Reader[12].ToString());  //12每次剂量
                    obj.Item.DoseUnit = this.Reader[13].ToString();                 //13剂量单位
                    obj.Usage.ID = this.Reader[14].ToString();                      //14用法代码
                    obj.Usage.Name = this.Reader[15].ToString();                    //15用法名称
                    obj.Frequency.ID = this.Reader[16].ToString();                  //16频次代码
                    obj.Frequency.Name = this.Reader[17].ToString();                //17频次名称
                    obj.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[18].ToString());  //18申请出库量
                    obj.DrugNO = this.Reader[19].ToString();                      //19摆药单号
                    obj.PrintState = this.Reader[20].ToString();                    //20打印状态（0未打印，1已打印）
                    obj.Operation.ExamOper.ID = this.Reader[21].ToString();                  //21打印人
                    obj.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[22].ToString()); //22打印日期
                    obj.CombNO = this.Reader[23].ToString();						//23组合序号
                    obj.Memo = this.Reader[24].ToString();							//24医嘱备注
                    obj.PlaceNO = this.Reader[25].ToString();						//25货位号
                    obj.User03 = this.Reader[26].ToString();
                    obj.OrderNO = this.Reader[27].ToString();					//医嘱流水号
                    obj.SendType = NConvert.ToInt32(this.Reader[28].ToString());//发送类型 1 集中 2 临时 0 全部
                    obj.State = this.Reader[29].ToString();				//单据状态

                    arrayObject.Add(obj);
                }
                return arrayObject;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得明细摆药单时，执行SQL语句出错！GetDrugBillDetail" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }


        /// <summary>
        /// 取明细摆药单
        /// //患者信息科室编码User01，摆药单号User02
        /// 按照床位号排序
        /// </summary>
        /// <param name="drugBillCode">摆药单号</param>
        /// <returns>成功返回摆药申请信息 失败返回null</returns>
        public ArrayList QueryDrugBillDetailOrderByBedNO(string drugBillCode)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDrugBillDetailOrderByBedNo", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugBillDetailOrderByBedNo字段!";
                return null;
            }

            if (drugBillCode.IndexOf("'") == -1)
            {
                drugBillCode = "'" + drugBillCode + "'";
            }

            strSQL = string.Format(strSQL, drugBillCode);

            //根据SQL语句取数组并返回数组
            ArrayList arrayObject = new ArrayList();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取明细摆药单时出错：" + this.Err;
                return null;
            }
            try
            {
                ApplyOut obj; //患者信息科室编码User01，摆药单号User02

                while (this.Reader.Read())
                {
                    obj = new ApplyOut();
                    obj.ApplyDept.ID = this.Reader[0].ToString();                   //0申请部门编码（科室或者病区）
                    obj.StockDept.Name = this.Reader[1].ToString();                  //1发药部门编码 
                    obj.Item.ID = this.Reader[2].ToString();                        //2药品编码
                    obj.Item.Name = this.Reader[3].ToString();                      //3药品商品名
                    obj.Item.Specs = this.Reader[4].ToString();                     //4规格
                    obj.Item.PackUnit = this.Reader[5].ToString();                  //5包装单位
                    obj.Item.PackQty = NConvert.ToDecimal(this.Reader[6].ToString());//6包装数
                    obj.Item.MinUnit = this.Reader[7].ToString();                   //7最小单位
                    obj.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString()); //8零售价
                    obj.Days = NConvert.ToDecimal(this.Reader[9].ToString());       //9付数
                    obj.User01 = this.Reader[10].ToString();                        //10患者姓名
                    obj.User02 = this.Reader[11].ToString();                        //11床号
                    obj.DoseOnce = NConvert.ToDecimal(this.Reader[12].ToString());  //12每次剂量
                    obj.Item.DoseUnit = this.Reader[13].ToString();                 //13剂量单位
                    obj.Usage.ID = this.Reader[14].ToString();                      //14用法代码
                    obj.Usage.Name = this.Reader[15].ToString();                    //15用法名称
                    obj.Frequency.ID = this.Reader[16].ToString();                  //16频次代码
                    obj.Frequency.Name = this.Reader[17].ToString();                //17频次名称
                    obj.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[18].ToString());  //18申请出库量
                    obj.DrugNO = this.Reader[19].ToString();                      //19摆药单号
                    obj.PrintState = this.Reader[20].ToString();                    //20打印状态（0未打印，1已打印）
                    obj.Operation.ExamOper.ID = this.Reader[21].ToString();                  //21打印人
                    obj.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[22].ToString()); //22打印日期
                    obj.CombNO = this.Reader[23].ToString();						//23组合序号
                    obj.Memo = this.Reader[24].ToString();							//24医嘱备注
                    obj.PlaceNO = this.Reader[25].ToString();						//25货位号
                    obj.User03 = this.Reader[26].ToString();
                    obj.OrderNO = this.Reader[27].ToString();					//医嘱流水号
                    obj.SendType = NConvert.ToInt32(this.Reader[28].ToString());//发送类型 1 集中 2 临时 0 全部
                    obj.State = this.Reader[29].ToString();				//单据状态

                    arrayObject.Add(obj);
                }
                return arrayObject;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得明细摆药单时，执行SQL语句出错！GetDrugBillDetail" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 更新出库申请表中的打印状态为已打印
        /// 需要的数据：出库申请单流水号
        /// </summary>
        /// <param name="applyOut">出库申请记录</param>
        /// <returns>0没有更新（并发） 1成功 -1失败</returns>
        public int ExamApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            string strSQL = "";

            try
            {
                // 只打印摆药单。更新摆药状态为1
                if (applyOut.State == "1")
                {
                    //审批出库申请（打印摆药单），更新出库申请表中的打印状态为已打印，摆药单流水号，打印人，打印日期（系统时间）

                    //清空核准数据项中的数值
                    applyOut.Operation.ApproveOper.ID = "";            //核准人
                    applyOut.Operation.ApproveOper.OperTime = DateTime.MinValue; //核准日期
                    applyOut.Operation.ApproveOper.Dept.ID = "";             //核准科室
                }

                //取SQL语句
                if (this.Sql.GetSql("Pharmacy.Item.ExamApplyOut", ref strSQL) == -1)
                {
                    this.Err = "没有找到SQL语句Pharmacy.Item.ExamApplyOut";
                    return -1;
                }

                //取参数列表
                string[] strParm = {
									   applyOut.ID,                                         //出库申请单流水号
									   applyOut.State,                                      //出库申请状态
									   applyOut.Operation.ApproveOper.ID,                   //核准人
									   applyOut.Operation.ApproveOper.OperTime.ToString(),  //核准日期
									   applyOut.Operation.ApproveOper.Dept.ID,              //核准科室
									   applyOut.DrugNO,                                     //摆药单流水号
									   applyOut.Operation.ApproveQty.ToString(),            //核准数量
									   this.Operator.ID,                                    //打印人
									   applyOut.Operation.ExamOper.OperTime.ToString(),    //打印时间
									   applyOut.PlaceNO,     		                        //货位号
                                       NConvert.ToInt32(applyOut.IsCharge).ToString(),      //收费标记
                                       applyOut.RecipeNO,                                   //处方号
                                       applyOut.SequenceNO.ToString()                       //处方内项目流水号
								   };


                strSQL = string.Format(strSQL, strParm);          //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "审批出库申请SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 审核出库申请单信息
        /// 用来记录打印摆药单的状态，摆药单状态由前台传入（打印摆药单时直接核准扣库存则为1，否则为2）
        /// 如果此方法返回0，则表示有并发操作。
        /// </summary>
        /// <param name="applyOut">出库申请记录</param>
        /// <returns>0没有更新（并发） 1成功 -1失败</returns>
        public int ApproveApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            string strSQL = "";

            try
            {
                //确认发药，更新申请状态，发药数量，发药人，核准日期，核准科室
                if (this.Sql.GetSql("Pharmacy.Item.ApproveApplyOut", ref strSQL) == -1)
                {
                    this.Err = "没有找到SQL语句Pharmacy.Item.ApproveApplyOut";
                    return -1;
                }

                //取参数列表
                string[] strParm = {
									   applyOut.ID,                     //出库申请单流水号
									   applyOut.Operation.ApproveOper.ID,        //核准人
									   applyOut.Operation.ApproveOper.Dept.ID          //核准科室
								   };

                strSQL = string.Format(strSQL, strParm);          //替换SQL语句中的参数。

            }
            catch (Exception ex)
            {
                this.Err = "核准出库申请SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据执行档流水号更新申请有效性
        /// </summary>
        /// <param name="orderExecNO">执行档流水号</param>
        /// <param name="isValid">是否有效 True 有效 False 无效</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int UpdateApplyOutValidByExecNO(string orderExecNO, bool isValid)
        {
            string strSQL = "";
            //根据执行档流水号，作废出库申请记录的Update语句
            if (this.Sql.GetSql("Pharmacy.Item.CancelApplyOut.OrderExecNO", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.CancelApplyOut.OrderExecNO";
                return -1;
            }

            //1 恢复申请有效性 0 作废申请
            if (isValid)
                strSQL = string.Format(strSQL, orderExecNO, this.Operator.ID, ((int)Neusoft.HISFC.Models.Base.EnumValidState.Valid).ToString());
            else
                strSQL = string.Format(strSQL, orderExecNO, this.Operator.ID, ((int)Neusoft.HISFC.Models.Base.EnumValidState.Invalid).ToString());

            int parm = this.ExecNoQuery(strSQL);
            if (parm != 1)
                return parm;
            return 1;
        }

        /// <summary>
        /// 根据流水号更新申请有效性
        /// </summary>
        /// <param name="applyID">申请流水号</param>
        /// <param name="isValid">是否有效 True 有效 False 无效</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int UpdateApplyOutValidByID(string applyID, bool isValid)
        {
            string strSQL = "";
            //根据执行档流水号，作废出库申请记录的Update语句
            if (this.Sql.GetSql("Pharmacy.Item.CancelApplyOut.ApplyID", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.CancelApplyOut.ApplyID";
                return -1;
            }

            //1 恢复申请有效性 0 作废申请
            if (isValid)
                strSQL = string.Format(strSQL, applyID, this.Operator.ID, ((int)Neusoft.HISFC.Models.Base.EnumValidState.Valid).ToString());
            else
                strSQL = string.Format(strSQL, applyID, this.Operator.ID, ((int)Neusoft.HISFC.Models.Base.EnumValidState.Invalid).ToString());

            int parm = this.ExecNoQuery(strSQL);
            if (parm != 1)
                return parm;
            return 1;
        }

        /// <summary>
        /// 根据处方号更新申请有效性
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="sequenceNO">处方内项目流水号</param>
        /// <param name="isValid">是否有效 True 有效 False 无效</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int UpdateApplyOutValidByRecipeNO(string recipeNO, int sequenceNO, bool isValid)
        {
            string strSQL = "";
            //根据处方流水号和处方内序号，作废出库申请记录的Update语句
            if (this.Sql.GetSql("Pharmacy.Item.CancelApplyOut", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.CancelApplyOut";
                return -1;
            }

            //1 恢复申请有效性 0 作废申请
            if (isValid)
                strSQL = string.Format(strSQL, recipeNO, sequenceNO.ToString(), this.Operator.ID, ((int)Neusoft.HISFC.Models.Base.EnumValidState.Valid).ToString());
            else
                strSQL = string.Format(strSQL, recipeNO, sequenceNO.ToString(), this.Operator.ID, ((int)Neusoft.HISFC.Models.Base.EnumValidState.Invalid).ToString());

            int parm = this.ExecNoQuery(strSQL);
            if (parm != 1)
                return parm;

            return 1;
        }

        /// <summary>
        /// 根据患者信息 获取用药申请信息
        /// </summary>
        /// <param name="patientID">患者住院流水号</param>
        /// <param name="drugDeptCode">库存药房</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">截至时间</param>
        /// <returns>成功返回申请信息 失败返回null</returns>
        public ArrayList GetPatientApply(string patientID, string drugDeptCode, DateTime beginTime, DateTime endTime, string state)
        {
            return this.GetPatientApply(patientID, drugDeptCode, "AAAA", beginTime, endTime, state);
        }

        /// <summary>
        /// 根据患者信息 获取用药申请信息
        /// </summary>
        /// <param name="patientID">患者住院流水号</param>
        /// <param name="drugDeptCode">库存药房</param>
        /// <param name="applyDept">申请科室</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">截至时间</param>
        /// <param name="state">状态</param>
        /// <returns>成功返回申请信息 失败返回null</returns>
        public ArrayList GetPatientApply(string patientID, string drugDeptCode, string applyDept, DateTime beginTime, DateTime endTime, string state)
        {
            string strSelect = "";  //取某一科室申请，某一目标本科室未核准的SELECT语句
            string strWhere = "";  //取某一科室申请，某一目标本科室未核准的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.PatientValidApply", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.PatientValidApply字段!";
                return null;
            }

            try
            {
                string[] strParm = { patientID, drugDeptCode, applyDept, beginTime.ToString(), endTime.ToString(), state };
                strSelect = string.Format(strSelect + " " + strWhere, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSelect);
        }


        /// <summary>
        /// 获取时间段内的有效的患者用药申请信息
        /// 返回值为NeuObject ID 患者流水号 Name 患者姓名 Memo 申请科室
        /// </summary>
        /// <param name="drugDeptCode">库存药房</param>
        /// <param name="dtBegin">起始时间</param>
        /// <param name="dtEnd">终止时间</param>
        /// <param name="state">申请状态</param>
        /// <returns>成功返回用药申请信息 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryInPatientApplyOutList(string drugDeptCode, DateTime dtBegin, DateTime dtEnd, string state)
        {
            string strSelect = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryInPatientApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryInPatientApplyOutList字段!";
                return null;
            }

            try
            {
                string[] strParm = { drugDeptCode, dtBegin.ToString(), dtEnd.ToString(), state };
                strSelect = string.Format(strSelect, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取数组并返回数组
            List<Neusoft.FrameWork.Models.NeuObject> patientApplyList = new List<Neusoft.FrameWork.Models.NeuObject>();

            if (this.ExecQuery(strSelect) == -1)
            {
                this.Err = "取汇总摆药单时出错：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.FrameWork.Models.NeuObject info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();            //患者ID流水号
                    info.Name = this.Reader[1].ToString();          //患者姓名
                    info.Memo = this.Reader[2].ToString();          //申请科室

                    patientApplyList.Add(info);
                }

                return patientApplyList;
            }
            catch (Exception ex)
            {
                this.Err = "获得申请患者列表时，执行SQL语句出错" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获取时间段内的有效的患者用药申请信息
        /// 返回值为NeuObject ID 患者流水号 Name 患者姓名 Memo 申请科室
        /// </summary>
        /// <param name="drugDeptCode">库存药房</param>
        /// <param name="dtBegin">起始时间</param>
        /// <param name="dtEnd">终止时间</param>
        /// <param name="stateCollection">申请状态</param>
        /// <returns>成功返回用药申请信息 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryOutPatientApplyOutList(string drugDeptCode, DateTime dtBegin, DateTime dtEnd, params string[] stateCollection)
        {
            string strSelect = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryOutPatientApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryOutPatientApplyOutList字段!";
                return null;
            }

            try
            {
                string strState = "";
                foreach (string str in stateCollection)
                {
                    strState = str + "','" + strState;
                }
                string[] strParm = { drugDeptCode, dtBegin.ToString(), dtEnd.ToString(), strState };
                strSelect = string.Format(strSelect, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取数组并返回数组
            List<Neusoft.FrameWork.Models.NeuObject> patientApplyList = new List<Neusoft.FrameWork.Models.NeuObject>();

            if (this.ExecQuery(strSelect) == -1)
            {
                this.Err = "取汇总摆药单时出错：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.FrameWork.Models.NeuObject info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();            //患者ID流水号
                    info.Name = this.Reader[1].ToString();          //患者姓名
                    info.Memo = this.Reader[2].ToString();          //申请科室

                    patientApplyList.Add(info);
                }

                return patientApplyList;
            }
            catch (Exception ex)
            {
                this.Err = "获得申请患者列表时，执行SQL语句出错" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        #region 配置中心调用处理

        /// <summary>
        /// 获取配置中心列表
        /// </summary>
        /// <param name="drugDeptCode">库存科室</param>
        /// <param name="groupCode">批次</param>
        /// <returns>成功返回待配置患者列表 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> QueryCompoundList(string drugDeptCode, string groupCode, string state)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryCompoundList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCompoundList字段!";
                return null;
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, drugDeptCode, groupCode, state);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            #region 执行Sql语句由Reader内获取数据

            //根据SQL语句取数组并返回数组
            List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> applyList = new List<ApplyOut>();

            if (this.ExecQuery(strSelect) == -1)
            {
                this.Err = "获取待配置列表时发生错误：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut info;
                while (this.Reader.Read())
                {
                    info = new ApplyOut();

                    info.StockDept.ID = drugDeptCode;
                    info.ApplyDept.ID = this.Reader[0].ToString();              //申请科室
                    info.PatientNO = this.Reader[1].ToString();                 //患者住院流水号
                    info.User01 = this.Reader[2].ToString();                    //床号
                    info.User02 = this.Reader[3].ToString();                    //姓名

                    applyList.Add(info);
                }

                return applyList;
            }
            catch (Exception ex)
            {
                this.Err = "获得申请患者列表时，执行SQL语句出错" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            #endregion
        }

        /// <summary>
        /// 获取配置中心列表
        /// </summary>
        /// <param name="drugDeptCode">库存科室</param>
        /// <param name="state">状态</param>        
        /// <param name="isExecCompound">是否已执行配置</param>
        /// <returns>成功返回待配置患者列表 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> QueryCompoundList(string drugDeptCode, string state, bool isExecCompound)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryCompoundList.ExecState", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCompoundList.ExecState字段!";
                return null;
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, drugDeptCode, state, NConvert.ToInt32(isExecCompound).ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            #region 执行Sql语句由Reader内获取数据

            //根据SQL语句取数组并返回数组
            List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> applyList = new List<ApplyOut>();

            if (this.ExecQuery(strSelect) == -1)
            {
                this.Err = "获取待配置列表时发生错误：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut info;
                while (this.Reader.Read())
                {
                    info = new ApplyOut();

                    info.StockDept.ID = drugDeptCode;
                    info.ApplyDept.ID = this.Reader[0].ToString();              //申请科室
                    info.PatientNO = this.Reader[1].ToString();                 //患者住院流水号
                    info.User01 = this.Reader[2].ToString();                    //床号
                    info.User02 = this.Reader[3].ToString();                    //姓名

                    applyList.Add(info);
                }

                return applyList;
            }
            catch (Exception ex)
            {
                this.Err = "获得申请患者列表时，执行SQL语句出错" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            #endregion
        }

        /// <summary>
        /// 取某一申请科室未被核准的申请列表	
        /// </summary>
        /// <param name="drugDeptCode">库存科室</param>
        /// <param name="applyDeptCode">申请科室编码</param>
        /// <param name="groupCode">批次</param>
        /// <param name="patientID">患者住院流水号</param>
        /// <param name="state">申请数据状态</param>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryCompoundApplyOut(string drugDeptCode, string applyDeptCode, string groupCode, string patientID, string state, bool isExec)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Patient", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryCompoundApplyOut.Patient.GroupCode.ApplyDept", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCompoundApplyOut.Patient.GroupCode.ApplyDept字段!";
                return null;
            }

            #region Sql语句格式化

            if (groupCode == null)
            {
                groupCode = "U";
            }
            if (patientID == null)
            {
                patientID = "ALL";
            }

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, drugDeptCode, applyDeptCode, groupCode, patientID, state, NConvert.ToInt32(isExec).ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            #endregion

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSelect);
        }

        /// <summary>
        /// 配置信息检索。根据批次流水号
        /// </summary>
        /// <param name="compoundGroup">批次流水号</param>
        /// <returns></returns>
        public ArrayList QueryCompoundApplyOut(string compoundGroup)
        {
            string strSelect = "";  //取某一申请科室未被核准数据的SELECT语句
            string strWhere = "";  //取某一申请科室未被核准数据的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Patient", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryCompoundApplyOut.CompoundGroup", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCompoundApplyOut.CompoundGroup字段!";
                return null;
            }

            #region Sql语句格式化

            try
            {
                strSelect = string.Format(strSelect + " " + strWhere, compoundGroup);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            #endregion

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSelect);
        }

        /// <summary>
        /// 配置确认
        /// </summary>
        /// <param name="info">待确认数据</param>
        /// <param name="compoundOper">配置确认人</param>
        /// <param name="isExec">是否执行</param>
        /// <returns>成功返回大于1 更新函数 失败返回－1</returns>
        public int UpdateCompoundApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut info, Neusoft.HISFC.Models.Base.OperEnvironment compoundOper, bool isExec)
        {
            string strSQL = "";
            //根据处方流水号和处方内序号，作废出库申请记录的Update语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCompoundApplyOut", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateCompoundApplyOut";
                return -1;
            }

            strSQL = string.Format(strSQL, info.ID, compoundOper.ID, compoundOper.OperTime.ToString(), NConvert.ToInt32(isExec));

            int parm = this.ExecNoQuery(strSQL);
            if (parm != 1)
            {
                return parm;
            }

            return 1;
        }

        /// <summary>
        /// 更新批次流水号为流水号 (原始批次流水号位数过多)
        /// </summary>
        /// <param name="compoundGroup"></param>
        /// <returns></returns>
        public int UpdateCompoundGroupNO(string compoundGroup, ref string newCompoundGroupNO)
        {
            newCompoundGroupNO = this.GetNewCompoundGroup();
            if (newCompoundGroupNO == null)
            {
                return -1;
            }

            newCompoundGroupNO = compoundGroup.Substring(0, 1) + "-" + newCompoundGroupNO;

            string strSQL = "";
            //根据处方流水号和处方内序号，作废出库申请记录的Update语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCompoundGroupNO", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateCompoundGroupNO";
                return -1;
            }

            strSQL = string.Format(strSQL, compoundGroup, newCompoundGroupNO);

            int parm = this.ExecNoQuery(strSQL);
            if (parm != 1)
            {
                return parm;
            }

            return 1;
        }
        #endregion

        #endregion

        #region 门诊药房调用

        /// <summary>
        /// 获取门诊处方明细
        /// </summary>
        /// <param name="drugDept">库房编码</param>
        /// <param name="class3MeaningCode">出库分类</param>
        /// <param name="state">出库状态</param>
        /// <param name="recipeNo">处方号</param>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryApplyOutListForClinic(string drugDept, string class3MeaningCode, string state, string recipeNo)
        {
            string strSQL = "";  //取某一药房，某一张摆药单中的摆药数据的SQL语句
            string strWhere = "";  //取某一药房，某一张摆药单中的摆药数据的WHERE语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutListForClinic.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutListForClinic.Where字段!";
                return null;
            }

            try
            {
                strSQL = string.Format(strSQL + strWhere, drugDept, class3MeaningCode, state, recipeNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            //根据SQL语句取摆药数据数组并返回数组
            return this.myGetApplyOut(strSQL);
        }

        /// <summary>
        /// 门诊配药更新申请数据状态
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="class3MenaingCode">出库分类</param>
        /// <param name="recipeNo">处方号</param>
        /// <param name="sequenceNo">处方内项目序号</param>
        /// <param name="state">处方状态</param>
        /// <param name="operID">配药人</param>
        /// <param name="drugedNum">配药数量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateApplyOutStateForDruged(string deptCode, string class3MenaingCode, string recipeNo, int sequenceNo, string state, string operID, decimal drugedNum)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyOutState.Druged", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateApplyOutState.Druged";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, class3MenaingCode, recipeNo, sequenceNo, state, operID, drugedNum.ToString());
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.UpdateApplyOutState.Druged";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 门诊发药更新申请数据状态
        /// </summary>
        /// <param name="info">出库申请实体</param>
        /// <param name="state">处方状态</param>
        /// <param name="operID">发药人</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateApplyOutStateForSend(Neusoft.HISFC.Models.Pharmacy.ApplyOut info, string state, string operID)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyOutState.Send", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateApplyOutState.Send";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, info.StockDept.ID, info.SystemType, info.RecipeNO, info.SequenceNO.ToString(), state, info.Operation.ApproveOper.Dept.ID, operID, info.Operation.ApproveQty.ToString(), info.OutBillNO);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.UpdateApplyOutState.Send";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 获取某科室所有未发药患者药品列表
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns></returns>
        public ArrayList QueryClinicUnSendList(string deptCode)
        {
            string strSqlSelect = "", strSqlWhere = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSqlSelect) == -1)
            {
                return null;
            }
            if (this.Sql.GetSql("Pharmacy.Item.GetList.UnSend", ref strSqlWhere) == -1)
            {
                return null;
            }
            try
            {
                strSqlSelect = strSqlSelect + strSqlWhere;
                strSqlSelect = string.Format(strSqlSelect, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "参数不正确" + ex.Message;
                return null;
            }

            ArrayList al = this.myGetApplyOut(strSqlSelect);

            return al;
        }
        #endregion

        #region 药库管理调用

        /// <summary>
        /// 读取某科室的内部入库申请单列表
        /// </summary>
        /// <param name="deptCode">库房编码 申请科室</param>
        /// <param name="class3MeaningCode">三级权限码</param>
        /// <param name="applyState">申请单状态 0 申请 1 审批 2 核准 3 作废</param>
        /// <returns>成功返回neuobject数组 id 申请单号 Name 供货单位名称 meno 供货单位编码</returns>
        public ArrayList QueryApplyOutList(string deptCode, string class3MeaningCode, string applyState)
        {
            ArrayList al = new ArrayList();
            string strSQL = "";
            string strString = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutListByApplyDept", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutListByApplyDept字段!";
                return null;
            }
            try
            {
                strString = string.Format(strSQL, deptCode, class3MeaningCode, applyState);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            Neusoft.FrameWork.Models.NeuObject info;

            if (this.ExecQuery(strString) == -1)
            {
                this.Err = "获得内部入库申请信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();		//申请单号
                    info.Name = this.Reader[1].ToString();		//供货单位名称
                    info.Memo = this.Reader[2].ToString();		//供货单位编码

                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获取内部入库申请列表信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 根据供货单位获取发送到该单位的申请列表
        /// </summary>
        /// <param name="targetDept">供货单位</param>
        /// <param name="class3MeaningCode">三级权限码</param>
        /// <param name="applyState">申请单状态 0 申请 1 审批 2 核准 3 作废 </param>
        /// <returns>成功返回neuobject数组 id 申请单号 Name 供货单位名称 meno 供货单位编码</returns>
        public ArrayList QueryApplyOutListByTargetDept(string targetDept, string class3MeaningCode, string applyState)
        {
            ArrayList al = new ArrayList();
            string strSQL = "";
            string strString = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutListByTargetDept", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutListByTargetDept字段!";
                return null;
            }
            try
            {
                strString = string.Format(strSQL, targetDept, class3MeaningCode, applyState);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            Neusoft.FrameWork.Models.NeuObject info;
            if (this.ExecQuery(strString) == -1)
            {
                this.Err = "获得内部入库申请信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();		//申请单号
                    info.Name = this.Reader[1].ToString();		//申请单位名称
                    info.Memo = this.Reader[2].ToString();		//申请单位编码
                    //{455251A2-1D85-4a97-A517-C82E2A331775} 增加货位号
                    info.User01 = this.Reader[3].ToString();    //货位号

                    al.Add(info);
                }
                this.Reader.Close();
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获取内部入库申请列表信息出错" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据内部入库申请单号获取详细申请信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="listCode">申请单号</param>
        /// <param name="state">申请单状态</param>
        /// <returns>成功返回ApplyOut数组、失败返回null</returns>
        public ArrayList QueryApplyOutInfoByListCode(string deptCode, string listCode, string state)
        {
            string strSelect = "";
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutInfoByListCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutInfoByListCode字段!";
                return null;
            }

            try
            {
                string[] strParm = { deptCode, listCode, state };
                strSelect = string.Format(strSelect + " " + strWhere, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSelect);
        }

        /// <summary>
        /// 取某一科室申请，某一目标本科室未核准的申请列表
        /// 例如，某一药房查看某一科室的领用申请信息	
        /// </summary>
        /// <param name="targetDeptCode">出库部门编码</param>
        /// <param name="applyDeptCode">申请部门编码</param>
        /// <returns>成功返回申请信息数组 失败返回null</returns>
        public ArrayList QueryApplyOutList(string applyDeptCode, string targetDeptCode)
        {
            string strSelect = "";  //取某一科室申请，某一目标本科室未核准的SELECT语句
            string strWhere = "";  //取某一科室申请，某一目标本科室未核准的WHERE条件语句

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByTargeDept", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByTargeDept字段!";
                return null;
            }

            try
            {
                string[] strParm = { applyDeptCode, targetDeptCode };
                strSelect = string.Format(strSelect + " " + strWhere, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSelect);
        }

        #endregion

        /// <summary>
        /// 更新申请数据状态
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="listCode">申请单据号</param>
        /// <param name="state">申请状态</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int UpdateApplyOutState(string deptCode, string listCode, string state)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyOutState", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateApplyOutState";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, listCode, state, this.Operator.ID);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.UpdateApplyOutState";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新已打印标记
        /// </summary>
        /// <param name="applyID">申请流水号</param>
        /// <param name="isPrint">是否已打印</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int UpdateApplyOutPrintState(string applyID, bool isPrint)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyOutPrintState", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateApplyOutPrintState";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, applyID, NConvert.ToInt32(isPrint));
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.UpdateApplyOutPrintState";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对未审核的申请数据更新申请数量、申请日期
        /// </summary>
        /// <param name="ID">申请流水号</param>
        /// <param name="applyNum">申请数量</param>
        /// <returns>成功返回1 失败返回－1 无数据返回0</returns>
        public int UpdateApplyOutNum(string ID, decimal applyNum)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyOutNum", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateApplyOutNum";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ID, applyNum, this.Operator.ID);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.UpdateApplyOutNum";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据申请科室 获取 取药药房
        /// </summary>
        /// <param name="deptCode">申请科室</param>
        /// <param name="drugType">药品类别</param>
        /// <param name="drugCode">申请药品编码</param>
        /// <param name="applyQty">申请数量</param>
        /// <param name="trans">事务</param>
        /// <returns>成功返回取药药房</returns>
        public Neusoft.FrameWork.Models.NeuObject GetStockDeptByDeptCode(string deptCode, string drugType, string drugCode, decimal applyQty, System.Data.IDbTransaction trans, ref string strErr)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Constant();
            if (trans != null)
            {
                phaConsManager.SetTrans(trans);
            }

            strErr = "";

            List<Neusoft.FrameWork.Models.NeuObject> alStockDept = phaConsManager.GetRecipeDrugDept(deptCode, drugType);
            if (alStockDept == null || alStockDept.Count == 0)
            {
                strErr = "未设置取药药房";
                return null;
            }

            foreach (Neusoft.FrameWork.Models.NeuObject stockDept in alStockDept)
            {
                decimal storeQty = 0;
                this.GetStorageNum(stockDept.ID.ToString(), drugCode, out storeQty);
                if (storeQty >= applyQty)
                {
                    return stockDept;
                }
            }

            strErr = "对应取药药房库存不足";
            return null;
        }

        #endregion

        #region 对外接口

        /// <summary>
        /// 取消出库申请
        /// 根据出库申请流水号，作废出库申请
        /// </summary>
        /// <param name="ID">出库申请流水号</param>
        /// <param name="validState">有效状态</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int UpdateApplyOutValidState(string ID, string validState)
        {
            string strSQL = "";
            //根据处方流水号和处方内序号，作废出库申请记录的Update语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyOutValidState", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateApplyOutValidState";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ID, validState, this.Operator.ID);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.UpdateApplyOutValidState";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新摆药申请处方号
        /// </summary>
        /// <param name="oldRecipeNo">旧处方号</param>
        /// <param name="oldSeqNo">旧处方内项目序号</param>
        /// <param name="newRecipeNo">新处方号</param>
        /// <param name="newSeqNo">新处方内项目许号</param>
        /// <returns>成功返回1 出错返回-1</returns>
        public int UpdateApplyOutRecipe(string oldRecipeNo, int oldSeqNo, string newRecipeNo, int newSeqNo)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyOutRecipe", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.UpdateApplyOutRecipe";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, oldRecipeNo, oldSeqNo.ToString(), newRecipeNo, newSeqNo.ToString());
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.UpdateApplyOutRecipe";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #region 申请作废操作

        /// <summary>
        /// 取消门诊发药申请
        /// 根据处方流水号，作废门诊发药申请
        /// </summary>
        /// <param name="recipeNo">处方号</param>
        /// <param name="sequenceNo">处方内项目流水号</param>
        /// <param name="isPreOut">是否预扣库存</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int CancelApplyOutClinic(string recipeNo, int sequenceNo, bool isPreOut)
        {
            //定义药房管理类
            DrugStore drugStoreManager = new DrugStore();
            drugStoreManager.SetTrans(this.Trans);

            #region 作废申请明细信息
            string strSQL = "";
            if (sequenceNo != -1)
            {
                #region 作废一张处方内某条项目
                /*
				 *
			  UPDATE	PHA_COM_APPLYOUT  
				SET    	PHA_COM_APPLYOUT.VALID_STATE  = '{3}',			        --有效标记（0有效，1无效，2不摆药）
						PHA_COM_APPLYOUT.CANCEL_EMPL  = '{2}', 				--操作人
						PHA_COM_APPLYOUT.CANCEL_DATE   = SYSDATE 			--操作时间
				WHERE	PHA_COM_APPLYOUT.PARENT_CODE  = '000010'   
				AND		PHA_COM_APPLYOUT.CURRENT_CODE = '004004' 
				AND		PHA_COM_APPLYOUT.RECIPE_NO    = '{0}' 				--处方流水号
				AND		PHA_COM_APPLYOUT.SEQUENCE_NO  = {1}  				--处方内序号
				AND		PHA_COM_APPLYOUT.VALID_STATE <> '{3}'  				--有效标记（0有效，1无效，2不摆药） 
				AND     PHA_COM_APPLYOUT.APPLY_STATE in ('0','1') 
				*/
                //根据处方流水号和处方内序号，作废出库申请记录的Update语句
                if (this.Sql.GetSql("Pharmacy.Item.CancelApplyOut.Clinic.SingleRecipe", ref strSQL) == -1)
                {
                    this.Err = "没有找到SQL语句Pharmacy.Item.CancelApplyOut.Clinic.SingleRecipe";
                    return -1;
                }
                try
                {
                    //"0"表示作废此申请
                    strSQL = string.Format(strSQL, recipeNo, sequenceNo.ToString(), this.Operator.ID, ((int)Neusoft.HISFC.Models.Base.EnumValidState.Invalid).ToString());
                }
                catch
                {
                    this.Err = "传入参数不正确！Pharmacy.Item.CancelApplyOut";
                    return -1;
                }
                #endregion
            }
            else
            {
                #region 作废整张处方
                //根据处方流水号作废该处方的所有申请 门诊调用Update语句
                /*
                 *原Sql
                 UPDATE	 PHA_COM_APPLYOUT  
                 SET     PHA_COM_APPLYOUT.VALID_STATE  = '{2}',			        --有效标记（0有效，1无效，2不摆药）
                         PHA_COM_APPLYOUT.CANCEL_EMPL  = '{1}', 				--操作人
                         PHA_COM_APPLYOUT.CANCEL_DATE   = SYSDATE 			--操作时间
                WHERE	 PHA_COM_APPLYOUT.PARENT_CODE  = '000010'   
                AND		 PHA_COM_APPLYOUT.CURRENT_CODE = '004004' 
                AND		 PHA_COM_APPLYOUT.RECIPE_NO    = '{0}' 				--处方流水号
                AND		 PHA_COM_APPLYOUT.VALID_STATE <> '{2}'  				--有效标记（0有效，1无效，2不摆药） 
                AND      PHA_COM_APPLYOUT.APPLY_STATE = '0'
                应改为
                UPDATE	 PHA_COM_APPLYOUT  
                 SET     PHA_COM_APPLYOUT.VALID_STATE  = '{2}',			        --有效标记（0有效，1无效，2不摆药）
                         PHA_COM_APPLYOUT.CANCEL_EMPL  = '{1}', 				--操作人
                         PHA_COM_APPLYOUT.CANCEL_DATE   = SYSDATE 			--操作时间
                WHERE	 PHA_COM_APPLYOUT.PARENT_CODE  = '000010'   
                AND		 PHA_COM_APPLYOUT.CURRENT_CODE = '004004' 
                AND		 PHA_COM_APPLYOUT.RECIPE_NO    = '{0}' 				--处方流水号
                AND		 PHA_COM_APPLYOUT.VALID_STATE <> '{2}'  				--有效标记（0有效，1无效，2不摆药） 
                AND      PHA_COM_APPLYOUT.APPLY_STATE in('0','1')
                 * 
                */
                if (this.Sql.GetSql("Pharmacy.Item.CancelApplyOut.Clinic", ref strSQL) == -1)
                {
                    this.Err = "没有找到SQL语句Pharmacy.Item.CancelApplyOut.Clinic";
                    return -1;
                }
                try
                {
                    //"0"表示作废此申请
                    strSQL = string.Format(strSQL, recipeNo, this.Operator.ID, ((int)Neusoft.HISFC.Models.Base.EnumValidState.Invalid).ToString());
                }
                catch
                {
                    this.Err = "传入参数不正确！Pharmacy.Item.CancelApplyOut.Clinic";
                    return -1;
                }
                #endregion
            }

            //取消出库申请
            int parm = this.ExecNoQuery(strSQL);
            if (parm < 0)
            {
                return parm;
            }
            else if (parm == 0)
            {
                this.Err = "未正确找到需作废的数据 可能数据已发生变化";
                return parm;
            }
            #endregion


            //{22995EEE-0F07-4f0e-A130-AFC738AAE873}  先进行预扣库存处理
            //如果预扣库存,则在取消出库申请的时候,还回预扣的库存
            if (isPreOut)
            {
                if (sequenceNo == -1)
                {
                    #region 还整张处方预扣库存
                    //取摆药申请数据
                    ArrayList al = this.QueryApplyOut(recipeNo);
                    if (al == null) return -1;

                    //还回预扣库存
                    //取消摆药申请时预扣减少（负数），取消退药申请时不处理预扣库存（退药确认时处理）
                    foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in al)
                    {
                        if (applyOut.BillClassNO != "R")
                        {
                            //预扣库存处理 //{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                            if (this.UpdateStockinfoPreOutNum(applyOut, -applyOut.Operation.ApplyQty,applyOut.Days) == -1)
                            {
                                return -1;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 还处方内一条记录库存
                    //取摆药申请数据
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.GetApplyOut(recipeNo, sequenceNo);
                    if (applyOut == null) return -1;

                    //还回预扣库存
                    //取消摆药申请时预扣减少（负数），取消退药申请时不处理预扣库存（退药确认时处理）
                    if (applyOut.BillClassNO != "R")
                    {
                        //预扣库存处理 //{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                        if (this.UpdateStockinfoPreOutNum(applyOut, -applyOut.Operation.ApplyQty, applyOut.Days) == -1)
                        {
                            return -1;
                        }
                    }
                    #endregion
                }
            }

            //{22995EEE-0F07-4f0e-A130-AFC738AAE873}  先进行预扣库存处理
            //作废处方调剂表
            parm = drugStoreManager.UpdateDrugRecipeValidState(recipeNo, "M1", Neusoft.HISFC.Models.Base.EnumValidState.Invalid);
            if (parm < 0)
            {
                return parm;
            }
            else if (parm == 0)
            {
                this.Err = "该申请信息已发药 不能再次作废发药申请";
                this.ErrCode = "2";
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// 取消出库申请
        /// 根据处方流水号和处方内序号，作废出库申请
        /// </summary>
        /// <param name="recipeNo">处方流水号</param>
        /// <param name="sequenceNo">处方内序号</param>
        /// <param name="isPreOut">是否预扣库存</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int CancelApplyOut(string recipeNo, int sequenceNo, bool isPreOut)
        {
            int parm = this.UpdateApplyOutValidByRecipeNO(recipeNo, sequenceNo, false);
            if (parm < 1)
            {
                if (parm == 0)
                {
                    this.Err = "该条药品已发药或做过退费申请，不能退费";
                }

                return -1;
            }

            //如果预扣库存,则在取消出库申请的时候,还回预扣的库存
            if (isPreOut)
            {
                //取摆药申请数据
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.GetApplyOut(recipeNo, sequenceNo);
                if (applyOut == null)
                    return -1;

                //还回预扣库存  取消摆药申请时预扣减少（负数），取消退药申请时不处理预扣库存（退药确认时处理）
                if (applyOut.BillClassNO != "R")
                {
                    //预扣库存处理 //{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                    if (this.UpdateStockinfoPreOutNum(applyOut, -applyOut.Operation.ApplyQty, applyOut.Days) == -1)
                    {
                        return -1;
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// 撤销取消出库申请（取消申请的逆过程）
        /// 根据处方流水号和处方内序号，撤销作废出库申请
        /// </summary>
        /// <param name="recipeNo">处方流水号</param>
        /// <param name="sequenceNo">处方内序号</param>
        /// <param name="isPreOut">是否预扣库存</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int UndoCancelApplyOut(string recipeNo, int sequenceNo, bool isPreOut)
        {
            //int parm = this.UpdateApplyOutValidByRecipeNO( recipeNo , sequenceNo , true );
            //if( parm != 1 )
            //    return parm;

            DrugStore drugStoreManager = new DrugStore();
            drugStoreManager.SetTrans(this.Trans);
            //获取摆药申请信息
            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOutTemp = this.GetApplyOut(recipeNo, sequenceNo);
            if (applyOutTemp == null)
                return -1;

            int parm = this.UpdateApplyOutValidByID(applyOutTemp.ID, true);
            if (parm != 1)
                return parm;


            if (drugStoreManager.UpdateDrugMessage(applyOutTemp.StockDept.ID, applyOutTemp.ApplyDept.ID, applyOutTemp.BillClassNO, applyOutTemp.SendType, "0") != 1)
            {
                this.Err = "更新摆药通知记录发生错误" + drugStoreManager.Err;
                return -1;
            }

            //如果预扣库存,则在取消出库申请的时候,还回预扣的库存
            if (isPreOut)
            {
                //还回预扣库存 恢复摆药申请时预扣增加（正数）
                if (applyOutTemp.BillClassNO != "R")
                {
                    ////{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                    if (this.UpdateStockinfoPreOutNum(applyOutTemp, applyOutTemp.Operation.ApplyQty, applyOutTemp.Days) == -1)
                    {
                        return -1;
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// 作废出库申请信息
        /// </summary>
        /// <param name="orderExecNO">执行档流水号</param>
        /// <param name="isPreOut">是否预出库</param>
        /// <returns>成功返回受影响条数 失败返回-1</returns>
        public int CancelApplyOut(string orderExecNO, bool isPreOut)
        {
            //申请信息作废
            int parm = this.UpdateApplyOutValidByExecNO(orderExecNO, false);
            if (parm != 1)
                return parm;

            //如果预扣库存,则在取消出库申请的时候,还回预扣的库存
            if (isPreOut)
            {
                //取摆药申请数据
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.GetApplyOutByExecNO(orderExecNO);
                if (applyOut == null)
                    return -1;

                //还回预扣库存       //取消摆药申请时预扣减少（负数），取消退药申请时不处理预扣库存（退药确认时处理）
                if (applyOut.BillClassNO != "R")
                {
                    ////{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                    if (this.UpdateStockinfoPreOutNum(applyOut, -applyOut.Operation.ApplyQty , applyOut.Days) == -1)
                    {
                        return -1;
                    }
                }
            }

            return 1;
        }

        /// <summary>
        /// 撤销取消出库申请（取消申请的逆过程）
        /// 根据申请档流水号进行更新
        /// </summary>
        /// <param name="orderExecNO">执行档流水号</param>
        /// <param name="isPreOut">是否预扣库存</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int UndoCancelApplyOut(string orderExecNO, bool isPreOut)
        {
            //申请信息置为有效
            int parm = this.UpdateApplyOutValidByExecNO(orderExecNO, true);
            if (parm != 1)
                return parm;

            //定义药房管理类
            DrugStore drugStoreManager = new DrugStore();
            drugStoreManager.SetTrans(this.Trans);
            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOutTemp = this.GetApplyOutByExecNO(orderExecNO);
            if (applyOutTemp == null)
                return -1;

            if (drugStoreManager.UpdateDrugMessage(applyOutTemp.StockDept.ID, applyOutTemp.ApplyDept.ID, applyOutTemp.BillClassNO, applyOutTemp.SendType, "0") != 1)
            {
                this.Err = "更新摆药通知记录发生错误" + drugStoreManager.Err;
                return -1;
            }

            //如果预扣库存,则在取消出库申请的时候,还回预扣的库存
            if (isPreOut)
            {
                //还回预扣库存       //恢复摆药申请时预扣增加（正数），恢复退药申请时不处理预扣（退药确认时处理）
                if (applyOutTemp.BillClassNO != "R")
                {
                    //{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                    if (this.UpdateStockinfoPreOutNum(applyOutTemp, applyOutTemp.Operation.ApplyQty, applyOutTemp.Days) == -1)
                    {
                        return -1;
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// 作废出库申请信息
        /// </summary>
        /// <param name="applyID">申请档流水号</param>
        /// <param name="isPreOut">是否预出库</param>
        /// <returns>成功返回受影响条数 失败返回-1</returns>
        public int CancelApplyOutByID(string applyID, bool isPreOut)
        {
            //申请信息作废
            int parm = this.UpdateApplyOutValidByID(applyID, false);
            if (parm != 1)
                return parm;

            //如果预扣库存,则在取消出库申请的时候,还回预扣的库存
            if (isPreOut)
            {
                //取摆药申请数据
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.GetApplyOutByID(applyID);
                if (applyOut == null)
                    return -1;

                //还回预扣库存       //取消摆药申请时预扣减少（负数），取消退药申请时不处理预扣库存（退药确认时处理）
                if (applyOut.BillClassNO != "R")
                {
                    //{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                    if (this.UpdateStockinfoPreOutNum(applyOut, -applyOut.Operation.ApplyQty , applyOut.Days) == -1)
                    {
                        return -1;
                    }
                }
            }

            return 1;
        }

        /// <summary>
        /// 撤销取消出库申请（取消申请的逆过程）
        /// 根据申请流水号进行更新
        /// </summary>
        /// <param name="applyID">申请流水号</param>
        /// <param name="isPreOut">是否预扣库存</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int UndoCancelApplyOutByID(string applyID, bool isPreOut)
        {
            //申请信息置为有效
            int parm = this.UpdateApplyOutValidByID(applyID, true);
            if (parm != 1)
                return parm;

            //定义药房管理类
            DrugStore drugStoreManager = new DrugStore();
            drugStoreManager.SetTrans(this.Trans);
            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOutTemp = this.GetApplyOutByID(applyID);
            if (applyOutTemp == null)
                return -1;

            if (drugStoreManager.UpdateDrugMessage(applyOutTemp.StockDept.ID, applyOutTemp.ApplyDept.ID, applyOutTemp.BillClassNO, applyOutTemp.SendType, "0") != 1)
            {
                this.Err = "更新摆药通知记录发生错误" + drugStoreManager.Err;
                return -1;
            }

            //如果预扣库存,则在取消出库申请的时候,还回预扣的库存
            if (isPreOut)
            {
                //还回预扣库存       //恢复摆药申请时预扣增加（正数），恢复退药申请时不处理预扣（退药确认时处理）
                if (applyOutTemp.BillClassNO != "R")
                {
                    //{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                    if (this.UpdateStockinfoPreOutNum(applyOutTemp, applyOutTemp.Operation.ApplyQty, applyOutTemp.Days) == -1)
                    {
                        return -1;
                    }
                }
            }
            return 1;
        }

        #endregion

        #region 申请操作

        #region 住院申请操作

        //{3E83AFA1-C364-4f72-8DFD-1B733CB9379E}
        //增加查询患者是否有未审核的退药记录,为出院登记判断用 Add by 王宇 2009.6.10

        /// <summary>
        /// 查询住院患者是否有未确认的退药申请
        /// </summary>
        /// <param name="inpatientNO">患者住院流水号</param>
        /// <returns>成功 > 0 记录 0 没有记录 -1 错误</returns>
        public int QueryNoConfirmQuitApply(string inpatientNO) 
        {
            string sql = string.Empty;

            int returnValue = this.Sql.GetSql("Pharmacy.Item.QueryNoConfirmQuitApply.Select.1", ref sql);
            if (returnValue < 0) 
            {
                this.Err = "没有找到SQL为Pharmacy.Item.QueryNoConfirmQuitApply.Select.1的SQL语句";

                return -1;
            }
            try
            {
                sql = string.Format(sql, inpatientNO);
            }
            catch (Exception ex) 
            {
                this.Err = ex.Message;

                return -1;
            }

            return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(sql));
        }
        ////{3E83AFA1-C364-4f72-8DFD-1B733CB9379E} 添加完毕

        /// <summary>
        /// 申请出库－－对医嘱子系统公开的函数
        /// </summary>
        /// <param name="execOrder">医嘱执行实体</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="isPreOut">是否预出库</param>
        /// <param name="applyDeptType">申请科室类型 0 科室 1 护理站</param>
        /// <param name="getStockDept">是否根据申请科室获取取药药房</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int ApplyOut(Neusoft.HISFC.Models.Order.ExecOrder execOrder, DateTime operDate, bool isPreOut, string applyDeptType, bool getStockDept)
        {
            #region 函数执行操作
            // 执行操作：
            // 1、execOrder对象转为出库申请对象
            // 2、取药品的所属的摆药单
            // 3、插入摆药通知
            // 4、插入出库申请
            // 5、预扣库存
            #endregion

            //定义药房管理类
            DrugStore myDrugStore = new DrugStore();
            Constant consManager = new Constant();

            myDrugStore.SetTrans(this.Trans);
            consManager.SetTrans(this.Trans);

            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = new ApplyOut();

            try
            {
                #region Applyout实体赋值

                applyOut.Item = (Neusoft.HISFC.Models.Pharmacy.Item)execOrder.Order.Item;       //药品实体

                #region 申请科室/发药科室获取

                if (applyDeptType == "0")       //申请科室为患者科室
                {
                    applyOut.ApplyDept = execOrder.Order.Patient.PVisit.PatientLocation.Dept;
                }
                else                           //申请科室为病区
                {
                    applyOut.ApplyDept = execOrder.Order.Patient.PVisit.PatientLocation.NurseCell;
                }

                applyOut.StockDept = execOrder.Order.StockDept;

                if (getStockDept)
                {
                    string strErr = "";
                    Neusoft.FrameWork.Models.NeuObject stockOjb = this.GetStockDeptByDeptCode(applyOut.ApplyDept.ID, applyOut.Item.Type.ID, applyOut.Item.ID, execOrder.Order.Qty, this.Trans, ref strErr);
                    if (stockOjb != null)
                    {
                        applyOut.StockDept.ID = stockOjb.ID;
                        applyOut.StockDept.Name = stockOjb.Name;
                    }
                }

                #endregion

                #region 库存判断

                if (isPreOut)
                {
                    //获取库存方法性能优化 by Sunjh 2010-8-30 {C2BF59BC-9C07-4b0a-A5E2-797426CCDE81}
                    //Neusoft.HISFC.Models.Pharmacy.Storage storage = this.GetStockInfoByDrugCode(applyOut.StockDept.ID, applyOut.Item.ID);
                    Neusoft.HISFC.Models.Pharmacy.Storage storage = this.GetStockInfoByDrugCodeOptimize(applyOut.StockDept.ID, applyOut.Item.ID);
                    
                    if (storage == null || storage.Item.ID == "")
                    {
                        this.Err = applyOut.Item.Name + "－ 在该药房不存在库存 无法进行发药收费！" + this.Err;
                        return -1;
                    }
                    if (storage.IsStop)
                    {
                        this.Err = applyOut.Item.Name + "－ 在药房已停用 不能进行发药收费！";
                        return -1;
                    }
                    //对允许扣除负库存时 不进行此项判断
                    if (isPreOut)
                    {
                        #region {D99D681D-997C-4896-A7B6-229FAA854225}
                        decimal orderDays = execOrder.Order.HerbalQty;
                        if (orderDays <= 0)
                        {
                            orderDays = 1;
                        }
                        #endregion
                        if (!Item.MinusStore && (storage.StoreQty - storage.PreOutQty) < execOrder.Order.Qty * orderDays)//{D99D681D-997C-4896-A7B6-229FAA854225}
                        {
                            this.Err = applyOut.Item.Name + "－ 在药房库存不足以进行本次收费发药 不能收费！";
                            return -1;
                        }
                    }
                    else
                    {
                        #region {D99D681D-997C-4896-A7B6-229FAA854225}
                        decimal orderDays = execOrder.Order.HerbalQty;
                        if (orderDays <= 0)
                        {
                            orderDays = 1;
                        }
                        #endregion
                        if (!Item.MinusStore && storage.StoreQty < execOrder.Order.Qty * orderDays)//{D99D681D-997C-4896-A7B6-229FAA854225}
                        {
                            this.Err = applyOut.Item.Name + "－ 在药房库存不足以进行本次收费发药 不能收费！";
                            return -1;
                        }
                    }
                    //长期医嘱分解时没有包装单位 在此处赋值 临时修改
                    applyOut.Item.PackUnit = storage.Item.PackUnit;
                }

                #endregion

                #region 批次信息设置

                //设置批次流水号
                applyOut.CompoundGroup = consManager.GetOrderGroup(execOrder.DateUse);
                if (applyOut.CompoundGroup == null)
                {
                    applyOut.CompoundGroup = "4";
                }
                applyOut.CompoundGroup = applyOut.CompoundGroup + execOrder.DateUse.ToString("yyMMdd") + execOrder.Order.Combo.ID + "C";

                #endregion

                #region 申请信息设置

                applyOut.SystemType = "Z1";                                                     //申请类型＝"Z1" 
                applyOut.Operation.ApplyOper.OperTime = operDate;                               //申请时间＝操作时间
                applyOut.Days = execOrder.Order.HerbalQty == 0 ? 1 : execOrder.Order.HerbalQty; //草药付数
                applyOut.IsPreOut = isPreOut;                                                   //是否预扣库存
                applyOut.IsCharge = execOrder.IsCharge;                                         //是否收费
                applyOut.PatientNO = execOrder.Order.Patient.ID;                                //患者住院流水号
                applyOut.PatientDept = execOrder.Order.Patient.PVisit.PatientLocation.Dept;     //患者所在科室
                applyOut.DoseOnce = execOrder.Order.DoseOnce;                                   //每次剂量
                applyOut.Frequency = execOrder.Order.Frequency;                                 //频次
                applyOut.Usage = execOrder.Order.Usage;                                         //用法
                applyOut.OrderType = execOrder.Order.OrderType;                                 //医嘱类型
                applyOut.OrderNO = execOrder.Order.ID;                                          //医嘱流水号
                applyOut.CombNO = execOrder.Order.Combo.ID;                                     //组合序号
                applyOut.ExecNO = execOrder.ID;                                                 //医嘱执行单流水号
                applyOut.RecipeNO = execOrder.Order.ReciptNO;                                   //处方号
                applyOut.SequenceNO = execOrder.Order.SequenceNO;                               //处方内流水号
                applyOut.SendType = execOrder.DrugFlag;                                         //发送类型1集中，2临时
                applyOut.State = "0";						                                    //出库申请状态:0申请,1摆药,2核准
                applyOut.User03 = execOrder.DateUse.ToString();	                                //用药时间
                applyOut.Memo = execOrder.Order.Memo;			                                //医嘱备注
                applyOut.ShowState = "0";
                applyOut.Operation.ApplyQty = execOrder.Order.Qty;

                applyOut.RecipeInfo.Dept = execOrder.Order.ReciptDept;                          //开方科室
                applyOut.RecipeInfo.ID = execOrder.Order.ReciptDoctor.ID;                       //开方医生
                applyOut.RecipeInfo.Name = execOrder.Order.ReciptDoctor.Name;

                applyOut.IsBaby = execOrder.Order.IsBaby;

                #endregion

                #endregion

                if (applyOut.IsCharge)      //对于收费后才进行此处判断
                {
                    if (applyOut.RecipeNO == null || applyOut.RecipeNO == "")
                    {
                        this.Err = "医嘱传入处方号为空值!";
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Err = "将医嘱执行实体转换成出库申请实体时出错！" + ex.Message;
                return -1;
            }

            //根据出库申请数据，查询所属摆药单分类，将分类编码存入出库申请表中，并插入摆药通知记录
            DrugBillClass billClass = myDrugStore.GetDrugBillClass(
                applyOut.OrderType.ID,
                applyOut.Usage.ID,
                applyOut.Item.Type.ID,
                applyOut.Item.Quality.ID.ToString(),
                applyOut.Item.DosageForm.ID
                );
            //没有找到摆药单，也会返回null
            if (billClass == null)
            {
                this.Err = myDrugStore.Err;
                this.ErrCode = myDrugStore.ErrCode;
                return -1;
            }

            #region 插入摆药通知记录

            #region 由于采用了集中发药方案，所以这里需要判断处理（集中发药时，审核和分解医嘱不更新通知档，否则更新） {7C848A97-8571-4162-AB11-294BE5FE5E76} wbo 2010-11-29
            //DrugMessage drugMessage = new DrugMessage();
            //drugMessage.ApplyDept = applyOut.ApplyDept;    //科室或者病区
            //drugMessage.DrugBillClass = billClass;        //摆药单分类
            //drugMessage.SendType = applyOut.SendType;     //发送类型0全部,1-集中,2-临时
            //drugMessage.SendFlag = 0;                     //状态0-通知,1-已摆
            //drugMessage.StockDept = applyOut.StockDept;   //发药科室

            //if (myDrugStore.SetDrugMessage(drugMessage) != 1)
            //{
            //    this.Err = myDrugStore.Err;
            //    return -1;
            //}

            Neusoft.FrameWork.Management.ControlParam controlParam = new Neusoft.FrameWork.Management.ControlParam();
            string result = controlParam.QueryControlerInfo("P01016", true);//获取参数，可以为空
            bool isConcentrateSend = false;//定义是否集中发送，默认否
            if (string.IsNullOrEmpty(result))//如果数据库没有这个参数，默认为非集中发送方式
            {
                isConcentrateSend = false;
            }
            else
            {
                if (NConvert.ToBoolean(result) == true)//集中发送
                {
                    isConcentrateSend = true;
                }
                else
                {
                    isConcentrateSend = false;
                }
            }
            //非集中发送才更新通知档
            if (isConcentrateSend == false)
            {
                DrugMessage drugMessage = new DrugMessage();
                drugMessage.ApplyDept = applyOut.ApplyDept;    //科室或者病区
                drugMessage.DrugBillClass = billClass;        //摆药单分类
                drugMessage.SendType = applyOut.SendType;     //发送类型0全部,1-集中,2-临时
                drugMessage.SendFlag = 0;                     //状态0-通知,1-已摆
                drugMessage.StockDept = applyOut.StockDept;   //发药科室

                if (myDrugStore.SetDrugMessage(drugMessage) != 1)
                {
                    this.Err = myDrugStore.Err;
                    return -1;
                }
            }
            #endregion

            #endregion

            #region 插入申请信息 预扣库存操作

            //将分类编码存入出库申请表中
            applyOut.BillClassNO = billClass.ID;
            //插入出库申请表
            int parm = this.InsertApplyOut(applyOut);
            if (parm == -1)
            {
                if (applyOut.ExecNO != "" && applyOut.ExecNO != null)
                {
                    if (this.UpdateApplyOutValidByExecNO(applyOut.ExecNO, true) >= 1)
                    {
                        this.Err = "申请档信息重复发送 \n" + applyOut.ExecNO + this.Err;
                        return -1;

                    }
                }

                return parm;
            }

            //{8113BE34-A5E0-4d87-B6FF-B8428BAA8711}  此处屏蔽预扣  预扣操作由外部Integrate处理
            ////预扣库存（加操作）
            if (isPreOut)
            {
                //parm = this.UpdateStoragePreOutNum(applyOut.StockDept.ID, applyOut.Item.ID, applyOut.Operation.ApplyQty);
                //if (parm == -1) return parm;

                ////{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                parm = this.UpdateStockinfoPreOutNum(applyOut, applyOut.Operation.ApplyQty, applyOut.Days);
                if (parm == -1) return parm;
            }

            #endregion

            return 1;
        }

        /// <summary>
        /// 申请出库－－对费用公开的函数
        /// </summary>
        /// <param name="patient">患者信息实体</param>
        /// <param name="feeItem">患者费用信息实体</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="isPreOut">是否预出库</param>
        /// <param name="applyDeptType">申请科室类型 0 科室 1 护理站</param>
        /// <param name="getStockDept">是否根据申请科室获取取药药房</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int ApplyOut(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem, DateTime operDate, bool isPreOut, string applyDeptType, bool getStockDept)
        {
            #region 函数执行操作 将FeeItemList对象转为出库申请对象，然后插入出库申请表
            // 执行操作：
            // 1、FeeItemList对象转为出库申请对象
            // 2、取药品的所属的摆药单
            // 3、插入摆药通知
            // 4、插入出库申请
            // 5、预扣库存
            #endregion

            //定义药房管理类
            DrugStore myDrugStore = new DrugStore();
            Constant consManager = new Constant();

            myDrugStore.SetTrans(this.Trans);
            consManager.SetTrans(this.Trans);

            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = new ApplyOut();

            try
            {
                #region ApplyOut实体赋值

                applyOut.Item = (Neusoft.HISFC.Models.Pharmacy.Item)feeItem.Clone().Item;           //药品实体
                applyOut.Item.PriceCollection.RetailPrice = feeItem.Item.Price;            //零售价
                applyOut.Item.MinUnit = feeItem.Item.PriceUnit;                             //最小单位＝记价单位

                #region 申请科室/发药药房获取

                if (applyDeptType == "0")                               //申请科室＝开方科室
                    applyOut.ApplyDept = feeItem.ExecOper.Dept;
                else                                                    //申请科室＝发送护士站
                    applyOut.ApplyDept = ((Neusoft.HISFC.Models.RADT.PatientInfo)feeItem.Patient).PVisit.PatientLocation.NurseCell;

                applyOut.StockDept = feeItem.StockOper.Dept;            //发药科室＝医嘱药房
                if (getStockDept)
                {
                    string strErr = "";
                    Neusoft.FrameWork.Models.NeuObject stockOjb = this.GetStockDeptByDeptCode(applyOut.ApplyDept.ID, applyOut.Item.Type.ID, applyOut.Item.ID, feeItem.Item.Qty, this.Trans, ref strErr);
                    if (stockOjb != null)
                    {
                        applyOut.StockDept.ID = stockOjb.ID;
                        applyOut.StockDept.Name = stockOjb.Name;
                    }
                    else
                    {
                        //this.Err = applyOut.ApplyDept.Name + "[" + applyOut.ApplyDept.ID + "]未维护取药药房";
                        this.Err = applyOut.ApplyDept.Name + "[" + applyOut.ApplyDept.ID + "] " + strErr;
                        return -1;
                    }
                }

                #endregion

                #region 库存判断

                if (isPreOut)
                {
                    Neusoft.HISFC.Models.Pharmacy.Storage storage = this.GetStockInfoByDrugCode(applyOut.StockDept.ID, feeItem.Item.ID);
                    if (storage == null || storage.Item.ID == "")
                    {
                        this.Err = applyOut.Item.Name + "－ 在该药房不存在库存 无法进行发药收费！" + this.Err;
                        return -1;
                    }
                    if (storage.IsStop)
                    {
                        this.Err = applyOut.Item.Name + "－ 在药房已停用 不能进行发药收费！";
                        return -1;
                    }
                    //对允许扣除负库存时 不进行此项判断
                    if (isPreOut)
                    {
                        if (!Item.MinusStore && (storage.StoreQty - storage.PreOutQty) < feeItem.Item.Qty)
                        {
                            this.Err = applyOut.Item.Name + "－ 在药房库存不足以进行本次收费发药 不能收费！";
                            return -1;
                        }
                    }
                    else
                    {
                        if (!Item.MinusStore && storage.StoreQty < feeItem.Item.Qty)
                        {
                            this.Err = applyOut.Item.Name + "－ 在药房库存不足以进行本次收费发药 不能收费！";
                            return -1;
                        }
                    }
                }

                #endregion

                #region 批次信息赋值

                applyOut.CompoundGroup = consManager.GetOrderGroup(operDate);
                if (applyOut.CompoundGroup == null)
                {
                    applyOut.CompoundGroup = "4";
                }
                applyOut.CompoundGroup = applyOut.CompoundGroup + operDate.ToString("yyMMdd") + feeItem.Order.Combo.ID + "C";

                #endregion

                #region ApplyOut赋值

                applyOut.SystemType = "Z1";                             //申请类型＝"Z1" 
                applyOut.Operation.ApplyOper.OperTime = operDate;       //申请时间＝操作时间

                //{55325559-19EB-4cac-8D6D-5BECEB4A03F5}
                //applyOut.Days = feeItem.Order.HerbalQty == 0 ? 1 : feeItem.Order.HerbalQty;     //草药付数
                applyOut.Days = feeItem.Days;

                applyOut.IsPreOut = isPreOut;                           //是否预扣库存
                applyOut.IsCharge = true;                               //是否收费
                applyOut.PatientNO = patient.ID;                        //患者住院流水号,传入参数
                applyOut.PatientDept = ((Neusoft.HISFC.Models.RADT.PatientInfo)feeItem.Patient).PVisit.PatientLocation.Dept;//患者所在科室
                applyOut.DoseOnce = feeItem.Order.DoseOnce;             //每次剂量
                applyOut.Frequency = feeItem.Order.Frequency;           //频次
                applyOut.Usage = feeItem.Order.Usage;                   //用法

                applyOut.OrderType = feeItem.Order.OrderType; //医嘱类型

                applyOut.OrderNO = feeItem.Order.ID;                    //医嘱流水号
                applyOut.CombNO = feeItem.Order.Combo.ID;               //组合序号
                applyOut.ExecNO = feeItem.ExecOrder.ID;                     //医嘱执行单流水号
                applyOut.RecipeNO = feeItem.RecipeNO;                   //处方号
                applyOut.SequenceNO = feeItem.SequenceNO;               //处方内流水号
                applyOut.SendType = 2;                                  //发送类型1集中，2临时
                applyOut.State = "0";							        //出库申请状态:0申请,1摆药,2核准
                applyOut.ShowState = "0";

                #endregion

                //费用表中的数量是乘以付数以后的总数量,药品表中保存的是每付的量,在此转换.
                applyOut.Operation.ApplyQty = feeItem.Item.Qty / applyOut.Days;

                applyOut.RecipeInfo = feeItem.RecipeOper;
                applyOut.IsBaby = feeItem.IsBaby;

                #endregion

                if (applyOut.RecipeNO == null || applyOut.RecipeNO == "")
                {
                    this.Err = "医嘱传入处方号为空值!";
                    return -1;
                }
            }
            catch (Exception ex)
            {
                this.Err = "将费用实体转换成出库申请实体时出错！" + ex.Message;
                return -1;
            }

            #region 摆药通知处理

            #region 由于采用了集中发药方案，所以这里需要判断处理（集中发药时，审核和分解医嘱不更新通知档，否则更新） {7C848A97-8571-4162-AB11-294BE5FE5E76} wbo 2010-11-29

            ////插入摆药通知记录
            //DrugMessage drugMessage = new DrugMessage();
            //drugMessage.ApplyDept = applyOut.ApplyDept;      //科室或者病区
            //drugMessage.DrugBillClass.ID = "P";             //摆药单分类编码：非医嘱摆药单 P
            //drugMessage.DrugBillClass.Name = "非医嘱摆药单";//摆药单分类名称：非医嘱摆药单
            //drugMessage.SendType = 0;                       //发送类型0全部,1-集中,2-临时
            //drugMessage.SendFlag = 0;                       //状态0-通知,1-已摆
            //drugMessage.StockDept = applyOut.StockDept;     //发药科室

            //if (myDrugStore.SetDrugMessage(drugMessage) != 1)
            //{
            //    this.Err = myDrugStore.Err;
            //    return -1;
            //}

            Neusoft.FrameWork.Management.ControlParam controlParam = new Neusoft.FrameWork.Management.ControlParam();
            string result = controlParam.QueryControlerInfo("P01016", true);//获取参数，可以为空
            bool isConcentrateSend = false;//定义是否集中发送，默认否
            if (string.IsNullOrEmpty(result))//如果数据库没有这个参数，默认为非集中发送方式
            {
                isConcentrateSend = false;
            }
            else
            {
                if (NConvert.ToBoolean(result) == true)//集中发送
                {
                    isConcentrateSend = true;
                }
                else
                {
                    isConcentrateSend = false;
                }
            }
            //非集中发送才更新通知档
            if (isConcentrateSend == false)
            {
                //插入摆药通知记录
                DrugMessage drugMessage = new DrugMessage();
                drugMessage.ApplyDept = applyOut.ApplyDept;      //科室或者病区
                drugMessage.DrugBillClass.ID = "P";             //摆药单分类编码：非医嘱摆药单 P
                drugMessage.DrugBillClass.Name = "非医嘱摆药单";//摆药单分类名称：非医嘱摆药单
                drugMessage.SendType = 0;                       //发送类型0全部,1-集中,2-临时
                drugMessage.SendFlag = 0;                       //状态0-通知,1-已摆
                drugMessage.StockDept = applyOut.StockDept;     //发药科室

                if (myDrugStore.SetDrugMessage(drugMessage) != 1)
                {
                    this.Err = myDrugStore.Err;
                    return -1;
                }
            }
            #endregion

            #endregion

            #region 出库申请 预扣库存操作

            //将分类编码存入出库申请表中
            applyOut.BillClassNO = "P";
            //插入出库申请表
            int parm = this.InsertApplyOut(applyOut);
            if (parm == -1) return parm;

            //预扣库存（加操作）
            if (isPreOut)
            {
                ////{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                parm = this.UpdateStockinfoPreOutNum(applyOut, applyOut.Operation.ApplyQty , applyOut.Days);
                if (parm == -1) return parm;
            }

            #endregion

            return 1;
        }

        /// <summary>
        /// 申请退库－－对费用子系统公开的函数
        /// </summary>
        /// <param name="patient">患者信息实体</param>
        /// <param name="feeItem">费用信息实体</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="applyDeptType">申请科室类型 0 科室 1 护理站</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int ApplyOutReturn(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem, DateTime operDate, string applyDeptType)
        {
            #region 执行操作
            // 将FeeItemList对象转为退库申请对象，然后插入出库申请表
            // 执行操作：
            // 1、FeeItemList对象转为退库申请对象
            // 2、插入摆药通知
            // 3、插入出库申请
            #endregion

            //定义药房管理类
            DrugStore myDrugStore = new DrugStore();
            myDrugStore.SetTrans(this.Trans);

            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = null;
            //记不清当初为什么先通过执行挡流水号获取信息了 
            //测试时执行挡流水号重复会发生错误
            //applyOut = this.GetApplyOutByExecNO( feeItem.ExecOrder.ID );


            //未找到相应的申请记录或者申请记录已确认 插入新的申请
            if (applyOut == null || applyOut.ID == "" || applyOut.State != "0" || applyOut.BillClassNO != "R")
            {
                applyOut = new ApplyOut();

                #region ApplyOut实体赋值

                try
                {
                    decimal tempPrice = feeItem.Item.Price;

                    applyOut.Item = (Neusoft.HISFC.Models.Pharmacy.Item)feeItem.Item;                 //药品实体
                    applyOut.Item.Price = tempPrice;
                    applyOut.Item.PriceCollection.RetailPrice = applyOut.Item.Price;                    //零售价
                    applyOut.Item.MinUnit = feeItem.Item.PriceUnit;                                     //最小单位＝记价单位

                    if (applyDeptType == "1")                   //申请科室为护理站
                    {
                        applyOut.ApplyDept = ((Neusoft.HISFC.Models.RADT.PatientInfo)feeItem.Patient).PVisit.PatientLocation.NurseCell;
                    }
                    else                                       //如果是医嘱发生的费用,则申请科室＝患者科室,否则为开方科室
                    {

                        #region {915E3F34-C8D7-41af-A016-9D0FACDBF850}
                        //不是医嘱的费用，再做退药确认时插入APPLOUT表里的申请科室改成执行科室。
                        //applyOut.ApplyDept = feeItem.Order.ID == "" ? feeItem.RecipeOper.Dept : ((Neusoft.HISFC.Models.RADT.PatientInfo)feeItem.Patient).PVisit.PatientLocation.Dept;
                        applyOut.ApplyDept = feeItem.Order.ID == "" ? feeItem.ExecOper.Dept : ((Neusoft.HISFC.Models.RADT.PatientInfo)feeItem.Patient).PVisit.PatientLocation.Dept; 
                        #endregion
                    }

                    //退费时不能重新获取取药药房
                    applyOut.StockDept = feeItem.StockOper.Dept;                                     //发药科室＝医嘱药房
                    applyOut.SystemType = "Z2";                                                      //申请类型＝"Z2" ，住院退药申请
                    applyOut.Operation.ApplyOper.OperTime = operDate;                                //申请时间＝操作时间
                    applyOut.Days = feeItem.Order.HerbalQty == 0 ? 1 : feeItem.Order.HerbalQty;      //草药付数
                    applyOut.IsPreOut = false;                                                       //是否预扣库存
                    applyOut.IsCharge = true;                                                        //是否收费
                    applyOut.PatientNO = patient.ID;                                                 //患者住院流水号,传入参数
                    applyOut.PatientDept = ((Neusoft.HISFC.Models.RADT.PatientInfo)feeItem.Patient).PVisit.PatientLocation.Dept;        //患者所在科室
                    applyOut.DoseOnce = feeItem.Order.DoseOnce;                                      //每次剂量
                    applyOut.Frequency = feeItem.Order.Frequency;                                    //频次
                    applyOut.Usage = feeItem.Order.Usage;                                            //用法

                    applyOut.OrderType = feeItem.Order.OrderType; //医嘱类型

                    applyOut.OrderNO = feeItem.Order.ID;                                             //医嘱流水号
                    applyOut.CombNO = feeItem.Order.Combo.ID;                                        //组合序号
                    applyOut.ExecNO = feeItem.ExecOrder.ID;                                              //医嘱执行单流水号
                    applyOut.RecipeNO = feeItem.RecipeNO;                                            //处方号
                    applyOut.SequenceNO = feeItem.SequenceNO;                                        //处方内流水号
                    applyOut.SendType = 2;                                                           //发送类型0全部，1集中，2临时
                    applyOut.OutBillNO = feeItem.SendSequence.ToString();                            //对应出库单的流水号
                    //退药申请 申请单据号
                    applyOut.BillNO = feeItem.User02;
                    applyOut.ShowState = "0";

                    applyOut.State = "0";

                    //费用表中的数量是乘以付数以后的总数量,药品表中保存的是每付的量,在此转换.
                    applyOut.Operation.ApplyQty = feeItem.Item.Qty / applyOut.Days;
                }
                catch (Exception ex)
                {
                    this.Err = "将费用实体转换成出库申请实体时出错！" + ex.Message;
                    return -1;
                }

                #endregion

                if (applyOut.OutBillNO == null || applyOut.OutBillNO == "")
                {
                    this.Err = "出库单流水号为空 无对应的出库记录 不能做退库申请";
                    return -1;
                }

                #region 出库申请处理

                //将分类编码存入出库申请表中，退药单"R"
                applyOut.BillClassNO = "R";

                //插入出库申请表
                int parm = this.InsertApplyOut(applyOut);
                if (parm != 1) return parm;

                #endregion

            }
            else
            {
                applyOut.Operation.ApplyQty = feeItem.Item.Qty / applyOut.Days + applyOut.Operation.ApplyQty;

                if (this.SetApplyOut(applyOut) != 1)
                    return -1;
            }

            #region 插入摆药通知记录

            #region 由于采用了集中发药方案，所以这里需要判断处理（集中发药时，审核和分解医嘱不更新通知档，否则更新） {7C848A97-8571-4162-AB11-294BE5FE5E76} wbo 2010-11-29
            //DrugMessage drugMessage = new DrugMessage();
            //drugMessage.ApplyDept = applyOut.ApplyDept;    //科室或者病区
            //drugMessage.DrugBillClass.ID = "R";           //摆药单分类编码：退药单
            //drugMessage.DrugBillClass.Name = "退药单";    //摆药单分类名称：退药单
            //drugMessage.SendType = 0;                     //发送类型0全部,1-集中,2-临时
            //drugMessage.SendFlag = 0;                     //状态0-通知,1-已摆
            //drugMessage.StockDept = applyOut.StockDept;   //发药科室

            //if (myDrugStore.SetDrugMessage(drugMessage) != 1)
            //{
            //    this.Err = myDrugStore.Err;
            //    return -1;
            //}

            Neusoft.FrameWork.Management.ControlParam controlParam = new Neusoft.FrameWork.Management.ControlParam();
            string result = controlParam.QueryControlerInfo("P01016", true);//获取参数，可以为空
            bool isConcentrateSend = false;//定义是否集中发送，默认否
            if (string.IsNullOrEmpty(result))//如果数据库没有这个参数，默认为非集中发送方式
            {
                isConcentrateSend = false;
            }
            else
            {
                if (NConvert.ToBoolean(result) == true)//集中发送
                {
                    isConcentrateSend = true;
                }
                else
                {
                    isConcentrateSend = false;
                }
            }
            //非集中发送才更新通知档
            if (isConcentrateSend == false)
            {
                DrugMessage drugMessage = new DrugMessage();
                drugMessage.ApplyDept = applyOut.ApplyDept;    //科室或者病区
                drugMessage.DrugBillClass.ID = "R";           //摆药单分类编码：退药单
                drugMessage.DrugBillClass.Name = "退药单";    //摆药单分类名称：退药单
                drugMessage.SendType = 0;                     //发送类型0全部,1-集中,2-临时
                drugMessage.SendFlag = 0;                     //状态0-通知,1-已摆
                drugMessage.StockDept = applyOut.StockDept;   //发药科室

                if (myDrugStore.SetDrugMessage(drugMessage) != 1)
                {
                    this.Err = myDrugStore.Err;
                    return -1;
                }
            }
            #endregion

            #endregion

            return 1;
        }

        #endregion

        #region 门诊申请操作

        /// <summary>
        /// 门诊收费调用的出库函数
        /// </summary>
        /// <param name="patient">患者信息实体</param>
        /// <param name="feeAl">费用信息数组</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="isPreOut">是否预出库</param>
        /// <param name="isModify">是否门诊退改药</param>
        /// <param name="alConstant">不发申请信息 直接扣库存科室</param>
        /// <param name="drugSendInfo">处方调剂信息 发药药房+发药窗口</param>
        /// <returns>1 成功 －1 失败</returns>
        public int ApplyOut(Neusoft.HISFC.Models.Registration.Register patient, ArrayList feeAl, DateTime operDate, bool isPreOut, bool isModify, ArrayList alConstant, out string drugSendInfo)
        {
            string feeWindow = "";
            drugSendInfo = "";
            //定义药房管理类
            DrugStore myDrugStore = new DrugStore();

            myDrugStore.SetTrans(this.Trans);

            if (alConstant == null)
            {
                alConstant = new ArrayList();
            }

            #region 收费窗口参数初始化

            if (Item.isInitSendWindow)
            {
                feeWindow = Item.feeWindowNO;
            }
            else
            {
                string strErr = "";
                ArrayList alWindow = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("Fee", "Window", out strErr);

                if (alWindow != null && alWindow.Count > 0)
                {
                    feeWindowNO = alWindow[0] as string;

                    feeWindow = feeWindowNO;
                }

                isInitSendWindow = true;
            }

            #endregion

            bool isSendApply = false;
            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = new ApplyOut();
            DateTime feeDate = System.DateTime.MinValue;
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeInfo in feeAl)
            {
                #region 申请明细表操作

                #region ApplyOut实体赋值
                applyOut = new ApplyOut();
                try
                {
                    Neusoft.HISFC.Models.Pharmacy.Item item = this.GetItem(feeInfo.Item.ID);
                    if (item == null)
                    {
                        this.Err = "获取药品基本信息失败" + this.Err;
                        return -1;
                    }
                    if (item.IsStop)
                    {
                        this.Err = item.Name + "－ 药库已停用 不能进行发药收费！";
                        return -1;
                    }
                    Neusoft.HISFC.Models.Pharmacy.Storage storage = this.GetStockInfoByDrugCode(feeInfo.ExecOper.Dept.ID, feeInfo.Item.ID);
                    if (storage == null || storage.Item.ID == "")
                    {
                        this.Err = item.Name + "－ 在该药房不存在库存 无法进行发药收费！" + this.Err;
                        return -1;
                    }
                    if (storage.IsStop)
                    {
                        this.Err = item.Name + "－ 在药房已停用 不能进行发药收费！";
                        return -1;
                    }
                    //对允许扣除负库存时 不进行此项判断
                    if (isPreOut)
                    {
                        if (!Item.MinusStore && (storage.StoreQty - storage.PreOutQty) < feeInfo.Item.Qty)
                        {
                            this.Err = item.Name + "－ 在药房库存不足以进行本次收费发药 不能收费！";
                            return -1;
                        }
                    }
                    else
                    {
                        if (!Item.MinusStore && storage.StoreQty < feeInfo.Item.Qty)
                        {
                            this.Err = item.Name + "－ 在药房库存不足以进行本次收费发药 不能收费！";
                            return -1;
                        }
                    }

                    applyOut.Item.MinUnit = item.MinUnit;			                            //最小单位
                    applyOut.Item.PackUnit = item.PackUnit;
                    applyOut.Item.PriceCollection.RetailPrice = feeInfo.Item.Price;			    //零售价
                    applyOut.Item.ID = feeInfo.Item.ID;					                            //药品编码
                    applyOut.Item.Name = feeInfo.Item.Name;				                            //药品名称
                    applyOut.Item.Type = item.Type;						                        //药品类别
                    applyOut.Item.Quality = ((Neusoft.HISFC.Models.Pharmacy.Item)feeInfo.Item).Quality;	        //药品性质
                    applyOut.Item.Specs = feeInfo.Item.Specs;				                    //规格
                    applyOut.Item.PackQty = feeInfo.Item.PackQty;			                    //包装数量
                    applyOut.ApplyDept = ((Neusoft.HISFC.Models.Registration.Register)feeInfo.Patient).DoctorInfo.Templet.Dept;			  //申请科室＝开方科室 

                    if (feeInfo.UndrugComb.User03 == null || feeInfo.UndrugComb.User03 == "")
                    {
                        applyOut.StockDept = feeInfo.ExecOper.Dept;                             //发药药房＝执行科室
                    }
                    else
                    {
                        applyOut.PrintState = "1";
                        applyOut.StockDept.ID = feeInfo.UndrugComb.User03;
                        applyOut.BillClassNO = feeInfo.ExecOper.Dept.ID;
                    }

                    applyOut.SystemType = "M1";                                                 //申请类型＝"M1" 
                    applyOut.Operation.ApplyOper.OperTime = operDate;                           //申请时间＝操作时间
                    applyOut.Days = feeInfo.Days == 0 ? 1 : feeInfo.Days;                       //草药付数
                    applyOut.IsPreOut = isPreOut;                                               //是否预扣库存
                    applyOut.IsCharge = true;                                                   //是否收费
                    applyOut.PatientNO = feeInfo.Patient.ID;                                    //患者门诊流水号
                    applyOut.PatientDept = ((Neusoft.HISFC.Models.Registration.Register)feeInfo.Patient).DoctorInfo.Templet.Dept;           //患者挂号科室 
                    applyOut.DoseOnce = feeInfo.Order.DoseOnce;		                            //每次剂量
                    applyOut.Item.DoseUnit = feeInfo.Order.DoseUnit;			                //每次剂量单位
                    applyOut.Frequency.ID = feeInfo.Order.Frequency.ID;			                //频次编码
                    applyOut.Frequency.Name = feeInfo.Order.Frequency.Name;	                    //频次名称
                    applyOut.Usage = feeInfo.Order.Usage;			                            //用法
                    applyOut.Item.DosageForm = ((Neusoft.HISFC.Models.Pharmacy.Item)feeInfo.Item).DosageForm;		  //剂型
                    applyOut.OrderNO = feeInfo.Order.ID;				                        //医嘱流水号
                    applyOut.CombNO = feeInfo.Order.Combo.ID;				                    //组合序号

                    //暂时使用执行档流水号 表示院注次数
                    applyOut.ExecNO = feeInfo.InjectCount.ToString();                           //院注次数
                    //有效性标记为 3 表示 退改药
                    if (isModify)
                    {
                        applyOut.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Extend;
                    }

                    applyOut.RecipeNO = feeInfo.RecipeNO;			                            //处方号
                    applyOut.SequenceNO = feeInfo.SequenceNO;		                            //处方内流水号
                    applyOut.State = "0";							                            //出库申请状态:0申请,1摆药,2核准
                    //费用表中的数量是乘以付数以后的总数量,药品表中保存的是每付的量,在此转换.
                    applyOut.ShowState = "0";
                    applyOut.Operation.ApplyQty = feeInfo.Item.Qty / applyOut.Days;
                    feeDate = feeInfo.FeeOper.OperTime;
                }
                catch (Exception ex)
                {
                    this.Err = "将费用实体转换成出库申请实体时出错！" + ex.Message;
                    return -1;
                }

                #endregion

                #region 是否发生申请判断

                bool isApply = true;
                if (alConstant != null)
                {
                    foreach (Neusoft.HISFC.Models.Base.Const cons in alConstant)
                    {
                        if (cons.ID == applyOut.ApplyDept.ID)
                        {
                            isApply = false;
                            break;
                        }
                    }
                }

                #endregion

                if (isApply)
                {
                    #region 申请信息发送

                    isSendApply = true;
                    //插入出库申请表
                    int parm = this.InsertApplyOut(applyOut);
                    if (parm == -1)
                    {
                        return parm;
                    }
                    if (parm == 0)
                    {
                        this.Err = feeInfo.Name + "未正确插入出库申请表";
                        return -1;
                    }
                    //预扣库存（加操作）
                    if (isPreOut)
                    {
                        //{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                        parm = this.UpdateStockinfoPreOutNum(applyOut, applyOut.Operation.ApplyQty , applyOut.Days);
                        if (parm == -1) return parm;
                    }

                    #endregion
                }
                else
                {
                    #region 直接出库

                    applyOut.Operation.ApproveOper.Dept = applyOut.StockDept;
                    applyOut.Operation.ApproveQty = applyOut.Operation.ApplyQty;
                    applyOut.DrugNO = "1";
                    applyOut.State = "2";
                    if (this.Output(applyOut) != 1)
                    {
                        this.Err = "对" + feeInfo.ExecOper.Dept.Name + " 进行直接出库操作失败 \n" + this.Err;
                        return -1;
                    }

                    #endregion
                }

                #endregion
            }

            if (isSendApply)
            {
                #region 申请头表
                if (isModify)
                {
                    #region 退改药更新原记录 处方状态 退/改药标记
                    int parm = myDrugStore.UpdateDrugRecipeModifyInfo(applyOut.StockDept.ID, applyOut.RecipeNO, "M1", "0", feeDate, isModify);
                    if (parm == -1)
                    {
                        return parm;
                    }
                    else if (parm == 0)
                    {
                        this.Err = "未正确找到需要更新的数据 可能数据已发生变化 ";
                        return -1;
                    }
                    #endregion
                }
                else
                {
                    #region 向调剂头表内插入数据
                    if (myDrugStore.DrugRecipe(patient, feeAl, feeWindow, out drugSendInfo) == -1)
                    {
                        this.Err = myDrugStore.Err;
                        return -1;
                    }
                    #endregion
                }
                #endregion
            }

            return 1;
        }

        #endregion

        #endregion

        #endregion

        #region 基础增、删、改操作

        /// <summary>
        /// 获得update或者insert出库申请表的传入参数数组
        /// 
        /// </summary>
        /// <param name="ApplyOut">出库申请类</param>
        /// <returns>成功返回参数字符串数组 失败返回null</returns>
        private string[] myGetParmApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut ApplyOut)
        {
            //默认申请状态为:0申请状态
            if (ApplyOut.State == null || ApplyOut.State == "")
                ApplyOut.State = "0";
            if (ApplyOut.User03 == null || ApplyOut.User03 == "")
            {
                ApplyOut.User03 = System.DateTime.MinValue.ToString();
            }
            string applyOper = ApplyOut.Operation.ApplyOper.ID;
            if (applyOper == "")
            {
                applyOper = this.Operator.ID;
            }

            string[] strParm ={   ApplyOut.ID,                                 //0申请流水号
								 ApplyOut.ApplyDept.ID,                       //1申请部门编码（科室或者病区）
								 ApplyOut.StockDept.ID,                      //2发药部门编码
								 ApplyOut.SystemType,                          //3出库申请分类
								 ApplyOut.GroupNO.ToString(),                 //4批次号
								 ApplyOut.Item.ID,                            //5药品编码
								 ApplyOut.Item.Name,                          //6药品商品名
								 ApplyOut.BatchNO,                            //7批号
								 ApplyOut.Item.Type.ID,                       //8药品类别
								 ApplyOut.Item.Quality.ID.ToString(),         //9药品性质
								 ApplyOut.Item.Specs,                         //10规格
								 ApplyOut.Item.PackUnit,                      //11包装单位
								 ApplyOut.Item.PackQty.ToString(),            //12包装数
								 ApplyOut.Item.MinUnit,                       //13最小单位
								 ApplyOut.ShowState,                          //14显示的单位标记
								 ApplyOut.ShowUnit,                           //15显示的单位
								 ApplyOut.Item.PriceCollection.RetailPrice.ToString(),        //16零售价
								 ApplyOut.Item.PriceCollection.WholeSalePrice.ToString(),     //17批发价
								 ApplyOut.Item.PriceCollection.PurchasePrice.ToString(),      //18购入价
								 ApplyOut.BillNO,                           //19申请单号
								 applyOper,                                 //20申请人编码
								 ApplyOut.Operation.ApplyOper.OperTime.ToString(),               //21申请日期
								 ApplyOut.State,                         //22申请状态 0申请，1核准（出库），2作废，3暂不摆药
								 ApplyOut.Operation.ApplyQty.ToString(),                //23申请出库量(每付的总数量)
								 ApplyOut.Days.ToString(),                    //24付数（草药）
								 NConvert.ToInt32(ApplyOut.IsPreOut).ToString(), //25预扣库存状态（'0'不预扣库存，'1'预扣库存）
								 NConvert.ToInt32(ApplyOut.IsCharge).ToString(), //26收费状态：0未收费，1已收费
								 ApplyOut.PatientNO,                          //27患者编号
								 ApplyOut.PatientDept.ID,                     //28患者科室
								 ApplyOut.DrugNO,                           //29摆药单号
								 ApplyOut.Operation.ApproveOper.Dept.ID,                     //30摆药科室
								 ApplyOut.Operation.ApproveOper.ID,                    //31摆药人
								 ApplyOut.Operation.ApproveOper.OperTime.ToString(),             //32摆药日期
								 ApplyOut.Operation.ApproveQty.ToString(),              //33摆药数量
								 ApplyOut.DoseOnce.ToString(),                //34每次剂量
								 ApplyOut.Item.DoseUnit,                      //35剂量单位
								 ApplyOut.Usage.ID,                           //36用法代码
								 ApplyOut.Usage.Name,                         //37用法名称
								 ApplyOut.Frequency.ID,                       //38频次代码
								 ApplyOut.Frequency.Name,                     //39频次名称
								 ApplyOut.Item.DosageForm.ID,                 //40剂型编码
								 ApplyOut.OrderType.ID,                       //41医嘱类型
								 ApplyOut.OrderNO,                            //42医嘱流水号
								 ApplyOut.CombNO,                             //43组合序号
								 ApplyOut.ExecNO,                             //44执行单流水号
								 ApplyOut.RecipeNO,                           //45处方号
								 ApplyOut.SequenceNO.ToString(),              //46处方内项目流水号
								 ApplyOut.SendType.ToString(),                //47医嘱发送类型1集中，2临时
								 ApplyOut.BillClassNO,                        //48摆药单分类
								 ApplyOut.PrintState,                         //49打印状态
								 ApplyOut.OutBillNO,                          //50出库单号（退库申请时，保存出库时对应的记录）
								 ((int)ApplyOut.ValidState).ToString(),	      //51有效标记（1有效，0无效，不摆药）
								 ApplyOut.Memo,								  //52医嘱备注
								 ApplyOut.PlaceNO,						      //53货位号
								 ApplyOut.User03,							  //54取消日期(用药时间)
                                 ApplyOut.RecipeInfo.Dept.ID,
                                 ApplyOut.RecipeInfo.ID,
                                 NConvert.ToInt32(ApplyOut.IsBaby).ToString(),
                                 ApplyOut.ExtFlag,
                                 ApplyOut.ExtFlag1,
                                 ApplyOut.CompoundGroup,
                                 NConvert.ToInt32(ApplyOut.Compound.IsNeedCompound).ToString(),
                                 NConvert.ToInt32(ApplyOut.Compound.IsExec).ToString(),
                                 ApplyOut.Compound.CompoundOper.ID,
                                 ApplyOut.Compound.CompoundOper.OperTime.ToString()
							 };

            return strParm;
        }

        /// <summary>
        /// 取出库申请表中的全部字段数据
        /// 私有方法，在其他方法中调用  
        /// 使用该函数的索引 : Pharmacy.Item.GetApplyOutList Pharmacy.Item.GetApplyOutList.Patient
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>成功返回出库申请实体数组 失败返回null</returns>
        private ArrayList myGetApplyOut(string SQLString)
        {
            ArrayList al = new ArrayList();              //用于返回出库申请信息的数组
            Neusoft.HISFC.Models.Pharmacy.ApplyOut info; //返回数组中的出库申请类

            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得出库申请信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.Pharmacy.ApplyOut();
                    try
                    {
                        info.ID = this.Reader[0].ToString();                                  //申请流水号
                        info.ApplyDept.ID = this.Reader[1].ToString();                        //申请部门编码（科室或者病区）
                        info.StockDept.ID = this.Reader[2].ToString();                       //发药部门编码
                        info.SystemType = this.Reader[3].ToString();                           //出库申请分类
                        info.GroupNO = NConvert.ToDecimal(this.Reader[4].ToString());                  //批次号
                        info.Item.ID = this.Reader[5].ToString();                             //药品编码
                        info.Item.Name = this.Reader[6].ToString();                           //药品商品名
                        info.BatchNO = this.Reader[7].ToString();                             //批号
                        info.Item.Type.ID = this.Reader[8].ToString();                        //药品类别
                        info.Item.Quality.ID = this.Reader[9].ToString();                      //药品性质
                        info.Item.Specs = this.Reader[10].ToString();                         //规格
                        info.Item.PackUnit = this.Reader[11].ToString();                      //包装单位
                        info.Item.PackQty = NConvert.ToDecimal(this.Reader[12].ToString());   //包装数
                        info.Item.MinUnit = this.Reader[13].ToString();                       //最小单位
                        info.ShowState = this.Reader[14].ToString();                          //显示的单位标记
                        info.ShowUnit = this.Reader[15].ToString();                           //显示的单位
                        info.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[16].ToString());    //零售价
                        info.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[17].ToString()); //批发价
                        info.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[18].ToString());  //购入价
                        info.BillNO = this.Reader[19].ToString();                           //申请单号
                        info.Operation.ApplyOper.ID = this.Reader[20].ToString();                      //申请人编码
                        info.Operation.ApplyOper.OperTime = NConvert.ToDateTime(this.Reader[21].ToString());     //申请日期
                        info.State = this.Reader[22].ToString();                         //申请状态 0申请，1核准（出库），2作废，3暂不摆药
                        info.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[23].ToString());       //申请出库量(每付的总数量)
                        info.Days = NConvert.ToDecimal(this.Reader[24].ToString());           //付数（草药）
                        info.IsPreOut = NConvert.ToBoolean(this.Reader[25].ToString());       //是否预扣库存：0未预扣，1已预扣
                        info.IsCharge = NConvert.ToBoolean(this.Reader[26].ToString());       //是否收费：0未收费，1已收费
                        info.PatientNO = this.Reader[27].ToString();                          //患者编号
                        info.PatientDept.ID = this.Reader[28].ToString();                     //患者科室
                        info.DrugNO = this.Reader[29].ToString();                           //摆药单号
                        info.Operation.ApproveOper.Dept.ID = this.Reader[30].ToString();                     //摆药科室
                        info.Operation.ApproveOper.ID = this.Reader[31].ToString();                    //摆药人
                        info.Operation.ApproveOper.OperTime = NConvert.ToDateTime(this.Reader[32].ToString());   //摆药日期
                        info.Operation.ApproveQty = NConvert.ToDecimal(this.Reader[33].ToString());     //摆药数量

                        info.Operation.ExamQty = info.Operation.ApproveQty;

                        info.DoseOnce = NConvert.ToDecimal(this.Reader[34].ToString());       //每次剂量
                        info.Item.DoseUnit = this.Reader[35].ToString();                      //剂量单位
                        info.Usage.ID = this.Reader[36].ToString();                           //用法代码
                        info.Usage.Name = this.Reader[37].ToString();                         //用法名称
                        info.Frequency.ID = this.Reader[38].ToString();                       //频次代码
                        info.Frequency.Name = this.Reader[39].ToString();                     //频次名称
                        info.Item.DosageForm.ID = this.Reader[40].ToString();                 //剂型编码
                        info.OrderType.ID = this.Reader[41].ToString();                       //医嘱类型编码
                        info.OrderNO = this.Reader[42].ToString();                            //医嘱流水号
                        info.CombNO = this.Reader[43].ToString();                             //组合序号
                        info.ExecNO = this.Reader[44].ToString();                             //执行单流水号
                        info.RecipeNO = this.Reader[45].ToString();                           //处方号
                        info.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[46].ToString());              //处方内项目流水号
                        info.SendType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[47].ToString());                //医嘱发送类型0全部，1集中，2临时
                        info.BillClassNO = this.Reader[48].ToString();                      //摆药单分类
                        info.PrintState = this.Reader[49].ToString();                         //打印状态
                        info.Operation.ExamOper.ID = this.Reader[50].ToString();                       //审批人（打印人）
                        info.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[51].ToString());      //审批时间（打印时间）
                        info.OutBillNO = this.Reader[52].ToString();                        //出库单号（退库申请时，保存出库时对应的记录）
                        info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)NConvert.ToInt32(this.Reader[53]);                         //有效标记（0有效，1无效，2不摆药）
                        info.User01 = this.Reader[54].ToString();                             //患者床位号
                        info.User02 = this.Reader[55].ToString();                             //患者姓名
                        info.Memo = this.Reader[56].ToString();								  //医嘱备注
                        info.RecipeInfo.Dept.ID = this.Reader[57].ToString();
                        info.RecipeInfo.ID = this.Reader[58].ToString();
                        info.IsBaby = NConvert.ToBoolean(this.Reader[59]);
                        info.ExtFlag = this.Reader[60].ToString();
                        info.ExtFlag1 = this.Reader[61].ToString();
                        info.CompoundGroup = this.Reader[62].ToString();
                        info.Compound.IsNeedCompound = NConvert.ToBoolean(this.Reader[63].ToString());
                        info.Compound.IsExec = NConvert.ToBoolean(this.Reader[64].ToString());
                        info.Compound.CompoundOper.ID = this.Reader[65].ToString();
                        info.Compound.CompoundOper.OperTime = NConvert.ToDateTime(this.Reader[66].ToString());

                        info.UseTime = NConvert.ToDateTime(this.Reader[67].ToString());
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得出库申请信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }

                    al.Add(info);
                }
                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得出库申请信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 插入一条出库申请记录
        /// </summary>
        /// <param name="applyOut">申请出库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertApplyOut", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.InsertApplyOut";
                return -1;
            }
            try
            {
                //{C37BEC96-D671-46d1-BCDD-C634423755A4}  更改预扣库存管理模式
                if (string.IsNullOrEmpty(applyOut.ID))
                {
                    applyOut.ID = this.GetSequence("Pharmacy.Item.GetNewApplyOutID");
                }

                string[] strParm = myGetParmApplyOut(applyOut);  //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "插入出库申请SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新出库申请记录
        /// </summary>
        /// <param name="applyOut">出库申请记录</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            return this.UpdateApplyOut(applyOut, false);
        }

        /// <summary>
        /// 更新出库申请记录
        /// {EE05DA01-8969-404d-9A6B-EE8AD0BC1CD0}
        /// </summary>
        /// <param name="applyOut">出库申请记录</param>
        /// <param name="isApplyState">是否判断是申请状态</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, bool isJudgeApplyState)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyOut", ref strSQL) == -1) return -1;
            try
            {
                string[] strParm = myGetParmApplyOut(applyOut);  //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新出库申请SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            string strWhere = "";
            if (isJudgeApplyState)
            {
                if (this.Sql.GetSql("Pharmacy.Item.UpdateApplyOutByApplyState", ref strWhere) == -1)
                {
                    this.Err += "获取Pharmacy.Item.UpdateApplyOutByApplyState语句出错！";
                    return -1;
                }
            }
            return this.ExecNoQuery(strSQL + strWhere);
        }

        /// <summary>
        /// 删除出库申请记录
        /// </summary>
        /// <param name="ID">出库申请记录流水号</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int DeleteApplyOut(string ID)
        {
            string strSQL = "";
            //根据出库申请流水号删除某一条出库申请记录的DELETE语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteApplyOut", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.DeleteApplyOut";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ID);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.DeleteApplyOut";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 先进行更新操作 更新数据为零则进行插入操作
        /// </summary>
        /// <param name="applyOut">出库申请实体</param>
        /// <returns>成功返回更新数量 失败返回－1</returns>
        public int SetApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            int parm;
            parm = this.UpdateApplyOut(applyOut);
            if (parm == -1)
                return -1;
            if (parm == 0)
                parm = this.InsertApplyOut(applyOut);
            return parm;
        }

        #endregion

        #endregion

        #region 出库表操作

        #region 内部使用

        #region 出库记录/信息查询

        /// <summary>
        /// 按出库单流水号查询出库记录（可能多条）
        /// </summary>
        /// <returns>成功返回满足条件的出库记录 失败返回null</returns>
        public ArrayList QueryOutputList(string outputID)
        {
            string strSQL = "";
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList.ByID", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList.ByID字段!";
                return null;
            }

            strSQL = string.Format(strSQL + strWhere, outputID);

            //根据SQL语句取药品类数组并返回数组
            return this.myGetOutput(strSQL);
        }

        /// <summary>
        /// 按出库单流水号查询出库记录
        /// </summary>
        /// <param name="outputID">出库流水号</param>
        /// <param name="groupNO">库存批次</param>
        /// <returns>成功返回满足条件的出库记录 失败返回null</returns>
        public Neusoft.HISFC.Models.Pharmacy.Output GetOutputDetail(string outputID, string groupNO)
        {
            ArrayList al = this.QueryOutputList(outputID);
            if (al == null)
            {
                return null;
            }
            if (al.Count == 0)
            {
                return new Output();
            }
            foreach (Neusoft.HISFC.Models.Pharmacy.Output output in al)
            {
                if (output.GroupNO.ToString() == groupNO)
                {
                    return output;
                }
            }

            return null;
        }

        /// <summary>
        /// 根据处方号、处方内项目流水号获取出库实体
        /// </summary>
        /// <param name="recipeNo">处方号</param>
        /// <param name="sequenceNo">处方内项目流水号</param>
        /// <param name="systemType">系统类别 M1门诊收 M2门诊退 Z1住院收 Z2住院退</param>
        /// <returns>成功返回1  失败返回－1</returns>
        public ArrayList QueryOutputList(string recipeNo, int sequenceNo, string systemType)
        {
            string strSQL = "";
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList.ByRecipeNo", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList.ByRecipeNo字段!";
                return null;
            }

            strSQL = string.Format(strSQL + strWhere, recipeNo, sequenceNo.ToString(), systemType);

            //根据SQL语句取药品类数组并返回数组
            return this.myGetOutput(strSQL);
        }

        /// <summary>
        /// 根据出库单据号、取药人字段获取出库信息
        /// 制剂管理调用时 取药人字段存储成品编码 用于确定同一生产计划内不同药品
        /// </summary>
        /// <param name="outListCode">出库单据号</param>
        /// <param name="getPersonID">取药人</param>
        /// <returns>成功返回对应的出库实体数组 失败返回null</returns>
        public ArrayList QueryOutList(string outListCode, string getPersonID)
        {
            string strSQL = "";
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList.ByListCode.PersonID", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList..ByListCode.PersonID字段!";
                return null;
            }

            strSQL = string.Format(strSQL + strWhere, outListCode, getPersonID);

            //根据SQL语句取药品类数组并返回数组
            return this.myGetOutput(strSQL);
        }

        /// <summary>
        /// 按出库单据号查询出库记录
        /// </summary>
        /// <param name="deptCode">出库科室</param>
        /// <param name="outListCode">出库单据号</param>
        /// <param name="state">出库状态 "A"忽略出库状态</param>
        /// <returns>成功返回 output实体数组 失败返回null</returns>
        public ArrayList QueryOutputInfo(string deptCode, string outListCode, string state)
        {
            string strSQL = "";
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList.ByListCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList.ByListCode字段!";
                return null;
            }

            strSQL = string.Format(strSQL + strWhere, deptCode, outListCode, state);

            //根据SQL语句取药品类数组并返回数组
            return this.myGetOutput(strSQL);
        }

        /// <summary>
        /// 获取出库单据列表
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="class3MeaningCode">三级权限码 "A"忽略权限信息</param>
        /// <param name="outState">出库状态 "A"忽略状态信息</param>
        /// <returns>成功返回neuobject数组 ID 出库单号 Name 领药单位名称 Memo 领药单位编码 User01 申请出库人编码 出错返回null</returns>
        public ArrayList QueryOutputList(string deptCode, string class3MeaningCode, string outState)
        {
            return this.QueryOutputList(deptCode, class3MeaningCode, "AAAA", outState);
        }

        /// <summary>
        /// 获取出库单据列表
        /// </summary>
        /// <param name="outDeptCode">出库科室</param>
        /// <param name="class3MeaningCode">三级权限码 “A”忽略权限信息</param>
        /// <param name="storageDept">领药科室编码</param>
        /// <param name="outState">出库状态 "A"忽略状态信息</param>
        /// <returns>成功返回neuobject数组 ID 出库单号 Name 领药单位名称 Memo 领药单位编码 User01 申请出库人编码 出错返回null</returns>
        public ArrayList QueryOutputList(string outDeptCode, string class3MeaningCode, string storageDept, string outState)
        {
            ArrayList al = new ArrayList();
            string strSQL = "";
            string strString = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutListInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutListInfo字段!";
                return null;
            }
            try
            {
                strString = string.Format(strSQL, outDeptCode, class3MeaningCode, storageDept, outState);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            Neusoft.FrameWork.Models.NeuObject info;

            if (this.ExecQuery(strString) == -1)
            {
                this.Err = "获得出库信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();		//出库单号
                    info.Name = this.Reader[1].ToString();		//领药单位名称
                    info.Memo = this.Reader[2].ToString();		//领药单位编码
                    info.User01 = this.Reader[3].ToString();	//申请人

                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获取出库列表信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获取出库单据列表
        /// </summary>
        /// <param name="outDeptCode">出库科室</param>
        /// <param name="class3MeaningCode">三级权限码</param>
        /// <param name="outState">出库状态 </param>
        /// <param name="dtBegin">查询起始时间</param>
        /// <param name="dtEnd">查询终止时间</param>
        /// <returns>成功返回neuobject数组 ID 出库单号 Name 领药单位 Memo 领药单位编码 User01 自定义类型 出错返回null</returns>
        public ArrayList QueryOutputList(string outDeptCode, string class3MeaningCode, string outState, DateTime dtBegin, DateTime dtEnd)
        {
            ArrayList al = new ArrayList();
            string strSQL = "";
            string strString = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutListInfo.OperTime", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutListInfo.OperTime字段!";
                return null;
            }
            try
            {
                strString = string.Format(strSQL, outDeptCode, class3MeaningCode, outState, dtBegin.ToString(), dtEnd.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            Neusoft.FrameWork.Models.NeuObject info;

            if (this.ExecQuery(strString) == -1)
            {
                this.Err = "获得出库信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();		//出库单号
                    info.Name = this.Reader[1].ToString();		//领药单位名称
                    info.Memo = this.Reader[2].ToString();		//领药单位编码
                    info.User01 = this.Reader[3].ToString();	//权限类型 自定义类型

                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获取出库列表信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获取出库单据列表 供入库核准
        /// </summary>
        /// <param name="storageDept">领药科室</param>
        /// <param name="dtBegin">统计起始时间</param>
        /// <param name="dtEnd">统计截至时间</param>
        /// <returns>成功返回neuobject数组 Id 单据号 Name 出库科室 Memo 出库科室编码 失败返回null</returns>
        public ArrayList QueryOutputListForApproveInput(string storageDept, DateTime dtBegin, DateTime dtEnd)
        {
            ArrayList al = new ArrayList();
            string strSQL = "";
            string strString = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutListForApproveInput.OperTime", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutListForApproveInput.OperTime字段!";
                return null;
            }
            try
            {
                strString = string.Format(strSQL, storageDept, dtBegin.ToString(), dtEnd.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            Neusoft.FrameWork.Models.NeuObject info;
            if (this.ExecQuery(strString) == -1)
            {
                this.Err = "获得出库信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();

                    info.ID = this.Reader[0].ToString();		//单据号
                    info.Name = this.Reader[1].ToString();		//出库单位名称
                    info.Memo = this.Reader[2].ToString();		//出库单位编码
                    info.User01 = this.Reader[3].ToString();	//入库类型

                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获取出库列表信息出错" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 出库记录
        /// </summary>
        /// <param name="output">出库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public ArrayList QueryOutputList(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            string strSQL = "";
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetOutputList.ByID", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetOutputList.ByID字段!";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetOutput(strSQL);
        }

        #endregion

        /// <summary>
        /// 更新一条出库记录中的"已退库数量"字段（加操作）
        /// </summary>
        /// <param name="outputID">出库单号</param>
        /// <param name="SerialNO">单内序号</param>
        /// <param name="returnNum">退库数量</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateOutputReturnNum(string outputID, int SerialNO, decimal returnNum)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateOutputReturnNum", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Item.UpdateOutputReturnNum";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   outputID, 
									   SerialNO.ToString(), 
									   returnNum.ToString(),
									   this.Operator.ID
								   };
                strSQL = string.Format(strSQL, strParm);              //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新退库数量的SQl参数赋值出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 审核出库信息（打印摆药单、摆药）
        /// </summary>
        /// <param name="Output">出库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int ExamOutput(Neusoft.HISFC.Models.Pharmacy.Output Output)
        {
            string strSQL = "";
            //审核出库信息（打印摆药单、摆药），更新出库状态为'1'。
            if (this.Sql.GetSql("Pharmacy.Item.ExamOutput", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Item.ExamOutput";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   Output.ID,                     //出库流水号
									   Output.Operation.ExamQty.ToString(),     //审批数量
									   Output.Operation.ExamOper.ID,           //审批人
									   Output.Operation.ExamOper.OperTime.ToString(),    //审批日期
									   this.Operator.ID,              //操作人
									   Output.Operation.ExamOper.OperTime.ToString()     //操作时间	                   
								   };


                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "审批出库记录的SQl参数赋值出错！Pharmacy.Item.ExamOutput" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 核准出库信息（摆药确认）
        /// </summary>
        /// <param name="Output">出库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int ApproveOutput(Neusoft.HISFC.Models.Pharmacy.Output Output)
        {
            string strSQL = "";
            //核准出库信息（摆药确认），更新申请状态为'2'。
            if (this.Sql.GetSql("Pharmacy.Item.ApproveOutput", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Item.ApproveOutput";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   Output.ID,                        //出库流水号
									   Output.Quantity.ToString(),       //核准数量
									   Output.Operation.ApproveOper.ID,           //核准人
									   Output.Operation.ApproveOper.OperTime.ToString(),    //核准日期
									   this.Operator.ID,                 //操作人
									   Output.Operation.ApproveOper.OperTime.ToString()     //操作时间	                   
								   };


                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "核准出库记录的SQl参数赋值时出错！Pharmacy.Item.ApproveOutput" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 同时更新出库审批（摆药）、出库核准（摆药确认）信息
        /// </summary>
        /// <param name="Output">出库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int SetOutput(Neusoft.HISFC.Models.Pharmacy.Output Output)
        {
            string strSQL = "";
            //同时更新出库审批（摆药）、出库核准（摆药确认）信息，更新申请状态为'2'。
            if (this.Sql.GetSql("Pharmacy.Item.SetOutput", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Item.SetOutput";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   Output.ID,                  //出库流水号
									   Output.Quantity.ToString(), //审批数量
									   Output.Operation.ExamOper.ID,        //审批人
									   Output.Operation.ExamOper.OperTime.ToString(), //审批日期
									   Output.Quantity.ToString(), //核准数量
									   Output.Operation.ExamOper.ID,        //核准人
									   Output.Operation.ExamOper.OperTime.ToString(), //核准日期
									   this.Operator.ID,           //操作人
									   Output.Operation.ExamOper.OperTime.ToString()  //操作时间	                   
								   };


                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新出库记录的SQl参数赋值时出错！Pharmacy.Item.SetOutput" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对患者管理库存的药品进行出库处理
        /// </summary>
        /// <param name="execOrder">医嘱执行实体</param>
        /// <param name="feeFlag">计费标志 0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费</param>
        /// <param name="isFee">是否已收费 feeFlag 为 "0" 时该参数才有意义</param>
        /// <param name="feeNum">计费数量 isFee为true时本参数才有效</param>
        /// <returns>成功返回1 失败返回-1</returns>
        [System.Obsolete("重构整合 更改为Integrate内的PatientStore函数", true)]
        public int Output(Neusoft.HISFC.Models.Order.ExecOrder execOrder, ref string feeFlag, ref decimal feeNum, ref bool isFee)
        {
            feeFlag = "2";
            feeNum = 0;
            isFee = true;
            if (!execOrder.Order.Item.IsPharmacy)
            {
                this.Err = "非药品不能进行摆药处理";
                return -1;
            }
            Neusoft.HISFC.Models.Pharmacy.Item itemPha = execOrder.Order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
            if (itemPha == null)
            {
                this.Err = "传入的医嘱执行实体内项目为非药品 " + execOrder.Order.Item.Name;
                return -1;
            }
            string drugProperty = this.GetDrugProperty(execOrder.Order.Item.ID, itemPha.DosageForm.ID, execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID);
            if (drugProperty != "3")	//配药属性不是 不可拆分 当日取整 正常处理
            {
                feeFlag = "2";			//0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费
                feeNum = 0;
                return 1;
            }
            execOrder.Order.Qty = System.Convert.ToDecimal(execOrder.Order.DoseOnce) / itemPha.BaseDose;
            //对配药属性是 不可拆分 当日取整 处理患者库存
            ArrayList al = this.QueryStorageList(execOrder.Order.Patient.ID, execOrder.Order.Item.ID);
            if (al == null)
            {
                return -1;
            }
            DateTime sysTime = this.GetDateTimeFromSysDateTime();
            if (al.Count == 0)
            {
                #region 库存内无该患者的药品库存
                feeNum = (decimal)System.Math.Ceiling((double)execOrder.Order.DoseOnce / (double)itemPha.BaseDose);
                Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase = new StorageBase();
                storageBase.Item = itemPha;			//项目实体
                storageBase.StockDept.ID = execOrder.Order.Patient.ID;	//库存患者住院号
                storageBase.TargetDept.ID = execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID; //目标科室 患者所在科室
                storageBase.GroupNO = 1;			//批次
                storageBase.Quantity = feeNum - execOrder.Order.Qty;			//库存数量
                storageBase.ValidTime = sysTime.Date;	//单据号 存储当日日期
                storageBase.SerialNO = 0;
                storageBase.PrivType = "AAAA";
                storageBase.State = "1";				//
                storageBase.Memo = "患者库存";
                storageBase.Operation.Oper.ID = this.Operator.ID;
                storageBase.Operation.Oper.OperTime = sysTime;
                if (this.InsertStorage(storageBase) == -1)
                {
                    return -1;
                }

                feeFlag = "1";					//0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费
                return 1;
                #endregion
            }
            else
            {
                #region 库存内有该患者库存药品
                Neusoft.HISFC.Models.Pharmacy.Storage storage;			//库存实体
                Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase = new StorageBase();
                storage = al[0] as Neusoft.HISFC.Models.Pharmacy.Storage;
                ////库存记录的发送日期 小于本次操作日期 则将原记录库存量清零 更新为本次库存量 进行计费处理 发摆药申请
                if (storage.StoreQty < execOrder.Order.Qty || storage.ValidTime.Date < sysTime.Date)
                {
                    #region 原库存记录数量清零 更新为本次应剩库存量
                    feeNum = (decimal)System.Math.Ceiling((double)execOrder.Order.DoseOnce / (double)itemPha.BaseDose);
                    storageBase.Item = storage.Item;
                    storageBase.StockDept.ID = storage.StockDept.ID;
                    storageBase.Item.ID = storage.Item.ID;
                    storageBase.GroupNO = 1;
                    storageBase.PrivType = "AAAA";
                    storageBase.Quantity = -storage.StoreQty + feeNum - execOrder.Order.Qty;		//清空原库存量 更新为本次量
                    storageBase.ValidTime = sysTime.Date;		//存储当天日期
                    storageBase.ID = "1";
                    storageBase.SerialNO = 0;
                    storageBase.TargetDept.ID = execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID;
                    storageBase.Operation.Oper.ID = this.Operator.ID;
                    if (this.UpdateStorageNum(storageBase, sysTime.Date) != 1)
                    {
                        return -1;
                    }
                    feeFlag = "1";					//0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费
                    return 1;
                    #endregion
                }
                if (storage.StoreQty >= execOrder.Order.Qty)
                {
                    #region 满足更新条件 更新患者库存
                    storageBase.Item = storage.Item;
                    storageBase.StockDept.ID = storage.StockDept.ID;
                    storageBase.Item.ID = storage.Item.ID;
                    storageBase.GroupNO = 1;
                    storageBase.PrivType = "AAAA";
                    storageBase.Quantity = -execOrder.Order.Qty;
                    storageBase.ValidTime = sysTime.Date;		//存储当天日期
                    storageBase.ID = "1";
                    storageBase.SerialNO = 0;
                    storageBase.TargetDept.ID = execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID;
                    storageBase.Operation.Oper.ID = this.Operator.ID;
                    if (this.UpdateStorageNum(storageBase, sysTime.Date) != 1)
                    {
                        return -1;
                    }
                    feeFlag = "0";				//0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费
                    feeNum = 0;
                    if (storage.State == "0")	//0 暂入库状态 1 正式入库状态 用于标志是否已收费
                        isFee = false;
                    else
                        isFee = true;
                    return 1;
                    #endregion
                }
                #endregion
            }
            return 1;
        }

        #region 出库操作

        /// <summary>
        /// 根据出库申请进行摆药出库。
        /// 此方法适合于摆药同时扣库存的情况。如果摆药时，不扣库存而只是核准出库申请单，调用ApproveApplyOut();
        /// 如果此方法返回0，说明程序产生并发，欲核准的出库申请已经被其他调用者核准或者作废。
        /// 执行操作：
        /// 1、将出库申请数据转为出库数据
        /// 2、进行出库综合处理
        /// 3、核准出库申请单
        /// 4、消减预扣库存
        /// </summary>
        /// <param name="applyOut">出库申请实体</param>
        /// <returns>1成功，0没有更新，-1失败 ErrCode 2 库存不足</returns>
        public int Output(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            //将出库申请数据转为出库数据。								 
            Neusoft.HISFC.Models.Pharmacy.Output output = new Output();

            output.StockDept = applyOut.Operation.ApproveOper.Dept;             //出库科室＝摆药核准科室
            output.SystemType = applyOut.SystemType;                            //系统类型＝出库申请类型
            output.PrivType = applyOut.PrivType;
            output.Item = applyOut.Item;                                        //药品实体
            output.ShowState = applyOut.ShowState;                              //显示的单位标记（0最小单位，1包装单位）
            output.Quantity = applyOut.Operation.ApproveQty * applyOut.Days;    //出库数量＝摆药核准数量
            output.State = applyOut.State;                                      //出库状态＝摆药状态
            output.GetPerson = applyOut.PatientNO;                              //取 药 人＝患者ID
            output.DrugedBillNO = applyOut.DrugNO;                              //摆药单号
            output.SpecialFlag = "0";                                           //特殊标记。1是，0否
            output.TargetDept = applyOut.ApplyDept;                             //领用科室＝出库申请科室
            output.RecipeNO = applyOut.RecipeNO;                                //处方号
            output.SequenceNO = applyOut.SequenceNO;                            //处方内流水号
            output.Operation.ApplyQty = applyOut.Operation.ApplyQty * applyOut.Days;     //出库申请数量
            output.Operation.ApplyOper.ID = applyOut.Operation.ApplyOper.ID;             //出库申请人编码
            output.Operation.ApplyOper.OperTime = applyOut.Operation.ApplyOper.OperTime; //出库申请日期
            output.Operation.ExamQty = applyOut.Operation.ApproveQty * applyOut.Days;    //审批出库数量＝摆药核准数量
            output.Operation.ExamOper.ID = applyOut.Operation.ExamOper.ID;               //审批人 ＝打印人
            output.Operation.ExamOper.OperTime = applyOut.Operation.ExamOper.OperTime;   //审批日期＝打印日期
            output.State = "2";

            //制剂管理业务中 存储生产计划号
            if (applyOut.BillNO != "")
                output.OutListNO = applyOut.BillNO;

            if (applyOut.State == "2")
            {
                //如果是核准出库状态，则赋值
                output.Operation.ApproveOper.ID = applyOut.Operation.ApproveOper.ID; //核准人（用户录入的工号）
            }

            //如果是退库，则进行退库综合处理，否则进行出库综合处理。
            if (applyOut.SystemType.Substring(1) == "2")
            {
                //退库处理
                output.Quantity = -output.Quantity;	//退库数量为负数
                output.Operation.ExamQty = -output.Operation.ExamQty;		//退库数量为负数
                //{0B42E3DB-BDD9-46dd-95EF-D1424327587D}  参数调整
                if (this.OutputReturn(output, applyOut.OutBillNO, -1) == -1) return -1;
            }
            else
            {
                //出库处理
                if (this.Output(output) == -1) return -1;
            }
            int parm;

            //如果出库申请的时候预扣了库存，则在核准的时候消减预扣库存（加操作） 退库是不减预扣
            if (applyOut.SystemType.Substring(1) != "2" && applyOut.IsPreOut)
            {
                //{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                parm = this.UpdateStockinfoPreOutNum(applyOut, -applyOut.Operation.ApproveQty , applyOut.Days);
                if (parm != 1) return parm;
            }

            //返回出库单号，保存在出库申请实体中
            applyOut.OutBillNO = output.ID == null ? "0" : output.ID;
            return 1;
        }

        /// <summary>
        /// 出库－－对其他子系统公开的函数。
        /// 此方法试用于没有出库申请，直接出库时调用。
        /// 目前此方法中没有科隆新的出库实体，而是使用传入的出库实体，方法中会对此实体中的属性做修改。以后改进
        /// 参数Output中必须传入的项目：
        ///		output.Dept.ID,           ***出库科室编码
        ///		output.OutListNO,       ***出库单据号
        ///		output.SystemType,        ***出库分类
        ///		output.Item.ID,           ***药品编码
        ///		output.Item.Name,         ***药品商品名
        ///		output.Item.Type.ID,      ***药品类别
        ///		output.Item.Quality.ID,   ***药品性质
        ///		output.Item.Specs,        ***规格
        ///		output.Item.PackUnit,     ***包装单位
        ///		output.Item.PackQty,      ***包装数
        ///		output.Item.MinUnit,      ***最小单位
        ///		output.ShowState,         ***显示的单位标记（0最小单位，1包装单位）
        ///		output.RetailPrice,       ***零售价
        ///		output.Quantity,          ***出库量
        ///		output.ExamNum,           ***审批数量（扣库存的数量）
        ///		output.ExamOperCode,      ***审批人（扣库存操作的人）
        ///		output.ExamDate,          ***审批日期（扣库存的时间）
        ///		output.TargetDept.ID,     ***领药单位编码
        ///		output.RecipeNo,          ***处方号（药房发药出库时必须填写）
        ///		output.SequenceNo,        ***处方流水号（药房发药出库时必须填写）
        ///		output.OperDate,          ***操作时间
        ///		
        ///	内部处理流程：
        /// 1、取实际库存汇总表中此药品总数量
        /// 2、判断库存是否不足，退库允许没有库存或者不足
        /// 3、取本次出库药品的库存明细记录数组
        /// 4、循环。按照效期近、批次小先出库的原则进行出库处理。对于退库的药品，处理方式相同。
        ///    4.1当库存数量大于出库数量时，则将此批次库存记录出库，出库数量等于待出库数量。(本次循环结束不再找下一个批次)
        ///    4.2如果库存数量小于出库数量，则将此批次库存数量全部出库。（程序会继续查找下一个批次的库存信息）
        ///	   4.3剩余待摆药数量＝本次待摆药数量－本次摆药数量。如果剩余待摆药数量大于0，循环将继续进行。
        ///	   4.4库存数量减少，减少的量等于出库数量
        ///	   4.5插入出库记录
        ///	   4.6修改库存数据（通过库存明细表的触发器实现台帐表，库存汇总表处理）
        ///	   4.7如果出库的药品零售价跟库存中的药品零售价不同，则记录调价盈亏
        ///	循环当待出库数量小于等于0时结束。
        /// </summary>
        /// <returns>0没有删除1 成功 -1 失败 ErrCode 2 库存不足 </returns>
        public int Output(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            return Output(output, null, false);
        }

        /// <summary>
        /// 处理出库信息 并根据标志处理入库记录
        /// </summary>
        /// <param name="output">出库实体</param>
        /// <param name="input">入库实体</param>
        /// <param name="isManagerInput">是否处理入库记录</param>
        /// <returns>1 成功 -1 失败 ErrCode 2 库存不足</returns>
        public int Output(Neusoft.HISFC.Models.Pharmacy.Output output, Neusoft.HISFC.Models.Pharmacy.Input input, bool isManagerInput)
        {
            //入库实体临时变量 用于处理入库记录
            Neusoft.HISFC.Models.Pharmacy.Input inputTemp;

            #region 库存量是否足够判断

            //住院摆药性能优化【修改撤销，为了不影响住院摆药之外的出库库存判断】 by Sunjh 2010-8-30 {32F6FA1C-0B8E-4b9c-83B6-F9626397AC7C}

            //***批次>0表示退库或者按某一批次进行出库
            //出库数量为output.Quantity，更新库存变化数量为storageBase.Quantity
            //取实际库存汇总表中此药品总数量
            decimal storageNum = 0;
            if (output.BatchNO == "ALL")
            {
                output.BatchNO = null;
            }
            if (this.GetStorageNum(output.StockDept.ID, output.Item.ID, output.BatchNO, out storageNum) == -1)
            {
                return -1;
            }
            //判断库存是否不足，退库允许没有库存或者不足
            if ((Item.MinusStore == false) && (storageNum < output.Quantity) && (output.Quantity > 0))
            {
                this.Err = output.Item.Name + "的库存数量不足。请补充库存";
                this.ErrCode = "2";
                return -1;
            }

            #endregion

            //取本次出库药品的库存明细记录数组
            ArrayList al = this.QueryStorageList(output.StockDept.ID, output.Item.ID, output.BatchNO);
            if (al == null)
            {
                return -1;
            }

            //取出库单流水号保存在output中，可以被外面调用，一个药品一个出库流水号，可能对应多个批次
            output.ID = this.GetNewOutputNO();
            if (output.ID == null)
            {
                return -1;
            }

            //临时存储出库总数量和待出库数量
            Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase = new StorageBase();
            decimal totOutNum = output.Quantity;
            decimal leftOutNum = output.Quantity;
            
            //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}   增加对出库时间的赋值
            DateTime sysDate = this.GetDateTimeFromSysDateTime();

            //按照效期近、批次小先出库的原则进行出库处理。对于退库的药品，处理方式相同。
            for (int i = 0; leftOutNum > 0; i++)
            {
                #region 循环进行出库处理

                if (al.Count > 0)
                {
                    #region 库存明细中存在记录  如果库存明细记录大于零时，取库存中的数据

                    //取库存记录中的数据
                    storageBase = al[i] as StorageBase;
                    //对库存明细中为零的数据 不生成出库记录
                    if (storageBase.StoreQty == 0)
                    {
                        continue;
                    }

                    //在库存实体中保存相应的出库信息
                    storageBase.ID = output.ID;                     //出库单流水号
                    storageBase.SerialNO = output.SerialNO;         //出库单内序号
                    storageBase.SystemType = output.SystemType;     //系统出库类型

                    storageBase.PrivType = output.PrivType;
                    storageBase.Class2Type = output.Class2Type;

                    //原处理方式
                    //if (output.PrivType.IndexOf("|") == -1)
                    //    storageBase.PrivType = "0320|" + output.PrivType;    //出库类型

                    storageBase.TargetDept = output.TargetDept;     //领药部门

                    //将部门库存信息保存到出库记录中
                    output.GroupNO = storageBase.GroupNO;           //批次
                    output.BatchNO = storageBase.BatchNO;           //批号
                    output.Company = storageBase.Company;           //供货公司
                    output.PlaceNO = storageBase.PlaceNO;           //货位号
                    output.Producer = storageBase.Producer;         //生产厂家
                    output.ValidTime = storageBase.ValidTime;       //有效期

                    #endregion
                }

                //当库存数量大于出库数量时（或者库存中无数据，只要当允许为负库存时才能出现此中情况），则将此批次库存记录出库，出库数量等于待出库数量
                if (storageBase.StoreQty >= leftOutNum || al.Count == 0)
                {
                    //出库数量等于待出库数量（待出库数量会随着循环的增加而逐渐减少）
                    output.Quantity = leftOutNum;
                }
                else
                {
                    //如果库存数量小于出库数量，则将此批次库存数量全部出库。（程序会继续查找下一个批次的库存信息）
                    output.Quantity = storageBase.StoreQty;
                }

                //库存数量减少，减少的量等于出库数量（此处的storageBase.Quantity用来保存库存变化量）
                storageBase.Quantity = -output.Quantity;

                //剩余待摆药数量＝本次待摆药数量－本次摆药数量。如果剩余待摆药数量大于0，循环将继续进行。
                leftOutNum = leftOutNum - output.Quantity;

                //按批次出库时，如果同一样物品产生多条出库记录，单内序号增加
                output.SerialNO = i + 1;

                //对于一条入库申请，如果出库记录多于一条，只有第一条出库记录中保存“申请数量",其余的出库记录中的申请数量为0，保证汇总数量正确
                if (i > 0)
                {
                    output.Operation.ApplyQty = 0;
                }

                //出库后库存量
                output.StoreQty = storageBase.StoreQty + storageBase.Quantity;
                //审核数量
                output.Operation.ExamQty = output.Quantity;

                #region 插入出库记录 更新库存

                //插入出库记录
                //取库存表里边的价格。购入价、零售价。
                //对于价让出库，取出库传入的价格；其他类型取库存内最新价格
                if (output.SystemType != Neusoft.HISFC.Models.Base.EnumIMAOutTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAOutType.TransferOutput))
                {                    
                    output.Item.PriceCollection = storageBase.Item.PriceCollection;
                }

                //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}  出库时间赋值 记录出库记录发生时间
                output.OutDate = sysDate;
                
                if (this.InsertOutput(output) != 1)
                {
                    this.Err = "插入出库记录时出错！" + this.Err;
                    return -1;
                }

                //修改库存数据（通过库存明细表的触发器实现台帐表，库存汇总表处理）
                //先执行更新数量操作，如果数据库中没有记录则执行插入操作
                storageBase.Class2Type = "0320";
                if (this.SetStorage(storageBase) != 1)
                {
                    this.Err = "更新库存表时出错！" + this.Err;
                    return -1;
                }

                #endregion

                #region 处理对应领用部门的入库数据（"特殊出库"不处理领用单位的入库，台帐，库存）

                //特殊出库、生产出库不处理
                if (output.SystemType != "26" && output.SystemType != "31")
                {
                    //判断是否需要处理入库记录 在不管理库存的情况下才处理入库记录 自动插入入库记录
                    if (isManagerInput && input != null)
                    {	//插入领用部门入库记录
                        inputTemp = new Input();
                        inputTemp = input.Clone();
                        inputTemp.OutBillNO = output.ID;				//出库流水号
                        inputTemp.Item = output.Item;					//药品实体
                        inputTemp.Quantity = output.Quantity;			//数量
                        inputTemp.GroupNO = output.GroupNO;				//批次
                        inputTemp.BatchNO = output.BatchNO;				//批号
                        inputTemp.Company = output.StockDept;				//供货单位
                        inputTemp.PlaceNO = output.PlaceNO;			//货位号
                        inputTemp.Producer = output.Producer;			//生产厂家
                        inputTemp.ValidTime = output.ValidTime;			//有效期
                        if (this.Input(inputTemp, "1", "1") == -1)
                        {
                            return -1;
                        }

                        output.InBillNO = inputTemp.ID;
                        output.InSerialNO = inputTemp.SerialNO;
                        output.InListNO = inputTemp.InListNO;

                        if (this.UpdateOutput(output) == -1)
                        {
                            this.Err = "入库记录生成后，更新出库记录执行出错！" + this.Err;
                            return -1;
                        }
                    }
                }

                #endregion

                #endregion
            }

            //恢复output实体中传入时的数值
            output.Quantity = totOutNum;

            return 1;
        }

        /// <summary>
        /// 出库－－对其他子系统公开的函数。
        /// 此方法试用于没有出库申请，直接出库时调用。
        /// 目前此方法中没有科隆新的出库实体，而是使用传入的出库实体，方法中会对此实体中的属性做修改。以后改进
        ///		
        ///	内部处理流程：
        /// 1、取实际库存汇总表中此药品总数量
        /// 2、判断库存是否不足，退库允许没有库存或者不足
        /// 3、取本次出库药品的库存明细记录数组
        /// 4、循环。按照效期近、批次小先出库的原则进行出库处理。对于退库的药品，处理方式相同。
        ///    4.1当库存数量大于出库数量时，则将此批次库存记录出库，出库数量等于待出库数量。(本次循环结束不再找下一个批次)
        ///    4.2如果库存数量小于出库数量，则将此批次库存数量全部出库。（程序会继续查找下一个批次的库存信息）
        ///	   4.3剩余待摆药数量＝本次待摆药数量－本次摆药数量。如果剩余待摆药数量大于0，循环将继续进行。
        ///	   4.4库存数量减少，减少的量等于出库数量
        ///	   4.5插入出库记录
        ///	   4.6修改库存数据（通过库存明细表的触发器实现台帐表，库存汇总表处理）
        ///	   4.7如果出库的药品零售价跟库存中的药品零售价不同，则记录调价盈亏
        ///	循环当待出库数量小于等于0时结束。
        /// </summary>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int OutputReturn(Neusoft.HISFC.Models.Pharmacy.Output output, string outputID, int serialNO)
        {
            return this.OutputReturn(output, outputID, serialNO, false);
        }

        /// <summary>
        /// 实现出库库退库
        /// </summary>
        /// <param name="output">待出库实体</param>
        /// <param name="outputID">出库流水号</param>
        /// <param name="isManagerInput">是否处理入库记录</param>
        /// <returns>0 没有删除 1 成功 －1 失败</returns>
        public int OutputReturn(Neusoft.HISFC.Models.Pharmacy.Output output, string outputID, int serialNO, bool isManagerInput)
        {
            Neusoft.HISFC.Models.Pharmacy.Input inputInfo;
            Neusoft.HISFC.Models.Pharmacy.Input inputTemp;

            //取出库单流水号保存在output中，可以被外面调用
            output.ID = this.GetNewOutputNO();
            if (output.ID == null) return -1;

            //临时存储出库总数量和待出库数量
            Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase;
            decimal totOutNum = output.Quantity;
            decimal leftOutNum = output.Quantity;

            #region 根据出库退库记录中的出库单流水号，取出库数据列表。

            //{0B42E3DB-BDD9-46dd-95EF-D1424327587D}  此段改动为了保证 出库退库时可按所选择的批号退库
            ArrayList al = new ArrayList();

            ArrayList alOriginal = this.QueryOutputList(outputID);
            if (alOriginal == null)
            {
                return -1;
            }
            //如果al超出索引，则提示出错
            if (alOriginal.Count == 0)
            {
                this.Err = "没有找到退库操作所对应的出库记录！";
                return -1;
            }
            if (serialNO != -1)
            {
                foreach (Neusoft.HISFC.Models.Pharmacy.Output outputSerial in alOriginal)
                {
                    if (outputSerial.SerialNO == serialNO)
                    {
                        al.Add(outputSerial);
                    }
                }
            }
            else
            {
                al = alOriginal;
            }
            //{0B42E3DB-BDD9-46dd-95EF-D1424327587D}  
            #endregion

            Neusoft.HISFC.Models.Pharmacy.Output info;
            //如果退库申请中，指定确定的批次，则将此批次记录退掉。
            //否则，在与出库申请对应的出库记录中按批次小先退的原则，做退库处理。

            DateTime sysTime = this.GetDateTimeFromSysDateTime();

            string inListCode = "";

            for (int i = 0; leftOutNum < 0; i++)
            {
                if (al.Count == i)
                {
                    this.Err = "该条出库记录的出库数量不足以进行此次退库 请重新选择退库记录";
                    return -1;
                }
                //取出库记录中的数据  
                info = al[i] as Output;
                //出库数量＝退库数量 且为最后出库记录
                if (info.Quantity == info.Operation.ReturnQty)
                {
                    continue;
                }

                #region 根据原出库记录 生成退库记录

                //将出库时的信息保存到退库记录中
                output.GroupNO = info.GroupNO;					//批次
                output.BatchNO = info.BatchNO;					//批号
                output.Company = info.Company;					//供货公司
                output.PlaceNO = info.PlaceNO;					//货位号
                output.Producer = info.Producer;					//生产厂家
                output.ValidTime = info.ValidTime;					//有效期
                output.Item.PriceCollection.RetailPrice = info.Item.PriceCollection.RetailPrice;	//零售价 利用原出库价格退库

                //当某一批次的可退数量（已出库数量－已退库数量）大于待退库数量时，则将此批次出库记录退库，退库数量等于待退库数量。(本次循环结束不再找下一个批次)
                if (info.Quantity - info.Operation.ReturnQty >= Math.Abs(leftOutNum))
                {
                    //退库数量等于待退库数量（待退库数量会随着循环的增加而逐渐减少）
                    //退库数量是负数
                    output.Quantity = leftOutNum;
                }
                else
                {
                    //如果可退数量（已出库数量－已退库数量）小于于待退库数量，则将此批次出库记录中的可退库数量全部退库。（程序会继续查找下一个批次的库存信息）
                    //退库数量是负数
                    output.Quantity = -(info.Quantity - info.Operation.ReturnQty);
                }

                //剩余待退库数量（负数）＝本次待退药数量（负数）－本次退药数量（负数）。如果剩余待退药数量小于0，则循环将继续进行。
                leftOutNum = leftOutNum - output.Quantity;

                //单内序号增加
                output.SerialNO = i + 1;

                //对于一条入库申请，如果出库记录多于一条，只有第一条出库记录中保存“申请数量",其余的出库记录中的申请数量为0，保证汇总数量正确
                if (i > 0) output.Operation.ApplyQty = 0;

                //插入出库记录
                output.State = "2";					//不需核准操作

                #endregion

                //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}  出/退库记录发生时间
                output.OutDate = sysTime;

                if (this.InsertOutput(output) != 1)
                {
                    this.Err = "插入出库记录时出错！" + this.Err;
                    return -1;
                }

                //更新出库记录中的"已退库数量"字段（加操作）
                output.Quantity = -output.Quantity;
                if (this.UpdateOutputReturnNum(outputID, info.SerialNO, output.Quantity) != 1)
                {
                    this.Err = "更新出库记录中的已退库数量时出错！" + this.Err;
                    return -1;
                }

                //{7788EE66-74E7-4b9d-B4DA-EFE14DBFAD0E}  说明是对审批记录的退库 更新该审批记录为已核准状态
                if (output.SystemType == "22" && info.State == "1")
                {
                    info.Operation.ApproveOper = output.Operation.ApproveOper;
                    if (this.ApproveOutput(info) == -1)
                    {
                        this.Err = "针对审批记录退库 更新原审批记录为核准状态出错！" + this.Err;
                        return -1;
                    }
                }

                //将出库数据赋值给库存数据，退库数量output.Quantity即是库存变化量（库存更新数量时是减操作）storageBase.Quantity（负数）
                storageBase = output.Clone() as StorageBase;

                storageBase.Class2Type = output.Class2Type;
                storageBase.PrivType = output.PrivType;

                //原实现方式
                //if (output.PrivType.IndexOf("|") == -1)
                //    storageBase.PrivType = "0320|" + output.PrivType;

                //修改库存数据（通过库存明细表的触发器实现台帐表，库存汇总表处理）
                //库存变化的数量（库存修改执行的加操作）跟出库的数量相反。
                //先执行更新数量操作，如果数据库中没有记录则执行插入操作
                if (this.SetStorage(storageBase) != 1)
                {
                    this.Err = "更新库存表时出错！" + this.Err;
                    return -1;
                }

                #region 如果出库的药品零售价跟库存中的药品零售价不同，则记录调价盈亏

                #region 屏蔽该段代码 通过函数调用实现

                //string adjustPriceID = "";
                //bool isDoAdjust = false;
                //decimal dNowPrice = 0;
                //dNowPrice = output.Item.PriceCollection.RetailPrice;

                //if (info.Item.PriceCollection.RetailPrice != dNowPrice)
                //{
                //    if (!isDoAdjust)
                //    {
                //        adjustPriceID = this.GetSequence("Pharmacy.Item.GetNewAdjustPriceID");
                //        if (adjustPriceID == null)
                //        {
                //            this.Err = "出库退库药品已发生调价 插入调价盈亏记录过程中获取调价单号出错！";
                //            return -1;
                //        }
                //    }
                //    Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice = new AdjustPrice();
                //    adjustPrice.ID = adjustPriceID;								//调价单号
                //    adjustPrice.SerialNO = i;									//调价单内序号
                //    adjustPrice.Item = info.Item;
                //    adjustPrice.StockDept.ID = info.StockDept.ID;				//调价科室 
                //    adjustPrice.State = "1";									//调价状态 1 已调价
                //    adjustPrice.StoreQty = output.Quantity;
                //    adjustPrice.Operation.Oper.ID = this.Operator.ID;
                //    adjustPrice.Operation.Oper.Name = this.Operator.Name;
                //    adjustPrice.Operation.Oper.OperTime = sysTime;
                //    adjustPrice.InureTime = sysTime;
                //    adjustPrice.AfterRetailPrice = dNowPrice;//调价后零售价
                //    if (dNowPrice - info.Item.PriceCollection.RetailPrice > 0)
                //        adjustPrice.ProfitFlag = "1";							//调盈
                //    else
                //        adjustPrice.ProfitFlag = "0";							//调亏
                //    adjustPrice.Memo = "出库退库补调价盈亏";
                //    if (!isDoAdjust)			//每次只插入一次调价汇总表
                //    {
                //        if (this.InsertAdjustPriceInfo(adjustPrice) == -1)
                //        {
                //            return -1;
                //        }
                //        isDoAdjust = true;
                //    }
                //    if (this.InsertAdjustPriceDetail(adjustPrice) == -1)
                //    {
                //        return -1;
                //    }
                //}

                #endregion

                this.OutputAdjust(info, output, sysTime, i);

                #endregion

                #region 处理对应领用部门的入库数据（"特殊出库"不处理领用单位的入库，台帐，库存）

                //插入领用部门入库记录
                //判断是否需要对领用部门进行库存管理。如果管理库存，则进行下面处理：
                if (isManagerInput)
                {
                    inputInfo = this.GetInputInfoByID(info.InBillNO);
                    if (inputInfo == null)
                    {
                        return -1;
                    }

                    inputTemp = inputInfo.Clone();

                    inputTemp.ID = "";							//流水号
                    inputTemp.Quantity = -output.Quantity;		//数量
                    inputTemp.GroupNO = output.GroupNO;			//批次
                    inputTemp.BatchNO = output.BatchNO;			//批号
                    inputTemp.Company = output.StockDept;		//供货公司
                    inputTemp.PlaceNO = output.PlaceNO;		    //货位号
                    inputTemp.Producer = output.Producer;		//生产厂家
                    inputTemp.ValidTime = output.ValidTime;		//有效期
                    inputTemp.Operation.ReturnQty = 0;

                    inputTemp.InListNO = output.OutListNO;
                    inputTemp.OutBillNO = output.ID;          //出库单据号

                    //插入入库负记录
                    if (this.Input(inputTemp, "1", "1") == -1)
                    {
                        this.Err = this.Err + "插入入库负记录出错！";
                        return -1;
                    }
                    //更新原入库记录退库数量
                    if (this.UpdateInputReturnNum(inputInfo.ID, inputInfo.SerialNO, -inputTemp.Quantity) != 1)
                    {
                        this.Err = this.Err + "更新入库记录退库数量出错！";
                        return -1;
                    }
                }

                #endregion
            }

            //恢复output实体中传入时的数值
            output.Quantity = totOutNum;
            return 1;
        }

        /// <summary>
        /// 出库退库时 对价格发生变化时 更新调价记录
        /// </summary>
        /// <returns></returns>
        public int OutputAdjust(Neusoft.HISFC.Models.Pharmacy.Output privOutput, Neusoft.HISFC.Models.Pharmacy.Output nowOutput, DateTime sysTime, int serialNo)
        {
            string adjustPriceID = "";
            bool isDoAdjust = false;
            decimal dNowPrice = 0;
            dNowPrice = nowOutput.Item.PriceCollection.RetailPrice;
            if (this.GetNowPrice(nowOutput.Item.ID, ref dNowPrice) == -1)
            {
                this.Err = "出库退库处理调价盈亏时 获取最新药品零售价失败";
                return -1;
            }

            if (privOutput.Item.PriceCollection.RetailPrice != dNowPrice)
            {
                if (!isDoAdjust)
                {
                    adjustPriceID = this.GetSequence("Pharmacy.Item.GetNewAdjustPriceID");
                    if (adjustPriceID == null)
                    {
                        this.Err = "出库退库药品已发生调价 插入调价盈亏记录过程中获取调价单号出错！";
                        return -1;
                    }
                }
                Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice = new AdjustPrice();
                adjustPrice.ID = adjustPriceID;								//调价单号
                adjustPrice.SerialNO = serialNo;									//调价单内序号
                adjustPrice.Item = privOutput.Item;
                adjustPrice.StockDept.ID = privOutput.StockDept.ID;				//调价科室 
                adjustPrice.State = "1";									//调价状态 1 已调价
                adjustPrice.StoreQty = nowOutput.Quantity;
                adjustPrice.Operation.Oper.ID = this.Operator.ID;
                adjustPrice.Operation.Oper.Name = this.Operator.Name;
                adjustPrice.Operation.Oper.OperTime = sysTime;
                adjustPrice.InureTime = sysTime;
                adjustPrice.AfterRetailPrice = dNowPrice;//调价后零售价
                if (dNowPrice - privOutput.Item.PriceCollection.RetailPrice > 0)
                    adjustPrice.ProfitFlag = "1";							//调盈
                else
                    adjustPrice.ProfitFlag = "0";							//调亏
                adjustPrice.Memo = "出库退库补调价盈亏";
                if (!isDoAdjust)			//每次只插入一次调价汇总表
                {
                    if (this.InsertAdjustPriceInfo(adjustPrice) == -1)
                    {
                        return -1;
                    }
                    isDoAdjust = true;
                }
                if (this.InsertAdjustPriceDetail(adjustPrice) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }
    
        #endregion

        #region 药柜出、退库

        /// <summary>
        /// 药柜出库摆药
        /// </summary>
        /// <param name="applyOut">摆药申请信息</param>
        /// <param name="arkDept">摆药药柜信息</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int ArkOutput(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, Neusoft.FrameWork.Models.NeuObject arkDept)
        {
            //将出库申请数据转为出库数据。								 
            Neusoft.HISFC.Models.Pharmacy.Output output = new Output();

            #region 出库数据赋值

            output.StockDept = applyOut.Operation.ApproveOper.Dept;             //出库科室＝摆药核准科室
            output.SystemType = applyOut.SystemType;                            //系统类型＝出库申请类型
            output.PrivType = applyOut.PrivType;
            output.Item = applyOut.Item;                                        //药品实体
            output.ShowState = applyOut.ShowState;                              //显示的单位标记（0最小单位，1包装单位）
            output.Quantity = applyOut.Operation.ApproveQty * applyOut.Days;    //出库数量＝摆药核准数量
            output.State = applyOut.State;                                      //出库状态＝摆药状态
            output.GetPerson = applyOut.PatientNO;                              //取 药 人＝患者ID
            output.DrugedBillNO = applyOut.DrugNO;                              //摆药单号
            output.SpecialFlag = "0";                                           //特殊标记。1是，0否
            output.TargetDept = applyOut.ApplyDept;                             //领用科室＝出库申请科室
            output.RecipeNO = applyOut.RecipeNO;                                //处方号
            output.SequenceNO = applyOut.SequenceNO;                            //处方内流水号
            output.Operation.ApplyQty = applyOut.Operation.ApplyQty * applyOut.Days;     //出库申请数量
            output.Operation.ApplyOper.ID = applyOut.Operation.ApplyOper.ID;             //出库申请人编码
            output.Operation.ApplyOper.OperTime = applyOut.Operation.ApplyOper.OperTime; //出库申请日期
            output.Operation.ExamQty = applyOut.Operation.ApproveQty * applyOut.Days;    //审批出库数量＝摆药核准数量
            output.Operation.ExamOper.ID = applyOut.Operation.ExamOper.ID;               //审批人 ＝打印人
            output.Operation.ExamOper.OperTime = applyOut.Operation.ExamOper.OperTime;   //审批日期＝打印日期
            output.State = "2";

            #endregion

            if (applyOut.State == "2")
            {
                //如果是核准出库状态，则赋值
                output.Operation.ApproveOper.ID = applyOut.Operation.ApproveOper.ID; //核准人（用户录入的工号）
            }

            //如果是退库，则进行退库综合处理，否则进行出库综合处理。
            if (applyOut.SystemType.Substring(1) == "2")
            {
                //退库处理
                output.Quantity = -output.Quantity;	//退库数量为负数
                output.Operation.ExamQty = -output.Operation.ExamQty;		//退库数量为负数
                //药房退库处理
                if (this.ArkOutputReturn(output, applyOut.OutBillNO, false) == -1)
                {
                    return -1;
                }
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject stockDept = output.StockDept.Clone();

                output.StockDept = arkDept;
                //对药柜 出库处理
                if (this.ArkOutput(output.Clone(), true, false, true, false) == -1)
                {
                    return -1;
                }

                //对药房 出库处理
                output.ArkOutNO = output.ID;                //药柜出库记录流水号
                output.ID = "";                             //出库记录流水号清空
                output.StockDept = stockDept;

                if (this.ArkOutput(output, false, false, true, true) == -1)
                {
                    return -1;
                }

            }
            int parm;

            #region 库存预扣处理 如果出库申请的时候预扣了库存，则在核准的时候消减预扣库存（加操作）

            if (applyOut.IsPreOut)
            {
                //{9CBE5D4D-9FDB-4543-B7CA-8C07A67B41AF}
                parm = this.UpdateStockinfoPreOutNum(applyOut, -applyOut.Operation.ApproveQty , applyOut.Days);
                if (parm != 1)
                {
                    return parm;
                }
            }

            //返回出库单号，保存在出库申请实体中
            applyOut.OutBillNO = output.ID == null ? "0" : output.ID;

            #endregion
            return 1;
        }

        /// <summary>
        /// 药柜管理 处理出库信息 并根据标志处理入库记录
        /// </summary>
        /// <说明>
        ///     1、如果入库科室是药柜 出库科室是药房 则 不处理药房的出库记录
        ///     2、如果入库科室是药柜 出库科室是药柜 则 入库/出库记录都处理
        /// </说明>
        /// <param name="output">出库实体</param>  
        /// <param name="isChestOut">是否药柜出库</param>
        /// <param name="isChestIn">接受科室是否药柜</param>
        /// <param name="isPatientOut">是否患者出库</param>
        /// <param name="isUpdateArkQty">是否更新药柜数量</param>
        /// <returns>1 成功 -1 失败 ErrCode 2 库存不足</returns>
        public int ArkOutput(Neusoft.HISFC.Models.Pharmacy.Output output, bool isChestOut, bool isChestIn, bool isPatientOut, bool isUpdateArkQty)
        {
            #region 科室库存量判断

            //取实际库存汇总表中此药品总数量  对于药柜来说 ArkQty为0 所以对判断没影响           
            Neusoft.HISFC.Models.Pharmacy.Storage storage = this.GetStockInfoByDrugCode(output.StockDept.ID, output.Item.ID);
            //药房向药柜出库时 进行此类判断
            if (!isChestOut && isChestIn)
            {
                if (output.Quantity > (storage.StoreQty - storage.ArkQty))
                {
                    this.Err = output.Item.Name + "的库存数量不足。请补充库存";
                    this.ErrCode = "2";
                    return -1;
                }
            }
            else
            {
                if (output.Quantity > storage.StoreQty)
                {
                    this.Err = output.Item.Name + "的库存数量不足。请补充库存";
                    this.ErrCode = "2";
                    return -1;
                }
            }
            #endregion

            //取本次出库药品的库存明细记录数组（批次＝0，则取本批次库存明细）
            ArrayList al = this.QueryStorageList(output.StockDept.ID, output.Item.ID, output.BatchNO);
            if (al == null)
            {
                return -1;
            }

            //取出库单流水号保存在output中，可以被外面调用，一个药品一个出库流水号，可能对应多个批次
            output.ID = this.GetNewOutputNO();
            if (output.ID == null)
            {
                return -1;
            }

            //临时存储出库总数量和待出库数量
            Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase = null;
            decimal totOutNum = output.Quantity;
            decimal leftOutNum = output.Quantity;

            //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}  出/退库记录发生时间
            DateTime sysTime = this.GetDateTimeFromSysDateTime();

            //按照效期近、批次小先出库的原则进行出库处理
            for (int i = 0; leftOutNum > 0; i++)
            {
                if (al.Count > 0)
                {
                    #region 库存明细中存在记录  如果库存明细记录大于零时，取库存中的数据

                    //取库存记录中的数据
                    storageBase = al[i] as StorageBase;
                    //对库存明细中为零的数据 不生成出库记录  {45938EF6-62DE-4df5-85C2-7D07FA0C1166}
                    if (isPatientOut == false && isChestOut == false && isChestIn == true)               //药库出库且接受科室为药柜，此时判断库存时需考虑药柜量
                    {
                        if (storageBase.StoreQty - storageBase.ArkQty <= 0)
                        {
                            continue;
                        }
                    }
                    else                                                       //药库/药柜发药时 不需要判断药柜；药房给非药柜科室出库时  不判断
                    {
                        if (storageBase.StoreQty <= 0)
                        {
                            continue;
                        }
                    }


                    //在库存实体中保存相应的出库信息
                    storageBase.ID = output.ID;                     //出库单流水号
                    storageBase.SerialNO = output.SerialNO;         //出库单内序号
                    storageBase.SystemType = output.SystemType;     //系统出库类型

                    storageBase.PrivType = output.PrivType;
                    storageBase.Class2Type = output.Class2Type;

                    storageBase.TargetDept = output.TargetDept;     //领药部门

                    //将部门库存信息保存到出库记录中
                    output.GroupNO = storageBase.GroupNO;           //批次
                    output.BatchNO = storageBase.BatchNO;           //批号
                    output.Company = storageBase.Company;           //供货公司
                    output.PlaceNO = storageBase.PlaceNO;           //货位号
                    output.Producer = storageBase.Producer;         //生产厂家
                    output.ValidTime = storageBase.ValidTime;       //有效期

                    #endregion
                }

                #region 变量赋值处理

                //当库存数量大于出库数量时（或者库存中无数据，只要当允许为负库存时才能出现此中情况），则将此批次库存记录出库，出库数量等于待出库数量
                if ((storageBase.StoreQty - storageBase.ArkQty) >= leftOutNum || al.Count == 0)
                {
                    //出库数量等于待出库数量（待出库数量会随着循环的增加而逐渐减少）
                    output.Quantity = leftOutNum;
                }
                else
                {
                    //如果库存数量小于出库数量，则将此批次库存数量全部出库。（程序会继续查找下一个批次的库存信息）
                    output.Quantity = storageBase.StoreQty - storageBase.ArkQty;
                }
                //药柜管理数量
                if (!isChestOut)            //非药柜出库 修改药柜管理库存汇总数量
                {
                    storageBase.ArkQty = output.Quantity;
                }
                else                        //药柜出库  药柜间正常调拨
                {
                    storageBase.ArkQty = 0;
                }

                //库存数量减少，减少的量等于出库数量（此处的storageBase.Quantity用来保存库存变化量）
                storageBase.Quantity = -output.Quantity;

                //剩余待摆药数量＝本次待摆药数量－本次摆药数量。如果剩余待摆药数量大于0，循环将继续进行。
                leftOutNum = leftOutNum - output.Quantity;

                //按批次出库时，如果同一样物品产生多条出库记录，单内序号增加
                output.SerialNO = i + 1;

                //对于一条入库申请，如果出库记录多于一条，只有第一条出库记录中保存“申请数量",其余的出库记录中的申请数量为0，保证汇总数量正确
                if (i > 0)
                {
                    output.Operation.ApplyQty = 0;
                }

                #endregion

                //药房向药柜出库时 置出库记录标记 
                if (isChestIn && !isChestOut)
                {
                    output.IsArkManager = true;
                }
                else
                {
                    output.IsArkManager = false;
                }
                //插入出库记录

                output.Item.PriceCollection = storageBase.Item.PriceCollection;

                //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}  出/退库记录发生时间
                output.OutDate = sysTime;

                if (this.InsertOutput(output) != 1)
                {
                    this.Err = "插入出库记录时出错！" + this.Err;
                    return -1;
                }
                //库存更新 对非药房向药柜出库情况下 更新库存
                if (!output.IsArkManager)
                {
                    //修改库存数据（通过库存明细表的触发器实现台帐表，库存汇总表处理）
                    //先执行更新数量操作，如果数据库中没有记录则执行插入操作
                    if (this.SetStorage(storageBase) != 1)
                    {
                        this.Err = "更新库存表时出错！" + this.Err;
                        return -1;
                    }
                }
                //更新药房内药柜库存汇总量 ArkQty数量
                if (output.IsArkManager || isUpdateArkQty)
                {
                    if (!output.IsArkManager)
                    {
                        storageBase.ArkQty = -storageBase.ArkQty;
                    }
                    //更新药柜 ArkQty数量  库存数量不变
                    if (this.SetArkStorage(storageBase) != 1)
                    {
                        this.Err = "更新库存表时出错！" + this.Err;
                        return -1;
                    }
                }
            }

            //恢复output实体中传入时的数值
            output.Quantity = totOutNum;

            return 1;
        }

        /// <summary>
        /// 实现出库库退库
        /// </summary>
        /// <说明>
        ///     药柜管理退库流程处理
        ///     1、如果 入出均非药柜 则按原流程处理
        ///     2、如果药柜退库 那么目标接受科室一定为药房 直接按原流程处理
        ///     3、如果药房退库 目标接受科室为药柜 则 生成药房负出库记录 药柜出库记录标志为True
        ///         更新药房药柜库存汇总量  生成药柜负入库记录 处理药柜库存
        /// </说明>
        /// <param name="output">待出库实体</param>
        /// <param name="outputID">出库流水号</param>
        /// <param name="isManagerInput">是否处理入库记录</param>
        /// <returns>0 没有删除 1 成功 －1 失败</returns>
        public int ArkOutputReturn(Neusoft.HISFC.Models.Pharmacy.Output output, string outputID, bool isManagerInput)
        {
            #region 根据出库退库记录中的出库单流水号，取出库数据列表

            ArrayList al = this.QueryOutputList(outputID);
            if (al == null) return -1;

            //如果al超出索引，则提示出错
            if (al.Count == 0)
            {
                this.Err = "没有找到退库操作所对应的出库记录！";
                return -1;
            }
            //判断是否存在药柜出库记录
            Neusoft.HISFC.Models.Pharmacy.Output outputTemp = al[0] as Neusoft.HISFC.Models.Pharmacy.Output;
            //存在药柜出库记录 先进行药柜退库
            if (outputTemp.ArkOutNO != null && outputTemp.ArkOutNO != "")
            {
                #region 药柜记录退库

                ArrayList alTemp = this.QueryOutputList(outputTemp.ArkOutNO);
                if (alTemp == null)
                {
                    return -1;
                }
                if (alTemp.Count == 0)
                {
                    this.Err = "没有找到退库操作所对应的出库记录！";
                    return -1;
                }

                Neusoft.HISFC.Models.Pharmacy.Output arkOut = alTemp[0] as Neusoft.HISFC.Models.Pharmacy.Output;

                arkOut.Quantity = output.Quantity;
                arkOut.SystemType = output.SystemType;
                arkOut.PrivType = output.PrivType;
                arkOut.Operation = output.Operation;

                if (this.ArkOutputReturn(arkOut, outputTemp.ArkOutNO, false) != 1)
                {
                    this.Err = "对于药柜记录退库发生错误" + this.Err;
                    return -1;
                }

                output.ArkOutNO = arkOut.ID;

                #endregion
            }

            #endregion

            //当前时间
            DateTime sysTime = this.GetDateTimeFromSysDateTime();

            //取出库单流水号保存在output中，可以被外面调用
            output.ID = this.GetNewOutputNO();
            if (output.ID == null)
            {
                return -1;
            }

            //临时存储出库总数量和待出库数量
            Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase = null;
            decimal totOutNum = output.Quantity;
            decimal leftOutNum = output.Quantity;

            Neusoft.HISFC.Models.Pharmacy.Input inputInfo;
            Neusoft.HISFC.Models.Pharmacy.Input inputTemp;

            Neusoft.HISFC.Models.Pharmacy.Output info = null;
            for (int i = 0; leftOutNum < 0; i++)
            {
                #region 退库有效性判断

                if (al.Count == i)
                {
                    this.Err = "该条出库记录的出库数量不足以进行此次退库 请重新选择退库记录";
                    return -1;
                }
                //取出库记录中的数据  
                info = al[i] as Output;
                //出库数量＝退库数量  此种记录已做过退库处理 继续查找
                if (info.Quantity == info.Operation.ReturnQty)
                {
                    continue;
                }

                #endregion

                #region 根据原出库记录 生成退库记录

                //将出库时的信息保存到退库记录中
                output.GroupNO = info.GroupNO;					//批次
                output.BatchNO = info.BatchNO;					//批号
                output.Company = info.Company;					//供货公司
                output.PlaceNO = info.PlaceNO;					//货位号
                output.Producer = info.Producer;					//生产厂家
                output.ValidTime = info.ValidTime;					//有效期
                output.Item.PriceCollection.RetailPrice = info.Item.PriceCollection.RetailPrice;	//零售价 利用原出库价格退库

                //当某一批次的可退数量（已出库数量－已退库数量）大于待退库数量时，则将此批次出库记录退库，退库数量等于待退库数量。(本次循环结束不再找下一个批次)
                if (info.Quantity - info.Operation.ReturnQty >= Math.Abs(leftOutNum))
                {
                    //退库数量等于待退库数量（待退库数量会随着循环的增加而逐渐减少）
                    //退库数量是负数
                    output.Quantity = leftOutNum;
                }
                else
                {
                    //如果可退数量（已出库数量－已退库数量）小于于待退库数量，则将此批次出库记录中的可退库数量全部退库。（程序会继续查找下一个批次的库存信息）
                    //退库数量是负数
                    output.Quantity = -(info.Quantity - info.Operation.ReturnQty);
                }

                //剩余待退库数量（负数）＝本次待退药数量（负数）－本次退药数量（负数）。如果剩余待退药数量小于0，则循环将继续进行。
                leftOutNum = leftOutNum - output.Quantity;

                //单内序号增加
                output.SerialNO = i + 1;

                //对于一条入库申请，如果出库记录多于一条，只有第一条出库记录中保存“申请数量",其余的出库记录中的申请数量为0，保证汇总数量正确
                if (i > 0) output.Operation.ApplyQty = 0;

                //插入出库记录
                output.State = "2";					                //不需核准操作

                //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}  出/退库记录发生时间
                output.OutDate = sysTime;

                if (this.InsertOutput(output) != 1)
                {
                    this.Err = "插入出库记录时出错！" + this.Err;
                    return -1;
                }

                //更新出库记录中的"已退库数量"字段（加操作）
                output.Quantity = -output.Quantity;
                if (this.UpdateOutputReturnNum(outputID, info.SerialNO, output.Quantity) != 1)
                {
                    this.Err = "更新出库记录中的已退库数量时出错！" + this.Err;
                    return -1;
                }

                #endregion

                #region 对非药房向药柜的出库记录 处理本科室库存处理

                //将出库数据赋值给库存数据，退库数量output.Quantity即是库存变化量（库存更新数量时是减操作）storageBase.Quantity（负数）
                storageBase = output.Clone() as StorageBase;

                storageBase.Class2Type = output.Class2Type;
                storageBase.PrivType = output.PrivType;

                if (!output.IsArkManager)
                {
                    //修改库存数据（通过库存明细表的触发器实现台帐表，库存汇总表处理）
                    //库存变化的数量（库存修改执行的加操作）跟出库的数量相反。
                    //先执行更新数量操作，如果数据库中没有记录则执行插入操作
                    if (this.SetStorage(storageBase) != 1)
                    {
                        this.Err = "更新库存表时出错！" + this.Err;
                        return -1;
                    }
                }

                #endregion

                #region 对于药柜退库 更新相应药房记录的药柜汇总库存量
                //药房向药柜出库记录(Output.IsArkManager 为True)
                //药房发药 存在对应的药柜出库记录  此两种情况下需更新药柜库存汇总量
                if (output.IsArkManager || (output.ArkOutNO != null && output.ArkOutNO != ""))
                {
                    if (output.IsArkManager)        //药房向药柜的出库记录 退库时 扣减药柜量
                    {
                        storageBase.ArkQty = -storageBase.Quantity;
                    }
                    else                           //正常退库 增加药柜量
                    {
                        storageBase.ArkQty = storageBase.Quantity;
                    }

                    if (this.SetArkStorage(storageBase) != 1)
                    {
                        this.Err = "更新库存表时出错！" + this.Err;
                        return -1;
                    }
                }

                #endregion

                #region 如果出库的药品零售价跟库存中的药品零售价不同，则记录调价盈亏

                this.OutputAdjust(info, output, sysTime, i);

                #endregion

                #region 处理对应领用部门的入库数据（"特殊出库"不处理领用单位的入库，台帐，库存）

                //插入领用部门入库记录
                //判断是否需要对领用部门进行库存管理。如果管理库存，则进行下面处理：
                if (isManagerInput)
                {
                    inputInfo = this.GetInputInfoByID(info.InBillNO);
                    if (inputInfo == null)
                    {
                        return -1;
                    }
                    inputTemp = inputInfo.Clone();
                    inputTemp.ID = "";							//流水号
                    inputTemp.Quantity = -output.Quantity;		//数量
                    inputTemp.GroupNO = output.GroupNO;			//批次
                    inputTemp.BatchNO = output.BatchNO;			//批号
                    inputTemp.Company = output.StockDept;		//供货公司
                    inputTemp.PlaceNO = output.PlaceNO;		    //货位号
                    inputTemp.Producer = output.Producer;		//生产厂家
                    inputTemp.ValidTime = output.ValidTime;		//有效期
                    inputTemp.Operation.ReturnQty = 0;

                    inputTemp.OutBillNO = output.ID;          //出库单据号

                    inputTemp.StoreQty = inputTemp.StoreQty + inputTemp.Quantity;

                    //插入入库负记录
                    if (this.Input(inputTemp, "1", "1") == -1)
                    {
                        this.Err = this.Err + "插入入库负记录出错！";
                        return -1;
                    }
                    //更新原入库记录退库数量
                    if (this.UpdateInputReturnNum(inputInfo.ID, inputInfo.SerialNO, -inputTemp.Quantity) != 1)
                    {
                        this.Err = this.Err + "更新入库记录退库数量出错！";
                        return -1;
                    }
                }

                #endregion
            }

            //恢复output实体中传入时的数值
            output.Quantity = totOutNum;
            return 1;
        }

        #endregion

        #endregion

        #region 外部接口

        /// <summary>
        /// 门诊退库
        /// 如果退库申请中，指定确定的批次，则将此批次记录退掉。
        /// 否则，在与出库申请对应的出库记录中按批次小先退的原则，做退库处理。
        /// </summary>
        /// <param name="feeInfo">收费费用实体</param>
        /// <returns>成功返回1 失败返回-1 无记录返回0</returns>
        public int OutputReturn(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeInfo, string operCode, DateTime operDate)
        {

            #region 等待门诊费用加字段 存储出库单据号
            #endregion

            DateTime sysTime = this.GetDateTimeFromSysDateTime();
            Neusoft.HISFC.Models.Pharmacy.Output output = new Output();

            #region Output实体赋值

            output.ID = this.GetNewOutputNO();
            if (output.ID == null) return -1;

            Neusoft.HISFC.Models.Pharmacy.Item item = this.GetItem(feeInfo.Item.ID);
            if (item == null)
            {
                this.Err = "获取药品基本信息失败" + this.Err;
                return -1;
            }

            output.Item.MinUnit = item.MinUnit;					                        //最小单位 ＝ 记价单位
            output.Item.PackUnit = item.PackUnit;
            output.Item.PriceCollection.RetailPrice = feeInfo.Item.Price;				//零售价
            output.Item.ID = feeInfo.Item.ID;							                    //药品编码
            output.Item.Name = feeInfo.Item.Name;						                    //药品名称
            output.Item.Type = item.Type;							                    //药品类别
            output.Item.Quality = ((Neusoft.HISFC.Models.Pharmacy.Item)feeInfo.Item).Quality;			//药品性质

            output.Item.Specs = feeInfo.Item.Specs;					                    //规格
            output.Item.PackQty = feeInfo.Item.PackQty;					                //包装数量
            output.Item.DoseUnit = feeInfo.Order.DoseUnit;				                //每次剂量单位
            output.Item.DosageForm = ((Neusoft.HISFC.Models.Pharmacy.Item)feeInfo.Item).DosageForm;				//剂型

            output.TargetDept = ((Neusoft.HISFC.Models.Registration.Register)feeInfo.Patient).DoctorInfo.Templet.Dept;				//申请科室＝开方科室   出库申请科室
            output.StockDept = feeInfo.ExecOper.Dept;						            //发药药房＝执行科室   出库科室
            output.SystemType = "M2";								                    //申请类型＝"M2" 门诊退药 
            output.PrivType = "M2";                                                     //用户自定义类型
            output.Operation.ApplyOper.OperTime = sysTime;							    //申请时间＝操作时间                    
            output.RecipeNO = feeInfo.RecipeNO;					                        //处方号
            output.SequenceNO = feeInfo.SequenceNO;						                //处方内流水号

            output.ShowState = "0";								                        //显示的单位标记（0最小单位，1包装单位）
            //此处赋值为乘以Days后的数量 药品部分申请表里边是剂数及每次剂量分开存储的
            output.Quantity = feeInfo.Item.Qty;						                    //出库数量
            output.GetPerson = feeInfo.Patient.ID;					                            //取药患者门诊流水号

            output.DrugedBillNO = "0";							                        //摆药单号 必须传值 

            output.SpecialFlag = "0";								                    //特殊标记。1是，0否
            output.Operation.ApplyOper.ID = operCode;						            //出库申请人编码
            output.Operation.ApplyOper.OperTime = operDate;						        //出库申请日期
            output.Operation.ApplyQty = output.Quantity;						        //申请数量
            output.Operation.ExamQty = output.Quantity;					                //审核数量
            output.Operation.ExamOper.ID = operCode;							        //审批人 ＝打印人
            output.Operation.ExamOper.OperTime = operDate;							    //审批日期＝打印日期
            output.Operation.ApproveOper.ID = operCode;						            //出库核准
            output.State = "2";

            #endregion

            //临时存储出库总数量和待出库数量
            Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase;

            output.Operation.ExamQty = -output.Quantity;
            decimal totOutNum = -output.Quantity;
            decimal leftOutNum = -output.Quantity;

            //根据出库退库记录中的出库单流水号，取出库数据列表。
            ArrayList al = new ArrayList();
            al = this.QueryOutputList(feeInfo.RecipeNO, feeInfo.SequenceNO, "M1");
            if (al == null) return -1;

            //如果al超出索引，用于控制重复退费
            if (al.Count == 0)
            {
                this.Err = "没有找到退库操作所对应的出库记录！";
                return 0;
            }

            Neusoft.HISFC.Models.Pharmacy.Output info;
            //如果退库申请中，指定确定的批次，则将此批次记录退掉。
            //否则，在与出库申请对应的出库记录中按批次小先退的原则，做退库处理。

            for (int i = 0; leftOutNum < 0; i++)
            {
                #region 根据出库记录 生成 退库记录

                if (al.Count <= i)
                {
                    this.Err = "药品" + feeInfo.Item.Name + "本次申请数量 大于 已出库数量";
                    return -1;
                }

                //取出库记录中的数据  
                info = al[i] as Output;

                //将出库时的信息保存到退库记录中
                output.GroupNO = info.GroupNO;					//批次
                output.BatchNO = info.BatchNO;					//批号
                output.Company = info.Company;					//供货公司
                output.PlaceNO = info.PlaceNO;					//货位号
                output.Producer = info.Producer;					//生产厂家
                output.ValidTime = info.ValidTime;					//有效期
                output.Item.PriceCollection.RetailPrice = info.Item.PriceCollection.RetailPrice;	//零售价 利用原出库价格退库
                //{92FE9833-A574-496b-93D9-A4BEDF5AD7CD}  保证购入价的赋值
                output.Item.PriceCollection = info.Item.PriceCollection;

                //当某一批次的可退数量（已出库数量－已退库数量）大于待退库数量时，则将此批次出库记录退库，退库数量等于待退库数量。(本次循环结束不再找下一个批次)
                if (info.Quantity - info.Operation.ReturnQty >= Math.Abs(leftOutNum))
                {
                    //退库数量等于待退库数量（待退库数量会随着循环的增加而逐渐减少）
                    //退库数量是负数
                    output.Quantity = leftOutNum;
                }
                else
                {
                    //如果可退数量（已出库数量－已退库数量）小于于待退库数量，则将此批次出库记录中的可退库数量全部退库。（程序会继续查找下一个批次的库存信息）
                    //退库数量是负数
                    output.Quantity = -(info.Quantity - info.Operation.ReturnQty);
                }

                //剩余待退库数量（负数）＝本次待退药数量（负数）－本次退药数量（负数）。如果剩余待退药数量小于0，则循环将继续进行。
                leftOutNum = leftOutNum - output.Quantity;

                //单内序号增加
                output.SerialNO = i + 1;

                //对于一条入库申请，如果出库记录多于一条，只有第一条出库记录中保存“申请数量",其余的出库记录中的申请数量为0，保证汇总数量正确
                if (i > 0) output.Operation.ApplyQty = 0;

                //插入出库记录
                output.State = "2";					//不需核准操作

                #endregion

                #region 退库记录保持 库存更新

                //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}  出/退库记录发生时间
                output.OutDate = sysTime;

                if (this.InsertOutput(output) != 1)
                {
                    this.Err = "插入出库记录时出错！" + this.Err;
                    return -1;
                }

                //更新出库记录中的"已退库数量"字段（加操作）
                output.Quantity = -output.Quantity;
                if (this.UpdateOutputReturnNum(info.ID, info.SerialNO, output.Quantity) != 1)
                {
                    this.Err = "更新出库记录中的已退库数量时出错！" + this.Err;
                    return -1;
                }

                //将出库数据赋值给库存数据，退库数量output.Quantity即是库存变化量（库存更新数量时是减操作）storageBase.Quantity（负数）
                storageBase = output.Clone() as StorageBase;

                storageBase.Class2Type = output.Class2Type;
                storageBase.PrivType = output.PrivType;

                //storageBase.PrivType = "0320" + output.PrivType;

                //修改库存数据（通过库存明细表的触发器实现台帐表，库存汇总表处理）
                //库存变化的数量（库存修改执行的加操作）跟出库的数量相反。
                //storageBase.Quantity = -output.Quantity; output中已经转为负数
                //先执行更新数量操作，如果数据库中没有记录则执行插入操作
                if (this.SetStorage(storageBase) != 1)
                {
                    this.Err = "更新库存表时出错！" + this.Err;
                    return -1;
                }

                #endregion

                #region 如果出库的药品零售价跟库存中的药品零售价不同，则记录调价盈亏

                #region 屏蔽以下处理 通过函数调用实现

                //bool isDoAdjust = false;
                //string adjustPriceID = "";
                //decimal dNowPrice = 0;
                //dNowPrice = output.Item.PriceCollection.RetailPrice;

                //if (info.Item.PriceCollection.RetailPrice != dNowPrice)
                //{
                //    //调价处理
                //    //
                //    if (!isDoAdjust)
                //    {
                //        adjustPriceID = this.GetSequence("Pharmacy.Item.GetNewAdjustPriceID");
                //        if (adjustPriceID == null)
                //        {
                //            this.Err = "出库退库药品已发生调价 插入调价盈亏记录过程中获取调价单号出错！";
                //            return -1;
                //        }
                //    }
                //    Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice = new AdjustPrice();
                //    adjustPrice.ID = adjustPriceID;								//调价单号
                //    adjustPrice.SerialNO = i;									//调价单内序号
                //    adjustPrice.Item = info.Item;
                //    adjustPrice.StockDept.ID = info.StockDept.ID;				//调价科室 
                //    adjustPrice.State = "1";									//调价状态 1 已调价
                //    adjustPrice.StoreQty = output.Quantity;
                //    adjustPrice.Operation.Oper.ID = this.Operator.ID;
                //    adjustPrice.Operation.Oper.Name = this.Operator.Name;
                //    adjustPrice.Operation.Oper.OperTime = sysTime;
                //    adjustPrice.InureTime = sysTime;
                //    adjustPrice.AfterRetailPrice = dNowPrice;//调价后零售价
                //    if (dNowPrice - info.Item.PriceCollection.RetailPrice > 0)
                //        adjustPrice.ProfitFlag = "1";							//调盈
                //    else
                //        adjustPrice.ProfitFlag = "0";							//调亏
                //    adjustPrice.Memo = "出库退库补调价盈亏";
                //    if (!isDoAdjust)			//每次只插入一次调价汇总表
                //    {
                //        if (this.InsertAdjustPriceInfo(adjustPrice) == -1)
                //        {
                //            return -1;
                //        }
                //        isDoAdjust = true;
                //    }
                //    if (this.InsertAdjustPriceDetail(adjustPrice) == -1)
                //    {
                //        return -1;
                //    }
                //}

                #endregion

                this.OutputAdjust(info, output, sysTime, i);

                #endregion

            }
            return 1;
        }

        /// <summary>
        /// 住院退库
        /// 如果退库申请中，指定确定的批次，则将此批次记录退掉。
        /// 否则，在与出库申请对应的出库记录中按批次小先退的原则，做退库处理。
        /// </summary>
        /// <param name="feeInfo">收费费用实体</param>
        /// <returns>成功返回1 失败返回-1 无记录返回0</returns>
        public int OutputReturn(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeInfo, string operCode, DateTime operDate)
        {
            DateTime sysTime = this.GetDateTimeFromSysDateTime();
            Neusoft.HISFC.Models.Pharmacy.Output output = new Output();

            #region Output实体赋值

            output.ID = this.GetNewOutputNO();
            if (output.ID == null) return -1;

            Neusoft.HISFC.Models.Pharmacy.Item item = this.GetItem(feeInfo.Item.ID);
            if (item == null)
            {
                this.Err = "获取药品基本信息失败" + this.Err;
                return -1;
            }

            output.Item.MinUnit = item.MinUnit;					                        //最小单位 ＝ 记价单位
            output.Item.PackUnit = item.PackUnit;
            output.Item.PriceCollection.RetailPrice = feeInfo.Item.Price;				//零售价
            output.Item.ID = feeInfo.Item.ID;							                //药品编码
            output.Item.Name = feeInfo.Item.Name;						                //药品名称
            output.Item.Type = item.Type;							                    //药品类别
            output.Item.Quality = ((Neusoft.HISFC.Models.Pharmacy.Item)feeInfo.Item).Quality;			//药品性质

            output.Item.Specs = feeInfo.Item.Specs;					                    //规格
            output.Item.PackQty = feeInfo.Item.PackQty;					                //包装数量
            output.Item.DoseUnit = feeInfo.Order.DoseUnit;				                //每次剂量单位
            output.Item.DosageForm = ((Neusoft.HISFC.Models.Pharmacy.Item)feeInfo.Item).DosageForm;				//剂型

            output.TargetDept = ((Neusoft.HISFC.Models.RADT.PatientInfo)feeInfo.Patient).PVisit.PatientLocation.Dept;				                //申请科室＝开方科室   出库申请科室
            output.StockDept = feeInfo.StockOper.Dept;						            //发药药房＝执行科室   出库科室
            output.SystemType = "Z2";								                    //申请类型＝"M2" 门诊退药 
            output.PrivType = "Z2";                                                     //用户自定义类型
            output.Operation.ApplyOper.OperTime = sysTime;							    //申请时间＝操作时间                    
            output.RecipeNO = feeInfo.RecipeNO;					                        //处方号
            output.SequenceNO = feeInfo.SequenceNO;						                //处方内流水号

            output.ShowState = "0";								                        //显示的单位标记（0最小单位，1包装单位）
            //此处赋值为乘以Days后的数量 药品部分申请表里边是剂数及每次剂量分开存储的
            output.Quantity = feeInfo.Item.Qty;						                    //出库数量
            output.GetPerson = feeInfo.Patient.ID;					                            //取药患者门诊流水号

            output.DrugedBillNO = "0";							                        //摆药单号 必须传值 

            output.SpecialFlag = "0";								                    //特殊标记。1是，0否
            output.Operation.ApplyOper.ID = operCode;						            //出库申请人编码
            output.Operation.ApplyOper.OperTime = operDate;						        //出库申请日期
            output.Operation.ApplyQty = output.Quantity;						        //申请数量
            output.Operation.ExamQty = output.Quantity;					                //审核数量
            output.Operation.ExamOper.ID = operCode;							        //审批人 ＝打印人
            output.Operation.ExamOper.OperTime = operDate;							    //审批日期＝打印日期
            output.Operation.ApproveOper.ID = operCode;						            //出库核准
            output.State = "2";

            #endregion

            //临时存储出库总数量和待出库数量
            Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase;

            output.Operation.ExamQty = -output.Quantity;
            decimal totOutNum = -output.Quantity;
            decimal leftOutNum = -output.Quantity;

            //根据出库退库记录中的出库单流水号，取出库数据列表。
            ArrayList al = new ArrayList();
            al = this.QueryOutputList(feeInfo.RecipeNO, feeInfo.SequenceNO, "Z1");
            if (al == null) return -1;

            //如果al超出索引，用于控制重复退费
            if (al.Count == 0)
            {
                this.Err = "没有找到退库操作所对应的出库记录！";
                return 0;
            }

            Neusoft.HISFC.Models.Pharmacy.Output info;
            //如果退库申请中，指定确定的批次，则将此批次记录退掉。
            //否则，在与出库申请对应的出库记录中按批次小先退的原则，做退库处理。

            for (int i = 0; leftOutNum < 0; i++)
            {
                #region 根据出库记录 生成 退库记录

                if (al.Count <= i)
                {
                    this.Err = "药品" + feeInfo.Item.Name + "本次申请数量 大于 已出库数量";
                    return -1;
                }

                //取出库记录中的数据  
                info = al[i] as Output;

                //将出库时的信息保存到退库记录中
                output.GroupNO = info.GroupNO;					//批次
                output.BatchNO = info.BatchNO;					//批号
                output.Company = info.Company;					//供货公司
                output.PlaceNO = info.PlaceNO;					//货位号
                output.Producer = info.Producer;					//生产厂家
                output.ValidTime = info.ValidTime;					//有效期
                output.Item.PriceCollection.RetailPrice = info.Item.PriceCollection.RetailPrice;	//零售价 利用原出库价格退库
                //{92FE9833-A574-496b-93D9-A4BEDF5AD7CD}  保证购入价的赋值
                output.Item.PriceCollection = info.Item.PriceCollection;

                //当某一批次的可退数量（已出库数量－已退库数量）大于待退库数量时，则将此批次出库记录退库，退库数量等于待退库数量。(本次循环结束不再找下一个批次)
                if (info.Quantity - info.Operation.ReturnQty >= Math.Abs(leftOutNum))
                {
                    //退库数量等于待退库数量（待退库数量会随着循环的增加而逐渐减少）
                    //退库数量是负数
                    output.Quantity = leftOutNum;
                }
                else
                {
                    //如果可退数量（已出库数量－已退库数量）小于于待退库数量，则将此批次出库记录中的可退库数量全部退库。（程序会继续查找下一个批次的库存信息）
                    //退库数量是负数
                    output.Quantity = -(info.Quantity - info.Operation.ReturnQty);
                }

                //剩余待退库数量（负数）＝本次待退药数量（负数）－本次退药数量（负数）。如果剩余待退药数量小于0，则循环将继续进行。
                leftOutNum = leftOutNum - output.Quantity;

                //单内序号增加
                output.SerialNO = i + 1;

                //对于一条入库申请，如果出库记录多于一条，只有第一条出库记录中保存“申请数量",其余的出库记录中的申请数量为0，保证汇总数量正确
                if (i > 0) output.Operation.ApplyQty = 0;

                //插入出库记录
                output.State = "2";					//不需核准操作

                #endregion

                #region 退库记录保持 库存更新

                //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}  出/退库记录发生时间
                output.OutDate = sysTime;

                if (this.InsertOutput(output) != 1)
                {
                    this.Err = "插入出库记录时出错！" + this.Err;
                    return -1;
                }

                //更新出库记录中的"已退库数量"字段（加操作）
                output.Quantity = -output.Quantity;
                if (this.UpdateOutputReturnNum(info.ID, info.SerialNO, output.Quantity) != 1)
                {
                    this.Err = "更新出库记录中的已退库数量时出错！" + this.Err;
                    return -1;
                }

                //将出库数据赋值给库存数据，退库数量output.Quantity即是库存变化量（库存更新数量时是减操作）storageBase.Quantity（负数）
                storageBase = output.Clone() as StorageBase;

                storageBase.Class2Type = output.Class2Type;
                storageBase.PrivType = output.PrivType;

                //storageBase.PrivType = "0320" + output.PrivType;

                //修改库存数据（通过库存明细表的触发器实现台帐表，库存汇总表处理）
                //库存变化的数量（库存修改执行的加操作）跟出库的数量相反。
                //storageBase.Quantity = -output.Quantity; output中已经转为负数
                //先执行更新数量操作，如果数据库中没有记录则执行插入操作
                if (this.SetStorage(storageBase) != 1)
                {
                    this.Err = "更新库存表时出错！" + this.Err;
                    return -1;
                }

                #endregion

                #region 如果出库的药品零售价跟库存中的药品零售价不同，则记录调价盈亏

                this.OutputAdjust(info, output, sysTime, i);

                #endregion

            }
            return 1;
        }

        /// <summary>
        /// 根据药品、退库数量、源/目标科室直接退库
        /// {1E95F7E5-7C6F-483a-9B7E-EA1DBDD9540F}
        /// 该部分需退库数据由库存列表选择产生，所以源科室、目标科室肯定都管理库存，不需进行是否管理库存的判断
        /// </summary>
        /// <param name="backDrugInformation">退库药品 需包含单据号、当前库存数</param>
        /// <param name="backDrugQty">退库药品数量</param>
        /// <param name="sourceDept">源科室(退库科室)</param>
        /// <param name="isSourceArk">源科室是否为药柜方式管理</param>
        /// <param name="targetDept">目标科室(退库目的科室)</param>
        /// <param name="isTargetArk">目标科室是否为药柜方式管理</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int OutputReturnForSingleDrug(Output backDrugInformation, decimal backDrugQty, Neusoft.FrameWork.Models.NeuObject sourceDept, bool isSourceArk, Neusoft.FrameWork.Models.NeuObject targetDept, bool isTargetArk)
        {
            #region 获取源科室退库药品的库存信息 按照批次流水号 由小到大

            ArrayList alSourceStoreList = this.QueryStorageList(sourceDept.ID, backDrugInformation.Item.ID);
            if (alSourceStoreList == null)
            {
                return -1;
            }
            if (alSourceStoreList.Count == 0)
            {
                this.Err = backDrugInformation.Item.Name + "  在" + sourceDept.Name + "已无库存，不能进行退库操作";
                return -1;
            }

            #endregion

            #region 根据退库数量进行退库处理  退库批次由小到大退

            DateTime sysTime = this.GetDateTimeFromSysDateTime();

            decimal totBackQty = backDrugQty;
            Neusoft.HISFC.Models.Pharmacy.Output output = backDrugInformation.Clone();

            foreach (Neusoft.HISFC.Models.Pharmacy.Storage store in alSourceStoreList)
            {
                if (totBackQty <= 0)
                {
                    break;
                }

                decimal batchBackQty = totBackQty;

                #region 计算本循环处理的退库数量

                if (store.StoreQty >= totBackQty)       //库存数量大于退库数量
                {
                    batchBackQty = totBackQty;
                    totBackQty = 0;
                }
                else                                   //库存数量小于退库数量
                {
                    batchBackQty = store.StoreQty;
                    totBackQty = totBackQty - store.StoreQty;
                }

                #endregion

                Neusoft.HISFC.Models.Pharmacy.Storage alterStore = store.Clone();

                #region 形成目标科室 退库记录(出库负记录)

                #region 出库实体信息赋值

                output.StockDept = targetDept;          //库存管理科室 即本次出库记录对应的库存变化科室
                output.TargetDept = sourceDept;         //出库目标科室 对应退库记录的目标科室 

                output.Quantity = -batchBackQty;         //出库数量

                //将部门库存信息保存到出库记录中
                output.GroupNO = alterStore.GroupNO;           //批次
                output.BatchNO = alterStore.BatchNO;           //批号
                output.Company = alterStore.Company;           //供货公司
                output.PlaceNO = alterStore.PlaceNO;           //货位号
                output.Producer = alterStore.Producer;         //生产厂家
                output.ValidTime = alterStore.ValidTime;       //有效期

                output.Operation.ApplyOper.ID = this.Operator.ID;
                output.Operation.ApplyOper.OperTime = sysTime;
                output.Operation.ApplyQty = output.Quantity;

                output.Operation.ApproveOper = output.Operation.ApplyOper;
                output.Operation.ApproveQty = output.Quantity;

                output.Operation.ExamOper = output.Operation.ApplyOper;
                output.Operation.ExamQty = output.Quantity;
                output.DrugedBillNO = "1";
                output.State = "2";

                #endregion

                //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}  出/退库记录发生时间
                output.OutDate = sysTime;

                if (this.InsertOutput(output) == -1)
                {
                    return -1;
                }

                #endregion

                if (!(!isTargetArk && isSourceArk))        //如源科室为药柜 且 目标科室不为药柜 则不处理目标科室库存
                {
                    #region 增加目标科室库存

                    alterStore.StockDept = targetDept;          //库存科室
                    alterStore.Quantity = batchBackQty;         //库存变化数量
                    alterStore.TargetDept = sourceDept;         //目标科室
                    alterStore.Class2Type = output.Class2Type;
                    alterStore.PrivType = output.PrivType;
                    alterStore.ID = output.ID;
                    alterStore.SerialNO = output.SerialNO;
                    if (this.SetStorage(alterStore) == -1)
                    {
                        return -1;
                    }

                    #endregion
                }

                #region 形成源科室 入库负记录

                #region 入库实体信息赋值

                Input inputTemp = new Input();

                inputTemp.StockDept = sourceDept;
                inputTemp.TargetDept = targetDept;
                inputTemp.Item = output.Item;

                inputTemp.Quantity = -batchBackQty;		//数量
                inputTemp.GroupNO = output.GroupNO;			//批次
                inputTemp.BatchNO = output.BatchNO;			//批号
                inputTemp.Company = output.StockDept;		//供货公司
                inputTemp.PlaceNO = output.PlaceNO;		    //货位号
                inputTemp.Producer = output.Producer;		//生产厂家
                inputTemp.ValidTime = output.ValidTime;		//有效期
                inputTemp.Operation.ReturnQty = 0;

                inputTemp.InListNO = output.OutListNO;
                inputTemp.OutBillNO = output.ID;          //出库单据号

                inputTemp.Operation = output.Operation;
                inputTemp.Operation.ApplyQty = inputTemp.Quantity;
                inputTemp.Operation.ExamQty = inputTemp.Quantity;
                inputTemp.Operation.ApproveQty = inputTemp.Quantity;
                inputTemp.State = "2";
                inputTemp.OutListNO = output.OutListNO;
                inputTemp.OutBillNO = output.ID;
                inputTemp.OutSerialNO = output.SerialNO;
                inputTemp.SystemType = Neusoft.HISFC.Models.Base.EnumIMAInTypeService.GetNameFromEnum(EnumIMAInType.ApproveInput);
                inputTemp.PrivType = "01";

                #endregion

                if (this.InsertInput(inputTemp) == -1)
                {
                    return -1;
                }

                #endregion

                if (!(isTargetArk && !isSourceArk))         //如源科室不为药柜 且 目标科室为药柜
                {
                    #region 减少源科室库存

                    alterStore.StockDept = sourceDept;          //库存科室
                    alterStore.Quantity = -batchBackQty;         //库存变化数量
                    alterStore.TargetDept = targetDept;         //目标科室
                    alterStore.Class2Type = inputTemp.Class2Type;
                    alterStore.PrivType = inputTemp.PrivType;
                    alterStore.ID = inputTemp.ID;
                    alterStore.SerialNO = inputTemp.SerialNO;
                    if (this.SetStorage(alterStore) == -1)
                    {
                        return -1;
                    }

                    #endregion
                }
            }

            #endregion

            if (totBackQty > 0)
            {
                this.Err = backDrugInformation.Item.Name + "  在" + sourceDept.Name + "库存不足，不能进行退库操作";
                return -1;
            }

            return 1;
        }

        #endregion

        #region 基础增、删、改操作

        /// <summary>
        /// 取药品基本信息列表，可能是一条或者多条药品记录
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>药品对象数组</returns>
        private ArrayList myGetOutput(string SQLString)
        {
            ArrayList al = new ArrayList();                //用于返回药品信息的数组
            Neusoft.HISFC.Models.Pharmacy.Output output; //返回数组中的出库实体

            this.ExecQuery(SQLString);
            try
            {
                while (this.Reader.Read())
                {
                    output = new Output();
                    try
                    {
                        #region 由结果集读取数据
                        output.StockDept.ID = this.Reader[0].ToString();                                  //0出库科室编码
                        output.ID = this.Reader[1].ToString();                                       //1出库单流水号
                        output.SerialNO = NConvert.ToInt32(this.Reader[2].ToString());               //2序号
                        output.GroupNO = NConvert.ToDecimal(this.Reader[3].ToString());                //3批次号
                        output.OutListNO = this.Reader[4].ToString();                              //4出库单据号
                        output.PrivType = this.Reader[5].ToString();                                 //5出库类型
                        output.SystemType = this.Reader[6].ToString();                               //6出库分类
                        output.InBillNO = this.Reader[7].ToString();                               //7入库单流水号
                        output.InSerialNO = NConvert.ToInt32(this.Reader[8].ToString());             //8入库单序号
                        output.InListNO = this.Reader[9].ToString();                               //9入库单据号
                        output.Item.ID = this.Reader[10].ToString();                                 //10药品编码
                        output.Item.Name = this.Reader[11].ToString();                               //11药品商品名
                        output.Item.Type.ID = this.Reader[12].ToString();                            //12药品类别
                        output.Item.Quality.ID = this.Reader[13].ToString();                         //13药品性质
                        output.Item.Specs = this.Reader[14].ToString();                              //14规格
                        output.Item.PackUnit = this.Reader[15].ToString();                           //15包装单位
                        output.Item.PackQty = NConvert.ToDecimal(this.Reader[16].ToString());        //16包装数
                        output.Item.MinUnit = this.Reader[17].ToString();                            //17最小单位
                        output.ShowState = this.Reader[18].ToString();                               //18显示的单位标记
                        output.BatchNO = this.Reader[19].ToString();                                 //19批号
                        output.ValidTime = NConvert.ToDateTime(this.Reader[20].ToString());          //20有效期
                        output.Producer.ID = this.Reader[21].ToString();                             //21生产厂家代码
                        output.Company.ID = this.Reader[22].ToString();                              //22供货单位代码
                        output.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[23].ToString());    //23零售价
                        output.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[24].ToString()); //24批发价
                        output.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[25].ToString());  //25购入价
                        output.Quantity = NConvert.ToDecimal(this.Reader[26].ToString());            //26出库量
                        output.RetailCost = NConvert.ToDecimal(this.Reader[27].ToString());          //27零售金额
                        output.WholeSaleCost = NConvert.ToDecimal(this.Reader[28].ToString());       //28批发金额
                        output.PurchaseCost = NConvert.ToDecimal(this.Reader[29].ToString());        //39购入金额
                        output.StoreQty = NConvert.ToDecimal(this.Reader[30].ToString());            //30出库后库存数量
                        output.StoreCost = NConvert.ToDecimal(this.Reader[31].ToString());           //31出库后库存总金额
                        output.SpecialFlag = this.Reader[32].ToString();                             //32特殊标记。1是，0否
                        output.State = this.Reader[33].ToString();                                   //33出库状态 0申请、1审批、2核准
                        output.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[34].ToString());            //34申请数量
                        output.Operation.ApplyOper.ID = this.Reader[35].ToString();                           //35申请出库人
                        output.Operation.ApplyOper.OperTime = NConvert.ToDateTime(this.Reader[36].ToString());          //36申请出库日期
                        output.Operation.ExamQty = NConvert.ToDecimal(this.Reader[37].ToString());            //37审批数量
                        output.Operation.ExamOper.ID = this.Reader[38].ToString();                            //38审批人
                        output.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[39].ToString());           //39审批日期
                        output.Operation.ApproveOper.ID = this.Reader[40].ToString();                         //40核准人
                        output.Operation.ApproveOper.OperTime = NConvert.ToDateTime(this.Reader[41].ToString());        //41核准日期
                        output.PlaceNO = this.Reader[42].ToString();                               //42货位号
                        output.Operation.ReturnQty = NConvert.ToDecimal(this.Reader[43].ToString());          //43退库数量
                        output.DrugedBillNO = this.Reader[44].ToString();                          //44摆药单号
                        output.MedNO = this.Reader[45].ToString();                                   //45制剂序号－生产序号或检验序号
                        output.TargetDept.ID = this.Reader[46].ToString();                           //46领药单位编码
                        output.RecipeNO = this.Reader[47].ToString();                                //47处方号
                        output.SequenceNO = NConvert.ToInt32(this.Reader[48].ToString());           //48处方流水号
                        output.GetPerson = this.Reader[49].ToString();                               //49领药人
                        output.Memo = this.Reader[50].ToString();                                    //50备注
                        output.Operation.Oper.ID = this.Reader[51].ToString();                                //51操作员
                        output.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[52].ToString());           //52操作日期
                        output.IsArkManager = NConvert.ToBoolean(this.Reader[53]);
                        output.ArkOutNO = this.Reader[54].ToString();

                        #endregion
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得药品基本信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }

                    al.Add(output);
                }

                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得药品基本信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return al;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获得update或者insert出库表的传入参数数组
        /// </summary>
        /// <param name="output">出库类</param>
        /// <returns>成功返回字符串数组 失败返回null</returns>
        private string[] myGetParmOutput(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            #region "接口说明"

            #endregion

            string arkNO = "0";
            if (output.ArkOutNO != null && output.ArkOutNO != "")
            {
                arkNO = output.ArkOutNO;
            }

            string[] strParm ={
								 output.StockDept.ID,                        //0出库科室编码
								 output.ID,                             //1出库单流水号
								 output.SerialNO.ToString(),            //2序号
								 output.GroupNO.ToString(),             //3批次号
								 output.OutListNO,                    //4出库单据号
								 output.PrivType,                       //5出库类型
								 output.SystemType,                     //6出库分类
								 output.InBillNO,                     //7入库单流水号
								 output.InSerialNO.ToString(),          //8入库单序号
								 output.InListNO,                     //9入库单据号
								 output.Item.ID,                        //10药品编码
								 output.Item.Name,                      //11药品商品名
								 output.Item.Type.ID,                   //12药品类别
								 output.Item.Quality.ID.ToString(),     //13药品性质
								 output.Item.Specs,                     //14规格
								 output.Item.PackUnit,                  //15包装单位
								 output.Item.PackQty.ToString(),        //16包装数
								 output.Item.MinUnit,                   //17最小单位
								 output.ShowState,                      //18显示的单位标记
								 output.ShowUnit,                       //19显示的单位
								 output.BatchNO,                        //20批号
								 output.ValidTime.ToString(),           //21有效期
								 output.Producer.ID,                    //22生产厂家代码
								 output.Company.ID,                     //23供货单位代码
								 output.Item.PriceCollection.RetailPrice.ToString(),    //24零售价
								 output.Item.PriceCollection.WholeSalePrice.ToString(), //25批发价
								 output.Item.PriceCollection.PurchasePrice.ToString(),  //26购入价
								 output.Quantity.ToString(),            //27出库量
								 (output.Quantity * output.Item.PriceCollection.RetailPrice / output.Item.PackQty).ToString(),          //28零售金额
                                 (output.Quantity * output.Item.PriceCollection.WholeSalePrice / output.Item.PackQty).ToString(),       //29批发金额
								 (output.Quantity * output.Item.PriceCollection.PurchasePrice / output.Item.PackQty).ToString(),        //30购入金额
								 output.StoreQty.ToString(),            //31出库后库存数量
								 output.StoreCost.ToString(),           //32出库后库存总金额
								 output.SpecialFlag,                    //33特殊标记。1是，0否
								 output.State,                          //34出库状态 0申请、1审批、2核准
								 output.Operation.ApplyQty.ToString(),            //35申请数量
								 output.Operation.ApplyOper.ID,                  //36申请出库人
								 output.Operation.ApplyOper.OperTime.ToString(),           //37申请出库日期
								 output.Operation.ExamQty.ToString(),             //38审批数量
								 output.Operation.ExamOper.ID,                   //39审批人
								 output.Operation.ExamOper.OperTime.ToString(),            //40审批日期
								 output.Operation.ApproveOper.ID,                //41核准人
								 output.PlaceNO,                      //42货位号
								 output.Operation.ReturnQty.ToString(),           //43退库数量
								 output.DrugedBillNO,                 //44摆药单号
								 output.MedNO,                          //45制剂序号－生产序号或检验序号
								 output.TargetDept.ID,                  //46领药单位编码
								 output.RecipeNO,                       //47处方号
								 output.SequenceNO.ToString(),          //48处方流水号
								 output.GetPerson,                      //49领药人
								 output.Memo,                           //50备注
								 this.Operator.ID,                      //51操作员
                                 NConvert.ToInt32(output.IsArkManager).ToString(),
                                 arkNO,
                                 //{F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}  出/退库记录发生时间
                                 output.OutDate.ToString()
			};
            return strParm;
        }

        /// <summary>
        /// 插入一条出库记录
        /// </summary>
        /// <param name="output">出库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertOutput(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertOutput", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Item.InsertOutput";
                return -1;
            }
            try
            {
                //如果出库实体中没有出库单流水号，则取出库单流水号
                if (output.ID == "")
                {
                    output.ID = this.GetNewOutputNO();
                    if (output.ID == null) return -1;
                }

                //取参数列表
                string[] strParm = myGetParmOutput(output);
                strSQL = string.Format(strSQL, strParm);  //替换SQL语句中的参数。          
            }
            catch (Exception ex)
            {
                this.Err = "插入出库记录SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新一条出库记录
        /// </summary>
        /// <param name="output">出库记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateOutput(Neusoft.HISFC.Models.Pharmacy.Output output)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateOutput", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Item.UpdateOutput";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmOutput(output);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新出库记录SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除出库记录
        /// </summary>
        /// <param name="ID">出库记录流水号</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int DeleteOutput(string ID)
        {
            string strSQL = "";
            //根据出库记录流水号删除某一条出库记录的DELETE语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteOutput", ref strSQL) == -1)
            {
                this.Err = "找不到SQL语句！Pharmacy.Item.DeleteOutput";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, ID);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.DeleteOutput";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #endregion

        #region 库存表操作

        #region 外部接口

        /// <summary>
        /// 取某一药房中某一药品在库存汇总表中的数量
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="deptCode">库房编码</param>
        /// <param name="storageNum">库存总数量（返回参数）</param>
        /// <returns>1成功，-1失败</returns>
        public int GetStorageNum(string deptCode, string drugCode, out decimal storageNum)
        {
            storageNum = 0;
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageNum.ByDrugCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageNum.ByDrugCode字段!";
                return -1;
            }
            //格式化SQL语句
            string[] parm = { deptCode, drugCode };
            strSQL = string.Format(strSQL, parm);

            try
            {
                //取药品库存总数量
                if (this.ExecQuery(strSQL) == -1)
                {
                    this.Err = "执行取药品库存总数量SQL语句时出错：" + this.Err;
                    return -1;
                }

                if (this.Reader.Read())
                {
                    try
                    {
                        storageNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0].ToString());  //药品库存总数量
                    }
                    catch (Exception ex)
                    {
                        this.Err = "取药品库存总数量时出错！" + ex.Message;
                        return -1;
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = "执行Sql语句 获取库存总数量发生错误" + ex.Message;
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }

        }

        /// <summary>
        /// 取某一药房中某一药品在库存汇总表中的数量，最低库存量，最高库存量{613A769A-C540-4a2c-949D-28B31F0BC482}
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="deptCode">库房编码</param>
        /// <param name="storageNum">库存总数量（返回参数）</param>
        /// <param name="storageNum">最低库存量（返回参数）</param>
        /// <param name="storageNum">最高库存量（返回参数）</param>
        /// <returns>1成功，-1失败</returns>
        public int GetStorageLowTopNum(string deptCode, string drugCode, out decimal storageNum,out decimal storageLowNum,out decimal storageTopNum)
        {
            storageNum = 0;
            storageLowNum = 0;
            storageTopNum = 0;
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageLowTopNum.ByDrugCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageLowTopNum.ByDrugCode字段!";
                return -1;
            }
            //格式化SQL语句
            string[] parm = { deptCode, drugCode };
            strSQL = string.Format(strSQL, parm);

            try
            {
                //取药品库存总数量
                if (this.ExecQuery(strSQL) == -1)
                {
                    this.Err = "执行取药品库存总数量SQL语句时出错：" + this.Err;
                    return -1;
                }

                if (this.Reader.Read())
                {
                    try
                    {
                        storageNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0].ToString());  //药品库存总数量
                        storageLowNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());//药品最低库存量
                        storageTopNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());//药品最高库存量
                    }
                    catch (Exception ex)
                    {
                        this.Err = "取药品库存总数量时出错！" + ex.Message;
                        return -1;
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = "执行Sql语句 获取库存总数量发生错误" + ex.Message;
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }

        }

        /// <summary>
        /// 取某一药房中某一药品在库存汇总表中的数量
        /// </summary>
        /// <param name="deptCode">药房编码</param>
        /// <param name="drugQuality">药品性质编码</param>
        /// <returns>成功返回库存记录数组，出错返回null</returns>
        public ArrayList QueryStockinfoList(string deptCode, string drugQuality)
        {
            string strSQL = "";
            string strWhere = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockinfoList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockinfoList字段!";
                return null;
            }

            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockinfoList.ByQuality", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockinfoList.ByQuality字段!";
                return null;
            }

            //格式化SQL语句
            string[] parm = { deptCode, drugQuality };
            strSQL = string.Format(strSQL + strWhere, parm);

            //取药品库存总数量
            return this.myGetStockinfo(strSQL);
        }

        /// <summary>
        /// 取某一药房中在库存汇总表中的记录
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <returns>库存记录数组，出错返回null</returns>
        public ArrayList QueryStockinfoList(string deptCode)
        {
            return this.QueryStockinfoList(deptCode, "ALL");
        }

        /// <summary>
        /// 获取科室库存低于最低库存量的药品
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回科室库存信息 失败返回null</returns>
        public ArrayList QueryWarnDrugStockInfoList(string deptCode)
        {
            string strSQL = "";
            string strWhere = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockinfoList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockinfoList字段!";
                return null;
            }

            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockinfoList.WarnDrug", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockinfoList.WarnDrug字段!";
                return null;
            }

            //格式化SQL语句
            string[] parm = { deptCode };
            strSQL = string.Format(strSQL + strWhere, parm);

            //取药品库存总数量
            return this.myGetStockinfo(strSQL);
        }

        /// <summary>
        /// 获取科室内达到库存有效期警戒线的药品
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="warnDays">有效期警示天数</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public ArrayList QueryWarnValidDateStockInfoList(string deptCode, int warnDays)
        {
            DateTime sysTime = this.GetDateTimeFromSysDateTime();

            string strSQL = "";
            string strWhere = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockinfoList字段!";
                return null;
            }

            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList.WarnValid", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList.WarnValid字段!";
                return null;
            }

            //格式化SQL语句
            string[] parm = { deptCode, (sysTime.AddDays(warnDays)).ToString() };
            strSQL = string.Format(strSQL + strWhere, parm);

            //取药品库存总数量
            return this.myGetStorage(strSQL);
        }

        /// <summary>
        /// 判断药品是否达到报警设置
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="isJudgePreOut">是否判断预扣库存</param>
        /// <param name="isJudgeMinStore">警戒线标准是否为库存下限</param>
        /// <returns>满足报警返回True 否则返回False</returns>
        public bool JudgeIsWarnStore(string deptCode, string drugCode, bool isJudgePreOut, bool isJudgeMinStore)
        {
            Neusoft.HISFC.Models.Pharmacy.Storage storage = this.GetStockInfoByDrugCode(deptCode, drugCode);
            if (storage == null)
            {
                return false;
            }

            decimal storeQty = storage.StoreQty;
            if (isJudgePreOut)
            {
                storeQty = storage.StoreQty - storage.PreOutQty;
            }

            decimal warnQty = 0;
            if (isJudgeMinStore)
            {
                warnQty = storage.LowQty;
            }

            if (warnQty > storeQty)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 根据科室编码/药品编码 获取该药品在科室内库存是否已低于警戒线
        /// </summary>
        /// <param name="stockDeptCode">库房编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>等于小于警戒线 False 大于警戒线 True</returns>
        public bool GetWarnDrugStock(string stockDeptCode, string drugCode)
        {
            Neusoft.HISFC.Models.Pharmacy.Storage storage = this.GetStockInfoByDrugCode(stockDeptCode, drugCode);
            if (storage == null)
                return false;
            if (storage.LowQty > 0 && storage.LowQty >= storage.StoreQty)     //当前库存量小于等于最低库存警戒线时
                return false;
            else
                return true;
        }

        /// <summary>
        /// 获取病区特殊药品取药信息 忽略药品职级限制的判断
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回该类药品数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QuerySpeLocationItem(string deptCode)
        {
            string strNormalSql = "";  //获得药品信息的SELECT语句

            //取无限制药品 
            if (this.Sql.GetSql("Pharmacy.Item.QuerySpeLocationItem", ref strNormalSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QuerySpeLocationItem字段!";
                return null;
            }

            strNormalSql = string.Format(strNormalSql, deptCode);

            List<Neusoft.HISFC.Models.Pharmacy.Item> alNormal = this.myGetAvailableList(strNormalSql);
            if (alNormal == null)
            {
                this.Err = "获取无限制药品发生错误" + this.Err;
                return null;
            }

            return alNormal;
        }

        /// <summary>
        /// 获取医嘱、收费使用的药品数据
        /// </summary>
        /// <param name="deptCode">取药部门</param>
        /// <param name="doctCode">医生编码</param>
        /// <param name="drugGrade">药品等级</param>
        /// <returns>成功返回药品数组 失败返回null 无满足条件数据返回空数组</returns>
        public ArrayList QueryItemAvailableArrayList(string deptCode, string doctCode, string drugGrade)
        {
            List<Neusoft.HISFC.Models.Pharmacy.Item> alList = this.QueryItemAvailableList(deptCode, doctCode, drugGrade);

            if (alList == null)
            {
                return null;
            }

            return new ArrayList(alList.ToArray());
        }

        /// <summary>
        /// 获取医嘱、收费使用的药品数据
        /// </summary>
        /// <param name="deptCode">取药部门</param>
        /// <param name="doctCode">医生编码</param>
        /// <param name="drugGrade">药品等级</param>
        /// <returns>成功返回药品数组 失败返回null 无满足条件数据返回空数组</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemAvailableList(string deptCode, string doctCode, string drugGrade)
        {
            string strNormalSql = "";  //获得药品信息的SELECT语句

            //取无限制药品 
            if (this.Sql.GetSql("Pharmacy.Item.QueryItemAvailableList.Normal", ref strNormalSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryItemAvailableList.Normal字段!";
                return null;
            }

            strNormalSql = string.Format(strNormalSql, deptCode);

            List<Neusoft.HISFC.Models.Pharmacy.Item> alNormal = this.myGetAvailableList(strNormalSql);
            if (alNormal == null)
            {
                this.Err = "获取无限制药品发生错误" + this.Err;
                return null;
            }
            //获取病区特殊药品取药
            List<Neusoft.HISFC.Models.Pharmacy.Item> alSpeLocation = this.QuerySpeLocationItem(deptCode);
            if (alSpeLocation == null)
            {
                this.Err = "获取病区特殊药品取药错误" + this.Err;
                return null;
            }

            alNormal.AddRange(alSpeLocation);

            //如果医生未维护职级对应药品等级 那么只能看到无限制药品 
            if (drugGrade == null || drugGrade == "")
            {
                return alNormal;
            }

            //取等级限制药品
            string strGradeSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.QueryItemAvailableList.Grade", ref strGradeSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryItemAvailableList.Grade字段!";
                return null;
            }

            strGradeSql = string.Format(strGradeSql, deptCode, drugGrade);

            List<Neusoft.HISFC.Models.Pharmacy.Item> alGrade = this.myGetAvailableList(strGradeSql);
            if (alGrade == null)
            {
                this.Err = "获取等级限制药品发生错误" + this.Err;
                return null;
            }

            alNormal.AddRange(alGrade);

            //取特限药品
            string strSpeDrugSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.QueryItemAvailableList.SpeDrug", ref strSpeDrugSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryItemAvailableList.SpeDrug字段!";
                return null;
            }

            strSpeDrugSql = string.Format(strSpeDrugSql, deptCode, drugGrade, doctCode);

            List<Neusoft.HISFC.Models.Pharmacy.Item> alSpeDrug = this.myGetAvailableList(strSpeDrugSql);
            if (alSpeDrug == null)
            {
                this.Err = "获取特限药品发送错误" + this.Err;
                return null;
            }

            alNormal.AddRange(alSpeDrug);

            return alNormal;
        }

        #endregion

        #region 入出库更新库存

        /// <summary>
        /// 根据入库信息更新库存
        /// </summary>
        /// <param name="input">入库信息</param>
        /// <param name="storageState">库存状态</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateStorageForInput(Neusoft.HISFC.Models.Pharmacy.Input input, string storageState)
        {
            decimal dNowPrice = 0;
            if (this.GetNowPrice(input.Item.ID, ref dNowPrice) == -1)
            {
                this.Err = "根据入库记录更新库存 获取药品" + input.Item.Name + "零售价出错";
                return -1;
            }

            //如包装数量为0 则将包装数量赋值为1
            if (input.Item.PackQty == 0)
                input.Item.PackQty = 1;
            Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase;
            storageBase = input.Clone() as Neusoft.HISFC.Models.Pharmacy.StorageBase;

            storageBase.Item.PriceCollection.RetailPrice = dNowPrice;					                //当前最新价格
            storageBase.Item.PriceCollection.PurchasePrice = input.Item.PriceCollection.PurchasePrice;	//最新购入价
            storageBase.Operation.Oper.OperTime = input.Operation.Oper.OperTime;
            storageBase.Class2Type = "0310";
            storageBase.PrivType = input.PrivType;

            //storageBase.PrivType = "0310" + input.PrivType;

            int parm;
            parm = this.UpdateStorageNum(storageBase);
            if (parm == -1)
            {
                this.Err = "更新申请科室库存时出错！";
                return -1;
            }
            if (parm == 0)
            {
                storageBase.State = storageState;		//库存状态
                parm = this.InsertStorage(storageBase);
                if (parm == -1)
                {
                    this.Err = "对申请科室增加库存出错！";
                    return -1;
                }
            }

            return 1;
        }

        #endregion

        #region 内部使用

        /// <summary>
        /// 取某一药品在全院的库存总条数
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <returns>返回库存数量大于零的总条数 失败返回-1</returns>
        public int GetDrugStorageRowNum(string drugCode)
        {
            int storageNum = 0;
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDrugStorageRowNum.ByDrugCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugStorageRowNum.ByDrugCode字段!";
                return -1;
            }
            //格式化SQL语句
            string[] parm = { drugCode };
            strSQL = string.Format(strSQL, parm);

            try
            {
                //取药品库存总数量
                if (this.ExecQuery(strSQL) == -1)
                {
                    this.Err = "取某一药品再全院的库存总条数SQL语句时出错：" + this.Err;
                    return -1;
                }

                if (this.Reader.Read())
                {
                    try
                    {
                        storageNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[0].ToString());  //药品库存总数量
                    }
                    catch (Exception ex)
                    {
                        this.Err = "取某一药品再全院的库存总条数！" + ex.Message;
                        this.Reader.Close();
                        return -1;
                    }
                }
                return storageNum;
            }
            catch (Exception ex)
            {
                this.Err = "执行Sql语句获取 库存总条目发生错误" + ex.Message;
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 取某一药房中某一药品某一批次在库存明细表中的数量
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="deptCode">库房编码</param>
        /// <param name="groupNO">批次（如果为0，则取所有批次库存数量之和）</param>
        /// <param name="storageNum">库存总数量（返回参数）</param>
        /// <returns>1成功，-1失败</returns>
        public int GetStorageNum(string deptCode, string drugCode, decimal groupNO, out decimal storageNum)
        {
            storageNum = 0;
            //如果批次为零则取所有批次库存数量之和
            if (groupNO == 0) return GetStorageNum(deptCode, drugCode, out storageNum);

            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageNum.ByGroupNo", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageNum.ByGroupNo字段!";
                return -1;
            }
            //格式化SQL语句
            string[] parm = { deptCode, drugCode, groupNO.ToString() };
            strSQL = string.Format(strSQL, parm);

            try
            {
                //取药品库存总数量
                if (this.ExecQuery(strSQL) == -1)
                {
                    this.Err = "执行取批次药品库存总数量SQL语句时出错：" + this.Err;
                    return -1;
                }

                if (this.Reader.Read())
                {
                    try
                    {
                        storageNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0].ToString());  //药品库存总数量
                    }
                    catch (Exception ex)
                    {
                        this.Err = "取批次药品库存总数量时出错！" + ex.Message;
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Err = "执行Sql语句获取制定批次药品数量发生错误" + ex.Message;
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }
            return 1;
        }

        /// <summary>
        /// 取某一药房中某一药品某一批号在库存明细表中的数量
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="deptCode">库房编码</param>
        /// <param name="batchNO">批号（如果为null或空字符串，则取所有批号库存数量之和）</param>
        /// <param name="storageNum">库存总数量（返回参数）</param>
        /// <returns>1成功，-1失败</returns>
        public int GetStorageNum(string deptCode, string drugCode, string batchNO, out decimal storageNum)
        {
            storageNum = 0;
            //如果批号为零则取所有批号库存数量之和
            if (batchNO == null || batchNO == "")
            {
                return GetStorageNum(deptCode, drugCode, out storageNum);
            }

            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageNum.ByBatchNO", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageNum.ByBatchNO字段!";
                return -1;
            }
            //格式化SQL语句
            string[] parm = { deptCode, drugCode, batchNO };
            strSQL = string.Format(strSQL, parm);

            try
            {
                //取药品库存总数量
                if (this.ExecQuery(strSQL) == -1)
                {
                    this.Err = "执行取批号药品库存总数量SQL语句时出错：" + this.Err;
                    return -1;
                }

                if (this.Reader.Read())
                {
                    try
                    {
                        storageNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0].ToString());  //药品库存总数量
                    }
                    catch (Exception ex)
                    {
                        this.Err = "取批号药品库存总数量时出错！" + ex.Message;
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Err = "执行Sql语句获取制定批号药品数量发生错误" + ex.Message;
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }
            return 1;
        }

        /// <summary>
        /// 取某一药房中某一药品在库存明细表中的数据
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="deptCode">库房编码</param>
        /// <returns>成功返回库存记录数组 Storage实体，出错返回null</returns>
        public ArrayList QueryStorageList(string deptCode, string drugCode)
        {
            string strSQL = "";
            string strWhere = "";
            string strOrder = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList字段!";
                return null;
            }

            //取WHERE条件
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList.ByDrugCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList.ByDrugCode字段!";
                return null;
            }

            //取Order条件
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList.OrderAsc", ref strOrder) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList.OrderAsc字段!";
                return null;
            }

            //格式化SQL语句
            string[] parm = { deptCode, drugCode, "0" };
            strSQL = string.Format(strSQL + strWhere + strOrder, parm);

            //取药品库存总数量
            return this.myGetStorage(strSQL);
        }

        /// <summary>
        /// 取某一药房中某一药品在库存明细表中的数量
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="deptCode">库房编码</param>
        /// <param name="groupNo">批次</param>
        /// <returns>成功返回库存记录数组，出错返回null</returns>
        public ArrayList QueryStorageList(string deptCode, string drugCode, decimal groupNo)
        {
            string strSQL = "";
            string strWhere = "";
            string strOrder = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList字段!";
                return null;
            }

            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList.ByDrugCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList.ByDrugCode字段!";
                return null;
            }

            //取Order条件
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList.OrderAsc", ref strOrder) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList.OrderAsc字段!";
                return null;
            }

            //格式化SQL语句
            string[] parm = { deptCode, drugCode, groupNo.ToString() };
            strSQL = string.Format(strSQL + strWhere + strOrder, parm);

            //取药品库存总数量
            return this.myGetStorage(strSQL);
        }

        /// <summary>
        /// 取某一药房中某一药品在库存明细表中的数量
        /// 只获取有效的记录
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="deptCode">库房编码</param>
        /// <param name="groupNo">批次</param>
        /// <returns>成功返回库存记录数组，出错返回null</returns>
        public ArrayList QueryStorageList(string deptCode, string drugCode, string batchNO)
        {
            string strSQL = "";
            string strWhere = "";
            string strOrder = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList字段!";
                return null;
            }

            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList.ByBatchNO", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList.ByBatchNO字段!";
                return null;
            }

            //取Order条件
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList.OrderAsc", ref strOrder) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList.OrderAsc字段!";
                return null;
            }

            //格式化SQL语句
            if (batchNO == null || batchNO == "")
            {
                batchNO = "ALL";
            }
            string[] parm = { deptCode, drugCode, batchNO };
            strSQL = string.Format(strSQL + strWhere + strOrder, parm);

            //取药品库存总数量
            return this.myGetStorage(strSQL);
        }

        /// <summary>
        /// 根据药品编码获取库存汇总信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>成功返回库存汇总信息 失败返回null 无记录返回空实体</returns>
        public Storage GetStockInfoByDrugCode(string deptCode, string drugCode)
        {
            string strSQL = "";
            string strWhere = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockinfoList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockinfoList字段!";
                return null;
            }

            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockinfoList.ByDrugCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockinfoList.ByDrugCode字段!";
                return null;
            }
            //格式化SQL语句
            string[] parm = { deptCode, drugCode };
            strSQL = string.Format(strSQL + strWhere, parm);

            //取药品库存总数量
            ArrayList al = this.myGetStockinfo(strSQL);
            if (al == null)
            {
                return null;
            }

            //如果没有找到数据，则返回新实体。
            if (al.Count == 0)
            {
                return new Neusoft.HISFC.Models.Pharmacy.Storage();
            }

            return al[0] as Neusoft.HISFC.Models.Pharmacy.Storage;
        }

        /// <summary>
        /// 根据是否按批号管理返回库存信息数组
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="isBatch">是否按批号管理</param>
        /// <returns>成功返回数组，失败返回null 无数据返回空数组</returns>
        public ArrayList QueryStorageList(string deptCode, bool isBatch)
        {
            string strSQL = "";
            string xmlSQL = "";
            //返回数组
            ArrayList al = new ArrayList();
            //用于库存信息存贮
            Neusoft.HISFC.Models.Pharmacy.Item info;
            //确定在xml中sql语句的位置
            if (isBatch)
                xmlSQL = "Pharmacy.Item.GetStorageListByBatch";
            else
                xmlSQL = "Pharmacy.Item.GetStorageListNoBatch";
            //取sql语句
            if (this.Sql.GetSql(xmlSQL, ref strSQL) == -1)
            {
                this.Err = "没有找到" + xmlSQL + "字段！";
                return null;
            }
            //格式化sql语句
            strSQL = string.Format(strSQL, deptCode);

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.Pharmacy.Item();
                    info.ID = this.Reader[0].ToString();							//0 药品编码
                    info.Name = this.Reader[1].ToString();							//1 药品名称
                    info.Specs = this.Reader[2].ToString();							//2 规格
                    info.User01 = this.Reader[3].ToString();						//3 批号
                    info.User02 = this.Reader[4].ToString();						//4 库位号
                    info.User03 = this.Reader[5].ToString();						//5 库存
                    info.SpellCode = this.Reader[6].ToString();					//6 拼音码
                    info.WBCode = this.Reader[7].ToString();						//7 五笔码
                    info.NameCollection.RegularSpell.SpellCode = this.Reader[8].ToString();	//8 通用名拼音码
                    info.NameCollection.RegularSpell.WBCode = this.Reader[9].ToString();		//9 通用名五笔码
                    if (this.Reader.FieldCount > 10)
                    {
                        info.NameCollection.OtherSpell.SpellCode = this.Reader[10].ToString();      //10 别名拼音码
                        info.NameCollection.OtherSpell.WBCode = this.Reader[11].ToString();         //11 别名五笔码
                        info.NameCollection.FormalSpell.SpellCode = this.Reader[12].ToString();     //12 学名拼音码
                        info.NameCollection.FormalSpell.WBCode = this.Reader[13].ToString();        //13 学名五笔码                    
                        info.PackQty = NConvert.ToDecimal(this.Reader[14]);                         //14 包装数量
                    }

                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获得库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获取指定药品的库房库存列表
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public ArrayList QueryStoreDeptList(string drugCode)
        {
            string strSQL = "";
            //返回数组
            ArrayList al = new ArrayList();
            //取sql语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryStoreDeptList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryStoreDeptList字段！";
                return null;
            }
            //格式化sql语句
            strSQL = string.Format(strSQL, drugCode);

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {

                //用于库存信息存贮
                Neusoft.HISFC.Models.Pharmacy.Storage info;

                while (this.Reader.Read())
                {
                    info = new Storage();

                    info.Item.ID = this.Reader[0].ToString();							    //0 药品编码
                    info.Item.Name = this.Reader[1].ToString();							    //1 药品名称
                    info.Item.Specs = this.Reader[2].ToString();							//2 规格
                    info.BatchNO = this.Reader[3].ToString();						        //3 批号
                    info.StoreQty = NConvert.ToDecimal(this.Reader[4].ToString());		    //5 库存
                    info.Item.MinUnit = this.Reader[5].ToString();
                    info.StockDept.ID = this.Reader[6].ToString();                          //库存科室
                    info.StockDept.Name = this.Reader[7].ToString();
                    info.Item.Product.Producer.ID = this.Reader[8].ToString();
                    info.Item.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());
                    info.Item.PackUnit = this.Reader[10].ToString();

                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获得库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 更新库存明细表中的数量（正数是增加，负数是减少）
        /// 患者库存管理时更新有效期为操作日期
        /// </summary>
        /// <param name="storageBase">库存记录类</param>
        /// <param name="operDate">操作日期 </param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateStorageNum(Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase, DateTime operDate)
        {
            string strSQL = "";
            //取SQL语句。
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStorageNumAndValidDate", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateStorageNumAndValidDate字段!";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   storageBase.StockDept.ID,                  //0库存科室编码
									   storageBase.Item.ID,                  //1药品编码
									   storageBase.GroupNO.ToString(),       //2批次
									   storageBase.Quantity.ToString(),      //3变化数量
									   (storageBase.Quantity * storageBase.Item.PriceCollection.RetailPrice / storageBase.Item.PackQty).ToString(),//4变化金额
									   storageBase.ID,                       //5出库单流水号
									   storageBase.SerialNO.ToString(),      //6出库单内序号
									   storageBase.TargetDept.ID,            //7领药部门
									   storageBase.Class2Type + "|" + storageBase.PrivType,				 //8权限类型
									   this.Operator.ID,                     //9操作人
									   operDate.ToString()					//10操作日期/有效期
								   };


                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新库存明细表中的数量的SQl参数赋值出错！Pharmacy.Item.UpdateStorageNumAndValidDate" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新库存明细表中的数量（正数是增加，负数是减少）
        /// </summary>
        /// <param name="storageBase">库存记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateStorageNum(Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase)
        {
            string strSQL = "";
            //取SQL语句。
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStorageNum", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateStorageNum字段!";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   storageBase.StockDept.ID,                  //0库存科室编码
									   storageBase.Item.ID,                  //1药品编码
									   storageBase.GroupNO.ToString(),       //2批次
									   storageBase.Quantity.ToString(),      //3变化数量
									   (storageBase.Quantity * storageBase.Item.PriceCollection.RetailPrice / storageBase.Item.PackQty).ToString(),//4变化金额
									   storageBase.ID,                       //5出库单流水号
									   storageBase.SerialNO.ToString(),      //6出库单内序号
									   storageBase.TargetDept.ID,            //7领药部门
									   storageBase.Class2Type + "|" + storageBase.PrivType,				 //8权限类型
									   this.Operator.ID                      //9操作人
								   };


                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新库存明细表中的数量的SQl参数赋值出错！Pharmacy.Item.ExamStorage" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新一条库存记录的库存状态
        /// </summary>
        /// <param name="storageBase">库存记录类</param>
        /// <param name="storageState">库存状态 0 暂入库 1 正式入库</param>
        /// <param name="updateStorage">是否根据库存记录类更新库存 true  更新 false 不更新</param>
        /// <returns>0 没有更新 1 成功 －1 失败</returns>
        public int UpdateStorageState(Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase, string storageState, bool updateStorage)
        {
            string strSQL = "";
            //取SQL语句。
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStorageState", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateStorageState字段!";
                return -1;
            }
            try
            {
                decimal quantity = 0;
                decimal cost = 0;
                if (updateStorage)		//如更新库存
                {
                    quantity = storageBase.Quantity;
                    cost = storageBase.Quantity * storageBase.Item.PriceCollection.RetailPrice / storageBase.Item.PackQty;
                }
                //取参数列表
                string[] strParm = {
									   storageBase.StockDept.ID,                  //0库存科室编码
									   storageBase.Item.ID,                  //1药品编码
									   storageBase.GroupNO.ToString(),       //2批次
									   quantity.ToString(),					//3变化数量
									   cost.ToString(),						//4变化金额
									   storageBase.ID,                       //5出库单流水号
									   storageBase.SerialNO.ToString(),      //6出库单内序号
									   storageBase.TargetDept.ID,            //7领药部门
									   storageBase.Class2Type + "|" + storageBase.PrivType,				 //8权限类型
									   this.Operator.ID,                     //9操作人
									   storageState							 //10库存状态
								   };


                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新库存记录内状态的SQl参数赋值出错！Pharmacy.Item.UpdateStorageState" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新库存明细数据
        /// 先执行更新数量操作，如果数据库中没有记录则执行插入操作
        /// </summary>
        /// <param name="storageBase">库存记录类</param>
        /// <returns>成功返回操作条目数 失败返回－1</returns>
        public int SetStorage(Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase)
        {
            //先执行更新操作
            int parm = UpdateStorageNum(storageBase);
            if (parm == 0)
            {
                //如果数据库中没有记录则执行插入操作
                parm = InsertStorage(storageBase);
            }
            return parm;
        }

        /// <summary>
        /// 更新库存汇总表中的预扣数量（正数是增加，负数是减少）
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="alterStoreNum">预扣变化数量</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        [System.Obsolete("原有预扣库存管理模式作废 采用UpdateStockinfoPreOutNum代替", true)]
        public int UpdateStoragePreOutNum(string deptCode, string drugCode, decimal alterStoreNum)
        {
            string strSQL = "";
            //取SQL语句。
            if (this.Sql.GetSql("Pharmacy.Item.UpdatePreOutNum", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdatePreOutNum字段!";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   deptCode,                       //库存科室编码
									   drugCode,                       //药品编码
									   alterStoreNum.ToString(),          //预扣变化数量
									   this.Operator.ID                //操作人
								   };

                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新库存汇总表中的预扣数量时出错！Pharmacy.Item.UpdatePreOutNum" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新库存汇总表中的一条记录
        /// </summary>
        /// <param name="storage">库存记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateStockinfoModifyData(Neusoft.HISFC.Models.Pharmacy.Storage storage)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStockinfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateStockinfo字段!";
                return -1;
            }
            try
            {
                string[] strParm = {
									   storage.StockDept.ID,                        //0 科室编码
									   storage.Item.ID,                             //1 药品编码
									   storage.LowQty.ToString(),                   //2 最低库存量
									   storage.TopQty.ToString(),                   //3 最高库存量
									   NConvert.ToInt32(storage.IsCheck).ToString(),//4 日盘点
									   //NConvert.ToInt32(storage.IsStop).ToString(), //5 是否停用
                                       ((int)storage.ValidState).ToString(),
									   storage.Memo,                                //6 备注
									   this.Operator.ID,                            //7 操作人
									   storage.PlaceNO,			                    //8 货位号
                                       NConvert.ToInt32(storage.IsLack).ToString(),  //9 是否缺药
                                       storage.ManageQuality.ID
								   };     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新库存汇总记录SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        ///<summary>
        ///获取某药品在全院、本库房的库存总量
        ///</summary>
        ///<param name="deptcode">库房编码</param>
        ///<param name="drugcode">药品编码</param>
        ///<param name="storeSum">返回库房总量</param>
        ///<param name="storeTotSum">返回全院总量</param>
        ///<returns>0 查找成功 -1 失败</returns>
        public int FindSum(string deptcode, string drugcode, ref decimal storeSum, ref decimal storeTotSum)
        {
            string strSelSQL = "";
            string strSQL = "";
            //取计算库存总量Select语句
            if (this.Sql.GetSql("Pharmacy.Item.StockPlanFindSum", ref strSelSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.StockPlanFindSum字段!";
                return -1;
            }

            string strWhere = "";
            //取查询本科室库存量的where条件语句
            if (this.Sql.GetSql("Pharmacy.Item.StockPlanFindSumList", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.StockPlanFindSumList字段!";
                return -1;
            }

            string strAllWhere = "";
            //取查询全院库存量的where条件语句
            if (this.Sql.GetSql("Pharmacy.Item.StockPlanFindSumAllList", ref strAllWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.StockPlanFindSumAllList字段!";
                return -1;
            }


            //格式化SQL语句，查询本科室库存总量
            try
            {
                strSQL = strSelSQL + " " + strWhere;
                strSQL = string.Format(strSQL, deptcode, drugcode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.StockPlanFindSumList:" + ex.Message;
                return -1;
            }

            storeSum = NConvert.ToDecimal(this.ExecSqlReturnOne(strSQL));
            //格式化SQL语句，查询全院库存总量
            try
            {
                strSQL = strSelSQL + " " + strAllWhere;
                strSQL = string.Format(strSQL, drugcode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.StockPlanFindSumAllList:" + ex.Message;
                return -1;
            }

            storeTotSum = NConvert.ToDecimal(this.ExecSqlReturnOne(strSQL));
            return 0;
        }

        /// <summary>
        /// 单科室调价更新库存零售价
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="retailPrice">新零售价格</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateStoragePrice(string deptCode, string drugCode, decimal retailPrice)
        {
            string strSQL = "";
            //取SQL语句。
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStoragePrice", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateStoragePrice字段!";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   deptCode,                       //库存科室编码
									   drugCode,                       //药品编码
									   retailPrice.ToString(),         //预扣变化数量
									   this.Operator.ID                //操作人
								   };

                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新库存汇总表中的零售价时出错！Pharmacy.Item.UpdateStoragePrice" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 为药柜管理添加

        /// <summary>
        /// 更新库存药柜管理数据
        /// </summary>
        /// <param name="storageBase">库存记录类</param>
        /// <returns>成功返回操作条目数 失败返回-1</returns>
        public int SetArkStorage(Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase)
        {
            string strSQL = "";
            //取SQL语句。
            if (this.Sql.GetSql("Pharmacy.Item.SetArkStorage", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.SetArkStorage字段!";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   storageBase.StockDept.ID,                        //库存科室编码
									   storageBase.Item.ID,                             //药品编码
                                       storageBase.GroupNO.ToString(),                  //库存序号
                                       storageBase.ArkQty.ToString()                    //变化量 加操作
								   };

                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新库存汇总表中的预扣数量时出错！Pharmacy.Item.SetArkStorage" + ex.Message;
                this.WriteErr();
                return -1;
            }
            int parma = this.ExecNoQuery(strSQL);
            if (parma != 1)
            {
                return parma;
            }

            //更新库存汇总信息内相应字段
            //取SQL语句。
            if (this.Sql.GetSql("Pharmacy.Item.SetArkStockinfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.SetArkStockinfo字段!";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = {
									   storageBase.StockDept.ID,                        //库存科室编码
									   storageBase.Item.ID,                             //药品编码
                                       storageBase.ArkQty.ToString()
								   };

                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "更新库存汇总表中的预扣数量时出错！Pharmacy.Item.SetArkStockinfo" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据科室编码、药柜管理标记获取科室库存药品列表
        /// </summary>
        /// <param name="deptCode">库存编码</param>
        /// <param name="isArk">是否药柜管理</param>
        /// <returns>成功返回药柜管理药品列表 失败返回null</returns>
        public ArrayList QueryArkFlagDrugByDeptCode(string deptCode, bool isArk)
        {
            string strSQL = "";
            string strWhere = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList字段!";
                return null;
            }

            //取WHERE条件
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageList.ForArk", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageList.ForArk字段!";
                return null;
            }

            //格式化SQL语句
            string[] parm = { deptCode, NConvert.ToInt32(isArk).ToString() };
            strSQL = string.Format(strSQL + strWhere, parm);

            return this.myGetStorage(strSQL);
        }

        /// <summary>
        /// 根据科室编码、药品编码判断药品是否药柜管理
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>如果药品为药柜管理返回True 否则返回False</returns>
        public bool IsArkManager(string deptCode, string drugCode)
        {
            string strSQL = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.IsArkManager", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.IsArkManager字段!";
                return false;
            }

            //格式化SQL语句
            string[] parm = { deptCode, drugCode };
            strSQL = string.Format(strSQL, parm);

            try
            {
                //执行查询语句
                if (this.ExecQuery(strSQL) == -1)
                {
                    this.Err = "获得库存信息时，执行SQL语句出错！" + this.Err;
                    this.ErrCode = "-1";
                    return false;
                }

                if (this.Reader.Read())
                {
                    return NConvert.ToBoolean(this.Reader[0]);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得库存信息时，执行SQL语句出错！" + ex.Message;
                this.ErrCode = "-1";
                return false;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        #endregion

        #region 基础增、删、改操作

        /// <summary>
        /// 取库存明细信息列表，可能是一条或者多条库存记录
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>成功返回库存对象数组 失败返回null</returns>
        private ArrayList myGetStorage(string SQLString)
        {
            ArrayList al = new ArrayList();                //用于返回库存信息的数组
            Neusoft.HISFC.Models.Pharmacy.Storage storage; //库存信息实体

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    storage = new Neusoft.HISFC.Models.Pharmacy.Storage();
                    storage.StockDept.ID = this.Reader[0].ToString();               //0库存科室
                    storage.Item.ID = this.Reader[1].ToString();               //1药品编码
                    storage.GroupNO = NConvert.ToDecimal(this.Reader[2].ToString());    //2批次号  
                    storage.BatchNO = this.Reader[3].ToString();               //3批号
                    storage.Item.Name = this.Reader[4].ToString();             //4药品商品名
                    storage.Item.Specs = this.Reader[5].ToString();            //5规格
                    storage.Item.Type.ID = this.Reader[6].ToString();          //6药品类别
                    storage.Item.Quality.ID = this.Reader[7].ToString();       //7药品性质
                    storage.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString());       //8零售价
                    storage.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[9].ToString());    //9批发价
                    storage.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[10].ToString());    //10实进价
                    storage.Item.PackUnit = this.Reader[11].ToString();                             //11包装单位
                    storage.Item.PackQty = NConvert.ToDecimal(this.Reader[12].ToString());          //12包装数
                    storage.Item.MinUnit = this.Reader[13].ToString();                              //13最小单位
                    storage.ShowState = this.Reader[14].ToString();                                 //14显示的单位标记
                    storage.ValidTime = NConvert.ToDateTime(this.Reader[15].ToString());            //15有效期
                    storage.StoreQty = NConvert.ToDecimal(this.Reader[16].ToString());              //16库存数量
                    storage.StoreCost = NConvert.ToDecimal(this.Reader[17].ToString());             //17库存金额
                    storage.PreOutQty = NConvert.ToDecimal(this.Reader[18].ToString());            //18预扣库存数量
                    storage.PreOutCost = NConvert.ToDecimal(this.Reader[19].ToString());           //19预扣库存金额

                    // storage.IsStop = NConvert.ToBoolean( this.Reader[ 20 ].ToString( ) );               //20有效性标志 1 在用 0 停用 2 废弃
                    storage.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)NConvert.ToInt32(this.Reader[20].ToString());

                    storage.Producer.ID = this.Reader[21].ToString();                               //21生产厂家
                    storage.LastMonthQty = NConvert.ToDecimal(this.Reader[22].ToString());         //22最近一次月结的库存量
                    storage.PlaceNO = this.Reader[23].ToString();                                 //23货位号
                    storage.State = this.Reader[24].ToString();                                     //24在库状态（0-暂入库，1正式入库）
                    storage.Memo = this.Reader[25].ToString();                                      //25备注
                    storage.Operation.Oper.ID = this.Reader[26].ToString();                                  //26操作人编码
                    storage.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[27].ToString());             //27操作日期
                    storage.InvoiceNO = this.Reader[28].ToString();									//28发票号

                    storage.IsArkManager = NConvert.ToBoolean(this.Reader[29]);
                    storage.ArkQty = NConvert.ToDecimal(this.Reader[30]);

                    al.Add(storage);
                }

                return al;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获得update或者insert库存表的传入参数数组
        /// </summary>
        /// <param name="storageBase">库存类</param>
        /// <returns>成功返回字符串数组 失败返回null</returns>
        private string[] myGetParmStorage(Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase)
        {

            string[] strParm ={   
								 storageBase.StockDept.ID,                       //0库存科室
								 storageBase.Item.ID,                       //1药品编码
								 storageBase.GroupNO.ToString(),            //2批次号  
								 storageBase.BatchNO,                       //3批号
								 storageBase.Item.Name,                     //4药品商品名
								 storageBase.Item.Specs,                    //5规格
								 storageBase.Item.Type.ID,                  //6药品类别
								 storageBase.Item.Quality.ID.ToString(),    //7药品性质
								 storageBase.Item.PriceCollection.RetailPrice.ToString(),   //8零售价
								 storageBase.Item.PriceCollection.WholeSalePrice.ToString(),//9批发价
								 storageBase.Item.PriceCollection.PurchasePrice.ToString(), //10实进价
								 storageBase.Item.PackUnit,                 //11包装单位
								 storageBase.Item.PackQty.ToString(),       //12包装数
								 storageBase.Item.MinUnit.ToString(),       //13最小单位
								 storageBase.ShowState,                     //14显示的单位标记
								 storageBase.ShowUnit,                      //15显示的单位
								 storageBase.ValidTime.ToString(),          //16有效期
								 storageBase.Quantity.ToString(),           //17库存数量
								 (storageBase.Quantity * storageBase.Item.PriceCollection.RetailPrice / storageBase.Item.PackQty).ToString(),//18库存金额
								 storageBase.Producer.ID,                   //19生产厂家
								 storageBase.PlaceNO,                     //20货位号
								 storageBase.TargetDept.ID,                 //21目标科室
								 storageBase.ID,                            //22单据号
								 storageBase.SerialNO.ToString(),           //23单内序号
								 storageBase.Class2Type + "|" + storageBase.PrivType,						//24库存操作类型0310入库,0320出库……
								 storageBase.Memo,                          //25备注
								 this.Operator.ID,                          //26操作人编码
								 storageBase.Operation.Oper.OperTime.ToString(),            //27操作日期
								 storageBase.State,							//28 状态
								 storageBase.InvoiceNO						//29 发票号
							 };
            return strParm;
        }

        /// <summary>
        /// 执行Sql语句 返回药品库存信息数组列表
        /// </summary>
        /// <param name="strSql">需执行的Sql</param>
        /// <returns>成功返回药品数组列表 失败返回null</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.Item> myGetAvailableList(string strSql)
        {
            Neusoft.HISFC.Models.Pharmacy.Item item; //返回数组中的药品信息类

            List<Neusoft.HISFC.Models.Pharmacy.Item> alList = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            try
            {
                if (this.ExecQuery(strSql) == -1)
                {
                    this.Err = "执行Sql语句发生错误" + this.Err;
                    return null;
                }

                while (this.Reader.Read())
                {
                    item = new Neusoft.HISFC.Models.Pharmacy.Item();

                    item.ID = this.Reader[0].ToString();                                  //0  药品编码
                    item.Name = this.Reader[1].ToString();                                //1  商品名称
                    item.PackQty = NConvert.ToDecimal(this.Reader[2].ToString());         //2  包装数量
                    item.Specs = this.Reader[3].ToString();                               //3  规格
                    item.MinFee.ID = this.Reader[4].ToString();                           //4  最小费用代码
                    item.SysClass.ID = this.Reader[5].ToString();                         //5  系统类别
                    item.PackUnit = this.Reader[6].ToString();                            //6  包装单位
                    item.MinUnit = this.Reader[7].ToString();                             //7  最小单位
                    item.Type.ID = this.Reader[8].ToString();                             //8  药品类别编码
                    item.Quality.ID = this.Reader[9].ToString();                          //9  药品性质编码
                    item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[10].ToString());      //10 零售价
                    item.Product.Producer.ID = this.Reader[11].ToString();                                  //11 生产厂家编码
                    item.SpellCode = this.Reader[12].ToString();                         //12 拼音码  
                    item.WBCode = this.Reader[13].ToString();                            //13 五笔码
                    item.UserCode = this.Reader[14].ToString();                          //14 自定义码
                    item.NameCollection.RegularName = this.Reader[15].ToString();                           //15 药品通用名
                    item.NameCollection.RegularSpell.SpellCode = this.Reader[16].ToString();                //16 通用名拼音码
                    item.NameCollection.RegularSpell.WBCode = this.Reader[17].ToString();                   //17 通用名五笔码
                    item.NameCollection.RegularSpell.UserCode = this.Reader[18].ToString();                 //18 通用名自定义码
                    item.NameCollection.EnglishName = this.Reader[19].ToString();                           //19 英文商品名 
                    item.User01 = this.Reader[20].ToString();                              //20 库存可用数量
                    item.User02 = this.Reader[21].ToString();                             //21 药房编码
                    item.DoseUnit = this.Reader[22].ToString();                           //22 剂量单位
                    item.BaseDose = NConvert.ToDecimal(this.Reader[23].ToString());       //23 基本剂量
                    item.DosageForm.ID = this.Reader[24].ToString();					  //24 剂型编码
                    item.Usage.ID = this.Reader[25].ToString();							  //25 用法编码
                    item.Frequency.ID = this.Reader[26].ToString();						  //26 频次编码
                    item.Grade = this.Reader[27].ToString();						      //27 药品等级：甲乙类
                    item.SpecialFlag = this.Reader[28].ToString();						  //28 省限
                    item.SpecialFlag1 = this.Reader[29].ToString();						  //29 市限	
                    item.SpecialFlag2 = this.Reader[30].ToString();						  //30 自费	
                    item.SpecialFlag3 = this.Reader[31].ToString();						  //31 特殊项目 项目特限标记
                    item.SpecialFlag4 = this.Reader[32].ToString();                       //32 特殊项目

                    alList.Add(item);
                }

                return alList;

            }
            catch (Exception ex)
            {
                this.Err = "获得药品库存时，执行SQL语句出错！" + ex.Message;
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 取库存明细信息列表，可能是一条或者多条库存记录
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>成功返回库存对象数组 失败返回null</returns>
        private ArrayList myGetStockinfo(string SQLString)
        {
            ArrayList al = new ArrayList();                  //用于返回库存信息的数组
            Neusoft.HISFC.Models.Pharmacy.Storage storage; //库存信息实体

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    storage = new Neusoft.HISFC.Models.Pharmacy.Storage();
                    storage.StockDept.ID = this.Reader[0].ToString();                              //0库存科室
                    storage.Item.ID = this.Reader[1].ToString();                              //1药品编码
                    storage.Item.Name = this.Reader[2].ToString();                            //2药品商品名
                    storage.Item.Specs = this.Reader[3].ToString();                           //3规格
                    storage.Item.Type.ID = this.Reader[4].ToString();                         //4药品类别
                    storage.Item.Quality.ID = this.Reader[5].ToString();                      //5药品性质
                    storage.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[6].ToString());  //6零售价
                    storage.Item.PackUnit = this.Reader[7].ToString();                         //7包装单位
                    storage.Item.PackQty = NConvert.ToDecimal(this.Reader[8].ToString());      //8包装数
                    storage.Item.MinUnit = this.Reader[9].ToString();                          //9最小单位
                    storage.ShowState = this.Reader[10].ToString();                            //10显示的单位标记
                    storage.ValidTime = NConvert.ToDateTime(this.Reader[11].ToString());       //11有效期
                    storage.StoreQty = NConvert.ToDecimal(this.Reader[12].ToString());         //12库存数量
                    storage.StoreCost = NConvert.ToDecimal(this.Reader[13].ToString());        //13库存金额
                    storage.PreOutQty = NConvert.ToDecimal(this.Reader[14].ToString());       //14预扣库存数量
                    storage.PreOutCost = NConvert.ToDecimal(this.Reader[15].ToString());      //15预扣库存金额

                    //storage.IsStop = NConvert.ToBoolean( this.Reader[ 16 ].ToString( ) );          //16有效性标志 0 在用 1 停用 2 废弃
                    storage.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)NConvert.ToInt32(this.Reader[16].ToString());

                    storage.LowQty = NConvert.ToDecimal(this.Reader[17].ToString());           //17最低库存量
                    storage.TopQty = NConvert.ToDecimal(this.Reader[18].ToString());           //18最高库存量
                    storage.PlaceNO = this.Reader[19].ToString();                            //19货位号
                    storage.IsCheck = NConvert.ToBoolean(this.Reader[20].ToString());          //20日盘点
                    storage.Memo = this.Reader[21].ToString();                                 //21备注
                    storage.Operation.Oper.ID = this.Reader[22].ToString();                             //22操作人编码
                    storage.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[23].ToString());        //23操作日期
                    storage.Item.SpellCode = this.Reader[24].ToString();                      //24拼音码
                    storage.Item.WBCode = this.Reader[25].ToString();                         //25五笔码
                    storage.Item.UserCode = this.Reader[26].ToString();                       //26自定义码
                    storage.Item.NameCollection.RegularName = this.Reader[27].ToString();                     //27通用名
                    storage.Item.NameCollection.RegularSpell.SpellCode = this.Reader[28].ToString();     //28通用名拼音码
                    storage.Item.NameCollection.RegularSpell.WBCode = this.Reader[29].ToString();        //29通用名五笔码
                    storage.Item.NameCollection.RegularSpell.UserCode = this.Reader[30].ToString();      //30通用名自定义码

                    storage.Item.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(NConvert.ToInt32(this.Reader[31]));
                    //storage.Item.IsStop = NConvert.ToBoolean( this.Reader[ 31 ].ToString( ) );     //31药库有效状态  -- zlw 2006-6-2

                    storage.Item.IsLack = NConvert.ToBoolean(this.Reader[32].ToString());     //32 缺药标志     -- zlw 2006-7-7

                    storage.IsArkManager = NConvert.ToBoolean(this.Reader[33].ToString());
                    storage.ArkQty = NConvert.ToDecimal(this.Reader[34]);

                    storage.ManageQuality.ID = this.Reader[35].ToString();

                    if (this.Reader.FieldCount > 36)
                    {
                        storage.Item.NameCollection.FormalName = this.Reader[36].ToString();
                        storage.Item.NameCollection.FormalSpell.SpellCode = this.Reader[37].ToString();
                        storage.Item.NameCollection.OtherName = this.Reader[38].ToString();
                        storage.Item.NameCollection.OtherSpell.SpellCode = this.Reader[39].ToString();
                        storage.Item.DosageForm.ID = this.Reader[40].ToString();
                        storage.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[41]);
                    }

                    al.Add(storage);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 向库存明细表中插入一条记录
        /// </summary>
        /// <param name="storageBase">库存记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertStorage(Neusoft.HISFC.Models.Pharmacy.StorageBase storageBase)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertStorage", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertStorage字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmStorage(storageBase);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "插入库存记录SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除库存明细记录
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="groupNo">批次</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int DeleteStorage(string deptCode, string drugCode, int groupNo)
        {
            string strSQL = "";
            //根据库存记录流水号删除某一条库存记录的DELETE语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteStorage", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, drugCode, deptCode, groupNo);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.DeleteStorage";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #endregion

        #region 调价表操作

        #region 内部使用

        /// <summary>
        /// 取某一药房中某一张调价单中的数据
        /// </summary>
        /// <param name="billCode">调价单号</param>
        /// <returns>调价信息记录数组，出错返回null</returns>
        public ArrayList QueryAdjustPriceInfoList(string billCode)
        {
            string strSQL = "";
            //string strWhere = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAdjustPriceInfoist", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAdjustPriceInfoist字段!";
                return null;
            }

            //格式化SQL语句
            strSQL = string.Format(strSQL, billCode);

            //取调价数据
            return this.myGetAdjustPriceInfo(strSQL);
        }

        /// <summary>
        /// 取某一药房中某一段时间的调价单列表
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <returns>调价信息记录数组，出错返回null</returns>
        public ArrayList QueryAdjustPriceBillList(string deptCode, DateTime beginTime, DateTime endTime)
        {
            return QueryAdjustPriceBillList(deptCode, beginTime, endTime, false);
        }

        /// <summary>
        /// 取某一药房中某一段时间的调价单列表
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <returns>调价信息记录数组，出错返回null</returns>
        public ArrayList QueryAdjustPriceBillList(string deptCode, DateTime beginTime, DateTime endTime, bool isDDDeptAdjust)
        {
            ArrayList al = new ArrayList();
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetAdjustPriceBillList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetAdjustPriceBillList字段!";
                return null;
            }

            //格式化SQL语句
            string[] parm = { deptCode, beginTime.ToString(), endTime.ToString(), NConvert.ToInt32(isDDDeptAdjust).ToString() };
            strSQL = string.Format(strSQL, parm);

            try
            {
                //执行SQL语句，取调价单数据
                if (this.ExecQuery(strSQL) == -1)
                {
                    this.Err = "取调价单列表时出错：" + this.Err;
                    return null;
                }

                AdjustPrice info;  //药品调价信息
                while (this.Reader.Read())
                {
                    info = new AdjustPrice();
                    try
                    {
                        info.ID = this.Reader[0].ToString();                            //调价单号
                        info.InureTime = NConvert.ToDateTime(this.Reader[1].ToString());//生效时间              
                        info.State = this.Reader[2].ToString();                         //调价单状态：0、未调价；1、已调价；2、无效
                        info.Operation.ID = this.Reader[3].ToString();                      //操作员编码
                        info.Operation.Name = this.Reader[4].ToString();                      //操作员名称
                        info.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[5].ToString()); //操作时间
                        info.IsDDAdjust = NConvert.ToBoolean(this.Reader[6]);
                        info.IsDSAdjust = NConvert.ToBoolean(this.Reader[7]);

                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得调价单列表时出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }
                    al.Add(info);
                }

                return al;
            }
            catch (Exception ex)
            {
                this.Err = "执行Sql语句获取调价信息发生错误 " + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

        }

        /// <summary>
        /// 在未生效的调价单中查找是否存在传入的药品
        /// </summary>
        /// <returns>成功返回调价调价单号 失败返回null  无未生效记录返回""</returns>
        public string SearchAdjustPriceByItem(string code)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.SearchAdjustPriceByItem", ref strSQL) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }

            try
            {
                strSQL = string.Format(strSQL, code);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            string strReturn = this.ExecSqlReturnOne(strSQL);
            if (strReturn == "-1")
            {
                this.Err = "查找调价单时出错！" + this.Err;
                return null;
            }
            return strReturn;
        }

        #endregion

        #region 基础增、删、改操作

        /// <summary>
        /// 向调价汇总表中插入一条记录
        /// </summary>
        /// <param name="adjustPrice">库存记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertAdjustPriceInfo(Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertAdjustPriceInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertAdjustPriceInfo字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmAdjustPriceInfo(adjustPrice);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "插入调价信息SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 向调价明细表中插入一条记录
        /// </summary>
        /// <param name="adjustPrice">库存记录类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertAdjustPriceDetail(Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertAdjustPriceDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertAdjustPriceDetail字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmAdjustPriceDetail(adjustPrice);     //取参数列表
                strSQL = string.Format(strSQL, strParm);									//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "插入调价明细信息SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 向调价汇总表中插入一条记录
        /// </summary>
        /// <param name="adjustPriceID">调价单号</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int DeleteAdjustPriceInfo(string adjustPriceID)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.DeleteAdjustPriceInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteAdjustPriceInfo字段!";
                return -1;
            }
            try
            {
                //如果是新增加的调价单，则直接返回
                if (adjustPriceID == "") return 1;
                strSQL = string.Format(strSQL, adjustPriceID);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "删除调价信息SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除某条未生效的药品调价信息 by Sunjh 2010-8-31 {B56F6FDF-E7D0-4afd-953A-3006AFE257C1}
        /// </summary>
        /// <param name="adjustPriceID">调价单号</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int DeleteAdjustPriceInfo(string adjustPriceID, string drugCode)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.DeleteAdjustPriceInfo.ByDrugCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteAdjustPriceInfo.ByDrugCode字段!";
                return -1;
            }
            try
            {
                //如果是新增加的调价单，则直接返回
                if (adjustPriceID == "") return 1;
                strSQL = string.Format(strSQL, adjustPriceID, drugCode);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "删除调价信息SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 取调价信息列表，可能是一条或者多条库存记录
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>调价信息对象数组</returns>
        private ArrayList myGetAdjustPriceInfo(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice; //调价信息实体

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    adjustPrice = new AdjustPrice();
                    adjustPrice.ID = this.Reader[0].ToString();                                    //0 调价单号
                    adjustPrice.SerialNO = NConvert.ToInt32(this.Reader[1].ToString());            //1 调价单内序号
                    adjustPrice.StockDept.ID = this.Reader[2].ToString();                               //2 库房编码  
                    adjustPrice.Item.ID = this.Reader[3].ToString();                               //3 药品编码
                    adjustPrice.Item.Type.ID = this.Reader[4].ToString();                          //4 药品类别
                    adjustPrice.Item.Quality.ID = this.Reader[5].ToString();                       //5 药品性质
                    adjustPrice.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[6].ToString());  //6 调价前零售价格
                    adjustPrice.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[7].ToString()); //7 调价前批发价格
                    adjustPrice.AfterRetailPrice = NConvert.ToDecimal(this.Reader[8].ToString());   //8 调价后零售价格
                    adjustPrice.AfterWholesalePrice = NConvert.ToDecimal(this.Reader[9].ToString()); //9 调价后批发价格
                    adjustPrice.ProfitFlag = this.Reader[10].ToString();                           //10盈亏标记1-盈，0-亏
                    adjustPrice.InureTime = NConvert.ToDateTime(this.Reader[11].ToString());       //11调价执行时间
                    adjustPrice.Item.Name = this.Reader[12].ToString();                             //12药品商品名
                    adjustPrice.Item.Specs = this.Reader[13].ToString();                            //13规格
                    adjustPrice.Item.Product.Producer.ID = this.Reader[14].ToString();                      //14生产厂家
                    adjustPrice.Item.PackUnit = this.Reader[15].ToString();                         //15包装单位
                    adjustPrice.Item.PackQty = NConvert.ToDecimal(this.Reader[16].ToString());      //16包装数
                    adjustPrice.Item.MinUnit = this.Reader[17].ToString();                          //17最小单位
                    adjustPrice.State = this.Reader[18].ToString();                                //18调价单状态：0、未调价；1、已调价；2、无效
                    adjustPrice.FileNO = this.Reader[19].ToString();                                //19招标文件号
                    adjustPrice.Memo = this.Reader[20].ToString();                                 //20备注
                    adjustPrice.Operation.Oper.ID = this.Reader[21].ToString();                              //21操作员编码
                    adjustPrice.Operation.Oper.Name = this.Reader[22].ToString();                             //22操作员名称
                    adjustPrice.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[23].ToString());        //23操作时间
                    adjustPrice.IsDDAdjust = NConvert.ToBoolean(this.Reader[24].ToString());
                    adjustPrice.IsDSAdjust = NConvert.ToBoolean(this.Reader[25]);
                    adjustPrice.Item.PriceCollection.PurchasePrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[26].ToString());//原购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}
                    adjustPrice.AfterPurchasePrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[27].ToString());//现购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}

                    al.Add(adjustPrice);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得调价信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 获得update或者insert库存表的传入参数数组
        /// </summary>
        /// <param name="adjustPrice">库存类</param>
        /// <returns>字符串数组 失败返回null</returns>
        private string[] myGetParmAdjustPriceInfo(Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice)
        {

            string[] strParm ={   
								 adjustPrice.ID,                        //0 调价单号
								 adjustPrice.SerialNO.ToString(),           //1 调价单内序号
								 adjustPrice.StockDept.ID,                       //2 库房编码  
								 adjustPrice.Item.ID,                       //3 药品编码
								 adjustPrice.Item.Type.ID,                  //4 药品类别
								 adjustPrice.Item.Quality.ID.ToString(),    //5 药品性质
								 adjustPrice.Item.PriceCollection.RetailPrice.ToString(),   //6 调价前零售价格
								 adjustPrice.Item.PriceCollection.WholeSalePrice.ToString(),//7 调价前批发价格
								 adjustPrice.AfterRetailPrice.ToString(),   //8 调价后零售价格
								 adjustPrice.AfterWholesalePrice.ToString(),//9 调价后批发价格
								 adjustPrice.ProfitFlag,                    //10盈亏标记1-盈，0-亏
								 adjustPrice.InureTime.ToString() ,         //11调价执行时间
								 adjustPrice.Item.Name,                     //12药品商品名
								 adjustPrice.Item.Specs,                    //13规格
								 adjustPrice.Item.Product.Producer.ID,              //14生产厂家
								 adjustPrice.Item.PackUnit,                 //15包装单位
								 adjustPrice.Item.PackQty.ToString(),       //16包装数
								 adjustPrice.Item.MinUnit,                  //17最小单位
								 adjustPrice.State,                         //18调价单状态：0、未调价；1、已调价；2、无效
								 adjustPrice.FileNO,                        //19招标文件号
								 adjustPrice.Memo ,                         //20备注
								 adjustPrice.Operation.Oper.ID,                      //21操作员编码
								 adjustPrice.Operation.Oper.Name,                      //22操作员名称
								 adjustPrice.Operation.Oper.OperTime.ToString(),            //23操作时间
                                 NConvert.ToInt32(adjustPrice.IsDDAdjust).ToString(),
                                 NConvert.ToInt32(adjustPrice.IsDSAdjust).ToString(),
                                 adjustPrice.Item.PriceCollection.PurchasePrice.ToString(),//原购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}
                                 adjustPrice.AfterPurchasePrice.ToString()//现购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}
							 };
            return strParm;
        }

        /// <summary>
        /// 获得update或者insert库存表的传入参数数组 操作调价明细表
        /// </summary>
        /// <param name="adjustPrice">调价实体</param>
        /// <returns>字符串数组 失败返回null</returns>
        private string[] myGetParmAdjustPriceDetail(Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice)
        {
            string[] strParm ={   
								 adjustPrice.ID,							//0 调价单号
								 adjustPrice.SerialNO.ToString(),           //1 调价单内序号
								 adjustPrice.StockDept.ID,                       //2 库房编码  
								 adjustPrice.Item.ID,                       //3 药品编码
								 adjustPrice.Item.Name,                     //4 药品商品名
								 adjustPrice.Item.Type.ID,                  //5 药品类别
								 adjustPrice.Item.Quality.ID.ToString(),    //6 药品性质
								 adjustPrice.Item.Specs,                    //7 规格
								 adjustPrice.Item.Product.Producer.ID,              //8 生产厂家
								 adjustPrice.Item.PackUnit,                 //9 包装单位
								 adjustPrice.Item.PackQty.ToString(),       //10包装数
								 adjustPrice.Item.MinUnit,                  //11最小单位
								 adjustPrice.Item.PriceCollection.RetailPrice.ToString(),   //12调价前零售价格
								 adjustPrice.Item.PriceCollection.WholeSalePrice.ToString(),//13调价前批发价格
								 adjustPrice.AfterRetailPrice.ToString(),   //14调价后零售价格
								 adjustPrice.AfterWholesalePrice.ToString(),//15调价后批发价格
								 adjustPrice.StoreQty.ToString(),			//16调价时库存量
								 adjustPrice.ProfitFlag,                    //17盈亏标记1-盈，0-亏
								 adjustPrice.InureTime.ToString() ,         //18调价执行时间								 
								 adjustPrice.State,                         //19调价单状态：0、未调价；1、已调价；2、无效
								 adjustPrice.Operation.Oper.ID,                      //20操作员编码
								 adjustPrice.Operation.Oper.OperTime.ToString(),           //21操作时间
								 adjustPrice.Memo							//22备注
							 };
            return strParm;
        }

        #endregion

        #endregion

        #region 配药属性操作

        #region 外部接口

        /// <summary>
        /// 获取药品配药属性
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="doseCode">剂型编码</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回配药属性 0 不可拆分 1 可拆分不取整 2 可拆分上取整，失败返回NULL</returns>
        public string GetDrugProperty(string drugCode, string doseCode, string deptCode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDrugProperty", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugProperty字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, drugCode, doseCode, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetDrugProperty:" + ex.Message;
                return null;
            }

            try
            {
                //执行查询语句
                if (this.ExecQuery(strSQL) == -1)
                {
                    this.Err = "获得配药属性信息时，执行SQL语句出错！" + this.Err;
                    this.ErrCode = "-1";
                    return null;
                }
                string drugProperty = "";
                if (this.Reader.Read())
                {
                    drugProperty = this.Reader[0].ToString();
                }
                else
                {
                    drugProperty = "0";
                }

                return drugProperty;
            }
            catch (Exception ex)
            {
                this.Err = "执行Sql语句 获取配药属性发生错误" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 取所有配药属性数据列表
        /// </summary>
        /// <returns>成功返回所有配药属性信息 失败返回null</returns>
        public ArrayList QueryDrugProperty()
        {
            string strSQL = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDrugPropertyAll", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugPropertyAll字段!";
                return null;
            }

            //取调价数据
            return this.myGetDrugPropertyinfo(strSQL);
        }

        #endregion

        #region 基础增、删、改操作

        /// <summary>
        /// 获得update或者insert的传入参数数组
        /// </summary>
        /// <param name="drugProperty">配药属性信息</param>
        /// <returns>返回参数列表</returns>
        private string[] myGetParmDrugProperty(Neusoft.FrameWork.Models.NeuObject drugProperty)
        {
            string[] strParm = {
								   drugProperty.ID,         //0 项目编码  
								   drugProperty.Name,		//1 项目名称
								   drugProperty.Memo,		//2 类型 0 药品 1 剂型
								   drugProperty.User01,		//3 拆分状态
								   drugProperty.User02,		//4 部门编码 "AAAA"为全院
								   this.Operator.ID			//5 操作员
							   };
            return strParm;
        }

        /// <summary>
        /// 取已设置的配药属性列表
        /// </summary>
        /// <param name="SQLString">执行sql语句</param>
        /// <returns>成功返回配药属性信息 失败返回null</returns>
        private ArrayList myGetDrugPropertyinfo(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject drugProperty; //配药属性实体

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得配药属性信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    drugProperty = new Neusoft.FrameWork.Models.NeuObject();
                    drugProperty.ID = this.Reader[1].ToString();                                    //0 类别编码 (药品/剂型)
                    drugProperty.Name = this.Reader[2].ToString();									//1 类别名称 (药品/剂型)
                    drugProperty.Memo = this.Reader[4].ToString();									//2 类型
                    drugProperty.User01 = this.Reader[3].ToString();								//3 拆分属性
                    drugProperty.User02 = this.Reader[0].ToString();								//4 部门编码
                    this.ProgressBarValue++;
                    al.Add(drugProperty);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得配药属性信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 向配药属性表内插入一条数据
        /// </summary>
        /// <param name="drugProperty">配药属性实体</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertDrugProperty(Neusoft.FrameWork.Models.NeuObject drugProperty)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertDrugProperty", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertDrugProperty字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmDrugProperty(drugProperty);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "插入配药信息SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除配药属性记录
        /// </summary>
        /// <param name="type">类型 0 药品 1 剂型 A 所有类别</param>
        /// <param name="itemCode">项目编码(药品/剂型) A 所有项目</param>
        /// <param name="deptCode">库房编码 A 所有库房</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int DeleteDrugProperty(string type, string itemCode, string deptCode)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.DeleteDrugProperty", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteDrugProperty字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, type, itemCode, deptCode);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "删除配药信息SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #endregion

        #region  盘点操作

        #region 基础增、删、改操作

        /// <summary>
        /// 获得对盘点明细表进行update或insert操作的传入参数数组
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>成功返回参数数组，失败返回null</returns>
        private string[] myGetParmForCheckDetail(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            try
            {
                string[] parm = {
									checkInfo.ID,				//0 盘点流水号
									checkInfo.CheckNO,		//1 盘点单号
									checkInfo.StockDept.ID,			//2 库房编码 0 为全部部门
									checkInfo.Item.ID,			//3 药品编码
									checkInfo.BatchNO,			//4 批号
									checkInfo.Item.Name,		//5 商品名称
									checkInfo.Item.Specs,		//6 药品规格
									checkInfo.Item.PriceCollection.RetailPrice.ToString(),	//7 零售价
									checkInfo.Item.PriceCollection.WholeSalePrice.ToString(),//8 批发价
									checkInfo.Item.PriceCollection.PurchasePrice.ToString(),//9 购入价
									checkInfo.Item.Type.ID.ToString(),		//10 药品类别
									checkInfo.Item.Quality.ID.ToString(),	//11 药品性质
									checkInfo.Item.MinUnit,					//12 最小单位
									checkInfo.Item.PackUnit,				//13 包装单位
									checkInfo.Item.PackQty.ToString(),		//14 包装数量
									checkInfo.PlaceNO,					//15 货位号
									checkInfo.ValidTime.ToString(),			//16 有效期
									checkInfo.Producer.ID,					//17 生产厂家
									checkInfo.FStoreQty.ToString(),			//18 封帐盘存数量
									checkInfo.AdjustQty.ToString(),			//19 实际盘存数量
									checkInfo.CStoreQty.ToString(),			//20 结存盘存数量
									checkInfo.MinQty.ToString(),			//21 最小数量
									checkInfo.PackQty.ToString(),			//22 包装数量
									checkInfo.ProfitStatic,					//23 盈亏状态
									checkInfo.QualityFlag,					//24 药品质量情况
									NConvert.ToInt32(checkInfo.IsAdd).ToString(),						//25 是否附加药品
									checkInfo.DisposeWay,					//26 处理方式
									checkInfo.State,					//27 盘点状态 0 封帐 1 结存 2 取消
									checkInfo.Operation.Oper.ID,						//28 操作员
									checkInfo.Operation.Oper.OperTime.ToString(),			//29 操作时间
									checkInfo.ProfitLossQty.ToString()		//30 盈亏数量		
								
								};
                return parm;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获得盘点详细信息
        /// </summary>
        /// <param name="SQLString">查询的SQL语句</param>
        /// <returns>成功返回盘点实体数组，失败返回null</returns>
        private ArrayList myGetCheckDetailInfo(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Check checkInfo;		//盘点实体

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得盘点明细信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    checkInfo = new Check();
                    checkInfo.ID = this.Reader[0].ToString();					//0 盘点流水号
                    checkInfo.CheckNO = this.Reader[1].ToString();			//1 盘点单号
                    checkInfo.StockDept.ID = this.Reader[2].ToString();				//2 库房编码
                    checkInfo.Item.ID = this.Reader[3].ToString();				//3 药品编码
                    checkInfo.BatchNO = this.Reader[4].ToString();				//4 批号
                    checkInfo.Item.Name = this.Reader[5].ToString();			//5 商品名称
                    checkInfo.Item.Specs = this.Reader[6].ToString();			//6 药品规格
                    checkInfo.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[7].ToString());		//7 零售价
                    checkInfo.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[8].ToString());	//8 批发价
                    checkInfo.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[9].ToString());		//9 购入价
                    checkInfo.Item.Type.ID = this.Reader[10].ToString();						//10 药品类别
                    checkInfo.Item.Quality.ID = this.Reader[11].ToString();						//11 药品性质
                    checkInfo.Item.MinUnit = this.Reader[12].ToString();						//12 最小单位
                    checkInfo.Item.PackUnit = this.Reader[13].ToString();						//13 包装单位
                    checkInfo.Item.PackQty = NConvert.ToDecimal(this.Reader[14].ToString());	//14 包装数量
                    checkInfo.PlaceNO = this.Reader[15].ToString();							//15 货位号
                    checkInfo.ValidTime = NConvert.ToDateTime(this.Reader[16].ToString());		//16 有效期
                    checkInfo.Producer.ID = this.Reader[17].ToString();							//17 生产厂家
                    checkInfo.FStoreQty = NConvert.ToDecimal(this.Reader[18].ToString());		//18 封帐盘存数量
                    checkInfo.AdjustQty = NConvert.ToDecimal(this.Reader[19].ToString());		//19 实际盘存数量
                    checkInfo.CStoreQty = NConvert.ToDecimal(this.Reader[20].ToString());		//20 结存盘存数量
                    checkInfo.MinQty = NConvert.ToDecimal(this.Reader[21].ToString());			//21 最小数量
                    checkInfo.PackQty = NConvert.ToDecimal(this.Reader[22].ToString());			//22 包装数量
                    checkInfo.ProfitStatic = this.Reader[23].ToString();						//23 盈亏状态
                    checkInfo.QualityFlag = this.Reader[24].ToString();							//24 药品质量情况
                    checkInfo.IsAdd = NConvert.ToBoolean(this.Reader[25].ToString());								//25 是否附加药品 0 不附加 1 附加 
                    checkInfo.DisposeWay = this.Reader[26].ToString();							//26 处理方式
                    checkInfo.State = this.Reader[27].ToString();							//27 盘点状态 0 封帐 1 结存 2 取消
                    checkInfo.Operation.Oper.ID = this.Reader[28].ToString();							//28 操作员
                    checkInfo.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[29].ToString());		//29 操作时间
                    checkInfo.ProfitLossQty = NConvert.ToDecimal(this.Reader[30].ToString());	//30 盈亏数量

                    al.Add(checkInfo);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点明细信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 获得对盘点统计表进行update或insert操作的传入参数数组
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>成功返回参数数组，失败返回null</returns>
        private string[] myGetParmForCheckStatic(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            try
            {
                string[] strParm = {
									   checkInfo.CheckNO,				        //0 盘点单号
                                       checkInfo.CheckName,                     //1 盘点单名称
									   checkInfo.StockDept.ID,					//2 库存单位编码
									   checkInfo.State,				            //3 盘点状态 0 封帐 1 结存 2 取消
									   checkInfo.FOper.ID,				        //4 封帐人
									   checkInfo.FOper.OperTime.ToString(),		//5 封帐时间
									   checkInfo.COper.ID,				        //6 结存人
									   checkInfo.COper.OperTime.ToString(),		//7 结存时间
									   checkInfo.User01,					    //8 盘亏金额
									   checkInfo.User02,					    //9 盘盈金额
									   checkInfo.Operation.ID,					//10 操作员
									   checkInfo.Operation.Oper.OperTime.ToString()		//11 操作时间
								   };
                return strParm;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获得盘点统计信息
        /// </summary>
        /// <param name="SQLString">查询的SQL语句</param>
        /// <returns>成功返回盘点实体数组，失败返回null</returns>
        private ArrayList myGetCheckStaticInfo(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Check checkInfo;		//盘点实体
            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得盘点统计信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    checkInfo = new Check();
                    checkInfo.CheckNO = this.Reader[0].ToString();							        //0 盘点单号
                    checkInfo.CheckName = this.Reader[1].ToString();                                    //1 盘点单名称
                    checkInfo.StockDept.ID = this.Reader[2].ToString();								//2 库存单位编码
                    checkInfo.State = this.Reader[3].ToString();							            //3 盘点状态 0 封帐 1 结存 2 取消
                    checkInfo.FOper.ID = this.Reader[4].ToString();							        //4 封帐人
                    checkInfo.FOper.OperTime = NConvert.ToDateTime(this.Reader[5].ToString());		//5 封帐时间
                    checkInfo.COper.ID = this.Reader[6].ToString();							        //6 结存人
                    checkInfo.COper.OperTime = NConvert.ToDateTime(this.Reader[7].ToString());		//7 结存时间
                    checkInfo.User01 = this.Reader[8].ToString();								    //8 盘亏金额
                    checkInfo.User02 = this.Reader[9].ToString();								    //9 盘盈金额
                    checkInfo.Operation.Oper.ID = this.Reader[10].ToString();								        //10 操作员
                    checkInfo.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[11].ToString());		//11 操作时间

                    al.Add(checkInfo);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点统计信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 获得对盘点批次表进行update或insert操作的传入参数数组
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>成功返回参数数组，失败返回null</returns>
        private string[] myGetParmForCheckBatch(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            try
            {
                string[] parm = {
									checkInfo.ID,				  //0 盘点流水号
									checkInfo.GroupNO.ToString(), //1 批次
									checkInfo.CheckNO,		//2 盘点单号
									checkInfo.StockDept.ID,			//3 库房编码 0 为全部部门
									checkInfo.Item.ID,			//4 药品编码
									checkInfo.BatchNO,			//5 批号
									checkInfo.Item.Name,		//6 商品名称
									checkInfo.Item.Specs,		//7 药品规格
									checkInfo.Item.PriceCollection.RetailPrice.ToString(),		//8 零售价
									checkInfo.Item.PriceCollection.WholeSalePrice.ToString(),		//9 批发价
									checkInfo.Item.PriceCollection.PurchasePrice.ToString(),		//10 购入价
									checkInfo.Item.Type.ID,					//11 药品类别
									checkInfo.Item.Quality.ID.ToString(),	//12 药品性质
									checkInfo.Item.MinUnit,					//13 最小单位
									checkInfo.Item.PackUnit,				//14 包装单位
									checkInfo.Item.PackQty.ToString(),		//15 包装数量
									checkInfo.PlaceNO,					//16 货位号
									checkInfo.ValidTime.ToString(),			//17 有效期
									checkInfo.Producer.ID,					//18 生产厂家
									checkInfo.ProfitLossQty.ToString(),		//19 盈亏数量
									checkInfo.ProfitStatic,					//20 盈亏状态
									checkInfo.QualityFlag,					//21 药品质量情况
									checkInfo.DisposeWay,					//22 处理方式
									checkInfo.State,					//23 盘点状态 0 封帐 1 结存 2 取消
									checkInfo.Operation.Oper.ID,						//24 操作员
									checkInfo.Operation.Oper.OperTime.ToString()			//25 操作时间							
								
								};
                return parm;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获得盘点批次信息
        /// </summary>
        /// <param name="SQLString">查询的SQL语句</param>
        /// <returns>成功返回盘点实体数组，失败返回null</returns>
        private ArrayList myGetCheckBatchInfo(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Check checkInfo;		//盘点实体

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得盘点批次信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    checkInfo = new Check();
                    checkInfo.ID = this.Reader[0].ToString();					//0 盘点流水号
                    checkInfo.GroupNO = NConvert.ToDecimal(this.Reader[1].ToString());	//1 批次号
                    checkInfo.CheckNO = this.Reader[2].ToString();			//2 盘点单号
                    checkInfo.StockDept.ID = this.Reader[3].ToString();				//3 库房编码
                    checkInfo.Item.ID = this.Reader[4].ToString();				//4 药品编码
                    checkInfo.BatchNO = this.Reader[5].ToString();				//5 批号
                    checkInfo.Item.Name = this.Reader[6].ToString();			//6 商品名称
                    checkInfo.Item.Specs = this.Reader[7].ToString();			//7 药品规格
                    checkInfo.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString());		//8 零售价
                    checkInfo.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[9].ToString());	//9 批发价
                    checkInfo.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[10].ToString());	//10 购入价
                    checkInfo.Item.Type.ID = this.Reader[11].ToString();						//11 药品类别
                    checkInfo.Item.Quality.ID = this.Reader[12].ToString();						//12 药品性质
                    checkInfo.Item.MinUnit = this.Reader[13].ToString();						//13 最小单位
                    checkInfo.Item.PackUnit = this.Reader[14].ToString();						//14 包装单位
                    checkInfo.Item.PackQty = NConvert.ToDecimal(this.Reader[15].ToString());	//15 包装数量
                    checkInfo.PlaceNO = this.Reader[16].ToString();							//16 货位号
                    checkInfo.ValidTime = NConvert.ToDateTime(this.Reader[17].ToString());		//17 有效期
                    checkInfo.Producer.ID = this.Reader[18].ToString();							//18 生产厂家
                    checkInfo.ProfitLossQty = NConvert.ToDecimal(this.Reader[19].ToString());	//19 盈亏数量
                    checkInfo.ProfitStatic = this.Reader[20].ToString();						//20 盈亏状态
                    checkInfo.QualityFlag = this.Reader[21].ToString();							//21 药品质量情况
                    checkInfo.DisposeWay = this.Reader[22].ToString();							//22 处理方式
                    checkInfo.State = this.Reader[23].ToString();							//23 盘点状态 0 封帐 1 结存 2 取消
                    checkInfo.Operation.Oper.ID = this.Reader[24].ToString();							//24 操作员
                    checkInfo.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[25].ToString());		//25 操作时间	

                    al.Add(checkInfo);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点批次信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 获得对盘点附加表进行update或insert操作的传入参数数组
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>成功返回参数数组，失败返回null</returns>
        private string[] myGetParmForCheckAdd(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            try
            {
                string[] parm = {
									checkInfo.PlaceNO,			//0 库位号
									checkInfo.StockDept.ID,				//1 库房编码
									checkInfo.Item.ID,				//2 药品编码
									checkInfo.BatchNO,				//3 批号 如为'ALL'则为所有批号的药品
									checkInfo.Operation.Oper.ID,				//4 操作员编码
									checkInfo.Operation.Oper.OperTime.ToString()	//5 操作时间
								};
                return parm;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获得盘点附加信息
        /// </summary>
        /// <param name="SQLString">查询的SQL语句</param>
        /// <returns>成功返回盘点实体数组，失败返回null</returns>
        private ArrayList myGetCheckAddInfo(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Check checkInfo;		//盘点实体

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得盘点附加信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    checkInfo = new Check();
                    checkInfo.PlaceNO = this.Reader[0].ToString();						//0 库位号
                    checkInfo.StockDept.ID = this.Reader[1].ToString();							//1 库房编码
                    checkInfo.Item.ID = this.Reader[2].ToString();							//2 药品编码
                    checkInfo.BatchNO = this.Reader[3].ToString();							//3 批号 如为'ALL'则为所有批号的药品
                    checkInfo.Operation.Oper.ID = this.Reader[4].ToString();							//4 操作员编码
                    checkInfo.Operation.Oper.OperTime = NConvert.ToDateTime(this.Reader[5].ToString());	//5 操作时间

                    al.Add(checkInfo);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点批次信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 向盘点附加表内插入一条数据
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>0 没有更新 1 成功 －1 失败</returns>
        public int InsertCheckAdd(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.InsertCheckAdd", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertCheckAdd字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmForCheckAdd(checkInfo);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.InsertCheckAdd:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对盘点附加表进行更新
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>0 没有更新 1 成功 －1 失败</returns>
        public int UpdateCheckAdd(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCheckAdd", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateCheckAdd字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmForCheckAdd(checkInfo);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateCheckAdd:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对药品附加信息删除一条记录
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugCode">药品编码 'ALL'时对所有药品执行删除</param>
        /// <returns>成功返回1 失败返回－1，无更新返回0</returns>
        public int DeleteCheckAdd(string deptCode, string drugCode)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteCheckAdd", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteCheckAdd字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, drugCode);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DeleteCheckAdd:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除科室全部附加药品信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <returns>成功返回1 失败返回－1，无更新返回0</returns>
        public int DeleteCheckAdd(string deptCode)
        {
            return this.DeleteCheckAdd(deptCode, "ALL");
        }

        /// <summary>
        /// 向盘点统计表内插入一条数据
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>0 没有更新 1 成功 －1 失败</returns>
        public int InsertCheckStatic(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.InsertCheckStatic", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertCheckStatic字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmForCheckStatic(checkInfo);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.InsertCheckStatic:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新盘点统计表
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>0没有更新 1 成功 －1 失败</returns>
        public int UpdateCheckStatic(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCheckStatic", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateCheckStatic字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmForCheckStatic(checkInfo);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateCheckStatic:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 向盘点明细表内插入一条数据
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>0 没有更新 1 成功 －1 失败</returns>
        public int InsertCheckDetail(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.InsertCheckDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertCheckDetail字段!";
                return -1;
            }
            try
            {
                //取流水号
                checkInfo.ID = this.GetSequence("Pharmacy.Item.GetCheckNo");
                string[] strParm = this.myGetParmForCheckDetail(checkInfo);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.InsertCheckDetail:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新盘点明细表
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>0 没有更新 1 成功 －1 失败</returns>
        public int UpdateCheckDetail(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCheckDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateCheckDetail字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmForCheckDetail(checkInfo);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateCheckDetail:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对盘点明细记录进行删除
        /// </summary>
        /// <param name="checkNo">盘点流水号</param>
        /// <returns>0 没有更新 1 成功 －1 失败</returns>
        public int DeleteCheckDetail(string checkNo)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteCheckDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteCheckDetail字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, checkNo);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DeleteCheckDetail:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 向盘点批次表内插入数据
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>0 没有更新 1 成功 －1 失败</returns>
        public int InsertCheckBatch(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.InsertCheckBatch", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertCheckBatch字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmForCheckBatch(checkInfo);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.InsertCheckBatch:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 内部使用

        /// <summary>
        /// 获得盘点单号
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <returns>成功返回盘点单号四位年+两位月+三位流水号,失败返回null</returns>
        public string GetCheckCode(string deptCode)
        {
            string strSQL = "";
            string temp1, temp2;
            string newCheckCode;
            //系统时间 yyyymm
            temp1 = this.GetSysDateNoBar().Substring(0, 6);
            //取最大入库计划单号
            if (this.Sql.GetSql("Pharmacy.Item.GetMaxCheckCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetMaxCheckCode字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetMaxCheckCode:" + ex.Message;
                return null;
            }

            temp2 = this.ExecSqlReturnOne(strSQL);
            if (temp2.ToString() == "-1" || temp2.ToString() == "")
            {
                temp2 = "001";
            }
            else
            {
                decimal i = NConvert.ToDecimal(temp2.Substring(6, 3)) + 1;
                temp2 = i.ToString().PadLeft(3, '0');
            }
            newCheckCode = temp1 + temp2;

            return newCheckCode;
        }

        /// <summary>
        /// 更新盘点状态
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <param name="checkState">盘点状态</param>
        /// <returns>失败返回－1 没有更新返回0 成功返回1</returns>
        public int UpdateCheckDetailForState(string deptCode, string checkCode, string checkState)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCheckDetailForState", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateCheckDetailForState字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, checkCode, checkState, this.Operator.ID);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateCheckDetailForState:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);

        }

        /// <summary>
        /// 更新盘点状态
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <param name="checkState">盘点状态</param>
        /// <returns>失败返回－1 没有更新返回0 成功返回1</returns>
        public int UpdateCheckStaticForState(string deptCode, string checkCode, string checkState)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCheckStaticForState", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateCheckStaticForState字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, checkCode, checkState, this.Operator.ID);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateCheckStaticForState:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);

        }

        /// <summary>
        /// 盘点单列表名称更新
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <param name="newCheckListName">新盘点单名称</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateCheckListName(string deptCode, string checkCode, string newCheckListName)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCheckListName", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateCheckListName字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, checkCode, deptCode, newCheckListName, this.Operator.ID);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateCheckListName:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 获得盘点附加信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <returns>成功返回动态数组，失败返回null</returns>
        public ArrayList QueryCheckAddByDept(string deptCode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetCheckAdd", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetCheckAdd字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetCheckAddByDept", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetCheckAddByDept字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckAddByDept:" + ex.Message;
                return null;
            }

            //取盘点详细信息数据
            return this.myGetCheckAddInfo(strSQL);
        }

        /// <summary>
        /// 获取盘点单列表，如不限制封帐人则传为"ALL"
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkState">盘点状态</param>
        /// <param name="fOperCode">封帐人</param>
        /// <returns>Check实体</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Check> QueryCheckList(string deptCode, string checkState, string fOperCode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetCheckList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetCheckList字段!";
                return null;
            }
            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptCode, checkState, fOperCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckList:" + ex.Message;
                return null;
            }

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得盘点列表信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            //将返回数据加入动态数组
            Neusoft.HISFC.Models.Pharmacy.Check check;
            List<Neusoft.HISFC.Models.Pharmacy.Check> alList = new List<Check>();

            try
            {
                while (this.Reader.Read())
                {
                    //此语句不能加到循环外面，否则会在al数组内加入相同的数据（最后一条数据）
                    check = new Check();
                    check.CheckNO = this.Reader[0].ToString();                   //盘点单号
                    check.CheckName = this.Reader[1].ToString();                    //盘点单名称
                    check.FOper.ID = this.Reader[2].ToString();                  //封帐人
                    check.FOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[3]);            //封帐时间

                    alList.Add(check);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点列表息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return alList;

        }

        /// <summary>
        /// 获取盘点详细信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回动态数组，失败返回null</returns>
        public ArrayList QueryCheckDetailByCheckCode(string deptCode, string checkCode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetCheckDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetCheckDetail字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetCheckDetailByCheckCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetCheckDetailByCheckCode字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptCode, checkCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckDetailByCheckCode:" + ex.Message;
                return null;
            }

            //取盘点详细信息数据
            return this.myGetCheckDetailInfo(strSQL);
        }

        /// <summary>
        /// 根据科室编码与盘点单号 获取盘点统计信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="checkNO"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Pharmacy.Check GetCheckStat(string deptCode, string checkNO)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetCheckStat", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetCheckStat字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetCheckStatByCheckCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetCheckStatByCheckCode字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptCode, checkNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckStatByCheckCode:" + ex.Message;
                return null;
            }

            //取盘点统计信息数据
            ArrayList alList = this.myGetCheckStaticInfo(strSQL);
            if (alList == null)
                return null;
            if (alList.Count > 0)
                return alList[0] as Neusoft.HISFC.Models.Pharmacy.Check;
            else
                return new Check();
        }

        /// <summary>
        /// 获取所有指定盘点单状态的盘点单列表
        /// </summary>
        /// <param name="checkState">盘点单状态</param>
        /// <returns>返回neuobject数组 ID 盘点单号 Name 封帐人-盘点科室 Memo封帐时间 User01 盘点科室</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryCheckList(string checkState)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetCheckList.State", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetCheckList.State字段!";
                return null;
            }
            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, checkState);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckList.State:" + ex.Message;
                return null;
            }
            //将返回数据加入动态数组
            Neusoft.FrameWork.Models.NeuObject info;
            List<Neusoft.FrameWork.Models.NeuObject> al = new List<Neusoft.FrameWork.Models.NeuObject>();
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得盘点列表信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();            //盘点单号
                    info.Name = this.Reader[1].ToString();          //封帐人
                    info.Memo = this.Reader[2].ToString();          //封帐时间
                    info.User01 = this.Reader[3].ToString();		//科室
                    info.Name = info.Name + "-" + info.User01;
                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点列表息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 判断对某药品进行封帐时 是否仍存在有效的盘点记录
        /// </summary>
        /// <param name="drugNO">药品编码</param>
        /// <param name="deptNO">科室编码</param>
        /// <param name="checkState">需检查的盘点单状态</param>
        /// <param name="checkID">盘点记录流水号 不对自身记录进行判断</param>
        /// <returns>仍存在盘点记录返回True 否则返回False</returns>
        public bool JudgeCheckState(string drugNO, string deptNO, string checkState, string checkID)
        {
            /*            
             *  select t.check_code
                from   pha_com_checkdetail t
                where  t.drug_code = '{0}'
                and    t.drug_dept_code = '{1}'
                and    t.check_state = '{2}'
            */
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.JudgeCheckState", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.JudgeCheckState字段!";
                return false;
            }
            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, drugNO, deptNO, checkState, checkID);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.JudgeCheckState:" + ex.Message;
                return false;
            }

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "判断药品盘点执行情况时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return false;
            }
            try
            {
                while (this.Reader.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点列表息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return false;
            }
            finally
            {
                this.Reader.Close();
            }
            return false;
        }

        /// <summary>
        /// 封帐数量更新
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <param name="drugNO">药品编码</param>
        /// <param name="fstoreNum">封帐数量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateFStoreNum(string deptCode, string checkCode, string drugNO, decimal fstoreNum)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql( "Pharmacy.Item.UpdateFStoreNum", ref strSQL ) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateFStoreNum字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format( strSQL, deptCode, checkCode, drugNO, fstoreNum.ToString() );            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateFStoreNum:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery( strSQL );
        }

        #region  {F2DA66B0-0AB4-4656-BB21-97CB731ABA4D}  盘点期间入出库数据校验控制

        /// <summary>
        /// 计算从起始时间至当前时间的入出库总量
        /// 
        /// </summary>
        /// <param name="drugDeptCode">科室编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="beginDate">查询起始时间</param>
        /// <returns>成功返回1</returns>
        public int ComputeInOutQty(string drugDeptCode, string drugCode, DateTime beginDate,out decimal inoutQty)
        {
            inoutQty = 0;

            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql( "Pharmacy.Item.ComputeInOutQty", ref strSQL ) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.ComputeInOutQty字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format( strSQL, drugDeptCode, drugCode, beginDate.ToString() );            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.ComputeInOutQty:" + ex.Message;
                return -1;
            }

            string result = "";
            //执行查询语句
            if (this.ExecQuery( strSQL ) == -1)
            {
                this.Err = "判断药品盘点执行情况时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return -1;
            }
            try
            {
                if (this.Reader.Read())
                {
                    result = this.Reader[0].ToString();
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点列表息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }

            inoutQty = NConvert.ToDecimal( result );

            return 1;
        }

        /// <summary>
        /// 获取入出库明细
        /// </summary>
        /// <param name="drugDeptCode">科室编码</param>
        /// <param name="deptCode">药品编码</param>
        /// <param name="beginDate">查询起始时间</param>
        /// <returns>成功返回入出库明细数据 失败返回null</returns>
        public System.Data.DataSet ComputeInOutDetailForCheck(string drugDeptCode, string drugCode, DateTime beginDate)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql( "Pharmacy.Item.ComputeInOutDetailForCheck", ref strSQL ) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.ComputeInOutDetailForCheck字段!";
                return null;
            }
            try
            {
                strSQL = string.Format( strSQL, drugDeptCode, drugCode, beginDate.ToString() );            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.ComputeInOutDetailForCheck:" + ex.Message;
                return null;
            }

            System.Data.DataSet ds = new System.Data.DataSet();

            if (this.ExecQuery( strSQL, ref ds ) == -1)
            {
                return null;
            }
            return ds;
        }

        #endregion

        #endregion

        #region 盘点封帐 可按不同方式进行封帐处理

        /// <summary>
        /// 按照药品类别、性质进行封帐处理,更新盘点明细表
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugType">药品类别</param>
        /// <param name="isBatch">是否按批号盘点</param>
        /// <param name="isCheckZeroStock">是否对库存为零药品进行封帐处理</param>
        /// <param name="isCheckStopDrug">是否对本库房停用药品进行封帐处理</param>   
        /// <returns>成功返回封帐数组，失败返回null</returns>
        public ArrayList CheckCloseByTypeQuality(string deptCode, string drugType, string drugQuality, bool isBatch, bool isCheckZeroStock, bool isCheckStopDrug)
        {
            #region 查找Sql语句
            string strSQL = "";
            //取查找库存的SELECT语句
            if (isBatch)
            {	//按批号盘点 按照批号获取列表
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByTypeBatch", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByTypeBatch字段!";
                    return null;
                }
            }
            else
            {	//不按批号盘点 由StockInfo获取 汇总信息 设置有效期为4000-01-01
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByType", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByType字段!";
                    return null;
                }
            }
            try
            {
                if (isCheckStopDrug)            //对停用药品进行封帐处理
                {
                    strSQL = string.Format(strSQL, deptCode, drugType, drugQuality, "A");
                }
                else                           //只对有效药品进行封帐
                {
                    strSQL = string.Format(strSQL, deptCode, drugType, drugQuality, '1');
                }
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckCloseByType:" + ex.Message;
                return null;
            }
            #endregion

            #region Sql语句执行 获取需盘点信息
            ArrayList al = new ArrayList();				//用于库存信息的存储
            Neusoft.FrameWork.Models.NeuObject storageInfo;	//用于存储返回的库存查询信息
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得库房库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    storageInfo = new Neusoft.FrameWork.Models.NeuObject();
                    storageInfo.ID = this.Reader[0].ToString();				//药品编码
                    storageInfo.Name = this.Reader[1].ToString();			//库位号
                    storageInfo.Memo = this.Reader[2].ToString();			//有效期
                    storageInfo.User01 = this.Reader[3].ToString();			//批号
                    storageInfo.User02 = this.Reader[4].ToString();			//封帐库存数量
                    al.Add(storageInfo);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得库房库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            #endregion

            DateTime tempdate = this.GetDateTimeFromSysDateTime();
            ArrayList checkAl = new ArrayList();	//用于盘点实体存储
            foreach (Neusoft.FrameWork.Models.NeuObject info in al)
            {
                //如不对库存为零进行封帐则继续
                if (!isCheckZeroStock && NConvert.ToDecimal(info.User02) == 0)
                {
                    continue;
                }

                Neusoft.HISFC.Models.Pharmacy.Item item = this.GetItem(info.ID);		//当前最新药品信息
                if (item == null)
                {
                    this.Err = "药品字典表内无" + info.ID + "信息!请在药品基本信息维护内进行添加";
                    this.ErrCode = "-2";
                    return null;
                }
                if (item.IsStop)                //不对药库停用药品进行盘点处理
                {
                    continue;
                }

                Neusoft.HISFC.Models.Pharmacy.Check checkTemp = new Check();
                checkTemp.StockDept.ID = deptCode;							//库房编码
                checkTemp.State = "0";								//盘点状态 封帐
                checkTemp.FOper.ID = this.Operator.ID;					//封帐人
                checkTemp.FOper.OperTime = tempdate;							//封帐时间
                checkTemp.Operation.Oper.ID = this.Operator.ID;					//操作人
                checkTemp.Operation.Oper.OperTime = tempdate;							//操作时间
                checkTemp.Item = item;									//药品实体
                checkTemp.BatchNO = info.User01;						//药品批号
                checkTemp.FStoreQty = NConvert.ToDecimal(info.User02);	//封帐库存数量
                checkTemp.PlaceNO = info.Name;						//库位号
                checkTemp.ValidTime = NConvert.ToDateTime(info.Memo);	//有效期
                checkTemp.Producer.ID = item.Product.Producer.ID;				//生产厂家
                checkTemp.CStoreQty = 0;								//结存数量 更新为0
                checkTemp.IsAdd = false;									//是否附加药品 对非附加药品数据库内标记为0

                checkAl.Add(checkTemp);
            }
            return checkAl;
        }

        /// <summary>
        /// 对本库房所有药品进行封帐处理，更新盘点明细表
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="isBatch">是否按批号盘点</param>
        /// <param name="isCheckZeroStock">是否对库存为零药品进行封帐处理</param>
        /// <param name="isCheckStopDrug">是否对本库房停用药品进行封帐处理</param>       
        /// <returns>成功返回封帐数组，失败返回null</returns>
        public ArrayList CheckCloseByTotal(string deptCode, bool isBatch, bool isCheckZeroStock, bool isCheckStopDrug)
        {
            #region 获取Sql语句
            string strSQL = "";
            //取查找库存的SELECT语句
            if (isBatch)
            {	//按批号盘点    由库存明细表Storage内获取
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByTotalBatch", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByTotalBatch字段!";
                    return null;
                }
            }
            else
            {	//不按批号盘点  由StockInfo内获取汇总统计量
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByTotal", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByTotal字段!";
                    return null;
                }
            }
            try
            {
                if (isCheckStopDrug)            //对停用药品进行封帐处理
                {
                    strSQL = string.Format(strSQL, deptCode, "A");
                }
                else                           //只对有效药品进行封帐
                {
                    strSQL = string.Format(strSQL, deptCode, '1');
                }
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckCloseByTotal:" + ex.Message;
                return null;
            }
            #endregion

            #region Sql语句执行
            ArrayList al = new ArrayList();			//用于库存信息的存储
            Neusoft.FrameWork.Models.NeuObject storageInfo;	//用于存储返回的库存查询信息
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得库房库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    storageInfo = new Neusoft.FrameWork.Models.NeuObject();
                    storageInfo.ID = this.Reader[0].ToString();				//药品编码
                    storageInfo.Name = this.Reader[1].ToString();			//库位号
                    storageInfo.Memo = this.Reader[2].ToString();			//有效期
                    storageInfo.User01 = this.Reader[3].ToString();			//批号
                    storageInfo.User02 = this.Reader[4].ToString();			//封帐库存数量
                    al.Add(storageInfo);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得库房库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            #endregion

            DateTime tempdate = this.GetDateTimeFromSysDateTime();
            ArrayList checkAl = new ArrayList();	//用于盘点实体存储
            foreach (Neusoft.FrameWork.Models.NeuObject info in al)
            {
                //如不对库存为零进行封帐则继续
                if (!isCheckZeroStock && NConvert.ToDecimal(info.User02) == 0)
                {
                    continue;
                }

                Neusoft.HISFC.Models.Pharmacy.Item item = this.GetItem(info.ID);		//当前最新药品信息
                if (item == null)
                {
                    this.Err = "药品字典表内无" + info.ID + "信息!请在药品基本信息维护内进行添加";
                    this.ErrCode = "-2";
                    return null;
                }
                if (item.IsStop)                //不对药库停用药品进行盘点处理
                {
                    continue;
                }

                Neusoft.HISFC.Models.Pharmacy.Check checkTemp = new Check();
                checkTemp.StockDept.ID = deptCode;							//库房编码
                checkTemp.State = "0";								        //盘点状态 封帐
                checkTemp.FOper.ID = this.Operator.ID;					    //封帐人
                checkTemp.FOper.OperTime = tempdate;						//封帐时间
                checkTemp.Operation.Oper.ID = this.Operator.ID;				//操作人
                checkTemp.Operation.Oper.OperTime = tempdate;				//操作时间
                checkTemp.Item = item;									    //药品实体
                checkTemp.BatchNO = info.User01;						    //药品批号
                checkTemp.FStoreQty = NConvert.ToDecimal(info.User02);	//封帐库存数量
                checkTemp.PlaceNO = info.Name;						        //库位号
                checkTemp.ValidTime = NConvert.ToDateTime(info.Memo);	    //有效期
                checkTemp.Producer.ID = item.Product.Producer.ID;			//生产厂家
                checkTemp.CStoreQty = 0;								    //结存数量 更新为0
                checkTemp.IsAdd = false;									//是否附加药品 对非附加药品数据库内标记为0

                checkAl.Add(checkTemp);
            }
            return checkAl;
        }

        /// <summary>
        /// 由库存内选择单条药品加入盘点
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="isBatch">是否批号管理</param>
        /// <returns>成功返回check实体，失败返回null</returns>
        public Check CheckCloseByDrug(string deptCode, string drugCode, string batchNo, bool isBatch)
        {
            #region 获取Sql语句
            string strSQL = "";
            //取查找库存的SELECT语句
            if (isBatch)
            {	//按批号盘点 由Storage内获取批号信息
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByDrugBatch", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByDrugBatch字段!";
                    return null;
                }
            }
            else
            {	//不按批号盘点 由StockInfo获取汇总后信息 
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByDrug", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByDrug字段!";
                    return null;
                }
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, drugCode, batchNo);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckCloseByDrug:" + ex.Message;
                return null;
            }
            #endregion

            #region Sql语句执行
            ArrayList al = new ArrayList();			//用于库存信息的存储
            Neusoft.FrameWork.Models.NeuObject storageInfo;	//用于存储返回的库存查询信息
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得库房库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    storageInfo = new Neusoft.FrameWork.Models.NeuObject();
                    storageInfo.ID = this.Reader[0].ToString();				//药品编码
                    storageInfo.Name = this.Reader[1].ToString();			//库位号
                    storageInfo.Memo = this.Reader[2].ToString();			//有效期
                    storageInfo.User01 = this.Reader[3].ToString();			//批号
                    storageInfo.User02 = this.Reader[4].ToString();			//封帐库存数量
                    al.Add(storageInfo);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得库房库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            if (al.Count == 0)
            {
                this.Err = "该药品无库存！";
                return null;
            }
            #endregion

            Neusoft.HISFC.Models.Pharmacy.Check checkTemp = new Check();
            ArrayList checkAl = new ArrayList();	//用于盘点实体存储
            DateTime tempDate = this.GetDateTimeFromSysDateTime();

            foreach (Neusoft.FrameWork.Models.NeuObject info in al)
            {
                Neusoft.HISFC.Models.Pharmacy.Item item = this.GetItem(info.ID);		//当前最新药品信息
                if (item == null)
                {
                    this.Err = "药品字典表内无" + info.ID + "信息!请在药品基本信息维护内进行添加";
                    this.ErrCode = "-2";
                    return null;
                }
                //对停用药品不进行处理
                if (item.IsStop)
                {
                    this.Err = "  [ " + item.Name + " ]已药库停用";
                    return null;
                }

                checkTemp.StockDept.ID = deptCode;							            //库房编码
                checkTemp.State = "0";								                    //盘点状态 封帐
                checkTemp.FOper.ID = this.Operator.ID;					                //封帐人
                checkTemp.FOper.OperTime = tempDate;                                    //封帐时间
                checkTemp.Operation.Oper.ID = this.Operator.ID;					        //操作人
                checkTemp.Operation.Oper.OperTime = tempDate;	                        //操作时间
                checkTemp.Item = item;									                //药品实体
                checkTemp.BatchNO = info.User01;						                //药品批号
                checkTemp.FStoreQty = NConvert.ToDecimal(info.User02);	            //封帐库存数量
                checkTemp.PlaceNO = info.Name;						                    //库位号
                checkTemp.ValidTime = NConvert.ToDateTime(info.Memo);	                //有效期
                checkTemp.Producer.ID = item.Product.Producer.ID;				        //生产厂家
                checkTemp.CStoreQty = 0;								                //结存数量 更新为0
                checkTemp.IsAdd = false;									            //是否附加药品 对非附加药品数据库内标记为0
            }
            return checkTemp;
        }

        #endregion

        #region 盘点保存 在盘点过程中对盘点明细进行保存

        /// <summary>
        /// 在盘点过程中进行盘点保存，更新结存数量
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1 失败返回－1 无更新返回0</returns>
        public int SaveCheck(string deptCode, string checkCode)
        {
            string strSQL1 = "";
            string strSQL2 = "";
            //取SELECT语句
            //更新盘点数量
            if (this.Sql.GetSql("Pharmacy.Item.SaveCheck", ref strSQL1) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.SaveCheck字段!";
                return -1;
            }
            //更新盘点盈亏标记
            if (this.Sql.GetSql("Pharmacy.Item.SaveCheckForState", ref strSQL2) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.SaveChecForStatek字段!";
                return -1;
            }

            //格式化SQL语句
            try
            {
                strSQL1 = string.Format(strSQL1, deptCode, checkCode);
                strSQL2 = string.Format(strSQL2, deptCode, checkCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.SaveCheck:" + ex.Message;
                return -1;
            }
            int flag = this.ExecNoQuery(strSQL1);
            if (flag == -1)
                return -1;
            else
                if (flag == 0)
                    return 0;
            return this.ExecNoQuery(strSQL2);
        }

        /// <summary>
        /// 增量更新盘点明细表
        /// </summary>
        /// <param name="checkInfo">盘点实体</param>
        /// <returns>0 没有更新 1 成功 －1 失败</returns>
        public int UpdateCheckDetailAddSave(Neusoft.HISFC.Models.Pharmacy.Check checkInfo)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCheckDetail.AddSave", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateCheckDetail.AddSave字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmForCheckDetail(checkInfo);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateCheckDetail.AddSave:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 盘点解封

        /// <summary>
        /// 对盘点进行解封，更新盘点明细、统计表内盘点状态
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int CancelCheck(string deptCode, string checkCode)
        {
            //更新盘点明细表
            int i = this.UpdateCheckDetailForState(deptCode, checkCode, "2");
            if (i == -1 || i == 0) return -1;
            //更新盘点统计表
            int j = this.UpdateCheckStaticForState(deptCode, checkCode, "2");
            if (j == -1 || j == 0) return -1;
            return 1;
        }

        #endregion

        #region 盘点分区保存 －－ 对每个人员输入的盘点量单独保存 可在结存前修改 并进行汇总

        /// <summary>
        /// 形成盘点分区保存权限信息
        /// </summary>
        /// <param name="checkCode"></param>
        /// <param name="drugDeptCode"></param>
        /// <param name="adjustOper"></param>
        /// <returns></returns>
        public int InsertCheckPartitionPriv(Neusoft.HISFC.Models.Pharmacy.Check info, Neusoft.FrameWork.Models.NeuObject adjustOper)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.InsertCheckPartitionPriv", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertCheckPartitionPriv字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, info.CheckNO,
                                              info.CheckName,
                                              info.StockDept.ID,
                                              info.State,
                                              info.FOper.ID,
                                              info.FOper.OperTime.ToString(),
                                              adjustOper.ID,
                                              info.Memo,
                                              info.Operation.Oper.ID,
                                              info.Operation.Oper.OperTime.ToString()
                                         );            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.InsertCheckPartitionPriv:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 盘点信息更新
        /// </summary>
        /// <param name="checkPartition"></param>
        /// <returns></returns>
        public int UpdateCheckPartition(Neusoft.HISFC.Models.Pharmacy.Check checkPartition)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateCheckPartition", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateCheckPartition字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmForCheckDetail(checkPartition);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateCheckPartition:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除盘点分区设置信息
        /// </summary>
        /// <param name="checkDept">盘点科室</param>
        /// <param name="checkCode">盘点单号</param>
        /// <param name="adjustOper">盘点人</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int DeleteCheckPartitonPriv(string checkDept, string checkCode, string adjustOper)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteCheckPartitonPriv", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteCheckPartitonPriv字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, checkCode, checkDept, adjustOper);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DeleteCheckPartitonPriv:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除盘点分区设置信息
        /// </summary>
        /// <param name="checkDept">盘点科室</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int DeleteCheckPartitonPriv(string checkDept, string checkCode)
        {
            return this.DeleteCheckPartitonPriv(checkDept, checkCode, "ALL");
        }

        /// <summary>
        /// 汇总盘点分区信息 形成库存明细汇总
        /// </summary>
        /// <param name="checkCode"></param>
        /// <param name="drugDeptCode"></param>
        /// <returns></returns>
        public int SaveCheckPartitionToCheckDetail(string checkCode, string drugDeptCode)
        {
            string strSQL1 = "";
            string strSQL2 = "";
            //取SELECT语句
            //根据盘点分区录入的结果 更新盘点明细汇总量
            if (this.Sql.GetSql("Pharmacy.Item.SaveCheckPartitionToCheckDetail", ref strSQL1) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.SaveCheckPartitionToCheckDetail字段!";
                return -1;
            }
            //更新盘点盈亏标记
            if (this.Sql.GetSql("Pharmacy.Item.SaveCheckForState", ref strSQL2) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.SaveChecForStatek字段!";
                return -1;
            }

            //格式化SQL语句
            try
            {
                strSQL1 = string.Format(strSQL1, drugDeptCode, checkCode);
                strSQL2 = string.Format(strSQL2, drugDeptCode, checkCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.SaveCheck:" + ex.Message;
                return -1;
            }
            int flag = this.ExecNoQuery(strSQL1);
            if (flag == -1)
                return -1;
            else
                if (flag == 0)
                    return 0;
            return this.ExecNoQuery(strSQL2);
        }

        /// <summary>
        /// 盘点分区列表加载
        /// </summary>
        /// <param name="drugDeptCode"></param>
        /// <param name="checkState"></param>
        /// <param name="adjustOper"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Check> QueryCheckPartitionPrivList(string drugDeptCode, string checkState, Neusoft.FrameWork.Models.NeuObject adjustOper)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryCheckPartitionList.OperList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCheckPartitionList.OperList字段!";
                return null;
            }
            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, drugDeptCode, checkState, adjustOper.ID);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryCheckPartitionList.OperList:" + ex.Message;
                return null;
            }

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得盘点分区列表信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            //将返回数据加入动态数组
            Neusoft.HISFC.Models.Pharmacy.Check check;
            List<Neusoft.HISFC.Models.Pharmacy.Check> alList = new List<Check>();

            try
            {
                while (this.Reader.Read())
                {
                    //此语句不能加到循环外面，否则会在al数组内加入相同的数据（最后一条数据）
                    check = new Check();
                    check.CheckNO = this.Reader[0].ToString();                   //盘点单号
                    check.CheckName = this.Reader[1].ToString();                 //盘点单名称
                    check.Operation.ID = this.Reader[2].ToString();                  //封帐人
                    check.Operation.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[3]);            //封帐时间

                    alList.Add(check);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点列表息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return alList;
        }

        /// <summary>
        /// 根据盘点科室、盘点单号、状态获取所有已授权人员
        /// </summary>
        /// <param name="drugDeptCode">盘点科室编码</param>
        /// <param name="checkState">盘点状态</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回授权人员信息 失败返回null</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryCheckPartitionPrivList(string drugDeptCode, string checkState, string checkCode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryCheckPartitionList.PrivList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCheckPartitionList.PrivList字段!";
                return null;
            }
            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, drugDeptCode, checkState, checkCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryCheckPartitionList.PrivList:" + ex.Message;
                return null;
            }

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得盘点分区列表信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            //将返回数据加入动态数组
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
            List<Neusoft.FrameWork.Models.NeuObject> alList = new List<Neusoft.FrameWork.Models.NeuObject>();

            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();                        //授权盘点人编码
                    info.Name = this.Reader[1].ToString();                      //授权盘点人名称
                    info.Memo = this.Reader[2].ToString();                      //备注

                    alList.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得盘点列表息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return alList;
        }

        /// <summary>
        /// 盘点分区明细检索
        /// </summary>
        /// <param name="checkCode"></param>
        /// <param name="drugDeptCode"></param>
        /// <param name="adjustOper"></param>
        /// <returns></returns>
        public System.Collections.ArrayList QueryCheckPartitionByCheckCode(string checkCode, string drugDeptCode, Neusoft.FrameWork.Models.NeuObject adjustOper)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryCheckPartition", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCheckPartition字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryCheckPartition.CheckCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCheckPartition.CheckCode字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, drugDeptCode, checkCode, adjustOper.ID);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryCheckPartition.CheckCode:" + ex.Message;
                return null;
            }

            //取盘点详细信息数据
            return this.myGetCheckDetailInfo(strSQL);
        }
        #endregion

        #region 特殊盘点维护{98F0BF7A-5F41-4de3-884F-B38E71B41A8C}

        /// <summary>
        /// 查询特殊盘点记录
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public List<CheckSpecial> QueryCheckSpecial(string deptCode)
        {
            string sqlSelect = "";
            if (this.Sql.GetSql("Pharmacy.Item.QueryCheckSpecial", ref sqlSelect) < 0)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCheckSpecial字段!";
                return null;
            }
            string sqlWhere = "";
            if (this.Sql.GetSql("Pharmacy.Item.QueryCheckSpecial.ByDeptCode", ref sqlWhere) < 0)
            {
                this.Err = "没有找到Pharmacy.Item.QueryCheckSpecial.ByDeptCode字段!";
                return null;
            }
            try
            {
                sqlWhere = string.Format(sqlWhere, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryCheckSpecial.ByDeptCode:" + ex.Message;
                return null;
            }
            return this.MyGetCheckSpecialList(sqlSelect + sqlWhere);
        }

        /// <summary>
        /// 执行sql语句查询记录
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private List<CheckSpecial> MyGetCheckSpecialList(string sql)
        {
            if (this.ExecQuery(sql) <0)
            {
                this.Err = "获得特殊盘点信息时，执行SQL语句出错！" + this.Err;
                return null;
            }
            List<CheckSpecial> specialList = new List<CheckSpecial>();
            try
            {
                while (this.Reader.Read())
                {
                    CheckSpecial csp = new CheckSpecial();
                    csp.Storage.ID = this.Reader[0].ToString();//库房编码
                    csp.DrugQuality.ID = this.Reader[1].ToString();//药品性质
                    csp.DrugQuality.Name = this.Reader[2].ToString();//药品性质名称
                    csp.CheckType = this.Reader[3].ToString();//盘点方式(1.正常，2.按批次)
                    csp.Memo = this.Reader[4].ToString();//备注
                    csp.Oper.ID = this.Reader[5].ToString();//操作员
                    csp.Oper.OperTime = FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());//操作时间

                    specialList.Add(csp);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得特殊盘点列表息时出错！" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return specialList;
        }

        /// <summary>
        /// 获得特殊盘点参数
        /// </summary>
        /// <param name="csp"></param>
        /// <returns></returns>
        private string[] MyGetParmCheckSpecial(CheckSpecial csp)
        {
            string[] parm =
            {
                csp.Storage.ID,
                csp.DrugQuality.ID,
                csp.DrugQuality.Name,
                csp.CheckType,
                csp.Memo,
                csp.Oper.ID,
                csp.Oper.OperTime.ToString("yyyy-MM-dd HH:mm:ss")
            };
            return parm;
        }

        /// <summary>
        /// 保存特殊盘点方式
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="specialList"></param>
        /// <returns></returns>
        public int SetCheckSpecial(string deptCode, List<CheckSpecial> specialList)
        {
            //删除
            if (this.DeleteCheckSpecialByDeptCode(deptCode) < 0)
            {
                return -1;
            }
            //逐条插入
            foreach (CheckSpecial info in specialList)
            {
                if (this.InsertCheckSpecial(info) < 0)
                {
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int InsertCheckSpecial(CheckSpecial info)
        {
            string sql = "";
            if (this.Sql.GetSql("Pharmacy.Item.CheckSpecial.Insert", ref sql) < 0)
            {
                this.Err = "没有找到Pharmacy.Item.CheckSpecial.Insert字段!";
                return -1;
            }
            try
            {
                sql = string.Format(sql, this.MyGetParmCheckSpecial(info));
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.CheckSpecial.Insert:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 删除特殊盘点记录
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        private int DeleteCheckSpecialByDeptCode(string deptCode)
        {
            string sql = "";
            if (this.Sql.GetSql("Pharmacy.Item.CheckSpecial.Delete", ref sql) < 0)
            {
                this.Err = "没有找到Pharmacy.Item.CheckSpecial.Delete字段!";
                return -1;
            }
            sql = string.Format(sql, deptCode);
            return this.ExecNoQuery(sql);
        }

        #endregion

        #endregion

        #region 供货商结存

        #region 基础增、删、改操作

        /// <summary>
        /// 获取结存头表的Insert或Update参数数组
        /// </summary>
        /// <param name="pay">供货商结存实体</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        protected string[] myGetParmPayHead(Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            try
            {
                string[] parm = {
									pay.ID,							//付款序号
									pay.InListNO,					//入库单据号
									pay.InvoiceNO,					//发票号
									pay.InvoiceTime.ToString(),		//发票日期
									pay.PayCost.ToString(),			//已付金额
									pay.UnPayCost.ToString(),		//未付金额
									pay.PayState,					//付款标志 0未付款  1已付款 2完成付款
									pay.PayOper.OperTime.ToString(),			//完成付款日期
									pay.DeliveryCost.ToString(),	//运费
									pay.RetailCost.ToString(),		//零售金额
									pay.WholeSaleCost.ToString(),	//批发金额
									pay.PurchaseCost.ToString(),	//购入金额（发票金额 ）
									pay.DisCountCost.ToString(),	//优惠金额
									pay.StockDept.ID,				//入库科室
									pay.Company.ID,					//供货单位编码
									pay.Company.Name,				//供货单位名称
									pay.Memo,						//备注
									pay.Oper.ID,					//操作员
									pay.Oper.OperTime.ToString(),		//操作日期
									pay.Extend,					//扩展字段
									pay.Extend1,					//扩展字段1
									pay.Extend2,					//扩展字段2
									pay.ExtendTime.ToString(),			//扩展日期
									pay.ExtendQty.ToString()		//扩展数量
								};
                return parm;
            }
            catch (Exception ex)
            {
                this.Err = "由实体获取参数数组时发生异常 \n" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行sql语句 获取结存头表信息数组
        /// </summary>
        /// <param name="strSql">欲执行的sql语句</param>
        /// <returns>成功返回pay数组 出错返回null 无记录返回空数组</returns>
        protected ArrayList myGetpayHead(string strSql)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Pay pay;
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "获得结存头表信息时，执行SQL语句出错！" + this.Err;
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    pay = new Pay();
                    pay.ID = this.Reader[0].ToString();								//付款序号
                    pay.InListNO = this.Reader[1].ToString();						//入库单据号
                    pay.InvoiceNO = this.Reader[2].ToString();						//发票号
                    pay.InvoiceTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[3].ToString());	//发票日期
                    pay.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());			//已付金额
                    pay.UnPayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());		//未付金额
                    pay.PayState = this.Reader[6].ToString();						//付款标志 0未付款  1已付款 2完成付款
                    pay.PayOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString());		//付款完成日期
                    pay.DeliveryCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[8].ToString());	//运费
                    pay.RetailCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());		//零售金额
                    pay.WholeSaleCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString());	//批发金额
                    pay.PurchaseCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[11].ToString());	//购入金额
                    pay.DisCountCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12].ToString());	//优惠金额
                    pay.StockDept.ID = this.Reader[13].ToString();			//入库科室
                    pay.Company.ID = this.Reader[14].ToString();			//供货单位编码
                    pay.Company.Name = this.Reader[15].ToString();			//供货单位名称
                    pay.Memo = this.Reader[16].ToString();					//备注
                    pay.Oper.ID = this.Reader[17].ToString();				//操作员
                    pay.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[18].ToString());		//操作日期
                    pay.Extend = this.Reader[19].ToString();
                    pay.Extend1 = this.Reader[20].ToString();
                    pay.Extend2 = this.Reader[21].ToString();
                    pay.ExtendTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[22].ToString());
                    pay.ExtendQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[23].ToString());

                    al.Add(pay);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获取结存头表信息时 由Reader内读取信息发生异常 \n" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 获取结存明细表的Insert或Update参数数组
        /// </summary>
        /// <param name="pay">供货商结存实体</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        protected string[] myGetParmPayDetail(Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            try
            {
                string[] parm = {
									pay.ID,						//付款序号
									pay.InvoiceNO,				//发票号
									pay.SequenceNO.ToString(),	//同一发票内付款流水号
									pay.PayType,				//付款类型 现金/支票
									pay.Company.OpenBank,		//开户银行
									pay.Company.OpenAccounts,	//银行帐号
									pay.PayCost.ToString(),		//本次付款金额
									pay.UnPayCost.ToString(),	//本次剩余付款金额
									pay.PayOper.ID,				//付款人代码
									pay.PayOper.OperTime.ToString(),		//付款日期
									pay.DeliveryCost.ToString(),//运费
									pay.Oper.ID,				//操作员
									pay.Oper.OperTime.ToString(),	//操作日期
									pay.Memo,					//备注
									pay.Extend,				//扩展字段
									pay.Extend1,				//扩展字段1
									pay.Extend2,				//扩展字段2
									pay.ExtendTime.ToString(),		//扩展日期
									pay.ExtendQty.ToString()	//扩展数量
								};
                return parm;
            }
            catch (Exception ex)
            {
                this.Err = "由实体获取参数数组时发生异常 \n" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行sql语句 获取结存头表信息数组
        /// </summary>
        /// <param name="strSql">欲执行的sql语句</param>
        /// <returns>成功返回pay数组 出错返回null 无记录返回空数组</returns>
        protected ArrayList myGetPayDetail(string strSql)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.Pay pay;
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "获得结存头表信息时，执行SQL语句出错！" + this.Err;
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    pay = new Pay();

                    pay.ID = this.Reader[0].ToString();							//付款序号
                    pay.InvoiceNO = this.Reader[1].ToString();					//发票号
                    pay.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[2].ToString());	//同一发票内付款流水号
                    pay.PayType = this.Reader[3].ToString();					//付款类型（现金，发票）
                    pay.Company.OpenBank = this.Reader[4].ToString();			//开户银行
                    pay.Company.OpenAccounts = this.Reader[5].ToString();		//银行帐号
                    pay.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6].ToString());		//本次付款金额
                    pay.UnPayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());	//本次剩余付款金额
                    pay.PayOper.ID = this.Reader[8].ToString();					//付款人
                    pay.PayOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString());	//付款日期
                    pay.DeliveryCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString());//运费
                    pay.Oper.ID = this.Reader[11].ToString();
                    pay.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[12].ToString());
                    pay.Memo = this.Reader[13].ToString();
                    pay.Extend = this.Reader[14].ToString();
                    pay.Extend1 = this.Reader[15].ToString();
                    pay.Extend2 = this.Reader[16].ToString();
                    pay.ExtendTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[17].ToString());
                    pay.ExtendQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[18].ToString());

                    al.Add(pay);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获取结存头表信息时 由Reader内读取信息发生异常 \n" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 插入结存头表
        /// </summary>
        /// <param name="pay">供货商结存实体</param>
        /// <returns>成功返回插入条数 失败返回-1</returns>
        public int InsertPayHead(Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.Pay.InsertPayHead", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.InsertPayHead字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmPayHead(pay);     //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.InsertPayHead:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新结存头表
        /// </summary>
        /// <param name="pay">供货商结存实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        public int UpdateInsertPayHead(Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.Pay.UpdatePayHead", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.UpdatePayHead字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmPayHead(pay);     //取参数列表
                strSQL = string.Format(strSQL, strParm);				   //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.UpdatePayHead:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除结存头表
        /// </summary>
        /// <param name="payNo">付款序号</param>
        /// <returns>成功返回删除条数 失败返回-1</returns>
        public int DelPayHead(string payNo)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.Pay.DeletePayHead", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.DeletePayHead字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, payNo);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.DeletePayHead:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 插入结存明细表
        /// </summary>
        /// <param name="pay">供货商结存实体</param>
        /// <returns>成功返回插入条数 失败返回-1</returns>
        public int InsertPayDetail(Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.Pay.InsertPayDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.InsertPayDetail字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmPayDetail(pay);     //取参数列表
                strSQL = string.Format(strSQL, strParm);					//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.InsertPayDetail:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新结存明细表
        /// </summary>
        /// <param name="pay">供货商结存实体</param>
        /// <returns>成功返回更新条数 失败返回-1</returns>
        public int UpdateInsertPayDetail(Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.Pay.UpdatePayDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.UpdatePayDetail字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmPayDetail(pay);     //取参数列表
                strSQL = string.Format(strSQL, strParm);				   //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.UpdatePayDetail" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除结存结存表
        /// </summary>
        /// <param name="payNo">付款序号</param>
        /// <returns>成功返回删除条数 失败返回-1</returns>
        public int DelPayDetail(string payNo, int sequenceNo)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.Pay.DeletePayDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.DeletePayDetail字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, payNo, sequenceNo);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.DeletePayDetail:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 内部使用

        /// <summary>
        /// 获取某入库科室某供货单位的所有发票列表
        /// </summary>
        /// <param name="drugDeptID">入库科室编码</param>
        /// <param name="companyID">供货单位编码 "AAAA" 查询所有供货单位</param>
        /// <param name="payFlag">付款标志 0未付款  1已付款 2完成付款 Sql语句采用In的方式 可同时查询多个状态</param>
        /// <param name="dtBegin">查询开始时间</param>
        /// <param name="dtEnd">查询结束时间</param>
        /// <returns>成功返回未结存发票列表 失败返回null</returns>
        public ArrayList QueryPayList(string drugDeptID, string companyID, string payFlag, DateTime dtBegin, DateTime dtEnd)
        {
            string strSelect = "";
            string strWhere = "";
            if (this.Sql.GetSql("Pharmacy.Item.Pay.GetPayHead", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.GetPayHead字段!";
                return null;
            }
            if (this.Sql.GetSql("Pharmacy.Item.Pay.GetPayList", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.GetPayList字段!";
                return null;
            }
            try
            {
                strSelect = strSelect + strWhere;
                strSelect = string.Format(strSelect, drugDeptID, companyID, payFlag, dtBegin.ToString(), dtEnd.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "格式化Sql语句出错" + ex.Message;
                return null;
            }
            return this.myGetpayHead(strSelect);
        }

        /// <summary>
        /// 获取某入库科室的所有未结存发票列表
        /// </summary>
        /// <param name="drugDeptID">入库科室编码</param>
        /// <param name="payFlag">付款标志 0未付款  1已付款 2完成付款</param>
        /// <param name="dtBegin">查询开始时间</param>
        /// <param name="dtEnd">查询结束时间</param>
        /// <returns>成功返回未结存发票列表 失败返回null</returns>
        public ArrayList QueryPayList(string drugDeptID, string payFlag, DateTime dtBegin, DateTime dtEnd)
        {
            return this.QueryPayList(drugDeptID, "AAAA", payFlag, dtBegin, dtEnd);
        }

        /// <summary>
        /// 获取某入库科室的所有未结存发票列表
        /// </summary>
        /// <param name="drugDeptID">入库科室编码</param>
        /// <param name="payFlag">付款标志 0未付款  1已付款 2完成付款</param>
        /// <returns>成功返回未结存发票列表 失败返回null</returns>
        public ArrayList QueryPayList(string drugDeptID, string payFlag)
        {
            return this.QueryPayList(drugDeptID, "AAAA", payFlag, System.DateTime.MinValue, System.DateTime.MinValue);
        }

        /// <summary>
        /// 获取结存明细信息
        /// </summary>
        /// <param name="payNo">付款序号</param>
        /// <param name="invoiceNo">发票号</param>
        /// <returns>成功返回结存实体数组 失败返回null</returns>
        public ArrayList QueryPayDetail(string payNo, string invoiceNo)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.Pay.GetPayDtail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.GetPayDtail字段!";
                return null;
            }
            string strWhere = "";
            if (this.Sql.GetSql("Pharmacy.Item.Pay.GetPayDtail.PayNo", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Pay.GetPayDtail.PayNo字段!";
                return null;
            }

            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, payNo, invoiceNo);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.GetPayDtail:" + ex.Message;
                return null;
            }
            return this.myGetPayDetail(strSQL);
        }

        /// <summary>
        /// 获取同一发票内付款流水号
        /// select max(s.sequence_no)								
        /// from   pha_med_paydetail s
        /// where  s.parent_code = '[父级编码]'
        /// and    s.current_code = '[本级编码]'
        /// and    s.pay_no = '{0}'
        /// and    s.invoice_no = '{1}'
        /// </summary>
        /// <param name="payNo">付款序号</param>
        /// <param name="invoiceNo">发票号</param>
        /// <param name="sequenceNo">返回的当前最大的同一发票内付款流水号</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int GetInvoicePaySequence(string payNo, string invoiceNo, ref int sequenceNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.Pay.GetInvoicePaySequence", ref strSql) == -1)
            {
                this.Err = "根据Sql索引Pharmacy.Item.Pay.GetInvoicePaySequence查找Sql出错 \n" + this.Err;
                return -1;
            }
            //格式化SQL语句
            try
            {
                strSql = string.Format(strSql, payNo, invoiceNo);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.GetInvoicePaySequence" + ex.Message;
                return -1;
            }

            string strSequenceNo = this.ExecSqlReturnOne(strSql, "0");
            sequenceNo = NConvert.ToInt32(strSequenceNo) + 1;
            return 1;
        }

        /// <summary>
        /// 更新结存头表 一次付款信息
        /// </summary>
        /// <param name="payNo">付款序号</param>
        /// <param name="pay">本次付款信息</param>
        /// <returns>成功返回1 失败返回-1 无记录返回0</returns>

        /*
         * update pha_med_payhead t
set    t.pay_cost = t.pay_cost + {1},
       t.unpay_cost = t.unpay_cost - {1},
       t.pay_flag = decode(t.unpay_cost - {1},0,'2','1'),
       t.pay_date = to_date('{2}','yyyy-mm-dd hh24:mi:ss'),
       t.oper_code = '{3}',
       t.oper_date = sysdate
from   t.parent_code = '[父级编码]'
and    t.current_code = '[本级编码]'
and    t.pay_no = '{0}'
         * */
        public int UpdatePayHead(string payNo, Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.Pay.UpdatePayHeadInfo", ref strSql) == -1)
            {
                this.Err = "根据Sql索引Pharmacy.Item.Pay.UpdatePayHeadInfo查找Sql出错 \n" + this.Err;
                return -1;
            }
            //格式化SQL语句
            try
            {
                strSql = string.Format(strSql, payNo, pay.PayCost, pay.PayOper.OperTime.ToString(), pay.PayOper.ID);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.GetInvoicePaySequence" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        ///	供货商结存 处理一次付款信息
        /// </summary>
        /// <param name="payNo">付款序号</param>
        /// <param name="pay">本次付款信息</param>
        /// <returns>成功返回1 失败返回-1 </returns>
        public int Pay(string payNo, Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            int parm = this.UpdatePayHead(payNo, pay);
            if (parm != 1)
                return parm;
            int sequenceNo = pay.SequenceNO;
            parm = this.GetInvoicePaySequence(payNo, pay.InvoiceNO, ref sequenceNo);
            if (parm != 1)
                return parm;
            pay.SequenceNO = sequenceNo;
            parm = this.InsertPayDetail(pay);
            if (parm != 1)
                return parm;
            return 1;
        }

        /// <summary>
        /// 供货商结存 新插入一次结存信息 如本次有支付记录 则向结存明细表内插入数据
        /// </summary>
        /// <param name="pay">供货商结存信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int Pay(Neusoft.HISFC.Models.Pharmacy.Pay pay)
        {
            int parm = this.InsertPayHead(pay);
            if (parm != 1)
                return parm;
            if (pay.PayState != "0")
            {
                parm = this.InsertPayDetail(pay);
                if (parm != 1)
                    return parm;
            }
            return parm;
        }

        #endregion

        /// <summary>
        /// 根据本次核准入库信息 对相同单据/相同发票 内的信息进行更新
        /// </summary>
        /// <param name="approveInput">核准入库信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdatePayForApproveInput(Neusoft.HISFC.Models.Pharmacy.Input approveInput)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.Pay.UpdatePayForApproveInput", ref strSql) == -1)
            {
                this.Err = "根据Sql索引Pharmacy.Item.Pay.UpdatePayForApproveInput查找Sql出错 \n" + this.Err;
                return -1;
            }
            //格式化SQL语句
            try
            {
                strSql = string.Format(strSql, approveInput.InListNO, approveInput.InvoiceNO,
                                                approveInput.StockDept.ID, approveInput.Company.ID,
                                                approveInput.RetailCost.ToString(),
                                                approveInput.WholeSaleCost.ToString(),
                                                approveInput.PurchaseCost.ToString()
                                        );
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.Pay.UpdatePayForApproveInput" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 根据本次核准入库信息 生成新的供货商结存信息
        /// </summary>
        /// <param name="approveInput">核准入库信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertPayForApproveInput(Neusoft.HISFC.Models.Pharmacy.Input approveInput)
        {
            Neusoft.HISFC.Models.Pharmacy.Pay pay = new Pay();
            pay.ID = this.GetNewPayNO();
            pay.InListNO = approveInput.InListNO;		//入库单据号
            pay.InvoiceNO = approveInput.InvoiceNO;			//发票号

            //发票日期目前没用录入
            //			pay.InvoiceDate = approveInput.invoice			//发票日期

            pay.PayCost = 0;
            pay.PayState = "0";								//付款标记
            pay.RetailCost = approveInput.RetailCost;
            pay.WholeSaleCost = approveInput.WholeSaleCost;
            pay.PurchaseCost = approveInput.PurchaseCost;
            pay.UnPayCost = approveInput.PurchaseCost;
            pay.StockDept = approveInput.StockDept;
            pay.Company.ID = approveInput.Company.ID;
            pay.Company.Name = approveInput.Company.Name;
            pay.Oper.ID = this.Operator.ID;
            pay.Oper.OperTime = approveInput.Operation.ApproveOper.OperTime;

            return this.InsertPayHead(pay);

        }

        /// <summary>
        /// 根据入库核准信息生成供货商结存信息
        /// </summary>
        /// <param name="input">入库核准信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int Pay(Neusoft.HISFC.Models.Pharmacy.Input input)
        {
            int parm = 0;
            parm = this.UpdatePayForApproveInput(input);
            if (parm == -1)
                return parm;
            if (parm == 0)
                parm = this.InsertPayForApproveInput(input);
            return parm;
        }

        #endregion

        #region 入库 警戒线/消耗量 计算 {F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 修改函数实现

        /// <summary>
        /// 获取库存不足最低库存量的库存药品数据
        /// 
        /// User01 最低库存量 User02 最高库存量 User03 应入库量(最高库存量-当前库存)    
        /// 
        /// {F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 修改函数实现
        /// </summary>
        /// <param name="deptCode">库存科室编码</param>
        /// <returns>成功返回库存药品数据 失败返回null</returns>
        public ArrayList QueryDrugListByNumAlter(string deptCode)
        {
            ArrayList drugList = new ArrayList();

            string strSQL = "";
            //取查找药品的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.FindByAlter", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.FindByAlter字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.FindByAlter:\n" + ex.Message;
                this.WriteErr();
                return null;
            }

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得药品警戒线信息时，执行SQL语句出错！\n" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();			//药品编码
                    info.Name = this.Reader[1].ToString();			//名称
                    info.Memo = this.Reader[2].ToString();			//规格
                    info.User01 = this.Reader[3].ToString();		//最低库存量
                    info.User02 = this.Reader[4].ToString();		//最高库存量
                    info.User03 = this.Reader[5].ToString();		//应入库量

                    drugList.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得药品警戒线信息时发生错误！\n" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return drugList;
        }

        ///<summary>
        ///获得当前科室内低于警戒线的药品
        /// 
        /// {F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 修改函数实现
        ///</summary>
        ///<param name="deptCode">库房编码</param>
        ///<param name="dtBegin">统计起始时间</param>
        ///<param name="dtEnd">统计截止时间</param>
        ///<param name="maxAlterDays">最高库存天数  </param>
        ///<param name="minAlterDays">最高库存天数  </param>
        /// <param name="isStatAllPDept">统计所有药房科室的消耗 True 统计全部 False 仅统计本科室</param>
        ///<returns>成功返回 object数组 ，查找失败返回null</returns>
        public ArrayList QueryDrugListByDayAlter(string deptCode, DateTime dtBegin, DateTime dtEnd, int maxAlterDays, int minAlterDays,bool isStatAllPDept)
        {
            ArrayList al = new ArrayList();				//存储待入库信息
            Neusoft.FrameWork.Models.NeuObject info;		    //存储待入库信息
           
            //获取当前药品库存列表
            if (isStatAllPDept)     //统计所有药房科室消耗
            {
                deptCode = "A";
            }
            List<Neusoft.HISFC.Models.Pharmacy.StorageBase> alStock = this.QueryDrugStockInfo(deptCode);
            if (alStock == null)
            {
                return null;
            }

            List<Neusoft.FrameWork.Models.NeuObject> expandList = this.FindByExpand(deptCode, dtBegin, dtEnd);
            if (expandList == null)
            {
                return null;
            }
            System.Collections.Hashtable hsExpandList = new Hashtable();
            foreach (Neusoft.FrameWork.Models.NeuObject expandItem in expandList)
            {
                hsExpandList.Add(expandItem.ID, expandItem);
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.StorageBase stockInfo in alStock)
            {
                if (hsExpandList.ContainsKey(stockInfo.Item.ID))
                {
                    Neusoft.FrameWork.Models.NeuObject expandInfo = hsExpandList[stockInfo.Item.ID] as Neusoft.FrameWork.Models.NeuObject;
                    decimal totOutNum = NConvert.ToDecimal(expandInfo.User01);
                    decimal perDayOutNum = NConvert.ToDecimal(expandInfo.User02);

                    //库存量小于日消耗 * 最低库存量天数
                    if (stockInfo.StoreQty < perDayOutNum * minAlterDays)
                    {
                        info = new Neusoft.FrameWork.Models.NeuObject();
                        info.ID = stockInfo.Item.ID;										//药品编码
                        info.Name = stockInfo.Item.Name;									//名称
                        info.Memo = stockInfo.Item.Specs;									//规格
                        info.User01 = totOutNum.ToString();									//出库总量
                        info.User02 = perDayOutNum.ToString();								//日消耗
                        info.User03 = (perDayOutNum * maxAlterDays - stockInfo.StoreQty).ToString();		//应入库量

                        al.Add(info);
                    }
                }
            }

            return al;
        }

        /// <summary>
        /// 根据科室获取当前药品库存列表
        /// 
        /// {F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 新增函数实现
        /// </summary>
        /// <param name="drugDeptCode">库存科室 A 查询所有科室</param>
        /// <returns>成功返回当前科室库存列表 失败返回null</returns>
        protected List<Neusoft.HISFC.Models.Pharmacy.StorageBase> QueryDrugStockInfo(string drugDeptCode)
        {
            List<Neusoft.HISFC.Models.Pharmacy.StorageBase> stockList = new List<StorageBase>();

            string strSQL = "";
            //取查找药品的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryDrugStockInfo", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryDrugStockInfo字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, drugDeptCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryDrugStockInfo:\n" + ex.Message;
                this.WriteErr();
                return null;
            }

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得药品库存量信息时，执行SQL语句出错！\n" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Pharmacy.StorageBase info = new Neusoft.HISFC.Models.Pharmacy.StorageBase();

                    info.Item.ID = this.Reader[0].ToString();			    //药品编码
                    info.Item.Name = this.Reader[1].ToString();			    //名称
                    info.Item.Specs = this.Reader[2].ToString();			//规格
                    info.StoreQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());

                    stockList.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得药品库存量信息时发生错误！\n" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return stockList;
        }

        /// <summary>
        /// 统计所有出库药品的消耗信息
        /// User01 出库量 User02 日均出库量
        /// 
        /// {F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 新增函数实现
        /// </summary>
        /// <param name="deptCode">统计科室 A 统计所有科室</param>
        /// <param name="outDay">统计天数</param>
        /// <param name="dtEnd">统计截至日期</param>
        /// <param name="isPatient">是否只统计实际消耗量 药房出库量</param>
        /// <returns>成功返回1 发生错误返回－1</returns>
        public List<Neusoft.FrameWork.Models.NeuObject> FindByExpand(string deptCode, DateTime dtBegin, DateTime dtEnd)
        {
            string strSQL = "";

            //取查找药品的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.FindByExpand.DeptPatient", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.FindByExpand.DeptPatient字段!";
                return null;
            }

            int intervalDays = (dtEnd - dtBegin).Days;

            try
            {
                strSQL = string.Format(strSQL, deptCode, intervalDays, dtEnd);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.FindByExpand.DeptPatient:" + ex.Message;
                this.WriteErr();
                return null;
            }

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得药品日均消耗信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            List<Neusoft.FrameWork.Models.NeuObject> expandList = new List<Neusoft.FrameWork.Models.NeuObject>();

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject expandDrug = new Neusoft.FrameWork.Models.NeuObject();

                    expandDrug.ID = this.Reader[0].ToString();
                    expandDrug.User01 = this.Reader[1].ToString();      //出库总量
                    expandDrug.User02 = this.Reader[2].ToString();      //日均出库量

                    expandList.Add(expandDrug.Clone());
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得药品日均消耗信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return expandList;
        }


        /// <summary>
        /// 根据指定库房、药品、日期、计算日均消耗量
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="outDay">统计天数</param>
        /// <param name="dtEnd">统计截止日期</param>
        /// <param name="totOutNum">返回 出库总量</param>
        /// <param name="perDayOutNum">返回 日均出库量</param>
        /// <returns>成功返回1 发生错误返回-1</returns>
        public int FindByExpand(string deptCode, string drugCode, decimal outDay, DateTime dtEnd, out decimal totOutNum, out decimal perDayOutNum)
        {
            return this.FindByExpand(deptCode, drugCode, outDay, dtEnd, false, out totOutNum, out perDayOutNum);
        }

        /// <summary>
        /// 根据指定库房、药品、日期、计算日均消耗量
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="outDay">统计天数</param>
        /// <param name="dtEnd">统计截止日期</param>
        /// <param name="isPatient">是否只统计实际消耗量 药房出库量</param>
        /// <param name="totOutNum">返回 出库总量</param>
        /// <param name="perDayOutNum">返回 日均出库量</param>
        /// <returns>成功返回1 发生错误返回-1</returns>
        public int FindByExpand(string deptCode, string drugCode, decimal outDay, DateTime dtEnd, bool isPatient, out decimal totOutNum, out decimal perDayOutNum)
        {
            totOutNum = 0;
            perDayOutNum = 0;

            string strSQL = "";
            if (isPatient)
            {
                //取查找药品的SQL语句
                if (this.Sql.GetSql("Pharmacy.Item.FindByExpand.PatientInOut", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.FindByExpand.PatientInOut字段!";
                    return -1;
                }
            }
            else
            {
                //取查找药品的SQL语句
                if (this.Sql.GetSql("Pharmacy.Item.FindByExpand", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.FindByExpand字段!";
                    return -1;
                }
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, drugCode, outDay, dtEnd);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.FindByExpand:" + ex.Message;
                this.WriteErr();
                return -1;
            }

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得药品日均消耗信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return -1;
            }

            try
            {
                while (this.Reader.Read())
                {
                    totOutNum = NConvert.ToDecimal(this.Reader[0].ToString());
                    perDayOutNum = NConvert.ToDecimal(this.Reader[1].ToString());
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得药品日均消耗信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }

            return 1;
        }

        #endregion

        #region  药品多级特殊单位维护

        #region 基础增、删、改操作

        /// <summary>
        /// 获取Insert、Update参数
        /// </summary>
        /// <param name="speUnit">药品特殊单位实体</param>
        /// <returns>成功返回对应的参数信息 失败返回null</returns>
        private string[] myGetParmSpeUnit(Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit speUnit)
        {
            try
            {
                string[] param = {
									 speUnit.Item.ID,				//药品编码
									 speUnit.Item.Name,				//药品名称
									 speUnit.Item.Specs,				//规格
									 speUnit.Item.PackUnit,			//包装单位
									 speUnit.Item.PackQty.ToString(),//包装数量
									 speUnit.Item.MinUnit,			//最小单位
									 speUnit.UnitType.ID,			//特殊类别ID
									 speUnit.UnitType.Name,			//特殊类别名称
									 speUnit.Unit,					//单位
									 speUnit.Qty.ToString(),			//参照数量
									 speUnit.UnitFlag,				//参照单位标志
									 speUnit.Extend,				//扩展字段
									 speUnit.Extend1,				//扩展字段1
									 speUnit.Oper.ID,				//操作员
									 speUnit.Oper.OperTime.ToString()		//操作时间
								 };
                return param;
            }
            catch (Exception ex)
            {
                this.Err = "由实体获取参数数组时发生异常 \n" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据Sql语句获取实体信息
        /// </summary>
        /// <param name="strSql">需执行Sql语句</param>
        /// <returns>成功返回实体数组 失败返回null</returns>
        private ArrayList myGetSpeUnit(string strSql)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit speUnit;
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "获取药品特殊单位信息出错！" + this.Err;
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    speUnit = new DrugSpeUnit();
                    speUnit.Item.ID = this.Reader[0].ToString();
                    speUnit.Item.Name = this.Reader[1].ToString();
                    speUnit.Item.Specs = this.Reader[2].ToString();
                    speUnit.Item.PackUnit = this.Reader[3].ToString();
                    speUnit.Item.PackQty = NConvert.ToDecimal(this.Reader[4].ToString());
                    speUnit.Item.MinUnit = this.Reader[5].ToString();
                    speUnit.UnitType.ID = this.Reader[6].ToString();
                    speUnit.UnitType.Name = this.Reader[7].ToString();
                    speUnit.Unit = this.Reader[8].ToString();
                    speUnit.Qty = NConvert.ToDecimal(this.Reader[9].ToString());
                    speUnit.UnitFlag = this.Reader[10].ToString();
                    speUnit.Extend = this.Reader[11].ToString();
                    speUnit.Extend1 = this.Reader[12].ToString();
                    speUnit.Oper.ID = this.Reader[13].ToString();
                    speUnit.Oper.OperTime = NConvert.ToDateTime(this.Reader[14].ToString());

                    al.Add(speUnit);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Sql语句读取特殊单位信息时发生错误" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="speUnit">药品特殊单位实体</param>
        /// <returns>成功返回插入条数 失败返回-1</returns>
        public int InsertSpeUnit(Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit speUnit)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.DrugSpeUnit.InsertSpeUnit", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DrugSpeUnit.InsertSpeUnit字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmSpeUnit(speUnit);     //取参数列表
                strSql = string.Format(strSql, strParm);				//替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DrugSpeUnit.InsertSpeUnit:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="speUnit">实体信息</param>
        /// <returns>成功返回删除条数 失败返回-1</returns>
        public int DeleteSpeUnit(Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit speUnit)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.DrugSpeUnit.DeleteOneSpeUnit", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DrugSpeUnit.DeleteOneSpeUnit字段!";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, speUnit.Item.ID, speUnit.UnitType.ID, speUnit.Unit);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DrugSpeUnit.DeleteOneSpeUnit:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="drugCode">需删除药品信息</param>
        /// <returns>成功返回删除条数 失败返回-1</returns>
        public int DeleteSpeUnit(string drugCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.DrugSpeUnit.DeleteSpeUnit.ByDrugCode", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DrugSpeUnit.DeleteSpeUnit.ByDrugCode字段!";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, drugCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DrugSpeUnit.DeleteSpeUnit.ByDrugCode:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        #endregion

        #region 内部使用

        /// <summary>
        /// 根据药品编码获取信息
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <returns>返回该药品维护的多级药品实体数组</returns>
        public ArrayList QuerySpeUnit(string drugCode)
        {
            string strSql = "";
            string strWhere = "";
            if (this.Sql.GetSql("Pharmacy.Item.DrugSpeUnit.GetSpeUnit", ref strSql) == -1)
            {
                this.Err = "根据Sql索引Pharmacy.Item.DrugSpeUnit.GetSpeUnit查找Sql出错 \n" + this.Err;
                return null;
            }
            if (this.Sql.GetSql("Pharmacy.Item.DrugSpeUnit.GetSpeUnit.ByDrugCode", ref strWhere) == -1)
            {
                this.Err = "根据Sql索引Pharmacy.Item.DrugSpeUnit.GetSpeUnit.ByDrugCode查找Sql出错 \n" + this.Err;
                return null;
            }
            //格式化SQL语句
            try
            {
                strSql = strSql + strWhere;
                strSql = string.Format(strSql, drugCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DrugSpeUnit.GetSpeUnit.ByDrugCode" + ex.Message;
                return null;
            }
            return this.myGetSpeUnit(strSql);
        }

        /// <summary>
        /// 获取已维护的药品列表
        /// </summary>
        /// <returns>成功返回已维护的药品列表 失败返回null</returns>
        public ArrayList QuerySpeUnitList()
        {
            string strSql = "";
            if (this.Sql.GetSql("Pharmacy.Item.DrugSpeUnit.GetSpeUnitList", ref strSql) == -1)
            {
                this.Err = "根据Sql索引Pharmacy.Item.DrugSpeUnit.GetSpeUnitList查找Sql出错 \n" + this.Err;
                return null;
            }

            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit speUnit;
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "获取药品特殊单位信息出错！" + this.Err;
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    speUnit = new DrugSpeUnit();
                    speUnit.Item.ID = this.Reader[0].ToString();
                    speUnit.Item.Name = this.Reader[1].ToString();
                    speUnit.Item.Specs = this.Reader[2].ToString();
                    speUnit.Item.PackUnit = this.Reader[3].ToString();
                    speUnit.Item.PackQty = NConvert.ToDecimal(this.Reader[4].ToString());
                    speUnit.Item.MinUnit = this.Reader[5].ToString();

                    al.Add(speUnit);
                }
            }
            catch (Exception ex)
            {
                this.Err = "由Sql语句读取特殊单位信息时发生错误" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        #endregion

        #region 外部接口

        /// <summary>
        /// 根据指定类别 获取取整后的特殊单位、转换取整数量
        /// 以最小单位数量显示
        /// </summary>
        /// <param name="unitType">类别</param>
        /// <param name="item">药品实体</param>
        /// <param name="originalNum">原始传入数量 以最小单位显示</param>
        /// <param name="splitNum">转换后取整数量 以最小单位显示</param>
        /// <param name="splitUnit">该类别对应的特殊单位</param>
        /// /// <param name="standNum">每个特殊单位对应最小单位数量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int QuerySpeUnit(string unitType, Neusoft.HISFC.Models.Pharmacy.Item item, decimal originalNum, out decimal splitNum, out string splitUnit, out decimal standNum)
        {
            splitNum = originalNum;
            splitUnit = item.MinUnit;
            standNum = 1;

            string strSql = "";
            string strWhere = "";

            if (this.Sql.GetSql("Pharmacy.Item.DrugSpeUnit.GetSpeUnit", ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DrugSpeUnit.GetSpeUnit字段!";
                return -1;
            }
            if (this.Sql.GetSql("Pharmacy.Item.DrugSpeUnit.GetSpeUnit.ByTypeDrugCode", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DrugSpeUnit.GetSpeUnit.ByTypeDrugCode字段!";
                return -1;
            }
            try
            {
                strSql = strSql + strWhere;
                strSql = string.Format(strSql, item.ID, unitType);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DrugSpeUnit.GetSpeUnit:" + ex.Message;
                return -1;
            }
            ArrayList al = this.myGetSpeUnit(strSql);
            if (al != null && al.Count > 0)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit speUnit = al[0] as Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit;
                if (speUnit != null && speUnit.Qty > 0)
                {
                    splitNum = (decimal)System.Math.Ceiling((double)(originalNum / speUnit.Qty)) * speUnit.Qty;
                    splitUnit = speUnit.Unit;
                    standNum = speUnit.Qty;
                }
            }
            return 1;
        }

        /// <summary>
        /// 返回门诊取整数量
        /// </summary>
        /// <param name="item">药品实体</param>
        /// <param name="originalNum">原始传入数量 以最小单位计算</param>
        /// <param name="splitNum">转换后取整数量 以最小单位显示</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int QuerySpeUnitForClinic(Neusoft.HISFC.Models.Pharmacy.Item item, decimal originalNum, out decimal splitNum)
        {
            string unit = "";
            decimal standNum;
            return this.QuerySpeUnit("Clinic", item, originalNum, out splitNum, out unit, out standNum);
        }

        /// <summary>
        /// 盘点该药品对该类型是否设置了多级单位
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="unitType">类型</param>
        /// <returns>已做过维护返回True 否则返回False</returns>
        public bool JudgeDrugSpe(string drugCode, string unitType)
        {
            ArrayList al = this.QuerySpeUnit(drugCode);
            if (al == null || al.Count <= 0)
                return false;
            foreach (Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit info in al)
            {
                if (info.UnitType.ID == unitType)
                    return true;
            }
            return false;
        }

        #endregion

        #endregion

        #region 药品转换

        /// <summary>
        /// 药品转换  扣减A药品库存 增加到B药品上
        /// </summary>
        ///<param name="stockDept">库存科室编码</param>
        ///<param name="originalDrug">原始药品</param>
        ///<param name="invertDrug">转换后药品</param>
        ///<param name="invertQty">转换数量 以最小单位表示</param>
        /// <param name="privOutType">用户定义出库权限类型</param>
        /// <param name="privInType">用户定义入库权限类型</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int DrugCoversion(string stockDept, Neusoft.HISFC.Models.Pharmacy.Item originalDrug, Neusoft.HISFC.Models.Pharmacy.Item invertDrug, decimal invertQty, string privOutType, string privInType)
        {
            Neusoft.HISFC.Models.Pharmacy.Storage originalStorage = this.GetStockInfoByDrugCode(stockDept, originalDrug.ID);
            if (originalStorage == null)
                return -1;
            if (originalStorage.StoreQty < invertQty)
            {
                this.Err = originalDrug.Name + "库存不足 不足以进行转换";
                return -1;
            }
            Neusoft.HISFC.Models.Pharmacy.Storage invertStorage = this.GetStockInfoByDrugCode(stockDept, invertDrug.ID);
            if (invertStorage == null)
                return -1;

            DateTime sysTime = this.GetDateTimeFromSysDateTime();

            string listCode = this.GetListCode(stockDept);
            if (listCode == null)
            {
                this.Err = "获取入出库单据号发生错误" + this.Err;
                return -1;
            }

            #region 自减少出库
            Neusoft.HISFC.Models.Pharmacy.Output speOut = new Output();

            speOut.Item = originalDrug;
            speOut.Quantity = invertQty;
            speOut.OutListNO = listCode;
            speOut.State = "2";
            speOut.SpecialFlag = "1";
            speOut.Class2Type = "0320";
            speOut.PrivType = privOutType;
            //speOut.PrivType = "0320";
            speOut.SystemType = "26";				//特殊出库 自减少出库
            speOut.StockDept.ID = stockDept;
            speOut.TargetDept.ID = stockDept;
            speOut.Operation.ExamOper.ID = this.Operator.ID;
            speOut.Operation.ExamOper.OperTime = sysTime;
            speOut.Operation.ExamQty = speOut.Quantity;
            speOut.DrugedBillNO = "1";
            speOut.Operation.ApplyOper.ID = this.Operator.ID;
            speOut.Operation.ApplyOper.OperTime = sysTime;
            speOut.Operation.ApproveOper.ID = this.Operator.ID;
            speOut.Operation.ApproveOper.OperTime = sysTime;

            if (this.Output(speOut, null, false) == -1)
                return -1;

            #endregion

            #region 自增加入库
            Neusoft.HISFC.Models.Pharmacy.Input speIn = new Input();

            speIn.Item = invertDrug;
            speIn.Quantity = invertQty;
            speIn.InListNO = listCode;
            speIn.State = "2";
            speIn.SpecialFlag = "1";
            //speIn.PrivType = "0310";
            speIn.Class2Type = "0310";
            speIn.PrivType = privInType;
            speIn.SystemType = "1C";
            speIn.StockDept.ID = stockDept;
            speIn.TargetDept.ID = stockDept;
            speIn.Operation.ExamOper.ID = this.Operator.ID;
            speIn.Operation.ExamOper.OperTime = sysTime;
            speIn.Operation.ExamQty = speIn.Quantity;
            speIn.GroupNO = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetNewGroupNO());
            speIn.BatchNO = originalStorage.BatchNO;
            speIn.ValidTime = originalStorage.ValidTime;
            speIn.Producer = originalStorage.Producer;
            speIn.Company = originalStorage.Company;
            speIn.StoreQty = invertStorage.StoreQty + speIn.Quantity;
            speIn.Operation.ApplyOper.ID = this.Operator.ID;
            speIn.Operation.ApplyOper.OperTime = sysTime;
            speIn.Operation.ApproveOper.ID = this.Operator.ID;
            speIn.Operation.ApproveOper.OperTime = sysTime;

            if (this.Input(speIn, "1") == -1)
                return -1;

            #endregion

            return 1;
        }

        #endregion

        #region 患者库存

        #region 基础增、删、改操作

        /// <summary>
        /// 插入患者药品库存表
        /// </summary>
        /// <param name="store">患者库存管理实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertPatientStore(Neusoft.HISFC.Models.Pharmacy.PatientStore store)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.PatientStore.Insert", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.PatientStore.Insert字段!";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = this.GetPatientStoreParameter(store);
                //替换SQL语句中的参数
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PatientStore.Insert:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除患者药品库存表中得记录
        /// </summary>
        /// <param name="type">类型0患者库存1科室取整库存</param>
        /// <param name="stockdept">库存科室编码</param>
        /// <param name="indept">患者所在科室编码</param>
        /// <param name="inpatientno">患者住院号</param>
        /// <param name="drugcode">药品编码</param>
        /// <returns>成功返回1失败返回-1</returns>
        public int DeletePatientStore(string type, string stockdept, string indept, string inpatientno, string drugcode)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.PatientStore.Delete", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.PatientStore.Delete字段!";
                return -1;
            }
            try
            {
                //格式化SQL语句
                string[] parm = { type, stockdept, indept, inpatientno, drugcode };
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL, parm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PatientStore.Delete:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据患者科室更新患者库存数量
        /// </summary>
        /// <param name="type">类型0患者库存1科室取整库存</param>
        /// <param name="indept">患者所在科室编码</param>
        /// <param name="drugcode">药品编码</param>
        /// <param name="storeQty">药品数量</param>
        /// <returns>成功返回1失败返回-1</returns>
        public int UpdatePatientStoreQty(string type, string indept, string drugcode, decimal storeQty)
        {
            return this.UpdatePatientStoreQty(type, indept, "AAAA", drugcode, storeQty);
        }

        /// <summary>
        /// 根据患者住院号更新患者库存数量
        /// </summary>
        /// <param name="type">类型0患者库存1科室取整库存</param>
        /// <param name="indept">患者所在科室编码</param>
        /// <param name="inpatientno">患者住院号</param>
        /// <param name="drugcode">药品编码</param>
        /// <param name="storeQty">药品数量</param>
        /// <returns>成功返回1失败返回-1</returns>
        public int UpdatePatientStoreQty(string type, string indept, string inpatientno, string drugcode, decimal storeQty)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.PatientStore.Update.Qty", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.PatientStore.Update.Qty字段!";
                return -1;
            }
            try
            {
                //格式化SQL语句
                string[] parm = { type, indept, drugcode, storeQty.ToString() };
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL, parm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PatientStore.Update.Qty:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据住院号更新患者库存收费标志
        /// </summary>
        /// <param name="type">类型0患者库存1科室取整库存</param>
        /// <param name="indept">患者所在科室编码</param>
        /// <param name="inpatientno">患者住院号</param>
        /// <param name="drugcode">药品编码</param>
        /// <param name="ischarge">收费标志</param>
        /// <param name="feeoper">收费人</param>
        /// <param name="feedate">收费时间</param>
        /// <returns>成功返回1失败返回-1</returns>
        public int UpdatePatientStoreFeeFlag(string type, string indept, string inpatientno, string drugcode, string ischarge, string feeoper, DateTime feedate)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.PatientStore.Update.FeeFlag", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.PatientStore.Update.FeeFlag字段!";
                return -1;
            }
            try
            {
                //格式化SQL语句
                string[] parm = { type, indept, inpatientno, drugcode, ischarge, feeoper, feedate.ToString() };
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL, parm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PatientStore.Update.FeeFlag:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据患者科室更新科室药品库存收费标志
        /// </summary>
        /// <param name="type">类型0患者库存1科室取整库存</param>
        /// <param name="indept">患者所在科室编码</param>
        /// <param name="drugcode">药品编码</param>
        /// <param name="ischarge">收费标志</param>
        /// <param name="feeoper">收费人</param>
        /// <param name="feedate">收费时间</param>
        /// <returns>成功返回1失败返回-1</returns>
        public int UpdatePatientStoreFeeFlag(string type, string indept, string drugcode, string ischarge, string feeoper, DateTime feedate)
        {
            return this.UpdatePatientStoreFeeFlag(type, indept, "AAAA", drugcode, ischarge, feeoper, feedate);
        }

        /// <summary>
        /// 更新患者库存信息表
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public int UpdatePatientStore(PatientStore store)
        {
            string strSQL = "";
            //取操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.PatientStore.Update.All", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.PatientStore.Update.All字段!";
                return -1;
            }
            try
            {
                if (store.PatientInfo.ID == "" || store.PatientInfo.ID == null)
                {
                    store.PatientInfo.ID = "AAAA";
                }
                //取参数列表
                string[] strParm = this.GetPatientStoreParameter(store);
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PatientStore.Update.All:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 根据科室获取科室取整库存信息
        /// </summary>
        /// <param name="type">类型 0患者库存 1科室取整库存 2 病区取整库存</param>
        /// <param name="indept">患者所在科室编码</param>
        /// <param name="drugcode">药品编码</param>
        /// <returns>成功返回PatientStore实体 失败返回null 无记录返回空实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.PatientStore GetPatientStore(string type, string indept, string drugcode)
        {
            return this.GetPatientStore(type, indept, "AAAA", drugcode);
        }

        /// <summary>
        /// 根据患者住院号获取患者库存信息
        /// </summary>
        /// <param name="type">类型 0患者库存 1科室取整库存 2 病区取整库存</param>
        /// <param name="indept">患者所在科室编码</param>
        /// <param name="inpatientno">患者住院号</param>
        /// <param name="drugcode">药品编码</param>
        /// <returns>成功返回PatientStore实体 失败返回null 无记录返回空实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.PatientStore GetPatientStore(string type, string indept, string inpatientno, string drugcode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.PatientStore.Get.Qty.ByPatient", ref strSQL) == -1)
            {
                this.Err = "Pharmacy.PatientStore.Get.Qty.ByPatient!";
                return null;
            }
            //格式化SQL语句
            string[] parm = { type, indept, inpatientno, drugcode };
            strSQL = string.Format(strSQL, parm);

            Neusoft.HISFC.Models.Pharmacy.PatientStore patientStore = new PatientStore();
            List<Neusoft.HISFC.Models.Pharmacy.PatientStore> alPatientStore = this.GetPatientStoreInfo(strSQL);
            if (alPatientStore == null)
                return null;
            if (alPatientStore.Count == 0)
                return patientStore;
            else
                return alPatientStore[0] as Neusoft.HISFC.Models.Pharmacy.PatientStore;
        }

        /// <summary>
        /// 查询某一科室全部患者的药品库存
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="indept">患者科室</param>
        /// <returns>科室患者药品库存列表</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.PatientStore> QueryPatientStore(string type, string indept)
        {
            return this.QueryPatientStore(type, indept, "AAAA");
        }

        /// <summary>
        /// 查询某一科室某一患者的药品库存
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="indept">患者科室</param>
        /// <param name="inpatientno">住院号</param>
        /// <returns>科室患者药品库存列表</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.PatientStore> QueryPatientStore(string type, string indept, string inpatientno)
        {

            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.PatientStore.Get.Qty.ByPatient", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.PatientStore.Get.Qty.ByPatient字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                string[] parm ={ type, indept, inpatientno };
                strSQL = string.Format(strSQL, parm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.PatientStore.Get.Qty.ByPatient:" + ex.Message;
                return null;
            }

            return this.GetPatientStoreInfo(strSQL);
        }

        #endregion

        #region 内部使用

        /// <summary>
        /// 获取患者库存管理参数数组
        /// </summary>
        /// <param name="store">患者库存管理实体</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        protected string[] GetPatientStoreParameter(PatientStore store)
        {
            try
            {
                string[] parm = {
                                   store.Type,                              //类型:0患者取整库存 1科室取整库存 2病区取整库存;
                                   store.InDept.ID,                         //患者科室
                                   store.PatientInfo.ID,                    //住院流水号 科室取整时为"AAAA"
                                   store.PatientInfo.Name,                  // 患者姓名
                                   store.Item.ID,                           //药品编码
                                   store.Item.Specs,                        //规格
                                   store.Item.PackQty.ToString(),           //包装数量
                                   store.Item.PackUnit,                     //包装单位
                                   store.Item.MinUnit,                      //最小单位
                                   store.Item.PriceCollection.RetailPrice.ToString(),   //零售价
                                   store.StoreQty.ToString(),               //库存数量
                                   store.ValidTime.ToString(),              //有效期       在此有效期内允许对库存扣减
                                   store.IsCharge?"1":"0",                  //是否计费 0 未计费 1 已计费
                                   store.FeeOper.ID,                        //收费人
                                   store.FeeOper.OperTime.ToString(),       //收费时间
                                   store.Oper.ID,                           //操作人
                                   store.Oper.OperTime.ToString(),          //操作时间
                                   store.Extend                             //扩展字段
								 };
                return parm;
            }
            catch (Exception ex)
            {
                this.Err = "由实体获取参数数组时发生异常 \n" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行Sql语句 返回患者库存信息数组
        /// </summary>
        /// <param name="strSQL">需执行的Sql语句</param>
        /// <returns>成功返回患者库存信息数组 失败返回null</returns>
        protected List<Neusoft.HISFC.Models.Pharmacy.PatientStore> GetPatientStoreInfo(string strSQL)
        {
            List<PatientStore> al = new List<PatientStore>();
            Neusoft.HISFC.Models.Pharmacy.PatientStore patientStore;

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "查询患者库存信息，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    patientStore = new PatientStore();

                    patientStore.Type = this.Reader[0].ToString();                          //类型:0患者取整库存 1科室取整库存2病区取整库存;                    
                    patientStore.InDept.ID = this.Reader[1].ToString();                     //患者科室
                    patientStore.PatientInfo.ID = this.Reader[2].ToString();                //住院流水号 科室取整时为"AAAA"
                    patientStore.PatientInfo.Name = this.Reader[3].ToString();              // 患者姓名
                    patientStore.Item.ID = this.Reader[4].ToString();                       //药品编码
                    patientStore.Item.Specs = this.Reader[5].ToString();                    //规格
                    patientStore.Item.PackQty = NConvert.ToDecimal(this.Reader[6].ToString());      //包装数量
                    patientStore.Item.PackUnit = this.Reader[7].ToString();                         //包装单位
                    patientStore.Item.MinUnit = this.Reader[8].ToString();                          //最小单位
                    patientStore.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[9].ToString());    //零售价
                    patientStore.StoreQty = NConvert.ToDecimal(this.Reader[10].ToString());         //库存数量
                    patientStore.ValidTime = NConvert.ToDateTime(this.Reader[11].ToString());       //有效期       在此有效期内允许对库存扣减
                    patientStore.IsCharge = NConvert.ToBoolean(this.Reader[12].ToString());         //是否计费 0 未计费 1 已计费
                    patientStore.FeeOper.ID = this.Reader[13].ToString();                           //收费人
                    patientStore.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[14].ToString());//收费时间
                    patientStore.Oper.ID = this.Reader[15].ToString();                              //操作人
                    patientStore.Oper.OperTime = NConvert.ToDateTime(this.Reader[16].ToString());   //操作时间
                    patientStore.Extend = this.Reader[17].ToString();                               //扩展字段

                    al.Add(patientStore);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询患者库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        #endregion

        /// <summary>
        /// 对患者管理库存的药品进行出库处理
        /// </summary>
        /// <param name="execOrder">医嘱执行实体</param>
        /// <param name="feeFlag">计费标志 0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费</param>
        /// <param name="isFee">是否已收费 feeFlag 为 "0" 时该参数才有意义</param>
        /// <param name="feeNum">计费数量 isFee为true时本参数才有效</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int PatientStore(Neusoft.HISFC.Models.Order.ExecOrder execOrder, ref string feeFlag, ref decimal feeNum, ref bool isFee)
        {
            #region 初始化及传入数据有效性判断

            feeFlag = "2";
            feeNum = 0;
            isFee = true;
            //if (!execOrder.Order.Item.IsPharmacy)
            if (execOrder.Order.Item.ItemType == EnumItemType.UnDrug)
            {
                this.Err = "非药品不能进行摆药处理";
                return -1;
            }
            Neusoft.HISFC.Models.Pharmacy.Item itemPha = execOrder.Order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
            if (itemPha == null)
            {
                this.Err = "传入的医嘱执行实体内项目为非药品 " + execOrder.Order.Item.Name;
                return -1;
            }

            #endregion

            //获取配药属性信息
            string drugProperty = this.GetDrugProperty(execOrder.Order.Item.ID, itemPha.DosageForm.ID, execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID);
            //获取当日日期
            DateTime sysTime = this.GetDateTimeFromSysDateTime();
            //医嘱数量
            execOrder.Order.Qty = System.Convert.ToDecimal(execOrder.Order.DoseOnce) / itemPha.BaseDose;

            //患者信息
            Neusoft.FrameWork.Models.NeuObject patientInfo = new Neusoft.FrameWork.Models.NeuObject();
            //患者科室信息
            Neusoft.FrameWork.Models.NeuObject patientDeptInfo = new Neusoft.FrameWork.Models.NeuObject();
            //取整类型 0 患者取整 1 科室病区 2 病区取整
            string storeType = "0";

            #region 根据不同配药属性 设置临时变量值

            switch (drugProperty)
            {
                case "3":               //患者库存当日取整
                    patientInfo.ID = execOrder.Order.Patient.ID;
                    patientInfo.Name = execOrder.Order.Patient.Name;

                    patientDeptInfo.ID = execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID;
                    patientDeptInfo.Name = execOrder.Order.Patient.PVisit.PatientLocation.Dept.Name;

                    storeType = "0";
                    break;
                case "4":               //科室库存取整
                    patientInfo.ID = "AAAA";
                    patientInfo.Name = "所有患者";

                    patientDeptInfo.ID = execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID;
                    patientDeptInfo.Name = execOrder.Order.Patient.PVisit.PatientLocation.Dept.Name;

                    storeType = "1";
                    break;
                case "5":               //病区库存取整
                    patientInfo.ID = "AAAA";
                    patientInfo.Name = "所有患者";

                    patientDeptInfo.ID = execOrder.Order.Patient.PVisit.PatientLocation.NurseCell.ID;
                    patientDeptInfo.Name = execOrder.Order.Patient.PVisit.PatientLocation.NurseCell.Name;

                    storeType = "2";
                    break;
                default:                //配药属性不是特殊取整类型 正常处理
                    feeFlag = "2";      //0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费
                    return 1;
            }

            #endregion

            Neusoft.HISFC.Models.Pharmacy.PatientStore patientStore = this.GetPatientStore(storeType, patientDeptInfo.ID, patientInfo.ID, itemPha.ID);
            if (patientStore == null)
                return -1;
            if (patientStore.PatientInfo.ID == "")
            {
                #region 患者库存内无该药品

                feeNum = (decimal)System.Math.Ceiling((double)execOrder.Order.DoseOnce / (double)itemPha.BaseDose);
                patientStore.Item = itemPha;			        //项目实体
                patientStore.PatientInfo = patientInfo;         //患者信息
                patientStore.InDept = patientDeptInfo;          //患者所在科室/病区
                patientStore.Type = storeType;
                //库存数量 取整后减去本次医嘱量
                patientStore.StoreQty = feeNum - execOrder.Order.Qty;
                patientStore.ValidTime = sysTime.Date;	        //有效期 存储当日日期
                patientStore.Oper.ID = this.Operator.ID;
                patientStore.Oper.OperTime = sysTime;
                patientStore.IsCharge = true;
                patientStore.FeeOper.ID = this.Operator.ID;
                patientStore.FeeOper.OperTime = sysTime;

                if (this.InsertPatientStore(patientStore) == -1)
                {
                    return -1;
                }
                feeFlag = "1";					//0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费

                #endregion

                return 1;
            }
            else
            {
                #region 患者库存内已有该药品记录 根据有效期进行处理

                if (patientStore.StoreQty < execOrder.Order.Qty || patientStore.ValidTime.Date < sysTime.Date)
                {
                    #region 原库存记录数量清零 更新为本次应剩库存量

                    feeNum = (decimal)System.Math.Ceiling((double)execOrder.Order.DoseOnce / (double)itemPha.BaseDose);
                    patientStore.Item = itemPha;
                    patientStore.PatientInfo = patientInfo;
                    patientStore.InDept = patientDeptInfo;
                    patientStore.Type = storeType;
                    patientStore.StoreQty = feeNum - execOrder.Order.Qty;		//清空原库存量 更新为本次量
                    patientStore.ValidTime = sysTime.Date;		//存储当天日期
                    patientStore.Oper.ID = this.Operator.ID;
                    patientStore.Oper.OperTime = sysTime;
                    patientStore.IsCharge = true;
                    patientStore.FeeOper.ID = this.Operator.ID;
                    patientStore.FeeOper.OperTime = sysTime;

                    if (this.UpdatePatientStore(patientStore) != 1)
                    {
                        return -1;
                    }
                    feeFlag = "1";					//0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费

                    #endregion

                    return 1;
                }
                if (patientStore.StoreQty >= execOrder.Order.Qty)
                {
                    #region 满足更新条件 更新患者库存

                    patientStore.Item = itemPha;
                    patientStore.PatientInfo = patientInfo;
                    patientStore.InDept = patientDeptInfo;
                    patientStore.Type = storeType;
                    patientStore.StoreQty = -execOrder.Order.Qty;
                    patientStore.ValidTime = sysTime.Date;		//存储当天日期
                    patientStore.Oper.ID = this.Operator.ID;
                    patientStore.Oper.OperTime = sysTime;

                    if (this.UpdatePatientStoreQty(storeType, patientDeptInfo.ID, patientInfo.ID, itemPha.ID, patientStore.StoreQty) != 1)
                    {
                        return -1;
                    }
                    feeFlag = "0";				//0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费
                    isFee = patientStore.IsCharge;

                    #endregion

                    return 1;
                }

                #endregion
            }

            return 1;
        }

        #endregion

        #region 入库/采购计划操作

        #region 入库计划基础增、删、改操作

        ///<summary>
        ///获得update或者insert入库计划明细信息传入参数数组
        ///</summary>
        ///<param name="inPlan">入库计划信息实体</param>
        ///<returns>字符串数组 失败返回null</returns>
        private string[] myGetParmInPlan(Neusoft.HISFC.Models.Pharmacy.InPlan inPlan)
        {
            string[] strParam = {
									inPlan.ID,                                              // 入库计划单流水号
									inPlan.BillNO,                                          // 采购单号
									inPlan.State,                                           // 状态 0计划单，1采购单，2审核，3已入库 4 作废计划单
									inPlan.PlanType,                                        // 类型 0手工计划，1警戒线，2消耗，3时间，4日消耗
									inPlan.Dept.ID,                                         // 科室编码
									inPlan.Item.ID,                                         // 药品编码
									inPlan.Item.Name,                                       // 药品名称
									inPlan.Item.Specs,                                      // 药品规格
									inPlan.Item.PriceCollection.RetailPrice.ToString(),     // 药品零售价
									inPlan.Item.PriceCollection.WholeSalePrice.ToString(),  // 药品批发价
									inPlan.Item.PriceCollection.PurchasePrice.ToString(),   // 药品购入价
									inPlan.Item.PackUnit,                                   // 药品包装单位
									inPlan.Item.PackQty.ToString(),	                        // 药品包装数量
									inPlan.Item.MinUnit,	                                // 药品最小单位
									inPlan.Item.Product.Producer.ID,                        // 药品生产厂家编码
									inPlan.Item.Product.Producer.Name,                      // 药品生产厂家名称
									inPlan.StoreQty.ToString(),                             // 本科室库存数量
									inPlan.StoreTotQty.ToString(),                          // 全院库存数量
									inPlan.OutputQty.ToString(),	                        // 全院出库总量
									inPlan.PlanQty.ToString(),		                        // 计划入库量
									inPlan.PlanOper.ID,		                                // 计划人
									inPlan.PlanOper.OperTime.ToString(),	                // 计划日期
									inPlan.StockOper.ID,		                            // 采购人
									inPlan.StockOper.OperTime.ToString(),	                // 采购日期
                                    inPlan.StockNO,                                         //采购流水号
                                    inPlan.ReplacePlanNO,                                   //作废、替代流水号
									inPlan.Memo,		                                    // 备注
									inPlan.Oper.ID,		                                    // 操作员
									inPlan.Oper.OperTime.ToString(),
                                    inPlan.Extend                                           //扩展字段
                                    //inPlan.SortNO.ToString()                                //顺序号
								};

            return strParam;
        }

        /// <summary>
        /// 取入库计划信息列表，可能是一条或者多条
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="sqlStr">SQL语句</param>
        /// <returns>入库计划信息数组</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.InPlan> myGetInPlan(string sqlStr)
        {
            List<Neusoft.HISFC.Models.Pharmacy.InPlan> al = new List<InPlan>();
            Neusoft.HISFC.Models.Pharmacy.InPlan inPlan; //入库计划明细信息实体

            //执行查询语句
            if (this.ExecQuery(sqlStr) == -1)
            {
                this.Err = "获得入库计划明细信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    inPlan = new Neusoft.HISFC.Models.Pharmacy.InPlan();
                    inPlan.ID = this.Reader[0].ToString();                                  // 入库计划单流水号
                    inPlan.BillNO = this.Reader[1].ToString();                              // 采购单号
                    inPlan.State = this.Reader[2].ToString();                               // 状态0计划单，1采购单，2审核，3已入库 4 作废计划单
                    inPlan.PlanType = this.Reader[3].ToString();                            // 采购类型0手工计划，1警戒线，2消耗，3时间，4日消耗
                    inPlan.Dept.ID = this.Reader[4].ToString();                             // 科室编码 
                    inPlan.Item.ID = this.Reader[5].ToString();                             // 药品编码
                    inPlan.Item.Name = this.Reader[6].ToString();                           // 药品名称
                    inPlan.Item.Specs = this.Reader[7].ToString();                          // 药品规格
                    inPlan.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString());        // 药品零售价
                    inPlan.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[9].ToString());     // 药品批发价
                    inPlan.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[10].ToString());     // 药品购入价(最新购入价)
                    inPlan.Item.PackUnit = this.Reader[11].ToString();		                // 药品包装单位
                    inPlan.Item.PackQty = NConvert.ToDecimal(this.Reader[12].ToString());	// 药品包装数量
                    inPlan.Item.MinUnit = this.Reader[13].ToString();	                    // 药品最小单位
                    inPlan.Item.Product.Producer.ID = this.Reader[14].ToString();           // 药品生产厂家编码
                    inPlan.Item.Product.Producer.Name = this.Reader[15].ToString();         // 药品生产厂家名称
                    inPlan.StoreQty = NConvert.ToDecimal(this.Reader[16].ToString());       // 本科室库存数量
                    inPlan.StoreTotQty = NConvert.ToDecimal(this.Reader[17].ToString());    // 全院库存数量
                    inPlan.OutputQty = NConvert.ToDecimal(this.Reader[18].ToString());		// 全院出库总量
                    inPlan.PlanQty = NConvert.ToDecimal(this.Reader[19].ToString());		// 计划入库量
                    inPlan.PlanOper.ID = this.Reader[20].ToString();			            // 计划人
                    inPlan.PlanOper.OperTime = NConvert.ToDateTime(this.Reader[21].ToString());		// 计划日期
                    inPlan.StockOper.ID = this.Reader[22].ToString();			            // 采购人
                    inPlan.StockOper.OperTime = NConvert.ToDateTime(this.Reader[23].ToString());	// 采购日期
                    inPlan.StockNO = this.Reader[24].ToString();                            //采购流水号
                    inPlan.ReplacePlanNO = this.Reader[25].ToString();                      //作废、替代流水号
                    inPlan.Memo = this.Reader[26].ToString();			                    // 备注
                    inPlan.Oper.ID = this.Reader[27].ToString();		                    // 操作员
                    inPlan.Oper.OperTime = NConvert.ToDateTime(this.Reader[28].ToString()); // 操作时间
                    inPlan.Extend = this.Reader[29].ToString();
                    //inPlan.SortNO = NConvert.ToDecimal(this.Reader[30].ToString());        //顺序号

                    al.Add(inPlan);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得入库计划明细信息信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 向采购计划表内插入一条记录
        /// </summary>
        /// <param name="inPlan">入库计划实体</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertInPlan(Neusoft.HISFC.Models.Pharmacy.InPlan inPlan)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.InsertInPlan", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertInPlan字段!";
                return -1;
            }
            try
            {
                //取流水号
                inPlan.ID = this.GetSequence("Pharmacy.Item.GetStockPlanID");
                if (inPlan.ID == null)
                    return -1;

                string[] strParm = this.myGetParmInPlan(inPlan);     //取参数列表

                strSQL = string.Format(strSQL, strParm);                     //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.InsertInPlan:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新入库计划表中一条记录，根据流水号更新 只能对状态不为2、3、4的更新
        /// </summary>
        /// <param name="inPlan">入库计划类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateInPlan(Neusoft.HISFC.Models.Pharmacy.InPlan inPlan)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateInPlan", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateInPlan字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmInPlan(inPlan);     //取参数列表

                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateInPlan:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除采购计划表中一条记录
        /// </summary>
        /// <param name="inPlanNO"></param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int DeleteInPlan(string inPlanNO)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteInPlan.PlanNO", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteInPlan.PlanNO字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, inPlanNO);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DeleteInPlan.PlanNO:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对入库计划单进行整单删除
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="billNO">入库计划单号</param>
        /// <returns></returns>
        public int DeleteInPlan(string deptCode, string billNO, string oldState)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteInPlan.Bill", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteInPlan.Bill字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, billNO, oldState);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DeleteInPlan.Bill:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 入库计划方法

        /// <summary>
        /// 根据入库计划单据号检索入库计划信息
        /// </summary>
        /// <param name="deptNO">科室编码</param>
        /// <param name="billNO">单据号</param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Pharmacy.InPlan> QueryInPlanDetail(string deptNO, string billNO)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryInPlanDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryInPlanDetail字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryInPlanDetail.BillNO", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryInPlanDetail.BillNO字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptNO, billNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryInPlanDetail:" + ex.Message;
                return null;
            }

            return this.myGetInPlan(strSQL);
        }

        /// <summary>
        /// 根据多个入库计划单号检索入库计划信息
        /// </summary>
        /// <param name="deptNO">科室编码</param>
        /// <param name="isSortByBill">是否按单据号对计划信息进行排序 True 按单据号 False 按药品项目</param>
        /// <param name="billNO">入库计划单号</param>
        /// <returns>成功返回入库计划单明细信息</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.InPlan> QueryInPlanDetail(string deptNO, bool isSortByBill, params string[] billNO)
        {
            if (billNO.Length == 1)
                return QueryInPlanDetail(deptNO, billNO[0]);

            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryInPlanDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryInPlanDetail字段!";
                return null;
            }

            string multiBillNO = "";
            foreach (string strBillNO in billNO)
            {
                if (strBillNO == null || strBillNO == "")
                    continue;

                if (multiBillNO == "")
                    multiBillNO = strBillNO;
                else
                    multiBillNO = multiBillNO + "','" + strBillNO;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryInPlanDetail.MultiBillNO", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryInPlanDetail.MultiBillNO字段!";
                return null;
            }
            string strSort = "";
            //数据排序
            if (isSortByBill)           //按单据号排序
            {
                if (this.Sql.GetSql("Pharmacy.Item.QueryInPlanDetail.SortBill", ref strSort) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.QueryInPlanDetail.SortBill字段!";
                    return null;
                }
            }
            else                        //按药品项目排序
            {
                if (this.Sql.GetSql("Pharmacy.Item.QueryInPlanDetail.SortItem", ref strSort) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.QueryInPlanDetail.SortItem字段!";
                    return null;
                }
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere + strSort;
                strSQL = string.Format(strSQL, deptNO, multiBillNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryInPlanDetail:" + ex.Message;
                return null;
            }

            return this.myGetInPlan(strSQL);
        }

        /// <summary>
        /// 根据入库计划单流水号检索入库计划信息
        /// </summary>
        /// <param name="planNO">入库计划单流水号</param>
        /// <returns>成功返回入库计划明细信息，失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.InPlan> QueryInPlanDetail(string planNO)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryInPlanDetail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryInPlanDetail字段!";
                return null;
            }
            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryInPlanDetail.PlanNO", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryInPlanDetail.PlanNO字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, planNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryInPlanDetail:" + ex.Message;
                return null;
            }

            return this.myGetInPlan(strSQL);
        }

        /// <summary>
        /// 根据入库单状态获得入库单号、供货公司列表
        /// </summary>
        /// <param name="state">入库计划单状态</param>
        /// <param name="deptNO">库房编码</param>
        /// <returns></returns>
        public ArrayList QueryInPLanList(string deptNO, string state)
        {
            string strSQL = "";
            //取查找记录的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryInPlanList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryInPlanList字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, deptNO, state);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryInPlanList:" + ex.Message;
                this.WriteErr();
                return null;
            }
            ArrayList al = new ArrayList();

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得采购计划信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    //此语句不能加到循环外面，否则会在al数组内加入相同的数据（最后一条数据）
                    Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();            //入库单号
                    info.Name = this.Reader[1].ToString();          //计划人
                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得采购计划信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        ///<summary>
        ///根据日消耗获得入库计划
        ///</summary>
        ///<param name="deptNO">库房编码</param>
        ///<returns>成功返回数组，否则返回null</returns>
        public ArrayList InPLanByConsume(string deptNO)
        {
            string strSQL = "";
            //取药品出库总量的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.OutPutByConsume", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.OutPutByConsume字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, deptNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.OutPutByConsume:" + ex.Message;
                this.WriteErr();
                return null;
            }
            ArrayList al = new ArrayList();
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得药品出库总量信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    //此语句不能加到循环外面，否则会在al数组内加入相同的数据（最后一条数据）
                    Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();     //药品编码
                    info.Name = this.Reader[1].ToString();   //出库总量
                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得药品出库总量信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return null;
        }

        ///<summary>
        ///取入库计划单号
        ///</summary>
        ///<returns>成功返回调价单号：年月日＋四位流水号，失败返回null</returns>
        public string GetPlanBillNO(string deptNO)
        {
            string strSQL = "";
            string temp1, temp2;
            string newBillCode;
            //系统时间 yymmdd
            temp1 = this.GetSysDateNoBar().Substring(2, 6);
            //取最大入库计划单号
            if (this.Sql.GetSql("Pharmacy.Item.GetMaxInPlanBillCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetMaxInPlanBillCode字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetMaxInPlanBillCode:" + ex.Message;
                return null;
            }

            temp2 = this.ExecSqlReturnOne(strSQL);
            if (temp2.ToString() == "-1" || temp2.ToString() == "")
            {
                temp2 = "0001";
            }
            else
            {
                decimal i = NConvert.ToDecimal(temp2.Substring(6, 4)) + 1;
                temp2 = i.ToString().PadLeft(4, '0');
            }
            newBillCode = temp1 + temp2;

            return newBillCode;
        }

        /// <summary>
        /// 合并计划单  作废原计划单
        /// </summary>
        /// <param name="newPlanNO">合并后计划单流水号</param>
        /// <param name="cancelPlanNO">被合并的(作废计划单)</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int CancelInPlan(string newPlanNO, params string[] cancelPlanNO)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.CancelInPlan", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.CancelInPlan字段!";
                return -1;
            }
            try
            {
                string cancelParm = "";
                foreach (string strPlanNO in cancelPlanNO)
                {
                    if (cancelParm == "")
                    {
                        cancelParm = strPlanNO;
                    }
                    else
                    {
                        cancelParm = cancelParm + "','" + strPlanNO;
                    }
                }

                strSQL = string.Format(strSQL, newPlanNO, cancelParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.CancelInPlan:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 合并计划单 返回合并后的新计划单实体
        /// </summary>
        /// <param name="inPlanListNO">合并计划单号</param>
        /// <returns>成功返回合并后的新计划单信息 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.InPlan> MergeInPlan(string deptNO, params string[] inPlanListNO)
        {
            List<Neusoft.HISFC.Models.Pharmacy.InPlan> alOriginalInPlanDetail = this.QueryInPlanDetail(deptNO, false, inPlanListNO);
            if (alOriginalInPlanDetail == null)
            {
                this.Err = "根据多个单据号获取入库计划明细发生错误" + this.Err;
                return null;
            }

            if (inPlanListNO.Length == 1)
            {
                return alOriginalInPlanDetail;
            }

            DateTime sysTime = this.GetDateTimeFromSysDateTime();

            string privDrugNO = "";
            List<Neusoft.HISFC.Models.Pharmacy.InPlan> alAlterInPlan = new List<InPlan>();
            Neusoft.HISFC.Models.Pharmacy.InPlan alterInPlan = null;
            foreach (Neusoft.HISFC.Models.Pharmacy.InPlan info in alOriginalInPlanDetail)
            {
                if (privDrugNO == "")               //初始 处理第一条
                {
                    alterInPlan = info.Clone();

                    alterInPlan.ID = "";                                    //流水号
                    alterInPlan.BillNO = "";                                //单据号

                    alterInPlan.Oper.ID = this.Operator.ID;                 //操作人
                    alterInPlan.Oper.OperTime = sysTime;                    //操作时间
                    alterInPlan.PlanOper = alterInPlan.Oper;                //计划人

                    alterInPlan.ReplacePlanNO = info.ID;                    //原单据流水号

                    privDrugNO = info.Item.ID;                              //药品编码

                    continue;
                }
                if (privDrugNO == info.Item.ID)     //处理相同药品
                {
                    alterInPlan.PlanQty = alterInPlan.PlanQty + info.PlanQty;
                    alterInPlan.ReplacePlanNO = alterInPlan.ReplacePlanNO + "|" + info.ID;
                }
                else
                {
                    alAlterInPlan.Add(alterInPlan); //将上一条入库计划信息加入List

                    alterInPlan = info.Clone();

                    alterInPlan.ID = "";                                    //流水号
                    alterInPlan.BillNO = "";                                //单据号

                    alterInPlan.Oper.ID = this.Operator.ID;                 //操作人
                    alterInPlan.Oper.OperTime = sysTime;                    //操作时间
                    alterInPlan.PlanOper = alterInPlan.Oper;                //计划人

                    alterInPlan.ReplacePlanNO = info.ID;                    //原单据流水号

                    privDrugNO = info.Item.ID;
                }
            }

            if (alterInPlan != null)
            {
                alAlterInPlan.Add(alterInPlan);
            }

            return alAlterInPlan;
        }

        /// <summary>
        /// 采购计划制定后更新入库计划信息
        /// </summary>
        /// <param name="planNO"></param>
        /// <param name="stockNO"></param>
        /// <param name="stockOper"></param>
        /// <returns></returns>
        public int UpdateInPlanForStock(string planNO, string stockNO, Neusoft.HISFC.Models.Base.OperEnvironment stockOper)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateInPlanForStock", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateInPlanForStock字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, planNO, stockNO, stockOper.ID, stockOper.OperTime.ToString());            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateInPlanForStock:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 采购计划基础增、删、改操作

        ///<summary>
        ///获得update或者insert采购计划明细信息传入参数数组
        ///</summary>
        ///<param name="stockPlan">入库计划信息实体</param>
        ///<returns>字符串数组 失败返回null</returns>
        private string[] myGetParmStockPlan(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan)
        {
            string[] strParam = {
									stockPlan.ID,                                       // 采购计划单流水号
									stockPlan.BillNO,                                   // 采购单号
									stockPlan.State,                                    // 状态0计划单，1采购单，2审核，3已入库								
									stockPlan.Dept.ID,                                  // 科室编码
									stockPlan.Company.ID,                               // 供药公司编码
									stockPlan.Company.Name,                             // 供货公司名称
									stockPlan.Item.ID,                                  // 药品编码
									stockPlan.Item.Name,                                // 药品名称
									stockPlan.Item.Specs,                               // 药品规格
									stockPlan.Item.PriceCollection.RetailPrice.ToString(),      // 药品零售价
									stockPlan.Item.PriceCollection.WholeSalePrice.ToString(),   // 药品批发价
									stockPlan.Item.PriceCollection.PurchasePrice.ToString(),    // 药品购入价
									stockPlan.Item.PackUnit,                                    // 药品包装单位
									stockPlan.Item.PackQty.ToString(),	                        // 药品包装数量
									stockPlan.Item.MinUnit,	                                    // 药品最小单位
									stockPlan.Item.Product.Producer.ID,                         // 药品生产厂家编码
									stockPlan.Item.Product.Producer.Name,                       // 药品生产厂家名称
                                    NConvert.ToInt32(stockPlan.Item.TenderOffer.IsTenderOffer).ToString(), // 是否招标用药
									stockPlan.StoreQty.ToString(),                              // 本科室库存数量
									stockPlan.StoreTotQty.ToString(),                           // 全院库存数量
									stockPlan.OutputQty.ToString(),	                            // 全院出库总量
									stockPlan.PlanQty.ToString(),		                        // 计划入库量
									stockPlan.PlanOper.ID,		                                // 计划人
									stockPlan.PlanOper.OperTime.ToString(),	                    // 计划日期
                                    stockPlan.PlanNO,                                           // 计划单号									
									stockPlan.StockOper.ID,		                                // 采购人
									stockPlan.StockOper.OperTime.ToString(),	                // 采购日期
									stockPlan.StockApproveQty.ToString(),	                    // 采购数量
                                    stockPlan.StockPrice.ToString(),	                        // 计划购入价
									stockPlan.ApproveOper.ID,	                                // 审批人
									stockPlan.ApproveOper.OperTime.ToString(),	                // 审批时间
									stockPlan.InQty.ToString(),	                                // 实际入库数量
									stockPlan.InOper.ID,	                                    // 入库操作人
									stockPlan.InOper.OperTime.ToString(),		                // 入库时间
									stockPlan.InListNO,		                                    // 入库单据号
									stockPlan.Memo,		                                        // 备注
									stockPlan.Oper.ID,		                                    // 操作员
									stockPlan.Oper.OperTime.ToString(),
                                    stockPlan.Extend,                                           // 扩展操作员
								};

            return strParam;
        }

        /// <summary>
        /// 取采购计划信息列表，可能是一条或者多条
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>入库计划信息数组</returns>
        private ArrayList myGetStockPlan(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan; //入库计划明细信息实体

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得采购计划明细信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    stockPlan = new Neusoft.HISFC.Models.Pharmacy.StockPlan();

                    stockPlan.ID = this.Reader[0].ToString();                             // 入库计划单流水号
                    stockPlan.BillNO = this.Reader[1].ToString();                         // 采购单号
                    stockPlan.State = this.Reader[2].ToString();                          // 状态0计划单，1采购单，2审核，3已入库
                    stockPlan.Dept.ID = this.Reader[3].ToString();                        // 科室编码 
                    stockPlan.Company.ID = this.Reader[4].ToString();                     // 供药公司编码
                    stockPlan.Company.Name = this.Reader[5].ToString();                   // 供货公司名称
                    stockPlan.Item.ID = this.Reader[6].ToString();                        // 药品编码
                    stockPlan.Item.Name = this.Reader[7].ToString();                      // 药品名称
                    stockPlan.Item.Specs = this.Reader[8].ToString();                     // 药品规格
                    stockPlan.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[9].ToString());       // 药品零售价
                    stockPlan.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[10].ToString());   // 药品批发价
                    stockPlan.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[11].ToString());    // 药品购入价(最新购入价)
                    stockPlan.Item.PackUnit = this.Reader[12].ToString();		                    // 药品包装单位
                    stockPlan.Item.PackQty = NConvert.ToDecimal(this.Reader[13].ToString());	    // 药品包装数量
                    stockPlan.Item.MinUnit = this.Reader[14].ToString();	                        // 药品最小单位
                    stockPlan.Item.Product.Producer.ID = this.Reader[15].ToString();                // 药品生产厂家编码
                    stockPlan.Item.Product.Producer.Name = this.Reader[16].ToString();              // 药品生产厂家名称
                    stockPlan.Item.TenderOffer.IsTenderOffer = NConvert.ToBoolean(this.Reader[17]); // 是否招标用药
                    stockPlan.StoreQty = NConvert.ToDecimal(this.Reader[18].ToString());            // 本科室库存数量
                    stockPlan.StoreTotQty = NConvert.ToDecimal(this.Reader[19].ToString());         // 全院库存数量
                    stockPlan.OutputQty = NConvert.ToDecimal(this.Reader[20].ToString());		    // 全院出库总量
                    stockPlan.PlanQty = NConvert.ToDecimal(this.Reader[21].ToString());		        // 计划入库量
                    stockPlan.PlanOper.ID = this.Reader[22].ToString();			                    // 计划人
                    stockPlan.PlanOper.OperTime = NConvert.ToDateTime(this.Reader[23].ToString());	// 计划日期
                    stockPlan.PlanNO = this.Reader[24].ToString();                                  // 计划流水号
                    stockPlan.StockOper.ID = this.Reader[25].ToString();			                // 采购人
                    stockPlan.StockOper.OperTime = NConvert.ToDateTime(this.Reader[26].ToString());	// 采购日期
                    stockPlan.StockApproveQty = NConvert.ToDecimal(this.Reader[27].ToString());     // 采购数量
                    stockPlan.StockPrice = NConvert.ToDecimal(this.Reader[28].ToString());	        // 计划购入价                   
                    stockPlan.ApproveOper.ID = this.Reader[29].ToString();	                        // 审批人
                    stockPlan.ApproveOper.OperTime = NConvert.ToDateTime(this.Reader[30].ToString());	// 审批时间
                    stockPlan.InQty = NConvert.ToDecimal(this.Reader[31].ToString());		        //  实际入库数量
                    stockPlan.InOper.ID = this.Reader[32].ToString();	                            // 入库操作人
                    stockPlan.InOper.OperTime = NConvert.ToDateTime(this.Reader[33].ToString());    // 入库时间
                    stockPlan.InListNO = this.Reader[34].ToString();		                        // 入库单据号
                    stockPlan.Memo = this.Reader[35].ToString();			                        // 备注
                    stockPlan.Oper.ID = this.Reader[36].ToString();		                            // 操作员
                    stockPlan.Oper.OperTime = NConvert.ToDateTime(this.Reader[37].ToString());      // 操作时间
                    stockPlan.Extend = this.Reader[38].ToString();

                    al.Add(stockPlan);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得入库计划明细信息信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        /// <summary>
        /// 向采购计划表内插入一条记录
        /// </summary>
        /// <param name="stockPlan">入库计划类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertStockPlan(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.InsertStockPlan", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertStockPlan字段!";
                return -1;
            }
            try
            {
                //取流水号
                stockPlan.ID = this.GetSequence("Pharmacy.Item.GetStockPlanID");
                if (stockPlan.ID == null)
                    return -1;

                string[] strParm = this.myGetParmStockPlan(stockPlan);     //取参数列表

                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.InsertStockPlan:" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新采购计划表中一条记录，只能对所有状态 不等于2 的记录进行更新
        /// </summary>
        /// <param name="stockPlan">采购计划类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateStockPlan(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStockPlan", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateStockPlan字段!";
                return -1;
            }
            try
            {
                string[] strParm = this.myGetParmStockPlan(stockPlan);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateStockPlan:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新采购计划表中一条记录
        /// </summary>
        /// <param name="stockNO">采购计划号</param>
        /// <param name="inBillNO">入库单据号</param>
        /// <param name="inQty">实际入库量</param>
        /// <param name="inOper">入库人</param>
        /// <param name="state">状态</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateStockPlanForIn(string stockNO, decimal inQty, string inBillNO, Neusoft.HISFC.Models.Base.OperEnvironment inOper, string state)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStockPlanForIn", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateStockPlanForIn字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, stockNO, inQty.ToString(), inBillNO, inOper.ID, inOper.OperTime.ToString(), state);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateStockPlanForIn:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除采购计划表中一条记录
        /// </summary>
        /// <param name="deptNO">科室编码</param>
        /// <param name="billNO">计划单号</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int DeleteStockPlan(string deptNO, string billNO)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteStockPlan.BillNo", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteStockPlan.BillNo字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptNO, billNO);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DeleteStockPlan.BillNo:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对入库计划单进行整单删除
        /// </summary>
        /// <param name="stockNO">采购流水号</param>
        /// <returns></returns>
        public int DeleteStockPlan(string stockNO)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteStockPlan.StockNO", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteStockPlan.StockNO字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, stockNO);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DeleteStockPlan.StockNO:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 采购计划方法

        ///<summary>
        ///根据入库计划单号检索入库计划明细信息
        ///</summary>
        ///<param name="deptNO">库房编码</param>
        ///<param name="billNO">入库计划单号</param>
        ///<returns>入库计划信息数组 失败返回null</returns>
        public ArrayList QueryStockPlanDetail(string deptNO, string billNO)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlan", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanRecord字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetNoStockPlan.BillNo", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetNoStockPlan.BillNo字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptNO, billNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetNoStockPlanRecord:" + ex.Message;
                return null;
            }

            return this.myGetStockPlan(strSQL);

        }

        /// <summary>
        /// 根据入库计划单流水号检索入库计划信息
        /// </summary>
        /// <param name="planNO">入库计划单流水号</param>
        /// <returns>成功返回入库计划明细信息，失败返回null</returns>
        public ArrayList QueryStockPlanDetail(string planNO)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlan", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlan字段!";
                return null;
            }
            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlan.StockNo", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlan.StockNo字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, planNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetStockPlanByPlanNo:" + ex.Message;
                return null;
            }

            return this.myGetStockPlan(strSQL);
        }

        /// <summary>
        /// 获取药品的历史采购记录
        /// </summary>
        /// <param name="deptNO">库房编码</param>
        /// <param name="drugNO">药品编码</param>
        /// <returns>成功返回入库计划信息，失败返回null</returns>
        public ArrayList QueryHistoryStockPlan(string deptNO, string drugNO)
        {
            string strSQLWhere = "";
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlan", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlan字段!";
                return null;
            }
            //取查找记录的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryHistoryStockPlan", ref strSQLWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryHistoryStockPlan字段!";
                return null;
            }
            try
            {
                strSQL = strSQL + strSQLWhere;
                strSQL = string.Format(strSQL, deptNO, drugNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryHistoryStockPlan:" + ex.Message;
                this.WriteErr();
                return null;
            }

            //取入库计划单明细信息数据
            return this.myGetStockPlan(strSQL);
        }

        /// <summary>
        /// 根据采购单状态获得采购单号、供货公司列表
        /// </summary>
        /// <param name="state">采购计划单状态</param>
        /// <param name="deptNO">库房编码</param>
        /// <returns></returns>
        public ArrayList QueryStockPLanCompanayList(string deptNO, string state)
        {
            string strSQL = "";
            //取查找记录的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.QueryStockPLanCompanayList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.QueryStockPLanCompanayList字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, deptNO, state);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.QueryStockPLanCompanayList:" + ex.Message;
                this.WriteErr();
                return null;
            }
            ArrayList al = new ArrayList();

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得采购计划信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    //此语句不能加到循环外面，否则会在al数组内加入相同的数据（最后一条数据）
                    Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();            //采购单号
                    info.User01 = this.Reader[1].ToString();          //供货公司
                    info.Name = this.Reader[2].ToString();       //供货公司编码
                    info.User02 = this.Reader[3].ToString();        //科室编码
                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得采购计划信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return al;
        }

        ///<summary>
        ///根据科室编码、采购计划单号、供货公司检索采购计划单明细信息
        ///</summary>
        ///<param name="deptNO">库房编码</param>
        ///<param name="billNO">入库计划单号</param>
        ///<param name="companyNO">供货公司编码</param>
        ///<returns>成功返回数组，失败返回null</returns>
        public ArrayList QueryStockPlanByCompany(string deptNO, string billNO, string companyNO)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlan", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlan字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlan.Company", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlan.Company字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptNO, billNO, companyNO);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetStockPlan.Company:" + ex.Message;
                return null;
            }

            //取入库计划单明细信息数据
            return this.myGetStockPlan(strSQL);
        }

        ///<summary>
        ///取采购计划单号
        ///</summary>
        ///<returns>成功返回调价单号：年月日＋四位流水号，失败返回null</returns>
        public string GetStockBillCode(string deptcode)
        {
            string strSQL = "";
            string temp1, temp2;
            string newBillCode;
            //系统时间 yymmdd
            temp1 = this.GetSysDateNoBar().Substring(2, 6);
            //取最大采购计划单号
            if (this.Sql.GetSql("Pharmacy.Item.GetMaxStockBillCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetMaxStockBillCode字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptcode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetMaxStockBillCode:" + ex.Message;
                return null;
            }

            temp2 = this.ExecSqlReturnOne(strSQL);
            if (temp2.ToString() == "-1" || temp2.ToString() == "")
            {
                temp2 = "0001";
            }
            else
            {
                decimal i = NConvert.ToDecimal(temp2.Substring(6, 4)) + 1;
                temp2 = i.ToString().PadLeft(4, '0');
            }
            newBillCode = temp1 + temp2;

            return newBillCode;
        }

        /// <summary>
        /// 采购计划设置
        /// </summary>
        /// <param name="stockPlan">采购计划信息</param>
        /// <returns>成功返回1 失败返回-1 无数据返回0</returns>
        public int SetStockPlan(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan)
        {
            if (stockPlan.ID == "")
            {
                return this.InsertStockPlan(stockPlan);
            }

            int param = this.UpdateStockPlan(stockPlan);
            if (param == 0)
            {
                param = this.InsertStockPlan(stockPlan);
            }

            return param;
        }

        #endregion

        #region 采购计划保存 更新入库计划信息

        /// <summary>
        /// 采购计划保存
        /// </summary>
        /// <param name="stockPlan">采购计划信息</param>
        /// <returns>成功返回1 失败返回-1 无数据返回0</returns>
        public int SaveStockPlan(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan)
        {
            int param = this.SetStockPlan(stockPlan);
            if (param != 1)
            {
                return param;
            }
            ////采购计划状态为零 不对入库计划进行处理 尚未进入采购状态
            //if (stockPlan.State == "0")
            //{
            //    return 1;
            //}

            //if (stockPlan.PlanNO == null || stockPlan.PlanNO == "")
            //{
            //    return 1;
            //}

            //if (stockPlan.PlanNO.IndexOf("|") == -1)        //只有一个对应对应的入库单流水号
            //{
            //    param = this.UpdateInPlanForStock(stockPlan.PlanNO, stockPlan.ID, stockPlan.StockOper);
            //}
            //else
            //{
            //    string[] inPlanNOCollection = stockPlan.PlanNO.Split('|');
            //    foreach (string planNO in inPlanNOCollection)
            //    {
            //        param = this.UpdateInPlanForStock(planNO, stockPlan.ID, stockPlan.StockOper);
            //        if (param != 1)
            //        {
            //            this.Err = "更新入库计划流水号 " + planNO + " 入库计划信息未成功";
            //            return -1;
            //        }
            //    }                
            //}

            return param;
        }

        /// <summary>
        /// 采购计划保存
        /// </summary>
        /// <param name="stockPlanCollection">需保存的采购计划信息</param>
        /// <returns>成功返回1 失败返回-1 无操作数据返回0</returns>
        public int SaveStockPlan(List<Neusoft.HISFC.Models.Pharmacy.StockPlan> stockPlanCollection)
        {
            //保存采购计划中相关的入库计划信息 对入库计划进行更新
            System.Collections.Hashtable hsInPlanInfo = new Hashtable();

            Neusoft.HISFC.Models.Base.OperEnvironment stockOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

            foreach (Neusoft.HISFC.Models.Pharmacy.StockPlan info in stockPlanCollection)
            {
                int parma = this.SaveStockPlan(info);
                if (parma == -1)
                {
                    return -1;
                }
                else if (parma == 0)
                {
                    return 0;
                }
                //仍为计划单 则不处理以下信息
                if (info.State == "0")
                {
                    continue;
                }
                //保存采购人员信息
                stockOper = info.StockOper;
                //保存入库计划信息
                if (info.PlanNO.IndexOf("|") == -1)         //只有一个流水号
                {
                    this.AddPlanNOToHs(hsInPlanInfo, info.PlanNO, info.ID);
                }
                else                                        //多个流水号
                {
                    string[] planNOList = info.PlanNO.Split('|');
                    foreach (string planNO in planNOList)
                    {
                        this.AddPlanNOToHs(hsInPlanInfo, planNO, info.ID);
                    }
                }
            }

            #region 处理入库记录 更新入库计划信息内的采购记录

            foreach (string strPlanNO in hsInPlanInfo.Keys)
            {
                int parma = this.UpdateInPlanForStock(strPlanNO, hsInPlanInfo[strPlanNO] as string, stockOper);
                if (parma == -1)
                {
                    return -1;
                }
                else if (parma == 0)
                {
                    this.Err = "原入库计划单信息可能已修改 请重新选择计划单";
                    return 0;
                }
            }

            #endregion

            return 1;
        }

        private void AddPlanNOToHs(System.Collections.Hashtable hsInPlan, string inPlanNO, string stockPlanNO)
        {
            if (hsInPlan.ContainsKey(inPlanNO))         //已包含该入库计划流水号
            {
                //采购计划流水号累加
                hsInPlan[inPlanNO] = (hsInPlan[inPlanNO] as string) + "|" + stockPlanNO;
            }
            else
            {
                //增加计划流水号
                hsInPlan.Add(inPlanNO, stockPlanNO);
            }
        }

        #endregion

        #region 基础增、删、改操作

        /*

        ///<summary>
        ///获得update或者insert入库计划明细信息传入参数数组
        ///</summary>
        ///<param name="stockPlanRecord">入库计划信息实体</param>
        ///<returns>字符串数组 失败返回null</returns>
        private string[] myGetParmStockPlanRecord(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlanRecord)
        {
            switch (stockPlanRecord.State)
            {
                case "0":
                    stockPlanRecord.PlanOper.ID = this.Operator.ID;
                    stockPlanRecord.PlanOper.OperTime = this.GetDateTimeFromSysDateTime();
                    break;
                case "1":
                    stockPlanRecord.StockOper.ID = this.Operator.ID;
                    stockPlanRecord.StockOper.OperTime = this.GetDateTimeFromSysDateTime();
                    break;
                case "2":
                    stockPlanRecord.ApproveOper.ID = this.Operator.ID;
                    stockPlanRecord.ApproveOper.OperTime = this.GetDateTimeFromSysDateTime();
                    break;
                default:
                    stockPlanRecord.InOper.ID = this.Operator.ID;
                    stockPlanRecord.InOper.OperTime = this.GetDateTimeFromSysDateTime();
                    break;
            }

            string[] strParam = {
									stockPlanRecord.ID, //0 入库计划单流水号
									stockPlanRecord.BillNO, //1 采购单号
									stockPlanRecord.State, //2 单据状态0计划单，1采购单，2审核，3已入库
									stockPlanRecord.PlanType, //3 采购类型0手工计划，1警戒线，2消耗，3时间，4日消耗
									stockPlanRecord.Dept.ID,//4 科室编码
									stockPlanRecord.Company.ID, //5 供药公司编码
									stockPlanRecord.Company.Name, //6 供货公司名称
									stockPlanRecord.Item.ID, //7 药品编码
									stockPlanRecord.Item.Name,//8 药品名称
									stockPlanRecord.Item.Specs, //9 药品规格
									stockPlanRecord.Item.PriceCollection.RetailPrice.ToString(), //10 药品零售价
									stockPlanRecord.Item.PriceCollection.WholeSalePrice.ToString(), //11 药品批发价
									stockPlanRecord.Item.PriceCollection.PurchasePrice.ToString(), //12 药品购入价
									stockPlanRecord.Item.PackUnit, //13 药品包装单位
									stockPlanRecord.Item.PackQty.ToString(),	//14 药品包装数量
									stockPlanRecord.Item.MinUnit,	//15 药品最小单位
									stockPlanRecord.Item.Product.Producer.ID, //16 药品生产厂家编码
									stockPlanRecord.Item.Product.Producer.Name, //17 药品生产厂家名称
									stockPlanRecord.StoreQty.ToString(), //18 本科室库存数量
									stockPlanRecord.StoreTotQty.ToString(), //19 全院库存数量
									stockPlanRecord.OutputQty.ToString(),	//20 全院出库总量
									stockPlanRecord.PlanQty.ToString(),		//21 计划入库量
									stockPlanRecord.PlanOper.ID,		//22 计划人
									stockPlanRecord.PlanOper.OperTime.ToString(),	//23 计划日期
									stockPlanRecord.StockPrice.ToString(),	//24 计划购入价
									stockPlanRecord.StockOper.ID,		//25 采购人
									stockPlanRecord.StockOper.OperTime.ToString(),	//26 采购日期
									stockPlanRecord.ApproveQty.ToString(),	//27 审批数量
									stockPlanRecord.ApproveOper.ID,	//28 审批人
									stockPlanRecord.ApproveOper.OperTime.ToString(),	//29 审批时间
									stockPlanRecord.InQty.ToString(),	//30  实际入库数量
									stockPlanRecord.InOper.ID,	//31 入库操作人
									stockPlanRecord.InOper.OperTime.ToString(),		//32 入库时间
									stockPlanRecord.InListNO,		//33 入库单据号
									stockPlanRecord.Memo,		//34 备注
									stockPlanRecord.Oper.ID,		//35 操作员
									stockPlanRecord.Oper.OperTime.ToString()
								};

            return strParam;
        }

        /// <summary>
        /// 取入库计划信息列表，可能是一条或者多条
        /// 私有方法，在其他方法中调用
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>入库计划信息数组</returns>
        private ArrayList myGetStockPlanRecord(string SQLString)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlanRecord; //入库计划明细信息实体
            this.ProgressBarText = "正在检索人员属性变动信息...";
            this.ProgressBarValue = 0;

            //执行查询语句
            if (this.ExecQuery(SQLString) == -1)
            {
                this.Err = "获得入库计划明细信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    stockPlanRecord = new Neusoft.HISFC.Models.Pharmacy.StockPlan();
                    stockPlanRecord.ID = this.Reader[0].ToString(); //0 入库计划单流水号
                    stockPlanRecord.BillNO = this.Reader[1].ToString(); //1 采购单号
                    stockPlanRecord.State = this.Reader[2].ToString(); //2 单据状态0计划单，1采购单，2审核，3已入库
                    stockPlanRecord.PlanType = this.Reader[3].ToString(); //3 采购类型0手工计划，1警戒线，2消耗，3时间，4日消耗
                    stockPlanRecord.Dept.ID = this.Reader[4].ToString(); //4 科室编码 
                    stockPlanRecord.Company.ID = this.Reader[5].ToString(); //5 供药公司编码
                    stockPlanRecord.Company.Name = this.Reader[6].ToString(); //6 供货公司名称
                    stockPlanRecord.Item.ID = this.Reader[7].ToString(); //7 药品编码
                    stockPlanRecord.Item.Name = this.Reader[8].ToString(); //8 药品名称
                    stockPlanRecord.Item.Specs = this.Reader[9].ToString(); //9 药品规格
                    stockPlanRecord.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[10].ToString()); //10 药品零售价
                    stockPlanRecord.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal(this.Reader[11].ToString()); //11 药品批发价
                    stockPlanRecord.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[12].ToString()); //12 药品购入价(最新购入价)
                    stockPlanRecord.Item.PackUnit = this.Reader[13].ToString();		//13 药品包装单位
                    stockPlanRecord.Item.PackQty = NConvert.ToDecimal(this.Reader[14].ToString());	//14 药品包装数量
                    stockPlanRecord.Item.MinUnit = this.Reader[15].ToString();	//15 药品最小单位
                    stockPlanRecord.Item.Product.Producer.ID = this.Reader[16].ToString(); //16 药品生产厂家编码
                    stockPlanRecord.Item.Product.Producer.Name = this.Reader[17].ToString(); //17 药品生产厂家名称
                    stockPlanRecord.StoreQty = NConvert.ToDecimal(this.Reader[18].ToString()); //18 本科室库存数量
                    stockPlanRecord.StoreTotQty = NConvert.ToDecimal(this.Reader[19].ToString()); //19 全院库存数量
                    stockPlanRecord.OutputQty = NConvert.ToDecimal(this.Reader[20].ToString());		//20 全院出库总量
                    stockPlanRecord.PlanQty = NConvert.ToDecimal(this.Reader[21].ToString());		//21 计划入库量
                    stockPlanRecord.PlanOper.ID = this.Reader[22].ToString();			//22 计划人
                    stockPlanRecord.PlanOper.OperTime = NConvert.ToDateTime(this.Reader[23].ToString());		//23 计划日期
                    stockPlanRecord.StockPrice = NConvert.ToDecimal(this.Reader[24].ToString());	//24 计划购入价
                    stockPlanRecord.StockOper.ID = this.Reader[25].ToString();			//25 采购人
                    stockPlanRecord.StockOper.OperTime = NConvert.ToDateTime(this.Reader[26].ToString());	//26 采购日期
                    stockPlanRecord.ApproveQty = NConvert.ToDecimal(this.Reader[27].ToString());	//27 审批数量
                    stockPlanRecord.ApproveOper.ID = this.Reader[28].ToString();	//28 审批人
                    stockPlanRecord.ApproveOper.OperTime = NConvert.ToDateTime(this.Reader[29].ToString());	//29 审批时间
                    stockPlanRecord.InQty = NConvert.ToDecimal(this.Reader[30].ToString());		//30  实际入库数量
                    stockPlanRecord.InOper.ID = this.Reader[31].ToString();	//31 入库操作人
                    stockPlanRecord.InOper.OperTime = NConvert.ToDateTime(this.Reader[32].ToString());		//32 入库时间
                    stockPlanRecord.InListNO = this.Reader[33].ToString();		//33 入库单据号
                    stockPlanRecord.Memo = this.Reader[34].ToString();			//34 备注
                    stockPlanRecord.Oper.ID = this.Reader[35].ToString();		//35 操作员
                    stockPlanRecord.Oper.OperTime = NConvert.ToDateTime(this.Reader[36].ToString());		//36 操作时间

                    this.ProgressBarValue++;
                    al.Add(stockPlanRecord);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得入库计划明细信息信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            this.ProgressBarValue = -1;
            return al;
        }

        /// <summary>
        /// 向采购计划表内插入一条记录
        /// </summary>
        /// <param name="stockPlanRecord">入库计划类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertStockPlanRecord(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlanRecord)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.InsertStockPlanRecord", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertStockPlanRecord字段!";
                return -1;
            }
            try
            {
                //取流水号
                stockPlanRecord.ID = this.GetSequence("Pharmacy.Item.GetStockPlanID");
                //if (employeeRecord.ID == null) return -1;
                string[] strParm = myGetParmStockPlanRecord(stockPlanRecord);     //取参数列表

                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.InsertStockPlanRecord:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新采购计划表中一条记录，只能对所有状态 不等于2 的记录进行更新
        /// </summary>
        /// <param name="stockPlanRecord">入库计划类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateStockPlanRecord(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlanRecord)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStockPlanRecord", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateStockPlanRecord字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmStockPlanRecord(stockPlanRecord);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateStockPlanRecord:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新采购计划表中一条记录
        /// </summary>
        /// <param name="stockPlanRecord">入库计划类</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateStockPlanRecordForIn(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlanRecord)
        {
            string strSQL = "";
            //取更新操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.UpdateStockPlanRecordForIn", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.UpdateStockPlanRecord字段!";
                return -1;
            }
            try
            {
                string[] strParm = myGetParmStockPlanRecord(stockPlanRecord);     //取参数列表
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.UpdateStockPlanRecord:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除采购计划表中一条记录
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="billNum">计划单号</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int DeleteStockPlanRecord(string deptCode, string billNum)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteStockPlanRecord", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteStockPlanRecord字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, billNum);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DeleteStockPlanRecord:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 对入库计划单进行整单删除
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="billCode">入库计划单号</param>
        /// <returns></returns>
        public int DeleteStockPlanByBill(string deptCode, string billCode)
        {
            string strSQL = "";
            //取删除操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.DeleteStockPlanByBill", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeleteStockPlanByBill字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode, billCode);    //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.DeleteStockPlanByBill:" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        */

        #endregion

        #region 内部使用

        /*

        ///<summary>
        ///取某段时间内某库房的入库计划信息
        ///</summary>
        ///<param name="deptcode">库房编码</param>
        ///<param name="beginDate">计划起始时间</param>
        ///<param name="endDate">计划结束时间</param>
        ///<returns>入库计划明细信息数组，出错返回null</returns>
        public ArrayList QueryDeptStockPlanRecord(string deptcode, DateTime beginDate, DateTime endDate)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlanRecord", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanRecord字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlanRecordList", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanRecordList字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptcode, beginDate.ToString(), endDate.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetStockPlanRecordList:" + ex.Message;
                return null;
            }

            //取人员属性变动信息数据
            return this.myGetStockPlanRecord(strSQL);
        }

        ///<summary>
        ///根据入库计划单号检索入库计划明细信息
        ///</summary>
        ///<param name="deptCode">库房编码</param>
        ///<param name="billCode">入库计划单号</param>
        ///<returns>入库计划信息数组 失败返回null</returns>
        public ArrayList QueryNoStockPlanRecord(string deptCode, string billCode)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlanRecord", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanRecord字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetNoStockPlanRecord", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetNoStockPlanRecord字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptCode, billCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetNoStockPlanRecord:" + ex.Message;
                return null;
            }

            return this.myGetStockPlanRecord(strSQL);

        }

        /// <summary>
        /// 根据入库计划单流水号检索入库计划信息
        /// </summary>
        /// <param name="planNo">入库计划单流水号</param>
        /// <returns>成功返回入库计划明细信息，失败返回null</returns>
        public ArrayList QueryStockPlanByPlanNo(string planNo)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlanRecord", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanRecord字段!";
                return null;
            }
            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlanByPlanNo", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanByPlanNo字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, planNo);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetStockPlanByPlanNo:" + ex.Message;
                return null;
            }

            return this.myGetStockPlanRecord(strSQL);
        }

        /// <summary>
        /// 获取药品的历史采购记录
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="state">获取的采购历史记录的状态 2 审核 3 入库</param>
        /// <returns>成功返回入库计划信息，失败返回null</returns>
        public ArrayList QueryHistoryStockPlan(string deptCode, string drugCode, string state)
        {
            string strSQLWhere = "";
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlanRecord", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanRecord字段!";
                return null;
            }
            //取查找记录的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetHistoryStockPlan", ref strSQLWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetHistoryStockPlan字段!";
                return null;
            }
            try
            {
                strSQL = strSQL + strSQLWhere;
                strSQL = string.Format(strSQL, deptCode, drugCode, state);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetHistoryStockPlan:" + ex.Message;
                this.WriteErr();
                return null;
            }

            //取入库计划单明细信息数据
            return this.myGetStockPlanRecord(strSQL);
        }

        /// <summary>
        /// 根据入库单状态获得入库单号、供货公司列表
        /// </summary>
        /// <param name="state">入库计划单状态</param>
        /// <param name="deptcode">库房编码</param>
        /// <returns></returns>
        public ArrayList QueryStockPLanCompanayList(string deptcode, string state)
        {
            string strSQL = "";
            //取查找记录的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPLanCompanayList", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPLanCompanayList字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, deptcode, state);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetStockPLanCompanayList:" + ex.Message;
                this.WriteErr();
                return null;
            }
            ArrayList al = new ArrayList();

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得采购计划信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    //此语句不能加到循环外面，否则会在al数组内加入相同的数据（最后一条数据）
                    Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();            //入库单号
                    info.Name = this.Reader[1].ToString();          //供货公司
                    info.User01 = this.Reader[2].ToString();       //供货公司编码
                    info.User02 = this.Reader[3].ToString();        //科室编码
                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得采购计划信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        ///<summary>
        ///根据入库计划单科室、状态、时间检索入库计划单信息
        ///</summary>
        ///<param name="deptCode">库房编码</param>
        ///<param name="state">入库计划单状态</param>
        ///<param name="beginDate">起始时间</param>
        ///<param name="endDate">终止时间</param>
        ///<returns>入库计划明细信息数组，出错返回null</returns>
        public ArrayList QueryStateStockPlanRecord(string deptCode, string state, DateTime beginDate, DateTime endDate)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlanRecord", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanRecord字段!";
                return null;
            }
            //根据入库计划单状态确定采用何种时间查询
            string strInfo = "";
            switch (state)
            {
                case "0":			//计划单，计划时间
                    strInfo = "Pharmacy.Item.GetStockPlanRecordByPlanTime";
                    break;
                case "1":			//采购单，采购时间
                    strInfo = "Pharmacy.Item.GetStockPlanRecordByStockTime";
                    break;
                case "2":			//审核单，审核时间
                    strInfo = "Pharmacy.Item.GetStockPlanRecordByApproveTime";
                    break;
                default:			//已入库状态，入库时间
                    strInfo = "Pharmacy.Item.GetStockPlanRecordByInTime";
                    break;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql(strInfo, ref strWhere) == -1)
            {
                this.Err = "没有找到" + strInfo + "字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptCode, state, beginDate.ToString(), endDate.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错" + strInfo + ex.Message;
                return null;
            }

            return this.myGetStockPlanRecord(strSQL);
        }

        ///<summary>
        ///根据科室编码、入库计划单号、供货公司检索入库计划单明细信息
        ///</summary>
        ///<param name="deptCode">库房编码</param>
        ///<param name="billCode">入库计划单号</param>
        ///<param name="companyId">供货公司编码</param>
        ///<returns>成功返回数组，失败返回null</returns>
        public ArrayList QueryStockPlanByCompany(string deptCode, string billCode, string companyId)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlanRecord", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanRecord字段!";
                return null;
            }

            string strWhere = "";
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlanByCompany", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlanByCompany字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL += " " + strWhere;
                strSQL = string.Format(strSQL, deptCode, billCode, companyId);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetStockPlanByCompany:" + ex.Message;
                return null;
            }

            //取入库计划单明细信息数据
            return this.myGetStockPlanRecord(strSQL);
        }

        ///<summary>
        ///根据日消耗获得入库计划
        ///</summary>
        ///<param name="deptCode">库房编码</param>
        ///<returns>成功返回数组，否则返回null</returns>
        public ArrayList StockPLanByConsume(string deptCode)
        {
            string strSQL = "";
            //取药品出库总量的SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.OutPutByConsume", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.OutPutByConsume字段!";
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.OutPutByConsume:" + ex.Message;
                this.WriteErr();
                return null;
            }
            ArrayList al = new ArrayList();
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得药品出库总量信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    //此语句不能加到循环外面，否则会在al数组内加入相同的数据（最后一条数据）
                    Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();     //药品编码
                    info.Name = this.Reader[1].ToString();   //出库总量
                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得药品出库总量信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return null;
        }

        ///<summary>
        ///取入库计划单号
        ///</summary>
        ///<returns>成功返回调价单号：年月日＋四位流水号，失败返回null</returns>
        public string GetBillCode(string deptcode)
        {
            string strSQL = "";
            string temp1, temp2;
            string newBillCode;
            //系统时间 yymmdd
            temp1 = this.GetSysDateNoBar().Substring(2, 6);
            //取最大入库计划单号
            if (this.Sql.GetSql("Pharmacy.Item.GetMaxBillCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetMaxBillCode字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, deptcode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetMaxBillCode:" + ex.Message;
                return null;
            }

            temp2 = this.ExecSqlReturnOne(strSQL);
            if (temp2.ToString() == "-1" || temp2.ToString() == "")
            {
                temp2 = "0001";
            }
            else
            {
                decimal i = NConvert.ToDecimal(temp2.Substring(6, 4)) + 1;
                temp2 = i.ToString().PadLeft(4, '0');
            }
            newBillCode = temp1 + temp2;

            return newBillCode;
        }

        */

        #endregion

        #endregion

        #region 预扣库存管理  {C37BEC96-D671-46d1-BCDD-C634423755A4}

        /// <summary>
        /// 形成库存预扣信息
        /// </summary>
        /// <param name="applyOut"></param>
        /// <param name="alterStoreNum"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        protected int InsertPreoutStore(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, decimal alterStoreNum, decimal days)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.InsertPreoutStore", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.InsertPreoutStore字段!";
                return -1;
            }
            try
            {
                string[] strParm = new string[] {   applyOut.ID,            //ApplyNum
                                                    applyOut.StockDept.ID,
                                                    applyOut.SystemType,
                                                    applyOut.Item.ID,
                                                    applyOut.Item.Name,
                                                    applyOut.Item.Specs,
                                                    applyOut.Operation.ApplyQty.ToString(),
                                                    applyOut.Days.ToString(),
                                                    applyOut.Operation.ApplyOper.ID,
                                                    applyOut.Operation.ApplyOper.OperTime.ToString(),
                                                    applyOut.PatientNO
                        
                                                };
                strSQL = string.Format(strSQL, strParm);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "插入库存记录SQl参数赋值时出错！" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 扣减库存预扣信息
        /// </summary>
        /// <param name="applyID"></param>
        /// <param name="alterStoreNum"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        protected int DeletePreoutStore(string applyID, decimal alterStoreNum, decimal days)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.DeletePreoutStore", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.DeletePreoutStore字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, applyID);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "插入库存记录SQl参数赋值时出错！" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新库存汇总表中的预扣数量（正数是增加，负数是减少）
        /// </summary>
        /// <param name="applyOut">申请信息</param>
        /// <param name="alterStoreNum">预扣变化数量 正数是增加，负数是减少</param>
        /// <param name="days">付数</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateStockinfoPreOutNum(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, decimal alterStoreNum, decimal days)
        {
            if (alterStoreNum > 0)
            {
                return this.InsertPreoutStore(applyOut, alterStoreNum, days);
            }
            else
            {
                return this.DeletePreoutStore(applyOut.ID, alterStoreNum, days);
            }

        }

        /// <summary>
        /// 获取预扣库存量
        /// </summary>
        /// <param name="drugDeptCode">库房科室编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>成功返回预扣库存量 失败返回-1</returns>
        public decimal GetPreOutNum(string drugDeptCode, string drugCode)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.PreoutStore.GetPreOutNum", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.PreoutStore.GetPreOutNum字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, drugDeptCode,drugCode);            //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "获取预扣库存量SQl参数赋值时出错！" + ex.Message;
                return -1;
            }

            string preOutStr = this.ExecSqlReturnOne(strSQL);

            if (string.IsNullOrEmpty(preOutStr) == true)        //没有找到相应数据
            {
                return 0;
            }
            else
            {
                decimal preOutNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(preOutStr);
                return preOutNum;
            }
        }
        #endregion

        #region 协定处方管理   {E49F9CEA-2E6D-4b2e-919F-99145BEE3E68}   移植加入5.0 2010-05-18

        /// <summary>
        /// 获取协定处方药品列表
        /// </summary>
        /// <returns>成功返回协定处方药品数据 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryNostrumList()
        {
            return this.QueryNostrumList("ALL");
        }

        /// <summary>
        /// 获取协定处方药品列表
        /// </summary>
        /// <returns>成功返回协定处方药品数据 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryNostrumList(string DrugType)
        {
            string strSelect = "";  //获得全部药品信息的SELECT语句
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.Info", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.Info字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetList.NostrumList", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetList.NostrumList字段!";
                return null;
            }
            try
            {
                strSelect = strSelect + strWhere;
                strSelect = string.Format(strSelect, DrugType);
            }
            catch
            {
                this.Err = "SQL参数初始化失败";
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetItemSimple(strSelect);
        }

        /// <summary>
        /// 获取协定处方参数数组
        /// </summary>
        /// <param name="nostrumItem">协定处方信息实体</param>
        /// <returns>成功返回参数数组 失败返回null</returns>
        private string[] GetNostrumParameter(Nostrum nostrumItem)
        {
            try
            {
                string[] parm = {
                                    nostrumItem.ID,             //协定处方编码
                                    nostrumItem.Name,           //协定处方名称
                                    nostrumItem.Item.ID,        //项目编码
                                    nostrumItem.Item.Name,      //项目名称
                                    nostrumItem.Item.Specs,     //规格
                                    nostrumItem.Qty.ToString(), //数量
                                    nostrumItem.Item.MinUnit,   //单位
                                    nostrumItem.SortNO.ToString(),      //顺序号
                                    NConvert.ToInt32(nostrumItem.IsValid).ToString(),   //有效性
                                    nostrumItem.Oper.ID,        //操作员
                                    nostrumItem.Oper.OperTime.ToString()        //操作时间
								 };
                return parm;
            }
            catch (Exception ex)
            {
                this.Err = "由实体获取参数数组时发生异常 \n" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 执行Sql语句 返回协定处方信息数组
        /// </summary>
        /// <param name="strSQL">需执行的Sql语句</param>
        /// <returns>成功返回协定处方信息数组 失败返回null</returns>
        private List<Neusoft.HISFC.Models.Pharmacy.Nostrum> GetNostrumInfo(string strSQL)
        {
            List<Nostrum> al = new List<Nostrum>();
            List<Nostrum> al1 = new List<Nostrum>();
            Neusoft.HISFC.Models.Pharmacy.Nostrum info;

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "查询协定处方信息，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    info = new Nostrum();

                    info.ID = this.Reader[0].ToString();            //组套编码
                    info.Name = this.Reader[1].ToString();          //组套名称
                    info.Item.ID = this.Reader[2].ToString();       //项目编码
                    info.Item.Name = this.Reader[3].ToString();     //项目名称
                    info.Item.Specs = this.Reader[4].ToString();    //规格
                    info.Qty = NConvert.ToDecimal(this.Reader[5].ToString());
                    info.Item.MinUnit = this.Reader[6].ToString();
                    info.SortNO = NConvert.ToInt32(this.Reader[7].ToString());
                    info.IsValid = NConvert.ToBoolean(this.Reader[8]);
                    info.Oper.ID = this.Reader[9].ToString();
                    info.Oper.OperTime = NConvert.ToDateTime(this.Reader[10]);
                    info.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[11]);
                    info.Item.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.Reader[12]);
                    info.Item.Usage.ID = this.Reader[13].ToString();
                    info.Item.User01 = this.Reader[14].ToString();

                    //{E49F9CEA-2E6D-4b2e-919F-99145BEE3E68} 修改Sql语句
                    if (this.Reader.FieldCount > 15)
                    {
                        info.Item.PackQty = NConvert.ToDecimal( this.Reader[15] );
                        info.Item.PriceCollection.WholeSalePrice = NConvert.ToDecimal( this.Reader[16] );
                    }

                    al.Add(info);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询协定处方信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //{43A42232-952B-48a2-A62B-5F22AD2C0858}
            decimal qty = 0m;
            int sortNO = 0;
            bool isValid = false;
            string operID = null;
            DateTime dt = new DateTime();
            foreach (Neusoft.HISFC.Models.Pharmacy.Nostrum nostrumInfo in al)
            {
                qty = nostrumInfo.Qty;
                sortNO = nostrumInfo.SortNO;
                isValid = nostrumInfo.IsValid;
                operID = nostrumInfo.Oper.ID;
                dt = nostrumInfo.Oper.OperTime;
                nostrumInfo.Item = this.GetItem(nostrumInfo.Item.ID);

                nostrumInfo.Qty = qty;
                nostrumInfo.SortNO = sortNO;
                nostrumInfo.IsValid = isValid;
                nostrumInfo.Oper.ID = operID;
                nostrumInfo.Oper.OperTime = dt;
                al1.Add(nostrumInfo);
            }
            return al1;
        }

        /// <summary>
        /// 插入协定处方信息
        /// </summary>
        /// <param name="info">协定处方信息实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertNostrum(Neusoft.HISFC.Models.Pharmacy.Nostrum info)
        {
            string strSQL = "";
            //取插入操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Nostrum.Insert", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Nostrum.Insert字段!";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = this.GetNostrumParameter(info);
                //替换SQL语句中的参数
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Nostrum.Insert:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新协定处方信息
        /// </summary>
        /// <param name="info">协定处方信息实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateNostrum(Neusoft.HISFC.Models.Pharmacy.Nostrum info)
        {
            string strSQL = "";
            //取操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Nostrum.Update", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Nostrum.Update字段!";
                return -1;
            }
            try
            {
                //取参数列表
                string[] strParm = this.GetNostrumParameter(info);
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Nostrum.Update:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 协定处方删除
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int DeleteNostrum(string nostrumID, string itemID)
        {
            string strSQL = "";
            //取操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Nostrum.DeleteNostrum", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Nostrum.DeleteNostrum字段!";
                return -1;
            }
            try
            {
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL, nostrumID, itemID);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Nostrum.DeleteNostrum:" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 获取协定处方明细信息
        /// </summary>
        /// <param name="packageCode">组套编码</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Nostrum> QueryNostrumDetail(string packageCode)
        {
            string strSQL = "";
            //取SELECT语句   //{E49F9CEA-2E6D-4b2e-919F-99145BEE3E68} 修改Sql语句
            if (this.Sql.GetSql("Pharmacy.Nostrum.Detail", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Nostrum.Detail字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, packageCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Nostrum.Detail:" + ex.Message;
                return null;
            }

            return this.GetNostrumInfo(strSQL);
        }

        /// <summary>
        /// 获取协定处方明细信息
        /// </summary>
        /// <param name="itemID">明细编码</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Nostrum> QueryNostrumListByDetail(string itemID)
        {
            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql( "Pharmacy.Nostrum.Detail.ByItem", ref strSQL ) == -1)
            {
                this.Err = "没有找到Pharmacy.Nostrum.Detail.ByItem字段!";
                return null;
            }

            //格式化SQL语句
            try
            {
                strSQL = string.Format( strSQL, itemID );
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Nostrum.Detail.ByItem:" + ex.Message;
                return null;
            }

            return this.GetNostrumInfo( strSQL );
        }

        /// <summary>
        /// 协定处方价格更新
        /// </summary>
        /// <param name="nostrumCode">协定处方编码</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateNostrumPrice(string nostrumCode)
        {
            string strSQL = "";
            //取操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Nostrum.ComputeNostrumPrice", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Nostrum.ComputeNostrumPrice字段!";
                return -1;
            }
            try
            {
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL, nostrumCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Nostrum.ComputeNostrumPrice:" + ex.Message;
                return -1;
            }
            decimal nostrumPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ExecSqlReturnOne(strSQL));

            //取操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Nostrum.UpdateNostrumPrice", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Nostrum.UpdateNostrumPrice字段!";
                return -1;
            }
            try
            {
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL, nostrumCode, nostrumPrice.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Nostrum.Update:" + ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 查询协定处方按明细的单价
        /// </summary>
        /// <param name="nostrumCode">协方代码</param>
        /// <returns></returns>
        public decimal GetNostrumPrice(string nostrumCode)
        {          
            string strSQL = "";
            //取操作的SQL语句
            if (this.Sql.GetSql("Pharmacy.Nostrum.GetNostrumPrice", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Nostrum.GetNostrumPrice字段!";
                return -1;
            }
            try
            {
                //替换SQL语句中的参数。
                strSQL = string.Format(strSQL, nostrumCode);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Nostrum.GetNostrumPrice:" + ex.Message;
                return -1;
            }
            decimal nostrumPrice = 0;
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "查询协定处方信息，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return 0;
            }

            try
            {
                while (this.Reader.Read())
                {
                    nostrumPrice = Convert.ToDecimal(this.Reader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询协定处方信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return 0;
            }
            finally
            {
                this.Reader.Close();
            }
            return nostrumPrice;
        }

        /// <summary>
        /// 协定处方包装库存明细出库
        /// </summary>
        /// <param name="detailItem">库存明细</param>
        /// <param name="qty">出库量</param>
        /// <param name="stockDept">库存科室</param>
        /// <param name="operEnvironment">操作环境</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int NostrumPackageOutput(Neusoft.HISFC.Models.Pharmacy.Item detailItem, decimal qty, Neusoft.FrameWork.Models.NeuObject stockDept, Neusoft.HISFC.Models.Base.OperEnvironment operEnvironment,string outListNO)
        {
            //转为出库数据。								 
            Neusoft.HISFC.Models.Pharmacy.Output output = new Output();

            output.StockDept = stockDept;                                   //出库科室＝摆药核准科室
            output.SystemType = Neusoft.HISFC.Models.Base.EnumIMAOutTypeService.GetNameFromEnum( Neusoft.HISFC.Models.Base.EnumIMAOutType.ProduceOutput );                            //系统类型＝出库申请类型
            output.PrivType = Neusoft.HISFC.Models.Base.EnumIMAOutTypeService.GetNameFromEnum( Neusoft.HISFC.Models.Base.EnumIMAOutType.ProduceOutput );
            output.Item = detailItem;                                       //药品实体
            output.ShowState = "0";                                         //显示的单位标记（0最小单位，1包装单位）
            output.Quantity = qty;                                          //出库数量＝摆药核准数量
            output.State = "2";                                             //出库状态＝摆药状态
            output.SpecialFlag = "0";                                       //特殊标记。1是，0否
            output.TargetDept = stockDept;                                  //领用科室＝出库申请科室

            output.Operation.ApplyQty = qty;                                //出库申请数量
            output.Operation.ApplyOper = operEnvironment;                   //出库申请人
            output.Operation.ExamQty = qty;                                 //审批出库数量＝摆药核准数量
            output.Operation.ExamOper = operEnvironment;                    //审批人 ＝打印人
            output.State = "2";

            output.OutListNO = outListNO;
            output.DrugedBillNO = "1";

            decimal storeQty = 0;
            if (this.GetStorageNum( output.StockDept.ID, output.Item.ID, out storeQty ) == -1)
            {
                return -1;
            }
            output.StoreQty = storeQty - output.Quantity;

            output.Operation.ApproveOper = operEnvironment;    //核准人（用户录入的工号）

            //出库处理
            return this.Output( output );
        }

        #endregion

        #region 功能无效 采用其他函数代替
        /// <summary>
        /// 取某一药品在全院库存汇总表中的总条数
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="storageCount">库存总条数（返回参数）</param>
        /// <returns>1成功，-1失败</returns>
        [System.Obsolete("重构整合 功能重复 可以使用GetDrugStorageRowNum代替 GetStorageCountByDrugCode对于库存为零的也进行了统计", true)]
        public int GetStorageCountByDrugCode(string drugCode, out int storageCount)
        {
            storageCount = 0;

            string strSQL = "";
            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetStorageCountByDrugCode", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStorageCountByDrugCode字段!";
                return -1;
            }
            //格式化SQL语句
            strSQL = string.Format(strSQL, drugCode);
            //取药品库存总条数
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "Pharmacy.Item.GetStorageCountByDrugCode：" + this.Err;
                return -1;
            }

            try
            {
                if (this.Reader.Read())
                {
                    storageCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[0].ToString());  //药品库存总条数
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = "Pharmacy.Item.GetStorageCountByDrugCode！" + ex.Message;
                return -1;
            }
            return 1;
        }

        #endregion

        #region 退费申请时调用

        ///// <summary>
        ///// 取某一药房中某一中摆药单待退药患者列表
        ///// </summary>
        ///// <returns>neuObject数组，患者信息住院流水号User01，姓名User02，床号User03</returns>
        //public ArrayList QueryDrugReturnPatientList(string medDeptCode)
        //{
        //    return this.QueryDrugReturnPatientList(medDeptCode, "");
        //}

        ///// <summary>
        ///// 取某一药房中某一中摆药单、某一科室待退药患者列表
        ///// </summary>
        ///// <returns>neuObject数组，患者信息住院流水号User01，姓名User02，床号User03</returns>
        //public ArrayList QueryDrugReturnPatientList(string medDeptCode, string applyDeptCode)
        //{
        //    string strSQL = "";  //取某一药房中某一中摆药单、某一科室待摆药患者列表的SQL语句
        //    //取SQL语句
        //    if (this.Sql.GetSql("Pharmacy.Item.GetDrugReturnPatientList", ref strSQL) == -1)
        //    {
        //        this.Err = "没有找到Pharmacy.Item.GetDrugReturnPatientList字段!";
        //        return null;
        //    }
        //    string[] strParm = {
        //                           applyDeptCode,            //0申请科室
        //                           medDeptCode               //1药房编码
        //                       };
        //    strSQL = string.Format(strSQL, strParm);

        //    //根据SQL语句取数组并返回数组
        //    ArrayList arrayObject = new ArrayList();

        //    if (this.ExecQuery(strSQL) == -1)
        //    {
        //        this.Err = "取待退药患者列表时出错：" + this.Err;
        //        return null;
        //    }
        //    try
        //    {
        //        Neusoft.FrameWork.Models.NeuObject obj; //患者信息住院流水号User01，姓名User02，床号User03	
        //        while (this.Reader.Read())
        //        {
        //            obj = new Neusoft.FrameWork.Models.NeuObject();
        //            obj.ID = this.Reader[0].ToString();                     //退药部门编码
        //            obj.Name = this.Reader[1].ToString();                   //退药部门名称
        //            obj.User01 = this.Reader[2].ToString();                 //住院流水号
        //            obj.User02 = this.Reader[3].ToString();                 //姓名
        //            obj.User03 = this.Reader[4].ToString();                 //床号

        //            arrayObject.Add(obj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Err = "获得待退药患者列表时出错！" + ex.Message;
        //        this.WriteErr();
        //        return null;
        //    }
        //    finally
        //    {
        //        this.Reader.Close();
        //    }

        //    return arrayObject;
        //}

        /// <summary>
        /// 取某一药房中某一申请科室待退药明细列表
        /// </summary>
        /// <param name="applyDeptCode">申请科室</param>
        /// <param name="medDeptCode">药房编码</param>
        /// <returns>成功返回ApplyOut实体数组 失败返回null</returns>
        public ArrayList QueryDrugReturn(string applyDeptCode, string medDeptCode)
        {
            return this.QueryDrugReturn(applyDeptCode, medDeptCode, null);

        }

        /// <summary>
        /// 取某一药房中某一申请科室，某一患者待退药明细列表
        /// </summary>
        /// <param name="applyDeptCode">申请科室编码</param>
        /// <param name="medDeptCode">药房编码</param>
        /// <param name="patientID">住院流水号 查询全部患者住院流水号传入空</param>
        /// <returns>成功返回ApplyOut实体数组 失败返回null</returns>
        public ArrayList QueryDrugReturn(string applyDeptCode, string medDeptCode, string patientID)
        {
            string strSQL = "";
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Patient", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
                return null;
            }
            string[] strParm;
            if (patientID == null || patientID == "")
            {
                //取WHERE语句
                if (this.Sql.GetSql("Pharmacy.Item.GetDrugReturn.ByDept", ref strWhere) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetDrugReturn.ByDept字段!";
                    return null;
                }
                //参数 申请科室 药房编码
                strParm = new string[] { applyDeptCode, medDeptCode };
            }
            else
            {
                //取WHERE语句
                if (this.Sql.GetSql("Pharmacy.Item.GetDrugReturn.ByPatient", ref strWhere) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetDrugReturn.ByPatient字段!";
                    return null;
                }
                //参数 申请科室 药房编码 住院流水号
                strParm = new string[] { applyDeptCode, medDeptCode, patientID };
            }

            strSQL = string.Format(strSQL + strWhere, strParm);

            return this.myGetApplyOut(strSQL);
        }

        #endregion

        #region 制剂生产出入库

        /// <summary>
        /// 制剂原料/生产出库
        /// </summary>
        /// <param name="item">出库项目信息</param>
        /// <param name="expand">制剂消耗信息</param>
        /// <param name="stockDept">库存科室</param>
        /// <returns>成功返回 失败返回－1</returns>
        public int ProduceOutput(Neusoft.HISFC.Models.Pharmacy.Item item, Neusoft.HISFC.Models.Preparation.Expand expand, Neusoft.FrameWork.Models.NeuObject stockDept)
        {
            //将出库申请数据转为出库数据。								 
            Neusoft.HISFC.Models.Pharmacy.Output output = new Output();

            output.StockDept = stockDept;                                   //出库科室＝摆药核准科室
            output.SystemType = Neusoft.HISFC.Models.Base.EnumIMAOutTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAOutType.ProduceOutput);                            //系统类型＝出库申请类型
            output.PrivType = Neusoft.HISFC.Models.Base.EnumIMAOutTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAOutType.ProduceOutput);
            output.Item = item;                                             //药品实体
            output.ShowState = "0";                                         //显示的单位标记（0最小单位，1包装单位）
            output.Quantity = expand.FacutalExpand;                         //出库数量＝摆药核准数量
            output.State = "2";                                             //出库状态＝摆药状态
            output.SpecialFlag = "0";                                       //特殊标记。1是，0否
            output.TargetDept = stockDept;                                  //领用科室＝出库申请科室
            output.Operation.ApplyQty = expand.FacutalExpand;               //出库申请数量
            output.Operation.ApplyOper = expand.Prescription.OperEnv;       //出库申请人
            output.Operation.ExamQty = expand.FacutalExpand;                //审批出库数量＝摆药核准数量
            output.Operation.ExamOper = expand.Prescription.OperEnv;        //审批人 ＝打印人
            output.State = "2";

            //制剂管理业务中 存储生产计划号
            output.OutListNO = expand.PlanNO;
            output.DrugedBillNO = "1";

            decimal storeQty = 0;
            if (this.GetStorageNum(output.StockDept.ID, output.Item.ID, out storeQty) == -1)
            {
                return -1;
            }
            output.StoreQty = storeQty - output.Quantity;

            output.Operation.ApproveOper = expand.Prescription.OperEnv;    //核准人（用户录入的工号）

            //出库处理
            return this.Output(output);
        }

        /// <summary>
        /// 制剂原料申请
        /// </summary>
        /// <param name="item">出库项目信息</param>
        /// <param name="expand">制剂消耗信息</param>
        /// <param name="applyDept">申请科室</param>
        /// <param name="stockDept">库存科室</param>
        /// <returns></returns>
        public int ProduceApply(Neusoft.HISFC.Models.Pharmacy.Item item, Neusoft.HISFC.Models.Preparation.Expand expand, Neusoft.FrameWork.Models.NeuObject applyDept, Neusoft.FrameWork.Models.NeuObject stockDept)
        {
            ApplyOut applyOut = new ApplyOut();

            applyOut.Item = item;       //药品实体

            applyOut.SystemType = Neusoft.HISFC.Models.Base.EnumIMAInTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAInType.InnerApply);                            //系统类型＝出库申请类型

            applyOut.ApplyDept = applyDept;
            applyOut.StockDept = stockDept;

            applyOut.BillNO = expand.PlanNO;
            applyOut.Operation.ApplyOper = expand.Prescription.OperEnv; ;                   //申请时间＝操作时间
            applyOut.Days = 1; //草药付数
            applyOut.State = "0";						                                    //出库申请状态:0申请,1摆药,2核准
            if (expand.FacutalExpand == 0)
            {
                applyOut.Operation.ApplyQty = 0;
            }
            else
            {
                applyOut.Operation.ApplyQty = expand.FacutalExpand - expand.StoreQty;
            }
            //{64FAE14C-7D1B-42ea-B19D-2C1B3846D2D0}  申请科室不对
            ArrayList alApplyList = this.QueryApplyOutInfoByListCode(applyDept.ID, expand.PlanNO, "0");
            if (alApplyList == null)
            {
                return -1;
            }
            else if (alApplyList.Count > 0)
            {
                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alApplyList)
                {
                    if (info.Item.ID == applyOut.Item.ID)
                    {
                        info.Operation.ApplyQty = applyOut.Operation.ApplyQty;
                        info.Operation.ApplyOper = applyOut.Operation.ApplyOper;

                        return this.UpdateApplyOut(info);
                    }
                }
            }

            return this.InsertApplyOut(applyOut);
        }

        /// <summary>
        /// 制剂生产入库
        /// </summary>
        /// <param name="preparationList">入库制剂信息</param>
        /// <param name="pprDept">制剂生产科室</param>
        /// <param name="stockDept">库存科室(入库目标科室)</param>
        /// <param name="isApply">是否做入库申请</param>
        /// <returns></returns>
        public int ProduceInput(List<Neusoft.HISFC.Models.Preparation.Preparation> preparationList, Neusoft.FrameWork.Models.NeuObject pprDept, Neusoft.FrameWork.Models.NeuObject stockDept, bool isApply)
        {
            string groupNO = this.GetNewGroupNO();
            if (groupNO == null)
            {
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Preparation.Preparation info in preparationList)
            {
                if (this.Input(info, NConvert.ToInt32(groupNO), pprDept, stockDept, isApply) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }

        #endregion


        #region 尝试一个统一的出库/退库函数

        /// <summary>
        /// 出库
        /// ErrCode 1 主键重复
        ///         2 库存不足
        /// </summary>
        /// <param name="outputStore">进销存实体</param>
        /// <param name="isMinusStore">是否允许扣负库存</param>
        /// <param name="isManagerInput">是否处理入库记录</param>
        /// <param name="iManager">进销存接口实例</param>
        /// <returns></returns>
        public static int Output(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore, bool isMinusStore, bool isManagerInput, IMAOutManager iManager)
        {
            #region 库存判断

            decimal storageNum = 0;
            if (iManager.GetStorageNum(outputStore, out storageNum) == -1)
                return -1;
            if (!isMinusStore && outputStore.Quantity > 0 && storageNum < outputStore.Quantity)
            {
                iManager.ErrStr = outputStore.Name + "的库存量不足" + iManager.ErrStr;
                return -1;
            }
            #endregion

            #region 获取库存明细 出库处理
            //取本次出库物品的库存明细数据
            List<Neusoft.HISFC.Models.IMA.IMAStoreBase> al = iManager.QueryStorageList(outputStore);
            if (al == null)
                return -1;

            //取出库单流水号 一个物品对应一个流水号 多个批次号
            string outputNO = iManager.GetNewOutputNO();
            if (outputNO == null)
                return -1;

            //库存操作临时变量
            Neusoft.HISFC.Models.IMA.IMAStoreBase tempStore;
            //出库总量
            decimal totOutNum = outputStore.Quantity;
            //待出库量
            decimal leftOutNum = outputStore.Quantity;

            //按照效期近、批次小先出库的原则进行出库处理。对于退库的药品，处理方式相同。
            for (int i = 0; leftOutNum > 0; i++)
            {
                if (al.Count > 0)
                {
                    #region 存在库存记录 库存出库处理

                    tempStore = al[i];

                    tempStore.ID = outputNO;                            //出库单流水号
                    tempStore.SerialNO = outputStore.SerialNO;         //出库单内序号
                    tempStore.Class2Type = outputStore.Class2Type;     //二级权限类型
                    tempStore.SystemType = outputStore.SystemType;     //系统出库类型
                    tempStore.PrivType = outputStore.PrivType;         //用户定义权限类型
                    tempStore.TargetDept = outputStore.TargetDept;     //领药部门

                    if (iManager.FillOutputInfo(tempStore, ref outputStore) == -1)
                        return -1;

                    #endregion
                }
                else
                {
                    #region  当出库退库的时候，有可能库存中数量为0的数据已经被清理，库存明细中没有记录

                    tempStore = outputStore;
                    tempStore.StoreQty = 0;

                    #endregion
                }

                //当库存数量大于出库数量时（或者库存中无数据，只要当允许为负库存时才能出现此中情况），则将此批次库存记录出库，出库数量等于待出库数量
                if (tempStore.StoreQty >= leftOutNum || al.Count == 0)
                {
                    //出库数量等于待出库数量（待出库数量会随着循环的增加而逐渐减少）
                    outputStore.Quantity = leftOutNum;
                }
                else
                {
                    //如果库存数量小于出库数量，则将此批次库存数量全部出库。（程序会继续查找下一个批次的库存信息）
                    outputStore.Quantity = tempStore.StoreQty;
                }

                //库存数量减少，减少的量等于出库数量（此处的storageBase.Quantity用来保存库存变化量）
                tempStore.Quantity = -outputStore.Quantity;

                //剩余待摆药数量＝本次待摆药数量－本次摆药数量。如果剩余待摆药数量大于0，循环将继续进行。
                leftOutNum = leftOutNum - outputStore.Quantity;

                //按批次出库时，如果同一样物品产生多条出库记录，单内序号增加
                outputStore.SerialNO = i + 1;

                if (i > 0)
                {
                    //对于一条入库申请，如果出库记录多于一条，只有第一条出库记录中保存“申请数量",其余的出库记录中的申请数量为0，保证汇总数量正确
                    outputStore.Operation.ApplyQty = 0;
                }

                //插入出库记录 
                if (iManager.SetOutput(outputStore) != 1)
                {
                    iManager.ErrStr = "插入出库记录时出错！" + iManager.ErrStr;
                    return -1;
                }

                //库存更新
                if (iManager.SetStorage(tempStore) != 1)
                {
                    iManager.ErrStr = "更新库存表时出错！" + iManager.ErrStr;
                    return -1;
                }

                //此处不用检查出库药品与库存药品零售价是否一致 
                //因为再调价时已对库存药品价格进行了更新 同时 记录了调价盈亏

                //处理对应领用部门的入库数据
                if (isManagerInput)
                {
                    if (iManager.SetInput(outputStore) == -1)
                    {
                        return -1;
                    }
                }
            }

            outputStore.Quantity = totOutNum;

            #endregion

            return 1;
        }

        /// <summary>
        /// 出库退库
        /// </summary>
        /// <param name="outputReturnStore">出库退库信息 包含需退库数量</param>
        /// <param name="outputNO">需退库的出库单流水号</param>
        /// <param name="isManagerInput">是否处理入库记录</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private static int OutputReturn(Neusoft.HISFC.Models.IMA.IMAStoreBase outputReturnStore, string outputNO, bool isManagerInput, DateTime sysTime, IMAOutManager iManager)
        {
            //取出库单流水号保存在output中，可以被外面调用
            string newOutputNO = iManager.GetNewOutputNO();
            if (newOutputNO == null)
                return -1;

            outputReturnStore.ID = newOutputNO;

            decimal totOutNum = outputReturnStore.Quantity;
            decimal leftOutNum = outputReturnStore.Quantity;

            #region 根据出库退库记录中的出库单流水号，取出库数据列表

            List<Neusoft.HISFC.Models.IMA.IMAStoreBase> al = iManager.QueryOutputList(outputNO);
            if (al == null)
                return -1;
            if (al.Count == 0)
            {
                iManager.ErrStr = "没有找到退库操作所对应的出库记录！" + iManager.ErrStr;
                return -1;
            }

            #endregion

            //Neusoft.HISFC.Models.Pharmacy.Input inputInfo;
            //Neusoft.HISFC.Models.Pharmacy.Input inputTemp;

            //Neusoft.HISFC.Models.Pharmacy.Output info;

            //如果退库申请中，指定确定的批次，则将此批次记录退掉。
            //否则，在与出库申请对应的出库记录中按批次小先退的原则，做退库处理
            Neusoft.HISFC.Models.IMA.IMAStoreBase tempStore;
            for (int i = 0; leftOutNum < 0; i++)
            {
                tempStore = al[i];

                if (iManager.FillOutputReturnInfo(tempStore, ref outputReturnStore) == -1)
                    return -1;

                //退库数量是负数
                if (tempStore.Quantity - tempStore.Operation.ReturnQty >= Math.Abs(leftOutNum))
                {
                    //退库数量等于待退库数量（待退库数量会随着循环的增加而逐渐减少）
                    outputReturnStore.Quantity = leftOutNum;
                }
                else
                {
                    //如果可退数量（已出库数量－已退库数量）小于于待退库数量，则将此批次出库记录中的可退库数量全部退库。（程序会继续查找下一个批次的库存信息）                   
                    outputReturnStore.Quantity = -(tempStore.Quantity - tempStore.Operation.ReturnQty);
                }

                leftOutNum = leftOutNum - outputReturnStore.Quantity;

                outputReturnStore.SerialNO = i + 1;

                //对于一条入库申请，如果出库记录多于一条，只有第一条出库记录中保存“申请数量",其余的出库记录中的申请数量为0，保证汇总数量正确
                if (i > 0)
                    outputReturnStore.Operation.ApplyQty = 0;
                //不需进行核准操作 直接设置状态
                outputReturnStore.State = "2";

                //生成退库记录
                if (iManager.SetOutput(outputReturnStore) != 1)
                {
                    iManager.ErrStr = "插入出库记录时出错！" + iManager.ErrStr;
                    return -1;
                }

                //更新库存
                if (iManager.SetStorage(outputReturnStore) != 1)
                {
                    iManager.ErrStr = "更新库存表时出错！" + iManager.ErrStr;
                    return -1;
                }

                //更新出库记录中的"已退库数量"字段（加操作）
                outputReturnStore.Quantity = -outputReturnStore.Quantity;
                if (iManager.UpdateOutputReturnQty(outputReturnStore) != 1)
                {
                    iManager.ErrStr = "更新出库记录中的已退库数量时出错！" + iManager.ErrStr;
                    return -1;
                }

                //出库退库调价
                if (iManager.OutputAdjust(tempStore, outputReturnStore, sysTime, i) != 1)
                {
                    iManager.ErrStr = "出库退库处理调价盈亏失败！" + iManager.ErrStr;
                    return -1;
                }

                if (iManager.SetInput(outputReturnStore) != 1)
                {
                    return -1;
                }

            }

            outputReturnStore.Quantity = totOutNum;

            return 1;
        }

        #endregion

        #region 尝试一个统一的入库/退库/核准函数

        /// <summary>
        /// 对一般入库、特殊入库进行处理 根据是否同步更新库存、库存
        /// </summary>
        /// <param name="inputStore">入库实体</param>
        /// <param name="isInputReturn">是否入库退库True 入库退库 False 正常入库</param>
        /// <param name="isUpdateStorage">是否更新库存 0 不更新 1 更新 True更新 False不更新</param>
        /// <param name="storageState">库存状态 0 暂入库 1 正式入库</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int Input(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore, bool isInputReturn, bool isUpdateStorage, string storageState, IMAInManager iManager)
        {
            if (isInputReturn)
            {
                inputStore.ID = "";
            }

            if (iManager.SetInput(inputStore) == -1)
                return -1;

            if (isUpdateStorage)
            {
                if (iManager.InputAdjust(inputStore) == -1)
                    return -1;

                if (iManager.SetStorage(inputStore, storageState) == -1)
                    return -1;
            }

            //需要更新库存
            //if (updateStorageFlag == "1")
            //{
            //    #region  判断入库价格与库存价格(当前最新价格)是否一致 不一致处理调价记录
            //    decimal dNowPrice = 0;
            //    DateTime sysTime = this.GetDateTimeFromSysDateTime();
            //    if (this.GetNowPrice(input.Item.ID, ref dNowPrice) == -1)
            //    {
            //        this.Err = "处理入库记录退库过程中 获取药品" + input.Item.Name + "零售价出错";
            //        return -1;
            //    }
            //    if (input.Item.PriceCollection.RetailPrice != dNowPrice)
            //    {
            //        string adjustPriceID = this.GetSequence("Pharmacy.Item.GetNewAdjustPriceID");
            //        if (adjustPriceID == null)
            //        {
            //            this.Err = "出库退库药品已发生调价 插入调价盈亏记录过程中获取调价单号出错！";
            //            return -1;
            //        }
            //        Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice = new AdjustPrice();
            //        adjustPrice.ID = adjustPriceID;								//调价单号
            //        adjustPrice.SerialNO = 0;									//调价单内序号
            //        adjustPrice.Item = input.Item;
            //        adjustPrice.StockDept.ID = input.StockDept.ID;						//调价科室 
            //        adjustPrice.State = "1";									//调价状态 1 已调价
            //        adjustPrice.StoreQty = input.Quantity;
            //        adjustPrice.Operation.ID = this.Operator.ID;
            //        adjustPrice.Operation.Name = this.Operator.Name;
            //        adjustPrice.Operation.Oper.OperTime = sysTime;
            //        adjustPrice.InureTime = sysTime;
            //        adjustPrice.AfterRetailPrice = dNowPrice;					//调价后零售价
            //        if (dNowPrice - input.Item.PriceCollection.RetailPrice > 0)
            //            adjustPrice.ProfitFlag = "1";							//调盈
            //        else
            //            adjustPrice.ProfitFlag = "0";							//调亏

            //        adjustPrice.Memo = "入库核准/入库退库补调价盈亏";
            //        if (this.InsertAdjustPriceInfo(adjustPrice) == -1)
            //        {
            //            return -1;
            //        }
            //        if (this.InsertAdjustPriceDetail(adjustPrice) == -1)
            //        {
            //            return -1;
            //        }
            //    }
            //    #endregion

            //    #region 库存更新
            //    if (this.UpdateStorageForInput(input, storageState) == -1)
            //        return -1;

            //    #endregion
            //}
            //更新药品字典表内信息
            //----
            return 1;
        }

        /// <summary>
        /// 核准入库信息（发票核准） 0 不更新库存 1 更新库存
        /// </summary>
        /// <param name="inputStore">入库记录类</param>
        /// <param name="isInputReturn">是否入库退库True 入库退库 False 正常入库</param>
        /// <param name="isUpdateStorage">是否更新库存 0 不更新 1 更新 True 更新 False 不更新</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int ApproveInput(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore, bool isInputReturn, bool isUpdateStorage, IMAInManager iManager)
        {
            int parm;
            if (inputStore.ID != "")
            {
                if (iManager.UpdateApproveInfo(inputStore) == -1)
                {
                    iManager.ErrStr = "核准入库记录执行出错！";
                    return -1;
                }

                //根据入库信息进行库存状态更新 如果不存在库存记录 则插入
                parm = iManager.UpdateStorageState(inputStore, "1", isUpdateStorage);
                if (parm == -1)
                {
                    iManager.ErrStr = "更新申请科室库存数据入库状态时出错！";
                    return -1;
                }
            }
            else
            {
                if (this.Input(inputStore, isInputReturn, isUpdateStorage, "1", iManager) == -1)
                {
                    return -1;
                }
            }

            //申请数据更新
            if (iManager.UpdateApplyInfo(inputStore) == -1)
            {
                return -1;
            }

            //更新出库记录状态为核准
            if (iManager.UpdateOutputInfo(inputStore) == -1)
            {
                return -1;
            }

            //更新/补足本批次物品库存信息
            if (iManager.UpdateItemInfoForStorage(inputStore) == -1)
            {
                return -1;
            }

            //更新/补足本批次物品基本项目信息
            if (iManager.UpdateItemInfoForBase(inputStore) == -1)
            {
                return -1;
            }

            //更新/补足本批次物品出库信息
            if (iManager.UpdateItemInfoForOutput(inputStore) == -1)
            {
                return -1;
            }

            return 1;



            //if (Input.StockDept.Memo == "PI")		//标志是药库的入库核准  
            //{
            //    #region 对全院库存更新购入价、发票信息
            //    decimal purchaseCost = System.Math.Round(Input.Quantity / Input.Item.PackQty * Input.Item.PriceCollection.PurchasePrice, 2);
            //    //取参数列表
            //    string[] strParmPrice = {
            //                                Input.ID,								//0 入库流水号
            //                                Input.Operation.ExamQty.ToString(),				//1 审批数量
            //                                Input.Operation.ExamOper.ID,						//2 审批人
            //                                Input.Operation.ExamOper.OperTime.ToString(),				//3 审批日期
            //                                Input.InvoiceNO,						//4 发票号码
            //                                Input.Item.PriceCollection.PurchasePrice.ToString(),	//5 购入价
            //                                purchaseCost.ToString(),				//6 购入金额
            //                                this.Operator.ID,						//7 操作人
            //                                Input.Item.ID,							//8 药品编码
            //                                Input.GroupNO.ToString(),				//9 批次
            //    };
            //    //更新全院药品库存购入价、入库发票号
            //    if (this.Sql.GetSql("Pharmacy.Item.UpdatePriceStorage", ref strSQL) == -1) return -1;
            //    strSQL = string.Format(strSQL, strParmPrice);        //替换SQL语句中的参数。
            //    parm = this.ExecNoQuery(strSQL);
            //    if (parm == -1)
            //    {
            //        this.Err = "更新库存表购入价时出错！";
            //        return -1;
            //    }

            //    //更新全院药品出库购入价
            //    if (this.Sql.GetSql("Pharmacy.Item.UpdatePriceOutput", ref strSQL) == -1) return -1;
            //    strSQL = string.Format(strSQL, strParmPrice);        //替换SQL语句中的参数。
            //    parm = this.ExecNoQuery(strSQL);
            //    if (parm == -1)
            //    {
            //        this.Err = "更新药品出库表购入价时出错！";
            //        return -1;
            //    }
            //    #endregion

            //    //更新药品字典内 信息
            //    parm = this.UpdateItemInputInfo(Input);
            //    if (parm == -1)
            //    {
            //        this.Err = "更新药品字典表内信息出错" + this.Err;
            //        return -1;
            //    }
            //}
            //return parm;
        }
        #endregion

        #region IMAInManager 成员

        public string ErrStr
        {
            get
            {
                return this.Err;
            }
            set
            {
                this.Err = value;
            }
        }

        public int SetInput(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore)
        {
            Neusoft.HISFC.Models.Pharmacy.Input input = inputStore as Neusoft.HISFC.Models.Pharmacy.Input;

            return this.InsertInput(input);
        }

        public int InputAdjust(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore)
        {
            Neusoft.HISFC.Models.Pharmacy.Input input = inputStore as Neusoft.HISFC.Models.Pharmacy.Input;

            decimal dNowPrice = 0;
            DateTime sysTime = this.GetDateTimeFromSysDateTime();
            if (this.GetNowPrice(input.Item.ID, ref dNowPrice) == -1)
            {
                this.Err = "处理入库记录退库过程中 获取药品" + input.Item.Name + "零售价出错";
                return -1;
            }
            if (input.Item.PriceCollection.RetailPrice != dNowPrice)
            {
                string adjustPriceID = this.GetSequence("Pharmacy.Item.GetNewAdjustPriceID");
                if (adjustPriceID == null)
                {
                    this.Err = "出库退库药品已发生调价 插入调价盈亏记录过程中获取调价单号出错！";
                    return -1;
                }
                Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice = new AdjustPrice();
                adjustPrice.ID = adjustPriceID;								//调价单号
                adjustPrice.SerialNO = 0;									//调价单内序号
                adjustPrice.Item = input.Item;
                adjustPrice.StockDept.ID = input.StockDept.ID;						//调价科室 
                adjustPrice.State = "1";									//调价状态 1 已调价
                adjustPrice.StoreQty = input.Quantity;
                adjustPrice.Operation.ID = this.Operator.ID;
                adjustPrice.Operation.Name = this.Operator.Name;
                adjustPrice.Operation.Oper.OperTime = sysTime;
                adjustPrice.InureTime = sysTime;
                adjustPrice.AfterRetailPrice = dNowPrice;					//调价后零售价
                if (dNowPrice - input.Item.PriceCollection.RetailPrice > 0)
                    adjustPrice.ProfitFlag = "1";							//调盈
                else
                    adjustPrice.ProfitFlag = "0";							//调亏

                adjustPrice.Memo = "入库核准/入库退库补调价盈亏";
                if (this.InsertAdjustPriceInfo(adjustPrice) == -1)
                {
                    return -1;
                }
                if (this.InsertAdjustPriceDetail(adjustPrice) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }

        public int SetStorage(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore, string storageState)
        {
            Neusoft.HISFC.Models.Pharmacy.Input input = inputStore as Neusoft.HISFC.Models.Pharmacy.Input;

            return this.UpdateStorageForInput(input, storageState);
        }

        public int UpdateApproveInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore)
        {
            string strSQL = "";
            int parm;

            if (this.Sql.GetSql("Pharmacy.Item.ApproveInput", ref strSQL) == -1)
                return -1;
            try
            {
                //取参数列表
                string[] strParm = {
										   inputStore.ID,                        //入库流水号
										   inputStore.Quantity.ToString(),       //核准数量
										   inputStore.Operation.ApproveOper.ID,           //核准人
										   inputStore.Operation.ApproveOper.OperTime.ToString(),    //核准日期
										   this.Operator.ID,                //操作人                  
					};
                strSQL = string.Format(strSQL, strParm);        //替换SQL语句中的参数。
                parm = this.ExecNoQuery(strSQL);
                if (parm == -1)
                {
                    this.Err = "核准入库记录执行出错！";
                    return -1;
                }
            }
            catch (Exception ex)
            {
                this.Err = "核准入库记录的SQl参数赋值时出错！Pharmacy.Item.ApproveInput" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return 1;
        }

        public int UpdateStorageState(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore, string storageState, bool isUpdateStorage)
        {
            Neusoft.HISFC.Models.Pharmacy.StorageBase storage = inputStore as Neusoft.HISFC.Models.Pharmacy.StorageBase;
            return this.UpdateStorageState(storage, storageState, isUpdateStorage);
        }

        public int UpdateApplyInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore)
        {
            Neusoft.HISFC.Models.Pharmacy.Input input = inputStore as Neusoft.HISFC.Models.Pharmacy.Input;

            return this.UpdateApplyOutState(input.StockDept.ID, input.OutListNO, "2");
        }

        public int UpdateOutputInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore)
        {
            Neusoft.HISFC.Models.Pharmacy.Input input = inputStore as Neusoft.HISFC.Models.Pharmacy.Input;

            int parm;
            ArrayList alOutput;

            alOutput = this.QueryOutputList(input.OutBillNO);
            if (alOutput == null)
            {
                this.Err = "更新出库记录过程中 获取出库记录出错！";
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.Output output;
            for (int i = 0; i < alOutput.Count; i++)
            {
                output = alOutput[i] as Neusoft.HISFC.Models.Pharmacy.Output;
                if (output == null)
                {
                    this.Err = "更新出库记录过程中 数据类型转换出错！";
                    return -1;
                }
                output.State = "2";
                output.InListNO = input.InListNO;
                output.InBillNO = input.ID;

                parm = this.UpdateOutput(output);
                if (parm == -1)
                {
                    this.Err = "更新出库记录执行出错！";
                    return -1;
                }
            }

            return 1;
        }

        public int UpdateItemInfoForStorage(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore)
        {
            string strSQL = "";
            int parm;

            Neusoft.HISFC.Models.Pharmacy.Input input = inputStore as Neusoft.HISFC.Models.Pharmacy.Input;

            decimal purchaseCost = System.Math.Round(input.Quantity / input.Item.PackQty * input.Item.PriceCollection.PurchasePrice, 2);
            //取参数列表
            string[] strParmPrice = {
											input.ID,								//0 入库流水号
											input.Operation.ExamQty.ToString(),				//1 审批数量
											input.Operation.ExamOper.ID,						//2 审批人
											input.Operation.ExamOper.OperTime.ToString(),				//3 审批日期
											input.InvoiceNO,						//4 发票号码
											input.Item.PriceCollection.PurchasePrice.ToString(),	//5 购入价
											purchaseCost.ToString(),				//6 购入金额
											this.Operator.ID,						//7 操作人
											input.Item.ID,							//8 药品编码
											input.GroupNO.ToString(),				//9 批次
				};
            //更新全院药品库存购入价、入库发票号
            if (this.Sql.GetSql("Pharmacy.Item.UpdatePriceStorage", ref strSQL) == -1) return -1;
            strSQL = string.Format(strSQL, strParmPrice);        //替换SQL语句中的参数。
            parm = this.ExecNoQuery(strSQL);
            if (parm == -1)
            {
                this.Err = "更新库存表购入价时出错！";
                return -1;
            }

            return 1;
        }

        public int UpdateItemInfoForBase(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore)
        {
            int parm;

            Neusoft.HISFC.Models.Pharmacy.Input input = inputStore as Neusoft.HISFC.Models.Pharmacy.Input;

            decimal purchaseCost = System.Math.Round(input.Quantity / input.Item.PackQty * input.Item.PriceCollection.PurchasePrice, 2);
            //取参数列表
            string[] strParmPrice = {
											input.ID,								//0 入库流水号
											input.Operation.ExamQty.ToString(),				//1 审批数量
											input.Operation.ExamOper.ID,						//2 审批人
											input.Operation.ExamOper.OperTime.ToString(),				//3 审批日期
											input.InvoiceNO,						//4 发票号码
											input.Item.PriceCollection.PurchasePrice.ToString(),	//5 购入价
											purchaseCost.ToString(),				//6 购入金额
											this.Operator.ID,						//7 操作人
											input.Item.ID,							//8 药品编码
											input.GroupNO.ToString(),				//9 批次
				};

            //更新药品字典内 信息
            parm = this.UpdateItemInputInfo(input);
            if (parm == -1)
            {
                this.Err = "更新药品字典表内信息出错" + this.Err;
                return -1;
            }

            return 1;
        }

        public int UpdateItemInfoForOutput(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore)
        {
            string strSQL = "";
            int parm;

            Neusoft.HISFC.Models.Pharmacy.Input input = inputStore as Neusoft.HISFC.Models.Pharmacy.Input;

            decimal purchaseCost = System.Math.Round(input.Quantity / input.Item.PackQty * input.Item.PriceCollection.PurchasePrice, 2);
            //取参数列表
            string[] strParmPrice = {
											input.ID,								//0 入库流水号
											input.Operation.ExamQty.ToString(),				//1 审批数量
											input.Operation.ExamOper.ID,						//2 审批人
											input.Operation.ExamOper.OperTime.ToString(),				//3 审批日期
											input.InvoiceNO,						//4 发票号码
											input.Item.PriceCollection.PurchasePrice.ToString(),	//5 购入价
											purchaseCost.ToString(),				//6 购入金额
											this.Operator.ID,						//7 操作人
											input.Item.ID,							//8 药品编码
											input.GroupNO.ToString(),				//9 批次
				};


            //更新全院药品出库购入价
            if (this.Sql.GetSql("Pharmacy.Item.UpdatePriceOutput", ref strSQL) == -1) return -1;
            strSQL = string.Format(strSQL, strParmPrice);        //替换SQL语句中的参数。
            parm = this.ExecNoQuery(strSQL);
            if (parm == -1)
            {
                this.Err = "更新药品出库表购入价时出错！";
                return -1;
            }

            return 1;
        }

        #endregion

        #region IMAOutManager 成员


        public int GetStorageNum(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore, out decimal storageNum)
        {
            storageNum = 0;
            Neusoft.HISFC.Models.Pharmacy.Output output = outputStore as Neusoft.HISFC.Models.Pharmacy.Output;
            if (output == null)
            {
                this.ErrStr = "对出库信息进行转换时 发生错误 传入参数不是Pharmacy.Output实体";
                return -1;
            }

            if (output.GroupNO != 0)
            {
                return this.GetStorageNum(output.StockDept.ID, output.Item.ID, output.GroupNO, out storageNum);
            }
            else
            {
                return this.GetStorageNum(output.StockDept.ID, output.Item.ID, out storageNum);
            }
        }

        public List<Neusoft.HISFC.Models.IMA.IMAStoreBase> QueryStorageList(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore)
        {
            Neusoft.HISFC.Models.Pharmacy.Output output = outputStore as Neusoft.HISFC.Models.Pharmacy.Output;
            ArrayList al = this.QueryStorageList(outputStore.StockDept.ID, output.Item.ID, output.GroupNO);
            if (al == null)
            {
                return null;
            }
            List<Neusoft.HISFC.Models.IMA.IMAStoreBase> alIMAStore = new List<Neusoft.HISFC.Models.IMA.IMAStoreBase>();
            foreach (Neusoft.HISFC.Models.Pharmacy.Storage info in al)
            {
                alIMAStore.Add(info);
            }

            return alIMAStore;
        }

        public int FillOutputInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase storeInfo, ref Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore)
        {
            Neusoft.HISFC.Models.Pharmacy.Output output = outputStore as Neusoft.HISFC.Models.Pharmacy.Output;
            if (output == null)
            {
                this.ErrStr = "对传入出库信息信息进行类型转换发生错误";
                return -1;
            }
            Neusoft.HISFC.Models.Pharmacy.Storage storage = storeInfo as Neusoft.HISFC.Models.Pharmacy.Storage;
            if (storage == null)
            {
                this.ErrStr = "对库存信息进行类型转换发生错误";
                return -1;
            }

            output.GroupNO = storage.GroupNO;           //批次
            output.BatchNO = storage.BatchNO;           //批号
            output.Company = storage.Company;           //供货公司
            output.PlaceNO = storage.PlaceNO;           //货位号
            output.Producer = storage.Producer;         //生产厂家
            output.ValidTime = storage.ValidTime;       //有效期

            return 1;

        }

        public int SetOutput(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore)
        {
            Neusoft.HISFC.Models.Pharmacy.Output output = outputStore as Neusoft.HISFC.Models.Pharmacy.Output;

            return this.InsertOutput(output);
        }

        public int UpdateOutputReturnQty(Neusoft.HISFC.Models.IMA.IMAStoreBase outputReturnQty)
        {
            return this.UpdateOutputReturnNum(outputReturnQty.ID, outputReturnQty.SerialNO, outputReturnQty.Operation.ReturnQty);
        }

        public int SetStorage(Neusoft.HISFC.Models.IMA.IMAStoreBase storeInfo)
        {
            Neusoft.HISFC.Models.Pharmacy.StorageBase info = storeInfo as Neusoft.HISFC.Models.Pharmacy.StorageBase;

            return this.SetStorage(info);
        }

        List<Neusoft.HISFC.Models.IMA.IMAStoreBase> IMAOutManager.QueryOutputList(string outputNO)
        {
            ArrayList al = this.QueryOutputList(outputNO);
            if (al == null)
            {
                return null;
            }
            List<Neusoft.HISFC.Models.IMA.IMAStoreBase> alOutput = new List<Neusoft.HISFC.Models.IMA.IMAStoreBase>();
            foreach (Neusoft.HISFC.Models.Pharmacy.Output info in al)
            {
                alOutput.Add(info);
            }

            return alOutput;
        }

        public int FillOutputReturnInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore, ref Neusoft.HISFC.Models.IMA.IMAStoreBase outputReturnStore)
        {
            Neusoft.HISFC.Models.Pharmacy.Output output = outputStore as Neusoft.HISFC.Models.Pharmacy.Output;
            Neusoft.HISFC.Models.Pharmacy.Output outputReturn = outputReturnStore as Neusoft.HISFC.Models.Pharmacy.Output;

            outputReturn.GroupNO = output.GroupNO;					//批次
            outputReturn.BatchNO = output.BatchNO;					//批号
            outputReturn.Company = output.Company;					//供货公司
            outputReturn.PlaceNO = output.PlaceNO;					//货位号
            outputReturn.Producer = output.Producer;					//生产厂家
            outputReturn.ValidTime = output.ValidTime;					//有效期
            outputReturn.Item.PriceCollection.RetailPrice = output.Item.PriceCollection.RetailPrice;	//零售价 利用原出库价格退库

            return 1;
        }

        public int OutputAdjust(Neusoft.HISFC.Models.IMA.IMAStoreBase privOutputStore, Neusoft.HISFC.Models.IMA.IMAStoreBase outputReturnStore, DateTime sysTime, int serialNo)
        {
            Neusoft.HISFC.Models.Pharmacy.Output privOutput = privOutputStore as Neusoft.HISFC.Models.Pharmacy.Output;
            if (privOutput == null)
            {
                this.ErrStr = "出库退库函数执行进行类型转换时发生错误 传入参数类型不正确";
                return -1;
            }
            Neusoft.HISFC.Models.Pharmacy.Output nowOutput = outputReturnStore as Neusoft.HISFC.Models.Pharmacy.Output;
            if (nowOutput == null)
            {
                this.ErrStr = "出库退库函数执行进行类型转换时发生错误 传入参数类型不正确";
                return -1;
            }

            string adjustPriceID = "";
            bool isDoAdjust = false;
            decimal dNowPrice = 0;

            if (this.GetNowPrice(nowOutput.Item.ID, ref dNowPrice) == -1)
            {
                this.Err = "出库退库处理调价盈亏时 获取最新药品零售价失败";
                return -1;
            }

            if (privOutput.Item.PriceCollection.RetailPrice != dNowPrice)
            {
                if (!isDoAdjust)
                {
                    adjustPriceID = this.GetSequence("Pharmacy.Item.GetNewAdjustPriceID");
                    if (adjustPriceID == null)
                    {
                        this.Err = "出库退库药品已发生调价 插入调价盈亏记录过程中获取调价单号出错！";
                        return -1;
                    }
                }
                Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice = new AdjustPrice();
                adjustPrice.ID = adjustPriceID;								//调价单号
                adjustPrice.SerialNO = serialNo;									//调价单内序号
                adjustPrice.Item = privOutput.Item;
                adjustPrice.StockDept.ID = privOutput.StockDept.ID;				//调价科室 
                adjustPrice.State = "1";									//调价状态 1 已调价
                adjustPrice.StoreQty = nowOutput.Quantity;
                adjustPrice.Operation.Oper.ID = this.Operator.ID;
                adjustPrice.Operation.Oper.Name = this.Operator.Name;
                adjustPrice.Operation.Oper.OperTime = sysTime;
                adjustPrice.InureTime = sysTime;
                adjustPrice.AfterRetailPrice = dNowPrice;//调价后零售价
                if (dNowPrice - privOutput.Item.PriceCollection.RetailPrice > 0)
                    adjustPrice.ProfitFlag = "1";							//调盈
                else
                    adjustPrice.ProfitFlag = "0";							//调亏
                adjustPrice.Memo = "出库退库补调价盈亏";
                if (!isDoAdjust)			//每次只插入一次调价汇总表
                {
                    if (this.InsertAdjustPriceInfo(adjustPrice) == -1)
                    {
                        return -1;
                    }
                    isDoAdjust = true;
                }
                if (this.InsertAdjustPriceDetail(adjustPrice) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }

        #endregion

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 账户新增
        /// <summary>
        /// 删除发药申请
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequenceNO">处方内项目流水号</param>
        /// <returns></returns>
        public int DelApplyOut(string recipeNO, string recipeSequenceNO)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.DeleteApplyOut1", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.DeleteApplyOut";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, recipeNO, recipeSequenceNO);
            }
            catch
            {
                this.Err = "传入参数不正确！Pharmacy.Item.DeleteApplyOut";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        #region 非正常业务调用方法 {5182824E-9F42-493c-B985-F5803AA5FC9E}

        /// <summary>
        /// 写临时日志（仅用于各种测试使用） by Sunjh 2010-8-24 {5182824E-9F42-493c-B985-F5803AA5FC9E}
        /// </summary>
        /// <param name="logTemp"></param>
        /// <returns></returns>
        public int WriteLogTemp(Neusoft.FrameWork.Models.NeuObject logTemp)
        {
            string strSQL = "insert into pha_com_temp_log(temp_id,temp_name,temp_memo) values('{0}','{1}','{2}')";
            try
            {
                strSQL = string.Format(strSQL, logTemp.ID, logTemp.Name, logTemp.Memo);
            }
            catch
            {
                this.Err = "传入参数不正确！";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 写临时日志（仅用于各种测试使用） by Sunjh 2010-8-24 {5182824E-9F42-493c-B985-F5803AA5FC9E}
        /// </summary>
        /// <param name="tempID"></param>
        /// <param name="tempName"></param>
        /// <param name="tempMemo"></param>
        /// <param name="tempDif"></param>
        /// <returns></returns>
        public int WriteLogTemp(string tempID, string tempName, string tempMemo, string tempDif)
        {
            string strSQL = "insert into pha_com_temp_log(temp_id,temp_name,temp_memo,user01) values('{0}','{1}','{2}','{3}')";
            try
            {
                strSQL = string.Format(strSQL, tempID, tempName, tempMemo, tempDif);
            }
            catch
            {
                this.Err = "传入参数不正确！";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 性能优化后的方法

        /// <summary>
        /// 获取库存方法性能优化 by Sunjh 2010-8-30 {C2BF59BC-9C07-4b0a-A5E2-797426CCDE81}
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="drugCode"></param>
        /// <returns></returns>
        public Storage GetStockInfoByDrugCodeOptimize(string deptCode, string drugCode)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetStockinfoList.ByDrugCode.Optimize", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockinfoList.ByDrugCode.Optimize字段!";
                return null;
            }
            
            strSQL = string.Format(strSQL, deptCode, drugCode);

            ArrayList al = new ArrayList();                  //用于返回库存信息的数组
            Neusoft.HISFC.Models.Pharmacy.Storage storage; //库存信息实体

            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    //取查询结果中的记录
                    storage = new Neusoft.HISFC.Models.Pharmacy.Storage();
                    storage.Item.ID = this.Reader[0].ToString();                              //1药品编码                    
                    storage.Item.PackUnit = this.Reader[1].ToString();                         //7包装单位                    
                    storage.StoreQty = NConvert.ToDecimal(this.Reader[2].ToString());         //12库存数量                   
                    storage.PreOutQty = NConvert.ToDecimal(this.Reader[3].ToString());       //14预扣库存数量                    
                    storage.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)NConvert.ToInt32(this.Reader[4].ToString());

                    al.Add(storage);
                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //------------

            if (al == null)
            {
                return null;
            }

            //如果没有找到数据，则返回新实体。
            if (al.Count == 0)
            {
                return new Neusoft.HISFC.Models.Pharmacy.Storage();
            }

            return al[0] as Neusoft.HISFC.Models.Pharmacy.Storage;
        }

        /// <summary>
        /// 获取某药品在某药房的货位号
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="drugCode"></param>
        /// <returns></returns>
        public string GetPlaceNoOptimize(string deptCode, string drugCode)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.GetStockPlaceNo.ByDrugCode.Optimize", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetStockPlaceNo.ByDrugCode.Optimize字段!";
                return null;
            }

            strSQL = string.Format(strSQL, deptCode, drugCode);
            return this.ExecSqlReturnOne(strSQL, "");
        }

        #endregion

        #region 郑大一附院增加 
    
        #region 批量盘点速度慢甚至死机的问题 {17261296-ABFC-45d5-AD3A-D772B905C8CA} wbo 2010-09-28
        /// <summary>
        /// 对本库房所有药品进行封帐处理，更新盘点明细表
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="isBatch">是否按批号盘点</param>
        /// <param name="isCheckZeroStock">是否对库存为零药品进行封帐处理</param>
        /// <param name="isCheckStopDrug">是否对本库房停用药品进行封帐处理</param>       
        /// <returns>成功返回封帐数组，失败返回null</returns>
        public ArrayList LocalCheckCloseByTotal(string deptCode, bool isBatch, bool isCheckZeroStock, bool isCheckStopDrug)
        {
            #region 获取Sql语句
            string strSQL = "";
            //取查找库存的SELECT语句
            if (isBatch)
            {	//按批号盘点    由库存明细表Storage内获取
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByTotalBatch", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByTotalBatch字段!";
                    return null;
                }
            }
            else
            {	//不按批号盘点  由StockInfo内获取汇总统计量
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByTotal", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByTotal字段!";
                    return null;
                }
            }
            try
            {
                if (isCheckStopDrug)            //对停用药品进行封帐处理
                {
                    strSQL = string.Format(strSQL, deptCode, "A");
                }
                else                           //只对有效药品进行封帐
                {
                    strSQL = string.Format(strSQL, deptCode, '1');
                }
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckCloseByTotal:" + ex.Message;
                return null;
            }
            #endregion

            #region Sql语句执行
            DateTime tempdate = this.GetDateTimeFromSysDateTime();
            ArrayList checkAl = new ArrayList();	//用于盘点实体存储
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得库房库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    string stoNum = this.Reader[4].ToString();
                    //如不对库存为零进行封帐则继续
                    if (!isCheckZeroStock && NConvert.ToDecimal(stoNum) == 0)
                    {
                        continue;
                    }
                    //放界面层
                    //if (item.IsStop)                //不对药库停用药品进行盘点处理
                    //{
                    //    continue;
                    //}

                    Neusoft.HISFC.Models.Pharmacy.Check checkTemp = new Check();
                    checkTemp.StockDept.ID = deptCode;							//库房编码
                    checkTemp.State = "0";								        //盘点状态 封帐
                    checkTemp.FOper.ID = this.Operator.ID;					    //封帐人
                    checkTemp.FOper.OperTime = tempdate;						//封帐时间
                    checkTemp.Operation.Oper.ID = this.Operator.ID;				//操作人
                    checkTemp.Operation.Oper.OperTime = tempdate;				//操作时间
                    //checkTemp.Item = item;									    //药品实体
                    checkTemp.Item.ID = this.Reader[0].ToString();
                    checkTemp.BatchNO = this.Reader[3].ToString();  		    //药品批号
                    checkTemp.FStoreQty = NConvert.ToDecimal(stoNum);	        //封帐库存数量
                    checkTemp.PlaceNO = this.Reader[1].ToString();		        //库位号
                    checkTemp.ValidTime = NConvert.ToDateTime(this.Reader[2].ToString());	    //有效期
                    //checkTemp.Producer.ID = item.Product.Producer.ID;			//生产厂家
                    checkTemp.CStoreQty = 0;								    //结存数量 更新为0
                    checkTemp.IsAdd = false;									//是否附加药品 对非附加药品数据库内标记为0

                    checkAl.Add(checkTemp);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得库房库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            #endregion

            return checkAl;
        }

        /// <summary>
        /// 按照药品类别、性质进行封帐处理,更新盘点明细表
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugType">药品类别</param>
        /// <param name="isBatch">是否按批号盘点</param>
        /// <param name="isCheckZeroStock">是否对库存为零药品进行封帐处理</param>
        /// <param name="isCheckStopDrug">是否对本库房停用药品进行封帐处理</param>   
        /// <returns>成功返回封帐数组，失败返回null</returns>
        public ArrayList LocalCheckCloseByTypeQuality(string deptCode, string drugType, string drugQuality, bool isBatch, bool isCheckZeroStock, bool isCheckStopDrug)
        {
            #region 查找Sql语句
            string strSQL = "";
            //取查找库存的SELECT语句
            if (isBatch)
            {	//按批号盘点 按照批号获取列表
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByTypeBatch", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByTypeBatch字段!";
                    return null;
                }
            }
            else
            {	//不按批号盘点 由StockInfo获取 汇总信息 设置有效期为4000-01-01
                if (this.Sql.GetSql("Pharmacy.Item.GetCheckCloseByType", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.GetCheckCloseByType字段!";
                    return null;
                }
            }
            try
            {
                if (isCheckStopDrug)            //对停用药品进行封帐处理
                {
                    strSQL = string.Format(strSQL, deptCode, drugType, drugQuality, "A");
                }
                else                           //只对有效药品进行封帐
                {
                    strSQL = string.Format(strSQL, deptCode, drugType, drugQuality, '1');
                }
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetCheckCloseByType:" + ex.Message;
                return null;
            }
            #endregion

            #region Sql语句执行
            DateTime tempdate = this.GetDateTimeFromSysDateTime();
            ArrayList checkAl = new ArrayList();	//用于盘点实体存储
            //执行查询语句
            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得库房库存信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    string stoNum = this.Reader[4].ToString();
                    //如不对库存为零进行封帐则继续
                    if (!isCheckZeroStock && NConvert.ToDecimal(stoNum) == 0)
                    {
                        continue;
                    }
                    //放界面层
                    //if (item.IsStop)                //不对药库停用药品进行盘点处理
                    //{
                    //    continue;
                    //}

                    Neusoft.HISFC.Models.Pharmacy.Check checkTemp = new Check();
                    checkTemp.StockDept.ID = deptCode;							//库房编码
                    checkTemp.State = "0";								        //盘点状态 封帐
                    checkTemp.FOper.ID = this.Operator.ID;					    //封帐人
                    checkTemp.FOper.OperTime = tempdate;						//封帐时间
                    checkTemp.Operation.Oper.ID = this.Operator.ID;				//操作人
                    checkTemp.Operation.Oper.OperTime = tempdate;				//操作时间
                    //checkTemp.Item = item;									    //药品实体
                    checkTemp.Item.ID = this.Reader[0].ToString();
                    checkTemp.BatchNO = this.Reader[3].ToString();  		    //药品批号
                    checkTemp.FStoreQty = NConvert.ToDecimal(stoNum);	        //封帐库存数量
                    checkTemp.PlaceNO = this.Reader[1].ToString();		        //库位号
                    checkTemp.ValidTime = NConvert.ToDateTime(this.Reader[2].ToString());	    //有效期
                    //checkTemp.Producer.ID = item.Product.Producer.ID;			//生产厂家
                    checkTemp.CStoreQty = 0;								    //结存数量 更新为0
                    checkTemp.IsAdd = false;									//是否附加药品 对非附加药品数据库内标记为0

                    checkAl.Add(checkTemp);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得库房库存信息时出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            #endregion

            return checkAl;
        }
        #endregion

        #region 住院集中发药相关 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}

        /// <summary>
        /// 查询某科室某药房的发药申请信息（为实现领药单模式）
        /// </summary>
        /// <param name="billClassCode">摆药单代码</param>
        /// <param name="deptCode">领药科室</param>
        /// <param name="drugDeptCode">目标药房</param>
        /// <param name="applyState">申请状态 0申请 1打印 2摆药</param>
        /// <returns></returns>
        public ArrayList QueryApplyOutList(string billClassCode, string deptCode, string drugDeptCode, string applyState)
        {
            string strSQL = "";
            string strWhere = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Patient", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Patient字段!";
                return null;
            }
            //取WHERE语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByApplyState", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByApplyState字段!";
                return null;
            }

            try
            {
                string[] strParm = { applyState, deptCode, drugDeptCode, billClassCode };
                strSQL = string.Format(strSQL + strWhere, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSQL);
        }

        /// <summary>
        /// 打印领药单时生成发药申请表的摆药单号
        /// </summary>
        /// <param name="billClassCode"></param>
        /// <param name="deptCode"></param>
        /// <param name="drugDeptCode"></param>
        /// <param name="applyState"></param>
        /// <param name="drugBill"></param>
        /// <returns></returns>
        public int UpdateApplyDrugBill(string billClassCode, string deptCode, string drugDeptCode, string applyState, ref string drugBill)
        {
            //取摆药单流水号（出库申请表中的摆药单号）
            drugBill = this.GetNewDrugBillNO();
            if (drugBill == null)
            {
                return -1;
            }
            //修改摆药单号
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.ApplyOut.UpdateDrugBill", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.ApplyOut.UpdateDrugBill";
                return -1;
            }
            strSQL = string.Format(strSQL, applyState, deptCode, drugDeptCode, billClassCode, drugBill);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据申请单号修改发药申请表
        /// </summary>
        /// <param name="applyNumber"></param>
        /// <param name="drugBill"></param>
        /// <returns></returns>
        public int UpdateApplyDrugBillByNumber(string drugBill, string applyNumber)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.ApplyOut.UpdateDrugBill.ByApplyNumber", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.ApplyOut.UpdateDrugBill.ByApplyNumber";
                return -1;
            }
            strSQL = string.Format(strSQL, drugBill, applyNumber);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 修改发药状态
        /// </summary>
        /// <param name="drugDeptCode">药房编码</param>
        /// <param name="drugBill">摆药单</param>
        /// <returns></returns>
        public int UpdateApplyDrugBill(string drugDeptCode, string drugBill)
        {
            string strSQL = "";
            if (this.Sql.GetSql("Pharmacy.Item.ApplyOut.UpdateState.ByBill", ref strSQL) == -1)
            {
                this.Err = "没有找到SQL语句Pharmacy.Item.ApplyOut.UpdateState.ByBill";
                return -1;
            }
            strSQL = string.Format(strSQL, drugDeptCode, drugBill);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 查询护士站已经打印的领药单号
        /// </summary>
        /// <param name="billClassCode"></param>
        /// <param name="deptCode"></param>
        /// <param name="drugDeptCode"></param>
        /// <returns></returns>
        public ArrayList QueryNursePrintBill(string billClassCode, string deptCode, string drugDeptCode)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.ApplyOut.QueryDrugBill.ByNursePrint", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.ApplyOut.QueryDrugBill.ByNursePrint字段!";
                return null;
            }

            try
            {
                string[] strParm = { deptCode, drugDeptCode, billClassCode };
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject info;

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得领药单列表时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();
                    info.Memo = this.Reader[0].ToString();
                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获得领药单列表时出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 查询护士站已经打印的领药单号
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public ArrayList QueryNursePrintBill(string deptCode)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.ApplyOut.QueryDrugBill.ByNursePrintDept", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.ApplyOut.QueryDrugBill.ByNursePrintDept字段!";
                return null;
            }

            try
            {
                string[] strParm = { deptCode };
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject info;

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得领药单列表时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();
                    info.Memo = this.Reader[0].ToString();
                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获得领药单列表时出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 根据领药单号获取待摆药信息
        /// </summary>
        /// <param name="drugBill"></param>
        /// <returns></returns>
        public ArrayList QueryApplyOutListByNurseBill(string drugBill)
        {
            string strSQL = "";

            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.Bill", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.Bill字段!";
                return null;
            }

            try
            {
                strSQL = string.Format(strSQL, drugBill);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSQL);
        }

        /// <summary>
        /// 获取已打印领药单的摆药单列表
        /// </summary>
        /// <param name="drugMessage"></param>
        /// <returns></returns>
        public List<Neusoft.FrameWork.Models.NeuObject> QueryApplyOutPatientListByBill(DrugMessage drugMessage)
        {
            string strSQL = "";  //取某一药房中某一中摆药单、某一科室待摆药患者列表的SQL语句

            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutPatientList.ByBill", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutPatientList.ByBill字段!";
                return null;
            }
            string[] strParm = {
								   drugMessage.ApplyDept.ID,             //0申请科室
								   drugMessage.StockDept.ID,              //1药房编码
								   drugMessage.DrugBillClass.ID,        //2摆药单分类编码
								   drugMessage.SendType.ToString(),     //3发送类型
			};
            strSQL = string.Format(strSQL, strParm);

            //根据SQL语句取数组并返回数组
            List<Neusoft.FrameWork.Models.NeuObject> neuObjectList = new List<Neusoft.FrameWork.Models.NeuObject>();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取待摆药患者列表时出错：" + this.Err;
                return null;
            }
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj; //患者信息住院流水号ID，姓名Name，床号Memo	
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();                   //住院流水号
                    obj.Name = this.Reader[1].ToString();                 //姓名
                    obj.Memo = this.Reader[2].ToString();                 //床号

                    neuObjectList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得待摆药患者列表时，执行SQL语句出错！myGetDrugBillClass" + ex.Message;
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return neuObjectList;
        }

        /// <summary>
        /// 更新出库申请表中已经打印领药单的打印状态为已打印
        /// 需要的数据：出库申请单流水号
        /// </summary>
        /// <param name="applyOut">出库申请记录</param>
        /// <returns>0没有更新（并发） 1成功 -1失败</returns>
        public int ExamApplyOutByNursePrint(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            string strSQL = "";

            try
            {
                // 只打印摆药单。更新摆药状态为1
                if (applyOut.State == "1")
                {
                    //审批出库申请（打印摆药单），更新出库申请表中的打印状态为已打印，摆药单流水号，打印人，打印日期（系统时间）

                    //清空核准数据项中的数值
                    applyOut.Operation.ApproveOper.ID = "";            //核准人
                    applyOut.Operation.ApproveOper.OperTime = DateTime.MinValue; //核准日期
                    applyOut.Operation.ApproveOper.Dept.ID = "";             //核准科室
                }

                //取SQL语句
                //Pharmacy.Item.ExamApplyOut.ByNursePrint
                if (this.Sql.GetSql("Pharmacy.Item.ExamApplyOut.ByNursePrint", ref strSQL) == -1)
                {
                    this.Err = "没有找到SQL语句Pharmacy.Item.ExamApplyOut";
                    return -1;
                }

                //取参数列表
                string[] strParm = {
									   applyOut.ID,                                         //出库申请单流水号
									   applyOut.State,                                      //出库申请状态
									   applyOut.Operation.ApproveOper.ID,                   //核准人
									   applyOut.Operation.ApproveOper.OperTime.ToString(),  //核准日期
									   applyOut.Operation.ApproveOper.Dept.ID,              //核准科室
									   applyOut.DrugNO,                                     //摆药单流水号
									   applyOut.Operation.ApproveQty.ToString(),            //核准数量
									   this.Operator.ID,                                    //打印人
									   applyOut.Operation.ExamOper.OperTime.ToString(),    //打印时间
									   applyOut.PlaceNO,     		                        //货位号
                                       NConvert.ToInt32(applyOut.IsCharge).ToString(),      //收费标记
                                       applyOut.RecipeNO,                                   //处方号
                                       applyOut.SequenceNO.ToString()                       //处方内项目流水号
								   };


                strSQL = string.Format(strSQL, strParm);          //替换SQL语句中的参数。
            }
            catch (Exception ex)
            {
                this.Err = "审批出库申请SQl参数赋值时出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 取汇总摆药单
        /// </summary>
        /// <param name="drugBillCode">摆药单号</param>
        /// <returns>成功返回摆药申请信息 失败返回null</returns>
        public ArrayList QueryDrugBillTotalByNursePrint(string drugBillCode)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDrugBillTotal.ByNursePrint", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugBillTotal.ByNursePrint字段!";
                return null;
            }

            if (drugBillCode.IndexOf("'") == -1)
            {
                drugBillCode = "'" + drugBillCode + "'";
            }

            strSQL = string.Format(strSQL, drugBillCode);

            //根据SQL语句取数组并返回数组
            ArrayList arrayObject = new ArrayList();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取汇总摆药单时出错：" + this.Err;
                return null;
            }
            try
            {
                ApplyOut obj = null;
                while (this.Reader.Read())
                {
                    obj = new ApplyOut();
                    obj.ApplyDept.ID = this.Reader[0].ToString();                        //0申请部门编码（科室或者病区）
                    obj.StockDept.Name = this.Reader[1].ToString();                     //1发药部门编码 
                    obj.Item.ID = this.Reader[2].ToString();                             //2药品编码
                    obj.Item.Name = this.Reader[3].ToString();                           //3药品商品名
                    obj.Item.Specs = this.Reader[4].ToString();                          //4规格
                    obj.Item.PackUnit = this.Reader[5].ToString();                       //5包装单位
                    obj.Item.PackQty = NConvert.ToDecimal(this.Reader[6].ToString());  //6包装数
                    obj.Item.MinUnit = this.Reader[7].ToString();                        //7最小单位
                    obj.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString());//8零售价
                    obj.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[9].ToString());        //9申请出库量
                    obj.DrugNO = this.Reader[10].ToString();                           //10摆药单号
                    obj.PrintState = this.Reader[11].ToString();                         //11打印状态（0未打印，1已打印）
                    obj.Operation.ExamOper.ID = this.Reader[12].ToString();                       //12打印人
                    obj.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[13].ToString());      //13打印日期
                    obj.PlaceNO = this.Reader[14].ToString();							 //14货位号
                    obj.SendType = NConvert.ToInt32(this.Reader[15].ToString());	//15 发送标志
                    //obj.RadixQty = NConvert.ToDecimal(this.Reader[16].ToString());      //16 基数药使用量{96110D72-8ADB-4af2-B616-5EDE8D3773ED}
                    arrayObject.Add(obj);
                }
                return arrayObject;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得汇总摆药单时，执行SQL语句出错！GetDrugBillTotalByNursePrint" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 取明细摆药单
        /// //患者信息科室编码User01，摆药单号User02
        /// </summary>
        /// <param name="drugBillCode">摆药单号</param>
        /// <returns>成功返回摆药申请信息 失败返回null</returns>
        public ArrayList QueryDrugBillDetailByNursePrint(string drugBillCode)
        {
            string strSQL = "";
            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Item.GetDrugBillDetail.ByNursePrint", ref strSQL) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetDrugBillDetail.ByNursePrint字段!";
                return null;
            }

            if (drugBillCode.IndexOf("'") == -1)
            {
                drugBillCode = "'" + drugBillCode + "'";
            }

            strSQL = string.Format(strSQL, drugBillCode);

            //根据SQL语句取数组并返回数组
            ArrayList arrayObject = new ArrayList();

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "取明细摆药单时出错：" + this.Err;
                return null;
            }
            try
            {
                ApplyOut obj; //患者信息科室编码User01，摆药单号User02

                while (this.Reader.Read())
                {
                    obj = new ApplyOut();
                    obj.ApplyDept.ID = this.Reader[0].ToString();                   //0申请部门编码（科室或者病区）
                    obj.StockDept.Name = this.Reader[1].ToString();                  //1发药部门编码 
                    obj.Item.ID = this.Reader[2].ToString();                        //2药品编码
                    obj.Item.Name = this.Reader[3].ToString();                      //3药品商品名
                    obj.Item.Specs = this.Reader[4].ToString();                     //4规格
                    obj.Item.PackUnit = this.Reader[5].ToString();                  //5包装单位
                    obj.Item.PackQty = NConvert.ToDecimal(this.Reader[6].ToString());//6包装数
                    obj.Item.MinUnit = this.Reader[7].ToString();                   //7最小单位
                    obj.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(this.Reader[8].ToString()); //8零售价
                    obj.Days = NConvert.ToDecimal(this.Reader[9].ToString());       //9付数
                    obj.User01 = this.Reader[10].ToString();                        //10患者姓名
                    obj.User02 = this.Reader[11].ToString();                        //11床号
                    obj.DoseOnce = NConvert.ToDecimal(this.Reader[12].ToString());  //12每次剂量
                    obj.Item.DoseUnit = this.Reader[13].ToString();                 //13剂量单位
                    obj.Usage.ID = this.Reader[14].ToString();                      //14用法代码
                    obj.Usage.Name = this.Reader[15].ToString();                    //15用法名称
                    obj.Frequency.ID = this.Reader[16].ToString();                  //16频次代码
                    obj.Frequency.Name = this.Reader[17].ToString();                //17频次名称
                    obj.Operation.ApplyQty = NConvert.ToDecimal(this.Reader[18].ToString());  //18申请出库量
                    obj.DrugNO = this.Reader[19].ToString();                      //19摆药单号
                    obj.PrintState = this.Reader[20].ToString();                    //20打印状态（0未打印，1已打印）
                    obj.Operation.ExamOper.ID = this.Reader[21].ToString();                  //21打印人
                    obj.Operation.ExamOper.OperTime = NConvert.ToDateTime(this.Reader[22].ToString()); //22打印日期
                    obj.CombNO = this.Reader[23].ToString();						//23组合序号
                    obj.Memo = this.Reader[24].ToString();							//24医嘱备注
                    obj.PlaceNO = this.Reader[25].ToString();						//25货位号
                    obj.User03 = this.Reader[26].ToString();
                    obj.OrderNO = this.Reader[27].ToString();					//医嘱流水号
                    obj.SendType = NConvert.ToInt32(this.Reader[28].ToString());//发送类型 1 集中 2 临时 0 全部
                    obj.State = this.Reader[29].ToString();				//单据状态
                    //字段无效需处理 by Sunjh 2011-11-17
                    //obj.HerbalDecoction.Mode.ID = this.Reader[30].ToString();
                    //obj.HerbalDecoction.Dose.ID = this.Reader[31].ToString();
                    //obj.HerbalDecoction.Type.ID = this.Reader[32].ToString();

                    obj.PatientNO = this.Reader[33].ToString();

                    obj.RecipeInfo.ID = this.Reader[34].ToString();

                    //字段无效需处理 by Sunjh 2011-11-17
                    //obj.HerbalDecoction.Usage.ID = this.Reader[35].ToString();

                    arrayObject.Add(obj);
                }
                return arrayObject;
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获得明细摆药单时，执行SQL语句出错！GetDrugBillDetailByNursePrint" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 查询摆药单列表
        /// </summary>
        /// <param name="drugDept">发药科室代码</param>
        /// <param name="applyDept">申请科室代码</param>
        /// <param name="applyState">申请状态</param>
        /// <param name="isQueryByTime">是否通过时间查询</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public ArrayList QueryDrugBillList(string drugDept, string applyDept, string applyState, bool isQueryByTime, DateTime beginTime, DateTime endTime)
        {
            string strSQL = "";
            if (!isQueryByTime)
            {
                if (this.Sql.GetSql("Pharmacy.Item.ApplyOut.QueryDrugBill.ByApplyState", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.ApplyOut.QueryDrugBill.ByApplyState字段!";
                    return null;
                }
                try
                {
                    strSQL = string.Format(strSQL, drugDept, applyDept, applyState);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    return null;
                }
            }
            else
            {
                if (this.Sql.GetSql("Pharmacy.Item.ApplyOut.QueryDrugBill.ByApplyStateTime", ref strSQL) == -1)
                {
                    this.Err = "没有找到Pharmacy.Item.ApplyOut.QueryDrugBill.ByApplyStateTime字段!";
                    return null;
                }
                try
                {
                    strSQL = string.Format(strSQL, drugDept, applyDept, applyState, beginTime, endTime);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    return null;
                }
            }

            //根据SQL语句取药品类数组并返回数组
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject info;

            if (this.ExecQuery(strSQL) == -1)
            {
                this.Err = "获得领药单列表时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.Reader[0].ToString();
                    info.Name = this.Reader[1].ToString();
                    info.Memo = this.Reader[2].ToString();
                    al.Add(info);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = "获得领药单列表时出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 查询已发药的摆药单号记录数
        /// </summary>
        /// <param name="drugBillCode"></param>
        /// <returns></returns>
        public int GetDrugBillCountByState(string drugBillCode)
        {
            string strCountBill = "";
            strCountBill = this.ExecSqlReturnOne("select count(t.druged_bill) from pha_com_applyout t where t.druged_bill='" + drugBillCode + "' and t.apply_state='1'");
            return Convert.ToInt32(strCountBill);
        }

        /// <summary>
        /// 查询发药申请表根据申请时间和药房
        /// </summary>
        /// <param name="stockDept"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="applyDept"></param>
        /// <param name="drugBill"></param>
        /// <returns></returns>
        public ArrayList QueryApplyOutByApplyDate(string stockDept, string beginTime, string endTime, string applyDept, string drugBill)
        {
            string strSelect = "";
            string strWhere = "";

            //取SELECT语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList", ref strSelect) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList字段!";
                return null;
            }

            //取WHERE条件语句
            if (this.Sql.GetSql("Pharmacy.Item.GetApplyOutList.ByApplyTime.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到Pharmacy.Item.GetApplyOutList.ByApplyTime.Where字段!";
                return null;
            }

            try
            {
                if (drugBill == "")
                {
                    strSelect = string.Format(strSelect + " " + strWhere, stockDept, beginTime, endTime, applyDept, "ALL");
                }
                else
                {
                    strSelect = string.Format(strSelect + " " + strWhere, stockDept, beginTime, endTime, applyDept, drugBill);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            //根据SQL语句取药品类数组并返回数组
            return this.myGetApplyOut(strSelect);
        }

        /// <summary>
        /// 取消发送到药房的药品，状态还原至发送之前
        /// </summary>
        /// <param name="applyNumber"></param>
        /// <returns></returns>
        public int CancelApplyDrug(string applyNumber, bool isInState)
        {
            string strSQL = "";
            if (isInState)
            {
                if (this.Sql.GetSql("Pharmacy.Item.ApplyOut.UpdateApply.ByApplyNumber", ref strSQL) == -1)
                {
                    this.Err = "没有找到SQL语句Pharmacy.Item.ApplyOut.UpdateApply.ByApplyNumber";
                    return -1;
                }
            }
            else
            {
                if (this.Sql.GetSql("Pharmacy.Item.ApplyOut.UpdateApply.UpdateValid.ByApplyNumber", ref strSQL) == -1)
                {
                    this.Err = "没有找到SQL语句Pharmacy.Item.ApplyOut.UpdateApply.UpdateValid.ByApplyNumber";
                    return -1;
                }
            }
            strSQL = string.Format(strSQL, applyNumber);

            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 临时表日志插入
        /// </summary>
        /// <param name="tempLog"></param>
        /// <returns></returns>
        public int CreatLogTemp(Neusoft.FrameWork.Models.NeuObject tempLog)
        {
            string strSQL = "insert into s_t_met2(met_code,met_name,memo,m1,m2,m3) values('{0}','{1}','{2}','{3}','{4}','{5}')";
            strSQL = string.Format(strSQL, tempLog.ID, tempLog.Name, tempLog.Memo, tempLog.User01, tempLog.User02, tempLog.User03);

            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #endregion

    }
}

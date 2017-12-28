/*----------------------------------------------------------------
            // Copyright (C) 沈阳东软软件股份有限公司
            // 版权所有。 
            //
            // 文件名：			EcoRate.cs
            // 文件功能描述：	优惠比率方法类
            //
            // 
            // 创建标识：		2006-6-16
            //
            // 修改标识：
            // 修改描述：
            //
            // 修改标识：
            // 修改描述：
//----------------------------------------------------------------*/

using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Fee
{
    /// <summary>
    /// 优惠比率方法类
    /// </summary>
    public class EcoRate : Neusoft.FrameWork.Management.Database
    {
        public EcoRate()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        #region 变量定义
        /// <summary>
        /// 返回值
        /// </summary>
        int intReturn = 0;
        /// <summary>
        /// Select语句
        /// </summary>
        string SELECT = "";
        /// <summary>
        /// Where语句
        /// </summary>
        string WHERE = "";
        /// <summary>
        /// SQL语句
        /// </summary>
        string SQL = "";
        /// <summary>
        /// 字段序号枚举
        /// </summary>
        enum Field
        {
            /// <summary>
            /// 医院父级编码
            /// </summary>
            ParentCode = 0,
            /// <summary>
            /// 医院本级编码
            /// </summary>
            CurrentCode = 1,
            /// <summary>
            /// 比率类别编码
            /// </summary>
            EcoCode = 2,
            /// <summary>
            /// 项目类型编码
            /// </summary>
            TypeCode = 3,
            /// <summary>
            /// 项目编码
            /// </summary>
            ItemCode = 4,
            /// <summary>
            /// 公费比率
            /// </summary>
            PubRate = 5,
            /// <summary>
            /// 自费比率
            /// </summary>
            OwnRate = 6,
            /// <summary>
            /// 自付比率
            /// </summary>
            PayRate = 7,
            /// <summary>
            /// 优惠比率
            /// </summary>
            EcoRate = 8,
            /// <summary>
            /// 减免比率
            /// </summary>
            ArrRate = 9,
            /// <summary>
            /// 操作员编码
            /// </summary>
            OperatorCode = 10,
            /// <summary>
            /// 操作日期
            /// </summary>
            OperateDate = 11,
            /// <summary>
            /// 项目名称
            /// </summary>
            ItemName = 12
        }
        /// <summary>
        /// 参数数组
        /// </summary>
        string[] parameters = new string[12];
        #endregion

        #region	清空数组
        /// <summary>
        /// 清空数组
        /// </summary>
        private void InitParameters()
        {
            for (int i = 0; i < this.parameters.Length; i++)
            {
                this.parameters[i] = "";
            }
        }
        #endregion

        #region 转换Reader成Object
        /// <summary>
        /// 转换Reader成Object
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 优惠比率类]
        /// </summary>
        /// <param name="ecoRate">优惠比率类</param>
        private void ChangeReaderToObject(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate)
        {
            // 父级编码
            ecoRate.Hospital.ID = this.Reader[(int)Field.ParentCode].ToString();
            // 本级编码
            ecoRate.Hospital.Name = this.Reader[(int)Field.CurrentCode].ToString();
            // 比率类别编码
            ecoRate.RateType.ID = this.Reader[(int)Field.EcoCode].ToString();
            // 项目类别编码
            ecoRate.ItemType.ID = this.Reader[(int)Field.TypeCode].ToString();
            switch (ecoRate.ItemType.ID)
            {
                case "0":
                    ecoRate.ItemType.Name = "大类";
                    break;
                case "1":
                    ecoRate.ItemType.Name = "最小费用";
                    break;
                case "2":
                    ecoRate.ItemType.Name = "收费项目";
                    break;
            }
            // 项目编码
            ecoRate.Item.ID = this.Reader[(int)Field.ItemCode].ToString();
            // 项目名称
            ecoRate.Item.Name = this.Reader[(int)Field.ItemName].ToString();
            // 公费比率
            try
            {
                ecoRate.Rate.PubRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[(int)Field.PubRate].ToString());
            }
            catch
            {
                ecoRate.Rate.PubRate = 1m;
            }
            // 自费比率
            try
            {
                ecoRate.Rate.OwnRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[(int)Field.OwnRate].ToString());
            }
            catch
            {
                ecoRate.Rate.OwnRate = 1m;
            }
            // 自付比率
            try
            {
                ecoRate.Rate.PayRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[(int)Field.PayRate].ToString());
            }
            catch
            {
                ecoRate.Rate.PayRate = 1m;
            }
            // 优惠比率
            try
            {
                ecoRate.Rate.RebateRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[(int)Field.EcoRate].ToString());
            }
            catch
            {
                ecoRate.Rate.RebateRate = 1m;
            }
            // 减免比率
            try
            {
                ecoRate.Rate.DerateRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[(int)Field.ArrRate].ToString());
            }
            catch
            {
                ecoRate.Rate.DerateRate = 1m;
            }
            // 操作员
            ecoRate.CurrentOperator.ID = this.Reader[(int)Field.OperatorCode].ToString();
            // 操作时间
            try
            {
                ecoRate.OperateDateTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[(int)Field.OperateDate].ToString());
            }
            catch { };
        }
        #endregion
        #region 转换Object成Parameters数组
        /// <summary>
        /// 转换Object成Parameters数组
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 优惠比率类]
        /// </summary>
        /// <param name="ecoRate">优惠比率类</param>
        private void ChangeObjectToParameters(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate)
        {
            // 清空数组
            this.InitParameters();
            // 父级编码
            this.parameters[(int)Field.ParentCode] = ecoRate.Hospital.ID;
            // 本级编码
            this.parameters[(int)Field.CurrentCode] = ecoRate.Hospital.Name;
            // 比率类别编码
            this.parameters[(int)Field.EcoCode] = ecoRate.RateType.ID;
            // 项目类别编码
            this.parameters[(int)Field.TypeCode] = ecoRate.ItemType.ID;
            // 项目编码
            this.parameters[(int)Field.ItemCode] = ecoRate.Item.ID;
            // 公费比率
            this.parameters[(int)Field.PubRate] = ecoRate.Rate.PubRate.ToString();
            // 自费比率
            this.parameters[(int)Field.OwnRate] = ecoRate.Rate.OwnRate.ToString();
            // 自付比率
            this.parameters[(int)Field.PayRate] = ecoRate.Rate.PayRate.ToString();
            // 优惠比率
            this.parameters[(int)Field.EcoRate] = ecoRate.Rate.RebateRate.ToString();
            // 减免比率
            this.parameters[(int)Field.ArrRate] = ecoRate.Rate.DerateRate.ToString();
            // 操作员编码
            this.parameters[(int)Field.OperatorCode] = ecoRate.CurrentOperator.ID;
            // 操作时间
            this.parameters[(int)Field.OperateDate] = ecoRate.OperateDateTime.ToString();
        }
        #endregion
        #region 转换Reader成ArrayList
        /// <summary>
        /// 转换Reader成ArrayList
        /// [参数: ArrayList alEcoRate - 对象数组]
        /// </summary>
        /// <param name="alEcoRate">对象数组</param>
        private void ChangeReaderToList(ArrayList alEcoRate)
        {
            // 循环推进游标
            while (this.Reader.Read())
            {
                // 比率类
                Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate = new Models.Fee.Outpatient.EcoRate();

                // 转换Reader成对象
                this.ChangeReaderToObject(ecoRate);

                // 添加进数组
                alEcoRate.Add(ecoRate);
            }
        }
        #endregion

        #region 验证入参是否合法
        /// <summary>
        /// 验证入参是否合法
        /// [参数1: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 返回的各种比率]
        /// [参数2: bool boolForce - 是否强制使用项目类别约束,true - 使用项目类别约束,false - 不使用项目类别约束]
        /// [返回: bool,true-有错误不合法,false-没有错误]
        /// </summary>
        /// <param name="ecoRate">返回的各种比率</param>
        /// <param name="boolForce">是否强制使用项目类别约束,true - 使用项目类别约束,false - 不使用项目类别约束</param>
        /// <returns>true-有错误不合法,false-没有错误</returns>
        private bool ValidParameter(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate, bool boolForce)
        {
            //
            // 判断比率类别编码是否合法
            //
            if (ecoRate.RateType.ID.Equals("") || ecoRate.RateType.ID == null)
            {
                this.Err = "比率类别编码ecoRate.EcoCode不允许为空";
                return true;
            }
            //
            // 判断项目编码是否合法
            //
            if (ecoRate.Item.ID.Equals("") || ecoRate.Item.ID == null)
            {
                this.Err = "项目编码ecoRate.ItemCode不允许为空";
                return true;
            }
            //
            // 如果有项目类别约束,那么项目类别不允许为空
            //
            if (boolForce)
            {
                if (ecoRate.ItemType.Equals("") || ecoRate.ItemType == null)
                {
                    this.Err = "项目类别ecoRate.ItemType不允许为空";
                    return true;
                }
            }
            //
            // 合法
            //
            return false;
        }
        #endregion

        #region 根据优惠比率类别编码和项目编码获取各种比率
        /// <summary>
        /// 根据优惠比率类别编码和项目编码获取各种比率。
        /// (1)使用项目类别约束:如果获取项目不存在,那么直接返回。
        /// (2)不使用项目类别约束:必须设置ecoRate.ItemType,
        /// 程序首先按项目编码获取,
        /// 如果不存在,按最小费用编码获取,
        /// 如果再不存在，按大类编码获取。 
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 返回的各种比率]
        /// [参数: bool boolForce - 是否强制使用项目类别约束,true - 使用项目类别约束,false - 不使用项目类别约束]
        /// [入参: ecoRate.EcoCode - 比率类别编码]
        /// [入参: ecoRate.ItemCode - 项目编码、最小费用编码或大类编码]
        /// [入参: ecoRate.ItemType]
        /// [返回 : int,1-成功,-1-失败]
        /// </summary>
        /// <param name="ecoRate">返回的各种比率</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRate(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate, bool boolForce)
        {
            //
            // 验证合法性
            //
            if (this.ValidParameter(ecoRate, boolForce))
            {
                return -1;
            }
            //
            // 如果强制类别约束
            //
            if (boolForce)
            {
                switch (ecoRate.ItemType.ID)
                {
                    case "0":
                        // 按大类编码获取
                        this.intReturn = this.GetRateByClass(ecoRate);
                        break;
                    case "1":
                        // 按最小费用编码获取
                        this.intReturn = this.GetRateByMinFee(ecoRate);
                        break;
                    case "2":
                        // 按项目编码获取
                        this.intReturn = this.GetRateByItem(ecoRate);
                        break;
                }
                if (this.intReturn == -1)
                {
                    this.Err = "获取项目比率失败!" + "\n" + this.Err;
                    return -1;
                }
                //
                // 如果项目不存在,那么设置项目比率为100%
                //
                if (this.intReturn == 0)
                {
                    this.FullRate(ecoRate);
                }
                //
                // 成功返回1
                //
                return 1;
            }
            //
            // 如果没有类别约束,根据项目编码获取项目比率
            //
            this.intReturn = this.GetRateByItem(ecoRate);
            if (this.intReturn == -1)
            {
                this.Err = "获取项目比率失败!" + "\n" + this.Err;
                return -1;
            }
            else
                //
                // 如果获取项目不存在,那么根据上级最小费用代码获取比率
                //
                if (this.intReturn == 0)
                {
                    this.intReturn = this.GetRateByMinFee(ecoRate);
                    if (this.intReturn == -1)
                    {
                        this.Err = "获取项目比率失败!" + "\n" + this.Err;
                    }
                }
            //
            // 如果获取项目不存在,那么根据大类编码获取比率
            //
            if (this.intReturn == 0)
            {
                this.intReturn = this.GetRateByClass(ecoRate);
                if (this.intReturn == -1)
                {
                    this.Err = "获取项目比率失败!" + "\n" + this.Err;
                }
            }
            //
            // 如果获取项目不存在,那么设置各种费用比率为100%
            //
            if (this.intReturn == 0)
            {
                this.FullRate(ecoRate);
            }
            //
            // 成功返回1
            //
            return 1;
        }
        #endregion
        #region 根据优惠比率类别编码和项目编码(非大类编码和非最小费用编码)获取各种比率
        /// <summary>
        /// 根据优惠比率类别编码和项目编码(非大类编码和非最小费用编码)获取各种比率
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 返回的各种比率]
        /// [返回 : int,1-成功,0-不存在,-1-失败]
        /// </summary>
        /// <param name="ecoRate">返回的各种比率</param>
        /// <returns>1-成功,0-不存在,-1-失败</returns>
        public int GetRateByItem(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.GetRate.Select", ref this.SELECT);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句失败!";
                return -1;
            }
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.GetRateByItem.Where", ref this.WHERE);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句失败!";
                return -1;
            }
            this.SQL = this.SELECT + " " + this.WHERE;
            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, ecoRate.RateType.ID, ecoRate.Item.ID);
            }
            catch (Exception e)
            {
                this.Err = "格式化SQL语句失败!" + "\n" + e.Message;
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecQuery(this.SQL);
            if (this.intReturn == -1)
            {
                this.Err = "执行SQL语句失败!" + "\n" + this.Err;
                return -1;
            }
            //
            // 获取结果
            //
            if (this.Reader.Read())
            {
                this.ChangeReaderToObject(ecoRate);
                this.Reader.Close();
            }
            else
            {
                this.Reader.Close();
                return 0;
            }
            //
            // 成功返回1
            //
            return 1;
        }
        #endregion
        #region 根据优惠比率类别编码和最小费用编码(非大类编码和非项目编码)获取各种比率
        /// <summary>
        /// 根据优惠比率类别编码和最小费用编码(非大类编码和非项目编码)获取各种比率
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 返回的各种比率]
        /// [返回 : int,1-成功,0-不存在,-1-失败]
        /// </summary>
        /// <param name="ecoRate">返回的各种比率</param>
        /// <returns>1-成功,0-不存在,-1-失败</returns>
        public int GetRateByMinFee(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.GetRate.Select", ref this.SELECT);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句失败!";
                return -1;
            }
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.GetRateByMinFee.Where", ref this.WHERE);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句失败!";
                return -1;
            }
            this.SQL = this.SELECT + " " + this.WHERE;
            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, ecoRate.RateType.ID, ecoRate.Item.ID);
            }
            catch (Exception e)
            {
                this.Err = "格式化SQL语句失败!" + "\n" + e.Message;
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecQuery(this.SQL);
            if (this.intReturn == -1)
            {
                this.Err = "执行SQL语句失败!" + "\n" + this.Err;
                return -1;
            }
            //
            // 获取结果
            //
            if (this.Reader.Read())
            {
                this.ChangeReaderToObject(ecoRate);
                this.Reader.Close();
            }
            else
            {
                this.Reader.Close();
                return 0;
            }
            //
            // 成功返回1
            //
            return 1;
        }
        #endregion
        #region 根据优惠比率类别编码和大类编码(非最小费用编码和非项目编码)获取各种比率
        /// <summary>
        /// 根据优惠比率类别编码和大类编码(非最小费用编码和非项目编码)获取各种比率
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 返回的各种比率]
        /// [返回 : int,1-成功,0-不存在,-1-失败]
        /// </summary>
        /// <param name="ecoRate">返回的各种比率</param>
        /// <returns>1-成功,0-不存在,-1-失败</returns>
        public int GetRateByClass(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.GetRate.Select", ref this.SELECT);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句失败!";
                return -1;
            }
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.GetRateByClass.Where", ref this.WHERE);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句失败!";
                return -1;
            }
            this.SQL = this.SELECT + " " + this.WHERE;
            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, ecoRate.RateType.ID, ecoRate.Item.ID);
            }
            catch (Exception e)
            {
                this.Err = "格式化SQL语句失败!" + "\n" + e.Message;
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecQuery(this.SQL);
            if (this.intReturn == -1)
            {
                this.Err = "执行SQL语句失败!" + "\n" + this.Err;
                return -1;
            }
            //
            // 获取结果
            //
            if (this.Reader.Read())
            {
                this.ChangeReaderToObject(ecoRate);
                this.Reader.Close();
            }
            else
            {
                this.Reader.Close();
                return 0;
            }
            //
            // 成功返回1
            //
            return 1;
        }
        #endregion

        #region 设置各种比率为100%
        /// <summary>
        /// 设置各种比率为100%
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 返回的各种比率]
        /// </summary>
        /// <param name="ecoRate">返回的各种比率</param>
        private void FullRate(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate)
        {
            ecoRate.Rate.ArrearageRate = 1m;
            ecoRate.Rate.DerateRate = 1m;
            ecoRate.Rate.OwnRate = 1m;
            ecoRate.Rate.PayRate = 1m;
            ecoRate.Rate.PubRate = 1m;
            ecoRate.Rate.RebateRate = 1m;
        }
        #endregion

        #region 创建比率
        /// <summary>
        /// 创建比率
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 优惠比率类]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="ecoRate">优惠比率类</param>
        /// <returns>1-成功,-1-失败</returns>
        public int CreateEcoRate(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.CreateEcoRate", ref this.SQL);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句Neusoft.HISFC.BizLogic.Fee.EcoRate.CreateEcoRate失败!";
                return -1;
            }
            //
            // 转换对象为字符串数组
            //
            this.ChangeObjectToParameters(ecoRate);
            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL,
                                        ecoRate.RateType.ID,			// 比率类别编码
                                        ecoRate.ItemType.ID,			// 项目类别
                                        ecoRate.Item.ID,			// 项目编码
                                        ecoRate.Rate.PubRate,		// 公费比率
                                        ecoRate.Rate.OwnRate,		// 自费比率
                                        ecoRate.Rate.PayRate,		// 自付比率
                                        ecoRate.Rate.RebateRate,	// 优惠比率
                                        ecoRate.Rate.DerateRate,	// 减免比率
                                        ecoRate.CurrentOperator.ID,	// 操作员代码
                                        ecoRate.OperateDateTime		// 操作时间
                                        );
            }
            catch (Exception e)
            {
                this.Err = "格式化SQL语句失败!" + "\n" + e.Message;
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecNoQuery(this.SQL);
            if (this.intReturn < 1)
            {
                this.Err = "创建比率项目失败!" + "\n" + this.Err;
                return -1;
            }
            //
            // 成功返回1
            //
            return 1;
        }
        #endregion
        #region 删除比率
        /// <summary>
        /// 删除比率
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 优惠比率类]
        /// [返回: int,影响的行数]
        /// </summary>
        /// <param name="ecoRate">优惠比率类</param>
        /// <returns>影响的行数</returns>
        public int DeleteEcoRate(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.DeleteEcoRate.Delete", ref this.SELECT);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句Neusoft.HISFC.BizLogic.Fee.EcoRate.DeleteEcoRate.Delete失败!";
            }
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.DeleteEcoRate.Where", ref this.WHERE);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句Neusoft.HISFC.BizLogic.Fee.EcoRate.DeleteEcoRate.Where失败!";
            }
            this.SQL = this.SELECT + " " + this.WHERE;
            //
            // 转换对象为字符串数组
            //
            this.ChangeObjectToParameters(ecoRate);
            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL,
                                        this.parameters[(int)Field.EcoCode],		// 比率类别
                                        this.parameters[(int)Field.TypeCode],		// 项目类别
                                        this.parameters[(int)Field.ItemCode]		// 项目编码
                                        );
            }
            catch (Exception e)
            {
                this.Err = "格式化SQL语句失败!" + "\n" + e.Message;
                return -1;
            }
            //
            // 执行SQL语句
            //
            return this.ExecNoQuery(this.SQL);
        }
        #endregion
        #region 更新比率
        /// <summary>
        /// 更新比率
        /// [参数: Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate - 优惠比率类]
        /// [返回: int,-1-失败,否则-影响的行数]
        /// </summary>
        /// <param name="ecoRate">优惠比率类</param>
        /// <returns>int,-1-失败,否则-影响的行数</returns>
        public int UpdateEcoRate(Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.UpdateEcoRate.Update", ref this.SELECT);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句Neusoft.HISFC.BizLogic.Fee.EcoRate.UpdateEcoRate.Update失败!";
                return -1;
            }
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.DeleteEcoRate.Where", ref this.WHERE);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句Neusoft.HISFC.BizLogic.Fee.EcoRate.DeleteEcoRate.Where失败!";
                return -1;
            }
            this.SQL = this.SELECT + " " + this.WHERE;
            //
            // 转换对象为字符串数组
            //
            this.ChangeObjectToParameters(ecoRate);
            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL,
                                        ecoRate.RateType.ID,			// 比率类别编码
                                        ecoRate.ItemType.ID,			// 项目类别
                                        ecoRate.Item.ID,			// 项目编码
                                        ecoRate.Rate.PubRate,		// 公费比率
                                        ecoRate.Rate.OwnRate,		// 自费比率
                                        ecoRate.Rate.PayRate,		// 自付比率
                                        ecoRate.Rate.RebateRate,	// 优惠比率
                                        ecoRate.Rate.DerateRate,	// 减免比率
                                        ecoRate.CurrentOperator.ID,	// 操作员代码
                                        ecoRate.OperateDateTime		// 操作时间
                                        );
            }
            catch (Exception e)
            {
                this.Err = "格式化SQL语句失败!" + "\n" + e.Message;
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecNoQuery(this.SQL);
            if (this.intReturn == -1)
            {
                this.Err = "更新执行SQL语句失败!" + "\n" + this.Err;
                return -1;
            }
            //
            // 返回影响的行数
            //
            return this.intReturn;
        }
        #endregion

        #region 根据比率类别编码和项目类别,获取相应的明细
        /// <summary>
        /// 根据比率类别编码和项目类别,获取相应的明细
        /// [参数1: string ecoCode - 比率类别编码]
        /// [参数2: string typeCode - 项目类别编码]
        /// [参数3: ArrayList alEcoRate - 返回的所有大类明细]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="ecoCode">比率类别编码</param>
        /// <param name="typeCode">项目类别编码</param>
        /// <param name="alEcoRate">返回的所有大类明细</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetAllEcoRate(string ecoCode, string typeCode, ArrayList alEcoRate)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.GetRate.Select", ref this.SELECT);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句失败!";
                return -1;
            }
            //
            // 如果获取全部项目
            //
            if (typeCode.Equals("999"))
            {
                this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.GetAll.Where1", ref this.WHERE);
            }
            else
            {
                this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.EcoRate.GetAll.Where", ref this.WHERE);
            }
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句失败!";
                return -1;
            }
            this.SQL = this.SELECT + " " + this.WHERE;
            //
            // 格式化SQL语句
            //
            try
            {
                if (typeCode.Equals("999"))
                {
                    // 获取全部明细
                    this.SQL = string.Format(this.SQL, ecoCode);
                }
                else
                {
                    this.SQL = string.Format(this.SQL, ecoCode, typeCode);
                }
            }
            catch (Exception e)
            {
                this.Err = "格式化SQL语句失败!" + "\n" + e.Message;
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecQuery(this.SQL);
            if (this.intReturn == -1)
            {
                this.Err = "执行SQL语句失败!" + "\n" + this.Err;
                return -1;
            }
            //
            // 转换Reader成数组
            //
            this.ChangeReaderToList(alEcoRate);
            //
            // 成功返回1
            //
            return 1;
        }
        #endregion
        #region 根据比率编码获取所有大类明细
        /// <summary>
        /// 根据比率编码获取所有大类明细
        /// [参数1: string ecoCode - 比率类别编码]
        /// [参数2: ArrayList alEcoRate - 返回的明细数组]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="ecoCode">比率类别编码</param>
        /// <param name="alEcoRate">明细数组</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetAllClassEcoRate(string ecoCode, ArrayList alEcoRate)
        {
            return this.GetAllEcoRate(ecoCode, "0", alEcoRate);
        }
        #endregion
        #region 根据比率编码获取所有最小费用明细
        /// <summary>
        /// 根据比率编码获取所有最小费用明细
        /// [参数1: string ecoCode - 比率类别编码]
        /// [参数2: ArrayList alEcoRate - 返回的明细数组]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="ecoCode">比率类别编码</param>
        /// <param name="alEcoRate">明细数组</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetAllMinFeeEcoRate(string ecoCode, ArrayList alEcoRate)
        {
            return this.GetAllEcoRate(ecoCode, "1", alEcoRate);
        }
        #endregion
        #region 根据比率编码获取所有项目明细
        /// <summary>
        /// 根据比率编码获取所有项目明细
        /// [参数1: string ecoCode - 比率类别编码]
        /// [参数2: ArrayList alEcoRate - 返回的明细数组]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="ecoCode">比率类别编码</param>
        /// <param name="alEcoRate">明细数组</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetAllItemEcoRate(string ecoCode, ArrayList alEcoRate)
        {
            return this.GetAllEcoRate(ecoCode, "2", alEcoRate);
        }
        #endregion
        #region 获取所有明细
        /// <summary>
        /// 获取所有明细
        /// [参数: ArrayList alEcoRate - 比率对象数组]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="alEcoRate">比率对象数组</param>
        /// <returns></returns>
        public int GetAll(string ecoCode, ArrayList alEcoRate)
        {
            return this.GetAllEcoRate(ecoCode, "999", alEcoRate);
        }
        #endregion

        #region 获取可以开立的项目
        /// <summary>
        /// 获取可以开立的项目
        /// [参数: System.Data.DataSet dataSet - 返回的项目数据集]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="dataSet">返回的项目数据集</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetPermitItems(System.Data.DataSet dataSet)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.GetPermitItems", ref this.SELECT);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句Neusoft.HISFC.BizLogic.Fee.GetPermitItems失败!";
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecQuery(this.SELECT, ref dataSet);
            if (this.intReturn == -1)
            {
                this.Err = "执行SQL语句失败!" + "\n" + this.Err;
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 获取可以开立的项目
        /// [参数: System.Data.DataSet dataSet - 返回的项目数据集]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="dataSet">返回的项目数据集</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetPermitItemsWorkload(System.Data.DataSet dataSet)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.GetPermitItems.Workload", ref this.SELECT);
            if (this.intReturn == -1)
            {
                this.Err = "获取SQL语句Neusoft.HISFC.BizLogic.Fee.GetPermitItems失败!";
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecQuery(this.SELECT, ref dataSet);
            if (this.intReturn == -1)
            {
                this.Err = "执行SQL语句失败!" + "\n" + this.Err;
                return -1;
            }
            return 1;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.Models.Order
{
    /// <summary>
    /// [功能描述: 移动护士站医嘱执行单实体类]<br></br>
    /// [创建者: 柏松涛]<br></br>
    /// [创建时间: 2010-01-31/]<br></br>
    /// <说明>
    ///    类实现过程中的一些必要说明
    /// </说明>
    /// <修改记录>
    ///     <修改时间>本次修改时间</修改时间>
    ///     <修改内容>
    ///            addby xuewj 2010-10-23 PDA {D81BC4C8-FDD1-42ab-93A0-56049C99DF9D}
    ///     </修改内容>
    /// </修改记录>
    /// </summary>
    public class ExcBill : Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量

        private string execSqn;     //执行单流水号*
        private string inpatientNo; //患者住院流水号*
        private string barCode;     //条码号(*)
        private string exeState;    //执行状态
        private string exeType;     //执行类别(*)
        private DateTime bgTime;    //开始执行时间
        private string bgOper;      //开始执行操作员ID
        private DateTime endTime;   //结束执行时间
        private string endOper;     //结束执行操作员ID
        private string billType;    //执行单类别*
        private DateTime useTime;   //应执行时间*
        private string execName;    //执行单名称*
        private string useName;     //用法名称*
        private decimal qtyTot;         //数量*
        private string fqName;      //频次*
        private decimal doseOnce;    //每次用量*
        private string doseUnit;    //计量单位*
        private string bgName;      //开始执行操作员姓名
        private string endName;     //结束执行操作员姓名
        private string conFlag;     //是否接瓶：'0'接瓶'1'非接瓶
        private string mulFlag;     //是否多路：'0'多路'1'非多路
        private string workRemind;  //是否提醒：'0'提醒'1'不提醒
        private DateTime estTime;   //估计执行时间
        private string groupNo;     //组合序号

        #endregion

        #region 属性

        /// <summary>
        /// 执行单流水号
        /// </summary>
        public string ExecSqn
        {
            get { return execSqn; }
            set { execSqn = value; }
        }

        /// <summary>
        /// 患者住院流水号
        /// </summary>
        public string InpatientNo
        {
            get { return inpatientNo; }
            set { inpatientNo = value; }
        }

        /// <summary>
        /// 执行类别
        /// </summary>
        public string ExeType
        {
            get { return exeType; }
            set { exeType = value; }
        }

        /// <summary>
        /// 组合序号
        /// </summary>
        public string GroupNo
        {
            get { return groupNo; }
            set { groupNo = value; }
        }

        /// <summary>
        /// 条码号
        /// </summary>
        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }

        /// <summary>
        /// 执行单类别
        /// </summary>
        public string BillType
        {
            get { return billType; }
            set { billType = value; }
        }

        /// <summary>
        /// 应执行时间
        /// </summary>
        public DateTime UseTime
        {
            get { return useTime; }
            set { useTime = value; }
        }

        /// <summary>
        /// 执行单名称
        /// </summary>
        public string ExecName
        {
            get { return execName; }
            set { execName = value; }
        }

        /// <summary>
        /// 用法名称
        /// </summary>
        public string UseName
        {
            get { return useName; }
            set { useName = value; }
        }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal QtyTot
        {
            get { return qtyTot; }
            set { qtyTot = value; }
        }

        /// <summary>
        /// 频次
        /// </summary>
        public string FqName
        {
            get { return fqName; }
            set { fqName = value; }
        }

        /// <summary>
        /// 每次用量
        /// </summary>
        public decimal DoseOnce
        {
            get { return doseOnce; }
            set { doseOnce = value; }
        }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string DoseUnit
        {
            get { return doseUnit; }
            set { doseUnit = value; }
        }

        #region 暂不使用

        /// <summary>
        /// 开始执行时间
        /// </summary>
        //public DateTime BgTime
        //{
        //    get { return bgTime; }
        //    set { bgTime = value; }
        //}

        /// <summary>
        /// 开始执行操作员ID
        /// </summary>
        //public string BgOper
        //{
        //    get { return bgOper; }
        //    set { bgOper = value; }
        //}

        /// <summary>
        /// 结束执行时间
        /// </summary>
        //public DateTime EndTime
        //{
        //    get { return endTime; }
        //    set { endTime = value; }
        //}

        /// <summary>
        /// 结束执行操作员ID
        /// </summary>
        //public string EndOper
        //{
        //    get { return endOper; }
        //    set { endOper = value; }
        //}

        /// <summary>
        /// 开始执行操作员姓名
        /// </summary>
        //public string BgName
        //{
        //    get { return bgName; }
        //    set { bgName = value; }
        //}

        /// <summary>
        /// 结束执行操作员姓名
        /// </summary>
        //public string EndName
        //{
        //    get { return endName; }
        //    set { endName = value; }
        //}

        /// <summary>
        /// 是否接瓶：'0'接瓶'1'非接瓶
        /// </summary>
        //public string ConFlag
        //{
        //    get { return conFlag; }
        //    set { conFlag = value; }
        //}

        /// <summary>
        /// 是否多路：'0'多路'1'非多路
        /// </summary>
        //public string MulFlag
        //{
        //    get { return mulFlag; }
        //    set { mulFlag = value; }
        //}

        /// <summary>
        /// 是否提醒：'0'提醒'1'不提醒
        /// </summary>
        //public string WorkRemind
        //{
        //    get { return workRemind; }
        //    set { workRemind = value; }
        //}

        /// <summary>
        /// 估计执行时间
        /// </summary>
        //public DateTime EstTime
        //{
        //    get { return estTime; }
        //    set { estTime = value; }
        //}

        #endregion

        #endregion


        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new ExcBill Clone()
        {
            return base.Clone() as ExcBill;
        }

        #endregion
    }
}

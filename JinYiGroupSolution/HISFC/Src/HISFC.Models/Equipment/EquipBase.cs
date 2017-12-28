using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Equipment
{
    #region 设备帐目信息实体

    /// <summary>
    /// Company<br></br>
    /// [功能描述: 设备帐目信息实体（设备字典）]<br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2007-10-30]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class EquipBase : Neusoft.HISFC.Models.Base.Spell
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public EquipBase()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 设备所属科室
        /// </summary>
        private NeuObject dept = new NeuObject();

        /// <summary>
        /// 科目分类
        /// </summary>
        private Kind kind = new Kind();

        /// <summary>
        /// 规格
        /// </summary>
        private string specs;

        /// <summary>
        /// 单位
        /// </summary>
        private NeuObject unit = new NeuObject();

        /// <summary>
        /// 最新单价
        /// </summary>
        private decimal currPrice;

        /// <summary>
        /// 国标码
        /// </summary>
        private string nationCode;

        /// <summary>
        /// 设备大类管理类别1设备2配件3固定资产
        /// </summary>
        private NeuObject equType = new NeuObject();

        /// <summary>
        /// 卫生局设备编码
        /// </summary>
        private string leadCode;

        /// <summary>
        /// 是否需要登记
        /// </summary>
        private bool isReg;

        /// <summary>
        /// 是否折旧
        /// </summary>
        private bool isDep;

        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid;

        /// <summary>
        /// 折旧方式
        /// </summary>
        private NeuObject deType = new NeuObject();

        /// <summary>
        /// 折旧年限
        /// </summary>
        private decimal deYear;

        /// <summary>
        /// 是否计量
        /// </summary>
        private bool isGauge;

        /// <summary>
        /// 是否附加设备
        /// </summary>
        private bool isAppend;

        /// <summary>
        /// 经管设备类型
        /// </summary>
        private NeuObject chargeType = new NeuObject();

        /// <summary>
        /// 保管等级
        /// </summary>
        private NeuObject storClass = new NeuObject();

        /// <summary>
        /// 库存上限
        /// </summary>
        private long mostNum;

        /// <summary>
        /// 库存下限
        /// </summary>
        private long lowestNum;

        /// <summary>
        /// 顺序号
        /// </summary>
        private long orderCode;

        /// <summary>
        /// 品牌名称
        /// </summary>
        private string brandName;

        /// <summary>
        /// 英文名称
        /// </summary>
        private string englishName;

        /// <summary>
        /// 是否自制1是0否
        /// </summary>
        private bool isSelf;

        /// <summary>
        /// 计量仪器分类
        /// </summary>
        private NeuObject gaugeType = new NeuObject();

        /// <summary>
        /// 操作环境信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 设备所属科室
        /// </summary>
        public NeuObject Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        /// <summary>
        /// 科目分类
        /// </summary>
        public Kind Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specs
        {
            get { return specs; }
            set { specs = value; }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public NeuObject Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        /// <summary>
        /// 最新单价
        /// </summary>
        public decimal CurrPrice
        {
            get { return currPrice; }
            set { currPrice = value; }
        }

        /// <summary>
        /// 国标码
        /// </summary>
        public string NationCode
        {
            get { return nationCode; }
            set { nationCode = value; }
        }

        /// <summary>
        /// 设备大类管理类别1设备2配件3固定资产
        /// </summary>
        public NeuObject EquType
        {
            get { return equType; }
            set { equType = value; }
        }

        /// <summary>
        /// 卫生局设备编码
        /// </summary>
        public string LeadCode
        {
            get { return leadCode; }
            set { leadCode = value; }
        }

        /// <summary>
        /// 是否需要登记
        /// </summary>
        public bool IsReg
        {
            get { return isReg; }
            set { isReg = value; }
        }

        /// <summary>
        /// 是否折旧
        /// </summary>
        public bool IsDep
        {
            get { return isDep; }
            set { isDep = value; }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        /// <summary>
        /// 折旧方式
        /// </summary>
        public NeuObject DeType
        {
            get { return deType; }
            set { deType = value; }
        }

        /// <summary>
        /// 折旧年限
        /// </summary>
        public decimal DeYear
        {
            get { return deYear; }
            set { deYear = value; }
        }

        /// <summary>
        /// 是否计量
        /// </summary>
        public bool IsGauge
        {
            get { return isGauge; }
            set { isGauge = value; }
        }

        /// <summary>
        /// 是否附加设备
        /// </summary>
        public bool IsAppend
        {
            get { return isAppend; }
            set { isAppend = value; }
        }

        /// <summary>
        /// 经管设备类型
        /// </summary>
        public NeuObject ChargeType
        {
            get { return chargeType; }
            set { chargeType = value; }
        }

        /// <summary>
        /// 保管等级
        /// </summary>
        public NeuObject StorClass
        {
            get { return storClass; }
            set { storClass = value; }
        }

        /// <summary>
        /// 库存上限
        /// </summary>
        public long MostNum
        {
            get { return mostNum; }
            set { mostNum = value; }
        }

        /// <summary>
        /// 库存下限
        /// </summary>
        public long LowestNum
        {
            get { return lowestNum; }
            set { lowestNum = value; }
        }

        /// <summary>
        /// 顺序号
        /// </summary>
        public long OrderCode
        {
            get { return orderCode; }
            set { orderCode = value; }
        }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName
        {
            get { return brandName; }
            set { brandName = value; }
        }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName
        {
            get { return englishName; }
            set { englishName = value; }
        }

        /// <summary>
        /// 是否自制1是0否
        /// </summary>
        public bool IsSelf
        {
            get { return isSelf; }
            set { isSelf = value; }
        }

        /// <summary>
        /// 计量仪器分类
        /// </summary>
        public NeuObject GaugeType
        {
            get { return gaugeType; }
            set { gaugeType = value; }
        }

        /// <summary>
        /// 操作环境信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 函数克隆
        /// </summary>
        /// <returns>成功返回克隆后的EquipBase实体 失败返回null</returns>
        public new EquipBase Clone()
        {
            EquipBase equipBase = base.Clone() as EquipBase;

            equipBase.dept = this.dept.Clone();
            equipBase.kind = this.kind.Clone();
            equipBase.unit = this.unit.Clone();
            equipBase.equType = this.equType.Clone();
            equipBase.deType = this.deType.Clone();
            equipBase.chargeType = this.chargeType.Clone();
            equipBase.storClass = this.storClass.Clone();
            equipBase.gaugeType = this.gaugeType.Clone();
            equipBase.oper = this.oper.Clone();

            return equipBase;
        }

        #endregion
    }

    #endregion
}

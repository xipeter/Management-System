using System;

namespace Neusoft.HISFC.Models.Registration
{
    /// <summary>
    /// <br>RegLevel</br>
    /// <br>[功能描述: 排班实体]</br>
    /// <br>[创 建 者: 黄小卫]</br>
    /// <br>[创建时间: 2007-2-1]</br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class Schema
    {
        /// <summary>
        /// 
        /// </summary>
        public Schema()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 排班模板
        /// </summary>
        private SchemaTemplet templet = new SchemaTemplet();

        /// <summary>
        /// 出诊时间
        /// </summary>
        private DateTime seeDate = DateTime.MaxValue;

        /// <summary>
        /// 已挂号数
        /// </summary>
        private decimal regedQTY = 0m;

        /// <summary>
        /// 预约电话已挂
        /// </summary>
        private decimal telingQTY = 0m;

        /// <summary>
        /// 预约电话已确认数
        /// </summary>
        private decimal teledQTY = 0m;

        /// <summary>
        /// 特诊已挂
        /// </summary>
        private decimal spedQTY = 0m;

        /// <summary>
        /// 看诊序号
        /// </summary>
        private int seeNO = 0;

        /// <summary>
        /// 停诊人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment stop = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 模板id
        /// </summary>
        private string fromTempletID = string.Empty;

      
        #endregion

        #region 属性

        /// <summary>
        /// 排班信息
        /// </summary>
        public SchemaTemplet Templet
        {
            get { return this.templet; }
            set { templet = value; }
        }

        /// <summary>
        /// 出诊时间
        /// </summary>
        public DateTime SeeDate
        {
            get { return this.seeDate; }
            set { this.seeDate = value; }
        }

        /// <summary>
        /// 已挂数量
        /// </summary>
        public decimal RegedQTY
        {
            get { return this.regedQTY; }
            set { this.regedQTY = value; }
        }

        /// <summary>
        /// 电话已预约
        /// </summary>
        public decimal TelingQTY
        {
            get { return this.telingQTY; }
            set { this.telingQTY = value; }
        }

        /// <summary>
        /// 预约电话已取
        /// </summary>
        public decimal TeledQTY
        {
            get { return this.teledQTY; }
            set { this.teledQTY = value; }
        }

        /// <summary>
        /// 特诊已挂
        /// </summary>
        public decimal SpedQTY
        {
            get { return this.spedQTY; }
            set { this.spedQTY = value; }
        }

        /// <summary>
        /// 看诊序号
        /// </summary>
        public int SeeNO
        {
            get { return this.seeNO; }
            set { this.seeNO = value; }
        }

        /// <summary>
        /// 模板id
        /// </summary>
        public string FromTempletID
        {
            get { return fromTempletID; }
            set { fromTempletID = value; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public Schema Clone()
        {
            Schema obj = base.MemberwiseClone() as Schema;

            obj.Templet = this.Templet.Clone();            

            return obj;
        }
        #endregion

    }
}

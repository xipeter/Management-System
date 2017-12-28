/*----------------------------------------------------------------
            // Copyright (C) 沈阳东软软件股份有限公司
            // 版权所有。 
            //
            // 文件名：			HomeBedRate.cs
            // 文件功能描述：	家庭病床比例类
            //
            // 
            // 创建标识：		2006-5-16
            //
            // 修改标识：
            // 修改描述：
            //
            // 修改标识：
            // 修改描述：
//----------------------------------------------------------------*/

using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Fee.Outpatient
{
    /// <summary>
    /// 家庭病床比例类
    /// </summary>
    /// 
    [System.Serializable]
    public class EcoRate : Neusoft.FrameWork.Models.NeuObject
    {
        public EcoRate()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 医院级别编码
        /// [ID - 父级编码]
        /// [Name - 本级编码]
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject hospital = new NeuObject();
        /// <summary>
        /// 比率类别
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject rateType = new NeuObject();
        /// <summary>
        /// 项目类型
        /// [0 - 大类]
        /// [1 - 最小费用]
        /// [2 - 项目]
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject itemType = new NeuObject();
        /// <summary>
        /// 项目
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject item = new NeuObject();
        /// <summary>
        /// 优惠比率
        /// </summary>
        Neusoft.HISFC.Models.Base.FTRate rate = new Neusoft.HISFC.Models.Base.FTRate();
        /// <summary>
        /// 操作员
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject currentOperator = new NeuObject();
        /// <summary>
        /// 操作时间
        /// </summary>
        System.DateTime operateDateTime = DateTime.MinValue;

        /// <summary>
        /// 医院级别编码
        /// [ID - 父级编码]
        /// [Name - 本级编码]
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Hospital
        {
            get
            {
                return this.hospital;
            }
            set
            {
                this.hospital = value;
            }
        }
        /// <summary>
        /// 比率类型类型
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject RateType
        {
            get
            {
                return this.rateType;
            }
            set
            {
                this.rateType = value;
            }
        }
        /// <summary>
        /// 项目类型
        /// [0 - 大类]
        /// [1 - 最小费用]
        /// [2 - 项目]
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }
        /// <summary>
        /// 项目编码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }
        /// <summary>
        /// 各种优惠比率
        /// </summary>
        public Neusoft.HISFC.Models.Base.FTRate Rate
        {
            get
            {
                return this.rate;
            }
            set
            {
                this.rate = value;
            }
        }
        /// <summary>
        /// 当前操作员
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CurrentOperator
        {
            get
            {
                return this.currentOperator;
            }
            set
            {
                this.currentOperator = value;
            }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public System.DateTime OperateDateTime
        {
            get
            {
                return this.operateDateTime;
            }
            set
            {
                this.operateDateTime = value;
            }
        }


        public new EcoRate Clone()
        {
            EcoRate ecoRate = base.Clone() as EcoRate;
            ecoRate.CurrentOperator = this.CurrentOperator.Clone();
            ecoRate.Hospital = this.Hospital.Clone();
            ecoRate.Item = this.Item.Clone();
            ecoRate.ItemType = this.ItemType.Clone();
            ecoRate.RateType = this.RateType.Clone();
            return ecoRate;
        }
    }
}

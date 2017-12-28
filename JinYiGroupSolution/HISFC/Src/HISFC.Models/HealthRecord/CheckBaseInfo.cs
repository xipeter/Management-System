using System;


namespace Neusoft.HISFC.Models.HealthRecord
{
    /*----------------------------------------------------------------


	// Copyright (C) 2004 东软股份有限公司
	// 版权所有。
	//
	// 文件名：CheckBaseInfo.cs
	// 文件功能描述：检查实体
	//
	//
	// 创建标识:
	//
	// 修改标识：周雪松 20060420
	// 修改描述：
	//
	// 修改标识：
	// 修改描述：
	//----------------------------------------------------------------*/
    [Serializable]
    public class CheckBaseInfo : Neusoft.FrameWork.Models.NeuObject
    {
        public CheckBaseInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 指定备注(检查化验名称)
        /// </summary>
        /// <param name="memo"></param>
        public CheckBaseInfo(string memo)
        {
            this.Memo = memo;
        }

        #region 私有变量

        private string code;
        private int times;
        //private string memo;

        #endregion

        #region 属性

        /// <summary>
        /// 检查化验编码
        /// </summary>
        public string Code
        {
            get
            {
                return code;
            }
            set
            {

                code = value;
            }
        }

        /// <summary>
        /// 检查化验次数
        /// </summary>
        public int Times
        {
            get
            {
                return times;
            }
            set
            {

                times = value;
            }
        }

        #endregion

        #region 公有函数


        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new CheckBaseInfo Clone()
        {
            CheckBaseInfo CheckBaseInfoClone = base.MemberwiseClone() as CheckBaseInfo;

            return CheckBaseInfoClone;
        }
        #endregion
    }
}

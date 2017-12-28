using System;

namespace Neusoft.HISFC.Models.Board
{
	/// <summary>
	/// Item 的摘要说明。
	/// 膳食项目信息实体
	/// </summary>
    /// 
    [System.Serializable]
	public class Item:Neusoft.HISFC.Models.Base.Item
	{
        /// <summary>
        /// 执行科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject executeDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 执行科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ExecuteDept
        {
            get
            {
                return this.executeDept;
            }
            set
            {
                this.executeDept = value;
            }
        }


		public Item()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns>实体</returns>
        public new Item Clone()
        {
            Item item = base.Clone() as Item;
            item.executeDept = this.executeDept.Clone();

            return item;
        }
	}
}

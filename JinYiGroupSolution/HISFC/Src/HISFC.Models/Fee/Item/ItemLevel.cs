using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Fee.Item
{
    [Serializable]
    public class ItemLevel :  Neusoft.HISFC.Models.Base.Spell	
    {
        /// <summary>
        /// 层级医嘱
        /// {1EB2DEC4-C309-441f-BCCE-516DB219FD0E} 
        /// </summary>
        public ItemLevel() 
		{
			
		}


        #region 变量

        /// <summary>
        /// 使用范围 1门诊/2住院/0全部
        /// </summary>
        private int inOutType;

        /// <summary>
        /// 科室信息
        /// </summary>
        private NeuObject dept = new NeuObject();

        /// <summary>
        /// 医生信息
        /// </summary>
        private NeuObject onwer = new NeuObject();

        /// <summary>
        /// 是否共享，1是，0否
        /// </summary>
        private bool isShared;

        /// <summary>
        /// 是否已经释放资源 默认为false没有释放
        /// </summary>
        private bool alreadyDisposed = false;

        /// <summary>
        /// 父节点ID
        /// </summary>
        private string parentID;

        /// <summary>
        /// 大类分类
        /// </summary>
        private NeuObject levelClass = new NeuObject();

        private int sortID = 0;
        #endregion

        #region 属性

        /// <summary>
        /// 使用范围 1门诊/2住院/0全部 
        /// </summary>
        public int InOutType
        {
            get
            {
                return this.inOutType;
            }
            set
            {
                this.inOutType = value;
            }
        }

        /// <summary>
        /// 科室信息
        /// </summary>
        public NeuObject Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;
            }
        }

        /// <summary>
        /// 医生信息
        /// </summary>
        public NeuObject Owner
        {
            get
            {
                return this.onwer;
            }
            set
            {
                this.onwer = value;
            }
        }

        /// <summary>
        /// 是否共享，1是，0否
        /// </summary>
        public bool IsShared
        {
            get
            {
                return this.isShared;
            }
            set
            {
                this.isShared = value;
            }
        }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public string ParentID
        {
            get
            {
                return parentID;
            }
            set
            {
                parentID = value;
            }
        }

        /// <summary>
        /// 大类分类
        /// </summary>
        public NeuObject LevelClass
        {
            get { return levelClass; }
            set { levelClass = value; }
        }

        public int SortID
        {
            get { return this.sortID; }
            set { this.sortID = value; }
        }
        #endregion

        #region 方法

        #region 释放资源
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="isDisposing">是否释放 true是 false否</param>
        protected override void Dispose(bool isDisposing)
        {
            if (alreadyDisposed)
            {
                return;
            }

            if (this.dept != null)
            {
                this.dept.Dispose();
                this.dept = null;
            }
            if (this.onwer != null)
            {
                this.onwer.Dispose();
                this.onwer = null;
            }

            base.Dispose(isDisposing);

            alreadyDisposed = true;
        }
        #endregion

        #region 克隆
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象副本</returns>
        public new ItemLevel Clone()
        {
            ItemLevel itemLevel = base.Clone() as ItemLevel;

            itemLevel.Dept = this.Dept.Clone();
            itemLevel.Owner = this.Owner.Clone();
            itemLevel.LevelClass = this.LevelClass.Clone();

            return itemLevel;
        }
        #endregion

        #endregion
	}
}

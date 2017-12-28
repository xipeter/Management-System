using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// Company<br></br>
    /// [功能描述: 卡片变更实体类]<br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2007-11-21]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class ChangeMain : Neusoft.HISFC.Models.Base.Spell
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ChangeMain()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion 构造函数

        #region 变量

        #region 私有变量

        /// <summary>
        /// 旧卡片实体
        /// </summary>
        private Main oldMain = new Main();

        /// <summary>
        /// 新卡片实体
        /// </summary>
        private Main newMain = new Main();

        /// <summary>
        /// 经手人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment dealOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion 私有变量

        #region 保护变量
        #endregion 保护变量

        #region 公开变量
        #endregion 公开变量

        #endregion 变量

        #region 属性

        /// <summary>
        /// 旧卡片实体
        /// </summary>
        public Main OldMain
        {
            get { return oldMain; }
            set { oldMain = value; }
        }

        /// <summary>
        /// 新卡片实体
        /// </summary>
        public Main NewMain
        {
            get { return newMain; }
            set { newMain = value; }
        }

        /// <summary>
        /// 经手人
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment DealOper
        {
            get { return dealOper; }
            set { dealOper = value; }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }

        #endregion 属性

        #region 方法

        #region 资源释放
        #endregion 资源释放

        #region 克隆

        /// <summary>
        /// 函数克隆
        /// </summary>
        /// <returns>成功返回克隆后的DeMethod实体 失败返回null</returns>
        public new ChangeMain Clone()
        {
            ChangeMain changeMain = base.Clone() as ChangeMain;
            changeMain.OldMain = this.oldMain.Clone();
            changeMain.NewMain = this.newMain.Clone();
            changeMain.DealOper = this.dealOper.Clone();
            changeMain.Oper = this.oper.Clone();
            return changeMain;
        }

        #endregion 克隆

        #region 私有方法
        #endregion 私有方法

        #region 保护方法
        #endregion 保护方法

        #region 公开方法
        #endregion 公开方法

        #endregion 方法

        #region 接口实现
        #endregion 接口实现

	
    }
}

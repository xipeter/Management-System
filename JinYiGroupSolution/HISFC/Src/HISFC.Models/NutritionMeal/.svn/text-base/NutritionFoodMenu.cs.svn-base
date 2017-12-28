using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NutritionMeal
{
    /// <summary>
    /// Terminal<br></br>
    /// [功能描述: 菜谱维护]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-9]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// ID：菜谱编码，NAME：菜谱名称，MEMO：菜谱类型(0－普通膳食菜谱、1－治疗膳食菜谱)
    /// </summary>
    /// 
    [System.Serializable]
    public class NutritionFoodMenu : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid, Neusoft.HISFC.Models.Base.ISpell
    {
        /// <summary>
        /// 有效性
        /// </summary>
        private bool isValid;

        /// <summary>
        /// 菜谱金额
        /// </summary>
        private decimal money;

        /// <summary>
        /// 创建环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment createEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 取消环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment cancelEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

        private string spellCode;
        private string wbCode;
        private string userCode;


        #region IValid 成员

        /// <summary>
        /// 有效性
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        #endregion

        /// <summary>
        /// 菜谱金额
        /// </summary>
        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                this.money = value;
            }
        }

        /// <summary>
        /// 创建环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment CreateEnv
        {
            get
            {
                return this.createEnv;
            }
            set
            {
                this.createEnv = value;
            }
        }

        /// <summary>
        /// 取消环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment CancelEnv
        {
            get
            {
                return this.cancelEnv;
            }
            set
            {
                this.cancelEnv = value;
            }
        }

        public new NutritionFoodMenu Clone()
        {
            NutritionFoodMenu n = base.Clone() as NutritionFoodMenu;
            n.createEnv = this.createEnv.Clone();
            n.cancelEnv = this.cancelEnv.Clone();

            return n;
        }

        #region ISpell 成员

        /// <summary>
        /// 拼音码
        /// </summary>
        public string SpellCode
        {
            get
            {
                return this.spellCode;
            }
            set
            {
                this.spellCode = value;
            }
        }

        /// <summary>
        /// 五笔码
        /// </summary>
        public string WBCode
        {
            get
            {
                return this.wbCode;
            }
            set
            {
                this.wbCode = value;
            }
        }

        /// <summary>
        /// 自定义码
        /// </summary>
        public string UserCode
        {
            get
            {
                return this.userCode;
            }
            set
            {
                this.userCode = value;
            }
        }

        #endregion
    }
}

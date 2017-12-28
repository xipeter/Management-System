using System;
using System.Collections;
namespace Neusoft.HISFC.Models.EPR
{

   

    #region SNOMED
    /// <summary>
    /// SNOPMED
    /// </summary>
    [Serializable]
    public class SNOMED : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.ISpell, Neusoft.HISFC.Models.Base.ISort
    {
        public SNOMED()
        {

        }
        /// <summary>
        /// 父级编码
        /// </summary>
        public string ParentCode = "";
        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName = "";

        /// <summary>
        /// 正式编码
        /// </summary>
        public string SNOPCode = "";

        /// <summary>
        /// 诊断编码
        /// </summary>
        public string DiagnoseCode = "";

        #region ISpellCode 成员
        private string wbcode = "";
        public string WBCode
        {
            get
            {
                // TODO:  添加 SysClass.WB_Code getter 实现
                return wbcode;
            }
            set
            {
                // TODO:  添加 SysClass.WB_Code setter 实现
                wbcode = value;
            }
        }
        private string spellcode = "";
        public string SpellCode
        {
            get
            {
                // TODO:  添加 SysClass.Spell_Code getter 实现
                return spellcode;
            }
            set
            {
                // TODO:  添加 SysClass.Spell_Code setter 实现
                spellcode = value;
            }
        }
        private string usercode = "";
        public string UserCode
        {
            get
            {
                // TODO:  添加 SysClass.User_Code getter 实现
                return usercode;
            }
            set
            {
                // TODO:  添加 SysClass.User_Code setter 实现
                usercode = value;
            }
        }

        #endregion

        #region ISort 成员
        private int sortid = 0;
        public int SortID
        {
            get
            {
                // TODO:  添加 SysClass.SortID getter 实现
                return sortid;
            }
            set
            {
                // TODO:  添加 SysClass.SortID setter 实现
                sortid = value;
            }
        }

        #endregion


        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new SNOMED Clone()
        {
            return base.Clone() as SNOMED;
        }
    }
    #endregion

}
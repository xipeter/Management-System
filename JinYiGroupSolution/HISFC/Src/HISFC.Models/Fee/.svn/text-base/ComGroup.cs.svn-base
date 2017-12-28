using System;

namespace Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// ComGroup 的摘要说明。
	/// </summary>
    /// 
    [System.Serializable]
	public class ComGroup : Neusoft.FrameWork.Models.NeuObject 
	{
		public ComGroup()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
//		GROUP_ID     VARCHAR2(10)                   组套ID                
//		GROUP_NAME   VARCHAR2(50)  Y                组套名称              
//		SPELL_CODE   VARCHAR2(8)   Y                组套拼音码            
//		INPUT_CODE   VARCHAR2(8)   Y                组套助记吗            
//		GROUP_KIND   VARCHAR2(3)   Y                组套类型              
//		DEPT_CODE    VARCHAR2(4)   Y                组套科室              
//		SORT_ID      NUMBER        Y                显示顺序              
//		VALID_FLAG   VARCHAR2(1)   Y                有效标志，1有效/2无效 
//		REMARK       VARCHAR2(150) Y                组套备注              
//		OPER_CODE    VARCHAR2(6)   Y                操作员                
//		OPER_DATE    DATE          Y                操作时间      
		// id 组套ID
		//NAME 组套名称
		public string spellCode ;//组套拼音码
		public string WBCode ; //五笔码
		public string inputCode ;// 组套助记码
		public string groupKind ;//组套类型 
		public string deptCode; //组套科室
		public string deptName;//科室名
		public int    sortId ; //显示顺序
		public Neusoft.HISFC.Models.Base.EnumValidState ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;// 有效标志，1有效/0无效
		public string reMark ; //组套备注 
		public string operCode; //操作员
		public string operName;
		public System.DateTime operDate;
        //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
        /// <summary>
        /// 上级节点
        /// </summary>
        private string parentGroupID = string.Empty;

        /// <summary>
        ///上级节点{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
        /// </summary>
        public string ParentGroupID
        {
            get { return parentGroupID; }
            set { parentGroupID = value; }
        }
        
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new ComGroup Clone()
		{
			return this.MemberwiseClone() as ComGroup;
		}
	}
}

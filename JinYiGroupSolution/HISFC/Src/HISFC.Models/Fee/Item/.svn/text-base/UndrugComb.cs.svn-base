using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee.Item
{
	/// <summary>
	/// Item<br></br>
	/// [功能描述: 组合项目类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-15]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class UndrugComb : Undrug
	{
		#region 变量
		
		/// <summary>
		/// 序号
		/// </summary>
		private int sortID;

        /// <summary>
        /// 组合项目ID,Name
        /// </summary>
        private NeuObject package = new NeuObject();

		#endregion

        #region 属性

        /// <summary>
        /// 组合项目ID,Name
        /// </summary>
        public NeuObject Package 
        {
            get 
            {
                return this.package;
            }
            set 
            {
                this.package = value;
            }
        }

        #endregion

        #region 方法

        #region 克隆

        /// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new UndrugComb Clone()
		{
            UndrugComb undrugComb = base.Clone() as UndrugComb;

            undrugComb.Package = this.Package.Clone();

            return undrugComb;
		}

		#endregion

		#endregion
		
		#region 接口实现

		#region ISort 成员
		
		/// <summary>
		/// 序号
		/// </summary>
		public int SortID
		{
			get
			{
				return this.sortID;
			}
			set
			{
				this.sortID = value;
			}
		}

		#endregion

		#endregion

		#region 无用变量

		/// <summary>
		/// 系统类别  
		/// </summary>
		[Obsolete("作废,基类SysClass代替", true)]
		public string  sysClass; //系统类别  
		
		/// <summary>
		/// 拼音码  
		/// </summary>
		[Obsolete("作废,基类SpellCode代替", true)]
		public new string spellCode ; //  拼音码  
		/// <summary>
		/// 五笔
		/// </summary>
		[Obsolete("作废,基类WBCode代替", true)]
		public string wbCode  ; //五笔
		/// <summary>
		/// 输入码
		/// </summary>
		[Obsolete("作废,基类UserCode代替", true)]
		public string inputCode  ;//输入码
		/// <summary>
		/// 执行科室编码
		/// </summary>
		[Obsolete("作废,ExecDept代替", true)]
		public string deptCode ;//执行科室编码
		/// <summary>
		/// 顺序号
		/// </summary>
		[Obsolete("作废,SortID代替", true)]
		public int  sortId  ; //顺序号
		/// <summary>
		/// 确认标志 
		/// </summary>
		[Obsolete("作废,基类IsNeedConfirm代替", true)]
		public string confirmFlag ;//确认标志 
		/// <summary>
		/// 扩展标志
		/// </summary>
		[Obsolete("作废,基类SpecialFlag代替", true)]
		public string  ExtFlag; //扩展标志
		/// <summary>
		/// 扩展标志1
		/// </summary>
		[Obsolete("作废,基类SpecialFlag1代替", true)]
		public string Ext1Flag ;// 扩展标志1
		/// <summary>
		/// 病史及检查(开立检查申请单时使用) 
		/// </summary>
		public new string Mark1;//病史及检查(开立检查申请单时使用) 
		/// <summary>
		/// 检查要求(开立检查申请单时使用)  
		/// </summary>
		public new string Mark2;//检查要求(开立检查申请单时使用)  
		/// <summary>
		/// 注意事项(开立检查申请单时使用)
		/// </summary>
		public new string Mark3;//注意事项(开立检查申请单时使用)
		/// <summary>
		/// //检查申请单名称   
		/// </summary>
		public new string Mark4;
		/// <summary>
		/// 是否需要预约
		/// </summary>
		public new string NeedBespeak;

		#endregion
		
	}
}

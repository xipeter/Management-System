using System;

namespace Neusoft.FrameWork.Models
{
    /// <summary>
    /// NeuInfo<br></br>
    /// [功能描述: xml接口 信息结构 的摘要说明。]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public  class NeuInfo:Neusoft.FrameWork.Models.NeuObject 
	{
		public NeuInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        /// <summary>
        /// 信息类型
        /// </summary>
		public enum infoType
		{
			/// <summary>
			/// 参数
			/// </summary>
			Param,
			/// <summary>
			/// 全局变量
			/// </summary>
			Global,
			/// <summary>
			/// 临时变量
			/// </summary>
			Temp,
			/// <summary>
			///关联变量 
			/// </summary>
			Associate,
			/// <summary>
			/// 常量
			/// </summary>
			Const,
			/// <summary>
			/// 患者列表
			/// </summary>
			PatientList,
			/// <summary>
			/// 住院科室列表
			/// </summary>
			inDeptList,
			/// <summary>
			/// 门诊科室列表
			/// </summary>
			outDeptList,
			/// <summary>
			/// 列表
			/// </summary>
			List,
			/// <summary>
			/// 事件
			/// </summary>
			Event
		}
		/// <summary>
		/// 变量类型
		/// </summary>
		public infoType type=new infoType();
		/// <summary>
		/// sql条件语句
		/// </summary>
		public string Sql;
		/// <summary>
		/// 更新Sql
		/// </summary>
		public string UpdateSql;
		/// <summary>
		/// 数值
		/// </summary>
		public string value;
		/// <summary>
		/// 显示类型
		/// </summary>
		public string showType;
	}
}

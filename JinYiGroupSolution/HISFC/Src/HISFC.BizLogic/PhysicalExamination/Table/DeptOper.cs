using System;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table
{
	/// DeptOper <br></br>
	/// [功能描述: 体检科室与人员的关系表 Met_PE_Dept_Oper]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-17]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class DeptOper : Neusoft.HISFC.BizLogic.PhysicalExamination.Base.BaseFunction, Neusoft.HISFC.BizLogic.PhysicalExamination.Base.TableInterface 
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string [] fields = new string[12];

		#endregion

		#region 私有函数

		/// <summary>
		/// 清空字段数组
		/// </summary>
		private void ClearFields()
		{
			for (int i=0;i<=11;i++)
			{
				this.fields[i] = "";
			}
		}

		/// <summary>
		/// 转换Reader为对象
		/// </summary>
		/// <param name="archieve">体检科室与人员类</param>
		private void ReaderToObject(ref Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve archieve)
		{
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">体检科室与人员的关系类</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Insert(NeuObject record)
		{
			// 转换成体检科室与人员的关系类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptUserRelation relation = (Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptUserRelation)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( relation );

			// 获取SQL语句
			if (this.Sql.GetSql( "", ref this.SQL ) == -1)
			{
				return -1;
			}

			// 执行SQL语句
			if (this.ExecNoQuery( this.SQL, this.fields ) == -1)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 更新表
		/// </summary>
		/// <param name="record">体检科室与人员的关系类</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Update(NeuObject record)
		{
			// 转换成体检科室与人员的关系类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptUserRelation relation = (Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptUserRelation)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( relation );

			// 获取SQL语句
			if (this.Sql.GetSql( "", ref this.SQL ) == -1)
			{
				return -1;
			}

			// 执行SQL语句
			if (this.ExecNoQuery( this.SQL, this.fields ) == -1)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 基本查询
		/// </summary>
		/// <param name="recordList">体检科室与人员的关系类数组</param>
		/// <param name="whereCondition">SQL语句Where条件</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Select(ref ArrayList recordList, string whereCondition)
		{
			this.SQL = "";

			// 获取SQL语句
			if( this.Sql.GetSql("", ref this.SQL) ==  -1)
			{
				return -1;
			}

			// 添加SQL语句
			if (whereCondition != "")
			{
				this.SQL += " ";
				this.SQL += whereCondition;
			}
			
			// 执行SQL语句
			if( this.Sql.ExecQuery(this.SQL) == -1 )
			{
				return -1;
			}

			// 形成结果
			this.ReturnArray(ref recordList);

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 填充字段数组
		/// </summary>
		/// <param name="record">体检科室与人员的关系类</param>
		public void FillFields(NeuObject record)
		{
			this.ClearFields();
		}

		public void ReturnArray(ref ArrayList recordList)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}

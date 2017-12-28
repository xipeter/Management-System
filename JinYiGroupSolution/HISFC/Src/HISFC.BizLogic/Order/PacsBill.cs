using System;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Order
{
	/// <summary>
	/// 检查管理类
	/// written by zuowy 
	/// 2005-8-20
	/// </summary>
	public class PacsBill:Neusoft.FrameWork.Management.Database 
	{
		public PacsBill()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}	


		#region 增删改

		#endregion

		#region 作废
		/// <summary>
		/// 
		/// </summary>
		/// <param name="PacsBill"></param>
		/// <returns></returns>
		public int SavePacsBill(Neusoft.HISFC.Models.Order.PacsBill PacsBill)
		{
			return 0;
		}

		/// <summary>
		/// 开立新的检查单
		/// </summary>
		/// <param name="PacsBill"></param>
		/// <returns></returns>
		public int InsertPacsBill( Neusoft.HISFC.Models.Order.PacsBill PacsBill ) 
		{
			// 开立新的检查单
			// Management.Order.InsertPacsBill
			// 传入 12 传出 0
			string strSql = "";
			if(this.Sql.GetSql("Management.Order.InsertPacsBill",ref strSql) == -1) return -1;
			strSql = this.GetPacsBillInfo(strSql,PacsBill);

			if(strSql == null) 
			{
				this.Err = "格式化Sql语句时出错";
				this.WriteErr();
				return -1;	 
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 更新检查单信息
		/// </summary>
		/// <param name="pacsbill"></param>
		/// <returns></returns>
		public int UpdatePacsBill(Neusoft.HISFC.Models.Order.PacsBill pacsbill) 
		{			
			// 更新检查单
			// Management.Order.UpdatePacsBill
			// 传入 12 传出 0
			string strSql = "";
			if(this.Sql.GetSql("Management.Order.UpdatePacsBill",ref strSql) == -1) return -1;
			strSql = this.GetPacsBillInfo(strSql,pacsbill);

			if(strSql == null) 
			{ 
				this.Err = "格式化Sql语句时出错";
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 删除一条记录
		/// </summary>
		/// <param name="PacsID"></param>
		/// <returns></returns>
		public int DeletePacsBill(string PacsID) 
		{
			string strSql = "";
			if(this.Sql.GetSql("Management.Order.deletePacsBill",ref strSql) == -1)  
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			strSql = string.Format(strSql,PacsID);
			if(strSql == null)
				return -1;
			return this.ExecNoQuery(strSql);
		}
		#endregion

		#region 共有
		/// <summary>
		/// 保存时的判断
		/// </summary>
		/// <param name="pacsbill"></param>
		public int SetPacsBill(Neusoft.HISFC.Models.Order.PacsBill pacsbill) 
		{
			int Parm;
			Parm = this.UpdatePacsBill(pacsbill);
			if(Parm == 0)
				Parm = this.SavePacsBill(pacsbill);
			return Parm;
		}
		/// <summary>
		/// 查询检查单信息
		/// </summary>
		/// <param name="combNo"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Order.PacsBill  QueryPacsBill(string combNo) {
			# region 查询检查单信息
			// 查询检查单信息
			// Management.Order.SelectPacsBill
			// 传入 1 传出 11
			# endregion
			string strSql = "";
			ArrayList al = null;
			if(this.Sql.GetSql("Management.Order.QueryResourceByPacsBillNo",ref strSql) == -1) { 
				this.Err="没有找到Management.Order.QueryResourceByPacsBillNo字段!";
				return null;	 
			}
			strSql = string.Format(strSql,combNo);
			al = this.myPacsBillQuery(strSql);
			if(al == null || al.Count == 0) return null;
			return al[0] as Neusoft.HISFC.Models.Order.PacsBill;
		}
		
		/// <summary>
		/// 获得检查单信息
		/// </summary>
		/// <param name="pacsbill"></param>
		/// <returns></returns>
		public string  GetPacsBillInfo(string strSql,Neusoft.HISFC.Models.Order.PacsBill pacsbill) {
			# region "接口说明"
			// 0 检查单号       1 检查单名称      2 住院流水号 3 科室编码 
			// 4 科室名称       5 检查部位/目的   6 病史及特征
			// 7 实验室检查结果 8 注意事项        9 诊断 10 备注
			// 11 操作员        12 操作日期
			# endregion
			try{
				System.Object[] s = {pacsbill.ComboNO,//检查单号
										pacsbill.BillName,//检查单名称
										pacsbill.PatientNO,//住院流水号
										pacsbill.Dept.ID,//科室代码
										pacsbill.Dept.Name,//科室名称
										pacsbill.CheckOrder,//检查部位/目的
										pacsbill.IllHistory,//病史检查及特征
										pacsbill.LisResult,//检查结果
										pacsbill.Caution,//注意事项
										pacsbill.DiagName,//诊断
										pacsbill.Memo,//备注
										pacsbill.Oper.ID,//操作员
										pacsbill.Oper.OperTime,//操作日期
					                    pacsbill.User01,//申请医师代码
					                    pacsbill.User02,//申请医师姓名
					                    pacsbill.User03,//项目价格
					                    pacsbill.PatientNO.Substring(pacsbill.PatientNO.Length - 7)//接口
									};
				string myErr = "";
				if(Neusoft.FrameWork.Public.String.CheckObject(out myErr,s) == -1) {
					this.Err = myErr;
					this.WriteErr();
					return null;	 
				}
				strSql = string.Format(strSql,s);
			}
			catch(Exception ex){
				this.Err="付数值时候出错！"+ex.Message;
				this.WriteErr();
				return null;
			}
			return  strSql;
		}

		#endregion

		#region 私有
		/// <summary>
		/// 获得检查单信息实体
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		private ArrayList  myPacsBillQuery(string strSql) 
		{
			ArrayList al = new ArrayList();

			if(this.ExecQuery(strSql) == -1) return null;
			Neusoft.HISFC.Models.Order.PacsBill pacsbill = new Neusoft.HISFC.Models.Order.PacsBill();
			try{
				while(this.Reader.Read()) {
					try {
						pacsbill.ComboNO = this.Reader[0].ToString();//检查单号
						pacsbill.BillName = this.Reader[1].ToString();//检查单名称
						pacsbill.PatientNO = this.Reader[2].ToString();//住院流水号
						pacsbill.Dept.Name = this.Reader[3].ToString();//科室名称
						pacsbill.CheckOrder = this.Reader[4].ToString();//检查部位/目的
						pacsbill.IllHistory = this.Reader[5].ToString();//病史检查及特征
						pacsbill.LisResult = this.Reader[6].ToString();//检查结果
						pacsbill.Caution = this.Reader[7].ToString();//注意事项
						pacsbill.DiagName = this.Reader[8].ToString();//诊断
						pacsbill.Memo = this.Reader[9].ToString();//备注
						pacsbill.Oper.ID = this.Reader[10].ToString();//操作员
						pacsbill.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11].ToString());//操作日期
					}
					catch(Exception ex) {
						this.Err="获得检查单信息出错！"+ex.Message;
						this.WriteErr();
						return null;	   
					}
					al.Add(pacsbill);
				}
			}
			catch(Exception ex){
				this.Err="获得检查单信息出错！"+ex.Message;
				this.WriteErr();
				return null;
			}
			this.Reader.Close();
			return al;
		}
		#endregion
	}
}

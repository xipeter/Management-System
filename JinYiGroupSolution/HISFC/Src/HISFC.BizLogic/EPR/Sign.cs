using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
	/// <summary>
	/// Sign 的摘要说明。
	/// 质量控制
	/// </summary>
	public class Sign:Neusoft.FrameWork.Management.Database 
	{
		/// <summary>
		/// 质量控制业务层
		/// </summary>
		public Sign()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		

		#region 签名操作
		/// <summary>
		/// 插入一条文件信息
		/// </summary>
		/// <returns></returns>
		public int InsertSign(Neusoft.FrameWork.Models.NeuObject obj)
		{
//			if(this.IsHaveSameSign (obj.ID) ==true)return 0;

			string strSql = "";
			if(this.Sql.GetSql("EPR.Sign.InsertSign",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,obj.ID ,obj.Name ,obj.Memo, obj.User01, obj.User02, obj.User03);
			}
			catch(Exception ex)
			{
				this.Err = "错误的参数！\n"+ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
		/// <summary>
		/// 插入一条文件信息
		/// </summary>
		/// <returns></returns>
		public int UpdateSignBackGround(string id, byte[] img)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.Sign.UpdateSignBackGround",ref strSql)==-1) return -1;
			strSql = string.Format(strSql, id);

			return this.InputBlob(strSql, img);
		}
		
		/// <summary>
		/// 插入一条文件信息
		/// </summary>
		/// <returns></returns>
		public int DeleteSign(string id)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.Sign.DeleteSign",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,id);
		}
		
		/// <summary>
		/// 插入一条文件信息
		/// </summary>
		/// <returns></returns>
		public int UpdateSign(Neusoft.FrameWork.Models.NeuObject obj)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.Sign.UpdateSign",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,obj.ID ,obj.Name ,obj.Memo, obj.User01, obj.User02, obj.User03);
			}
			catch(Exception ex)
			{
				this.Err = "错误的参数！\n"+ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		

//		/// <summary>
//		/// 是否有相同的病历文件
//		/// </summary>
//		/// <param name="id"></param>
//		/// <returns></returns>
//		public bool IsHaveSameSign (string id)
//		{
//			string strSql = "";
//			if(this.Sql.GetSql("EPR.Sign.IsHaveSameSign",ref strSql)==-1) return false;
//			if(this.ExecQuery(strSql,id)==-1) return false;
//			if(this.Reader.HasRows) return true;
//			return false;
//		}

//		/// <summary>
//		/// 获得文件质控数据
//		/// </summary>
//		/// <param name="ID"></param>
//		/// <returns></returns>
//		public Neusoft.FrameWork.Models.neuObject  GetSign(string ID)
//		{
//			string strSql = "";
//			if(this.Sql.GetSql("EPR.Sign.GetSign.1",ref strSql)==-1) return null;
//			strSql = string.Format(strSql,ID);
//			ArrayList al = this.myGetSign(strSql);
//			if(al == null || al.Count<=0) return null;
//			return al[0] as Neusoft.FrameWork.Models.neuObject ;
//		}

		/// <summary>
		/// 获得质量控制信息-查询可用的病历信息
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public Neusoft.FrameWork.Models.NeuObject GetSign(string ID)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.Sign.GetSign",ref strSql)==-1) return null;
			strSql = string.Format(strSql,ID);
			ArrayList al =  this.myGetSign(strSql);
			if(al ==null || al.Count == 0) return null;
			return al[0] as Neusoft.FrameWork.Models.NeuObject;
		}

		public byte[] GetSignBackGround(string ID)
		{
			string strSql = "";

			if(this.Sql.GetSql("EPR.Sign.GetSignBackGround", ref strSql) == -1) return null;
			strSql = string.Format(strSql, ID);
			return this.OutputBlob(strSql);
		} 
		
		/// <summary>
		/// 获得质量控制信息-查询可用的病历信息
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public ArrayList GetSignList()
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.Sign.GetSignList",ref strSql)==-1) return null;
			return this.myGetSign(strSql);
		}
		/// <summary>
		/// 根据 条件 查询文件列表
		/// </summary>
		/// <param name="strWhere"></param>
		/// <returns></returns>
		public ArrayList GetSignBySqlWhere(string strWhere)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.Sign.GetSign",ref strSql)==-1) return null;
			strSql = strSql +" "+strWhere;
			return this.myGetSign(strSql);
		}

		
		#region "私有"
		private ArrayList myGetSign(string sql)
		{
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				Neusoft.FrameWork.Models.NeuObject  sign = new Neusoft.FrameWork.Models.NeuObject();
				sign.ID = this.Reader[0].ToString();
				sign.Name = this.Reader[1].ToString();
				sign.Memo = this.Reader[2].ToString();
				sign.User01 = this.Reader[3].ToString();
				sign.User02 = this.Reader[4].ToString();
				sign.User03 = this.Reader[5].ToString();
				al.Add(sign);
			}
			this.Reader.Close();
			return al;
		}

		/// <summary>
		/// 保存人员属性变动数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="Permission">权限实体</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int SetSign(Neusoft.FrameWork.Models.NeuObject sign, byte[] img) 
		{
			int param;
			//执行更新操作
			param = UpdateSign(sign);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (param == 0 || param == -1) 
			{
				param = InsertSign(sign);
			}
			if(param == -1) return -1;
			param = UpdateSignBackGround(sign.ID, img);
			return param;
		}
		#endregion
		#endregion

		
	}
}

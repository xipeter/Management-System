using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
	/// <summary>
	/// QCScoreSet 的摘要说明。
	/// 质量控制评价标准
	/// </summary>
	public class QCScore:Neusoft.FrameWork.Management.Database 
	{
		/// <summary>
		/// 质量控制评价标准业务层
		/// </summary>
		public QCScore()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		

		#region 质控评分设置
		/// <summary>
		/// 插入一条评价标准
		/// </summary>
		/// <returns></returns>
		public int InsertQCScoreSet(Neusoft.HISFC.Models.EPR.QCScore  obj)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QCScoreSet.InsertQCScoreSet",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,obj.ID ,obj.Name ,obj.Type,obj.Memo, obj.MiniScore, obj.TotalScore, obj.User02);
			}
			catch(Exception ex)
			{
				this.Err = "错误的参数！\n"+ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
		/// <summary>
		/// 删除一条评价标准
		/// </summary>
		/// <returns></returns>
		public int DeleteQCScoreSet(string id)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QCScoreSet.DeleteQCScoreSet",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,id);
		}
		
		/// <summary>
		/// 更新一条评价标准
		/// </summary>
		/// <returns></returns>
		public int UpdateQCScoreSet(Neusoft.HISFC.Models.EPR.QCScore obj)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QCScoreSet.UpdateQCScoreSet",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,obj.ID ,obj.Name, obj.Type ,obj.Memo, obj.MiniScore, obj.TotalScore, obj.User02);
			}
			catch(Exception ex)
			{
				this.Err = "错误的参数！\n"+ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新评价标准项目总分值
		/// </summary>
		/// <returns></returns>
		public int UpdateQCScoreSetTypeTotalScore(Neusoft.HISFC.Models.EPR.QCScore obj)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QCScoreSet.UpdateQCScoreSetTypeTotalScore",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql, obj.Type, obj.TotalScore);
			}
			catch(Exception ex)
			{
				this.Err = "错误的参数！\n"+ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 获得质量控制信息评价标准-根据ID查询评价标准
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.EPR.QCScore GetQCScoreSet(string ID)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QCScoreSet.GetQCScoreSet",ref strSql)==-1) return null;
			strSql = string.Format(strSql,ID);
			ArrayList al =  this.myGetQCScoreSet(strSql);
			if(al ==null || al.Count == 0) return null;
			return al[0] as Neusoft.HISFC.Models.EPR.QCScore;
		}

		/// <summary>
		/// 获得质量控制信息评价标准-查询所有评价标准
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public ArrayList GetQCScoreSetList()
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QCScoreSet.GetQCScoreSetList",ref strSql)==-1) return null;
			return this.myGetQCScoreSet(strSql);
		}

//		/// <summary>
//		/// 获得质量控制信息评价标准-查询所有评价标准
//		/// </summary>
//		/// <param name="inpatientNo"></param>
//		/// <param name="ID"></param>
//		/// <returns></returns>
//		public ArrayList GetQCScoreSetTypeList()
//		{
//			string strSql = "";
//			if(this.Sql.GetSql("EPR.QCScoreSet.GetQCScoreSetTypeList",ref strSql)==-1) return null;
//			return this.myGetQCScoreSetTypeList(strSql);
//		}
//		
		#region "私有"
		private ArrayList myGetQCScoreSet(string sql)
		{
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				Neusoft.HISFC.Models.EPR.QCScore  qcScoreSet = new Neusoft.HISFC.Models.EPR.QCScore ();
				qcScoreSet.ID = this.Reader[0].ToString();
				qcScoreSet.Name = this.Reader[1].ToString();
				qcScoreSet.Type = this.Reader[2].ToString();
				qcScoreSet.Memo = this.Reader[3].ToString();
				qcScoreSet.MiniScore = this.Reader[4].ToString();
				qcScoreSet.TotalScore = this.Reader[5].ToString();
				qcScoreSet.User02 = this.Reader[6].ToString();
				qcScoreSet.User03 = this.Reader[7].ToString();
				al.Add(qcScoreSet);
			}
			this.Reader.Close();
			return al;
		}

//		private ArrayList myGetQCScoreSetTypeList(string sql)
//		{
//			if(this.ExecQuery(sql)==-1) return null;
//			ArrayList al = new ArrayList();
//			while(this.Reader.Read())
//			{
//				Neusoft.FrameWork.Models.NeuObject qcScoreSetType = new Neusoft.FrameWork.Models.NeuObject();
//				qcScoreSetType.ID = this.Reader[0].ToString();
//				qcScoreSetType.User01 = this.Reader[1].ToString();
//				al.Add(qcScoreSetType);
//			}
//			this.Reader.Close();
//			return al;
//		}

		/// <summary>
		/// 保存评价标准变动数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="qcScoreSet">评价标准</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int SetQCScoreSet(Neusoft.HISFC.Models.EPR.QCScore qcScoreSet) 
		{
			int param;
			//执行更新操作
			param = UpdateQCScoreSet(qcScoreSet);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (param == 0 || param == -1) 
			{
				param = InsertQCScoreSet(qcScoreSet);
			}

			param = this.UpdateQCScoreSetTypeTotalScore(qcScoreSet);
			return param;
		}
		#endregion
		#endregion

		#region 病历评分
		/// <summary>
		/// 插入一条评价标准
		/// </summary>
		/// <returns></returns>
		public int InsertQCScore(Neusoft.HISFC.Models.EPR.QCScore  obj)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.QCScore.InsertScore",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,obj.ID ,obj.PatientInfo.ID,obj.PatientInfo.Name,obj.Name ,obj.MiniScore,obj.User01,obj.Memo,this.Operator.ID);
			}
			catch(Exception ex)
			{
				this.Err = "错误的参数！\n"+ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
		/// <summary>
		/// 删除一条评价标准
		/// </summary>
		/// <returns></returns>
		public int DeleteQCScore(string id,string inpatientNo)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.QCDeleteScore",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,id,inpatientNo);
		}
		
		/// <summary>
		/// 删除患者评分
		/// </summary>
		/// <returns></returns>
		public int DeleteQCScore(string inpatientNo)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.QCDeleteScoreByInpatientNo",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,inpatientNo);
		}

		/// <summary>
		/// 更新一条评价标准
		/// </summary>
		/// <returns></returns>
		public int UpdateQCScore(Neusoft.HISFC.Models.EPR.QCScore obj)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.QCScore.UpdateScore",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,obj.ID ,obj.PatientInfo.ID,obj.PatientInfo.Name,obj.Name ,obj.MiniScore,obj.User01,obj.Memo,this.Operator.ID);
			}
			catch(Exception ex)
			{
				this.Err = "错误的参数！\n"+ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

//		/// <summary>
//		/// 获得质量控制信息评价标准-根据ID查询评价标准
//		/// </summary>
//		/// <param name="ID"></param>
//		/// <returns></returns>
//		public Neusoft.HISFC.Models.EPR.QCScore GetQCScore(string ID)
//		{
//			string strSql = "";
//			if(this.Sql.GetSql("EPR.QCScoreSet.GetQCScoreSet",ref strSql)==-1) return null;
//			strSql = string.Format(strSql,ID);
//			ArrayList al =  this.myGetQCScoreSet(strSql);
//			if(al ==null || al.Count == 0) return null;
//			return al[0] as Neusoft.HISFC.Models.EPR.QCScore;
//		}

		/// <summary>
		/// 获得质量控制信息评价标准-查询所有评价标准
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public ArrayList GetQCScoreList(string inpatientNo)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.QCScore.SelectAllScore",ref strSql)==-1) return null;
			try
			{
				strSql = string.Format(strSql,inpatientNo);
			}
			catch{this.Err = "EPR.QC.QCScore.SelectAllScore 参数不对！";return null;}
			return this.myGetQCScoreSet(strSql);
		}

		#region "私有"
		private ArrayList myGetQCScoreList(string sql)
		{
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				Neusoft.HISFC.Models.EPR.QCScore  obj = new Neusoft.HISFC.Models.EPR.QCScore ();
				obj.ID = this.Reader[0].ToString();
				obj.PatientInfo.ID = this.Reader[0].ToString();
				obj.PatientInfo.Name = this.Reader[0].ToString();
				obj.Name = this.Reader[0].ToString();
				obj.MiniScore = this.Reader[0].ToString();
				obj.User01 = this.Reader[0].ToString();
				obj.Memo = this.Reader[0].ToString();
				al.Add(obj);
			}
			this.Reader.Close();
			return al;
		}
		#endregion
	
		#endregion


		
	}
}


//namespace Neusoft.HISFC.Models.EPR
//{
//    /// <summary>
//    /// QCScoreSet 的摘要说明。
//    /// </summary>
//    public class QCScore:Neusoft.FrameWork.Models.NeuObject 
//    {
//        public QCScore()
//        {
//            //
//            // TODO: 在此处添加构造函数逻辑
//            //
//        }
//        private Neusoft.HISFC.Models.RADT.PatientInfo myPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
//        /// <summary>
//        /// 患者信息
//        /// </summary>
//        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
//        {
//            get
//            {
//                return this.myPatientInfo;
//            }
//            set
//            {
//                this.myPatientInfo = value;
//            }
//        }
//        private string type;
//        /// <summary>
//        /// 项目类别
//        /// </summary>
//        public string Type
//        {
//            get
//            {
//                return this.type;
//            }
//            set
//            {
//                this.type = value;
//            }
//        }

//        private string totalScore;
//        /// <summary>
//        /// 项目类别总分值
//        /// </summary>
//        public string TotalScore
//        {
//            get
//            {
//                return this.totalScore;
//            }
//            set
//            {
//                this.totalScore = value;
//            }
//        }
//        private string miniScore;
//        /// <summary>
//        /// 最小分值
//        /// </summary>
//        public string MiniScore
//        {
//            get
//            {
//                return this.miniScore;
//            }
//            set
//            {
//                this.miniScore = value;
//            }
//        }
//        /// <summary>
//        /// 克隆
//        /// </summary>
//        /// <returns></returns>
//        public QCScore Clone()
//        {
//            QCScore score = base.Clone() as QCScore;
//            score.PatientInfo = this.PatientInfo.Clone();
//            return score;
//        }
//    }
//}


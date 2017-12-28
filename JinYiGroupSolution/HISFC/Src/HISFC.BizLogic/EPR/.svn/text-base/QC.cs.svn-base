using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
	/// <summary>
	/// QC 的摘要说明。
	/// 质量控制
	/// </summary>
	public class QC:Neusoft.FrameWork.Management.Database 
	{
		/// <summary>
		/// 质量控制业务层
		/// </summary>
		public QC()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		

		#region 质量控制数据操作
		/// <summary>
		/// 插入一条文件信息
		/// </summary>
		/// <returns></returns>
		public int InsertQCData(Neusoft.HISFC.Models.EPR.QC qc)
		{
			if(this.IsHaveSameEMRFile(qc.ID,qc.Index) ==true)return 0;

			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.InsertQCData",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,qc.ID ,qc.PatientInfo.ID ,qc.PatientInfo.Name,qc.PatientInfo.PVisit.PatientLocation.Dept.ID,qc.Index,qc.Name,this.Operator.ID );
		}
		
		/// <summary>
		///  更新文件状态
		/// </summary>
		/// <param name="id"></param>
		/// <param name="State"></param>
		/// <returns></returns>
		public int UpdateQCDataState(string id,int State)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.UpdateQCDataState",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,id,State.ToString(),this.Operator.ID);
		}

		/// <summary>
		///  根据当前已经有的病历判断是否添加的病历页可以重复添加
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="EMRName"></param>
		/// <param name="isOnly"></param>
		/// <returns></returns>
		public bool IsCanAddByQC(string  inpatientNo,string EMRName,bool isOnly)
		{
			if(isOnly==false) return true;
			return this.IsHaveSameEMRName(inpatientNo,EMRName);
		}
		

		/// <summary>
		/// 查找是否游戏相同的指控名称的病历文件
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="EMRName"></param>
		/// <returns></returns>
		public bool IsHaveSameEMRName(string inpatientNo,string EMRName)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.IsHaveSameEMRName",ref strSql)==-1) return false;
			if(this.ExecQuery(strSql,inpatientNo,EMRName)==-1) return false;
			if(this.Reader.Read()) return true;
			return false;
		}

		/// <summary>
		/// 是否有相同的病历文件
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool IsHaveSameEMRFile(string id,string index)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.IsHaveSameEMRFile",ref strSql)==-1) return false;
			if(this.ExecQuery(strSql,id,index)==-1) return false;
			if(this.Reader.Read()) return true;
			return false;
		}

		/// <summary>
		/// 获得文件质控数据
		/// </summary>
		/// <param name="fileID"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.EPR.QC GetQCData(string fileID)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.GetQCData.1",ref strSql)==-1) return null;
			strSql = string.Format(strSql,fileID);
			ArrayList al = this.myGetQCData(strSql);
			if(al == null || al.Count<=0) return null;
			return al[0] as Neusoft.HISFC.Models.EPR.QC;
		}

		/// <summary>
		/// 签名
		/// </summary>
		/// <param name="fileID"></param>
		/// <returns></returns>
		public int SignEmrPage(string fileID)
		{
			Neusoft.HISFC.Models.EPR.QC obj = this.GetQCData(fileID);
			if(obj == null) 
			{
				this.Err = "没有找到文件记录，请先保存病历页然后再签名操作！";
				return -1;
			}
			string s ="";
			string sTip = "文件已经{0},不能进行签名操作!";
			if(obj.QCData.State.ToString() =="0") //新建立
			{
				return this.UpdateQCDataState(fileID,1);
			}
			else if(obj.QCData.State.ToString() =="1")
			{
				s ="签名";
			}
			else if(obj.QCData.State.ToString() =="2")
			{
				s ="封存";
			}
			else if(obj.QCData.State.ToString() =="3")
			{
				s ="删除";
			}
			sTip = string.Format(sTip,s);
			this.Err = sTip;
			return -1;
		}
        /// <summary>
        /// 签名更新
        /// 主要为病程记录 
        /// 更新 签名人，签名日期，上级签名人
        /// </summary>
        /// <param name="id"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public int SignEmrPage(Neusoft.HISFC.Models.EPR.QC qc)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.UpdateQCData", ref strSql) == -1) return -1;
            return this.ExecNoQuery(strSql, qc.ID, qc.Index, qc.QCData.Saver.ID, qc.QCData.Saver.Memo, qc.QCData.Sealer.ID);
        }
        /// <summary>
        /// 是否签名
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public bool IsSign(string fileID)
        {
            Neusoft.HISFC.Models.EPR.QC obj = this.GetQCData(fileID);
            if (obj == null)
            {
                return false;
            }
            if (obj.QCData.State.ToString() == "0") //新建立
            {
                return false;
            }
            else
            {
                return true;
            }

        }
		/// <summary>
		/// 封存
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <returns></returns>
		public int Seal(string inpatientNo)
		{
			if(this.IsSeal(inpatientNo) )
			{
				this.Err = "病历已经封存，不能执行封存操作！";
				return -1;
			}
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.Update.2",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,inpatientNo,this.Operator.ID );
		}
		/// <summary>
		/// 是否封存
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <returns></returns>
		public bool IsSeal(string inpatientNo)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.IsSeal",ref strSql)==-1) return false;
			if(this.ExecQuery(strSql,inpatientNo)==-1) return false;
            bool b = this.Reader.Read();
            this.Reader.Close();
            return b;
		}
		/// <summary>
		/// 解封--恢复到签名操作
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <returns></returns>
		public int UnSeal(string inpatientNo)
		{
			if(this.IsSeal(inpatientNo)==false )
			{
				this.Err = "病历没有封存，不能执行解封操作！";
				return -1;
			}
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.Update.3",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,inpatientNo);
		}
		
		/// <summary>
		/// 获得质量控制信息-查询可用的病历信息
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="EMRName"></param>
		/// <returns></returns>
		public ArrayList GetQCData(string inpatientNo,string EMRName)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.GetQCData.2",ref strSql)==-1) return null;
			strSql = string.Format(strSql,inpatientNo,EMRName);
			return this.myGetQCData(strSql);
		}
		/// <summary>
		/// 根据 条件 查询文件列表
		/// </summary>
		/// <param name="strWhere"></param>
		/// <returns></returns>
		public ArrayList GetQCDataBySqlWhere(string strWhere)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.GetQCData.Select",ref strSql)==-1) return null;
			strSql = strSql +" "+strWhere;
			return this.myGetQCData(strSql);
		}

		
		/// <summary>
		/// 获得节点内容
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <param name="nodeName"></param>
		/// <returns></returns>
		public string GetControlValue(string inpatientNo,string nodeName)
		{
			string strSql ="",sql="";
			if(this.Sql.GetSql("Management.DataFile.GetNodeValueFormDataStore",ref strSql)==-1) return "-1";
			try
			{
				sql = string.Format(strSql,"DataStore_Emr",inpatientNo,nodeName);
			}
			catch(Exception ex)
			{
				this.Err ="GetNodeValueFormDataStore付值时候出错！"+ex.Message;
				this.WriteErr();
				return "-1";
			}
			return this.ExecSqlReturnOne(sql);
		}
		#region "私有"
		private ArrayList myGetQCData(string sql)
		{
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				Neusoft.HISFC.Models.EPR.QC qc = new Neusoft.HISFC.Models.EPR.QC();
				qc.ID = this.Reader[0].ToString();
				qc.PatientInfo.ID = this.Reader[1].ToString();
				qc.PatientInfo.Name = this.Reader[2].ToString();
				qc.PatientInfo.PVisit.PatientLocation.Dept.ID = this.Reader[3].ToString();
				qc.Index = this.Reader[4].ToString();
				qc.Name = this.Reader[5].ToString();
				qc.QCData.State = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[6].ToString());
				
				if(!this.Reader.IsDBNull(7))
						 qc.QCData.Creater.Memo = this.Reader[7].ToString();
				if(!this.Reader.IsDBNull(8))
					qc.QCData.Creater.ID = this.Reader[8].ToString();
				if(!this.Reader.IsDBNull(9))
					qc.QCData.Saver.Memo = this.Reader[9].ToString();
					
				if(!this.Reader.IsDBNull(10))
					qc.QCData.Saver.ID = this.Reader[10].ToString();
				if(!this.Reader.IsDBNull(11))
					qc.QCData.Sealer.Memo = this.Reader[11].ToString();
				if(!this.Reader.IsDBNull(12))
					qc.QCData.Sealer.ID  = this.Reader[12].ToString();
				if(!this.Reader.IsDBNull(13))
					qc.QCData.Deleter.Memo = this.Reader[13].ToString();
				if(!this.Reader.IsDBNull(14))
					qc.QCData.Deleter.ID = this.Reader[14].ToString();
				
				al.Add(qc);
			}
			this.Reader.Close();
			return al;
		}
		#endregion

		#endregion

		#region 质量控制条件操作
		/// <summary>
		/// 插入一条质量控制条件信息
		/// </summary>
		/// <returns></returns>
		public int InsertQCCondition(Neusoft.HISFC.Models.EPR.QCConditions qc)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.InsertQCCondition",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,qc.ID,qc.Name,qc.Memo,qc.Conditions,qc.Acion.Name,this.Operator.ID);
		}
		
		/// <summary>
		///  更新质量控制条件信息
		/// </summary>
		/// <param name="qc"></param>
		/// <returns></returns>
		public int UpdateQCCondition(Neusoft.HISFC.Models.EPR.QCConditions qc)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.UpdateQCCondition",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,qc.ID,qc.Name,qc.Memo,qc.Conditions,qc.Acion.Name,this.Operator.ID);
		}
		
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public int DeleteQCCondition(string ID)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.DeleteQCCondition",ref strSql)==-1) return -1;
			return this.ExecNoQuery(strSql,ID);
		}
		/// <summary>
		/// 获得全部条件
		/// </summary>
		/// <returns></returns>
		public ArrayList GetQCConditionList()
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.SelectQCCondition.1",ref strSql)==-1) return null;
			return this._execConditionSelect(strSql);
		}
		/// <summary>
		/// 获得一个条件
		/// </summary>
		/// <returns></returns>
		public Neusoft.HISFC.Models.EPR.QCConditions GetQCCondition(string ID)
		{
			string strSql = "";
			if(this.Sql.GetSql("EPR.QC.SelectQCCondition.2",ref strSql)==-1) return null;
			strSql = string.Format(strSql,ID);
			ArrayList al = this._execConditionSelect(strSql);
			if(al == null)
			{
				return null;
			}
			else
			{
				return al[0] as Neusoft.HISFC.Models.EPR.QCConditions;
			}
		}
		protected ArrayList _execConditionSelect(string sql)
		{
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				try
				{
					Neusoft.HISFC.Models.EPR.QCConditions qc = new Neusoft.HISFC.Models.EPR.QCConditions();
					qc.ID= this.Reader[0].ToString();
					qc.Name= this.Reader[1].ToString();
					qc.Memo= this.Reader[2].ToString();
					qc.Conditions= this.Reader[3].ToString();
					qc.Acion.Name= this.Reader[4].ToString();
					qc.User01= this.Reader[5].ToString();
					qc.User02 = this.Reader[6].ToString();
					al.Add(qc);
				}
				catch(Exception ex){
					this.Err = ex.Message;
					this.WriteErr();
				return null;}	
			}
			this.Reader.Close();
			return al;
		}
		#endregion

		#region 质量控制名称
		/// <summary>
		/// 获得质量控制名称
		/// </summary>
		/// <returns></returns>
		public ArrayList GetQCName()
		{
			string sql = "EPR.QC.GetQCname";
			if(this.Sql.GetSql(sql,ref sql)==-1) return null;
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
			while(this.Reader.Read())
			{
				Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
				obj.ID = this.Reader[0].ToString();
				obj.Name = this.Reader[1].ToString();
				obj.Memo = this.Reader[2].ToString();
				try
				{
					obj.User01 = this.Reader[3].ToString();
					obj.User02 = this.Reader[4].ToString();
				}
				catch{}
				al.Add(obj);
			}
			this.Reader.Close();
			return al;
		}
		#endregion
        #region 质控条件输入操作
        /// <summary>
        /// 获得全部输入条件
        /// </summary>
        /// <returns></returns>
        public ArrayList GetQCInputCondition()
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.SelectQCInputCondition.1", ref strSql) == -1) return null;

            if (this.ExecQuery(strSql) == -1) return null;
            return _getQCInutCondition(strSql);
        }
        /// <summary>
        ///  获得全部输入条件
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public ArrayList GetQCInputCondition(string inpatientNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.SelectQCInputCondition.2", ref strSql) == -1) return null;

            if (this.ExecQuery(strSql, inpatientNo) == -1) return null;
            return _getQCInutCondition(strSql);
        }

        /// <summary>
        /// 保存条件
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        public int SaveQCInputCondition(ArrayList al)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                if (this.UpdateQCInputCondition(obj) <= 0)
                {
                    if (this.InsertQCInputCondition(obj) <= 0)
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 插入一条质量控制条件信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertQCInputCondition(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.InsertQCInputCondition", ref strSql) == -1) return -1;
            return this.ExecNoQuery(strSql, obj.ID, obj.Name.Trim(), obj.Memo.TrimStart(), obj.User01.Trim(), obj.User02, obj.User03);
        }

        /// <summary>
        /// 更新质量控制条件信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateQCInputCondition(Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.UpdateQCInputCondition", ref strSql) == -1) return -1;
            return this.ExecNoQuery(strSql, obj.ID, obj.Name.Trim(), obj.Memo.TrimStart(), obj.User01.Trim(), obj.User02, obj.User03);
        }

        /// <summary>
        /// 获得输入条件
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList _getQCInutCondition(string strSql)
        {
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                try
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString();
                    obj.Name = this.Reader[1].ToString().Trim();
                    obj.Memo = this.Reader[2].ToString().Trim();
                    obj.User01 = this.Reader[3].ToString();
                    obj.User02 = this.Reader[4].ToString();
                    obj.User03 = this.Reader[5].ToString();
                    al.Add(obj);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                    return null;
                }
            }
            this.Reader.Close();
            return al;
        }
        #endregion

        #region 患者质控数据操作
        /// <summary>
        /// 插入一条质控信息
        /// </summary>
        /// <returns></returns>
        public int InsertQCPatientData(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.EPR.QCConditions qc)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.Inpatient.Insert", ref strSql) == -1) return -1;
            return this.ExecNoQuery(strSql,
                patient.ID,
                patient.Name,
                patient.PVisit.PatientLocation.Dept.ID,
                patient.PVisit.PatientLocation.Dept.Name,
                patient.PVisit.AdmittingDoctor.ID,
                patient.PVisit.AdmittingDoctor.Name,
                patient.PVisit.OutTime.ToString(),
                patient.Memo,
                qc.ID,
                qc.Name,
                qc.Memo,
                this.Operator.ID
                );
        }

        /// <summary>
        ///  更新质量控制条件信息
        /// </summary>
        /// <param name="qc"></param>
        /// <returns></returns>
        public int UpdateQCPatientData(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.EPR.QCConditions qc)
        {
            if (this.DeleteQCPatientData(patient.ID, qc.ID) == -1) return -1;
            return this.InsertQCPatientData(patient, qc);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteQCPatientData(string inpatientNo, string qcid)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.Inpatient.Delete", ref strSql) == -1) return -1;
            return this.ExecNoQuery(strSql, inpatientNo, qcid);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int QueryQCPatientData(string inpatientNo, ref System.Data.DataSet ds)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.Inpatient.Where.1", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, inpatientNo);
            return this._execQueryQCPatientData(strSql, ref ds);
            //<SQL id="EPR.QC.Inpatient.Where.1" Memo="查询Where条件，按患者" input="1" output="10"><![CDATA[ 
            //where	   INPATIENT_NO ='{0}'
            //]]></SQL>
            //<SQL id="EPR.QC.Inpatient.Where.2" Memo="查询Where条件，按患者的质控条件" input="1" output="10"><![CDATA[ 
            //where	   INPATIENT_NO ='{0}' and  QC_CODE   ='{1}'
            //]]></SQL>
            //<SQL id="EPR.QC.Inpatient.Where.3" Memo="查询Where条件，按科室" input="1" output="10"><![CDATA[ 
            //where	  dept_code ='{0}' 
            //]]></SQL>
        }
        /// <summary>
        /// 查询患者的质控数据
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="qccode"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int QueryQCPatientData(string inpatientNo, string qccode, ref System.Data.DataSet ds)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.Inpatient.Where.2", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, inpatientNo, qccode);
            return this._execQueryQCPatientData(strSql, ref ds);

        }

        /// <summary>
        /// 查询患者的质控数据
        /// </summary>
        /// <param name="deptcode"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int QueryQCPatientDataByDept(string deptcode, ref System.Data.DataSet ds)
        {
            string strSql = "";
            if (this.Sql.GetSql("EPR.QC.Inpatient.Where.3", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, deptcode);
            return this._execQueryQCPatientData(strSql, ref ds);

        }
        /// <summary>
        /// 私有患者质控数据查询函数
        /// </summary>
        /// <param name="wheresql"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        protected int _execQueryQCPatientData(string wheresql, ref System.Data.DataSet ds)
        {
            string strSql = "";

            if (this.Sql.GetSql("EPR.QC.Inpatient.Select", ref strSql) == -1) return -1;//查询sql

            if (this.ExecQuery(strSql + "\n" + wheresql, ref ds) == -1) return -1;//查询+Where条件进行查询

            return 0;
        }


        #endregion
	}
}

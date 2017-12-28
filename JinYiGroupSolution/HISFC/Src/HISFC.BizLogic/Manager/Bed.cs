using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager {
	/// <summary>
	/// Bed 的摘要说明。
	/// </summary>
	public class Bed:Neusoft.FrameWork.Management.Database {
		public Bed() {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 取检索床位信息的sql语句
		/// </summary>
		/// <returns></returns>
		private string myGetQueryString() {		
			string strSql = "";
			if(this.Sql.GetSql("Manager.Bed.GetBedList",ref strSql)==-1) {
				this.Err = this.Sql.Err;
				return null;
			}

			return strSql;
		}


		/// <summary>
		/// 格式化参数:更新和插入时调用
		/// </summary>
		/// <param name="objBed"></param>
		/// <returns></returns>
		private string[] myGetParm(Neusoft.HISFC.Models.Base.Bed objBed) {
			string[] strParm={   objBed.ID,						//0 床号
								 objBed.NurseStation.ID,		//1 护理站编码
								 objBed.BedGrade.ID,			//2 床位等级编码
								 objBed.BedRankEnumService.ID.ToString(),	//3 床位编制编码
								 objBed.Status.ID.ToString(),//4 床位状态编码
								 Neusoft.FrameWork.Function.NConvert.ToInt32(objBed.IsValid).ToString(),	//5 是否有效
								 objBed.SickRoom.ID,				//6 房号
								 objBed.Doctor.ID,				//7 医生编码
								 objBed.Phone,					//8 电话
								 objBed.OwnerPc,				//9 归属
								 objBed.SortID.ToString(),		//10序号
								 this.Operator.ID,				//11操作员
								 objBed.InpatientNO,			//12患者住院号
								 Neusoft.FrameWork.Function.NConvert.ToInt32(objBed.IsPrepay).ToString(),	//13是否预约
								 objBed.PrepayOutdate.ToString(),//14预约日期
								 objBed.AdmittingDoctor.ID,		//住院医生
								 objBed.AttendingDoctor.ID,		//主治医生
								 objBed.ConsultingDoctor.ID,	//主任医生
								 objBed.AdmittingNurse.ID,		//责任护士
								 objBed.TendGroup,				//护理组
                                 //{4A0E8D9F-2FF5-4fc5-A050-8AA719E4D302}
                                 objBed.Status.User03 ==string.Empty?"ALL":objBed.Status.User03
							 };
			return strParm;
		}


		/// <summary>
		/// 增加床位信息
		/// </summary>
		/// <param name="objBed"></param>
		/// <returns></returns>
		public int CreatBedInfo(Neusoft.HISFC.Models.Base.Bed objBed) {
			string strSql="";	
			if(this.Sql.GetSql("Manager.Bed.CreatBedInfo.1",ref strSql)==-1) {
				this.Err = this.Sql.Err;
				return -1;
			}
			try {
				//如果床号小于四位,或者(大于四位的时候)前四位不等于护理站编码时,生成床号10位:护理站编码+床号
				if(objBed.ID.Length <= 4 || objBed.ID.Substring(0,4) != objBed.NurseStation.ID) {
					//生成床号10位:护理站编码+床号(后六位)
					objBed.ID = objBed.NurseStation.ID + (objBed.ID.Length > 6 ?objBed.ID.Substring(0, 6) :objBed.ID);
				}

				try {   				
					string[] strParm = myGetParm(objBed);  //取参数列表
					strSql = string.Format(strSql, strParm);

				}
				catch(Exception ex) {
					this.ErrCode=ex.Message;
					this.Err=ex.Message;
					return -1;
				}    

			}
			catch(Exception ex) {
				this.Err="付数值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}

			//执行SQL语句
			return this.ExecNoQuery(strSql);
		}


		/// <summary>
		/// 更改床位信息
		/// </summary>
		/// <param name="objBed"></param>
		/// <returns></returns>
		public int UpdateBedInfo(Neusoft.HISFC.Models.Base.Bed objBed) {
			string strSql="";
			
			if(this.Sql.GetSql("Manager.Bed.UpdateBedInfo.1",ref strSql)==-1) {
				this.Err = this.Sql.Err;
				return -1;
			}

			try {   				
				string[] strParm = myGetParm(objBed);  //取参数列表
                
				strSql = string.Format(strSql, strParm);

			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}    

			//执行SQL语句
			return this.ExecNoQuery(strSql);
		}


		/// <summary>
		/// 保存床位信息－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="objBed">床位信息实体</param>
		/// <returns>0未更新，大于1成功，-1失败</returns>
		public int SetBedInfo(Neusoft.HISFC.Models.Base.Bed objBed) {
			int parm;
			//执行更新操作
			parm = this.UpdateBedInfo(objBed);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (parm == 0 ) {
				parm = this.CreatBedInfo(objBed);
			}

			return parm;
		}


		/// <summary>
		/// 删除床位信息
		/// </summary>
		/// <param name="BedNo"></param>
		/// <returns></returns>
		public int DeleteBedInfo(string BedNo) {
			if (QuerySpecialBed(BedNo) > 0) {
				this.Err="该床位存在包床或挂床设置，请先做解开处理才能删除！";
				return -1;
			}
			string strSql="";
			
			if(this.Sql.GetSql("Manager.Bed.DeleteBedInfo.1",ref strSql)==-1) return -1;
			try {
				strSql=string.Format(strSql,BedNo);
			}
			catch(Exception ex) {
				this.Err="付数值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if (this.ExecNoQuery(strSql) <= 0) {
				return -1;
			}
			return 0;
		}


		/// <summary>
		/// 判断是否存在包床、挂床处理
		/// </summary>
		/// <param name="BedNo"></param>
		/// <returns></returns>
		private int QuerySpecialBed(string BedNo) {
			string strSql="";
			
			if(this.Sql.GetSql("Manager.Bed.QuerySpecialBed.1",ref strSql)==-1) return -1;
			try {
				strSql=string.Format(strSql,BedNo);
			}
			catch(Exception ex) {
				this.Err="付数值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecQuery(strSql);

		}


		/// <summary>
		/// 传入病区ID得到病区所有床位信息
		/// </summary>
		/// <param name="NurseStationId"></param>
		/// <returns></returns>
		public ArrayList GetBedList(string NurseStationId) {
			ArrayList al = new ArrayList();
			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetBedList.1",ref strSql)==0) {
				try {
					strSql=string.Format(strSql,NurseStationId);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(myGetQueryString() + " " + strSql)< 0) return null;
				return myGetBedList();
				
			}
			else {
				return null;
			}
		}
		/// <summary>
		/// 获得患者的请假床和包床信息
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <returns></returns>
		public ArrayList GetOtherBedList(string inpatientNo)
		{
			ArrayList al = new ArrayList();
			string strSql = "";
			if(this.Sql.GetSql("Manager.Bed.GetOtherBedList.Where", ref strSql) == 0) 
			{
				try 
				{
					strSql=string.Format(strSql,inpatientNo);
				}
				catch(Exception ex) 
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(myGetQueryString() + " " + strSql)< 0) return null;
				return myGetBedList();
				
			}
			else 
			{
				return null;
			}
		}


		/// <summary>
		/// 空床查询
		/// </summary>
		/// <param name="NurseStationId"></param>
		/// <returns></returns>
		public ArrayList GetFeeBedList(string NurseStationId) {
			ArrayList al = new ArrayList();
			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetFeeBedList.1",ref strSql)==0) 
			{
				try 
				{
					strSql=string.Format(strSql,NurseStationId);
				}
				catch(Exception ex) 
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				this.ExecQuery(strSql);
				Neusoft.HISFC.Models.Base.Bed obj = null;
				while(this.Reader.Read()) 
				{		
					obj = new Neusoft.HISFC.Models.Base.Bed();
					try 
					{
						obj.ID = this.Reader[0].ToString();					//床位编码
						obj.Name = obj.ID.Substring(4);						//去掉后四位做为床位名称
						obj.Name = this.Reader[0].ToString().Substring(4);	//如果床位编码大于4位,则从第5位开始取剩余的,否则取全部编码
						obj.BedGrade.ID=this.Reader[2].ToString();			//床位登记
						obj.BedRankEnumService.ID=this.Reader[3].ToString();			//床位编制
						obj.Status.ID = this.Reader[4].ToString();		//床位状态
						obj.SickRoom.ID=this.Reader[5].ToString();				//房号
						obj.Doctor.ID=this.Reader[6].ToString();			//床位医生
						obj.Phone=this.Reader[7].ToString();				//床位电话
						obj.OwnerPc=this.Reader[8].ToString();				//归属
						obj.InpatientNO=this.Reader[9].ToString();			//患者住院流水号
						obj.PrepayOutdate= Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());		//预约出院日期
						//是否有效:0有效,1无效
						if(this.Reader[11].ToString()=="0") 
						{
							obj.IsValid = true;
						}
						else 
						{
							obj.IsValid = false;
						}
						obj.IsPrepay=  Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[12].ToString());			//是否预约
						obj.SortID=  Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13].ToString());	//排序
						obj.NurseStation.ID= this.Reader[1].ToString();		//护理站
						obj.User01 = this.Reader[14].ToString();			//操作人编码
						obj.User02=this.Reader[15].ToString();				//操作日期
						obj.BedGrade.Name = this.Reader[16].ToString();		//床位等级名称
						obj.User03 = this.Reader["sumfee"].ToString();		//床位费
						obj.AdmittingDoctor.ID = this.Reader[18].ToString();//住院医生
						obj.AttendingDoctor.ID = this.Reader[19].ToString();//主治医生
						obj.ConsultingDoctor.ID = this.Reader[20].ToString();//主任医生
						obj.AdmittingNurse.ID = this.Reader[21].ToString();	//责任护士
						obj.User01 = this.Reader[22].ToString();
						al.Add(obj);
					}
					catch(Exception ex) 
					{
						this.Err = ex.Message;
						this.WriteErr();
						this.Reader.Close();
						return null;
					}
				}
				this.Reader.Close();
				return al;
				
			}
			else 
			{
				return null;
			}
		}
	

		/// <summary>
		/// 传入病区ID得到病区所有床位信息按床位状态
		/// </summary>
		/// <param name="NurseStationId"></param>
		/// <param name="Status"></param>
		/// <returns></returns>
		public ArrayList GetBedList(string NurseStationId,string Status) {   
			ArrayList al = new ArrayList();
			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetBedList.2",ref strSql)==0) {
				try {
					strSql=string.Format(strSql,NurseStationId,Status);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(myGetQueryString() + " " + strSql)< 0) return null;

				return myGetBedList();
			}
			else {
				return null;
			}

		}


		/// <summary>
		/// 传入病区ID得到病区所有空床位信息
		/// </summary>
		/// <param name="NurseStationId"></param>
		/// <returns></returns>
		public ArrayList GetUnoccupiedBed(string NurseStationId) {
			ArrayList al = new ArrayList();
			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetBedList.3",ref strSql)==0) {
				try {
					strSql=string.Format(strSql,NurseStationId);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(myGetQueryString() + " " + strSql)< 0) return null;
				return myGetBedList();
				
			}
			else {
				return null;
			}
		}


		//按床号查询床位信息(床号可以录入本病区的序列号)
		public  Neusoft.HISFC.Models.Base.Bed GetBedInfo(string BedNo) {   
			Neusoft.HISFC.Models.Base.Bed obj=new Neusoft.HISFC.Models.Base.Bed();

			//床号可以录入本病区的序列号
			if (BedNo.Length < 10) {
			}

			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetBedInfo.1",ref strSql)==0) {
				try {
					strSql=string.Format(strSql,BedNo);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(myGetQueryString() + " " + strSql)< 0) return null;

				ArrayList al = this.myGetBedList();
				
				if(al == null) 
					return null;
				else 
					return al[0] as  Neusoft.HISFC.Models.Base.Bed;			   
			}
			else {
				return null;
			}
		}


		/// <summary>
		/// 获得病区房间号
		/// </summary>
		/// <param name="NurseStationId"></param>
		/// <returns></returns>
		public ArrayList GetBedRoom(string NurseStationId) {
			ArrayList al=new ArrayList();
			string strSql="";
			
			if(this.Sql.GetSql("Manager.Bed.GetBedRoom.1",ref strSql)==0) {
				try {
					strSql=string.Format(strSql,NurseStationId);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(strSql)==-1) return null;
				while(this.Reader.Read()) {
					al.Add(this.Reader[0].ToString());
				}
				this.Reader.Close();
			}
			else {
				return null;
			}
			return al;
		}


		/// <summary>
		/// 传入病区ID得到病区所有床位信息
		/// </summary>
		/// <param name="RoomId">病房号</param>
		/// <param name="NurseCellID">护理站编码</param>
		/// <returns></returns>
		public ArrayList GetBedListByRoom(string RoomId,string NurseCellID) {
			ArrayList al = new ArrayList();
			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetBedByRoom",ref strSql)==0) {
				try {
					strSql=string.Format(strSql, RoomId, NurseCellID);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(myGetQueryString() + " " + strSql)< 0) return null;
				return myGetBedList();
				
			}
			else {
				return null;
			}
		}


		/// <summary>
		/// 通过病区编码获得护理组
		/// </summary>
		/// <param name="NurseCode"></param>
		/// <returns></returns>
		public ArrayList GetNurseTendGroupList(string NurseCode) {
			ArrayList al = new ArrayList();
			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetNurseTendGroupList",ref strSql)==0) {
				try {
					strSql=string.Format(strSql,NurseCode);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(strSql)< 0) return null;
				while(this.Reader.Read()) {
					al.Add(this.Reader[0].ToString());
				}
				
			}
			else {
				return null;
			}
			return al;
		}
		/// <summary>
		/// 获得护理组
		/// </summary>
		/// <param name="BedID"></param>
		/// <returns></returns>
		public string GetNurseTendGroupFromBed(string BedID) 
		{
			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetNurseTendGroupFromBed",ref strSql)==0) 
			{
				try 
				{
					strSql=string.Format(strSql,BedID);
				}
				catch(Exception ex) 
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return "-1";
				}
				if(this.ExecQuery(strSql)< 0) return null;
				if(this.Reader.Read() == false)
				{
					return "";
				}
				while(this.Reader.Read()) 
				{
					return this.Reader[0].ToString();
				}
				
			}
			else 
			{
				return "-1";
			}
			return "";
		}

		/// <summary>
		/// 获得病床及护理组
		/// </summary>
		/// <param name="NurseCode"></param>
		/// <returns></returns>
		public ArrayList GetBedNurseTendGroupList(string NurseCode) {
			ArrayList al = new ArrayList();
			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetNurseTendGroupList.1",ref strSql)==0) {
				try {
					strSql=string.Format(strSql,NurseCode);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(strSql)< 0) return null;
				while(this.Reader.Read()) {
					Neusoft.FrameWork.Models.NeuObject obj =new Neusoft.FrameWork.Models.NeuObject();
					obj.ID = (this.Reader[0].ToString());
					obj.Name = this.Reader[1].ToString();
					al.Add(obj);
				}
				
			}
			else {
				return null;
			}
			return al;
		}


		/// <summary>
		/// 获得病床列表通过护理组
		/// </summary>
		/// <param name="NurseTendGroup"></param>
		/// <returns></returns>
		public ArrayList GetBedListFromNurseTendGroup(string NurseTendGroup) {
			ArrayList al = new ArrayList();
			string strSql="";
			if(this.Sql.GetSql("Manager.Bed.GetBedListFromNurseTendGroup",ref strSql)==0) {
				try {
					strSql=string.Format(strSql,NurseTendGroup);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
				if(this.ExecQuery(strSql)< 0) return null;
				while(this.Reader.Read()) {
					al.Add(this.Reader[0].ToString());
				}
				
			}
			else {
				return null;
			}
			return al;
		}


		/// <summary>
		/// 更新病床护理组
		/// </summary>
		/// <param name="BedNo"></param>
		/// <returns></returns>
		public int UpdateNurseTendGroup(string BedNo,string NurseTendGroup) {
			string strSql="";
			
			
			if(this.Sql.GetSql("Manager.Bed.UpdateNurseTendGroup",ref strSql)==-1) return -1;
			try {
				strSql=string.Format(strSql,BedNo,NurseTendGroup);
			}
			catch(Exception ex) {
				this.Err="付数值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if (this.ExecNoQuery(strSql) <= 0) {
				return -1;
			}
			return 0;
		}


		/// <summary>
		/// 是否有存在病床号
		/// </summary>
		/// <param name="bedNo"></param>
		/// <returns></returns>
		public int  IsExistBedNo(string bedNo) {
			int  IsExist=0;
			string strSql = "";
			if (this.Sql.GetSql("Manager.Bed.GetBedListByRoom",ref strSql)==-1) return -1;
			try {
				if(bedNo!="") {
					strSql = string.Format(strSql,bedNo);
					this.ExecQuery(strSql);
					while(this.Reader.Read()) {
						IsExist = 1;
					}
					this.Reader.Close();
				}
			}
			catch(Exception ee) {
				this.Err = ee.Message;
				IsExist = -1;
			}
			return IsExist;
		}


		/// <summary>
		/// 取床位信息--私有方法
		/// </summary>
		/// <returns>床位数组,错误返回null</returns>
		private ArrayList myGetBedList() {
			ArrayList al = new ArrayList();
			Neusoft.HISFC.Models.Base.Bed obj = null;
			while(this.Reader.Read()) {		
				obj = new Neusoft.HISFC.Models.Base.Bed();
				try {
					obj.ID = this.Reader[0].ToString();					//床位编码
					obj.Name = obj.ID.Substring(4);						//去掉后四位做为床位名称
					obj.NurseStation.ID= this.Reader[1].ToString();		//护理站
					obj.BedGrade.ID=this.Reader[2].ToString();			//床位登记
					obj.BedRankEnumService.ID=this.Reader[3].ToString();			//床位编制
					obj.Status.ID = this.Reader[4].ToString();		//床位状态
					obj.SickRoom.ID=this.Reader[5].ToString();				//房号
					obj.Doctor.ID=this.Reader[6].ToString();			//床位医生
					obj.Phone=this.Reader[7].ToString();				//床位电话
					obj.OwnerPc=this.Reader[8].ToString();				//归属
					obj.InpatientNO=this.Reader[9].ToString();			//患者住院流水号
					obj.PrepayOutdate= Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());		//预约出院日期			
					obj.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[11].ToString());			//是否有效:0有效,1无效
					obj.IsPrepay=  Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[12].ToString());			//是否预约
					obj.SortID=  Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13].ToString());	//排序
					obj.User01 = this.Reader[14].ToString();			//操作人编码
					obj.User02=this.Reader[15].ToString();				//操作日期
					obj.BedGrade.Name = this.Reader[16].ToString();		//床位等级名称
					obj.User03 = this.Reader["sumfee"].ToString();		//床位费
					obj.AdmittingDoctor.ID = this.Reader[18].ToString();//住院医生
					obj.AttendingDoctor.ID = this.Reader[19].ToString();//主治医生
					obj.ConsultingDoctor.ID = this.Reader[20].ToString();//主任医生
					obj.AdmittingNurse.ID = this.Reader[21].ToString();	//责任护士
					obj.TendGroup = this.Reader[22].ToString();			//护理组
					al.Add(obj);
				}
				catch(Exception ex) {
					this.Err = ex.Message;
					this.WriteErr();
					this.Reader.Close();
					return null;
				}
			}
			this.Reader.Close();
			return al;
		}

        /// <summary>
        /// 获取护士站列表[2007/01/04 xuweizhe]
        /// </summary>
        /// <returns>null失败</returns>
        public ArrayList QueryNurseStationInfo()
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.Bed.GetNurseStationInfo", ref strsql) == -1)
            {
                return null;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }
            ArrayList alBeds = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.Bed bed = new Neusoft.HISFC.Models.Base.Bed();
                bed.ID = this.Reader.GetString(0);
                bed.Name = this.Reader.GetString(1);
                alBeds.Add(bed);
            }
            this.Reader.Close();
            return alBeds;
        }

        /// <summary>
        /// 获取床位信息,根据护士站ID[2007/01/04 XUWEIZHE]
        /// </summary>
        /// <param name="id">护士站ID</param>
        /// <param name="dv">返回的数据视图</param>
        /// <returns>-1,失败; 1,成功</returns>
        public int QueryBedInfoByNurseStationID(string id, ref System.Data.DataView dv)
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.Bed.QueryBedInfoByNurseStationID", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = String.Format(strsql, id);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            System.Data.DataSet ds = new System.Data.DataSet();
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            dv.Table = ds.Tables[0];
            return 1;

            #region 1111
            //ArrayList alBeds = new ArrayList();
            //while (this.Reader.Read())
            //{
            //    Neusoft.HISFC.Models.Base.Bed bed = new Neusoft.HISFC.Models.Base.Bed();
            //    bed.ID = this.Reader.GetString(0);
            //    bed.Name = this.Reader.GetString(1);
            //    bed.BedRankEnumService.Name = this.Reader.GetString(2);
            //    bed.Status.Name = this.Reader.GetString(3);
            //    bed.Phone = this.Reader.GetString(4);
            //    bed.OwnerPc = this.Reader.GetString(5);
            //    bed.InpatientNO = this.Reader.GetString(6);//医疗流水号
            //    bed.PrepayOutdate = Convert.ToDateTime(this.Reader.GetString(7));//出院日期
            //    bed.IsValid = this.Reader.GetString(8) == "0" ? true : false;
            //    bed.IsPrepay = this.Reader.GetString(9) == "1" ? true : false;
            //    bed.SortID = this.Reader.GetInt32(10);
            //    bed.TendGroup = this.Reader.GetString(11);//护理组

            //    alBeds.Add(bed);
            //}
            //this.Reader.Close();
            //return alBeds;
            #endregion


        }

        /// <summary>
        /// 获取所有床位信息
        /// </summary>
        /// <param name="dv">返回的数据视图</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryBedInfo(ref System.Data.DataView dv)
        {
            string strsql = "";
            if (this.Sql.GetSql("Manager.Bed.QueryBedInfo", ref strsql) == -1)
            {
                return -1;
            }
            System.Data.DataSet ds = new System.Data.DataSet();
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            dv.Table = ds.Tables[0];
            return 1;
        }
	}
}
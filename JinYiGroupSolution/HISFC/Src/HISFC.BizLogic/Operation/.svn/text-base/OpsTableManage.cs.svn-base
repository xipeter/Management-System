using System;
using System.Collections;
using System.Collections.Generic;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.BizLogic.Operation
{
	/// <summary>
	/// OpsTableManage 的摘要说明。
	/// </summary>
	public class OpsTableManage : Neusoft.FrameWork.Management.Database 
	{
		public OpsTableManage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 成员函数
		/// <summary>
		/// 申请新手术台序号
		/// </summary>
		/// <returns></returns>
		public string GetNewTableNo()
		{
			string strNewNo = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableManage.GetNewConsoleNo.1",ref strSql) == -1) 
			{
				return strNewNo; //空字符串
			}
			if (strSql == null) return strNewNo;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					strNewNo = Reader[0].ToString();
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return strNewNo;            
			}
			this.Reader.Close();
			strNewNo = strNewNo.PadLeft(4,'0');
			return strNewNo;
		}
		/// <summary>
		/// 给指定手术室增加手术台
		/// </summary>
		/// <param name="OpsTableAl">手术台对象数组</param>
		/// <returns>0 success -1 fail</returns>
		public int AddOpsTable(ArrayList OpsTableAl)
		{
			string strSql = string.Empty;			
			foreach(Neusoft.HISFC.Models.Operation.OpsTable thisOpsTable in OpsTableAl)
			{
				strSql = string.Empty;
				if(this.Sql.GetSql("Operator.OpsTableManage.AddOpsTable.1",ref strSql) == -1) return -1;
				try
				{						
					strSql = string.Format(strSql,thisOpsTable.ID.ToString(),thisOpsTable.Name,
						thisOpsTable.InputCode,thisOpsTable.Dept.ID.ToString(),
						thisOpsTable.RoomID,thisOpsTable.Remark ,thisOpsTable.User.ID.ToString());
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					this.ErrCode = ex.Message;
					return -1;            
				}
				if (strSql == null) return -1;				
				if(this.ExecNoQuery(strSql) == -1) return -1;
			}
			return 0;
		}

        /// <summary>
        /// 给指定手术室增加手术台
        /// </summary>
        /// <param name="tables">手术台对象数组</param>
        /// <returns>0 success -1 fail</returns>
        /// Robin   2007-01-19
        public int AddOpsTable(List<OpsTable> tables)
        {
            string strSql = string.Empty;
            foreach (Neusoft.HISFC.Models.Operation.OpsTable thisOpsTable in tables)
            {
                strSql = string.Empty;
                if (this.Sql.GetSql("Operator.OpsTableManage.AddOpsTable.1", ref strSql) == -1) return -1;
                try
                {
                    strSql = string.Format(strSql, thisOpsTable.ID, thisOpsTable.Name,
                        thisOpsTable.InputCode, thisOpsTable.Dept.ID,
                        thisOpsTable.Room.ID, thisOpsTable.Memo, thisOpsTable.User.ID.ToString());
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.ErrCode = ex.Message;
                    return -1;
                }
                if (strSql == null) return -1;
                if (this.ExecNoQuery(strSql) == -1) return -1;
            }
            return 0;
        }
		/// <summary>
		/// 修改手术台信息
		/// </summary>
		/// <param name="OpsTable">手术台对象</param>
		/// <returns>0 success -1 fail</returns>
		public int UpdateOpsTable(Neusoft.HISFC.Models.Operation.OpsTable OpsTable)
		{
			string strSql = string.Empty;
			string strValid = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsTable.IsValid).ToString();
			if(this.Sql.GetSql("Operator.OpsTableManage.UpdateOpsTable.1",ref strSql) == -1) return -1;			
			
			try
			{								
				strSql = string.Format(strSql,OpsTable.ID.ToString(),OpsTable.Name,OpsTable.InputCode,
					OpsTable.Dept.ID.ToString(),OpsTable.RoomID,strValid,OpsTable.Remark,OpsTable.User.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;			
			if(this.ExecNoQuery(strSql) == -1) return -1;
			return 0;
		}
		/// <summary>
		/// 删除手术台
		/// </summary>
		/// <param name="OpsTable">手术台编号</param>
		/// <returns>0 success -1 fail</returns>
		public int DelOpsTable(string OpsTableId)
		{
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableManage.DelOpsTable.1",ref strSql) == -1) return -1;
			
			try
			{	
				strSql = string.Format(strSql,OpsTableId);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;			
			return this.ExecNoQuery(strSql);
		}

        /// <summary>
        /// 删除手术间内所有手术台
        /// </summary>
        /// <param name="roomID">手术间ID</param>
        /// <returns></returns>
        /// Robin   2007-01-19
        public int DelOpsTables(string roomID)
        {
            string strSql = string.Empty;

            if (this.Sql.GetSql("Operator.OpsTableManage.DelOpsRoom.2", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, roomID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
		/// <summary>
		/// 获取指定手术室的手术台列表
		/// </summary>
		/// <param name="OpsRoomID">房间编码</param>
		/// <returns>手术台对象数组</returns>
		public ArrayList GetOpsTable(string OpsRoomID)
		{
			ArrayList OpsTableAl = new ArrayList();
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableManage.GetOpsTable.1",ref strSql) == -1) return OpsTableAl;
			try
			{
				strSql = string.Format(strSql,OpsRoomID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return OpsTableAl;            
			}
			if (strSql == null) return OpsTableAl;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.OpsTable thisTable = new Neusoft.HISFC.Models.Operation.OpsTable();

					thisTable.ID = Reader[0].ToString();//手术台代码
									
					thisTable.Name = Reader[1].ToString();//手术台名称
					
					thisTable.InputCode = Reader[2].ToString();//输入码
					
					thisTable.Dept.ID = Reader[3].ToString();//手术室编码
					
					thisTable.RoomID = Reader[4].ToString();//手术房间
					
					string strValid = Reader[5].ToString();//1有效0无效
					thisTable.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(strValid); 
					
					thisTable.Memo= Reader[6].ToString();//备注
					
					OpsTableAl.Add(thisTable);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得手术台信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return OpsTableAl;
			}
			this.Reader.Close();
			return OpsTableAl;
		}

        /// <summary>
        /// 获取指定手术室的手术台列表
        /// </summary>
        /// <param name="roomID">房间编码</param>
        /// <returns>手术台对象数组</returns>
        /// Robin   2007-01-16
        public List<OpsTable> GetOperationTables(string roomID)
        {
            ArrayList tables = this.GetOpsTable(roomID);
            List<OpsTable> ret = new List<OpsTable>();
            foreach(OpsTable table in tables)
            {
                ret.Add(table);
            }

            return ret;
        }
		/// <summary>
		/// 获取指定手术室的手术台列表
		/// </summary>
		/// <param name="OpsRoomID">科室编码</param>
		/// <returns>手术台对象数组</returns>
		public ArrayList GetOpsTableByDept(string DeptID)
		{
			ArrayList OpsTableAl = new ArrayList();
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableManage.GetOpsTable.2",ref strSql) == -1) return OpsTableAl;
			try
			{
				strSql = string.Format(strSql,DeptID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return OpsTableAl;            
			}
			if (strSql == null) return OpsTableAl;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.OpsTable thisTable = new Neusoft.HISFC.Models.Operation.OpsTable();

					thisTable.ID = Reader[0].ToString();//手术台代码
									
					thisTable.Name = Reader[1].ToString();//手术台名称
					
					thisTable.InputCode = Reader[2].ToString();//输入码
					
					thisTable.Dept.ID = Reader[3].ToString();//手术室编码
					
					thisTable.RoomID = Reader[4].ToString();//手术房间
					
					string strValid = Reader[5].ToString();//1有效0无效
					thisTable.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(strValid); 
					
					thisTable.Remark= Reader[6].ToString();//备注
					
					OpsTableAl.Add(thisTable);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得手术台信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return OpsTableAl;
			}
			this.Reader.Close();
			return OpsTableAl;
		}
		/// <summary>
		/// 根据手术台编号获得手术台名称
		/// </summary>
		/// <param name="strID">手术台编号</param>
		/// <returns>手术台名称</returns>
		public string GetTableNameFromID(string strID)
		{
			string strSql = string.Empty;
			string strName = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableManage.GetOpsTableFromID.1",ref strSql) == -1) return strName;
			try
			{
				strSql = string.Format(strSql,strID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return strName;            
			}
			if (strSql == null) return strName;
			this.ExecQuery(strSql);
			while(this.Reader.Read())
			{
				try
				{
					strName = Reader[0].ToString();//手术台名称
				}
				catch(Exception ex)
				{
					this.Err=ex.Message;
					this.WriteErr();
				}
			}
			this.Reader.Close();
			return strName;
		}
		/// <summary>
		/// 添加手术间
		/// </summary>
		/// <param name="room"></param>
		/// <returns></returns>
		public int AddOpsRooms(ArrayList rooms)
		{
			string strSql = string.Empty,strValid=string.Empty;			
			foreach(Neusoft.HISFC.Models.Operation.OpsRoom room in rooms)
			{
				strSql = string.Empty;
				if(this.Sql.GetSql("Operator.OpsTableManage.AddOpsRooms.1",ref strSql) == -1) return -1;
				try
				{	
					if(room.IsValid)
						strValid="1";
					else
						strValid="0";

					strSql = string.Format(strSql,room.ID,room.Name,room.InputCode,room.DeptID,
						strValid,room.OperCode);
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					this.ErrCode = ex.Message;
					return -1;            
				}
				if (strSql == null) return -1;				
				if(this.ExecNoQuery(strSql) == -1) return -1;
			}
			return 0;
		}

        /// <summary>
        /// 添加手术间
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int AddOpsRoom(OpsRoom room)
        {
            string strSql = string.Empty, strValid = string.Empty;	
            strSql = string.Empty;
            if (this.Sql.GetSql("Operator.OpsTableManage.AddOpsRooms.1", ref strSql) == -1) return -1;
            try
            {
                if (room.IsValid)
                    strValid = "1";
                else
                    strValid = "0";

                strSql = string.Format(strSql, room.ID, room.Name, room.InputCode, room.DeptID,
                    strValid, room.OperCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            if (strSql == null) return -1;
            return this.ExecNoQuery(strSql);
        }
		/// <summary>
		/// 更新手术间
		/// </summary>
		/// <param name="room"></param>
		/// <returns></returns>
		public int UpdateOpsRoom(Neusoft.HISFC.Models.Operation.OpsRoom room)
		{
			string strSql = string.Empty;
			string strValid = Neusoft.FrameWork.Function.NConvert.ToInt32(room.IsValid).ToString();
			if(this.Sql.GetSql("Operator.OpsTableManage.UpdateOpsRoom.1",ref strSql) == -1) return -1;			
			
			try
			{								
				strSql = string.Format(strSql,room.Name,room.InputCode,
					strValid,room.DeptID,room.OperCode,room.ID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;	
		
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 删除手术间
		/// </summary>
		/// <param name="room"></param>
		/// <returns></returns>
		public int DelOpsRoom(Neusoft.HISFC.Models.Operation.OpsRoom room)
		{
			string strSql=string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableManage.DelOpsRoom.1",ref strSql)==-1)return -1;
			try
			{
				strSql=string.Format(strSql,room.ID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1; 
			}
			if(this.ExecNoQuery(strSql)==-1)return -1;
			//删除手术间下的手术台
			if(this.Sql.GetSql("Operator.OpsTableManage.DelOpsRoom.2",ref strSql)==-1)return -1;
			try
			{
				strSql=string.Format(strSql,room.ID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1; 
			}
			if(this.ExecNoQuery(strSql)==-1)return -1;
			return 0;
		}
		/// <summary>
		/// 根据科室获得科室下手术间
		/// </summary>
		/// <param name="deptID"></param>
		/// <returns></returns>
		public ArrayList GetRoomsByDept(string deptID)
		{
			ArrayList rooms = new ArrayList();
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableManage.GetRoomsByDept.1",ref strSql) == -1) return rooms;
			try
			{
				strSql = string.Format(strSql,deptID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return rooms;
			}
			if (strSql == null) 
				return rooms;
			if(this.ExecQuery(strSql)==-1)return rooms;
			try
			{
				while(Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.OpsRoom room=new Neusoft.HISFC.Models.Operation.OpsRoom();
					room.ID=Reader[2].ToString();//代码
					room.Name=Reader[3].ToString();//名称
					room.InputCode=Reader[4].ToString();//助记码
					room.DeptID=deptID;//所属科室
					room.IsValid=Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[6].ToString());
					room.OperCode=Reader[7].ToString();
					room.OperDate=Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[8].ToString());
					rooms.Add(room);
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				if(this.Reader.IsClosed==false)
					Reader.Close();
				return rooms;
			}

			Reader.Close();
			return rooms;
		}
		/// <summary>
		/// 根据房间号获得手术房间
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Operation.OpsRoom GetRoomByID(string ID)
		{
			string sql=string.Empty;
			Neusoft.HISFC.Models.Operation.OpsRoom room=null;

			if(this.Sql.GetSql("Operator.OpsTableManage.GetRoomsByID.1",ref sql)==-1)return null;
			try
			{
				sql = string.Format(sql,ID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return null;    
			}
		
			if(this.ExecQuery(sql)==-1)return null;
			try
			{
				while(Reader.Read())
				{
					room=new Neusoft.HISFC.Models.Operation.OpsRoom();
					room.ID=Reader[2].ToString();//代码
					room.Name=Reader[3].ToString();//名称
					room.InputCode=Reader[4].ToString();//助记码
					room.DeptID=Reader[5].ToString();//所属科室
					room.IsValid=Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[6].ToString());
					room.OperCode=Reader[7].ToString();
					room.OperDate=Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[8].ToString());					
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				if(this.Reader.IsClosed==false)Reader.Close();
				return null;
			}

			Reader.Close();
			return room;
		}
		/// <summary>
		/// 获取新房间号
		/// </summary>
		/// <returns></returns>
		public string GetNewRoomID()
		{
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsRoomManage.GetNewRoomID.1",ref strSql) == -1) 
			{
				return string.Empty;
			}
			
			return this.ExecSqlReturnOne(strSql);			
		}
        /// <summary>
        /// 判断当前的手术台是否有已安排过记录
        /// </summary>
        /// <param name="OpsTableID"> 手术台号</param>
        /// <returns>出错返回-1 有安排记录1,没有安排记录0</returns>
        private int OpsTableIsUsing(string OpsTableID)
        {
            string strSql = string.Empty;
            if (this.Sql.GetSql("Operator.OpsTableManage.OpsTableIsUsing.1", ref strSql) == -1)
            {
                this.Err = "没有找到SQL Operator.OpsTableManage.OpsTableIsUsing.1 ";
                return -1;
            }
            strSql = string.Format(strSql, OpsTableID);
            this.ExecQuery(strSql);
            int i = 0;
            try
            {
                while (this.Reader.Read())
                {
                    i++;
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Reader.Close();
                this.Err = ex.Message;
                return -1;
            }
            return i;
        }
        /// <summary>
        /// 判断当前的手术房间是否有已安排过记录
        /// </summary>
        /// <param name="OpsRoomID">手术房间号</param>
        /// <returns>出错返回-1 有安排记录1,没有安排记录0</returns>
        private int OpsRoomIsUsing(string OpsRoomID)
        {
            string strSql = string.Empty;
            if (this.Sql.GetSql("Operator.OpsTableManage.OpsRoomIsUsing.1", ref strSql) == -1)
            {
                this.Err = "没有找到SQL Operator.OpsTableManage.OpsRoomIsUsing.1 ";
                return -1;
            }
            strSql = string.Format(strSql, OpsRoomID);
            this.ExecQuery(strSql);
            int i = 0;
            try
            {
                while (this.Reader.Read())
                {
                    return i++;
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Reader.Close();
                this.Err = ex.Message;
                return -1;
            }
            return i;
        }
		#endregion
	}
}

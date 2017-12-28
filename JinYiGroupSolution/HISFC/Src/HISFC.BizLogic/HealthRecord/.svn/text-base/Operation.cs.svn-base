using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    public class Operation : Neusoft.FrameWork.Management.Database
    {
        public Operation()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 检索某个住院流水号下的 手术信息  operType 如果是 "DOC" 查询的是医生站录入的手术信息 如果输入的是“CAS”，则查询病案师录入的手术信息
        /// Creator: zhangjunyi@neusoft.com
        /// </summary>
        /// <param name="operType">类型</param>
        /// <returns>成功返回符合条件的数组，失败或出现异常错误 返回</returns>
        public ArrayList QueryOperation(Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes operType, string InpatientNo)
        {
            string OperType = "";
            if (operType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                OperType = "1";
            }
            else if (operType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                OperType = "2";
            }
            else
            {
                this.Err = "没有指定插入的类型 DOC 或 CAS";
                return null;
            }
            ArrayList List = null;
            string MainSql = QueryOperationSql();
            if (MainSql == null)
            {
                return null;
            }
            string strSql = "";
            if (this.Sql.GetSql("Case.Operationdetail.Select", ref strSql) == -1) return null;
            strSql = MainSql + strSql;
            try
            {
                //查询
                strSql = string.Format(strSql, InpatientNo, OperType);
                return myQuery(strSql);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                List = null;
            }
            return List;
        }
        /// <summary>
        /// 私有变量
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList myQuery(string strSql)
        {
            ArrayList List = null;
            try
            {
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.OperationDetail info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.HealthRecord.OperationDetail();

                    info.OperationDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[0]);//手术日期 
                    info.OperationInfo.ID = Reader[1].ToString();	//手术代码
                    info.OperationInfo.Name = Reader[2].ToString(); //手术名称
                    info.OperationKind = Reader[3].ToString();      //手术种类
                    info.MarcKind = Reader[4].ToString();			//麻醉方式
                    info.NickKind = Reader[5].ToString();			//切口种类  
                    info.CicaKind = Reader[6].ToString();			//愈合种类
                    info.FirDoctInfo.ID = Reader[7].ToString();		//手术医师编码
                    info.FirDoctInfo.Name = Reader[8].ToString();	//手术医师名称
                    info.SecDoctInfo.ID = Reader[9].ToString();	//I助代码
                    info.SecDoctInfo.Name = Reader[10].ToString();	//I助名称
                    info.ThrDoctInfo.ID = Reader[11].ToString();	//II助代码
                    info.ThrDoctInfo.Name = Reader[12].ToString();	//II助名称
                    info.NarcDoctInfo.ID = Reader[13].ToString();	//麻醉医师代码
                    info.NarcDoctInfo.Name = Reader[14].ToString();	//麻醉医师名称
                    //					info.OperationInfo.Name = Reader[15].ToString();//手术日期
                    info.OpbOpa = Reader[15].ToString();			//术前_后符合术前_后符合
                    info.BeforeOperDays = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[16]);//术前住院天数
                    info.StatFlag = Reader[17].ToString();//统计标志 
                    info.InDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[18]);	//入科日期 
                    info.OutDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[19]);//出院日期
                    info.DeatDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[20]);//死亡日期
                    info.OperationDeptInfo.ID = Reader[21].ToString();//手术科室
                    info.OutDeptInfo.ID = Reader[22].ToString();	//出院病房 
                    info.OutICDInfo.ID = Reader[23].ToString();		//出院主诊断ICD
                    info.SYNDFlag = Reader[24].ToString();			//是否合并症
                    //					info.OperDate = Reader[25].ToString();		//操作员
                    //					info.		  Reader[26].ToString();  操作时间			
                    info.OperType = Reader[27].ToString();			//类别  1 医生站手术明细   2 病案室手术明细 
                    info.FourDoctInfo.ID = Reader[28].ToString();//手术医师编码2
                    info.FourDoctInfo.Name = Reader[29].ToString();//手术医师名称2
                    info.HappenNO = Reader[30].ToString();//发生序号
                    info.InpatientNO = Reader[31].ToString(); //住院流水号
                    List.Add(info);
                    info = null;
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                List = null;
            }
            return List;
        }
        /// <summary>
        /// 主SQL语句
        /// </summary>
        /// <returns></returns>
        private string QueryOperationSql()
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.Operationdetail.QueryOperationSql", ref strSql) == -1) return null;
            return strSql;
        }
        /// <summary>
        /// 检索某个住院流水号下的 手术室录入的手术信息
        /// Creator: zhangjunyi@neusoft.com
        /// </summary>
        /// <returns>成功返回符合条件的数组，失败或出现异常错误 返回</returns>
        public ArrayList QueryOperationByInpatientNo(string InpatientNo)
        {
            ArrayList List = null;
            string MainSql = QueryOperationSql();
            string strSql = "";
            if (this.Sql.GetSql("Case.Operationdetail.SelectOperation", ref strSql) == -1) return null;
            strSql = MainSql + strSql;
            try
            {
                //查询
                strSql = string.Format(strSql, InpatientNo);
                return myQuery(strSql);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                List = null;
            }
            return List;
        }
        /// <summary>
        /// 更新某条手术信息  operType 如果是 "DOC" 更新的是医生站录入的手术信息 如果输入的是“CAS”，则更新病案师录入的手术信息
        /// Creator:zhangjunyi@neusoft.com
        /// </summary>
        /// <param name="OperType">类型 用来标识操作医生站还是病案 </param>
        /// <param name="info"></param>
        /// <returns>成功返回1 失败返回 －1</returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType, Neusoft.HISFC.Models.HealthRecord.OperationDetail info)
        {
            //手术类别 判断是医生输入还是病案室输入

            if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                info.OperType = "1";
            }
            else if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                info.OperType = "2";
            }
            else
            {
                this.Err = "没有指定插入的类型 DOC 或 CAS";
                return -1;
            }
            string strSql = "";
            if (this.Sql.GetSql("Case.Operationdetail.Update", ref strSql) == -1) return -1;
            try
            {
                //参数数组
                string[] str = Getinfo(info);
                strSql = string.Format(strSql, str);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 插入某条手术信息  operType 如果是 "DOC" 插入的是医生站录入的手术信息 如果输入的是“CAS”，则 插入病案师录入的手术信息
        /// Creator: zhangjunyi@neusoft.com
        /// </summary>
        /// <param name="OperType">标识</param>
        /// <param name="info"></param>
        /// <returns>成功返回 1 失败返回 －1 </returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType, Neusoft.HISFC.Models.HealthRecord.OperationDetail info)
        {
            string strSql = "";
            //手术类别 判断是医生输入还是病案室输入

            if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                info.OperType = "1";
            }
            else if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                info.OperType = "2";
            }
            else
            {
                this.Err = "没有指定插入的类型 DOC 或 CAS";
                return -1;
            }
            int intHappenNo = GetNewOperationNo(info.InpatientNO, info.OperType);
            //发生序号
            info.HappenNO = intHappenNo.ToString();
            if (this.Sql.GetSql("Case.Operationdetail.Insert", ref strSql) == -1) return -1;
            try
            {
                //参数数组
                string[] str = Getinfo(info);
                strSql = string.Format(strSql, str);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 申请新手术发生序号
        /// </summary>
        /// <returns> 新申请的序号 错误时返回-1</returns>
        public int GetNewOperationNo(string InpatientNo, string type)
        {
            int lNewNo = -1;
            string strSql = "";
            if (this.Sql.GetSql("Case.Operationdetail.GetNewOperationNo.1", ref strSql) == -1) return -1;
            if (strSql == null) return -1;
            strSql = string.Format(strSql, InpatientNo, type);
            this.ExecQuery(strSql);
            try
            {
                while (this.Reader.Read())
                {
                    lNewNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr(); ;
                return -1;
            }
            this.Reader.Close();
            return lNewNo;
        }
        /// <summary>
        /// 删除某条手术信息  operType 如果是 "DOC" 删除的是医生站录入的手术信息 如果输入的是“CAS”，则 删除病案师录入的手术信息
        /// Creator :zhangjunyi@neusoft.com
        /// </summary>
        /// <param name="OperType"></param>
        /// <param name="info"></param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int delete(Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType, Neusoft.HISFC.Models.HealthRecord.OperationDetail info)
        {
            //手术类别 判断是医生输入还是病案室输入

            if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                info.OperType = "1";
            }
            else if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                info.OperType = "2";
            }
            else
            {
                this.Err = "没有指定插入的类型 DOC 或 CAS";
                return -1;
            }
            string strSql = "";
            if (this.Sql.GetSql("Case.Operationdetail.delete", ref strSql) == -1) return -1;
            try
            {
                //参数数组
                string[] str = Getinfo(info);
                strSql = string.Format(strSql, str);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        public int DeleteByCodeAndTime(System.DateTime dt, string InpatientNO)
        {
            try
            {
                string strSql = "";
                if (this.Sql.GetSql("Case.Operationdetail.DeleteByCodeAndTime", ref strSql) == -1) return -1;
                strSql = string.Format(strSql, InpatientNO, dt.ToString());
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 获取实体里的信息 ，返回参数数组 
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>失败返回null 成功返回参数数组</returns>
        private string[] Getinfo(Neusoft.HISFC.Models.HealthRecord.OperationDetail info)
        {
            string[] s = new string[32];
            try
            {
                s[0] = info.InpatientNO; //住院流水号
                s[1] = info.HappenNO;//发生序号
                s[2] = info.OperationDate.ToString();//手术日期 
                s[3] = info.OperationInfo.ID;	//手术代码
                s[4] = info.OperationInfo.Name; //手术名称
                s[5] = info.OperationKind;      //手术种类
                s[6] = info.MarcKind;			//麻醉方式
                s[7] = info.NickKind;			//切口种类  
                s[8] = info.CicaKind;			//愈合种类
                s[9] = info.FirDoctInfo.ID;		//手术医师编码
                s[10] = info.FirDoctInfo.Name;	//手术医师名称
                s[11] = info.SecDoctInfo.ID;	//I助代码
                s[12] = info.SecDoctInfo.Name;	//I助名称
                s[13] = info.ThrDoctInfo.ID;	//II助代码
                s[14] = info.ThrDoctInfo.Name;	//II助名称
                s[15] = info.NarcDoctInfo.ID;	//麻醉医师代码
                s[16] = info.NarcDoctInfo.Name;	//麻醉医师名称
                s[17] = info.OpbOpa;			//术前_后符合术前_后符合
                s[18] = info.BeforeOperDays.ToString();//术前住院天数
                s[19] = info.StatFlag;//统计标志 
                s[20] = info.InDate.ToString();	//入科日期 
                s[21] = info.OutDate.ToString();//出院日期
                s[22] = info.DeatDate.ToString();//死亡日期
                s[23] = info.OperationDeptInfo.ID;//手术科室
                s[24] = info.OutDeptInfo.ID;	//出院病房 
                s[25] = info.OutICDInfo.ID;		//出院主诊断ICD
                s[26] = info.SYNDFlag;			//是否合并症
                s[27] = this.Operator.ID;		//操作员
                s[28] = info.OperType;			//类别  1 医生站手术明细   2 病案室手术明细 
                s[29] = info.FourDoctInfo.ID;//手术医师编码2
                s[30] = info.FourDoctInfo.Name;//手术医师名称2
                s[31] = info.OperDate.ToString(); //操作时间
                return s;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取第一手术 
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="frmType"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.HealthRecord.OperationDetail GetFirstOperation(string InpatientNo, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes frmType)
        {
            Neusoft.HISFC.Models.HealthRecord.OperationDetail info = new Neusoft.HISFC.Models.HealthRecord.OperationDetail();
            ArrayList list = QueryOperation(frmType, InpatientNo);
            if (list == null)
            {
                return null;
            }
            if (list.Count > 0)
            {
                info = (Neusoft.HISFC.Models.HealthRecord.OperationDetail)list[0];
            }
            return info;
        }

        #region 废弃
        /// <summary>
        /// 检索某个住院流水号下的 手术信息  operType 如果是 "DOC" 查询的是医生站录入的手术信息 如果输入的是“CAS”，则查询病案师录入的手术信息
        /// Creator: zhangjunyi@neusoft.com
        /// </summary>
        /// <param name="operType">类型</param>
        /// <returns>成功返回符合条件的数组，失败或出现异常错误 返回</returns>
        [Obsolete("废弃 用 QueryOperation ", true)]
        public ArrayList Select(Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes operType, string InpatientNo)
        {
            string OperType = "";
            if (operType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                OperType = "1";
            }
            else if (operType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                OperType = "2";
            }
            else
            {
                this.Err = "没有指定插入的类型 DOC 或 CAS";
                return null;
            }
            ArrayList List = null;
            string MainSql = QueryOperationSql();
            if (MainSql == null)
            {
                return null;
            }
            string strSql = "";
            if (this.Sql.GetSql("Case.Operationdetail.Select", ref strSql) == -1) return null;
            strSql = MainSql + strSql;
            try
            {
                //查询
                strSql = string.Format(strSql, InpatientNo, OperType);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.OperationDetail info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.HealthRecord.OperationDetail();

                    info.OperationDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[0]);//手术日期 
                    info.OperationInfo.ID = Reader[1].ToString();	//手术代码
                    info.OperationInfo.Name = Reader[2].ToString(); //手术名称
                    info.OperationKind = Reader[3].ToString();      //手术种类
                    info.MarcKind = Reader[4].ToString();			//麻醉方式
                    info.NickKind = Reader[5].ToString();			//切口种类  
                    info.CicaKind = Reader[6].ToString();			//愈合种类
                    info.FirDoctInfo.ID = Reader[7].ToString();		//手术医师编码
                    info.FirDoctInfo.Name = Reader[8].ToString();	//手术医师名称
                    info.SecDoctInfo.ID = Reader[9].ToString();	//I助代码
                    info.SecDoctInfo.Name = Reader[10].ToString();	//I助名称
                    info.ThrDoctInfo.ID = Reader[11].ToString();	//II助代码
                    info.ThrDoctInfo.Name = Reader[12].ToString();	//II助名称
                    info.NarcDoctInfo.ID = Reader[13].ToString();	//麻醉医师代码
                    info.NarcDoctInfo.Name = Reader[14].ToString();	//麻醉医师名称
                    //					info.OperationInfo.Name = Reader[15].ToString();//手术日期
                    info.OpbOpa = Reader[15].ToString();			//术前_后符合术前_后符合
                    info.BeforeOperDays = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[16]);//术前住院天数
                    info.StatFlag = Reader[17].ToString();//统计标志 
                    info.InDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[18]);	//入科日期 
                    info.OutDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[19]);//出院日期
                    info.DeatDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[20]);//死亡日期
                    info.OperationDeptInfo.ID = Reader[21].ToString();//手术科室
                    info.OutDeptInfo.ID = Reader[22].ToString();	//出院病房 
                    info.OutICDInfo.ID = Reader[23].ToString();		//出院主诊断ICD
                    info.SYNDFlag = Reader[24].ToString();			//是否合并症
                    //					info.OperDate = Reader[25].ToString();		//操作员
                    //					info.		  Reader[26].ToString();  操作时间			
                    info.OperType = Reader[27].ToString();			//类别  1 医生站手术明细   2 病案室手术明细 
                    info.FourDoctInfo.ID = Reader[28].ToString();//手术医师编码2
                    info.FourDoctInfo.Name = Reader[29].ToString();//手术医师名称2
                    info.InpatientNO = InpatientNo; //住院流水号
                    info.HappenNO = Reader[30].ToString();//发生序号
                    List.Add(info);
                    info = null;
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                List = null;
            }
            return List;
        }

        /// <summary>
        /// 检索某个住院流水号下的 手术室录入的手术信息
        /// Creator: zhangjunyi@neusoft.com
        /// </summary>
        /// <returns>成功返回符合条件的数组，失败或出现异常错误 返回</returns>
        [Obsolete("废弃 用 QueryOperationByInpatientNo 代替 ",true)]
        public ArrayList SelectOperation(string InpatientNo)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.Operationdetail.SelectOperation", ref strSql) == -1) return null;
            try
            {
                //查询
                strSql = string.Format(strSql, InpatientNo);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.OperationDetail info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.HealthRecord.OperationDetail();

                    info.OperationDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[0]);//手术日期 
                    info.OperationInfo.ID = Reader[1].ToString();	//手术代码
                    info.OperationInfo.Name = Reader[2].ToString(); //手术名称
                    info.OperationKind = Reader[3].ToString();      //手术种类
                    info.MarcKind = Reader[4].ToString();			//麻醉方式
                    info.NickKind = Reader[5].ToString();			//切口种类  
                    info.CicaKind = Reader[6].ToString();			//愈合种类
                    info.FirDoctInfo.ID = Reader[7].ToString();		//手术医师编码
                    info.FirDoctInfo.Name = Reader[8].ToString();	//手术医师名称
                    info.SecDoctInfo.ID = Reader[9].ToString();	//I助代码
                    info.SecDoctInfo.Name = Reader[10].ToString();	//I助名称
                    info.ThrDoctInfo.ID = Reader[11].ToString();	//II助代码
                    info.ThrDoctInfo.Name = Reader[12].ToString();	//II助名称
                    info.NarcDoctInfo.ID = Reader[13].ToString();	//麻醉医师代码
                    info.NarcDoctInfo.Name = Reader[14].ToString();	//麻醉医师名称
                    //					info.OperationInfo.Name = Reader[15].ToString();//手术日期
                    info.OpbOpa = Reader[15].ToString();			//术前_后符合术前_后符合
                    info.BeforeOperDays = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[16]);//术前住院天数
                    info.StatFlag = Reader[17].ToString();//统计标志 
                    info.InDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[18]);	//入科日期 
                    info.OutDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[19]);//出院日期
                    info.DeatDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[20]);//死亡日期
                    info.OperationDeptInfo.ID = Reader[21].ToString();//手术科室
                    info.OutDeptInfo.ID = Reader[22].ToString();	//出院病房 
                    info.OutICDInfo.ID = Reader[23].ToString();		//出院主诊断ICD
                    info.SYNDFlag = Reader[24].ToString();			//是否合并症
                    //					info.OperDate = Reader[25].ToString();		//操作员
                    //					info.		  Reader[26].ToString();  操作时间			
                    info.OperType = Reader[27].ToString();			//类别  1 医生站手术明细   2 病案室手术明细 
                    info.FourDoctInfo.ID = Reader[28].ToString();//手术医师编码2
                    info.FourDoctInfo.Name = Reader[29].ToString();//手术医师名称2
                    info.InpatientNO = InpatientNo; //住院流水号
                    info.HappenNO = Reader[30].ToString();//发生序号
                    List.Add(info);
                    info = null;
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                List = null;
            }
            return List;
        }
        #endregion
    }
}

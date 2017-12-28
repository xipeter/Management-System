using System;
using System.Collections;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;

namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    /// <summary>
    /// Diagnose 的摘要说明。
    /// </summary>
    public class Diagnose : Neusoft.FrameWork.Management.Database
    {
        public Diagnose()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 公有函数

        #region 插入病案诊断信息
        /// <summary>
        /// 插入病案诊断信息
        /// </summary>
        /// <param name="Item">Neusoft.HISFC.Models.HealthRecord.Diagnose</param>
        /// <returns>int 0 成功 -1 失败</returns>
        public int InsertDiagnose(Neusoft.HISFC.Models.HealthRecord.Diagnose Item)
        {
            string strSQL = "";
            if (this.Sql.GetSql("CASE.Diagnose.Insert.1", ref strSQL) == -1) return -1;
            Item.DiagInfo.HappenNo = GetMaxHappenNum(Item.DiagInfo.Patient.ID);
            string[] strParm = myGetItemParm(Item);
            return this.ExecNoQuery(strSQL, strParm);
        }
        #endregion 

        #region 更新病案诊断信息
        /// <summary>
        /// 更新病案诊断信息
        /// </summary>
        /// <param name="dg">Neusoft.HISFC.Models.HealthRecord.Diagnose</param>
        /// <returns>int 0 成功 -1 失败</returns>
        public int UpdateDiagnose(Neusoft.HISFC.Models.HealthRecord.Diagnose dg)
        {
            string strSQL = "";
            if (this.Sql.GetSql("CASE.Diagnose.Update.1", ref strSQL) == -1) return -1;
            string[] strParm = myGetItemParm(dg);  //取参数列表
            return this.ExecNoQuery(strSQL, strParm);
        }
        /// <summary>
        /// 更新病案诊断信息
        /// </summary>
        /// <param name="dg">Neusoft.HISFC.Models.HealthRecord.Diagnose</param>
        /// <returns>int 0 成功 -1 失败</returns>
        public int UpdateDiagnoseForClinic(Neusoft.HISFC.Models.HealthRecord.Diagnose dg)
        {
            string strSQL = "";
            if (this.Sql.GetSql("CASE.Diagnose.Update.2", ref strSQL) == -1) return -1;
            string[] strParm = myGetItemParm(dg);  //取参数列表
            return this.ExecNoQuery(strSQL, strParm);
        }
        #endregion 

        #region 删除一个患者的所有病案诊断信息
        /// <summary>
        /// 删除一个患者的所有病案诊断信息
        /// </summary>
        /// <param name="InpatientNO">string 患者住院流水号</param>
        /// <returns>int 0 成功 -1 失败</returns>
        public int DeleteDiagnoseAll(string InpatientNO, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType)
        {
            string temp = "";
            if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                temp = "1";
            }
            else if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                temp = "2";
            }

            string strSQL = "";
            if (this.Sql.GetSql("CASE.Diagnose.Delete.1", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, InpatientNO, temp);
            }
            catch
            {
                this.Err = "传入参数不对！CASE.Diagnose.Delete.1";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion 

        #region 删除一个患者的单条诊断信息
        ///<summary>
        /// 删除一个患者的单条诊断信息
        /// </summary>
        /// <param name="InpatientNO">患者住院流水号</param>
        /// <param name="happenNO">诊断流水号</param>
        /// <param name="OperType">类型 DOC 医生站录入的诊断 ，CAS 病案室录入的诊断 </param>
        /// <returns></returns>
        public int DeleteDiagnoseSingle(string InpatientNO, int happenNO, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType)
        {
            string strSQL = "";
            string temp = "";
            if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                temp = "1";
            }
            else if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                temp = "2";
            }
            else
            {
            }
            if (this.Sql.GetSql("CASE.Diagnose.Delete.2", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, InpatientNO, happenNO.ToString(), temp);
            }
            catch
            {
                this.Err = "传入参数不对！CASE.Diagnose.Delete.2";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion 

        #region 删除一个患者的单条诊断信息
        ///<summary>
        /// 删除一个患者的单条诊断信息
        /// </summary>
        /// <param name="patientId">患者门诊号</param>
        /// <param name="icdCode">icdcode </param>
        /// <returns></returns>
        public int DeleteDiagnoseSingleForClinic(string patientId, string icdCode, string happenno)
        {
            string strSQL = "";
            if (this.Sql.GetSql("CASE.Diagnose.Delete.3", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, patientId, icdCode, happenno);
            }
            catch
            {
                this.Err = "传入参数不对！CASE.Diagnose.Delete.3";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion 

        #region 查询患者诊断信息
        /// <summary>
        /// 门诊使用，查询患者诊断信息
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="OperType"></param>
        /// <returns></returns>
        public ArrayList QueryCaseDiagnoseForClinic(string patientId, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType)
        {
            string strSQL = "";
            string temp = "";
            if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                temp = "1";
            }
            else if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                temp = "2";
            }
            else
            {
                this.Err = "没有指定插入的类型 DOC 或 CAS";
                return null;
            }
            string MainSql = QuerySql();
            if (MainSql == null)
            {
                return null;
            }
            if (this.Sql.GetSql("CASE.Diagnose.Select.2", ref strSQL) == -1) return null;
            strSQL = MainSql + strSQL;
            try
            {
                strSQL = string.Format(strSQL, patientId, temp);
            }
            catch
            {
                this.Err = "传入参数不对！CASE.Diagnose.Select.1";
                return null;
            }

            return this.myQuery(strSQL);
        }
        /// <summary>
        /// 获得病案诊断表中的患者诊断信息,针对已经有病案的患者查询 
        /// </summary>
        /// <param name="InpatientNO">住院流水号</param>
        /// <param name="diagType">诊断类型 门诊诊断，入院诊断等 查询所有的可以输入 %</param>
        /// <param name="OperType">"DOC"查询医生站录入的诊断信息 “CAS" 查询病案是录入的诊断信息</param>
        /// <returns>诊断信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Diagnose</returns>
        public ArrayList QueryCaseDiagnose(string InpatientNO, string diagType, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType)
        {
            string strSQL = "";
            string temp = "";
            if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                temp = "1";
            }
            else if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                temp = "2";
            }
            else
            {
                this.Err = "没有指定插入的类型 DOC 或 CAS";
                return null;
            }
            string MainSql = QuerySql();
            if (MainSql == null)
            {
                return null;
            }
            if (this.Sql.GetSql("CASE.Diagnose.Select.1", ref strSQL) == -1) return null;
            strSQL = MainSql + strSQL;
            try
            {
                strSQL = string.Format(strSQL, InpatientNO, diagType, temp);
            }
            catch
            {
                this.Err = "传入参数不对！CASE.Diagnose.Select.1";
                return null;
            }

            return this.myQuery(strSQL);
        }
        /// <summary>
        /// 查询主诊断
        /// </summary>
        /// <param name="InpatientNO">住院流水号 </param>
        /// <param name="IsMain">true 主诊断 false  非主诊断</param>
        /// <param name="OperType">DOC 查询医生录入的诊断,CAS 查询病案室整理后的诊断</param>
        /// <returns></returns>
        public ArrayList QueryMainDiagnose(string InpatientNO, bool IsMain, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType)
        {
            string strSQL = "";
            string MainFlag = "";
            if (IsMain)
            {
                MainFlag = "1";//主诊断
            }
            else
            {
                MainFlag = "0";//非主诊断 
            }
            string temp = "";
            if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC)
            {
                temp = "1";
            }
            else if (OperType == Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.CAS)
            {
                temp = "2";
            }
            else
            {
                this.Err = "没有指定插入的类型 DOC 或 CAS";
                return null;
            }
            string MainSql = QuerySql();
            if (MainSql == null)
            {
                return null;
            }
            if (this.Sql.GetSql("CASE.Diagnose.QueryMainDiagnose", ref strSQL) == -1) return null;
            strSQL = MainSql + strSQL;
            try
            {
                strSQL = string.Format(strSQL, InpatientNO, MainFlag, temp);
            }
            catch
            {
                this.Err = "传入参数不对！CASE.Diagnose.Select.1";
                return null;
            }

            return this.myQuery(strSQL);
        }
        #endregion 

        #region 获取最大的发生序号
        /// <summary>
        /// 获取最大的发生序号
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <returns></returns>
        public int GetMaxHappenNum(string InpatientNo)
        {
            string strSQL = "";

            if (this.Sql.GetSql("CASE.Diagnose.GetMaxHappenNum", ref strSQL) == -1) return -1;

            try
            {
                strSQL = string.Format(strSQL, InpatientNo);
            }
            catch
            {
                this.Err = "传入参数不对！CASE.Diagnose.GetMaxHappenNum";
                return -1;
            }

            //返回最大的发生序号
            return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strSQL));
        }
        #endregion 

        #region 私有函数 
        private string QuerySql()
        {
            string strSQL = "";
            if (this.Sql.GetSql("CASE.Diagnose.Select.QuerySql", ref strSQL) == -1) return null;
            return strSQL;
        }
        #endregion 
     
        #region 判断输入诊断是否合乎规则
        /// <summary>
        /// 判断输入诊断是否合乎规则 
        /// 程序出错  返回 null
        /// 完全合乎规则,没有提示 list.Count == 0 
        ///  User01 =1 存在遗漏的附加诊断 ,必须输入
        ///  User01 = 2 存在可能遗漏的诊断 ,可输可不输
        /// </summary>
        /// <param name="list">要检测的项目列表</param>
        /// <param name="SexType">性别</param>
        /// <returns> 程序出错  返回 null ;list.Count == 0 完全合乎规则,没有提示 ;User01 =1  缺少必须的诊断或组合错误 不允许通过;User01 = 2 存在可能遗漏的诊断 ,可输可不输 </returns>
        public ArrayList QueryDiagnoseValueState(ArrayList list, Neusoft.HISFC.Models.Base.EnumSex SexType)
        {
            if (list == null)
            {
                return null;
            }
            ArrayList SexTypeList = null;
            ICD icd = new ICD();
            //判断男女性诊断是否混用
            if (SexType.ToString() == "M")
            {
                //查询专用于女性的诊断列表
                SexTypeList = icd.QueryDiagnoseBySex("F");
                if (SexTypeList == null)
                {
                    return null;
                }
            }
            else if (SexType.ToString() == "F")
            {
                //查询专用于男性的诊断 列表
                SexTypeList = icd.QueryDiagnoseBySex("M");
                if (SexTypeList == null)
                {
                    this.Err = "获取男性诊断列表出错";
                    return null;
                }
            }
            //返回的数组
            ArrayList Returnlist = new ArrayList();
            foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in list)
            {
                if (obj.DiagInfo.ICD10.ID.Length < 3)
                {
                    continue;
                }
                if (obj.DiagInfo.ICD10.ID.Length >= 6) //肿瘤形态学除外 
                {
                    string str = obj.DiagInfo.ICD10.ID.Substring(0, 6);
                    if (str.CompareTo("M80000") >= 0 && str.CompareTo("M99890") <= 0)
                    {
                        continue;
                    }
                }
                Neusoft.HISFC.Models.HealthRecord.Diagnose info = null;
                string strCode = obj.DiagInfo.ICD10.ID.Substring(0, 3);

                if (strCode.CompareTo("A00") >= 0 && strCode.CompareTo("R99") <= 0)
                {
                    bool boolTemp = true;
                    //判断list中是否有 V或W或X或Y开头表示损伤或中毒的外因码  如果没有 添加到提示数组中 
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 1);
                        if (strFirst.CompareTo("V") == 0 || strFirst.CompareTo("W") == 0 || strFirst.CompareTo("X") == 0 || strFirst.CompareTo("Y") == 0)
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp) //如果没有 V或W或X或Y开头表示损伤或中毒的外因码
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "1"; //可能需要添加的 
                        info.User02 = "可能需要添加V或W或X或Y开头表示损伤或中毒的外因码";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                else if (strCode.CompareTo("S00") >= 0 && strCode.CompareTo("T98") <= 0)
                {
                    bool boolTemp = true;
                    //判断list中是否有 V或W或X或Y开头表示损伤或中毒的外因码  如果没有 添加到提示数组中 
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 1);
                        if (strFirst.CompareTo("V") == 0 || strFirst.CompareTo("W") == 0 || strFirst.CompareTo("X") == 0 || strFirst.CompareTo("Y") == 0)
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp)
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "2"; //必须添加的 
                        info.User02 = "必须添加V或W或X或Y开头表示损伤或中毒的外因码";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                if (strCode.CompareTo("C00") >= 0 && strCode.CompareTo("D48") <= 0)
                {
                    if (strCode.CompareTo("C00") >= 0 && strCode.CompareTo("C96") <= 0)
                    {
                        bool boolTemp = true;
                        //C00 - C96 提示附加M80000/3 - M99890/3
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/3") >= 0 && strFirst.CompareTo("M99890/3") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加 M80000/3 - M99890/3 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }

                    }
                    if (strCode.CompareTo("C77") >= 0 && strCode.CompareTo("C79") <= 0)
                    {
                        bool boolTemp = true;
                        //C77 - C79 提示附加M80000/6 - M99890/6 
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/6") >= 0 && strFirst.CompareTo("M99890/6") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加 M80000/6 - M99890/6 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                    if (strCode.CompareTo("D00") >= 0 && strCode.CompareTo("D09") <= 0)
                    {
                        bool boolTemp = true;
                        //D00 - D09 提示附加M80000/2 - M99890/2 
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/2") >= 0 && strFirst.CompareTo("M99890/2") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加 M80000/2 - M99890/2 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                    if (strCode.CompareTo("D10") >= 0 && strCode.CompareTo("D36") <= 0)
                    {
                        bool boolTemp = true;
                        //D10- D36 提示附加 M80000/0 - M99890/0 
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/0") >= 0 && strFirst.CompareTo("M99890/0") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加 M80000/0 - M99890/0 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                    if (strCode.CompareTo("D37") >= 0 && strCode.CompareTo("D48") <= 0)
                    {
                        bool boolTemp = true;
                        //D37- D48 提示附加M80000/1 - M99890/1 
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/1") >= 0 && strFirst.CompareTo("M99890/1") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加M80000/1 - M99890/1 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                }
                else if (strCode.CompareTo("080") == 0 && obj.MainFlag == "1")
                {
                    // 如果是080 是主诊断 , 010 - 099 不能出现在附加诊断中
                    bool boolTemp = true;
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 3);
                        if (strFirst.CompareTo("010") >= 0 && strFirst.CompareTo("099") <= 0 && obj.MainFlag == "0")
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp)
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "2"; //必须添加的 
                        info.User02 = "080 是主诊断 , 010 - 099 不能出现在附加诊断中 ";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                else if (strCode.CompareTo("010") >= 0 && strCode.CompareTo("099") >= 0 && obj.MainFlag == "1")
                {
                    bool boolTemp = true;
                    // 如果是　010 - 099　是主诊断 , 080　不能出现在附加诊断中
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 3);
                        if (strFirst.CompareTo("080") >= 0 && obj.MainFlag == "0")
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp)
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "2"; //必须添加的 
                        info.User02 = " 010 - 099　是主诊断 , 080　不能出现在附加诊断中 ";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                //判断男女性诊断是否混用
                if (SexType.ToString() == "M")
                {
                    //判断是否有
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in SexTypeList)
                    {
                        if (temp.DiagInfo.ICD10.ID == obj.DiagInfo.ICD10.ID)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = " 女性的诊断不能用于男性  ";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                }
                else if (SexType.ToString() == "F")
                {
                    //判断是否有
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in SexTypeList)
                    {
                        if (temp.DiagInfo.ICD10.ID == obj.DiagInfo.ICD10.ID)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = " 男性的诊断不能用于女性  ";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                }
                if (strCode.CompareTo("010") >= 0 && strCode.CompareTo("099") <= 0)
                {
                    bool boolTemp = true;
                    //输入 010  - 099 必须附加Z31 - Z37 编码 
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 3);
                        if (strFirst.CompareTo("Z31") >= 0 && strFirst.CompareTo("Z37") <= 0)
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp)
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "2"; //必须添加的 
                        info.User02 = " 010 - 099　是主诊断 , 080　不能出现在附加诊断中 ";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                else if (strCode.CompareTo("003") >= 0 && strCode.CompareTo("008") <= 0)
                {
                    //如果婴儿死亡天数超过22天需要提示医生输入 P95编码
                    info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                    info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                    info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                    info.User01 = "1"; //可选的 
                    info.User02 = " 如果婴儿死亡天数超过22天,需要输入 P95编码  ";//提示的信息
                    Returnlist.Add(info);
                }
                else if (strCode.CompareTo("B95") >= 0 && strCode.CompareTo("B97") <= 0 && obj.MainFlag == "1")
                {
                    //B95 - B97 不能作为出院主诊断 
                    info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                    info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                    info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                    info.User01 = "2"; //必须添加的 
                    info.User02 = " B95 - B97 不能作为出院主诊断  ";//提示的信息
                    Returnlist.Add(info);
                }
                else if (strCode.CompareTo("J98.401") == 0)
                {
                    //提示有无细菌学很痰培养 如果属于阳性需要输入 J12 - J17 疾病编码 
                    info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                    info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                    info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                    info.User01 = "1"; //可选的 
                    info.User02 = " 如果细菌学或痰培养且结果逞阳性,需要输入J12 - J17编码  ";//提示的信息
                    Returnlist.Add(info);
                }
            }
            return Returnlist;
        }
        #endregion 

        #region 获取第一诊断
        /// <summary>
        /// 获取第一诊断
        /// </summary>
        /// <param name="InpatienNo"></param>
        /// <param name="diagType"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.HealthRecord.Diagnose GetFirstDiagnose(string InpatienNo, Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType diagType, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes frmType)
        {
            string strSql1 = "";
            Neusoft.HISFC.Models.HealthRecord.Diagnose info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
            string MainSql = QuerySql();
            if (MainSql == null)
            {
                return null;
            }
            try
            {
                ArrayList list = new ArrayList();
                if (this.Sql.GetSql("CASE.Diagnose.GetFirstDiagnose.FIRST", ref strSql1) == -1) return null;
                strSql1 = MainSql + strSql1;
                string str = "";
                if (frmType == frmTypes.CAS)
                {
                    str = "2";
                }
                else if (frmType == frmTypes.DOC)
                {
                    str = "1";
                }
                //获取索引值
                int i = (int)diagType;
                strSql1 = string.Format(strSql1, InpatienNo, i.ToString(), str);
                list = myQuery(strSql1);
                if (list == null)
                {
                    return null;
                }
                if (list.Count > 0)
                {
                    info = (Neusoft.HISFC.Models.HealthRecord.Diagnose)list[0];
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            return info;
        }

        #endregion

        #region 私有函数
        /// <summary>
        /// 从实体中获取数据形成数组
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        private string[] myGetItemParm(Neusoft.HISFC.Models.HealthRecord.Diagnose Item)
        {

            string[] strParm = new string[23];
            string IsMain = "";
            if (Item.DiagInfo.IsMain)
            {
                IsMain = "1";
            }
            else
            {
                IsMain = "0";
            }
            strParm[0] = Item.DiagInfo.Patient.ID; // 住院流水号
            strParm[1] = Item.DiagInfo.HappenNo.ToString(); //发生序号
            strParm[2] = Item.DiagInfo.DiagType.ID; // 诊断类型 
            strParm[3] = Item.LevelCode;//诊断级别 
            strParm[4] = Item.PeriorCode;// 诊断分期 
            strParm[5] = Item.DiagInfo.ICD10.ID;// 诊断ICD码        
            strParm[6] = Item.DiagInfo.ICD10.Name;// 诊断名称        
            strParm[7] = Item.DiagInfo.DiagDate.ToString();// 诊断日期
            strParm[8] = Item.DiagInfo.Doctor.ID;// 医师代号
            strParm[9] = Item.DiagInfo.Doctor.Name;// 医师姓名(诊断)
            strParm[10] = Item.Pvisit.InTime.ToString();//入院日期 
            strParm[11] = Item.Pvisit.OutTime.ToString();//出院日期 
            strParm[12] = Item.DiagOutState;//治疗情况 0 治愈1 好转 2 未愈3 死亡 4 其他
            strParm[13] = Item.SecondICD;//第二ICD    
            strParm[14] = Item.SynDromeID;// 并发症类别   
            strParm[15] = Item.CLPA;//病理符合
            strParm[16] = Item.DubDiagFlag;//是否疑诊     
            strParm[17] = IsMain;//是否主诊断 1 主诊断 0 其他诊断             
            strParm[18] = Item.Memo;//备注  
            strParm[19] = Item.ID;//操作员 
            strParm[20] = Item.OperType;//类别 1 医生站录入诊断  2 病案室录入诊断
            strParm[21] = Item.OperationFlag;// 手术标志 1 有手术 0 没有手术  
            strParm[22] = Item.Is30Disease; //是否是30种疾病

            return strParm;
        }

        /// <summary>
        /// 从 reader中读取数据
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        private ArrayList myQuery(string strSQL)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.Diagnose dg;

            this.ExecQuery(strSQL);

            try
            {
                while (this.Reader.Read())
                {
                    dg = new Neusoft.HISFC.Models.HealthRecord.Diagnose();

                    dg.DiagInfo.Patient.ID = this.Reader[0].ToString();//住院流水号
                    dg.DiagInfo.Patient.PID.ID = this.Reader[0].ToString();
                    dg.DiagInfo.HappenNo = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());//发生序号
                    dg.DiagInfo.DiagType.ID = this.Reader[2].ToString();//诊断类型
                    dg.LevelCode = this.Reader[3].ToString();//诊断级别
                    dg.PeriorCode = this.Reader[4].ToString();//诊断分期
                    dg.DiagInfo.ICD10.ID = this.Reader[5].ToString();//诊断ICD码
                    dg.DiagInfo.ICD10.Name = this.Reader[6].ToString();//诊断名称
                    dg.DiagInfo.DiagDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString());//诊断日期
                    dg.DiagInfo.Doctor.ID = this.Reader[8].ToString();//医师代号
                    dg.DiagInfo.Doctor.Name = this.Reader[9].ToString();//医师姓名
                    dg.Pvisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());//入院日期
                    dg.Pvisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11].ToString());//出院日期
                    dg.DiagOutState = this.Reader[12].ToString();
                    dg.SecondICD = this.Reader[13].ToString();//第二ICD
                    dg.SynDromeID = this.Reader[14].ToString();//并发症类别
                    dg.CLPA = this.Reader[15].ToString();//病理符合
                    dg.DubDiagFlag = this.Reader[16].ToString();//是否疑诊
                    dg.DiagInfo.IsMain = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[17].ToString());//是否主诊断
                    dg.Memo = this.Reader[18].ToString();//备注
                    dg.ID = this.Reader[19].ToString();//操作员
                    dg.OperInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[20].ToString());//操作时间
                    dg.OperType = this.Reader[21].ToString(); // 1 医生站录入 2 病案室录入
                    dg.OperationFlag = this.Reader[22].ToString(); //手术标志
                    dg.Is30Disease = this.Reader[23].ToString(); // 30种疾病
                    al.Add(dg);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = "获得病案诊断信息出错![com_cas_diagnose]" + ex.Message;
                this.WriteErr();
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
            }

            this.Reader.Close();

            return al;
        }
        #endregion

        /// <summary>
        /// 判断该诊断是否是传染病诊断
        /// </summary>
        /// <param name="ICDCode"></param>
        /// <returns></returns>
        public string IsInfect(string ICDCode)
        {
            string strSql = "";
            string result = "";
            if (this.Sql.GetSql("Case.Diagnose.IsInfect", ref strSql) == -1)
            {
                return "Error";
            }
            strSql = string.Format(strSql, ICDCode);
            if (this.ExecQuery(strSql) == -1)
                return "Error";
            while (this.Reader.Read())
            {
                try
                {
                    result = this.Reader[0].ToString();
                }
                catch
                {
                    return "Error";
                }
            }
            return result;
        }
        #endregion

        //{8BC09475-C1D9-4765-918B-299E21E04C74} 诊断录入增加医生站、门诊医生站、病案室属性
        #region 医生站录入诊断用 存表met_com_diagnose

        /// <summary>
        /// 查询患者诊断,不包括手术诊断
        /// </summary>
        /// <param name="InPatientNo"></param>
        /// <returns></returns> 
        public ArrayList QueryDiagnoseNoOps(string InPatientNo)
        {
            #region 接口说明
            //RADT.Diagnose.PatientDiagnoseQuery.1
            //传入：住院流水号
            //传出：患者诊断信息
            #endregion
            ArrayList al = new ArrayList();
            string sql1 = "", sql2 = "";

            sql1 = PatientQuerySelect();
            if (sql1 == null)
                return null;

            if (this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.5", ref sql2) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.PatientDiagnoseQuery.5字段!";
                this.ErrCode = "-1";
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, InPatientNo);
            return this.myPatientQuery(sql1);
        }

        /// 查询患者诊断信息的select语句（无where条件）
        private string PatientQuerySelect()
        {
            #region 接口说明
            //RADT.Diagnose.DiagnoseQuery.select.1
            //传入：0
            //传出：sql.select
            #endregion
            string sql = "";
            if (this.Sql.GetSql("RADT.Diagnose.DiagnoseQuery.select.1", ref sql) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.DiagnoseQuery.select.1字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            return sql;
        }

        //私有函数，查询患者基本信息 
        private ArrayList myPatientQuery(string SQLPatient)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.Diagnose Diagnose;
            this.ProgressBarText = "正在查询患者诊断...";
            this.ProgressBarValue = 0;

            this.ExecQuery(SQLPatient);
            try
            {
                while (this.Reader.Read())
                {
                    Diagnose = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                    Diagnose.DiagInfo.Patient.ID = this.Reader[0].ToString();// 住院流水号

                    Diagnose.DiagInfo.HappenNo = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());//  发生序号

                    Diagnose.DiagInfo.Patient.PID.CardNO = this.Reader[2].ToString();//病历号

                    Diagnose.DiagInfo.DiagType.ID = this.Reader[3].ToString();//诊断类别
                    //Neusoft.HISFC.Models.HealthRecord.DiagnoseType diagnosetype = new Neusoft.HISFC.Models.HealthRecord.DiagnoseType();
                    //diagnosetype.ID = Diagnose.DiagType.ID;
                    //Diagnose.DiagType.Name = diagnosetype.Name;//获得诊断名称 zjy

                    Diagnose.DiagInfo.ID = this.Reader[4].ToString();		//诊断代码
                    Diagnose.DiagInfo.ICD10.ID = this.Reader[4].ToString();
                    Diagnose.DiagInfo.Name = this.Reader[5].ToString();		//诊断名称
                    Diagnose.DiagInfo.ICD10.Name = this.Reader[5].ToString();

                    Diagnose.DiagInfo.DiagDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());

                    Diagnose.DiagInfo.Doctor.ID = this.Reader[7].ToString();

                    Diagnose.DiagInfo.Doctor.Name = this.Reader[8].ToString();

                    Diagnose.DiagInfo.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[9]);

                    Diagnose.DiagInfo.Dept.ID = this.Reader[10].ToString();

                    Diagnose.DiagInfo.IsMain = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[11]);

                    Diagnose.DiagInfo.Memo = this.Reader[12].ToString();

                    Diagnose.DiagInfo.User01 = this.Reader[13].ToString();
                    Diagnose.DiagInfo.User02 = this.Reader[14].ToString();

                    //手术序号
                    Diagnose.DiagInfo.OperationNo = this.Reader[15].ToString();

                    al.Add(Diagnose);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得患者诊断信息出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            this.Reader.Close();

            this.ProgressBarValue = -1;
            return al;
        }

        #region 私有函数，查询患者基本信息 -- 已重写屏蔽
        //私有函数，查询患者基本信息
        //private ArrayList myPatientQuery(string SQLPatient)
        //{
        //    ArrayList al = new ArrayList();
        //    Neusoft.HISFC.Models.HealthRecord.DiagnoseBase Diagnose;
        //    this.ProgressBarText = "正在查询患者诊断...";
        //    this.ProgressBarValue = 0;

        //    this.ExecQuery(SQLPatient);
        //    try
        //    {
        //        while (this.Reader.Read())
        //        {
        //            Diagnose = new Neusoft.HISFC.Models.HealthRecord.DiagnoseBase();
        //            Diagnose.Patient.ID = this.Reader[0].ToString();// 住院流水号

        //            Diagnose.HappenNo = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());//  发生序号

        //            Diagnose.Patient.PID.CardNO = this.Reader[2].ToString();//病历号

        //            Diagnose.DiagType.ID = this.Reader[3].ToString();//诊断类别
        //            //Neusoft.HISFC.Models.HealthRecord.DiagnoseType diagnosetype = new Neusoft.HISFC.Models.HealthRecord.DiagnoseType();
        //            //diagnosetype.ID = Diagnose.DiagType.ID;
        //            //Diagnose.DiagType.Name = diagnosetype.Name;//获得诊断名称 zjy

        //            Diagnose.ID = this.Reader[4].ToString();		//诊断代码
        //            Diagnose.ICD10.ID = this.Reader[4].ToString();
        //            Diagnose.Name = this.Reader[5].ToString();		//诊断名称
        //            Diagnose.ICD10.Name = this.Reader[5].ToString();

        //            Diagnose.DiagDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());

        //            Diagnose.Doctor.ID = this.Reader[7].ToString();

        //            Diagnose.Doctor.Name = this.Reader[8].ToString();

        //            Diagnose.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[9]);

        //            Diagnose.Dept.ID = this.Reader[10].ToString();

        //            Diagnose.IsMain = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[11]);

        //            Diagnose.Memo = this.Reader[12].ToString();

        //            Diagnose.User01 = this.Reader[13].ToString();
        //            Diagnose.User02 = this.Reader[14].ToString();

        //            //手术序号
        //            Diagnose.OperationNo = this.Reader[15].ToString();

        //            al.Add(Diagnose);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Err = "获得患者诊断信息出错！" + ex.Message;
        //        this.ErrCode = "-1";
        //        this.WriteErr();
        //        return null;
        //    }
        //    this.Reader.Close();

        //    this.ProgressBarValue = -1;
        //    return al;
        ////} 
        #endregion

        #region 更新患者诊断信息
        /// <summary>
        /// 更新患者诊断信息
        /// </summary>
        /// <param name="Diagnose"></param>
        /// <returns></returns>
        public int UpdatePatientDiagnose(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase Diagnose)
        {
            #region "接口说明"
            //接口名称 RADT.Diagnose.UpdatePatientDiagnose.1
            // 0  --住院流水号, 1 --发生序号      2   --病历号   ,     3   --诊断类别  ,4   --诊断编码 
            // 5  --诊断名称,   6   --诊断时间   ,7   --诊断医生编码  ,8   --医生名称 , 9   --是否有效
            // 10 --诊断科室ID 11   --是否主诊断 12   --备注          13   --操作员    14   --操作时间
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("RADT.Diagnose.UpdatePatientDiagnose.1", ref strSql) == -1)
                return -1;

            try
            {
                string[] s = new string[15];
                try
                {
                    s[0] = Diagnose.Patient.ID.ToString();// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[1] = Diagnose.HappenNo.ToString();//  --发生序号
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[2] = Diagnose.Patient.PID.CardNO;// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[3] = Diagnose.DiagType.ID.ToString();//  --诊断类别
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[4] = Diagnose.ID.ToString();// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[5] = Diagnose.Name;//.Replace("'","''");//--诊断名称
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[6] = Diagnose.DiagDate.ToString();//  --诊断时间
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[7] = Diagnose.Doctor.ID.ToString();//    --诊断医生
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[8] = Diagnose.Doctor.Name;//    --诊断医生
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[9] = (System.Convert.ToInt16(Diagnose.IsValid)).ToString();//    --是否有效
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[10] = Diagnose.Dept.ID.ToString();//  --诊断科室
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[11] = (System.Convert.ToInt16(Diagnose.IsMain)).ToString();//  --是否主诊断
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }

                try
                {
                    s[12] = Diagnose.Memo;//    --备注
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[13] = this.Operator.ID.ToString();//    --操作人
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[14] = this.GetSysDateTime().ToString();//    --操作人
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                //				strSql=string.Format(strSql,s);
                return this.ExecNoQuery(strSql, s);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

        }

        /// <summary>
        /// 更新患者诊断信息
        /// </summary>
        /// <param name="Diagnose"></param>
        /// <returns></returns> 
        public int UpdatePatientDiagnose(Neusoft.HISFC.Models.HealthRecord.Diagnose Diagnose)
        {
            #region "接口说明"
            //接口名称 RADT.Diagnose.UpdatePatientDiagnose.1
            // 0  --住院流水号, 1 --发生序号      2   --病历号   ,     3   --诊断类别  ,4   --诊断编码 
            // 5  --诊断名称,   6   --诊断时间   ,7   --诊断医生编码  ,8   --医生名称 , 9   --是否有效
            // 10 --诊断科室ID 11   --是否主诊断 12   --备注          13   --操作员    14   --操作时间
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("RADT.Diagnose.UpdatePatientDiagnose.1", ref strSql) == -1)
                return -1;

            try
            {
                string[] s = new string[15];
                try
                {
                    s[0] = Diagnose.DiagInfo.Patient.ID.ToString();// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[1] = Diagnose.DiagInfo.HappenNo.ToString();//  --发生序号
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[2] = Diagnose.DiagInfo.Patient.PID.CardNO;// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[3] = Diagnose.DiagInfo.DiagType.ID.ToString();//  --诊断类别
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[4] = Diagnose.DiagInfo.ICD10.ID.ToString();// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[5] = Diagnose.DiagInfo.ICD10.Name;//.Replace("'","''");//--诊断名称
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[6] = Diagnose.DiagInfo.DiagDate.ToString();//  --诊断时间
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[7] = Diagnose.DiagInfo.Doctor.ID.ToString();//    --诊断医生
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[8] = Diagnose.DiagInfo.Doctor.Name;//    --诊断医生
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[9] = (System.Convert.ToInt16(Diagnose.DiagInfo.IsValid)).ToString();//    --是否有效
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[10] = Diagnose.DiagInfo.Dept.ID.ToString();//  --诊断科室
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[11] = (System.Convert.ToInt16(Diagnose.DiagInfo.IsMain)).ToString();//  --是否主诊断
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }

                try
                {
                    s[12] = Diagnose.DiagInfo.Memo;//    --备注
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[13] = this.Operator.ID.ToString();//    --操作人
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[14] = this.GetSysDateTime().ToString();//    --操作人
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                //				strSql=string.Format(strSql,s);
                return this.ExecNoQuery(strSql, s);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

        }

        #endregion

        #region 登记患者诊断信息
        /// <summary>
        /// 登记新的患者诊断
        /// </summary>
        /// <param name="Diagnose"></param>
        /// <returns></returns>
        public int CreatePatientDiagnose(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase Diagnose)
        {
            #region "接口说明"
            //接口名称 RADT.Diagnose.CreatePatientDiagnose.1
            // 0  --住院流水号, 1 --发生序号      2   --病历号   ,     3   --诊断类别  ,4   --诊断编码 
            // 5  --诊断名称,   6   --诊断时间   ,7   --诊断医生编码  ,8   --医生名称 , 9   --是否有效
            // 10 --诊断科室ID 11   --是否主诊断 12   --备注          13   --操作员    14   --操作时间
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("RADT.Diagnose.CreatePatientDiagnose.1", ref strSql) == -1)
                return -1;
            string[] s = new string[16];
            try
            {

                try
                {
                    s[0] = Diagnose.Patient.ID.ToString();// --患者住院流水号
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[1] = Diagnose.HappenNo.ToString();//  --发生序号
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[2] = Diagnose.Patient.PID.CardNO;// --就诊卡号
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[3] = Diagnose.DiagType.ID.ToString();//  --诊断类别
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[4] = Diagnose.ID.ToString();// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[5] = Diagnose.Name;//.Replace("'","''") ;//--诊断名称
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[6] = Diagnose.DiagDate.ToString();//  --诊断时间
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[7] = Diagnose.Doctor.ID.ToString();//    --诊断医生
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[8] = Diagnose.Doctor.Name;//    --诊断医生
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[9] = (System.Convert.ToInt16(Diagnose.IsValid)).ToString();//    --是否有效
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[10] = Diagnose.Dept.ID.ToString();//  --诊断科室
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[11] = (System.Convert.ToInt16(Diagnose.IsMain)).ToString();//  --是否主诊断
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }

                try
                {
                    s[12] = Diagnose.Memo;//    --备注
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[13] = this.Operator.ID.ToString();//    --操作人
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[14] = this.GetSysDateTime().ToString();//    --操作人
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                s[15] = Diagnose.OperationNo;//手术序号

                //				strSql=string.Format(strSql,s);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql, s);
        }

        /// <summary>
        /// 登记新的患者诊断
        /// </summary>
        /// <param name="Diagnose"></param>
        /// <returns></returns> 
        public int CreatePatientDiagnose(Neusoft.HISFC.Models.HealthRecord.Diagnose Diagnose)
        {
            #region "接口说明"
            //接口名称 RADT.Diagnose.CreatePatientDiagnose.1
            // 0  --住院流水号, 1 --发生序号      2   --病历号   ,     3   --诊断类别  ,4   --诊断编码 
            // 5  --诊断名称,   6   --诊断时间   ,7   --诊断医生编码  ,8   --医生名称 , 9   --是否有效
            // 10 --诊断科室ID 11   --是否主诊断 12   --备注          13   --操作员    14   --操作时间
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("RADT.Diagnose.CreatePatientDiagnose.1", ref strSql) == -1)
                return -1;
            string[] s = new string[16];
            s[0] = Diagnose.DiagInfo.Patient.ID.ToString();// --患者住院流水号 
            //s[1] = Diagnose.DiagInfo.HappenNo.ToString();//  --发生序号 
            s[1] = this.GetNewDignoseNo().ToString();//  --发生序号 
            s[2] = Diagnose.DiagInfo.Patient.PID.CardNO;// --就诊卡号 
            s[3] = Diagnose.DiagInfo.DiagType.ID.ToString();//  --诊断类别 
            s[4] = Diagnose.DiagInfo.ICD10.ID.ToString();// --诊断编码 
            s[5] = Diagnose.DiagInfo.ICD10.Name;//.Replace("'","''") ;//--诊断名称 
            s[6] = Diagnose.DiagInfo.DiagDate.ToString();//  --诊断时间 
            s[7] = Diagnose.DiagInfo.Doctor.ID.ToString();//    --诊断医生 
            s[8] = Diagnose.DiagInfo.Doctor.Name;//    --诊断医生 
            s[9] = (System.Convert.ToInt16(Diagnose.DiagInfo.IsValid)).ToString();//    --是否有效 
            s[10] = Diagnose.DiagInfo.Dept.ID.ToString();//  --诊断科室 
            s[11] = (System.Convert.ToInt16(Diagnose.DiagInfo.IsMain)).ToString();//  --是否主诊断 
            s[12] = Diagnose.DiagInfo.Memo;//    --备注 
            s[13] = this.Operator.ID.ToString();//    --操作人 
            s[14] = this.GetSysDateTime().ToString();//    --操作人 
            s[15] = Diagnose.DiagInfo.OperationNo;//手术序号 

            return this.ExecNoQuery(strSql, s);
        }

        /// <summary>
        /// 删除患者诊断信息
        /// </summary>
        /// <param name="InpatientNO"></param>
        /// <param name="happenNO"></param>
        /// <returns></returns>
        public int DeleteDiagnoseSingle(string InpatientNO, int happenNO)
        {

            string strSQL = "";

            if (this.Sql.GetSql("RADT.Diagnose.DeleteDocDiagnose.1", ref strSQL) == -1)
                return -1;
            try
            {
                strSQL = string.Format(strSQL, InpatientNO, happenNO.ToString());
            }
            catch
            {
                this.Err = "传入参数不对！RADT.Diagnose.DeleteDocDiagnose.1";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }

        #region 申请新诊断发生序号
        /// <summary>
        /// 申请新诊断发生序号
        /// </summary>
        /// <returns> 新申请的序号 错误时返回-1</returns>
        public int GetNewDignoseNo()
        {
            int lNewNo = -1;
            string strSql = "";
            if (this.Sql.GetSql("RADT.Diagnose.GetNewDiagnoseNo.1", ref strSql) == -1)
                return -1;
            if (strSql == null)
                return -1;
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
                this.WriteErr();
                ;
                return -1;
            }
            this.Reader.Close();
            return lNewNo;
        }
        #endregion

        #endregion

        #endregion

        #region 废弃  
        /// <summary>
        /// 判断输入诊断是否合乎规则 
        /// 程序出错  返回 null
        /// 完全合乎规则,没有提示 list.Count == 0 
        ///  User01 =1 存在遗漏的附加诊断 ,必须输入
        ///  User01 = 2 存在可能遗漏的诊断 ,可输可不输
        /// </summary>
        /// <param name="list">要检测的项目列表</param>
        /// <param name="SexType">性别</param>
        /// <returns> 程序出错  返回 null ;list.Count == 0 完全合乎规则,没有提示 ;User01 =1  缺少必须的诊断或组合错误 不允许通过;User01 = 2 存在可能遗漏的诊断 ,可输可不输 </returns>
        [Obsolete("废弃,用QueryDiagnoseValueState代替",true)]
        public ArrayList DiagnoseValueState(ArrayList list, Neusoft.HISFC.Models.Base.EnumSex SexType)
        {
            if (list == null)
            {
                return null;
            }
            ArrayList SexTypeList = null;
            ICD icd = new ICD();
            //判断男女性诊断是否混用
            if (SexType.ToString() == "M")
            {
                //查询专用于女性的诊断列表
                SexTypeList = icd.GetDiagnoseBySex("F");
                if (SexTypeList == null)
                {
                    return null;
                }
            }
            else if (SexType.ToString() == "F")
            {
                //查询专用于男性的诊断 列表
                SexTypeList = icd.GetDiagnoseBySex("M");
                if (SexTypeList == null)
                {
                    this.Err = "获取男性诊断列表出错";
                    return null;
                }
            }
            //返回的数组
            ArrayList Returnlist = new ArrayList();
            foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose obj in list)
            {
                if (obj.DiagInfo.ICD10.ID.Length < 3)
                {
                    continue;
                }
                if (obj.DiagInfo.ICD10.ID.Length >= 6) //肿瘤形态学除外 
                {
                    string str = obj.DiagInfo.ICD10.ID.Substring(0, 6);
                    if (str.CompareTo("M80000") >= 0 && str.CompareTo("M99890") <= 0)
                    {
                        continue;
                    }
                }
                Neusoft.HISFC.Models.HealthRecord.Diagnose info = null;
                string strCode = obj.DiagInfo.ICD10.ID.Substring(0, 3);

                if (strCode.CompareTo("A00") >= 0 && strCode.CompareTo("R99") <= 0)
                {
                    bool boolTemp = true;
                    //判断list中是否有 V或W或X或Y开头表示损伤或中毒的外因码  如果没有 添加到提示数组中 
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 1);
                        if (strFirst.CompareTo("V") == 0 || strFirst.CompareTo("W") == 0 || strFirst.CompareTo("X") == 0 || strFirst.CompareTo("Y") == 0)
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp) //如果没有 V或W或X或Y开头表示损伤或中毒的外因码
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "1"; //可能需要添加的 
                        info.User02 = "可能需要添加V或W或X或Y开头表示损伤或中毒的外因码";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                else if (strCode.CompareTo("S00") >= 0 && strCode.CompareTo("T98") <= 0)
                {
                    bool boolTemp = true;
                    //判断list中是否有 V或W或X或Y开头表示损伤或中毒的外因码  如果没有 添加到提示数组中 
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 1);
                        if (strFirst.CompareTo("V") == 0 || strFirst.CompareTo("W") == 0 || strFirst.CompareTo("X") == 0 || strFirst.CompareTo("Y") == 0)
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp)
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "2"; //必须添加的 
                        info.User02 = "必须添加V或W或X或Y开头表示损伤或中毒的外因码";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                if (strCode.CompareTo("C00") >= 0 && strCode.CompareTo("D48") <= 0)
                {
                    if (strCode.CompareTo("C00") >= 0 && strCode.CompareTo("C96") <= 0)
                    {
                        bool boolTemp = true;
                        //C00 - C96 提示附加M80000/3 - M99890/3
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/3") >= 0 && strFirst.CompareTo("M99890/3") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加 M80000/3 - M99890/3 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }

                    }
                    if (strCode.CompareTo("C77") >= 0 && strCode.CompareTo("C79") <= 0)
                    {
                        bool boolTemp = true;
                        //C77 - C79 提示附加M80000/6 - M99890/6 
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/6") >= 0 && strFirst.CompareTo("M99890/6") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加 M80000/6 - M99890/6 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                    if (strCode.CompareTo("D00") >= 0 && strCode.CompareTo("D09") <= 0)
                    {
                        bool boolTemp = true;
                        //D00 - D09 提示附加M80000/2 - M99890/2 
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/2") >= 0 && strFirst.CompareTo("M99890/2") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加 M80000/2 - M99890/2 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                    if (strCode.CompareTo("D10") >= 0 && strCode.CompareTo("D36") <= 0)
                    {
                        bool boolTemp = true;
                        //D10- D36 提示附加 M80000/0 - M99890/0 
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/0") >= 0 && strFirst.CompareTo("M99890/0") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加 M80000/0 - M99890/0 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                    if (strCode.CompareTo("D37") >= 0 && strCode.CompareTo("D48") <= 0)
                    {
                        bool boolTemp = true;
                        //D37- D48 提示附加M80000/1 - M99890/1 
                        foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                        {
                            if (temp.DiagInfo.ICD10.ID.Length >= 8)
                            {
                                string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 8);
                                if (strFirst.CompareTo("M80000/1") >= 0 && strFirst.CompareTo("M99890/1") <= 0)
                                {
                                    boolTemp = false;
                                    break;
                                }
                            }
                        }
                        if (boolTemp)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = "必须附加M80000/1 - M99890/1 肿瘤形态学编码";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                }
                else if (strCode.CompareTo("080") == 0 && obj.MainFlag == "1")
                {
                    // 如果是080 是主诊断 , 010 - 099 不能出现在附加诊断中
                    bool boolTemp = true;
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 3);
                        if (strFirst.CompareTo("010") >= 0 && strFirst.CompareTo("099") <= 0 && obj.MainFlag == "0")
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp)
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "2"; //必须添加的 
                        info.User02 = "080 是主诊断 , 010 - 099 不能出现在附加诊断中 ";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                else if (strCode.CompareTo("010") >= 0 && strCode.CompareTo("099") >= 0 && obj.MainFlag == "1")
                {
                    bool boolTemp = true;
                    // 如果是　010 - 099　是主诊断 , 080　不能出现在附加诊断中
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 3);
                        if (strFirst.CompareTo("080") >= 0 && obj.MainFlag == "0")
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp)
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "2"; //必须添加的 
                        info.User02 = " 010 - 099　是主诊断 , 080　不能出现在附加诊断中 ";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                //判断男女性诊断是否混用
                if (SexType.ToString() == "M")
                {
                    //判断是否有
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in SexTypeList)
                    {
                        if (temp.DiagInfo.ICD10.ID == obj.DiagInfo.ICD10.ID)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = " 女性的诊断不能用于男性  ";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                }
                else if (SexType.ToString() == "F")
                {
                    //判断是否有
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in SexTypeList)
                    {
                        if (temp.DiagInfo.ICD10.ID == obj.DiagInfo.ICD10.ID)
                        {
                            info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                            info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                            info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                            info.User01 = "2"; //必须添加的 
                            info.User02 = " 男性的诊断不能用于女性  ";//提示的信息
                            Returnlist.Add(info);
                        }
                    }
                }
                if (strCode.CompareTo("010") >= 0 && strCode.CompareTo("099") <= 0)
                {
                    bool boolTemp = true;
                    //输入 010  - 099 必须附加Z31 - Z37 编码 
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose temp in list)
                    {
                        string strFirst = temp.DiagInfo.ICD10.ID.Substring(0, 3);
                        if (strFirst.CompareTo("Z31") >= 0 && strFirst.CompareTo("Z37") <= 0)
                        {
                            boolTemp = false;
                            break;
                        }
                    }
                    if (boolTemp)
                    {
                        info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                        info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                        info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                        info.User01 = "2"; //必须添加的 
                        info.User02 = " 010 - 099　是主诊断 , 080　不能出现在附加诊断中 ";//提示的信息
                        Returnlist.Add(info);
                    }
                }
                else if (strCode.CompareTo("003") >= 0 && strCode.CompareTo("008") <= 0)
                {
                    //如果婴儿死亡天数超过22天需要提示医生输入 P95编码
                    info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                    info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                    info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                    info.User01 = "1"; //可选的 
                    info.User02 = " 如果婴儿死亡天数超过22天,需要输入 P95编码  ";//提示的信息
                    Returnlist.Add(info);
                }
                else if (strCode.CompareTo("B95") >= 0 && strCode.CompareTo("B97") <= 0 && obj.MainFlag == "1")
                {
                    //B95 - B97 不能作为出院主诊断 
                    info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                    info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                    info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                    info.User01 = "2"; //必须添加的 
                    info.User02 = " B95 - B97 不能作为出院主诊断  ";//提示的信息
                    Returnlist.Add(info);
                }
                else if (strCode.CompareTo("J98.401") == 0)
                {
                    //提示有无细菌学很痰培养 如果属于阳性需要输入 J12 - J17 疾病编码 
                    info = new Neusoft.HISFC.Models.HealthRecord.Diagnose();
                    info.DiagInfo.ICD10.ID = obj.DiagInfo.ICD10.ID; //诊断编码
                    info.DiagInfo.ICD10.Name = obj.DiagInfo.ICD10.Name; //诊断名称 
                    info.User01 = "1"; //可选的 
                    info.User02 = " 如果细菌学或痰培养且结果逞阳性,需要输入J12 - J17编码  ";//提示的信息
                    Returnlist.Add(info);
                }
            }
            return Returnlist;
        }
        #region  病案函数 彻底废弃
        /// <summary>
        /// 获取诊断类别 
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用常数维护",true)]
        public ArrayList GetDiagnoseList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode obj = new neusoft.HISFC.Object.Base.SpellCode();
            //#region  以前的
            ////			info.ID = "1";
            ////			info.Name = "主要诊断";
            ////			list.Add(info);
            ////
            ////			info = new neusoft.HISFC.Object.Base.SpellCode();
            ////			info.ID = "2";
            ////			info.Name = "其他诊断";
            ////			list.Add(info);
            ////
            ////			info = new neusoft.HISFC.Object.Base.SpellCode();
            ////			info.ID = "3";
            ////			info.Name = "并发症";
            ////			list.Add(info);
            ////
            ////			info = new neusoft.HISFC.Object.Base.SpellCode();
            ////			info.ID = "4";
            ////			info.Name = "院内感染";
            ////			list.Add(info);
            ////
            ////			info = new neusoft.HISFC.Object.Base.SpellCode();
            ////			info.ID = "5";
            ////			info.Name = "损伤";
            ////			list.Add(info);
            ////
            ////			info = new neusoft.HISFC.Object.Base.SpellCode();
            ////			info.ID = "6";
            ////			info.Name = "病理诊断";
            ////			list.Add(info);
            ////
            ////			info = new neusoft.HISFC.Object.Base.SpellCode();
            ////			info.ID = "7";
            ////			info.Name = "过敏药";
            ////			list.Add(info);
            ////
            ////			info = new neusoft.HISFC.Object.Base.SpellCode();
            ////			info.ID = "8";
            ////			info.Name = "新生儿疾病";
            ////			list.Add(info);
            ////
            ////			info = new neusoft.HISFC.Object.Base.SpellCode();
            ////			info.ID = "9";
            ////			info.Name = "新生儿院感";
            ////			list.Add(info);
            //#endregion
            //obj.ID = "1";
            //obj.Name = "入院诊断";
            //list.Add(obj);
            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "2";
            //obj.Name = "转入诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "3";
            //obj.Name = "出院诊断"; //这里跟医生站有区别，出院诊断对应 主要诊断
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "4";
            //obj.Name = "转出诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "5";
            //obj.Name = "确诊诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "6";
            //obj.Name = "死亡诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "7";
            //obj.Name = "术前诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "8";
            //obj.Name = "术后诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "9";
            //obj.Name = "感染诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "10";
            //obj.Name = "损伤中毒诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "12";
            //obj.Name = "病理诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "13";
            //obj.Name = "抢救诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "14";
            //obj.Name = "门诊诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "15";
            //obj.Name = "其他诊断";
            //list.Add(obj);

            //obj = new neusoft.HISFC.Object.Base.SpellCode();
            //obj.ID = "16";
            //obj.Name = "结算诊断";
            //list.Add(obj);
            ////
            ////			obj = new neusoft.HISFC.Object.Base.SpellCode();
            ////			obj.ID = "17";
            ////			obj.Name = "其他诊断";
            ////			list.Add(obj);

            return list;
        }

        /// <summary>
        /// 诊断中操作的类型
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用常数 OPERATIONTYPE 维护", true)]
        public ArrayList GetDiagOperType()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "0";
            //info.Name = "无";
            //info.Spell_Code = "w";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "手术";
            //info.Spell_Code = "ss";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "操作";
            //info.Spell_Code = "cz";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "全部";
            //info.Spell_Code = "qb";
            //list.Add(info);

            return list;
        }
        #endregion 


        #region 非病案函数 暂时废弃 ，如果有人用再启用
        #region 诊断业务  暂时废弃  诊断没有向 met_com_diagnose中存数据直接存到 met_cas_diagnose

        #region 作废患者诊断信息
        /// <summary>
        /// 作废患者诊断信息
        /// </summary>
        /// <param name="Diagnose"></param>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public int DcPatientDiagnose(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase Diagnose)
        {
            #region 接口说明
            //作废患者诊断信息
            //RADT.Diagnose.DcPatientDiagnose.1
            //传入：0 InpatientNo住院流水号,1 happenno 发生序号
            //传出：0 
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("RADT.Diagnose.DcPatientDiagnose.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, Diagnose.Patient.ID, Diagnose.HappenNo.ToString());
            }
            catch
            {
                this.Err = "传入参数不对！RADT.Diagnose.DcPatientDiagnose.1";
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        #endregion
        #endregion

        #region "查询功能" 暂时废弃
        #region "查询患者诊断"
        /// <summary>
        /// 查询患者所有诊断
        /// </summary>
        /// <param name="InPatientNo"></param>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public ArrayList PatientDiagnoseQuery(string InPatientNo)
        {
            #region 接口说明
            //RADT.Diagnose.PatientDiagnoseQuery.1
            //传入：住院流水号
            //传出：患者诊断信息
            #endregion
            ArrayList al = new ArrayList();
            string sql1 = "", sql2 = "";

            sql1 = PatientQuerySelect();
            if (sql1 == null) return null;

            if (this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.1", ref sql2) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.PatientDiagnoseQuery.1字段!";
                this.ErrCode = "-1";
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, InPatientNo);
            return this.myPatientQuery(sql1);
        }
        /// <summary>
        /// 查询患者各类型诊断
        /// </summary>
        /// <param name="InPatientNo"></param>
        /// <param name="DiagType"></param>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public ArrayList PatientDiagnoseQuery(string InPatientNo, string DiagType)
        {
            #region 接口说明
            //RADT.Diagnose.PatientDiagnoseQuery.2
            //传入：住院流水号
            //传出：患者诊断信息
            #endregion
            ArrayList al = new ArrayList();
            string sql1 = "", sql2 = "";

            sql1 = PatientQuerySelect();
            if (sql1 == null) return null;

            if (this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.2", ref sql2) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.PatientDiagnoseQuery.2字段!";
                this.ErrCode = "-1";
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, InPatientNo, DiagType);
            return this.myPatientQuery(sql1);
        }
        /// <summary>
        /// 查询患者各状态诊断
        /// </summary>
        /// <param name="InPatientNo"></param>
        /// <param name="IsValid"></param>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public ArrayList PatientDiagnoseQuery(string InPatientNo, bool IsValid)
        {
            #region 接口说明
            //RADT.Diagnose.PatientDiagnoseQuery.3
            //传入：住院流水号
            //传出：患者诊断信息
            #endregion
            ArrayList al = new ArrayList();
            string sql1 = "", sql2 = "";

            sql1 = PatientQuerySelect();
            if (sql1 == null) return null;

            if (this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.3", ref sql2) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.PatientDiagnoseQuery.3字段!";
                this.ErrCode = "-1";
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, InPatientNo, Neusoft.FrameWork.Function.NConvert.ToInt32(IsValid).ToString());
            return this.myPatientQuery(sql1);
        }
        /// <summary>
        /// 查询患者主/非主诊断
        /// </summary>
        /// <param name="InPatientNo"></param>
        /// <param name="IsMain"></param>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public ArrayList MainDiagnoseQuery(string InPatientNo, bool IsMain)
        {
            #region 接口说明
            //RADT.Diagnose.PatientDiagnoseQuery.4
            //传入：0住院流水号1 是否主诊断
            //传出：患者诊断信息
            #endregion
            ArrayList al = new ArrayList();
            string sql1 = "", sql2 = "";

            sql1 = PatientQuerySelect();
            if (sql1 == null) return null;

            if (this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.4", ref sql2) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.PatientDiagnoseQuery.4字段!";
                this.ErrCode = "-1";
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, InPatientNo, IsMain.ToString());
            return this.myPatientQuery(sql1);
        }

        #endregion
   
        #endregion

        #region 获取诊断类别信息 列表  病案首页 诊断信息录入专用 注意跟手术室用的诊断类别不是一个
        /// <summary> 
        /// 获取诊断类别信息 列表  病案首页 诊断信息录入专用 
        /// creator :zhangjunyi@neusoft.com
        /// </summary>
        /// <returns>诊断类别列表</returns>
        [Obsolete("废弃", true)]
        public ArrayList getList()
        {
            ArrayList list = new ArrayList();
            //Neusoft.HISFC.Models.Base.Const obj = new Neusoft.HISFC.Models.Base.Const();

            //obj.ID = "2";
            //obj.Name = "转入诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "3";
            //obj.Name = "主要诊断"; //这里跟医生站有区别，出院诊断对应 主要诊断
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "4";
            //obj.Name = "转出诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "5";
            //obj.Name = "确诊诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "6";
            //obj.Name = "死亡诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "7";
            //obj.Name = "术前诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "8";
            //obj.Name = "术后诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "9";
            //obj.Name = "感染诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "10";
            //obj.Name = "损伤中毒诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "12";
            //obj.Name = "病理诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "13";
            //obj.Name = "抢救诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "14";
            //obj.Name = "门诊诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "15";
            //obj.Name = "其他诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "16";
            //obj.Name = "结算诊断";
            //list.Add(obj);

            //obj = new Neusoft.HISFC.Models.Base.Const();
            //obj.ID = "17";
            //obj.Name = "其他诊断";
            //list.Add(obj);

            return list;
        }
        #endregion
        #endregion 

        #endregion 
    }
}


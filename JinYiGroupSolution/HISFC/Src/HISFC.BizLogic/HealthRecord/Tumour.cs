using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    public class Tumour : Neusoft.FrameWork.Management.Database
    {
        #region  肿瘤主表
        /// <summary>
        /// 获取肿瘤信息
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.HealthRecord.Tumour GetTumour(string inpatientNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.Tumour.GetTumour", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, inpatientNo);
                //查询
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.Tumour info = new Neusoft.HISFC.Models.HealthRecord.Tumour();
                while (this.Reader.Read())
                {
                    info.InpatientNo = Reader[0].ToString();								//住院流水号 
                    info.Rmodeid = Reader[1].ToString();									//放疗方式
                    info.Rprocessid = Reader[2].ToString();									//放疗程式
                    info.Rdeviceid = Reader[3].ToString();									//放疗装置
                    info.Cmodeid = Reader[4].ToString();									//化疗方式
                    info.Cmethod = Reader[5].ToString();									//化疗方法
                    info.Gy1 = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[6]);		//原发灶gy剂量
                    info.Time1 = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[7]);		//原发灶次数
                    info.Day1 = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8]);		//原发灶天数
                    info.BeginDate1 = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[9]);//原发灶开始时间
                    info.EndDate1 = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10]);  //原发灶结束时间
                    info.Gy2 = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[11]);		//区域淋巴结gy剂量
                    info.Time2 = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[12]);		//区域淋巴结次数
                    info.Day2 = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[13]);		//区域淋巴结天数
                    info.BeginDate2 = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[14]);//区域淋巴结开始时间
                    info.EndDate2 = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[15]);  //区域淋巴结结束时间
                    info.Gy3 = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[16]);		//转移灶gy剂量
                    info.Time3 = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[17]);		//区域淋巴结次数
                    info.Day3 = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[18]);		//区域淋巴结天数
                    info.BeginDate3 = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[19]);//区域淋巴结开始时间
                    info.EndDate3 = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[20]);  //区域淋巴结结束时间
                    info.OperInfo.ID = Reader[21].ToString();								 //操作员 
                    info.User01 = Reader[22].ToString();//操作时间           
                }
                return info;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 更新肿瘤表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateTumour(Neusoft.HISFC.Models.HealthRecord.Tumour info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.Tumour.UpdateTumour", ref strSql) == -1) return -1;
            try
            {
                object[] mm = GetTumourInfo(info);
                if (mm == null)
                {
                    this.Err = "业务层从实体中获取字符数组出错";
                    return -1;
                }
                strSql = string.Format(strSql, mm);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        private string[] GetTumourInfo(Neusoft.HISFC.Models.HealthRecord.Tumour info)
        {
            string[] ss = new string[23];
            ss[0] = info.InpatientNo;	//住院流水号 
            ss[1] = info.Rmodeid;		//放疗方式
            ss[2] = info.Rprocessid;	//放疗程式
            ss[3] = info.Rdeviceid;		//放疗装置
            ss[4] = info.Cmodeid;		//化疗方法
            ss[5] = info.Cmethod;		//化疗方法
            ss[6] = info.Gy1.ToString();			//原发灶gy剂量
            ss[7] = info.Time1.ToString();			//原发灶次数
            ss[8] = info.Day1.ToString();			//原发灶天数
            ss[9] = info.BeginDate1.ToString();	//原发灶开始时间
            ss[10] = info.EndDate1.ToString();		//原发灶结束时间
            ss[11] = info.Gy2.ToString();			//区域淋巴结gy剂量
            ss[12] = info.Time2.ToString();		//区域淋巴结次数
            ss[13] = info.Day2.ToString();			//区域淋巴结天数
            ss[14] = info.BeginDate2.ToString();	//区域淋巴结开始时间
            ss[15] = info.EndDate2.ToString();		//区域淋巴结结束时间
            ss[16] = info.Gy3.ToString();			//转移灶gy剂量
            ss[17] = info.Time3.ToString();		//区域淋巴结次数
            ss[18] = info.Day3.ToString();		//区域淋巴结天数
            ss[19] = info.BeginDate3.ToString();	//区域淋巴结开始时间
            ss[20] = info.EndDate3.ToString();		//区域淋巴结结束时间
            ss[21] = this.Operator.ID;	//操作员 
            //			ss[21] = info.User01 = Reader[21].ToString();//操作时间           
            return ss;
        }
        /// <summary>
        /// 向肿瘤明细表中插入一条数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns>出现异常返回－1 成功返回1 插入失败返回 0</returns>
        public int InsertTumour(Neusoft.HISFC.Models.HealthRecord.Tumour info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.Tumour.InsertTumour", ref strSql) == -1) return -1;
            try
            {
                //获取索引值
                object[] mm = GetTumourInfo(info);
                if (mm == null)
                {
                    this.Err = "业务层从实体中获取字符数组出错";
                    return -1;
                }
                strSql = string.Format(strSql, mm);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 从肿瘤明细表中删除一条数据
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns>出现异常返回－1 成功返回1 插入失败返回 0</returns>
        public int DeleteTumour(string InpatientNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.Tumour.DeleteTumour", ref strSql) == -1) return -1;
            try
            {
                //获取索引值
                strSql = string.Format(strSql, InpatientNo);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        #endregion

        #region 肿瘤明细表
        /// <summary>
        /// 获取肿瘤明细表中得数据
        /// </summary>
        /// <param name="inpatienNo">住院流水号</param>
        /// <returns>出错返回null</returns>
        public ArrayList QueryTumourDetail(string inpatienNo)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.Tumour.GetTumourDetail", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, inpatienNo);
                //查询
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.TumourDetail info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.HealthRecord.TumourDetail();
                    info.InpatientNO = Reader[0].ToString();
                    info.HappenNO = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[1].ToString());
                    info.CureDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[2].ToString());
                    info.DrugInfo.ID = Reader[3].ToString();
                    info.DrugInfo.Name = Reader[4].ToString();
                    info.Qty = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[5].ToString());
                    info.Unit = Reader[6].ToString();
                    info.Period = Reader[7].ToString();
                    info.Result = Reader[8].ToString();
                    info.OperInfo.ID = Reader[9].ToString();
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
        /// 更新肿瘤明细表中得数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns>出现异常返回－1 成功返回1更新失败返回 0 </returns>
        public int UpdateTumourDetail(Neusoft.HISFC.Models.HealthRecord.TumourDetail info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.Tumour.UpdateTumourDetail", ref strSql) == -1) return -1;
            try
            {
                info.OperInfo.ID = this.Operator.ID;
                object[] mm = GetInfo(info);
                if (mm == null)
                {
                    this.Err = "业务层从实体中获取字符数组出错";
                    return -1;
                }
                strSql = string.Format(strSql, mm);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 向肿瘤明细表中插入一条数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns>出现异常返回－1 成功返回1 插入失败返回 0</returns>
        public int InsertTumourDetail(Neusoft.HISFC.Models.HealthRecord.TumourDetail info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.Tumour.InsertTumourDetail", ref strSql) == -1) return -1;
            try
            {
                info.OperInfo.ID = this.Operator.ID;
                //获取索引值
                info.HappenNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetSequence("Case.Tumour.GetSequence"));
                object[] mm = GetInfo(info);
                if (mm == null)
                {
                    this.Err = "业务层从实体中获取字符数组出错";
                    return -1;
                }
                strSql = string.Format(strSql, mm);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        private object[] GetInfo(Neusoft.HISFC.Models.HealthRecord.TumourDetail info)
        {
            try
            {
                object[] s = new object[10];
                s[0] = info.InpatientNO;		//住院流水号
                s[1] = info.HappenNO; //发生序号      
                s[2] = info.CureDate.ToString(); //治疗日期
                s[3] = info.DrugInfo.ID;//药物代码       
                s[4] = info.DrugInfo.Name;//药物名称         
                s[5] = info.Qty.ToString();//剂量   
                s[6] = info.Unit;//单位 
                s[7] = info.Period;//疗程
                s[8] = info.Result;// 疗效		
                s[9] = info.OperInfo.ID;//  操作员代号       
                return s;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int DeleteTumourDetail(Neusoft.HISFC.Models.HealthRecord.TumourDetail info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.Tumour.DeleteTumourDetail", ref strSql) == -1) return -1;
            try
            {
                //格式化字符串
                strSql = string.Format(strSql, info.InpatientNO, info.HappenNO);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        #endregion

        #region  废弃
        /// <summary>
        /// 获取肿瘤明细表中得数据
        /// </summary>
        /// <param name="inpatienNo">住院流水号</param>
        /// <returns>出错返回null</returns>
        [Obsolete("废弃,用 QueryTumourDetail 代替", true)]
        public ArrayList GetTumourDetail(string inpatienNo)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.Tumour.GetTumourDetail", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, inpatienNo);
                //查询
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.TumourDetail info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.HealthRecord.TumourDetail();
                    info.InpatientNO = Reader[0].ToString();
                    info.HappenNO = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[1].ToString());
                    info.CureDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[2].ToString());
                    info.DrugInfo.ID = Reader[3].ToString();
                    info.DrugInfo.Name = Reader[4].ToString();
                    info.Qty = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[5].ToString());
                    info.Unit = Reader[6].ToString();
                    info.Period = Reader[7].ToString();
                    info.Result = Reader[8].ToString();
                    info.OperInfo.ID = Reader[9].ToString();
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
        /// 疗程列表
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 用 常数PERIODOFTREATMENT代替", true)]
        public ArrayList GetPeriodList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "疗程I";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "疗程II";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "疗程III";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 获取结果列表
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 用 常数RADIATERESULT 代替", true)]
        public ArrayList GetResultList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "CR";
            //info.Name = "消失";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "PR";
            //info.Name = "显效";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "MR";
            //info.Name = "好转";
            //list.Add(info);

            //info.ID = "S";
            //info.Name = "不变";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "P";
            //info.Name = "恶化";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "NA";
            //info.Name = "未定";

            //list.Add(info);
            return list;
        }
        /// <summary>
        /// 放疗方式 
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 用 常数 RADIATETYPE 代替", true)]
        public ArrayList GetRmodeidList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "根治性";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "姑息性";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "辅助性";
            //list.Add(info);
            return list;
        }
        /// <summary>
        /// 放疗程式 
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 用 常数RADIATEPERIOD 代替", true)]
        public ArrayList GetRprocessidList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "连续";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "间断";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "分段";
            //list.Add(info);
            return list;
        }
        /// <summary>
        /// 放疗装置
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 用 常数 RADIATEDEVICE 代替", true)]
        public ArrayList GetRdeviceidList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "钴";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "直加";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "X线";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "4";
            //info.Name = "后装";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 化疗方式
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 用 常数 CHEMOTHERAPY 代替", true)]
        public ArrayList GetCmodeidList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "根治性";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "姑息性";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "新辅助性";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "4";
            //info.Name = "辅助性";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "5";
            //info.Name = "新药试用";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "6";
            //info.Name = "其他";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 化疗方法
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 用 常数 CHEMOTHERAPYWAY 代替", true)]
        public ArrayList GetCmethodList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "全化";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "半化";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "A插管";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "4";
            //info.Name = "胸腔注";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "5";
            //info.Name = "腹腔注";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "6";
            //info.Name = "其他";
            //list.Add(info);

            return list;
        }
        #endregion 
    }
}

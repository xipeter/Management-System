using System;
using System.Collections;
using Neusoft.HISFC.Models.SIInterface;
using Neusoft.HISFC.Models.Fee;
using System.Data;

namespace Neusoft.HISFC.BizLogic.Fee
{
    /// <summary>
    /// Interface 的摘要说明。
    /// </summary>
    public class Interface : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 
        /// </summary>
        public Interface()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 对照
        /// <summary>
        /// 获取医保中心药品信息代码
        /// </summary>
        /// <param name="pactCode"></param>
        /// <param name="sysClass"></param>
        /// <returns></returns>
        public ArrayList GetCenterItem(string pactCode, string sysClass)
        {
            string centerDrugType = "";
            string centerDrugTypeSec = "";
            string strSql = "";

            switch (sysClass)
            {
                case "P":
                    centerDrugType = "X"; //西药项目
                    centerDrugTypeSec = "X";
                    break;
                case "Z":
                    centerDrugType = "Z"; //中药项目
                    centerDrugTypeSec = "Z";
                    break;
                case "C":
                    centerDrugType = "C"; //草药项目
                    centerDrugTypeSec = "C";
                    break;
                case "Undrug":
                    centerDrugType = "L";
                    centerDrugTypeSec = "F";
                    break;
                //{8507E4F9-9C00-4571-BF32-2A6779CE4815} wbo 2010-08-30
                case "ALL":
                    centerDrugType = "ALL";
                    centerDrugTypeSec = "ALL";
                    break;
            }

            if (this.Sql.GetSql("Fee.Interface.GetCenterItem.Select.1", ref strSql) == -1)
                return null;

            try
            {
                strSql = string.Format(strSql, pactCode, centerDrugType, centerDrugTypeSec);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.SIInterface.Item obj = new Neusoft.HISFC.Models.SIInterface.Item();

                    obj.PactCode = Reader[0].ToString();
                    obj.ID = Reader[1].ToString();
                    obj.SysClass = Reader[2].ToString();
                    obj.Name = Reader[3].ToString();
                    obj.EnglishName = Reader[4].ToString();
                    obj.Specs = Reader[5].ToString();
                    obj.DoseCode = Reader[6].ToString();
                    obj.SpellCode = Reader[7].ToString();
                    obj.FeeCode = Reader[8].ToString();
                    obj.ItemType = Reader[9].ToString();
                    obj.ItemGrade = Reader[10].ToString();
                    obj.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[11].ToString());
                    obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[12].ToString());
                    obj.Memo = Reader[13].ToString();
                    obj.OperCode = Reader[14].ToString();
                    obj.OperDate = Convert.ToDateTime(Reader[15].ToString());

                    al.Add(obj);
                }

                Reader.Close();

                return al;

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取医保中心所有信息代码
        /// </summary>
        /// <param name="pactCode">合同单位</param>
        /// <returns></returns>
        public ArrayList GetCenterItem(string pactCode)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.GetCenterItem.Select.3", ref strSql) == -1)
                return null;
            try
            {
                strSql = string.Format(strSql, pactCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.SIInterface.Item obj = new Neusoft.HISFC.Models.SIInterface.Item();

                    obj.PactCode = Reader[0].ToString();
                    obj.ID = Reader[1].ToString();
                    obj.SysClass = Reader[2].ToString();
                    obj.Name = Reader[3].ToString();
                    obj.EnglishName = Reader[4].ToString();
                    obj.Specs = Reader[5].ToString();
                    obj.DoseCode = Reader[6].ToString();
                    obj.SpellCode = Reader[7].ToString();
                    obj.FeeCode = Reader[8].ToString();
                    obj.ItemType = Reader[9].ToString();
                    obj.ItemGrade = Reader[10].ToString();
                    obj.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[11].ToString());
                    obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[12].ToString());
                    obj.Memo = Reader[13].ToString();
                    obj.OperCode = Reader[14].ToString();
                    obj.OperDate = Convert.ToDateTime(Reader[15].ToString());

                    al.Add(obj);
                }

                Reader.Close();

                return al;

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 获得对照后的项目信息
        /// </summary>
        /// <param name="pactCode"></param>
        /// <param name="sysClass"></param>
        /// <returns></returns>
        public ArrayList GetCompareItem(string pactCode, string sysClass)
        {
            string centerDrugType = "";
            string centerDrugTypeSec = "";

            switch (sysClass)
            {
                case "P":
                    centerDrugType = "X"; //西药项目
                    centerDrugTypeSec = "X";
                    break;
                case "Z":
                    centerDrugType = "Z"; //中药项目
                    centerDrugTypeSec = "Z";
                    break;
                case "C":
                    centerDrugType = "C"; //草药项目
                    centerDrugTypeSec = "C";
                    break;
                case "Undrug":
                    centerDrugType = "L";
                    centerDrugTypeSec = "F";
                    break;
                //不分中西成药{8507E4F9-9C00-4571-BF32-2A6779CE4815} WBO 2010-08-30
                case "ALL":
                    centerDrugType = "ALL";
                    centerDrugTypeSec = "ALL";
                    break;
            }

            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.GetCompareItem.Select.1", ref strSql) == -1)
                return null;

            try
            {
                strSql = string.Format(strSql, pactCode, centerDrugType, centerDrugTypeSec);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.SIInterface.Compare obj = new Compare();

                    obj.CenterItem.PactCode = Reader[0].ToString();
                    obj.HisCode = Reader[1].ToString();
                    obj.CenterItem.ID = Reader[2].ToString();
                    obj.CenterItem.SysClass = Reader[3].ToString();
                    obj.CenterItem.Name = Reader[4].ToString();
                    obj.CenterItem.EnglishName = Reader[5].ToString();
                    obj.CenterItem.Specs = Reader[6].ToString();
                    obj.CenterItem.DoseCode = Reader[7].ToString();
                    obj.CenterItem.SpellCode = Reader[8].ToString();
                    obj.CenterItem.FeeCode = Reader[9].ToString();
                    obj.CenterItem.ItemType = Reader[10].ToString();
                    obj.CenterItem.ItemGrade = Reader[11].ToString();
                    obj.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[12].ToString());
                    obj.CenterItem.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[13].ToString());
                    obj.CenterItem.Memo = Reader[14].ToString();
                    obj.SpellCode.SpellCode = Reader[15].ToString();
                    obj.SpellCode.WBCode = Reader[16].ToString();
                    obj.SpellCode.UserCode = Reader[17].ToString();
                    obj.Specs = Reader[18].ToString();
                    obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[19].ToString());
                    obj.DoseCode = Reader[20].ToString();
                    obj.CenterItem.OperCode = Reader[21].ToString();
                    obj.CenterItem.OperDate = Convert.ToDateTime(Reader[22].ToString());
                    obj.Name = Reader[23].ToString();
                    obj.RegularName = Reader[24].ToString();
                    //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                    obj.HisSysClass = Reader[25].ToString();

                    al.Add(obj);
                }

                Reader.Close();

                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }

        /*
        /// <summary>
        /// 获得对照后的所有类别药品信息
        /// </summary>
        /// <param name="pactCode"></param>
        /// <returns></returns>
        public ArrayList GetCompareDrugItem(string pactCode)
        {
            string strSql = "";
            if(this.Sql.GetSql("Fee.Interface.GetCompareItem.Select.3", ref strSql) == -1) 
                return null;
			
            try
            {   				
                strSql = string.Format(strSql, pactCode);
            }
            catch(Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while(Reader.Read())
                {
                    Neusoft.HISFC.Models.InterfaceSi.Compare obj = new Neusoft.HISFC.Models.InterfaceSi.Compare();

                    obj.CenterItem.PactCode = Reader[0].ToString();
                    obj.HisCode = Reader[1].ToString();
                    obj.CenterItem.ID = Reader[2].ToString();
                    obj.CenterItem.SysClass = Reader[3].ToString();
                    obj.CenterItem.Name = Reader[4].ToString();
                    obj.CenterItem.EnglishName = Reader[5].ToString();
                    obj.CenterItem.Specs = Reader[6].ToString();
                    obj.CenterItem.DoseCode = Reader[7].ToString();
                    obj.CenterItem.SpellCode = Reader[8].ToString();
                    obj.CenterItem.FeeCode = Reader[9].ToString();
                    obj.CenterItem.ItemType = Reader[10].ToString();
                    obj.CenterItem.ItemGrade = Reader[11].ToString();
                    obj.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[12].ToString());
                    obj.CenterItem.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[13].ToString());
                    obj.CenterItem.Memo = Reader[14].ToString();
                    obj.SpellCode = Reader[15].ToString();
                    obj.SpellCode.WBCode = Reader[16].ToString();
                    obj.SpellCode.UserCode = Reader[17].ToString();
                    obj.Specs = Reader[18].ToString();
                    obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[19].ToString());
                    obj.DoseCode = Reader[20].ToString();
                    obj.CenterItem.OperCode = Reader[21].ToString();
                    obj.CenterItem.OperDate = Convert.ToDateTime(Reader[22].ToString());
                    obj.Name = Reader[23].ToString();
                    obj.RegularName = Reader[24].ToString();

                    al.Add(obj);
                }

                Reader.Close();

                return al;
            }
            catch(Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }
        */

        /// <summary>
        /// 获取中心项目信息
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <param name="itemCode">项目编码</param>
        /// <returns>中心项目信息</returns>
        public Neusoft.HISFC.Models.SIInterface.Item GetCenterItemInfo(string pactCode, string itemCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.GetCenterItem", ref strSql) == -1)
                return null;
            try
            {
                strSql = string.Format(strSql, pactCode, itemCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            Neusoft.HISFC.Models.SIInterface.Item obj = new Neusoft.HISFC.Models.SIInterface.Item();
            try
            {
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    obj = new Neusoft.HISFC.Models.SIInterface.Item();

                    obj.PactCode = Reader[0].ToString();
                    obj.ID = Reader[1].ToString();
                    obj.SysClass = Reader[2].ToString();
                    obj.Name = Reader[3].ToString();
                    obj.EnglishName = Reader[4].ToString();
                    obj.Specs = Reader[5].ToString();
                    obj.DoseCode = Reader[6].ToString();
                    obj.SpellCode = Reader[7].ToString();
                    obj.FeeCode = Reader[8].ToString();
                    obj.ItemType = Reader[9].ToString();
                    obj.ItemGrade = Reader[10].ToString();
                    obj.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[11].ToString());
                    obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[12].ToString());
                    obj.Memo = Reader[13].ToString();
                    obj.OperCode = Reader[14].ToString();
                    obj.OperDate = Convert.ToDateTime(Reader[15].ToString());
                }

                Reader.Close();
                if (obj == null || obj.ID == "")
                    this.Err = "未获取医保中心项目信息 请先对启用更新程序更新本地中心项目信息";
                return obj;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 是否对该项目已对照
        /// </summary>
        /// <param name="hisUserCode">his内项目自定义码 对应医保服务器内医保对照信息的his项目代码</param>
        /// <param name="centerCode">中心项目代码</param>
        /// <returns>-1 出错 0 未对照 1 已对照</returns>
        public int IsCompared(string hisUserCode, string centerCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.IsCompared", ref strSql) == -1)
                return -1;
            try
            {
                strSql = string.Format(strSql, hisUserCode, centerCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            try
            {
                this.ExecQuery(strSql);
                return 0;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 获得单条已对照信息
        /// </summary>
        /// <param name="pactCode"></param>
        /// <param name="itemCode"></param>
        /// <param name="objCompare"></param>
        /// <returns></returns>
        public int GetCompareSingleItem(string pactCode, string itemCode, ref Compare objCompare)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.GetCompareSingleItem.Select.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, pactCode, itemCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.SIInterface.Compare obj = new Compare();

                    obj.CenterItem.PactCode = Reader[0].ToString();
                    obj.HisCode = Reader[1].ToString();
                    obj.CenterItem.ID = Reader[2].ToString();
                    obj.CenterItem.SysClass = Reader[3].ToString();
                    obj.CenterItem.Name = Reader[4].ToString();
                    obj.CenterItem.EnglishName = Reader[5].ToString();
                    obj.CenterItem.Specs = Reader[6].ToString();
                    obj.CenterItem.DoseCode = Reader[7].ToString();
                    obj.CenterItem.SpellCode = Reader[8].ToString();
                    obj.CenterItem.FeeCode = Reader[9].ToString();
                    obj.CenterItem.ItemType = Reader[10].ToString();
                    obj.CenterItem.ItemGrade = Reader[11].ToString();
                    obj.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[12].ToString());
                    obj.CenterItem.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[13].ToString());
                    obj.CenterItem.Memo = Reader[14].ToString();
                    obj.SpellCode.SpellCode = Reader[15].ToString();
                    obj.SpellCode.WBCode = Reader[16].ToString();
                    obj.SpellCode.UserCode = Reader[17].ToString();
                    obj.Specs = Reader[18].ToString();
                    obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[19].ToString());
                    obj.DoseCode = Reader[20].ToString();
                    obj.CenterItem.OperCode = Reader[21].ToString();
                    obj.CenterItem.OperDate = Convert.ToDateTime(Reader[22].ToString());
                    obj.Name = Reader[23].ToString();
                    obj.RegularName = Reader[24].ToString();
                    //{8DF3D566-FA34-44cb-A2D5-919FE05D1702}
                    obj.Practicablesymptom.ID = Reader[25].ToString();
                    //obj.Ispracticablesymptom = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[25]);
                    obj.Practicablesymptomdepiction = Reader[26].ToString();

                    al.Add(obj);
                }

                Reader.Close();

                if (al.Count > 0)
                {
                    objCompare = (Compare)al[0];
                    return 0;
                }
                else
                {
                    return -2;
                }
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 插入对照后的项目信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertCompareItem(Compare obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.InsertCompareItem.1", ref strSql) == -1)
                return -1;

            //			try
            //			{   				
            //				strSql = string.Format(strSql, obj.CenterItem.PactCode ,obj.HisCode, obj.CenterItem.ID,
            //					obj.CenterItem.SysClass, obj.CenterItem.Name, obj.CenterItem.EnglishName,
            //					obj.CenterItem.Specs, obj.CenterItem.DoseCode, obj.CenterItem.SpellCode,
            //					obj.CenterItem.FeeCode, obj.CenterItem.ItemType, obj.CenterItem.ItemGrade,
            //					obj.CenterItem.Rate, obj.CenterItem.Price, obj.CenterItem.Memo, 
            //					obj.SpellCode, obj.SpellCode.WBCode, obj.SpellCode.UserCode,
            //					obj.Specs, obj.Price, obj.DoseCode, obj.CenterItem.OperCode,
            //					obj.Name, obj.RegularName);
            //
            //			}
            //			catch(Exception ex)
            //			{
            //				this.ErrCode = ex.Message;
            //				this.Err = ex.Message;
            //				return -1;
            //			}      			

            try
            {
                return this.ExecNoQuery(strSql, obj.CenterItem.PactCode, obj.HisCode, obj.CenterItem.ID,
                    obj.CenterItem.SysClass, obj.CenterItem.Name, obj.CenterItem.EnglishName,
                    obj.CenterItem.Specs, obj.CenterItem.DoseCode, obj.CenterItem.SpellCode,
                    obj.CenterItem.FeeCode, obj.CenterItem.ItemType, obj.CenterItem.ItemGrade,
                    obj.CenterItem.Rate.ToString(), obj.CenterItem.Price.ToString(), obj.CenterItem.Memo,
                    obj.SpellCode.SpellCode, obj.SpellCode.WBCode, obj.SpellCode.UserCode,
                    obj.Specs, obj.Price.ToString(), obj.DoseCode, obj.CenterItem.OperCode,
                    obj.Name, obj.RegularName,
                    //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
                    obj.HisSysClass);//this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 删除已对照信息
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <param name="hisCode">HIS本地编码</param>
        /// <returns></returns>
        public int DeleteCompareItem(string pactCode, string hisCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.DeleteCompareItem.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, pactCode, hisCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 获得未对照非药品项目信息
        /// </summary>
        /// <param name="pactCode"></param>
        /// <returns></returns>
        public ArrayList GetNoCompareUndrugItem(string pactCode)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.GetNoCompareUndrugItem.Select.1", ref strSql) == -1)
                return null;

            try
            {
                strSql = string.Format(strSql, pactCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug obj = new Neusoft.HISFC.Models.Fee.Item.Undrug();

                    obj.ID = Reader[0].ToString();
                    obj.Name = Reader[1].ToString();
                    obj.SpellCode = Reader[2].ToString();
                    obj.WBCode = Reader[3].ToString();
                    obj.UserCode = Reader[4].ToString();
                    obj.Specs = Reader[5].ToString();
                    obj.NationCode = Reader[6].ToString();
                    obj.GBCode = Reader[7].ToString();
                    obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8].ToString());
                    obj.PriceUnit = Reader[9].ToString();

                    al.Add(obj);
                }

                Reader.Close();

                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获得药品信息
        /// </summary>
        /// <param name="pactCode">合同单位</param>
        /// <param name="drugType">药品类别</param>
        /// <returns></returns>
        public ArrayList GetNoCompareDrugItem(string pactCode, string drugType)
        {
            string strSql = "";
            string centerDrugType = "";

            //本地项目P 西药 Z 中成药 C 草药

            if (drugType == "P")
            {
                centerDrugType = "X"; //西药项目
            }
            else
            {
                centerDrugType = "Z"; //中草药项目
            }
            if (drugType == "ALL")			//忽略药品类别
                centerDrugType = "ALL";

            if (this.Sql.GetSql("Fee.Interface.GetNoCompareDrugItem.Select.1", ref strSql) == -1)
                return null;

            try
            {
                strSql = string.Format(strSql, pactCode, drugType, centerDrugType);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {

                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Pharmacy.Item obj = new Neusoft.HISFC.Models.Pharmacy.Item();

                    obj.ID = Reader[0].ToString();
                    obj.Name = Reader[1].ToString();
                    obj.SpellCode = Reader[2].ToString();
                    obj.WBCode = Reader[3].ToString();
                    obj.UserCode = Reader[4].ToString();
                    obj.Specs = Reader[5].ToString();
                    obj.NameCollection.RegularName = Reader[6].ToString();
                    obj.NameCollection.RegularSpell.SpellCode = Reader[7].ToString();
                    obj.NameCollection.RegularSpell.WBCode = Reader[8].ToString();
                    obj.NameCollection.InternationalCode = Reader[9].ToString();
                    obj.GBCode = Reader[10].ToString();
                    obj.PriceCollection.RetailPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[11].ToString());
                    obj.Type.ID = Reader[12].ToString();
                    obj.DosageForm.ID = Reader[13].ToString();

                    al.Add(obj);
                }

                Reader.Close();

                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 获得本地医保目录信息
        /// </summary>
        /// <returns></returns>
        public int GetLocalSIItemCounts()
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.GetLocalSIItemCounts.Select", ref strSql) == -1)
                return -1;

            if (this.ExecQuery(strSql) == -1)
            {
                this.ErrCode = "-1";
                this.Err = "查询医保项目目录失败!";
                return -1;
            }

            int count = 0;
            try
            {
                while (Reader.Read())
                {
                    count = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[0].ToString());
                }

                Reader.Close();

                return count;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                return -1;
            }
        }
        /// <summary>
        /// 删除所有医保信息
        /// </summary>
        /// <returns></returns>
        public int DeleteSIItem()
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.DeleteSIItem.Delete", ref strSql) == -1)
                return -1;

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

        }
        /// <summary>
        /// 插入医保项目信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int InsertSIItem(Neusoft.HISFC.Models.SIInterface.Item item)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.InsertSIItem.Insert", ref strSql) == -1)
                return -1;

            //			try
            //			{   				
            //				strSql = string.Format(strSql, item.ID, item.SysClass, item.Name, item.EnglishName,
            //					item.Specs, item.DoseCode, item.SpellCode, item.FeeCode, item.ItemType, 
            //					item.ItemGrade, item.Rate.ToString(),this.Operator.ID);
            //
            //			}
            //			catch(Exception ex)
            //			{
            //				this.ErrCode = ex.Message;
            //				this.Err = ex.Message;
            //				return -1;
            //			}      			

            try
            {
                //{E5267BE7-0707-4780-AB86-266650C476C2} 修改sql语句，将pactCode传入
                return this.ExecNoQuery(strSql, item.ID, item.SysClass, item.Name, item.EnglishName,
                    item.Specs, item.DoseCode, item.SpellCode, item.FeeCode, item.ItemType,
                    item.ItemGrade, item.Rate.ToString(), this.Operator.ID, item.PactCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        #endregion

        #region 医保政策维护
        /// <summary>
        /// 获得政策维护的所有合同单位信息;
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAllPactInfo()
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.Ruls.GetAllPactInfo.Select.1", ref strSql) == -1)
                return null;

            try
            {
                strSql = string.Format(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    Insurance obj = new Insurance();

                    obj.PactInfo.ID = Reader[0].ToString();
                    obj.PactInfo.Name = Reader[1].ToString();
                    obj.Kind.ID = Reader[2].ToString();

                    al.Add(obj);
                }

                Reader.Close();

                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

        }
        /// <summary>
        /// 插入医保政策信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertInsuranceDeal(Insurance obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.InsertInsuranceDeal.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, obj.PactInfo.ID, obj.Kind.ID, obj.PartId, obj.Rate,
                    obj.BeginCost, obj.EndCost, obj.Memo, obj.OperCode.ID);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 更新医保政策信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateInsuranceDeal(Insurance obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.UpdateInsuranceDeal.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, obj.PactInfo.ID, obj.Kind.ID, obj.PartId, obj.Rate,
                    obj.BeginCost, obj.EndCost, obj.Memo, obj.OperCode.ID);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 删除医保政策信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int DeleteInsuranceDeal(Insurance obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.DeleteInsuranceDeal.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, obj.PactInfo.ID, obj.Kind.ID, obj.PartId);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 得到指定合同单位,类别下的规则信息
        /// </summary>
        /// <param name="pactCode"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public ArrayList GetAllInsuranceInfo(string pactCode, string kind)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.Ruls.GetAllInsuranceInfo.Select.1", ref strSql) == -1)
                return null;

            try
            {
                strSql = string.Format(strSql, pactCode, kind);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    Insurance obj = new Insurance();

                    //					obj.PactInfo.ID = Reader[0].ToString();
                    //obj.PactInfo.Name = Reader[1].ToString();
                    //obj.Kind.ID = Reader[2].ToString();
                    obj.PartId = Reader[0].ToString();
                    obj.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[1].ToString());
                    obj.BeginCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[2].ToString());
                    obj.EndCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[3].ToString());
                    obj.Memo = Reader[4].ToString();
                    obj.OperCode.ID = Reader[5].ToString();
                    obj.OperDate = Convert.ToDateTime(Reader[6].ToString());

                    al.Add(obj);
                }

                Reader.Close();

                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

        }

        #endregion

        #region 黑名单维护
        /// <summary>
        /// 插入黑名单信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertBlackList(BlackList obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.InsertBlackList.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, obj.MCardNo, obj.Kind, obj.Name, obj.ValidState,
                    obj.OperInfo.ID);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 更新黑名单信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateBlackList(BlackList obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.UpdateBlackList.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, obj.ID, obj.MCardNo, obj.Kind, obj.Name, obj.ValidState,
                    obj.OperInfo.ID, obj.OperDate);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 删除黑名单信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mCardNo"></param>
        /// <returns></returns>
        public int DeleteBlackList(string id, string mCardNo)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.DeleteBlackList.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, id, mCardNo);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 通过黑名单类别获得所有黑名单列表
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="validState"></param>
        /// <returns></returns>
        public ArrayList GetBlackListFromKind(string kind, string validState)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.GetBlackListFromKind.Select.1", ref strSql) == -1)
                return null;

            try
            {
                strSql = string.Format(strSql, kind, validState);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    BlackList obj = new BlackList();

                    obj.ID = Reader[0].ToString();
                    obj.MCardNo = Reader[1].ToString();
                    obj.Kind = Reader[2].ToString();
                    obj.Name = Reader[3].ToString();
                    obj.ValidState = Reader[4].ToString();
                    obj.OperInfo.ID = Reader[5].ToString();
                    obj.OperDate = Convert.ToDateTime(Reader[6].ToString());

                    al.Add(obj);
                }

                Reader.Close();

                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 判断患者得单位或个人是否存在黑名单内
        /// </summary>
        /// <param name="pactCode"></param>
        /// <param name="mCardNo"></param>
        /// <returns></returns>
        public bool ExistBlackList(string pactCode, string mCardNo)
        {
            string strSql = "";
            string strSql2 = "";
            int pactCount = 0;
            int personCount = 0;

            if (this.Sql.GetSql("Fee.Interface.ExistBlackList.Select.1", ref strSql) == -1)
                return false;

            try
            {
                strSql = string.Format(strSql, pactCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return false;
            }
            try
            {

                pactCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strSql));

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return false;
            }

            if (this.Sql.GetSql("Fee.Interface.ExistBlackList.Select.2", ref strSql2) == -1)
                return false;

            try
            {
                strSql = string.Format(strSql2, pactCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return false;
            }
            try
            {

                personCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strSql2));

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return false;
            }

            if (pactCount + personCount > 0)
                return true;
            else
                return false;

        }


        #endregion

        #region 医保接口计算
        /// <summary>
        /// 计算比例
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <param name="item">费用实体</param>
        /// <returns></returns>
        public int ComputeRate(string pactCode, ref Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList item)
        {
            int returnValue = 0;

            Compare objCompare = new Compare();

            returnValue = GetCompareSingleItem(pactCode, item.Item.ID, ref objCompare);

            if (returnValue == -1)
                return returnValue;
            if (returnValue == -2)
                objCompare.CenterItem.Rate = 1;

            item.FT.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(item.FT.TotCost * objCompare.CenterItem.Rate, 2);
            item.FT.PubCost = item.FT.TotCost - item.FT.OwnCost;

            return 0;
        }
        /// <summary>
        /// 得到对照信息
        /// </summary>
        /// <param name="pactCode"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetItemCompareInfo(string pactCode, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj)
        {
            return 0;
        }

        #endregion

        #region 医保限额维护
        /// <summary>
        /// 获得输入月份的科室限额信息
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public ArrayList GetDeptSICostFromMonth(string month)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.GetDeptSICostFromMonth.Select.1", ref strSql) == -1)
                return null;

            try
            {
                strSql = string.Format(strSql, month);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    DeptSICost obj = new DeptSICost();

                    obj.ID = Reader[0].ToString();
                    obj.Month = Reader[1].ToString();
                    obj.Name = Reader[2].ToString();
                    obj.AlertMoney = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[3].ToString());
                    obj.ValidStateId = Reader[4].ToString();
                    obj.SortId = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[5].ToString());
                    obj.OperInfo.ID = Reader[6].ToString();
                    obj.OperDate = Convert.ToDateTime(Reader[7].ToString());
                    obj.SpellCode.SpellCode = Reader[8].ToString();

                    al.Add(obj);
                }

                Reader.Close();

                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 插入未维护到医保限额的科室信息,警戒线默认为0; sortId默认为10000
        /// </summary>
        /// <param name="month"></param>
        /// <param name="operCode"></param>
        /// <returns></returns>
        public int InsertNoExistDeptInfo(string month, string operCode)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.InsertNoExistDeptInfo.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, month, operCode);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 更新医保限额
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateDeptSICost(DeptSICost obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.UpdateDeptSICost.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, obj.ID, obj.Month, obj.Name, obj.AlertMoney, obj.ValidStateId,
                    obj.SortId, obj.OperInfo.ID);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 获得某科室某月的限额
        /// </summary>
        /// <param name="month"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public DeptSICost GetSingleDeptSICost(string month, string deptCode)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.GetSingleDeptSICost.Select.1", ref strSql) == -1)
                return null;

            try
            {
                strSql = string.Format(strSql, month, deptCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            try
            {
                ArrayList al = new ArrayList();
                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    DeptSICost obj = new DeptSICost();

                    obj.ID = Reader[2].ToString();
                    obj.Month = Reader[3].ToString();
                    obj.Name = Reader[4].ToString();
                    obj.AlertMoney = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[5].ToString());
                    obj.ValidStateId = Reader[6].ToString();
                    obj.SortId = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[7].ToString());
                    obj.OperInfo.ID = Reader[8].ToString();
                    obj.OperDate = Convert.ToDateTime(Reader[9].ToString());
                    al.Add(obj);
                }

                Reader.Close();

                if (al.Count > 0)
                    return (DeptSICost)al[0];
                else
                {
                    this.Err = month + "的科室限额没有维护,请通知信息科！";
                    return null;
                }
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
        }
        #endregion

        #region 医保结算表

        /// <summary>
        /// 得到结算序号
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public string GetBalNo(string inpatientNo)
        {
            string strSql = "";
            string balNo = "";
            if (this.Sql.GetSql("Fee.Interface.GetBalNo.1", ref strSql) == -1)
                return "";
            try
            {
                strSql = string.Format(strSql, inpatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return "";
            }
            this.ExecQuery(strSql);
            try
            {
                while (Reader.Read())
                {
                    balNo = Reader[0].ToString();
                }
                Reader.Close();
                return balNo;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return "";
            }
        }


        /// <summary>
        /// 插入医保结算信息表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertSIMainInfo(Neusoft.HISFC.Models.RADT.PatientInfo obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.Interface.InsertSIMainInfo.1", ref strSql) == -1)
                return -1;

            try
            {
                strSql = string.Format(strSql, obj.ID, obj.SIMainInfo.BalNo, obj.SIMainInfo.InvoiceNo, obj.PVisit.MedicalType.ID, obj.PID.PatientNO,
                    obj.PID.CardNO, obj.SSN, obj.SIMainInfo.AppNo, obj.SIMainInfo.ProceatePcNo,
                    obj.SIMainInfo.SiBegionDate.ToString(), obj.SIMainInfo.SiState, obj.Name, obj.Sex.ID.ToString(),
                    obj.IDCard, "", obj.Birthday.ToString(), obj.SIMainInfo.EmplType, obj.CompanyName,
                    obj.SIMainInfo.InDiagnose.Name, obj.PVisit.PatientLocation.Dept.ID, obj.PVisit.PatientLocation.Dept.Name,
                    obj.Pact.PayKind.ID, obj.Pact.ID, obj.Pact.Name, obj.PVisit.PatientLocation.Bed.ID,
                    obj.PVisit.InTime.ToString(), obj.PVisit.InTime.ToString(), obj.SIMainInfo.InDiagnose.ID,
                    obj.SIMainInfo.InDiagnose.Name, this.Operator.ID, obj.SIMainInfo.HosNo, obj.SIMainInfo.RegNo,
                    obj.SIMainInfo.FeeTimes, obj.SIMainInfo.HosCost, obj.SIMainInfo.YearCost, obj.PVisit.OutTime.ToString(),
                    obj.SIMainInfo.OutDiagnose.ID, obj.SIMainInfo.OutDiagnose.Name, obj.SIMainInfo.BalanceDate.ToString(),
                    obj.SIMainInfo.TotCost, obj.SIMainInfo.PayCost, obj.SIMainInfo.PubCost, obj.SIMainInfo.ItemPayCost,
                    obj.SIMainInfo.BaseCost, obj.SIMainInfo.ItemYLCost, obj.SIMainInfo.PubOwnCost, obj.SIMainInfo.OwnCost,
                    obj.SIMainInfo.OverTakeOwnCost, Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsValid),
                    Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsBalanced));

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            try
            {
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 得到医保患者基本信息;
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo GetSIPersonInfo(string inpatientNo)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo obj = new Neusoft.HISFC.Models.RADT.PatientInfo();
            string strSql = "";
            string balNo = this.GetBalNo(inpatientNo);
            if (balNo == "")
                return null;
            if (this.Sql.GetSql("Fee.Interface.GetSIPersonInfo.Select.1", ref strSql) == -1)
                return null;
            try
            {
                strSql = string.Format(strSql, inpatientNo, balNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            this.ExecQuery(strSql);
            try
            {
                while (Reader.Read())
                {

                    obj.SIMainInfo.HosNo = Reader[0].ToString();
                    obj.ID = Reader[1].ToString();
                    obj.SIMainInfo.BalNo = Reader[2].ToString();
                    obj.SIMainInfo.InvoiceNo = Reader[3].ToString();
                    obj.SIMainInfo.MedicalType.ID = Reader[4].ToString();
                    if (obj.SIMainInfo.MedicalType.ID == "1")
                        obj.SIMainInfo.MedicalType.Name = "住院";
                    else
                        obj.SIMainInfo.MedicalType.Name = "门诊特定项目";
                    obj.PID.PatientNO = Reader[5].ToString();
                    obj.PID.CardNO = Reader[6].ToString();
                    obj.SSN = Reader[7].ToString();
                    obj.SIMainInfo.AppNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[8].ToString());
                    obj.SIMainInfo.ProceatePcNo = Reader[9].ToString();
                    obj.SIMainInfo.SiBegionDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());
                    obj.SIMainInfo.SiState = Reader[11].ToString();
                    obj.Name = Reader[12].ToString();
                    obj.Sex.ID = Reader[13].ToString();
                    obj.IDCard = Reader[14].ToString();
                    obj.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[15].ToString());
                    obj.SIMainInfo.EmplType = Reader[16].ToString();
                    obj.CompanyName = Reader[17].ToString();
                    obj.SIMainInfo.InDiagnose.Name = Reader[18].ToString();
                    obj.PVisit.PatientLocation.Dept.ID = Reader[19].ToString();
                    obj.PVisit.PatientLocation.Dept.Name = Reader[20].ToString();
                    obj.Pact.PayKind.ID = Reader[21].ToString();
                    obj.Pact.ID = Reader[22].ToString();
                    obj.Pact.Name = Reader[23].ToString();
                    obj.PVisit.PatientLocation.Bed.ID = Reader[24].ToString();
                    obj.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[25].ToString());
                    obj.SIMainInfo.InDiagnoseDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[25].ToString());
                    obj.SIMainInfo.InDiagnose.ID = Reader[26].ToString();
                    obj.SIMainInfo.InDiagnose.Name = Reader[27].ToString();
                    if (!Reader.IsDBNull(28))
                        obj.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[28].ToString());
                    obj.SIMainInfo.OutDiagnose.ID = Reader[29].ToString();
                    obj.SIMainInfo.OutDiagnose.Name = Reader[30].ToString();
                    if (!Reader.IsDBNull(31))
                        obj.SIMainInfo.BalanceDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[31].ToString());

                    obj.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[32].ToString());
                    obj.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[33].ToString());
                    obj.SIMainInfo.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[34].ToString());
                    obj.SIMainInfo.ItemPayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[35].ToString());
                    obj.SIMainInfo.BaseCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[36].ToString());
                    obj.SIMainInfo.PubOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[37].ToString());
                    obj.SIMainInfo.ItemYLCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[38].ToString());
                    obj.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[39].ToString());
                    obj.SIMainInfo.OverTakeOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[40].ToString());
                    obj.SIMainInfo.Memo = Reader[41].ToString();
                    obj.SIMainInfo.OperInfo.ID = Reader[42].ToString();
                    obj.SIMainInfo.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[43].ToString());
                    obj.SIMainInfo.RegNo = Reader[44].ToString();
                    obj.SIMainInfo.FeeTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[45].ToString());
                    obj.SIMainInfo.HosCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[46].ToString());
                    obj.SIMainInfo.YearCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[47].ToString());
                    obj.SIMainInfo.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[48].ToString());
                    obj.SIMainInfo.IsBalanced = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[49].ToString());
                }
                Reader.Close();
                return obj;
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                Reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 更新医保结算主表信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateSiMainInfo(Neusoft.HISFC.Models.RADT.PatientInfo obj)
        {
            string strSql = "";
            string balNo = this.GetBalNo(obj.ID);
            if (this.Sql.GetSql("Fee.Interface.UpdateSiMainInfo.Update.1", ref strSql) == -1)
                return -1;
            try
            {
                strSql = string.Format(strSql, obj.ID, obj.SIMainInfo.BalNo, obj.SIMainInfo.InvoiceNo, obj.PVisit.MedicalType.ID, obj.PID.PatientNO,
                    obj.PID.CardNO, obj.SSN, obj.SIMainInfo.AppNo, obj.SIMainInfo.ProceatePcNo,
                    obj.SIMainInfo.SiBegionDate.ToString(), obj.SIMainInfo.SiState, obj.Name, obj.Sex.ID.ToString(),
                    obj.IDCard, "", obj.Birthday.ToString(), obj.SIMainInfo.EmplType, obj.CompanyName,
                    obj.SIMainInfo.InDiagnose.Name, obj.PVisit.PatientLocation.Dept.ID, obj.PVisit.PatientLocation.Dept.Name,
                    obj.Pact.PayKind.ID, obj.Pact.ID, obj.Pact.Name, obj.PVisit.PatientLocation.Bed.ID,
                    obj.PVisit.InTime.ToString(), obj.PVisit.InTime.ToString(), obj.SIMainInfo.InDiagnose.ID,
                    obj.SIMainInfo.InDiagnose.Name, obj.PVisit.OutTime, obj.SIMainInfo.OutDiagnose.ID, obj.SIMainInfo.OutDiagnose.Name,
                    obj.SIMainInfo.BalanceDate.ToString(), obj.SIMainInfo.TotCost, obj.SIMainInfo.PayCost, obj.SIMainInfo.PubCost,
                    obj.SIMainInfo.ItemPayCost, obj.SIMainInfo.BaseCost, obj.SIMainInfo.PubOwnCost, obj.SIMainInfo.ItemYLCost,
                    obj.SIMainInfo.OwnCost, obj.SIMainInfo.OverTakeOwnCost, obj.SIMainInfo.Memo, this.Operator.ID,
                    obj.SIMainInfo.RegNo, obj.SIMainInfo.FeeTimes, obj.SIMainInfo.HosCost, obj.SIMainInfo.YearCost,
                    Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsValid), Neusoft.FrameWork.Function.NConvert.ToInt32(obj.SIMainInfo.IsBalanced));
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSql);

        }
        #endregion

        #region 临时

        #endregion

        #region 医保预结算
        /// <summary>
        /// 更新医保患者预结算费用信息
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <returns>-1失败，0成功</returns>
        public int UpdateSICostForPreBalance(string InpatientNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.UpdateSICostForPreBalance", ref strSql) == -1)
            {
                this.Err = "没有找到 Fee.Interface.UpdateSICostForPreBalance 字段!";
                this.ErrCode = "-1";
                return -1;
            }
            decimal owncost = 0m;
            decimal pubcost = 0m;
            decimal realOwncost = 0m;
            decimal realPubcost = 0m;
            string Error = "";
            if (this.ExecutePackage(InpatientNo, ref owncost, ref pubcost, ref realOwncost, ref realPubcost, ref Error) == -1)
            {
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, InpatientNo, owncost.ToString(), pubcost.ToString(),
                    realOwncost.ToString());
                this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 医保预结算
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="myFee"></param>
        /// <param name="refFT"></param>
        /// <returns></returns>
        public bool CalculateSiFee(Neusoft.HISFC.Models.RADT.PatientInfo obj, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList myFee, Neusoft.HISFC.Models.Base.FT refFT)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo myObj = GetSIPersonInfo(obj.ID);
            if (myObj == null)
            {
                this.Err = "获得患者信息出错!";
                return false;
            }
            if (!this.Calculate(myObj, myFee, refFT))
            {
                this.Err = "预结算计算失败!";
                return false;
            }
            if (UpdateSiMainInfo(myObj) == -1)
            {
                this.Err = "更新医保患者结算主表出错!";
                return false;
            }

            obj.SIMainInfo = myObj.SIMainInfo;

            return true;
        }

        #region 执行存储过程
        /// <summary>
        /// 1.获得医保患者计算项目比例后德自费总额和统筹总额 2.按照医保待遇算法后计算德最终自费和统筹费用   
        /// </summary>
        /// <param name="inpatient_no">病人住院流水号</param>
        /// <param name="ownCost">自费金额</param>
        /// <param name="pubCost">公费金额</param>
        /// <param name="realOwnCost">计算比例后自费金额</param>
        /// <param name="realPubCost">计算比例后公费金额</param>
        /// <param name="Error">错误信息</param>
        /// <returns>-1 操作数据库失败 0 成功 </returns>
        public int ExecutePackage(string inpatient_no, ref decimal ownCost, ref decimal pubCost, ref decimal realOwnCost, ref decimal realPubCost, ref string Error)
        {
            //定义字符串 存储SQL语句
            string strSql = "";
            string strReturn = "";
            int iReturn = 0;
            //获取SQL语句
            if (this.Sql.GetSql("RADT.Inpatient.ExecutePackage.ComputeSICost", ref strSql) == -1)
            {
                this.Err = "没有找到 RADT.Inpatient.ExecutePackage 字段!";
                this.ErrCode = "-1";
                return -1;
            }
            //格式化字符串
            strSql = string.Format(strSql, inpatient_no, "1", "1", "1", "1", "1", "1");

            if (this.ExecEvent(strSql, ref strReturn) == -1)
            {
                this.Err = "执行存储过程出错!PRC_PRE_BALANCE";
                this.ErrCode = "PRC_PRE_BALANCE";
                this.WriteErr();
                return -1;
            }

            string[] s = strReturn.Split(',');

            try
            {
                ownCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[0]), 2);
                pubCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[1]), 2);
                realOwnCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[2]), 2);
                realPubCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[3]), 2);
                iReturn = Neusoft.FrameWork.Function.NConvert.ToInt32(s[4]);
                Error = s[5];
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err += ex.Message;
                return -1;
            }
            return iReturn;
        }
        /// <summary>
        /// （报表用）1.获得医保患者计算项目比例后德自费总额和统筹总额 2.按照医保待遇算法后计算德最终自费和统筹费用   
        /// </summary>
        /// <param name="inpatient_no">病人住院流水号</param>
        /// <param name="ownCost">自费金额</param>
        /// <param name="pubCost">公费金额</param>
        /// <param name="realOwnCost">计算比例后自费金额</param>
        /// <param name="realPubCost">计算比例后公费金额</param>
        /// <param name="drugOwnCost">自费药品</param>
        /// <param name="drugPubCost">统筹药品</param>
        /// <param name="Error">错误信息</param>
        /// <returns>-1 操作数据库失败 0 成功</returns>
        public int ExecutePackage(string inpatient_no, ref decimal ownCost, ref decimal pubCost, ref decimal realOwnCost, ref decimal realPubCost, ref decimal drugOwnCost, ref decimal drugPubCost, ref string Error)
        {
            //定义字符串 存储SQL语句
            string strSql = "";
            string strReturn = "";
            int iReturn = 0;
            //获取SQL语句
            if (this.Sql.GetSql("RADT.Inpatient.ExecutePackage.ComputeSICost.2", ref strSql) == -1)
            {
                this.Err = "没有找到 RADT.Inpatient.ExecutePackage 字段!";
                this.ErrCode = "-1";
                return -1;
            }
            //格式化字符串
            strSql = string.Format(strSql, inpatient_no, "1", "1", "1", "1", "1", "1", "1", "1");

            if (this.ExecEvent(strSql, ref strReturn) == -1)
            {
                this.Err = "执行存储过程出错!PRC_PRE_BALANCE";
                this.ErrCode = "PRC_PRE_BALANCE";
                this.WriteErr();
                return -1;
            }

            string[] s = strReturn.Split(',');

            try
            {
                ownCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[0]), 2);
                pubCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[1]), 2);
                realOwnCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[2]), 2);
                realPubCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[3]), 2);
                drugOwnCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[4]), 2);
                drugPubCost = Neusoft.FrameWork.Public.String.FormatNumber(Neusoft.FrameWork.Function.NConvert.ToDecimal(s[5]), 2);

                iReturn = Neusoft.FrameWork.Function.NConvert.ToInt32(s[6]);
                Error = s[7];
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err += ex.Message;
                return -1;
            }
            return iReturn;
        }

        #endregion

        /// <summary>
        /// 医保预结算
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="myFeeItemList"></param>
        /// <param name="refFT"></param>
        /// <returns></returns>
        public bool Calculate(Neusoft.HISFC.Models.RADT.PatientInfo obj, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList myFeeItemList, Neusoft.HISFC.Models.Base.FT refFT)
        {
            if (myFeeItemList == null || myFeeItemList.FT == null)
            {
                return true;
            }

            if (obj.SIMainInfo == null)
            {
                //m_error = "个人信息无效！";
                return false;
            }

            //m_error = "";


            //累计医疗费用

            obj.SIMainInfo.TotCost += myFeeItemList.FT.TotCost;	//上传总金额


            if (myFeeItemList.FT.TotCost == myFeeItemList.FT.OwnCost)
            {
                obj.SIMainInfo.OwnCost += myFeeItemList.FT.OwnCost;//个人自费项目金额
            }
            else
            {
                obj.SIMainInfo.ItemYLCost += myFeeItemList.FT.OwnCost;//个人自付金额（乙类自付部分）
            }



            //获取该类人员的医保支付比例列表
            string pactCode = obj.Pact.ID;		//合同单位代码
            string emplType = obj.SIMainInfo.EmplType;	//人员类别,1在职..

            // 分段支付比例列表

            ArrayList rateList = this.GetAllInsuranceInfo(pactCode, obj.SIMainInfo.EmplType);

            if (rateList.Count == 0)
            {
                //m_error = "医保支付比例列表无效！";
                return false;
            }


            // 纳入医保统筹总费用
            decimal nrzfy = obj.SIMainInfo.TotCost - obj.SIMainInfo.OwnCost - obj.SIMainInfo.ItemYLCost;

            decimal zje1 = 0;
            decimal zje2 = 0;
            decimal bfb = 0;
            decimal gffy1 = 0;
            decimal gffy2 = 0;

            decimal[] zf_fy = new decimal[rateList.Count];	//存放各部分自付金额

            for (int i = 0; i < rateList.Count; i++)
            {
                zf_fy[i] = 0;
            }


            // 按照纳入医保统筹总费用计算各部分统筹/个人支付费用
            for (int i = 0; i < rateList.Count; i++)
            {
                Neusoft.HISFC.Models.SIInterface.Insurance rate = (Neusoft.HISFC.Models.SIInterface.Insurance)rateList[i];

                zje1 = zje2;
                gffy1 = gffy2;

                zje2 = rate.EndCost;	//限额	(decimal)DbAssist.GetItemNumber(drv,"zje",0);
                bfb = rate.Rate * 100;		//比例	(decimal)DbAssist.GetItemNumber(drv,"zfbl",100);

                if (nrzfy <= gffy1) break;

                if (bfb == 100)
                {
                    if (zje2 == 0)
                    {
                        zf_fy[i] += (nrzfy - gffy1);
                    }
                    else
                    {
                        if (nrzfy >= zje2)
                        {
                            zf_fy[i] += zje2;
                        }
                        else
                        {
                            zf_fy[i] += nrzfy;
                        }
                    }

                    gffy2 = zf_fy[i]; // needed
                }
                else
                {
                    gffy2 = zje2 / (100 - bfb) * 100 + gffy1;
                    if (nrzfy < gffy2) gffy2 = nrzfy;

                    zf_fy[i] += (gffy2 - gffy1) * bfb / 100;
                }
            }

            ////////////////////////////////////////////////////////////////

            decimal ybzf = 0;	//医保自付金额 = 起付部分 + 共付自付部分 + 超限额自付部分

            for (int i = 0; i < rateList.Count; i++)
            {
                ybzf += zf_fy[i];
            }

            //医保记帐支付金额 = 医疗费用 - 自费部分 - 自付部分
            obj.SIMainInfo.PubCost = obj.SIMainInfo.TotCost - obj.SIMainInfo.OwnCost - obj.SIMainInfo.ItemYLCost - ybzf;


            //obj.SIMainInfo.ItemPayCost	= 0;//部分项目自付金额

            obj.SIMainInfo.BaseCost = (rateList.Count > 0) ? zf_fy[0] : 0;	//个人起付金额
            obj.SIMainInfo.PubOwnCost = (rateList.Count > 1) ? zf_fy[1] : 0;	//个人自付金额

            obj.SIMainInfo.OverTakeOwnCost = 0;				//超统筹支付限额个人自付金额

            for (int i = 2; i < rateList.Count; i++)
            {
                obj.SIMainInfo.OverTakeOwnCost += zf_fy[i];	//超统筹支付限额个人自付金额
            }



            refFT.TotCost = obj.SIMainInfo.TotCost;
            refFT.OwnCost = obj.SIMainInfo.TotCost - obj.SIMainInfo.PubCost;
            refFT.PubCost = obj.SIMainInfo.PubCost;

            return true;

        }

        #endregion

        #region 医保传明细
        /// <summary>
        /// 获得医保患者要传递的明细信息
        /// </summary>
        /// <param name="pactCode"></param>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public ArrayList GetSIPersonDetail(string pactCode, string inpatientNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.GetSIPersonDetail.Select.1", ref strSql) == -1)
                return null;
            try
            {
                strSql = string.Format(strSql, pactCode, inpatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err = ex.Message;
                this.WriteErr();
                return null;
            }
            this.ExecQuery(strSql);
            try
            {
                ArrayList al = new ArrayList();

                while (Reader.Read())
                {
                    Compare obj = new Compare();
                    if (!Reader.IsDBNull(0))
                        obj.CenterItem.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[0].ToString());
                    obj.ID = Reader[1].ToString();
                    obj.Name = Reader[2].ToString();
                    obj.CenterItem.FeeCode = Reader[3].ToString();
                    obj.Specs = Reader[4].ToString();
                    obj.DoseCode = Reader[5].ToString();
                    //单价
                    obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[6].ToString());
                    //数量
                    obj.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[7].ToString());
                    //金额
                    obj.CenterItem.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8].ToString());

                    al.Add(obj);
                }

                Reader.Close();

                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err = ex.Message;
                this.WriteErr();
                Reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 回写已上传标志
        /// </summary>
        /// <param name="noteNo">处方号</param>
        /// <param name="seqNo">处方流水号</param>
        /// <param name="flag">项目标记, 1 药品 2 非药品</param>
        /// <returns>-1数据库操作失败, 0 没有找到行(并发), 1 成功</returns>
        public int UpdateUploadedDetailFlag(string noteNo, int seqNo, string flag)
        {
            string strSQL = "";

            if (flag == "1") //药品
            {
                if (this.Sql.GetSql("Fee.Interface.UpdateUploadedDetailFlag.Drug", ref strSQL) == -1)
                {
                    this.ErrCode = "-1";
                    this.Err = "获得更新药品上传SQL语句出错!";
                    return -1;
                }

            }
            else if (flag == "2")//非药品
            {
                if (this.Sql.GetSql("Fee.Interface.UpdateUploadedDetailFlag.Undrug", ref strSQL) == -1)
                {
                    this.ErrCode = "-1";
                    this.Err = "获得更新非药品上传SQL语句出错!";
                    return -1;
                }
            }
            else
            {
                return 0;
            }

            try
            {
                strSQL = string.Format(strSQL, noteNo, seqNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新医保要上传的明细信息
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <param name="flag">更新标记 0 没有上传 1 已经上传</param>
        /// <returns>-1更新失败 0 没有记录 >=1 更新成功</returns>
        public int UpdateAllDetailFlag(string inpatientNo, string flag)
        {
            string strSqlDrug = "", strSqlItem = "";
            int iReturnDrug = 0, iReturnItem = 0;
            if (this.Sql.GetSql("Fee.Interface.UpdateAllDetailFlag.Drug", ref strSqlDrug) == -1)
            {
                this.ErrCode = "-1";
                this.Err = "获得更新药品上传SQL语句出错!";
                return -1;
            }
            if (this.Sql.GetSql("Fee.Interface.UpdateAllDetailFlag.UnDrug", ref strSqlItem) == -1)
            {
                this.ErrCode = "-1";
                this.Err = "获得更新非药品上传SQL语句出错!";
                return -1;
            }
            if (Neusoft.FrameWork.Public.String.FormatString(strSqlDrug, out strSqlDrug, inpatientNo, flag) == -1)
            {
                this.Err += "药品SQL语句负值出错!";
                return -1;
            }
            if (Neusoft.FrameWork.Public.String.FormatString(strSqlItem, out strSqlItem, inpatientNo, flag) == -1)
            {
                this.Err += "非药品SQL语句负值出错!";
                return -1;
            }
            iReturnDrug = this.ExecNoQuery(strSqlDrug);
            if (iReturnDrug < 0)
            {
                return iReturnDrug;
            }
            iReturnItem = this.ExecNoQuery(strSqlItem);
            if (iReturnItem < 0)
            {
                return iReturnItem;
            }

            return iReturnItem + iReturnDrug;
        }
        /// <summary>
        /// 更新不上传的项目的上传标记
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <param name="condition">不上传项目列表</param>
        /// <param name="flag">0 需要上传 3 不上传</param>
        /// <returns>-1更新失败 0 没有记录 >=1 更新成功</returns>
        public int UpdateFlagForNotUpload(string inpatientNo, string condition, string flag)
        {
            string strSqlDrug = "", strSqlItem = "";
            int iReturnDrug = 0, iReturnItem = 0;
            if (this.Sql.GetSql("Fee.Interface.UpdateFlagForNotUpload.Drug", ref strSqlDrug) == -1)
            {
                this.ErrCode = "-1";
                this.Err = "获得更新不上传药品SQL语句出错!";
                return -1;
            }
            if (this.Sql.GetSql("Fee.Interface.UpdateFlagForNotUpload.UnDrug", ref strSqlItem) == -1)
            {
                this.ErrCode = "-1";
                this.Err = "获得更新不上传非药品SQL语句出错!";
                return -1;
            }
            //			if(Neusoft.FrameWork.Public.String.FormatString(strSqlDrug, out strSqlDrug, inpatientNo, flag) == -1)
            //			{
            //				this.Err += "药品SQL语句赋值出错!";
            //				return -1;
            //			}
            //			if(Neusoft.FrameWork.Public.String.FormatString(strSqlItem, out strSqlItem, inpatientNo, flag) == -1)
            //			{
            //				this.Err += "非药品SQL语句赋值出错!";
            //				return -1;
            //			}
            try
            {
                strSqlDrug = string.Format(strSqlDrug, inpatientNo, flag, condition);
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err = ex.Message;
                return -1;
            }
            try
            {
                strSqlItem = string.Format(strSqlItem, inpatientNo, flag, condition);
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err = ex.Message;
                return -1;
            }
            iReturnDrug = this.ExecNoQuery(strSqlDrug);
            if (iReturnDrug < 0)
            {
                return iReturnDrug;
            }
            iReturnItem = this.ExecNoQuery(strSqlItem);
            if (iReturnItem < 0)
            {
                return iReturnItem;
            }

            return iReturnItem + iReturnDrug;
        }
        #endregion

        #region 医保报表
        /// <summary>
        /// 获得指定月份之间的科室医保限额
        /// </summary>
        /// <param name="dtBegin">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <param name="inState">在院状态</param>
        /// <param name="pactCode">合同单位</param>
        /// <param name="ds">返回的显示信息</param>
        /// <returns>-1 失败 0 成功</returns>
        public int QueryDeptSiCost(DateTime dtBegin, DateTime dtEnd, string inState, string pactCode, ref DataSet ds)
        {
            string strSql = "";
            if (inState == "B")
            {
                if (this.Sql.GetSql("Fee.Interface.QueryDeptSiCost.DataSet.OUT", ref strSql) == -1)
                {
                    this.Err += "获得SQL语句出错!";
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, inState, dtBegin.ToString(), dtEnd.ToString(), pactCode) == -1)
                {
                    this.Err += "SQL语句负值出错!";
                    return -1;
                }
            }
            if (inState == "I")
            {
                if (this.Sql.GetSql("Fee.Interface.QueryDeptSiCost.DataSet.IN", ref strSql) == -1)
                {
                    this.Err += "获得SQL语句出错!";
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, pactCode) == -1)
                {
                    this.Err += "SQL语句负值出错!";
                    return -1;
                }
            }

            return this.ExecQuery(strSql, ref ds);
        }
        /// <summary>
        /// 获得一段时间内的病区医保患者用药情况
        /// </summary>
        /// <param name="dtBegin">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <param name="inState">在院状态</param>
        /// <param name="pactCode">合同单位</param>
        /// <param name="ds">返回的显示信息</param>
        /// <returns>-1 失败 0 成功</returns>
        public int QuerySIDeptDrug(DateTime dtBegin, DateTime dtEnd, string inState, string pactCode, ref DataSet ds)
        {
            string strSql = "";
            if (inState == "B")
            {
                if (this.Sql.GetSql("Fee.Interface.QuerySIDeptDrug.DataSet.OUT", ref strSql) == -1)
                {
                    this.Err += "获得SQL语句出错!";
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, dtBegin.ToString(), dtEnd.ToString(), pactCode) == -1)
                {
                    this.Err += "SQL语句负值出错!";
                    return -1;
                }
            }
            if (inState == "I")
            {
                if (this.Sql.GetSql("Fee.Interface.QuerySIDeptDrug.DataSet.IN", ref strSql) == -1)
                {
                    this.Err += "获得SQL语句出错!";
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, pactCode) == -1)
                {
                    this.Err += "SQL语句负值出错!";
                    return -1;
                }
            }

            return this.ExecQuery(strSql, ref ds);
        }
        /// <summary>
        /// 查询指定病区的医保患者的药品信息
        /// </summary>
        /// <param name="dtBegin">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <param name="deptCode">病区代码</param>
        /// <param name="inState">在院状态</param>
        /// <param name="pactCode">合同单位</param>
        /// <param name="ds">显示信息DataSet</param>
        /// <returns>-1 失败 0 成功</returns>
        public int QuerySIPateintDrugForDept(DateTime dtBegin, DateTime dtEnd, string deptCode, string inState, string pactCode, ref DataSet ds)
        {
            string strSql = "";
            if (inState == "O")
            {
                if (this.Sql.GetSql("Fee.Interface.QuerySIPateintDrugForDept.DataSet.OUT", ref strSql) == -1)
                {
                    this.Err += "获得SQL语句出错!";
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, deptCode, dtBegin.ToString(), dtEnd.ToString(), pactCode) == -1)
                {
                    this.Err += "SQL语句负值出错!";
                    return -1;
                }
            }
            if (inState == "I")
            {
                if (this.Sql.GetSql("Fee.Interface.QuerySIPateintDrugForDept.DataSet.IN", ref strSql) == -1)
                {
                    this.Err += "获得SQL语句出错!";
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, deptCode, pactCode, dtBegin.ToString(), dtEnd.ToString()) == -1)
                {
                    this.Err += "SQL语句负值出错!";
                    return -1;
                }
            }

            return this.ExecQuery(strSql, ref ds);
        }
        /// <summary>
        /// 查询指定病区的医保患者的药品信息, 报表2
        /// </summary>
        /// <param name="dtBegin">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <param name="deptCode">病区代码</param>
        /// <param name="inState">在院状态</param>
        /// <param name="pactCode">合同单位</param>
        /// <param name="ds">显示信息DataSet</param>
        /// <returns>-1 失败 0 成功</returns>
        public int QuerySIPateintDrugForDeptSec(DateTime dtBegin, DateTime dtEnd, string deptCode, string inState, string pactCode, ref DataSet ds)
        {
            string strSql = "";
            if (inState == "O")
            {
                if (this.Sql.GetSql("Fee.Interface.QuerySIPateintDrugForDeptSec.DataSet.OUT", ref strSql) == -1)
                {
                    this.Err += "获得SQL语句出错!";
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, deptCode, dtBegin.ToString(), dtEnd.ToString(), pactCode) == -1)
                {
                    this.Err += "SQL语句负值出错!";
                    return -1;
                }
            }
            if (inState == "I")
            {
                if (this.Sql.GetSql("Fee.Interface.QuerySIPateintDrugForDeptSec.DataSet.IN", ref strSql) == -1)
                {
                    this.Err += "获得SQL语句出错!";
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, deptCode, pactCode, dtBegin.ToString(), dtEnd.ToString()) == -1)
                {
                    this.Err += "SQL语句负值出错!";
                    return -1;
                }
            }

            return this.ExecQuery(strSql, ref ds);
        }
        /// <summary>
        ///	获得出院结算的医保患者信息
        /// </summary>
        /// <param name="dtBegin">住院登记开始时间</param>
        /// <param name="dtEnd">住院登记结束时间</param>
        /// <param name="pactCode">合同单位代码</param>
        /// <returns></returns>
        public ArrayList QueryOutHosPatients(DateTime dtBegin, DateTime dtEnd, string pactCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.QueryOutHosPatients.Select.1", ref strSql) == -1)
            {
                this.Err += "获得SQL语句出错!";
                return null;
            }
            if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, dtBegin.ToString(), dtEnd.ToString(), pactCode) == -1)
            {
                this.Err += "SQL语句负值出错!";
                return null;
            }
            this.ExecQuery(strSql);
            ArrayList al = new ArrayList();
            string temp = "";
            try
            {
                while (Reader.Read())
                {
                    temp = Reader[0].ToString();
                    al.Add(temp);
                }

                this.Reader.Close();
                return al;
            }
            catch (Exception ex)
            {
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                this.Err += ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 获得当前所有在院医保患者
        /// </summary>
        /// <param name="dtBegin">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <param name="pactCode">合同单位代码</param>
        /// <returns>null 失败 ArrayList.Count > 1 成功</returns>
        public ArrayList QueryInHosPatients(DateTime dtBegin, DateTime dtEnd, string pactCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.QueryInHosPatient.Select.1", ref strSql) == -1)
            {
                this.Err += "获得SQL语句出错!";
                return null;
            }
            if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, dtBegin.ToString(), dtEnd.ToString(), pactCode) == -1)
            {
                this.Err += "SQL语句负值出错!";
                return null;
            }
            this.ExecQuery(strSql);
            ArrayList al = new ArrayList();
            string temp = "";
            try
            {
                while (Reader.Read())
                {
                    temp = Reader[0].ToString();
                    al.Add(temp);
                }

                this.Reader.Close();
                return al;
            }
            catch (Exception ex)
            {
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                this.Err += ex.Message;
                return null;
            }
        }

        /// <summary>
        ///	获得出院结算的医保患者信息
        /// </summary>
        /// <param name="dtBegin">住院登记开始时间</param>
        /// <param name="dtEnd">住院登记结束时间</param>
        /// <param name="pactCode">合同单位代码</param>
        /// <param name="sqlWhere">科室代码</param>
        /// <returns></returns>
        public ArrayList QueryOutHosPatients(DateTime dtBegin, DateTime dtEnd, string pactCode, string sqlWhere)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.QueryOutHosPatients.Select.1", ref strSql) == -1)
            {
                this.Err += "获得SQL语句出错!";
                return null;
            }
            if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, dtBegin.ToString(), dtEnd.ToString(), pactCode) == -1)
            {
                this.Err += "SQL语句负值出错!";
                return null;
            }
            strSql = strSql + sqlWhere;
            this.ExecQuery(strSql);
            ArrayList al = new ArrayList();
            string temp = "";
            try
            {
                while (Reader.Read())
                {
                    temp = Reader[0].ToString();
                    al.Add(temp);
                }

                this.Reader.Close();
                return al;
            }
            catch (Exception ex)
            {
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                this.Err += ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 获得当前所有在院医保患者
        /// </summary>
        /// <param name="dtBegin">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <param name="pactCode">合同单位代码</param>
        /// <param name="sqlWhere">科室代码</param>
        /// <returns>null 失败 ArrayList.Count > 1 成功</returns>
        public ArrayList QueryInHosPatients(DateTime dtBegin, DateTime dtEnd, string pactCode, string sqlWhere)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Interface.QueryInHosPatient.Select.1", ref strSql) == -1)
            {
                this.Err += "获得SQL语句出错!";
                return null;
            }
            if (Neusoft.FrameWork.Public.String.FormatString(strSql, out strSql, dtBegin.ToString(), dtEnd.ToString(), pactCode) == -1)
            {
                this.Err += "SQL语句负值出错!";
                return null;
            }
            strSql = strSql + sqlWhere;
            this.ExecQuery(strSql);
            ArrayList al = new ArrayList();
            string temp = "";
            try
            {
                while (Reader.Read())
                {
                    temp = Reader[0].ToString();
                    al.Add(temp);
                }

                this.Reader.Close();
                return al;
            }
            catch (Exception ex)
            {
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                this.Err += ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 查询医保病人费用构成
        /// </summary>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="state"></param>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public DataSet QueryFeeStruct(string dtBegin, string dtEnd, string[] state, string reportName)
        {
            string strSql = "";
            DataSet dsFee = new DataSet();
            if (this.Sql.GetSql("Fee.Interface.QueryFeeStruct", ref strSql) == -1)
            {
                this.Err = "Can't Find The SqlExpression";
                return null;
            }
            strSql = System.String.Format(strSql, reportName, dtBegin, dtEnd, state[0] + "','" + state[1]);
            this.ExecQuery(strSql, ref dsFee);
            return dsFee;
        }
        /// <summary>
        /// 按照科室或者全院查询社会医疗保险定点机构医疗费用病区明细
        /// </summary>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="DeptCode"></param>
        /// <returns></returns>
        public DataSet QuerySIDeptFee(string dtBegin, string dtEnd, string DeptCode)
        {
            string strSql = "";
            DataSet dsFee = new DataSet();
            Neusoft.HISFC.BizLogic.Manager.Department manager = new Neusoft.HISFC.BizLogic.Manager.Department();
            if (this.Sql.GetSql("Fee.Interface.QuerySIDeptFee", ref strSql) == -1)
            {
                this.Err = "Can't Find the Sql";
                return null;
            }
            if (DeptCode == "")
            {
                strSql = System.String.Format(strSql, dtBegin, dtEnd);
                strSql += " ORDER BY A.DEPT_NAME";
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = DeptCode;
                ArrayList alDept = manager.GetDeptFromNurseStation(obj);
                DeptCode = "";
                for (int i = 0; i < alDept.Count; i++)
                {
                    DeptCode += (alDept[i] as  FrameWork.Models.NeuObject).ID + "','";
                }
                DeptCode = DeptCode.Substring(0, DeptCode.Length - 2);
                strSql += " AND A.DEPT_CODE IN( '" + DeptCode + ")";
                strSql += " ORDER BY A.DEPT_NAME";
                strSql = System.String.Format(strSql, dtBegin, dtEnd);
            }
            this.ExecQuery(strSql, ref dsFee);
            return dsFee;
        }
        /// <summary>
        /// 查询医保费用对帐明细
        /// </summary>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public DataSet QueryFeeCollateDetail(string dtBegin, string dtEnd, string reportName)
        {
            string strSql = "";
            DataSet dsFee = new DataSet();
            if (this.Sql.GetSql("Fee.Interface.QueryFeeCollateDetail", ref strSql) == -1)
            {
                this.Err = "Can't Find The Sql";
                return null;
            }
            strSql = System.String.Format(strSql, dtBegin, dtEnd, reportName);
            this.ExecQuery(strSql, ref dsFee);
            return dsFee;
        }
        /// <summary>
        /// 查询医保费用结算申请信息
        /// </summary>
        /// <param name="dtBegin">起始日期</param>
        /// <param name="dtEnd">终止日期</param>
        /// <param name="state">住院or门诊特定项目</param>
        /// <param name="empl_type">在职or离休</param>
        /// <returns></returns>
        public DataSet QueryStatFeePactByInsure(string dtBegin, string dtEnd, string[] state, string[] empl_type)
        {
            string strSql = "";
            DataSet ds = new DataSet();
            if (this.Sql.GetSql("Fee.Interface.QueryStatFeePactByInsure", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql";
                return null;
            }
            strSql = System.String.Format(strSql, dtBegin, dtEnd, state[0] + "','" + state[1], empl_type[0] + "','" + empl_type[1]);
            this.ExecQuery(strSql, ref ds);
            return ds;
        }
        #endregion

        #region 医保项目显示
        /// <summary>
        /// 获得项目标记
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string ShowItemFlag(Neusoft.HISFC.Models.Base.Item item)
        {
            bool b1, b2, b3, b4;
            //if (item.IsPharmacy)
            if(item.ItemType==HISFC.Models.Base.EnumItemType.Drug)
            {
                Neusoft.HISFC.Models.Pharmacy.Item o = item as Neusoft.HISFC.Models.Pharmacy.Item;
                b1 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag);
                b2 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag1);
                b3 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag2);
                b4 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag3);
            }
            #region {8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
            else if (item.ItemType == HISFC.Models.Base.EnumItemType.MatItem)
            {
                Neusoft.HISFC.Models.FeeStuff.MaterialItem o = item as Neusoft.HISFC.Models.FeeStuff.MaterialItem;

                b1 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag);
                b2 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag1);
                b3 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag2);
                b4 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag3);
            }
            #endregion
            else
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug o = item as Neusoft.HISFC.Models.Fee.Item.Undrug;

                b1 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag);
                b2 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag1);
                b3 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag2);
                b4 = Neusoft.FrameWork.Function.NConvert.ToBoolean(o.SpecialFlag3);
            }
            string s = "";
            if (b1) s = s + "X";
            if (b2) s = s + "S";
            if (b3) s = s + "Z";
            if (b4) s = s + "T";
            if (s != "") s = "[" + s + "]";
            return s;
        }
        /// <summary>
        /// 获得项目类别 甲,..
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public string ShowItemGrade(string ItemCode)
        {
            Neusoft.HISFC.Models.SIInterface.Compare obj = null;
            int iReturn = this.GetCompareSingleItem("2", ItemCode, ref obj);
            if (iReturn == -1)
            {
                return "获得医保比例出错！";
            }
            else if (iReturn == -2)//没对照
            {
                return "自费【100%】";
            }
            else
            {
                switch (Neusoft.FrameWork.Function.NConvert.ToInt32(obj.CenterItem.ItemGrade))
                {
                    case 1:
                        return "甲类【" + (obj.CenterItem.Rate * 100).ToString() + "%】";
                    case 2:
                        return "乙类【" + (obj.CenterItem.Rate * 100).ToString() + "%】";
                    case 3:
                        return "自费【" + (obj.CenterItem.Rate * 100).ToString() + "%】";
                    default:
                        break;
                }
            }
            return "";

        }

        /// <summary>
        /// 传入ItemGrade编码，返回甲，乙，丙类
        /// wolf 添加,静态的大家都可以用
        /// </summary>
        /// <param name="itemGrade"></param>
        /// <returns></returns>
        public static string ShowItemGradeByCode(string itemGrade)
        {
            if (itemGrade == "1")
            {
                return "甲类";
            }
            else if (itemGrade == "2")
            {
                return "乙类";
            }
            else if (itemGrade == "3")
            {
                return "自费";
            }

            return "未知";

        }

        #region addby xuewj 2010-9-15 {A79FEAFD-BD92-4bff-A74B-A41055D8D15F}
        /// <summary>
        /// 根据合同单位、项目编码获得项目类别 甲,..
        /// </summary>
        /// <param name="pactCode">合同单位</param>
        /// <param name="itemCode">项目编码</param>
        /// <returns></returns>
        public string ShowItemGradeByPactAndItemCode(string pactCode, string itemCode)
        {
            #region 02省离休 07省生育 跟03普通省保用同一套对照 {F6E31B09-7A4D-4268-B623-9F2C7FF1B03A} wbo 2010-10-21
            switch (pactCode)
            {
                case "02":
                case "03":
                case "07":
                    pactCode = "03";
                    break;
            }
            #endregion

            Neusoft.HISFC.Models.SIInterface.Compare obj = null;
            int iReturn = this.GetCompareSingleItem(pactCode, itemCode, ref obj);
            if (iReturn == -1)
            {
                return "获得医保比例出错！";
            }
            else if (iReturn == -2)//没对照
            {
                return "自费【100%】";
            }
            else
            {
                switch (Neusoft.FrameWork.Function.NConvert.ToInt32(obj.CenterItem.ItemGrade))
                {
                    case 1:
                        return "甲类【" + (obj.CenterItem.Rate * 100).ToString() + "%】";
                    case 2:
                        return "乙类【" + (obj.CenterItem.Rate * 100).ToString() + "%】";
                    case 3:
                        return "自费【" + (obj.CenterItem.Rate * 100).ToString() + "%】";
                    default:
                        return  "【"+ (obj.CenterItem.Rate * 100).ToString() + "%】";
                }
            }
            return "";

        }
        #endregion

        #region addby xuewj 2010-10-1 {EA10BA8E-CBF4-4348-8BCE-9AD0D193CAE1}
        /// <summary>
        /// 根据合同单位、项目编码获得适应症
        /// </summary>
        /// <param name="pactCode">合同单位</param>
        /// <param name="itemCode">项目编码</param>
        /// <returns></returns>
        public string ShowItemIndicationByPactAndItemCode(string pactCode, string itemCode)
        {
            #region 02省离休 07省生育 跟03普通省保用同一套对照 {F6E31B09-7A4D-4268-B623-9F2C7FF1B03A} wbo 2010-10-21
            switch (pactCode)
            {
                case "02":
                case "03":
                case "07":
                    pactCode = "03";
                    break;
            }
            #endregion

            Neusoft.HISFC.Models.SIInterface.Compare obj = null;
            int iReturn = this.GetCompareSingleItem(pactCode, itemCode, ref obj);
            if (iReturn == -1)
            {
                return "获得医保适应症出错！";
            }
            else if (iReturn == -2)//没对照
            {
                return "无";
            }

            return obj.CenterItem.Memo;

        }
        #endregion

        #endregion
    }
}

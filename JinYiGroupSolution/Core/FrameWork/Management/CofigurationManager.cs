using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.FrameWork.Models;
namespace Neusoft.FrameWork.Management
{
     /// <summary>
    /// [功能描述: 配置设置类]<br></br>
    /// [创建者:   张凯钧]<br></br>
    /// [创建时间: 2008.5.19]<br></br>
    /// <说明>
    ///    实现先IConfigurationManger接口
    /// </说明>

    public class ConfigurationManager : Database
    {
        #region 共有成员
        /// <summary>
        /// 保存配置属性
        /// </summary>
        /// <param name="neuConfiguration"></param>
        /// <returns></returns>
        public int Save(NeuConfiguration neuConfiguration)
        {
            int ret = Update(neuConfiguration);
            if (ret == 0)
            {
                Insert(neuConfiguration);
            }
            return 0;
        }

        /// <summary>
        /// 获取配置属性
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public NeuConfiguration GetConfiguration(string id, string type)
        {
            return GetEntity(id, type);
        }


        /// <summary>
        /// 
        /// A9D33964-33F0-4bfd-B28E-EBC425F97C99
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        public string GetResourceId(String formId)
        {
            string a = "";
            //AbstractSqlModel sqlModel = new SqlModel("ConfigurationManagerEntity.Get.ResourceId");
            //sqlModel["ResourceId"] = formId;

            string sql = "";
            if (this.Sql.GetSql("CONFIGURATIONMANAGERENTITY.GET.RESOURCEID", ref sql) == -1) return null;
            try
            {
                // {A6AEB319-8190-4188-BFCB-825C83A14C89}

                //sql = string.Format(sql,formId);
                sql = string.Format(sql, formId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) <= 0) return null;
            while (this.Reader.Read())
            {
                a = Reader[0].ToString();
            }
            this.Reader.Close();
            return a;
        }

        public int DeleteConfiguration(string id, string type)
        {
            //AbstractSqlModel sqlModel = new SqlModel("NeuConfiguration.Delete");
            //sqlModel["id"] = id;
            //sqlModel["type"] = type;
            //return base.ExecuteNonQuery(sqlModel);

            string sql = "";
            if (this.Sql.GetSql("CONFIGURATIONMANAGERENTITY.DELETE", ref sql) == -1) return -1;
            try
            {
                // {A6AEB319-8190-4188-BFCB-825C83A14C89}
                //sql = string.Format(sql,formId);
                sql = string.Format(sql, type, id);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 查询所有报表
        /// </summary>
        /// <returns></returns>
        public List<NeuConfiguration> QueryAllReporter()
        {
            List<NeuConfiguration> reportList = new List<NeuConfiguration>();
            //string sql = "";
            //if(this.Sql.GetSql("Reporter.QueryAll",ref sql)==-1) return null;
            //if(this.ExecQuery(sql)==-1) return null;
            string sql = "";
            if (this.Sql.GetSql("Reporter.QueryAll", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) <= 0) return null;
            while (this.Reader.Read())
            {
                NeuConfiguration NeuConfiguration = new NeuConfiguration();
                NeuConfiguration = new NeuConfiguration();
                NeuConfiguration.Type = Reader[0].ToString();
                NeuConfiguration.ID = Reader[1].ToString();
                NeuConfiguration.Remark = Reader[6].ToString();
                reportList.Add(NeuConfiguration);
            }

            return reportList;
        }
        #endregion

        #region 私有成员
        private int Insert(NeuConfiguration NeuConfiguration)
        {
            //AbstractSqlModel sqlModel = new SqlModel("NeuConfiguration.Insert");
            //if (String.IsNullOrEmpty(NeuConfiguration.Id) )
            //{
            //    NeuConfiguration.Id = this.GetSequence();
            //}
            //sqlModel["id"] = NeuConfiguration.Id;
            //sqlModel["type"] = NeuConfiguration.Type;
            //sqlModel["config_xml"] = NeuConfiguration.ConfigXml.OuterXml;
            //sqlModel["oper_code"] = NeuConfiguration.OperCode;
            //sqlModel["oper_date"] = NeuConfiguration.OperDate;
            //sqlModel["valid_state"] = (NConvert.ToInt32(NeuConfiguration.ValidState)).ToString();
            //sqlModel["remark"] = NeuConfiguration.Remark;
            //return base.ExecuteNonQuery(sqlModel);

            string[] args = new string[]{
            NeuConfiguration.Remark,
            NeuConfiguration.Type,
            NeuConfiguration.ID,
            NeuConfiguration.ConfigString,
            FrameWork.Function.NConvert.ToInt32(NeuConfiguration.IsValidState).ToString(),
            NeuConfiguration.OperCode,
            NeuConfiguration.OperDate.ToString()
            };

            string sql = "";
            if (this.Sql.GetSql("CONFIGURATIONMANAGERENTITY.INSERT", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;

        }

        private int Update(NeuConfiguration NeuConfiguration)
        {
            //AbstractSqlModel sqlModel = new SqlModel("NeuConfiguration.Update");
            //sqlModel["id"] = NeuConfiguration.Id;
            //sqlModel["type"] = NeuConfiguration.Type;
            //sqlModel["config_xml"] = NeuConfiguration.ConfigXml.OuterXml;
            //sqlModel["oper_code"] = NeuConfiguration.OperCode;
            //sqlModel["oper_date"] = NeuConfiguration.OperDate;
            //sqlModel["valid_state"] = (NConvert.ToInt32(NeuConfiguration.ValidState)).ToString();
            //sqlModel["remark"] = NeuConfiguration.Remark;
            //return base.ExecuteNonQuery(sqlModel);
            string[] args = new string[]{
            NeuConfiguration.Type,
            NeuConfiguration.ID,
            NeuConfiguration.Remark,
            NeuConfiguration.ConfigString,
            FrameWork.Function.NConvert.ToInt32(NeuConfiguration.IsValidState).ToString(),
            NeuConfiguration.OperCode,
            NeuConfiguration.OperDate.ToString()
            };

            string sql = "";
            if (this.Sql.GetSql("CONFIGURATIONMANAGERENTITY.UPDATE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;

            return 0;
        }

        private NeuConfiguration GetEntity(string id, string type)
        {
            ////

            ////AbstractSqlModel sqlModel = new SqlModel("ConfigurationManagerEntity.Get");
            ////sqlModel["id"] = id;
            ////sqlModel["type"] = type;

            ////using (DbDataReader reader = base.ExecuteReader(sqlModel))
            ////{
            ////}

            NeuConfiguration neuConfiguration = null;
            string sql = "";
            if (this.Sql.GetSql("CONFIGURATIONMANAGERENTITY.GET", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql,type,id);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) <= 0) return null;
            while (this.Reader.Read())
            {
                neuConfiguration = new NeuConfiguration();
                neuConfiguration.Type = Reader[0].ToString();
                neuConfiguration.ID = Reader[1].ToString();
                neuConfiguration.ConfigString = Reader[2].ToString();
                neuConfiguration.OperCode = Reader[3].ToString();
                if (!Reader.IsDBNull(4))
                    neuConfiguration.OperDate = DateTime.Parse(Reader[4].ToString());
                neuConfiguration.IsValidState =FrameWork.Function.NConvert.ToBoolean(Reader[5].ToString());
                neuConfiguration.Remark = Reader[6].ToString();
            }
            this.Reader.Close();
            return neuConfiguration;
        }

        #endregion
    }
}

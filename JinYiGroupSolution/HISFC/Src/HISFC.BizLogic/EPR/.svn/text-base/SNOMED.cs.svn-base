using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
    #region SNOPMED
    /// <summary>
    /// SNOPMED管理类
    /// </summary>
    public class SNOMED : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 临床路径项目管理类
        /// </summary>
        public SNOMED()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 获得SNOPMED

        /// <summary>
        /// 获得所有项目列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetSNOPMED()
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("ClinicalPath.SNOPMED.Get.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到ClinicalPath.SNOPMED.Get.Select字段!";
                return null;
            }

            return myGetSNOPMED(strSQL);
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentCode">父级编码</param>
        /// <param name="bChild">是否包含子类</param>
        /// <returns></returns>
        public ArrayList GetSNOPMED(string parentCode, bool bChild)
        {
            string strSQL = "";
            string strSQLWhere = "";
            //取SQL语句
            if (this.Sql.GetSql("ClinicalPath.SNOPMED.Get.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到ClinicalPath.SNOPMED.Get.Select字段!";
                return null;
            }
            if (bChild)
            {
                //取SQL语句
                if (this.Sql.GetSql("ClinicalPath.SNOPMED.Get.Where.2", ref strSQLWhere) == -1)
                {
                    this.Err = "没有找到ClinicalPath.SNOPMED.Get.Where.2字段!";
                    return null;
                }
            }
            else
            {
                //取SQL语句
                if (this.Sql.GetSql("ClinicalPath.SNOPMED.Get.Where.3", ref strSQLWhere) == -1)
                {
                    this.Err = "没有找到ClinicalPath.SNOPMED.Get.Where.3字段!";
                    return null;
                }
            }
            try
            {
                strSQLWhere = string.Format(strSQLWhere, parentCode);
            }
            catch { return null; }

            return myGetSNOPMED(strSQL + " " + strSQLWhere);
        }
        /// <summary>
        /// 获得单个项目
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.EPR.SNOMED GetSNOPMED(string id)
        {
            string strSQL = "";
            string strSQLWhere = "";

            //取SQL语句
            if (this.Sql.GetSql("ClinicalPath.SNOPMED.Get.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到ClinicalPath.SNOPMED.Get.Select字段!";
                return null;
            }

            //取SQL语句
            if (this.Sql.GetSql("ClinicalPath.SNOPMED.Get.Where.1", ref strSQLWhere) == -1)
            {
                this.Err = "没有找到ClinicalPath.SNOPMED.Get.Where.1字段!";
                return null;
            }
            try
            {
                strSQLWhere = string.Format(strSQLWhere, id);
            }
            catch { return null; }

            ArrayList al = myGetSNOPMED(strSQL + " " + strSQLWhere);
            if (al == null)
                return null;
            else if (al.Count == 0)
                return null;
            else
                return al[0] as Neusoft.HISFC.Models.EPR.SNOMED;


        }

        /// <summary>
        /// 获得所有项目列表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet GetSNOPMEDs()
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("ClinicalPath.SNOPMED.Get.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到ClinicalPath.SNOPMED.Get.Select字段!";
                return null;
            }

            System.Data.DataSet ds = new System.Data.DataSet();
            if (this.ExecQuery(strSQL, ref ds) == -1)
                return null;

            return ds;
        }

        /// <summary>
        /// 获得项目信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected ArrayList myGetSNOPMED(string sql)
        {
            if (this.ExecQuery(sql) == -1) return null;

            ArrayList al = new ArrayList();

            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.EPR.SNOMED item = new Neusoft.HISFC.Models.EPR.SNOMED();
                item.ID = this.Reader[0].ToString();
                item.Name = this.Reader[1].ToString();
                item.SNOPCode = this.Reader[2].ToString();
                item.EnglishName = this.Reader[3].ToString();
                item.DiagnoseCode = this.Reader[4].ToString();
                item.ParentCode = this.Reader[5].ToString();
                item.Memo = this.Reader[6].ToString();
                item.SpellCode = this.Reader[7].ToString();
                item.WBCode = this.Reader[8].ToString();
                item.UserCode = this.Reader[9].ToString();
                item.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[10]);
                try
                {
                    item.User01 = this.Reader[11].ToString(); //isleaf
                }
                catch { }
                al.Add(item);
            }
            this.Reader.Close();
            return al;
        }
        #endregion

        #region 更新SNOPMED
        /// <summary>
        /// 更新单个项目列表
        /// <param name="code">编码</param>
        /// </summary>
        /// <returns></returns>
        public int UpdateSNOPMED(Neusoft.HISFC.Models.EPR.SNOMED s)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("EPR.SNOMED.Update.1", ref strSQL) == -1)
            {
                this.Err = "没有找到EPR.SNOMED.Update.1字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, s.ParentCode, s.ID, s.SNOPCode, s.Name, s.EnglishName, s.SpellCode, s.WBCode, s.DiagnoseCode, s.Memo, s.UserCode, s.SortID);
            }
            catch { return -1; }
            return this.ExecNoQuery(strSQL);
            
        }

        /// <summary>
        /// 更新单个项目列表的父级编码
        /// <param name="code">编码</param>
        /// </summary>
        /// <returns></returns>
        public int UpdateSNOPMEDParentCode(Neusoft.HISFC.Models.EPR.SNOMED s)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("EPR.SNOMED.Update.2", ref strSQL) == -1)
            {
                this.Err = "没有找到EPR.SNOMED.Update.2字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, s.ParentCode);
            }
            catch { return -1; }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 删除SNOPMED
        /// <summary>
        /// 删除编码为code的记录
        /// <param name="code">编码</param>
        /// </summary>
        /// <returns></returns>
        public int DelSNOPMEDByCode(string code)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("EPR.SNOMED.Delet.2", ref strSQL) == -1)
            {
                this.Err = "没有找到EPR.SNOMED.Delet.2字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, code);
            }
            catch { return -1; }
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 删除父级编码为parentcode的记录
        /// <param name="parentcode">父级编码</param>
        /// </summary>
        /// <returns></returns>
        public int DelSNOPMEDByPCode(string parentcode)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("EPR.SNOMED.Delet.1", ref strSQL) == -1)
            {
                this.Err = "没有找到EPR.SNOMED.Delet.1字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, parentcode);
            }
            catch { return -1; }
            return this.ExecNoQuery(strSQL);
        }

        #endregion

        #region 插入一条SNOPMED
        /// <summary>
        /// 插入一条SNOPMED记录
        /// <param name="s">snomed</param>
        /// </summary>
        /// <returns></returns>
        public int InsertSNOMED(Neusoft.HISFC.Models.EPR.SNOMED s)
        {
            string strSQL = "";

            //取SQL语句
            if (this.Sql.GetSql("EPR.SNOMED.Insert", ref strSQL) == -1)
            {
                this.Err = "没有找到EPR.SNOMED.Delet.1字段!";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, s.ParentCode, s.ID, s.SNOPCode, s.Name, s.EnglishName, s.SpellCode, s.WBCode, s.DiagnoseCode, s.Memo, s.UserCode, s.SortID);
            }
            catch { return -1; }
            return this.ExecNoQuery(strSQL);

        }

        #endregion

    }
    #endregion
}
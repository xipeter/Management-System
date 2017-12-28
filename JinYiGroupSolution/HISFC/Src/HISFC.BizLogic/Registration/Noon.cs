using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Registration
{
    public class Noon:Neusoft.FrameWork.Management.Database
    {
        private ArrayList al = null;
        /// <summary>
        /// 午别实体
        /// </summary>
        private Neusoft.HISFC.Models.Base.Noon noon = null;

        /// <summary>
        /// 插入午别表
        /// </summary>
        /// <param name="noon"></param>
        /// <returns></returns>
        public int Insert(Neusoft.HISFC.Models.Base.Noon noon)
        {
            string sql = "";

            if (this.Sql.GetSql("Registration.DoctSchema.Insert.2", ref sql) == -1) return -1;

            try
            {
                sql = string.Format(sql, noon.ID, noon.Name, noon.StartTime.ToString(), noon.EndTime.ToString(),
                    "", DateTime.MinValue.ToString());

                return this.ExecNoQuery(sql);

            }
            catch (Exception e)
            {
                this.Err = "插入午别信息表出错!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 删除一条午别记录
        /// </summary>
        /// <param name="noon"></param>
        /// <returns></returns>
        public int Delete(Neusoft.HISFC.Models.Base.Noon noon)
        {
            string sql = "";
            if (this.Sql.GetSql("Registration.DoctSchema.Delete.2", ref sql) == -1) return -1;

            try
            {
                sql = string.Format(sql, noon.ID);

                return this.ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                this.Err = "删除午别信息时出错!" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 查询午别
        /// </summary>
        /// <returns></returns>
        public ArrayList Query()
        {
            string sql = "";

            if (this.Sql.GetSql("Registration.DoctSchema.Query.1", ref sql) == -1) return null;
            if (this.ExecQuery(sql) == -1) return null;

            al = new ArrayList();
            try
            {
                while (this.Reader.Read())
                {
                    noon = new Neusoft.HISFC.Models.Base.Noon();
                    noon.ID = this.Reader[2].ToString();//id
                    noon.Name = this.Reader[3].ToString();//name

                    if (Reader.IsDBNull(4) == false)
                        noon.StartTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[4].ToString());//开始时间
                    if (Reader.IsDBNull(5) == false)
                        noon.EndTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[5].ToString());//结束时间
                    if (Reader.IsDBNull(6) == false)
                        noon.IsAutoEmergency = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[6].ToString());//是否急诊

                    //noon.OperID = this.Reader[7].ToString();//操作员
                    //noon.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[8].ToString());

                    al.Add(noon);
                }
                this.Reader.Close();
            }
            catch (Exception e)
            {
                this.Err = "获取午别出错" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
            return al;
        }
        /// <summary>
        /// 根据午别代码查询午别名称
        /// </summary>
        /// <param name="noon_id"></param>
        /// <returns></returns>
        public string Query(string noon_id)
        {
             string sql = "";
            if (this.Sql.GetSql("Registration.Noon.Query.1", ref sql) == -1) return "";
            try
            {
                sql = string.Format(sql, noon_id);
                return this.ExecSqlReturnOne(sql);

            }
            catch (Exception ex)
            {
                this.Err = "获取午别名称出错" + ex.Message;
                this.ErrCode = ex.Message;
                return "";
               
            }

        }

    }
}

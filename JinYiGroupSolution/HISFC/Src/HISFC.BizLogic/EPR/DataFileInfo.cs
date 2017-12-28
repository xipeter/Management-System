using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
    /// <summary>
    /// DataFileInfo 的摘要说明。
    /// </summary>
    public class DataFileInfo : Neusoft.FrameWork.Management.Database, Neusoft.HISFC.Models.Base.IManagement
    {
        public DataFileInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region IManagement 成员
        public System.Collections.ArrayList GetList()
        {
            return null;
        }

        /// <summary>
        /// 默认显示数据文件
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public System.Collections.ArrayList GetList(Neusoft.HISFC.Models.File.DataFileParam param)
        {
            return this.GetList(param, 0, true);
        }



        /// <summary>
        /// 获得模板列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public System.Collections.ArrayList GetModualList(Neusoft.HISFC.Models.File.DataFileParam param, bool isAll)
        {
            string strSql = "";
            if (isAll)//全院模板，包含无效的
            {
                if (this.Sql.GetSql("Manager.DataFileInfo.Select.Modual.All.1", ref strSql) == -1) return null;
                try
                {
                    strSql = string.Format(strSql, param.ID, param.Type);
                }
                catch
                {
                    this.Err = "参数传入错误!";
                    return null;
                }
            }
            else
            {
                if (this.Sql.GetSql("Manager.DataFileInfo.Select.Modual.All.2", ref strSql) == -1) return null;
                try
                {
                    strSql = string.Format(strSql, param.ID, param.Type, ((Neusoft.HISFC.Models.Base.Employee)this.Operator).Dept.ID);
                }
                catch
                {
                    this.Err = "参数传入错误!";
                    return null;
                }
            }
            return this.myGetFiles(param, strSql);
        }

        /// <summary>
        /// 显示类型文件 0 数据文件 ,1 模板文件
        /// </summary>
        /// <param name="param"></param>
        /// <param name="iType"></param>
        /// <param name="isAll">是否全院 只对模板文件有效</param>
        /// <returns></returns>
        public System.Collections.ArrayList GetList(Neusoft.HISFC.Models.File.DataFileParam param, int iType, bool isAll)
        {
            string strSql = "";

            if (iType == 0)//数据文件 
            {
                if (this.Sql.GetSql("Manager.DataFileInfo.Select.Data.1", ref strSql) == -1) return null;
                try
                {
                    strSql = string.Format(strSql, param.ID, param.Type);
                }
                catch
                {
                    this.Err = "参数传入错误!";
                    return null;
                }
            }
            else//模板文件
            {
                if (isAll)//全院模板，都是有效的
                {
                    if (this.Sql.GetSql("Manager.DataFileInfo.Select.Modual.1", ref strSql) == -1) return null;
                    try
                    {
                        strSql = string.Format(strSql, param.ID, param.Type);
                    }
                    catch
                    {
                        this.Err = "参数传入错误!";
                        return null;
                    }
                }
                else
                {
                    if (this.Sql.GetSql("Manager.DataFileInfo.Select.Modual.2", ref strSql) == -1) return null;
                    try
                    {
                        strSql = string.Format(strSql, param.ID, param.Type, ((Neusoft.HISFC.Models.Base.Employee)this.Operator).Dept.ID);
                    }
                    catch
                    {
                        this.Err = "参数传入错误!";
                        return null;
                    }
                }
            }
            return this.myGetFiles(param, strSql);

        }

        private ArrayList myGetFiles(Neusoft.HISFC.Models.File.DataFileParam param, string strSql)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.File.DataFileInfo DataFileInfo = null;
            if (this.ExecQuery(strSql) == -1) return null;

            while (this.Reader.Read())
            {
                DataFileInfo = new Neusoft.HISFC.Models.File.DataFileInfo();

                DataFileInfo.Param = (Neusoft.HISFC.Models.File.DataFileParam)param.Clone();

                // TODO:  添加 DataFileInfo.GetList 实现
                try
                {
                    DataFileInfo.ID = this.Reader[0].ToString();//文件编号
                }
                catch
                { }
                try
                {
                    DataFileInfo.Param.ID = this.Reader[1].ToString();//参数名
                }
                catch
                { }
                try
                {
                    DataFileInfo.Param.Type = this.Reader[2].ToString();//系统类型 0 电子病历 1 手术申请单
                }
                catch
                { }
                try
                {
                    DataFileInfo.Type = this.Reader[3].ToString();//文件类型 数据文件 模板文件
                }
                catch
                { }
                try
                {
                    DataFileInfo.Name = this.Reader[4].ToString();//文件名 说明名称
                }
                catch
                { }
                try
                {
                    DataFileInfo.Param.Http = this.Reader[5].ToString();//http
                }
                catch
                { }
                try
                {
                    DataFileInfo.Param.IP = this.Reader[6].ToString();//主机名
                }
                catch
                { }
                try
                {
                    DataFileInfo.Param.Folders = this.Reader[7].ToString();//路径名
                }
                catch
                { }
                try
                {
                    DataFileInfo.Param.FileName = this.Reader[8].ToString();//文件名
                }
                catch
                { }
                try
                {
                    DataFileInfo.Index1 = this.Reader[9].ToString();//索引1
                }
                catch
                { }
                try
                {
                    DataFileInfo.Index2 = this.Reader[10].ToString();//索引2
                }
                catch
                { }
                try
                {
                    DataFileInfo.Memo = this.Reader[11].ToString();//备注
                }
                catch
                { }
                try
                {
                    DataFileInfo.DataType = this.Reader[12].ToString();//特定类型
                }
                catch
                { }
                try
                {
                    DataFileInfo.valid = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13].ToString());//有效标志
                }
                catch
                { }
                try
                {
                    DataFileInfo.UseType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[14].ToString());//用户类型
                    DataFileInfo.Count = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[15].ToString());//使用次数
                }
                catch
                { }
                al.Add(DataFileInfo);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="iType"> 0 数据文件 1 模板文件</param>
        /// <returns></returns>
        public int Del(object strID, int iType)
        {
            // TODO:  添加 DataFileInfo.Del 实现
            string strSql = "";
            if (iType == 0)//数据
            {
                if (this.Sql.GetSql("Manager.DataFileInfo.Delete.1", ref strSql) == -1) return -1;
            }
            else //模板
            {
                if (this.Sql.GetSql("Manager.DataFileInfo.Delete.Modual.1", ref strSql) == -1) return -1;
            }
            try
            {
                strSql = string.Format(strSql, strID);
            }
            catch
            {
                this.Err = "参数传入错误!";
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 删除数据文件
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int Del(object strID)
        {
            return this.Del(strID, 0);
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        public int SetList(System.Collections.ArrayList al)
        {
            // TODO:  添加 DataFileInfo.SetList 实现
            return 0;
        }
        /// <summary>
        /// 数据文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Neusoft.FrameWork.Models.NeuObject Get(object id)
        {
            return this.Get(id, 0);
        }
        /// <summary>
        /// 获得datafileinfo
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Neusoft.FrameWork.Models.NeuObject Get(object id, int iType)
        {
            // TODO:  添加 DataFileInfo.Get 实现
            string strSql = "";
            if (iType == 0)
            {
                if (this.Sql.GetSql("Manager.DataFileInfo.Select.5", ref strSql) == -1) return null;
            }
            else
            {
                if (this.Sql.GetSql("Manager.DataFileInfo.Select.Modual.5", ref strSql) == -1) return null;
            }
            try
            {
                strSql = string.Format(strSql, id);
            }
            catch
            {
                this.Err = "参数传入错误!";
                return null;
            }


            if (this.ExecQuery(strSql) == -1) return null;
            Neusoft.HISFC.Models.File.DataFileInfo DataFileInfo = null;

            if (this.Reader.Read())
            {
                DataFileInfo = new Neusoft.HISFC.Models.File.DataFileInfo();

                DataFileInfo.ID = this.Reader[0].ToString();//文件编号

                DataFileInfo.Param.ID = this.Reader[1].ToString();//参数名

                DataFileInfo.Param.Type = this.Reader[2].ToString();//系统类型 0 电子病历 1 手术申请单

                DataFileInfo.Type = this.Reader[3].ToString();//文件类型 数据文件 模板文件

                DataFileInfo.Name = this.Reader[4].ToString();//文件名 说明名称

                DataFileInfo.Param.Http = this.Reader[5].ToString();//http

                DataFileInfo.Param.IP = this.Reader[6].ToString();//主机名

                DataFileInfo.Param.Folders = this.Reader[7].ToString();//路径名

                DataFileInfo.Param.FileName = this.Reader[8].ToString();//文件名

                DataFileInfo.Index1 = this.Reader[9].ToString();//索引1

                DataFileInfo.Index2 = this.Reader[10].ToString();//索引2

                DataFileInfo.Memo = this.Reader[11].ToString();//备注

                DataFileInfo.DataType = this.Reader[12].ToString();//特定类型

                DataFileInfo.Param.IsInDB = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[13]);//是否在数据库
                try
                {
                    DataFileInfo.valid = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[14]);//有效标致
                }
                catch { }
                try
                {
                    DataFileInfo.UseType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[15].ToString());//用户类型
                    DataFileInfo.Count = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[16].ToString());//使用次数                
                }
                catch { }
            }
            this.Reader.Close();
            return DataFileInfo;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int SetInValid(Neusoft.FrameWork.Models.NeuObject obj, int iType)
        {
            Neusoft.HISFC.Models.File.DataFileInfo DataFileInfo = null;
            try
            {
                DataFileInfo = obj as Neusoft.HISFC.Models.File.DataFileInfo;
            }
            catch
            {
                return -1;
            }
            DataFileInfo.valid = 1;//无效
            return this.Set(DataFileInfo, iType);
        }
        /// <summary>
        /// 设置为可用
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="iType"></param>
        /// <returns></returns>
        public int SetValid(Neusoft.FrameWork.Models.NeuObject obj, int iType)
        {
            Neusoft.HISFC.Models.File.DataFileInfo DataFileInfo = null;
            try
            {
                DataFileInfo = obj as Neusoft.HISFC.Models.File.DataFileInfo;
            }
            catch
            {
                return 0;
            }
            DataFileInfo.valid = 0;//有效
            return this.Set(DataFileInfo, iType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Set(Neusoft.FrameWork.Models.NeuObject obj)
        {
            return this.Set(obj, 0);
        }


        protected int setModual(Neusoft.FrameWork.Models.NeuObject obj)
        {
            #region
            string strSql = "", strSql1 = "";
            Neusoft.HISFC.Models.File.DataFileInfo DataFileInfo = null;

            DataFileInfo = obj as Neusoft.HISFC.Models.File.DataFileInfo;
            if (DataFileInfo == null)
            {
                this.Err = "传入实体非DataFileInfo.";
                return -1;
            }

            if (this.Sql.GetSql("Manager.DataFileInfo.Update.Modual.1", ref strSql) == -1) return -1;
            if (this.Sql.GetSql("Manager.DataFileInfo.Insert.Modual.1", ref strSql1) == -1) return -1;

            string[] s = new string[18];
            try
            {

                s[0] = DataFileInfo.Param.ID;//参数名
                s[1] = DataFileInfo.Param.Type;//系统类型 0 电子病历 1 手术申请单
                s[2] = DataFileInfo.Type;//文件类型 数据文件 模板文件
                s[3] = DataFileInfo.Name;//文件名 说明名称
                s[4] = DataFileInfo.Param.Http;//完整文件头名
                s[5] = DataFileInfo.Param.IP;//主机名
                s[6] = DataFileInfo.Param.Folders;//路径名
                s[7] = DataFileInfo.Param.FileName;//文件名
                s[8] = DataFileInfo.Index1;//索引1
                s[9] = DataFileInfo.Index2;//索引2
                s[10] = DataFileInfo.Memo;//备注
                s[11] = DataFileInfo.DataType;//特定类型 文件属于类别
                s[12] = DataFileInfo.Data;//数据
                s[13] = this.Operator.ID;//操作人ID
                s[14] = DataFileInfo.ID;//文件号
                s[15] = DataFileInfo.valid.ToString();//有效标记 0 有效 1 作废
                s[16] = DataFileInfo.UseType.ToString(); //用户类型
                s[17] = DataFileInfo.Count.ToString();//使用次数
                strSql = string.Format(strSql, s);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            #endregion

            if (this.ExecNoQuery(strSql) <= 0)//update
            {
                strSql = string.Format(strSql1, s);
                if (this.ExecNoQuery(strSql) <= 0)//insert
                {
                    return -1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Set(Neusoft.FrameWork.Models.NeuObject obj, int iType)
        {
            // TODO:  添加 DataFileInfo.Set 实现
            #region
            string strSql = "", strSql1 = "";
            Neusoft.HISFC.Models.File.DataFileInfo DataFileInfo = null;
            try
            {
                DataFileInfo = obj as Neusoft.HISFC.Models.File.DataFileInfo;
            }
            catch
            {
                return -1;
            }
            if (iType == 0)
            {
                if (this.Sql.GetSql("Manager.DataFileInfo.Update.1", ref strSql) == -1) return -1;
                if (this.Sql.GetSql("Manager.DataFileInfo.Insert.1", ref strSql1) == -1) return -1;
            }
            else
            {
                //if(this.Sql.GetSql("Manager.DataFileInfo.Update.Modual.1",ref strSql)==-1) return -1;
                //if(this.Sql.GetSql("Manager.DataFileInfo.Insert.Modual.1",ref strSql1)==-1) return -1;
                return this.setModual(obj);
            }
            string[] s = new string[17];
            try
            {
                try
                {
                    s[0] = DataFileInfo.Param.ID;//参数名
                }
                catch { }
                try
                {
                    s[1] = DataFileInfo.Param.Type;//系统类型 0 电子病历 1 手术申请单
                }
                catch { }
                try
                {
                    s[2] = DataFileInfo.Type;//文件类型 数据文件 模板文件
                }
                catch { }
                try
                {
                    s[3] = DataFileInfo.Name;//文件名 说明名称
                }
                catch { }
                try
                {
                    s[4] = DataFileInfo.Param.Http;//完整文件头名
                }
                catch { }
                try
                {
                    s[5] = DataFileInfo.Param.IP;//主机名
                }
                catch { }
                try
                {
                    s[6] = DataFileInfo.Param.Folders;//路径名
                }
                catch { }
                try
                {
                    s[7] = DataFileInfo.Param.FileName;//文件名
                }
                catch { }
                try
                {
                    s[8] = DataFileInfo.Index1;//索引1
                }
                catch { }
                try
                {
                    s[9] = DataFileInfo.Index2;//索引2
                }
                catch { }
                try
                {
                    s[10] = DataFileInfo.Memo;//备注
                }
                catch { }
                try
                {
                    s[11] = DataFileInfo.DataType;//特定类型 文件属于类别
                }
                catch { }
                try
                {
                    s[12] = DataFileInfo.Data;//数据
                }
                catch { }
                try
                {
                    s[13] = this.Operator.ID;//操作人ID
                }
                catch { }
                try
                {
                    s[14] = DataFileInfo.ID;//文件号
                }
                catch { }
                try
                {
                    s[15] = DataFileInfo.valid.ToString();//有效标记 0 有效 1 作废
                    s[16] = DataFileInfo.UseType.ToString();//有效标记 0 有效 1 作废
                }
                catch { }
                strSql = string.Format(strSql, s);
            #endregion
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }
            if (this.ExecNoQuery(strSql) <= 0)//update
            {
                strSql = string.Format(strSql1, s);
                if (this.ExecNoQuery(strSql) <= 0)//insert
                {
                    return -1;
                }
            }
            return 0;
        }
        public string GetNewFileID()
        {
            string strSql = "";
            if (this.Sql.GetSql("Manager.DataFileInfo.GetNewID", ref strSql) == -1) return "-1";
            return this.ExecSqlReturnOne(strSql);
        }
        #endregion
    }//81067437 
}

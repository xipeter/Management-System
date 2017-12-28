using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;

namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    /// <summary>
    /// 类名称<br>ICDMedicare</br>
    /// <Font color='#FF1111'>[功能描述: 医保ICD业务层]</Font><br></br>
    /// [创 建 者: ]<br>耿晓雷</br>
    /// [创建时间: ]<br>2007-08-14</br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public class ICDMedicare : Neusoft.FrameWork.Management.Database
    {
        	/// <summary>
	/// 构造函数
	/// </summary>
        public ICDMedicare()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        #region 私有
        #endregion

        #region 保护
        #endregion

        #region 公开
        #endregion

        #endregion

        #region 属性
        #endregion

        #region 方法

        #region 资源释放
        #endregion

        #region 克隆
        #endregion

        #region 私有
        /// <summary>
        /// 从Reader  中读取数据
        /// </summary>
        /// <returns>出现未处理的错误返回 null 有记录list.Count >1  没有记录 list.Count =0</returns>
        private ArrayList ICDReaderInfo()
        {
            //定义 动态数组， 用来存储读出的信息
            ArrayList list = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.HealthRecord.ICDMedicare icdM = null;
                while (this.Reader.Read())
                {
                    icdM = new Neusoft.HISFC.Models.HealthRecord.ICDMedicare();

                    icdM.SeqID = Reader[0].ToString();//序列号
                    icdM.ID = Reader[1].ToString();//医保诊断代码
                    icdM.Name = Reader[2].ToString();//医保诊断名称
                    icdM.SpellCode = Reader[3].ToString();//医保诊断拼音
                    icdM.IcdType = Reader[4].ToString();//1 ICD10，2 市医保，3 省医保
                    //将ICD填入列表
                    list.Add(icdM);
                }
                this.Reader.Close(); //关闭reade

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;

                if (!this.Reader.IsClosed) // 判断是否关闭了Reader
                {
                    this.Reader.Close();//没有关闭则先关闭
                }

                return null; //出现错误返回null 
            }
            return list;
        }
        /// <summary>
        /// 获取查询语句
        /// </summary>
        /// <param name="dType">查询类别 0 全部，1 ICD10，2 市医保，3 省医保</param>
        /// <returns>sql
        ///          出错返回null</returns>
        private String GetSQL(String dType)
        {
            String strSQL = "";
            switch (dType)
            {
                case "0"://全部
                    if (this.Sql.GetSql("Case.ICDDML.Query.ICDAll.Base", ref strSQL) == -1)
                    {
                        this.Err = "获取SQL语句失败,索引:Case.ICDDML.Query.ICDAll.Base";
                        return null;
                    }
                    break;
                case "1"://ICD10
                    if (this.Sql.GetSql("Case.ICDDML.Query.ICD10ForMedicare.Base", ref strSQL) == -1)
                    {
                        this.Err = "获取SQL语句失败,索引:Case.ICDDML.Query.ICDAll.Base";
                        return null;
                    }
                    break;
                default://ICDMEDICARE 2 市医保，3 省医保
                    if (this.Sql.GetSql("Case.ICDDML.Query.ICDMedicare.Base", ref strSQL) == -1)
                    {
                        this.Err = "获取SQL语句失败,索引:Case.ICDDML.Query.ICDMedicare.Base";
                        return null;
                    }
                    try
                    {
                        //格式化SQL语句
                        strSQL = string.Format(strSQL, dType);
                    }
                    catch (Exception ex)
                    {
                        this.Err = "SQL语句赋值出错!" + ex.Message;
                    }
                    break;
            }
            return strSQL;
        }
        #endregion

        #region 保护
        #endregion

        #region 公开

        /// <summary>
        /// 查询医保ICD信息
        /// </summary>
        /// <param name="dType">查询类别 0 全部，1 ICD10，2 市医保，3 省医保</param>
        /// <returns>arrayList.Count >= 1 正确获得符合条件的ICD集合
        ///          arrayList.Count == 0 没有符合条件的ICD集合 
        ///          出错返回null</returns>
        public ArrayList Query(String dType)
        {
            String strQuerySQL = "";
            //定义数组，储存查询到的信息
            ArrayList arryList = new ArrayList();
            try
            {
                //获取SQL
                strQuerySQL = this.GetSQL(dType);
                //执行查询操作
                this.ExecQuery(strQuerySQL);
                //读取数据
                arryList = ICDReaderInfo();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;

                if (!Reader.IsClosed) // 如果没有关闭reader
                {
                    this.Reader.Close(); //关闭reader
                }

                return null; // 出现错误返回null
            }

            return arryList;
        }

        #endregion

        #endregion
    }
}

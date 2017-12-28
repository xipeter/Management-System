using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Integrate.Equipment
{    
    /// <summary>
    /// Base<br></br>
    /// [功能描述: 整合的设备管理类]<br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2007-11-2]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Equipment : IntegrateBase
    {
        /// <summary>
	    /// 构造函数
	    /// </summary>
        public Equipment()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

	    #region 变量

	    #region 私有
	    #endregion

	    #region 保护

        /// <summary>
        /// 帐目信息业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Equipment.Base baseInfoMgr = new Neusoft.HISFC.BizLogic.Equipment.Base();

	    #endregion

	    #region 公开
	    #endregion

	    #endregion

	    #region 属性
	    #endregion

	    #region 方法

	    #region 私有
	    #endregion

	    #region 保护
	    #endregion

	    #region 公开

        /// <summary>
        /// 设置数据库事务
        /// </summary>
        /// <param name="trans">数据库事务</param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            baseInfoMgr.SetTrans(trans);
            this.trans = trans;
        }

        /// <summary>
        /// 根据设备编码获取一条帐目信息
        /// </summary>
        /// <param name="EquCode">设备编码（LOG_EQU_BASEINFO的主键）</param>
        /// <returns>设备帐目信息实体 失败：null</returns>
        public Neusoft.HISFC.Models.Equipment.EquipBase GetBaseInfo(string EquCode)
        {
            this.SetDB(baseInfoMgr);
            return baseInfoMgr.GetBaseInfo(EquCode);
        }
                
        /// <summary>
        /// 向帐目信息表中插入一条记录
        /// </summary>
        /// <param name="BaseInfo">帐目实体</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int InsertBaseInfo(Neusoft.HISFC.Models.Equipment.EquipBase BaseInfo)
        {
            this.SetDB(baseInfoMgr);
            if (baseInfoMgr.InsertBaseInfo(BaseInfo) == -1)
            {
                return -1;
            }
            return 1;
        }
                
        /// <summary>
        /// 取帐目信息列表
        /// </summary>
        /// <returns>帐目信息数组，出错返回null</returns>
        public ArrayList QueryAllBaseInfo()
        {
            this.SetDB(baseInfoMgr);
            return baseInfoMgr.QueryAllBaseInfo();
        }
        
        /// <summary>
        /// 根据设备分类编码获取帐目信息列表
        /// </summary>
        /// <returns>帐目信息数组，出错返回null</returns>
        public ArrayList QueryAllBaseInfoByKind(string ID)
        {
            this.SetDB(baseInfoMgr);
            return baseInfoMgr.QueryAllBaseInfoByKind(ID);
        }
                
        /// <summary>
        /// 更新帐目信息表中一条记录
        /// </summary>
        /// <param name="BaseInfo">帐目实体</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int UpdateBaseInfo(Neusoft.HISFC.Models.Equipment.EquipBase BaseInfo)
        {
            this.SetDB(baseInfoMgr);
            return baseInfoMgr.UpdateBaseInfo(BaseInfo);
        }
                
        /// <summary>
        /// 保存帐目实体变动数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
        /// </summary>
        /// <param name="BaseInfo">帐目信息实体</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int SetBaseInfo(Neusoft.HISFC.Models.Equipment.EquipBase BaseInfo)
        {
            this.SetDB(baseInfoMgr);
            return baseInfoMgr.SetBaseInfo(BaseInfo);
        }

	    #endregion

	    #endregion

    }
}

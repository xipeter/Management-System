using System;
using System.Collections.Generic;
using System.Text;

namespace UFC.Lis
{
    /// <summary>
    /// [功能描述: Lis接口数据传输]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-03]<br></br>
    /// </summary>
    public interface ILisDB
    {

        /// <summary>
        /// 窗口Load连接Lis数据库
        /// </summary>
        /// <returns></returns>
        int ConnectLisOnLoad();

        /// <summary>
        /// 查询时连接Lis数据库
        /// </summary>
        /// <returns></returns>
        int ConnectLisOnQuery();

        /// <summary>
        /// 关闭Lis连接
        /// </summary>
        /// <returns></returns>
        int CloseLisDB();

        /// <summary>
        /// 数据传输
        /// </summary>
        /// <param name="p"></param>
        /// <param name="execList"></param>
        /// <returns></returns>
        int TransDataToLisDB(Neusoft.HISFC.Models.RADT.PatientInfo p,List<Neusoft.HISFC.Models.Order.ExecOrder> execList,ref string err);

    }
}

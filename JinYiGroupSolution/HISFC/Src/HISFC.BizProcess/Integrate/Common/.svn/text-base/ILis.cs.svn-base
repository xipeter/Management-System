using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.Common
{
    /// <summary>
    /// [功能描述: LIS医嘱接口]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2007-05-11]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface ILis
    {

        /// <summary>
        /// 下医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        int PlaceOrder(Neusoft.HISFC.Models.Order.Order order);

        /// <summary>
        /// 下组合医嘱
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        int PlaceOrder(ICollection<Neusoft.HISFC.Models.Order.Order> orders);

        /// <summary>
        /// 检查医嘱项目是否可以开立
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        bool CheckOrder(Neusoft.HISFC.Models.Order.Order order);

        /// <summary>
        /// 设置患者信息
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <returns></returns>
        int SetPatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo);

        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Connect();

        /// <summary>
        /// 数据库关闭
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Disconnect();

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// 回滚
        /// </summary>
        /// <returns></returns>
        int Rollback();

        /// <summary>
        /// 按医嘱显示检验结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ShowResult(string id);

        /// <summary>
        /// 查询检验结果
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        string[] QueryResult(string inpatientNo);

        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        int ShowResultByPatient(string inpatientNo);


        /// <summary>
        /// 检验结果是否已经生成
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsReportValid(string id);


        /// <summary>
        /// 设置本地数据库连接
        /// </summary>
        /// <param name="t"></param>
        void SetTrans(System.Data.IDbTransaction t);

        /// <summary>
        /// 错误编码
        /// </summary>
        string ErrCode
        {
            get;
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        string ErrMsg
        {
            get;
        }

    }

}

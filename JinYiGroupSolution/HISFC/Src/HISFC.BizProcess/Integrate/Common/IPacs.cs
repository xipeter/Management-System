using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.Common
{
    /// <summary>
    /// [功能描述: PACS医嘱接口]<br></br>
    /// [创 建 者: 不详]<br></br>
    /// [创建时间: 未知]<br></br>
    /// <修改记录
    ///		修改人='孙盟'
    ///		修改时间='2009-02-12'
    ///		修改目的=''
    ///		修改描述='原来这个接口什么都没有，现在抽象一个'
    ///  />
    /// </summary>
    public interface IPacs
    {
        /// <summary>
        /// 下医嘱
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        int PlaceOrder(Neusoft.HISFC.Models.Order.Order Order);

        /// <summary>
        /// 下组合医嘱
        /// </summary>
        /// <param name="OrderList"></param>
        /// <returns></returns>
        int PlaceOrder(List<Neusoft.HISFC.Models.Order.Order> OrderList);

        /// <summary>
        /// 检查医嘱项目是否可以开立
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        bool CheckOrder(Neusoft.HISFC.Models.Order.Order Order);

        /// <summary>
        /// 设置患者信息
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        int SetPatient(Neusoft.HISFC.Models.RADT.Patient Patient);

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
        /// <param name="id">申请单号</param>
        /// <returns></returns>
        int ShowResult(string id);

        /// <summary>
        /// 查询检验结果
        /// </summary>
        /// <param name="PatientNo"></param>
        /// <returns></returns>
        string[] QueryResult(string PatientNo);

        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="PatientNo"></param>
        /// <returns></returns>
        int ShowResultByPatient(string PatientNo);


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
            set;
            get;
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        string ErrMsg
        {
            set;
            get;
        }

        /// <summary>
        /// 调用模式(1:门诊2:住院)
        /// </summary>
        string OprationMode
        {
            set;
            get;
        }

        /// <summary>
        /// pacs结果察看类型1：图像2：报告
        /// </summary>
        string PacsViewType
        {
            set;
            get;
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        void ShowForm();
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// 处方配置维护接口
    /// </summary>
    public interface IPrescription
    {
        /// <summary>
        /// 显示标题
        /// </summary>
        string DisplayTitle
        {
            get;
        }

        Neusoft.FrameWork.WinForms.Controls.ucBaseControl Control
        {
            get;
        }

        Neusoft.HISFC.Models.Pharmacy.Item Drug
        {
            set;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        int Init();

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        int Save(Neusoft.HISFC.Models.Pharmacy.Item item,ref string information);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        int Delete();

        /// <summary>
        /// 信息检索
        /// </summary>
        /// <returns></returns>
        int Query();

        /// <summary>
        /// 新增明细
        /// </summary>
        /// <returns></returns>
        int AddNewItem();
    }

    /// <summary>
    /// 制剂主实现接口
    /// </summary>
    public interface IPreparation
    {
        decimal GetStore(string deptCode,string itemID);

        /// <summary>
        /// 原材料出库
        /// </summary>
        /// <param name="matierialObj"></param>
        /// <param name="expand"></param>
        /// <param name="stockDept"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        int Output(Neusoft.FrameWork.Models.NeuObject matierialObj, Neusoft.HISFC.Models.Preparation.Expand expand, Neusoft.FrameWork.Models.NeuObject stockDept, System.Data.IDbTransaction t);

        /// <summary>
        /// 原材料申请
        /// </summary>
        /// <param name="materialObj"></param>
        /// <param name="expand"></param>
        /// <param name="applyDept"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        int Apply(Neusoft.FrameWork.Models.NeuObject materialObj, Neusoft.HISFC.Models.Preparation.Expand expand, Neusoft.FrameWork.Models.NeuObject applyDept, System.Data.IDbTransaction t);
    }

    /// <summary>
    /// 工艺流程记录
    /// </summary>
    public interface IProcess
    {
        int SetProcess(Neusoft.HISFC.Models.Preparation.EnumState state,Neusoft.HISFC.Models.Preparation.Preparation preparation);
    }

}

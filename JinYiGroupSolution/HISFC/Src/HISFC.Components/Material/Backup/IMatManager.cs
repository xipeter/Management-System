using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Material
{
    public interface IMatManager
    {
        /// <summary>
        /// 入库业务接口
        /// </summary>
        Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get;
        }


        /// <summary>
        /// 数据表初始化
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        System.Data.DataTable InitDataTable();

        /// <summary>
        /// 增加物品项目
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parms"></param>
        int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow);

        /// <summary>
        /// 增加物品项目
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parms"></param>
        int AddItem(FarPoint.Win.Spread.SheetView sv, Neusoft.HISFC.Models.Material.Input input);

        /// <summary>
        /// 显示申请信息
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        int ShowApplyList();

        /// <summary>
        /// 入库单据
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        int ShowInList();

        /// <summary>
        /// 出库单据
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        int ShowOutList();

        /// <summary>
        /// 显示采购信息
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        int ShowStockList();

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns>成功返回True 无效信息返回False</returns>
        bool Valid();

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sv">需删除数据所属Fp</param>
        /// <param name="delRowIndex">需删除行索引</param>
        /// <returns>成功返回1 失败返回-1</returns>
        int Delete(FarPoint.Win.Spread.SheetView sv, int delRowIndex);

        void SetFormat();

        /// <summary>
        /// 清屏
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        int Clear();

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="filterStr">过滤数值</param>
        void Filter(string filterStr);

        /// <summary>
        /// 焦点设置
        /// </summary>
        void SetFocusSelect();

        /// <summary>
        /// 保存
        /// </summary>
        void Save();

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        int Print();

        /// <summary>
        /// 作废
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        int Cancel();

        /// <summary>
        /// 导入
        /// </summary>
        /// <returns></returns>
        int ImportData();

        /// <summary>
        /// 释放资源
        /// //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
        /// </summary>
        void Dispose();
    }
}

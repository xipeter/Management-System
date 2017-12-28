using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Pharmacy.Out
{
    /// <summary>
    /// [功能描述: 换药出库]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// <说明>
    ///     会导致处方明细与出库明细不符合。暂不考虑
    /// 
    ///     1、增加控制参数，设置对于换药原药品对应的出库类型
    ///     2、增加控制参数，设置对于换药后药品对应的出库类型
    ///     3、增加控制参数，控制换药出库时允许不符金额的最小值 设置为0则必须完全符合
    /// </说明>
    /// </summary>
    public class ChangeOutput : Neusoft.HISFC.Components.Pharmacy.In.IPhaInManager
    {
        public ChangeOutput()
        {
 
        }

        #region IPhaInManager 成员

        public Neusoft.FrameWork.WinForms.Controls.ucBaseControl InputModualUC
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public System.Data.DataTable InitDataTable()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int AddItem(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ShowApplyList()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ShowInList()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ShowOutList()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ShowStockList()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ImportData()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Valid()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Delete(FarPoint.Win.Spread.SheetView sv, int delRowIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Clear()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Filter(string filterStr)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetFocusSelect()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Save()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Print()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IPhaInManager 成员

        public int Dispose()
        {
            return 1;
        }

        #endregion
    }
}

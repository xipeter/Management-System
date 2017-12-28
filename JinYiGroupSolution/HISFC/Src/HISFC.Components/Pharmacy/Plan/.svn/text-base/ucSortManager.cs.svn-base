using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Pharmacy.Plan
{
    /// <summary>
    /// [功能描述: Fp排序管理]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-10]<br></br>
    /// <修改>
    /// </修改>
    /// </summary>
    public partial class ucSortManager : UserControl
    {
        public ucSortManager()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 排序级别
        /// </summary>
        private List<string> sortLevel = new List<string>();

        /// <summary>
        /// 结果
        /// </summary>
        private DialogResult result = DialogResult.Cancel;

        
        #endregion

        #region 属性

        /// <summary>
        /// 排序优先级
        /// </summary>
        public List<string> SortLevel
        {
            get
            {
                return this.sortLevel;
            }
        }

        /// <summary>
        /// 排序方式
        /// </summary>
        public SortDirection Direction
        {
            get
            {
                if (this.ckAscend.Checked)
                {
                    return SortDirection.Ascend;
                }
                else
                {
                    return SortDirection.Descend;
                }
            }
        }

        /// <summary>
        /// 操作结果
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.result;
            }
        }
        #endregion

        /// <summary>
        /// 读取需排序的Fp信息
        /// </summary>
        /// <param name="sortColumn">需排序的列</param>
        /// <returns>成功读取信息返回1 失败返回－1</returns>
        public int SetFarPoint(params string[] sortColumn)
        {
            this.neuSpread1_Sheet1.Rows.Count = sortColumn.Length;
            for (int i = 0; i < sortColumn.Length; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Text = sortColumn[i];
            }

            return 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.neuSpread1_Sheet1.AutoSortColumn(1,true);
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 1].Text != "")
                {
                    this.sortLevel.Add(this.neuSpread1_Sheet1.Cells[i, 0].Text);
                }
            }

            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.Cancel;

            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }
    }

    public class MultiSortBase<T> where T : class
    {
        public delegate IComparer<T> GetCompareDelegate(List<string> hsSortColumnLevel,SortDirection direction);

        public GetCompareDelegate GetCompareInstance = null;

        public void MultiStort(List<T> subList, ref List<T> parentList,List<string> sortColumnLevelList,SortDirection direction)
        {
            IComparer<T> sortCom = GetCompareInstance(sortColumnLevelList,direction);

            this.MultiSort(subList, ref parentList, sortCom,sortColumnLevelList,direction);
        }

        public void MultiSort(List<T> subList, ref List<T> parentList, IComparer<T> compare, List<string> sortColumnLevelList,SortDirection direction)
        {
            if (subList.Count == 1)     //只有一个项目
            {
                parentList.Add(subList[0]);
                return;
            }
            if (compare == null)
            {
                parentList.AddRange(subList);
                return;
            }

            subList.Sort(compare);

            parentList.AddRange(subList);

            return;

            #region 原递归处理方式  屏蔽此种处理方式

            //List<List<T>> subListCollecte = QuerySubListInstance(subList, compareLevel);

            //compareLevel++;

            //foreach (List<T> list in subListCollecte)
            //{
            //    compare = GetCompareInstance(compareLevel,this.hsSortColumnLevel);

            //    MultiSort(list, ref parentList, compare, compareLevel);
            //}

            #endregion
        }
    }

    /// <summary>
    /// 排序类别
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// 升序
        /// </summary>
        Ascend,
        /// <summary>
        /// 降序
        /// </summary>
        Descend,
    }
}

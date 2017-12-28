using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucOpItem : UserControl
    {
        public ucOpItem()
        {
            InitializeComponent();
        }
        private ArrayList al = null;
        private DataSet ds = null;
        public delegate int MyDelegate(Keys key);
        /// <summary>
        /// 双击、回车项目列表时执行的事件
        /// </summary>
        public event MyDelegate SelectItem;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            Neusoft.HISFC.BizProcess.Integrate.Fee itemMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            al = itemMgr.QueryOperationItems();

            #region 生成DataSet
            ds = new DataSet();
            ds.Tables.Add("items");
            ds.Tables[0].Columns.AddRange(new DataColumn[]
				{
					new DataColumn("input_code",Type.GetType("System.String")),
					new DataColumn("item_name",Type.GetType("System.String")),
					new DataColumn("price",Type.GetType("System.Decimal")),
					new DataColumn("spell_code",Type.GetType("System.String")),
					new DataColumn("WB_code",Type.GetType("System.String")),
					new DataColumn("operate_code",Type.GetType("System.String")),
					new DataColumn("operate_kind",Type.GetType("System.String")),
					new DataColumn("operate_type",Type.GetType("System.String")),
					new DataColumn("item_code",Type.GetType("System.String"))
				});
            ds.CaseSensitive = false;
            #endregion

            foreach (Neusoft.HISFC.Models.Fee.Item.Undrug item in al)
            {
                if (item.SysClass.ID.ToString() == "UO")//手术
                {
                    ds.Tables[0].Rows.Add(new object[]
						{
							item.UserCode,item.Name,item.Price,item.SpellCode,item.WBCode,
							item.OperationInfo.ID,item.OperationType,item.OperationScale,item.ID});
                }
            }

            fpSpread1.DataSource = ds;
            fpSpread1_Sheet1.Columns[0].Width = 66F;
            fpSpread1_Sheet1.Columns[1].Width = 216F;
            fpSpread1_Sheet1.Columns[2].Width = 57F;
            fpSpread1_Sheet1.Columns[3].Width = 0F;
            fpSpread1_Sheet1.Columns[4].Width = 88F;
            fpSpread1_Sheet1.Columns[5].Width = 59F;
            fpSpread1_Sheet1.Columns[6].Width = 57F;
            fpSpread1_Sheet1.Columns[7].Width = 0F;

            return 0;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int Filter(string text)
        {
            text = "input_code like '%" + text.Trim() + "%' or " +
                 "spell_code like '%" + text.Trim() + "%' or " +
                 "item_name like '%" + text.Trim() + "%' or " +
                 "WB_code like '%" + text.Trim() + "%' or " +
                 "operate_code like '%" + text.Trim() + "%'";
            DataView dv = new DataView(ds.Tables[0]);
            try
            {
                dv.RowFilter = text;
            }
            catch { }

            fpSpread1.DataSource = dv;
            fpSpread1_Sheet1.Columns[0].Width = 66F;
            fpSpread1_Sheet1.Columns[1].Width = 216F;
            fpSpread1_Sheet1.Columns[2].Width = 57F;
            fpSpread1_Sheet1.Columns[3].Width = 0F;
            fpSpread1_Sheet1.Columns[4].Width = 88F;
            fpSpread1_Sheet1.Columns[5].Width = 59F;
            fpSpread1_Sheet1.Columns[6].Width = 57F;
            fpSpread1_Sheet1.Columns[7].Width = 0F;

            return 0;
        }
        /// <summary>
        /// 下一行
        /// </summary>
        /// <returns></returns>
        public int NextRow()
        {
            int row = fpSpread1_Sheet1.ActiveRowIndex;
            if (row < fpSpread1_Sheet1.RowCount - 1)
            {
                fpSpread1_Sheet1.ActiveRowIndex = row + 1;
                //{0CD66D53-785C-4ba5-840B-885F01A31A42}
                //fpSpread1_Sheet1.AddSelection(row + 1, 0, 1, 0);
                fpSpread1_Sheet1.AddSelection(row + 1, 1, 1, 1);
            }
            return 0;
        }
        /// <summary>
        /// 上一行
        /// </summary>
        /// <returns></returns>
        public int PriorRow()
        {
            int row = fpSpread1_Sheet1.ActiveRowIndex;
            if (row > 0)
            {
                fpSpread1_Sheet1.ActiveRowIndex = row - 1;
                //{0CD66D53-785C-4ba5-840B-885F01A31A42}
                //fpSpread1_Sheet1.AddSelection(row - 1, 0, 1, 0);
                fpSpread1_Sheet1.AddSelection(row - 1, 1, 1, 1);
            }
            return 0;
        }

        /// <summary>
        /// 返回选择项
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int GetItem(ref Neusoft.HISFC.Models.Fee.Item.Undrug item)
        {
            int row = fpSpread1_Sheet1.ActiveRowIndex;

            if (row < 0 || fpSpread1_Sheet1.RowCount == 0)
            {
                item = null;
                return -1;
            }
            string itemCode = fpSpread1_Sheet1.GetText(row, 8);//项目代码

            foreach (Neusoft.HISFC.Models.Fee.Item.Undrug undrug in al)
            {
                if (undrug.ID == itemCode)
                {
                    item = undrug;
                    return 0;
                }
            }

            item = null;
            return -1;
        }


        private void fpSpread1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (SelectItem != null)
            {
                this.SelectItem(Keys.Enter);
            }
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (SelectItem != null)
            {
                this.SelectItem(Keys.Enter);
            }
        }
    }
}

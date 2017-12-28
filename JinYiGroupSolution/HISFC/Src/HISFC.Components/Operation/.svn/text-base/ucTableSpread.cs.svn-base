using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术台维护表格]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-16]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucTableSpread : UserControl
    {
        public ucTableSpread()
        {
            InitializeComponent();
        }

        #region 字段
        public event EventHandler ItemModified;
        private OpsRoom room;

        private bool inited = false;    //初始化
        #endregion

        #region 属性
        /// <summary>
        /// 手术室
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OpsRoom OperationRoom
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
            }
        }
        #endregion
        #region 方法
        public int ValidState()
        {
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                if (fpSpread1_Sheet1.Cells[i, 0].Text.Trim() == "")
                {
                    MessageBox.Show("手术台名称不能为空");
                    return -1;
                }
                if (fpSpread1_Sheet1.Cells[i, 1].Text.Trim() == "")
                {
                    MessageBox.Show("输入码不能为空");
                    return -1;
                }
                for (int j = 0; j < this.fpSpread1_Sheet1.RowCount; j++)
                {
                    if (i == j)
                    {
                        continue;
                    } 
                    if (fpSpread1_Sheet1.Cells[i, 0].Text == fpSpread1_Sheet1.Cells[j, 0].Text)
                    {
                        MessageBox.Show("手术台名称不能相同");
                        return -1;
                    }
                    if (fpSpread1_Sheet1.Cells[i, 1].Text == fpSpread1_Sheet1.Cells[j, 1].Text)
                    {
                        MessageBox.Show("输入码不能相同");
                        return -1;
                    }
                }
            }
            return 1;
        }
        /// <summary>
        /// 向表格中添加一行
        /// </summary>
        /// <param name="table"></param>
        private void AddItem(Neusoft.HISFC.Models.Operation.OpsTable table)
        {
            this.fpSpread1_Sheet1.RowCount++;
            int index = this.fpSpread1_Sheet1.RowCount - 1;

            this.fpSpread1_Sheet1.Cells[index, 0].Text = table.Name;
            this.fpSpread1_Sheet1.Cells[index, 1].Text = table.InputCode;
            if (table.IsValid)
                this.fpSpread1_Sheet1.Cells[index, 2].Text = "在用";
            else
                this.fpSpread1_Sheet1.Cells[index, 2].Value = "停用";

            this.fpSpread1_Sheet1.Cells[index, 3].Text = table.Memo;


            this.fpSpread1_Sheet1.Rows[index].Tag = table;
        }

        /// <summary>
        /// 向表格添加一空行
        /// </summary>
        public void AddItem()
        {
            if (this.room == null)
                return;

            this.fpSpread1_Sheet1.RowCount++;
            OpsTable table = new OpsTable();
            table.ID = Environment.TableManager.GetNewTableNo();
            table.Room = room;
            table.Dept.ID = Environment.OperatorDeptID;
            table.User.ID = Environment.OperatorID;
            room.Tables.Add(table);
            this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.RowCount - 1].Tag = table;

        }

        /// <summary>
        /// 向表格中添加多行
        /// </summary>
        /// <param name="tables"></param>
        public void AddItem(List<OpsTable> tables)
        {
            if (this.room == null)
                return;

            this.inited = false;
            foreach (OpsTable table in tables)
            {
                this.AddItem(table);
            }
            this.inited = true;
        }

        /// <summary>
        /// 删除一行
        /// </summary>
        public void DeleteItem()
        {
            if (this.fpSpread1_Sheet1.RowCount > 0 && this.fpSpread1_Sheet1.ActiveRowIndex >= 0)
            {
                this.room.Tables.Remove(this.fpSpread1_Sheet1.ActiveRow.Tag as OpsTable);
                this.fpSpread1_Sheet1.Rows.Remove(this.fpSpread1_Sheet1.ActiveRowIndex, 1);
            }
        }
        /// <summary>
        /// 清空
        /// </summary>
        public void Reset()
        {
            this.fpSpread1_Sheet1.RowCount = 0;
            this.room = null;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public new void Update()
        {
            if (this.room == null)
                return;

            this.room.Tables.Clear();
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                OpsTable table = this.fpSpread1_Sheet1.Rows[i].Tag as OpsTable;
                table.Name = this.fpSpread1_Sheet1.Cells[i, 0].Text;
                table.InputCode = this.fpSpread1_Sheet1.Cells[i, 1].Text;
                if (this.fpSpread1_Sheet1.Cells[i, 2].Text == "在用")
                    table.IsValid = true;
                else
                    table.IsValid = false;
                table.Memo = this.fpSpread1_Sheet1.Cells[i, 3].Text;

                this.room.AddTable(table);
            }

        }
        #endregion

        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (!this.inited)
                return;
            if (this.ItemModified != null)
                this.ItemModified(this, null);
        }
    }
}
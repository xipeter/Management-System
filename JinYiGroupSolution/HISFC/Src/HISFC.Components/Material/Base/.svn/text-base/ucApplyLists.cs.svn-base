using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>
    /// 申请单列表选择控件
    /// </summary>
    public partial class ucApplyLists : UserControl
    {
        public ucApplyLists()
        {
            InitializeComponent();
        }

        #region 变量

        private ArrayList listApply = new ArrayList(); 
        
        #endregion

        #region 属性

        public ArrayList ListApply
        {
            get
            {
                return listApply;
            }
            set
            {
                listApply = value;
            }
        } 

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="al">申请单集合</param>
        public void Init(ArrayList al)
        {
            this.Clear();
            //先初始化其他控件
            this.InitControls();
            //根据传入的申请单集合初始化表格
            this.InitSheet(al);
        }

        private void Clear()
        {
            this.neuSpread1_Sheet1.RowCount = 0;
            this.cmbStatus.Text = "";
            this.dtpBeginTime.Value = DateTime.Now.AddDays(-7);
            this.dtpEndTime.Value = DateTime.Now;
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        /// <param name="arrayList"></param>
        private void InitSheet(ArrayList arrayList)
        {
            this.SetSheetFormat();

            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.Models.Base.Employee emp = new Neusoft.HISFC.Models.Base.Employee();
            Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();

            if (arrayList != null && arrayList.Count > 0)
            {
                foreach (ArrayList al in arrayList)
                {
                    this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 1].Text = al[1].ToString();//申请单号

                    emp = manager.GetEmployeeInfo(al[2].ToString());
                    if (emp != null && !string.IsNullOrEmpty(emp.ID))
                    {
                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 2].Text = emp.Name;
                    }

                    dept = manager.GetDepartment(al[3].ToString());
                    if (dept != null && !string.IsNullOrEmpty(dept.ID))
                    {
                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 3].Text = dept.Name;
                    }
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 4].Text = al[4].ToString();
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 5].Text = al[5].ToString();
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 6].Text = al[6].ToString();
                    //主键
                    this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.RowCount - 1].Tag = al;
                }
                this.neuSpread1_Sheet1.Columns[1, this.neuSpread1_Sheet1.ColumnCount - 1].Locked = true;
            }
        }

        /// <summary>
        /// 设置表格格式
        /// </summary>
        private void SetSheetFormat()
        {
            this.neuSpread1_Sheet1.Columns[1].Label = "申请单号";
            this.neuSpread1_Sheet1.Columns[1].Width = 90F;

            this.neuSpread1_Sheet1.Columns[2].Label = "申请人";
            this.neuSpread1_Sheet1.Columns[2].Width = 70F;

            this.neuSpread1_Sheet1.Columns[3].Label = "申请科室";
            this.neuSpread1_Sheet1.Columns[3].Width = 80F;

            this.neuSpread1_Sheet1.Columns[4].Label = "申请日期";
            this.neuSpread1_Sheet1.Columns[4].Width = 90F;

            this.neuSpread1_Sheet1.Columns[5].Label = "状态";
            this.neuSpread1_Sheet1.Columns[5].Width = 70F;

            this.neuSpread1_Sheet1.Columns[6].Label = "单据类型";
            this.neuSpread1_Sheet1.Columns[6].Width = 80F;

            this.neuSpread1_Sheet1.Columns[7, this.neuSpread1_Sheet1.ColumnCount - 1].Visible = false;
        }

        /// <summary>
        /// 初始化其他控件
        /// </summary>
        private void InitControls()
        {
            this.dtpBeginTime.Value = DateTime.Now.AddDays(-7);
            this.dtpEndTime.Value = DateTime.Now;

            ArrayList alStatus = new ArrayList();

            this.SetArrayList(ref alStatus);

            this.cmbStatus.AddItems(alStatus);
        }

        private void SetAllRowVisible()
        {
            foreach (FarPoint.Win.Spread.Row r in neuSpread1_Sheet1.Rows)
            {
                this.neuSpread1_Sheet1.Rows[r.Index].Visible = true;
            }
        }

        /// <summary>
        /// 设置状态下拉框中的值
        /// </summary>
        /// <param name="alStatus"></param>
        private void SetArrayList(ref ArrayList alStatus)
        {
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject obj3 = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject obj4 = new Neusoft.FrameWork.Models.NeuObject();

            obj1.ID = "0";
            obj1.Name = "申请状态";
            alStatus.Add(obj1);

            obj2.ID = "1";
            obj2.Name = "入库计划";
            alStatus.Add(obj2);

            obj3.ID = "9";
            obj3.Name = "部分审批";
            alStatus.Add(obj3);

            obj4.ID = "3";
            obj4.Name = "全部审批";
            alStatus.Add(obj4);
        }

        #endregion        
        
        #region 事件

        /// <summary>
        /// 根据状态过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetAllRowVisible();
            foreach (FarPoint.Win.Spread.Row r in neuSpread1_Sheet1.Rows)
            {
                if (neuSpread1_Sheet1.Cells[r.Index, 5].Text != cmbStatus.Text)
                {
                    this.neuSpread1_Sheet1.Rows[r.Index].Visible = false;
                }
            }
        }

        /// <summary>
        /// 根据开始时间过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpBeginTime_ValueChanged(object sender, EventArgs e)
        {
            this.SetAllRowVisible();
            foreach (FarPoint.Win.Spread.Row r in neuSpread1_Sheet1.Rows)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToDateTime(neuSpread1_Sheet1.Cells[r.Index, 4].Text) < dtpBeginTime.Value)
                {
                    this.neuSpread1_Sheet1.Rows[r.Index].Visible = false;
                }
            }
        }

        /// <summary>
        /// 根据结束时间过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            this.SetAllRowVisible();
            foreach (FarPoint.Win.Spread.Row r in neuSpread1_Sheet1.Rows)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToDateTime(neuSpread1_Sheet1.Cells[r.Index, 4].Text) > dtpEndTime.Value)
                {
                    this.neuSpread1_Sheet1.Rows[r.Index].Visible = false;
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            foreach (FarPoint.Win.Spread.Row r in neuSpread1_Sheet1.Rows)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(neuSpread1_Sheet1.Cells[r.Index, 0].Value))
                {
                    listApply.Add(neuSpread1_Sheet1.Rows[r.Index].Tag);
                }
            }

            this.FindForm().Close();
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSelectAll_Click(object sender, EventArgs e)
        {
            foreach (FarPoint.Win.Spread.Row r in neuSpread1_Sheet1.Rows)
            {
                neuSpread1_Sheet1.Cells[r.Index, 0].Value = !Neusoft.FrameWork.Function.NConvert.ToBoolean(neuSpread1_Sheet1.Cells[r.Index, 0].Value);
            }
        } 

        #endregion
    }

    
}

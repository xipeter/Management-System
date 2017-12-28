using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Operation.Report
{
    /// <summary>
    /// [功能描述: 手术分类汇总统计]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucReportBase : UserControl, Neusoft.FrameWork.WinForms.Forms.IReport
    {
        public ucReportBase()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
            {
                this.Init();
                this.InitSpread();
                this.InitCategory();
            }
        }

#region 属性
        protected bool ShowCategory
        {
            get
            {
                return this.cmbCategory.Visible;
            }
            set
            {
                this.cmbCategory.Visible = value;
                this.neuLabel4.Visible = value;
            }
        }

        protected string Title
        {
            get
            {
                return this.lblTitle.Text;
            }
            set
            {
                this.lblTitle.Text = value;
            }
        }
#endregion
        #region 方法
        private void Init()
        {
            this.fpSpread1_Sheet1.Columns[-1].Locked = true;
            this.fpSpread1_Sheet1.GrayAreaBackColor = Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.Rows[0].BackColor = Color.White;
            
            this.dtpBegin.Value = DateTime.Parse(Environment.OperationManager.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtpEnd.Value = DateTime.Parse(Environment.OperationManager.GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd") + " 23:59:59");

            //手术室
            ArrayList alRet = Environment.IntegrateManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.OP);
            this.cmbDept.AddItems(alRet);
            this.cmbDept.IsListOnly = true;
            this.cmbDept.Tag = Environment.OperatorDeptID;

        }

        protected virtual void InitSpread()
        {
            
        }

        protected virtual void InitCategory()
        {
            
        }

        protected virtual void OnCategoryChanged()
        {

        }

        protected virtual int OnQuery()
        {
            return -1;
        }
        #endregion

        #region IReport 成员

        public int Query()
        {
            return this.OnQuery();
        }

        #endregion

        #region IReportPrinter 成员

        public int Print()
        {
            return Environment.Print.PrintPreview(30,0,this.neuPanel2);
        }

        public int PrintPreview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Export()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region 事件
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnCategoryChanged();
        }
     

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            this.lblTime.Text = string.Concat("查询时间：", this.dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"), " -- ", this.dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

   #endregion


    }


}

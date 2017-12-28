using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.WinForms.Report.Pharmacy
{
    /// <summary>
    /// [功能描述: 药库入库汇总]<br></br>
    /// [创 建 者: 蒋飞]<br></br>
    /// [创建时间: 2007-10]<br></br>
    /// </summary>
    public partial class ucPhaInputSum : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucPhaInputSum()
        {
            InitializeComponent();
        }



        #region 属性

        /// <summary>
        /// 查询起始时间
        /// </summary>
        public DateTime BeginTime
        {
            get
            {
                return NConvert.ToDateTime(this.dtpBeginTime.Text);
            }
        }

        /// <summary>
        /// 查询终止时间
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return NConvert.ToDateTime(this.dtpEndTime.Text);
            }
        }

        #endregion

        #region 工具栏

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected int Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList alDept = deptManager.GetDeptmentAll();

            ArrayList alStockDept = new ArrayList();
            foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
            {
                if (dept.DeptType.ID.ToString() == "PI")
                {
                    alStockDept.Add(dept);
                }
            }

            this.cmbStockDept.AddItems(alStockDept);

            this.dtpBeginTime.Value = deptManager.GetDateTimeFromSysDateTime().AddDays(-1);
            this.dtpEndTime.Value = deptManager.GetDateTimeFromSysDateTime();
            return 1;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>

        protected int Query()
        {
            if (this.cmbStockDept.Tag == null || this.cmbStockDept.Tag.ToString() == "")
            {
                MessageBox.Show(Language.Msg("请选择查询药库"));
                return -1;
            }

            System.Data.DataSet ds = new DataSet();

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();
            if (dataManager.ExecQuery("Pharmacy.Report.InputSum", ref ds, this.cmbStockDept.Tag.ToString(), this.BeginTime.ToString(), this.EndTime.ToString()) == -1)
            {
                MessageBox.Show(Language.Msg("没有相关信息！") + dataManager.Err);
                return -1;
            }

            if (ds == null || ds.Tables.Count <= 0)
            {
                return 0;
            }
            this.fpSpread1_Sheet1.DataSource = ds;



            int iTotIndex = this.fpSpread1_Sheet1.RowCount;
            decimal sumNum4 = 0;
            decimal sumNum3 = 0;
            decimal sumNum2 = 0;
            decimal sumNum1 = 0;

       
            for (int i = 0; i < iTotIndex; i++)
            {
                sumNum1 = sumNum1 + NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, 1].Text);
                sumNum2 = sumNum2 + NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, 2].Text);
                sumNum3 = sumNum3 + NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, 3].Text);
                sumNum4 = sumNum4 + NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, 4].Text);
            }
            //this.fpSpread1_Sheet1.RowCount = iTotIndex + 1;
            this.fpSpread1_Sheet1.Rows.Add(iTotIndex, 1);
            this.fpSpread1_Sheet1.Cells[iTotIndex , 0].Text = "合计";
            this.fpSpread1_Sheet1.Cells[iTotIndex , 1].Text = sumNum1.ToString();
            this.fpSpread1_Sheet1.Cells[iTotIndex , 2].Text = sumNum2.ToString();
            this.fpSpread1_Sheet1.Cells[iTotIndex , 3].Text = sumNum3.ToString();
            this.fpSpread1_Sheet1.Cells[iTotIndex , 4].Text = sumNum4.ToString();          

            return 1;
        }
        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.PrintPage(30, 10, this);

        }
        protected override int OnPrint(object sender, object neuObject)
        {
            this.Print();
            return base.OnPrint(sender, neuObject);
        }

        //public override int Export(object sender, object neuObject)
        //{
        //    if (this.fpSpread1.Export() == 1)
        //    {
        //        MessageBox.Show(Language.Msg("导出成功"));
        //    }

        //    return 1;
        //}

        protected override void OnLoad(EventArgs e)
        {
            this.Init();

            base.OnLoad(e);
        }

        private void neuLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    /// [功能描述: 住院药品消耗查询]<br></br>
    /// [创 建 者: sel]<br></br>
    /// [创建时间: 2009-07]<br></br>
    /// </summary>
    public partial class ucPhaExpenseQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucPhaExpenseQuery()
        {
            InitializeComponent();
        }



        #region 属性

        /// <summary>
        /// 请求起始时间
        /// </summary>
        public DateTime Q_BeginTime
        {
            get
            {
                return NConvert.ToDateTime(this.dt_begin_quest.Text);
            }
        }

        /// <summary>
        /// 请求终止时间
        /// </summary>
        public DateTime Q_EndTime
        {
            get
            {
                return NConvert.ToDateTime(this.dt_end_quest.Text);
            }
        }

        /// <summary>
        /// 发药起始时间
        /// </summary>
        public DateTime S_BeginTime
        {
            get
            {
                return NConvert.ToDateTime(this.dt_begin_send.Text);
            }
        }

        /// <summary>
        /// 发药终止时间
        /// </summary>
        public DateTime S_EndTime
        {
            get
            {
                return NConvert.ToDateTime(this.dt_end_send.Text);
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
            DataSet ds = new DataSet();
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            Neusoft.HISFC.BizLogic.Pharmacy.Item phaManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            ArrayList AllNurseCellList = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
            ArrayList AllShouShuList = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.OP);
            List<Neusoft.HISFC.Models.Pharmacy.Item> ListDrug= phaManager.QueryItemList();
            ArrayList AllDrugList = new ArrayList();
            Object b =new Object();
            for (int i = 0; i < ListDrug.Count; i++)
            {
                b = ListDrug[i];
                AllDrugList.Insert(0, b);
            }
            Neusoft.HISFC.Models.Base.Item allItem = new Neusoft.HISFC.Models.Base.Item();
            allItem.ID = "%%";
            allItem.Name = "全部";
            allItem.SpellCode = "QB";
            AllNurseCellList.Insert(0,allItem);
            AllDrugList.Insert(0, allItem);
            AllNurseCellList.AddRange(AllShouShuList);
            this.cmbNurseCellCode.AddItems(AllNurseCellList);
            this.cmbDrugCode.AddItems(AllDrugList);

            this.cmbDrugCode.SelectedIndex = 0;
            this.cmbNurseCellCode.SelectedIndex = 0;

            //InitFp();


            //this.dt_begin_quest.Value = deptManager.GetDateTimeFromSysDateTime().AddDays(-1);
            //this.dt_begin_send.Value = deptManager.GetDateTimeFromSysDateTime().AddDays(-1);
            return 1;
        }

        private DateTime BeginTime = new DateTime();
        private DateTime EndTime = new DateTime();
        private string DateNum = "1";
        private string strFilter = "1=1";
        private System.Data.DataSet ds = new DataSet();
        private System.Data.DataView dv=new DataView();
        private string[] filterField = new string[2] { "病区", "药品编码" };
        private DataColumn[] dc = null;

        //private int InitFp()
        //{
        //    dc = new DataColumn[10] {
        //        new DataColumn("病区"), 
        //        new DataColumn("1"),
        //        new DataColumn("1"), 
        //        new DataColumn("药品名称"),
        //        new DataColumn("1"), 
        //        new DataColumn("1"),
        //        new DataColumn("1"), 
        //        new DataColumn("1"),
        //        new DataColumn("1"), 
        //        new DataColumn("1")
        //    };
        //    ds.Tables[0].Columns.AddRange(dc);
        //    return 1;
        //}
        /// <summary>
        /// 过滤
        /// </summary>
        /// <returns></returns>
        protected int SetFilter()
        {
            string strCellCode="%%";
            string strDrugCode = "%%";
            if (cmbNurseCellCode.SelectedItem!=null && cmbDrugCode.SelectedItem.Name!=null)
            {
                strCellCode=this.cmbNurseCellCode.SelectedItem.Name.ToString();
                strDrugCode= this.cmbDrugCode.SelectedItem.ID.ToString();
            }
            if (this.cmbDrugCode.SelectedIndex == 0)
            {
                strDrugCode = "%%";
            }
            if (this.cmbNurseCellCode.SelectedIndex == 0)
            {
                strCellCode = "%%";
            }
            strFilter = string.Format(this.filterField[0] + "  like '{0}' and " + this.filterField[1] + " like '{1}'", strCellCode, strDrugCode);
            if (this.dv != null)
            {
                this.dv.RowFilter = strFilter;
            }
            this.fpSpread1_Sheet1.ActiveRowIndex = 0;
            return 1;
        }


        /// <summary>
        /// 时间选择
        /// </summary>
        /// <returns></returns>
        protected int GetQueryTime()
        {
            BeginTime = this.dt_begin_quest.Value;
            EndTime = this.dt_end_quest.Value;
            this.dt_begin_send.Enabled= false;
            this.dt_end_send.Enabled = false;
            this.dt_begin_quest.Enabled = true;
            this.dt_end_quest.Enabled = true;
            if (this.neuRadioButton1.Checked)
            {
                BeginTime = this.dt_begin_quest.Value;
                EndTime = this.dt_end_quest.Value;
            }
            else
            {
                BeginTime = this.dt_begin_send.Value;
                EndTime = this.dt_end_send.Value;
                DateNum = "2";
                this.dt_begin_quest.Enabled = false;
                this.dt_end_quest.Enabled = false;
                this.dt_begin_send.Enabled = true;
                this.dt_end_send.Enabled = true;
            }
            return 1;
        }




        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        protected int Query()
        {
            //if (this.cmbStockDept.Tag == null || this.cmbStockDept.Tag.ToString() == "")
            //{
            //    MessageBox.Show(Language.Msg("请选择查询药库"));
            //    return -1;
            //}
            ds.Clear();
            this.GetQueryTime();
            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();
            if (dataManager.ExecQuery("Pharmacy.Report.ExpenseQuery", ref ds, this.cmbNurseCellCode.Tag.ToString(), this.cmbDrugCode.Tag.ToString(), this.BeginTime.ToString(), this.EndTime.ToString(), DateNum) == -1)
            {
                MessageBox.Show(Language.Msg("没有相关信息！") + dataManager.Err);
                return -1;
            }

            if (ds == null || ds.Tables.Count <= 0)
            {
                return 0;
            }
            //this.filterField = new string[2] { "病区", "药品名称" };
            this.dv = new DataView(this.ds.Tables[0]);
            this.fpSpread1_Sheet1.DataSource = this.dv;

            //int iTotIndex = this.fpSpread1_Sheet1.RowCount;
            //decimal sumNum4 = 0;
            //decimal sumNum3 = 0;
            //decimal sumNum2 = 0;
            //decimal sumNum1 = 0;


            //for (int i = 0; i < iTotIndex; i++)
            //{
            //    sumNum1 = sumNum1 + NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, 1].Text);
            //    sumNum2 = sumNum2 + NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, 2].Text);
            //    sumNum3 = sumNum3 + NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, 3].Text);
            //    sumNum4 = sumNum4 + NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, 4].Text);
            //}
            ////this.fpSpread1_Sheet1.RowCount = iTotIndex + 1;
            //this.fpSpread1_Sheet1.Rows.Add(iTotIndex, 1);
            //this.fpSpread1_Sheet1.Cells[iTotIndex, 0].Text = "合计";
            //this.fpSpread1_Sheet1.Cells[iTotIndex, 1].Text = sumNum1.ToString();
            //this.fpSpread1_Sheet1.Cells[iTotIndex, 2].Text = sumNum2.ToString();
            //this.fpSpread1_Sheet1.Cells[iTotIndex, 3].Text = sumNum3.ToString();
            //this.fpSpread1_Sheet1.Cells[iTotIndex, 4].Text = sumNum4.ToString();          

            return 1;
        }
        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.PrintPage(30, 10, this.fpSpread1);

        }
        protected override int OnPrint(object sender, object neuObject)
        {
            this.Print();
            return base.OnPrint(sender, neuObject);
        }

        public override int Export(object sender, object neuObject)
        {
            if (base.Export(sender,neuObject) == 1)
            {
                
                MessageBox.Show(Language.Msg("导出成功"));
            }

            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Init();

            base.OnLoad(e);
        }

        private void cmbDrugCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetFilter();
        }

        private void cmbNurseCellCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetFilter();
        }

        private void neuRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.GetQueryTime();
        }

        private void neuRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.GetQueryTime();
        }

    }
}

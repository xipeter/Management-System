using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Finance.FinIpb
{
    /// <summary>
    /// 【功能】按照统计大类汇总费用信息
    /// 【时间】20101001
    /// 【创建人】席宗飞
    /// </summary>
    public partial class ucFinIpbSubentryNew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
       public ucFinIpbSubentryNew()
        {
            InitializeComponent();
            Init();
        }
        public void Init() {
            System.Collections.ArrayList constantList = manager.GetConstantList("FEECODESTAT");
            this.cmbKind.AddItems(constantList);
            int i = 0;
            foreach (Neusoft.FrameWork.Models.NeuObject obj in cmbKind.alItems) {
                if (obj.ID == "ZY01") {
                    cmbKind.SelectedIndex = i;
                }
                i++;
            }
        }
        public override int Print(object sender, object neuObject)
        {

            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            Neusoft.HISFC.Models.Base.PageSize ps = new Neusoft.HISFC.Models.Base.PageSize("SI", 0, 0);
            ps.Top = 0;
            ps.Left = 0;
            print.SetPageSize(ps);
            print.PrintPage(0, 0, this.neuPanel2);
            return base.Print(sender, neuObject);
        }
        protected override int OnQuery(object sender, object neuObject)
        {
            this.lblFromTimetoTime.Text = this.begin_time.Value.ToShortDateString() + "    至  " + this.end_time.Value.ToShortDateString();
            if (this.fpSpread1_Sheet1.Rows.Count > 1) {
                this.fpSpread1_Sheet1.Rows.Remove(1, this.fpSpread1_Sheet1.Rows .Count- 1);
            }
            Neusoft.FrameWork.Models.NeuObject obj = this.cmbKind.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
            Neusoft.Report.Finance.FinIpb.sql local = new Neusoft.Report.Finance.FinIpb.sql();
            DataSet ds = new DataSet();
            int rev = local.GetKindFee(this.begin_time.Value.ToShortDateString()+" 00:00:00", this.end_time.Value.ToShortDateString()+" 23:59:59", obj.ID, ref ds);
            if (rev == -1)
            {
                MessageBox.Show(local.Err);
            }
            else {
                DataTable tb = ds.Tables[0];
                this.fpSpread1_Sheet1.Rows.Add(1,tb.Rows.Count+6);
                int j = 5;
                for (int k= 0; k< this.fpSpread1_Sheet1.Rows.Count -1; k++)
                {
                     this.fpSpread1_Sheet1.Cells[k+ 1, 0].Border = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, Color.Black, Color.Black);
                    this.fpSpread1_Sheet1.Cells[k+ 1, 1].Border = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, Color.Black, Color.Black);
                }
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                   if (tb.Rows[i].ItemArray.GetValue(2) .ToString()== "01") { 
                        //西药
                        this.fpSpread1_Sheet1.Cells[1, 0].Text = tb.Rows[i].ItemArray.GetValue(1).ToString();
                        this.fpSpread1_Sheet1.Cells[1, 1].Text = tb.Rows[i].ItemArray.GetValue(0).ToString();
                    }
                    else if (tb.Rows[i].ItemArray.GetValue(2).ToString() == "02") { 
                        //中成药
                        this.fpSpread1_Sheet1.Cells[2, 0].Text = tb.Rows[i].ItemArray.GetValue(1).ToString();
                        this.fpSpread1_Sheet1.Cells[2, 1].Text = tb.Rows[i].ItemArray.GetValue(0).ToString();
                    }
                    else if (tb.Rows[i].ItemArray.GetValue(2).ToString() == "03")
                    {
                        //中草药
                        this.fpSpread1_Sheet1.Cells[3, 0].Text = tb.Rows[i].ItemArray.GetValue(1).ToString();
                        this.fpSpread1_Sheet1.Cells[3, 1].Text = tb.Rows[i].ItemArray.GetValue(0).ToString();
                    }
                    else {
                        this.fpSpread1_Sheet1.Cells[j, 0].Text = tb.Rows[i].ItemArray.GetValue(1).ToString();
                        this.fpSpread1_Sheet1.Cells[j, 1].Text = tb.Rows[i].ItemArray.GetValue(0).ToString();
                        j++;
                    }
                }
                this.fpSpread1_Sheet1.Cells[4, 0].Text = "小计";
                this.fpSpread1_Sheet1.Cells[4, 1].Formula = "sum(B2:B4)";
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 0].Text = "小计";
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 1].Formula = "sum(B6:B" + (this.fpSpread1_Sheet1.Rows.Count - 2).ToString() + ")";
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 0].Text = "总计";
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 1].Formula = "B5+B"+(this.fpSpread1_Sheet1.Rows.Count-1).ToString();
                //去除为空的cell
                RemoveRow();
            }
            return base.OnQuery(sender, neuObject);
        }
        /// <summary>
        /// 递归删除
        /// </summary>
        public void RemoveRow()
        {
            //去除为空的cell
            for (int a = 0; a < this.fpSpread1_Sheet1.Rows.Count; a++)
            {
                if (string.IsNullOrEmpty(this.fpSpread1_Sheet1.Cells[a, 0].Text))
                {
                    this.fpSpread1_Sheet1.Rows.Remove(a, 1);
                    RemoveRow();
                }
            }
        }
    }
  
}

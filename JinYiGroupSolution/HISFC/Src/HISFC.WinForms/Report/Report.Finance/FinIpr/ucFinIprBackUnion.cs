using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Finance.FinIpr
{
    public partial class ucFinIprBackUnion : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucFinIprBackUnion()
        {
            InitializeComponent();
        }
        protected override int OnQuery(object sender, object neuObject)
        {
            string begin_time = this.begin_time.Value.ToShortDateString();
            FinIpr.Sql local = new Sql();
            DataSet ds = new DataSet();
            local.Exec(Sql.GetBackFeeByTj, begin_time, ref ds);
            if (this.neuSpread1_Sheet1.Rows.Count > 1) {
                this.neuSpread1_Sheet1.Rows.Remove(1, this.neuSpread1_Sheet1.Rows.Count - 1);
            }
            this.neuSpread1_Sheet1.Rows.Add(1, ds.Tables[0].Rows.Count);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //科室
                this.neuSpread1_Sheet1.Cells[i + 1, 0].Text = ds.Tables[0].Rows[i].ItemArray.GetValue(2).ToString();
                //住院流水号
                this.neuSpread1_Sheet1.Cells[i + 1, 1].Text = ds.Tables[0].Rows[i].ItemArray.GetValue(3).ToString();
                //姓名
                this.neuSpread1_Sheet1.Cells[i + 1, 2].Text = ds.Tables[0].Rows[i].ItemArray.GetValue(4).ToString();
                //统计大类
                this.neuSpread1_Sheet1.Cells[i + 1, 3].Text = ds.Tables[0].Rows[i].ItemArray.GetValue(1).ToString();
                //冲单费用
                this.neuSpread1_Sheet1.Cells[i + 1, 4].Text = ds.Tables[0].Rows[i].ItemArray.GetValue(0).ToString();
                //操作员
                this.neuSpread1_Sheet1.Cells[i + 1, 5].Text = ds.Tables[0].Rows[i].ItemArray.GetValue(5).ToString();
                
            }
            for (int j = 0; j< this.neuSpread1_Sheet1.Rows.Count; j++)
            {
                for (int k= 0;k< 6; k++)
                {
                    this.neuSpread1_Sheet1.Cells[j,k].Border = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, Color.Black, Color.Black);
                }
            }
             this.neuSpread1_Sheet1.SetRowMerge(-1, FarPoint.Win.Spread.Model.MergePolicy.None);
             this.neuSpread1_Sheet1.SetColumnMerge(5, FarPoint.Win.Spread.Model.MergePolicy.Always);
             this.neuSpread1_Sheet1.SetColumnMerge(2, FarPoint.Win.Spread.Model.MergePolicy.Always);
             this.neuSpread1_Sheet1.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always);
             this.neuSpread1_Sheet1.SetColumnMerge(1, FarPoint.Win.Spread.Model.MergePolicy.Always);
             this.lblTime.Text = this.begin_time.Value.ToShortDateString();
             this.lblPrintTime.Text = DateTime.Now.ToString();

            return base.OnQuery(sender, neuObject);
        }
         public override int Print(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            Neusoft.HISFC.Models.Base.PageSize pg = new Neusoft.HISFC.Models.Base.PageSize("CD", 0, 0);
            p.SetPageSize(pg);
            pg.Top = 0;
            pg.Left = 0;
            p.PrintPage(0,0,this.neuPanel1);
            return base.Print(sender, neuObject);
        }
    }
}

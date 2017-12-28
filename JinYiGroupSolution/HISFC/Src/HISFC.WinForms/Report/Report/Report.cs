using System;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace Neusoft.Report
{
    /// <summary>
    /// Report 的摘要说明。
    /// </summary>
    public class ReportClass
    {
        public ReportClass()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        protected CrystalReportViewer ReportViewer = new CrystalReportViewer();

        public ReportDocument PrintDoc = new ReportDocument();//临时创建 by zuowy

        public CrystalReportViewer ReportView
        {
            get
            {
                return this.ReportViewer;
            }
        }
        public int ShowReport(string FileName, object ds)
        {
            return this.ShowReport(new Report.frmReport(), FileName, ds);

        }
        public int ShowReport(System.Windows.Forms.Control parentControl, string FileName, object ds)
        {
            try
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(FileName);
                rpt.SetDataSource(ds);
                ReportViewer.ReportSource = rpt;
                Show(parentControl);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return -1; }
            return 0;
        }
        /// <summary>
        /// 显示报表一次
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="FileName"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int ShowReportOnce(System.Windows.Forms.Control parentControl, string FileName, object ds)
        {
            try
            {
                ReportDocument rpt = null;
                if (ReportViewer.ReportSource == null)
                {
                    rpt = new ReportDocument();
                    rpt.Load(FileName);
                }
                else
                {
                    rpt = ReportViewer.ReportSource as ReportDocument;
                }

                rpt.SetDataSource(ds);
                ReportViewer.ReportSource = rpt;
                ReportViewer.RefreshReport();
                Show(parentControl);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return -1; }
            return 0;
        }
        public int ShowReport(object rpt, object ds)
        {
            return this.ShowReport(new frmReport(), rpt, ds);

        }
        public int ShowReport(System.Windows.Forms.Control parentControl, object rpt, object ds)
        {
            try
            {
                ReportDocument r = rpt as ReportDocument;
                r.SetDataSource(ds);
                this.PrintDoc = r;
                ReportViewer.ReportSource = rpt;
                Show(parentControl);
                ReportView.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 0;
        }
        public int ShowReportOnce(System.Windows.Forms.Control parentControl, object rpt, object ds)
        {
            try
            {
                ReportDocument r = null;
                if (ReportViewer.ReportSource == null)
                {
                    r = rpt as ReportDocument;
                    r.SetDataSource(ds);
                    this.PrintDoc = r;//临时赋值 by zuowy
                    ReportViewer.ReportSource = rpt;
                    Show(parentControl);
                }
                else
                {
                    r = ReportViewer.ReportSource as ReportDocument;
                    r.SetDataSource(ds);
                    ReportView.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 0;
        }
        private void Show(System.Windows.Forms.Control f)
        {
            ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            ReportViewer.ShowGroupTreeButton = false;
            ReportViewer.DisplayGroupTree = false;
            f.Controls.Clear();
            f.Controls.Add(ReportViewer);
            f.Show();
        }
    }
}

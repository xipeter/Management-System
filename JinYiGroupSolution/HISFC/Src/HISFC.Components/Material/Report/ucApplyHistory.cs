using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Material.Report
{
    public partial class ucApplyHistory : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucApplyHistory()
        {
            InitializeComponent();
        }
        
        private string Dept = "";
        private string Item = "";
        private bool IsInit = false;
        public string reportParm = "";	//报表统计类型
        public DateTime myBeginDate;	//开始时间
        public DateTime myEndDate;		//结束时间
        private string filePath = "";   //格式配置文件地址
        public DataSet myDataSet = new DataSet();
        public DataView myDataView;
        
        private Neusoft.HISFC.BizLogic.Material.MetItem itemMgr = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 页边距 默认 50
        /// </summary>
        private int top = 10;

        /// <summary>
        /// 页边距 默认 50
        /// </summary>
        public int TableTop
        {
            set
            {
                this.top = value;
            }
        }

        /// <summary>
        /// 页边距 默认 50
        /// </summary>
        private int left = 10;

        /// <summary>
        /// 页边距 默认 50
        /// </summary>
        public int TableLeft
        {
            set
            {
                this.left = value;
            }
        }

        /// <summary>
        /// tabPage初始化
        /// </summary>
        public virtual void InitTabPage()
        {
            //默认不显示第二个tab页.如果需要可以overridate此方法.
            this.tabControl1.TabPages.Remove(this.tabPage2);
        }

        /// <summary>
        /// 设置数据第一个tab页的显示格式显示格式
        /// </summary>
        public virtual void SetFormat()
        {
            //如果存在配置文件，则调用配置文件中的样式。否则为DataSet的默认样式
            if (System.IO.File.Exists(this.filePath))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuSpread1_Sheet1, this.filePath);
            }
            else
            {
                this.neuSpread1_Sheet1.Columns[0].Width = 70F;//
                this.neuSpread1_Sheet1.Columns[1].Width = 140F;
                this.neuSpread1_Sheet1.Columns[2].Width = 70F;
                this.neuSpread1_Sheet1.Columns[3].Width = 60F;
                this.neuSpread1_Sheet1.Columns[4].Width = 60F;
                this.neuSpread1_Sheet1.Columns[5].Width = 50F;
                this.neuSpread1_Sheet1.Columns[6].Width = 70F;
                this.neuSpread1_Sheet1.Columns[7].Width = 70F;
            }
        }

        /// <summary>
        /// 添加合计项
        /// </summary>
        /// <param name="iTextIndex">"合计："项所在行</param>
        /// <param name="iIndex">需计算合计的行索引</param>
        public void SetSum(int iTextIndex, params int[] iIndex)
        {
            int iRowIndex = this.neuSpread1_Sheet1.Rows.Count;
            this.neuSpread1_Sheet1.Rows.Add(iRowIndex, 1);
            this.neuSpread1_Sheet1.Cells[iRowIndex, iTextIndex].Text = "合计：";
            if (iRowIndex == 0)
                return;
            for (int i = 0; i < iIndex.Length; i++)
            {
                if (iIndex[i] >= this.neuSpread1_Sheet1.Columns.Count)
                    continue;
                this.neuSpread1_Sheet1.Cells[iRowIndex, iIndex[i]].Formula = "SUM(" + (char)(65 + iIndex[i]) + "1:" + (char)(65 + iIndex[i]) + iRowIndex.ToString() + ")";
            }

        }

        private int iTextIndex = 0;

        private int[] iIndex = null;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="type">初始化类型</param>
        /// <param name="dept">科室代码</param>
        /// <param name="item">物资代码</param>
        /// <param name="IsQuery">是否直接查询</param>
        public void Init(string type, Neusoft.FrameWork.Models.NeuObject dept, Neusoft.FrameWork.Models.NeuObject item, bool IsQuery)
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
            this.neuSpread1_Sheet1.SetColumnAllowAutoSort(-1, true);

            if (dept == null)
            {
                this.cmbDept.Enabled = true;
                ArrayList al = new ArrayList();
                al = deptMgr.GetDeptmentAll();

                if (al != null || al.Count > 0)
                {
                    this.cmbDept.ClearItems();
                    this.cmbDept.AddItems(al);
                }

            }
            else
            {
                ArrayList al = new ArrayList();
                al.Add(dept);
                this.cmbDept.AddItems(al);
                this.cmbDept.SelectedIndex = 0;
                this.cmbDept.Tag = dept.ID;
                this.cmbDept.Text = dept.Name;
                this.Dept = dept.ID;
                this.cmbDept.Visible = false;
                this.label10.Visible = false;
            }


            if (item == null)
            {
                this.cmbItem.Enabled = true;
                List<Neusoft.HISFC.Models.Material.MaterialItem> alItem = new List<Neusoft.HISFC.Models.Material.MaterialItem>();
                alItem = this.itemMgr.GetMetItemList();
                if (alItem != null && alItem.Count > 0)
                {
                    this.cmbItem.ClearItems();
                    this.cmbItem.AddItems(new ArrayList(alItem.ToArray()));
                }
            }
            else
            {
                ArrayList al = new ArrayList();
                al.Add(item);
                this.cmbItem.AddItems(al);
                this.cmbItem.SelectedIndex = 0;
                this.Item = item.ID;
                this.cmbItem.Text = item.Name;
                this.cmbItem.Visible = false;
                this.label10.Visible = false;
            }

            this.dtpBeginDate.Value = this.itemMgr.GetDateTimeFromSysDateTime().AddMonths(-1);
            this.dtpEndDate.Value = this.itemMgr.GetDateTimeFromSysDateTime();

            if (IsQuery)
            {
                this.Query();
            }
        }

        /// <summary>
        /// 检索查询结果
        /// </summary>
        public virtual void Query()
        {
            // TODO:  添加 ucReportBase.Query 实现

            this.myBeginDate = this.dtpBeginDate.Value;	//取开始时间
            this.myEndDate = this.dtpEndDate.Value;	//取结束时间

            //判断时间的有效性
            if (this.myEndDate.CompareTo(this.myBeginDate) < 0)
            {
                MessageBox.Show("终止时间必须大于起始时间！", "提示");
                return;
            }

            this.lblTop.Text = "统计时间:" + this.myBeginDate.ToString() + " － " + this.myEndDate.ToString();
            this.lblTop.Text = "统计科室:" + this.cmbDept.Text + "               统计日期:"
                //+ this.myBeginDate.ToString() + " － " + this.myEndDate.ToString();
                + System.DateTime.Now.ToString("yyyy-MM-dd");

            Neusoft.HISFC.BizLogic.Manager.Report report = new Neusoft.HISFC.BizLogic.Manager.Report();
            //检索数据，返回dataset
            //this.myDataSet = report.Query(reportParm, this.myBeginDate, this.myEndDate);
            Neusoft.HISFC.BizLogic.Manager.Person ps = new Neusoft.HISFC.BizLogic.Manager.Person();
            Neusoft.HISFC.Models.Base.Employee var = new Neusoft.HISFC.Models.Base.Employee();// Neusoft.FrameWork.WinForms.BaseVar();
            var = ps.GetPersonByID(ps.Operator.ID);
            this.myDataSet = new DataSet();

            try
            {
                if (this.cmbItem.Tag == null || this.cmbItem.Tag.ToString() == "" || this.cmbItem.SelectedIndex < 0)
                {
                    this.cmbItem.Tag = "ALL";
                }

                if (this.cmbDept.Tag == null || this.cmbItem.Tag == null)
                {
                    MessageBox.Show("请先选择好申请科室!");
                    return;
                }

                int parm = report.ExecQuery("Material.Report.GetApplyInfoHistory", ref this.myDataSet,
                    this.cmbDept.Tag.ToString(), this.cmbItem.Tag.ToString(),
                    this.dtpBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    this.dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                if (parm == -1)
                {
                    MessageBox.Show(report.Err);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //格式配置文件地址

            //对farpoint绑定数据源
            this.myDataView = new DataView(myDataSet.Tables[0]);
            this.neuSpread1_Sheet1.DataSource = this.myDataView;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.SetFormat();

            if (this.iIndex != null)
            {
                this.SetSum(this.iTextIndex, this.iIndex);
            }
        }

        public virtual void Print()
        {
            // TODO:  添加 ucReportBase.Print 实现

            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;

            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            Neusoft.HISFC.Models.Base.PageSize page = new Neusoft.HISFC.Models.Base.PageSize();
            page.Height = 1062;
            page.Width = 965;
            page.Name = "10x11";
            print.SetPageSize(page);

            print.PrintPreview(this.left, this.top, this.panelPrint);
        }

        public virtual void Export()
        {
            // TODO:  添加 ucReportBase.Export 实现
            try
            {
                string fileName = "";
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Microsoft Excel 工作薄 (*.xls)|*.*";
                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public virtual void Import()
        {
            // TODO:  添加 ucReportBase.Import 实现
            //接口中没有打印设置，只能使用这个了
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            //纸张配置
            p.ShowPageSetup();
            p.IsHaveGrid = true;
            //打印起始终止页面配置
            p.ShowPrintPageDialog();
            System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("Letter", 813, 1064);
            p.SetPageSize(size);
            //打印预览
            p.PrintPreview(10, 60, this.panelPrint);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //初始化
            if (!this.IsInit)
            {
                this.Init(null, null, null, false);
                this.btnOK.Text = "查询";
                this.IsInit = true;
                this.label10.Visible = true;
                this.label10.Visible = true;
                this.cmbDept.Visible = true;
                this.cmbItem.Visible = true;
            }
            else
            {
                this.Query();
            }
        }

        private void dtpBeginDate_ValueChanged(object sender, EventArgs e)
        {
            this.Query();
        }

        public virtual string Parm
        {
            get
            {
                // TODO:  添加 ucReportBase.Parm getter 实现
                return reportParm;
            }
            set
            {
                // TODO:  添加 ucReportBase.Parm setter 实现
                if (value.IndexOf("|") == -1 || value.IndexOf("|") == value.Length - 1)
                    this.reportParm = value;
                else
                {
                    this.iIndex = null;
                    if (value.IndexOf("+") == -1 || value.IndexOf("+") == value.Length - 1)
                    {
                        this.reportParm = value.Substring(0, value.IndexOf("|"));
                        this.lbTitle.Text = value.Substring(value.IndexOf("|") + 1, value.Length - value.IndexOf("|") - 1);
                    }
                    else
                    {
                        string str1 = value.Substring(0, value.IndexOf("+"));
                        this.reportParm = str1.Substring(0, str1.IndexOf("|"));
                        this.lbTitle.Text = str1.Substring(str1.IndexOf("|") + 1, str1.Length - str1.IndexOf("|") - 1);

                        string str2 = value.Substring(value.IndexOf("+") + 1);
                        str2 = str2.Trim(',');
                        string[] strIndex = str2.Split(',');
                        iIndex = new int[strIndex.Length - 1];
                        iTextIndex = Neusoft.FrameWork.Function.NConvert.ToInt32(strIndex[0]);
                        int j = 1;
                        for (int i = 0; i < strIndex.Length - 1; i++)
                        {
                            if (j >= strIndex.Length)
                                break;
                            iIndex[i] = Neusoft.FrameWork.Function.NConvert.ToInt32(strIndex[j]);
                            j++;
                        }

                    }
                }
                //查询
                this.Query();
            }
        }

    }
}

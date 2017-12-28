using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// 报表基类查询控件
    /// 修改说明
    /// 1、屏蔽配置文件功能
    /// </summary>
    public partial class ucReportBase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IReport
    {
        public ucReportBase()
        {
            InitializeComponent();
        }

        #region 域变量参数

        /// <summary>
        /// 报表统计类型
        /// </summary>
        public string reportParm = "";	

        private string parm = "";

        public DataView myDataView;

        public DataSet myDataSet = new DataSet();

        private int iTextIndex = 0;

        private int[] iIndex = null;

        /// <summary>
        /// 页边距 默认 50
        /// </summary>
        private int top = 10;

        /// <summary>
        /// 页边距 默认 50
        /// </summary>
        private int left = 10;

        /// <summary>
        /// 分组列索引
        /// </summary>
        private int groupIndex = -1;

        /// <summary>
        /// 分组合计行索引
        /// </summary>
        private string groupSumIndex = "";

        /// <summary>
        /// 存储分组后的每组累计额
        /// </summary>
        private System.Collections.Hashtable hsGroupSum = new System.Collections.Hashtable();

        /// <summary>
        /// 是否显示明细Tab
        /// </summary>
        private bool isShowDetailTab = false;

        #endregion

        #region 属性

        /// <summary>
        /// Sql配置参数
        /// </summary>
        public virtual string Parm
        {
            get
            {
                // TODO:  添加 ucReportBase.Parm getter 实现
                return this.parm;
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

                this.parm = value;

                //查询
                this.Query();
            }
        }
      
        /// <summary>
        /// 页边距 默认 50
        /// </summary>
        public int TableTop
        {
            get
            {
                return this.top;
            }
            set
            {
                this.top = value;
            }
        }

        /// <summary>
        /// 页边距 默认 50
        /// </summary>
        public int TableLeft
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
            }
        }

        /// <summary>
        /// 分组列索引
        /// </summary>
        public int GroupValueIndex
        {
            get
            {
                return this.groupIndex;
            }
            set
            {
                this.groupIndex = value;
            }
        }

        /// <summary>
        /// 分组合计行索引
        /// </summary>
        [Description("分组合计行索引"), Category("设置"), DefaultValue(false)]
        public string GroupSumIndex
        {
            get
            {
                return this.groupSumIndex;
            }
            set
            {
                this.groupSumIndex = value;
            }
        }

        /// <summary>
        /// 是否显示明细Tab
        /// </summary>
        [Description("是否显示明细Tab"),Category("设置"),DefaultValue(false)]
        public bool IsShowDetailTab
        {
            get
            {
                return this.isShowDetailTab;
            }
            set
            {
                this.isShowDetailTab = value;
            }
        }

        #endregion

        /// <summary>
        /// tabPage初始化
        /// </summary>
        public virtual void InitTabPage()
        {
            //默认不显示第二个tab页.如果需要可以overridate此方法.
            this.neuTabControl1.TabPages.Remove(this.tabPage2);
        }

        /// <summary>
        /// 设置数据第一个tab页的显示格式显示格式
        /// </summary>
        public virtual void SetFormat()
        {
            //如果存在配置文件，则调用配置文件中的样式。否则为DataSet的默认样式
            //if (System.IO.File.Exists(this.filePath))
            //    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuSpread1_Sheet1, this.filePath);
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

        /// <summary>
        /// 列分组处理
        /// </summary>
        public void Group()
        {
            string groupValue = "";

            decimal totCost = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (groupValue != this.neuSpread1_Sheet1.Cells[i, this.groupIndex].Text && groupValue != "")
                {
                    
                }
            }
        }

        #region IReport 成员

        public int Query()
        {
            DateTime myBeginDate = this.dtpBeginDate.Value;	//取开始时间
            DateTime myEndDate = this.dtpEndDate.Value;	//取结束时间

            //判断时间的有效性
            if (myEndDate.CompareTo(myBeginDate) < 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("终止时间必须大于起始时间"));
                return -1;
            }

            this.lblTop.Text = Neusoft.FrameWork.Management.Language.Msg("统计时间:") + myBeginDate.ToString() + " － " + myEndDate.ToString();

            Neusoft.HISFC.BizLogic.Manager.Report report = new Neusoft.HISFC.BizLogic.Manager.Report();

            Neusoft.HISFC.BizLogic.Manager.Person ps = new Neusoft.HISFC.BizLogic.Manager.Person();
            Neusoft.HISFC.Models.Base.Employee var = new Neusoft.HISFC.Models.Base.Employee();
            var = ps.GetPersonByID(ps.Operator.ID);
            this.myDataSet = new DataSet();
            int parm = report.ExecQuery(reportParm, ref this.myDataSet, myBeginDate.ToString(), myEndDate.ToString(), var.Dept.ID);
            if (parm == -1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(report.Err));
                return -1;
            }

            //对farpoint绑定数据源
            this.myDataView = new DataView(myDataSet.Tables[0]);
            this.neuSpread1_Sheet1.DataSource = this.myDataView;

            //格式化 该函数不在起作用
            this.SetFormat();

            if (this.iIndex != null)
            {
                this.SetSum(this.iTextIndex, this.iIndex);
            }
            return 1;
        }

        #endregion

        #region IReportPrinter 成员

        public int Export()
        {
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
                return -1;
            }
            return 1;
        }

        public int Print()
        {
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;

            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            return print.PrintPage(this.left, this.top, this.panelPrint);

        }

        public int PrintPreview()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            //纸张配置
            p.ShowPageSetup();
            p.IsHaveGrid = true;
            //打印起始终止页面配置
            p.ShowPrintPageDialog();
            System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("Letter", 813, 1064);
            p.SetPageSize(size);
            //打印预览
            return p.PrintPreview(10, 60, this.panelPrint);
        }

        #endregion

        private void ucReportBase_Load(object sender, EventArgs e)
        {
            try
            {
                this.neuSpread1_Sheet1.SetColumnAllowAutoSort(-1, true);
                Neusoft.FrameWork.Management.DataBaseManger data = new Neusoft.FrameWork.Management.DataBaseManger();
                this.dtpBeginDate.Value = DateTime.Parse(data.GetSysDate() + " 00:00:00");	//起始时间
                this.dtpEndDate.Value = DateTime.Parse(data.GetSysDate() + " 23:59:59");	//结束时间

                if (!this.isShowDetailTab)
                {
                    this.InitTabPage();
                }
            }
            catch { }

        }

        private void neuSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
           // Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, this.filePath);
        }
    }
}

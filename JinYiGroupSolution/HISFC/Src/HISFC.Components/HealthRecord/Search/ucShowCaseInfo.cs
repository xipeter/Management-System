using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    public partial class ucShowCaseInfo : UserControl
    {
        public ucShowCaseInfo()
        {
            InitializeComponent();
        }
        #region  全局变量
        private System.Data.DataSet ds = null;
        private Neusoft.HISFC.BizLogic.HealthRecord.SearchManager SearMan = new Neusoft.HISFC.BizLogic.HealthRecord.SearchManager();
        #endregion
        public void LockFp()
        {
            this.fpSpread1_Sheet1.Columns[0].Width = 60;//姓名
            this.fpSpread1_Sheet1.Columns[1].Width = 65;//住院号
            this.fpSpread1_Sheet1.Columns[2].Width = 50;//性别 
            this.fpSpread1_Sheet1.Columns[3].Width = 50;//年龄
            this.fpSpread1_Sheet1.Columns[4].Width = 65;//出生年月
            this.fpSpread1_Sheet1.Columns[5].Width = 120;//籍贯
            this.fpSpread1_Sheet1.Columns[6].Width = 120;//出生地
            this.fpSpread1_Sheet1.Columns[7].Width = 120;//户籍地址
            this.fpSpread1_Sheet1.Columns[8].Width = 50;//次数
            this.fpSpread1_Sheet1.Columns[9].Width = 65;//入院日期
            this.fpSpread1_Sheet1.Columns[10].Width = 65;//入院科别
            this.fpSpread1_Sheet1.Columns[11].Width = 65;//出院日期
            this.fpSpread1_Sheet1.Columns[12].Width = 65;//出院科别
        }
        /// <summary>
        /// 根据sql查询数据
        /// </summary>
        /// <param name="xmlIndex">查询主索引 </param>
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public int SearchInfo(string xmlIndex, string strWhere)
        {
            try
            {
                if (ds != null)
                {
                    ds.Clear();//清空
                }
                else
                {
                    ds = new System.Data.DataSet();
                }
                SearMan.GetSearchInfo(xmlIndex, ds, strWhere);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        this.fpSpread1_Sheet1.DataSource = ds.Tables[0];
                    }
                }
                LockFp();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
        /// <summary>
        /// 根据sql查询数据
        /// </summary>
        /// <param name="xmlIndex"></param>
        /// <param name="likeName"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int SearchInfo(string xmlIndex, string likeName, string strWhere)
        {
            try
            {
                if (ds != null)
                {
                    ds.Clear();//清空
                }
                else
                {
                    ds = new System.Data.DataSet();
                }
                SearMan.GetSearchInfo(xmlIndex, ds, strWhere);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        this.fpSpread1_Sheet1.DataSource = ds.Tables[0];
                    }
                }
                LockFp();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public void ExportInfo()
        {
            bool ret = false;
            //导出数据
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Excel|.xls";
                saveFileDialog1.FileName = "";

                saveFileDialog1.Title = "导出数据";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    //以Excel 的形式导出数据
                    ret = fpSpread1.SaveExcel(saveFileDialog1.FileName, FarPoint.Win.Spread.Model.IncludeHeaders.BothCustomOnly);
                    if (ret)
                    {
                        MessageBox.Show("导出成功！");
                    }
                }
            }
            catch (Exception ex)
            {
                //出错了
                MessageBox.Show(ex.Message);
            }
        }
        public void PrintInfo()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
            p.PrintPreview(this.panel1);
        }

        private void ucShowCaseInfo_Load(object sender, System.EventArgs e)
        {
            LockFp();
        }
    }
}

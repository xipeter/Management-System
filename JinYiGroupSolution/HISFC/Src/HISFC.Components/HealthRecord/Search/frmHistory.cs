using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
        }
        private void frmHistory_Load(object sender, System.EventArgs e)
        {
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            SetRowHeight();
            #region 结果显示
            frm.Show();
            frm.Visible = false;
            #endregion
        }
        /// <summary>
        /// 设定表格
        /// </summary>
        public void SetRowHeight()
        {
            //定义列的格式
            FarPoint.Win.Spread.CellType.TextCellType cel = new FarPoint.Win.Spread.CellType.TextCellType();
            cel.WordWrap = true; //自动换行 
            this.fpSpread1_Sheet1.Columns[2].CellType = cel;
            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
            {
                this.fpSpread1_Sheet1.Rows[i].Height = 39;
            }
            fpSpread1_Sheet1.Columns[0].Width = 60;
            fpSpread1_Sheet1.Columns[1].Width = 50;
            fpSpread1_Sheet1.Columns[2].Width = 390;
            fpSpread1_Sheet1.Columns[3].Width = 50;
            fpSpread1_Sheet1.Columns[4].Width = 60;
            fpSpread1_Sheet1.Columns[5].Visible = false;
        }
        #region  全局变量
        private System.Data.DataTable dt = null;
        private Neusoft.HISFC.BizLogic.HealthRecord.SearchManager sm = new Neusoft.HISFC.BizLogic.HealthRecord.SearchManager();
        private frmShowResult frm = new frmShowResult();
        public bool BoolClose = false;
        #endregion
        /// <summary>
        /// 初始化表
        /// </summary>
        public void InitDateTable()
        {
            dt = new DataTable();
            Type strType = typeof(System.String);
            Type intType = typeof(System.Int32);
            Type dtType = typeof(System.DateTime);
            Type boolType = typeof(System.Boolean);

            dt.Columns.AddRange(new DataColumn[]{new DataColumn("日期", strType),
													new DataColumn("检索人", strType),
													new DataColumn("检索条件", strType),
													new DataColumn("记录数", strType),
													new DataColumn("检索医生", strType),
													new DataColumn("序号",strType)});
            this.fpSpread1_Sheet1.DataSource = dt;
        }
        /// <summary>
        /// 加载数据 
        /// </summary>
        /// <param name="list"></param>
        /// <returns>出错返回 -1 </returns>
        public int AddInfo(ArrayList list)
        {
            try
            {
                if (list == null)
                {
                    return -1;
                }
                if (list.Count == 0)
                {
                    this.dt.Clear();
                }
                Neusoft.FrameWork.Models.NeuObject obj = null;
                for (int i = 0; i < list.Count; i = i + 5)
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = ((Neusoft.FrameWork.Models.NeuObject)list[i]).ID;//日期
                    obj.Name = ((Neusoft.FrameWork.Models.NeuObject)list[i + 1]).ID;//检索者
                    obj.User01 = ((Neusoft.FrameWork.Models.NeuObject)list[i + 2]).ID;//检索条件 
                    obj.User02 = ((Neusoft.FrameWork.Models.NeuObject)list[i + 3]).ID;//记录数
                    obj.User03 = ((Neusoft.FrameWork.Models.NeuObject)list[i + 4]).ID;//检索医生
                    string strSequence = ((Neusoft.FrameWork.Models.NeuObject)list[i]).User02;
                    dt.Rows.Add(new object[] { obj.ID, obj.Name, obj.User01, obj.User02, obj.User03, strSequence });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            SetRowHeight();
            return 1;
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (this.fpSpread1_Sheet1.Rows.Count == 0)
                {
                    return;
                }
                string Sequence = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 5].Text;
                string Result = sm.SelectResult(Sequence);
                if (Result != null)
                {
                    this.TopMost = false; //本窗口不处于最前面
                    frm.LBSeacheInfo.Text = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 2].Text;
                    frm.InpatientNoList = Result;
                    frm.Visible = true;
                    frm.TopMost = true; //显示窗口处于最前面
                    frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                }
                else
                {
                    MessageBox.Show("查询出错" + sm.Err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmHistory_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!BoolClose)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }
    }
}
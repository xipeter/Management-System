using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    /// <summary>
    /// ucNeedCase<br></br>
    /// [功能描述: 门诊病人需要病案病人查询]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-05-9]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucNeedCase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucNeedCase()
        {
            InitializeComponent();
        }

        #region 工具栏信息
        private int timeNum = 5000;
        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            //toolBarService.AddToolButton("查询", "查询", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            return toolBarService;
        }
        #endregion

        #region 工具栏增加按钮单击事件
        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                //case "查询":
                //    Search();
                //    break;
                default:
                    break;
            }
        }
        #endregion

        #endregion

        protected override int OnQuery(object sender, object neuObject)
        {
            Search();
            return base.OnQuery(sender, neuObject);
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void Search()
        {
            Neusoft.HISFC.BizLogic.HealthRecord.SearchManager searchMgr = new Neusoft.HISFC.BizLogic.HealthRecord.SearchManager();
            System.Data.DataSet ds = new DataSet();
            if (searchMgr.QueryClinicPatientNeedCase(this.dtBegin.Value, this.dtEnd.Value, ref ds) < 0)
            {
                this.neuSpread1_Sheet1.RowCount = 0;
                MessageBox.Show("查询出错");
                return;
            }
            if (ds != null && ds.Tables.Count > 0)
            {
                this.neuSpread1_Sheet1.DataSource = ds;
            }
            else
            {
                this.neuSpread1_Sheet1.RowCount = 0;
            }
        }

        #region 时间改变
        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtEnd.Value < dtBegin.Value)
            {
                dtEnd.Value = dtBegin.Value;
            }
        }

        private void dtBegin_ValueChanged(object sender, EventArgs e)
        {
            if (dtEnd.Value < dtBegin.Value)
            {
                dtBegin.Value = dtEnd.Value;
            }
        }
        #endregion
        private enum EnumCols
        {
            Name, //姓名
            CardNO,//卡号
            Sex,//性别
            Dept //科室 
        }
        private void ucNeedCase_Load(object sender, EventArgs e)
        {
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;

            this.timer1.Interval = 5000;
            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType.ReadOnly = true;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.Name].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.CardNO].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.Sex].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.Dept].CellType = txtCellType; 
        }

        #region 自动刷新
        private void cbHand_CheckedChanged(object sender, EventArgs e)
        { 
            this.cbAuto.Checked = !cbHand.Checked; 
        }

        private void cbAuto_CheckedChanged(object sender, EventArgs e)
        {
            cbHand.Checked = !cbAuto.Checked;
            if (cbAuto.Checked)
            {
                txtTime.Enabled = true;
            }
            else
            {
                txtTime.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!cbAuto.Checked)
            {
                return ;
            } 
            Search();
        }
        #endregion 

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(txtTime.Text) <=0)
            {
                return;
            }
            this.timer1.Interval = Neusoft.FrameWork.Function.NConvert.ToInt32(txtTime.Text) * 1000;
            if (timer1.Interval < 5000)
            {
                timer1.Interval = 5000;
            }
            this.timer1.Enabled = cbAuto.Checked;
        }
    } 
}

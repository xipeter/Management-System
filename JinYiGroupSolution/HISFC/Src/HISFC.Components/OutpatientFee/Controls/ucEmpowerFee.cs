using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Neusoft.HISFC.BizLogic.Fee;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    /// <summary>
    /// ucBalance<br></br>
    /// [功能描述: 收费授权(日结后通过财务授权后才可以继续收费)]<br></br>//{645F3DDE-4206-4f26-9BC5-307E33BD882C}
    /// [创 建 者: 董国强]<br></br>
    /// [创建时间: 2010-08-02]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucEmpowerFee : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 变量

        private EmpowerFee empowerFeeManager = new EmpowerFee();
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarservice = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 初始化


        #region 构造方法

        /// <summary>
        ///  构造方法
        /// </summary>
        public ucEmpowerFee()
        {
            InitializeComponent();
            InitControls();
        }

        #endregion

        /// <summary>
        /// 初始化控件的设置或值
        /// </summary>
        private void InitControls()
        {
            //DateTimePicker
            this.dtpBegin.Value = empowerFeeManager.GetDateTimeFromSysDateTime().Date;
            this.dtpEnd.Value = empowerFeeManager.GetDateTimeFromSysDateTime().Date.AddDays(1).AddSeconds(-1);
            //Farpoint--left
            fpUnauthorized_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            fpAuthorized_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            //屏蔽Farpoint按键
            //InputMap im;
            //im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //im.Put(new Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //im.Put(new Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //im.Put(new Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        /// <summary>
        /// 自定义Toolbar按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarservice.AddToolButton("授权", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.R入库单, true, false, null);
            toolBarservice.AddToolButton("作废", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.R入库单, true, false, null);
            return toolBarservice;
        }

        #endregion

        #region 方法

        #region ToolBar按钮事件处理

        /// <summary>
        /// Toolbar上的【查询】按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            QueryAllDayBalance();

            return base.OnQuery(sender, neuObject);
        }

        /// <summary>
        /// Toolbar上的【授权】按钮单击事件
        /// </summary>
        private void Authorized()
        {
            if (fpUnauthorized_Sheet1 == null || fpUnauthorized_Sheet1.RowCount <= 0)
            {
                MessageBox.Show("没用任何记录可以操作！");
                return;
            }
            else
            {               

                Neusoft.HISFC.Models.Fee.EmpowerFeeOper empowerFeeOper = new Neusoft.HISFC.Models.Fee.EmpowerFeeOper();
                int ridx = fpUnauthorized_Sheet1.ActiveRowIndex;
                empowerFeeOper.FeeOperCode = fpUnauthorized_Sheet1.Cells[ridx, 4].Value.ToString();
                empowerFeeOper.StatNo = fpUnauthorized_Sheet1.Cells[ridx, 5].Value.ToString();
                empowerFeeOper.DayBalanceDate = Convert.ToDateTime(fpUnauthorized_Sheet1.Cells[ridx, 1].Value);
                empowerFeeOper.OperCode = empowerFeeManager.Operator.ID;
                empowerFeeOper.OperDate = empowerFeeManager.GetDateTimeFromSysDateTime();
                empowerFeeOper.Valid = true;
                if (empowerFeeManager.InsertEmpowerOper(empowerFeeOper))
                {
                    QueryAllDayBalance();
                    QueryAllEmpowered();
                }

            }
        }

        /// <summary>
        /// Toolbar上的【作废】按钮单击事件
        /// </summary>
        private void Unauthorized()
        {
            if (fpAuthorized_Sheet1 == null || fpAuthorized_Sheet1.RowCount <= 0)
            {
                MessageBox.Show("没用任何记录可以操作！");
                return;
            }
            else
            {
                int ridx = fpAuthorized_Sheet1.ActiveRowIndex;
                string feeOperCode = fpAuthorized_Sheet1.Cells[ridx, 4].Value.ToString();
                string statNo = fpAuthorized_Sheet1.Cells[ridx, 5].Value.ToString();

                if (empowerFeeManager != null && !string.IsNullOrEmpty(feeOperCode) && !string.IsNullOrEmpty(statNo))
                {
                    if (MessageBox.Show("确定作废吗?", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        empowerFeeManager.DeleteEmpowerByPk(feeOperCode, statNo);
                        QueryAllDayBalance();
                        QueryAllEmpowered();
                    }
                }
            }
        }


        #endregion

        #region 业务方法

        /// <summary>
        /// 查询所有已经授权的记录
        /// </summary>
        private void QueryAllEmpowered()
        {
            if (empowerFeeManager != null)
            {
                System.Data.DataTable dt = empowerFeeManager.QueryAllEmpowered();
                if (dt != null)
                {
                    fpAuthorized_Sheet1.DataSource = dt;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 查询所有没用日结的记录
        /// </summary>
        private void QueryAllDayBalance()
        {
            if (empowerFeeManager != null)
            {
                System.Data.DataTable dt = empowerFeeManager.QueryAllDayBalance(dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                if (dt != null)
                {
                    fpUnauthorized_Sheet1.DataSource = dt;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        #endregion

        #endregion

        #region 事件

        /// <summary>
        /// 自定义Toolbar按钮的事件处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "授权":
                    {
                        Authorized();
                        break;
                    }
                case "作废":
                    {
                        Unauthorized();
                        break;
                    }
                default:
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// uc的Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucEmpowerFee_Load(object sender, EventArgs e)
        {
            QueryAllDayBalance();
            QueryAllEmpowered();

        }

        #endregion

    }
}

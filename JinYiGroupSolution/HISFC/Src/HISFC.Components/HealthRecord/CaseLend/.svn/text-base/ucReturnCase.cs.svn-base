using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
namespace Neusoft.HISFC.Components.HealthRecord.CaseLend
{
    public partial class ucReturnCase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucReturnCase()
        {
            InitializeComponent();
        }

        #region  全局变量
        private Neusoft.HISFC.BizLogic.HealthRecord.CaseCard card = new Neusoft.HISFC.BizLogic.HealthRecord.CaseCard();
        private ArrayList LendList = null;
        Neusoft.FrameWork.Public.ObjectHelper SexHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        #endregion

        #region 工具栏信息

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
            toolBarService.AddToolButton("确定", "确定", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借入, true, false, null);
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
                case "确定":
                    ReturnCase();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #endregion

        private void frmReturnCase_Load(object sender, System.EventArgs e)
        {
            SexHelper.ArrayObject = Neusoft.HISFC.Models.Base.SexEnumService.List();
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            LockFP();
        }

        enum Cols
        {
            Check, //选择 
            CaseNO, //病案号
            StrType,//类型
            patientName, //姓名
            SexID,//性别
            LentType,//借阅类型
            OperTime,//借阅日期
            InpatientNO //住院流水号
        }
        private void LockFP()
        {
            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType.ReadOnly = false;
            this.fpSpread1_Sheet1.Columns[(int)Cols.CaseNO].CellType = txtCellType;
            this.fpSpread1_Sheet1.Columns[(int)Cols.StrType].CellType = txtCellType;
            this.fpSpread1_Sheet1.Columns[(int)Cols.patientName].CellType = txtCellType;
            this.fpSpread1_Sheet1.Columns[(int)Cols.SexID].CellType = txtCellType;
            this.fpSpread1_Sheet1.Columns[(int)Cols.LentType].CellType = txtCellType;
            this.fpSpread1_Sheet1.Columns[(int)Cols.StrType].CellType = txtCellType;
            this.fpSpread1_Sheet1.Columns[(int)Cols.InpatientNO].CellType = txtCellType;
            this.fpSpread1_Sheet1.Columns[(int)Cols.OperTime].CellType = txtCellType;
        }
        #region 加载信息
        /// <summary>
        /// 加载信息
        /// </summary>
        /// <param name="list"></param>
        private void AddDateInfo(ArrayList list)
        {
            this.fpSpread1_Sheet1.RowCount = 0;
            foreach (Neusoft.HISFC.Models.HealthRecord.Lend info in list)
            {
                this.fpSpread1_Sheet1.Rows.Add(0, 1);
                if (info.CaseBase.PatientInfo.Sex.ID != null)
                {
                    this.fpSpread1_Sheet1.Cells[0, (int)Cols.SexID].Text = SexHelper.GetName(info.CaseBase.PatientInfo.Sex.ID.ToString());
                }
                this.fpSpread1_Sheet1.Columns[0, (int)Cols.Check].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                this.fpSpread1_Sheet1.Cells[0, (int)Cols.Check].Value = true;
                this.fpSpread1_Sheet1.Cells[0, (int)Cols.CaseNO].Text = info.CaseBase.CaseNO;
                this.fpSpread1_Sheet1.Cells[0, (int)Cols.patientName].Text = info.CaseBase.PatientInfo.Name;
                if (info.LendKind == "1")
                {
                    this.fpSpread1_Sheet1.Cells[0, (int)Cols.LentType].Text = "内借";
                }
                else if (info.LendKind == "2")
                {
                    this.fpSpread1_Sheet1.Cells[0, (int)Cols.LentType].Text = "外借";
                }
                this.fpSpread1_Sheet1.Cells[0, (int)Cols.InpatientNO].Text = info.CaseBase.PatientInfo.ID;
                this.fpSpread1_Sheet1.Cells[0, (int)Cols.OperTime].Text = info.OperInfo.OperTime.ToShortDateString();
                this.fpSpread1_Sheet1.Rows[0].Tag = info;
                this.SetInfo(info);
            }
            Common.Classes.Function.DrawCombo(this.fpSpread1_Sheet1, (int)Cols.CaseNO, (int)Cols.StrType);
        }
        #endregion

        #region 显示信息
        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="obj"></param>
        private void SetInfo(Neusoft.HISFC.Models.HealthRecord.Lend obj)
        {
            CardNO.Text = obj.CardNO;
            txName.Text = obj.EmployeeInfo.Name;
            txDept.Text = obj.EmployeeDept.Name;　
            dtContinue.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(card.GetSysDate());
            dtReturn.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(card.GetSysDate());
            txReturn.Text = obj.Memo;
        }
        #endregion

        private bool ValidState()
        {
            DateTime nowTime = this.card.GetDateTimeFromSysDateTime();
            
            #region 续借
            if (cbContinueLend.Checked)
            {
                if (dtContinue.Value <= nowTime)
                {
                    System.TimeSpan sp = nowTime - dtContinue.Value;
                    if (sp.Days > 0)
                    {
                        MessageBox.Show("续借日期不能小于当前日期");

                        return false;
                    }
                } 
            }


            #endregion

            return true;
        }
        #region 保存
        private void ReturnCase()
        {

            if (!ValidState())
            {
                return;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(txReturn.Text, 100))
            {
                MessageBox.Show("归还情况过长");
                return;
            }
            ArrayList list = GetInfo(); //获取信息
            if (list == null)
            { 
                return;
            }
            if (list.Count == 0)
            {
                MessageBox.Show("请选择需要归还的病案");
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(card.Connection);
            //trans.BeginTransaction();

            card.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            foreach (Neusoft.HISFC.Models.HealthRecord.Lend obj in list)
            {
                if (card.ReturnCase(obj) < 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("操作失败: " + card.Err);
                    return;
                }
                if (!cbContinueLend.Checked) //归还
                {
                    if (card.UpdateBase(LendType.I, obj.CaseBase.CaseNO) <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新病案主表失败");
                        return;
                    }
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("操作成功");
            this.ClearInfo();
            this.CardNO.SelectAll();
            
        }
        private void ClearInfo()
        {
            this.fpSpread1_Sheet1.RowCount = 0;
            this.txName.Text = "";
            txDept.Text = "";
            CardNO.Text = "";
            txReturn.Text = "";
        }
        private ArrayList GetInfo()
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.fpSpread1_Sheet1.Cells[i, (int)Cols.Check].Value == null || fpSpread1_Sheet1.Cells[i, (int)Cols.Check].Value.ToString().ToUpper() != "TRUE")
                {
                    continue;
                }
                Neusoft.HISFC.Models.HealthRecord.Lend obj = (Neusoft.HISFC.Models.HealthRecord.Lend)fpSpread1_Sheet1.Rows[i].Tag;
                if (obj == null)
                {
                    MessageBox.Show("获取病案信息出错");
                    return null;
                }
                #region  校验
                for (int j = 0; j < this.fpSpread1_Sheet1.Rows.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (fpSpread1_Sheet1.Cells[i, (int)Cols.CaseNO].Text == fpSpread1_Sheet1.Cells[j, (int)Cols.CaseNO].Text)
                    {
                        if (this.fpSpread1_Sheet1.Cells[j, (int)Cols.Check].Value == null)
                        {
                            MessageBox.Show("病案号相同的必须全部选中");
                            return null;
                        }
                        if (this.fpSpread1_Sheet1.Cells[j, (int)Cols.Check].Value.ToString().ToUpper() != "TRUE")
                        {
                            MessageBox.Show("病案号相同的必须全部选中");
                            return null;
                        }
                    }
                }
                #endregion 
                if (cbContinueLend.Checked) //续借
                {
                    obj.PrerDate = dtContinue.Value;
                }
                else if (cbReturn.Checked) //返还
                {
                    obj.ReturnDate = dtReturn.Value; //实际返还时间 
                    obj.ReturnOperInfo.ID = card.Operator.ID;  //返还操作员
                    obj.LendStus = "2"; //状态 
                    obj.Memo = this.txReturn.Text; //是否完好 
                }
                else
                {
                    obj.LendStus = "1"; //状态 
                }
                list.Add(obj);
            }
            return list;
        }
        #endregion

        #region 回车事件

        private void cbReturn_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dtReturn.Enabled = this.cbReturn.Checked;
            //if (!cbReturn.Checked)
            //{
                cbContinueLend.Checked = !cbReturn.Checked;
            //}
        }

        private void cbContinueLend_CheckedChanged(object sender, System.EventArgs e)
        {
            this.dtContinue.Enabled = this.cbContinueLend.Checked;
            //if (!cbContinueLend.Checked)
            //{
                cbReturn.Checked = !cbContinueLend.Checked;
            //}
        }
        private void CardNO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.CardNO.Text == "")
                {
                    MessageBox.Show("请输入卡号");
                    return;
                }
                LendList = null;
                LendList = this.card.QueryLendInfo(this.CardNO.Text);
                if (LendList == null)
                {
                    CardNO.SelectAll();
                    MessageBox.Show("查询借阅信息出错");
                    return;
                }
                if (LendList.Count == 0)
                {
                    CardNO.SelectAll();
                    MessageBox.Show("没有查到尚未归还的借阅信息");
                    return;
                }

                AddDateInfo(LendList);
                this.cbContinueLend.Focus();
            }
        }
        private void cbContinueLend_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == e.KeyData)
            {
                if (this.cbContinueLend.Checked)
                {
                    this.dtContinue.Focus();
                }
                else
                {
                    this.dtReturn.Focus();
                }
            }
        }

        private void cbReturn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == e.KeyData)
            {
                if (this.cbReturn.Checked)
                {
                    this.dtReturn.Focus();
                }
                else
                {
                    this.dtContinue.Focus();
                }
            }
        }

        private void dtContinue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txReturn.Focus();
            }
        }

        #endregion
    }
}

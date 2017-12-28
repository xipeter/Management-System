using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    public partial class ucCaseTrack : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCaseTrack()
        {
            InitializeComponent();
        }
        Neusoft.HISFC.BizLogic.HealthRecord.Base baseMgr = new Neusoft.HISFC.BizLogic.HealthRecord.Base();
        Neusoft.HISFC.BizLogic.HealthRecord.CaseCard caseCard = new Neusoft.HISFC.BizLogic.HealthRecord.CaseCard();
        Neusoft.FrameWork.Public.ObjectHelper objSex = new Neusoft.FrameWork.Public.ObjectHelper();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            Query();
            return base.OnQuery(sender, neuObject);
        }
        /// <summary>
        /// 操作员
        /// </summary>
        private enum EnumCols
        {
            OperTime, //操作时间
            InpatientNO,//住院流水号
            Name,//姓名
            Sex,//性别
            CaseState, //状态
            LendTime, //借阅时间
            ReturnTime // 归还时间
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void Query()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            string strCaseNO = txtCaseNO.Text.PadLeft(10, '0');
            ArrayList list = baseMgr.QueryCaseBaseInfoByCaseNO(strCaseNO);
            if (list == null)
            {
                MessageBox.Show("查询病案失败 " + baseMgr.Err);
                return;
            } 

            if(list.Count == 0)
            {
                MessageBox.Show("没有病案信息");
                return;
            }
            #region 病案主表信息
            foreach (Neusoft.HISFC.Models.HealthRecord.Base obj in list)
            {
                this.neuSpread1_Sheet1.Rows.Add(0, 1);
                //操作时间
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.OperTime].Text = obj.OperInfo.OperTime.ToShortDateString();
                //住院流水号
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.InpatientNO].Text = obj.PatientInfo.ID;
                //姓名
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.Name].Text = obj.PatientInfo.Name;
                string SexID = "";

                if (obj.PatientInfo.Sex.ID != null)
                {
                    SexID = obj.PatientInfo.Sex.ID.ToString();
                }
                //性别
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.Sex].Text = objSex.GetName(SexID);
                if (obj.PatientInfo.CaseState == "1")
                {
                    //状态
                    this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.CaseState].Text = "没有形成病案";
                }
                else if (obj.PatientInfo.CaseState == "2")
                {
                    //状态
                    this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.CaseState].Text = "医生站形成病案";
                }
                else if (obj.PatientInfo.CaseState == "3")
                {
                    //状态
                    this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.CaseState].Text = "病案室形成病案";
                }
                else if (obj.PatientInfo.CaseState == "4")
                {
                    //状态
                    this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.CaseState].Text = "病案封存";
                }
            }
            #endregion 

            ArrayList cardList = caseCard.QueryLendInfoByCaseNO(strCaseNO);
            if (cardList == null)
            {
                MessageBox.Show("查询病案借阅信息失败 " + baseMgr.Err);
                return;
            }
            if (cardList.Count == 0)
            {
                return;
            }
            #region 病案借阅信息
            foreach (Neusoft.HISFC.Models.HealthRecord.Lend info in cardList)
            {
                this.neuSpread1_Sheet1.Rows.Add(0, 1);
                //操作时间
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.OperTime].Text = info.OperInfo.OperTime.ToShortDateString();
                //住院流水号
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.InpatientNO].Text = info.CaseBase.PatientInfo.ID;
                //姓名
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.Name].Text = info.CaseBase.PatientInfo.Name;
                string SexID = "";

                if (info.CaseBase.PatientInfo.Sex.ID != null)
                {
                    SexID = info.CaseBase.PatientInfo.Sex.ID.ToString();
                }
                //性别
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.Sex].Text = objSex.GetName(SexID);
                if (info.LendStus == "1")
                {
                    //状态
                    this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.CaseState].Text = "病案借出";
                }
                else if (info.LendStus == "2")
                {
                    //状态
                    this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.CaseState].Text = "借阅后返还";
                    //归还日期
                    this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.ReturnTime].Text = info.ReturnDate.ToShortDateString();
                }
                //借阅日期
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCols.LendTime].Text = info.LendDate.ToShortDateString();
               
            }
            #endregion 

        }

        private void ucCaseTrack_Load(object sender, EventArgs e)
        {
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            objSex.ArrayObject = Neusoft.HISFC.Models.Base.SexEnumService.List();
            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType.ReadOnly = true;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.OperTime].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.InpatientNO].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.Name].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.Sex].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.CaseState].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.LendTime].CellType = txtCellType;
            this.neuSpread1_Sheet1.Columns[(int)EnumCols.ReturnTime].CellType = txtCellType;
        }

        private void txtCaseNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                this.Query();
            }
        }
    }
}

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病案基本信息维护]<br></br>
    /// [创 建 者: 周全]<br></br>
    /// [创建时间: 2007/09/10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucCaseInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCaseInfo()
        {
            InitializeComponent();

            this.Init();
        }

        #region 变量

        /// <summary>
        /// 病案基本信息维护
        /// </summary>
        private Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseInfo caseInfoMrg = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseInfo();

        /// <summary>
        /// 工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 组合类维护
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.HealthRecord.Case.Case caseMrg = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.Case.Case();

        /// <summary>
        /// 病案信息
        /// </summary>
        private Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInformation = new Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo();

        #endregion

        #region 事件

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("测试", "功能测试", 1, true, false, null);

            return toolBarService;

        }

        /// <summary>
        /// 病案状态改变事件 当为丢失状态时显示丢失原因
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCaseState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCaseState.Tag.ToString() == "00")
            {
                this.labCaseLose.Visible = true;
                this.cmbCaseLose.Visible = true;
                this.cmbCaseLose.Tag = "01";
            }
            else
            {
                this.labCaseLose.Visible = false;
                this.cmbCaseLose.Visible = false;
                this.cmbCaseLose.Tag = "";
            }
        }

        /// <summary>
        /// 病案所在类型改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbInType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbInType.Tag.ToString() == "0")
            {
                this.lblInType.Text = "病案所在人员：";
                this.cmbInEmployee.Visible = true;
                this.cmbInDept.Visible = false;
            }
            else
            { 
                this.lblInType.Text = "病案所在科室：";
                this.cmbInDept.Visible = true;
                this.cmbInEmployee.Visible = false;
            }
        }

        /// <summary>
        /// 表单双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.SetContorl();
        }

        /// <summary>
        /// 键盘触发事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.txtSearchFor.Focused)
                {
                    if (string.IsNullOrEmpty(this.txtSearchFor.Text)) this.Clear();

                    if (this.cmbSearchType.Text == "按病历号查询")
                    {
                        this.txtSearchFor.Text = this.txtSearchFor.Text.PadLeft(10, '0');
                        this.SelectCase(this.txtSearchFor.Text);
                    }
                }
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            if (this.Valid() < 0) return -1;

            Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo = new Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo();

            caseInfo = this.caseInformation;

            caseInfo.Cabinet.ID = this.txtCabinetNO.Text;
            caseInfo.GridNO = this.txtGridNO.Text;
            caseInfo.CaseState.ID = this.cmbCaseState.Tag.ToString();
            caseInfo.LoseState.ID = this.cmbCaseLose.Tag.ToString();
            caseInfo.InType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.cmbInType.Tag);

            if (this.cmbInEmployee.Visible)
            {
                caseInfo.InEmployee.ID = this.cmbInEmployee.Tag.ToString();
                caseInfo.InDept.ID = "";
            }
            else if (this.cmbInDept.Visible)
            {
                caseInfo.InDept.ID = this.cmbInDept.Tag.ToString();
                caseInfo.InEmployee.ID = "";
            }

            //保存数据

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.caseInfoMrg.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.caseInfoMrg.Update(caseInfo) < 0)
            {
                MessageBox.Show("更新失败！ " + this.caseInfoMrg.Err, "提示");
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //FarPoint刷新
            this.SetSingleRow(this.fpSpread_Sheet.ActiveRow.Index, caseInfo);

            MessageBox.Show("更新成功！", "提示");
            this.Clear();

            return base.OnSave(sender, neuObject);
        }

        #endregion

        #region 函数

        /// <summary>
        /// 初始化函数
        /// </summary>
        private void Init()
        {
            this.cmbCaseState.AddItems(this.caseMrg.GetCaseConstant("CASE02"));
            this.cmbCaseState.Tag = "01";

            this.cmbCaseLose.AddItems(this.caseMrg.GetCaseConstant("CASE03"));
            this.cmbCaseLose.Tag = "01";

            this.cmbInType.AddItems(this.caseMrg.GetCaseConstant("INTYPE"));
            this.cmbInType.Tag = "0";

            this.cmbInEmployee.AddItems(this.caseMrg.GetEmployeeAll()); //获取所有人员列表

            this.cmbInDept.AddItems(this.caseMrg.GetDeptmentAll()); //获取所有科室列表

            this.cmbSearchType.SelectedIndex = 0;

            this.SetFpSpeard();
        }

        /// <summary>
        /// 设置FarPoint
        /// </summary>
        private void SetFpSpeard()
        {
            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();

            this.fpSpread_Sheet.ColumnCount = 15;
            this.fpSpread_Sheet.Columns[0].CellType = txt;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 0].Text = "当前病历号";
            this.fpSpread_Sheet.ColumnHeader.Columns[0].Width = 100;
            this.fpSpread_Sheet.Columns[1].CellType = txt;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 1].Text = "初诊病历号";
            this.fpSpread_Sheet.ColumnHeader.Columns[1].Width = 100;
            this.fpSpread_Sheet.Columns[2].CellType = txt;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 2].Text = "门诊病历号";
            this.fpSpread_Sheet.ColumnHeader.Columns[2].Width = 100;
            this.fpSpread_Sheet.Columns[3].CellType = txt;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 3].Text = "住院病历号";
            this.fpSpread_Sheet.ColumnHeader.Columns[3].Width = 100;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 4].Text = "姓名";
            this.fpSpread_Sheet.ColumnHeader.Columns[4].Width = 60;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 5].Text = "性别";
            this.fpSpread_Sheet.ColumnHeader.Columns[5].Width = 40;
            this.fpSpread_Sheet.Columns[6].CellType = txt;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 6].Text = "出生日期";
            this.fpSpread_Sheet.ColumnHeader.Columns[6].Width = 100;
            this.fpSpread_Sheet.Columns[7].CellType = txt;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 7].Text = "身份证号";
            this.fpSpread_Sheet.ColumnHeader.Columns[7].Width = 120;
            this.fpSpread_Sheet.Columns[8].CellType = txt;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 8].Text = "病案柜编码";
            this.fpSpread_Sheet.ColumnHeader.Columns[8].Width = 80;
            this.fpSpread_Sheet.Columns[9].CellType = txt;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 9].Text = "病案柜格号";
            this.fpSpread_Sheet.ColumnHeader.Columns[9].Width = 80;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 10].Text = "病案状态";
            this.fpSpread_Sheet.ColumnHeader.Columns[10].Width = 60;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 11].Text = "丢失原因";
            this.fpSpread_Sheet.ColumnHeader.Columns[11].Width = 80;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 12].Text = "病案所在类型";
            this.fpSpread_Sheet.ColumnHeader.Columns[12].Width = 100;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 13].Text = "病案所在人员";
            this.fpSpread_Sheet.ColumnHeader.Columns[13].Width = 100;
            this.fpSpread_Sheet.ColumnHeader.Cells[0, 14].Text = "病案所在科室";
            this.fpSpread_Sheet.ColumnHeader.Columns[14].Width = 100;

            ArrayList caseList = this.caseInfoMrg.GetAllCaseInfo();
            this.fpSpread_Sheet.RowCount = caseList.Count;

            Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo = new Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo();

            for (int i = 0; i < caseList.Count; i++)
            {
                caseInfo = caseList[i] as Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo;

                this.SetSingleRow(i, caseInfo);
            }
        }

        /// <summary>
        /// FarPoint设置单行
        /// </summary>
        /// <param name="caseInfo"></param>
        private void SetSingleRow(int index, Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo)
        {
            caseInfo.CaseState = this.caseMrg.GetConstant("CASE02", caseInfo.CaseState.ID);
            caseInfo.LoseState = this.caseMrg.GetConstant("CASE03", caseInfo.LoseState.ID);
            caseInfo.InEmployee = this.caseMrg.GetPersonByID(caseInfo.InEmployee.ID);
            caseInfo.InDept = this.caseMrg.GetDeptmentById(caseInfo.InDept.ID);

            if (caseInfo.InDept == null) caseInfo.InDept = new Neusoft.HISFC.Models.Base.Department();

            this.fpSpread_Sheet.Rows[index].Tag = caseInfo;
            this.fpSpread_Sheet.Cells[index, 0].Text = caseInfo.Patient.PID.CardNO; //当前病历号
            this.fpSpread_Sheet.Cells[index, 1].Text = caseInfo.Patient.User01; //初诊病历号
            this.fpSpread_Sheet.Cells[index, 2].Text = caseInfo.Patient.User02; //门诊病历号
            this.fpSpread_Sheet.Cells[index, 3].Text = caseInfo.Patient.User03; //住院病历号
            this.fpSpread_Sheet.Cells[index, 4].Text = caseInfo.Patient.Name; //患者姓名
            this.fpSpread_Sheet.Cells[index, 5].Text = caseInfo.Patient.Sex.Name; //患者性别
            this.fpSpread_Sheet.Cells[index, 6].Text = caseInfo.Patient.Birthday.ToShortDateString(); //出生日期
            this.fpSpread_Sheet.Cells[index, 7].Text = caseInfo.Patient.IDCard; //身份证号
            this.fpSpread_Sheet.Cells[index, 8].Text = caseInfo.Cabinet.ID; //病案柜编码
            this.fpSpread_Sheet.Cells[index, 9].Text = caseInfo.GridNO; //病案柜格号
            this.fpSpread_Sheet.Cells[index, 10].Text = caseInfo.CaseState.Name; //病案状态
            this.fpSpread_Sheet.Cells[index, 11].Text = caseInfo.LoseState.Name; //丢失原因

            //病案所在
            if (caseInfo.InType == 0)
            {
                this.fpSpread_Sheet.Cells[index, 12].Text = "个人";
            }
            else if (caseInfo.InType == 1)
            {
                this.fpSpread_Sheet.Cells[index, 12].Text = "科室";
            }

            this.fpSpread_Sheet.Cells[index, 13].Text = caseInfo.InEmployee.Name; //病案所在个人
            this.fpSpread_Sheet.Cells[index, 14].Text = caseInfo.InDept.Name; //病案所在科室
        }

        /// <summary>
        /// 有效性验证
        /// </summary>
        /// <returns></returns>
        private int Valid()
        {
            if (string.IsNullOrEmpty(this.txtNowCardNO.Text))
            {
                MessageBox.Show("请选择病案信息！", "提示");
                return -1;
            }

            if (string.IsNullOrEmpty(this.txtCabinetNO.Text))
            {
                MessageBox.Show("病案柜编码不能为空！", "提示");
                this.txtCabinetNO.Focus();
                return -1;
            }

            if (string.IsNullOrEmpty(this.txtGridNO.Text))
            {
                MessageBox.Show("病案柜格号不能为空！", "提示");
                this.txtGridNO.Focus();
                return -1;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtCabinetNO.Text, 50))
            {
                MessageBox.Show("输入的病案柜编码过长！", "提示");
                this.txtCabinetNO.Focus();
                this.txtCabinetNO.SelectAll();
                return -1;
            }

            try
            {
                int j = (Convert.ToInt32(this.txtGridNO.Text)) / 2;
            }
            catch
            {
                MessageBox.Show("病案柜格号输入数据非法：必须为数字", "提示");
                this.txtGridNO.Focus();
                this.txtGridNO.SelectAll();

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 选择病案
        /// </summary>
        /// <param name="cardNO"></param>
        private void SelectCase(string cardNO)
        {
            for (int i = 0; i < this.fpSpread_Sheet.RowCount; i++)
            {
                if (cardNO == this.fpSpread_Sheet.Cells[i, 0].Text)
                {
                    this.fpSpread_Sheet.ActiveRowIndex = i;
                    this.fpSpread_Sheet.AddSelection(i, 0, 1, 0);

                    this.SetContorl();
                    return;
                }
            }

            this.Clear();
        }

        /// <summary>
        /// 控件赋值
        /// </summary>
        private void SetContorl()
        {
            this.caseInformation = fpSpread_Sheet.ActiveRow.Tag as Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo;

            this.txtNowCardNO.Text = this.caseInformation.Patient.PID.CardNO;
            this.txtFirstCardNO.Text = this.caseInformation.Patient.User01;
            this.txtRegCardNO.Text = this.caseInformation.Patient.User02;
            this.txtInHosCardNO.Text = this.caseInformation.Patient.User03;
            this.txtName.Text = this.caseInformation.Patient.Name;
            this.txtSex.Text = this.caseInformation.Patient.Sex.Name;
            this.txtBirthday.Text = this.caseInformation.Patient.Birthday.ToShortDateString();
            this.txtIDCard.Text = this.caseInformation.Patient.IDCard;
            this.txtCabinetNO.Text = this.caseInformation.Cabinet.ID;
            this.txtGridNO.Text = this.caseInformation.GridNO;
            this.cmbCaseState.Tag = this.caseInformation.CaseState.ID;
            this.cmbCaseLose.Tag = this.caseInformation.LoseState.ID;
            this.cmbInType.Tag = this.caseInformation.InType.ToString();
            this.cmbInEmployee.Tag = this.caseInformation.InEmployee.ID;
            this.cmbInDept.Tag = this.caseInformation.InDept.ID;
        }

        /// <summary>
        /// 控件清空
        /// </summary>
        private void Clear()
        {
            this.fpSpread_Sheet.ClearSelection();

            this.txtNowCardNO.Text = "";
            this.txtFirstCardNO.Text = "";
            this.txtRegCardNO.Text = "";
            this.txtInHosCardNO.Text = "";
            this.txtName.Text = "";
            this.txtSex.Text = "";
            this.txtBirthday.Text = "";
            this.txtIDCard.Text = "";
            this.txtCabinetNO.Text = "";
            this.txtGridNO.Text = "";
            this.cmbCaseState.Tag = "01";
            this.cmbCaseLose.Tag = "01";
            this.cmbInType.Tag = "01";
            this.cmbInEmployee.Tag = "";
            this.cmbInDept.Tag = "";
        }

        #endregion

    }
}

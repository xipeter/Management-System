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
    /// <summary>
    /// ucBorrowCase<br></br>
    /// [功能描述: 病案借阅]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-20]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucBorrowCase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucBorrowCase()
        {
            InitializeComponent();
        }


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
            toolBarService.AddToolButton("借阅", "借阅", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借出, true, false, null);
            toolBarService.AddToolButton("删除", "删除", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null); 
            //toolBarService.AddToolButton("添加明细", "添加明细", 2, true, false, null);
            //toolBarService.AddToolButton("删除明细", "删除明细", 3, true, false, null);
            //toolBarService.AddToolButton("保存", "保存", 6, true, false, null);
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
                case "借阅":
                    LendCase();
                    break;
                case "删除":
                    {
                        DeleteLend();
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #endregion

        #region 全局变量
        private Neusoft.HISFC.BizLogic.HealthRecord.CaseCard card = new Neusoft.HISFC.BizLogic.HealthRecord.CaseCard();
        private Neusoft.HISFC.BizLogic.HealthRecord.Base baseDml = new Neusoft.HISFC.BizLogic.HealthRecord.Base();
        private System.Data.DataTable dt = null;
        private ArrayList Caselist = null;
        //借阅卡信息 
        private Neusoft.HISFC.Models.HealthRecord.ReadCard Cardinfo = null;
        //民族
        Neusoft.FrameWork.Public.ObjectHelper NationalHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //性别
        Neusoft.FrameWork.Public.ObjectHelper SexHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //科室
        Neusoft.FrameWork.Public.ObjectHelper DeptHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        #endregion

        /// <summary>
        /// 借出
        /// </summary>
        private void LendCase()
        {
            //首先判断是否已经借出了，如果借出了没有归还则不能再外借
            //借出操作 
            ArrayList list = GetLendInfo();
            if (list == null || list.Count == 0)
            {
               // MessageBox.Show("没有信息");
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(card.Connection);
            //trans.BeginTransaction();

            card.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            foreach (Neusoft.HISFC.Models.HealthRecord.Lend obj in list)
            {
                if (obj == null)
                {
                    return;
                }
                if (ValidState(obj) == -1)
                {
                    return;
                } 
                if (card.LendCase(obj) < 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入借阅记录失败: " + card.Err);
                    return;
                }
                if (card.UpdateBase(LendType.O, obj.CaseBase.CaseNO) <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新病案主表失败");
                    return;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("借阅成功");
            this.ClearCase();
            this.ClearPerson();
            this.caseDetail.RowCount = 0;
            this.caseMain.RowCount = 0;
            this.caseNo.Focus();
        }
        private void caseNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    if (this.caseNo.Text == "")
                    {
                        this.caseNo.Focus();

                        MessageBox.Show("请输入病案号");
                        return;
                    }
                    caseNo.Text = caseNo.Text.PadLeft(10, '0');
                    Caselist = null;
                    Caselist = baseDml.QueryCaseBaseInfoByCaseNO(this.caseNo.Text);
                    if (Caselist == null)
                    {
                        this.caseNo.SelectAll();
                        MessageBox.Show("查询病案信息出错");
                        return;
                    }
                    if (Caselist.Count == 0)
                    {
                        this.caseNo.SelectAll();
                        MessageBox.Show("没有查到相关信息");
                        return;
                    }
                    //判断是否已经借出了 
                    Neusoft.HISFC.Models.HealthRecord.Base info = (Neusoft.HISFC.Models.HealthRecord.Base)Caselist[0];
                    if (info.LendStat == "O") //是字母 O 
                    {
                        this.caseNo.SelectAll();
                        MessageBox.Show("该病案已经借出.");
                        return;
                    }
                    this.AddCaseInfo(Caselist);
                    this.caseNo.SelectAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 病案基本信息
        /// </summary>
        private enum Cols
        {
            caseNO,//病案号
            strName,//姓名
            sexName,//性别
            nationName,//民族
            birthday,//生日
            birthArea,//出生地
            linkPhone,//联系电话
            linkArea//联系地址
        }
        /// <summary>
        /// 病案详细信息
        /// </summary>
        private enum DetailCos
        {
            InpatientNO, //住院流水号
            patientNO,//住院号
            caseNO,//病案号
            strName,//姓名
            deptIN, //入院科室
            dateIN,//入院日期
            DeptOut,//出院科室
            dateOut //出院日期
        }
        /// <summary>
        /// 加载病案信息
        /// </summary>
        /// <param name="Caselist"></param>
        /// <returns></returns>
        private int AddCaseInfo(ArrayList Caselist)
        {
            #region 加载病案基本信息
            Neusoft.HISFC.Models.HealthRecord.Base info = (Neusoft.HISFC.Models.HealthRecord.Base)Caselist[0]; 
            for (int i = 0; i < this.caseMain.RowCount; i++)
            {
                if (caseMain.Cells[i, (int)Cols.caseNO].Text == info.CaseNO)
                {
                    return 1;
                }
            }
            txName.Text = info.PatientInfo.Name;
            txSex.Text = SexHelper.GetName(info.PatientInfo.Sex.ID.ToString());
            this.caseMain.Rows.Add(0, 1);
            this.caseMain.Cells[0, (int)Cols.caseNO].Text = info.CaseNO;
            this.caseMain.Cells[0, (int)Cols.strName].Text = info.PatientInfo.Name; 
            if (info.PatientInfo.Sex.ID != null)
            {
                this.caseMain.Cells[0, (int)Cols.sexName].Text = SexHelper.GetName(info.PatientInfo.Sex.ID.ToString()); //性别
            }
            this.caseMain.Cells[0, (int)Cols.nationName].Text = NationalHelper.GetName(info.PatientInfo.Nationality.ID);//民族
            this.caseMain.Cells[0, (int)Cols.birthArea].Text = info.PatientInfo.AreaCode;//出生地
            this.caseMain.Cells[0, (int)Cols.birthday].Text = info.PatientInfo.Birthday.ToShortDateString(); //生日
            this.caseMain.Cells[0, (int)Cols.linkArea].Text = info.PatientInfo.Kin.RelationAddress;//联系地址
            this.caseMain.Cells[0, (int)Cols.linkPhone].Text = info.PatientInfo.Kin.RelationPhone;//联系电话
            this.caseMain.Rows[0].Tag = info;
            #endregion   
            return 1;
        } 
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(Neusoft.HISFC.Models.HealthRecord.Base info)
        { 
            if (info.PatientInfo.Sex.ID != null)
            {
                txSex.Text = SexHelper.GetName(info.PatientInfo.Sex.ID.ToString());//
            }
            caseNo.Text = info.CaseNO;
            txName.Text = info.PatientInfo.Name;
            
            txDeptIn.Text = info.InDept.Name;
            txDeptOut.Text = info.OutDept.ID;
            dtInDate.Text = info.PatientInfo.PVisit.InTime.ToString();
            dtOutDate.Text = info.PatientInfo.PVisit.OutTime.ToString();
            dtBirthDate.Text = info.PatientInfo.Birthday.ToString();
        }
        /// <summary>
        /// 清空病案信息
        /// </summary>
        private void ClearCase()
        {
            caseNo.Text = "";
            txName.Text = "";
            txSex.Text = "";
            txDeptIn.Text = "";
            txDeptOut.Text = "";
            dtInDate.Text = "";
            dtOutDate.Text = "";
            dtBirthDate.Text = "";
            if (dt != null)
            {
                dt.Clear();
            }
        }
        /// <summary>
        /// 清空人员信息
        /// </summary>
        private void ClearPerson()
        {
            CardNO.Text = "";
            comPerson.Text = "";
            //			txDays.Text = "";
            comType.Text = "";
            //txReturnTime.Value = Convert.ToDateTime("3000-1-1");
        }
        private void frmLendCard_Load(object sender, System.EventArgs e)
        {
            //InitDateTable();
            LockFp();
            Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();
            Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //获取人员列表
            ArrayList DoctorList = person.GetEmployeeAll();
            this.comPerson.AppendItems(DoctorList);
            txReturnTime.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(baseDml.GetSysDate()).AddDays(14);
            comPerson.BackColor = System.Drawing.Color.White;
            this.SexHelper.ArrayObject = Neusoft.HISFC.Models.Base.SexEnumService.List();
            ArrayList list = managerMgr.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.NATION);
            this.NationalHelper.ArrayObject = list;
        }
        private void LockFp()
        {
            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.caseMain.GrayAreaBackColor = System.Drawing.Color.White;
            this.caseDetail.GrayAreaBackColor = System.Drawing.Color.White;
            this.caseMain.Columns[(int)Cols.caseNO].CellType = txtCellType;
            this.caseMain.Columns[(int)Cols.strName].CellType = txtCellType;
            this.caseMain.Columns[(int)Cols.sexName].CellType = txtCellType;
            this.caseMain.Columns[(int)Cols.nationName].CellType = txtCellType;
            this.caseMain.Columns[(int)Cols.birthday].CellType = txtCellType;
            this.caseMain.Columns[(int)Cols.birthArea].CellType = txtCellType;
            this.caseMain.Columns[(int)Cols.linkPhone].CellType = txtCellType;
            this.caseMain.Columns[(int)Cols.linkArea].CellType = txtCellType;
            this.caseDetail.Columns[(int)DetailCos.InpatientNO].CellType = txtCellType;
            this.caseDetail.Columns[(int)DetailCos.patientNO].CellType = txtCellType;
            this.caseDetail.Columns[(int)DetailCos.caseNO].CellType = txtCellType;
            this.caseDetail.Columns[(int)DetailCos.strName].CellType = txtCellType;
            this.caseDetail.Columns[(int)DetailCos.deptIN].CellType = txtCellType;
            this.caseDetail.Columns[(int)DetailCos.dateIN].CellType = txtCellType;
            this.caseDetail.Columns[(int)DetailCos.DeptOut].CellType = txtCellType;
            this.caseDetail.Columns[(int)DetailCos.dateOut].CellType = txtCellType;
        }
        private void CardNO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.caseDetail.RowCount = 0;
                this.caseMain.RowCount = 0;
                if (CardNO.Text == "")
                {
                    CardNO.Focus();
                    MessageBox.Show("请输入卡号");
                    return;
                }
                Cardinfo = null;
                Cardinfo = card.GetCardInfo(this.CardNO.Text);
                if (Cardinfo == null)
                {
                    MessageBox.Show("查询出错");
                    return;
                }
                if (Cardinfo.CardID == null || Cardinfo.CardID == "")
                {
                    MessageBox.Show("没有查到该卡号的相关信息");
                    return;
                }
                CardNO.Text = Cardinfo.CardID;
                comPerson.Text = Cardinfo.EmployeeInfo.Name;
                comPerson.Tag = Cardinfo.EmployeeInfo.ID;
                comType.Text = "内借";
                //				this.txDays.Focus();
                this.comType.Focus();
            }
        }

        private int ValidState(Neusoft.HISFC.Models.HealthRecord.Lend obj)
        {
            if (CardNO.Text == null && CardNO.Text == "")
            {
                MessageBox.Show("请输入借阅卡号");
                return -1;
            }
            if (caseNo.Text == null && caseNo.Text == "")
            {
                MessageBox.Show("请输入借阅卡号");
                return -1;
            }
            if (comType.Text == "")
            {
                MessageBox.Show("借阅方式");
                return -1;
            }
            if (this.txReturnTime.Value <= System.DateTime.Now)
            {
                MessageBox.Show("预计归还日期不能小于当前时间");
                return -1;
            }
            return 1;
        } 
        #region 获取病案信息
        private ArrayList GetLendInfo()
        {
            ArrayList list = new ArrayList();
            if (this.caseMain.RowCount == 0)
            {
                MessageBox.Show("请选择借阅的病案信息");
                return list;
            }
            if (Cardinfo == null)
            {
                MessageBox.Show("请选择借阅的病案信息");
                return null;
            }
            if (comType.Text != "内借" && comType.Text != "外借")
            {
                MessageBox.Show("请选择借阅方式");
                return null;
            }
            if (txReturnTime.Value < System.DateTime.Now)
            {
                System.TimeSpan sp = System.DateTime.Now - txReturnTime.Value;
                if (sp.Days > 1)
                {
                    MessageBox.Show("预计归还日期不能小于当前日期");
                    return null;
                }
            }
            for (int i = 0; i < this.caseMain.RowCount; i++)
            {
                //{B6105962-245E-4106-89F2-3469B2065617}
                //Neusoft.HISFC.Models.HealthRecord.Lend Saveinfo = new Neusoft.HISFC.Models.HealthRecord.Lend();


                Neusoft.HISFC.Models.HealthRecord.Base objBase = (Neusoft.HISFC.Models.HealthRecord.Base)this.caseMain.Rows[i].Tag;

                ArrayList tempList = this.baseDml.QueryCaseBaseInfoByCaseNO(objBase.CaseNO);
                foreach (Neusoft.HISFC.Models.HealthRecord.Base tempObj in tempList)
                {
                    //{B6105962-245E-4106-89F2-3469B2065617}
                    Neusoft.HISFC.Models.HealthRecord.Lend Saveinfo = new Neusoft.HISFC.Models.HealthRecord.Lend();
                    Saveinfo.SeqNO = this.card.GetSequence("Case.CaseCard.LendCase.Seq");
                    if (Saveinfo.SeqNO == null || Saveinfo.SeqNO == "")
                    {
                        MessageBox.Show("获取序号失败");
                        return null;
                    }
                    if (tempObj.LendStat == "O") //是字母 O 
                    {
                        MessageBox.Show("该病案已经借出.");
                        return　null;
                    }
                    Saveinfo.CaseBase.CaseNO = tempObj.CaseNO;
                    Saveinfo.CaseBase.PatientInfo.ID = tempObj.PatientInfo.ID;//住院流水号
                    Saveinfo.CaseBase.CaseNO = tempObj.CaseNO;//病人住院号 
                    Saveinfo.CaseBase.PatientInfo.Name = tempObj.PatientInfo.Name; //病人姓名
                    Saveinfo.CaseBase.PatientInfo.Sex.ID = tempObj.PatientInfo.Sex.ID;//性别
                    Saveinfo.CaseBase.PatientInfo.Birthday = tempObj.PatientInfo.Birthday;//出生日期
                    Saveinfo.CaseBase.PatientInfo.PVisit.InTime = tempObj.PatientInfo.PVisit.InTime;//入院日期
                    Saveinfo.CaseBase.PatientInfo.PVisit.OutTime = tempObj.PatientInfo.PVisit.OutTime;//出院日期
                    Saveinfo.CaseBase.InDept.ID = tempObj.InDept.ID; //入院科室代码
                    Saveinfo.CaseBase.InDept.Name = tempObj.InDept.Name; //入院科室名称
                    Saveinfo.CaseBase.OutDept.ID = tempObj.OutDept.ID;  //出院科室代码
                    Saveinfo.CaseBase.OutDept.Name = tempObj.OutDept.Name; //出院科室名称
                    Saveinfo.EmployeeInfo.ID = Cardinfo.EmployeeInfo.ID;//借阅人代号
                    Saveinfo.EmployeeInfo.Name = Cardinfo.EmployeeInfo.Name;//借阅人姓名
                    Saveinfo.EmployeeDept.ID = Cardinfo.DeptInfo.ID; //借阅人所在科室代码
                    Saveinfo.EmployeeDept.Name = Cardinfo.DeptInfo.Name; //借阅人所在科室名称
                    Saveinfo.LendDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(baseDml.GetSysDate()); //借阅日期
                    Saveinfo.PrerDate = txReturnTime.Value; //预定还期
                    if (this.comType.Text == "内借")
                    {
                        Saveinfo.LendKind = "1"; ; //借阅性质
                    }
                    else if (this.comType.Text == "外借")
                    {
                        Saveinfo.LendKind = "2"; ; //借阅性质
                    }
                    Saveinfo.LendStus = "1"; ;//病历状态 1借出/2返还
                    Saveinfo.ID = baseDml.Operator.ID; //操作员代号
                    Saveinfo.OperInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(baseDml.GetSysDate()); //操作时间
                    Saveinfo.ReturnOperInfo.ID = "";   //归还操作员代号
                    Saveinfo.ReturnDate = Neusoft.FrameWork.Function.NConvert.ToDateTime("3000-1-1");   //实际归还日期
                    Saveinfo.CardNO = CardNO.Text;//卡号
                    list.Add(Saveinfo);
                }
            }
            return list;
        }
        #endregion  

        private void comType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txReturnTime.Focus();
            }
        }

        private void txReturnTime_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.caseNo.Focus();
            }
        }

        private void fpSpread2_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //this.caseDetail.RowCount = 0;
            //if (this.caseMain.Rows.Count == 0)
            //{
            //    return;
            //}
            //Neusoft.HISFC.Models.HealthRecord.Base PatientCaseInfo = (Neusoft.HISFC.Models.HealthRecord.Base)this.caseMain.Rows[this.caseMain.ActiveRowIndex].Tag;
            //SetInfo(PatientCaseInfo);
            //ArrayList tempList = this.baseDml.QueryCaseBaseInfoByCaseNO(PatientCaseInfo.CaseNO);

            //#region 加载病案明细信息
            //foreach (Neusoft.HISFC.Models.HealthRecord.Base obj in tempList)
            //{
            //    this.caseDetail.Rows.Add(0, 1);
            //    this.caseDetail.Cells[0, (int)DetailCos.InpatientNO].Text = obj.PatientInfo.ID;//住院流水号
            //    this.caseDetail.Cells[0, (int)DetailCos.patientNO].Text = obj.PatientInfo.PID.PatientNO;//住院号
            //    this.caseDetail.Cells[0, (int)DetailCos.caseNO].Text = obj.CaseNO;//病案号
            //    this.caseDetail.Cells[0, (int)DetailCos.strName].Text = obj.PatientInfo.Name;
            //    this.caseDetail.Cells[0, (int)DetailCos.deptIN].Text = obj.InDept.Name;//入院科室
            //    this.caseDetail.Cells[0, (int)DetailCos.dateIN].Text = obj.PatientInfo.PVisit.InTime.ToShortDateString();//入院日期
            //    this.caseDetail.Cells[0, (int)DetailCos.DeptOut].Text = obj.OutDept.Name;//出院科室
            //    this.caseDetail.Cells[0, (int)DetailCos.dateOut].Text = obj.PatientInfo.PVisit.OutTime.ToShortDateString();//出院日期
            //    this.caseDetail.Rows[0].Tag = obj;
            //}
            //#endregion 

            //this.tabControl1.SelectedIndex = 1;
        }

        private void caseNo_Enter(object sender, EventArgs e)
        {
            this.caseNo.SelectAll();
        }

        private void CardNO_Enter(object sender, EventArgs e)
        {
            this.caseNo.SelectAll();
        }

        private void fpSpread2_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.caseDetail.RowCount = 0;
            if (this.caseMain.Rows.Count == 0)
            {
                return;
            }
            Neusoft.HISFC.Models.HealthRecord.Base PatientCaseInfo = (Neusoft.HISFC.Models.HealthRecord.Base)this.caseMain.Rows[this.caseMain.ActiveRowIndex].Tag;
            SetInfo(PatientCaseInfo);
            ArrayList tempList = this.baseDml.QueryCaseBaseInfoByCaseNO(PatientCaseInfo.CaseNO);

            #region 加载病案明细信息
            foreach (Neusoft.HISFC.Models.HealthRecord.Base obj in tempList)
            {
                this.caseDetail.Rows.Add(0, 1);
                this.caseDetail.Cells[0, (int)DetailCos.InpatientNO].Text = obj.PatientInfo.ID;//住院流水号
                this.caseDetail.Cells[0, (int)DetailCos.patientNO].Text = obj.PatientInfo.PID.PatientNO;//住院号
                this.caseDetail.Cells[0, (int)DetailCos.caseNO].Text = obj.CaseNO;//病案号
                this.caseDetail.Cells[0, (int)DetailCos.strName].Text = obj.PatientInfo.Name;
                this.caseDetail.Cells[0, (int)DetailCos.deptIN].Text = obj.InDept.Name;//入院科室
                this.caseDetail.Cells[0, (int)DetailCos.dateIN].Text = obj.PatientInfo.PVisit.InTime.ToShortDateString();//入院日期
                this.caseDetail.Cells[0, (int)DetailCos.DeptOut].Text = obj.OutDept.Name;//出院科室
                this.caseDetail.Cells[0, (int)DetailCos.dateOut].Text = obj.PatientInfo.PVisit.OutTime.ToShortDateString();//出院日期
                this.caseDetail.Rows[0].Tag = obj;
            }
            #endregion

            this.tabControl1.SelectedIndex = 1;
        }

        private void DeleteLend()
        {
            if (this.caseMain.Rows.Count > 0)
            {
                this.caseMain.Rows.Remove(this.caseMain.ActiveRowIndex, 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
    public partial class ucChildBirthRecord : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucChildBirthRecord()
        {
            InitializeComponent();
        }

        #region 变量

        Neusoft.FrameWork.Public.ObjectHelper objSex = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper womenKind = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper familyPlanning = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper breakLevel = new Neusoft.FrameWork.Public.ObjectHelper();

        Neusoft.HISFC.BizProcess.Integrate.Manager constant = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.HISFC.BizLogic.HealthRecord.ChildbirthRecord record = new Neusoft.HISFC.BizLogic.HealthRecord.ChildbirthRecord();

        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return patientInfo;
            }
            set
            {
                this.patientInfo = value;
                Init();
                this.SetpatientInfo(patientInfo);
                QueryData();
                
            }
        }


        #endregion

        #region 方法


        protected void Init()
        {
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            //生成性别下拉列表
            FarPoint.Win.Spread.CellType.ComboBoxCellType celType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            objSex.ArrayObject = Neusoft.HISFC.Models.Base.SexEnumService.List();
            string[] str = new string[objSex.ArrayObject.Count];
            for (int i = 0; i < objSex.ArrayObject.Count; i++)
            {
                str[i] = this.objSex.ArrayObject[i].ToString();
            }
            celType.Items = str;
            this.neuSpread1_Sheet1.Columns[7].CellType = celType;

            //生成计划生育下拉列表

            FarPoint.Win.Spread.CellType.ComboBoxCellType celType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.familyPlanning.ArrayObject = this.constant.GetConstantList("FAMILYPLANNING");
            string[] str1 = new string[this.familyPlanning.ArrayObject.Count];
            for (int i = 0; i < this.familyPlanning.ArrayObject.Count; i++)
            {
                str1[i] = this.familyPlanning.ArrayObject[i].ToString();
            }
            celType1.Items = str1;
            this.neuSpread1_Sheet1.Columns[2].CellType = celType1;

            //生成产妇类型下拉列表

            FarPoint.Win.Spread.CellType.ComboBoxCellType celType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.womenKind.ArrayObject = this.constant.GetConstantList("WOMENKIND");
            string[] str2 = new string[this.womenKind.ArrayObject.Count];
            for (int i = 0; i < this.womenKind.ArrayObject.Count; i++)
            {
                str2[i] = this.womenKind.ArrayObject[i].ToString();
            }
            celType2.Items = str2;
            this.neuSpread1_Sheet1.Columns[4].CellType = celType2;

            //生成破裂程度下拉列表

            FarPoint.Win.Spread.CellType.ComboBoxCellType celType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.breakLevel.ArrayObject = this.constant.GetConstantList("BREAKLEVEL");
            string[] str3 = new string[this.breakLevel.ArrayObject.Count];
            for (int i = 0; i < this.breakLevel.ArrayObject.Count; i++)
            {
                str3[i] = this.breakLevel.ArrayObject[i].ToString();
            }
            celType3.Items = str3;
            this.neuSpread1_Sheet1.Columns[6].CellType = celType3;
        }

        /// <summary>
        /// 界面显示基本信息
        /// </summary>
        /// <param name="patientInfo">患者信息实体</param>
        protected virtual void SetpatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            this.txtName.Text = patientInfo.Name;
            this.txtDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
            this.txtNurseStation.Text = patientInfo.PVisit.PatientLocation.NurseCell.Name;
            this.txtDoctor.Text = patientInfo.PVisit.AdmittingDoctor.Name;
            this.txtBirthday.Text = patientInfo.Birthday.ToShortDateString();
            this.txtBedNo.Text = patientInfo.PVisit.PatientLocation.Bed.ID;
            this.txtDateIn.Text = patientInfo.PVisit.InTime.ToShortDateString();
            this.txtPact.Text = patientInfo.Pact.Name;
            this.ucQueryInpatientNo1.Text = this.patientInfo.ID.Substring(4,10);
        }
        /// <summary>
        /// 清理信息
        /// </summary>
        private void Clear()
        {
            this.ucQueryInpatientNo1.Text = "";
            this.txtName.Text = "";
            this.txtDept.Text = "";
            this.txtNurseStation.Text = "";
            this.txtDoctor.Text = "";
            this.txtBirthday.Text = "";
            this.txtBedNo.Text = "";
            this.txtDateIn.Text = "";
            this.txtPact.Text = "";
            this.neuSpread1_Sheet1.Rows.Count = 0;
        }
      /// <summary>
      /// 查询患者分娩记录
      /// </summary>
        private void QueryData()
        {
            //{6DE13BEE-0219-427b-A798-5F0309EDAA00}
            this.neuSpread1_Sheet1.RowCount = 0;

            List<Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord> alRecord = new List<Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord>();
            if (this.patientInfo.ID == "" || this.patientInfo.ID == null)
            {
                return;
            }
            alRecord = this.record.QueryChildbirthRecord(this.patientInfo.ID);
            for (int i = 0; i < alRecord.Count; i++)
            {
                //this.neuSpread1_Sheet1.Rows.Count = ;
                this.neuSpread1_Sheet1.Rows.Add(i, 1);
                this.neuSpread1_Sheet1.Cells[i, 0].Text = alRecord[i].IsNormalChildbirth ? "是" : "否";
                this.neuSpread1_Sheet1.Cells[i, 1].Text = alRecord[i].IsDystocia ? "是" : "否";
                this.neuSpread1_Sheet1.Cells[i, 2].Text = this.familyPlanning.GetName(alRecord[i].FamilyPlanning.ID);
                this.neuSpread1_Sheet1.Cells[i, 3].Text = alRecord[i].IsPerineumBreak ? "是" : "否";
                this.neuSpread1_Sheet1.Cells[i, 4].Text = this.womenKind.GetName(alRecord[i].WomenKind.ID);
                this.neuSpread1_Sheet1.Cells[i, 5].Text = alRecord[i].IsBreak ? "是" : "否";
                this.neuSpread1_Sheet1.Cells[i, 6].Text = this.breakLevel.GetName(alRecord[i].BreakLevel.ID);
                this.neuSpread1_Sheet1.Cells[i, 7].Text = this.objSex.GetName(alRecord[i].BabySex.ToString());
                this.neuSpread1_Sheet1.Cells[i, 8].Value = alRecord[i].BabyWeight;
            }
        }

        /// <summary>
        /// 增加分娩记录
        /// </summary>
        private void AddRow()
        {
            if (this.patientInfo.ID == "" || this.patientInfo.ID ==null )
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请输入正确的住院号，按回车键确认后再增加！"));
                return;
            }
            int rowCount = this.neuSpread1_Sheet1.Rows.Count;
            this.neuSpread1_Sheet1.Rows.Add(rowCount, 1);
            //{EFDD586D-A0B1-4bbf-85D1-641247533CDF}
            this.neuSpread1_Sheet1.ActiveRowIndex = rowCount;
        }

        /// <summary>
        /// 删除行
        /// </summary>
        private void DeleteRow()
        {
            if (this.neuSpread1_Sheet1.RowCount > 0 && this.neuSpread1_Sheet1.ActiveRowIndex >= 0)
            {
                this.neuSpread1.ActiveSheet.Rows.Remove(this.neuSpread1.ActiveSheet.ActiveRowIndex, 1);
                return;
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveData()
        {
            if (this.patientInfo.ID == "" || this.patientInfo.ID == null)
            {
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.record.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                //清除原来数据
                if (this.record.DeleteAllByInpatientNO(this.patientInfo.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this, "数据保存出错！" + this.record.Err, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //装入新数据
                Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord obj = new Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord();
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {

                    obj.Patient = this.patientInfo;
                    obj.IsNormalChildbirth = this.neuSpread1_Sheet1.Cells[i, 0].Text == "是" ? true : false;
                    obj.IsDystocia = this.neuSpread1_Sheet1.Cells[i, 1].Text == "是" ? true : false;
                    obj.FamilyPlanning.ID = this.familyPlanning.GetID(this.neuSpread1_Sheet1.Cells[i, 2].Text.ToString());
                    obj.IsPerineumBreak = this.neuSpread1_Sheet1.Cells[i, 3].Text == "是" ? true : false;
                    obj.WomenKind.ID = this.womenKind.GetID(this.neuSpread1_Sheet1.Cells[i, 4].Text.ToString());
                    obj.IsBreak = this.neuSpread1_Sheet1.Cells[i, 5].Text == "是" ? true : false;
                    obj.BreakLevel.ID = this.breakLevel.GetID(this.neuSpread1_Sheet1.Cells[i, 6].Text.ToString());

                    if (this.neuSpread1_Sheet1.Cells[i, 7].Value != null )
                    {
                        switch (this.neuSpread1_Sheet1.Cells[i, 7].Value.ToString())
                        {
                            //{0E9F748A-DE93-4642-9A4F-075DE33CCEF6}

                            //case "A":
                            //    obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.A;
                            //    break;
                            //case "F":
                            //    obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.F;
                            //    break;
                            //case "M":
                            //    obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.M;
                            //    break;
                            //case "O":
                            //    obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.O;
                            //    break;
                            //case "U":
                            //    obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.U;
                            //    break;
                            //case "全部":
                            //    obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.A;
                            //    break;
                            case "女":
                                obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.F;
                                break;
                            case "男":
                                obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.M;
                                break;
                            //case "其他":
                            //    obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.O;
                                break;
                            case "未知":
                                obj.BabySex = Neusoft.HISFC.Models.Base.EnumSex.U;
                                break;
                        }
                    }
                    obj.BabyWeight = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 8].Value);



                    //数据更新
                    if (this.record.Insert(obj) != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        if (this.record.DBErrCode == 1)
                        {
                            this.neuSpread1_Sheet1.ActiveRowIndex = i;
                            MessageBox.Show("数据重复,已有相同的记录存在.请维护不同的记录.", "保存提示");
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.ActiveRowIndex = i;
                            MessageBox.Show(this, "数据保存出错！" + this.record.Err, "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message);
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功！");

        }

        #endregion

        #region 事件
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucChildBirthRecord_Load(object sender, EventArgs e)
        {
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            //生成性别下拉列表
            FarPoint.Win.Spread.CellType.ComboBoxCellType celType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            objSex.ArrayObject = Neusoft.HISFC.Models.Base.SexEnumService.List();
            string[] str = new string[objSex.ArrayObject.Count];
            for (int i = 0; i < objSex.ArrayObject.Count; i++)
            {
                str[i] = this.objSex.ArrayObject[i].ToString();
            }
            celType.Items = str;
            this.neuSpread1_Sheet1.Columns[7].CellType = celType;

            //生成计划生育下拉列表
            
            FarPoint.Win.Spread.CellType.ComboBoxCellType celType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.familyPlanning.ArrayObject = this.constant.GetConstantList("FAMILYPLANNING");
            string[] str1 = new string[this.familyPlanning.ArrayObject.Count];
            for (int i = 0; i < this.familyPlanning.ArrayObject.Count; i++)
            {
                str1[i] = this.familyPlanning.ArrayObject[i].ToString();
            }
            celType1.Items = str1;
            this.neuSpread1_Sheet1.Columns[2].CellType = celType1;

            //生成产妇类型下拉列表

            FarPoint.Win.Spread.CellType.ComboBoxCellType celType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.womenKind.ArrayObject = this.constant.GetConstantList("WOMENKIND");
            string[] str2 = new string[this.womenKind.ArrayObject.Count];
            for (int i = 0; i < this.womenKind.ArrayObject.Count; i++)
            {
                str2[i] = this.womenKind.ArrayObject[i].ToString();
            }
            celType2.Items = str2;
            this.neuSpread1_Sheet1.Columns[4].CellType = celType2;

            //生成破裂程度下拉列表

            FarPoint.Win.Spread.CellType.ComboBoxCellType celType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.breakLevel.ArrayObject = this.constant.GetConstantList("BREAKLEVEL");
            string[] str3 = new string[this.breakLevel.ArrayObject.Count];
            for (int i = 0; i < this.breakLevel.ArrayObject.Count; i++)
            {
                str3[i] = this.breakLevel.ArrayObject[i].ToString();
            }
            celType3.Items = str3;
            this.neuSpread1_Sheet1.Columns[6].CellType = celType3;
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            this.Clear();
            if (this.ucQueryInpatientNo1.InpatientNo == null || this.ucQueryInpatientNo1.InpatientNo.Trim() == "")
            {
                if (this.ucQueryInpatientNo1.Err == "")
                {
                    this.ucQueryInpatientNo1.Err = "此患者不在院";
                }
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.ucQueryInpatientNo1.Err, 211);

                this.ucQueryInpatientNo1.Focus();
                return;
            }
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo1.InpatientNo);
            //界面显示基本信息
            this.SetpatientInfo(this.patientInfo);
            //显示分娩情况
            this.QueryData();
        }

        #endregion 

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            //增加工具栏
            this.toolBarService.AddToolButton("增加", "增加", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            this.toolBarService.AddToolButton("删除", "删除", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            return this.toolBarService;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveData();
            return base.OnSave(sender, neuObject);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryData();
            return base.OnQuery(sender, neuObject);
        }

        /// <summary>
        /// 工具栏按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.AddRow();
                    break;
                case "删除":
                    this.DeleteRow();
                    break;
            }

        }

        #endregion

        private void neuButton1_Click(object sender, EventArgs e)
        {
            SaveData();
            this.FindForm().Close();
            
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            this.AddRow();
        }

        private void neuButton3_Click(object sender, EventArgs e)
        {
            this.DeleteRow();
        }

   



    }
}

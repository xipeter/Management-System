using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Balance
{
    public partial class ucChangePact : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 变量
        /// <summary>
        /// 入出转integrate层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        /// <summary>
        /// 住院患者信息实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        /// <summary>
        /// 更新后的实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo oENewPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        /// <summary>
        /// 住院患者费用业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.InPatient InpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        /// <summary>
        /// 
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 合同单位
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.PactUnitInfo myPactUnit = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();
        /// <summary>
        /// 费用中间层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        ///待遇接口类
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();

         
        

        DataTable dtDrug = new DataTable();
        DataTable dtUndrug = new DataTable();
       

        #endregion
        public ucChangePact()
        {
            InitializeComponent();
        }
        #region 方法
        /// <summary>
        /// 初始化

        /// </summary>
        protected virtual void Init()
        {
            //初始化合同单位

            this.InitPact();
            //
            this.initFPdrug();
            this.initFPUndrug();
 
        }
        /// <summary>
        /// 初始化药品

        /// </summary>
        protected virtual void initFPdrug()
        {
            this.dtDrug.Columns.AddRange(new DataColumn[]{
            new DataColumn("药品名称"),
            new DataColumn("规格"),
            new DataColumn("价格"),
            new DataColumn("单位"),
            new DataColumn("数量"),
            new DataColumn("金额"),
            new DataColumn("自费金额"),
            new DataColumn("自费比例"),
            new DataColumn("自付金额"),
            new DataColumn("自负比例"),
            new DataColumn("记帐金额"),
            new DataColumn("记帐日期")});
            this.fpDrug_Sheet1.DataSource = this.dtDrug;
            FarPoint.Win.Spread.CellType.NumberCellType numtype = new FarPoint.Win.Spread.CellType.NumberCellType();
            numtype.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
          
            this.fpDrug_Sheet1.Columns[0].Width = 200;
            this.fpDrug_Sheet1.Columns[2].Width = 100;
            this.fpDrug_Sheet1.Columns[3].Width = 100;
            this.fpDrug_Sheet1.Columns[4].Width = 100;
            this.fpDrug_Sheet1.Columns[5].Width = 100;
            this.fpDrug_Sheet1.Columns[6].Width = 100;
            this.fpDrug_Sheet1.Columns[7].Width = 100;
            this.fpDrug_Sheet1.Columns[8].Width = 100;
            this.fpDrug_Sheet1.Columns[9].Width = 100;
            this.fpDrug_Sheet1.Columns[10].Width = 100;

             
            this.fpDrug_Sheet1.Columns[2].CellType = numtype;
            this.fpDrug_Sheet1.Columns[4].CellType = numtype;
            this.fpDrug_Sheet1.Columns[5].CellType = numtype;
            this.fpDrug_Sheet1.Columns[6].CellType = numtype;
            this.fpDrug_Sheet1.Columns[7].CellType = numtype;
            this.fpDrug_Sheet1.Columns[8].CellType = numtype;
            this.fpDrug_Sheet1.Columns[9].CellType = numtype;
            this.fpDrug_Sheet1.Columns[10].CellType = numtype;


        }
        /// <summary>
        /// 初始化非药品
        /// </summary>
        protected virtual void initFPUndrug()
        {
            this.dtUndrug .Columns.AddRange(new DataColumn[]{
            new DataColumn("项目名称"),
            new DataColumn ("价格"),
            new DataColumn("数量"),
            new DataColumn ("单位"),
            new DataColumn ("金额"),
            new DataColumn ("自费金额"),
            new DataColumn ("自费比例"),
            new DataColumn ("自付金额"),
            new DataColumn("自负比例"),
            new DataColumn("记帐金额"),
            new DataColumn("记帐日期")});

            this.fpUndrug_Sheet1.DataSource = this.dtUndrug;
            this.fpUndrug_Sheet1.Columns[0].Width = 200;
            this.fpUndrug_Sheet1.Columns[1].Width = 100;
            this.fpUndrug_Sheet1.Columns[2].Width = 100;
            this.fpUndrug_Sheet1.Columns[3].Width = 100;
            this.fpUndrug_Sheet1.Columns[4].Width = 100;
            this.fpUndrug_Sheet1.Columns[5].Width = 100;
            this.fpUndrug_Sheet1.Columns[6].Width = 100;
            this.fpUndrug_Sheet1.Columns[7].Width = 100;
            this.fpUndrug_Sheet1.Columns[8].Width = 100;
            this.fpUndrug_Sheet1.Columns[9].Width = 100; 
            FarPoint.Win.Spread.CellType.NumberCellType numtype = new FarPoint.Win.Spread.CellType.NumberCellType ();
            numtype.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.fpUndrug_Sheet1.Columns[1].CellType = numtype;
            this.fpUndrug_Sheet1.Columns[2].CellType = numtype;
            this.fpUndrug_Sheet1.Columns[4].CellType = numtype;
            this.fpUndrug_Sheet1.Columns[5].CellType = numtype;
            this.fpUndrug_Sheet1.Columns[6].CellType = numtype;
            this.fpUndrug_Sheet1.Columns[7].CellType = numtype;
            this.fpUndrug_Sheet1.Columns[8].CellType = numtype;
            this.fpUndrug_Sheet1.Columns[9].CellType = numtype;

  
        }
        /// <summary>
        /// 初始化合同单位

        /// </summary>
        /// <returns></returns>
        private void InitPact()
        {
            ArrayList al = new ArrayList();
            //al = this.managerIntegrate.GetConstantList("PACTUNIT");
            //{4FC828DD-F685-4381-803F-01C97FE0E7EA}
            al = this.managerIntegrate.QueryPactUnitAll();
            if (al.Count > 0)
            {
                this.cmbNewPact.AddItems(al);
            } 
        }
        /// <summary>
        /// 界面显示基本信息
        /// </summary>
        /// <param name="patientInfo">患者信息实体</param>
        protected virtual void SetpatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            this.txtName.Text = patientInfo.Name;
            this.txtOldPact.Text = patientInfo.Pact.Name;
            this.txtOldPact.Tag = patientInfo.Pact.ID;
            this.txtDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
            this.txtNurseStation.Text = patientInfo.PVisit.PatientLocation.NurseCell.Name;
            this.txtDoctor.Text = patientInfo.PVisit.AdmittingDoctor.Name;
            this.txtBirthday.Text = patientInfo.Birthday.ToShortDateString();
            this.txtBedNo.Text = patientInfo.PVisit.PatientLocation.Bed.ID;
            this.txtDateIn.Text = patientInfo.PVisit.InTime.ToShortDateString();
            this.txtPact.Text = patientInfo.Pact.Name;
        }
        /// <summary>
        /// 显示费用信息
        /// </summary>
        /// <returns></returns>
        protected virtual int DisplayDetail(string inpatientNO)
        {
            if (fpDrug_Sheet1.Rows.Count > 0)
            {
                this.fpDrug_Sheet1.RemoveRows(0, this.fpDrug_Sheet1.RowCount);
            }
            if (this.fpUndrug_Sheet1.Rows.Count > 0)
            {
                this.fpUndrug_Sheet1.RemoveRows(0, this.fpUndrug_Sheet1.RowCount);
            }
            //药品信息
            if (this.DisplayDrugDetail(inpatientNO) < 0)
            {
                return -1;
            }
            //非药品信息

            if (this.DisplayUndrugDetail(inpatientNO) < 0)
            {
                return -1;
            }

            
            return 1;
        }
        /// <summary>
        /// 显示费用品信息

        /// </summary>
        /// <returns></returns>
        protected virtual int DisplayDrugDetail(string inpatientNO)
        {
            DateTime fromDate = Neusoft.FrameWork.Function.NConvert.ToDateTime("1900-01-01");
            DateTime endDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.InpatientManager.GetSysDateTime());
            ArrayList alDrung = new ArrayList();
            Neusoft.HISFC.Models.Fee.MedItemList medicineList = new Neusoft.HISFC.Models.Fee.MedItemList();
            //批费
            alDrung = this.InpatientManager.QueryMedItemListsCanQuit(inpatientNO, fromDate, endDate, "1,2", false);
            if (alDrung.Count > 0)
            {
                for (int i = 0; i < alDrung.Count; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList medcineList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    medcineList = (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)alDrung[i];
                    this.fpDrug_Sheet1.Rows.Add(this.fpDrug_Sheet1.RowCount, 1);

                    this.fpDrug_Sheet1.Cells[i, 0].Value = medcineList.Item.Name;
                    this.fpDrug_Sheet1.Cells[i, 1].Value = medcineList.Item.Specs;
                    this.fpDrug_Sheet1.Cells[i, 2].Value = medcineList.Item.Price;
                    this.fpDrug_Sheet1.Cells[i, 3].Value = medcineList.Item.PriceUnit;
                    this.fpDrug_Sheet1.Cells[i, 4].Value = medcineList.Item.Qty;
                    this.fpDrug_Sheet1.Cells[i, 5].Value = medcineList.FT.TotCost;
                    this.fpDrug_Sheet1.Cells[i, 6].Value = medcineList.FT.OwnCost;
                    this.fpDrug_Sheet1.Cells[i, 7].Value = Neusoft.FrameWork.Public.String.FormatNumberReturnString(medcineList.FT.OwnCost / medcineList.FT.TotCost, 2);
                    this.fpDrug_Sheet1.Cells[i, 8].Value = medcineList.FT.PayCost;
                    this.fpDrug_Sheet1.Cells[i, 9].Value = Neusoft.FrameWork.Public.String.FormatNumberReturnString(medcineList.FT.PayCost / medcineList.FT.TotCost, 2);
                    this.fpDrug_Sheet1.Cells[i, 10].Value = medcineList.FT.PubCost;
                    this.fpDrug_Sheet1.Cells[i, 11].Value = medcineList.FeeOper.OperTime;
                    this.fpDrug_Sheet1.Rows[i].Tag = medcineList;

                }
            }
            
            return 1;
        }
        /// <summary>
        /// 非药品收费明细

        /// </summary>
        /// <returns></returns>
        protected virtual int DisplayUndrugDetail(string inpatientNO)
        {
            DateTime fromDate = Neusoft.FrameWork.Function.NConvert.ToDateTime("1900-01-01");
            DateTime endDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.InpatientManager.GetSysDateTime());
            ArrayList alUnDrung = new ArrayList();
           
            alUnDrung = this.InpatientManager.QueryFeeItemListsCanQuit(inpatientNO, fromDate, endDate, false);
            if (alUnDrung.Count > 0)
            {
                for (int i = 0; i < alUnDrung.Count; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList undrugItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();

                    undrugItem = (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)alUnDrung[i];
                    this.fpUndrug_Sheet1.AddRows(this.fpUndrug_Sheet1.RowCount, 1);
                    this.fpUndrug_Sheet1.Cells[i, 0].Text = undrugItem.Item.Name;
                    this.fpUndrug_Sheet1.Cells[i, 1].Value = undrugItem.Item.Price;
                    this.fpUndrug_Sheet1.Cells[i, 3].Value = undrugItem.Item.PriceUnit;
                    this.fpUndrug_Sheet1.Cells[i, 2].Value = undrugItem.Item.Qty;
                    this.fpUndrug_Sheet1.Cells[i, 4].Value = undrugItem.FT.TotCost;
                    this.fpUndrug_Sheet1.Cells[i, 5].Value = undrugItem.FT.OwnCost;
                    this.fpUndrug_Sheet1.Cells[i, 6].Value = Neusoft.FrameWork.Public.String.FormatNumberReturnString(undrugItem.FT.OwnCost / undrugItem.FT.TotCost, 2);
                    this.fpUndrug_Sheet1.Cells[i, 7].Value = undrugItem.FT.PayCost;
                    this.fpUndrug_Sheet1.Cells[i, 8].Value = Neusoft.FrameWork.Public.String.FormatNumberReturnString(undrugItem.FT.PayCost / undrugItem.FT.TotCost, 2);
                    this.fpUndrug_Sheet1.Cells[i, 9].Value = undrugItem.FT.PubCost;
                    this.fpUndrug_Sheet1.Cells[i,10].Value = undrugItem.FeeOper.OperTime;
                    this.fpUndrug_Sheet1.Rows[i].Tag = undrugItem;

                }

            }
            return 1;
        }
        /// <summary>
        /// 清屏
        /// </summary>
        protected virtual void Clear()
        {
            this.patientInfo = null;
            if (fpDrug_Sheet1.Rows.Count >0 )
            {
                this.fpDrug_Sheet1.RemoveRows(0, this.fpDrug_Sheet1.RowCount);
            }
            if (this.fpUndrug_Sheet1.Rows.Count > 0)
            {
                this.fpUndrug_Sheet1.RemoveRows(0, this.fpUndrug_Sheet1.RowCount);
            }
            this.txtDept.Text = "";
            this.txtDoctor.Text = "";
            this.txtName.Text = "";
            this.txtNurseStation.Text = "";
            this.txtOldPact.Text = "";
            this.cmbNewPact.Text = "";
            this.txtBirthday.Text = "";
            this.txtDateIn.Text = "";
            this.txtBedNo.Text = "";
            this.txtPact.Text = "";
            this.ucQueryInpatientNo1.Focus();

        }
        /// <summary>
        /// 校验
        /// </summary>
        /// <returns></returns>
        protected int IsValid()
        {

            if (this.patientInfo == null || string.IsNullOrEmpty(this.patientInfo.ID)) 
            {
                MessageBox.Show("没有患者基本信息，请正确输入住院号并回车确认!");

                return -1;
            }
            
            //判断合同单位
            if (this.cmbNewPact.SelectedIndex < 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择合同单位"));
                return -1;
            }
            if (this.cmbNewPact.SelectedItem.ID == this.txtOldPact.Tag.ToString())
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("新合同单位与原合同单位相同，请重新选择"));
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 根据合同单位标示返回支付类别名称
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        private Neusoft.FrameWork.Models.NeuObject GetPactUnitByID(string strID)
        {
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.HISFC.Models.Base.PactInfo p = new Neusoft.HISFC.Models.Base.PactInfo();
            p = this.myPactUnit.GetPactUnitInfoByPactCode(strID);
            if (p == null)
            {
                MessageBox.Show("检索合同单位出错" + this.myPactUnit.Err, "提示");
                return null;
            }
            if (p.PayKind.ID == "" || p.PayKind == null)
            {
                MessageBox.Show("该合同单位的结算类别没有维护", "提示");
                return null;
            }
            else
            {
                switch (p.PayKind.ID)
                {
                    case "01":
                        obj.Name = "自费"; obj.ID = "01";
                        break;
                    case "02":
                        obj.Name = "保险";
                        obj.ID = "02";
                        break;
                    case "03":
                        obj.Name = "公费在职";
                        obj.ID = "03";
                        break;
                    case "04":
                        obj.Name = "公费退休";
                        obj.ID = "04";
                        break;
                    case "05":
                        obj.Name = "公费高干";
                        obj.ID = "05";
                        break;
                    default:
                        break;
                }
            }
            return obj;
        }
        /// <summary>
        /// 身份变更确认操作
        /// </summary>
        /// <returns></returns>
        protected virtual int ChangePact()
        {
            if (this.IsValid() < 0)
            {
                return -1;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在处理明细数据……");
            Application.DoEvents();
            Neusoft.FrameWork.Models.NeuObject newObj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject oldObj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            //备份收费药品信息
            ArrayList alDruglistBackUp = new ArrayList();
            //备份收费药品信息
            ArrayList alUndruglistBackUp = new ArrayList();
            obj = this.GetPactUnitByID(this.cmbNewPact.SelectedItem.ID);

            this.medcareInterfaceProxy.SetPactCode(this.cmbNewPact.SelectedItem.ID);
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            pharmacyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            this.InpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.myPactUnit.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            newObj.ID = this.cmbNewPact.SelectedItem.ID;	//1 合同单位代码
            newObj.Name = this.cmbNewPact.SelectedItem.Name;		//2 合同单位名称
            newObj.User01 = obj.ID;		//3 结算类别代码
            newObj.User02 = obj.Name;		//4 结算类别名称
            newObj.User03 = this.patientInfo.SSN; //医疗证号

            oldObj.ID = this.txtOldPact.Tag.ToString();
            oldObj.Name = this.txtOldPact.Text;


            #region 退费

            #region 处理非药品


            //处理非药品 
            if (this.fpUndrug_Sheet1.RowCount > 0)
            {
                for (int i = 0; i < fpUndrug_Sheet1.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList undrugItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList oldUndrugItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    if (this.fpUndrug_Sheet1.Rows[i].Tag != null)
                    {
                        undrugItem = (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)this.fpUndrug_Sheet1.Rows[i].Tag;
                        oldUndrugItem = undrugItem.Clone();
                        undrugItem.ExtFlag2 = "3";//变更标志 
                        //退费


                        undrugItem.IsNeedUpdateNoBackQty = true;
                        if (this.feeIntegrate.QuitItem(this.patientInfo, undrugItem) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("调用中间层出错" + this.feeIntegrate.Err);
                            this.Clear();
                            return -1;
                        }


                        //收费
                        oldUndrugItem.RecipeNO = this.InpatientManager.GetUndrugRecipeNO();
                        oldUndrugItem.Patient.Pact.ID = this.cmbNewPact.SelectedItem.ID;
                        oldUndrugItem.FeeOper.ID = this.InpatientManager.Operator.ID;
                        oldUndrugItem.FeeOper.OperTime = this.InpatientManager.GetDateTimeFromSysDateTime();
                        //备份非药品信息

                        alUndruglistBackUp.Add(oldUndrugItem);
                        //if (this.feeIntegrate.FeeItem(this.oENewPatientInfo, oldUndrugItem) == -1)
                        //{
                        //    t.RollBack();
                        //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        //    MessageBox.Show("调用中间层出错" + this.feeIntegrate.Err);
                        //    this.Clear();
                        //    return -1;
                        //}
                    }
                    else
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("调用中间层出错" + this.feeIntegrate.Err);
                        this.Clear();
                        return -1;
                    }
                }


            }
            #endregion

            #region 处理药品
            //处理药品
            if (this.fpDrug_Sheet1.RowCount > 0)
            {
                for (int i = 0; i < fpDrug_Sheet1.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList medicineItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList oldMedicineItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    if (this.fpDrug_Sheet1.Rows[i].Tag != null)
                    {
                        medicineItem = (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)this.fpDrug_Sheet1.Rows[i].Tag;
                        oldMedicineItem = medicineItem.Clone();
                        medicineItem.ExtFlag2 = "3";//变更标志 
                        //退费
                        ////这里是否更改成未摆药的更新发药申请的记录addbyhuazb
                        //if (string.IsNullOrEmpty(medicineItem.ExecOper.ID))
                        //{
                        //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        //    MessageBox.Show("保存出错出错" + "该患者有药未摆，请通知药房摆药以后再进行变更！");
                        //    this.Clear();
                        //    return -1;
                        //}



                        medicineItem.IsNeedUpdateNoBackQty = true;
                        if (this.feeIntegrate.QuitItem(this.patientInfo, medicineItem) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("调用中间层出错" + this.feeIntegrate.Err);
                            this.Clear();
                            return -1;
                        }


                        //收费
                        //存储旧处方号
                        oldMedicineItem.BalanceOper.User01 = oldMedicineItem.RecipeNO;

                        oldMedicineItem.RecipeNO = this.InpatientManager.GetDrugRecipeNO();
                        oldMedicineItem.Patient.Pact.ID = this.cmbNewPact.SelectedItem.ID;
                        oldMedicineItem.FeeOper.ID = this.InpatientManager.Operator.ID;
                        oldMedicineItem.FeeOper.OperTime = this.InpatientManager.GetDateTimeFromSysDateTime();
                        //备份药品信息
                        alDruglistBackUp.Add(oldMedicineItem);
                        //if (this.feeIntegrate.FeeItem(this.oENewPatientInfo, oldMedicineItem) == -1)
                        //{
                        //    t.RollBack();
                        //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        //    MessageBox.Show("调用中间层出错" + this.feeIntegrate.Err);
                        //    this.Clear();
                        //    return -1;
                        //}
                    }
                    else
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("调用中间层出错" + this.feeIntegrate.Err);
                        this.Clear();
                        return -1;
                    }
                }


            }
            #endregion
            #endregion

            
            if (this.radtIntegrate.SetPactShiftData(this.patientInfo, newObj, oldObj) != 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("调用中间层出错");
                this.Clear();
                return -1;
            }
            //获得更改后得患者信息



            this.oENewPatientInfo = this.radtIntegrate.GetPatientInfomation(this.patientInfo.ID);
            if (this.oENewPatientInfo == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("获得变更后患者信息出错!!", "提示");
                this.Clear();
                return -1;
            }

            #region 重新收费
            #region 处理非药品

            long returnValue = 0;
            this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            returnValue = this.medcareInterfaceProxy.Connect();
            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                //{0C35F3E3-2E72-4ae3-8809-FF3809DA2A16}
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("请确保待遇接口存在或正常初始化初始化失败" + this.medcareInterfaceProxy.ErrMsg);
                this.Clear();
                return -1;
            }
            returnValue = this.medcareInterfaceProxy.GetRegInfoInpatient(oENewPatientInfo);
            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                //{0C35F3E3-2E72-4ae3-8809-FF3809DA2A16}
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("待遇接口获得患者信息失败" + this.medcareInterfaceProxy.ErrMsg);
                this.Clear();
                return -1;
            }
            returnValue = this.medcareInterfaceProxy.UploadRegInfoInpatient(oENewPatientInfo);
            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                //{0C35F3E3-2E72-4ae3-8809-FF3809DA2A16}
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("待遇接口上传住院登记信息失败" + this.medcareInterfaceProxy.ErrMsg);
                this.Clear();
                return -1;
            }

            //处理非药品 
            if (alUndruglistBackUp.Count > 0)
            {
                for (int i = 0; i < alUndruglistBackUp.Count; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList oldUndrugItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    oldUndrugItem = (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)alUndruglistBackUp[i];
                    if (this.feeIntegrate.FeeItem(this.oENewPatientInfo, oldUndrugItem) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("调用中间层出错" + this.feeIntegrate.Err);
                        this.Clear();
                        return -1;
                    }
                }


            }
            #endregion

            #region 处理药品
            //处理药品
            if (alDruglistBackUp.Count > 0)
            {
                for (int i = 0; i < alDruglistBackUp.Count; i++)
                {

                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList oldMedicineItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    oldMedicineItem = (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)alDruglistBackUp[i];
                    if (oldMedicineItem != null)
                    {

                        if (this.feeIntegrate.FeeItem(this.oENewPatientInfo, oldMedicineItem.Clone()) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.medcareInterfaceProxy.Rollback();
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("调用中间层出错" + this.feeIntegrate.Err);
                            this.Clear();
                            return -1;
                        }
                        //这里收费完已经发药的senddrug_flag未更新。addbyhuazb

                        if (this.InpatientManager.UpdateMedItemExecInfo(oldMedicineItem.RecipeNO, oldMedicineItem.SequenceNO
                        , oldMedicineItem.UpdateSequence, oldMedicineItem.SendSequence,(int)oldMedicineItem.PayType, oldMedicineItem.StockOper.Dept.ID,
                        oldMedicineItem.ExecOper.ID, oldMedicineItem.ExecOper.OperTime) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.medcareInterfaceProxy.Rollback();
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("调用中间层出错" + this.feeIntegrate.Err);
                            this.Clear();
                            return -1;
                        }
                        //更新处方号
                        if (pharmacyIntegrate.UpdateApplyOutRecipe(oldMedicineItem.BalanceOper.User01, oldMedicineItem.SequenceNO, oldMedicineItem.RecipeNO, oldMedicineItem.SequenceNO) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("更新药品申请表处方号信息发生错误！" + pharmacyIntegrate.Err);
                            this.Clear();
                            return -1;
                        }
                    }

                }


            }
            #endregion
            #endregion


            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.medcareInterfaceProxy.Commit();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("变更成功"));
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //重新显示介面
            this.SetpatientInfo(this.oENewPatientInfo);
            //重新显示费用明细
            this.DisplayDetail(this.oENewPatientInfo.ID);

            return 1;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.ChangePact();
            return base.OnSave(sender, neuObject);
        }
        #endregion
        #region 事件
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
            if (this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.N.ToString() || this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.O.ToString())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院!", 111);

                this.patientInfo.ID = null;

                return;
            }
            //界面显示基本信息
            this.SetpatientInfo(this.patientInfo);
            //费用信息
            this.DisplayDetail(this.patientInfo.ID);
        }

        private void ucChangePact_Load(object sender, EventArgs e)
        {
           
            this.Init();
        }
        #endregion
    }
}
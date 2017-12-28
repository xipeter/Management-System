using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.FrameWork.Management;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// ucNurseQuitApply<br></br>
    /// [功能描述: 住院护士退费申请UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucNurseQuitApply : ucQuitFee
    {
        /// <summary>
        /// 护士站退费申请
        /// </summary>
        public ucNurseQuitApply()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 复合项目退费是否必须全退{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        protected bool isCombItemAllQuit = false;
        //{F4912030-EF65-4099-880A-8A1792A3B449}结束

        /// <summary>
        /// 复合项目退费是否必须全退{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        public bool IsCombItemAllQuit
        {
            get
            {
                return this.isCombItemAllQuit;
            }
            set
            {
                this.isCombItemAllQuit = value;
            }
        }//{F4912030-EF65-4099-880A-8A1792A3B449}结束

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            //设置不可以输入住院号
            this.IsCanInputInpatientNO = false;
            //设置保存方式为退费申请
            this.operation = Operations.Apply;

            this.itemType = ItemTypes.All;
            
            return base.OnInit(sender, neuObject, param);
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        protected override void SetPatientInfomation()
        {
            this.ucQueryPatientInfo.Text = this.patientInfo.PID.PatientNO;
            
            base.SetPatientInfomation();
        }

        /// <summary>
        /// 接收树选择的患者基本信息
        /// </summary>
        /// <param name="neuObject">患者基本信息实体</param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            base.Clear();

            base.PatientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;

            return base.OnSetValue(neuObject, e);
        }

        protected override int SaveApply()
        {
            if (base.SaveApply() == 1) 
            {
                base.ClearItemList();
                
                this.Retrive(false);
            }

            return 1;
        }

        /// <summary>
        /// 重写基类的取消退费操作,这里为取消退费申请信息
        /// </summary>
        /// <returns></returns>
        protected override int CancelQuitOperation()
        {
            if (this.fpQuit.ActiveSheet.RowCount == 0) 
            {
                return -1;
            }
            //当前选中的行
            int selectedIndex = this.fpQuit.ActiveSheet.ActiveRowIndex;

            if(this.fpQuit.ActiveSheet.Rows[selectedIndex].Tag == null)
            {
                return -1;
            }

            //获得当前选中项目
            FeeItemList feeItemList = this.fpQuit.ActiveSheet.Rows[selectedIndex].Tag as FeeItemList;

            //判断是否已经确认退费,如果退费,那么不允许取消
            if (feeItemList.Item.User01 == "1") 
            {
                MessageBox.Show(Language.Msg("该退药申请药房已做退药确认 无法撤销申请"));

                return -1;
            }
            //如果该项目是本次未提交数据库的记录,那么直接调用基类的取消操作.
            if (feeItemList.Memo != "OLD")
            {
                return base.CancelQuitOperation();
            }
            else//取消的项目为提交数据库的记录,那么需要删除数据库记录,判断并发等操作. 
            {
                //判断当前退费申请科室,是否为该条记录的退费申请科室,暂时代码没有写.至于为什么没有写,问God.

                DialogResult result = MessageBox.Show(Language.Msg("确认取消本条退费申请信息"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);

                if (result == DialogResult.No)
                {
                    return -1;
                }

                //Transaction t = new Transaction(this.inpatientManager.Connection);
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.phamarcyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.returnApplyManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //对由病区退费申请表获取得退费申请数据 判断退费申请取消并发
                if (feeItemList.User01 == "0")
                {
                    //判断数据是否已被退费确认
                    bool isStill = false;
                    ArrayList tempAl = null;

                    tempAl = this.returnApplyManager.QueryDrugReturnApplys(feeItemList.Patient.ID, false, true);

                    foreach (Neusoft.HISFC.Models.Fee.ReturnApply info in tempAl)
                    {
                        if (info.RecipeNO == feeItemList.RecipeNO && info.SequenceNO == feeItemList.SequenceNO)
                        {
                            isStill = true;

                            break;
                        }
                    }

                    if (isStill)
                    {  //数据已被确认
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("该数据已被退费确认，无法撤销申请"));

                        return -1;
                    }
                }

                //if (feeItemList.Item.IsPharmacy)
                if (feeItemList.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    //更新药品明细表中的可退数量，防止并发
                    int returnValue = this.inpatientManager.UpdateNoBackQtyForDrug(feeItemList.RecipeNO, feeItemList.SequenceNO, -feeItemList.Item.Qty, feeItemList.BalanceState);
                    if (returnValue == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("更新药品可退数量出错!") + this.inpatientManager.Err);

                        return -1;
                    }
                    else if (returnValue == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("数据发生变动!请刷新窗口"));

                        return -1;
                    }

                    //取消退药申请，并判断并发操作
                    //根据不同数据来源进行不同处理
                    //已做过发药确认 作废出库申请
                    if (feeItemList.PayType == Neusoft.HISFC.Models.Base.PayTypes.PhaConfim)
                    {
                        returnValue = this.phamarcyIntegrate.CancelApplyOut(feeItemList.RecipeNO, feeItemList.SequenceNO);
                        if (returnValue == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("取消退费申请出错!") + this.phamarcyIntegrate.Err);

                            return -1;
                        }
                        else if (returnValue == 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("数据发生变动!请刷新窗口"));

                            return -1;
                        }
                    }
                    else//没有发药确认
                    {
                        //恢复出库申请记录为有效   待添加 
                        returnValue = this.phamarcyIntegrate.UndoCancelApplyOut(feeItemList.RecipeNO, feeItemList.SequenceNO);
                        if (returnValue == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(this.phamarcyIntegrate.Err);

                            return -1;
                        }
                        else if (returnValue == 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("该数据已被取消，无法撤销申请"));

                            return -1;
                        }

                        //取消退费申请 改状态为2 删除退费申请数据
                        //绝对不会错
                        if (this.returnApplyManager.CancelReturnApply(feeItemList.User03, this.returnApplyManager.Operator.ID) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(this.returnApplyManager.Err);

                            return -1;
                        }
                    }
                }
                else
                {//更新非药品明细表中的可退数量，防止并发
                    int returnValue = this.inpatientManager.UpdateNoBackQtyForUndrug(feeItemList.RecipeNO, feeItemList.SequenceNO, -feeItemList.Item.Qty, feeItemList.BalanceState);
                    if (returnValue == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.inpatientManager.Err);

                        return -1;
                    }
                    else if (returnValue == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("数据发生变动!请刷新窗口"));

                        return -1;
                    }

                    //取消退费申请 改状态为2 删除退费申请数据
                    //绝对不会错
                    if (this.returnApplyManager.CancelReturnApply(feeItemList.User03, this.returnApplyManager.Operator.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.returnApplyManager.Err);

                        return -1;
                    }
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();

                MessageBox.Show(Language.Msg("退费申请取消成功!"));

                base.ClearItemList();

                this.Retrive(false);
            }

            return 1;
        }

        /// <summary>
        /// 查询待退费和已经申请信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected override int Retrive(bool isRetrieveReturnApply)
        {
            DateTime beginTime = this.dtpBeginTime.Value;
            DateTime endTime = this.dtpEndTime.Value;

            if (this.patientInfo == null) 
            {
                MessageBox.Show(Language.Msg("请选择要退费申请的患者"));

                return -1;
            }

            this.RetrieveReturnApplyDrug(this.patientInfo.ID, beginTime, endTime);

            this.RetrieveReturnApplyUndrug(this.patientInfo.ID, beginTime, endTime);
            
            return base.Retrive(false);
        }

        /// <summary>
        /// 读取药品退费申请信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        private void RetrieveReturnApplyDrug(string inpatientNO, DateTime beginTime, DateTime endTime)
        {

            this.fpQuit_SheetDrug.RowCount = 0;
            
            ArrayList applyReturnFromApplyOut = new ArrayList();
            ArrayList applyReturnsUnQuit = new ArrayList();//未处理的退费申请信息
            ArrayList confirmDrugList = new ArrayList();//核准药品信息
            //获取药品退费申请信息  检索有效的退药申请记录 由出库申请表获取退药申请 申请状态且有效的
            //该部分获取的对已发药的药品的退费申请 由ApplyOut内检索的状态为0(申请)的记录 
            //			al = this.drugItem.GetDrugReturn(this.PatientInfo.PVisit.PatientLocation.Dept.ID,"AAAA",this.PatientInfo.ID);
            //applyReturnFromApplyOut = this.drugItem.GetDrugReturn("AAAA", "AAAA", this.PatientInfo.ID);
            if (applyReturnFromApplyOut == null)
                return;
            //获取未发药(药房未做过退药确认)的退药申请 对此部分退费申请 保存时会直接置出库申请表内出库申请记录为无效
            //该部分获取的对未发药的药品的退费申请 由CancelItem内检索得出 
            //获取该患者未确认 未发药的退费申请记录
            applyReturnsUnQuit = this.returnApplyManager.QueryDrugReturnApplys(this.patientInfo.ID, false, false);
            if (applyReturnsUnQuit != null)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = null;
                foreach (Neusoft.HISFC.Models.Fee.ReturnApply applyReturn in applyReturnsUnQuit)
                {
                    applyOut = new Neusoft.HISFC.Models.Pharmacy.ApplyOut();
                    applyOut.ID = applyReturn.ID;								//申请流水号
                    applyOut.BillNO = applyReturn.ApplyBillNO;					    //申请单据号
                    applyOut.RecipeNO = applyReturn.RecipeNO;					//处方号
                    applyOut.SequenceNO = applyReturn.SequenceNO;				//处方内项目流水号
                    applyOut.ApplyDept.ID = applyReturn.RecipeOper.Dept.ID;				//申请科室
                    applyOut.Item.Name = applyReturn.Item.Name;					//项目名称
                    applyOut.Item.ID = applyReturn.Item.ID;						//项目编码
                    applyOut.Item.Specs = applyReturn.Item.Specs;				//规格
                    applyOut.Item.Price = applyReturn.Item.Price;				//零售价  以最小单位计算的零售价
                    applyOut.Operation.ApplyQty = applyReturn.Item.Qty;				//申请退药数量（乘以付数后的总数量）
                    applyOut.Item.PackQty = applyReturn.Item.PackQty;
                    applyOut.Days = applyReturn.Days;							//付数
                    applyOut.Item.MinUnit = applyReturn.Item.PriceUnit;			//计价单位
                    applyOut.User01 = "0";										//标志该数据由病区退费申请表获得 由applyReturn实体获取
                    
                    applyReturnFromApplyOut.Add(applyOut);
                }
            }
            

            #region 获取药房已退药确认 住院处尚未退费确认得费申请记录
            //该部分获取的对已发药的药品退费申请 药房已做过退药确认 住院处尚未做退费确认的数据 由CancelItem内检索
            confirmDrugList = this.returnApplyManager.QueryDrugReturnApplys(this.patientInfo.ID, false, true);
            if (confirmDrugList != null)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut;
                foreach (Neusoft.HISFC.Models.Fee.ReturnApply applyReturn in confirmDrugList)
                {
                    applyOut = new Neusoft.HISFC.Models.Pharmacy.ApplyOut();
                    applyOut.ID = applyReturn.ID;								//申请流水号
                    applyOut.BillNO = applyReturn.ApplyBillNO;					//申请单据号
                    applyOut.RecipeNO = applyReturn.RecipeNO;					//处方号
                    applyOut.SequenceNO = applyReturn.SequenceNO;				//处方内项目流水号
                    applyOut.ApplyDept.ID = applyReturn.RecipeOper.Dept.ID;				//申请科室
                    applyOut.Item.Name = applyReturn.Item.Name;					//项目名称
                    applyOut.Item.ID = applyReturn.Item.ID;						//项目编码
                    applyOut.Item.Specs = applyReturn.Item.Specs;				//规格
                    applyOut.Item.Price = applyReturn.Item.Price;				//零售价  以最小单位计算的零售价
                    applyOut.Operation.ApplyQty = applyReturn.Item.Qty;				//申请退药数量（乘以付数后的总数量）
                    applyOut.Item.PackQty = applyReturn.Item.PackQty;
                    applyOut.Days = applyReturn.Days;							//付数
                    applyOut.Item.MinUnit = applyReturn.Item.PriceUnit;			//计价单位
                    applyOut.User01 = "0";										//标志该数据由病区退费申请表获得 由applyReturn实体获取
                    applyOut.User02 = "1";										//标志该数据 药房已退药确认 但住院处尚未退费确认
                   
                    applyReturnFromApplyOut.Add(applyOut);
                }
            }
            #endregion

            for (int i = 0; i < applyReturnFromApplyOut.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = new Neusoft.HISFC.Models.Pharmacy.ApplyOut();
                applyOut = applyReturnFromApplyOut[i] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                if (applyOut == null)
                    return;

                //取费用信息
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList;
                //feeItemList = this.inpatientManager.GetItemListByRecipeNO(applyOut.RecipeNO, applyOut.SequenceNO, true);
                feeItemList = this.inpatientManager.GetItemListByRecipeNO(applyOut.RecipeNO, applyOut.SequenceNO, HISFC.Models.Base.EnumItemType.Drug);
                if (feeItemList == null)
                {
                    MessageBox.Show("获取未核准退费申请信息的费用明细出错");
                    return;
                }
                //临时存储申请科室
                feeItemList.ExecOper.Dept.User03 = applyOut.ApplyDept.ID;

                //获取医生姓名
                //string DoctName = "";
                //DoctName = this.personHelp.GetName(feeItemList.FeeInfo.ReciptDoct.ID);
                //feeItemList.FeeInfo.ReciptDoct.Name = DoctName;

                //获取最小费用名称--Add By Maokb
                //string MinFee = "";
                //MinFee = this.minfeeHelp.GetName(feeItemList.Item.MinFee.ID);
                //feeItemList.Item.MinFee.Name = MinFee;
                //获取执行科室名称--Add By Maokb
                //string DeptName = "";
                //DeptName = this.deptHelp.GetName(feeItemList.FeeInfo.ExeDept.ID);
                //feeItemList.FeeInfo.ExeDept.Name = DeptName;

               
               
                this.fpQuit_SheetDrug.Rows.Add(this.fpQuit_SheetDrug.RowCount, 1);

                int index = this.fpQuit_SheetDrug.Rows.Count - 1;
                
                applyOut.Item.PackQty = feeItemList.Item.PackQty;
                if (applyOut.Item.PackQty == 0)
                {
                    applyOut.Item.PackQty = 1;
                }
                if (feeItemList.Item.PackQty == 0)
                {
                    feeItemList.Item.PackQty = 1;
                }
                if (applyOut.Days == 0)
                {
                    applyOut.Days = 1;
                }
                decimal iNum = 0;
                decimal iCost = 0; ;
                if (applyOut.User01 == "0")			//该条数据由病区退费申请表获取 根据applyReturn实体获取数据转换为applyOut实体
                {
                    iNum = applyOut.Operation.ApplyQty;						//申请退药数量（乘以付数后的总数量）
                    iCost = feeItemList.Item.Price * applyOut.Operation.ApplyQty / feeItemList.Item.PackQty;	//总金额
                }
                else							//该条数据由出库申请表获取  
                {
                    iNum = Neusoft.FrameWork.Public.String.FormatNumber(applyOut.Operation.ApplyQty * applyOut.Days, 4);				//退费数量
                    iCost = applyOut.Operation.ApplyQty * applyOut.Item.Price / applyOut.Item.PackQty;		//总金额
                }

                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.ItemName, applyOut.Item.Name);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Specs, applyOut.Item.Specs);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Price, applyOut.Item.Price);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Qty, iNum);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Unit, feeItemList.Item.PriceUnit);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.Cost, iCost);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.FeeDate, feeItemList.FeeOper.OperTime);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.IsConfirm, feeItemList.IsConfirmed);
                this.fpQuit_SheetDrug.SetValue(index, (int)DrugColumns.IsApply, false);

                feeItemList.User02 = applyOut.BillNO; //退费申请单据号
                feeItemList.Item.Qty = iNum;
                feeItemList.FT.TotCost = iCost;
                feeItemList.User03 = applyOut.ID;				//退费申请流水号
                feeItemList.User01 = applyOut.User01;			// "0" 该条数据由病区退费申请表获取 其他 该条数据由出库申请表获取
                feeItemList.Item.User01 = applyOut.User02;		//"1" 标志该数据已退药确认 但尚未退费确认
                //用于区别是否为已保存过的退费申请
                feeItemList.Memo = "OLD";

                this.fpQuit_SheetDrug.Rows[index].Tag = feeItemList;
            }
        }

        private void RetrieveReturnApplyUndrug(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            this.fpQuit_SheetUndrug.Rows.Count = 0;

            ArrayList returnApplys = new ArrayList();
            //获取时间段范围内的记录
            returnApplys = this.returnApplyManager.QueryReturnApplys(this.patientInfo.ID, false, false);
            if (returnApplys == null)
            {
                return;
            }

            foreach (Neusoft.HISFC.Models.Fee.ReturnApply returnApply in returnApplys) 
            {
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = null;

                //feeItemList = this.inpatientManager.GetItemListByRecipeNO(returnApply.RecipeNO, returnApply.SequenceNO, false);
                feeItemList = this.inpatientManager.GetItemListByRecipeNO(returnApply.RecipeNO, returnApply.SequenceNO, HISFC.Models.Base.EnumItemType.UnDrug);
                if (feeItemList == null) 
                {
                    MessageBox.Show("获得项目信息出错!" + this.inpatientManager.Err);

                    return;
                }

                this.fpQuit_SheetUndrug.Rows.Add(this.fpQuit_SheetUndrug.RowCount, 1);

                int index = this.fpQuit_SheetUndrug.Rows.Count - 1;

                returnApply.Item.PackQty = feeItemList.Item.PackQty;
                if (returnApply.Item.PackQty == 0)
                {
                    returnApply.Item.PackQty = 1;
                }
                if (feeItemList.Item.PackQty == 0)
                {
                    feeItemList.Item.PackQty = 1;
                }
                if (returnApply.Days == 0)
                {
                    returnApply.Days = 1;
                }

                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.ItemName, returnApply.Item.Name);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.FeeName, feeItemList.Item.MinFee.ID);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Price, feeItemList.Item.Price);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Qty, returnApply.Item.Qty);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Unit, feeItemList.Item.PriceUnit);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.Cost, feeItemList.Item.Price * returnApply.Item.Qty);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.ExecDept, feeItemList.FeeOper.Dept.ID);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.IsConfirm, feeItemList.IsConfirmed);
                this.fpQuit_SheetUndrug.SetValue(index, (int)UndrugColumns.IsApply, false);

                feeItemList.User02 = returnApply.ApplyBillNO; //退费申请单据号
                feeItemList.Item.Qty = returnApply.Item.Qty;
                feeItemList.FT.TotCost = feeItemList.Item.Price * returnApply.Item.Qty;
                feeItemList.User03 = returnApply.ID;				//退费申请流水号
                feeItemList.User01 = "0";			// "0" 该条数据由病区退费申请表获取 其他 该条数据由出库申请表获取
                //用于区别是否为已保存过的退费申请
                feeItemList.Memo = "OLD";

                this.fpQuit_SheetUndrug.Rows[index].Tag = feeItemList;
            }  
        }
        private void RetrieveReturnApplyMaterial(string inpatientNO, DateTime beginTime, DateTime endTime)
        { 

        }
    }
}

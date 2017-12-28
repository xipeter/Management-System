using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.WinForms.Report.DrugStore
{
    public partial class ucRecipeLabelFY : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,
        Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBackFeeRecipePrint
    {
        public ucRecipeLabelFY()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
        }

        private bool isPrint;

        protected bool Isprint
        {
            get
            {
                return this.isPrint;
            }
            set
            {
                this.isPrint = value;
            }
        }

        /// <summary>
        /// 频次帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper frequencyHelper = null;

        /// <summary>
        /// 用法帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper usageHelper = null;

        /// <summary>
        /// 打印
        /// </summary>
        Neusoft.FrameWork.WinForms.Classes.Print p = null;

        /// <summary>
        /// 初始化加载数据
        /// </summary>
        private void Init()
        {
            //获得所有频次信息 
            //if (this.frequencyHelper == null)
            //{
            //    Neusoft.HISFC.BizLogic.Manager.Frequency frequencyManagement = new Neusoft.HISFC.BizLogic.Manager.Frequency();
            //    ArrayList alFrequency = frequencyManagement.GetAll("Root");
            //    if (alFrequency != null)
            //        this.frequencyHelper = new Neusoft.FrameWork.Public.ObjectHelper(alFrequency);
            //}
            ////获取所用用法
            //if (this.usageHelper == null)
            //{
            //    Neusoft.HISFC.BizLogic.Manager.Constant c = new Neusoft.HISFC.BizLogic.Manager.Constant();
            //    ArrayList alUsage = c.GetList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
            //    if (alUsage == null)
            //    {
            //        MessageBox.Show("获取用法列表出错!");
            //        return;
            //    }
            //    ArrayList tempAl = new ArrayList();
            //    foreach (Neusoft.FrameWork.Models.NeuObject info in alUsage)
            //    {
            //        tempAl.Add(info);
            //    }

            //    this.usageHelper = new Neusoft.FrameWork.Public.ObjectHelper(tempAl);
            //}
        }

        /// <summary>
        /// 返回药品储藏信息
        /// </summary>
        private void GetRecipeLabelItem(string drugDept, string drugCode, ref Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            Neusoft.FrameWork.Management.DataBaseManger dataBaseMgr = new Neusoft.FrameWork.Management.DataBaseManger();
            string strSql = @"select t.trade_name,t.regular_name,t.formal_name,t.other_name,
       t.english_regular,t.english_other,t.english_name,t.caution,t.store_condition,t.specs,s.place_code,
	   t.custom_code
from   pha_com_baseinfo t,pha_com_stockinfo s
where  t.drug_code = s.drug_code
and    s.drug_dept_code = '{0}'
and    s.drug_code = '{1}'";
            strSql = string.Format(strSql, drugDept, drugCode);
            if (dataBaseMgr.ExecQuery(strSql) != -1)
            {
                if (dataBaseMgr.Reader.Read())
                {
                    item.Name = dataBaseMgr.Reader[0].ToString();
                    item.NameCollection.RegularName = dataBaseMgr.Reader[1].ToString();
                    //item.NameCollection.FormalName = dataBaseMgr.Reader[2].ToString();
                    //item.NameCollection.OtherName = dataBaseMgr.Reader[3].ToString();
                    //item.NameCollection.EnglishRegularName = dataBaseMgr.Reader[4].ToString();
                    //item.NameCollection.EnglishOtherName = dataBaseMgr.Reader[5].ToString();
                    //item.NameCollection.EnglishName = dataBaseMgr.Reader[6].ToString();
                    //item.Product.Caution = dataBaseMgr.Reader[7].ToString();
                    //item.Product.StoreCondition = dataBaseMgr.Reader[8].ToString();
                    item.Specs = dataBaseMgr.Reader[9].ToString();
                    item.User01 = dataBaseMgr.Reader[10].ToString();
                    //item.NameCollection.UserCode = dataBaseMgr.Reader[11].ToString();
                }
            }
        }
       
        /// <summary>
        /// 清空显示 
        /// </summary>
        protected void Clear()
        {
            this.lblAge.Text = "";
            this.lblDeptName.Text = "";
            this.lblDignoseName.Text = "";
            this.lblDoct.Text = "";
            this.lblDrug.Text = "";
            this.lblDrugDate.Text = "";
            this.lblInvoiceNo.Text = "";
            this.lblPactName.Text = "";
            this.lblPatientId.Text = "";
            this.lblPatientName.Text = "";
            this.lblSendWindow.Text = "";
            this.lblSex.Text = "";
            this.lblTotCost.Text = "";
            this.TotCost =0;
            this.fpSpread1_Sheet1.RemoveRows(0, this.fpSpread1_Sheet1.Rows.Count);
        }


        /// <summary>
        /// 设置患者信息
        /// </summary>
        protected void SetPatiAndSendInfo(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, decimal labelNum)
        {
            //设置条码
           // this.lbBarCode.Text = "*" + applyOut.RecipeNO + "*";
            //设置患者信息、发药信息
            if (this.patientInfo != null)
            {
                //姓名
                this.lblPatientName.Text = this.patientInfo.Name;
                this.lblPatientId.Text = this.patientInfo.ID;
                this.lblInvoiceNo.Text = this.patientInfo.InvoiceNO;//发票号
                this.lblPactName.Text = this.patientInfo.Pact.Name;
                this.lblSex.Text = this.patientInfo.Sex.Name;
                this.lblAge.Text = this.patientInfo.Age;
                this.lblDeptName.Text = this.patientInfo.DoctorInfo.Templet.Dept.Name;
                this.lblDignoseName.Text = this.patientInfo.ClinicDiagnose;
                this.lblDrug.Text = "发药人";
                this.lblDoct.Text = this.patientInfo.DoctorInfo.Templet.Doct.Name;
                this.lblSendWindow.Text = applyOut.SendWindow;
         
            }
        }

        /// <summary>
        /// 设置患者信息B
        /// </summary>
        protected void SetPatiAndSendInfo(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList iteminfo)
        {
            //设置条码
            // this.lbBarCode.Text = "*" + applyOut.RecipeNO + "*";
            //设置患者信息、发药信息
            if (this.patientInfo != null)
            {
                //姓名
                this.lblPatientName.Text = this.patientInfo.Name;
                this.lblPatientId.Text = this.patientInfo.ID;
                this.lblInvoiceNo.Text = this.patientInfo.InvoiceNO;//发票号
                this.lblPactName.Text = this.patientInfo.Pact.Name;
                this.lblSex.Text = this.patientInfo.Sex.Name;
                this.lblAge.Text = this.patientInfo.Age;
                this.lblDeptName.Text = this.patientInfo.DoctorInfo.Templet.Dept.Name;
                this.lblDignoseName.Text = this.patientInfo.ClinicDiagnose;
                this.lblDrug.Text = "";
                this.lblDoct.Text = this.patientInfo.DoctorInfo.Templet.Doct.Name;
                this.lblSendWindow.Text = "退药窗口";

            }
        }
        /// <summary>
        /// 设置患者信息
        /// </summary>
        protected void SetPatiAndSendInfo(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            this.SetPatiAndSendInfo(applyOut, this.labelNum);
        }

        /// <summary>
        /// 转换剂量单位按最小单位显示
        /// </summary>
        /// <param name="doseOnce">每次剂量</param>
        /// <param name="baseDose">基本剂量</param>
        /// <returns>返回相应的表示字符串 对大于1的按小数显示 小于1的按分数方式显示</returns>
        protected string DoseToMin(decimal doseOnce, decimal baseDose)
        {
            if (baseDose == 0)
                baseDose = 1;
            decimal result = doseOnce / baseDose;
            if (result >= 1)
                return System.Math.Round(result, 2).ToString();
            else  //计算公约数 显示为分数形式
            {
                result = this.MaxCD(doseOnce, baseDose);
                return (doseOnce / result).ToString() + "/" + (baseDose / result).ToString();
            }
        }

        public decimal MaxCD(decimal i, decimal j)
        {
            decimal a, b, temp;
            if (i > j)
            {
                a = i;
                b = j;
            }
            else
            {
                b = i;
                a = j;
            }
            temp = a % b;
            while (temp != 0)
            {
                a = b;
                b = temp;
                temp = a % b;
            }
            return b;
        }


        /// <summary>
        /// 汇总页数据赋值
        /// </summary>
        /// <param name="applyOut">发药申请数组</param>
        public void SetPatiTotData()
        {
            //this.Clear();

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();
            this.lblDrugDate.Text =  this.patientInfo.User01;

        }


        #region IRecipeLabel 成员
        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Register patientInfo = null;
        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            get
            {
                // TODO:  添加 ucComboRecipeLabel.PatientInfo getter 实现
                return this.patientInfo;
            }
            set
            {
                // TODO:  添加 ucComboRecipeLabel.PatientInfo setter 实现
                this.patientInfo = value;

                this.SetPatiTotData();
                //this.Print();
            }
        }


        protected decimal drugTotNum;
        /// <summary>
        /// 一次打印药品种类总页数
        /// </summary>
        public decimal DrugTotNum
        {
            set
            {
                this.drugTotNum = value;
                this.labelNum = 1;
            }
        }
        /// <summary>
        /// 本次处方打印页数
        /// </summary>
        protected decimal labelNum;
        /// <summary>
        /// 本次处方金额
        /// </summary>
        protected decimal TotCost;

        /// <summary>
        /// 本次处方打印总页数
        /// </summary>
        public decimal LabelTotNum
        {
            set
            {
                //this.labelTotNum = value;
                this.labelNum = 1;
            }
        }
        /// <summary>
        /// 打印单个药品
        /// </summary>
        /// <param name="applyOut"></param>
        public void AddSingle(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            //this.Clear();
            Neusoft.HISFC.Models.Pharmacy.Item item = applyOut.Item;
            this.GetRecipeLabelItem(applyOut.StockDept.ID, applyOut.Item.ID, ref item);
            //设置患者信息显示、发药信息
            this.SetPatiAndSendInfo(applyOut);
            //退改药标志
            this.fpSpread1_Sheet1.AddRows(this.fpSpread1_Sheet1.Rows.Count, 2);
            this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.Rows.Count - 1].Font = new System.Drawing.Font("宋体", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.Rows.Count - 2].Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 0].Text = item.NameCollection.RegularName;
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 0].Text = "     [" + item.Name + "]";
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 1].Text = item.Specs;
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 1].Text = applyOut.Usage.Name.ToString();
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 2].Text = applyOut.Operation.ApplyQty.ToString() + applyOut.Item.MinUnit;
            if (applyOut.PlaceNO != null)
            {
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 3].Text = applyOut.PlaceNO.ToString();
            }
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 4].Text = applyOut.Item.Price.ToString();
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 5].Text = "80%";
            TotCost += applyOut.Operation.ApplyQty * applyOut.Item.Price;
            this.lblTotCost.Text = TotCost.ToString();
        }

        /// <summary>
        /// 打印一组药品
        /// </summary>
        /// <param name="alCombo"></param>
        public void AddCombo(ArrayList alCombo)
        {
            this.fpSpread1_Sheet1.Rows.Count = 0;
            for (int i = 0; i < alCombo.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = alCombo[i] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                if (i == 0)
                {
                    this.SetPatiAndSendInfo(applyOut);
                }
                this.AddSingle(applyOut);
                if (i < alCombo.Count - 1)
                    this.Print();
            }
        }



        public void AddBackFeeItem(int iIndex, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList infoItem)
        {
            //this.Clear();
            Neusoft.HISFC.BizLogic.Pharmacy.Item con = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            Neusoft.HISFC.Models.Pharmacy.Item item =con.GetItem(infoItem.Item.ID);
            this.GetRecipeLabelItem(infoItem.FeeOper.Dept.ID, infoItem.Item.ID, ref item);
            //设置患者信息显示、发药信息
            this.SetPatiAndSendInfo(infoItem);
            if (infoItem.Item.Qty < 0)
            {
                this.neuLabel1.Text = "无锡市妇幼保健院退药清单";
            }
            //退改药标志
            this.fpSpread1_Sheet1.AddRows(iIndex * 2, 2);
            this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.Rows.Count - 1].Font = new System.Drawing.Font("宋体", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 0].Text = item.NameCollection.RegularName;
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 0].Text = "     [" + item.Name+"]";
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 1].Text = item.Specs;
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 1].Text = " ";
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 2].Text = infoItem.Item.Qty + infoItem.Item.PriceUnit;

            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 3].Text = " ";

            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 4].Text = infoItem.Item.Price.ToString();
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 2, 5].Text = "80%";
            TotCost += infoItem.Item.Qty * infoItem.Item.Price;
            this.lblTotCost.Text = TotCost.ToString();
            
        }

        /// <summary>
        /// 打印全部药品 摆药清单
        /// </summary>
        /// <param name="al"></param>
        public void AddAllData(ArrayList al)
        {
            // TODO:  添加 ucComboRecipeLabel.AddAllData 实现
        }

        /// <summary>
        /// 打印函数
        /// </summary>
        public void Print()
        {

            // TODO:  添加 ucComboRecipeLabel.Print 实现
            if (p == null)
            {
                p = new Neusoft.FrameWork.WinForms.Classes.Print();

                //Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("RecipeLabel", ref p);//界面配置，信息科模块

                Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("MZPY", ref p);

                p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            }
            System.Windows.Forms.Control c = this;
     
            p.PrintPage(5, 1, c);
           // p.PrintPreview(5, 1, c);

            this.Clear();
        }

        #endregion


        private enum RowSet
        {
            /// <summary>
            /// 摆药行数开始索引 1
            /// </summary>
            RowDrugBegin = 1,
            /// <summary>
            /// 注意事项 4
            /// </summary>
            RowCaution = 4,
            /// <summary>
            /// 频次 5
            /// </summary>
            RowFreUse = 5,
            /// <summary>
            /// 患者信息 0
            /// </summary>
            RowPatiInfo = 0,
            /// <summary>
            /// 发药信息 0
            /// </summary>
            RowSendInfo = 0,
            /// <summary>
            /// 医院名称
            /// </summary>
            RowHosName = 6
        }


        #region IDrugPrint 成员

        public void AddAllData(ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void AddAllData(ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Neusoft.HISFC.Models.RADT.PatientInfo InpatientInfo
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public Neusoft.HISFC.Models.Registration.Register OutpatientInfo
        {
            get
            {
                // TODO:  添加 ucComboRecipeLabel.PatientInfo getter 实现
                return this.patientInfo;
            }
            set
            {
                // TODO:  添加 ucComboRecipeLabel.PatientInfo setter 实现
                this.patientInfo = value;

                this.SetPatiTotData();              
            }
        }

        public void Preview()
        {
            if (p == null)
            {
                p = new Neusoft.FrameWork.WinForms.Classes.Print();

                Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("RecipeLabel", ref p);
                p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            }
            System.Windows.Forms.Control c = this;
            c.Width = this.Width;
            c.Height = this.Height;
            //			p.PrintPreview(12,1,c);
            p.PrintPreview(12, 1, c);

            this.Clear();
        }

        #endregion
        #region IBackFeeRecipePrint 成员

        public int SetData(ArrayList alBackFee)
        {
            //this.Clear();
            this.isPrint = true;
            int i = 0;
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in alBackFee)
            {
                this.AddBackFeeItem(i, f);
                i++;
            }

            return 1;
        }

        #endregion

        #region IBackFeeRecipePrint 成员

        public Neusoft.HISFC.Models.Registration.Register Patient
        {
            set {

                if (value != null)
                {
                    this.patientInfo = value;
                }
            }
        }

        #endregion
    }
}

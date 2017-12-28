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
    public partial class ucRecipeLabel : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,
        Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint
    {
        public ucRecipeLabel()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
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
            if (this.frequencyHelper == null)
            {
                Neusoft.HISFC.BizLogic.Manager.Frequency frequencyManagement = new Neusoft.HISFC.BizLogic.Manager.Frequency();
                ArrayList alFrequency = frequencyManagement.GetAll("Root");
                if (alFrequency != null)
                    this.frequencyHelper = new Neusoft.FrameWork.Public.ObjectHelper(alFrequency);
            }
            //获取所用用法
            if (this.usageHelper == null)
            {
                Neusoft.HISFC.BizLogic.Manager.Constant c = new Neusoft.HISFC.BizLogic.Manager.Constant();
                ArrayList alUsage = c.GetList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
                if (alUsage == null)
                {
                    MessageBox.Show("获取用法列表出错!");
                    return;
                }
                ArrayList tempAl = new ArrayList();
                foreach (Neusoft.FrameWork.Models.NeuObject info in alUsage)
                {
                    tempAl.Add(info);
                }

                this.usageHelper = new Neusoft.FrameWork.Public.ObjectHelper(tempAl);
            }
        }

        private void GetRecipeLabelItem(string drugDept, string drugCode, ref Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            Neusoft.FrameWork.Management.DataBaseManger dataBaseMgr = new Neusoft.FrameWork.Management.DataBaseManger();
            string strSql = @"select t.trade_name,t.regular_name,t.formal_name,t.other_name,
       t.english_regular,t.english_other,t.english_name,t.caution,t.store_condition,t.base_dose,s.place_code,
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
                    item.NameCollection.FormalName = dataBaseMgr.Reader[2].ToString();
                    item.NameCollection.OtherName = dataBaseMgr.Reader[3].ToString();
                    item.NameCollection.EnglishRegularName = dataBaseMgr.Reader[4].ToString();
                    item.NameCollection.EnglishOtherName = dataBaseMgr.Reader[5].ToString();
                    item.NameCollection.EnglishName = dataBaseMgr.Reader[6].ToString();
                    item.Product.Caution = dataBaseMgr.Reader[7].ToString();
                    item.Product.StoreCondition = dataBaseMgr.Reader[8].ToString();
                    item.BaseDose = Neusoft.FrameWork.Function.NConvert.ToDecimal(dataBaseMgr.Reader[9].ToString());
                    item.User01 = dataBaseMgr.Reader[10].ToString();
                    item.NameCollection.UserCode = dataBaseMgr.Reader[11].ToString();
                }
            }
        }
       
        /// <summary>
        /// 清空显示 
        /// </summary>
        protected void Clear()
        {
            this.lbBarCode.Text = "";
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                for (int j = 0; j < this.neuSpread1_Sheet1.Columns.Count; j++)
                {
                    this.neuSpread1_Sheet1.Cells[i, j].Text = "";
                }
            }

            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 3, 0].Text = "注意事项：";
            //又改标签 数据维护不全 暂时不显示存储
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 4, 0].Text = "";
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowHosName, 0].Text = "";//"广州医学院第一附属医院";
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2, 0].ColumnSpan = 1;
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2, 2].ColumnSpan = 2;
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 3, 0].ColumnSpan = 1;

        }


        /// <summary>
        /// 设置患者信息
        /// </summary>
        protected void SetPatiAndSendInfo(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, decimal labelNum)
        {
            //设置条码
            this.lbBarCode.Text = "*" + applyOut.RecipeNO + "*";
            //设置患者信息、发药信息
            if (this.patientInfo != null)
            {
                //姓名
                this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo, 0].Text = this.patientInfo.Name;
                //设置发药信息			
                this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo, 1].Text = applyOut.Operation.ApplyOper.OperTime.ToString();
                //货位号
                this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo, 2].Text = applyOut.Item.User01;
                //配药标签总页数/当前页数
                this.neuSpread1_Sheet1.Cells[(int)RowSet.RowSendInfo, 3].Text = labelNum + "/" + this.drugTotNum;
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
            this.Clear();

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo, 0].Text = this.patientInfo.Name;
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo, 1].Text = "性别:" + this.patientInfo.Sex.Name + "   年龄:" + dataManager.GetAge(this.patientInfo.Birthday);
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo, 2].Text = "共 " + this.patientInfo.User02 + "张";
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo + 1, 0].Text = "病历号:  " + this.patientInfo.PID.CardNO;

            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo + 2, 0].Text = "医生姓名: " + this.patientInfo.DoctorInfo.Templet.Doct.Name;
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo + 3, 0].ColumnSpan = 3;
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowPatiInfo + 3, 0].Text = "收费日期： " + this.patientInfo.User01;

            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 3, 0].Text = "";
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 4, 0].Text = "";

            //设置条码
            this.lbBarCode.Text = "*" + this.patientInfo.User03 + "*";
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
                this.Print();
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
        /// 本次处方打印总页数
        /// </summary>
        protected decimal labelTotNum;

        /// <summary>
        /// 本次处方打印总页数
        /// </summary>
        public decimal LabelTotNum
        {
            set
            {
                this.labelTotNum = value;
                this.labelNum = 1;
            }
        }
        /// <summary>
        /// 打印单个药品
        /// </summary>
        /// <param name="applyOut"></param>
        public void AddSingle(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            this.Clear();
            Neusoft.HISFC.Models.Pharmacy.Item item = applyOut.Item;
            this.GetRecipeLabelItem(applyOut.StockDept.ID, applyOut.Item.ID, ref item);
            //设置患者信息显示、发药信息
            this.SetPatiAndSendInfo(applyOut);
            //设置处方内发药药品信息
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin, 0].ColumnSpan = 3;
            //退改药标志
            if (applyOut.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Extend)
                this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin, 0].Text = "[改] " + applyOut.Item.Name + "[" + applyOut.Item.Specs + "]";	//名称
            else
                this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin, 0].Text = applyOut.Item.Name + "[" + applyOut.Item.Specs + "]";	//名称

            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin, 3].Text = applyOut.Operation.ApplyQty.ToString() + applyOut.Item.MinUnit;	//申请量、单位
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 1, 0].Text = applyOut.Item.NameCollection.RegularName;	//名称
            if (applyOut.ExecNO.ToString() != "" && applyOut.ExecNO.ToString() != "0")
                this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 1, 2].Text = "院注" + applyOut.ExecNO.ToString() + "次";

            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2, 0].Text = this.usageHelper.GetName(applyOut.Usage.ID);						//用法

            //屏蔽代码
            //			this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2,1].Text = "每次" + applyOut.DoseOnce.ToString() + applyOut.Item.DoseUnit;	//每次量
            //			this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2,2].Text = "  " + this.frequencyHelper.GetName(applyOut.Frequency.ID);		//频次

            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2, 1].Text = "  " + this.frequencyHelper.GetName(applyOut.Frequency.ID);		//频次
            //对注射剂每次量 显示剂量单位
            //string str = applyOut.Item.NameCollection.UserCode;
            //if (str != null && str.Length > 3 && (str.Substring(0, 3) == "002" || str.Substring(0, 3) == "003" || str.Substring(0, 3) == "004"))
            //    this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2, 2].Text = "每次" + applyOut.DoseOnce.ToString() + applyOut.Item.DoseUnit;	//每次量
            //else
            //    this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2, 2].Text = "每次" + this.DoseToMin(applyOut.DoseOnce, applyOut.Item.BaseDose).ToString() + applyOut.Item.MinUnit;	//每次量

            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2, 2].Text = "每次" + applyOut.DoseOnce.ToString() + applyOut.Item.DoseUnit;	//每次量

            //用法包含'适量'字样的药品不打印每次量
            if (this.usageHelper.GetObjectFromID(applyOut.Usage.ID) != null)
            {
                if (this.usageHelper.GetName(applyOut.Usage.ID).IndexOf("适量") != -1)
                {
                    this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 2, 2].Text = "";
                }
            }

            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 3, 1].Text = applyOut.Item.Product.Caution;								//注意事项
            //默认不显示存储
            //			if (applyOut.Item.StoreCondition == "")
            //				applyOut.Item.StoreCondition = "常温存储";
            //			this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 4,1].Text = applyOut.Item.StoreCondition;						//存储条件
            this.neuSpread1_Sheet1.Cells[(int)RowSet.RowDrugBegin + 4, 1].Text = "";

            this.labelNum = this.labelNum + 1;
        }

        /// <summary>
        /// 打印一组药品
        /// </summary>
        /// <param name="alCombo"></param>
        public void AddCombo(ArrayList alCombo)
        {
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

                Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("RecipeLabel", ref p);
                p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            }
            System.Windows.Forms.Control c = this;
            c.Width = this.Width;
            c.Height = this.Height;
            //			p.PrintPreview(12,1,c);
            p.PrintPage(12, 1, c);

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
                this.Print();
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
    }
}

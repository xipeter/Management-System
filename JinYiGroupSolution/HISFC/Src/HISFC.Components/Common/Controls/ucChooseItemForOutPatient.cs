using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucChooseItemForOutPatient : UserControl, Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IChooseItemForOutpatient
    {
        public ucChooseItemForOutPatient()
        {
            InitializeComponent();
        }

        #region 私有成员
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.ChooseItemTypes chooseItemType = Neusoft.HISFC.BizProcess.Integrate.FeeInterface.ChooseItemTypes.ItemChanging;
        string deptCode = ""; 
        System.Data.DataTable dtItem = null;
        Neusoft.FrameWork.Public.ObjectHelper minFeeHelp = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper deptHelp = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.HISFC.Models.Base.ItemKind itemKind = Neusoft.HISFC.Models.Base.ItemKind.All;
        System.Data.DataView dvItem = null;

        Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrage = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        bool isSelectAndClose = true;
        /// <summary>
        /// 传入的字符串
        /// </summary>
        protected string inputChar = string.Empty;

        /// <summary>
        /// 查询方式,默认拼音
        /// </summary>
        protected Neusoft.HISFC.Models.Base.InputTypes inputType = Neusoft.HISFC.Models.Base.InputTypes.Spell;

        //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序

        /// <summary>
        /// 排序doc
        /// </summary>
        static XmlDocument xSortDoc = null;

        #endregion   

        #region 私有函数 
        /// <summary>
        /// 初始化显示列信息
        /// </summary>
        private void InitDataTable()
        {
            this.fpSpread1_Sheet1.DataAutoSizeColumns = false;
            Type str = typeof(string);
            Type dec = typeof(decimal);
            Type bl = typeof(bool);
            dtItem = new DataTable("列表");
            dtItem.Columns.AddRange(new DataColumn[]{       new DataColumn("项目名称", str),
                                                            new DataColumn("费用类别", str),
															new DataColumn("规格", str),
															new DataColumn("价格", str),
                                                            new DataColumn("库存", str),
															new DataColumn("单位", str), 
                                                            new DataColumn("执行科室", str), 
															new DataColumn("拼音码", str),
                                                            new DataColumn("自定义码", str),
															new DataColumn("五笔码", str),
                                                            new DataColumn("编码", str),
                                                            new DataColumn("是否药品",str),
                                                            new DataColumn("医保等级",str),   //{E91E0D33-FCC6-4982-BA74-320A6E8A373C}
                                                            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序
                                                            new DataColumn("sort", dec)
                                                            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加完毕
															
                                                        });
            this.fpSpread1_Sheet1.RowCount = 0;
            dvItem = new DataView(dtItem);
            this.fpSpread1_Sheet1.DataSource = dvItem;
            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序
            this.fpSpread1_Sheet1.Columns[(int)Cols.Sort].Visible = false;
            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数完毕
        } 
        #endregion  

        #region IChooseItemForOutpatient 成员

        public Neusoft.HISFC.BizProcess.Integrate.FeeInterface.ChooseItemTypes ChooseItemType
        {
            get
            {
                return chooseItemType;
            }
            set
            {
                //chooseItemType = value;
            }
        }

        public string DeptCode
        {
            get
            {
                return deptCode;
            }
            set
            {
                deptCode = value;
            }
        }

        public int GetSelectedItem(ref Neusoft.HISFC.Models.Base.Item item)
        {
            if (fpSpread1_Sheet1.RowCount == 0)
            {
                return 1;
            }
            if (item == null)
            {
                return 1;
            }
            item.ID = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ItemCode].Text;
            string drugFlag = fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.DrugFlag].Text;
            if (drugFlag == "1")
            {
                //item.IsPharmacy = false;
                item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
            }
            return 1;
        }

        public int GetSelectedItem()
        {
            if (fpSpread1_Sheet1.RowCount == 0)
            {
                return 1;
            }
            string itemCode = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ItemCode].Text;
            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序
            Common.Classes.Function.SetSortItemXML(itemCode);
            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数完毕
            string drugFlag = fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.DrugFlag].Text;
            string exeDept = deptHelp.GetID(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ExeDept].Text);
            //物资收费 {40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
            //SelectedItem(itemCode, drugFlag, exeDept);
            decimal price = FrameWork.Function.NConvert.ToDecimal(fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.UintPrice].Text);
            SelectedItem(itemCode, drugFlag, exeDept, price);

            if (isSelectAndClose)
            {
                this.Visible = false;
            }
            return 1;
        }

        public int Init()
        {
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            InitDataTable();
            #region 最小费用
            Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList minFeeList = managerMgr.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE);
            if (minFeeList == null)
            {
                MessageBox.Show("获取最小费用失败！");
                return -1;
            }
            minFeeHelp.ArrayObject = minFeeList;
            #endregion 

            #region 科室
            ArrayList deptList = managerMgr.GetDeptmentAllValid();
            if (deptList == null)
            {
                MessageBox.Show("获取科室列表失败");
                return -1;
            }
            deptHelp.ArrayObject = deptList;
            #endregion 
            this.fpSpread1_Sheet1.Columns[(int)Cols.ItemCode].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)Cols.WBCode].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)Cols.DrugFlag].Visible = false;

            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序
            xSortDoc = Common.Classes.Function.GetSortXML();

            Common.Classes.Function.xmlDoc = xSortDoc;
            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数完毕

            return 1;
        }

        public string InputPrev
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

        public bool IsJudgeStore
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

        public bool IsQueryLike
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

        public bool IsSelectAndClose
        {
            get
            {
                return true;
            }
            
        }

        public bool IsSelectItem
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

        public int ItemCount
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

        public Neusoft.HISFC.Models.Base.ItemKind ItemKind
        {
            get
            {
                return itemKind;
            }
            set
            {
                itemKind = value;
            }
        }

        public void NextPage()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void NextRow()
        {

            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                return;
            }
            int RowNum = fpSpread1_Sheet1.ActiveRowIndex;
            if (RowNum > 9)
            {
                fpSpread1.SetViewportTopRow(0, fpSpread1_Sheet1.ActiveRowIndex - 9);
            }
            if (RowNum < this.fpSpread1_Sheet1.RowCount-1)
            { 
                RowNum++;
                fpSpread1_Sheet1.ActiveRowIndex = RowNum;
                fpSpread1_Sheet1.SetActiveCell(RowNum, 0);
                fpSpread1_Sheet1.AddSelection(RowNum, 0, 1, 1);
            }

            this.fpSpread1_SelectionChanged(this, null);
        }

        public Neusoft.HISFC.Models.Base.Item NowItem
        {
            get
            {
                //if (this.fpSpread1_Sheet1.RowCount == 0)
                //{
                //    return new Neusoft.HISFC.Models.Base.Item(); ;
                //}

                //Neusoft.HISFC.Models.Base.Item item = new Neusoft.HISFC.Models.Base.Item();
                //item.ID = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ItemCode].Text;
                //item.Name = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ItemName].Text;
                //string DrugFlag = fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.DrugFlag].Text;
                //if (DrugFlag == "0")
                //{
                //    item.IsPharmacy = false;
                //}
                //else if (DrugFlag == "1")
                //{
                //    item.IsPharmacy = true;
                //}
                //return item;
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object ObjectFilterObject
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

        public void PriorPage()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void PriorRow()
        {
            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                return;
            }
            int RowNum = fpSpread1_Sheet1.ActiveRowIndex;
            if (RowNum > 9)
            {
                fpSpread1.SetViewportTopRow(0, fpSpread1_Sheet1.ActiveRowIndex - 9);
            }
            if (RowNum > 0 )
            { 
                RowNum--;
                fpSpread1_Sheet1.ActiveRowIndex = RowNum;
                fpSpread1_Sheet1.SetActiveCell(RowNum, 0);
                fpSpread1_Sheet1.AddSelection(RowNum, 0, 1, 1);
            }

            this.fpSpread1_SelectionChanged(this, null);
        }

        public string QueryType
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

        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.WhenGetItem SelectedItem;

        public void SetDataSet(DataSet dsItem)
        {
            if (dsItem == null)
            {
                return;
            }
            if (dsItem.Tables.Count == 0)
            {
                return;
            }
            //{E91E0D33-FCC6-4982-BA74-320A6E8A373C}
            dtItem.Clear();
            foreach (DataRow row in dsItem.Tables[0].Rows)
            {
                if (itemKind == Neusoft.HISFC.Models.Base.ItemKind.Pharmacy)
                {
                    if(row["DRUG_FLAG"].ToString() ==  "0")
                    continue;
                }
                if (itemKind == Neusoft.HISFC.Models.Base.ItemKind.Undrug)
                {
                    if (row["DRUG_FLAG"].ToString() == "1")
                        continue;
                }

                DataRow IRow = dtItem.NewRow();
                IRow["项目名称"] = row["ITEM_NAME"];
                IRow["费用类别"] = minFeeHelp.GetName(row["FEE_CODE"].ToString()); 
                IRow["规格"] = row["SPECS"];
                IRow["价格"] = row["UNIT_PRICE"];
                IRow["单位"] = row["PACK_UNIT"];
                IRow["库存"] = row["NOW_STORE"];
                IRow["执行科室"] = deptHelp.GetName(row["EXE_DEPT"].ToString());
                IRow["拼音码"] = row["SPELL_CODE"];
                IRow["自定义码"] = row["USER_CODE"];
                IRow["五笔码"] = row["WB_CODE"]; 
                IRow["编码"] = row["ITEM_CODE"];
                IRow["是否药品"] = row["DRUG_FLAG"];
                //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序
                IRow["sort"] = Common.Classes.Function.GetSortValue(xSortDoc, row["ITEM_CODE"].ToString());
                //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数完毕
                //{E91E0D33-FCC6-4982-BA74-320A6E8A373C}
                #region
                string strGrage = string.Empty;
                if (iGetSiItemGrade != null)
                {
                    if (this.regPatientInfo == null)
                    {
                        this.iGetSiItemGrade.GetSiItemGrade(row["ITEM_CODE"].ToString(), ref strGrage);
                    }
                    else
                    {
                        this.iGetSiItemGrade.GetSiItemGrade(this.regPatientInfo.Pact.ID, row["ITEM_CODE"].ToString(), ref strGrage);
                    }
                    strGrage = Neusoft.HISFC.BizLogic.Fee.Interface.ShowItemGradeByCode(strGrage);

                }
                else
                {
                    strGrage = "自费";
                }
                IRow["医保等级"] = strGrage;
                #endregion
                dtItem.Rows.Add(IRow);
                //dtItem.Rows.Add(IRow);
            }
            this.fpSpread1_Sheet1.Columns[(int)Cols.NowStore].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1_Sheet1.Columns[(int)Cols.PackUnit].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)Cols.UintPrice].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
        }

        public void SetInputChar(object sender, string inputChar, Neusoft.HISFC.Models.Base.InputTypes inputType)
        {
            if (!this.Visible)
            {
                this.Show();
            }

            this.Show();

            this.fpSpread1_SelectionChanged(this, null);

            this.BringToFront();

            this.SetFilter(inputChar);
        }
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="inputChar">输入字符串</param>
        private void SetFilter(string inputChar)
        {
            string filterString = string.Empty;

            if (inputChar == string.Empty)
            {
                filterString = "1 = 1";
            }
            else if(!cbFilter.Checked)
            {
                filterString = "(拼音码 LIKE '" + inputChar + "%') OR " + " (项目名称 LIKE '" + inputChar + "%') OR" + " (自定义码 LIKE '" + inputChar + "%') OR" + " (五笔码 LIKE '" + inputChar + "%')";// + "(wb_code LIKE '%" + inputChar + "%') OR" + "(item_name LIKE '%" + inputChar + "%')";
            }
            else if (cbFilter.Checked)
            {
                filterString = "(拼音码 LIKE '%" + inputChar + "%') OR " + " (项目名称 LIKE '%" + inputChar + "%') OR" + " (自定义码 LIKE '%" + inputChar + "%') OR" + " (五笔码 LIKE '%" + inputChar + "%') ";// + "(wb_code LIKE '%" + inputChar + "%') OR" + "(item_name LIKE '%" + inputChar + "%')";
            }

            dvItem.RowFilter = filterString;

            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序
            //dvItem.Sort = " sort DESC, 拼音码 ASC";
            dvItem.Sort = " 自定义码";
            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序完毕
        }
        public void SetLocation(Point p)
        {
            this.Location = p;
        }

        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                if (this.fpSpread1_Sheet1.RowCount == 0)
                {
                    return false;
                }
                string itemCode = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ItemCode].Text;
                string drugFlag = fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.DrugFlag].Text;
                string exeDept = deptHelp.GetID(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ExeDept].Text);
                //物资收费{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                //SelectedItem(itemCode, drugFlag, exeDept);
                decimal price = FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.UintPrice].Text);
                SelectedItem(itemCode, drugFlag, exeDept, price);

                if (isSelectAndClose)
                {
                    this.Visible = false;
                }
            }
            return base.ProcessDialogKey(keyData);
        }
        private enum Cols
        {
            ItemName,//项目名称
            FeeCode,//系统类别
            Spaces, //规格
            UintPrice,//价格
            NowStore,//库存量
            PackUnit,//单位 
            ExeDept,//执行科室
            SpellCode,//拼音码
            UsageCode,//自定义码
            WBCode,//五笔码
            ItemCode,//编码
            DrugFlag,
            ItemGrade,  //{E91E0D33-FCC6-4982-BA74-320A6E8A373C}
            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序
            Sort
            //{ED51E97B-B752-4c32-BD93-F80209A24879}增加输入次数排序完毕
        }

        #region IChooseItemForOutpatient 成员


        bool Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IChooseItemForOutpatient.IsSelectAndClose
        {
            get
            {
                return isSelectAndClose;
            }
            set
            {
                isSelectAndClose = value;
            }
        }

        #endregion

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string itemCode = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ItemCode].Text;
            string drugFlag = fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.DrugFlag].Text;
            string exeDept = deptHelp.GetID(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ExeDept].Text);
            //物资收费 {40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
            //SelectedItem(itemCode, drugFlag, exeDept);
            decimal price = FrameWork.Function.NConvert.ToDecimal(fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.UintPrice].Text);
            SelectedItem(itemCode, drugFlag, exeDept, price);

            if (isSelectAndClose)
            {
                this.Visible = false;
            }
        }

        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            return;
        }

        //{E91E0D33-FCC6-4982-BA74-320A6E8A373C}
        #region 医保列显示相关
        Neusoft.HISFC.Models.Registration.Register regPatientInfo = null;


        #region IChooseItemForOutpatient 成员


        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register RegPatientInfo
        {
            get
            {
                return this.regPatientInfo;
            }
            set
            {
                this.regPatientInfo = value;
            }
        }

        /// <summary>
        /// 医保等级接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade iGetSiItemGrade = null;

        /// <summary>
        /// 医保接口变量
        /// </summary>
        public Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade IGetSiItemGrade
        {
            get
            {
                return this.iGetSiItemGrade;
            }
            set
            {
                this.iGetSiItemGrade = value; ;
            }
        }


        #endregion

        //{32553EB6-EF4D-4c61-A63A-17B3C850FC51}
        private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                return;
            }

            //{F26216A3-5256-40e8-BB6D-3D1C51B5F4BE} 通过1,2,3,4,5选择 20100102 yoyi++
            int curViewportTop = this.fpSpread1.GetViewportTopRow(0);
            this.fpSpread1_Sheet1.StartingRowNumber = 0 - curViewportTop + 1;

            string itemCode = this.fpSpread1_Sheet1.Cells[row, (int)Cols.ItemCode].Text;
            if (string.IsNullOrEmpty(itemCode))
            {
                return;
            }

           // GetDisplaySI(itemCode);

            string drugFlag = this.fpSpread1_Sheet1.Cells[row, (int)Cols.DrugFlag].Text;
            if (drugFlag.Trim() == "4")//协定处方
            {
                this.neuGroupBox1.Visible = true;
                this.neuGroupBox1.Width = 233;

                List<Neusoft.HISFC.Models.Pharmacy.Nostrum> drugCombList = this.pharmacyIntegrage.QueryNostrumDetail(itemCode);
                if (drugCombList == null)
                {
                    MessageBox.Show("获得药品协议处方明细出错!" + this.pharmacyIntegrage.Err);

                    return;
                }

                this.neuSpread1_Sheet1.RowCount = 0;
                this.neuSpread1_Sheet1.RowCount = drugCombList.Count;

                for (int i = 0; i < drugCombList.Count; i++)
                {
                    Neusoft.HISFC.Models.Pharmacy.Nostrum n = drugCombList[i];

                    this.neuSpread1_Sheet1.Cells[i, 0].Text = n.Item.Name;
                    this.neuSpread1_Sheet1.Cells[i, 1].Text = n.Item.Price.ToString();
                    this.neuSpread1_Sheet1.Cells[i, 2].Text = n.Qty.ToString();
                }
            }
            else
            {
                this.neuGroupBox1.Visible = false;
                this.neuGroupBox1.Width = 0;
            }
        }
        #endregion
    }
}

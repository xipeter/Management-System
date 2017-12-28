using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 医嘱查询控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2007-1-17]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucOrderShow : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucOrderShow()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.BizProcess.Integrate.Manager deptManagement = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizLogic.Order.Order orderManagement = new Neusoft.HISFC.BizLogic.Order.Order();
        Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        string orderId = "";
        protected DataSet dsAllLong;
        protected DataSet dsAllShort;
        private DataSet dataSet = null;							//当前DataSet
        private DataView dvLong = null;							//当前DataView
        private DataView dvShort = null;						//当前DataView
        private string LONGSETTINGFILENAME = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath +
            Neusoft.FrameWork.WinForms.Classes.Function.SettingPath+ "LongOrderQuerySetting.xml";
        private string SHORTSETTINGFILENAME = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath +
            Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "ShortOrderQuerySetting.xml";

        private int sheetIndex = 0;			//当前活动Sheet页索引
        ucSubtblManager ucSubtblManager1 = null;//附材维护
        /// <summary>
        /// 皮试药批注
        /// {17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
        /// </summary>
        ucTip ucTip = null;
        float[] longColumnWidth;
        float[] shortColumnWidth;
        ArrayList alQueryLong = new ArrayList();
        ArrayList alQueryShort = new ArrayList();

        private void ucOrderShow_Load(object sender, System.EventArgs e)
        {
            

        }


        #region 属性
        Neusoft.HISFC.Models.RADT.PatientInfo myPatientInfo = null;
        /// <summary>
        /// 患者基本信息
        /// </summary>
        protected Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                if (this.myPatientInfo == null)
                    this.myPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                return this.myPatientInfo;
            }
            set
            {
                this.myPatientInfo = value;
            
                this.QueryOrder();
            
            }
        }

        Neusoft.HISFC.Models.Base.Employee oper = null;
        /// <summary>
        /// 操作员信息
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Neusoft.HISFC.Models.Base.Employee Oper
        {
            get
            {
                if (oper == null)
                    oper = Neusoft.FrameWork.Management.Connection.Operator as  Neusoft.HISFC.Models.Base.Employee;
                return oper;
            }
            set
            {
                this.oper = value;
            }
        }
        /// <summary>
        /// 是否显示过滤功能
        /// </summary>
        public bool IsShowFilter
        {
            set
            {
                this.cmbOderStatus.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示停止/作废医嘱
        /// </summary>
        private bool showDCOrder = true;
        /// <summary>
        /// 是否显示停止/作废医嘱
        /// </summary>
        public bool IsShowDCOrder
        {
            set
            {
                this.showDCOrder = value;
            }
        }

        /// <summary>
        /// 是否允许操作附材
        /// </summary>
        protected bool enableSubtbl = true;
        /// <summary>
        /// 是否允许操作附材 当用于护士站综合收费时查询医嘱时不允许操作附材
        /// </summary>
        public bool IsEnabledSubtbl
        {
            set
            {
                this.enableSubtbl = value;
            }
        }
        
        #endregion

        #region 初始化
        private void InitFP()
        {

            SetColumnProperty();
        }

        private void SetColumnProperty()
        {
            if (System.IO.File.Exists(LONGSETTINGFILENAME))
            {
                if (this.longColumnWidth == null || this.shortColumnWidth == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1.Sheets[0], LONGSETTINGFILENAME);
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1.Sheets[1], SHORTSETTINGFILENAME);
                    this.longColumnWidth = new float[this.fpSpread1.Sheets[0].Columns.Count];
                    for (int i = 0; i < this.fpSpread1.Sheets[0].Columns.Count; i++)
                    {
                        this.longColumnWidth[i] = this.fpSpread1.Sheets[0].Columns[i].Width;
                    }
                    this.shortColumnWidth = new float[this.fpSpread1.Sheets[1].Columns.Count];
                    for (int i = 0; i < this.fpSpread1.Sheets[1].Columns.Count; i++)
                    {
                        this.shortColumnWidth[i] = this.fpSpread1.Sheets[1].Columns[i].Width;
                    }
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < this.fpSpread1.Sheets[0].Columns.Count; i++)
                            this.fpSpread1.Sheets[0].Columns[i].Width = this.longColumnWidth[i];
                        for (int i = 0; i < this.fpSpread1.Sheets[1].Columns.Count; i++)
                            this.fpSpread1.Sheets[1].Columns[i].Width = this.shortColumnWidth[i];
                    }
                    catch
                    { }
                }
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[0], LONGSETTINGFILENAME);
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[1], SHORTSETTINGFILENAME);
            }

            this.fpSpread1.Sheets[0].Columns[0].Visible = false;//！备注不显示
            this.fpSpread1.Sheets[1].Columns[0].Visible = false;//！备注不显示

            this.fpSpread1.Sheets[0].Columns[21].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1.Sheets[0].Columns[20].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1.Sheets[1].Columns[21].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1.Sheets[1].Columns[20].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList list = managerMgr.GetDepartment();
            if (list == null)
            {
                MessageBox.Show("获取科室信息失败" + managerMgr.Err);
                list = new ArrayList();
            }

            this.deptHelper.ArrayObject = list;
        }

        private FarPoint.Win.Spread.CellType.DateTimeCellType dateCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();

        
        private DataSet InitDataSet()
        {
            try
            {
                dataSet = new DataSet();
                Type dtStr = System.Type.GetType("System.String");
                Type dtDbl = typeof(System.Double);
                Type dtInt = typeof(System.Int32);
                Type dtBoolean = typeof(System.Boolean);
                Type dtDate = typeof(System.DateTime);

                DataTable table = new DataTable("Table");

                table.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("!",dtStr),						//0
					new DataColumn("顺序号",dtInt),					//35  by zlw 2006-4-18
					new DataColumn("重整",dtBoolean),	
					new DataColumn("期效",dtStr),					//1
					new DataColumn("医嘱类型",dtStr),				//2
					new DataColumn("医嘱流水号",dtStr),				//3
					new DataColumn("医嘱状态",dtStr),				//4 新开立，审核，执行
					new DataColumn("组合号",dtStr),					//5
					new DataColumn("主药",dtStr),					//6
					new DataColumn("医嘱名称",dtStr),				//8
					new DataColumn("组",dtStr),					    //9
					new DataColumn("备注",dtStr),					//20
					new DataColumn("总量",dtDbl),					//9
					new DataColumn("总量单位",dtStr),				//10
					new DataColumn("每次量",dtStr),				//11
					new DataColumn("单位",dtStr),					//12
					new DataColumn("付数",dtStr),					//13
					new DataColumn("频次编码",dtStr),				//14
					new DataColumn("频次",dtStr),				//15
					new DataColumn("用法编码",dtStr),				//16
					new DataColumn("用法",dtStr),				//17
					new DataColumn("大类",dtStr),
					new DataColumn("开始时间",dtStr),				//18
					new DataColumn("停止时间",dtStr),				//19
					new DataColumn("开立医生",dtStr),				//21
					new DataColumn("执行科室编码",dtStr),			//22
					new DataColumn("执行科室",dtStr),				//23
					new DataColumn("加急",dtStr),					//24
					new DataColumn("检查部位",dtStr),				//25
					new DataColumn("样本类型/检查部位",dtStr),				//26
					new DataColumn("扣库科室编码",dtStr),			//27
					new DataColumn("扣库科室",dtStr),				//28
					new DataColumn("录入人编码",dtStr),				//29	
					new DataColumn("录入人",dtStr),					//30
					new DataColumn("开立科室",dtStr),				//31
					new DataColumn("开立时间",dtStr),				//32
					new DataColumn("停止人编码",dtStr),				//33
					new DataColumn("停止人",dtStr),					//34
					new DataColumn("皮试标志",dtStr),				//36
					new DataColumn("附材标志",dtBoolean),
					
				});

                
                dataSet.Tables.Add(table);

                DataColumn[] keys = new DataColumn[1];
                keys[0] = dataSet.Tables[0].Columns["医嘱流水号"];
                this.dataSet.Tables[0].PrimaryKey = keys;

                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        #endregion

        #region 显示医嘱
        /// <summary>
        /// 添加实体toTable
        /// </summary>
        /// <param name="list"></param>
        private void AddObjectsToTable(ArrayList list)
        {
            Neusoft.HISFC.Models.Order.Inpatient.Order order;
            this.alQueryLong = new ArrayList();
            this.alQueryShort = new ArrayList();
            foreach (object obj in list)
            {
                order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                if (order == null)
                    continue;

                if (!this.showDCOrder)
                {
                    if (order.Status == 3)		//不显示作废/停止医嘱
                        continue;
                }
                
                if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)//长期医嘱
                {
                    dsAllLong.Tables[0].Rows.Add(AddObjectToRow(order, dsAllLong.Tables[0]));
                    alQueryLong.Add(order.Item.Name);
                }
                else//临时医嘱
                {
                    dsAllShort.Tables[0].Rows.Add(AddObjectToRow(order, dsAllShort.Tables[0]));
                    alQueryShort.Add(order.Item.Name);
                }
            
            }
            this.lblInfo.Text ="姓名:"+this.myPatientInfo.Name+ "  结算方式: " + this.myPatientInfo.Pact.Name + "   剩余金额: " + this.myPatientInfo.FT.LeftCost;
        }


        private DataRow AddObjectToRow(object obj, DataTable table)
        {

            DataRow row = table.NewRow();
            
            string strTemp = "";
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
            

            if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
            {
                Neusoft.HISFC.Models.Pharmacy.Item objItem = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                row["主药"] = System.Convert.ToInt16(order.Combo.IsMainDrug);	//6
                row["每次量"] = order.DoseOnce.ToString();					//10
                row["单位"] = objItem.DoseUnit;								//0415 2307096 wang renyi
                row["付数"] = order.HerbalQty;								//11
            }
            else if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
            {
                //Neusoft.HISFC.Models.Fee.Item objItem = order.Item as Neusoft.HISFC.Models.Fee.Item;
            }

            if (order.Note != "")
            {
                row["!"] = order.Note;
            }
            row["期效"] = System.Convert.ToInt16(order.OrderType.Type);			//0
            row["医嘱类型"] = order.OrderType.Name;								//2
            row["医嘱流水号"] = order.ID;										//3
            row["医嘱状态"] = order.Status;										//12 新开立，审核，执行
            row["组合号"] = order.Combo.ID;	//5

            if (order.Item.Specs == null || order.Item.Specs.Trim() == "")
            {
                row["医嘱名称"] = order.Item.Name;
            }
            else
            {
                row["医嘱名称"] = order.Item.Name + "[" + order.Item.Specs + "]";
            }

            //医保用药
            if (order.IsPermission) row["医嘱名称"] = "√" + row["医嘱名称"];

            row["总量"] = order.Qty;
            row["总量单位"] = order.Unit;
            row["频次编码"] = order.Frequency.ID;
            row["频次"] = order.Frequency.Name;
            row["用法编码"] = order.Usage.ID;
            row["用法"] = order.Usage.Name;
            row["大类"] = order.Item.SysClass.Name;
            row["开始时间"] = order.BeginTime;
            row["执行科室编码"] = order.ExeDept.ID;
            if (order.ExeDept.Name == "" && order.ExeDept.ID != "") order.ExeDept.Name = this.GetDeptName(order.ExeDept);
            row["执行科室"] = order.ExeDept.Name;
            if (order.IsEmergency)
            {
                strTemp = "是";
            }
            else
            {
                strTemp = "否";
            }
            row["加急"] = strTemp;
            row["检查部位"] = order.CheckPartRecord;
            row["样本类型/检查部位"] = order.Sample;
            row["扣库科室编码"] = order.StockDept.ID;
            row["扣库科室"] = deptHelper.GetName(order.StockDept.ID);

            row["备注"] = order.Memo;
            row["录入人编码"] = order.Oper.ID;

            row["录入人"] = order.Oper.Name;
            if (order.ReciptDept.Name == "" && order.ReciptDept.ID != "") order.ReciptDept.Name = this.GetDeptName(order.ReciptDept);
            row["开立医生"] = order.ReciptDoctor.Name;
            row["开立科室"] = order.ReciptDept.Name;
            row["开立时间"] = order.MOTime.ToString();
            #region addby xuewj {B8EDA745-62C3-407e-9480-3A9E60647141} 未停止的医嘱 停止时间不显示
            if (!order.EndTime.ToString().Contains("0001"))
            {
                row["停止时间"] = order.EndTime;
            }
            #endregion
            row["停止人编码"] = order.DCOper.ID;
            row["停止人"] = order.DCOper.Name;
            
            row["顺序号"] = order.SortID;
            row["皮试标志"] = order.HypoTest;
            row["附材标志"] = order.IsSubtbl;

            
            return row;
        }


        /// <summary>
        /// 查询医嘱
        /// </summary>
        /// 
        private void QueryOrder()
        {
            try
            {
                this.fpSpread1.Sheets[0].RowCount = 0;
                this.fpSpread1.Sheets[1].RowCount = 0;
                this.dsAllLong.Tables[0].Rows.Clear();
                this.dsAllShort.Tables[0].Rows.Clear();
            }
            catch { }
            if (this.myPatientInfo == null)
            {
                return;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询医嘱,请稍候!");
            Application.DoEvents();

            if (this.ucSubtblManager1 != null)
            {
                this.ucSubtblManager1.PatientInfo = this.myPatientInfo;
            }

            //查询所有医嘱类型
            ArrayList alAllOrder = orderManagement.QueryOrder(this.myPatientInfo.ID);
            if (alAllOrder == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(orderManagement.Err);
                return;
            }
            //查询所有医嘱附材
            ArrayList alSub = this.orderManagement.QueryOrderSubtbl(this.myPatientInfo.ID);
            if (alSub == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(this.orderManagement.Err);
                return;
            }

            try
            {
                dsAllLong.Tables[0].Clear();
                dsAllShort.Tables[0].Clear();
                alAllOrder.AddRange(alSub);

                ArrayList al = new ArrayList();
                
                //屏蔽显示重整医嘱					
                foreach (Neusoft.HISFC.Models.Order.Order info in alAllOrder)
                {
                    if (info.Status != 4)
                        al.Add(info);
                }
            

                this.AddObjectsToTable(al);
                dvLong = new DataView(dsAllLong.Tables[0]);
                dvShort = new DataView(dsAllShort.Tables[0]);

                //{EACD8AED-FDF6-490a-980C-EC9A89391719} 显示前先进行排序操作
                try
                {
                    dvLong.Sort = "顺序号 ASC , 组合号 ASC";
                    dvShort.Sort = "顺序号 ASC , 组合号 ASC";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("对显示医嘱根据顺序号、组合号排序发生错误" + ex.Message);
                    return;
                }

                this.fpSpread1.Sheets[0].DataSource = dvLong;
                this.fpSpread1.Sheets[1].DataSource = dvShort;

                
                this.InitFP();

                this.fpSpread1.Sheets[0].Columns[0, this.fpSpread1.Sheets[0].Columns.Count - 1].Locked = true;
                this.fpSpread1.Sheets[1].Columns[0, this.fpSpread1.Sheets[0].Columns.Count - 1].Locked = true;

            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(ex.Message);
                return;
            }

            this.Filter(this.cmbOderStatus.SelectedIndex);
            this.InitQueryCombox(this.sheetIndex);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }


        ///<summary>
        /// 刷新组合
        /// </summary>
        public void RefreshCombo()
        {
            Classes.Function.DrawCombo(this.fpSpread1.Sheets[0], (int)ColEnum.ColComboNo, (int)ColEnum.ColComboFlag);

            Classes.Function.DrawCombo(this.fpSpread1.Sheets[1], (int)ColEnum.ColComboNo, (int)ColEnum.ColComboFlag);

            this.SetSortID();
        }


        ArrayList alDepts = null;

        private string GetDeptName(Neusoft.FrameWork.Models.NeuObject dept)
        {
            for (int i = 0; i < alDepts.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj = (Neusoft.FrameWork.Models.NeuObject)alDepts[i];
                if (obj.ID == dept.ID)
                {
                    dept.Name = obj.Name;
                    return dept.Name;
                }
            }
            return "";
        }


        /// <summary>
        /// 更新医嘱状态
        /// </summary>
        public void RefreshOrderState()
        {
            for (int i = 0; i < this.fpSpread1.Sheets[0].Rows.Count; i++)
            {
                this.ChangeOrderState(i, 0, false);
            }
            for (int i = 0; i < this.fpSpread1.Sheets[1].Rows.Count; i++)
            {
                this.ChangeOrderState(i, 1, false);
            }
        }


        /// <summary>
        /// 刷新医嘱状态
        /// </summary>
        /// <param name="row"></param>
        /// <param name="SheetIndex"></param>
        /// <param name="reset"></param>
        private void ChangeOrderState(int row, int SheetIndex, bool reset)
        {
            try
            {
                int i = (int)ColEnum.ColOrderState;//"医嘱状态";
                int j = (int)ColEnum.ColSort;//顺序号所在的列
                int state = int.Parse(this.fpSpread1.Sheets[SheetIndex].Cells[row, i].Text);
                
                switch (state)
                {
                    case 0://updated by zlw 006-4-18
                        this.fpSpread1.Sheets[SheetIndex].Cells[row, j].BackColor = Color.FromArgb(128, 255, 128);

                        break;
                    case 1:
                        this.fpSpread1.Sheets[SheetIndex].Cells[row, j].BackColor = Color.FromArgb(106, 174, 242);
                        break;
                    case 2:
                        this.fpSpread1.Sheets[SheetIndex].Cells[row, j].BackColor = Color.FromArgb(243, 230, 105);
                        break;
                    case 3:
                        this.fpSpread1.Sheets[SheetIndex].Cells[row, j].BackColor = Color.FromArgb(248, 120, 222);
                        break;
                    case 5:
                        this.fpSpread1.Sheets[SheetIndex].Cells[row, j].BackColor = Color.Black;
                        break;
                    default:
                        this.fpSpread1.Sheets[SheetIndex].Cells[row, j].BackColor = Color.White;
                        break;
                }
            }
            catch { }
        }


        /// <summary>
        /// 设置备注和皮试
        /// </summary>
        /// <param name="k"></param>
        private void SetTip(int k)
        {
            for (int i = 0; i < this.fpSpread1.Sheets[k].RowCount; i++)//批注
            {

                string sHypotest = this.fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColHypoTest].Text;
                if (fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text.Substring(fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text.Length - 1, 1) == "+" || fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text.Substring(fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text.Length - 1, 1) == "-")
                    fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text = fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text.Substring(0, fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text.Length - 1);

                fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].ForeColor = Color.Black;

                switch (sHypotest)
                {
                    case "2":
                        fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text += "[需皮试]";//皮试
                        break;
                    case "3":
                        fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text += "+";//皮试
                        fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].ForeColor = Color.Red;
                        break;
                    case "4":
                        fpSpread1.Sheets[k].Cells[i, (int)ColEnum.ColItemName].Text += "-";
                        break;
                }
            }
        }

        private void SetSortID()
        {
            this.fpSpread1.Sheets[0].RowHeaderAutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.fpSpread1.Sheets[1].RowHeaderAutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
        }
        
        #endregion

        #region IToolBar 成员

        public int Retrieve()
        {
            // TODO:  添加 ucOrderShow.Retrieve 实现
            this.QueryOrder();
            return 0;
        }

        public int Save()
        {
            if (ifHaveNotSameCom() == 0)
            {
                UpdateOrderSortID();
                

                QueryOrder();
            }
            else
            {
                MessageBox.Show("同一组合序号要相同,否则会影响组合显示!");
            }

            return 0;
        }


        #endregion

        #region 过滤
        /// <summary>
        /// 过滤医嘱显示
        /// </summary>
        /// <param name="State"></param>
        public void Filter(int State)
        {
            if (this.PatientInfo == null) return;
            if (this.PatientInfo.ID == "") return;
            if (this.dvLong == null || this.dvShort == null)
                return;

            //查询时候才能过滤
            switch (State)
            {
                case 0://全部
                    dvLong.RowFilter = "";
                    dvShort.RowFilter = "";
                    break;
                case 2://当天
                    DateTime dt = orderManagement.GetDateTimeFromSysDateTime();
                    DateTime dt1 = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
                    DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                    dvLong.RowFilter = "开始时间>=" + "#" + dt1 + "#" + " and 开始时间<=" + "#" + dt2 + "#" + " and 附材标志 = false";
                    dvShort.RowFilter = "开始时间>=" + "#" + dt1 + "#" + " and 开始时间<=" + "#" + dt2 + "#" + " and 附材标志 = false";
                    break;
                case 1://有效
                    dvLong.RowFilter = "医嘱状态 ='1' or 医嘱状态 = '2'";
                    dvShort.RowFilter = "医嘱状态 ='1' or 医嘱状态 = '2'";
                    break;
                case 5://无效
                    dvLong.RowFilter = "医嘱状态 = '3'";
                    dvShort.RowFilter = "医嘱状态 = '3'";
                    break;
                case 3://未审核
                    dvLong.RowFilter = "医嘱状态 = '0'";
                    dvShort.RowFilter = "医嘱状态 = '0'";
                    break;
                case 4://当天作废
                    DateTime d = orderManagement.GetDateTimeFromSysDateTime();
                    DateTime d1 = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                    DateTime d2 = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
                    dvLong.RowFilter = "停止时间>=" + "#" + d1 + "#" + " and 停止时间<=" + "#" + d2 + "#" + " and 医嘱状态 = '3'";
                    dvShort.RowFilter = "停止时间>=" + "#" + d1 + "#" + " and 停止时间<=" + "#" + d2 + "#" + " and 医嘱状态 = '3'";
                    break;
                case 6://未审核
                    dvLong.RowFilter = "医嘱状态 = '4'";//已作废
                    dvShort.RowFilter = "医嘱状态 = '4'";//已作废
                    //皮试医嘱//{17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
                    dvLong.RowFilter = "皮试标志 in ('2','3','4')";
                    dvShort.RowFilter = "皮试标志 in ('2','3','4')";
                    break;
                default:
                    dvLong.RowFilter = "";
                    dvShort.RowFilter = "";
                    break;
            }

            this.InitFP();
            this.RefreshOrderState();
            this.RefreshCombo();
            this.RefreshSubtblDisplay(0);
            this.RefreshSubtblDisplay(1);
            if (this.fpSpread1.Sheets[this.fpSpread1.ActiveSheetIndex].Rows.Count >= 20)
            {
                this.neuLabel2.Visible = true;
                this.txtQuery.Visible = true;
            }
            else
            {
                this.neuLabel2.Visible = false;
                this.txtQuery.Visible = false;
            }
            this.SetTip(0);
            this.SetTip(1);
        }

        /// <summary>
        /// 添加查询下拉列表数据
        /// </summary>
        /// <param name="name"></param>
        private void addCombo(string name)
        {
            if (this.txtQuery.FindStringExact(name) >= 0) return;
            this.txtQuery.Items.Add(name);
        }

        private void InitQueryCombox(int index)
        {
            this.txtQuery.Items.Clear();
            string orderName = "";
            if (index == 0)
            {
                for (int i = 0; i < this.alQueryLong.Count; i++)
                {
                    orderName = this.alQueryLong[i].ToString();
                    this.addCombo(orderName);
                }
            }

            if (index == 1)
            {
                for (int i = 0; i < this.alQueryShort.Count; i++)
                {
                    orderName = this.alQueryShort[i].ToString();
                    this.addCombo(orderName);
                }
            }
        }

        #endregion

        #region 吸附窗口
        public Crownwood.Magic.Docking.DockingManager dockingManager;
        /// <summary>
        /// 附材管理控件
        /// </summary>
        private Crownwood.Magic.Docking.Content content;

        /// <summary>
        /// 皮试药控件
        /// </summary>
        private Crownwood.Magic.Docking.Content hypoTestContent;

        private Crownwood.Magic.Docking.WindowContent wc;

        private Crownwood.Magic.Docking.WindowContent wc1;

        public void DockingManager()
        {
            this.dockingManager = new Crownwood.Magic.Docking.DockingManager(this, Crownwood.Magic.Common.VisualStyle.IDE);
            this.dockingManager.InnerControl = this.panel1;		//在InnerControl前加入的控件不受停靠窗口的影响

            content = new Crownwood.Magic.Docking.Content(this.dockingManager);
            content.Control = ucSubtblManager1;

            Size ucSize = content.Control.Size;

            content.Title = "附材管理";
            content.FullTitle = "附材管理";
            content.AutoHideSize = ucSize;
            content.DisplaySize = ucSize;

            //{17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
            this.hypoTestContent = new Crownwood.Magic.Docking.Content(this.dockingManager);
            this.hypoTestContent.Control = ucTip;

            Size ucTipSize = this.hypoTestContent.Control.Size;
            this.hypoTestContent.Title = "皮试药管理";
            this.hypoTestContent.FullTitle = "皮试药管理";
            this.hypoTestContent.AutoHideSize = ucTipSize;
            this.hypoTestContent.DisplaySize = ucTipSize;

            this.dockingManager.Contents.Add(this.hypoTestContent);
            this.dockingManager.Contents.Add(content);
        
        }
        #endregion

        #region 附材显示
        /// <summary>
        /// 更新附材显示标志
        /// </summary>
        private void RefreshSubtblFlag(string operFlag, bool isShowSubtblFlag, object sender)
        {
            if (this.fpSpread1.Sheets[this.sheetIndex].Rows.Count < 0)
                return;

            int rowIndex = this.fpSpread1.ActiveSheet.ActiveRowIndex;
            string s = this.fpSpread1.Sheets[this.sheetIndex].Cells[rowIndex, (int)ColEnum.ColItemName].Text;       //医嘱名称
            string comboNo = this.fpSpread1.Sheets[this.sheetIndex].Cells[rowIndex, (int)ColEnum.ColComboNo].Text;	//组合号

            #region 刷新组合显示"@"
            //用于查找同一组合医嘱
            int iUp = rowIndex;
            bool isUp = true;
            int iDown = rowIndex;
            bool isDown = true;

            if (!isShowSubtblFlag)	//不需显示"@"符号
            {
                while (isUp || isDown)
                {
                    #region 向上查找 如到最前一行或组合号不同则置标志为false
                    if (isUp)
                    {
                        iUp = iUp - 1;
                        if (iUp < 0)
                            isUp = false;
                        else
                        {
                            if (this.fpSpread1.Sheets[this.sheetIndex].Cells[iUp, (int)ColEnum.ColComboNo].Text == comboNo)				//同一组合
                            {
                                if (this.fpSpread1.Sheets[this.sheetIndex].Cells[iUp, (int)ColEnum.ColItemName].Text.Substring(0, 1) == "@")	//医嘱名称带有"@"符号
                                {
                                    this.fpSpread1.Sheets[this.sheetIndex].Cells[iUp, (int)ColEnum.ColItemName].Text = this.fpSpread1.Sheets[this.sheetIndex].Cells[iUp, (int)ColEnum.ColItemName].Text.Substring(1);
                                }
                            }
                            else		//不是同一组合 不需再查找
                            {
                                isUp = false;
                            }
                        }
                    }
                    #endregion

                    #region 向下查找 如遇最下一行或组合号不同则置标志为false
                    if (isDown)
                    {
                        iDown = iDown + 1;
                        if (iDown >= this.fpSpread1.Sheets[this.sheetIndex].Rows.Count)
                            isDown = false;
                        else
                        {
                            if (this.fpSpread1.Sheets[this.sheetIndex].Cells[iDown, (int)ColEnum.ColComboNo].Text == comboNo)					//同一组合
                            {
                                if (this.fpSpread1.Sheets[this.sheetIndex].Cells[iDown, (int)ColEnum.ColItemName].Text.Substring(0, 1) == "@")	//医嘱名称带有"@"符号
                                {
                                    this.fpSpread1.Sheets[this.sheetIndex].Cells[iDown, (int)ColEnum.ColItemName].Text = this.fpSpread1.Sheets[this.sheetIndex].Cells[iDown, (int)ColEnum.ColItemName].Text.Substring(1);
                                }
                            }
                            else			//不是同一组合 不需再查找
                            {
                                isDown = false;
                            }
                        }
                    }
                    #endregion
                }
                //更新本条记录医嘱标志
                if (s.Substring(0, 1) == "@")
                {
                    this.fpSpread1.Sheets[this.sheetIndex].Cells[rowIndex, (int)ColEnum.ColItemName].Text = s.Substring(1);
                }
            }
            else		//需要显示"@"符号
            {
                bool isAlreadyHave = false;			//该组合是否已包含"@"医嘱符号
                while (isUp || isDown)
                {
                    #region 向上查找 如到最前一行或组合号不同则置标志为false
                    if (isUp)
                    {
                        iUp = iUp - 1;
                        if (iUp < 0)
                            isUp = false;
                        else
                        {
                            if (this.fpSpread1.Sheets[this.sheetIndex].Cells[iUp, (int)ColEnum.ColComboNo].Text == comboNo)					//同一组合中
                            {
                                if (this.fpSpread1.Sheets[this.sheetIndex].Cells[iUp, (int)ColEnum.ColItemName].Text.Substring(0, 1) == "@")		//已经存在"@"符号
                                {
                                    isAlreadyHave = true;
                                    break;
                                }
                            }
                            else
                            {
                                isUp = false;
                            }
                        }
                    }
                    #endregion

                    #region 向下查找 如遇最下一行或组合号不同则置标志为false
                    if (isDown)
                    {
                        iDown = iDown + 1;
                        if (iDown >= this.fpSpread1.Sheets[this.sheetIndex].Rows.Count)
                            isDown = false;
                        else
                        {
                            if (this.fpSpread1.Sheets[this.sheetIndex].Cells[iDown, (int)ColEnum.ColComboNo].Text == comboNo)
                            {
                                if (this.fpSpread1.Sheets[this.sheetIndex].Cells[iDown, (int)ColEnum.ColItemName].Text.Substring(0, 1) == "@")
                                {
                                    isAlreadyHave = true;
                                    break;
                                }
                            }
                            else
                            {
                                isDown = false;
                            }
                        }
                    }
                    #endregion
                }
                //本组合内未存在"@"符号
                if (!isAlreadyHave && s.Substring(0, 1) != "@")
                {
                    this.fpSpread1.Sheets[this.sheetIndex].Cells[rowIndex, (int)ColEnum.ColItemName].Text = "@" + s;
                }
            }
            #endregion

            #region 改变界面附材的显示 添加或删除
            try
            {
                if (operFlag == "2")					//删除/停止操作
                {
                    #region 处理删除/停止操作时的附材界面显示
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = sender as Neusoft.HISFC.Models.Order.Inpatient.Order;
                    if (order == null)
                    {
                        MessageBox.Show("准备刷新处理界面附材显示时发生错误 请退出界面重试");
                        return;
                    }
                    if (order.ID != "")					//已保存附材 
                    {
                        if (this.sheetIndex == 0)		//长嘱
                        {
                            string[] tempFind = new string[1];								//寻找需删除行的主键
                            tempFind[0] = order.ID;
                            DataRow delRow = this.dsAllLong.Tables[0].Rows.Find(tempFind);	//需由DataSet内移除的行				
                            this.dsAllLong.Tables[0].Rows.Remove(delRow);					//移除行

                            if (order.Status != 0)											//对已审核/执行的数据 仍需显示 但改变状态
                            {
                                order.Status = 3;
                                //添加改变状态的行 
                                this.dsAllLong.Tables[0].Rows.Add(this.AddObjectToRow(order, this.dsAllLong.Tables[0]));
                            }
                        }
                        else							//临嘱
                        {
                            string[] tempFind = new string[1];								//寻找需删除行的主键
                            tempFind[0] = order.ID;
                            DataRow delRow = this.dsAllShort.Tables[0].Rows.Find(tempFind);//需由DataSet内移除的行	
                            this.dsAllShort.Tables[0].Rows.Remove(delRow);					//移除行

                            if (order.Status != 0)											//对已审核/执行的数据 仍需显示 但改变状态
                            {
                                order.Status = 3;
                                //添加改变状态的行 
                                this.dsAllShort.Tables[0].Rows.Add(this.AddObjectToRow(order, this.dsAllShort.Tables[0]));
                            }
                        }
                        //处理相关信息刷新
                        
                        this.Filter(this.cmbOderStatus.SelectedIndex);
                       
                    }
                    #endregion
                }
                else									//保存操作
                {
                    if (this.ucSubtblManager1.AddSubInfo != null && this.ucSubtblManager1.AddSubInfo.Count > 0)
                    {
                        this.AddObjectsToTable(this.ucSubtblManager1.AddSubInfo);			//向DataSet内加入新数据
                        //处理相关信息刷新
                        
                        this.Filter(this.cmbOderStatus.SelectedIndex);
                       
                    }
                    if (this.ucSubtblManager1.EditSubInfo != null && this.ucSubtblManager1.EditSubInfo.Count > 0)
                    {
                        foreach (Neusoft.HISFC.Models.Order.Order info in this.ucSubtblManager1.EditSubInfo)
                        {
                            if (info == null) continue;
                            int row = 0, col = 0;
                            string find = this.fpSpread1.Search(this.fpSpread1.ActiveSheetIndex, info.ID, false, true, false, false,
                                0, 0, ref row, ref col);
                            if (find == info.ID)
                            {
                                this.fpSpread1.ActiveSheet.Cells[row, (int)ColEnum.ColQty].Text = info.Qty.ToString();
                                this.fpSpread1.ActiveSheet.Cells[row, (int)ColEnum.ColUnit].Text = info.Unit;
                            }
                        }
                    }
                }
            }
            catch (System.Data.ConstraintException)
            {
                MessageBox.Show("无法添加两条同样的附材！可以修改附材数量");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("处理附材显示时发生不可预知错误 请退出界面重试" + ex.Message);
                return;
            }
            #endregion

            this.RefreshSubtblDisplay(this.sheetIndex);
        }

        /// <summary>
        /// 刷新附材显示 对附材显示斜体字
        /// </summary>
        /// <param name="sheetIndex"></param>
        private void RefreshSubtblDisplay(int sheetIndex)
        {
            for (int i = 0; i < this.fpSpread1.Sheets[sheetIndex].RowCount; i++)
            {
                string temp = this.fpSpread1.Sheets[sheetIndex].Cells[i, (int)ColEnum.ColSubtbl].Text;

                if (temp == "True")
                {
                    this.fpSpread1.Sheets[sheetIndex].Cells[i, (int)ColEnum.ColItemName].Font = new Font("宋体", 10, System.Drawing.FontStyle.Italic);
                    this.fpSpread1.Sheets[sheetIndex].Cells[i, 9].Locked = true;

                }
                else
                {
                    this.fpSpread1.Sheets[sheetIndex].Cells[i, (int)ColEnum.ColItemName].Font = new Font("宋体", 10, System.Drawing.FontStyle.Bold);
                    this.fpSpread1.Sheets[sheetIndex].Cells[i, 9].Locked = true;
                }
            }

        }

        #endregion

        
        private void fpSpread1_SheetTabClick(object sender, FarPoint.Win.Spread.SheetTabClickEventArgs e)
        {
            
            this.sheetIndex = e.SheetTabIndex;
            this.ucSubtblManager1.Clear();
            if (this.sheetIndex == 0)
            {
                //this.cmbOderStatus.SelectedIndex = 1;
                //{17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
                if (this.dockingManager != null)
                {
                    this.dockingManager.HideContent(this.hypoTestContent);
                }
            }

            if (this.sheetIndex == 1)
            {
                //this.cmbOderStatus.SelectedIndex = 2;

                //{07B60769-DFBE-4797-823D-3C07ACD737B4}
                //临时医嘱不显示附材界面
                if (this.dockingManager != null)
                {
                    this.dockingManager.HideContent(this.content);
                }
            }
            this.InitQueryCombox(this.sheetIndex);
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (!this.enableSubtbl)
                return;

            //判断当前的停靠窗口是否已显示 如未显示 则显示停靠窗口
            try
            {
                //{17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
                //皮试药显示
                //获取皮试药标记
                this.orderId = e.View.Sheets[e.View.ActiveSheetIndex].Cells[e.Row, (int)ColEnum.ColOrderID].Value.ToString();
                string flag = e.View.Sheets[e.View.ActiveSheetIndex].Cells[e.Row, (int)ColEnum.ColHypoTest].Value.ToString();
                if (flag == "2" || flag == "3" || flag == "4")
                {
                    this.ucTip.Hypotest = Neusoft.FrameWork.Function.NConvert.ToInt32(flag);
                    this.ucTip.Tip = this.orderManagement.QueryOrderNote(orderId);

                    if (this.hypoTestContent != null && this.hypoTestContent.Visible == false)
                    {
                        if (wc1 == null && this.dockingManager != null)
                        {
                            wc1 = this.dockingManager.AddContentWithState(this.hypoTestContent, Crownwood.Magic.Docking.State.DockRight);
                            this.dockingManager.AddContentToWindowContent(this.hypoTestContent, wc1);
                        }
                        if (this.dockingManager != null)
                            this.dockingManager.ShowContent(this.hypoTestContent);
                    }
                }
                else
                {
                    if (this.dockingManager != null)
                    {
                        this.dockingManager.HideContent(this.hypoTestContent);
                    }
                }
                //{17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}

                //{07B60769-DFBE-4797-823D-3C07ACD737B4}
                //临时医嘱不显示附材界面
                if (e.View.ActiveSheetIndex == 0)
                {
                    if (this.content != null && this.content.Visible == false)
                    {
                        if (wc == null && this.dockingManager != null)
                        {
                            wc = this.dockingManager.AddContentWithState(content, Crownwood.Magic.Docking.State.DockBottom);
                            this.dockingManager.AddContentToWindowContent(content, wc);
                        }
                        if (this.dockingManager != null)
                            this.dockingManager.ShowContent(this.content);
                    }
                    if (this.ucSubtblManager1 != null && !e.RowHeader && !e.ColumnHeader)		//点击非列标题与行标题
                    {
                        ucSubtblManager1.OrderID = this.fpSpread1.ActiveSheet.Cells[e.Row, (int)ColEnum.ColOrderID].Text;
                        ucSubtblManager1.ComboNo = this.fpSpread1.ActiveSheet.Cells[e.Row, (int)ColEnum.ColComboNo].Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ucSubtblManager1_ShowSubtblFlag(string operFlag, bool isShowSubtblFlag, object sender)
        {
            this.RefreshSubtblFlag(operFlag, isShowSubtblFlag, sender);
        }

        /// <summary>
        /// 皮试药保存
        /// {17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
        /// </summary>
        /// <param name="Tip"></param>
        /// <param name="Hypotest"></param>
        public void ucTip_OKEvent(string Tip, int Hypotest)
        {
            if (this.orderManagement.UpdateFeedback(this.PatientInfo.ID, this.orderId, Tip, Hypotest) == -1)
            {
                MessageBox.Show(this.orderManagement.Err);
                this.orderManagement.Err = "";
                return;
            }


            this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex, (int)ColEnum.ColHypoTest].Value = Hypotest;

            this.SetTip(this.fpSpread1.ActiveSheetIndex);
        }

        #region 右键菜单
        private void fpSpread1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!this.enableSubtbl)
                return;
            if (e.Button == MouseButtons.Right)
            {
                FarPoint.Win.Spread.Model.CellRange c = this.fpSpread1.GetCellFromPixel(0, 0, e.X, e.Y);
                if (c.Row >= 0)
                {
                    this.fpSpread1.ActiveSheet.ActiveRowIndex = c.Row;
                    this.fpSpread1.ActiveSheet.ClearSelection();
                    this.fpSpread1.ActiveSheet.AddSelection(c.Row, 0, 1, 1);
                }
                if (c.Row < 0) return;
                orderId = this.fpSpread1.ActiveSheet.Cells[c.Row, (int)ColEnum.ColOrderID].Text;

                if (this.contextMenuStrip1.Items.Count > 0)
                    this.contextMenuStrip1.Items.Clear();

                ToolStripMenuItem mnuSetTime = new ToolStripMenuItem("执行时间");
                mnuSetTime.Click += new EventHandler(mnuSetTime_Click);
                ToolStripMenuItem menuTip = new ToolStripMenuItem("批注/皮试");
                menuTip.Click += new EventHandler(menuTip_Click);

                this.contextMenuStrip1.Items.Add(mnuSetTime);
                this.contextMenuStrip1.Items.Add(menuTip);
            }

        }

        private void mnuSetTime_Click(object sender, EventArgs e)
        {
            //frmSetExecTime frm = new frmSetExecTime();
            //frm.SetItem(orderId);
            //frm.ShowDialog();
        }

        private void menuTip_Click(object sender, EventArgs e)
        {
            //ucTip ucTip1 = new ucTip();
            //ucTip1.IsEnabled = true;
            //int iHypotest = this.orderManagement.QueryOrderHypotest(this.orderId);
            //if (iHypotest == -1)
            //{
            //    MessageBox.Show(this.orderManagement.Err);
            //    return;
            //}

            ////非药品医嘱不显示皮试页
            //Neusoft.HISFC.Models.Order.Order o = this.orderManagement.QueryOneOrder(this.orderId);
            //if (o.Item.isPharmacy == false)
            //{
            //    ucTip1.Hypotest = 1;
            //}
            //ucTip1.Tip = this.orderManagement.QueryOrderNote(this.orderId);
            //ucTip1.Hypotest = iHypotest;
            //ucTip1.OKEvent += new myTipEvent(ucTip1_OKEvent);
            //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucTip1);

        }
        /// <summary>
        /// 批注事件
        /// </summary>
        private void ucTip1_OKEvent(string Tip, int Hypotest)
        {
            //int rowIndex = this.fpSpread1.Sheets[this.sheetIndex].ActiveRowIndex;
            //if (this.orderManagement.Updatefeedback(this.myPatientInfo.ID, this.orderId, Tip, Hypotest) == -1)
            //{
            //    MessageBox.Show(this.orderManagement.Err);
            //    this.orderManagement.Err = "";
            //    return;
            //}
            //this.fpSpread1.Sheets[this.sheetIndex].Cells[rowIndex, (int)ColEnum.ColHypoTest].Text = Hypotest.ToString();
            //this.SetTip(this.sheetIndex);
            //Neusoft.HISFC.BizLogic.RADT.InPatient pManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            //Neusoft.HISFC.Models.RADT.PatientInfo p = pManager.PatientQuery(this.myPatientInfo.ID);
            ////传送消息给科室
            //Neusoft.Common.Class.Message.SendMessage(p.Name + "有的医嘱有问题<" + Tip + ">需要更改。", p.PVisit.PatientLocation.Dept.ID, "22222");
        }
        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.S.GetHashCode())
            {
                if (this.fpSpread1.ActiveSheetIndex == 0)
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[0], LONGSETTINGFILENAME);
                else
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[1], SHORTSETTINGFILENAME);
            }
            else if (keyData.GetHashCode() == Keys.F12.GetHashCode())
            {
                this.fpSpread1.ActiveSheetIndex = (this.fpSpread1.ActiveSheetIndex + 1) % 2;
            }
            return base.ProcessDialogKey(keyData);
        }
        
        private void txtQuery_TextChanged(object sender, System.EventArgs e)
        {
            if (this.PatientInfo == null) return;
            if (this.PatientInfo.ID == "") return;
            if (this.dvLong == null || this.dvShort == null)
                return;
            string rowFilter = "医嘱名称 like '%{0}%'";
            string textQuery = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtQuery.Text.Trim());
            rowFilter = System.String.Format(rowFilter, textQuery);
            //长期医嘱
            if (this.fpSpread1.ActiveSheetIndex == 0)
                this.dvLong.RowFilter = rowFilter;
            //临时医嘱
            else
                this.dvShort.RowFilter = rowFilter;

            this.InitFP();
            this.RefreshOrderState();
            this.RefreshCombo();
            this.RefreshSubtblDisplay(0);
            this.RefreshSubtblDisplay(1);
        }

        #region  医嘱
        /// <summary>
        /// 通过医嘱状态过滤医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOderStatus_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Filter(this.cmbOderStatus.SelectedIndex);
        }
        /// <summary>
        /// 更新医嘱序号
        /// </summary>
        private void UpdateOrderSortID()
        {
            int colorderid = (int)ColEnum.ColOrderID;    //医嘱流水号    
            int sortid = (int)ColEnum.ColSort;
            string OrderID = null;//医嘱编号
            string SortID = null; //顺序号
            FarPoint.Win.Spread.SheetView sv = fpSpread1.ActiveSheet;//取得当前操作的有效的SHEET
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在更新医嘱序号...");
            Application.DoEvents();
            for (int i = 0; i < sv.Rows.Count; i++) //长期医嘱
            {
                OrderID = sv.Cells[i, colorderid].Text;//医嘱编号
                SortID = sv.Cells[i, sortid].Text; //顺序编号
                int Sortid = 0;
                if (sv.Cells[i, 2].Text.ToUpper() == "TRUE")
                {
                    
                    Sortid = Convert.ToInt32(SortID) - 10000;
                    
                    SortID = Sortid.ToString();
                }
                #region 医嘱序号更新
                if (orderManagement.UpdateOrderSortID(OrderID, SortID) == -1)
                {
                    MessageBox.Show("更新错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return;

                }

                #endregion
            }
            
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        
        /// <summary>
        /// 必要时判断是不是含有相同组合号，序号不同的医嘱
        /// </summary>
        /// <returns></returns>
        private int ifHaveNotSameCom()
        {
            int m = 0;
            for (int i = 0; i < fpSpread1.ActiveSheet.RowCount; i++)
            {
                string sortNum = fpSpread1.ActiveSheet.Cells[i, 1].Text;//当前选中行的序号
                string sComNum = fpSpread1.ActiveSheet.Cells[i, 7].Text;//当前选中行的组合号
                for (int j = 0; j < fpSpread1.ActiveSheet.RowCount; j++)
                {
                    string sortNum1 = fpSpread1.ActiveSheet.Cells[j, 1].Text;//当前选中行的序号
                    string sComNum1 = fpSpread1.ActiveSheet.Cells[j, 7].Text;//当前选中行的组合号
                    if (sComNum1 == sComNum)
                    {
                        if (sortNum1 != sortNum)
                        {
                            m += 1;
                        }
                    }
                }
            }

            if (m >= 1)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
     
        

        #endregion

        #region 列设置
        protected enum ColEnum
        {
            /// <summary>
            /// 护士备注
            /// </summary>
            ColNurMemo,
            /// <summary>
            /// 顺序号
            /// </summary>
            ColSort,//  updated by zlw 2006-4-18
            /// <summary>
            /// 重整
            /// </summary>
            ColInforming,
            /// <summary>
            /// 医嘱类型代码 期效 0 长嘱
            /// </summary>
            ColOrderTypeID,
            /// <summary>
            /// 医嘱类型
            /// </summary>
            ColOrderTypeName,
            /// <summary>
            /// 医嘱流水号
            /// </summary>
            ColOrderID,
            /// <summary>
            /// 医嘱状态
            /// </summary>
            ColOrderState,
            /// <summary>
            /// 组合号
            /// </summary>
            ColComboNo,
            /// <summary>
            /// 主药
            /// </summary>
            ColMainDrug,
            /// <summary>
            /// 医嘱名称
            /// </summary>
            ColItemName,
            /// <summary>
            /// 组标记
            /// </summary>
            ColComboFlag,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 总量
            /// </summary>
            ColQty,
            /// <summary>
            /// 总量单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 每次量
            /// </summary>
            ColDoseOnce,
            /// <summary>
            /// 单位
            /// </summary>
            ColDoseUnit,
            /// <summary>
            /// 付数
            /// </summary>
            ColHerbalQty,
            /// <summary>
            /// 频次编码
            /// </summary>
            ColFrequencyID,
            /// <summary>
            /// 频次
            /// </summary>
            ColFrequencyName,
            /// <summary>
            /// 用法编码
            /// </summary>
            ColUsageID,
            /// <summary>
            /// 用法
            /// </summary>
            ColUsageName,
            /// <summary>
            /// 大类
            /// </summary>
            ColSysType,
            /// <summary>
            /// 开始时间
            /// </summary>
            ColOrderBgn,
            /// <summary>
            /// 停止时间
            /// </summary>
            ColOrderEnd,
            /// <summary>
            /// 开立医生
            /// </summary>
            ColDoc,
            /// <summary>
            /// 执行科室编码
            /// </summary>
            ColExeDeptID,
            /// <summary>
            /// 执行科室
            /// </summary>
            ColExeDeptName,
            /// <summary>
            /// 加急
            /// </summary>
            ColEmEmergency,
            /// <summary>
            /// 检查部位
            /// </summary>
            ColCheckPart,
            /// <summary>
            /// 样本类型
            /// </summary>
            ColSample,
            /// <summary>
            /// 扣库科室编码
            /// </summary>
            ColStockDeptID,
            /// <summary>
            /// 扣库科室
            /// </summary>
            ColStockDeptName,
            /// <summary>
            /// 录入人编码
            /// </summary>
            ColUseRecID,
            /// <summary>
            /// 录入人
            /// </summary>
            ColUseRecName,
            /// <summary>
            /// 开立科室
            /// </summary>
            ColRecDept,
            /// <summary>
            /// 开立时间
            /// </summary>
            ColRecDate,
            /// <summary>
            /// 停止人编码
            /// </summary>
            ColDCOperID,
            /// <summary>
            /// 停止人
            /// </summary>
            ColDCOperName,
            /// <summary>
            /// 皮试标志
            /// </summary>
            ColHypoTest,
            /// <summary>
            /// 附材标志
            /// </summary>
            ColSubtbl
        }
        #endregion

        #region 重写
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
          

            try//获得所有科室
            {

                alDepts = deptManagement.GetDepartment();
            }
            catch { }
            //初始化farpoint
            dsAllLong = this.InitDataSet();
            dsAllShort = this.InitDataSet();

            //sheet0 ==长期 sheet1 ==临时
            this.fpSpread1.Sheets[0].DataSource = dsAllLong.Tables[0];
            this.fpSpread1.Sheets[1].DataSource = dsAllShort.Tables[0];

            this.fpSpread1.Sheets[0].DataAutoSizeColumns = false;
            this.fpSpread1.Sheets[1].DataAutoSizeColumns = false;

            this.fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.fpSpread1.SheetTabClick += new FarPoint.Win.Spread.SheetTabClickEventHandler(fpSpread1_SheetTabClick);
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);


            DateTime dt = this.orderManagement.GetDateTimeFromSysDateTime();
            this.InitFP();

            try
            {
                this.fpSpread1.ActiveSheetIndex = 0;
                this.cmbOderStatus.SelectedIndex = 1;//默认选有效的医嘱
            }
            catch { }

            #region 附材管理窗口
            ucSubtblManager1 = new ucSubtblManager();
            //皮试药{17A8C36D-DFA8-4d4e-A2AB-893AD5B3073A}
            ucTip = new ucTip();
            ucTip.IsCanModifyHypotest = true;
            this.ucTip.OKEvent += new myTipEvent(ucTip_OKEvent);
            this.DockingManager();
            this.ucSubtblManager1.ShowSubtblFlag += new ucSubtblManager.ShowSubtblFlagEvent(ucSubtblManager1_ShowSubtblFlag);
            #endregion
            //{EB125429-3FD1-4608-A99F-36F03E35299C}排除异常，判断tv是否为空 by guanyx
            if (this.tv != null)
            {
                this.tv.CheckBoxes = false;
                this.tv.ExpandAll();
            }
            return base.OnInit(sender, neuObject, param);
        }

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if(this.tv.CheckBoxes == true)
                this.tv.CheckBoxes = false;
            this.PatientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;
            
            return base.OnSetValue(neuObject, e);
        }
        #endregion

        private void fpSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            if (this.fpSpread1.ActiveSheetIndex == 0)
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[0], LONGSETTINGFILENAME);
            else
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[1], SHORTSETTINGFILENAME);
        }

        /// <summary>
        /// 已重整医嘱查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReOrderQueryed_Click(object sender, EventArgs e)
        {
            try
            {
                this.fpSpread1.Sheets[0].RowCount = 0;
                this.fpSpread1.Sheets[1].RowCount = 0;
                this.dsAllLong.Tables[0].Rows.Clear();
                this.dsAllShort.Tables[0].Rows.Clear();
            }
            catch { }
            if (this.myPatientInfo == null)
            {
                return;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询已重整医嘱,请稍候!");
            Application.DoEvents();

            if (this.ucSubtblManager1 != null)
            {
                this.ucSubtblManager1.PatientInfo = this.myPatientInfo;
            }

            //查询所有医嘱类型
            ArrayList alAllOrder = orderManagement.QueryOrder(this.myPatientInfo.ID);
            if (alAllOrder == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(orderManagement.Err);
                return;
            }
            //查询所有医嘱附材
            ArrayList alSub = this.orderManagement.QueryOrderSubtbl(this.myPatientInfo.ID);
            if (alSub == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(this.orderManagement.Err);
                return;
            }

            try
            {
                dsAllLong.Tables[0].Clear();
                dsAllShort.Tables[0].Clear();
                alAllOrder.AddRange(alSub);

                ArrayList al = new ArrayList();

                //屏蔽显示重整医嘱					
                foreach (Neusoft.HISFC.Models.Order.Order info in alAllOrder)
                {
                    if (info.Status == 4)
                        al.Add(info);
                }


                this.AddObjectsToTable(al);
                dvLong = new DataView(dsAllLong.Tables[0]);
                dvShort = new DataView(dsAllShort.Tables[0]);

                try
                {
                    dvLong.Sort = "顺序号 ASC , 组合号 ASC";
                    dvShort.Sort = "顺序号 ASC , 组合号 ASC";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("对显示医嘱根据顺序号、组合号排序发生错误" + ex.Message);
                    return;
                }

                this.fpSpread1.Sheets[0].DataSource = dvLong;
                this.fpSpread1.Sheets[1].DataSource = dvShort;


                this.InitFP();

                this.fpSpread1.Sheets[0].Columns[0, this.fpSpread1.Sheets[0].Columns.Count - 1].Locked = true;
                this.fpSpread1.Sheets[1].Columns[0, this.fpSpread1.Sheets[0].Columns.Count - 1].Locked = true;

            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(ex.Message);
                return;
            }

            this.Filter(this.cmbOderStatus.SelectedIndex);
            this.InitQueryCombox(this.sheetIndex);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }
    }
}

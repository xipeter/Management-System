using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FarPoint.Win.Spread;
using FarPoint.Win;
namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 医嘱审核的说]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucOrderConfirm : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucOrderConfirm()
        {
            InitializeComponent();
        }

        #region 变量
        private int LongOrderCount = 0; //长期医嘱数量
        private int ShortOrderCount = 0;//临时医嘱数量
        string strFileName = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath +
            Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "fpOrderConfirm.xml";
        DataTable dtMain;
        DataSet myDataSet;
        DataTable dtChild1;
        DataTable dtChild2;
        Neusoft.FrameWork.Models.NeuObject OrderId = new Neusoft.FrameWork.Models.NeuObject();
        Neusoft.FrameWork.Models.NeuObject ComboNo = new Neusoft.FrameWork.Models.NeuObject();
        protected FarPoint.Win.Spread.Cell CurrentCellName;
        string PatientId = "";
        /// <summary>
        /// 患者信息列表
        /// </summary>
        protected ArrayList alpatientinfos;
        protected Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();
        protected Neusoft.HISFC.BizProcess.Integrate.Order orderIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Order();
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        protected Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet nurseFeeBill = null;
        protected Neusoft.HISFC.BizProcess.Interface.Order.IApplyFeeSheet nurseApplyFeeBill=null;
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// IOP接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IHE.IOP iop = null;
        #region addby xuewj 2010-10-1 医嘱审核增加系统类别过滤 {93CA36C4-ABF1-459d-A94A-0AD81F0804C8}
        private Control activeBtn = null;
        private Color foreColor = Color.White;
        private Color backColor = Color.DarkBlue;
        private Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();
        #endregion
        #endregion
        private Neusoft.HISFC.Models.Base.MessType messType = Neusoft.HISFC.Models.Base.MessType.Y;
        /// <summary>
        /// 是否判断欠费，欠费是否提示
        /// </summary>
        [Category("控件设置"), Description("Y：判断欠费,不允许继续收费,M：判断欠费，提示是否继续收费,N：不判断欠费")]
        public Neusoft.HISFC.Models.Base.MessType MessageType
        {
            set
            {
                messType = value;
            }
            get
            {
                return messType;
            }
        }
        #region 模块1 初始化

        /// <summary>
        /// 初始化各个控件
        /// </summary>
        private void InitControl()
        {
            this.InitFp();
            ucSubtblManager1 = new ucSubtblManager();
            this.ucSubtblManager1.IsVerticalShow = true;
            this.DockingManager();
            this.ucSubtblManager1.ShowSubtblFlag += new ucSubtblManager.ShowSubtblFlagEvent(ucSubtblManager1_ShowSubtblFlag);
            #region addby xuewj 2010-10-5 增加StatusBarPanel {C0E71DA8-F246-4ff2-98CB-7EC72A767453}
            //base.OnStatusBarInfo(null, "(绿色：新开)(蓝色：审核)(黄色：执行)(红色：作废)");
            base.InsertStastusBarPanel(Properties.Resources.医保及医嘱状态, "", 1); 
            #endregion
            #region addby xuewj 2010-10-1 医嘱审核增加系统类别过滤 {93CA36C4-ABF1-459d-A94A-0AD81F0804C8}
            this.Initcontrolargument();
            ChangeBtnVisble(this.fpSpread.ActiveSheetIndex);
            this.ChangeBtnColor(this.btnAll);
            #endregion
        }

        void ucSubtblManager1_ShowSubtblFlag(string operFlag, bool isShowSubtblFlag, object sender)
        {
            string s = this.CurrentCellName.Text;
            if (!isShowSubtblFlag)
            {
                //更新医嘱标志
                if (s.Substring(0, 1) == "@")
                {
                    this.CurrentCellName.Text = s.Substring(1);
                }
            }
            else
            {
                if (s.Substring(0, 1) != "@")
                {
                    this.CurrentCellName.Text = "@" + s;
                }
            }
            if (this.dockingManager != null)
                this.dockingManager.HideAllContents();
        }
     
        
        /// <summary>
        /// 初始化fpTreeView1
        /// </summary>
        private void InitFp()
        {
            this.fpSpread.ChildViewCreated += new FarPoint.Win.Spread.ChildViewCreatedEventHandler(fpSpread_ChildViewCreated);
            
            this.fpSpread.Sheets[0].SheetName = "长期医嘱";
            this.fpSpread.Sheets[1].SheetName = "临时医嘱";
            this.fpSpread.Sheets[0].Columns[0].Visible = false;
            this.fpSpread.Sheets[0].Columns[1].Label = "审核［长期］";
            this.fpSpread.Sheets[0].Columns[2].Label = "患者姓名";
            this.fpSpread.Sheets[0].Columns[3].Label = "床号";
            this.fpSpread.Sheets[0].RowCount = 0;
            this.fpSpread.Sheets[0].ColumnCount = 4;
            this.fpSpread.Sheets[0].Columns[1].Width = 100;
            this.fpSpread.Sheets[0].Columns[2].Width = 100;
            this.fpSpread.Sheets[0].GrayAreaBackColor = Color.WhiteSmoke;


            this.fpSpread.Sheets[1].Columns[0].Visible = false;
            this.fpSpread.Sheets[1].Columns[1].Label = "审核［临时］";
            this.fpSpread.Sheets[1].Columns[2].Label = "患者姓名";
            this.fpSpread.Sheets[1].Columns[3].Label = "床号";
            this.fpSpread.Sheets[1].RowCount = 0;
            this.fpSpread.Sheets[1].ColumnCount = 4;
            this.fpSpread.Sheets[1].GrayAreaBackColor = Color.WhiteSmoke;
            this.fpSpread.Sheets[1].Columns[1].Width = 100;
            this.fpSpread.Sheets[1].Columns[2].Width = 100;
 
            this.fpSpread.Sheets[0].DataAutoSizeColumns = false;
            this.fpSpread.Sheets[1].DataAutoSizeColumns = false;

            this.fpSpread.Sheets[0].Rows.Get(-1).BackColor = Color.LightSkyBlue;
            this.fpSpread.Sheets[1].Rows.Get(-1).BackColor = Color.LightSkyBlue;

            this.fpSpread.Sheets[0].CellChanged+=new FarPoint.Win.Spread.SheetViewEventHandler(ucOrderConfirm_CellChanged);
            this.fpSpread.Sheets[1].CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(ucOrderConfirm_CellChanged);
            this.fpSpread.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread_CellClick);
            this.fpSpread.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread_CellDoubleClick);
            this.fpSpread.MouseUp += new MouseEventHandler(fpSpread_MouseUp);
            this.fpSpread.SheetTabClick += new FarPoint.Win.Spread.SheetTabClickEventHandler(fpSpread_SheetTabClick);
        }

       
        
        #endregion

        #region 模块2 属性
    
        /// <summary>
        /// 当前医嘱类型
        /// </summary>
        protected Neusoft.HISFC.Models.Order.EnumType myShowOrderType = Neusoft.HISFC.Models.Order.EnumType.LONG;
        /// <summary>
        /// 显示医嘱类型
        /// </summary>
        public Neusoft.HISFC.Models.Order.EnumType ShowOrderType
        {
            get
            {
                return this.myShowOrderType;
            }
            set
            {
                this.myShowOrderType = value;
                if (this.myShowOrderType == Neusoft.HISFC.Models.Order.EnumType.LONG)
                {
                    this.fpSpread.ActiveSheetIndex = 0;
                }
                else
                {
                    this.fpSpread.ActiveSheetIndex = 1;
                }
            }
        }

        /// <summary>
        /// 操作员变量
        /// </summary>
        protected Neusoft.HISFC.Models.Base.Employee myOperator;
        /// <summary>
        /// 当前操作员
        /// </summary>
        protected Neusoft.HISFC.Models.Base.Employee Operator
        {
            get
            {
                if (myOperator == null)
                    myOperator = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                return myOperator;
            }
        }
        #endregion

        #region 模块4 函数
      
        /// <summary>
        /// 查询医嘱
        /// </summary>
        private void QueryOrder()
        {
            if (this.alpatientinfos == null) return;
            this.fpSpread.ChildViewCreated += new FarPoint.Win.Spread.ChildViewCreatedEventHandler(fpSpread_ChildViewCreated);
            
            this.myShowOrderType = Neusoft.HISFC.Models.Order.EnumType.SHORT;//临时医嘱初始化
            this.fpSpread.Sheets[1].DataSource = CreateDataSetShort(this.alpatientinfos);

            this.myShowOrderType = Neusoft.HISFC.Models.Order.EnumType.LONG;//长期医嘱初始化
            this.fpSpread.Sheets[0].DataSource = CreateDataSetLong(this.alpatientinfos);

            this.fpSpread.Sheets[0].Columns[0].Visible = false;
            this.fpSpread.Sheets[0].Columns[2].Locked = true;
            this.fpSpread.Sheets[0].Columns[3].Locked = true;
            this.fpSpread.Sheets[0].GrayAreaBackColor = Color.WhiteSmoke;
            this.fpSpread.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;

            Classes.Function.DrawCombo(this.fpSpread.Sheets[0], 2, 5, 1);



            this.fpSpread.Sheets[1].Columns[0].Visible = false;
            this.fpSpread.Sheets[1].Columns[2].Locked = true;
            this.fpSpread.Sheets[1].Columns[3].Locked = true;
            this.fpSpread.Sheets[1].GrayAreaBackColor = Color.WhiteSmoke;
            this.fpSpread.Sheets[1].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;

            Classes.Function.DrawCombo(this.fpSpread.Sheets[1], 2, 5, 1);
            ////{92E9D8ED-A768-47b9-9C27-16FEFA990B84}
            SetRowColor(fpSpread.Sheets[1]);
            SetRowColor(fpSpread.Sheets[0]);
            this.ExpandAll();//展开

            this.refreshView();//刷新列表信息

            #region addby xuewj 2010-10-1 医嘱审核增加系统类别过滤 {93CA36C4-ABF1-459d-A94A-0AD81F0804C8}
            this.ChangeBtnColor(this.btnAll);
            this.ChangeBtnSize();
            #endregion
        }
        //{92E9D8ED-A768-47b9-9C27-16FEFA990B84}
        private void SetRowColor(FarPoint.Win.Spread.SheetView sv)
        {
            

            for (int i = 0; i < sv.RowCount; i++)
            {
                Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.radtIntegrate.GetPatientInfoByPatientNO(sv.Cells[i, 0].Text);
                string note = string.Empty;
                if (patientInfo != null)
                {
                    note = string.Format("预 交 金：{0}\n" + "费用总额：{1}\n" + "自费金额：{2}\n" + "余    额：{3}\n" + "警 戒 线：{4}",
                        patientInfo.FT.PrepayCost.ToString(),
                        patientInfo.FT.TotCost.ToString(),
                        patientInfo.FT.OwnCost.ToString(),
                        patientInfo.FT.LeftCost.ToString(),
                        patientInfo.PVisit.MoneyAlert.ToString());

                }

                string text = sv.Cells[i, 4].Text;
                if (text == "已欠费")
                {
                    sv.Cells[i,4].ForeColor = Color.Red;
                }
                sv.Cells[i, 4].Note = note;
               
               
                
            }
        }

        
      
        /// <summary>
        /// 展开全部节点
        /// </summary>
        private void ExpandAll()
        {
            for (int j = 0; j < this.fpSpread.Sheets.Count; j++)
            {
                for (int i = 0; i < this.fpSpread.Sheets[j].Rows.Count; i++)
                {
                    this.fpSpread.Sheets[j].ExpandRow(i, true);
                    SheetView sv = this.fpSpread.Sheets[j].GetChildView(i, 0);
                    this.SetChildViewStyle(sv);
                }
            }
        }

        /// <summary>
        /// 获得列序号
        /// </summary>
        /// <param name="name"></param>
        /// <param name="iSheet"></param>
        /// <returns></returns>
        private int GetColumnIndex(string name, int iSheet)
        {
            DataTable dt = null;
            if (iSheet == 0)
            {
                dt = dtChild1;
            }
            else
            {
                dt = dtChild2;
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == name) return i;
            }
            MessageBox.Show("缺少列" + Name);
            return -1;
        }


        /// <summary>
        /// 返回长期医嘱的dataSet
        /// </summary>
        /// <param name="alPatient"></param>
        /// <returns></returns>
        private DataSet CreateDataSetLong(ArrayList alPatient)
        {
            //定义传出DataSet
            myDataSet = new DataSet();
            myDataSet.EnforceConstraints = false;//是否遵循约束规则
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtBool = System.Type.GetType("System.Boolean");
            System.Type dtInt = System.Type.GetType("System.Int32");
            //定义表********************************************************
            //Main Table

            dtMain = myDataSet.Tables.Add("TableMain");
            //{96C7CE3E-CBD3-4862-A5F2-66DBB4DBF4CB}
            dtMain.Columns.AddRange(new DataColumn[] { new DataColumn("ID", dtStr), new DataColumn("审核", dtBool), new DataColumn("患者姓名", dtStr), new DataColumn("床号", dtStr),new DataColumn("是否欠费",dtStr) });
            //ChildTable1

            dtChild1 = myDataSet.Tables.Add("TableChild1");
            dtChild1.Columns.AddRange(new DataColumn[]{new DataColumn("ID",dtStr),new DataColumn("医嘱流水号", dtStr),
					new DataColumn("组合号", dtStr),new DataColumn("审核", dtBool),new DataColumn("医嘱名称", dtStr),
					new DataColumn("组", dtStr),new DataColumn("规格", dtStr),new DataColumn("执行科室", dtStr),//执行科室列 提前 {AFC6B462-3C6D-4ada-B74E-CAD4E9B402D5}  再次提前{8BD9B4E1-DFB7-45c3-B059-9AF6FB155590}
                    new DataColumn("单价",dtStr),//add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
                    new DataColumn("每次量", dtStr),
					new DataColumn("频次", dtStr),new DataColumn("用法", dtStr),new DataColumn("数量", dtStr),
				    new DataColumn("付数", dtStr),
                    new DataColumn("医嘱类型", dtStr),new DataColumn("急", dtBool),
					new DataColumn("开始时间", dtStr),new DataColumn("停止时间", dtStr),new DataColumn("开立医生", dtStr),
					new DataColumn("开立时间", dtStr),new DataColumn("停止医生", dtStr),
					new DataColumn("备注", dtStr),new DataColumn("顺序号", dtStr),new DataColumn("批注",dtStr),new DataColumn("状态",dtStr),new DataColumn("皮试",dtStr)});
            this.OrderId.ID = "1";
            this.ComboNo.ID = "2";


            this.fpSpread.Sheets[0].RowCount = 0;

            string tempCombNo = "";
            this.LongOrderCount = 0;
            //{96C7CE3E-CBD3-4862-A5F2-66DBB4DBF4CB}
            Neusoft.HISFC.BizProcess.Integrate.Fee feeManagement = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            string isOwnFee = string.Empty;
            for (int i = 0; i < alPatient.Count; i++)
            {
                Neusoft.HISFC.Models.RADT.PatientInfo p = (Neusoft.HISFC.Models.RADT.PatientInfo)alPatient[i];
                //查询未审核的医嘱--判断查询医嘱类型
                ArrayList al = orderManager.QueryIsConfirmOrder(p.ID, myShowOrderType, false);
                if (al.Count > 0)
                {
                    //{96C7CE3E-CBD3-4862-A5F2-66DBB4DBF4CB}
                    if (feeManagement.IsPatientLackFee(p) == true) //欠费患者
                    {
                        isOwnFee = "已欠费";
                    }
                    else
                    {
                        isOwnFee = "未欠费";
                    }
                    this.LongOrderCount = this.LongOrderCount + al.Count;
                    //{92E9D8ED-A768-47b9-9C27-16FEFA990B84}
                    dtMain.Rows.Add(new Object[] { p.ID, false, p.Name, p.PVisit.PatientLocation.Bed.ID.Substring(4), isOwnFee });//添加行
                    for (int j = 0; j < al.Count; j++)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order o = al[j] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                        if (o.IsPermission) //已经有权限的药品
                            o.Item.Name = "【√】" + o.Item.Name;

                        # region 同一个组合取一次就可以了  
                        if (tempCombNo != o.Combo.ID)
                        {
                            int count = this.orderManager.QuerySubtbl(o.Combo.ID).Count;
                            tempCombNo = o.Combo.ID;
                            if (count > 0)
                                o.Item.Name = "@" + o.Item.Name; //显示附材
                        }
                        # endregion
                        if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))//药品
                        {
                            Neusoft.HISFC.Models.Pharmacy.Item item = o.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                            
                            dtChild1.Rows.Add(new Object[] {o.Patient.ID,o.ID,o.Combo.ID,false,o.Item.Name,
															   "",o.Item.Specs,o.ExeDept.Name,//执行科室列 提前 {AFC6B462-3C6D-4ada-B74E-CAD4E9B402D5} 再次提前{8BD9B4E1-DFB7-45c3-B059-9AF6FB155590}
                                                               "",//add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
                                                               o.DoseOnce.ToString()+item.DoseUnit ,
															   o.Frequency.ID,o.Usage.Name,o.Item.Qty ==0 ? "":(o.Item.Qty.ToString()+o.Unit),
															   o.HerbalQty==0 ? "":o.HerbalQty.ToString(),
															   o.OrderType.Name,o.IsEmergency,
                                                               o.BeginTime.ToString("MM-dd HH:mm"),
															   o.EndTime.ToString("MM-dd HH:mm") == "01-01 00:00" ? "":o.EndTime.ToString("MM-dd HH:mm"),
                                                               o.ReciptDoctor.Name,o.MOTime,
															   o.DCOper.Name,o.Memo,o.SortID,o.Note,
                                                               Classes.Function.OrderStatus(o.Status),
                                                                Classes.Function.TransHypotest(o.HypoTest)});

                        }
                        else if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
                        {
                            
                            dtChild1.Rows.Add(new Object[] {o.Patient.ID,o.ID,o.Combo.ID,false,o.Item.Name,
															   "",o.Item.Specs,o.ExeDept.Name,//执行科室列 提前 {AFC6B462-3C6D-4ada-B74E-CAD4E9B402D5} 再次提前{8BD9B4E1-DFB7-45c3-B059-9AF6FB155590}
                                                               o.Item.Price.ToString(),//add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
                                                               "" ,
															   o.Frequency.ID,"",o.Item.Qty.ToString()+o.Unit,"",
															   o.OrderType.Name,o.IsEmergency,
                                                               o.BeginTime.ToString("MM-dd HH:mm"),
															   o.EndTime.ToString("MM-dd HH:mm") == "01-01 00:00" ? "":o.EndTime.ToString("MM-dd HH:mm"),
                                                               o.ReciptDoctor.Name,o.MOTime,
															   o.DCOper.Name,o.Memo,o.SortID,o.Note,
                                                               Classes.Function.OrderStatus(o.Status),
                                                                Classes.Function.TransHypotest(o.HypoTest)});
                        }
                    }
                }
            }
            //表关联显示
            myDataSet.Relations.Add("TableChild1", dtMain.Columns["ID"], dtChild1.Columns["ID"]);
           
            return myDataSet;
        }
        /// <summary>
        /// 返回临时医嘱的DataSet
        /// </summary>
        /// <param name="alPatient"></param>
        /// <returns></returns>
        private DataSet CreateDataSetShort(ArrayList alPatient)
        {
            DataTable dtMain;
            DataSet myDataSet;
            //ataTable dtChild1;
            //定义传出DataSet
            myDataSet = new DataSet();
            myDataSet.EnforceConstraints = false;//是否遵循约束规则
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtBool = System.Type.GetType("System.Boolean");
            System.Type dtInt = System.Type.GetType("System.Int32");
            //定义表********************************************************
            //Main Table

            dtMain = myDataSet.Tables.Add("TableMain");
            //{96C7CE3E-CBD3-4862-A5F2-66DBB4DBF4CB}
            dtMain.Columns.AddRange(new DataColumn[] { new DataColumn("ID", dtStr), new DataColumn("审核", dtBool), new DataColumn("患者姓名", dtStr), new DataColumn("床号", dtStr),new DataColumn("是否欠费",dtStr)});
            //ChildTable1

            dtChild2 = myDataSet.Tables.Add("TableChild1");
            dtChild2.Columns.AddRange(new DataColumn[]{new DataColumn("ID",dtStr),new DataColumn("医嘱流水号", dtStr),
														  new DataColumn("组合号", dtStr),new DataColumn("审核", dtBool),new DataColumn("医嘱名称", dtStr),
														  new DataColumn("组", dtStr),new DataColumn("规格", dtStr),new DataColumn("执行科室", dtStr),//执行科室列 提前 {AFC6B462-3C6D-4ada-B74E-CAD4E9B402D5} 再次提前{8BD9B4E1-DFB7-45c3-B059-9AF6FB155590}
                                                          new DataColumn("单价",dtStr),//add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
                                                          new DataColumn("每次量", dtStr),
														  new DataColumn("频次", dtStr),new DataColumn("用法", dtStr),new DataColumn("数量", dtStr),
														  new DataColumn("付数", dtStr), 
                                                          new DataColumn("医嘱类型", dtStr),new DataColumn("急", dtBool),
														  new DataColumn("开始时间", dtStr),new DataColumn("停止时间", dtStr),new DataColumn("开立医生", dtStr),
														  new DataColumn("开立时间", dtStr),new DataColumn("停止医生", dtStr),
														  new DataColumn("备注", dtStr),new DataColumn("顺序号", dtStr),new DataColumn("批注",dtStr),new DataColumn("状态",dtStr),new DataColumn("皮试",dtStr)});
            this.OrderId.ID = "1";
            this.ComboNo.ID = "2";
           
            
            this.fpSpread.Sheets[1].RowCount = 0;
            
            string tempCombNo = "";
            this.ShortOrderCount = 0;
            Neusoft.HISFC.BizProcess.Integrate.Fee feeManagement = new Neusoft.HISFC.BizProcess.Integrate.Fee ();
            for (int i = 0; i < alPatient.Count; i++)
            {
                //{96C7CE3E-CBD3-4862-A5F2-66DBB4DBF4CB}
                string isOwnFee = string.Empty;
                Neusoft.HISFC.Models.RADT.PatientInfo p = (Neusoft.HISFC.Models.RADT.PatientInfo)alPatient[i];

               
                //查询未审核的医嘱--判断查询医嘱类型
                ArrayList al = this.orderManager.QueryIsConfirmOrder(p.ID, myShowOrderType, false);	//查询未审核的医嘱
                if (al.Count > 0)
                {
                    //{96C7CE3E-CBD3-4862-A5F2-66DBB4DBF4CB}
                    if (feeManagement.IsPatientLackFee(p) == true) //欠费患者
                    {
                        isOwnFee = "已欠费";
                    }
                    else
                    {
                        isOwnFee = "未欠费";
                    }
                    this.ShortOrderCount = this.ShortOrderCount + al.Count;

                    //{C3C32101-297D-40c1-97BA-46938537002B}  床位号截取
                    string bedNO = p.PVisit.PatientLocation.Bed.ID;
                    if (bedNO.Length > 4)
                    {
                        bedNO = bedNO.Substring( 4 );
                    }
                    //{92E9D8ED-A768-47b9-9C27-16FEFA990B84}
                    dtMain.Rows.Add( new Object[] { p.ID, false, p.Name, bedNO ,isOwnFee} );//添加行
                    for (int j = 0; j < al.Count; j++)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order o = al[j] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                        if (o.IsPermission) //
                            o.Item.Name = "【√】" + o.Item.Name;

                       
                        # region 同一个组合取一次就可以了 
                        if (tempCombNo != o.Combo.ID)
                        {
                            int count = this.orderManager.QuerySubtbl(o.Combo.ID).Count;
                            tempCombNo = o.Combo.ID;
                            if (count > 0)
                                o.Item.Name = "@" + o.Item.Name; //显示附材
                        }
                        # endregion
                        if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                        {
                            Neusoft.HISFC.Models.Pharmacy.Item item = o.Item as Neusoft.HISFC.Models.Pharmacy.Item;

                            dtChild2.Rows.Add(new Object[] {o.Patient.ID,o.ID,o.Combo.ID,false,o.Item.Name,
															   "",o.Item.Specs,o.ExeDept.Name,//执行科室列 提前 {AFC6B462-3C6D-4ada-B74E-CAD4E9B402D5} 再次提前{8BD9B4E1-DFB7-45c3-B059-9AF6FB155590}
                                                               "",//add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
                                                               o.DoseOnce.ToString()+item.DoseUnit ,
															   o.Frequency.ID,o.Usage.Name,o.Item.Qty ==0 ? "":(o.Item.Qty.ToString()+o.Unit),
															   o.HerbalQty==0 ? "":o.HerbalQty.ToString(),              
															   o.OrderType.Name,o.IsEmergency,
                                                                  o.BeginTime.ToString("MM-dd HH:mm"),
															  o.EndTime.ToString("MM-dd HH:mm") == "01-01 00:00" ? "":o.EndTime.ToString("MM-dd HH:mm"),
                                                               o.ReciptDoctor.Name,o.MOTime,
															   o.DCOper.Name,o.Memo,o.SortID,o.Note,
                                                                Classes.Function.OrderStatus(o.Status),
                                                                Classes.Function.TransHypotest(o.HypoTest) });

                        }
                        else if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
                        {
                            dtChild2.Rows.Add(new Object[] {o.Patient.ID,o.ID,o.Combo.ID,false,o.Item.Name,
															   "",o.Item.Specs,	o.ExeDept.Name,//执行科室列 提前 {AFC6B462-3C6D-4ada-B74E-CAD4E9B402D5} 再次提前{8BD9B4E1-DFB7-45c3-B059-9AF6FB155590}
                                                               o.Item.Price.ToString(),//add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
                                                               "" ,
															   o.Frequency.ID,"",o.Item.Qty.ToString()+o.Unit,"",
                                                               o.OrderType.Name,o.IsEmergency,
                                                                o.BeginTime.ToString("MM-dd HH:mm"),
															   o.EndTime.ToString("MM-dd HH:mm") == "01-01 00:00" ? "":o.EndTime.ToString("MM-dd HH:mm"),
                                                               o.ReciptDoctor.Name,o.MOTime,
															   o.DCOper.Name,o.Memo,o.SortID,o.Note,
                                                                 Classes.Function.OrderStatus(o.Status),
                                                                Classes.Function.TransHypotest(o.HypoTest)});
                        }
                        
                    }
                }
            }
            //关联
            myDataSet.Relations.Add("TableChild1", dtMain.Columns["ID"], dtChild2.Columns["ID"]);
            
            return myDataSet;
        }

        public void SetChildViewStyle(FarPoint.Win.Spread.SheetView sv)
        {
            this.SetChildViewStyle(sv, true);
        }
        public void SetChildViewStyle(FarPoint.Win.Spread.SheetView sv, bool SetChildViewStyle)
        {
            try
            {
                //Make the header font italic
                sv.ColumnHeader.DefaultStyle.Font = this.fpSpread.Font;
                sv.ColumnHeader.DefaultStyle.Border = new EmptyBorder();
                sv.ColumnHeader.DefaultStyle.BackColor = Color.White;
                sv.ColumnHeader.DefaultStyle.ForeColor = Color.Black;
                //Change the sheet corner color
                sv.SheetCornerStyle.BackColor = Color.White;
                sv.SheetCornerStyle.Border = new EmptyBorder();

                //Clear the autotext
                sv.RowHeader.AutoText = HeaderAutoText.Blank;

                sv.RowHeader.DefaultStyle.BackColor = Color.Honeydew;
                sv.RowHeader.DefaultStyle.ForeColor = Color.Black;

                sv.ColumnHeaderVisible = true;
                sv.RowHeaderVisible = SetChildViewStyle;
                sv.RowHeaderAutoText = HeaderAutoText.Numbers;
                for (int i = 0; i < sv.RowCount; i++) sv.Rows[i].Height = 20;
                sv.CellChanged += new SheetViewEventHandler(sv_CellChanged);
            }
            catch { }

            
            sv.DataAutoSizeColumns = false;
            sv.OperationMode = OperationMode.SingleSelect;

           
            //hide or show the ID column
            sv.Columns[0].Visible = false;
            sv.Columns[1].Visible =false;
            sv.Columns[2].Visible =false;
            sv.Columns[3].Visible =true;
            sv.Columns[3].Width = 32;
            sv.Columns[3].Locked = true;
            sv.Columns[4].Width = 200;
            sv.Columns[4].Locked = true;
            sv.Columns[5].Width = 15;
            sv.Columns[5].Locked = true;
            sv.Columns[6].Width = 62;
            sv.Columns[6].Locked = true;
            #region add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
            //sv.Columns[7].Width = 48;
            //sv.Columns[7].Locked = true;
            //sv.Columns[8].Width = 37;
            //sv.Columns[8].Locked = true;
            //sv.Columns[9].Width = 33;
            //sv.Columns[9].Locked = true;
            //sv.Columns[10].Width = 35;
            //sv.Columns[10].Locked = true;
            //sv.Columns[11].Width = 33;
            //sv.Columns[11].Locked = true;
            //sv.Columns[12].Width = 59;
            //sv.Columns[12].Locked = true;
            //sv.Columns[13].Width = 19;
            //sv.Columns[13].Visible = false;
            //sv.Columns[14].Width = 63;
            //sv.Columns[14].Locked = true;
            //sv.Columns[15].Width = 63;
            //sv.Columns[15].Locked = true;
            //sv.Columns[16].Width = 59;
            //sv.Columns[16].Locked = true;
            //sv.Columns[17].Width = 59;
            //sv.Columns[17].Locked = true;
            //sv.Columns[18].Width = 59;
            //sv.Columns[18].Locked = true;

            sv.Columns[7].Width = 48;
            sv.Columns[7].Locked = true;
            sv.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Right;
            sv.Columns[8].Width = 48;
            sv.Columns[8].Locked = true;
            sv.Columns[9].Width = 37;
            sv.Columns[9].Locked = true;
            sv.Columns[10].Width = 33;
            sv.Columns[10].Locked = true;
            sv.Columns[11].Width = 35;
            sv.Columns[11].Locked = true;
            sv.Columns[12].Width = 33;
            sv.Columns[12].Locked = true;
            sv.Columns[13].Width = 59;
            sv.Columns[13].Locked = true;
            sv.Columns[14].Width = 63;
            sv.Columns[14].Locked = true;
            sv.Columns[15].Width = 19;
            sv.Columns[15].Visible = false;
            sv.Columns[16].Width = 63;
            sv.Columns[16].Locked = true;
            sv.Columns[17].Width = 59;
            sv.Columns[17].Locked = true;
            sv.Columns[18].Width = 59;
            sv.Columns[18].Locked = true;
            sv.Columns[19].Width = 59;
            sv.Columns[19].Locked = true; 
            #endregion
        }


        protected void refreshView()
        {
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < this.fpSpread.Sheets[k].Rows.Count; i++) //长期医嘱-临时医嘱
                {
                    this.fpSpread.BackColor = System.Drawing.Color.Azure;
                    try
                    {
                        FarPoint.Win.Spread.SheetView sv = this.fpSpread.Sheets[k].GetChildView(i, 0);
                        if (sv != null)
                        {
                            #region add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
                            //sv.Columns[7].Font = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
                            //sv.Columns[8].Font = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
                            sv.Columns[8].Font = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
                            sv.Columns[9].Font = new Font("Arial", 10, System.Drawing.FontStyle.Bold); 
                            #endregion
                            for (int j = 0; j < sv.Rows.Count; j++)
                            {//医嘱项目
                                #region add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
                                //string note = sv.Cells[j, 22].Text;//批注
                                string note = sv.Cells[j, 23].Text;//批注
                                //if (sv.Cells.Get(j, 23).Text == "停止/取消") 
                                if (sv.Cells.Get(j, 24).Text == "停止/取消") sv.Rows[j].BackColor = Color.FromArgb(255, 222, 222);//医嘱状态，医嘱作废审核
                                sv.SetNote(j, 4, note);
                                if ((bool)sv.Cells[j, 15].Value)
                                //if ((bool)sv.Cells[j, 13].Value)
                                {
                                    sv.Rows[j].Label = "急";
                                    sv.RowHeader.Rows[j].BackColor = System.Drawing.Color.Pink;
                                }
                                int hypotest = 0;
                                //if (sv.Cells[j, 24].Text == "阳性")
                                if (sv.Cells[j, 25].Text == "阳性")
                                {
                                    hypotest = 3;
                                }
                                //else if (sv.Cells[j, 24].Text == "阴性")
                                else if (sv.Cells[j, 25].Text == "阴性")
                                {
                                    hypotest = 4;
                                } 
                                #endregion
                                //int hypotest = Neusoft.FrameWork.Function.NConvert.ToInt32(sv.Cells[j, 24].Text);//皮试
                                string sTip = "需不需皮试";//Function.TipHypotest;
                                if (sv.Cells[j, 4].Text.Length > 3)
                                {
                                    if ((sv.Cells[j, 4].Text.Substring(sv.Cells[j, 4].Text.Length - 3) == "［＋］"
                                    || sv.Cells[j, 4].Text.Substring(sv.Cells[j, 4].Text.Length - 3) == "［－］"))
                                    {
                                        sv.Cells[j, 4].Text = sv.Cells[j, 4].Text.Substring(0, sv.Cells[j, 4].Text.Length - 3);
                                    }
                                }
                                try
                                {
                                    if (sv.Cells[j, 4].Text.Length > 3)
                                        if (sv.Cells[j, 4].Text.Substring(sv.Cells[j, 4].Text.Length - sTip.Length, sTip.Length) == sTip)
                                            sv.Cells[j, 4].Text = sv.Cells[j, 4].Text.Substring(0, sv.Cells[j, 4].Text.Length - sTip.Length);
                                }
                                catch { }
                                sv.Cells[j, 4].ForeColor = Color.Black;
                                if (hypotest == 3)
                                {
                                    sv.Cells[j, 4].Text += "［＋］";//皮试
                                    sv.Cells[j, 4].ForeColor = Color.Red;
                                }
                                else if (hypotest == 4)
                                {
                                    sv.Cells[j, 4].Text += "［－］";
                                }
                                else if (hypotest == 2)
                                {
                                }

                                //显示顺序号
                                if (sv.RowHeader.Cells[j, 0].Text != "急")
                                    //sv.RowHeader.Cells[j, 0].Text = sv.Cells[j, 21].Text;
                                    sv.RowHeader.Cells[j, 0].Text = sv.Cells[j, 22].Text;//add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("刷新医嘱备注信息出错！", "Sorry");
                    }
                }
            }
        }
        
        #endregion

        #region 多太太
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            tv = sender as TreeView;
            if (tv != null && tv.CheckBoxes == false)
                tv.CheckBoxes = true;
            this.InitControl();

            return null;
        }
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (tv != null && this.tv.CheckBoxes == false)
            {
                tv.CheckBoxes = true;
            }
            #region {07650785-3A5B-4ecf-AFC4-1FD7E6366906} 选中患者即显示患者医嘱by guanyx
            if (e != null && e.Tag.ToString() != "In" )
            {
                ArrayList patientList = new ArrayList();
                patientList.Add((Neusoft.HISFC.Models.RADT.PatientInfo)e.Tag);
                this.SetValues(patientList, e);
                this.QueryOrder();
            }
            #endregion
            return base.OnSetValue(neuObject, e);
        }
        /// <summary>
        /// 患者付给我了
        /// </summary>
        /// <param name="alValues"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValues(ArrayList alValues, object e)
        {
            this.alpatientinfos = alValues;
            this.QueryOrder();
            #region {839D3A8A-49FA-4d47-A022-6196EB1A5715}
            if (this.tv != null && this.tv.CheckBoxes)
            {
                foreach (TreeNode parentNode in tv.Nodes)
                {
                    foreach (TreeNode node in parentNode.Nodes)
                    {
                        if (node.Tag is Neusoft.HISFC.Models.RADT.PatientInfo)
                        {
                            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = node.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
                            if (node.Checked)
                            {
                                switch (patientInfo.Sex.ID.ToString())
                                {
                                    case "F":
                                        //男
                                        if (patientInfo.ID.IndexOf("B") > 0)
                                            node.ImageIndex = 10;	//婴儿女
                                        else
                                            node.ImageIndex = 6;	//成年女
                                        break;
                                    case "M":
                                        if (patientInfo.ID.IndexOf("B") > 0)
                                            node.ImageIndex = 8;	//婴儿男
                                        else
                                            node.ImageIndex = 4;	//成年男
                                        break;
                                    default:
                                        node.ImageIndex = 4;
                                        break;
                                }
                                Neusoft.HISFC.Components.Common.Classes.Function.DelLabel((node.Tag as Neusoft.HISFC.Models.RADT.PatientInfo).ID);
                            }
                        }
                    }
                }
            }
            #endregion
            return 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            if (Neusoft.FrameWork.WinForms.Classes.Function.Msg("是否确定要保存?", 422) == DialogResult.No)
            {
                return -1;
            }
            this.fpSpread.StopCellEditing();//{7B757642-336B-4384-8DE4-9DFE4E4DCD1F}加入停止编辑
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            
            Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
            for (int i = 0; i < this.fpSpread.Sheets[0].Rows.Count; i++) //长期医嘱
            {
                #region 医嘱处理
                string strInpatientNo = this.fpSpread.Sheets[0].Cells[i, 0].Text;//当前的患者
                string strName = this.fpSpread.Sheets[0].Cells[i, 2].Text;//当前的患者

                string strComboNo = "";
                //当前患者的医嘱列表页 sv
                FarPoint.Win.Spread.SheetView sv = this.fpSpread.Sheets[0].GetChildView(i, 0);
                ArrayList alOrders = new ArrayList();
                Neusoft.HISFC.Models.RADT.PatientInfo p = radtIntegrate.GetPatientInfomation(strInpatientNo);
                if (sv != null)
                {
                    for (int j = 0; j < sv.Rows.Count; j++)//医嘱项目
                    {
                        if (sv.Cells[j, 3].Text.ToUpper() == "TRUE")
                        {
                            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在处理长期医嘱...");
                            Application.DoEvents();
                            string orderid = sv.Cells[j, int.Parse(OrderId.ID)].Text;//医嘱项目处理
                            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.orderManager.QueryOneOrder(orderid);                                                                                 
                            if (order == null)
                            {
                                orderIntegrate.fee.Rollback();
                                //Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                MessageBox.Show("医嘱已经发生变化，请刷新屏幕！");
                                return -1;
                            }

                            order.Patient.Name = strName;

                            alOrders.Add(order);
                        }

                    }
                    if (orderIntegrate.SaveChecked(p, alOrders, true, empl.Nurse.ID) == -1)
                    {
                        orderIntegrate.fee.Rollback();
                       // Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(this.orderIntegrate.Err);
                        return -1;
                    }
                    else
                    {
                        orderIntegrate.fee.Commit();
                        //Neusoft.FrameWork.Management.Transaction 
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        this.orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        this.orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    }
                }
                #endregion
            }
            #region {2D97BF3B-C09C-433d-9C8C-F80CC2751261}
            DateTime beginDate = this.orderManager.GetDateTimeFromSysDateTime();
            DateTime endDate = beginDate;
            string paramRecipeNo = "";
            string paramOrderNo = "";
            string deptCode=((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
            #endregion

            #region donggq-20101109-申请单过滤-{755769B0-C65F-4eb4-A6BA-80F0E4843B32}

            Neusoft.HISFC.BizProcess.Integrate.Manager mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alApplys = mgr.GetConstantList("CheckPrintApply");
            ArrayList alExecs = new ArrayList();
            if (alApplys != null && alApplys.Count > 0)
            {
                for (int i = 0; i < alApplys.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject tmp = alApplys[i] as Neusoft.FrameWork.Models.NeuObject;
                    alExecs.Add(tmp.Memo);
                }
            }

            #endregion

            for (int i = 0; i < this.fpSpread.Sheets[1].Rows.Count; i++) //临时医嘱
            {
                #region 医嘱处理
                string strInpatientNo = this.fpSpread.Sheets[1].Cells[i, 0].Text;//当前的患者
                string strName = this.fpSpread.Sheets[1].Cells[i, 2].Text;//当前的患者

                string strComboNo = "";
                //当前患者的医嘱列表页 sv
                FarPoint.Win.Spread.SheetView sv = this.fpSpread.Sheets[1].GetChildView(i, 0);
                ArrayList alOrders = new ArrayList();
                Neusoft.HISFC.Models.RADT.PatientInfo p = radtIntegrate.GetPatientInfomation(strInpatientNo);
                if (sv != null)
                {
                    for (int j = 0; j < sv.Rows.Count; j++)//医嘱项目
                    {
                        if (sv.Cells[j, 3].Text.ToUpper() == "TRUE")
                        {
                            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在处理临时医嘱...");
                            Application.DoEvents();
                            string orderid = sv.Cells[j, int.Parse(OrderId.ID)].Text;//医嘱项目处理
                            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.orderManager.QueryOneOrder(orderid);                                                       
                            if (order == null)
                            {
                                orderIntegrate.fee.Rollback();
                                //Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                MessageBox.Show("医嘱已经发生变化，请刷新屏幕！");
                                return -1;
                            }

                            order.Patient.Name = strName;

                            alOrders.Add(order);

                            if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.UnDrug)
                            {
                                #region addby xuewj 2010-10-5 描述医嘱取不到基本信息 {46F66712-91CF-42bf-BB95-BE6782764AAC}
                                if (order.Item.ID != "999")//描述医嘱不再重新取信息
                                {
                                    Neusoft.HISFC.Models.Fee.Item.Undrug undrugInfo = this.feeIntegrate.GetItem(order.Item.ID);
                                    if (undrugInfo == null || undrugInfo.ID == "")
                                    {
                                        orderIntegrate.fee.Rollback();
                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        MessageBox.Show("查询非药品" + order.Item.Name + "信息失败!" + this.feeIntegrate.Err);
                                        return -1; ;
                                    }

                                    if (undrugInfo.IsNeedConfirm && !paramOrderNo.Contains(order.ID)
                                        && order.ExeDept.ID != order.Patient.PVisit.PatientLocation.Dept.ID
                                        && order.Status == 0)
                                    {
                                        #region donggq-20101109-申请单过滤-{755769B0-C65F-4eb4-A6BA-80F0E4843B32}

                                        if (!alExecs.Contains(order.ExeDept.ID))
                                        {
                                            paramOrderNo = "'" + order.ID + "'," + paramOrderNo;
                                        }

                                        #endregion
                                    }
                                } 
                                #endregion
                            }
                        }

                    }
                    orderIntegrate.MessageType = messType;
                    //{2D97BF3B-C09C-433d-9C8C-F80CC2751261}
                    //if (orderIntegrate.SaveChecked(p, alOrders, false, empl.Nurse.ID) == -1)
                    string tempParamRecipeNo="";
                    if (orderIntegrate.SaveCheckedForShort(p, alOrders, false, empl.Nurse.ID, ref tempParamRecipeNo) == -1)
                    {
                        //orderIntegrate.fee.Rollback();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(this.orderIntegrate.Err);
                        return -1;
                    }
                    else
                    {
                        orderIntegrate.fee.Commit();
                        //Neusoft.FrameWork.Management.Transaction 
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        this.orderIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        this.orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    }

                    paramRecipeNo += tempParamRecipeNo;//{2D97BF3B-C09C-433d-9C8C-F80CC2751261}

                    #region addby xuewj 2010-03-12 HL7消息 send：op---receiver：of

                    if (this.iop == null)
                    {
                        this.iop = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IOP)) as Neusoft.HISFC.BizProcess.Interface.IHE.IOP;
                    }
                    if(this.iop!=null)
                    {
                        this.iop.PlaceOrder(alOrders);
                    }

                    #endregion
                }
                #endregion

                
            }
            endDate = this.orderManager.GetDateTimeFromSysDateTime(); //{2D97BF3B-C09C-433d-9C8C-F80CC2751261}
            orderIntegrate.fee.Commit();

            #region 调用病区记账单 {2D97BF3B-C09C-433d-9C8C-F80CC2751261}
            if (paramRecipeNo != "")
            {
                MessageBox.Show("即将打印——记账单，请确认打印机已就位？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                paramRecipeNo = paramRecipeNo.Substring(0, paramRecipeNo.Length - 1);//去掉后面的逗号

                if (this.nurseFeeBill == null)
                {
                    this.nurseFeeBill = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet)) as Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet;
                }
                if (this.nurseFeeBill != null)
                {
                    this.nurseFeeBill.NurseFeeBill(beginDate, endDate, paramRecipeNo);
                }
            }
            #endregion 
            #region 调用病区记账申请单 {2D97BF3B-C09C-433d-9C8C-F80CC2751261}
            if (paramOrderNo != "")
            {
                MessageBox.Show("即将打印——记账申请单，请确认打印机已就位？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                paramOrderNo = paramOrderNo.Substring(0, paramOrderNo.Length - 1);//去掉后面的逗号

                if (this.nurseApplyFeeBill == null)
                {
                    this.nurseApplyFeeBill = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Order.IApplyFeeSheet)) as Neusoft.HISFC.BizProcess.Interface.Order.IApplyFeeSheet;
                }
                if (this.nurseApplyFeeBill != null)
                {
                    this.nurseApplyFeeBill.NurseFeeBill(paramOrderNo);
                }
            }
            #endregion 
            //Neusoft.FrameWork.Management.PublicTrans.Commit();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            this.QueryOrder();
            return 0;
        }
        #endregion

        #region 事件
        void sv_CellChanged(object sender, SheetViewEventArgs e)
        {

        }

        /// <summary>
        /// 该函数没有起作用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void fpSpread_ChildViewCreated(object sender, FarPoint.Win.Spread.ChildViewCreatedEventArgs e)
        {
            this.SetChildViewStyle(e.SheetView);
        }

        void fpSpread_SheetTabClick(object sender, FarPoint.Win.Spread.SheetTabClickEventArgs e)
        {
            #region addby xuewj 2010-10-1 医嘱审核增加系统类别过滤 {93CA36C4-ABF1-459d-A94A-0AD81F0804C8}
            this.ChangeBtnVisble(e.SheetTabIndex); 
            #endregion
        }

        void fpSpread_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        void fpSpread_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.RowHeader || e.Row < 0)
                return;

            //判断当前的停靠窗口是否已显示 如未显示 则显示停靠窗口
            try
            {
                if (e.View.Sheets[0].Columns[2].Label == "组合号") //是childtable1
                {
                    if (this.content != null && this.content.Visible == false)
                    {
                        if (wc == null && this.dockingManager != null)
                        {
                            wc = this.dockingManager.AddContentWithState(content, Crownwood.Magic.Docking.State.DockRight);
                            this.dockingManager.AddContentToWindowContent(content, wc);
                        }
                        if (this.dockingManager != null)
                            this.dockingManager.ShowContent(this.content);
                    }
                    if (this.ucSubtblManager1 != null && !e.RowHeader && !e.ColumnHeader)		//点击非列标题与行标题
                    {
                        ucSubtblManager1.OrderID = this.OrderId.Name;
                        ucSubtblManager1.ComboNo = this.ComboNo.Name;
                        this.CurrentCellName = e.View.Sheets[0].Cells[e.View.Sheets[0].ActiveRowIndex, 4];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        FarPoint.Win.Spread.CellClickEventArgs cellClickEvent = null;
        int curRow = 0;
        void fpSpread_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row < 0) return;
            if (e.Column > 0)
            {
                try
                {
                    int active = this.fpSpread.ActiveSheetIndex;   
                    if (e.View.Sheets.Count <= active) active = 0;
                    curRow = active;
                    if (e.View.Sheets[active].Columns[2].Label == "组合号") //子表1
                    {
                        if (e.Button == MouseButtons.Left) //左键
                        {
                            this.OrderId.Name = e.View.Sheets[active].Cells[e.Row, int.Parse(this.OrderId.ID)].Text;
                            this.ComboNo.Name = e.View.Sheets[active].Cells[e.Row, int.Parse(this.ComboNo.ID)].Text;
                            this.PatientId = e.View.Sheets[active].Cells[e.Row, 0].Text;//住院流水号

                            if (e.View.Sheets[active].Cells[e.Row, 3].Text.ToUpper() == "TRUE")
                            {
                                e.View.Sheets[active].Cells[e.Row, 3].Text = "False";
                                e.View.Sheets[active].Cells[e.Row, 3].BackColor = Color.White;
                            }
                            else
                            {
                                e.View.Sheets[active].Cells[e.Row, 3].Text = "True";
                                e.View.Sheets[active].Cells[e.Row, 3].BackColor = Color.Blue;
                            }
                            //更新组合的医嘱选择信息
                            for (int i = 0; i < e.View.Sheets[active].RowCount; i++)
                            {
                                if (e.View.Sheets[active].Cells[i, int.Parse(this.ComboNo.ID)].Text == this.ComboNo.Name 
                                    && i != e.Row)
                                {
                                    e.View.Sheets[active].Cells[i, 3].Text = e.View.Sheets[active].Cells[e.Row, 3].Text;
                                    e.View.Sheets[active].Cells[i, 3].BackColor = e.View.Sheets[active].Cells[e.Row, 3].BackColor;
                                }
                            }
                        }
                        else//右键
                        {
                            this.OrderId.Name = e.View.Sheets[active].Cells[e.Row, int.Parse(this.OrderId.ID)].Text;
                            string strItemName = e.View.Sheets[active].Cells[e.Row, 5].Text;
                            this.PatientId = e.View.Sheets[active].Cells[e.Row, 0].Text;//住院流水号 
                            cellClickEvent = e;
                            ContextMenu menu = new ContextMenu();
                            MenuItem mnuTip = new MenuItem("批注");//批注
                            mnuTip.Click += new EventHandler(mnuTip_Click);

                            MenuItem mnuChangeDept = new MenuItem("修改取药科室");//修改取药科室
                            mnuChangeDept.Click+=new EventHandler(mnuChangeDept_Click);
                            
                            menu.MenuItems.Add(mnuTip);
                            menu.MenuItems.Add(mnuChangeDept);
                            this.fpSpread.ContextMenu = menu;
                            //Function.PopMenu(menu, obj.Item.ID, false);

                            
                            //ContextMenu menu = new ContextMenu();
                            //MenuItem mnuTip = new MenuItem("批注");//批注
                            //MenuItem mnuExecTime = new MenuItem("执行时间");
                            
                        }
                    }
                    else if (e.View.Sheets[active].Columns[2].Label == "患者姓名")//主表
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            if (e.View.Sheets[active].Cells[e.Row, 1].Text.ToUpper() == "TRUE")
                            {
                                e.View.Sheets[active].Cells[e.Row, 1].Text = "false";
                             
                            }
                            else
                            {
                                e.View.Sheets[active].Cells[e.Row, 1].Text = "True";
                             
                            }
                            //更新子表的选择
                            try
                            {
                                List<string> alComboNO = new List<string>();//addby xuewj 2010-10-1 医嘱审核增加系统类别过滤 {93CA36C4-ABF1-459d-A94A-0AD81F0804C8}
                                FarPoint.Win.Spread.SheetView sv = e.View.Sheets[active].GetChildView(e.Row, 0);//(FarPoint.Win.Spread.SpreadView).GetChildWorkbooks()[e.Row];                                
                                if (sv.Columns[3].Label == "审核")
                                {
                                    for (int i = 0; i < sv.Rows.Count; i++)
                                    {
                                        #region addby xuewj 2010-10-1 医嘱审核增加系统类别过滤 {93CA36C4-ABF1-459d-A94A-0AD81F0804C8}
                                        if (sv.Rows[i].Visible)
                                        {
                                            sv.Cells[i, 3].Text = e.View.Sheets[active].Cells[e.Row, 1].Text;
                                            if (!alComboNO.Contains(sv.Cells[i, int.Parse(this.ComboNo.ID)].Text))
                                            {
                                                alComboNO.Add(sv.Cells[i, int.Parse(this.ComboNo.ID)].Text);
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                #region addby xuewj 2010-10-1 医嘱审核增加系统类别过滤 {93CA36C4-ABF1-459d-A94A-0AD81F0804C8}
                                //更新组合的医嘱选择信息
                                for (int i = 0; i < sv.RowCount; i++)
                                {
                                    if (Neusoft.FrameWork.Function.NConvert.ToBoolean(sv.Cells[i, 3].Value) == !Neusoft.FrameWork.Function.NConvert.ToBoolean(e.View.Sheets[active].Cells[e.Row, 1].Text)
                                        && alComboNO.Contains(sv.Cells[i, int.Parse(this.ComboNo.ID)].Text))
                                    {
                                        sv.Cells[i, 3].Text = e.View.Sheets[active].Cells[e.Row, 1].Text;
                                    }
                                }
                                #endregion
                            }
                            catch { }
                            this.OrderId.Name = "";
                            this.ComboNo.Name = "";
                        }

                    }
                }
                catch { }
            }
        }
        //批注单击
        private void mnuTip_Click(object sender, EventArgs e)
        {
            ucTip ucTip1 = new ucTip(); 
            string OrderID = this.OrderId.Name;
            int iHypotest = this.orderManager.QueryOrderHypotest(OrderID);
            if (iHypotest == -1)
            {
                MessageBox.Show(this.orderManager.Err);
                return;
            }
            #region 非药品医嘱不显示皮试页 
            Neusoft.HISFC.Models.Order.Order o = this.orderManager.QueryOneOrder(this.OrderId.Name);
            //if (o.Item.IsPharmacy == false)
            if (o.Item.ItemType != Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                ucTip1.Hypotest = 1;
            }
            #endregion
            ucTip1.Tip = this.orderManager.QueryOrderNote(OrderID);
            ucTip1.Hypotest = iHypotest;
            ucTip1.OKEvent += new myTipEvent(ucTip1_OKEvent);
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucTip1);
        }

        /// <summary>
        /// 修改执行科室事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuChangeDept_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.orderManager.QueryOneOrder(this.OrderId.Name);
            Neusoft.FrameWork.Models.NeuObject dept = ucChangeStoreDept.ChangeStoreDept(order);
            if (dept == null) return;
            order.StockDept = dept;
            if (this.orderManager.UpdateOrder(order) < 0)
            {
                MessageBox.Show(this.orderManager.Err);
                return;
            }
        }

        //批注事件
        private void ucTip1_OKEvent(string Tip, int Hypotest)
        {
            if (this.orderManager.UpdateFeedback(this.PatientId, this.OrderId.Name, Tip, Hypotest) == -1)
            {
                MessageBox.Show(this.orderManager.Err);
                this.orderManager.Err = "";
                return;
            }
             
            //SheetView sv=  this.fpSpread.ActiveSheet.GetChildView(this.fpSpread.ActiveSheet.ActiveRowIndex, 0);
            #region add by xuewj 2010-9-26 增加列 单价 {5C90E8AB-70B8-45b9-ABEE-577048C0FE43}
            if (Hypotest == 3)
            {
                //cellClickEvent.View.Sheets[curRow].Cells[cellClickEvent.Row, 24].Text = "阳性";
                cellClickEvent.View.Sheets[curRow].Cells[cellClickEvent.Row, 25].Text = "阳性";
            }
            else if (Hypotest == 4)
            {
                //cellClickEvent.View.Sheets[curRow].Cells[cellClickEvent.Row, 24].Text = "阴性";
                cellClickEvent.View.Sheets[curRow].Cells[cellClickEvent.Row, 25].Text = "阴性";
            }

            //cellClickEvent.View.Sheets[curRow].Cells[cellClickEvent.Row, 22].Text = Tip;
            cellClickEvent.View.Sheets[curRow].Cells[cellClickEvent.Row, 23].Text = Tip; 
            #endregion
            Neusoft.HISFC.Models.RADT.PatientInfo p = this.radtIntegrate.GetPatientInfoByPatientNO(this.PatientId);
            refreshView();
     
        }
        void ucOrderConfirm_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
         
        }
        #endregion

        #region 吸附窗口处理附材
        public Crownwood.Magic.Docking.DockingManager dockingManager;
        private Crownwood.Magic.Docking.Content content;
        private Crownwood.Magic.Docking.WindowContent wc;
        ucSubtblManager ucSubtblManager1 = null;
        public void DockingManager()
        {
            this.dockingManager = new Crownwood.Magic.Docking.DockingManager
                (this, Crownwood.Magic.Common.VisualStyle.IDE);
            this.dockingManager.OuterControl = this.panelMain;		//在OuterControl后加入的控件不受停靠窗口的影响

            content = new Crownwood.Magic.Docking.Content(this.dockingManager);
            content.Control = ucSubtblManager1;

            Size ucSize = content.Control.Size;

            content.Title = "附材管理";
            content.FullTitle = "附材管理";
            content.AutoHideSize = ucSize;
            content.DisplaySize = ucSize;
            
           
            this.dockingManager.Contents.Add(content);
        }
        #endregion

        #region IInterfaceContainer 成员 {2D97BF3B-C09C-433d-9C8C-F80CC2751261}

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] t = new Type[1];
                t[0] = typeof(Neusoft.HISFC.BizProcess.Interface.Order.IFeeSheet);
                t[1] = typeof(Neusoft.HISFC.BizProcess.Interface.Order.IApplyFeeSheet);
                return t;
            }
        }

        #endregion

        #region addby xuewj 2010-10-1 医嘱审核增加系统类别过滤 {93CA36C4-ABF1-459d-A94A-0AD81F0804C8} 
        /// <summary>
        /// 西药
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnP_Click(object sender, EventArgs e)
        {
            if (this.activeBtn != this.btnP)
            {
                if (this.FilteOrder("P") == 1)
                {
                    ChangeBtnColor(this.btnP);
                }
            }
        }

        /// <summary>
        /// 中成药、中草药
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPCCANDPCZ_Click(object sender, EventArgs e)
        {
            if (this.activeBtn != this.btnPCCANDPCZ)
            {
                if (this.FilteOrder("PCC,PCZ") == 1)
                {
                    ChangeBtnColor(this.btnPCCANDPCZ);
                }
            }
        }

        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUC_Click(object sender, EventArgs e)
        {
            if (this.activeBtn != this.btnUC)
            {
                if (this.FilteOrder("UC") == 1)
                {
                    ChangeBtnColor(this.btnUC);
                }
            }
        }

        /// <summary>
        /// 检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUL_Click(object sender, EventArgs e)
        {
            if (this.activeBtn != this.btnUL)
            {
                if (this.FilteOrder("UL") == 1)
                {
                    ChangeBtnColor(this.btnUL);
                }
            }
        }

        /// <summary>
        /// 其他
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOther_Click(object sender, EventArgs e)
        {
            if (this.activeBtn != this.btnOther)
            {
                if (this.FilteOrder("OTHER") == 1)
                {
                    ChangeBtnColor(this.btnOther);
                }
            }
        }

        /// <summary>
        /// 所有医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAll_Click(object sender, EventArgs e)
        {
            if (this.activeBtn != this.btnAll)
            {
                if (this.FilteOrder("All") == 1)
                {
                    ChangeBtnColor(this.btnAll);
                }
            }
        }

        /// <summary>
        /// 按钮大小自适应
        /// </summary>
        private void ChangeBtnSize()
        {
            bool existOrder = false;
            if (this.fpSpread.Sheets[1].RowCount == 0)
            {
                existOrder = false;
            }
            else
            {
                for (int i = 0; i < this.fpSpread.Sheets[1].RowCount; i++)
                {
                    if (this.fpSpread.Sheets[1].Rows[i].Visible == true)
                    {
                        existOrder = true;
                        break;
                    }
                }
            }
            foreach (Control c in this.panelMain.Controls)
            {
                if (c is Neusoft.FrameWork.WinForms.Controls.NeuButton)
                {
                    if (existOrder)
                    {
                        c.Height = 42;
                    }
                    else
                    {
                        c.Height = 22;
                    }
                }
            }
        }

        /// <summary>
        /// 根据当前sheet页决定过滤按钮是否显示
        /// </summary>
        /// <param name="sheetView"></param>
        private void ChangeBtnVisble(int sheetIndex)
        {
            if (sheetIndex == 0)
            {
                foreach (Control c in this.panelMain.Controls)
                {
                    if (c is Neusoft.FrameWork.WinForms.Controls.NeuButton)
                    {
                        c.Visible = false;
                    }
                }
            }
            else if (sheetIndex == 1)
            {
                foreach (Control c in this.panelMain.Controls)
                {
                    if (c is Neusoft.FrameWork.WinForms.Controls.NeuButton)
                    {
                        c.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// 改变背景色
        /// </summary>
        private void ChangeBtnColor(Control control)
        {
            if (this.activeBtn == null)
            {
                this.activeBtn = control;
                this.activeBtn.BackColor = this.backColor;
                this.activeBtn.ForeColor = this.foreColor;
            }
            else 
            {
                if (this.activeBtn.Name != control.Name)
                {
                    control.BackColor = this.backColor;
                    control.ForeColor = this.foreColor;
                    this.activeBtn.BackColor = Color.White;
                    this.activeBtn.ForeColor = Color.Black;
                    this.activeBtn = control;
                }
            }
        }

        /// <summary>
        /// 按照系统类别过滤待审核医嘱   PS:每次都需要查询医嘱信息过慢，待优化
        /// </summary>
        /// <param name="sysClass"></param>
        private int FilteOrder(string sysClass)
        {
            if (this.fpSpread.Sheets[1].RowCount == 0)
            {
                MessageBox.Show("没有需要过滤的临时医嘱!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return -1;
            }
            int perPatientRowCount = 0;//过滤后当前患者显示的医嘱数量
            string[] sysClasses = sysClass.Split(',');
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示医嘱,请您稍等(*^__^*)...");
            Application.DoEvents();
            for (int i = 0; i < this.fpSpread.Sheets[1].Rows.Count; i++) //临时医嘱
            {
                #region 医嘱处理

                //当前患者的医嘱列表页 sv
                FarPoint.Win.Spread.SheetView sv = this.fpSpread.Sheets[1].GetChildView(i, 0);               
                if (sv != null)
                {
                    perPatientRowCount = 0;
                    for (int j = 0; j < sv.Rows.Count; j++)//医嘱项目
                    {
                        if (sysClass == "All")
                        {
                            sv.Rows[j].Visible = true;
                        }
                        else
                        {
                            string orderid = sv.Cells[j, int.Parse(OrderId.ID)].Text;//医嘱项目处理
                            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.orderManager.QueryOneOrder(orderid);
                            if (order == null)
                            {
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                MessageBox.Show("医嘱已经发生变化，请刷新屏幕！");
                                return -1;
                            }

                            bool isInclude=false;//是否包含显示条件
                            foreach (string s in sysClasses)
                            {
                                if (s != "")
                                {
                                    if (s == order.Item.SysClass.ID.ToString())//包含显示条件
                                    {
                                        isInclude = true;
                                        break;
                                    }
                                }
                            }

                            if (isInclude)
                            {
                                sv.Rows[j].Visible = true;
                                perPatientRowCount++;
                            }
                            else
                            {
                                if (sysClass == "OTHER")
                                {
                                    //排除药品、中草药、中成药、检查、检验（如有需要可改成属性模式）
                                    string sysClassTmp = order.Item.SysClass.ID.ToString();
                                    if (sysClassTmp != "P" && sysClassTmp != "PCC" && sysClassTmp != "PCZ"
                                        && sysClassTmp != "UL" && sysClassTmp != "UC")
                                    {
                                        sv.Rows[j].Visible = true;
                                        perPatientRowCount++;
                                    }
                                    else
                                    {
                                        sv.Rows[j].Visible = false;
                                    }
                                }
                                else
                                {
                                    sv.Rows[j].Visible = false;
                                }
                            }
                        }
                    }

                    //当前患者不存在符合条件的医嘱，则屏蔽
                    if (perPatientRowCount == 0&&sysClass!="All")
                    {
                        this.fpSpread.Sheets[1].Rows[i].Visible = false;
                    }
                    else
                    {
                        this.fpSpread.Sheets[1].Rows[i].Visible = true;
                        this.fpSpread.Sheets[1].ExpandRow(i, false);
                        this.fpSpread.Sheets[1].ExpandRow(i, true);
                    }
                }
                #endregion
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            this.ChangeBtnSize();
            Classes.Function.DrawCombo(this.fpSpread.Sheets[1], 2, 5, 1);
            return 1;
        }

        /// <summary>
        /// 初始化控制参数
        /// </summary>
        private void Initcontrolargument()
        {
            //背景色
            string returnValue = ctlMgr.QueryControlerInfo("200213");

            if (!string.IsNullOrEmpty(returnValue))
            {
                this.backColor = System.Drawing.Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(returnValue));
            }

            //前景色
            returnValue = ctlMgr.QueryControlerInfo("200214");

            if (!string.IsNullOrEmpty(returnValue))
            {
                this.foreColor = System.Drawing.Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(returnValue));
            }
        }

        #endregion
    }
}

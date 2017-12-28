using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.WinForms.Report.InpatientFee
{      
    /// <summary>
    /// [功能描述: 在院患者情况查询]<br></br>
    /// [创 建 者: 张琦]<br></br>
    /// [创建时间: 2007-9-13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPatientInHosQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 变量
        /// <summary>
        /// 科室业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        /// <summary>
        /// 住院出入转业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.RADT.InPatient patientQuery = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        /// <summary>
        /// 人员信息业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();

        /// <summary>
        /// 常数业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 费用业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.InPatient feeManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 医嘱管理实体
        /// </summary>
        Neusoft.HISFC.BizLogic.Order.Order orderManagement = new Neusoft.HISFC.BizLogic.Order.Order();

        Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 当前患者
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo currentPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();
        /// <summary>
        /// 查询时间
        /// </summary>
        string queryTime = string.Empty;
        /// <summary>
        /// 查询科室
        /// </summary>
        string deptCode = string.Empty;
        /// <summary>
        /// 查询病人
        /// </summary>
        string patientNo = string.Empty;
        /// <summary>
        /// DataTable 相关
        /// </summary>
        DataTable dtPatientInfo=new DataTable();
        DataTable dtPatientOrder = new DataTable();
        DataTable dtFeeTotal = new DataTable();
        DataTable dtFeeDetail = new DataTable();
        DataTable dtPayInfo = new DataTable();
        DataTable dtShiftDept = new DataTable();
        /// <summary>
        /// 类型
        /// </summary>
        Type str = typeof(String);
        Type date = typeof(DateTime);
        Type dec = typeof(Decimal);
        Type bo = typeof(bool);
        ArrayList alDepts = new ArrayList();
        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        public ucPatientInHosQuery()
        {
            InitializeComponent();
        }

        private void ucPatientInHosQuery_Load(object sender, EventArgs e)
        {
            try//获得所有科室
            {

                this.alDepts = this.deptManager.GetDeptmentAll();
            }
            catch { }

            this.InitSpreadParm();

            this.Text = "在院患者情况查询";
            //初始化科室列表
            this.InitDept();
            this.InitTree();
            //设置默认查询时间 
            this.InitPatientInfo();

            this.InitFeeTotal();

            this.InitOrder();

            this.InitFeeDetail();

            this.InitPayInfo();

            this.InitRADTInfo();
        }
        #endregion

        #region 初始化相关函数 

        /// <summary>
        /// fp初始化
        /// </summary>
        private void InitSpreadParm()
        {
            this.spdPatient_Sheet1.DefaultStyle.Locked = true;
            this.spdFeeTotal_Sheet1.DefaultStyle.Locked = true;
            this.spdOrder_Sheet1.DefaultStyle.Locked = true;
        }

        /// <summary>
        /// 初始化科室列表
        /// </summary>
        /// <returns></returns>
        private int InitDept()
        {
            int findAll = 0;
            Neusoft.FrameWork.Models.NeuObject objAll = new Neusoft.FrameWork.Models.NeuObject();

            objAll.ID = "ALL";
            objAll.Name = "全部";

            ArrayList deptList = this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            if (deptList == null)
            {
                MessageBox.Show(Language.Msg("加载科室列表出错!") + this.deptManager.Err);
                return -1;
            }

            deptList.Add(objAll);
            findAll = deptList.IndexOf(objAll);
            this.cmbDept.AddItems(deptList);
            if (findAll >= 0)
            {
                this.cmbDept.SelectedIndex = findAll;
            }
            return 1;
        }

        /// <summary>
        /// 患者信息
        /// </summary>
        /// <returns></returns>
        private int InitPatientInfo()
        {
            dtPatientInfo.Columns.AddRange(new DataColumn[]{new DataColumn("住院流水号", str),
																new DataColumn("住院号", str),
																new DataColumn("姓名", str),
																new DataColumn("住院科室", str),
																new DataColumn("床号", str),
																new DataColumn("患者类别", str),
																new DataColumn("预交金(未结)", dec),
																new DataColumn("费用合计(未结)", dec),
																new DataColumn("余额", dec),
																new DataColumn("自费", dec),
																new DataColumn("自负", dec),
																new DataColumn("公费", dec),
																new DataColumn("入院日期", date),
																new DataColumn("在院状态", str),
																new DataColumn("出院日期", str),
																new DataColumn("预交金(已结)", dec),
																new DataColumn("费用合计(已结)", dec),
																new DataColumn("结算日期", date)});

            dtPatientInfo.PrimaryKey = new DataColumn[] { dtPatientInfo.Columns["住院流水号"] };
                this.spdPatient_Sheet1.DataSource = dtPatientInfo;
            return 1;
        }

        /// <summary>
        /// 费用汇总
        /// </summary>
        /// <returns></returns>
        private int InitFeeTotal()
        {
            this.dtFeeTotal.Columns.AddRange(new DataColumn[]{ new DataColumn("费用名称",str),
                                                               new DataColumn("金额",dec),
                                                               new DataColumn("自费",dec),
                                                               new DataColumn("公费",dec),
                                                               new DataColumn("自负",dec),
                                                               new DataColumn("优惠金额",dec),
                                                               new DataColumn("结算状态",str)});
            //this.dtFeeTotal.PrimaryKey = new DataColumn[] { this.dtFeeTotal.Columns["费用名称"] };
            this.spdFeeTotal_Sheet1.DataSource = this.dtFeeTotal;
            return 1;
        }

        /// <summary>
        /// 医嘱
        /// </summary>
        /// <returns></returns>
        private int InitOrder()
        {

            this.dtPatientOrder.Columns.AddRange(new DataColumn[]
			{
				new DataColumn("医嘱类型",str),				//2
				new DataColumn("医嘱流水号",str),				//3
				new DataColumn("医嘱状态",str),				//4 新开立，审核，执行
				new DataColumn("组合号",str),					//5
				new DataColumn("主药",str),					//6
				new DataColumn("医嘱名称",str),				//8
				new DataColumn("组",str),					    //9
				new DataColumn("备注",str),					//20
				new DataColumn("总量",dec),					//9
				new DataColumn("总量单位",str),				//10
				new DataColumn("每次量",str),				//11
				new DataColumn("单位",str),					//12
				new DataColumn("付数",str),					//13
				new DataColumn("频次编码",str),				//14
				new DataColumn("频次",str),				//15
				new DataColumn("用法",str),				//17
				new DataColumn("大类",str),
				new DataColumn("开始时间",str),				//18
				new DataColumn("停止时间",str),				//19
				new DataColumn("开立医生",str),				//21
				new DataColumn("执行科室",str),				//23
				new DataColumn("加急",str),					//24
				new DataColumn("检查部位",str),				//25
				new DataColumn("样本类型",str),				//26
				new DataColumn("扣库科室",str),				//28
				new DataColumn("录入人",str),					//30
				new DataColumn("开立科室",str),				//31
				new DataColumn("开立时间",str),				//32
				new DataColumn("停止人",str),					//34
				new DataColumn("皮试标志",str),				//36
				new DataColumn("附材标志",bo),
				
			});

            this.spdOrder_Sheet1.DataSource = this.dtPatientOrder;
            return 1;
        }

        /// <summary>
        /// 费用明细
        /// </summary>
        /// <returns></returns>
        private int InitFeeDetail()
        {
            this.dtFeeDetail.Columns.AddRange(new DataColumn[]{ new DataColumn("名称", str),
																new DataColumn("规格", str),
																new DataColumn("单价", dec),
																new DataColumn("数量", dec),
																new DataColumn("付数", dec),
																new DataColumn("单位", str),
																new DataColumn("金额", dec),
																new DataColumn("自费", dec),
																new DataColumn("公费", dec),
																new DataColumn("自负", dec),
																new DataColumn("优惠", dec),
																new DataColumn("执行科室",str),
																new DataColumn("患者科室",str),
																new DataColumn("收费时间", str),
																new DataColumn("收费员", str),
																new DataColumn("发药时间", str),   
																new DataColumn("发药员", str)});
            this.spdFeeInfo_Sheet1.DataSource = this.dtFeeDetail;
            return 1;

        }

        private int InitPayInfo()
        {
            this.dtPayInfo.Columns.AddRange(new DataColumn[]{ new DataColumn("票据号", str),
															  new DataColumn("预交金额", dec),
															  new DataColumn("支付方式", str),
															  new DataColumn("操作员", str),
															  new DataColumn("操作日期", date),
															  new DataColumn("所在科室", str),
															  new DataColumn("结算状态", str),
															  new DataColumn("来源", str)});
            this.spdPayInfo_Sheet1.DataSource = this.dtPayInfo;
            return 1;
        }

        private int InitRADTInfo()
        {
            this.dtShiftDept.Columns.AddRange(new DataColumn[] { new DataColumn("原科室",str),
                                                                 new DataColumn("原护士站",str),
                                                                 new DataColumn("新科室",str),
                                                                 new DataColumn("新护士站",str),
                                                                 new DataColumn("确认时间",str)});
            this.spdShiftInfo_Sheet1.DataSource = this.dtShiftDept;
            return 1;
        }

        #endregion

        #region 事件

        private void btQuery_Click(object sender, EventArgs e)
        {
            //根据查询条件获得患者信息列表
            //初始化树
            this.InitTree();
            this.ClearDT();
            //查询患者
            ArrayList patientList = new ArrayList();
            ArrayList deptList = new ArrayList(); //科室列表
            this.queryTime = this.dtTime.Value.ToString();
            deptList = this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            if (this.cmbDept.Text == "全部")
            {
                foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
                {
                    deptCode = (dept.ID).ToString();
                    patientList.AddRange(this.patientQuery.PatientInHosQueryByTime(deptCode, queryTime));
                }
            }
            else
            {
                if (this.cmbDept.Text != "")
                {
                    deptCode = (this.cmbDept.Tag).ToString();
                }
                patientList = this.patientQuery.PatientInHosQueryByTime(deptCode, queryTime);
            }
            if (patientList == null)
            {
                MessageBox.Show(Language.Msg("获得患者信息出错!") + this.patientQuery.Err);
                return;
            }
            this.GetArraryPatientInfo(patientList);
        }

        #endregion

        #region 函数

        /// <summary>
        /// 初始树
        /// </summary>
        private void InitTree()
        {
            ArrayList deptList = new ArrayList(); //科室列表
            ArrayList patientList = new ArrayList();//患者列表
            this.queryTime = this.dtTime.Value.ToString();
            this.tvPatientList.ImageList = this.tvPatientList.deptImageList;

            this.tvPatientList.Nodes.Clear();

            if (this.cmbDept.Text == "全部" || this.cmbDept.Text == string.Empty)//默认为全部科室 全部科室列表
            {
                //this.cmbDept.Tag = "ALL";
                //this.cmbDept.Text = "全部";
                deptList = this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);

                TreeNode parentTreeNode = new TreeNode("住院病区");
                tvPatientList.Nodes.Add(parentTreeNode);

                foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
                {
                    TreeNode parentNode = new TreeNode();
                    parentNode.Tag = dept.ID;
                    parentNode.Text = dept.Name;
                    parentNode.ImageIndex = 5;
                    parentNode.SelectedImageIndex = 5;
                    //this.tvPatientList.Nodes.Add(parentNode);
                    parentTreeNode.Nodes.Add(parentNode);

                    //添加子节点 为人员列表
                    deptCode = dept.ID;
                    patientList = new ArrayList();
                    patientList = this.patientQuery.PatientInHosQueryByTime(deptCode, queryTime);

                    if (patientList != null)
                    {
                        //动态加载人员列表
                        foreach (Neusoft.HISFC.Models.RADT.PatientInfo patientInfo in patientList)
                        {
                            TreeNode patientNode = new TreeNode();
                            patientNode.Tag = patientInfo.ID;
                            patientNode.Text = patientInfo.Name;
                            patientNode.ImageIndex = 0;
                            patientNode.SelectedImageIndex = 1;
                            parentNode.Nodes.Add(patientNode);
                        }
                    }
                }

            }
            else //列出当前科室
            {
                TreeNode parentTreeNode = new TreeNode("住院病区");
                tvPatientList.Nodes.Add(parentTreeNode);

                TreeNode parentNode = new TreeNode();
                parentNode.Tag = this.cmbDept.Tag.ToString();
                parentNode.Text = this.cmbDept.Text;
                parentNode.ImageIndex = 5;
                parentNode.SelectedImageIndex = 5;
                parentTreeNode.Nodes.Add(parentNode);

                //添加子节点 为人员列表
                deptCode = this.cmbDept.Tag.ToString();
                patientList = this.patientQuery.PatientInHosQueryByTime(deptCode, queryTime);
                if (patientList != null)
                {
                    //动态加载人员列表
                    foreach (Neusoft.HISFC.Models.RADT.PatientInfo patientInfo in patientList)
                    {
                        TreeNode patientNode = new TreeNode();
                        patientNode.Tag = patientInfo.ID;
                        patientNode.Text = patientInfo.Name;
                        patientNode.ImageIndex = 0;
                        patientNode.SelectedImageIndex = 1;
                        parentNode.Nodes.Add(patientNode);
                    }
                }
            }
        }

        /// <summary>
        /// 清空各个dt
        /// </summary>
        private void ClearDT()
        {
            this.dtFeeDetail.Clear();
            this.dtFeeTotal.Clear();
            this.dtPatientInfo.Clear();
            this.dtPatientOrder.Clear();
            this.dtPayInfo.Clear();
            this.dtShiftDept.Clear();
        }
        #endregion

        #region 获取患者各个信息（tab页）

        /// <summary>
        /// 获得患者信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        private void GetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            DataRow row = this.dtPatientInfo.NewRow();
            try
            {

                row["住院流水号"] = patient.ID;
                row["住院号"] = patient.PID.PatientNO;
                row["姓名"] = patient.Name;
                row["住院科室"] = patient.PVisit.PatientLocation.Dept.Name;
                row["床号"] = patient.PVisit.PatientLocation.Bed.ID;
                row["患者类别"] = patient.Pact.Name;
                row["预交金(未结)"] = patient.FT.PrepayCost;
                row["费用合计(未结)"] = patient.FT.TotCost;
                row["余额"] = patient.FT.LeftCost;
                row["自费"] = patient.FT.OwnCost;
                row["自负"] = patient.FT.PayCost;
                row["公费"] = patient.FT.PubCost;
                row["入院日期"] = patient.PVisit.InTime;
                row["在院状态"] = patient.PVisit.InState.Name;

                row["出院日期"] = patient.PVisit.OutTime.Date == new DateTime(1, 1, 1).Date ? string.Empty : patient.PVisit.OutTime.ToString();

                row["预交金(已结)"] = patient.FT.BalancedPrepayCost;
                row["费用合计(已结)"] = patient.FT.BalancedCost;
                row["结算日期"] = patient.BalanceDate;

                this.dtPatientInfo.Rows.Add(row);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        /// <summary>
        /// 显示患者信息
        /// </summary>
        /// <param name="patientInfo"></param>
        private void GetArraryPatientInfo(ArrayList patientInfo)
        {
            this.dtPatientInfo.Clear();
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patientInfo)
            {
                this.GetPatientInfo(patient);
            }
        }

        /// <summary>
        /// 显示患者费用汇总信息
        /// </summary>
        /// <param name="patientInfo"></param>
        private void GetArraryFeeTotal(ArrayList patientInfo)
        {
            this.dtFeeTotal.Clear();
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patientInfo)
            {
                this.GetPatientFeeTotal(patient);
            }
        }

        /// <summary>
        /// 显示患者医嘱信息
        /// </summary>
        /// <param name="patientInfo"></param>
        private void GetArrayPatientOrder(ArrayList patientInfo)
        {
            this.dtPatientOrder.Clear();
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patientInfo)
            {
                this.GetPatientOrder(patient);
            }
        }

        /// <summary>
        /// 患者费用明细信息
        /// </summary>
        /// <param name="patientInfo"></param>
        private void GetArrayFeedetail(ArrayList patientInfo)
        {
            this.dtFeeDetail.Clear();
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patientInfo)
            {
                this.GetPatientDrugList(patient);
                this.GetPatientUndrugList(patient);
            }
        }

        /// <summary>
        /// 患者预交金信息
        /// </summary>
        /// <param name="patientInfo"></param>
        private void GetArrayPayInfo(ArrayList patientInfo)
        {
            this.dtPayInfo.Clear();
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patientInfo)
            {
                this.GetPatientPayInfo(patient);
            }
        }

        /// <summary>
        /// 患者转科情况
        /// </summary>
        /// <param name="patientInfo"></param>
        private void GetArrayRADTInfo(ArrayList patientInfo)
        {
            this.dtShiftDept.Clear();
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patientInfo)
            {
                this.GetPatientShiftDept(patient);
            }
        }

        #endregion

        #region 函数

        /// <summary>
        /// 获得科室名称
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        private string GetDeptName(Neusoft.FrameWork.Models.NeuObject dept)
        {
            for (int i = 0; i < this.alDepts.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj = (Neusoft.FrameWork.Models.NeuObject)this.alDepts[i];
                if (obj.ID == dept.ID)
                {
                    dept.Name = obj.Name;
                    return dept.Name;
                }
            }
            return "";
        }

        /// <summary>
        /// 击树的节点显示患者信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvPatientList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ArrayList deptList = new ArrayList(); //科室列表
            ArrayList patientList = new ArrayList();//患者列表
            this.queryTime = this.dtTime.Value.ToString();
            this.ClearDT();
            if (e.Node.Level == 0)
            {
                deptList = this.deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
                foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
                {
                    deptCode = (dept.ID).ToString();
                    patientList.AddRange(this.patientQuery.PatientInHosQueryByTime(deptCode, queryTime));
                }
            }
            else if (e.Node.Level == 1)
            {
                deptCode = e.Node.Tag.ToString();
                patientList = this.patientQuery.PatientInHosQueryByTime(deptCode, queryTime);
            }
            else
            {
                patientNo = e.Node.Tag.ToString();
                patientList.Add(this.patientQuery.QueryPatientInfoByInpatientNO(patientNo));
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据,请等待....");
                Application.DoEvents();
                this.GetArraryFeeTotal(patientList);
                this.GetArrayPatientOrder(patientList);
                this.GetArrayFeedetail(patientList);
                this.GetArrayPayInfo(patientList);
                this.GetArrayRADTInfo(patientList);
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            this.GetArraryPatientInfo(patientList);
        }

        #endregion

        #region 患者药品明细、非药品明细

        /// <summary>
        /// 获得患者药品明细
        /// </summary>
        /// <param name="patient"></param>
        private void GetPatientDrugList(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            DateTime beginTime = patient.PVisit.InTime;
            DateTime endTime = this.feeManager.GetDateTimeFromSysDateTime();

            ArrayList drugList = this.feeManager.GetMedItemsForInpatient(patient.ID, beginTime, endTime);
            if (drugList == null)
            {
                MessageBox.Show(Language.Msg("获得患者药品明细出错!") + this.feeManager.Err);

                return;
            }
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj in drugList)
            {
                DataRow row = this.dtFeeDetail.NewRow();

                row["名称"] = obj.Item.Name;
                Neusoft.HISFC.Models.Pharmacy.Item medItem = (Neusoft.HISFC.Models.Pharmacy.Item)obj.Item;
                row["规格"] = medItem.Specs;
                row["单价"] = obj.Item.Price;
                row["数量"] = obj.Item.Qty;
                row["付数"] = obj.Days;
                row["单位"] = obj.Item.PriceUnit;
                row["金额"] = obj.FT.TotCost;
                row["自费"] = obj.FT.OwnCost;
                row["公费"] = obj.FT.PubCost;
                row["自负"] = obj.FT.PayCost;
                row["优惠"] = obj.FT.RebateCost;
                row["执行科室"] = this.deptManager.GetDeptmentById(obj.ExecOper.Dept.ID).Name;
                row["患者科室"] = this.deptManager.GetDeptmentById(((Neusoft.HISFC.Models.RADT.PatientInfo)obj.Patient).PVisit.PatientLocation.Dept.ID).Name;
                row["收费时间"] = obj.FeeOper.OperTime;

                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();
                empl = managerIntergrate.GetEmployeeInfo(obj.FeeOper.ID);
                if (empl.Name == string.Empty)
                {
                    row["收费员"] = obj.FeeOper.ID;
                }
                else
                {
                    row["收费员"] = empl.Name;
                }


                row["发药时间"] = obj.ExecOper.OperTime.Date == new DateTime(1, 1, 1).Date ? string.Empty : obj.ExecOper.OperTime.ToString();

                Neusoft.HISFC.Models.Base.Employee confirmOper = new Neusoft.HISFC.Models.Base.Employee();
                confirmOper = managerIntergrate.GetEmployeeInfo(obj.ExecOper.ID);

                if (confirmOper.Name == string.Empty)
                {
                    row["发药员"] = obj.ExecOper.ID;
                }
                else
                {
                    row["发药员"] = confirmOper.Name;
                }

                this.dtFeeDetail.Rows.Add(row);
            }
        }

        /// <summary>
        /// 查询患者非药品明细
        /// </summary>
        /// <param name="patient"></param>
        private void GetPatientUndrugList(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            DateTime beginTime = patient.PVisit.InTime;
            DateTime endTime = this.feeManager.GetDateTimeFromSysDateTime();

            ArrayList undrugList = this.feeManager.QueryFeeItemLists(patient.ID, beginTime, endTime);
            if (undrugList == null)
            {
                MessageBox.Show(Language.Msg("获得患者非药品明细出错!") + this.feeManager.Err);

                return;
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj in undrugList)
            {
                DataRow row = this.dtFeeDetail.NewRow();

                row["名称"] = obj.Item.Name;
                row["单价"] = obj.Item.Price;
                row["数量"] = obj.Item.Qty;
                row["单位"] = obj.Item.PriceUnit;
                row["金额"] = obj.FT.TotCost;
                row["自费"] = obj.FT.OwnCost;
                row["公费"] = obj.FT.PubCost;
                row["自负"] = obj.FT.PayCost;
                row["优惠"] = obj.FT.RebateCost;
                row["收费时间"] = obj.FeeOper.OperTime;

                //收款员姓名
                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();
                empl = managerIntergrate.GetEmployeeInfo(obj.FeeOper.ID);

                if (empl.Name == string.Empty)
                {
                    row["收费员"] = obj.FeeOper.ID;
                }
                else
                {
                    row["收费员"] = empl.Name;
                }

                row["执行科室"] = this.deptManager.GetDeptmentById(obj.ExecOper.Dept.ID).Name;
                row["患者科室"] = this.deptManager.GetDeptmentById(((Neusoft.HISFC.Models.RADT.PatientInfo)obj.Patient).PVisit.PatientLocation.Dept.ID).Name;

                this.dtFeeDetail.Rows.Add(row);
            }
        }
        #endregion

        #region 患者医嘱明细

        #region 查医嘱用的

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
            row["用法"] = order.Usage.Name;
            row["大类"] = order.Item.SysClass.Name;
            row["开始时间"] = order.BeginTime;
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
            row["样本类型"] = order.Sample;
            row["扣库科室"] = deptHelper.GetName(order.StockDept.ID);

            row["备注"] = order.Memo;
            row["录入人"] = order.Oper.Name;
            if (order.ReciptDept.Name == "" && order.ReciptDept.ID != "") order.ReciptDept.Name = this.GetDeptName(order.ReciptDept);
            row["开立医生"] = order.ReciptDoctor.Name;
            row["开立科室"] = order.ReciptDept.Name;
            row["开立时间"] = order.MOTime.ToString();
            row["停止时间"] = order.EndTime;
            row["停止人"] = order.DCOper.Name;
            row["皮试标志"] = order.HypoTest;
            row["附材标志"] = order.IsSubtbl;
            return row;
        }

               #endregion

        /// <summary>
        /// 获得患者医嘱信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        private void GetPatientOrder(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            ArrayList alAllOrder = orderManagement.QueryOrder(patient.ID);
            if (alAllOrder == null) return;
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order orderObj in alAllOrder)
            {
                if (orderObj == null) continue;
                this.dtPatientOrder.Rows.Add(AddObjectToRow(orderObj, dtPatientOrder));
            }
        }
        #endregion

        #region 患者费用汇总
        /// <summary>
        /// 患者费用合计
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        private void GetPatientFeeTotal(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            DateTime beginTime = patient.PVisit.InTime;
            DateTime endTime = this.feeManager.GetDateTimeFromSysDateTime();

            ArrayList feeInfoList = this.feeManager.QueryFeeInfosGroupByMinFeeByInpatientNO(patient.ID, beginTime, endTime, "0");
            if (feeInfoList == null)
            {
                MessageBox.Show(Language.Msg("获得患者费用汇总明细出错!") + this.feeManager.Err);

                return;
            }

            this.dtFeeTotal.Rows.Clear();

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeInfo in feeInfoList)
            {

                DataRow row = dtFeeTotal.NewRow();

                row["费用名称"] = this.feeManager.GetComDictionaryNameByID("MINFEE", feeInfo.Item.MinFee.ID);
                row["金额"]     = feeInfo.FT.TotCost;
                row["自费"]     = feeInfo.FT.OwnCost;
                row["公费"]     = feeInfo.FT.PubCost;
                row["自负"]     = feeInfo.FT.PayCost;
                row["优惠金额"] = feeInfo.FT.RebateCost;
                row["结算状态"] = "未结算";

                dtFeeTotal.Rows.Add(row);
            }

            ArrayList feeInfoListBalanced = this.feeManager.QueryFeeInfosGroupByMinFeeByInpatientNO(patient.ID, beginTime, endTime, "1");
            if (feeInfoListBalanced == null)
            {
                MessageBox.Show(Language.Msg("获得患者费用汇总明细出错!") + this.feeManager.Err);

                return;
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeInfo in feeInfoListBalanced)
            {

                DataRow row = dtFeeTotal.NewRow();

                row["费用名称"] = this.feeManager.GetComDictionaryNameByID("MINFEE", feeInfo.Item.MinFee.ID);
                row["金额"]     = feeInfo.FT.TotCost;
                row["自费"]     = feeInfo.FT.OwnCost;
                row["公费"]     = feeInfo.FT.PubCost;
                row["自负"]     = feeInfo.FT.PayCost;
                row["优惠金额"] = feeInfo.FT.RebateCost;
                row["结算状态"] = "已结算";

                dtFeeTotal.Rows.Add(row);
            }
        }
        #endregion

        #region 患者预交金
        /// <summary>
        /// 交款信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        private void GetPatientPayInfo(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            DateTime beginTime = patient.PVisit.InTime;
            DateTime endTime = this.feeManager.GetDateTimeFromSysDateTime();

            ArrayList prepayList = this.feeManager.QueryPrepays(patient.ID);
            if (prepayList == null)
            {
                MessageBox.Show(Language.Msg("获得患者预交金明细出错!") + this.feeManager.Err);

                return;
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay in prepayList)
            {
                Neusoft.HISFC.Models.Base.Employee employeeObj = new Neusoft.HISFC.Models.Base.Employee();
                Neusoft.HISFC.Models.Base.Department deptObj = new Neusoft.HISFC.Models.Base.Department();
                DataRow row = this.dtPayInfo.NewRow();

                row["票据号"] = prepay.RecipeNO;
                row["预交金额"] = prepay.FT.PrepayCost;
                row["支付方式"] = prepay.PayType.Name;
                employeeObj = this.personManager.GetPersonByID(prepay.PrepayOper.ID);
                row["操作员"] = employeeObj.Name;
                row["操作日期"] = prepay.PrepayOper.OperTime;
                deptObj = this.deptManager.GetDeptmentById(((Neusoft.HISFC.Models.RADT.PatientInfo)prepay.Patient).PVisit.PatientLocation.Dept.ID);
                row["所在科室"] = deptObj.Name;
                string tempBalanceStatusName = string.Empty;
                switch (prepay.BalanceState)
                {
                    case "0":
                        tempBalanceStatusName = "未结算";
                        break;
                    case "1":
                        tempBalanceStatusName = "已结算";
                        break;
                    case "2":
                        tempBalanceStatusName = "已结转";
                        break;
                }
                row["结算状态"] = tempBalanceStatusName;
                string tempPrepayStateName = string.Empty;
                switch (prepay.PrepayState)
                {
                    case "0":
                        tempPrepayStateName = "收取";
                        break;
                    case "1":
                        tempPrepayStateName = "作废";
                        break;
                    case "2":
                        tempPrepayStateName = "补打";
                        break;
                }
                this.dtPayInfo.Rows.Add(row);
            }
        }
        #endregion

        #region 患者转科信息
        /// <summary>
        /// 转科信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        private void GetPatientShiftDept(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            ArrayList radtList = this.patientQuery.GetPatientRADTInfo(patient.ID);
            if (radtList == null)
            {
                MessageBox.Show(Language.Msg("获得患者转科明细出错!") + this.patientQuery.Err);

                return;
            }

            foreach (Neusoft.HISFC.Models.Invalid.CShiftData csdata in radtList)
            {
                DataRow row = this.dtShiftDept.NewRow();

                row["原科室"] = this.deptManager.GetDeptmentById(csdata.OldDataCode).Name;
                row["原护士站"] = this.deptManager.GetDeptmentById(csdata.OldDataName).Name;
                row["新科室"] = this.deptManager.GetDeptmentById(csdata.NewDataCode).Name;
                row["新护士站"] = this.deptManager.GetDeptmentById(csdata.NewDataName).Name;
                row["确认时间"] = csdata.User03;
                this.dtShiftDept.Rows.Add(row);
            }
        }
        #endregion

        private void spdPatient_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            ArrayList patientList = new ArrayList();
            patientNo = this.spdPatient_Sheet1.Cells[e.Row, 0].Text.ToString();
            patientList.Add(this.patientQuery.QueryPatientInfoByInpatientNO(patientNo));

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据,请等待....");
            Application.DoEvents();
            this.GetArraryFeeTotal(patientList);
            this.GetArrayPatientOrder(patientList);
            this.GetArrayFeedetail(patientList);
            this.GetArrayPayInfo(patientList);
            this.GetArrayRADTInfo(patientList);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

        }

    }
}

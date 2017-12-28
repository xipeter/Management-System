using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.Report.Logistics.DrugStore
{
    /// <summary>
    /// [功能描述: 门诊处方查询]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-03]<br></br>
    /// <修改记录 
    ///		 待实现 门诊标签的补打 由此处完成
    ///  />
    /// </summary>
    public partial class ucMzOutRecipeQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMzOutRecipeQuery()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 药品管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 药品管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        /// <summary>
        /// 操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = null;

        /// <summary>
        /// 药品数组
        /// </summary>
        private ArrayList drugCollectioon = null;

        /// <summary>
        /// 是否是草药方式打印 配药打印时是否打印草药摆药单而不打印标签
        /// </summary>
        private bool isHerbalPrint = false;

        /// <summary>
        /// 防止出现大红叉
        /// </summary>
        private bool isCanExplan = false;

        #endregion

        #region 帮助类变量

        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper personHelper = null;

        /// <summary>
        /// 配药终端帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper drugTerminalHelper = null;

        /// <summary>
        /// 发药终端帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper sendTerminalHelper = null;

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
            this.toolBarService.AddToolButton("合并", "合并处方显示", 0, true, false, null);
            this.toolBarService.AddToolButton("展开", "展开显示处方明细", 0, true, false, null);
            return this.toolBarService;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryData();

            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            this.Export();

            return base.Export(sender, neuObject);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "合并")
            {
                this.ExpandFp(false);
            }
            if (e.ClickedItem.Text == "展开")
            {
                this.ExpandFp(true);
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        #region 数据初始化

        /// <summary>
        /// 数据初始化
        /// </summary>
        protected void DataInit()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载基础查询数据,请稍候...."));
            Application.DoEvents();

            this.dtEnd.Value = this.itemManager.GetDateTimeFromSysDateTime();
            this.dtBegin.Value = this.dtEnd.Value.AddDays(-1);

            #region 加载查询类别

            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject info1 = new Neusoft.FrameWork.Models.NeuObject();
            info1.ID = "A";
            info1.Name = "全部";
            al.Add(info1);
            Neusoft.FrameWork.Models.NeuObject info2 = new Neusoft.FrameWork.Models.NeuObject();
            info2.ID = "0";
            info2.Name = "病历卡号";
            al.Add(info2);
            Neusoft.FrameWork.Models.NeuObject info3 = new Neusoft.FrameWork.Models.NeuObject();
            info3.ID = "1";
            info3.Name = "发票号";
            al.Add(info3);
            Neusoft.FrameWork.Models.NeuObject info4 = new Neusoft.FrameWork.Models.NeuObject();
            info4.ID = "2";
            info4.Name = "姓名";
            al.Add(info4);
            Neusoft.FrameWork.Models.NeuObject info5 = new Neusoft.FrameWork.Models.NeuObject();
            info5.ID = "3";
            info5.Name = "处方号";
            al.Add(info5);
            Neusoft.FrameWork.Models.NeuObject info6 = new Neusoft.FrameWork.Models.NeuObject();
            info6.ID = "D";
            info6.Name = "药品";
            al.Add(info6);
            this.cmbQueryType.DataSource = al;
            this.cmbQueryType.DisplayMember = "Name";
            this.cmbQueryType.ValueMember = "ID";

            #endregion

            #region 加载人员

            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            ArrayList personAl = personManager.GetEmployeeAll();
            if (personAl == null)
            {
                Function.ShowMsg("获取人员列表失败" + personManager.Err);
                return;
            }
            if (this.personHelper == null)
            {
                this.personHelper = new Neusoft.FrameWork.Public.ObjectHelper(personAl);
            }
            #endregion

            #region 加载药品
            List<Neusoft.HISFC.Models.Pharmacy.Item> itemList = this.itemManager.QueryItemList(true);
            if (itemList == null)
            {
                Function.ShowMsg("获取药品列表失败" + this.itemManager.Err);
                return;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.Item item in itemList)
            {
                item.Memo = item.Specs;
            }

            this.drugCollectioon = new ArrayList(itemList.ToArray());

            #endregion

            #region 加载门诊终端列表
            ArrayList alDrugTerminal = this.drugStoreManager.QueryDrugTerminalByDeptCode(this.operDept.ID, "1");
            if (alDrugTerminal != null)
            {
                this.drugTerminalHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDrugTerminal);
            }
            ArrayList alSendTerminal = this.drugStoreManager.QueryDrugTerminalByDeptCode(this.operDept.ID, "0");
            if (alSendTerminal != null)
            {
                this.sendTerminalHelper = new Neusoft.FrameWork.Public.ObjectHelper(alSendTerminal);
            }
            #endregion

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        #endregion

        /// <summary>
        /// 设置FarPoint
        /// </summary>
        private void SetFP()
        {
            if (this.cmbQueryType.SelectedValue != null && this.cmbQueryType.SelectedValue.ToString() == "D")
            {
                FarPoint.Win.Spread.CellType.NumberCellType numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCellType.DecimalPlaces = 4;

                this.neuSpread1_Sheet1.Columns[0].Visible = false;			//药品编码
                this.neuSpread1_Sheet1.Columns[1].Width = 184F;			    //名称[规格]
                this.neuSpread1_Sheet1.Columns[2].Width = 90F;				//总量 单位

                this.neuSpread1_Sheet1.Columns[3].Visible = false;
                this.neuSpread1_Sheet1.Columns[4].Visible = false;
                this.neuSpread1_Sheet1.Columns[5].Visible = false;
            }
            else
            {
                this.neuSpread1_Sheet1.Columns[0].Visible = true;
                this.neuSpread1_Sheet1.Columns[0].Width = 50F;		//处方号
                this.neuSpread1_Sheet1.Columns[1].Width = 60F;		//姓名
                this.neuSpread1_Sheet1.Columns[2].Width = 35F;		//性别
                this.neuSpread1_Sheet1.Columns[3].Width = 35F;		//年龄
                this.neuSpread1_Sheet1.Columns[3].Visible = true;
                this.neuSpread1_Sheet1.Columns[4].Width = 70F;		//病历号
                this.neuSpread1_Sheet1.Columns[4].Visible = true;
                this.neuSpread1_Sheet1.Columns[5].Width = 80F;		//发票号
                this.neuSpread1_Sheet1.Columns[5].Visible = true;
                this.neuSpread1_Sheet1.Columns[6].Width = 70F;		//配药台
                this.neuSpread1_Sheet1.Columns[7].Width = 50F;		//配药人
                this.neuSpread1_Sheet1.Columns[8].Width = 120F;		//配药时间
                this.neuSpread1_Sheet1.Columns[9].Width = 70F;		//发药台
                this.neuSpread1_Sheet1.Columns[10].Width = 50F;		//发药人
                this.neuSpread1_Sheet1.Columns[11].Width = 120F;	//发药时间
                this.neuSpread1_Sheet1.Columns[12].Width = 60F;		//开方医生
            }

            //防止事件重复添加
            this.neuSpread1.ChildViewCreated -= new FarPoint.Win.Spread.ChildViewCreatedEventHandler(fpSpread1_ChildViewCreated);
            this.neuSpread1.ChildViewCreated += new FarPoint.Win.Spread.ChildViewCreatedEventHandler(fpSpread1_ChildViewCreated);
        }

        public override int Print(object sender, object neuObject)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

            if (this.neuSpread1_Sheet1.ActiveCell == null)
            {
                
                MessageBox.Show("没有查询出相关数据，打印无效!...");
                return 1;
            }
            else
            {
                Neusoft.HISFC.Models.Pharmacy.DrugRecipe info = drugManager.GetDrugRecipe(this.operDept.ID, this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRow.Index, 0].Text);
                string detailState = "0";

                if (info.RecipeState == "0" || info.RecipeState == "1")
                {
                    detailState = "0";
                }
                else if (info.RecipeState == "2")
                {
                    detailState = "1";
                }
                else
                {
                    detailState = "2";
                }

                ArrayList alInfo = new ArrayList();
                alInfo = this.itemManager.QueryApplyOutListForClinic(this.operDept.ID, "M1", detailState, info.RecipeNO);

                Print(info, alInfo);

                return base.Print(sender, neuObject);

            }


            
        }

        /// <summary>
        /// 执行打印
        /// </summary>
        /// <param name="al">打印数据</param>
        /// <returns>成功返回1 失败返回-1</returns>
        internal int Print(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe, ArrayList al)
        {
            //一次只打印一个处方号的
            //传入的时候按照组合号、院注标记分组 便于打印
            //applyOut.User01 发药窗口号 applyOut.User02 院注次数

            if (al.Count <= 0)
                return 1;

            Neusoft.HISFC.Models.Registration.Register patientInfo = null;		//患者信息

            #region 患者信息获取

            //获取患者信息
            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regManager = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
            patientInfo = regManager.GetByClinic(drugRecipe.ClinicNO);

            #endregion

            #region 中药房草药、成药打印
            if (this.isHerbalPrint)
            {
                patientInfo.User01 = drugRecipe.FeeOper.OperTime.ToString();

                patientInfo.DoctorInfo.Templet.Doct.Name = this.personHelper.GetName(drugRecipe.Doct.ID);

                Function.IDrugPrint.OutpatientInfo = patientInfo;

                Function.IDrugPrint.AddAllData(al);
                Function.IDrugPrint.Print();

                return 1;
            }
            #endregion

            #region 获取标签总页数
            string privCombo = "";												//上次医嘱组合号
            int iRecipeTotNum = 0;												//本次需打印标签总页数
            string recipeNo = "";		//处方号
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut temp in al)
            {
                //temp.SendWindow = this.terminal.SendWindow.Name;
                if (privCombo == temp.CombNO && temp.CombNO != "")
                {
                    continue;
                }
                else
                {
                    iRecipeTotNum = iRecipeTotNum + 1;
                    privCombo = temp.CombNO;
                }

                recipeNo = temp.RecipeNO;
            }
            #endregion

            Function.IDrugPrint.LabelTotNum = iRecipeTotNum;
            Function.IDrugPrint.DrugTotNum = al.Count;
            if (patientInfo != null)
            {
                patientInfo.User02 = al.Count.ToString();
                patientInfo.User01 = drugRecipe.FeeOper.OperTime.ToString();

                patientInfo.DoctorInfo.Templet.Doct.Name = this.personHelper.GetName(drugRecipe.Doct.ID);

                patientInfo.User03 = drugRecipe.RecipeNO;

                Function.IDrugPrint.OutpatientInfo = patientInfo;
            }

            privCombo = "-1";
            ArrayList alCombo = new ArrayList();

            if (true)
            {
                #region 标签打印
                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in al)
                {
                    //info.SendWindow = this.terminal.SendWindow.Name;
                    if (privCombo == "-1" || (privCombo == info.CombNO && info.CombNO != ""))
                    {
                        alCombo.Add(info);
                        privCombo = info.CombNO;
                        continue;
                    }
                    else			//不同处方号
                    {
                        if (alCombo.Count == 1)
                            Function.IDrugPrint.AddSingle(alCombo[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut);
                        else
                            Function.IDrugPrint.AddCombo(alCombo);
                        Function.IDrugPrint.Print();

                        privCombo = info.CombNO;
                        alCombo = new ArrayList();

                        alCombo.Add(info);
                    }
                }
                if (alCombo.Count == 0)
                {
                    return 1;
                }
                if (alCombo.Count > 1)
                {
                    Function.IDrugPrint.AddCombo(alCombo);
                }
                else
                {
                    Function.IDrugPrint.AddSingle(alCombo[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut);
                }

                Function.IDrugPrint.Print();

                #endregion
            }
            //else
            //{
            //    Function.IDrugPrint.AddAllData(al);
            //    Function.IDrugPrint.Print();
            //}

            return 1;
        }

        protected virtual bool IsValid()
        {
            DateTime dt1 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtBegin.Text);
            DateTime dt2 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtEnd.Text);
            if (dt1 >= dt2)
            {
                MessageBox.Show(Language.Msg("查询 开始时间应大于终止时间"));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        protected void QueryData()
        {
            this.isCanExplan = true;         //防止出现大红叉的必要标记位

            if (!this.IsValid())
            {
                return;
            }

            try
            {
                this.neuSpread1_Sheet1.DataSource = null;
                this.neuSpread1_Sheet1.Rows.Count = 0;

                DataSet dsData = new DataSet();

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询 请稍候...");
                Application.DoEvents();

                if (this.cmbQueryType.SelectedValue.ToString() == "D")
                {
                    if (this.txtQueryData.Text == "")
                        this.txtQueryData.Tag = "";
                    if (this.GetDrugDataSet(ref dsData, this.txtQueryData.Tag) == 1)
                    {
                        this.neuSpread1_Sheet1.DataSource = dsData;

                        this.SetFP();
                        this.ExpandFp(true);
                    }
                }
                else
                {
                    if (this.GetDataSet(ref dsData) == 1)
                    {
                        this.neuSpread1_Sheet1.DataSource = dsData;

                        this.SetFP();
                        this.ExpandFp(true);
                    }
                }

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取Sql索引
        /// </summary>
        /// <param name="isHead">是否头信息查询</param>
        /// <param name="strIndex">Sql语句索引</param>
        private void GetSqlIndex(bool isHead, ref string strIndex)
        {
            if (isHead)
            {
                if (this.ckBlurry.Checked)
                    strIndex = "Pharmacy.DrugStore.RecipeQuery.Head.2";
                else
                    strIndex = "Pharmacy.DrugStore.RecipeQuery.Head.1";
            }
            else
            {
                strIndex = "Pharmacy.DrugStore.RecipeQuery.Detail";
            }
        }

        /// <summary>
        /// 获取待查询数据
        /// </summary>
        /// <param name="queryData"></param>
        private void GetQueryData(ref string queryData)
        {
            switch (this.cmbQueryType.SelectedValue.ToString())
            {
                case "A":		//全部
                    queryData = "A";
                    break;
                case "0":		//病历卡号
                    queryData = this.txtQueryData.Text.PadLeft(8, '0');
                    break;
                case "1":		//发票号
                    queryData = this.txtQueryData.Text.PadLeft(12, '0');
                    break;
                case "2":		//姓名
                case "3":		//处方号
                    queryData = this.txtQueryData.Text;
                    break;
            }
        }

        /// <summary>
        /// 执行Sql语句 获取处方头信息
        /// </summary>
        /// <param name="dsData">查询后的DataSet</param>
        /// <returns></returns>
        private int GetDataSet(ref DataSet dsData)
        {
            dsData = new DataSet();
            DataTable dtHead = new DataTable("Head");
            DataTable dtDetail = new DataTable("Detail");
            DataSet dsHead = new DataSet();

            DateTime dt1 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtBegin.Text);
            DateTime dt2 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtEnd.Text);

            string strIndex = "";
            string strQueryData = "";

            this.GetSqlIndex(true, ref strIndex);
            this.GetQueryData(ref strQueryData);
            if (this.ckBlurry.Checked)
                strQueryData = "%" + strQueryData + "%";
            this.drugStoreManager.ExecQuery(strIndex, ref dsHead, dt1.ToString(), dt2.ToString(), strQueryData, this.cmbQueryType.SelectedValue.ToString(), this.operDept.ID);

            if (dsHead != null && dsHead.Tables.Count > 0 && dsHead.Tables[0].Rows.Count > 0)
            {
                dtHead = dsHead.Tables[0];
                dtHead.TableName = "Head";
                dsHead.Tables.Remove(dsHead.Tables[0]);
                string str = "";
                for (int i = 0; i < dtHead.Rows.Count; i++)
                {
                    DataSet dsDetail = new DataSet();
                    str = dtHead.Rows[i]["处方号"].ToString();

                    #region 设置显示 由编码转换为名称
                    dtHead.Rows[i]["年龄"] = this.drugStoreManager.GetAge(Neusoft.FrameWork.Function.NConvert.ToDateTime(dtHead.Rows[i]["年龄"].ToString()));
                    if (this.personHelper != null)
                    {
                        if (dtHead.Rows[i]["配药人"] != null && dtHead.Rows[i]["配药人"].ToString() != "")
                        {
                            dtHead.Rows[i]["配药人"] = this.personHelper.GetName(dtHead.Rows[i]["配药人"].ToString());
                        }
                        if (dtHead.Rows[i]["发药人"] != null && dtHead.Rows[i]["发药人"].ToString() != "")
                        {
                            dtHead.Rows[i]["发药人"] = this.personHelper.GetName(dtHead.Rows[i]["发药人"].ToString());
                        }
                        if (dtHead.Rows[i]["开方医生"] != null && dtHead.Rows[i]["开方医生"].ToString() != "")
                        {
                            dtHead.Rows[i]["开方医生"] = this.personHelper.GetName(dtHead.Rows[i]["开方医生"].ToString());
                        }
                    }
                    if (this.drugTerminalHelper != null)
                    {
                        if (dtHead.Rows[i]["配药台"] != null && dtHead.Rows[i]["配药台"].ToString() != "")
                        {
                            if (this.drugTerminalHelper.GetObjectFromID(dtHead.Rows[i]["配药台"].ToString()) != null)
                            {
                                dtHead.Rows[i]["配药台"] = this.drugTerminalHelper.GetName(dtHead.Rows[i]["配药台"].ToString());
                            }
                            else
                            {
                                dtHead.Rows[i]["配药台"] = "已删除台";
                            }
                        }
                    }
                    if (this.sendTerminalHelper != null)
                    {
                        if (dtHead.Rows[i]["发药台"] != null && dtHead.Rows[i]["发药台"].ToString() != "")
                        {
                            if (this.sendTerminalHelper.GetObjectFromID(dtHead.Rows[i]["发药台"].ToString()) != null)
                            {
                                dtHead.Rows[i]["发药台"] = this.sendTerminalHelper.GetName(dtHead.Rows[i]["发药台"].ToString());
                            }
                            else
                            {
                                dtHead.Rows[i]["发药台"] = "已删除窗";
                            }
                        }
                    }

                    if (dtHead.Rows[i]["性别"] != null)
                    {
                        switch (dtHead.Rows[i]["性别"].ToString())
                        {
                            case "M":
                                dtHead.Rows[i]["性别"] = "男";
                                break;
                            case "F":
                                dtHead.Rows[i]["性别"] = "女";
                                break;
                            case "U":
                                dtHead.Rows[i]["性别"] = "未知";
                                break;

                        }
                    }
                    #endregion

                    #region 配/发药日期显示

                    if (Neusoft.FrameWork.Function.NConvert.ToDateTime(dtHead.Rows[i]["配药时间"]) == System.DateTime.MinValue)
                    {
                        dtHead.Rows[i]["配药时间"] = "";
                    }
                    if (Neusoft.FrameWork.Function.NConvert.ToDateTime(dtHead.Rows[i]["发药时间"]) == System.DateTime.MinValue)
                    {
                        dtHead.Rows[i]["发药时间"] = "";
                    }

                    #endregion

                    this.GetSqlIndex(false, ref strIndex);
                    this.itemManager.ExecQuery(strIndex, ref dsDetail, str);
                    if (dsDetail != null && dsDetail.Tables.Count > 0 && dsDetail.Tables[0].Rows.Count > 0)
                    {
                        if (i == 0)
                        {
                            dtDetail = dsDetail.Tables[0];
                            dtDetail.TableName = "Detail";
                            dsDetail.Tables.Remove(dsDetail.Tables[0]);
                        }
                        else
                        {
                            for (int j = 0; j < dsDetail.Tables[0].Rows.Count; j++)
                            {
                                dtDetail.ImportRow(dsDetail.Tables[0].Rows[j]);
                            }
                        }
                    }
                }

                dsData.Tables.Add(dtHead);
                dsData.Tables.Add(dtDetail);
                try
                {
                    dsData.Relations.Add(dtHead.Columns["处方号"], dtDetail.Columns["处方号"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + "\n" + ex.Message);
                }
            }
            else
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// 执行Sql语句 获取处方明细信息
        /// </summary>
        /// <param name="dsData">处方明细信息</param>
        /// <param name="queryData"></param>
        /// <returns></returns>
        private int GetDrugDataSet(ref DataSet dsData, object queryData)
        {
            string drugCode = "";
            if (queryData == null || queryData.ToString() == "")
            {
                MessageBox.Show(Language.Msg("请选择查询药品"));
            }
            else
            {
                drugCode = queryData.ToString();
            }

            dsData = new DataSet();
            DataTable dtHead = new DataTable("Head");
            DataTable dtDetail = new DataTable("Detail");
            DataSet dsHead = new DataSet();
            string str = "";

            DateTime dt1 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtBegin.Text);
            DateTime dt2 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtEnd.Text);

            this.drugStoreManager.ExecQuery("Pharmacy.DrugStore.Recipe.DrugHead", ref dsHead, dt1.ToString(), dt2.ToString(), ((Neusoft.HISFC.Models.Base.Employee)this.itemManager.Operator).Dept.ID, drugCode);

            if (dsHead != null && dsHead.Tables.Count > 0 && dsHead.Tables[0].Rows.Count > 0)
            {
                dtHead = dsHead.Tables[0];
                dtHead.TableName = "Head";
                dsHead.Tables.Remove(dsHead.Tables[0]);
                for (int i = 0; i < dtHead.Rows.Count; i++)
                {
                    DataSet dsDetail = new DataSet();
                    str = dtHead.Rows[i]["药品编码"].ToString();
                    this.itemManager.ExecQuery("Pharmacy.DrugStore.Recipe.DrugDetail", ref dsDetail, dt1.ToString(), dt2.ToString(), ((Neusoft.HISFC.Models.Base.Employee)this.itemManager.Operator).Dept.ID, str);
                    if (dsDetail != null && dsDetail.Tables.Count > 0 && dsDetail.Tables[0].Rows.Count > 0)
                    {
                        if (i == 0)
                        {
                            dtDetail = dsDetail.Tables[0];
                            dtDetail.TableName = "Detail";
                            dsDetail.Tables.Remove(dsDetail.Tables[0]);
                        }
                        else
                        {
                            for (int j = 0; j < dsDetail.Tables[0].Rows.Count; j++)
                            {
                                dtDetail.ImportRow(dsDetail.Tables[0].Rows[j]);
                            }
                        }
                    }
                }

                dsData.Tables.Add(dtHead);

                dsData.Tables.Add(dtDetail);

                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    dtDetail.Rows[i]["年龄"] = this.itemManager.GetAge(Neusoft.FrameWork.Function.NConvert.ToDateTime(dtDetail.Rows[i]["年龄"].ToString()));

                    #region 配/发药日期显示

                    if (Neusoft.FrameWork.Function.NConvert.ToDateTime(dtDetail.Rows[i]["配药时间"]) == System.DateTime.MinValue)
                    {
                        dtDetail.Rows[i]["配药时间"] = "";
                    }
                    if (Neusoft.FrameWork.Function.NConvert.ToDateTime(dtDetail.Rows[i]["发药时间"]) == System.DateTime.MinValue)
                    {
                        dtDetail.Rows[i]["发药时间"] = "";
                    }

                    if (dtDetail.Rows[i]["开方医生"] != null && dtDetail.Rows[i]["开方医生"].ToString() != "")
                    {
                        dtDetail.Rows[i]["开方医生"] = this.personHelper.GetName(dtDetail.Rows[i]["开方医生"].ToString());
                    }

                    #endregion
                }

                try
                {
                    dsData.Relations.Add(dtHead.Columns["药品编码"], dtDetail.Columns["药品编码"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + "\n" + ex.Message);
                }
            }
            else
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// Fp显示展开
        /// </summary>
        /// <param name="isExpand"></param>
        private void ExpandFp(bool isExpand)
        {
            if (isCanExplan)
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    this.neuSpread1_Sheet1.ExpandRow(i, isExpand);
                }
            }
            if (isExpand)
            {
                this.btnExpand.Text = "全部合并";
            }
            else
            {
                this.btnExpand.Text = "全部展开";
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        private void Export()
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
        }

        protected override void OnLoad(EventArgs e)
        {

            try
            {
                this.operDept = ((Neusoft.HISFC.Models.Base.Employee)this.drugStoreManager.Operator).Dept;

                this.DataInit();

                #region 反射读取标签格式

                //string dllName = "Report";
                string className = "Neusoft.WinForms.Report.DrugStore.ucRecipeLabel";

                //门诊标签打印接口实现类
                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                string labelValue = "Neusoft.WinForms.Report.DrugStore.ucRecipeLabel";//ctrlIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Clinic_Print_Label, true, "Report.DrugStore.ucRecipeLabel");
                //门诊草药打印接口实现类
                string billValue = "Neusoft.WinForms.Report.DrugStore.ucOutHerbalBill";// ctrlIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Clinic_Print_Bill, true, "Report.DrugStore.ucOutHerbalBill");

                //默认标签打印
                className = labelValue;
                //读取本地控制参数 判断是否采用草药打印方式
                string strErr = "";
                ArrayList alParm = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("ClinicDrug", "PrintList", out strErr);
                if (alParm != null && alParm.Count > 0)
                {
                    if ((alParm[0] as string) == "1")
                    {
                        className = billValue;
                        this.isHerbalPrint = true;
                    }
                }

                object[] o = new object[] { };

                try
                {
                    System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("WinForms.Report", className, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);
                    object oLabel = objHandel.Unwrap();

                    // Neusoft.HISFC.Components.DrugStore.Function.IDrugPrint = oLabel as Neusoft.HISFC.BizProcess.Integrate.PharmacyInterface.IDrugPrint;
                    Neusoft.Report.Logistics.DrugStore.Function.IDrugPrint = oLabel as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint;

                }
                catch (System.TypeLoadException ex)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(Language.Msg("标签命名空间无效\n" + ex.Message));
                }

                #endregion
            }
            catch
            { }

            base.OnLoad(e);
        }

        private void fpSpread1_ChildViewCreated(object sender, FarPoint.Win.Spread.ChildViewCreatedEventArgs e)
        {
            e.SheetView.DataAutoCellTypes = false;
            e.SheetView.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            e.SheetView.DefaultStyle.BackColor = System.Drawing.Color.White;
            e.SheetView.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            e.SheetView.DataAutoSizeColumns = false;

            if (e.SheetView.Columns.Count > 7)
            {
                FarPoint.Win.Spread.CellType.NumberCellType numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCell.DecimalPlaces = 4;
                e.SheetView.Columns[7].CellType = numCell;
            }

            if (this.cmbQueryType.SelectedValue != null && this.cmbQueryType.SelectedValue.ToString() == "D")
            {
                e.SheetView.Columns[0].Visible = false;
                e.SheetView.Columns[0].Width = 50F;		//药品编码
                e.SheetView.Columns[1].Visible = true;
                e.SheetView.Columns[1].Width = 60F;		//姓名
                e.SheetView.Columns[2].Width = 35F;		//性别
                e.SheetView.Columns[3].Width = 35F;		//年龄
                e.SheetView.Columns[4].Width = 70F;		//病历号
                e.SheetView.Columns[5].Width = 80F;		//发票号
                e.SheetView.Columns[6].Width = 60F;		//配药数量
                e.SheetView.Columns[7].Width = 50F;		//配药人
                e.SheetView.Columns[8].Width = 120F;	//配药时间
                e.SheetView.Columns[9].Width = 60F;		//发药数量
                e.SheetView.Columns[10].Width = 50F;	//发药人
                e.SheetView.Columns[11].Width = 120F;	//发药时间
                e.SheetView.Columns[12].Width = 60F;	//开方医生

                e.SheetView.Columns[13].Visible = false;

                for (int i = 0; i < e.SheetView.Rows.Count; i++)
                {
                    if (e.SheetView.Cells[i, 13].Text == "0")
                    {
                        e.SheetView.Rows[i].ForeColor = System.Drawing.Color.Red;
                    }
                }

            }
            else
            {
                #region 普通格式化
                e.SheetView.Columns[0].Visible = false;			//处方号
                e.SheetView.Columns[1].Visible = false;			//有效性代码
                e.SheetView.Columns[2].Width = 184F;			//名称[规格]
                e.SheetView.Columns[3].Width = 80F;				//每次量 单位
                e.SheetView.Columns[4].Width = 60F;				//用法
                e.SheetView.Columns[5].Width = 60F;				//频次
                e.SheetView.Columns[6].Width = 80F;				//总量 单位
                e.SheetView.Columns[7].Width = 70F;				//零售价
                e.SheetView.Columns[8].Width = 100F;				//有效性

                for (int i = 0; i < e.SheetView.Rows.Count; i++)
                {
                    if (e.SheetView.Cells[i, 1].Text == "0")
                    {
                        e.SheetView.Rows[i].ForeColor = System.Drawing.Color.Red;
                    }
                }

                #region 增加合计
                try
                {
                    int iIndex = e.SheetView.Rows.Count;
                    e.SheetView.Rows.Add(iIndex, 1);
                    e.SheetView.Cells[iIndex, 0].Text = e.SheetView.Cells[0, 0].Text;
                    e.SheetView.Cells[iIndex, 2].Text = "合计";
                    e.SheetView.Cells[iIndex, 8].Formula = "SUM(I1:I" + iIndex.ToString() + ")";
                }
                catch { }
                #endregion

                #endregion
            }
        }

        private void btnExpand_Click(object sender, System.EventArgs e)
        {
            if (this.btnExpand.Text == "全部合并")
            {
                this.ExpandFp(false);
            }
            else
            {
                this.ExpandFp(true);
            }
        }

        private void txtQueryData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.QueryData();
            }
            if (e.KeyCode == Keys.Space && this.cmbQueryType.SelectedValue != null && this.cmbQueryType.SelectedValue.ToString() == "D" && this.drugCollectioon != null)
            {
                Neusoft.FrameWork.Models.NeuObject drugInfo = new Neusoft.FrameWork.Models.NeuObject();
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.drugCollectioon, new string[] { "编码", "商品名称", "规格" }, new bool[] { false, true, true, false, false, false, false, false, false }, new int[] { 100, 160, 80 }, ref drugInfo) == 0)
                {
                    return;
                }
                else
                {
                    this.txtQueryData.Text = drugInfo.Name;
                    this.txtQueryData.Tag = drugInfo.ID;

                    this.QueryData();
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Space && this.cmbQueryType.Focused)
            {
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        //打印预览
        public override int PrintPreview(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print printview = new Neusoft.FrameWork.WinForms.Classes.Print();

            //printview.PrintPreview(0, 0, this.neuTabControl1.SelectedTab);
            printview.PrintPreview(this.panel1);
            return base.OnPrintPreview(sender, neuObject);
        }

        //打印
        protected override int OnPrint(object sender, object neuObject)
        {

            this.neuSpread1.PrintSheet(0);
            return base.OnPrint(sender, neuObject);
        }
    }
}

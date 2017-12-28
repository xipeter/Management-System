using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using System.Collections;
using Neusoft.HISFC.BizLogic.Material;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Material.UndrugMatCompare
{
    public partial class ucUndrugMatCompare : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucUndrugMatCompare()
        {
            InitializeComponent();
        }


        #region 变量
        /// <summary>
        /// 物资科目替换
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper itemKindObjHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 生产厂家替换
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper operHelper = new Neusoft.FrameWork.Public.ObjectHelper();


        /// <summary>
        /// 物资仓库、科目管理
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Baseset basesetManager = new Neusoft.HISFC.BizLogic.Material.Baseset();
        /// <summary>
        /// 非药品项目业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeItem = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 非药品物资比较
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.UndrugMatCompare undrugMatManager = new Neusoft.HISFC.BizLogic.Material.UndrugMatCompare();
        /// <summary>
        /// 物资业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem metitem = new Neusoft.HISFC.BizLogic.Material.MetItem();
        /// <summary>
        /// 科室ID,NAME
        /// </summary>
        private Hashtable htExecDept = new Hashtable();
        /// <summary>
        /// 最小费用代码
        /// </summary>
        private Hashtable htFeeType = new Hashtable();

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt_mat = new DataTable();
        private DataTable dt_undrug = new DataTable();
        private DataTable dt_compare = new DataTable();

        private Neusoft.FrameWork.Public.ObjectHelper applicabilityAreaHelp = new Neusoft.FrameWork.Public.ObjectHelper();

        private Neusoft.FrameWork.Public.ObjectHelper produceHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        /// <summary>
        /// 哈希表
        /// </summary>
        private Hashtable htMat = new Hashtable();
        private Hashtable htUndrug = new Hashtable();

        /// <summary>
        /// 数据过滤
        /// </summary>
        private DataView dv_mat;
        private DataView dv_undrug;
        private DataView dv_compare;

        /// <summary>
        /// 委托
        /// </summary>
        public delegate void SaveInput(ArrayList arrayList);
        /// <summary>
        /// 物资维护控件
        /// </summary>




        //private ucUndrugMatManager frm = new ucUndrugMatManager();



        #endregion

        #region 初始化及数据表操作

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            this.txtFiler3.Focus();
            #region Fp屏蔽回车键
            InputMap im;

            im = this.fpCompare.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            //this.cmbLeach.AddItems(this.comCompany.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM));
            #endregion
            ArrayList alItemKind = new ArrayList();
            alItemKind = this.basesetManager.QueryKind();

            itemKindObjHelper.ArrayObject = alItemKind;
            //获得操作员姓名
            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            ArrayList personAl = personManager.GetEmployeeAll();
            if (personAl == null)
            {
                MessageBox.Show("获取全部人员列表出错!" + personManager.Err);
                return 0;
            }
            this.operHelper.ArrayObject = personAl;


            this.InitCompareDataSet();
            this.ShowCompareData();

            this.InitMatDataSet();
            this.ShowMatData();

            this.InitUndrugDataSet();
            this.ShowUndrugData();

            return 1;

        }

        #region 物资显示
        /// <summary>
        ///  初始化DataSet
        /// </summary>
        private void InitMatDataSet()
        {

            this.fpMat_Sheet1.DataAutoSizeColumns = true;


            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBool = System.Type.GetType("System.Boolean");

            //在dt中添加列
            this.dt_mat.Columns.AddRange(new DataColumn[] {
												new DataColumn("物品编码", dtStr),	 //0														   
												new DataColumn("物品科目", dtStr),  //1
												new DataColumn("物品名称", dtStr),     //2                                
												new DataColumn("拼音码", dtStr),     //3
												new DataColumn("五笔码", dtStr),     //4
												new DataColumn("自定义码", dtStr),    //5
												new DataColumn("国家编码", dtStr),    //6
												new DataColumn("规格", dtStr),         //7
												new DataColumn("单位", dtStr),          //8
												new DataColumn("单价", dtStr),           //9
												new DataColumn("财务收费标志",dtStr),     //10
												new DataColumn("批文信息", dtStr),        //11
												new DataColumn("医疗项目编码", dtStr),        //12
												new DataColumn("医疗项目名称", dtStr),     //13
												new DataColumn("非药品编码", dtStr),        //14
												new DataColumn("非药品名称", dtStr),       //15
												new DataColumn("停用标记", dtStr),       //16
												new DataColumn("特殊标志", dtStr),        //17
												new DataColumn("生产厂家", dtStr),        //18
												new DataColumn("供货公司", dtStr),        //19
												new DataColumn("费用代码", dtStr),        //20
												new DataColumn("统计代码", dtStr),          //21
                                                new DataColumn("科目编码",dtStr),          //22
												new DataColumn("包装单位",dtStr),          //23
												new DataColumn("包装数量",dtStr),          //24
												new DataColumn("包装价格",dtStr),          //25
												new DataColumn("加价规则",dtStr),         //26
												new DataColumn("仓库名称",dtStr),        //27
												new DataColumn("来源",dtStr),             //28
												new DataColumn("用途",dtStr)				//29						
														});

            this.dv_mat = new DataView(this.dt_mat);
            this.dv_mat.AllowEdit = true;
            this.dv_mat.AllowNew = true;
            this.fpMat.DataSource = this.dv_mat;

            this.fpMat_Sheet1.Columns[0].Visible = false;
            this.fpMat_Sheet1.Columns[3].Visible = false;
            this.fpMat_Sheet1.Columns[4].Visible = false;
            this.fpMat_Sheet1.Columns[5].Visible = false;
            this.fpMat_Sheet1.Columns[6].Visible = false;
            this.fpMat_Sheet1.Columns[12].Visible = false;
            this.fpMat_Sheet1.Columns[14].Visible = false;
            this.fpMat_Sheet1.Columns[15].Visible = false;
            this.fpMat_Sheet1.Columns[16].Visible = false;
            this.fpMat_Sheet1.Columns[17].Visible = false;
            this.fpMat_Sheet1.Columns[20].Visible = false;
            this.fpMat_Sheet1.Columns[21].Visible = false;
            this.fpMat_Sheet1.Columns[22].Visible = false;
        }

        /// <summary>
        /// 将传入数组中的数据显示在fpMat_sheet1中
        /// </summary>
        public void ShowMatData()
        {
            //this.ClearData();

            //取科目信息
            List<Neusoft.HISFC.Models.Material.MaterialItem> matlist = this.metitem.QueryMetItemByValidFlag(true);
            if (matlist == null)
            {
                MessageBox.Show(this.metitem.Err);
                return;
            }
            //循环插入物品基本信息
            for (int i = 0; i < matlist.Count; i++)
            {
                Neusoft.HISFC.Models.Material.MaterialItem myItem = matlist[i];

                DataRow dr_mat = dt_mat.NewRow();

                try
                {
                    //将数据插入到DataTable中
                    this.SetMatRow(dr_mat, myItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("{0}", ex.Message);
                    return;
                }

                dt_mat.Rows.Add(dr_mat);

                htMat.Add(myItem.ID, myItem);

            }





            #region 备份
            //foreach (Neusoft.HISFC.Models.Material.MaterialItem myItem in al)
            //{
            //    this.dt.Rows.Add(new Object[] {			
            //                                                        //物品编码																																

            //                                                         materialItem.ID, 

            //                                                         //物品科目
            //                                                           this.itemKindObjHelper.GetName(myItem.MaterialKind.ID.ToString()),

            //                                                            //物品名称
            //                                                            myItem.Name,

            //                                                            //科目名称
            //                                                            metKind.Name,

            //                                                            //拼音码
            //                                                            metKind.SpellCode.ToString(),

            //                                                            //五笔码
            //                                                            metKind.WBCode,

            //                                                            //最末级标识
            //                                                            metKind.EndGrade,

            //                                                            //需要卡片
            //                                                            metKind.IsCardNeed,//.ToString(),

            //                                                            //批次管理
            //                                                            metKind.IsBatch,//.ToString(),

            //                                                            //有效期管理
            //                                                            metKind.IsValidcon,//.ToString(),

            //                                                            //财务科目编码
            //                                                            metKind.AccountCode.ToString(),

            //                                                            //财务科目名称
            //                                                            metKind.AccountName.ToString(),

            //                                                            //操作员
            //                                                            //metKind.Oper.ID,

            //                                                            //操作日期
            //                                                            //metKind.OperateDate.ToString(),

            //                                                            //预计残值率
            //                                                            metKind.LeftRate.ToString(),

            //                                                            //是否固定资产
            //                                                            metKind.IsFixedAssets,//.ToString(),

            //                                                            //排列序号
            //                                                            metKind.OrderNo.ToString(),																		

            //                                                            //对应成本核算项目类别
            //                                                            metKind.StatCode,

            //                                                            //是否加价卫材
            //                                                            metKind.IsAddFlag//.ToString()
            //                                                        });
            //}
            #endregion
            //提交DataSet中的变化。
            this.dt_mat.AcceptChanges();


        }
        /// <summary>
        /// 将数据插入到DataTable中
        /// </summary>

        private DataRow SetMatRow(DataRow dr_mat, Neusoft.HISFC.Models.Material.MaterialItem myItem)
        {
            dr_mat["物品编码"] = myItem.ID;
            dr_mat["物品科目"] = this.itemKindObjHelper.GetName(myItem.MaterialKind.ID.ToString());
            dr_mat["物品名称"] = myItem.Name;
            dr_mat["拼音码"] = myItem.SpellCode;
            dr_mat["五笔码"] = myItem.WBCode;
            dr_mat["自定义码"] = myItem.UserCode;
            dr_mat["国家编码"] = myItem.GbCode;
            dr_mat["规格"] = myItem.Specs;
            dr_mat["单位"] = myItem.MinUnit;
            dr_mat["单价"] = myItem.UnitPrice.ToString();
            if (myItem.FinanceState)
            {
                dr_mat["财务收费标志"] = "是";
            }
            else
            {
                dr_mat["财务收费标志"] = "否";
            }
            dr_mat["批文信息"] = myItem.ApproveInfo;
            dr_mat["医疗项目编码"] = myItem.Compare.ID;
            dr_mat["医疗项目名称"] = myItem.Compare.Name;
            dr_mat["非药品编码"] = myItem.UndrugInfo.ID;
            dr_mat["非药品名称"] = myItem.UndrugInfo.Name;
            if (myItem.ValidState)
            {
                dr_mat["停用标记"] = "使用";
            }
            else
            {
                dr_mat["停用标记"] = "停用";
            }
            dr_mat["特殊标志"] = myItem.SpecialFlag;
            dr_mat["生产厂家"] = this.produceHelper.GetName(myItem.Factory.ID.ToString());
            dr_mat["供货公司"] = this.produceHelper.GetName(myItem.Company.ID.ToString());
            dr_mat["费用代码"] = myItem.MinFee.ID;
            dr_mat["统计代码"] = myItem.StatInfo.ID;
            dr_mat["科目编码"] = myItem.MaterialKind.ID;
            dr_mat["包装单位"] = myItem.PackUnit;
            dr_mat["包装数量"] = myItem.PackQty;
            dr_mat["包装价格"] = myItem.PackPrice;
            dr_mat["加价规则"] = myItem.AddRule;
            dr_mat["仓库名称"] = itemKindObjHelper.GetName(myItem.StorageInfo.ID);
            dr_mat["来源"] = myItem.InSource;
            dr_mat["用途"] = myItem.Usage;
            return dr_mat;

        }


        #endregion

        #region 非药品显示


        /// <summary>
        ///  初始化dt_undrug
        /// </summary>
        private void InitUndrugDataSet()
        {

            this.fpUndrug_Sheet1.DataAutoSizeColumns = true;


            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBool = System.Type.GetType("System.Boolean");

            //在dt中添加列
            this.dt_undrug.Columns.AddRange(new DataColumn[] { 
                                                               new DataColumn("项目编号", typeof(string)),                    //0 
                                                               new DataColumn("项目名称", typeof(string)),                    //1 
                                                               new DataColumn("系统类别", typeof(string)),                    //2 
                                                               new DataColumn("费用代码", typeof(string)),                    //3 
                                                               new DataColumn("输入码", typeof(string)),                      //4 
                                                               new DataColumn("拼音码", typeof(string)),                      //5 
                                                               new DataColumn("五笔码", typeof(string)),                      //6 
                                                               new DataColumn("国家编码", typeof(string)),                    //7 
                                                               new DataColumn("国际编码", typeof(string)),                    //8 
                                                               new DataColumn("默认价", typeof(string)),                      //9 
                                                               new DataColumn("单位", typeof(string)),                        //10
                                                               new DataColumn("急诊加成比例", typeof(string)),                //11
                                                               new DataColumn("计划生育标记", typeof(string)),                //12
                                                               new DataColumn("特定诊疗项目", typeof(string)),                //13
                                                               new DataColumn("甲乙类标志", typeof(string)),                  //14
                                                               new DataColumn("确认标志", typeof(string)),                    //15
                                                               new DataColumn("有效性标识", typeof(string)),                  //16
                                                               new DataColumn("规格", typeof(string)),                        //17
                                                               new DataColumn("执行科室", typeof(string)),                    //18
                                                               new DataColumn("设备编号", typeof(string)),                    //19
                                                               new DataColumn("标本", typeof(string)),                        //20
                                                               new DataColumn("手术编码", typeof(string)),                    //21
                                                               new DataColumn("手术分类", typeof(string)),                    //22
                                                               new DataColumn("手术规模", typeof(string)),                    //23
                                                               new DataColumn("是否对照", typeof(string)),                    //24
                                                               new DataColumn("备注", typeof(string)),                        //25
                                                               new DataColumn("儿童价", typeof(string)),                      //26
                                                               new DataColumn("特诊价", typeof(string)),                      //27
                                                               new DataColumn("省限制", typeof(string)),                      //28
                                                               new DataColumn("市限制", typeof(string)),                      //29
                                                               new DataColumn("自费项目", typeof(string)),                    //30
                                                               new DataColumn("特殊标识1", typeof(string)),                   //31
                                                               new DataColumn("特殊标识2", typeof(string)),                   //32
                                                               new DataColumn("单价1", typeof(string)),                       //33
                                                               new DataColumn("单价2", typeof(string)),                       //34
                                                               new DataColumn("疾病分类", typeof(string)),                    //35
                                                               new DataColumn("专科名称", typeof(string)),                    //36
                                                               new DataColumn("病史及检查", typeof(string)),                  //37
                                                               new DataColumn("检查要求", typeof(string)),                    //38
                                                               new DataColumn("注意事项", typeof(string)),                    //39
                                                               new DataColumn("知情同意书", typeof(string)),                  //40
                                                               new DataColumn("检查申请单名称", typeof(string)),              //41
                                                               new DataColumn("是否需要预约", typeof(string)),                //42
                                                               new DataColumn("项目范围", typeof(string)),                    //43
                                                               new DataColumn("项目约束", typeof(string)),                    //44
                                                               new DataColumn("单位标识", typeof(string)),                    //45
                                                               new DataColumn("适用范围",typeof(string))                      //46
                                                  });

            this.dv_undrug = new DataView(this.dt_undrug);
            this.dv_undrug.AllowEdit = true;
            this.dv_undrug.AllowNew = true;
            this.fpUndrug.DataSource = this.dv_undrug;

            this.fpUndrug_Sheet1.Columns[0].Visible = false;
            this.fpUndrug_Sheet1.Columns[3].Visible = false;
            this.fpUndrug_Sheet1.Columns[4].Visible = false;
            this.fpUndrug_Sheet1.Columns[5].Visible = false;
            this.fpUndrug_Sheet1.Columns[6].Visible = false;
            this.fpUndrug_Sheet1.Columns[7].Visible = false;
            this.fpUndrug_Sheet1.Columns[8].Visible = false;
            this.fpUndrug_Sheet1.Columns[11].Visible = false;
            this.fpUndrug_Sheet1.Columns[12].Visible = false;
            this.fpUndrug_Sheet1.Columns[13].Visible = false;
            this.fpUndrug_Sheet1.Columns[15].Visible = false;
            this.fpUndrug_Sheet1.Columns[19].Visible = false;
            this.fpUndrug_Sheet1.Columns[20].Visible = false;
            this.fpUndrug_Sheet1.Columns[21].Visible = false;
            this.fpUndrug_Sheet1.Columns[22].Visible = false;
            this.fpUndrug_Sheet1.Columns[23].Visible = false;
            this.fpUndrug_Sheet1.Columns[24].Visible = false;
            this.fpUndrug_Sheet1.Columns[30].Visible = false;
            this.fpUndrug_Sheet1.Columns[31].Visible = false;
            this.fpUndrug_Sheet1.Columns[32].Visible = false;
            this.fpUndrug_Sheet1.Columns[33].Visible = false;
            this.fpUndrug_Sheet1.Columns[34].Visible = false;
            this.fpUndrug_Sheet1.Columns[35].Visible = false;
            this.fpUndrug_Sheet1.Columns[36].Visible = false;
            this.fpUndrug_Sheet1.Columns[37].Visible = false;
            this.fpUndrug_Sheet1.Columns[38].Visible = false;
            this.fpUndrug_Sheet1.Columns[40].Visible = false;
            this.fpUndrug_Sheet1.Columns[41].Visible = false;
            this.fpUndrug_Sheet1.Columns[42].Visible = false;
            this.fpUndrug_Sheet1.Columns[43].Visible = false;
            this.fpUndrug_Sheet1.Columns[44].Visible = false;
            this.fpUndrug_Sheet1.Columns[45].Visible = false;

        }

        /// <summary>
        /// 将传入数组中的数据显示在fpMat_sheet1中
        /// </summary>
        public void ShowUndrugData()
        {
            //this.ClearData();

            //取科目信息
            List<Neusoft.HISFC.Models.Fee.Item.Undrug> itemList = this.feeItem.QueryAllItemsList();
            if (itemList == null)
            {
                MessageBox.Show(this.feeItem.Err);
                return;
            }
            //循环插入物品基本信息
            for (int i = 0; i < itemList.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = itemList[i];

                DataRow dr_undrug = dt_undrug.NewRow();

                try
                {
                    //将数据插入到DataTable中
                    this.SetUndrugRow(dr_undrug, undrug);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("{0}", ex.Message);
                    return;
                }

                dt_undrug.Rows.Add(dr_undrug);
                htUndrug.Add(undrug.ID, undrug);

            }

            //提交DataSet中的变化。
            this.dt_undrug.AcceptChanges();


        }
        /// <summary>
        /// 将数据插入到DataTable中
        /// </summary>

        private DataRow SetUndrugRow(DataRow dr_undrug, Neusoft.HISFC.Models.Fee.Item.Undrug undrug)
        {
            dr_undrug["项目编号"] = undrug.ID;
            dr_undrug["项目名称"] = undrug.Name;

            dr_undrug["系统类别"] = undrug.SysClass.Name;
            try
            {
                dr_undrug["执行科室"] = undrug.ExecDept == "" ? "" : this.htExecDept[undrug.ExecDept].ToString();
            }
            catch
            {
                dr_undrug["执行科室"] = "";
            }

            try
            {
                dr_undrug["费用代码"] = this.htFeeType[undrug.MinFee.ID].ToString();//
            }
            catch
            {
                dr_undrug["费用代码"] = "";
            }

            dr_undrug["输入码"] = undrug.UserCode;
            dr_undrug["拼音码"] = undrug.SpellCode;
            dr_undrug["五笔码"] = undrug.WBCode;
            dr_undrug["国家编码"] = undrug.GBCode;
            dr_undrug["国际编码"] = undrug.NationCode;
            dr_undrug["默认价"] = undrug.Price;
            dr_undrug["单位"] = undrug.PriceUnit;
            dr_undrug["急诊加成比例"] = undrug.FTRate.EMCRate.ToString();
            dr_undrug["计划生育标记"] = undrug.IsFamilyPlanning ? "真" : "假";

            //这个也有问题,以后再整吧
            dr_undrug["特定诊疗项目"] = undrug.User01;

            //没有转换，现在只是显示1或2
            switch (undrug.Grade)
            {
                case "1":
                    dr_undrug["甲乙类标志"] = "甲";
                    break;
                case "2":
                    dr_undrug["甲乙类标志"] = "乙";
                    break;
                case "3":
                    dr_undrug["甲乙类标志"] = "丙";
                    break;
                default:
                    dr_undrug["甲乙类标志"] = "";
                    break;
            }
            //dr["甲乙类标志"] = undrug.Grade;

            dr_undrug["确认标志"] = undrug.IsNeedConfirm ? "需要" : "不需要";
            switch (undrug.ValidState)
            {
                case "0":
                    dr_undrug["有效性标识"] = "停用";
                    break;
                case "1":
                    dr_undrug["有效性标识"] = "在用";
                    break;
                case "2":
                    dr_undrug["有效性标识"] = "废弃";
                    break;
                default:
                    dr_undrug["有效性标识"] = "";
                    break;
            }
            dr_undrug["规格"] = undrug.Specs;
            dr_undrug["设备编号"] = undrug.MachineNO;
            dr_undrug["标本"] = undrug.CheckBody;
            dr_undrug["手术编码"] = undrug.OperationInfo.ID;
            dr_undrug["手术分类"] = undrug.OperationType.ID;
            dr_undrug["手术规模"] = undrug.OperationScale.ID;
            dr_undrug["是否对照"] = undrug.IsCompareToMaterial ? "有" : "没有";
            dr_undrug["备注"] = undrug.Memo;
            dr_undrug["儿童价"] = undrug.ChildPrice.ToString();
            dr_undrug["特诊价"] = undrug.SpecialPrice.ToString();
            switch (undrug.SpecialFlag)
            {
                case "0":
                    dr_undrug["省限制"] = "不限制";
                    break;
                case "1":
                    dr_undrug["省限制"] = "限制";
                    break;
                default:
                    dr_undrug["省限制"] = "";
                    break;
            }
            switch (undrug.SpecialFlag1)
            {
                case "0":
                    dr_undrug["市限制"] = "不限制";
                    break;
                case "1":
                    dr_undrug["市限制"] = "限制";
                    break;
                default:
                    dr_undrug["市限制"] = "";
                    break;
            }
            switch (undrug.SpecialFlag2)
            {
                case "0":
                    dr_undrug["自费项目"] = "不是";
                    break;
                case "1":
                    dr_undrug["自费项目"] = "是";
                    break;
                default:
                    dr_undrug["自费项目"] = "";
                    break;
            }
            switch (undrug.SpecialFlag3)
            {
                case "0":
                    dr_undrug["特殊标识1"] = "不是";
                    break;
                case "1":
                    dr_undrug["特殊标识1"] = "是";
                    break;
                default:
                    dr_undrug["特殊标识1"] = "";
                    break;
            }
            switch (undrug.SpecialFlag4)
            {
                case "0":
                    dr_undrug["特殊标识2"] = "不是";
                    break;
                case "1":
                    dr_undrug["特殊标识2"] = "是";
                    break;
                default:
                    dr_undrug["特殊标识2"] = "";
                    break;
            }

            //还没用呢,估计会有问题
            dr_undrug["单价1"] = undrug.User02;

            //还没用呢,估计会有问题
            dr_undrug["单价2"] = undrug.User03;

            dr_undrug["疾病分类"] = undrug.DiseaseType.ID;
            dr_undrug["专科名称"] = undrug.SpecialDept.ID;
            dr_undrug["病史及检查"] = undrug.MedicalRecord;
            dr_undrug["检查要求"] = undrug.CheckRequest;
            dr_undrug["注意事项"] = undrug.Notice;
            dr_undrug["知情同意书"] = undrug.IsConsent ? "需要" : "不需要";
            dr_undrug["检查申请单名称"] = undrug.CheckApplyDept;
            dr_undrug["是否需要预约"] = undrug.IsNeedBespeak ? "需要" : "不需要";
            dr_undrug["项目范围"] = undrug.ItemArea;
            dr_undrug["项目约束"] = undrug.ItemException;
            dr_undrug["适用范围"] = this.applicabilityAreaHelp.GetName(undrug.ApplicabilityArea);
            /*单位标识(0,明细; 1,组套)[2007/01/01  xuweizhe]*/
            dr_undrug["单位标识"] = undrug.UnitFlag;
            return dr_undrug;

        }








        #endregion

        #region 比较表显示
        /// <summary>
        ///  初始化DataSet
        /// </summary>
        private void InitCompareDataSet()
        {
            this.fpCompare_Sheet1.DataAutoSizeColumns = true;


            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBool = System.Type.GetType("System.Boolean");

            //在dt中添加列
            this.dt_compare.Columns.AddRange(new DataColumn[] {
												new DataColumn("对照编号", dtStr),				//0											   
												new DataColumn("对照序号", dtStr),              //1
												new DataColumn("非药品编码", dtStr),            //2                      
												new DataColumn("非药品名称", dtStr),            //3
												new DataColumn("非药品拼音码", dtStr),          //4
												new DataColumn("非药品五笔", dtStr),            //5
												new DataColumn("非药品自定义码", dtStr),        //6
												new DataColumn("非药品国家编码", dtStr),        //7
												new DataColumn("物资编码", dtStr),              //8
												new DataColumn("物资名称", dtStr),              //9
												new DataColumn("物资拼音码",dtStr),             //10
												new DataColumn("物资五笔码", dtStr),            //11
												new DataColumn("物资自定义码", dtStr),          //12
												new DataColumn("物资国家编码", dtStr),          //13
												new DataColumn("操作员", dtStr),                //14
												new DataColumn("操作日期", dtStr),     		    //15				
														});

            //this.fpCompare_Sheet1.Rows[0].ForeColor = Color.Red
            this.fpCompare_Sheet1.Columns[0].Visible = false;
            this.fpCompare_Sheet1.Columns[1].Visible = false;
            this.fpCompare_Sheet1.Columns[2].Visible = false;
            this.fpCompare_Sheet1.Columns[4].Visible = false;
            this.fpCompare_Sheet1.Columns[5].Visible = false;
            this.fpCompare_Sheet1.Columns[6].Visible = false;
            this.fpCompare_Sheet1.Columns[7].Visible = false;
            this.fpCompare_Sheet1.Columns[8].Visible = false;
            this.fpCompare_Sheet1.Columns[10].Visible = false;
            this.fpCompare_Sheet1.Columns[11].Visible = false;
            this.fpCompare_Sheet1.Columns[12].Visible = false;
            this.fpCompare_Sheet1.Columns[13].Visible = false;
        }

        /// <summary>
        /// 将传入数组中的数据显示在fpMat_sheet1中
        /// </summary>
        public void ShowCompareData()
        {

            this.dt_compare.Rows.Clear();

            //取科目信息
            ArrayList al = this.undrugMatManager.UndrugMatCompareInfo();

            if (al == null)
            {
                MessageBox.Show(this.undrugMatManager.Err);
                return;
            }
            //循环插入物品基本信息
            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Material.UndrugMatCompare undrugmat = (Neusoft.HISFC.Models.Material.UndrugMatCompare)al[i];

                DataRow dr_compare = dt_compare.NewRow();

                try
                {
                    //将数据插入到DataTable中
                    this.SetCompareRow(dr_compare, undrugmat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("{0}", ex.Message);
                    return;
                }

                dt_compare.Rows.Add(dr_compare);

            }

            //提交DataSet中的变化。
            this.dt_compare.AcceptChanges();
            this.dv_compare = new DataView(this.dt_compare);
            this.dv_compare.AllowEdit = true;
            this.dv_compare.AllowNew = true;
            this.fpCompare.DataSource = this.dv_compare;


        }
        /// <summary>
        /// 将数据插入到DataTable中
        /// </summary>
        private DataRow SetCompareRow(DataRow dr_compare, Neusoft.HISFC.Models.Material.UndrugMatCompare umc)
        {


            dr_compare["对照编号"] = umc.ID;
            dr_compare["对照序号"] = umc.Compare_NO.ToString();
            dr_compare["非药品编码"] = umc.Undrug.ID;
            dr_compare["非药品名称"] = umc.Undrug.Name;
            dr_compare["非药品拼音码"] = umc.Undrug.SpellCode;
            dr_compare["非药品五笔"] = umc.Undrug.WBCode;
            dr_compare["非药品自定义码"] = umc.Undrug.UserCode;
            dr_compare["非药品国家编码"] = umc.Undrug.GBCode;
            dr_compare["物资编码"] = umc.MatItem.ID;
            dr_compare["物资名称"] = umc.MatItem.Name;
            dr_compare["物资拼音码"] = umc.MatItem.SpellCode;
            dr_compare["物资五笔码"] = umc.MatItem.WBCode;
            dr_compare["物资自定义码"] = umc.MatItem.UserCode;
            dr_compare["物资国家编码"] = umc.MatItem.GbCode;
            dr_compare["操作员"] = this.operHelper.GetName(umc.Oper.ID);
            dr_compare["操作日期"] = umc.Oper.OperTime;
            return dr_compare;

        }
        #endregion


        #endregion

        #region 私有方法

        private void frm_MyInput(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                this.fpCompare_Sheet1.Cells[this.fpCompare_Sheet1.ActiveRowIndex, i].Value = arrayList[i] as string;

            }
        }





        private bool IsExist(object undrugID, object matItemID)
        {

            //定义返回的BOOL值
            bool result = false;
            ArrayList al = new ArrayList();
            al = this.undrugMatManager.UndrugMatCompareInfo();
            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Material.UndrugMatCompare undrugmat = (Neusoft.HISFC.Models.Material.UndrugMatCompare)al[i];

                if (string.Equals(undrugmat.Undrug.ID, undrugID))
                {
                    if (string.Equals(undrugmat.MatItem.ID, matItemID))
                    {

                        result = true;
                        break;

                    }
                }
            }


            for (int i = 0; i < this.fpCompare_Sheet1.RowCount && !result; i++)
            {
                if (string.Equals(this.fpCompare_Sheet1.Cells[i, 2].Value, undrugID))
                {
                    if (string.Equals(this.fpCompare_Sheet1.Cells[i, 8].Value, matItemID))
                    {
                        result = true;
                        break;
                    }

                }


            }
            return result;
        }



        /// <summary>
        /// 对照表中显示选中的数据
        /// </summary>
        private void GetUndrugMat(Neusoft.HISFC.Models.Material.MaterialItem matItem, Neusoft.HISFC.Models.Fee.Item.Undrug undrug)
        {
            Neusoft.HISFC.Models.Material.UndrugMatCompare umc = new Neusoft.HISFC.Models.Material.UndrugMatCompare();
            this.fpCompare_Sheet1.Columns[0].Visible = false;
            this.fpCompare_Sheet1.Columns[1].Visible = false;
            if (this.IsExist(undrug.ID, matItem.ID))
            {
                MessageBox.Show("添加的数据对照表中已有，无需再添加！如果看不到，请刷新！");
                return;
            }
            umc.Undrug.ID = undrug.ID;
            umc.Undrug.Name = undrug.Name;
            umc.Undrug.SpellCode = undrug.SpellCode;
            umc.Undrug.WBCode = undrug.WBCode;
            umc.Undrug.UserCode = undrug.UserCode;
            umc.Undrug.GBCode = undrug.GBCode;
            umc.MatItem.ID = matItem.ID;
            umc.MatItem.Name = matItem.Name;
            umc.MatItem.SpellCode = matItem.SpellCode;
            umc.MatItem.WBCode = matItem.WBCode;
            umc.MatItem.UserCode = matItem.UserCode;
            umc.MatItem.GbCode = matItem.GbCode;
            umc.Oper.ID = this.operHelper.GetID(this.undrugMatManager.Operator.Name);
            umc.Oper.OperTime = System.DateTime.Now;

            DataRow dr_compare = dt_compare.NewRow();

            try
            {
                //将数据插入到DataTable中
                this.SetCompareRow(dr_compare, umc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("{0}", ex.Message);
                return;
            }

            dt_compare.Rows.Add(dr_compare);
            //提交DataSet中的变化。
            //this.dt_compare.AcceptChanges();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private int Save()
        {
            this.fpCompare.StopCellEditing();

            foreach (DataRow dr in this.dt_compare.Rows)
            {
                dr.EndEdit();
            }

            //定义数据库处理事务


            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.undrugMatManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            bool isUpdate = false; //判断是否更新或者删除过数据

            //取修改和增加的数据

            DataTable dataChanges = this.dt_compare.GetChanges(DataRowState.Modified | DataRowState.Added);

            if (dataChanges != null)
            {
                foreach (DataRow row in dataChanges.Rows)
                {
                    Neusoft.HISFC.Models.Material.UndrugMatCompare undrugMat = this.GetDataFromTable(row);

                    //执行更新操作，先更新，如果没有成功则插入新数据

                    if (this.undrugMatManager.SetUndrugMat(undrugMat) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("保存对照表信息发生错误!" + this.undrugMatManager.Err));
                        return -1;
                    }
                }
                dataChanges.AcceptChanges();

                isUpdate = true;
            }

            //取删除的数据
            dataChanges = this.dt_compare.GetChanges(DataRowState.Deleted);
            if (dataChanges != null)
            {
                dataChanges.RejectChanges();
                foreach (DataRow row in dataChanges.Rows)
                {
                    string UndrugMatID = row["对照编号"].ToString();        //公司编码		
                    //执行删除操作
                    if (this.undrugMatManager.Delete(UndrugMatID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("删除对照表中" + row["非药品名称"].ToString() + "发生错误" + this.undrugMatManager.Err));
                        return -1;
                    }
                }
                dataChanges.AcceptChanges();

                isUpdate = true;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (isUpdate)
            {
                MessageBox.Show(Language.Msg("保存成功！"));
            }
            else
            {
                MessageBox.Show("没做任何修改，无需保存！");
                return -1;
            }

            //刷新数据
            this.ShowCompareData();

            return 1;
        }

        private Neusoft.HISFC.Models.Material.UndrugMatCompare GetDataFromTable(DataRow row)
        {
            Neusoft.HISFC.Models.Material.UndrugMatCompare undrugmat = new Neusoft.HISFC.Models.Material.UndrugMatCompare();
            undrugmat.ID = row["对照编号"].ToString();
            undrugmat.Compare_NO = NConvert.ToInt32(row["对照序号"]);

            undrugmat.Undrug.ID = row["非药品编码"].ToString();
            undrugmat.Undrug.Name = row["非药品名称"].ToString();
            undrugmat.Undrug.SpellCode = row["非药品拼音码"].ToString();
            undrugmat.Undrug.WBCode = row["非药品五笔"].ToString();
            undrugmat.Undrug.UserCode = row["非药品自定义码"].ToString();
            undrugmat.Undrug.GBCode = row["非药品国家编码"].ToString();
            undrugmat.MatItem.ID = row["物资编码"].ToString();
            undrugmat.MatItem.Name = row["物资名称"].ToString();
            undrugmat.MatItem.SpellCode = row["物资拼音码"].ToString();
            undrugmat.MatItem.WBCode = row["物资五笔码"].ToString();
            undrugmat.MatItem.UserCode = row["物资自定义码"].ToString();
            undrugmat.MatItem.GbCode = row["物资国家编码"].ToString();
            undrugmat.Oper.Name = row["操作员"].ToString();
            return undrugmat;
        }


        /// <summary>
        /// 删除一条记录

        /// </summary>
        private void DeleteViewData()
        {
            if (this.fpCompare_Sheet1.Rows.Count <= 0)
            {
                return;
            }
            string undrugMatID = this.fpCompare_Sheet1.Cells[this.fpCompare_Sheet1.ActiveRowIndex, 0].Text;
            if ((undrugMatID == null) || (undrugMatID.Equals("")))
            {
                //在控件中删除此记录

                this.fpCompare_Sheet1.Rows.Remove(this.fpCompare_Sheet1.ActiveRowIndex, 1);
            }
            else
            {
                if (MessageBox.Show(Language.Msg("确认将第“" + ((int)(this.fpCompare_Sheet1.ActiveRowIndex + 1)).ToString() + "”对照表信息废弃吗？"), "确认对照表信息废弃", MessageBoxButtons.YesNo) == DialogResult.No)
                {

                    return;
                }
                //this.fpCompare_Sheet1.Rows[this.fpCompare_Sheet1.ActiveRowIndex].BackColor = Color.Red;
                this.fpCompare_Sheet1.Rows.Remove(this.fpCompare_Sheet1.ActiveRowIndex, 1);
            }
            return;
        }




        private void SetUndrugMat()
        {
            //int key = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpMat_Sheet1.Cells[this.fpMat_Sheet1.ActiveRowIndex, 0].Value.ToString());
            Neusoft.HISFC.Models.Material.MaterialItem matItem = new Neusoft.HISFC.Models.Material.MaterialItem();
            //key = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpUndrug_Sheet1.Cells[this.fpUndrug_Sheet1.ActiveRowIndex, 0].Value.ToString());
            Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();

            undrug.ID = this.fpUndrug_Sheet1.Cells[this.fpUndrug_Sheet1.ActiveRowIndex, 0].Value.ToString();
            undrug.Name = this.fpUndrug_Sheet1.Cells[this.fpUndrug_Sheet1.ActiveRowIndex, 1].Value.ToString();
            undrug.SpellCode = this.fpUndrug_Sheet1.Cells[this.fpUndrug_Sheet1.ActiveRowIndex, 5].Value.ToString();
            undrug.WBCode = this.fpUndrug_Sheet1.Cells[this.fpUndrug_Sheet1.ActiveRowIndex, 6].Value.ToString();
            undrug.UserCode = this.fpUndrug_Sheet1.Cells[this.fpUndrug_Sheet1.ActiveRowIndex, 4].Value.ToString();
            undrug.GBCode = this.fpUndrug_Sheet1.Cells[this.fpUndrug_Sheet1.ActiveRowIndex, 7].Value.ToString();
            matItem.ID = this.fpMat_Sheet1.Cells[this.fpMat_Sheet1.ActiveRowIndex, 0].Value.ToString();
            matItem.Name = this.fpMat_Sheet1.Cells[this.fpMat_Sheet1.ActiveRowIndex, 2].Value.ToString();
            matItem.SpellCode = this.fpMat_Sheet1.Cells[this.fpMat_Sheet1.ActiveRowIndex, 3].Value.ToString();
            matItem.WBCode = this.fpMat_Sheet1.Cells[this.fpMat_Sheet1.ActiveRowIndex, 4].Value.ToString();
            matItem.UserCode = this.fpMat_Sheet1.Cells[this.fpMat_Sheet1.ActiveRowIndex, 5].Value.ToString();
            matItem.GbCode = this.fpMat_Sheet1.Cells[this.fpMat_Sheet1.ActiveRowIndex, 6].Value.ToString();
            this.GetUndrugMat(matItem, undrug);


        }

        /// <summary>
        /// 通过输入的查询码，过滤数据列表

        /// </summary>
        private void Filter(DataTable dt, string filter, DataView dv)
        {
            if (dt.Rows.Count == 0) return;

            try
            {



                //设置过滤条件
                dv.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
            }
        }




        #endregion

        #region 工具栏



        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("删除", "删除对照表信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("确定", "对照表比较更新", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("刷新", "刷新对照表信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, null);



            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删除")
            {
                this.txtFiler3.Focus();
                this.DeleteViewData();
            }
            if (e.ClickedItem.Text == "确定")
            {
                this.SetUndrugMat();
            }
            if (e.ClickedItem.Text == "刷新")
            {
                //this.fpUndrug_Sheet1.Rows[0].BackColor=this.fpUndrug_Sheet1.SelectionBackColor ;


                //this.fpUndrug_Sheet1.ActiveRowIndex = 0;
                //this.fpUndrug_Sheet1.SetActiveCell(0, 0);
                this.txtFiler3.Focus();
                //this.fpUndrug_Sheet1.SetActiveCell(0,0);

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行数据初始化...请稍候");
                Application.DoEvents();
                this.ShowCompareData();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }

            base.ToolStrip_ItemClicked(sender, e);
        }


        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return 1;
        }






        #endregion

        #region 事件
        private void ucUndrugMatCompare_Load(object sender, EventArgs e)
        {


            if (!this.DesignMode)
            {
                #region 检查权限
                //Neusoft.FrameWork.Models.NeuObject myPrivDept = new Neusoft.FrameWork.Models.NeuObject();
                //int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0920", ref myPrivDept);

                //if (parma == -1)            //无权限
                //{
                //    MessageBox.Show(NFC.Management.Language.Msg("您无此窗口操作权限"));
                //    return;
                //}
                //else if (parma == 0)       //用户选择取消
                //{
                //    return;
                //}

                //this.workDept = myPrivDept;

                //base.OnStatusBarInfo(null, "操作科室： " + myPrivDept.Name);
                #endregion
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行数据初始化...请稍候");
                Application.DoEvents();


                this.Init();
                //this.InitFp();
                //this.InitList();

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();


            }

            this.fpUndrug_Sheet1.AddSelection(0, 0, 1, 46);
            this.fpMat_Sheet1.AddSelection(0, 0, 1, 30);
            this.txtFiler3.Focus();


        }

        private void txtFiler1_TextChanged(object sender, EventArgs e)
        {
            string queryCode = "";

            queryCode = "%" + this.txtFiler1.Text.Trim() + "%";
            string filter = "(非药品拼音码 LIKE '" + queryCode + "') OR " +
                            "(非药品五笔 LIKE '" + queryCode + "') OR " +
                            "(非药品自定义码 LIKE '" + queryCode + "') OR " +
                            "(物资拼音码 LIKE '" + queryCode + "') OR " +
                            "(物资五笔码 LIKE '" + queryCode + "') OR " +
                            "(物资自定义码 LIKE '" + queryCode + "') ";

            this.Filter(this.dt_compare, filter, this.dv_compare);
        }


        private void txtFiler2_TextChanged(object sender, EventArgs e)
        {
            //this.Filter(this.dt_mat, this.txtFiler2.Text.Trim());
            string queryCode = "";

            queryCode = "%" + this.txtFiler2.Text.Trim() + "%";
            string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                            "(五笔码 LIKE '" + queryCode + "') OR " +
                            "(自定义码 LIKE '" + queryCode + "') ";

            this.Filter(this.dt_mat, filter, this.dv_mat);

        }

        private void txtFiler3_TextChanged(object sender, EventArgs e)
        {
            string queryCode = "";

            queryCode = "%" + this.txtFiler3.Text.Trim() + "%";
            string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                            "(五笔码 LIKE '" + queryCode + "') OR " +
                            "(输入码 LIKE '" + queryCode + "') ";

            this.Filter(this.dt_undrug, filter, this.dv_undrug);


        }

        /// <summary>
        /// 对照表数据修改
        /// </summary>
        //private void fpCompare_CellDoubleClick(object sender, CellClickEventArgs e)
        //{
        //    ArrayList al = new ArrayList();
        //    for (int i = 0; i < this.fpCompare_Sheet1.ColumnCount; i++)
        //    {
        //        al.Add(this.fpCompare_Sheet1.Cells[this.fpCompare_Sheet1.ActiveRowIndex, i].Value);

        //    }

        //    al.Add(this.undrugMatManager.Operator.Name);
        //    this.frm.frmInit(al);
        //    this.frm.MyInput += new ucUndrugMatManager.SaveInput(frm_MyInput);

        //    this.frm.ShowDialog();
        //}


        private void txtFiler3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtFiler2.Focus();
            }
        }

        private void txtFiler2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtFiler1.Focus();
            }
        }

        #endregion

    }
}
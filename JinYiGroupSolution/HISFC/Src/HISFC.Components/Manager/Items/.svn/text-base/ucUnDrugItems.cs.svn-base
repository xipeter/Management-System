using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Neusoft.HISFC.Components.Manager.Items
{
    public partial class ucUnDrugItems : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 私有成员
        
        //private Neusoft.HISFC.BizLogic.Fee.Item item = new Neusoft.HISFC.BizLogic.Fee.Item();
        /// <summary>
        /// 非药品项目业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeItem = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 获取最小费用类别
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant cons = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 工具条
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 数据视图,用于过滤
        /// </summary>
        private DataView dvUndrugItem = new DataView();

        /// <summary>
        /// 配置文件的路径
        /// </summary>
        private string filePath = Application.StartupPath + @".\profile\UndrugItemSet.xml";

        /// <summary>
        /// 最小费用代码
        /// </summary>
        private Hashtable htFeeType = new Hashtable();

        /// <summary>
        /// 系统类别(注意: 键-名称, 值-ID),是为了方便使用所以才这样的,
        /// 如果改这个,那个要把 (过滤函数) 也一起改掉.
        /// </summary>
        private Hashtable htClassType = new Hashtable();

        /// <summary>
        /// 科室ID,NAME
        /// </summary>
        private Hashtable htExecDept = new Hashtable();

        private DataTable dataTable = new DataTable();
        private Neusoft.FrameWork.Public.ObjectHelper applicabilityAreaHelp = new Neusoft.FrameWork.Public.ObjectHelper();

        #endregion


        public ucUnDrugItems()
        {
            InitializeComponent();
        }

        private void ucUnDrugItems_Load(object sender, EventArgs e)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据...", false);
                Application.DoEvents();
                this.FpItems.DataSource = this.dataTable;


                CreateEmptyDS();
                FillMinFeeType();
                FillClassType();
                FillExecDept();
                FillFarPoint(/*CreateEmptyDS()*/);
                //this.FpItems.DataSource = this.dvUndrugItem;

                //Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.FpItems, this.filePath);

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
        /// <summary>
        /// 注册工具条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            //return base.OnInit(sender, neuObject, param);
            this.toolBarService.AddToolButton("设置列", "设置数据显示控件的列", 2, true, false, null);
            this.toolBarService.AddToolButton("添加", "添加数据", 1, true, false, null);
            this.toolBarService.AddToolButton("删除", "更改数据", 3, true, false, null);
            this.toolBarService.AddToolButton("导出数据", "导出数据到EXCEL文件", 8, true, false, null);
            return this.toolBarService;
        }

        
        /// <summary>
        /// 处理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //base.ToolStrip_ItemClicked(sender, e);
            switch (e.ClickedItem.Text.Trim())
            {
                case "设置列":
                    SetColumn();
                    break;
                case "添加":
                    AddItem();
                    break;
                case "删除":
                    DeleteRow();
                    break;
                case "导出数据":
                    ExportToExcel();
                    break;
                default: break;
            }

        }
        
        #region 工具条按钮处理函数

        /// <summary>
        /// 工具条:"设置列"按钮的处理函数
        /// </summary>
        private void SetColumn()
        {
            Neusoft.HISFC.Components.Common.Controls.ucSetColumn uc = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            //uc.DisplayEvent += new EventHandler(uc_DisplayEvent);
            uc.SetDataTable(this.filePath, this.FpItems);
            uc.DisplayEvent += new EventHandler(uc_DisplayEvent);

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }

        void uc_DisplayEvent(object sender, EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.FpItems, this.filePath);
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据...", false);
            Application.DoEvents();
            CreateEmptyDS();
            FillFarPoint(/*CreateEmptyDS()*/);
            //this.FpItems.DataSource = this.dvUndrugItem;

            //Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.FpItems, this.filePath);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 工具条:"添加"按钮的处理函数
        /// </summary>
        private void AddItem()
        {
            ucHandleItems handleItem = new ucHandleItems(true);
            handleItem.InsertSuccessed += new InsertSuccessHandler(handleItem_InsertSuccessed);
            handleItem.IsAddLine = true;
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(handleItem);
        }

        /// <summary>
        /// 工具条:"删除"按钮的处理函数
        /// </summary>
        private void DeleteRow()
        {
            if (MessageBox.Show("是否删除该项目,删除后将不能恢复", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            int index = this.FpItems.ActiveRow.Index;
            string code = this.FpItems.GetText(index, this.GetCloumn("项目编号"));

            //if(this.item.IsUsed(code))
            if (this.feeItem.IsUsed(code))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("项目已经使用,不能删除!"), "消息");
                return;
            }
            //if (this.item.DeleteUndrugItemByCode(code) <= 0)
            if( this.feeItem.DeleteUndrugItemByCode(code) <= 0 ) 
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("项目删除失败!"), "消息");
                return;
            }
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("项目删除成功!"), "消息");
            this.Delete();
        }

        /// <summary>
        /// 工具条:"导出"按钮处理程序
        /// </summary>
        private void ExportToExcel()
        {
            if (this.FpItems.Rows.Count == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有要保存的数据!"), "消息");
                return;
            }
            if (this.neuSpreadItems.Export() == 1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("数据导出成功!"), "消息");
            }
        }

        #endregion

        #region 私有辅助函数

        /// <summary>
        /// 生成DataSet
        /// </summary>
        /// <returns></returns>
        private /*DataSet*/void CreateEmptyDS()
        {
            //DataSet ds = new DataSet();

            #region 创建DataTable
            //DataTable dt = new DataTable();


            if (System.IO.File.Exists(this.filePath))
            {
                this.dataTable = new DataTable();
                //Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(this.filePath, this.dataTable, ref this.dvUndrugItem, this.FpItems);
                //Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.FpItems, this.filePath);
                //this.CreateTable();
                XmlDocument doc = new XmlDocument();
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(this.filePath, System.Text.Encoding.Default);
                    string streamXml = sr.ReadToEnd();
                    sr.Close();
                    doc.LoadXml(streamXml);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("读取Xml配置文件发生错误 请检查配置文件是否正确") + ex.Message);
                    return;
                }

                XmlNodeList nodes = doc.SelectNodes("//Column");

                string tempString = "";

                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["type"].Value == "TextCellType" || node.Attributes["type"].Value == "ComboBoxCellType")
                    {
                        tempString = "System.String";
                    }
                    else if (node.Attributes["type"].Value == "CheckBoxCellType")
                    {
                        tempString = "System.Boolean";
                    }
                    this.dataTable.Columns.Add(new DataColumn(node.Attributes["displayname"].Value,
                        System.Type.GetType(tempString)));
                }

                //this.FpItems.DataAutoHeadings = true;

                //this.dvUndrugItem = new DataView(this.dataTable);
                //this.FpItems.DataSource = this.dataTable;

                //Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.FpItems, this.filePath);
            }
            else
            {
                #region 暂时不用
                //this.dataTable = new DataTable();
                //this.dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("项目编号", typeof(string)),
                //                                   new DataColumn("项目名称", typeof(string)),
                //                                   new DataColumn("系统类别", typeof(string)),
                //                                   new DataColumn("费用代码", typeof(string)),
                //                                   new DataColumn("输入码", typeof(string)),
                //                                   new DataColumn("拼音码", typeof(string)),
                //                                   new DataColumn("五笔码", typeof(string)),
                //                                   new DataColumn("国家编码", typeof(string)),
                //                                   new DataColumn("国际编码", typeof(string)),
                //                                   new DataColumn("默认价", typeof(string)),
                //                                   new DataColumn("单位", typeof(string)),
                //                                   new DataColumn("急诊加成比例", typeof(string)),
                //                                   new DataColumn("计划生育标记", typeof(string)),
                //                                   new DataColumn("特定诊疗项目", typeof(string)),
                //                                   new DataColumn("甲乙类标志", typeof(string)),
                //                                   new DataColumn("确认标志", typeof(string)),
                //                                   new DataColumn("有效性标识", typeof(string)),
                //                                   new DataColumn("规格", typeof(string)),
                //                                   new DataColumn("执行科室", typeof(string)),
                //                                   new DataColumn("设备编号", typeof(string)),
                //                                   new DataColumn("标本", typeof(string)),
                //                                   new DataColumn("手术编码", typeof(string)),
                //                                   new DataColumn("手术分类", typeof(string)),
                //                                   new DataColumn("手术规模", typeof(string)),
                //                                   new DataColumn("是否对照", typeof(string)),
                //                                   new DataColumn("备注", typeof(string)),
                //                                   new DataColumn("儿童价", typeof(string)),
                //                                   new DataColumn("特诊价", typeof(string)),
                //                                   new DataColumn("省限制", typeof(string)),
                //                                   new DataColumn("市限制", typeof(string)),
                //                                   new DataColumn("自费项目", typeof(string)),
                //                                   new DataColumn("特殊标识1", typeof(string)),
                //                                   new DataColumn("特殊标识2", typeof(string)),
                //                                   new DataColumn("单价1", typeof(string)),
                //                                   new DataColumn("单价2", typeof(string)),
                //                                   new DataColumn("疾病分类", typeof(string)),
                //                                   new DataColumn("专科名称", typeof(string)),
                //                                   new DataColumn("病史及检查", typeof(string)),
                //                                   new DataColumn("检查要求", typeof(string)),
                //                                   new DataColumn("注意事项", typeof(string)),
                //                                   new DataColumn("知情同意书", typeof(string)),
                //                                   new DataColumn("检查申请单名称", typeof(string)),
                //                                   new DataColumn("是否需要预约", typeof(string)),
                //                                   new DataColumn("项目范围", typeof(string)),
                //                                   new DataColumn("项目约束", typeof(string)),
                //                                   new DataColumn("单位标识", typeof(string))
                //                                  });
                #endregion

                this.CreateTable();
                this.FpItems.DataSource = this.dataTable;
                //this.dvUndrugItem = new DataView(this.dataTable);
                //this.FpItems.DataSource = this.dvUndrugItem;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.FpItems, this.filePath);
            }


            //Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.FpItems, this.filePath);
            //this.dvUndrugItem.Table = this.dataTable;
            //this.dvUndrugItem.Sort = "项目编号 DESC";
            //Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(FpItems, filePath);

            DataColumn[] keys = new DataColumn[1];
            keys[0] = this.dataTable.Columns["项目编号"];
            this.dataTable.PrimaryKey = keys;
            #endregion
        }

        /// <summary>
        /// 填充"最小费用代码"控件
        /// </summary>
        private void FillMinFeeType()
        {
            ArrayList alMinFee = cons.GetAllList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE);
            if (alMinFee == null)
            {
                return;
            }
            for (int i = 0, j = alMinFee.Count; i < j; i++)
            {
                htFeeType.Add(((Neusoft.FrameWork.Models.NeuObject)alMinFee[i]).ID, ((Neusoft.FrameWork.Models.NeuObject)alMinFee[i]).Name);
            }

            this.cbFeeType.AddItems(alMinFee);
            ArrayList applicabilityArea = cons.GetAllList("APPLICABILITYAREA");
            if (applicabilityArea == null)
            {
                MessageBox.Show("获取适用范围失败 " + cons.Err);
            }
            applicabilityAreaHelp.ArrayObject = applicabilityArea; 
            //DictionaryEntry de;
            //IEnumerator en=this.htFeeType.GetEnumerator();
            //while (en.MoveNext())
            //{
            //    de = (DictionaryEntry)en.Current;
            //    this.cbFeeType.Items.Add(de.Value.ToString());
            //}
        }

        /// <summary>
        /// 填充"系统类别"控件
        /// </summary>
        private void FillClassType()
        {
            ArrayList alClassType = Neusoft.HISFC.Models.Base.SysClassEnumService.List();
            if (alClassType == null)
            {
                return;
            }

            for (int i = 0, j = alClassType.Count; i < j; i++)
            {
                htClassType.Add(((Neusoft.FrameWork.Models.NeuObject)alClassType[i]).ID, ((Neusoft.FrameWork.Models.NeuObject)alClassType[i]).Name);
            }

            this.cbClassType.AddItems(alClassType);
        }

        /// <summary>
        /// 获取所有执行科室
        /// </summary>
        private void FillExecDept()
        {
            Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();

            ArrayList alExecDept = dept.GetDeptmentAll();

            if (alExecDept == null)
            {
                return;
            }

            for (int i = 0, j = alExecDept.Count; i < j; i++)
            {
                this.htExecDept.Add(((Neusoft.FrameWork.Models.NeuObject)alExecDept[i]).ID, ((Neusoft.FrameWork.Models.NeuObject)alExecDept[i]).Name);
            }
        }

        /// <summary>
        /// 根据指定的列名,得到对应的位置索引
        /// </summary>
        /// <param name="name">列名</param>
        /// <returns>>=0:位置索引,  -1:失败</returns>
        private int GetCloumn(string name)
        {
            for (int i = 0; i < this.FpItems.Columns.Count; i++)
            {
                if (name == this.FpItems.Columns[i].Label)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 初始化FarPoint
        /// </summary>
        /// <param name="ds">数据集</param>
        private void FillFarPoint(/*DataSet ds*/)
        {
            //ArrayList alItems = this.feeItem.QueryValidItems();

            List<Neusoft.HISFC.Models.Fee.Item.Undrug> itemList = this.feeItem.QueryAllItemsList();

            if (itemList == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取项目失败!"));
                return;
            }
            if (this.FpItems.Rows.Count > 0)
            {
                this.FpItems.Rows.Remove(0, this.FpItems.Rows.Count);
            }

            #region
            
            for (int i = 0, j = itemList.Count; i < j; i++)
            {
                //Neusoft.HISFC.Models.Fee.Item.Undrug undrug = (Neusoft.HISFC.Models.Fee.Item.Undrug)alItems[i];
                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = itemList[i];
                //DataRow dr = ds.Tables[0].NewRow();
                DataRow dr;
                if (this.dataTable.Rows.Count > 0)
                {
                    if (this.dataTable.Rows.Find(undrug.ID.ToString()) == null)
                    {
                        dr = this.dataTable.NewRow();
                    }
                    else
                    {
                        throw new Exception("主键重复");
                    }
                }
                else
                {
                    dr = this.dataTable.NewRow();
                }

                dr["项目编号"] = undrug.ID;
                dr["项目名称"] = undrug.Name;

                dr["系统类别"] = undrug.SysClass.Name;
                try
                {
                    dr["执行科室"] = undrug.ExecDept == "" ? "" : this.htExecDept[undrug.ExecDept].ToString();
                }
                catch
                {
                    dr["执行科室"] = "";
                }

                try
                {
                    dr["费用代码"] = this.htFeeType[undrug.MinFee.ID].ToString();//
                }
                catch
                {
                    dr["费用代码"] = "";
                }

                dr["输入码"] = undrug.UserCode;
                dr["拼音码"] = undrug.SpellCode;
                dr["五笔码"] = undrug.WBCode;
                dr["国家编码"] = undrug.GBCode;
                dr["国际编码"] = undrug.NationCode;
                dr["默认价"] = undrug.Price;
                dr["单位"] = undrug.PriceUnit;
                dr["急诊加成比例"] = undrug.FTRate.EMCRate.ToString();
                dr["计划生育标记"] = undrug.IsFamilyPlanning ? "真" : "假";

                //这个也有问题,以后再整吧
                dr["特定诊疗项目"] = undrug.User01;

                //没有转换，现在只是显示1或2
                switch (undrug.Grade)
                {
                    case "1":
                        dr["甲乙类标志"] = "甲";
                        break;
                    case "2":
                        dr["甲乙类标志"] = "乙";
                        break;
                    case "3":
                        dr["甲乙类标志"] = "丙";
                        break;
                    default:
                        dr["甲乙类标志"] = "";
                        break;
                }
                //dr["甲乙类标志"] = undrug.Grade;

                dr["确认标志"] = undrug.IsNeedConfirm ? "需要" : "不需要";
                switch (undrug.ValidState)
                {
                    case "0":
                        dr["有效性标识"] = "停用";
                        break;
                    case "1":
                        dr["有效性标识"] = "在用";
                        break;
                    case "2":
                        dr["有效性标识"] = "废弃";
                        break;
                    default:
                        dr["有效性标识"] = "";
                        break;
                }
                dr["规格"] = undrug.Specs;
                dr["设备编号"] = undrug.MachineNO;
                dr["标本"] = undrug.CheckBody;
                dr["手术编码"] = undrug.OperationInfo.ID;
                dr["手术分类"] = undrug.OperationType.ID;
                dr["手术规模"] = undrug.OperationScale.ID;
                dr["是否对照"] = undrug.IsCompareToMaterial ? "有" : "没有";
                dr["备注"] = undrug.Memo;
                dr["儿童价"] = undrug.ChildPrice.ToString();
                dr["特诊价"] = undrug.SpecialPrice.ToString();
                switch (undrug.SpecialFlag)
                {
                    case "0":
                        dr["省限制"] = "不限制";
                        break;
                    case "1":
                        dr["省限制"] = "限制";
                        break;
                    default:
                        dr["省限制"] = "";
                        break;
                }
                switch (undrug.SpecialFlag1)
                {
                    case "0":
                        dr["市限制"] = "不限制";
                        break;
                    case "1":
                        dr["市限制"] = "限制";
                        break;
                    default:
                        dr["市限制"] = "";
                        break;
                }
                switch (undrug.SpecialFlag2)
                {
                    case "0":
                        dr["自费项目"] = "不是";
                        break;
                    case "1":
                        dr["自费项目"] = "是";
                        break;
                    default:
                        dr["自费项目"] = "";
                        break;
                }
                switch (undrug.SpecialFlag3)
                {
                    case "0":
                        dr["特殊标识1"] = "不是";
                        break;
                    case "1":
                        dr["特殊标识1"] = "是";
                        break;
                    default:
                        dr["特殊标识1"] = "";
                        break;
                }
                switch (undrug.SpecialFlag4)
                {
                    case "0":
                        dr["特殊标识2"] = "不是";
                        break;
                    case "1":
                        dr["特殊标识2"] = "是";
                        break;
                    default:
                        dr["特殊标识2"] = "";
                        break;
                }

                //还没用呢,估计会有问题
                dr["单价1"] = undrug.User02;

                //还没用呢,估计会有问题
                dr["单价2"] = undrug.User03;

                dr["疾病分类"] = undrug.DiseaseType.ID;
                dr["专科名称"] = undrug.SpecialDept.ID;
                dr["病史及检查"] = undrug.MedicalRecord;
                dr["检查要求"] = undrug.CheckRequest;
                dr["注意事项"] = undrug.Notice;
                dr["知情同意书"] = undrug.IsConsent ? "需要" : "不需要";
                dr["检查申请单名称"] = undrug.CheckApplyDept;
                dr["是否需要预约"] = undrug.IsNeedBespeak ? "需要" : "不需要";
                dr["项目范围"] = undrug.ItemArea;
                dr["项目约束"] = undrug.ItemException;
                dr["适用范围"] = this.applicabilityAreaHelp.GetName(undrug.ApplicabilityArea);
                /*单位标识(0,明细; 1,组套)[2007/01/01  xuweizhe]*/
                dr["单位标识"] = undrug.UnitFlag;

                this.dataTable.Rows.Add(dr);
            }
            #endregion

            this.dataTable.AcceptChanges();
            //this.dvUndrugItem.Sort = "项目编号 DESC";
            this.dvUndrugItem = this.dataTable.DefaultView;
            
            this.dvUndrugItem.Sort = "项目编号 DESC";
            this.FpItems.DataSource = this.dvUndrugItem;
            this.FpItems.Columns[31].Visible = false;
            this.FpItems.Columns[32].Visible = false;
            this.FpItems.Columns[33].Visible = false;
            this.FpItems.Columns[34].Visible = false;
            //this.FpItems.DataSource = this.dvUndrugItem;
        }

        /// <summary>
        /// 更新成功时事件处理程序中调用的函数
        /// </summary>
        /// <param name="undrug">非药品实体</param>
        private void Update(Neusoft.HISFC.Models.Fee.Item.Undrug undrug)
        {
            this.dvUndrugItem.Sort = "项目编号 DESC";
            DataRowView[] drvs = this.dvUndrugItem.FindRows(undrug.ID);
            this.dvUndrugItem.AllowEdit = true;
            drvs[0].BeginEdit();

            drvs[0]["项目编号"] = undrug.ID;
            drvs[0]["项目名称"] = undrug.Name;

            drvs[0]["系统类别"] = undrug.SysClass.Name;
            drvs[0]["执行科室"] = undrug.ExecDept == "" ? "" : this.htExecDept[undrug.ExecDept].ToString();
            drvs[0]["费用代码"] = this.htFeeType[undrug.MinFee.ID].ToString();//

            drvs[0]["输入码"] = undrug.UserCode;
            drvs[0]["拼音码"] = undrug.SpellCode;
            drvs[0]["五笔码"] = undrug.WBCode;
            drvs[0]["国家编码"] = undrug.GBCode;
            drvs[0]["国际编码"] = undrug.NationCode;
            drvs[0]["默认价"] = undrug.Price;
            drvs[0]["单位"] = undrug.PriceUnit;
            drvs[0]["急诊加成比例"] = undrug.FTRate.EMCRate.ToString();
            drvs[0]["计划生育标记"] = undrug.IsFamilyPlanning ? "真" : "假";

            //这个也有问题,以后再整吧
            drvs[0]["特定诊疗项目"] = undrug.User01;

            //没有转换，现在只是显示1或2
            switch (undrug.Grade)
            {
                case "1":
                    drvs[0]["甲乙类标志"] = "甲";
                    break;
                case "2":
                    drvs[0]["甲乙类标志"] = "乙";
                    break;
                case "3":
                    drvs[0]["甲乙类标志"] = "丙";
                    break;
                default:
                    drvs[0]["甲乙类标志"] = "";
                    break;
            }
            //dr["甲乙类标志"] = undrug.Grade;

            drvs[0]["确认标志"] = undrug.IsNeedConfirm ? "需要" : "不需要";
            switch (undrug.ValidState)
            {
                case "0":
                    drvs[0]["有效性标识"] = "停用";
                    break;
                case "1":
                    drvs[0]["有效性标识"] = "在用";
                    break;
                case "2":
                    drvs[0]["有效性标识"] = "废弃";
                    break;
                default:
                    drvs[0]["有效性标识"] = "";
                    break;
            }
            drvs[0]["规格"] = undrug.Specs;
            drvs[0]["设备编号"] = undrug.MachineNO;
            drvs[0]["标本"] = undrug.CheckBody;
            drvs[0]["手术编码"] = undrug.OperationInfo.ID;
            drvs[0]["手术分类"] = undrug.OperationType.ID;
            drvs[0]["手术规模"] = undrug.OperationScale.ID;
            drvs[0]["是否对照"] = undrug.IsCompareToMaterial ? "有" : "没有";
            drvs[0]["备注"] = undrug.Memo;
            drvs[0]["儿童价"] = undrug.ChildPrice.ToString();
            drvs[0]["特诊价"] = undrug.SpecialPrice.ToString();
            switch (undrug.SpecialFlag)
            {
                case "0":
                    drvs[0]["省限制"] = "不限制";
                    break;
                case "1":
                    drvs[0]["省限制"] = "限制";
                    break;
                default:
                    drvs[0]["省限制"] = "";
                    break;
            }
            switch (undrug.SpecialFlag1)
            {
                case "0":
                    drvs[0]["市限制"] = "不限制";
                    break;
                case "1":
                    drvs[0]["市限制"] = "限制";
                    break;
                default:
                    drvs[0]["市限制"] = "";
                    break;
            }
            switch (undrug.SpecialFlag2)
            {
                case "0":
                    drvs[0]["自费项目"] = "不是";
                    break;
                case "1":
                    drvs[0]["自费项目"] = "是";
                    break;
                default:
                    drvs[0]["自费项目"] = "";
                    break;
            }
            switch (undrug.SpecialFlag3)
            {
                case "0":
                    drvs[0]["特殊标识1"] = "不是";
                    break;
                case "1":
                    drvs[0]["特殊标识1"] = "是";
                    break;
                default:
                    drvs[0]["特殊标识1"] = "";
                    break;
            }
            switch (undrug.SpecialFlag4)
            {
                case "0":
                    drvs[0]["特殊标识2"] = "不是";
                    break;
                case "1":
                    drvs[0]["特殊标识2"] = "是";
                    break;
                default:
                    drvs[0]["特殊标识2"] = "";
                    break;
            }

            //还没用呢,估计会有问题
            drvs[0]["单价1"] = undrug.User02;

            //还没用呢,估计会有问题
            drvs[0]["单价2"] = undrug.User03;

            drvs[0]["疾病分类"] = undrug.DiseaseType.ID;
            drvs[0]["专科名称"] = undrug.SpecialDept.ID;
            drvs[0]["病史及检查"] = undrug.MedicalRecord;
            drvs[0]["检查要求"] = undrug.CheckRequest;
            drvs[0]["注意事项"] = undrug.Notice;
            drvs[0]["知情同意书"] = undrug.IsConsent ? "需要" : "不需要";
            drvs[0]["检查申请单名称"] = undrug.CheckApplyDept;
            drvs[0]["是否需要预约"] = undrug.IsNeedBespeak ? "需要" : "不需要";
            drvs[0]["项目范围"] = undrug.ItemArea;
            drvs[0]["项目约束"] = undrug.ItemException;
            drvs[0]["单位标识"] = undrug.UnitFlag;
            drvs[0]["适用范围"] = this.applicabilityAreaHelp.GetName(undrug.ApplicabilityArea);
            drvs[0].EndEdit();
        }

        /// <summary>
        /// 插入成功时事件处理程序中调用的函数
        /// </summary>
        /// <param name="undrug">非药品实体</param>
        private void Insert(Neusoft.HISFC.Models.Fee.Item.Undrug undrug)
        {
            this.dvUndrugItem.Sort = "项目编号 DESC";
            DataRowView drv = this.dvUndrugItem.AddNew();

            drv["项目编号"] = undrug.ID;
            drv["项目名称"] = undrug.Name;

            drv["系统类别"] = undrug.SysClass.Name;
            drv["执行科室"] = undrug.ExecDept == "" ? "" : this.htExecDept[undrug.ExecDept].ToString();
            drv["费用代码"] = this.htFeeType[undrug.MinFee.ID].ToString();//

            drv["输入码"] = undrug.UserCode;
            drv["拼音码"] = undrug.SpellCode;
            drv["五笔码"] = undrug.WBCode;
            drv["国家编码"] = undrug.GBCode;
            drv["国际编码"] = undrug.NationCode;
            drv["默认价"] = undrug.Price;
            drv["单位"] = undrug.PriceUnit;
            drv["急诊加成比例"] = undrug.FTRate.EMCRate.ToString();
            drv["计划生育标记"] = undrug.IsFamilyPlanning ? "真" : "假";

            //这个也有问题,以后再整吧
            drv["特定诊疗项目"] = undrug.User01;

            //没有转换，现在只是显示1或2
            switch (undrug.Grade)
            {
                case "1":
                    drv["甲乙类标志"] = "甲";
                    break;
                case "2":
                    drv["甲乙类标志"] = "乙";
                    break;
                case "3":
                    drv["甲乙类标志"] = "丙";
                    break;
                default:
                    drv["甲乙类标志"] = "";
                    break;
            }
            //dr["甲乙类标志"] = undrug.Grade;

            drv["确认标志"] = undrug.IsNeedConfirm ? "需要" : "不需要";
            switch (undrug.ValidState)
            {
                case "0":
                    drv["有效性标识"] = "停用";
                    break;
                case "1":
                    drv["有效性标识"] = "在用";
                    break;
                case "2":
                    drv["有效性标识"] = "废弃";
                    break;
                default:
                    drv["有效性标识"] = "";
                    break;
            }
            drv["规格"] = undrug.Specs;
            drv["设备编号"] = undrug.MachineNO;
            drv["标本"] = undrug.CheckBody;
            drv["手术编码"] = undrug.OperationInfo.ID;
            drv["手术分类"] = undrug.OperationType.ID;
            drv["手术规模"] = undrug.OperationScale.ID;
            drv["是否对照"] = undrug.IsCompareToMaterial ? "有" : "没有";
            drv["备注"] = undrug.Memo;
            drv["儿童价"] = undrug.ChildPrice.ToString();
            drv["特诊价"] = undrug.SpecialPrice.ToString();
            switch (undrug.SpecialFlag)
            {
                case "0":
                    drv["省限制"] = "不限制";
                    break;
                case "1":
                    drv["省限制"] = "限制";
                    break;
                default:
                    drv["省限制"] = "";
                    break;
            }
            switch (undrug.SpecialFlag1)
            {
                case "0":
                    drv["市限制"] = "不限制";
                    break;
                case "1":
                    drv["市限制"] = "限制";
                    break;
                default:
                    drv["市限制"] = "";
                    break;
            }
            switch (undrug.SpecialFlag2)
            {
                case "0":
                    drv["自费项目"] = "不是";
                    break;
                case "1":
                    drv["自费项目"] = "是";
                    break;
                default:
                    drv["自费项目"] = "";
                    break;
            }
            switch (undrug.SpecialFlag3)
            {
                case "0":
                    drv["特殊标识1"] = "不是";
                    break;
                case "1":
                    drv["特殊标识1"] = "是";
                    break;
                default:
                    drv["特殊标识1"] = "";
                    break;
            }
            switch (undrug.SpecialFlag4)
            {
                case "0":
                    drv["特殊标识2"] = "不是";
                    break;
                case "1":
                    drv["特殊标识2"] = "是";
                    break;
                default:
                    drv["特殊标识2"] = "";
                    break;
            }

            //还没用呢,估计会有问题
            drv["单价1"] = undrug.User02;

            //还没用呢,估计会有问题
            drv["单价2"] = undrug.User03;

            drv["疾病分类"] = undrug.DiseaseType.ID;
            drv["专科名称"] = undrug.SpecialDept.ID;
            drv["病史及检查"] = undrug.MedicalRecord;
            drv["检查要求"] = undrug.CheckRequest;
            drv["注意事项"] = undrug.Notice;
            drv["知情同意书"] = undrug.IsConsent ? "需要" : "不需要";
            drv["检查申请单名称"] = undrug.CheckApplyDept;
            drv["是否需要预约"] = undrug.IsNeedBespeak ? "需要" : "不需要";
            drv["项目范围"] = undrug.ItemArea;
            drv["项目约束"] = undrug.ItemException;
            drv["单位标识"] = undrug.UnitFlag;
            drv["适用范围"] =  this.applicabilityAreaHelp.GetName(undrug.ApplicabilityArea); 

            drv.EndEdit();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void Delete()
        {
            int index = this.FpItems.ActiveRow.Index;
            this.dvUndrugItem.Delete(index);
        }
                
        /// <summary>
        /// 过滤函数
        /// </summary>
        /// <param name="whereValue">输入码</param>
        /// <param name="sct">系统类别</param>
        /// <param name="sft">最小费用代码</param>
        private void GenerateRowFilter(string whereValue, string sct, string sft)
        {
            StringBuilder sb = new StringBuilder();
            this.dvUndrugItem.AllowDelete = true;
            this.dvUndrugItem.AllowEdit = true;
            this.dvUndrugItem.AllowNew = true;

            #region 不用
            //if (whereValue != "")
            //{
            //    sb.Append("输入码 like '");
            //    sb.Append(whereValue.ToUpper());
            //    sb.Append("%' or  拼音码 like '");
            //    sb.Append(whereValue.ToUpper());
            //    sb.Append("%' or 五笔码 like '");
            //    sb.Append(whereValue.ToUpper());
            //    sb.Append("%' ");
            //}
            //if (sct != "")
            //{
            //    if (whereValue != "")
            //    {
            //        sb.Append("and 系统类别='");
            //    }
            //    else
            //    {
            //        sb.Append(" 系统类别='");
            //    }
            //    sb.Append(sct);
            //    sb.Append("' ");
            //}
            //if (sft != "")
            //{
            //    if (whereValue != "" || sct != "")
            //    {
            //        sb.Append("and 费用代码='");
            //    }
            //    else
            //    {
            //        sb.Append(" 费用代码='");
            //    }
            //    sb.Append(sft);
            //    sb.Append("' ");
            //}

            //if (whereValue.Trim() == "" || sct.Trim() == "" || sft.Trim() == "")
            //{
            //    return;
            //}
            #endregion


            if (whereValue == "" && sft == "" && sct == "")
            {
                this.dvUndrugItem.RowFilter = "";
                this.dvUndrugItem.RowStateFilter = DataViewRowState.CurrentRows;
                return;
            }

            string where = whereValue.Trim().Equals("") ? "" : whereValue.ToUpper();
            string condition = "";
            if (where != "")
            {
                condition = "(输入码 like '" + where;
                condition += "%' or  拼音码 like '" + where;
                condition += "%' or 五笔码 like '" + where;
                condition += "%') ";
                if (sct == "")
                {
                    condition += " or 系统类别='";
                    condition += sct;
                    condition += "' ";
                }
                else
                {
                    condition += " and 系统类别='";
                    condition += sct;
                    condition += "' ";
                }
                if (sft == "")
                {
                    condition += " or 费用代码='";
                    condition += sft;
                    condition += "' ";
                }
                else
                {
                    condition += " and 费用代码='";
                    condition += sft;
                    condition += "' ";
                }
                this.dvUndrugItem.RowFilter = condition;
                this.dvUndrugItem.RowStateFilter = DataViewRowState.CurrentRows;
            }
            else
            {
                //如果以空格开始则返回
                if (whereValue.StartsWith(" ") || sct.StartsWith(" ") || sft.StartsWith(" "))
                {
                    return;
                }
                if (sct.Trim() != "" && sft.Trim() != "" )
                {
                    condition += " 系统类别='";
                    condition += sct.Trim();
                    condition += "' ";
                    condition += " and 费用代码='";
                    condition += sft.Trim();
                    condition += "' ";
                    this.dvUndrugItem.RowFilter = condition;
                    this.dvUndrugItem.RowStateFilter = DataViewRowState.CurrentRows;
                }
                else
                {
                    condition += " 系统类别='";
                    condition += sct.Trim();
                    condition += "' ";
                    condition += " or 费用代码='";
                    condition += sft.Trim();
                    condition += "' ";
                    this.dvUndrugItem.RowFilter = condition;
                    this.dvUndrugItem.RowStateFilter = DataViewRowState.CurrentRows;
                }
            }
            
            //this.dvUndrugItem.RowFilter = condition;
            //this.dvUndrugItem.RowStateFilter = DataViewRowState.CurrentRows;
        }

        private void CreateTable()
        {
            this.dataTable = new DataTable();

            this.dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("项目编号", typeof(string)),
                                                   new DataColumn("项目名称", typeof(string)),
                                                   new DataColumn("系统类别", typeof(string)),
                                                   new DataColumn("费用代码", typeof(string)),
                                                   new DataColumn("输入码", typeof(string)),
                                                   new DataColumn("拼音码", typeof(string)),
                                                   new DataColumn("五笔码", typeof(string)),
                                                   new DataColumn("国家编码", typeof(string)),
                                                   new DataColumn("国际编码", typeof(string)),
                                                   new DataColumn("默认价", typeof(string)),
                                                   new DataColumn("单位", typeof(string)),
                                                   new DataColumn("急诊加成比例", typeof(string)),
                                                   new DataColumn("计划生育标记", typeof(string)),
                                                   new DataColumn("特定诊疗项目", typeof(string)),
                                                   new DataColumn("甲乙类标志", typeof(string)),
                                                   new DataColumn("确认标志", typeof(string)),
                                                   new DataColumn("有效性标识", typeof(string)),
                                                   new DataColumn("规格", typeof(string)),
                                                   new DataColumn("执行科室", typeof(string)),
                                                   new DataColumn("设备编号", typeof(string)),
                                                   new DataColumn("标本", typeof(string)),
                                                   new DataColumn("手术编码", typeof(string)),
                                                   new DataColumn("手术分类", typeof(string)),
                                                   new DataColumn("手术规模", typeof(string)),
                                                   new DataColumn("是否对照", typeof(string)),
                                                   new DataColumn("备注", typeof(string)),
                                                   new DataColumn("儿童价", typeof(string)),
                                                   new DataColumn("特诊价", typeof(string)),
                                                   new DataColumn("省限制", typeof(string)),
                                                   new DataColumn("市限制", typeof(string)),
                                                   new DataColumn("自费项目", typeof(string)),
                                                   new DataColumn("特殊标识1", typeof(string)),
                                                   new DataColumn("特殊标识2", typeof(string)),
                                                   new DataColumn("单价1", typeof(string)),
                                                   new DataColumn("单价2", typeof(string)),
                                                   new DataColumn("疾病分类", typeof(string)),
                                                   new DataColumn("专科名称", typeof(string)),
                                                   new DataColumn("病史及检查", typeof(string)),
                                                   new DataColumn("检查要求", typeof(string)),
                                                   new DataColumn("注意事项", typeof(string)),
                                                   new DataColumn("知情同意书", typeof(string)),
                                                   new DataColumn("检查申请单名称", typeof(string)),
                                                   new DataColumn("是否需要预约", typeof(string)),
                                                   new DataColumn("项目范围", typeof(string)),
                                                   new DataColumn("项目约束", typeof(string)),
                                                   new DataColumn("单位标识", typeof(string)),
                                                   new DataColumn("适用范围",typeof(string))
                                                  });
        }

        #endregion
        private bool canModifyPrice = false;
        /// <summary>
        /// 是否允许修改价格
        /// </summary>
        [Category("控件设置"), Description("上线前是否允许修改价格")]
        public bool CanModifyPrice
        {
            get
            {
                return canModifyPrice;
            }
            set
            {
                canModifyPrice = value;
            }
        }
        private void tbQueryValue_TextChanged(object sender, EventArgs e)
        {
            string sClassType = "";
            string sFeeType = "";
            if (!this.cbClassType.Text.Equals("") && this.cbClassType.Text != null)
            {
                //sClassType = this.htClassType[this.cbClassType.Text].ToString();
                sClassType = this.cbClassType.Text;
            }
            if (!this.cbFeeType.Text.Equals("") && this.cbFeeType.Text != null)
            {
                sFeeType = this.cbFeeType.Text;//.ToString();
            }
            GenerateRowFilter(this.tbQueryValue.Text, sClassType, sFeeType);
            //GenerateRowFilter(this.tbQueryValue.Text, this.cbClassType.Text, this.cbFeeType.Text);
        }

        private void cbClassType_TextChanged(object sender, EventArgs e)
        {
            GenerateRowFilter(this.tbQueryValue.Text, this.cbClassType.Text, this.cbFeeType.Text);
        }

        private void cbFeeType_TextChanged(object sender, EventArgs e)
        {
            GenerateRowFilter(this.tbQueryValue.Text, this.cbClassType.Text, this.cbFeeType.Text);
        }

        private void neuSpreadItems_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();
            
            undrug.ID = this.FpItems.GetText(e.Row, this.GetCloumn("项目编号"));
            undrug.Name = this.FpItems.GetText(e.Row, this.GetCloumn("项目名称"));

            //系统类别
            undrug.SysClass.Name = this.FpItems.GetText(e.Row, this.GetCloumn("系统类别"));

            //最小费用代码
            undrug.MinFee.Name = this.FpItems.GetText(e.Row, this.GetCloumn("费用代码"));//

            //各种码
            undrug.UserCode = this.FpItems.GetText(e.Row, this.GetCloumn("输入码"));
            undrug.SpellCode = this.FpItems.GetText(e.Row, this.GetCloumn("拼音码"));
            undrug.WBCode = this.FpItems.GetText(e.Row, this.GetCloumn("五笔码"));
            undrug.GBCode = this.FpItems.GetText(e.Row, this.GetCloumn("国家编码"));
            undrug.NationCode = this.FpItems.GetText(e.Row, this.GetCloumn("国际编码"));
            string tempStr = FpItems.GetText(e.Row, this.GetCloumn("适用范围")); 
            undrug.ApplicabilityArea = applicabilityAreaHelp.GetID(tempStr); 

            //默认价
            undrug.Price = this.FpItems.GetText(e.Row, this.GetCloumn("默认价")) == "" ? 0 : Convert.ToDecimal(this.FpItems.GetText(e.Row, this.GetCloumn("默认价")));

            undrug.PriceUnit = this.FpItems.GetText(e.Row, this.GetCloumn("单位"));

            //急诊加成比例
            undrug.FTRate.EMCRate = this.FpItems.GetText(e.Row, this.GetCloumn("急诊加成比例")) == "" ? 0 : Convert.ToDecimal(this.FpItems.GetText(e.Row, 11));

            //计划生育标记
            undrug.IsFamilyPlanning = this.FpItems.GetText(e.Row, this.GetCloumn("计划生育标记")) == "真" ? true : false;

            //这个也有问题,以后再整吧
            //undrug.User01;//13;

            //甲乙类标志
            undrug.Grade = this.FpItems.GetText(e.Row, this.GetCloumn("甲乙类标志"));

            
            //是否需要确认
            undrug.IsNeedConfirm = this.FpItems.GetText(e.Row, this.GetCloumn("确认标志")) == "需要" ? true : false;

            //项目状态
            //switch (this.FpItems.GetText(e.Row, 16).Trim())
            //{
            //    case "在用":
            //        undrug.ValidState = "0";
            //        break;
            //    case "停用":
            //        undrug.ValidState = "1";
            //        break;
            //    case "废弃":
            //        undrug.ValidState = "2";
            //        break;
            //    default:
            //        undrug.ValidState = "";
            //        break;
            //}
            undrug.ValidState = this.FpItems.GetText(e.Row, this.GetCloumn("有效性标识")).Trim();

            //规格
            undrug.Specs = this.FpItems.GetText(e.Row, this.GetCloumn("规格"));
            undrug.ExecDept = this.FpItems.GetText(e.Row, this.GetCloumn("执行科室"));
            undrug.MachineNO = this.FpItems.GetText(e.Row, this.GetCloumn("设备编号"));
            undrug.CheckBody = this.FpItems.GetText(e.Row, this.GetCloumn("标本"));//

            //手术
            undrug.OperationInfo.ID = this.FpItems.GetText(e.Row, this.GetCloumn("手术编码"));
            undrug.OperationType.ID = this.FpItems.GetText(e.Row, this.GetCloumn("手术分类"));
            undrug.OperationScale.ID = this.FpItems.GetText(e.Row ,this.GetCloumn("手术规模"));

            //对照
            undrug.IsCompareToMaterial = this.FpItems.GetText(e.Row, this.GetCloumn("是否对照")) == "有" ? true : false; 
            
            undrug.Memo = this.FpItems.GetText(e.Row, this.GetCloumn("备注"));

            //儿童价
            undrug.ChildPrice = this.FpItems.GetText(e.Row, this.GetCloumn("儿童价")) == "" ? 0 : Convert.ToDecimal(this.FpItems.GetText(e.Row, 26));

            //特诊价
            undrug.SpecialPrice = this.FpItems.GetText(e.Row, this.GetCloumn("特诊价")) == "" ? 0 : Convert.ToDecimal(this.FpItems.GetText(e.Row, 27));

            switch (this.FpItems.GetText(e.Row, this.GetCloumn("省限制")).Trim())// undrug.SpecialFlag)
            {
                case "不限制":
                    undrug.SpecialFlag = "0";
                    break;
                case "限制":
                    undrug.SpecialFlag = "1";
                    break;
                default:
                    undrug.SpecialFlag = "";
                    break;
            }
            switch (this.FpItems.GetText(e.Row, this.GetCloumn("市限制")).Trim())// undrug.SpecialFlag1)
            {
                case "不限制":
                    undrug.SpecialFlag1 = "0";
                    break;
                case "限制":
                    undrug.SpecialFlag1 = "1";
                    break;
                default:
                    undrug.SpecialFlag1 = "";
                    break;
            }
            
            switch (this.FpItems.GetText(e.Row, this.GetCloumn("自费项目")).Trim())// undrug.SpecialFlag2)
            {
                case "不是":
                    undrug.SpecialFlag2 = "0";
                    break;
                case "是":
                    undrug.SpecialFlag2 = "1";
                    break;
                default:
                    undrug.SpecialFlag2 = "";
                    break;
            }
            switch (this.FpItems.GetText(e.Row, this.GetCloumn("特殊标识1")).Trim())// undrug.SpecialFlag3)
            {
                case "不是":
                    undrug.SpecialFlag3 = "0";
                    break;
                case "是":
                    undrug.SpecialFlag3 = "1";
                    break;
                default:
                    undrug.SpecialFlag3 = "";
                    break;
            }
            switch (this.FpItems.GetText(e.Row, this.GetCloumn("特殊标识2")).Trim())// undrug.SpecialFlag4)
            {
                case "不是":
                    undrug.SpecialFlag4 = "0";
                    break;
                case "是":
                    undrug.SpecialFlag4 = "1";
                    break;
                default:
                    undrug.SpecialFlag4 = "";
                    break;
            }

            //还没用呢,估计会有问题
            //undrug.User02;//33

            //还没用呢,估计会有问题
            //undrug.User03;//34
            
            undrug.DiseaseType.ID = this.FpItems.GetText(e.Row, this.GetCloumn("疾病分类"));
            undrug.SpecialDept.ID = this.FpItems.GetText(e.Row, this.GetCloumn("专科名称"));
            undrug.MedicalRecord = this.FpItems.GetText(e.Row, this.GetCloumn("病史及检查"));
            undrug.CheckRequest = this.FpItems.GetText(e.Row, this.GetCloumn("检查要求"));
            undrug.Notice = this.FpItems.GetText(e.Row, this.GetCloumn("注意事项"));
            undrug.IsConsent = this.FpItems.GetText(e.Row, this.GetCloumn("知情同意书")) == "需要" ? true : false;
            undrug.CheckApplyDept = this.FpItems.GetText(e.Row, this.GetCloumn("检查申请单名称"));
            undrug.IsNeedBespeak = this.FpItems.GetText(e.Row, this.GetCloumn("是否需要预约")) == "需要" ? true : false;
            undrug.ItemArea = this.FpItems.GetText(e.Row, this.GetCloumn("项目范围"));
            undrug.ItemException = this.FpItems.GetText(e.Row, this.GetCloumn("项目约束"));


            //单位标识(0,明细; 1,组套)[2007/01/01  xuweizhe]
            undrug.UnitFlag = this.FpItems.GetText(e.Row, this.GetCloumn("单位标识"));

            ucHandleItems handleItem = new ucHandleItems(false);
            handleItem.SaveSuccessed += new SaveSuccessHandler(handleItem_SaveSuccessed);
            handleItem.UpdateUndrugItems(undrug);
            handleItem.CanModifyPrice = canModifyPrice;
            handleItem.IsAddLine = false;
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(handleItem);
        }

        private void neuSpreadItems_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.FpItems, this.filePath);

        }

        #region 自定义事件处理函数

        /// <summary>
        /// 更新成功处理函数
        /// </summary>
        /// <param name="undrug">非药品项目实体</param>
        void handleItem_SaveSuccessed(Neusoft.HISFC.Models.Fee.Item.Undrug undrug)
        {
            //throw new Exception("The method or operation is not implemented.");
            this.Update(undrug);
        }

        /// <summary>
        /// 插入成功处理函数
        /// </summary>
        /// <param name="undrug">非药品项目实体</param>
        void handleItem_InsertSuccessed(Neusoft.HISFC.Models.Fee.Item.Undrug undrug)
        {
            Insert(undrug);
            //throw new Exception("The method or operation is not implemented.");

        }

        #endregion

        private void neuSpreadItems_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        /* 不用了,但是还得留着.
        private void cbClassType_SelectedValueChanged(object sender, EventArgs e)
        {
            GenerateRowFilter(this.tbQueryValue.Text, this.cbClassType.Text, this.cbFeeType.Text);
        }
        private void cbFeeType_SelectedValueChanged(object sender, EventArgs e)
        {
            GenerateRowFilter(this.tbQueryValue.Text, this.cbClassType.Text, this.cbFeeType.Text);
        }
        private void cbClassType_TextUpdate(object sender, System.EventArgs e)
        {
            GenerateRowFilter(this.tbQueryValue.Text, this.cbClassType.Text, this.cbFeeType.Text);
        }

        private void cbFeeType_TextUpdate(object sender, System.EventArgs e)
        {
            GenerateRowFilter(this.tbQueryValue.Text, this.cbClassType.Text, this.cbFeeType.Text);
        }
        */
    }
}
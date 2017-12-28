using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml;
using Neusoft.HISFC.Models.Material;


namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>		
    /// ucMaterialQuery的摘要说明。<br></br>
    /// [功能描述: 物资信息查询]<br></br>
    /// [创 建 者: 李超]<br></br>
    /// [创建时间: 2007-03-28<br></br>
    /// </summary>
    public partial class ucMaterialQuery : UserControl
    {
        public ucMaterialQuery()
        {
            InitializeComponent();
        }

        #region 管理类

        /// <summary>
        /// 物资字典管理
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem materialManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 物资管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store matManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 物资仓库、科目管理
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Baseset basesetManager = new Neusoft.HISFC.BizLogic.Material.Baseset();

        /// <summary>
        /// 物资供货公司管理
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.ComCompany companyManager = new Neusoft.HISFC.BizLogic.Material.ComCompany();

        /// <summary>
        /// 物资科目替换
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper itemKindObjHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 生产厂家替换
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper produceHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 供货公司替换
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper companyHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        #endregion

        #region 变量

        /// <summary>
        /// XML路径
        /// </summary>
        private string filePath = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "\\MaterialItem.xml";

        /// <summary>
        /// 物资基本信息实体
        /// </summary>
        private Neusoft.HISFC.Models.Material.MaterialItem materialItem = new Neusoft.HISFC.Models.Material.MaterialItem();

        /// <summary>
        /// 与选择列表关联的DataSet
        /// </summary>
        private DataSet myDataSet;

        /// <summary>
        /// 数据集
        /// </summary>
        protected DataTable myDataTable = new DataTable();

        /// <summary>
        /// 数据视图
        /// </summary>
        private DataView dv;

        /// <summary>
        /// 供货公司使用的数组
        /// </summary>
        private ArrayList alCompany = new ArrayList();

        /// <summary>
        /// 生产厂家使用的数组
        /// </summary>
        private ArrayList alFactory = new ArrayList();

        /// <summary>
        /// 物资科目使用的数组
        /// </summary>
        private ArrayList alItemKind = new ArrayList();

        /// <summary>
        /// 物资字典数组
        /// </summary>
        private List<Neusoft.HISFC.Models.Material.MaterialItem> nowDrugList = new List<Neusoft.HISFC.Models.Material.MaterialItem>();

        /// <summary>
        /// 最小费用代码数组
        /// </summary>
        private ArrayList alFeeCode = new ArrayList();

        /// <summary>
        /// 统计代码数组
        /// </summary>
        private ArrayList alStatCode = new ArrayList();

        /// <summary>
        /// 加价规则数组
        /// </summary>
        private ArrayList alAddRule = new ArrayList();

        /// <summary>
        /// 存储仓库数组
        /// </summary>
        private ArrayList alStorCode = new ArrayList();

        /// <summary>
        /// 当前物资科目级别
        /// </summary>
        private string matKind = "";

        /// <summary>
        /// 是否已对MyInput事件处理函数进行过注册
        /// </summary>
        private bool isEventRegister = false;

        /// <summary>
        /// 只读属性
        /// </summary>
        private bool isEditExpediency = true;

        /// <summary>
        /// 删除时 是否采用更新状态为'2' 的方式 (不实际删除)
        /// </summary>
        private bool isDelToUpdateState = false;

        public delegate void SaveInput(Neusoft.HISFC.Models.Pharmacy.Item item);

        public string storageCode;//liuxq add

        /// <summary>
        /// 物资维护控件
        /// </summary>
        private ucMaterialManager MainteranceUC = null;

        /// <summary>
        /// 物资维护窗口
        /// </summary>
        private System.Windows.Forms.Form MainteranceForm = null;

        #endregion

        #region 属性

        // <summary>
        /// XML路径属性
        /// </summary>
        public string FilePath
        {
            set
            {
                try
                {
                    this.filePath = value;
                }
                catch
                {
                    this.filePath = ".\\PharmacyManager.xml";
                }
            }
        }

        /// <summary>
        /// 物资科目级别编码
        /// </summary>
        public string MatKind
        {
            get
            {
                return this.matKind;
            }
            set
            {
                this.matKind = value;
            }
        }

        /// <summary>
        /// 是否拥有修改权限 1 有修改权限 0 无修改权限
        /// </summary>
        public bool EditExpediency
        {
            set
            {
                this.isEditExpediency = value;
            }
        }

        /// <summary>
        /// DataView
        /// </summary>
        public DataView DefaultDataView
        {
            get { return dv; }
        }

        #endregion

        #region 维护弹出窗口

        /// <summary>
        /// 维护弹出窗口 需继承自Material.Base.ucMaterialManager
        /// </summary>
        public Material.Base.ucMaterialManager MaintenancePopUC
        {
            set
            {
                if (value != null && value as Material.Base.ucMaterialManager == null)
                {
                    System.Windows.Forms.MessageBox.Show("该维护控件需继承自Material.Base.ucMaterialManager");
                }
                else
                {
                    this.MainteranceUC = value as Material.Base.ucMaterialManager;

                    this.MainteranceUC.MyInput -= new ucMaterialManager.SaveInput(ucMaterialManager_MyInput);
                    this.MainteranceUC.MyInput += new ucMaterialManager.SaveInput(ucMaterialManager_MyInput);
                }
            }
        }

        /// <summary>
        /// 设置维护窗口
        /// </summary>
        private void InitMaintenanceForm()
        {
            if (this.MainteranceUC == null)
            {
                this.MainteranceUC = new Material.Base.ucMaterialManager();
                this.MainteranceUC.MyInput -= new Material.Base.ucMaterialManager.SaveInput(ucMaterialManager_MyInput);
                this.MainteranceUC.MyInput += new Material.Base.ucMaterialManager.SaveInput(ucMaterialManager_MyInput);
            }
            if (this.MainteranceForm == null)
            {
                this.MainteranceForm = new Form();
                this.MainteranceForm.Width = this.MainteranceUC.Width + 10;
                this.MainteranceForm.Height = this.MainteranceUC.Height + 25;
                this.MainteranceForm.Text = "物品详细信息维护";
                this.MainteranceForm.StartPosition = FormStartPosition.CenterScreen;
                this.MainteranceForm.ShowInTaskbar = false;
                this.MainteranceForm.HelpButton = false;
                this.MainteranceForm.MaximizeBox = false;
                this.MainteranceForm.MinimizeBox = false;
                this.MainteranceForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            }


            this.MainteranceUC.Dock = DockStyle.Fill;
            this.MainteranceForm.Controls.Add(this.MainteranceUC);
        }

        /// <summary>
        /// 维护窗口显示
        /// </summary>
        private void ShowMaintenanceForm(string inputType, Neusoft.HISFC.Models.Material.MaterialItem item, bool isShow)
        {
            if (this.MainteranceForm == null || this.MainteranceUC == null)
                this.InitMaintenanceForm();

            this.MainteranceUC.InputType = inputType;
            this.MainteranceUC.Item = item;
            this.MainteranceUC.MatKind = this.MatKind;
            this.MainteranceUC.storageCode = storageCode;
            this.MainteranceUC.ReadOnly = !this.isEditExpediency;

            if (isShow)
            {
                this.MainteranceForm.ShowDialog();
            }
        }

        #endregion

        #region 方法

        #region 初始化数据

        /// <summary>
        /// 设置DataTable中的列
        /// 如果本地目录下面存在列的配置文件，则按此文件显示列，否则设定DataTable的初始列
        /// </summary>
        /// <param name="table"></param>
        private void SetColumn(DataTable table)
        {
            if (System.IO.File.Exists(this.filePath))
            {
                #region 由Xml配置文件内读取列设置
                XmlDocument doc = new XmlDocument();
                try
                {
                    StreamReader sr = new StreamReader(this.filePath, System.Text.Encoding.Default);
                    string cleandown = sr.ReadToEnd();
                    sr.Close();
                    doc.LoadXml(cleandown);
                }
                catch { return; }

                XmlNodeList nodes = doc.SelectNodes("//Column");

                string tempString = "";

                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["type"].Value == "TextCellType")
                    {
                        tempString = "System.String";
                    }
                    else if (node.Attributes["type"].Value == "CheckBoxCellType")
                    {
                        tempString = "System.Boolean";
                    }

                    table.Columns.Add(new DataColumn(node.Attributes["displayname"].Value,
                        System.Type.GetType(tempString)));
                }
                #endregion
            }
            else
            {
                #region 采用默认DataTable设置 显示
                //定义类型
                System.Type dtStr = System.Type.GetType("System.String");
                System.Type dtDec = System.Type.GetType("System.Decimal");
                System.Type dtDTime = System.Type.GetType("System.DateTime");
                System.Type dtBool = System.Type.GetType("System.Boolean");
                table.Columns.AddRange(new DataColumn[]{
															new DataColumn("物品编码", dtStr),															   
															new DataColumn("物品科目", dtStr),  
															new DataColumn("物品名称", dtStr),                                     
															new DataColumn("拼音码", dtStr),     
															new DataColumn("五笔码", dtStr),   
															new DataColumn("自定义码", dtStr),   
															new DataColumn("国家编码", dtStr),   
															new DataColumn("规格", dtStr),   
															new DataColumn("单位", dtStr),   
															new DataColumn("单价", dtStr), 
															new DataColumn("财务收费标志",dtStr),
															new DataColumn("批文信息", dtStr),   
															new DataColumn("医疗项目编码", dtStr),       
															new DataColumn("医疗项目名称", dtStr),   
															new DataColumn("非药品编码", dtStr),   
															new DataColumn("非药品名称", dtStr),     
															new DataColumn("停用标记", dtStr),     
															new DataColumn("特殊标志", dtStr), 
															new DataColumn("生产厂家", dtStr),       
															new DataColumn("供货公司", dtStr),       
															new DataColumn("费用代码", dtStr),       
															new DataColumn("统计代码", dtStr),
                                                            new DataColumn("科目编码",dtStr),
															new DataColumn("包装单位",dtStr),
															new DataColumn("包装数量",dtStr),
															new DataColumn("包装价格",dtStr),
															new DataColumn("加价规则",dtStr),
															new DataColumn("仓库名称",dtStr),
															new DataColumn("来源",dtStr),
															new DataColumn("用途",dtStr)
														});

                this.fpMaterialQuery_Sheet1.DataSource = table;
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpMaterialQuery_Sheet1, this.filePath);
                #endregion
            }

            DataColumn[] keys = new DataColumn[1];
            keys[0] = table.Columns["物品编码"];
            table.PrimaryKey = keys;

            for (int i = 0; i < this.fpMaterialQuery_Sheet1.Columns.Count; i++)
            {
                this.fpMaterialQuery_Sheet1.Columns[i].Locked = true;
            }
        }


        /// <summary>
        /// 将传入的数组中的数据保存在myDataSet中
        /// </summary>
        /// <param name="al">物资字典数组</param>
        public int InitDataSet(List<Neusoft.HISFC.Models.Material.MaterialItem> al)
        {
            alItemKind = this.basesetManager.QueryKind();

            alFactory = this.companyManager.QueryCompany("0", "A");

            alCompany = this.companyManager.QueryCompany("1", "A");

            nowDrugList = al;

            itemKindObjHelper.ArrayObject = this.alItemKind;
            produceHelper.ArrayObject = this.alFactory;
            produceHelper.ArrayObject = this.alCompany;

            myDataSet = new DataSet();

            myDataSet.EnforceConstraints = true;//是否遵循约束规则

            myDataSet.Tables.Clear();

            //定义表并增加到myDataSet中
            DataTable myDataTable = myDataSet.Tables.Add("MaterialItem");

            //从XML中读取列顺序,长度等属性
            this.SetColumn(myDataTable);

            DataRow newRow;

            Neusoft.HISFC.Models.Material.MaterialItem myItem;

            //循环插入物品基本信息
            for (int i = 0; i < al.Count; i++)
            {
                myItem = (Neusoft.HISFC.Models.Material.MaterialItem)al[i];

                newRow = myDataTable.NewRow();

                try
                {
                    //将数据插入到DataTable中
                    this.SetRow(newRow, myItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n请删除程序目录下的文件:" + this.filePath, "错误提示");
                    return -1;
                }

                myDataTable.Rows.Add(newRow);

            }

            dv = new DataView(myDataSet.Tables[0]);

            this.fpMaterialQuery.DataSource = dv;

            for (int i = 0; i < this.fpMaterialQuery_Sheet1.Columns.Count; i++)
            {
                this.fpMaterialQuery_Sheet1.Columns[i].Locked = true;
            }

            this.SetColor();

            return 1;
        }

        /// <summary>
        /// 将停用的物资项目设为红色
        /// </summary>
        private void SetColor()
        {
            for (int i = 0; i < this.fpMaterialQuery_Sheet1.Rows.Count; i++)
            {
                if (this.fpMaterialQuery_Sheet1.Cells[i, 16].Text == "停用")
                {
                    this.fpMaterialQuery_Sheet1.Rows[i].ForeColor = Color.Red;
                }
                else
                {
                    this.fpMaterialQuery_Sheet1.Rows[i].ForeColor = Color.Black;
                }
            }
        }


        /// <summary>
        /// 向DataSet中插入数据
        /// </summary>
        /// <param name="row"></param>
        /// <param name="myItem"></param>
        /// <returns></returns>
        private DataRow SetRow(DataRow row, Neusoft.HISFC.Models.Material.MaterialItem myItem)
        {
            row["物品编码"] = myItem.ID;
            row["物品科目"] = this.itemKindObjHelper.GetName(myItem.MaterialKind.ID.ToString());
            row["物品名称"] = myItem.Name;
            row["拼音码"] = myItem.SpellCode;
            row["五笔码"] = myItem.WBCode;
            row["自定义码"] = myItem.UserCode;
            row["国家编码"] = myItem.GbCode;
            row["规格"] = myItem.Specs;
            row["单位"] = myItem.MinUnit;
            row["单价"] = myItem.UnitPrice.ToString();
            if (myItem.FinanceState)
            {
                row["财务收费标志"] = "是";
            }
            else
            {
                row["财务收费标志"] = "否";
            }
            row["批文信息"] = myItem.ApproveInfo;
            row["医疗项目编码"] = myItem.Compare.ID;
            row["医疗项目名称"] = myItem.Compare.Name;
            row["非药品编码"] = myItem.UndrugInfo.ID;
            row["非药品名称"] = myItem.UndrugInfo.Name;
            if (myItem.ValidState)
            {
                row["停用标记"] = "使用";
            }
            else
            {
                row["停用标记"] = "停用";
            }
            row["特殊标志"] = myItem.SpecialFlag;
            row["生产厂家"] = this.produceHelper.GetName(myItem.Factory.ID.ToString());
            row["供货公司"] = this.produceHelper.GetName(myItem.Company.ID.ToString());
            row["费用代码"] = myItem.MinFee.ID;
            row["统计代码"] = myItem.StatInfo.ID;
            row["科目编码"] = myItem.MaterialKind.ID;
            row["包装单位"] = myItem.PackUnit;
            row["包装数量"] = myItem.PackQty;
            row["包装价格"] = myItem.PackPrice;
            row["加价规则"] = myItem.AddRule;
            row["仓库名称"] = itemKindObjHelper.GetName(myItem.StorageInfo.ID);
            row["来源"] = myItem.InSource;
            row["用途"] = myItem.Usage;
            return row;

        }


        #endregion

        /// <summary>
        /// 清空当前数据
        /// </summary>
        public void Clear()
        {
            this.fpMaterialQuery_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        public void Modify()
        {
            if (this.fpMaterialQuery_Sheet1.Rows.Count == 0)
                return;

            DataRow findRow;

            MaterialItem myItem = null;
            myItem = this.materialManager.GetMetItemByMetID(this.fpMaterialQuery_Sheet1.Cells[this.fpMaterialQuery_Sheet1.ActiveRowIndex, this.dv.Table.Columns.IndexOf("物品编码")].Value.ToString());

            this.ShowMaintenanceForm("U", myItem, true);

            findRow = dv.Table.Rows.Find(myItem.ID.ToString());

            if (findRow != null)
            {
                //根据编码取全部信息并显示在列表中
                myItem = materialManager.GetMetItemByMetID(myItem.ID.ToString());
                this.SetRow(findRow, myItem);
            }
            this.SetColor();
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        public void Copy()
        {
            if (this.fpMaterialQuery_Sheet1.Rows.Count == 0)
                return;

            MaterialItem myItem = null;
            myItem = materialManager.GetMetItemByMetID(this.fpMaterialQuery_Sheet1.Cells[this.fpMaterialQuery_Sheet1.ActiveRowIndex, this.dv.Table.Columns.IndexOf("物品编码")].Value.ToString());

            myItem.ID = "";

            this.ShowMaintenanceForm("I", myItem, true);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        public void Add()
        {
            MaterialItem myItem = null;
            myItem = new MaterialItem();
            myItem.StorageInfo.ID = storageCode;
            myItem.MaterialKind.ID = this.MatKind;

            this.ShowMaintenanceForm("I", myItem, true);

            this.SetColor();
        }

        /// <summary>
        /// 控件中增加显示一条数据
        /// </summary>
        /// <param name="obj"></param>
        public void AddNewRow(Neusoft.HISFC.Models.Material.MaterialItem obj)
        {
            DataRow newRow = dv.Table.NewRow();

            this.SetRow(newRow, obj);

            dv.Table.Rows.Add(newRow);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete()
        {
            if (this.fpMaterialQuery_Sheet1.Rows.Count == 0)
                return;

            int parm;
            string itemID = "";

            itemID = this.fpMaterialQuery_Sheet1.Cells[this.fpMaterialQuery_Sheet1.ActiveRowIndex, this.dv.Table.Columns.IndexOf("物品编码")].Value.ToString();

            int count = this.matManager.GetMatStorageRowNum(itemID);

            if (count > 0)
            {
                MessageBox.Show("此物品在库存中已存在,不允许删除!", "删除提示");
                return;
            }

            if (count < 0)
            {
                MessageBox.Show("获取此物品在库存中的总条数出错");
                return;
            }

            System.Windows.Forms.DialogResult dr;
            dr = MessageBox.Show("请谨慎确定是否删除该物品?", "提示!", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            if (this.isDelToUpdateState)
            {
                #region

                Neusoft.HISFC.Models.Material.MaterialItem itemTemp = this.materialManager.GetMetItemByMetID(itemID);
                if (itemTemp != null)
                {

                }

                #endregion
            }
            else
            {
                #region 数据删除

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //t.BeginTransaction();

                materialManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //删除
                parm = materialManager.DeleteMetItem(itemID);

                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.materialManager.Err);
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show("删除成功！");
                }

                //在DataTable中查找此物品
                DataRow findRow;

                Object[] obj = new object[1];

                obj[0] = itemID.ToString();

                findRow = dv.Table.Rows.Find(obj);

                //从DataTable中删除此物品
                if (findRow != null)
                {
                    dv.Table.Rows.Remove(findRow);
                }

                #endregion
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void Export()
        {

        }

        /// <summary>
        /// 根据传入的过滤条件,过滤数据
        /// </summary>
        /// <param name="filter">过滤条件</param>
        public void SetFilter(string filter)
        {
            //过滤数据
            this.dv.RowFilter = filter;

            //如果存在配置文件，则调用配置文件中的样式。否则为DataSet的默认样式
            //if(System.IO.File.Exists(this.filePath))
            //	Neusoft.FrameWork.WinForms.CustomerFp.ReadColumnProperty( this.fpPharmacyQuery_Sheet1,this.filePath);
            this.SetColor();
        }

        #endregion

        #region 事件

        private void fpMaterialQuery_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.isEditExpediency)	//拥有修改权限
            {
                this.Modify();
            }
        }


        private void ucMaterialQuery_Load(object sender, System.EventArgs e)
        {

        }


        private void ucMaterialManager_MyInput(Neusoft.HISFC.Models.Material.MaterialItem item)
        {
            this.AddNewRow(item);

        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Control.GetHashCode() + Keys.C.GetHashCode())
            {
                this.Copy();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }


        private void fpMaterialQuery_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        private void fpMaterialQuery_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpMaterialQuery_Sheet1, this.filePath);
        }

        #endregion
    }
}

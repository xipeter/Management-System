using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FarPoint.Win.Spread;
using Neusoft.FrameWork.Models;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    /// <summary>
    /// ucPopSelected<br></br>
    /// [功能描述: 门诊弹出选择项目UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-2-5]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPopSelected : Form, Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IChooseItemForOutpatient
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucPopSelected()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 是否选择项目的时候判断库存
        /// </summary>
        protected bool isJudgeStore = false;

        /// <summary>
        /// 所有项目的DataSet
        /// </summary>
        protected DataSet dsAllItem = new DataSet();

        /// <summary>
        /// 传入的字符串
        /// </summary>
        protected string inputChar = string.Empty;

        /// <summary>
        /// 查询方式,默认拼音
        /// </summary>
        protected Neusoft.HISFC.Models.Base.InputTypes inputType = Neusoft.HISFC.Models.Base.InputTypes.Spell;

        /// <summary>
        /// 选择项目的方式,这里默认为输入回车后检索
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.FeeInterface.ChooseItemTypes chooseItemType = Neusoft.HISFC.BizProcess.Integrate.FeeInterface.ChooseItemTypes.ItemInputEnd;

        /// <summary>
        /// 原始项目列表(过滤之前的)
        /// </summary>
        private DataView preDvItem;
        /// <summary>
        /// 原始查询字符串
        /// </summary>
        string rowFilter = "";
        /// <summary>
        /// 查询码
        /// </summary>
        private string queryText;
        /// <summary>
        /// 是否模糊查询
        /// </summary>
        private bool queryLike = false;
        /// <summary>
        /// 项目类别
        /// </summary>
        private Neusoft.HISFC.Models.Base.ItemTypes itemType = Neusoft.HISFC.Models.Base.ItemTypes.All;
        /// <summary>
        /// 项目集DataTable
        /// </summary>
        private DataTable dtItem = null;
        /// <summary>
        /// 对应项目集DataTable 的视图
        /// </summary>
        private DataView dvItem = null;
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private string filePath = Application.StartupPath + @".\profile\clinicItemList.xml";
        /// <summary>
        /// 默认每页显示9条记录，以后会加入参数设置
        /// </summary>
        private int itemCount = 9;
        /// <summary>
        /// 当前页最后一行;
        /// </summary>
        private int nowCount = 0;
        /// <summary>
        /// 当选择一条项目的时候是否关闭窗口
        /// </summary>
        private bool selectAndClose = false;
        /// <summary>
        /// 当前选定的项目实体
        /// </summary>
        private Neusoft.HISFC.Models.Base.Item nowItem = null;
    
        /// <summary>
        /// 当选择项目后触发
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.WhenGetItem SelectedItem;
        /// <summary>
        /// 当前科室代码
        /// </summary>
        private string deptCode = "";
        /// <summary>
        /// 保存过滤后的的项目fpSheet
        /// </summary>
        private FarPoint.Win.Spread.SheetView fpSheetData = new FarPoint.Win.Spread.SheetView();

        /// <summary>
        /// 住院费用业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.InPatient myInpatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        /// <summary>
        /// 医保接口业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Interface myInterface = new Neusoft.HISFC.BizLogic.Fee.Interface();

        /// <summary>
        /// 药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        /// <summary>
        /// 管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private bool isSelectItem = false;

        private string inputCode = "";
        private string queryType = "1";//默认后模糊
        /// <summary>
        /// 加载类别
        /// </summary>
        private Neusoft.HISFC.Models.Base.ItemKind itemKind = Neusoft.HISFC.Models.Base.ItemKind.All;

        #endregion

        #region 属性

        /// <summary>
        /// 加载列表类型
        /// </summary>
        public Neusoft.HISFC.Models.Base.ItemKind ItemKind
        {
            get
            {
                return this.itemKind;
            }
            set
            {
                this.itemKind = value;
            }
        }

        /// <summary>
        /// 查询项目的类别
        /// </summary>
        public Neusoft.HISFC.Models.Base.ItemTypes ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                itemType = value;
            }
        }

        /// <summary>
        /// 模糊查询方式
        /// </summary>
        public Neusoft.HISFC.Models.Base.InputTypes InputType
        {
            get
            {
                return inputType;
            }
            set
            {
                inputType = value;
            }
        }

        /// <summary>
        /// 输入优先级
        /// </summary>
        public string InputPrev
        {
            get
            {
                if (this.cmbPrev.Tag != null)
                {
                    return this.cmbPrev.Tag.ToString();
                }
                else
                {
                    return "SYS_CLASS ASC";
                }
            }
            set 
            {
                
            }
        }

        /// <summary>
        /// 是否有效选择项目
        /// </summary>
        public bool IsSelectItem
        {
            get
            {
                return isSelectItem;
            }
            set
            {
                this.isSelectItem = value;
            }
        }

        /// <summary>
        /// 当前科室代码
        /// </summary>
        public string DeptCode
        {
            set
            {
                this.deptCode = value;
            }
            get 
            {
                return this.deptCode;
            }
        }

        /// <summary>
        /// 保存过滤后的的项目fpSheet
        /// </summary>
        public FarPoint.Win.Spread.SheetView FpSheetData
        {
            set
            {
                fpSheetData = value;
                if (this.preDvItem == null)
                {
                    this.preDvItem = ((DataView)this.fpSheetData.DataSource);
                }
                int iReturn = 0;
                nowCount = 0;
                btnNextPage.Enabled = false;
                btnPre.Enabled = false;
                //查询并填充项目
                iReturn = Query();
                if (iReturn == -1)
                {
                    return;
                }
                if (iReturn > itemCount)// 如果查询的项目多余9行，则下一页按钮为可以用，否则不可用
                {
                    btnNextPage.Enabled = true;
                }
                else
                {
                    btnNextPage.Enabled = false;
                }
                this.fpSpread1.Focus();

            }
        }

        /// <summary>
        /// 查询码
        /// </summary>
        public string QueryText
        {
            get
            {
                return queryText;
            }
            set
            {
                queryText = value;
                tbInput.Text = queryText;
                tbInput.Focus();
                tbInput.SelectAll();
            }
        }

        /// <summary>
        /// 每次取几条条记录 > 1
        /// </summary>
        public int ItemCount
        {
            get
            {
                return itemCount;
            }
            set
            {
                itemCount = value;
            }
        }

        /// <summary>
        /// 当选择一条项目的时候是否关闭窗口;
        /// </summary>
        public bool SelectAndClose
        {
            get
            {
                return selectAndClose;
            }
            set
            {
                selectAndClose = value;
            }
        }

        /// <summary>
        /// 当前选定的项目
        /// </summary>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Base.Item NowItem
        {
            get
            {
                return nowItem;
            }
            set
            {
                nowItem = value;
            }
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        public bool QueryLike
        {
            get
            {
                return this.queryLike;
            }
            set
            {
                this.queryLike = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化显示列信息
        /// </summary>
        private void InitColumn()
        {
            if (File.Exists(filePath))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(filePath, dtItem, ref dvItem, this.fpSpread1_Sheet1);
            }
            else
            {
                Type str = typeof(string);
                Type dec = typeof(decimal);
                Type bl = typeof(bool);

                dtItem.Columns.AddRange(new DataColumn[]{new DataColumn("费用分类", str),
															new DataColumn("代码", str),
															new DataColumn("中文名", str),
															new DataColumn("英文名", str),
															new DataColumn("规格", str),
															new DataColumn("库存", str),
															new DataColumn("剂型", str),
															new DataColumn("自定义码", str),
															new DataColumn("单价", dec),
															new DataColumn("单位", str),
															new DataColumn("公费类别", str),
															new DataColumn("医保类别", str),
															new DataColumn("自付比例", dec),
															new DataColumn("项目类别", bl),
															new DataColumn("执行科室", str)});
                dvItem = new DataView(dtItem);
                this.fpSpread1_Sheet1.DataSource = dvItem;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1, filePath);
            }
        }

        /// <summary>
        /// 初始化Farpoint
        /// </summary>
        private void InitFp()
        {
            InputMap im;

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.PageDown, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.PageUp, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        /// <summary>
        /// 获得指定行的项目信息
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetItem(int row)
        {
            if (row > this.fpSpread1_Sheet1.Rows.Count - 1)
            {
                return "";
            }
            else
            {
                if (this.fpSpread1_Sheet1.Rows[row].Tag == null || this.fpSpread1_Sheet1.Rows[row].Tag.ToString() == "")
                {
                    return "";
                }
                else
                {
                    return ((NeuObject)this.fpSpread1_Sheet1.Rows[row].Tag).Name;
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public int Query()
        {
            dtItem.Rows.Clear();
            string feeCode = "";//最小费用代码
            string itemCode = "";//项目编码
            string drugFlag = "";//项目类别 0 非药品 1 药品 2 组合项目
            string itemName = "";//项目名称

            Neusoft.HISFC.Models.Pharmacy.Storage stoItem = null;
            if (fpSheetData.Rows.Count == 1)
            {
                if (isJudgeStore)
                {
                    drugFlag = this.fpSheetData.Cells[0, 0].Text;
                    string exeDeptCode = this.fpSheetData.Cells[0, 22].Text;
                    if (drugFlag == "1")//获得药品库存
                    {
                        itemName = this.fpSheetData.Cells[0, 4].Text.ToString();
                        itemCode = this.fpSheetData.Cells[0, 3].Text;
                        decimal storeSum = 0;

                        stoItem = this.pharmacyIntegrate.GetStockInfoByDrugCode(this.fpSheetData.Cells[0, 22].Text, itemCode);
                        if (stoItem != null)
                        {
                            if (stoItem.IsStop)
                            {
                                MessageBox.Show(itemName + "[药品缺药]!");
                                isSelectItem = false;

                                return -1;
                            }
                        }

                        int iReturn = this.pharmacyIntegrate.GetStorageNum(exeDeptCode, itemCode, out storeSum);

                        if (iReturn <= 0)
                        {
                            MessageBox.Show("查找库存失败!");
                            isSelectItem = false;

                            return -1;
                        }
                        if (storeSum <= 0)
                        {
                            MessageBox.Show(itemName + "库存不足!");
                            isSelectItem = false;

                            return -1;
                        }
                    }
                }
                isSelectItem = true;
                //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                SelectedItem(fpSheetData.Cells[0, 3].Text, this.fpSheetData.Cells[0, 0].Text, fpSheetData.Cells[0, 22].Text, NConvert.ToDecimal(this.fpSheetData.Cells[0, 16].Text));

                return 0;
            }
            int i = 0;//当前取得的行数

            decimal price = 0;
            decimal packQty = 0;

            for (int j = nowCount; j < fpSheetData.Rows.Count; j++)
            {
                i++;
                if (i > itemCount)
                {
                    break;
                }
                itemCode = this.fpSheetData.Cells[j, 3].Text;
                feeCode = this.fpSheetData.Cells[j, 2].Text;
                drugFlag = this.fpSheetData.Cells[j, 0].Text;

                DataRow row = dtItem.NewRow();

                if (drugFlag == "1")//药品刷新库存
                {
                    stoItem = this.pharmacyIntegrate.GetStockInfoByDrugCode(this.fpSheetData.Cells[j, 22].Text, itemCode);
                    if (stoItem != null)
                    {
                        if (stoItem.IsStop)
                        {
                            row["库存"] = "1";
                        }
                         else
                        {
                            row["库存"] = Neusoft.FrameWork.Public.String.FormatNumber( stoItem.StoreQty/stoItem.Item.PackQty,2);
                        }
                    }
                    else
                    {
                        row["库存"] = this.fpSheetData.Cells[j, 21].Text;
                    }
                    //liu.xq20071009显示库存
                }
                if (feeCode != "")
                {
                    feeCode = myInpatient.GetComDictionaryNameByID("MINFEE", feeCode);
                }

                row["费用分类"] = feeCode;
                row["代码"] = itemCode;
                row["中文名"] = this.fpSheetData.Cells[j, 4].Text.ToString();
                row["英文名"] = this.fpSheetData.Cells[j, 5].Text.ToString();
                row["规格"] = this.fpSheetData.Cells[j, 7].Text;
                row["剂型"] = this.fpSheetData.Cells[j, 8].Text;
                row["自定义码"] = this.fpSheetData.Cells[j, 11].Text;

                Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();

                dept = this.managerIntegrate.GetDepartment(this.fpSheetData.Cells[j, 22].Text);
                string deptName = "";
                if (dept != null)
                {
                    deptName = dept.Name;
                }
                else
                {
                    deptName = this.fpSheetData.Cells[j, 22].Text;
                }
                row["执行科室"] = deptName;

                price = NConvert.ToDecimal(this.fpSheetData.Cells[j, 16].Text);
                packQty = NConvert.ToDecimal(this.fpSheetData.Cells[j, 6].Text);
                if (packQty == 0)
                {
                    packQty = 1;
                }

                row["单价"] = price;
                row["单位"] = this.fpSheetData.Cells[j, 19].Text;

                dtItem.Rows.Add(row);
                //默认字体为黑色
                this.fpSpread1_Sheet1.Cells[i - 1, 2].ForeColor = Color.Black;
                //如果是药品并且库存不足，字体为红色
                if (drugFlag == "1")
                {
                    try
                    {
                        if (row["库存"].ToString() == "1")
                        {
                            this.fpSpread1_Sheet1.Rows[i - 1].ForeColor = Color.Red;
                            row["中文名"] = row["中文名"].ToString() + "{缺药}";
                        }
                        else
                        {
                            this.fpSpread1_Sheet1.Rows[i - 1].ForeColor = Color.Black;
                            row["中文名"] = row["中文名"].ToString();
                        }
                    }
                    catch { }
                }
                NeuObject obj = new NeuObject();
                obj.ID = row["代码"].ToString();
                obj.Name = this.fpSheetData.Cells[j, 22].Text;
                obj.Memo = drugFlag;
                obj.User01 = this.fpSheetData.Cells[j, 34].Text;

                if (row["库存"].ToString() == "1")
                {
                    obj.User01 = "1";
                }
                else
                {
                    obj.User01 = "0";
                }

                this.fpSpread1_Sheet1.Rows[i - 1].Tag = obj;
                this.fpSpread1_Sheet1.Rows[i - 1].Label = "F" + i.ToString();
            }

            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1, filePath);

            if (this.fpSpread1_Sheet1.RowCount > 0)
            {
                this.fpSpread1_Sheet1.ActiveRowIndex = 0;
                this.fpSpread1_Sheet1.SetActiveCell(0, 0, false);
            }

            return fpSheetData.Rows.Count - nowCount;
        }

        /// <summary>
        /// 最小费用过滤
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public int QueryByFeeCode()
        {
            dtItem.Rows.Clear();
            string feeCode = "";//最小费用代码
            string itemCode = "";//项目编码
            string drugFlag = "";//项目类别 0 非药品 1 药品 2 组合项目

            Neusoft.HISFC.Models.Pharmacy.Storage stoItem = null;

            int i = 0;//当前取得的行数

            decimal price = 0;
            decimal packQty = 0;

            for (int j = nowCount; j < fpSheetData.Rows.Count; j++)
            {
                i++;
                if (i > itemCount)
                {
                    break;
                }
                itemCode = this.fpSheetData.Cells[j, 3].Text;
                feeCode = this.fpSheetData.Cells[j, 2].Text;
                drugFlag = this.fpSheetData.Cells[j, 0].Text;

                DataRow row = dtItem.NewRow();

                if (drugFlag == "1")//药品刷新库存
                {
                    stoItem = this.pharmacyIntegrate.GetStockInfoByDrugCode(this.fpSheetData.Cells[j, 22].Text, itemCode);

                    if (stoItem != null)
                    {
                        if (stoItem.IsStop)
                        {
                            row["库存"] = "1";
                        }
                        else
                        {
                            row["库存"] = "0";
                        }
                    }
                }
                if (feeCode != "")
                {
                    feeCode = this.myInpatient.GetComDictionaryNameByID("MINFEE", feeCode);
                }

                row["费用分类"] = feeCode;
                row["代码"] = itemCode;
                row["中文名"] = this.fpSheetData.Cells[j, 4].Text.ToString();
                row["英文名"] = this.fpSheetData.Cells[j, 5].Text.ToString();
                row["规格"] = this.fpSheetData.Cells[j, 7].Text;
                row["剂型"] = this.fpSheetData.Cells[j, 8].Text;
                row["自定义码"] = this.fpSheetData.Cells[j, 11].Text;

                Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
                dept = this.managerIntegrate.GetDepartment(this.fpSheetData.Cells[j, 22].Text);
                string deptName = "";
                if (dept != null)
                {
                    deptName = dept.Name;
                }
                else
                {
                    deptName = this.fpSheetData.Cells[j, 22].Text;
                }
                row["执行科室"] = deptName;

                price = NConvert.ToDecimal(this.fpSheetData.Cells[j, 16].Text);
                packQty = NConvert.ToDecimal(this.fpSheetData.Cells[j, 6].Text);
                if (packQty == 0)
                {
                    packQty = 1;
                }

                row["单价"] = price;
                row["单位"] = this.fpSheetData.Cells[j, 19].Text;

                dtItem.Rows.Add(row);
                //默认字体为黑色
                this.fpSpread1_Sheet1.Cells[i - 1, 2].ForeColor = Color.Black;
                //如果是药品并且库存不足，字体为红色
                if (drugFlag == "1")
                {
                    try
                    {
                        if (row["库存"].ToString() == "1")
                        {
                            this.fpSpread1_Sheet1.Rows[i - 1].ForeColor = Color.Red;
                            row["中文名"] = row["中文名"].ToString() + "{缺药}";
                        }
                        else
                        {
                            this.fpSpread1_Sheet1.Rows[i - 1].ForeColor = Color.Black;
                            row["中文名"] = row["中文名"].ToString();
                        }
                    }
                    catch { }
                }
                NeuObject obj = new NeuObject();
                obj.ID = row["代码"].ToString();
                obj.Name = this.fpSheetData.Cells[j, 22].Text;
                obj.Memo = drugFlag;

                if (row["库存"].ToString() == "1")
                {
                    obj.User01 = "1";
                }
                else
                {
                    obj.User01 = "0";
                }

                this.fpSpread1_Sheet1.Rows[i - 1].Tag = obj;
                this.fpSpread1_Sheet1.Rows[i - 1].Label = "F" + i.ToString();
            }

            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1, filePath);

            if (this.fpSpread1_Sheet1.RowCount > 0)
            {
                this.fpSpread1_Sheet1.ActiveRowIndex = 0;
                this.fpSpread1_Sheet1.SetActiveCell(0, 0, false);
            }

            return fpSheetData.Rows.Count - nowCount + 1;
        }

        /// <summary>
        /// 下一页
        /// </summary>
        public void NextPage()
        {
            btnNextPage.Enabled = false;
            int iReturn = 0;
            nowCount += itemCount;
            //查询代码
            iReturn = Query();
            //查询代码结束

            if (iReturn > itemCount) //说明还下页还有项目
            {
                btnNextPage.Enabled = true;
            }
            else //说明下页还有项目
            {
                btnNextPage.Enabled = false;
            }

            btnPre.Enabled = true;
        }

        /// <summary>
        /// 上一页
        /// </summary>
        private void PrePage()
        {
            btnPre.Enabled = false;
            nowCount -= itemCount;
            if (nowCount < 0)
            {
                return;
            }
            if (nowCount == 0)
            {
                btnPre.Enabled = false;
            }
            else
            {
                btnPre.Enabled = true;
            }

            Query();
            btnNextPage.Enabled = true;
        }

        /// <summary>
        /// 利用Fn功能键选择项目
        /// </summary>
        /// <param name="i"></param>
        private void SelectItemKeys(int i)
        {
            string itemCode = GetItem(i);
            if (itemCode == "")
            {
                return;
            }
            NeuObject obj = ((NeuObject)this.fpSpread1_Sheet1.Rows[i].Tag);
            if (isJudgeStore)
            {

                if (obj.Memo == "1")//获得药品库存
                {
                    decimal storeSum = 0;
                    int iReturn = this.pharmacyIntegrate.GetStorageNum(obj.Name, obj.ID, out storeSum);
                    if (iReturn <= 0)
                    {
                        MessageBox.Show("查找库存失败!");
                        isSelectItem = false;
                        return;
                    }
                    if (storeSum <= 0)
                    {
                        MessageBox.Show("库存不足!");
                        isSelectItem = false;
                        return;
                    }
                    if (obj.User01 == "1")
                    {
                        MessageBox.Show("该项目已经缺药,不能选择!");
                        isSelectItem = false;
                        return;
                    }
                }

            }
            isSelectItem = true;
            //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
            SelectedItem(obj.ID, obj.Memo, obj.Name, NConvert.ToDecimal(obj.User02));
            this.FindForm().Close();
        }

        /// <summary>
        /// 获得执行科室
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetExeDeptCode(int row)
        {
            if (row > this.fpSpread1_Sheet1.Rows.Count - 1)
            {
                return "";
            }
            else
            {
                if (this.fpSpread1_Sheet1.Rows[row].Tag == null || this.fpSpread1_Sheet1.Rows[row].Tag.ToString() == "")
                {
                    return "";
                }
                else
                {

                    return ((NeuObject)this.fpSpread1_Sheet1.Rows[row].Tag).Name;
                }
            }
        }

        /// <summary>
        /// 初始化优先级
        /// </summary>
        public void InitPrev()
        {
            ArrayList alPrev = new ArrayList();

            NeuObject o2 = new NeuObject();

            o2.ID = "";

            o2.Name = "默认";

            alPrev.Add(o2);

            NeuObject o = new NeuObject();

            o.ID = "SYS_CLASS ASC";

            o.Name = "西药优先";

            alPrev.Add(o);

            NeuObject o1 = new NeuObject();

            o1.ID = "SYS_CLASS DESC";

            o1.Name = "中药优先";

            alPrev.Add(o1);

            this.cmbPrev.AddItems(alPrev);

            ArrayList alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("INPUTPREV");

            if (alValues == null || alValues.Count <= 0)
            {
                this.cmbPrev.SelectedIndexChanged -= new EventHandler(cmbPrev_SelectedIndexChanged);
                this.cmbPrev.SelectedIndex = 0;
                this.cmbPrev.SelectedIndexChanged += new EventHandler(cmbPrev_SelectedIndexChanged);
            }
            else
            {
                this.cmbPrev.Tag = alValues[0].ToString();
                this.cmbPrev.Text = alValues[1].ToString();
            }
        }

        /// <summary>
        /// 获得过滤条件
        /// </summary>
        private void SetRowFilter()
        {
            string tagValue = this.cmbQueryType.Tag.ToString();

            switch (tagValue)
            {
                case "0":
                    rowFilter = "SPELL_CODE like '%" + inputCode + "'" +
                        " OR " + "WB_CODE like '%" + inputCode + "'" +
                        " OR " + "USER_CODE like '%" + inputCode.PadLeft(6, '0') + "'" +
                        " OR " + "ITEM_NAME like '%" + inputCode + "'" +
                        " OR " + "CUS_SPELL_CODE like '%" + inputCode + "'" +
                        " OR " + "CUS_WB_CODE like '%" + inputCode + "'" +
                        " OR " + "CUS_USER_CODE like '%" + inputCode + "'" +
                        " OR " + "CUS_NAME like '%" + inputCode + "'" +
                        " OR " + "OTHER_NAME like '%" + inputCode + "'" +
                        " OR " + "OTHER_SPELL like '%" + inputCode + "'" +
                        " OR " + "EN_NAME like '%" + inputCode + "'";
                    break;
                case "1":
                    rowFilter = "SPELL_CODE like '" + inputCode + "%'" +
                        " OR " + "WB_CODE like '" + inputCode + "%'" +
                        " OR " + "USER_CODE like '" + inputCode.PadLeft(6, '0') + "%'" +
                        " OR " + "ITEM_NAME like '" + inputCode + "%'" +
                        " OR " + "CUS_SPELL_CODE like '" + inputCode + "%'" +
                        " OR " + "CUS_WB_CODE like '" + inputCode + "%'" +
                        " OR " + "CUS_USER_CODE like '" + inputCode + "%'" +
                        " OR " + "CUS_NAME like '" + inputCode + "%'" +
                        " OR " + "OTHER_NAME like '%" + inputCode + "'" +
                        " OR " + "OTHER_SPELL like '%" + inputCode + "'" +
                        " OR " + "EN_NAME like '" + inputCode + "%'";
                    break;
                case "2":
                    rowFilter = "SPELL_CODE like '%" + inputCode + "%'" +
                        " OR " + "WB_CODE like '%" + inputCode + "%'" +
                        " OR " + "USER_CODE like '%" + inputCode.PadLeft(6, '0') + "%'" +
                        " OR " + "ITEM_NAME like '%" + inputCode + "%'" +
                        " OR " + "CUS_SPELL_CODE like '%" + inputCode + "%'" +
                        " OR " + "CUS_WB_CODE like '%" + inputCode + "%'" +
                        " OR " + "CUS_USER_CODE like '%" + inputCode + "%'" +
                        " OR " + "CUS_NAME like '%" + inputCode + "%'" +
                        " OR " + "OTHER_NAME like '%" + inputCode + "'" +
                        " OR " + "OTHER_SPELL like '%" + inputCode + "'" +
                        " OR " + "EN_NAME like '%" + inputCode + "%'";
                    break;
                case "3":
                    rowFilter = "SPELL_CODE like '" + inputCode + "'" +
                        " OR " + "WB_CODE like '" + inputCode + "'" +
                        " OR " + "USER_CODE like '" + inputCode.PadLeft(6, '0') + "'" +
                        " OR " + "ITEM_NAME like '" + inputCode + "'" +
                        " OR " + "CUS_SPELL_CODE like '" + inputCode + "'" +
                        " OR " + "CUS_WB_CODE like '" + inputCode + "'" +
                        " OR " + "CUS_USER_CODE like '" + inputCode + "'" +
                        " OR " + "CUS_NAME like '" + inputCode + "'" +
                        " OR " + "OTHER_NAME like '%" + inputCode + "'" +
                        " OR " + "OTHER_SPELL like '%" + inputCode + "'" +
                        " OR " + "EN_NAME like '" + inputCode + "'";
                    break;
                default:
                    rowFilter = "SPELL_CODE like '" + inputCode + "%'" +
                        " OR " + "WB_CODE like '" + inputCode + "%'" +
                        " OR " + "USER_CODE like '" + inputCode.PadLeft(6, '0') + "%'" +
                        " OR " + "ITEM_NAME like '" + inputCode + "%'" +
                        " OR " + "CUS_SPELL_CODE like '" + inputCode + "%'" +
                        " OR " + "CUS_WB_CODE like '" + inputCode + "%'" +
                        " OR " + "CUS_USER_CODE like '" + inputCode + "%'" +
                        " OR " + "CUS_NAME like '" + inputCode + "%'" +
                        " OR " + "OTHER_NAME like '%" + inputCode + "'" +
                        " OR " + "OTHER_SPELL like '%" + inputCode + "'" +
                        " OR " + "EN_NAME like '" + inputCode + "%'";
                    break;
            }
        }

        /// <summary>
        /// 显示医保信息
        /// </summary>
        private void DisplayCompareInfo()
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex < 0)
            {
                return;
            }

            if (this.fpSpread1_Sheet1.Rows.Count <= 0)
            {
                return;
            }

            NeuObject obj = this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.ActiveRowIndex].Tag as NeuObject;

            if (obj == null)
            {
                return;
            }

            DataRow findRow;
            DataRow[] rowFinds = this.preDvItem.Table.Select("ITEM_CODE = " + "'" + obj.ID + "'");
            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItem = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();
            feeItem.ID = obj.ID;
            //医保信息
            try
            {
                myInterface.GetCompareSingleItem("2", feeItem.ID, ref feeItem.Compare);
            }
            catch { }

            if (rowFinds != null && rowFinds.Length > 0)
            {
                findRow = rowFinds[0];
                string siInfo = "";

                if (feeItem.Compare != null)
                {
                    if (feeItem.Compare.CenterItem.ItemGrade == "1")
                    {
                        siInfo += "医保类别:甲类" + System.Convert.ToString(feeItem.Compare.CenterItem.Rate * 100) + "%";
                    }
                    else if (feeItem.Compare.CenterItem.ItemGrade == "2")
                    {
                        siInfo += "医保类别:乙类" + System.Convert.ToString(feeItem.Compare.CenterItem.Rate * 100) + "%";
                    }
                    else
                    {
                        siInfo += "医保类别:自费" + System.Convert.ToString(feeItem.Compare.CenterItem.Rate * 100) + "%";
                    }
                }
                this.label5.Text = siInfo + "\n" + "通用名:" + findRow["cus_name"].ToString() + " 英文名:" + findRow["en_name"].ToString().ToLower() +
                    "别名:" + findRow["OTHER_NAME"].ToString() + "\n" +
                    "规格:" + findRow["SPECS"].ToString() + " 剂型:" + findRow["DOSE_CODE"].ToString();
            }
        }


        #endregion

        #region IChooseItemForOutpatient 成员

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public int Init()
        {
            dtItem = new DataTable();
            //初始化列信息
            InitColumn();
            tbInput.Focus();
            tbInput.SelectAll();
            this.InitFp();

            ArrayList alMinFee = new ArrayList();
            Neusoft.HISFC.Models.Base.Const cnst = new Neusoft.HISFC.Models.Base.Const();
            cnst.ID = "";
            cnst.Name = "全部";
            alMinFee.Add(cnst);
            ArrayList al = this.managerIntegrate.GetConstantList("MINFEE");
            if (al == null)
            {
                MessageBox.Show("获得最小费用类别出错！");
            }
            else
            {
                alMinFee.AddRange(al);
                this.cmbMinFee.AddItems(alMinFee);
            }

            this.chooseItemType = Neusoft.HISFC.BizProcess.Integrate.FeeInterface.ChooseItemTypes.ItemInputEnd;

            return 1;
        }

        /// <summary>
        /// 获得选中的项目
        /// </summary>
        /// <param name="item">选中的项目</param>
        /// <returns>成功 1 失败 -1</returns>
        public int GetSelectedItem(ref Neusoft.HISFC.Models.Base.Item item)
        {
            item = this.nowItem.Clone();

            return 1;
        }

        /// <summary>
        /// 是否选择项目的时候判断库存
        /// </summary>
        public bool IsJudgeStore
        {
            get
            {
                return this.isJudgeStore;
            }
            set
            {
                this.isJudgeStore = value;
            }
        }

        /// <summary>
        /// 设置所有项目的DataSet
        /// </summary>
        /// <param name="dsItem">所有项目的DataSet</param>
        public void SetDataSet(DataSet dsItem)
        {
            this.dsAllItem = dsItem;
        }

        /// <summary>
        /// 设置传入的过滤字符串,和查询方式
        /// </summary>
        /// <param name="inputChar">传入的过滤字符串</param>
        /// <param name="inputType">查询方式</param>
        public void SetInputChar(object sender, string inputChar, Neusoft.HISFC.Models.Base.InputTypes inputType)
        {
            this.inputChar = inputChar;
            this.inputType = inputType;
        }

        /// <summary>
        /// 选择项目的方式,这里默认为输入回车后检索
        /// </summary>
        public Neusoft.HISFC.BizProcess.Integrate.FeeInterface.ChooseItemTypes ChooseItemType
        {
            get
            {
                return this.chooseItemType;
            }
            set
            {
                this.chooseItemType = value;
            }
        }

        /// <summary>
        /// 是否模糊查询
        /// </summary>
        public bool IsQueryLike
        {
            get
            {
                return this.queryLike;
            }
            set
            {
                this.queryLike = value;
            }
        }

        /// <summary>
        /// 是否选择项目后关闭窗口
        /// </summary>
        public bool IsSelectAndClose
        {
            get
            {
                return this.selectAndClose;
            }
            set
            {
                this.selectAndClose = value;
            }
        }

        /// <summary>
        /// 查询方式
        /// </summary>
        public string QueryType 
        {
            get 
            {
                return this.queryType;
            }
            set 
            {
                this.queryType = value;
            }
        }

        /// <summary>
        /// 过滤后对象,这里是FarPoint
        /// </summary>
        public object ObjectFilterObject
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                fpSheetData = value as FarPoint.Win.Spread.SheetView;
                if (this.preDvItem == null)
                {
                    this.preDvItem = ((DataView)this.fpSheetData.DataSource);
                }
                int iReturn = 0;
                nowCount = 0;
                btnNextPage.Enabled = false;
                btnPre.Enabled = false;
                //查询并填充项目
                iReturn = Query();
                if (iReturn == -1)
                {
                    return;
                }
                if (iReturn > itemCount)// 如果查询的项目多余9行，则下一页按钮为可以用，否则不可用
                {
                    btnNextPage.Enabled = true;
                }
                else
                {
                    btnNextPage.Enabled = false;
                }
                this.fpSpread1.Focus();
            }
        }

        /// <summary>
        /// 设置坐标
        /// </summary>
        /// <param name="p">当前坐标</param>
        public void SetLocation(Point p)
        {
            this.Location = p;
        }

        /// <summary>
        /// 下一行
        /// </summary>
        public void NextRow()
        {

        }


        /// <summary>
        /// 上一行
        /// </summary>
        public void PriorRow()
        {

        }

        /// <summary>
        /// 上一页
        /// </summary>
        public void PriorPage()
        {

        }

        /// <summary>
        /// 选择当前项目
        /// </summary>
        /// <returns>成功 1 失败-1</returns>
        public int GetSelectedItem()
        {
            return 1;
        }


        #endregion

        private void cmbPrev_SelectedIndexChanged(object sender, EventArgs e)
        {
            NeuObject o = this.cmbPrev.SelectedItem;

            if (o != null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("INPUTPREV", o.ID, o.Name);
            }
            else
            {
                return;
            }

            this.fpSpread1.Focus();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (btnNextPage.Enabled == false)
            {
                return;
            }

            NextPage();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            //if (btnNextPage.Enabled == false)
            //{
            //    return;
            //}
            this.PrePage();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            int iReturn = 0;
            nowCount = 0;
            btnNextPage.Enabled = false;
            btnPre.Enabled = false;
            iReturn = Query();
            if (iReturn == -1)
            {
                return;
            }
            if (iReturn > itemCount)
            {
                btnNextPage.Enabled = true;
            }
            else
            {
                btnNextPage.Enabled = false;
            }
        }

        private void fpSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1, filePath);
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.fpSpread1.SetViewportTopRow(0, this.fpSpread1_Sheet1.ActiveRowIndex - 5);
                this.fpSpread1_Sheet1.ActiveRowIndex--;
                ////{0CD66D53-785C-4ba5-840B-885F01A31A42}
                //this.fpSpread1_Sheet1.AddSelection(this.fpSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
                this.fpSpread1_Sheet1.AddSelection(this.fpSpread1_Sheet1.ActiveRowIndex, 1, 1, 1);
            }
            if (e.KeyCode == Keys.Down)
            {
                this.fpSpread1.SetViewportTopRow(0, this.fpSpread1_Sheet1.ActiveRowIndex - 4);
                this.fpSpread1_Sheet1.ActiveRowIndex++;
                ////{0CD66D53-785C-4ba5-840B-885F01A31A42}
                //this.fpSpread1_Sheet1.AddSelection(this.fpSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
                this.fpSpread1_Sheet1.AddSelection(this.fpSpread1_Sheet1.ActiveRowIndex, 1, 1, 1);
            }
            if (e.KeyCode == Keys.Enter)
            {
                Neusoft.HISFC.Models.Base.Item obj = null;

                if (obj != null)
                {
                    //MessageBox.Show(obj.Name + obj.IsPharmacy.ToString());
                    MessageBox.Show(obj.Name + obj.ItemType.ToString());
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                this.isSelectItem = false;
                this.FindForm().Close();
            }
            if (keyData == Keys.F1)
            {
                SelectItemKeys(0);
            }
            if (keyData == Keys.F2)
            {
                SelectItemKeys(1);
            }
            if (keyData == Keys.F3)
            {
                SelectItemKeys(2);
            }
            if (keyData == Keys.F4)
            {
                SelectItemKeys(3);
            }
            if (keyData == Keys.F5)
            {
                SelectItemKeys(4);
            }
            if (keyData == Keys.F6)
            {
                SelectItemKeys(5);
            }
            if (keyData == Keys.F7)
            {
                SelectItemKeys(6);
            }
            if (keyData == Keys.F8)
            {
                SelectItemKeys(7);
            }
            if (keyData == Keys.F9)
            {
                SelectItemKeys(8);
            }
            if (keyData == Keys.F10)
            {
                this.cmbMinFee.SelectedIndex = (this.cmbMinFee.SelectedIndex + 1) % this.cmbMinFee.Items.Count;
                return true;
            }
            if (keyData == Keys.F11)
            {

            }
            if (keyData == Keys.F12)
            {
                this.cmbQueryType.SelectedIndex = (this.cmbQueryType.SelectedIndex + 1) % this.cmbQueryType.Items.Count;
            }
            if (keyData == Keys.PageDown)
            {
                if (btnNextPage.Enabled == false)
                {
                    return false;
                }
                NextPage();
            }
            if (keyData == Keys.PageUp)
            {
                if (btnPre.Enabled == false)
                {
                    return false;
                }
                PrePage();
            }
            if (keyData == Keys.N)
            {
                if (btnNextPage.Enabled == false)
                {
                    return false;
                }
                NextPage();
            }
            if (keyData == Keys.P)
            {
                if (btnPre.Enabled == false)
                {
                    return false;
                }
                PrePage();
            }
            if (keyData == Keys.Back)
            {
                if (this.cmbMinFee.SelectedIndex >= 1)
                {
                    this.cmbMinFee.SelectedIndex = (this.cmbMinFee.SelectedIndex - 1) % this.cmbMinFee.Items.Count;
                }
            }

            return base.ProcessDialogKey(keyData);
        }

        private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (this.fpSpread1_Sheet1.RowCount > 0)
                {
                    int row = this.fpSpread1_Sheet1.ActiveRowIndex;
                    NeuObject obj = ((NeuObject)this.fpSpread1_Sheet1.Rows[row].Tag);
                    if (isJudgeStore)
                    {

                        if (obj.Memo == "1")//获得药品库存
                        {
                            decimal storeSum = 0;
                            int iReturn = this.pharmacyIntegrate.GetStorageNum(obj.Name, obj.ID, out storeSum);
                            if (iReturn <= 0)
                            {
                                MessageBox.Show("查找库存失败!");
                                isSelectItem = false;
                                return;
                            }
                            if (storeSum <= 0)
                            {
                                MessageBox.Show("库存不足!");
                                isSelectItem = false;
                                return;
                            }
                            if (obj.User01 == "1")
                            {
                                MessageBox.Show("该项目已经缺药,不能选择!");
                                isSelectItem = false;
                                return;
                            }
                        }
                    }
                    isSelectItem = true;
                    //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                    SelectedItem(obj.ID, obj.Memo, obj.Name, NConvert.ToDecimal(obj.User02));
                    this.FindForm().Close();
                }
            }
        }

        private void fpSpread1_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            if (this.fpSpread1_Sheet1.RowCount > 0)
            {
                NeuObject obj = ((NeuObject)this.fpSpread1_Sheet1.Rows[e.Row].Tag);
                if (isJudgeStore)
                {

                    if (obj.Memo == "1")//获得药品库存
                    {
                        decimal storeSum = 0;
                        int iReturn = this.pharmacyIntegrate.GetStorageNum(obj.Name, obj.ID, out storeSum);
                        if (iReturn <= 0)
                        {
                            MessageBox.Show("查找库存失败!");
                            return;
                        }
                        if (storeSum <= 0)
                        {
                            MessageBox.Show("库存不足!");
                            return;
                        }
                        if (obj.User01 == "1")
                        {
                            MessageBox.Show("该项目已经缺药,不能选择!");
                            isSelectItem = false;
                            return;
                        }
                    }
                }
                isSelectItem = true;
                //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                SelectedItem(obj.ID, obj.Memo, obj.Name, NConvert.ToDecimal(obj.User02));
                this.FindForm().Close();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Components.Common.Controls.ucSetColumn ucSet = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            ucSet.FilePath = this.filePath;
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucSet);
        }

        private void cmbMinFee_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFilter = "";

            if (this.cmbMinFee.Tag != null)
            {
                strFilter = this.cmbMinFee.Tag.ToString();
            }

            ((DataView)this.fpSheetData.DataSource).RowFilter = "(" + rowFilter + ")" + " and " + "FEE_CODE like '%" + strFilter + "%'";

            int iReturn = 0;
            nowCount = 0;
            btnNextPage.Enabled = false;
            btnPre.Enabled = false;
            //查询并填充项目
            iReturn = QueryByFeeCode();
            if (iReturn == -1)
            {
                return;
            }
            if (iReturn > itemCount)// 如果查询的项目多余9行，则下一页按钮为可以用，否则不可用
            {
                btnNextPage.Enabled = true;
            }
            else
            {
                btnNextPage.Enabled = false;
            }

            this.fpSpread1.Focus();
        }

        private void cmbQueryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();

            this.cmbMinFee_SelectedIndexChanged(null, null);

            this.fpSpread1.Focus();
        }

        private void fpSpread1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex < 0)
            {
                return;
            }

            if (this.fpSpread1_Sheet1.Rows.Count <= 0)
            {
                return;
            }

            NeuObject obj = this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.ActiveRowIndex].Tag as NeuObject;

            if (obj == null)
            {
                return;
            }

            DataRow findRow;
            DataRow[] rowFinds = this.preDvItem.Table.Select("ITEM_CODE = " + "'" + obj.ID + "'");
            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItem = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();
            feeItem.ID = obj.ID;
            //医保信息
            try
            {
                myInterface.GetCompareSingleItem("2", feeItem.ID, ref feeItem.Compare);
            }
            catch { }

            if (rowFinds != null && rowFinds.Length > 0)
            {
                findRow = rowFinds[0];
                string siInfo = "";

                if (feeItem.Compare != null)
                {
                    if (feeItem.Compare.CenterItem.ItemGrade == "1")
                    {
                        siInfo += "医保类别:甲类" + System.Convert.ToString(feeItem.Compare.CenterItem.Rate * 100) + "%";
                    }
                    else if (feeItem.Compare.CenterItem.ItemGrade == "2")
                    {
                        siInfo += "医保类别:乙类" + System.Convert.ToString(feeItem.Compare.CenterItem.Rate * 100) + "%";
                    }
                    else
                    {
                        siInfo += "医保类别:自费" + System.Convert.ToString(feeItem.Compare.CenterItem.Rate * 100) + "%";
                    }
                }
                this.label5.Text = siInfo + "\n" + "通用名:" + findRow["cus_name"].ToString() + " 英文名:" + findRow["en_name"].ToString().ToLower() +
                    "别名:" + findRow["OTHER_NAME"].ToString() + "\n" +
                    "规格:" + findRow["SPECS"].ToString() + " 剂型:" + findRow["DOSE_CODE"].ToString();
            }
        }

        private void ucPopSelected_Load(object sender, EventArgs e)
        {
            this.fpSpread1.Select();
            this.fpSpread1.Focus();
        }

        #region IChooseItemForOutpatient 成员


        public Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade IGetSiItemGrade
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

        public Neusoft.HISFC.Models.Registration.Register RegPatientInfo
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

        #endregion
    }
}

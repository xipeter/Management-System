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
    //addby xuewj 2009-8-26 执行单管理 单项目维护 {0BB98097-E0BE-4e8c-A619-8B4BCA715001}
    public partial class ucInputUndrugItem : Neusoft.HISFC.Components.Common.Controls.ucInputItem
    {
        public ucInputUndrugItem()
        {
            InitializeComponent();
        }

        public event Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler SelectedItem;

        private ArrayList alOrderType;
        public ArrayList AlOrderType
        {
            get
            {
                return this.alOrderType;
            }
            set
            {
                this.alOrderType = value;
            }
        }

        //医嘱类型
        private string myOrderType;
        public string MyOrderType
        {
            get
            {
                return this.myOrderType;
            }
            set
            {
                this.myOrderType = value;
            }
        }

        //医嘱开立项目

        private string mySysClass = "";
        public string MySysClass
        {
            get
            {
                return this.mySysClass;
            }
            set
            {
                if (this.mySysClass == value && this.cmbCategory.SelectedItem != null && this.cmbCategory.SelectedItem.ID == value)
                {
                    return;
                }
                else
                {
                    this.mySysClass = value;
                    for (int i = 0; i < this.cmbCategory.alItems.Count; i++)
                    {
                        Neusoft.FrameWork.Models.NeuObject obj = this.cmbCategory.alItems[i] as Neusoft.FrameWork.Models.NeuObject;
                        if (obj.ID == value)
                        {
                            this.cmbCategory.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private string nurseID;
        public String NurseID
        {
            get
            {
                return this.nurseID;
            }
            set
            {
                this.nurseID = value;
            }
        }

        private DataSet dsUndrugItem;
        public DataSet DsUndrugItem
        {
            get
            {
                return this.dsUndrugItem;
            }
            set
            {
                this.dsUndrugItem = value;
            }
        }

        public new int Init()
        {
            if (this.GetUndrugDS() == -1)
            {
                return -1;
            }

            try
            {
                if (this.fpItemList.Sheets.Count <= 0)
                    this.fpItemList.Sheets.Add(new FarPoint.Win.Spread.SheetView());
                AddCategory();//添加类别
                this.InputType = 0;//默认拼音
                #region {46983F5B-E184-4b8b-B819-AA1C34993F1B}
                this.initFPdetail();
                #endregion
                fpItemList.Sheets[0].DataAutoCellTypes = false;
                fpItemList.Sheets[0].DataAutoSizeColumns = false;
                frmItemList.AddControl(fpItemList);
                frmItemList.Owner = this.FindForm();
                frmItemList.Size = new Size(0, 0);
                frmItemList.Show();
                frmItemList.Hide();
                fpItemList.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
                frmItemList.Closing += new CancelEventHandler(frmItemList_Closing);
                fpItemList.KeyDown += new KeyEventHandler(fpSpread1_KeyDown);
                fpItemList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpItemList_CellDoubleClick);
                this.txtItemCode.TextChanged += new EventHandler(txtItemCode_TextChanged);
                this.txtItemCode.Enter += new EventHandler(txtItemCode_Enter);
                this.txtItemCode.Leave += new EventHandler(txtItemCode_Leave);
                this.InputType = Neusoft.FrameWork.WinForms.Classes.Function.GetInputType();
            }
            catch
            {
                return -1;
            }
            return 0;
        }


        //获取非药品项目

        public int GetUndrugDS()
        {
            if (this.alOrderType == null || this.alOrderType.Count == 0)
            {
                MessageBox.Show("获取医嘱类别错误！");
                return -1;
            }

            this.dsUndrugItem = new DataSet();
            Neusoft.HISFC.BizProcess.Integrate.Fee itemManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            foreach (Neusoft.HISFC.Models.Order.OrderType orderType in this.alOrderType)
            {
                DataSet ds = new DataSet();
                if (itemManager.QueryItemOutExecBill(this.nurseID, orderType.ID, "1", ref ds) == -1)
                {
                    MessageBox.Show("获取非药品项目错误!");
                    return -1;
                }

                if (ds == null || ds.Tables.Count == 0)
                {
                    MessageBox.Show("获取非药品项目错误!");
                    return -1;
                }
                else
                {
                    DataTable dt = ds.Tables[0].Copy();
                    dt.TableName = orderType.ID;
                    this.dsUndrugItem.Tables.Add(dt);
                }
            }
            return 0;
        }

        protected override int AddCategory()
        {
            //由此获取项目类别 西药、手术、描述性医嘱等
            ArrayList arrItemTypes = Neusoft.HISFC.Models.Base.SysClassEnumService.List();

            if (arrItemTypes != null)
            {
                Neusoft.FrameWork.Models.NeuObject o = new Neusoft.FrameWork.Models.NeuObject();
                o.Name = "全部";
                arrItemTypes.Insert(0, o);
                this.cmbCategory.AddItems(arrItemTypes);
            }
            else
            {
                MessageBox.Show("类别加载失败，请重新操作！");
                return -1;
            }
            this.cmbCategory.Text = "全部";
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            return 0;
        }

        protected override void changeItem()
        {
            try
            {
                this.myShowList(); //显示列表

                string sCategory = " and 类别编码 = '" + this.cmbCategory.Tag + "'";
                if (this.cmbCategory.Text == "全部")
                {
                    //因为全部包含的类别可能不同，所以不能这样写,by huangxw
                    //sCategory =string.Empty;
                    sCategory = string.Empty;
                    foreach (Neusoft.FrameWork.Models.NeuObject obj in this.cmbCategory.alItems)
                    {
                        if (obj.Name != "全部")
                            sCategory = sCategory + " or 类别编码 = '" + obj.ID + "'";
                    }
                    if (sCategory != string.Empty)
                    {
                        sCategory = sCategory.Substring(3);//去掉第一个or
                        sCategory = " and (" + sCategory + ")";
                    }
                }
                string sInput = string.Empty;
                //取输入码
                string[] spChar = new string[] { "@", "#", "$", "%", "^", "&", "[", "]", "|" };
                string queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtItemCode.Text.Trim(), spChar);
                queryCode = queryCode.Replace("*", "[*]");

                //根据是否精确查找，决定是否进行模糊查询

                if (this.frmItemList.IsReal == false)
                {
                    queryCode = '%' + Neusoft.FrameWork.Public.String.TakeOffSpecialChar(queryCode) + '%';
                }
                else
                {
                    queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(queryCode) + '%';
                }
                if (queryCode == "%%")
                {
                    queryCode = "%";
                }
                //
                sInput = "(拼音码 LIKE '{0}' or " + "通用名拼音码 LIKE '{0}' or 五笔码 LIKE '{0}' or " + "通用名五笔码 LIKE '{0}' or 自定义码 LIKE '{0}' or " + "通用名自定义码 LIKE '{0}' or " + "英文商品名 LIKE '{0}' or " + "名称 LIKE '{0}')";
                //
                sInput = string.Format(sInput, queryCode);

                sInput = sInput + sCategory;
                //过滤
                dv.RowFilter = sInput;

                if (this.IsListShowAlways)
                {
                    fpItemList.Sheets[0].DataSource = dv;
                }
                fpItemList.Sheets[0].ActiveRowIndex = 0;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        protected override void txtItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (fpItemList.Sheets[0].ActiveRowIndex > 9)
                    fpItemList.SetViewportTopRow(0, fpItemList.Sheets[0].ActiveRowIndex - 9);
                if (e.KeyCode == Keys.Up)
                {
                    fpItemList.Sheets[0].ActiveRowIndex--;
                    fpItemList.Sheets[0].AddSelection(fpItemList.Sheets[0].ActiveRowIndex, 0, 1, 1);
                    fpItemList.Focus();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    fpItemList.Sheets[0].ActiveRowIndex++;
                    fpItemList.Sheets[0].AddSelection(fpItemList.Sheets[0].ActiveRowIndex, 0, 1, 1);
                    fpItemList.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (fpItemList.Sheets[0].Rows.Count > 0 && fpItemList.Sheets[0].ActiveRowIndex >= 0 && this.fpItemList.Visible)
                    {
                        mySelectedItem();
                    }
                }
                else if (e.KeyCode == Keys.F3)//显示选择项目窗口
                {
                    if (this.bIsListShowAlways == false)
                    {
                        if (this.frmItemList != null) this.frmItemList.Hide();
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    frmItemList.Hide();
                }
            }
            catch { }
        }

        protected new void mySelectedItem()
        {
            if (this.bIsListShowAlways == false)
            {
                if (this.frmItemList != null) this.frmItemList.Hide();
            }

            int columnIndex = 0;
            for (int j = 0; j < this.fpItemList.Sheets[0].ColumnCount; j++)
            {
                if (this.fpItemList.Sheets[0].ColumnHeader.Columns[j].Label == "执行科室")
                {
                    columnIndex = j;
                    break;
                }

            }
            Neusoft.HISFC.Models.Base.Item item = new Neusoft.HISFC.Models.Base.Item();
            item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
            item.ID = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 0].Text;
            item.Name = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 1].Text;
            item.Specs = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 3].Text;
            item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 4].Text);
            item.PriceUnit = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 5].Text;
            item.SysClass.ID = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 8].Text;
            item.SpellCode = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 9].Text;
            item.WBCode = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 10].Text;
            item.UserCode = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 11].Text;

            this.myFeeItem = item;

            this.txtItemName.Text = this.myFeeItem.Name;
            this.txtItemCode.Text = string.Empty;
            frmItemList.Hide();
            if (this.SelectedItem != null)
                this.SelectedItem(this.FeeItem);
            return;
        }

        public override void Refresh()
        {
            this.AddItem();
        }

        public override void AddItem()
        {
            // [2007/02/08 徐伟哲]
            // 关键节同步对象,排它访问
            try
            {
                System.Threading.Monitor.Enter(this);
                if (this.bIsListShowAlways == false)
                {
                    this.txtItemCode.Enabled = false;
                }
                RefreshFP();
                this.txtItemCode.Text = "";
                this.txtItemCode.Enabled = true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                System.Threading.Monitor.Exit(this);
            }
        }

        public override void RefreshFP()
        {
            if (this.MyOrderType == null)
            {
                MessageBox.Show("请选择医嘱类型！");
                return;
            }

            if (this.dsUndrugItem == null || this.dsUndrugItem.Tables.Count == 0)
            {
                MessageBox.Show("获取非药品项目错误！");
                return;
            }

            try
            {
                dv = new DataView(this.dsUndrugItem.Tables[MyOrderType]);
                fpItemList.Sheets[0].DataSource = dv;
                if (this.IsListShowAlways == false)
                {
                    frmItemList.DataView = dv;
                    frmItemList.RefreshFP();
                }
                this.fpItemList.Sheets[0].Columns[0].Visible = false;
                this.fpItemList.Sheets[0].Columns[2].Width = 50;
                this.fpItemList.Sheets[0].Columns[3].Width = 90;
                this.fpItemList.Sheets[0].Columns[4].Width = 40;
                this.fpItemList.Sheets[0].Columns[5].Width = 30;
                this.fpItemList.Sheets[0].Columns[7].Visible = false;
                this.fpItemList.Sheets[0].Columns[8].Visible = false;
                this.fpItemList.Sheets[0].Columns[9].Visible = false;
                this.fpItemList.Sheets[0].Columns[10].Visible = false;
                this.fpItemList.Sheets[0].Columns[13].Visible = false;
                this.fpItemList.Sheets[0].Columns[14].Visible = false;
                this.fpItemList.Sheets[0].Columns[15].Visible = false;
                this.fpItemList.Sheets[0].Columns[16].Visible = false;
            }
            catch (Exception err)
            {
                MessageBox.Show("获取非药品项目错误:" + err.ToString());
                return;
            }
        }

        protected new void fpItemList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e != null)
            {
                mySelectedItem();
            }
        }
    }
}

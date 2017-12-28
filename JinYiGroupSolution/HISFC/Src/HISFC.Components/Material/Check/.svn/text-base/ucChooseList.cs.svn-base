using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Material.Check
{
    public partial class ucChooseList : UserControl
    {
        public ucChooseList()
        {
            InitializeComponent();
        }

        #region 域变量
        /// <summary>
        /// 查询方式
        /// </summary>
        private int intQueryType = 0;
        /// <summary>
        /// 与选择列表关联的DataSet
        /// </summary>
        protected DataTable myDataTable = new DataTable();
        protected DataView myDataView;
        /// <summary>
        /// 过滤字符串
        /// </summary>
        private string[] filterField = { "" };
        /// <summary>
        /// 是否使用默认字符串过滤
        /// </summary>
        private bool isFilterDefault;
        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.Management.Material.MetItem myItem = new Neusoft.HISFC.Management.Material.MetItem();
        /// <summary>
        /// 需执行的SetFormat函数名称
        /// </summary>
        private static string formatFlag = "SetFormat";
        /// <summary>
        /// 过滤后是否需要SetFormat
        /// </summary>
        private bool useFormat = true;
        #endregion

        #region 属性
        /// <summary>
        /// 是否使用默认过滤字段
        /// </summary>
        public bool IsFilterDefault
        {
            set { this.isFilterDefault = value; }
        }

        /// <summary>
        /// 数据绑定对象
        /// </summary>
        public DataTable DataTable
        {
            get { return this.myDataTable; }
            set
            {
                this.myDataTable = value;
                this.myDataView = new DataView(this.myDataTable);
                this.neuSpread1.DataSource = this.myDataView;
            }
        }

        public string[] FilterField
        {
            set { this.filterField = value; }
        }

        /// <summary>
        /// 树型列表
        /// </summary>
        public ImageList TvImageList
        {
            get { return this.tvList.ImageList; }
            set { this.tvList.ImageList = value; }
        }


        /// <summary>
        /// 树型列表
        /// </summary>
        public Neusoft.NFC.Interface.Controls.NeuTreeView TvList
        {
            get { return this.tvList; }
            set { this.tvList = value; }
        }


        /// <summary>
        /// 控件标题
        /// </summary>
        public string Caption
        {
            get { return this.lblCaption.Text; }
            set { this.lblCaption.Text = value; }
        }


        /// <summary>
        /// 是否显示TreeView，true显示TreeView，false显示Farpoit
        /// </summary>
        public bool IsShowTreeView
        {
            get { return this.tvList.Visible; }
            set
            {
                if (!this.tvList.Visible.Equals(value))
                {
                    this.tvList.Visible = value;
                    this.neuPanel1.Visible = !value;
                }
            }
        }

        /// <summary>
        /// 是否显示关闭按钮
        /// </summary>
        public bool IsShowCloseButton
        {
            get { return this.btnClose.Visible; }
            set { this.btnClose.Visible = value; }
        }

        /// <summary>
        /// 过滤后是否需要SetFormat
        /// </summary>
        public bool UseFormatForFilter
        {
            set
            {
                this.useFormat = value;
            }
        }
        /// <summary>
        /// 查询条件 0.全部   1.第一列   2.第二列   3......
        /// </summary>
        //private int iFilter = -1;//liuxq 屏蔽掉（因编译时警告）
        #endregion


        /// <summary>
        /// 通过输入的查询码，过滤数据列表
        /// </summary>
        private void ChangeItem()
        {
            //TODO:过滤列表，与输入法有关
            try
            {
                //判断当前类别过滤DataSet
                //System.Data.DataView dv = new DataView(myDataSet.Tables[0]);

                string filter = " ";
                if (!this.isFilterDefault)
                {			//不使用默认过滤字段
                    if (this.filterField.Length == 0)
                        return;

                    filter = "(" + this.filterField[0] + " LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                    for (int i = 1; i < this.filterField.Length; i++)
                    {
                        filter += "OR (" + this.filterField[i] + " LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                    }
                }
                else
                {							   //使用默认过滤字段					 －－改成右模糊
                    switch (this.intQueryType)
                    {
                        case 1://五笔
                            filter = "(五笔码 LIKE '" + this.txtQueryCode.Text.Trim() + "%' )";
                            break;
                        case 2://自定义
                            filter = "(自定义码 LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                            break;
                        default:
                            //拼音
                            filter = "(拼音码 LIKE '" + this.txtQueryCode.Text.Trim() + "%' )";
                            break;
                    }
                    filter = filter + " OR (商品名称 LIKE '%" + this.txtQueryCode.Text.Trim() + "%' )";
                }
                //设置过滤条件
                this.myDataView.RowFilter = filter;
                this.neuSpread1_Sheet1.ActiveRowIndex = 0;

                if (this.useFormat)
                {
                    switch (ucChooseList.formatFlag)
                    {
                        case "SetFormatForStorage":
                            this.SetFormatForStorage();
                            break;
                        default:
                            this.SetFormat();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 设置药品数据显示格式
        /// </summary>
        public void SetFormat()
        {
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "物资编码";
            this.neuSpread1_Sheet1.Columns.Get(0).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(1).Label = "物资名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 120F;
            this.neuSpread1_Sheet1.Columns.Get(1).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(2).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 76F;
            this.neuSpread1_Sheet1.Columns.Get(2).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(3).Label = "零售价";
            this.neuSpread1_Sheet1.Columns.Get(3).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(4).Label = "包装单位";
            this.neuSpread1_Sheet1.Columns.Get(4).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(5).Label = "包装数量";
            this.neuSpread1_Sheet1.Columns.Get(5).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(6).Label = "拼音码";
            this.neuSpread1_Sheet1.Columns.Get(6).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "五笔码";
            this.neuSpread1_Sheet1.Columns.Get(7).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "自定义码";
            this.neuSpread1_Sheet1.Columns.Get(8).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "通用名";
            this.neuSpread1_Sheet1.Columns.Get(9).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "通用名拼音码";
            this.neuSpread1_Sheet1.Columns.Get(10).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "通用名五笔码";
            this.neuSpread1_Sheet1.Columns.Get(11).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "通用名自定义码";
            this.neuSpread1_Sheet1.Columns.Get(12).Visible = false;

            ucChooseList.formatFlag = "SetFormat";
        }

        /// <summary>
        /// 显示库存药品时进行格式化
        /// </summary>
        public void SetFormatForStorage()
        {
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "物资编码";
            this.neuSpread1_Sheet1.Columns.Get(0).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(1).Label = "物资名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Visible = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 100F;

            this.neuSpread1_Sheet1.Columns.Get(2).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 76F;
            this.neuSpread1_Sheet1.Columns.Get(2).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(3).Label = "批号";
            this.neuSpread1_Sheet1.Columns.Get(3).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 0F;

            this.neuSpread1_Sheet1.Columns.Get(4).Label = "库位号";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 0F;
            this.neuSpread1_Sheet1.Columns.Get(4).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get(5).Label = "库存";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 58F;
            this.neuSpread1_Sheet1.Columns.Get(5).Visible = true;

            this.neuSpread1_Sheet1.Columns.Get(6).Label = "拼音码";
            this.neuSpread1_Sheet1.Columns.Get(6).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "五笔码";
            this.neuSpread1_Sheet1.Columns.Get(7).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "自定义码";
            this.neuSpread1_Sheet1.Columns.Get(8).Visible = false;

            ucChooseList.formatFlag = "SetFormatForStorage";
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="label">列标题</param>
        /// <param name="width">宽度</param>
        /// <param name="visible">是否显示</param>
        public void SetFormat(string[] label, int[] width, bool[] visible)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (label != null && label.Length > i)
                    this.neuSpread1_Sheet1.Columns[i].Label = label[i];
                if (width != null && width.Length > i)
                    this.neuSpread1_Sheet1.Columns[i].Width = width[i];
                if (visible != null && visible.Length > i)
                    this.neuSpread1_Sheet1.Columns[i].Visible = visible[i];
            }
        }

        /// <summary>
        /// 设置过滤框为内容全选状态
        /// </summary>
        public void SetFocusSelect()
        {
            this.txtQueryCode.SelectAll();
        }

        /// <summary>
        /// 获取显示数据的第一列到指定列宽度
        /// </summary>
        /// <param name="columnNum">需计算的列数量</param>
        /// <param name="width">返回的宽度</param>
        public void GetColumnWidth(int columnNum, ref int width)
        {
            int iNum = 0;
            width = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Columns[i].Visible)
                {
                    width = width + (int)this.neuSpread1_Sheet1.Columns[i].Width;
                    iNum = iNum + 1;
                    if (iNum > columnNum - 1)
                        break;
                }
            }
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowChooseList(System.Data.DataSet dataSet)
        {
            try
            {
                this.neuSpread1.DataSource = this.myDataView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        
        /// <summary>
        ///  设置查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, System.EventArgs e)
        {
        }

        private void txtQueryCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex++;
                this.neuSpread1_Sheet1.AddSelection(this.neuSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex--;
                this.neuSpread1_Sheet1.AddSelection(this.neuSpread1_Sheet1.ActiveRowIndex, 0, 1, 0);
                return;
            }
        }

        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            this.ChangeItem();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Neusoft.NFC.Interface.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, "d:\\wolf.xml");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Visible = false;
        }

        private void ucChooseList_Load(object sender, System.EventArgs e)
        {
            this.btnClose.Click += new EventHandler(btnClose_Click);
            //将myDataView跟neuSpread1绑定
            this.myDataView = new DataView(this.myDataTable);
            this.neuSpread1.DataSource = this.myDataView;

            //显示neuSpread1
            this.IsShowTreeView = false;
        }

     }
}

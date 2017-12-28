using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Pharmacy;
using System.Collections;

namespace Neusoft.HISFC.Components.Preparation
{
    public partial class ucItemList : UserControl
    {
        public ucItemList()
        {
            InitializeComponent();
            this.Load += new EventHandler(ucPhaItem_Load);
            this.neuSpread1.KeyDown += new KeyEventHandler(neuSpread1_KeyDown);
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(neuSpread1_CellDoubleClick);
            this.pbHide.Click += new EventHandler(pbHide_Click);
        }

        public event System.EventHandler SelectItem;

        #region 变量
        /// <summary>
        /// 配置文件存储路径
        /// </summary>
        protected string FilePath = Application.StartupPath + "//Profile//PhaItem.xml";
        /// <summary>
        /// 检索数据DataSet
        /// </summary>
        protected DataSet dsPhaData;
        /// <summary>
        /// 检索数据DataView
        /// </summary>
        protected DataView dvPhaData;
        /// <summary>
        /// 需检索的药品类别
        /// </summary>
        protected string drugType = "ALL";
        /// <summary>
        /// 库存科室 ID 为空 则检索数据由字典表内获取
        /// </summary>
        protected Neusoft.FrameWork.Models.NeuObject drugDept = new Neusoft.FrameWork.Models.NeuObject(); 
        /// <summary>
        /// 过滤字符串
        /// </summary>
        protected string strFilter = "(spell_code like '{0}') or (wb_code like '{0}') or (custom_code like '{0}') or (trade_name like '{0}')";
        #endregion

        #region 属性

        /// <summary>
        /// 过滤字符串  格式 (spell_code like '{0}') or (wb_code like '{0}')
        /// </summary>
        public string FilterString
        {
            get
            {
                return this.strFilter;
            }
            set
            {
                this.strFilter = value;
            }
        }

        #endregion

        #region 函数

        /// <summary>
        /// 数据检索初始化 
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int Init()
        {
            this.neuSpread1_Sheet1.DataAutoSizeColumns = false;

            #region 获取数据

            Neusoft.FrameWork.Management.DataBaseManger dataBaseMgr = new Neusoft.FrameWork.Management.DataBaseManger();
            if (dsPhaData == null)
            {
                dsPhaData = new DataSet();
            }

            #region 获取查询Sql索引
            string[] strIndex;
            string[] strParam = null;
            if (drugDept == null || drugDept.ID == "")
            {
                if (drugType == "ALL")
                {
                    strIndex = new string[] { "Pharmacy.Item.Info" };
                    strParam = new string[] { };
                }
                else
                {
                    strIndex = new string[] { "Pharmacy.Item.Info", "Preparation.Item.GetList.QueryByType" };
                    strParam = new string[] { drugType };
                }
            }
            else
            {
                strIndex = new string[] { "Pharmacy.Item.Info", "Pharmacy.Item.GetAvailableList.Inpatient.ByDrugType" };
                strParam = new string[] { drugDept.ID, drugType };
            }
            #endregion

            if (dataBaseMgr.ExecQuery(strIndex, ref dsPhaData, strParam) == -1)
            {
                MessageBox.Show("读取药品信息时发生错误 \n" + dataBaseMgr.Err);
                return -1;
            }

            if (dsPhaData.Tables.Count > 0)
            {
                this.dvPhaData = new DataView(this.dsPhaData.Tables[0]);
                this.neuSpread1_Sheet1.DataSource = dvPhaData;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnFormatProperty(this.neuSpread1_Sheet1, this.FilePath);
            }
            #endregion

            return 1;
        }

        /// <summary>
        /// 数据检索初始化
        /// </summary>
        /// <param name="drugDept">检索库房</param>
        /// <param name="drugType">检索药品类别 ALL检索所有类别</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int Init(Neusoft.FrameWork.Models.NeuObject drugDept, string drugType)
        {
            if (drugDept == null || drugDept.ID == "")
                this.drugDept = new Neusoft.FrameWork.Models.NeuObject();
            else
                this.drugDept = drugDept;
            this.drugType = drugType;
            return this.Init();
        }

        /// <summary>
        /// 格式化
        /// </summary>
        private void SetFormat()
        {

        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="str">过滤字符串</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int Filter(string str)
        {
            try
            {
                if (this.dvPhaData == null)
                    return -1;
                str = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(str);
                if (!this.ckExactSearch.Checked)
                {
                    str = "%" + str + "%";
                }
                this.dvPhaData.RowFilter = string.Format(this.strFilter, str);
                this.neuSpread1_Sheet1.DataSource = this.dvPhaData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行过滤操作发生异常 \n" + ex.Message);
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 获取当前药品实体
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int GetItem()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return 1;

            if (this.SelectItem != null)
            {
                Item item = this.GetItem(this.neuSpread1_Sheet1.ActiveRowIndex);
                if (item == null)
                    return -1;
                this.SelectItem(item, System.EventArgs.Empty);

                this.Hide();
            }
            return 1;
        }

        /// <summary>
        /// 获取指定行的Item实体
        /// </summary>
        /// <param name="rowIndex">指定行索引</param>
        /// <returns>成功返回Item实体 失败返回null</returns>
        protected Item GetItem(int rowIndex)
        {
            try
            {
                Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                return itemManager.GetItem(this.neuSpread1_Sheet1.Cells[rowIndex, 0].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("由FarPoint读取实体信息进行赋值时发生异常\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 按键相应
        /// </summary>
        /// <param name="key"></param>
        public void Key(System.Windows.Forms.Keys key)
        {
            switch (key)
            {
                case Keys.Enter:
                    this.GetItem();
                    break;
                case Keys.Up:
                    this.PrivRow();
                    break;
                case Keys.Down:
                    this.NextRow();
                    break;
                case Keys.Escape:
                    this.Hide();
                    break;
            }
        }

        /// <summary>
        /// 选择上一行
        /// </summary>
        public void PrivRow()
        {
            this.neuSpread1_Sheet1.ActiveRowIndex--;
        }

        /// <summary>
        /// 选择下一行
        /// </summary>
        public void NextRow()
        {
            this.neuSpread1_Sheet1.ActiveRowIndex++;
        }

        #endregion

        private void ucPhaItem_Load(object sender, EventArgs e)
        {
            string strErr = "";
            ArrayList al = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("Pha", "ItemSize", out strErr);
            if (al != null && al.Count > 1)
            {
                this.Height = Neusoft.FrameWork.Function.NConvert.ToInt32(al[0]);
                this.Width = Neusoft.FrameWork.Function.NConvert.ToInt32(al[1]);
            }
        }

        private void neuSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.GetItem();
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.RowHeader || e.ColumnHeader)
                return;

            this.GetItem();
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void neuSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnFormatProperty(this.neuSpread1_Sheet1, this.FilePath);
        }

    }
}

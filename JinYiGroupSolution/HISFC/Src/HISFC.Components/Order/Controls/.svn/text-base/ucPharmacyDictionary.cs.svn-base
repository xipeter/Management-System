using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 药品字典]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPharmacyDictionary : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPharmacyDictionary()
        {
            InitializeComponent();
        }
        public string FilePath
        {
            get { return Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "PharmacyOrderInfo.xml"; }
        }

        Neusoft.FrameWork.Management.DataBaseManger myItem = new Neusoft.FrameWork.Management.DataBaseManger();
        DataView dv = null;

        private string filterTree = " 1=1 "; //树型节点选择过滤条件
        private string filterInput = " 1=1 "; //输入码过滤条件


        #region {E556A187-D9CA-4837-86ED-A57FA4FF23C4}
        protected bool isShowStorage = false;
        /// <summary>
        /// 保存出错后，是否继续进行其它患者保存
        /// </summary>
        [Description("是否显示库存信息")]
        public bool IsShowStorage
        {
            get
            {
                return this.isShowStorage;
            }
            set
            {
                this.isShowStorage = value;
            }
        }


        private void ShowStorage(string drugCode)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载药品库存信息 请稍候.....");
            Application.DoEvents();
            DataSet ds = new DataSet();
            if (this.myItem.ExecQuery("Order.GetPharmacy.Storage.OrderInfo", ref ds, drugCode) == -1)
            {
                MessageBox.Show("获取药品库存信息出错\n" + this.myItem.Err + "请退出重试");
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return;
            }
            try
            {
                DataView dvStore = new DataView(ds.Tables[0]);
                this.fpStorage_Sheet1.DataSource = dvStore;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GC.Collect();
                return;
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }

        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string drugCode = string.Empty;
            if (this.fpSpread1_Sheet1.RowCount > 0 && e.Row >= 0)
            {
                drugCode = this.fpSpread1_Sheet1.Cells[e.Row, 0].Text;

                if (string.IsNullOrEmpty(drugCode))
                {
                    this.pnlBottom.Visible = false;
                }
                else
                {
                    if (this.isShowStorage)
                    {
                        this.pnlBottom.Visible = true;
                        this.ShowStorage(drugCode);
                    }
                }
            }
        }

        #endregion

        private void ucPharmacyDictionary_Load(object sender, System.EventArgs e)
        {

            this.neuLinkLabel1.Click += new EventHandler(linkLabel1_Click);
            this.txtFilter.TextChanged += new EventHandler(textBox1_TextChanged);
            this.fpSpread1.ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(fpSpread1_ColumnWidthChanged);
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);
            //this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellClick);
            
            try
            {
                this.PassInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.pnlBottom.Visible = false;//{E556A187-D9CA-4837-86ED-A57FA4FF23C4}

            //this.ShowPharmacyInfo();
        }


        public int PassInit()
        {
            //Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("合理用药系统初始化 请稍候...");
            //Application.DoEvents();
            ////if (Pass.Pass.PassInit(this.myItem.Operator.ID, this.myItem.Operator.Name, ((Neusoft.HISFC.Models.RADT.Person)this.myItem.Operator).Dept.ID, ((Neusoft.HISFC.Models.RADT.Person)this.myItem.Operator).Dept.Name, false) == -1)
            ////{
            ////    MessageBox.Show(Pass.Pass.Err);
            ////    return -1;
            ////}
            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        
        public void ShowPharmacyInfo()
        {

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载药品信息 请稍候.....");
            Application.DoEvents();
            DataSet ds = new DataSet();
            if (this.myItem.ExecQuery("Pharmacy.Item.OrderInfo", ref ds, "") == -1)
            {
                MessageBox.Show("获取药品信息出错\n" + this.myItem.Err + "请退出重试");
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return;
            }
            try
            {
                dv = new DataView(ds.Tables[0]);
                this.fpSpread1_Sheet1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GC.Collect();
                return;
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }

            try
            {
                if (System.IO.File.Exists(this.FilePath))
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpSpread1_Sheet1, this.FilePath);
                }
                else
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1, this.FilePath);
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show("获取数据显示配置文件时出错! 请退出重试" + ex.Message);
                //GC.Collect();
                return;
            }
        }


        private void linkLabel1_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Components.Common.Controls.ucSetColumn uc = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            uc.FilePath = this.FilePath;
            uc.SetColVisible(true, true, false, false);
            uc.SetDataTable(this.FilePath, this.fpSpread1.Sheets[0]);
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "显示设置";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            uc.DisplayEvent += new EventHandler(ucSetColumn_DisplayEvent);
            this.ucSetColumn_DisplayEvent(null, null);
        }

        private void ucSetColumn_DisplayEvent(object sender, EventArgs e)
        {
            this.ShowPharmacyInfo();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtFilter.Text);
            queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(queryCode, "'", "%");
            queryCode = queryCode + "%";
            this.filterInput = "((商品名拼音码 LIKE '" + queryCode + "') OR " +
                "(商品名五笔码 LIKE '" + queryCode + "') OR " +
                "(商品名自定义码 LIKE '" + queryCode + "') OR " +
                "(商品名称 LIKE '" + queryCode + "') OR" +
                "(通用名拼音码 LIKE '" + queryCode + "') OR " +
                "(通用名五笔码 LIKE '" + queryCode + "') OR " +
                "(通用名 LIKE '" + queryCode + "') OR (英文名 LIKE '" + queryCode + "') )";

            this.SetFilter();
        }


        private void SetFilter()
        {
            //组合过滤条件
            string filter = this.filterTree + " AND " + this.filterInput;
            //过滤数据
            dv.RowFilter = filter;
        }


        private void fpSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1_Sheet1, this.FilePath);
        }



        #region IReport 成员

       

        public void Export()
        {
            // TODO:  添加 ucPharmacyDictionary.Export 实现
            try
            {
                string fileName = "";
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Microsoft Excel 工作薄 (*.xls)|*.xls";
                DialogResult result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    this.fpSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Query()
        {
            // TODO:  添加 ucPharmacyDictionary.Query 实现
            this.ShowPharmacyInfo();
        }

      
        #endregion

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.Query();
            return null;
        }
        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.PrintPreview(this);
            return 0;
        }
      
    }
}

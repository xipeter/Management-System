using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 特殊单位维护]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// <说明>
    ///     待测试
    /// </说明>
    /// </summary>
    public partial class ucSpeUnit : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSpeUnit()
        {
            InitializeComponent();
        }

        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        private ucSpeUnitManager uc = null;

        private System.Data.DataSet myDataSet = new System.Data.DataSet();

        private System.Data.DataView myDataView;

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加", "新增多级单位信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("删除", "删除多级单位信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "增加")
            {
                this.Add();
            }
            if (e.ClickedItem.Text == "删除")
            {
                this.Del();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        /// <summary>
        /// DataSet初始化
        /// </summary>
        private void InitDataSet()
        {
            this.myDataSet.Tables.Clear();
            this.myDataSet.Tables.Add();

            this.myDataView = new System.Data.DataView(this.myDataSet.Tables[0]);
            this.neuSpread1_Sheet1.DataSource = this.myDataView;

            System.Type tStr = System.Type.GetType("System.String");
            System.Type tDec = System.Type.GetType("System.Decimal");

            this.myDataSet.Tables[0].Columns.AddRange(new System.Data.DataColumn[] {
																					   new DataColumn("编码",tStr),
																					   new DataColumn("名称",tStr),
																					   new DataColumn("规格",tStr),
																					   new DataColumn("包装单位",tStr),
				                                                                       new DataColumn("包装数量",tDec),
																					   new DataColumn("最小单位",tStr),
																					   new DataColumn("拼音码",tStr),
																					   new DataColumn("五笔码",tStr),
																					   new DataColumn("自定义码",tStr)
																				   });

            DataColumn[] keys = new DataColumn[] { this.myDataSet.Tables[0].Columns["编码"] };
            this.myDataSet.Tables[0].PrimaryKey = keys;

        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.InitDataSet();

            if (uc == null)
            {
                uc = new ucSpeUnitManager();
            }

            this.uc.SaveDataEvent += new HISFC.Components.Pharmacy.Base.ucSpeUnitManager.SaveDataHander( uc_SaveDataEvent );
            this.uc.Init();

            this.neuSpread1_Sheet1.RowHeaderVisible = true;
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
        }

        /// <summary>
        /// 按照药品检索显示 
        /// </summary>
        private void ShowList()
        {
            this.myDataSet.Tables[0].Rows.Clear();

            ArrayList al = this.itemManager.QuerySpeUnitList();
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取已维护的特殊单位列表发生错误" + itemManager.Err));
                return;
            }
            if (this.uc == null)
            {
                this.uc.HsItem = new Hashtable();
            }

            Neusoft.HISFC.Models.Pharmacy.Item item;

            foreach (Neusoft.HISFC.Models.Pharmacy.DrugSpeUnit info in al)
            {
                item = this.itemManager.GetItem(info.Item.ID);
                if (!this.uc.HsItem.ContainsKey(item.ID))
                {
                    this.uc.HsItem.Add(item.ID, item);
                }

                this.myDataSet.Tables[0].Rows.Add(new object[]
					{
						item.ID,
						item.Name,
						item.Specs,
						item.PackUnit,
						item.PackQty.ToString(),
						item.MinUnit,
						item.NameCollection.SpellCode,
						item.NameCollection.WBCode,
						item.NameCollection.UserCode
					});
            }

            this.myDataSet.AcceptChanges();

            this.SetFormat();

        }

        /// <summary>
        /// 加入信息
        /// </summary>
        private void AddItem(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            this.myDataSet.Tables[0].Rows.Add(new object[] {
																		item.ID,
																		item.Name,
																		item.Specs,
																		item.PackUnit,
																		item.PackQty.ToString(),
																		item.MinUnit,
																		item.NameCollection.SpellCode,
																		item.NameCollection.WBCode,
																		item.NameCollection.UserCode
																   });
        }

        /// <summary>
        /// 增加项目
        /// </summary>
        private void Add()
        {
            if (uc != null)
            {
                this.uc.Item = null;
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Del()
        {
            DialogResult rs = MessageBox.Show(Language.Msg("确认删除该条药品吗？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
                return;

            int i = this.neuSpread1_Sheet1.ActiveRowIndex;

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.itemManager.DeleteSpeUnit(this.neuSpread1_Sheet1.Cells[i, 0].Text) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("删除数据失败");
                return;
            }
            if (this.uc.HsItem != null)
            {
                if (this.uc.HsItem.ContainsKey(this.neuSpread1_Sheet1.Cells[i, 0].Text))
                {
                    this.uc.HsItem.Remove(this.neuSpread1_Sheet1.Cells[i, 0].Text);
                }
            }

            this.neuSpread1_Sheet1.RemoveRows(i, 1);

            this.myDataSet.AcceptChanges();

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("删除成功"));

        }

        /// <summary>
        /// 项目过滤
        /// </summary>
        private void FilterItem()
        {
            if (this.myDataSet.Tables[0].Rows.Count == 0) return;

            try
            {
                string queryCode = "";
                queryCode = "%" + this.txtFilter.Text.Trim() + "%";

                string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                    "(五笔码 LIKE '" + queryCode + "') OR " +
                    "(自定义码 LIKE '" + queryCode + "')";

                //设置过滤条件
                this.myDataView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.SetFormat();
        }

        /// <summary>
        /// 格式化
        /// </summary>
        private void SetFormat()
        {
            this.neuSpread1_Sheet1.Columns[0].Visible = false;		//编码

            this.neuSpread1_Sheet1.Columns[6].Visible = false;
            this.neuSpread1_Sheet1.Columns[7].Visible = false;
            this.neuSpread1_Sheet1.Columns[8].Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.ShowList();
            }

            base.OnLoad(e);
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (uc != null)
            {
                this.uc.SetSpeUnit(this.uc.HsItem[this.neuSpread1_Sheet1.Cells[e.Row, 0].Text] as Neusoft.HISFC.Models.Pharmacy.Item);

                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            }
        }

        private void uc_SaveDataEvent(object data)
        {
            try
            {
                Neusoft.HISFC.Models.Pharmacy.Item item = data as Neusoft.HISFC.Models.Pharmacy.Item;
                object[] keys = new object[] { item.ID };
                DataRow row = this.myDataSet.Tables[0].Rows.Find(keys);
                if (row == null)
                {
                    this.AddItem(data as Neusoft.HISFC.Models.Pharmacy.Item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.FilterItem();
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Items
{
    public partial class ucPriceHistory : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private System.Data.DataTable PriceHistry = null;
        private System.Data.DataView PricehistryDV = null;
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        public ucPriceHistory()
        {
            InitializeComponent();
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("打印", "打印数据", 0, true, false, null);
            return this.toolBarService;
            //return base.OnInit(sender, neuObject, param);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "打印":
                    this.PrintInfo();
                    this.SerWidth();
                    break;
                default: break;
            }
            //base.ToolStrip_ItemClicked(sender, e);
        }

        private void initDataTable()
        {
            PriceHistry = new System.Data.DataTable("调价");

            DataColumn his_DataColumn1 = new DataColumn("调价单号");
            his_DataColumn1.DataType = typeof(System.String);
            PriceHistry.Columns.Add(his_DataColumn1);

            DataColumn his_DataColumn2 = new DataColumn("非药品代码");
            his_DataColumn2.DataType = typeof(System.String);
            PriceHistry.Columns.Add(his_DataColumn2);

            DataColumn his_DataColumn3 = new DataColumn("名称");
            his_DataColumn3.DataType = typeof(System.String);
            PriceHistry.Columns.Add(his_DataColumn3);

            DataColumn his_DataColumn4 = new DataColumn("调前默认价");
            his_DataColumn4.DataType = typeof(System.Decimal);
            PriceHistry.Columns.Add(his_DataColumn4);

            DataColumn his_DataColumn5 = new DataColumn("调后默认价");
            his_DataColumn5.DataType = typeof(System.Decimal);
            PriceHistry.Columns.Add(his_DataColumn5);

            DataColumn his_DataColumn6 = new DataColumn("调前儿童价");
            his_DataColumn6.DataType = typeof(System.Decimal);
            PriceHistry.Columns.Add(his_DataColumn6);

            DataColumn his_DataColumn7 = new DataColumn("调后儿童价");
            his_DataColumn7.DataType = typeof(System.Decimal);
            PriceHistry.Columns.Add(his_DataColumn7);

            DataColumn his_DataColumn8 = new DataColumn("调前特诊价");
            his_DataColumn8.DataType = typeof(System.Decimal);
            PriceHistry.Columns.Add(his_DataColumn8);

            DataColumn his_DataColumn9 = new DataColumn("调后特诊价");
            his_DataColumn9.DataType = typeof(System.Decimal);
            PriceHistry.Columns.Add(his_DataColumn9);

            DataColumn his_DataColumn10 = new DataColumn("有效");
            his_DataColumn10.DataType = typeof(System.String);
            PriceHistry.Columns.Add(his_DataColumn10);
        }

        private void AddDataToTable(ArrayList List)
        {
            if (PriceHistry != null)
            {
                PriceHistry.Clear();
            }
            if (List != null)
            {
                try
                {
                    foreach (Neusoft.HISFC.Models.Fee.Item.AdjustPrice info in List)
                    {
                        PriceHistry.Rows.Add(new object[] { info.AdjustPriceNO, 
                                                            info.OrgItem.ID, 
                                                            info.OrgItem.Name, 
                                                            info.OrgItem.Price, 
                                                            info.NewItem.Price, 
                                                            info.OrgItem.ChildPrice, 
                                                            info.NewItem.ChildPrice, 
                                                            info.OrgItem.SpecialPrice, 
                                                            info.NewItem.SpecialPrice, 
                                                            info.User03 });
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void AddDataToTree(ArrayList List)
        {
            try
            {
                this.neuTreeView1.Nodes.Clear();
                if (List != null)
                {
                    TreeNode node = null;
                    foreach (Neusoft.HISFC.Models.Fee.Item.AdjustPrice info in List)
                    {
                        string temp = "调价单 " + info.AdjustPriceNO;// +" 生效日期:" + info.Oper.OperTime.ToString("yyyy-MM-dd");
                        node = new TreeNode(temp);
                        node.Tag = info.AdjustPriceNO;
                        this.neuTreeView1.Nodes.Add(node);
                        node = null;
                    }
                }
            }
            catch (Exception ee)
            {
                string Error = ee.Message;
            }
        }

        private void GetData()
        {
            Neusoft.HISFC.BizLogic.Manager.AdjustPrice pric = new Neusoft.HISFC.BizLogic.Manager.AdjustPrice();
            string strMorning = this.neuDateTimePicker1.Value.ToShortDateString() + " 00:00:00";
            string strNight = this.neuDateTimePicker2.Value.ToShortDateString() + " 23:59:59";
            ArrayList List = pric.SelectPriceAdjustHead(Convert.ToDateTime(strMorning), Convert.ToDateTime(strNight));
            AddDataToTree(List);
        }

        private void SerWidth()
        {
            this.neuSpread1_Sheet1.Columns[1].Visible = false;
            FarPoint.Win.Spread.CellType.CheckBoxCellType check = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            neuSpread1_Sheet1.Columns[1].CellType = check;
        }

        private void PrintInfo()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
                p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                p.PrintPreview(this.neuPanel4);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            PricehistryDV.RowFilter = "名称 like  '" + neuTextBox1.Text + "%'";
            PricehistryDV.RowStateFilter = DataViewRowState.CurrentRows;
        }

        private void neuDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (this.neuDateTimePicker1.Value > this.neuDateTimePicker2.Value)
            {
                this.neuDateTimePicker1.Value = this.neuDateTimePicker2.Value;
            }
            GetData();
        }

        private void neuDateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (this.neuDateTimePicker1.Value > this.neuDateTimePicker2.Value)
            {
                this.neuDateTimePicker2.Value = this.neuDateTimePicker1.Value;
            }
            GetData();
        }

        private void neuTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                Neusoft.HISFC.BizLogic.Manager.AdjustPrice pric = new Neusoft.HISFC.BizLogic.Manager.AdjustPrice();
                ArrayList List = pric.SelectPriceAdjustTail(e.Node.Tag.ToString());
                AddDataToTable(List);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            SerWidth();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            int altKey = Keys.Alt.GetHashCode();
            if (keyData.GetHashCode() == altKey + Keys.P.GetHashCode())
            {
                //打印
                this.PrintInfo();
            }
            if (keyData.GetHashCode() == altKey + Keys.P.GetHashCode())
            {
                //退出
                this.FindForm().Close();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ucPriceHistory_Load(object sender, EventArgs e)
        {
            this.initDataTable();
            PricehistryDV = new DataView(PriceHistry);
            neuSpread1_Sheet1.DataSource = PricehistryDV;
            GetData();
            SerWidth();
        }
    }
}

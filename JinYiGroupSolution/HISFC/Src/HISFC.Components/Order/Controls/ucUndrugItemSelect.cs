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
    /// <summary>
    /// 执行单管理 单项目维护
    /// </summary>
    public partial class ucUndrugItemSelect : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucUndrugItemSelect()
        {
            InitializeComponent();
        }

        public delegate int AllItemHandle(string orderType, string sysClass, ArrayList alItems);
        public event AllItemHandle ItemAllUpdate;
        public delegate int OtherItemHandle(ArrayList alItems);
        public event ItemHandle ItemOtherInsert;
        public delegate int ItemHandle(ArrayList alItems);
        public event ItemHandle ItemInsert;

        private Neusoft.FrameWork.Public.ObjectHelper orderTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        //护士站编码

        private string nurseID;
        public string NurseID
        {
            set
            {
                this.nurseID = value;
                this.ucInputUndrug.NurseID = value;
            }
        }

        private string billNO;
        public string BillNO
        {
            set
            {
                this.billNO = value;
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
                if (this.myOrderType == value)
                {
                    return;
                }
                else
                {
                    this.myOrderType = value;
                    this.ucInputUndrug.MyOrderType = value;
                    for (int i = 0; i < this.cmbOrderType.alItems.Count; i++)
                    {
                        Neusoft.HISFC.Models.Order.OrderType orderType = this.cmbOrderType.alItems[i] as Neusoft.HISFC.Models.Order.OrderType;
                        if (orderType.ID == value)
                        {
                            this.cmbOrderType.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        //医嘱开立项目

        private string mySysClass;
        public string MySysClass
        {
            get
            {
                return this.mySysClass;
            }
            set
            {
                if (this.mySysClass == value)
                {
                    return;
                }
                else
                {
                    this.mySysClass = value;
                    this.ucInputUndrug.MySysClass = value;
                }
            }
        }

        public int Init()
        {
            if (this.GetOrderType() == -1)
            {
                return -1;
            }

            this.ucInputUndrug.AlOrderType = this.cmbOrderType.alItems;
            this.ucInputUndrug.CatagoryChanged += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucInputUndrug_CatagoryChanged);
            if (this.ucInputUndrug.Init() == -1)
            {
                return -1;
            }
            this.ucInputUndrug.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucInputUndrug_SelectedItem);
            return 0;
        }

        void ucInputUndrug_CatagoryChanged(Neusoft.FrameWork.Models.NeuObject sender)
        {
            Neusoft.FrameWork.Models.NeuObject obj = sender as Neusoft.FrameWork.Models.NeuObject;
            this.mySysClass = obj.ID;
        }

        void ucInputUndrug_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {
            Neusoft.HISFC.Models.Base.Item item = sender as Neusoft.HISFC.Models.Base.Item;
            this.AddItem(item);
        }

        private int GetOrderType()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alOrderType = manager.QueryOrderTypeList();
            if (alOrderType == null)
            {
                MessageBox.Show("获取医嘱类别错误！");
                return -1;
            }

            this.cmbOrderType.AddItems(alOrderType);
            this.orderTypeHelper.ArrayObject = alOrderType;
            return 0;
        }

        protected void AddItem(Neusoft.HISFC.Models.Base.Item item)
        {
            if (item == null)
            {
                return;
            }

            if (this.rdbSingle.Checked)
            {
                if (this.lvUndrugItems.Items.Count > 0)
                {
                    this.lvUndrugItems.Items.Clear();
                }
            }

            foreach (ListViewItem lstItem in this.lvUndrugItems.Items)
            {
                Neusoft.HISFC.Models.Base.Item inItem = lstItem.Tag as Neusoft.HISFC.Models.Base.Item;
                if (item.ID == inItem.ID)
                {
                    MessageBox.Show("该项目已添加:" + item.Name);
                    return;
                }
            }

            ListViewItem lvItem = new ListViewItem(item.Name);
            lvItem.Tag = item;
            lvItem.Checked = true;
            this.lvUndrugItems.Items.Add(lvItem);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.ucInputUndrug.Refresh();
            base.OnLoad(e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (this.lvUndrugItems.Items.Count > 0)
            {
                this.lvUndrugItems.Items.Clear();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Check() == -1)
            {
                MessageBox.Show("保存失败！");
                this.FindForm().Hide();
                return;
            }

            if (this.rdbAll.Checked)//全部
            {
                if (this.SaveAllItems() == -1)
                {
                    MessageBox.Show("保存失败！");
                }
                else
                {
                    MessageBox.Show("保存成功！");
                }
            }
            else if (this.rdbOther.Checked)//剩余全部
            {
                if (this.SaveOtherItems() == -1)
                {
                    MessageBox.Show("保存失败！");
                }
                else
                {
                    MessageBox.Show("保存成功！");
                }
            }
            else
            {
                if (this.SaveItems() == -1)
                {
                    MessageBox.Show("保存失败！");
                }
                else
                {
                    MessageBox.Show("保存成功！");

                }
            }
            if (this.lvUndrugItems.Items.Count > 0)
            {
                this.lvUndrugItems.Items.Clear();
            }
            this.FindForm().Hide();
            return;
        }

        /// <summary>
        /// 选择全部保存
        /// </summary>
        /// <returns></returns>
        private int SaveAllItems()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //执行单表操作
            Neusoft.HISFC.BizLogic.Order.ExecBill manager = new Neusoft.HISFC.BizLogic.Order.ExecBill();
            if (manager.UpdateExecBillAllItem(this.nurseID, this.billNO, this.myOrderType, this.mySysClass) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            //DataSet操作
            DataTable dt = this.ucInputUndrug.DsUndrugItem.Tables[this.myOrderType];
            if (dt == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            ArrayList alItems = new ArrayList();
            string filter = "类别编码='" + this.mySysClass + "'";
            foreach (DataRow row in dt.Select(filter))
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                order.ID = this.billNO;
                order.Memo = "2";
                order.OrderType.ID = this.myOrderType;
                order.OrderType.Name = this.orderTypeHelper.GetName(this.myOrderType);
                order.Item.SysClass.ID = this.mySysClass;
                order.Item.ID = row["编码"].ToString();
                order.Item.Name = row["名称"].ToString();
                alItems.Add(order);
                row.Delete();
            }

            //farpoint操作
            if (this.ItemAllUpdate != null)
            {
                if (this.ItemAllUpdate(this.myOrderType, this.mySysClass, alItems) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 0;
        }

        private int SaveOtherItems()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //执行单表操作
            Neusoft.HISFC.BizLogic.Order.ExecBill manager = new Neusoft.HISFC.BizLogic.Order.ExecBill();
            if (manager.InsertExecBillOtherItem(this.nurseID, this.billNO, this.myOrderType, this.mySysClass) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            //DataSet操作
            DataTable dt = this.ucInputUndrug.DsUndrugItem.Tables[this.myOrderType];
            if (dt == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            ArrayList alItems = new ArrayList();
            string filter = "类别编码='" + this.mySysClass + "'";
            foreach (DataRow row in dt.Select(filter))
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                order.ID = this.billNO;
                order.Memo = "2";
                order.OrderType.ID = this.myOrderType;
                order.OrderType.Name = this.orderTypeHelper.GetName(this.myOrderType);
                order.Item.SysClass.ID = this.mySysClass;
                order.Item.ID = row["编码"].ToString();
                order.Item.Name = row["名称"].ToString();
                alItems.Add(order);
                row.Delete();
            }

            //farpoint操作
            if (this.ItemOtherInsert != null)
            {
                if (this.ItemOtherInsert(alItems) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 0;
        }

        /// <summary>
        /// 选择单选或多选的保存
        /// </summary>
        /// <returns></returns>
        private int SaveItems()
        {
            ArrayList alItem = this.GetItems();
            if (alItem == null)
            {
                return 0;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //执行单表操作
            Neusoft.HISFC.BizLogic.Order.ExecBill manager = new Neusoft.HISFC.BizLogic.Order.ExecBill();
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in alItem)
            {
                if (manager.UpdateExecBillItem(this.nurseID, this.billNO, this.myOrderType, this.mySysClass, order.Item.ID, order.Item.Name) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }

            DataTable dt = this.ucInputUndrug.DsUndrugItem.Tables[this.myOrderType];
            if (dt == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            //datase操作
            string filter = "类别编码='" + this.mySysClass + "' and 编码 in (";
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in alItem)
            {
                filter += "'" + order.Item.ID + "',";
            }
            filter = filter.Substring(0, filter.Length - 1);
            filter += ")";
            foreach (DataRow row in dt.Select(filter))
            {
                row.Delete();
            }

            //farpoint操作
            if (this.ItemInsert != null)
            {
                if (this.ItemInsert(alItem) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 0;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.lvUndrugItems.Items.Count > 0)
            {
                this.lvUndrugItems.Items.Clear();
            }
            this.FindForm().Hide();
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbAll.Checked || this.rdbOther.Checked)
            {
                this.ucInputUndrug.txtItemCode.Enabled = false;
                if (this.lvUndrugItems.Items.Count > 0)
                {
                    this.lvUndrugItems.Items.Clear();
                }
            }
            else
            {
                this.ucInputUndrug.txtItemCode.Enabled = true;
            }
        }

        private void rdbOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbAll.Checked || this.rdbOther.Checked)
            {
                this.ucInputUndrug.txtItemCode.Enabled = false;
                if (this.lvUndrugItems.Items.Count > 0)
                {
                    this.lvUndrugItems.Items.Clear();
                }
            }
            else
            {
                this.ucInputUndrug.txtItemCode.Enabled = true;
            }
        }

        private int Check()
        {
            if (this.nurseID == null || this.nurseID == string.Empty)
            {
                return -1;
            }

            if (this.billNO == null || this.billNO == string.Empty)
            {
                return -1;
            }

            if (this.myOrderType == null || this.myOrderType == string.Empty)
            {
                return -1;
            }

            if (this.myOrderType == null || this.mySysClass == string.Empty)
            {
                return -1;
            }

            return 0;
        }

        private ArrayList GetItems()
        {
            if (this.cmbOrderType.SelectedItem == null)
            {
                return null;
            }

            if (this.mySysClass == null || this.mySysClass == string.Empty)
            {
                return null;
            }

            if (this.lvUndrugItems.CheckedItems.Count > 0)
            {
                ArrayList alItem = new ArrayList();
                foreach (ListViewItem item in this.lvUndrugItems.CheckedItems)
                {
                    Neusoft.FrameWork.Models.NeuObject obj = item.Tag as Neusoft.FrameWork.Models.NeuObject;
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                    order.ID = this.billNO;
                    order.Memo = "2";
                    order.OrderType.ID = this.myOrderType;
                    order.OrderType.Name = this.orderTypeHelper.GetName(this.myOrderType);
                    order.Item.SysClass.ID = this.mySysClass;
                    order.Item.ID = obj.ID;
                    order.Item.Name = obj.Name;
                    alItem.Add(order);
                }
                return alItem;
            }
            else
            {
                return null;
            }
        }
    }
}

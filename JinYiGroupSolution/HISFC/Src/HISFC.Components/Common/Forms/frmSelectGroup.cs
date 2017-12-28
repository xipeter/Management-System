using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Common.Forms
{
    /// <summary>
    /// [功能描述: 组套选择控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <说明
    ///		 通过传入的Fp 显示Fp的列信息 并可维护是否显示/排序等信息
    ///  />
    /// </summary>
    public partial class frmSelectGroup : Form
    {
        public frmSelectGroup(Neusoft.HISFC.Models.Base.Group groupInfo)
        {
            InitializeComponent();
            this.Init(groupInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        protected Neusoft.HISFC.Models.Base.ServiceTypes inpatientType = Neusoft.HISFC.Models.Base.ServiceTypes.I;


        private Neusoft.HISFC.BizLogic.Manager.UndrugztManager ztManager = new Neusoft.HISFC.BizLogic.Manager.UndrugztManager();

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(Neusoft.HISFC.Models.Base.ServiceTypes.I)]
        public Neusoft.HISFC.Models.Base.ServiceTypes InpatientType
        {
            get
            {
                return inpatientType;
            }
            set
            {
                inpatientType = value;
            }
        }

        Neusoft.HISFC.BizLogic.Manager.Group groupManager = new Neusoft.HISFC.BizLogic.Manager.Group();
        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init(Neusoft.HISFC.Models.Base.Group groupInfo)
        {
            ArrayList myalItems = groupManager.GetAllItem(groupInfo);
            if (myalItems == null) return;

            this.InpatientType = groupInfo.UserType;
            Classes.Function.ShowOrder(this.spread1_Sheet1, myalItems, 1, this.inpatientType);
            this.spread1_Sheet1.Columns.Add(0, 1);
            this.spread1_Sheet1.Columns[0].Label = "选择";
            this.spread1_Sheet1.Columns[0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.spread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            
            for (int i = 1; i < this.spread1_Sheet1.ColumnCount; i++)
            {
                
                   this.spread1_Sheet1.Columns[i].Locked = true;
                
            }
            this.spread1_Sheet1.Columns[0].Locked = false;
            //默认全部选中
            for (int i = 0; i < this.spread1_Sheet1.RowCount; i++)
            {
               this.spread1_Sheet1.SetValue(i, 0, true, false);
               Neusoft.HISFC.Models.Order.Order order = this.spread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.Order;
               if (order != null && order.ExtendFlag2 == "N")
               {
                   this.spread1_Sheet1.Rows[i].BackColor = Color.Gray;//停用的项目
                   this.spread1_Sheet1.SetValue(i, 0, false, false);
               }
            }
           
        }
        public ArrayList Orders
        {
            get
            {
                ArrayList alOrders = new ArrayList();
                string comboID = "";
                string newComboID = "";
                Neusoft.HISFC.BizLogic.Order.Order ordermanager = new Neusoft.HISFC.BizLogic.Order.Order();
                Neusoft.HISFC.BizLogic.Manager.OrderType orderType = new Neusoft.HISFC.BizLogic.Manager.OrderType();
                Neusoft.FrameWork.Public.ObjectHelper objecthelper = new Neusoft.FrameWork.Public.ObjectHelper(orderType.GetList());
                Neusoft.HISFC.BizLogic.Fee.Item itemManagement = new Neusoft.HISFC.BizLogic.Fee.Item();
                Neusoft.HISFC.BizLogic.Pharmacy.Item pManagement = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                string err = "";
                for (int i = 0; i < this.spread1_Sheet1.RowCount; i++)
                {
                    if (this.spread1_Sheet1.Cells[i, 0].Text.ToUpper() == "TRUE")
                    {
                        if (this.InpatientType == Neusoft.HISFC.Models.Base.ServiceTypes.I)
                        {
                            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.spread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                            if (order.ExtendFlag2 == "N")
                                continue;
                            order.User01 = "";
                            order.User02 = "";
                            order.ID = "";
                            if (order.Combo.ID != "" && order.Combo.ID != comboID)//新的
                            {
                                comboID = order.Combo.ID;
                                newComboID = ordermanager.GetNewOrderComboID();
                                order.Combo.ID = newComboID;
                            }
                            else if (order.Combo.ID == comboID)
                            {
                                order.Combo.ID = newComboID;
                            }
                            string strOrderName = order.Name;
                            //填充项目基本信息  Add By liangjz 2005-08
                            //if (order.Item.IsPharmacy)
                            if(order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                            {

                                if (Neusoft.HISFC.BizProcess.Integrate.Order.FillPharmacyItem(null, ref order, out err) == -1)
                                {
                                    MessageBox.Show("获得药品信息出错！" + string.Format("错误原因，［{0}］药品可能已经停用！", strOrderName));
                                    return null;
                                }
                            }
                            else
                            {
                                if (Neusoft.HISFC.BizProcess.Integrate.Order.FillFeeItem(null, ref order, out err) == -1)
                                {
                                    MessageBox.Show("获得非药品信息出错！" + string.Format("错误原因，［{0}］非药品可能已经停用！", strOrderName));
                                    return null;
                                }
                            }

                            order.OrderType = (Neusoft.HISFC.Models.Order.OrderType)objecthelper.GetObjectFromID(order.OrderType.ID);

                            alOrders.Add(order);
                        }
                        else
                        {
                            Neusoft.HISFC.Models.Order.OutPatient.Order order = this.spread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                            if (order.ExtendFlag2 == "N")
                                continue;
                            order.User01 = "";
                            order.User02 = "";
                            order.ID = "";
                            if (order.Combo.ID != "" && order.Combo.ID != comboID)//新的
                            {
                                comboID = order.Combo.ID;
                                newComboID = ordermanager.GetNewOrderComboID();
                                order.Combo.ID = newComboID;
                            }
                            else if (order.Combo.ID == comboID)
                            {
                                order.Combo.ID = newComboID;
                            }
                            //填充项目基本信息
                            //if (order.Item.IsPharmacy)
                            if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                            {
                                if (order.Item.ID == "999")
                                {
                                    ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Type.ID = order.Item.SysClass.ID.ToString().Substring(order.Item.SysClass.ID.ToString().Length - 1, 1);
                                }
                                else
                                {
                                    Neusoft.HISFC.Models.Pharmacy.Item item = new Neusoft.HISFC.Models.Pharmacy.Item();
                                    item = pManagement.GetItem(order.Item.ID);
                                    if (item == null || item.IsStop)
                                    {
                                        MessageBox.Show("获得非药品信息出错！" + string.Format("错误原因，［{0}］药品可能已经停用！", order.Item.Name));
                                        return null;
                                    }
                                    else
                                    {
                                        order.Item.MinFee = item.MinFee;
                                        order.Item.Price = item.Price;
                                        order.Item.Name = item.Name;
                                        order.Item.SysClass = item.SysClass.Clone();//付给系统类别
                                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsAllergy = item.IsAllergy;
                                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).PackUnit = item.PackUnit;
                                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit = item.MinUnit;
                                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose = item.BaseDose;
                                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm = item.DosageForm;
                                        if (order.Unit == item.MinUnit)
                                        {
                                            order.NurseStation.User03 = "1";
                                        }
                                        else
                                        {
                                            order.NurseStation.User03 = "0";
                                        }
                                    }
                                    #region {DC0E8BDB-D918-4c14-8474-3D2E6F986A57}
                                    if (item.SysClass.ID.ToString() == "PCC")
                                    {
                                        order.Qty = order.Qty * order.HerbalQty;
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                if (order.Item.ID != "999")
                                {
                                    Neusoft.HISFC.Models.Fee.Item.Undrug item = itemManagement.GetValidItemByUndrugCode(order.Item.ID);
                                    if (item == null)
                                    {
                                        MessageBox.Show("获得非药品信息出错！" + string.Format("错误原因，［{0}］非药品可能已经停用！", order.Item.Name));
                                        return null;
                                    }
                                    else
                                    {
                                        ((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).IsNeedConfirm = item.IsNeedConfirm;
                                        order.Item.Price = item.Price;
                                        order.Item.MinFee = item.MinFee;
                                        order.Item.SysClass = item.SysClass.Clone();
                                    }
                                }
                            }
                            
                            alOrders.Add(order);
                        }
                    }
                }
                return alOrders;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.spread1_Sheet1.Columns[0].CellType.GetType() != typeof(FarPoint.Win.Spread.CellType.CheckBoxCellType))
                return;

            //全部选中
            for (int i = 0; i < spread1_Sheet1.RowCount; i++)
            {
                spread1_Sheet1.SetValue(i, 0, this.chkAll.Checked, false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void spread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.HISFC.Models.Order.Order order = this.spread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Order;
            List<Neusoft.HISFC.Models.Fee.Item.UndrugComb> lstzt = new List<Neusoft.HISFC.Models.Fee.Item.UndrugComb>();
            if (this.ztManager.QueryUnDrugztDetail(order.ID, ref lstzt) == -1)
            {
                return ;
            }
            if (lstzt.Count == 0)
            {
                return ;
            }
            for(int i=0;i<lstzt.Count;i++)
            {               
                this.neuTextBox1.Text += "  "+lstzt[i].Name.ToString() ;
            }
        }
    }
}
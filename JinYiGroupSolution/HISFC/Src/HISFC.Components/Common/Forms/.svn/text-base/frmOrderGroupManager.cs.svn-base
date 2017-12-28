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
    /// 医嘱组套修改，添加；
    /// 管理窗口
    /// </summary>
    public partial class frmOrderGroupManager : Form
    {
        public frmOrderGroupManager()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        public Neusoft.HISFC.Models.Base.Group CurrentGroup;

        //public ArrayList alGroupDept = new ArrayList();
        //public ArrayList alGroupPer = new ArrayList();
        public ArrayList alGroupAll = new ArrayList();

        protected ArrayList myalItems;
        /// <summary>
        /// 显示项目
        /// </summary>
        public ArrayList alItems
        {
            set
            {
                myalItems = value;
                Classes.Function.ShowOrder(this.fpSpread1_Sheet1, myalItems, 1, this.inpatientType);
                FarPoint.Win.Spread.CellType.NumberCellType num = new FarPoint.Win.Spread.CellType.NumberCellType();
                num.MaximumValue = 10;
                num.DecimalPlaces = 0;
                this.fpSpread1_Sheet1.Columns[5].CellType = num;
                this.tvDoctorGroup1.Visible = false;
                this.mnuAll.Checked = false;
            }
        }

        private Neusoft.HISFC.BizLogic.Manager.Group manager = new Neusoft.HISFC.BizLogic.Manager.Group();
        /// <summary>
        /// 是否显示全院组套
        /// </summary>
        public bool IsManager
        {
            set
            {
                this.rdo3.Visible = value;
            }
        }
        bool IsAdd = false;


        /// <summary>
        /// 组套类型（门诊C，住院I）
        /// </summary>
        protected Neusoft.HISFC.Models.Base.ServiceTypes inpatientType = Neusoft.HISFC.Models.Base.ServiceTypes.I;

        /// <summary>
        /// 组套类型（门诊C，住院I）
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

        protected override void OnLoad(EventArgs e)
        {
            this.tvDoctorGroup1.SelectOrder += new Neusoft.HISFC.Components.Common.Controls.SelectOrderHandler(tvDoctorGroup1_SelectOrder);
            
            this.cmbGroupName.Text = "";

            
            this.Activated+=new EventHandler(frmOrderGroupManager_Activated);
            this.fpSpread1_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(fpSpread1_Sheet1_CellChanged);
            this.rdo3.CheckedChanged += new EventHandler(radioButton3_CheckedChanged);
            
            if (this.tvDoctorGroup1.Nodes.Count == 0)
            {
                this.tvDoctorGroup1.Type = Neusoft.HISFC.Components.Common.Controls.enuType.Order;
                this.tvDoctorGroup1.ShowType = Neusoft.HISFC.Components.Common.Controls.enuGroupShowType.All;
                this.tvDoctorGroup1.InpatientType = this.inpatientType;
                this.tvDoctorGroup1.Init();
                this.alGroupAll = this.tvDoctorGroup1.AllGroup;
            }

            InitComboBox();
            base.OnLoad(e);
        }
       
        void tvDoctorGroup1_SelectOrder(ArrayList alOrders)
        {
            object o = this.tvDoctorGroup1.SelectedNode.Tag;
            if (o != null)
            {
                if (o.GetType() == typeof(Neusoft.HISFC.Models.Base.Group))
                {
                    Neusoft.HISFC.Models.Base.Group info = o as Neusoft.HISFC.Models.Base.Group;
                    this.label1.Text = info.Name;
                    this.cmbGroupName.Items.Clear();
                    this.cmbGroupName.Items.Add(info);
                    this.cmbGroupName.SelectedIndex = 0;
                    //this.cmbGroupName.Text = info.Name;
                    myalItems = manager.GetAllItem(info);
                    Classes.Function.ShowOrder(this.fpSpread1_Sheet1, myalItems, 1,this.inpatientType);
                    
                }
            }
        }
        

       
        public void Save()
        {
            #region 判断是否为修改原组套
            Neusoft.HISFC.Models.Base.Group group;
            Neusoft.HISFC.Models.Base.Employee empl = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Clone();
            Neusoft.HISFC.Models.Base.Group groupSelected = this.cmbGroupName.SelectedItem as Neusoft.HISFC.Models.Base.Group;
            if (groupSelected == null || groupSelected.ID == "")
            {
                groupSelected = new Neusoft.HISFC.Models.Base.Group();
            }
            if (this.rdo2.Checked)
            {
                for (int i = 0; i < this.alGroupAll.Count; i++)
                {
                    group = alGroupAll[i] as Neusoft.HISFC.Models.Base.Group;
                    
                    if (groupSelected.ID == group.ID)
                    {
                        this.CurrentGroup = group;
                        this.IsAdd = true;
                        break;
                    }
                    if (this.cmbGroupName.Text == group.Name && group.Dept.ID == empl.Dept.ID && group.Kind == Neusoft.HISFC.Models.Base.GroupKinds.Dept )
                    {
                        this.CurrentGroup = group;
                        this.IsAdd = true;
                        break;
                    }
                }
            }
            else
            {
                if (this.rdo1.Checked)
                {
                    for (int i = 0; i < this.alGroupAll.Count; i++)
                    {
                        group = alGroupAll[i] as Neusoft.HISFC.Models.Base.Group;
                        
                        if (groupSelected.ID == group.ID)
                        {
                            this.CurrentGroup = group;
                            this.IsAdd = true;
                            break;
                        }
                        if (this.cmbGroupName.Text == group.Name && group.Doctor.ID == empl.ID && group.Kind == Neusoft.HISFC.Models.Base.GroupKinds.Doctor)
                        {
                            this.CurrentGroup = group;
                            this.IsAdd = true;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.alGroupAll.Count; i++)
                    {
                        group = this.alGroupAll[i] as Neusoft.HISFC.Models.Base.Group;
                        
                        if (groupSelected.ID == group.ID)
                        {
                            this.CurrentGroup = group;
                            this.IsAdd = true;
                            break;
                        }
                        if (this.cmbGroupName.Text == group.Name && group.Kind == Neusoft.HISFC.Models.Base.GroupKinds.All)
                        {
                            this.CurrentGroup = group;
                            this.IsAdd = true;
                            break;
                        }
                    }
                }
            }
            #endregion

            if (this.CurrentGroup == null)//新的
            {
                CurrentGroup = new Neusoft.HISFC.Models.Base.Group();
                CurrentGroup.ID = manager.GetNewGroupID();
                if (this.cmbGroupName.Text.Trim() == "")
                {
                    MessageBox.Show("请输入组套名称!");
                    CurrentGroup = null;
                    return;
                }
                if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbGroupName.Text.Trim(), 30) == false)
                {
                    MessageBox.Show("组套名称超长!", "提示");
                    CurrentGroup = null;
                    return;
                }
                CurrentGroup.Name = this.cmbGroupName.Text;
                //CurrentGroup.UserType = Neusoft.HISFC.Models.Base.ServiceTypes.I;//住院
                CurrentGroup.UserType = this.inpatientType;
                Neusoft.HISFC.Models.Base.Employee ee = ((Neusoft.HISFC.Models.Base.Employee)manager.Operator).Clone();
                CurrentGroup.Dept.ID = ee.Dept.ID;
                if (this.rdo2.Checked)			//科室
                {
                    CurrentGroup.Kind = Neusoft.HISFC.Models.Base.GroupKinds.Dept;
                    CurrentGroup.Doctor.ID = "";
                }
                else
                {
                    if (this.rdo1.Checked)		//个人
                    {
                        CurrentGroup.Kind = Neusoft.HISFC.Models.Base.GroupKinds.Doctor;
                        CurrentGroup.Doctor.ID = manager.Operator.ID;
                    }
                    else								//全院组套
                    {
                        CurrentGroup.Kind = Neusoft.HISFC.Models.Base.GroupKinds.All;
                    }
                }
            }

            if (this.IsAdd == true && this.chkAdd.Checked == false)
            {
                DialogResult r = MessageBox.Show("是否要覆盖掉原来的组套，\n*不追加会丢失掉原来的数据！", "友情提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.No)
                    return;
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
            //t.BeginTransaction();
            manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            if (this.chkAdd.Checked == false)
            {
                if (manager.DeleteGroup(CurrentGroup) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存组套失败"  + manager.Err);
                    return;
                }
                if (manager.DeleteGroupOrder(CurrentGroup) < 0)//删除明细
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存组套失败" + manager.Err);
                    return;
                }
            }
            if (manager.UpdateGroup(CurrentGroup) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存组套失败" + manager.Err);
                return;
            }
            if (this.chkAdd.Checked == false)
            {
                if (manager.DeleteGroupOrder(CurrentGroup) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存组套失败" + manager.Err);
                    return;
                }
            }
            try
            {
                for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
                {
                    if (this.inpatientType == Neusoft.HISFC.Models.Base.ServiceTypes.I)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order order = (this.fpSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order).Clone();
                        //判断对开立时间的修改是否正确
                        order.BeginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.Cells[i, 13].Text);
                        if (order.BeginTime == DateTime.MinValue)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(order.Item.Name + "医嘱开始时间设置错误 请重新设置");
                            return;
                        }
                        if (order.Item.SysClass.ID.ToString() == "UL" && order.Sample.Name != "")
                        {
                            order.CheckPartRecord = order.Sample.Name;
                        }
                        if (manager.UpdateGroupItem(CurrentGroup, order) < 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(manager.Err);
                            return;
                        }
                    }
                    else
                    {
                        Neusoft.HISFC.Models.Order.OutPatient.Order order = (this.fpSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order).Clone();
                        //判断对开立时间的修改是否正确
                        order.BeginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.Cells[i, 13].Text);
                        if (order.BeginTime == DateTime.MinValue)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(order.Item.Name + "医嘱开始时间设置错误 请重新设置");
                            return;
                        }
                        if (order.Item.SysClass.ID.ToString() == "UL" && order.Sample.Name != "")
                        {
                            order.CheckPartRecord = order.Sample.Name;
                        }
                        if (manager.UpdateGroupItem(CurrentGroup, order) < 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(manager.Err);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { Neusoft.FrameWork.Management.PublicTrans.RollBack(); MessageBox.Show(ex.Message); }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功！");
            this.tvDoctorGroup1.RefrshGroup();
            this.Close();
        }

        private void InitComboBox()
        {
            Neusoft.HISFC.Models.Base.Group group;
            this.cmbGroupName.Items.Clear();
            Neusoft.HISFC.Models.Base.Employee empl = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Clone();
            if (this.rdo2.Checked)
            {
                for (int i = 0; i < this.alGroupAll.Count; i++)
                {
                    group = alGroupAll[i] as Neusoft.HISFC.Models.Base.Group;
                    if (group == null) continue;
                    if ( group.Dept.ID == empl.Dept.ID && group.Kind == Neusoft.HISFC.Models.Base.GroupKinds.Dept)
                    {
                        this.cmbGroupName.Items.Add(group);
                    }
                }
            }
            else
            {
                if (this.rdo1.Checked)
                {
                    for (int i = 0; i < this.alGroupAll.Count; i++)
                    {
                        group = alGroupAll[i] as Neusoft.HISFC.Models.Base.Group;
                        if (group == null) continue;
                        if ( group.Doctor.ID == empl.ID && group.Kind == Neusoft.HISFC.Models.Base.GroupKinds.Doctor)
                        {
                            this.cmbGroupName.Items.Add(group);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.alGroupAll.Count; i++)
                    {
                        group = this.alGroupAll[i] as Neusoft.HISFC.Models.Base.Group;
                        if (group == null) continue;
                        if (group.Kind == Neusoft.HISFC.Models.Base.GroupKinds.All)
                        {
                            this.cmbGroupName.Items.Add(group);
                        }
                        
                    }
                }
            }   
        }
       

        private void mnuExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

      
        private void frmOrderGroupManager_Activated(object sender, EventArgs e)
        {
            this.cmbGroupName.Focus();
        }

        bool dirty = false;
        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (e.Column == 5 && dirty == false)
            {
                Neusoft.HISFC.Models.Order.Order order = this.fpSpread1_Sheet1.Rows[e.Row].Tag as Neusoft.HISFC.Models.Order.Order;
                if (order == null) return;
                order.User03 = this.fpSpread1_Sheet1.Cells[e.Row, e.Column].Value.ToString();
                if (order.Combo.ID != null && order.Combo.ID != "")
                {
                    for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                    {
                        Neusoft.HISFC.Models.Order.Order obj = this.fpSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.Order;
                        if (obj.Combo.ID == order.Combo.ID)
                        {
                            obj.User03 = order.User03;
                            dirty = true;
                            this.fpSpread1_Sheet1.Cells[i, e.Column].Value = order.User03;
                            dirty = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 选择组套类型变化 处理下拉列表内项目
        /// </summary>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cmbGroupName.Items.Count > 0)
                this.cmbGroupName.Items.Clear();
            InitComboBox();
        }
        

     
        /// <summary>
        /// 保存
        /// </summary>
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Save();
        }

        /// <summary>
        /// 取消
        /// </summary>
        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuAll_Click(object sender, EventArgs e)
        {
            this.tvDoctorGroup1.Visible = !this.mnuAll.Checked;
            this.mnuAll.Checked = !this.mnuAll.Checked;
            
        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cmbGroupName.Items.Count > 0)
                this.cmbGroupName.Items.Clear();
            InitComboBox();

        }

        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cmbGroupName.Items.Count > 0)
                this.cmbGroupName.Items.Clear();
            InitComboBox();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
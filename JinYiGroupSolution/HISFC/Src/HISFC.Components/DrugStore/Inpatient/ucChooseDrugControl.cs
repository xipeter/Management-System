using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    public partial class ucChooseDrugControl : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucChooseDrugControl()
        {
            InitializeComponent();

            this.neuSpread1.ButtonClicked -= new FarPoint.Win.Spread.EditorNotifyEventHandler(neuSpread1_ButtonClicked);
            this.neuSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(neuSpread1_ButtonClicked);
        }

        public delegate void SelectControlDelegate(Neusoft.HISFC.Models.Pharmacy.DrugControl drugControl);

        public event SelectControlDelegate SelectControlEvent;

        /// <summary>
        /// 当前选择的摆药台
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.DrugControl drugControl = new Neusoft.HISFC.Models.Pharmacy.DrugControl();

        /// <summary>
        /// 当前选择的科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject selectOperDept = null;

        /// <summary>
        /// 是否显示科室列表
        /// </summary>
        [Description("是否显示科室列表"),Category("设置"),DefaultValue(false)]
        public bool IsShowDept
        {
            get
            {
                return this.panelTree.Visible;
            }
            set
            {
                this.panelTree.Visible = value;
            }
        }

        /// <summary>
        /// 当前选择的科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SelectOperDept
        {
            get
            {
                return this.selectOperDept;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void InitDeptList()
        {
            try
            {
                Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
                this.ShowControlList(((Neusoft.HISFC.Models.Base.Employee)dataManager.Operator).Dept.ID);

                this.tvDeptTree1.IsShowPI = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化配药台列表发生错误" + ex.Message);
            }
        }

        #region {50CAFFB7-1E18-4b0d-95D6-CEC019D4C35D} 权限控制摆药台 add by guanyx
        /// <summary>
        /// 根据登陆人的权限，过滤摆药台
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        private ArrayList FliterControl(ArrayList al)
        {
            
            //人员权限分配明细管理
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager privManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();

            string operCode = privManager.Operator.ID;
            string deptCode = ((Neusoft.HISFC.Models.Base.Employee)privManager.Operator).Dept.ID;

            //定义药房管理类
            Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();           

            //取操作员的药房权限
            ArrayList alPriv = privManager.LoadByUserCode(operCode, "03", deptCode);
            
            string priv = "";
            for (int i = 0; i < alPriv.Count; i++)
            {
                Neusoft.HISFC.Models.Admin.UserPowerDetail no = alPriv[i] as Neusoft.HISFC.Models.Admin.UserPowerDetail;
                if (no.PowerLevelClass.Class3Code == "Z1")
                {
                    priv += "B";
                }
                if (no.PowerLevelClass.Class3Code == "Z2")
                {
                    priv += "T";
                }
            }
            if (al == null)
            {
                MessageBox.Show(drugStoreManager.Err);
                return al;
            }
            if (al.Count == 0)
            {
                MessageBox.Show(Language.Msg("您所在的科室没有设置摆药台，请先设置本科室的摆药台。"));
                return al;
            }
            Neusoft.HISFC.Models.Pharmacy.DrugControl control;
            Neusoft.HISFC.Models.Pharmacy.DrugControl QuitDrugControl = new Neusoft.HISFC.Models.Pharmacy.DrugControl();
            for (int i = 0; i < al.Count; i++)
            {
                control = al[i] as Neusoft.HISFC.Models.Pharmacy.DrugControl;
                if (control.Name == "退药台")
                {
                    QuitDrugControl = control;
                }
            }
            if (priv.Length == 1)
            {
                if (priv == "B")
                {
                    al.Remove(QuitDrugControl);
                }
                else
                {
                    al.Clear();
                    al.Add(QuitDrugControl);
                }
                return al;
            }
            else if (priv.Length == 0)
            {
                al.Clear();
                return al;
            }

            //{4DD1822D-1CB6-4561-9EBD-FE14DC4FCBC0} 摆药台排序 by guanyx
            ControlCompare controlCompare = new ControlCompare();
            al.Sort(controlCompare);

            return al;
        }

        /// <summary>
        /// {4DD1822D-1CB6-4561-9EBD-FE14DC4FCBC0} by guanyx
        /// 摆药台排序
        /// </summary>
        public class ControlCompare : System.Collections.IComparer
        {
            #region Comparer 成员

            public int Compare(object x, object y)
            {
                if (((Neusoft.HISFC.Models.Pharmacy.DrugControl)x).ExtendFlag != "" && ((Neusoft.HISFC.Models.Pharmacy.DrugControl)y).ExtendFlag != "")
                {
                    int i = Convert.ToInt32(((Neusoft.HISFC.Models.Pharmacy.DrugControl)x).ExtendFlag);
                    int j = Convert.ToInt32(((Neusoft.HISFC.Models.Pharmacy.DrugControl)y).ExtendFlag);
                    return i - j;
                }
                else
                {
                    return 0;
                }
            }

            #endregion
        }

        #endregion

        /// <summary>
        /// 显示本科室全部摆药台列表
        /// </summary>
        public virtual void ShowControlList(string deptCode)
        {
            //清除当前显示的摆药台
            this.neuSpread1_Sheet1.Rows.Count = 0;

            //判断科室编码是否存在
            if (deptCode == "")
            {
                MessageBox.Show(Language.Msg("无效的摆药科室！没有可以选择的摆药台"));
                return;
            }

            //定义药房管理类
            Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();           

            //取本科室全部摆药台列表
            ArrayList al = drugStoreManager.QueryDrugControlList(deptCode);

            //{50CAFFB7-1E18-4b0d-95D6-CEC019D4C35D} 权限控制摆药台 add by guanyx
            al = this.FliterControl(al);        

            if (al == null)
            {
                MessageBox.Show(drugStoreManager.Err);
                return;
            }
            if (al.Count == 0)
            {
                MessageBox.Show(Language.Msg("您所在的科室没有设置摆药台，请先检查本科室的摆药台。\n\r或者您没有操作摆药台的权限，请检查您的权限"));
                return;
            }
           
            this.neuSpread1_Sheet1.Rows.Add(0, al.Count);
            Neusoft.HISFC.Models.Pharmacy.DrugControl drugControl;
            for (int i = 0; i < al.Count; i++)
            {
                drugControl = al[i] as Neusoft.HISFC.Models.Pharmacy.DrugControl;

                FarPoint.Win.Spread.CellType.ButtonCellType btnType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                btnType.ButtonColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(225)), ((System.Byte)(243)));
                btnType.Text = drugControl.Name;
                btnType.TextDown = drugControl.Name;
                this.neuSpread1_Sheet1.Cells[i, 0].CellType = btnType;
                this.neuSpread1_Sheet1.Cells[i, 1].Text = drugControl.SendType == 0 ? "全部" : (drugControl.SendType == 1 ? "集中" : "临时");
                this.neuSpread1_Sheet1.Cells[i, 2].Text = drugControl.ShowLevel == 0 ? "显示科室汇总" : (drugControl.ShowLevel == 1 ? "显示科室明细" : "显示患者明细");
                this.neuSpread1_Sheet1.Rows[i].Tag = drugControl;
            }

            if (al.Count == 1)
            {
                this.drugControl = al[0] as Neusoft.HISFC.Models.Pharmacy.DrugControl;

                if (this.SelectControlEvent != null)
                {
                    this.SelectControlEvent(this.drugControl);
                }
                return;
            }
        }

         private void tvDeptTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                this.ShowControlList((e.Node.Tag as Neusoft.HISFC.Models.Base.Department).ID);

                this.selectOperDept = e.Node.Tag as Neusoft.HISFC.Models.Base.Department;
            }
        }

        private void neuSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 0)
            {
                this.drugControl = this.neuSpread1_Sheet1.Rows[e.Row].Tag as Neusoft.HISFC.Models.Pharmacy.DrugControl;

                if (this.SelectControlEvent != null)
                {
                    this.SelectControlEvent(this.drugControl);
                }
            }
        }

    }
}

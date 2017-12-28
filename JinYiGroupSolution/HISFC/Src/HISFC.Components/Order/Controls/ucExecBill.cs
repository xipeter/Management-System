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
    /// <summary>
    /// [功能描述: 执行单打印]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucExecBill : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucExecBill()
        {
            InitializeComponent();
        }

        private Neusoft.HISFC.BizLogic.Order.Order Order = new Neusoft.HISFC.BizLogic.Order.Order();
        private Neusoft.HISFC.BizLogic.Order.ExecBill Bill = new Neusoft.HISFC.BizLogic.Order.ExecBill();
        private Neusoft.HISFC.BizProcess.Integrate.Manager bed = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        bool IsPrint = false;//是否打印状态
        string Memo = "";//执行单执行时间

        DateTime tempDate = new DateTime();


        protected List<Neusoft.HISFC.Models.RADT.PatientInfo> myPatients = null;

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            ResetPanel();
            tempDate = this.Order.GetDateTimeFromSysDateTime();
            this.dateTimePicker1.Value = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, 00, 00, 00);
            this.dateTimePicker2.Value = new DateTime(tempDate.AddDays(1).Year, tempDate.AddDays(1).Month, tempDate.AddDays(1).Day, 12, 01, 00);

        }

        Neusoft.HISFC.BizProcess.Interface.IPrintTransFusion ip = null;//当前接口


        protected override void OnLoad(EventArgs e)
        {
            Init();

        }
        public int Retrieve()
        {
            // TODO:  添加 ucDrugCardPanel.Retrieve 实现
            if (this.tabControl1.TabPages.Count <= 0) return 0;
            Neusoft.FrameWork.Models.NeuObject obj = ((Neusoft.FrameWork.Models.NeuObject)this.tabControl1.SelectedTab.Tag);
            string BillNo = ((Neusoft.FrameWork.Models.NeuObject)this.tabControl1.SelectedTab.Tag).ID;
            this.IsPrint = false;
            this.Memo = ((Neusoft.FrameWork.Models.NeuObject)this.tabControl1.SelectedTab.Tag).User01;
            this.Query(BillNo);
            return 0;
        }

        private void Query(string billNo)
        {

            if (this.tabControl1.TabPages.Count <= 0 || this.myPatients == null) return;

            IsPrint = this.chkRePrint.Checked;
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询执行单信息...");
            if (this.tabControl1.SelectedTab.Controls[0].Controls.Count == 0)
            {
                //当前Tab页里面还没有输液卡
                object o = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.Controls.ucExecBill), typeof(Neusoft.HISFC.BizProcess.Interface.IPrintTransFusion));
                //object o = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(), typeof(Neusoft.HISFC.BizProcess.Integrate.IPrintTransFusion));
                if (o == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("请维护HISFC.Components.Order.Controls.ucExecBill里面接口Neusoft.HISFC.BizProcess.Integrate.IPrintTransFusion的实例对照！");
                    return;
                }
                ip = o as Neusoft.HISFC.BizProcess.Interface.IPrintTransFusion;
                ((Control)o).Tag = tabControl1.SelectedTab.Text;
                ((Control)o).Visible = true;
                ((Control)o).Dock = DockStyle.Fill;
                this.tabControl1.SelectedTab.Controls[0].Controls.Add((Control)o);

            }
            else
            {
                ip = this.tabControl1.SelectedTab.Controls[0].Controls[0] as Neusoft.HISFC.BizProcess.Interface.IPrintTransFusion;
            }
            if (ip == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("维护的实例不具备Neusoft.HISFC.BizProcess.Integrate.IPrintTransFusion接口");
                return;
            }

            try
            {
                ip.Query(this.myPatients, billNo, this.dateTimePicker1.Value, this.dateTimePicker2.Value, this.IsPrint);
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }



        public void ResetPanel()
        {
            ArrayList alBill = new ArrayList();

            try
            {
                //获得执行单分类
                alBill = Bill.QueryExecBill(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID);
            }
            catch { MessageBox.Show("获得执行单分类出错！"); }

            if (alBill == null)
            {
                MessageBox.Show("获得执行单设置出错！");
                return;
            }
            this.tabControl1.TabPages.Clear();

            for (int i = 0; i < alBill.Count; i++)
            {
                TabPage t = new TabPage();
                t.Text = ((Neusoft.FrameWork.Models.NeuObject)alBill[i]).Name;
                t.Tag = alBill[i];

                Panel p = new Panel();
                p.AutoScroll = true;
                p.Dock = DockStyle.Fill;
                p.BackColor = Color.White;

                t.Controls.Add(p);

                this.tabControl1.TabPages.Add(t);
            }


        }



        /// <summary>
        /// 设置执行单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //frmSetExecBill f = new frmSetExecBill(Neusoft.Common.Class.Main.var);
            //f.ShowDialog();
            this.ResetPanel();
        }


        private void tabControl1_SelectionChanged(object sender, System.EventArgs e)
        {
            if (this.myPatients != null && this.myPatients.Count > 0 && this.tabControl1.TabPages.Count > 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示执行单信息，请稍候........");
                Application.DoEvents();
                string BillNo = ((Neusoft.FrameWork.Models.NeuObject)this.tabControl1.SelectedTab.Tag).ID;
                this.IsPrint = false;

                this.Memo = ((Neusoft.FrameWork.Models.NeuObject)this.tabControl1.SelectedTab.Tag).User01;
                this.Query(BillNo);
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 补打变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.Retrieve();
            }
            catch
            {
                MessageBox.Show("请先点查询按钮进行查询！");
            }
        }




        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public override Neusoft.FrameWork.WinForms.Forms.ToolBarService Init(object sender, object neuObject, object param)
        {
            TreeView tv = sender as TreeView;
            if (tv != null && tv.CheckBoxes == false) tv.CheckBoxes = true;
            this.ResetPanel();
            return null;
        }


        #region donggq--20101118--{7DC99247-EB4B-4660-87D0-E581F9247F51}

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (tv != null && this.tv.CheckBoxes == false)
            {
                tv.CheckBoxes = true;
            }

            if (e != null && e.Tag.ToString() != "In")
            {
                ArrayList patientList = new ArrayList();
                patientList.Add((Neusoft.HISFC.Models.RADT.PatientInfo)e.Tag);
                return this.SetValues(patientList, e);
            }

            return base.OnSetValue(neuObject, e);
        }

        #endregion

        protected override int OnSetValues(ArrayList alValues, object e)
        {
            this.myPatients = new List<Neusoft.HISFC.Models.RADT.PatientInfo>();
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo p in alValues)
            {
                myPatients.Add(p);
            }
            this.Retrieve();
            return 0;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
           // return this.Retrieve();
            return 0;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Print(object sender, object neuObject)
        {
            if (ip != null)
                ip.Print();
            return 0;
        }

        /// <summary>
        /// 设置打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int SetPrint(object sender, object neuObject)
        {
            if (ip != null)
                ip.PrintSet();
            return 0;
        }
         #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get {
                 Type[]  type = new Type[1];
                 type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.IPrintTransFusion);
                return type;
            }
        }

        #endregion

    }
}

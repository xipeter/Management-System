using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.WinForms.DrugStore
{
    /// <summary>
    /// Bed<br></br>
    /// [功能描述: 门诊配发药]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <修改记录
    ///	    为了测试控件使用 希望可以通过基类窗口弹出设置属性来代替窗口Tag 目前来看不行..
    ///  />
    /// </summary>
    public partial class ucOutpatientDrug : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucOutpatientDrug()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 操作的门诊终端类型
        /// </summary>
        private Neusoft.HISFC.Components.DrugStore.OutpatientFun funMode = Neusoft.HISFC.Components.DrugStore.OutpatientFun.Drug;

        /// <summary>
        /// 操作科室 本次登陆选择的科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject OperDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject OperInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 核准科室 扣库科室 
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject ApproveDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 门诊终端
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.DrugTerminal Terminal = new Neusoft.HISFC.Models.Pharmacy.DrugTerminal();

        /// <summary>
        /// 窗口功能
        /// </summary>
        private Neusoft.HISFC.Components.DrugStore.OutpatientWinFun winFun = Neusoft.HISFC.Components.DrugStore.OutpatientWinFun.配药;

        /// <summary>
        /// 是否其他药房配/发药
        /// </summary>
        private bool isOtherDrugDept = false;

        #endregion

        #region  属性

        /// <summary>
        /// 窗口功能
        /// </summary>
        public Neusoft.HISFC.Components.DrugStore.OutpatientWinFun WinFun
        {
            get
            {
                return this.winFun;
            }
            set
            {
                this.winFun = value;

                switch (value)
                {
                    case Neusoft.HISFC.Components.DrugStore.OutpatientWinFun.配药:
                        this.funMode = Neusoft.HISFC.Components.DrugStore.OutpatientFun.Drug;
                        this.isOtherDrugDept = false;
                        break;
                    case Neusoft.HISFC.Components.DrugStore.OutpatientWinFun.发药:
                        this.funMode = Neusoft.HISFC.Components.DrugStore.OutpatientFun.Send;
                        this.isOtherDrugDept = false;
                        break;
                    case Neusoft.HISFC.Components.DrugStore.OutpatientWinFun.直接发药:
                        this.funMode = Neusoft.HISFC.Components.DrugStore.OutpatientFun.DirectSend;
                        this.isOtherDrugDept = false;
                        break;
                    case Neusoft.HISFC.Components.DrugStore.OutpatientWinFun.还药:
                        this.funMode = Neusoft.HISFC.Components.DrugStore.OutpatientFun.Back;
                        this.isOtherDrugDept = false;
                        break;
                    case Neusoft.HISFC.Components.DrugStore.OutpatientWinFun.其他药房配药:
                        this.funMode = Neusoft.HISFC.Components.DrugStore.OutpatientFun.Drug;
                        this.isOtherDrugDept = true;
                        break;
                    case Neusoft.HISFC.Components.DrugStore.OutpatientWinFun.其他药房发药:
                        this.funMode = Neusoft.HISFC.Components.DrugStore.OutpatientFun.Send;
                        this.isOtherDrugDept = true;
                        break;
                }
            }
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Neusoft.FrameWork.Management.DataBaseManger dataBaseManager = new Neusoft.FrameWork.Management.DataBaseManger();

            if (this.isOtherDrugDept)
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager integrateManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                System.Collections.ArrayList al = integrateManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
                Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(al, ref info) == 0)
                    return;
                else
                    this.OperDept = info;
            }
            else
            {
                this.OperDept = ((Neusoft.HISFC.Models.Base.Employee)dataBaseManager.Operator).Dept;
            }

            this.OperInfo = dataBaseManager.Operator;
            this.ApproveDept = ((Neusoft.HISFC.Models.Base.Employee)dataBaseManager.Operator).Dept;

            if (this.InitTerminal() == -1)
                return;

            this.InitControlParm();
        }

        /// <summary>
        /// 终端初始化  暂时写死使用配药台
        /// </summary>
        protected int InitTerminal()
        {
            if (this.funMode == Neusoft.HISFC.Components.DrugStore.OutpatientFun.Drug)
                this.Terminal = Neusoft.HISFC.Components.DrugStore.Function.TerminalSelect(this.OperDept.ID, Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.配药台, true);
            else
                this.Terminal = Neusoft.HISFC.Components.DrugStore.Function.TerminalSelect(this.OperDept.ID, Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.发药窗口, true);
            if (this.Terminal == null)
                return -1;
            return 1;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected void InitControlParm()
        {
            this.ucClinicTree1.OperDept = this.OperDept;
            this.ucClinicTree1.OperInfo = this.OperInfo;
            this.ucClinicTree1.ApproveDept = this.OperDept;
            this.ucClinicTree1.SetFunMode(Neusoft.HISFC.Components.DrugStore.OutpatientFun.Drug);
            this.ucClinicTree1.SetTerminal(this.Terminal);

            this.ucClinicDrug1.OperDept = this.OperDept;
            this.ucClinicDrug1.OperInfo = this.OperInfo;
            this.ucClinicDrug1.ApproveDept = this.OperDept;
            this.ucClinicDrug1.SetFunMode(Neusoft.HISFC.Components.DrugStore.OutpatientFun.Drug);
            this.ucClinicDrug1.SetTerminal(this.Terminal);

            this.funMode = Neusoft.HISFC.Components.DrugStore.OutpatientFun.Drug;
        }

        #endregion

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            //this.statusBar1.Panels[1].Text = "正在保存...";

            base.OnStatusBarInfo(null, "正在保存...");

            this.ucClinicTree1.IsBusySave = true;

            this.ucClinicDrug1.Save();

            this.ucClinicTree1.IsBusySave = false;
        }

        /// <summary>
        /// 退出判断 是否允许关闭窗口
        /// </summary>
        /// <returns></returns>
        public bool EnableExit()
        {
            if (this.funMode == Neusoft.HISFC.Components.DrugStore.OutpatientFun.Drug)
            {
                if (this.ucClinicTree1.SpareNode())
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("尚有未配药确认的处方 请对所有处方完成配药 进行配药确认后再关闭窗口"));
                    return false;
                }
            }
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.OnLoad(e);
        }

        private void ucClinicTree1_MyTreeSelectEvent(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            this.ucClinicDrug1.ShowData(drugRecipe);
        }

        private void ucClinicDrug1_EndSave(object sender, EventArgs e)
        {
            this.ucClinicTree1.ChangeNodeLocation();
        }

        //private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    if (e.ClickedItem == this.tsbExit)          //退出
        //    {
        //        if (this.EnableExit())
        //            this.Close();
        //        return;
        //    }
        //    if (e.ClickedItem == this.tsbSave)          //保存
        //    {
        //        this.Save();
        //        return;
        //    }
        //    if (e.ClickedItem == this.tsbRefresh)       //刷新
        //    {
        //        this.ucClinicTree1.ShowList();
        //        return;
        //    }
        //    if (e.ClickedItem == this.tsbQuery)         //查询
        //    {
        //        this.ucClinicTree1.FindNode();
        //        return;
        //    }
        //    if (e.ClickedItem == this.tsbPrint)         //打印
        //    {
        //        this.ucClinicTree1.Print();
        //        return;
        //    }
        //    if (e.ClickedItem == this.tsbPause)         //暂停打印
        //    {
        //        Neusoft.FrameWork.WinForms.Classes.Print.PausePrintJob(0);
        //        return;
        //    }
        //    if (e.ClickedItem == this.tsbRefreshWay)    //手工刷新 / 自动刷新
        //    {
        //        if (this.tsbRefreshWay.Checked)         //手工刷新状态
        //        {
        //            this.ucClinicTree1.EndProcessRefresh();
        //            this.tsbRefreshWay.Text = "自动刷新";
        //        }
        //        else
        //        {
        //            this.ucClinicTree1.BeginProcessRefresh(1000);
        //            this.tsbRefreshWay.Text = "手动刷新";
        //        }
        //        return;
        //    }
        //    if (e.ClickedItem == this.tsbRecipe)        //处方
        //    {
        //        this.ucClinicDrug1.IsPrintRecipe = this.tsbRecipe.Checked;
        //        return;
        //    }
        //    if (e.ClickedItem == this.tsbDrugList)      //发药清单
        //    {
        //        this.ucClinicDrug1.IsPrintListing = this.tsbDrugList.Checked;
        //        return;

        //    }
        //}

        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("刷新", "刷新列表显示", 0, true, false, null);
            this.toolBarService.AddToolButton("暂停打印", "暂停当前打印机", 0, true, false, null);
            this.toolBarService.AddToolButton("手工刷新", "退出应用程序存在未配药处方时不允许退出", 0, true, false, null);
            this.toolBarService.AddToolButton("处方", "发药同时打印处方", 0, true, false, null);
            this.toolBarService.AddToolButton("发药清单", "发药同时打印发药清单", 0, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "刷新":
                    this.ucClinicTree1.ShowList();
                    break;
                case "暂停打印":
                    Neusoft.FrameWork.WinForms.Classes.Print.PausePrintJob(0);
                    break;
                case "处方":
                    //this.ucClinicDrug1.IsPrintRecipe = this.tsbRecipe.Checked;
                    break;
                case "发药清单":
                    //this.ucClinicDrug1.IsPrintListing = this.tsbDrugList.Checked;
                    break;
                case "手工刷新":
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.ucClinicTree1.FindNode();
            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.ucClinicTree1.Print();
            return 1;
        }

        private void ucClinicTree1_ProcessMessageEvent(object sender, string msg)
        {
            //this.statusBar1.Panels[1].Text = msg;

            base.OnStatusBarInfo(null, msg);
        }
    }
}

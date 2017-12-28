using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 特殊药品维护]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// <说明
    ///		
    ///  />
    /// </summary>
    public partial class ucSpeDrug : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSpeDrug()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 药品常数管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        /// <summary>
        /// 科室信息
        /// </summary>
        private ArrayList alDpet = new ArrayList();

        /// <summary>
        /// 人员信息
        /// </summary>
        private ArrayList alPerson = new ArrayList();

        #endregion

        #region 属性

        /// <summary>
        /// 当前活动SheetView
        /// </summary>
        protected FarPoint.Win.Spread.SheetView ActiveSv
        {
            get
            {
                return this.neuSpread1.ActiveSheet;
            }
        }

        #endregion

        #region 工具栏 

        protected override int OnSave(object sender, object neuObject)
        {
            return this.SaveDrugSpecial();
        }

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("删除", "删除明细信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
         
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删除")
            {
                this.DelDrugSpecial();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            //药品列表加载
            this.ucDrugList1.ShowInfoList("Pharmacy.Item.SpeDrug",new string[] { "SPELL_CODE", "WB_CODE", "TRADE_NAME", "CUSTOM_CODE" });

            this.ucDrugList1.SetFormat(new string[] { "编码", "商品名称", "规格", "拼音码", "五笔码", "自定义码" }, new int[] { 100, 120, 100, 60, 60, 60 }, new bool[] { false, true, true, false, false, false, false,false,false,false });
                                     

            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            this.alDpet = deptManager.GetDeptmentAll();
            if (this.alDpet == null)
            {
                MessageBox.Show(Language.Msg("科室列表加载失败") + deptManager.Err);
                return -1;
            }

            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            this.alPerson = personManager.GetEmployeeAll();
            if (this.alPerson == null)
            {
                MessageBox.Show(Language.Msg("人员列表加载失败") + personManager.Err);
                return -1;
            }

            this.SetItemListWidth(3);

            #region 屏蔽Fp回车/换行键

            FarPoint.Win.Spread.InputMap im;

            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Space, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            #endregion

            return 1;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置列表数据宽度 显示指定列
        /// </summary>
        /// <param name="showColumnCount">显示指定列个数 不计算隐藏列</param>
        public void SetItemListWidth(int showColumnCount)
        {
            int iWidth = this.splitContainer1.SplitterDistance;

            this.ucDrugList1.GetColumnWidth(showColumnCount, ref iWidth);

            this.splitContainer1.SplitterDistance = iWidth + 5;
        }

        /// <summary>
        /// 数据清空
        /// </summary>
        public void Clear(bool isClearAll)
        {
            if (isClearAll)
            {
                this.fpDeptSheet.Rows.Count = 0;
                this.fpDocSheet.Rows.Count = 0;
            }
            else
            {
                this.ActiveSv.Rows.Count = 0;
            }
        }

        /// <summary>
        /// 加载显示特限药品列表
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowDrugSpecialList()
        {
            Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType speType = Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType.Dept;
            if (this.ActiveSv == this.fpDeptSheet)
            {
                speType = Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType.Dept;
            }
            else
            {
                speType = Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType.Doc;
            }

            List<Neusoft.HISFC.Models.Pharmacy.DrugSpecial> drugSpeList = this.consManager.QueryDrugSpecialList(speType);

            if (drugSpeList == null)
            {
                MessageBox.Show(Language.Msg("加载特限药品列表发生错误") + this.consManager.Err);
                return -1;
            }

            this.Clear(false);
            foreach (Neusoft.HISFC.Models.Pharmacy.DrugSpecial drugSpe in drugSpeList)
            {
                this.AddItem(drugSpe);
            }

            return 1;
        }

        /// <summary>
        /// 特限药品信息显示
        /// </summary>
        /// <param name="drugSpe">特限药品信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int AddItem(Neusoft.HISFC.Models.Pharmacy.DrugSpecial drugSpe)
        {
            this.ActiveSv.Rows.Add(0, 1);

            this.ActiveSv.Cells[0, 0].Text = drugSpe.Item.Name;
            this.ActiveSv.Cells[0, 1].Text = drugSpe.Item.Specs;
            this.ActiveSv.Cells[0, 2].Text = drugSpe.SpeItem.Name;
            this.ActiveSv.Cells[0, 3].Text = drugSpe.Memo;
            this.ActiveSv.Cells[0, 1].Tag = null;

            this.ActiveSv.Rows[0].Tag = drugSpe;

            return 1;
        }

        /// <summary>
        /// 项目信息加入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddItem(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            int iIndex = this.ActiveSv.Rows.Count;
            this.ActiveSv.Rows.Add(iIndex, 1);

            Neusoft.HISFC.Models.Pharmacy.DrugSpecial drugSpe = new Neusoft.HISFC.Models.Pharmacy.DrugSpecial();
            if (this.ActiveSv == this.fpDeptSheet)
            {
                drugSpe.SpeType = Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType.Dept;
            }
            else
            {
                drugSpe.SpeType = Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType.Doc;
            }

            drugSpe.Item = item;

            this.ActiveSv.Cells[iIndex, 0].Text = item.Name;
            this.ActiveSv.Cells[iIndex, 1].Text = item.Specs;
            this.ActiveSv.Cells[iIndex, 0].Tag = "New";
            this.ActiveSv.Rows[iIndex].Tag = drugSpe;

            return 1;
        }

        /// <summary>
        /// 特限信息删除
        /// </summary>
        /// <returns></returns>
        public int DelDrugSpecial()
        {
            if (this.ActiveSv.Rows.Count <= 0)
            {
                return 1;
            }

            DialogResult rs = MessageBox.Show(Language.Msg("确认删除该条特限信息吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
            {
                return 0;
            }

            Neusoft.HISFC.Models.Pharmacy.DrugSpecial drugSpe = this.ActiveSv.Rows[this.ActiveSv.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.DrugSpecial;

            if (this.consManager.DelDrugSpecial(drugSpe) == -1)
            {
                MessageBox.Show(Language.Msg(string.Format("删除{0} - {1} 特限信息失败",drugSpe.Item.Name,drugSpe.SpeItem.Name)) + this.consManager.Err);
                return -1;
            }

            MessageBox.Show(Language.Msg("删除成功"));

            this.ActiveSv.Rows.Remove(this.ActiveSv.ActiveRowIndex, 1);

            return 1;
        }

        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <returns></returns>
        protected bool IsValid()
        {
            if (this.ActiveSv.Rows.Count <= 0)
            {
                return false;
            }

            for (int i = 0; i < this.ActiveSv.Rows.Count; i++)
            {
                if (this.ActiveSv.Cells[i, 2].Text == "")
                {
                    MessageBox.Show(Language.Msg("请设置" + this.ActiveSv.Cells[i,0].Text + " 特限项目信息"));
                    return false;
                }
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.ActiveSv.Cells[i, 3].Text, 20))
                { 
                    MessageBox.Show(Language.Msg(string.Format("{0} - {1} 特限信息中 备注信息过长 限制20个字符",this.ActiveSv.Cells[i,0].Text,this.ActiveSv.Cells[0,2].Text)));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 保存特限药品信息
        /// </summary>
        /// <returns></returns>
        public int SaveDrugSpecial()
        {
            if (!this.IsValid())
            {
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType speType = Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType.Dept;

            if (this.ActiveSv == this.fpDeptSheet)
            {
                speType = Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType.Dept;
            }
            else
            {
                speType = Neusoft.HISFC.Models.Pharmacy.EnumDrugSpecialType.Doc;
            }

            DateTime sysTime = this.consManager.GetDateTimeFromSysDateTime();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.consManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 先删除原特限信息

            if (this.consManager.DelDrugSpecial(speType) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("原特限药品信息删除失败") + this.consManager.Err);
                return -1;
            }

            #endregion

            #region 新特限信息保存

            for (int i = 0; i < this.ActiveSv.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugSpecial drugSpe = this.ActiveSv.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.DrugSpecial;

                drugSpe.Memo = this.ActiveSv.Cells[i, 3].Text;          //备注信息
                drugSpe.Oper.OperTime = sysTime;
                drugSpe.Oper.ID = this.consManager.Operator.ID;

                if (this.consManager.InsertDrugSpecial(drugSpe) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    if (this.consManager.DBErrCode == 1)
                    {
                        MessageBox.Show(Language.Msg(string.Format("{0} - {1} 特限信息重复 请删除一条", drugSpe.Item.Name, drugSpe.SpeItem.Name)));
                    }
                    else
                    {
                        MessageBox.Show(Language.Msg(string.Format("保存{0} - {1} 特限信息失败", drugSpe.Item.Name, drugSpe.SpeItem.Name)) + this.consManager.Err);
                    }
                    return -1;
                }
                this.ActiveSv.Cells[i, 0].Tag = null;
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            
            MessageBox.Show(Language.Msg("保存成功"));

            return 1;
        }

        /// <summary>
        /// 特限项目选择框
        /// </summary>
        /// <param name="iIndex"></param>
        /// <returns></returns>
        public void PopSpeItem(int iIndex)
        {
            ArrayList alData = new ArrayList();

            if (this.ActiveSv == this.fpDeptSheet)
            {
                alData = this.alDpet;
            }
            else
            {
                alData = this.alPerson;
            }

            string[] label = { "项目", "项目名称" };
            float[] width = { 80F, 100F };
            bool[] visible = { true, true };
            Neusoft.FrameWork.Models.NeuObject speObj = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alData, ref speObj) == 1)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugSpecial drugSpe = this.ActiveSv.Rows[iIndex].Tag as Neusoft.HISFC.Models.Pharmacy.DrugSpecial;

                drugSpe.SpeItem = speObj;

                this.ActiveSv.Cells[iIndex, 2].Text = speObj.Name;

                this.SetFocus(false);
            }
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        /// <param name="isFpFocus">是否设置Fp焦点</param>
        public void SetFocus(bool isFpFocus)
        {
            if (isFpFocus)
            {
                this.ActiveSv.ActiveRowIndex = this.ActiveSv.Rows.Count - 1;
                this.ActiveSv.ActiveColumnIndex = 2;

                this.neuSpread1.StartCellEditing(null, false);
            }
            else
            {
                this.ucDrugList1.SetFocusSelect();
            }

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.ShowDrugSpecialList();

                this.ucDrugList1.SetFocusSelect();
            }

            base.OnLoad(e);
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.ActiveSv.ActiveColumnIndex == 2)
            {
                this.PopSpeItem(e.Row);
            }
        }

        private void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string drugCode = sv.Cells[activeRow, 0].Text;

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            Neusoft.HISFC.Models.Pharmacy.Item item = itemManager.GetItem(drugCode);

            if (item == null)
            {
                MessageBox.Show(Language.Msg("获取药品信息失败") + itemManager.Err);
            }

            this.AddItem(item);

            this.SetFocus(true);
        }

        private void neuSpread1_ActiveSheetChanged(object sender, EventArgs e)
        {
            if (!isSucc)
            {
                this.neuSpread1.ActiveSheetChanging -= new FarPoint.Win.Spread.ActiveSheetChangingEventHandler(neuSpread1_ActiveSheetChanging);
                this.neuSpread1.ActiveSheetIndex = this.acctiveSheetIndex;
                this.neuSpread1.ActiveSheetChanging += new FarPoint.Win.Spread.ActiveSheetChangingEventHandler(neuSpread1_ActiveSheetChanging);
            }

            if (isSucc)
            {
                this.ShowDrugSpecialList();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.neuSpread1.ContainsFocus)
            {
                if (keyData == Keys.Space || keyData == Keys.Enter)
                {
                    if (this.ActiveSv.ActiveColumnIndex == 2)
                    {
                        this.PopSpeItem(this.ActiveSv.ActiveRowIndex);

                        return true;
                    }
                }
            }
            if (keyData == Keys.F8)            
            {
                ucDeptDrugListPriv uc = new ucDeptDrugListPriv();
                uc.Init();

                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc); 
            }
            return base.ProcessDialogKey(keyData);
        }

        bool isSucc = true;
        int acctiveSheetIndex = 0;
        
        private void neuSpread1_ActiveSheetChanging(object sender, FarPoint.Win.Spread.ActiveSheetChangingEventArgs e)
        {
            acctiveSheetIndex = this.neuSpread1.ActiveSheetIndex;

            int j = 0;
            for (int i = 0; i < this.ActiveSv.Rows.Count; i++)
            {
                string Flag = string.Empty;
                try
                {
                    Flag = this.ActiveSv.Cells[i, 0].Tag.ToString() ;
                }
                catch (Exception)
                {

                    Flag = null;
                }

                if (Flag != null)
                {
                    j++;
                }
               
            }

            if (j > 0)
            {
                DialogResult dr = MessageBox.Show("信息变动，是否保存", "提示", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    int returnvalue = this.SaveDrugSpecial();

                    if (returnvalue < 0)
                    {
                        isSucc = false;
                    }

                }
                else
                {
                    isSucc = true;
                }
            }
            else
            {
                isSucc = true;
            }
        }
    }
}

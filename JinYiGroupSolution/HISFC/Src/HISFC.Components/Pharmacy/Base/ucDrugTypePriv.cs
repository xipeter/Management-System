using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 药品类别控药权限]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-01]<br></br>
    /// </summary>
    public partial class ucDrugTypePriv : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDrugTypePriv()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 药品类别控制集合
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper itemTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 人员列表
        /// </summary>
        private System.Collections.ArrayList alPerson = new System.Collections.ArrayList();       

        /// <summary>
        /// 业务管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加","增加新控药权限信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("删除", "删除当前控药权限信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);            
           
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "增加")
            {
                this.NewPriv();
            }
            if (e.ClickedItem.Text == "删除")
            {
                this.DelConstantList();
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            System.Collections.ArrayList alTypelist = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            if (alTypelist == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载药品列表失败") + consManager.Err);
                return;
            }

            this.itemTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper(alTypelist);
            FarPoint.Win.Spread.CellType.ComboBoxCellType cmbCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            string[] strItemType = new string[alTypelist.Count];
            for (int i = 0; i < strItemType.Length; i++)
            {
                Neusoft.HISFC.Models.Base.Const tempCons = alTypelist[i] as Neusoft.HISFC.Models.Base.Const;
                strItemType[i] = "<" + tempCons.ID + ">" + tempCons.Name;
            }
            cmbCellType.Items = strItemType;
            this.neuSpread1_Sheet1.Columns[0].CellType = cmbCellType;

            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            this.alPerson = personManager.GetEmployeeAll();
            if (this.alPerson == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载人员列表失败") + personManager.Err);
                return;
            }

        }

        /// <summary>
        /// 清屏处理
        /// </summary>
        protected void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;            
        }

        /// <summary>
        /// 增加新控药权限分配
        /// </summary>
        protected void NewPriv()
        {
            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.Rows.Count, 1);

            this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.Rows.Count - 1, 0);
        }

        /// <summary>
        /// 常数信息加载
        /// </summary>
        /// <returns></returns>
        protected int ShowConstantList()
        {
            List<Neusoft.HISFC.Models.Pharmacy.DrugConstant> drugConstantList = phaConsManager.QueryDrugConstant(Function.DrugTypePriv_ConsType);
            if (drugConstantList == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载药品常数类别发生错误") + this.phaConsManager.Err);
                return -1;
            }

            this.Clear();
            this.neuSpread1_Sheet1.Rows.Count = drugConstantList.Count;
            int iRowIndex = 0;
            foreach (Neusoft.HISFC.Models.Pharmacy.DrugConstant info in drugConstantList)
            {
                this.neuSpread1_Sheet1.Cells[iRowIndex, 0].Text = "<" + info.DrugType + ">" + this.itemTypeHelper.GetName(info.DrugType);        //药品类别
                this.neuSpread1_Sheet1.Cells[iRowIndex, 1].Text = info.Item.ID;
                this.neuSpread1_Sheet1.Cells[iRowIndex, 2].Text = info.Item.Name;
                this.neuSpread1_Sheet1.Cells[iRowIndex, 3].Text = info.Memo;            //备注

                this.neuSpread1_Sheet1.Rows[iRowIndex].Tag = info;

                iRowIndex++;
            }

            return 1;
        }

        /// <summary>
        /// 删除药品常数信息
        /// </summary>
        /// <returns></returns>
        protected int DelConstantList()
        {
            if (this.neuSpread1_Sheet1.Rows.Count < 0)
            {
                return 1;
            }

            //删除增加提示 by Sunjh 2010-8-25 {375E3D5C-F4B3-43bf-9908-CEE1C78BC5F2}
            if (MessageBox.Show("确定删除本条记录吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return 1;
            }

            if (this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag != null)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugConstant info = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.DrugConstant;
                if (info != null)
                {
                    if (this.phaConsManager.DeleteDrugConstant(info) == -1)
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("删除药品常数信息失败"));
                        return -1;
                    }

                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("删除成功"));
                }
            }

            this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);

            return 1;
        }

        /// <summary>
        /// 由Fp内获取常数设置信息
        /// </summary>
        /// <param name="iRowIndex"></param>
        /// <returns></returns>
        protected Neusoft.HISFC.Models.Pharmacy.DrugConstant GetDrugConstant(int iRowIndex)
        {
            Neusoft.HISFC.Models.Pharmacy.DrugConstant info = new Neusoft.HISFC.Models.Pharmacy.DrugConstant();
            info.ConsType = Function.DrugTypePriv_ConsType;
            info.DrugType = this.neuSpread1_Sheet1.Cells[iRowIndex, 0].Text.Substring(1, 1);
            info.Dept.ID = "0";
            info.Item.ID = this.neuSpread1_Sheet1.Cells[iRowIndex, 1].Text;
            info.Item.Name = this.neuSpread1_Sheet1.Cells[iRowIndex, 2].Text;
            info.Memo = Neusoft.FrameWork.Public.String.TakeOffSpecialChar( this.neuSpread1_Sheet1.Cells[iRowIndex, 3].Text );
            
            return info;
        }

        protected override int OnSave(object sender, object neuObject)
        {

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(this.neuSpread1_Sheet1.Cells[i, 0].Text) == true)
                {
                    MessageBox.Show("请选择授权的药品类别", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
                if (string.IsNullOrEmpty(this.neuSpread1_Sheet1.Cells[i, 1].Text) == true)
                {
                    MessageBox.Show("请选择授权人员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.phaConsManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //根据常数类别删除原维护的信息
            if (this.phaConsManager.DeleteDrugConstant(Function.DrugTypePriv_ConsType) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("删除常数类别信息发生错误") + this.phaConsManager.Err);
                return -1;
            }
            DateTime sysTime = this.phaConsManager.GetDateTimeFromSysDateTime();

            Neusoft.HISFC.Models.Pharmacy.DrugConstant info = new Neusoft.HISFC.Models.Pharmacy.DrugConstant();
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                info = this.GetDrugConstant(i);
                if (info == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("由FarPoint内获取数据发生错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
                info.Oper.ID = this.phaConsManager.Operator.ID;
                info.Oper.OperTime = sysTime;
                if (info != null)
                {
                    if (this.phaConsManager.InsertDrugConstant(info) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("插入常数类别信息发生错误") + this.phaConsManager.Err);
                        return -1;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));

            return base.OnSave(sender, neuObject);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            return this.ShowConstantList();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.ShowConstantList();
            }

            base.OnLoad(e);
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column == 1)
            {
                Neusoft.FrameWork.Models.NeuObject person = new Neusoft.FrameWork.Models.NeuObject(); 
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alPerson, ref person) == 1)
                {
                    #region {75C20D74-9B76-474a-9069-15FF2EB438C3}
                    for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                    {
                        if (this.neuSpread1_Sheet1.Cells[i, 0].Text.Trim() == this.neuSpread1_Sheet1.Cells[e.Row, 0].Text.Trim())
                        {
                            if (this.neuSpread1_Sheet1.Cells[i, 1].Text.Trim() == person.ID)
                            {
                                MessageBox.Show("该人员已存在，请重新选择授权人员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.neuSpread1_Sheet1.ActiveRowIndex = i;
                                this.neuSpread1_Sheet1.ActiveColumnIndex = e.Column;
                                return;
                            }

                        }
                    } 
                    #endregion
                    this.neuSpread1_Sheet1.Cells[e.Row, e.Column].Text = person.ID;
                    this.neuSpread1_Sheet1.Cells[e.Row, 2].Text = person.Name;
                }
            }
        }
    }
}

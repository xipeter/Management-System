using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucPageSize : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPageSize()
        {
            InitializeComponent();
        }

        #region 定义工具栏

        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 初始化工具栏

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("添加", "添加", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null); 

            return toolBarService;
        }

        #endregion

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "添加":
                    this.Add();
                    break; 
                default:
                    break;
            }
        }

        private void frmPageSize_Load(object sender, System.EventArgs e)
        { 
            Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList al = dept.GetDeptmentAll();
            Neusoft.FrameWork.Models.NeuObject objAll = new Neusoft.FrameWork.Models.NeuObject();
            objAll.ID = "ALL";
            objAll.Name = "全部";
            al.Add(objAll);
            helper = new Neusoft.FrameWork.Public.ObjectHelper(al);
            FarPoint.Win.Spread.CellType.ComboBoxCellType c = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            string[] s = new string[al.Count + 1];
            int i = 0;
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                s[i] = obj.Name;
                i++;
            }
            s[i] = "ALL";
            c.Items = s;
            this.fpSpread1.Sheets[0].Columns[8].CellType = c;
            dept = null;
            this.Retrieve();
            //MessageBox.Show(manager.GetPageSize("operation1").Name);
        }
        private Neusoft.FrameWork.Public.ObjectHelper helper = null;
        private Neusoft.HISFC.BizLogic.Manager.PageSize manager = new Neusoft.HISFC.BizLogic.Manager.PageSize();

        #region IToolBar 成员
　　　
        /// <summary>
        /// 刷新查询
        /// </summary>
        /// <returns></returns>
        public int Retrieve()
        {
            // TODO:  添加 frmPageSize.Retrieve 实现
            ArrayList al = manager.GetList();
            try
            {
                this.fpSpread1.Sheets[0].RowCount = 0;
            }
            catch { }
            foreach (Neusoft.HISFC.Models.Base.PageSize obj in al)
            {
                this.fpSpread1.Sheets[0].Rows.Add(0, 1);
                this.fpSpread1.Sheets[0].Cells[0, 0].Text = obj.ID;
                this.fpSpread1.Sheets[0].Cells[0, 1].Text = obj.Printer;
                this.fpSpread1.Sheets[0].Cells[0, 2].Text = obj.Name;
                this.fpSpread1.Sheets[0].Cells[0, 3].Text = obj.Memo;
                this.fpSpread1.Sheets[0].Cells[0, 4].Value = obj.Width;
                this.fpSpread1.Sheets[0].Cells[0, 5].Value = obj.Height;
                this.fpSpread1.Sheets[0].Cells[0, 6].Value = obj.Top;
                this.fpSpread1.Sheets[0].Cells[0, 7].Value = obj.Left;
                this.fpSpread1.Sheets[0].Cells[0, 8].Text = helper.GetName(obj.Dept.ID);
            }
            al = null;
            return 0;
        }

        public int Add()
        {
            // TODO:  添加 frmPageSize.Add 实现
            this.fpSpread1.Sheets[0].Rows.Add(0, 1);
            return 0;
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return base.OnSave(sender, neuObject);
        }
　　
        public int Save()
        {
            if (this.IsValid() == false) return -1;
            // TODO:  添加 frmPageSize.Save 实现

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(manager.Connection);
            //t.BeginTransaction();

            manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            for (int i = 0; i < this.fpSpread1.Sheets[0].RowCount; i++)
            {
                Neusoft.HISFC.Models.Base.PageSize p = new Neusoft.HISFC.Models.Base.PageSize();
                try
                {
                    p.ID = this.fpSpread1.Sheets[0].Cells[i, 0].Text;
                    p.Printer = this.fpSpread1.Sheets[0].Cells[i, 1].Text;
                    p.Name = this.fpSpread1.Sheets[0].Cells[i, 2].Text;
                    p.Memo = this.fpSpread1.Sheets[0].Cells[i, 3].Text;
                    p.Width = int.Parse(this.fpSpread1.Sheets[0].Cells[i, 4].Text);
                    p.Height = int.Parse(this.fpSpread1.Sheets[0].Cells[i, 5].Text);
                    p.Top = int.Parse(this.fpSpread1.Sheets[0].Cells[i, 6].Text);
                    p.Left = int.Parse(this.fpSpread1.Sheets[0].Cells[i, 7].Text);
                    p.Dept.ID = helper.GetID(this.fpSpread1.Sheets[0].Cells[i, 8].Text);
                }
                catch
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.MessageBox("数据不合法，高度，宽度请维护正确数值！");
                    return -1;
                }
                if (manager.SetPageSize(p) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.MessageBox(manager.Err, manager.ErrCode, "错误");
                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //Neusoft.FrameWork.WinForms.Classes.Function.MessageBox("保存成功！");

            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));

            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected bool IsValid()
        {
            for (int i = 0; i < this.fpSpread1.Sheets[0].RowCount; i++)
            {
                if (this.fpSpread1.Sheets[0].Cells[i, 0].Text == null)
                {
                    this.fpSpread1.Sheets[0].SetActiveCell(i, 0, false);
                    MessageBox.Show("编码不能为空！");
                    return false;
                }
                if (this.fpSpread1.Sheets[0].Cells[i, 2].Text == null)
                {
                    this.fpSpread1.Sheets[0].SetActiveCell(i, 2, false);
                    MessageBox.Show("名称不能为空！");
                    return false;
                }
                if (this.fpSpread1.Sheets[0].Cells[i, 4].Text == null)
                {
                    this.fpSpread1.Sheets[0].SetActiveCell(i, 4, false);
                    MessageBox.Show("宽度不能为空！");
                    return false;
                }
                if (this.fpSpread1.Sheets[0].Cells[i, 5].Text == null)
                {
                    this.fpSpread1.Sheets[0].SetActiveCell(i, 5, false);
                    MessageBox.Show("高度不能为空！");
                    return false;
                }
            }
            return true;
        }　

        #endregion
    }
}

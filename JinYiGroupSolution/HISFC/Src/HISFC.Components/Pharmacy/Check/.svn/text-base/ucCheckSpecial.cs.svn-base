using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.FrameWork.Function;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Components.Pharmacy.Check
{
    /// <summary>
    /// ucCheckSpecial<br></br>
    /// <Font color='#FF1111'>[功能描述: 特殊盘点药品维护{98F0BF7A-5F41-4de3-884F-B38E71B41A8C}]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-08-05]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucCheckSpecial : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        #region 构造函数
        public ucCheckSpecial()
        {
            InitializeComponent();
        }
        #endregion

        #region 私有变量

        /// <summary>
        /// 整合的管理业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager interManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 常数管理类－取常数列表
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 药品业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        /// <summary>
        /// 用户权限科室列表
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> privDeptList = null;

        /// <summary>
        /// 操作员
        /// </summary>
        private string operCode = "";

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dtBatch = null;

        #endregion

        #region 工具栏


        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("删    除", "删除当前选择数据", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删    除")
            {
                this.DeleteData();
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化科室树
        /// </summary>
        private void InitDeptTree()
        {
            this.tvDept.Nodes.Clear();
            this.tvDept.ImageList = this.tvDept.deptImageList;
            foreach (Neusoft.FrameWork.Models.NeuObject dept in this.privDeptList)
            {
                TreeNode newNode = new TreeNode();
                this.tvDept.Nodes.Add(newNode);
                newNode.Text = dept.Name;
                newNode.Tag = dept;
                newNode.ImageIndex = 0;
                newNode.SelectedImageIndex = 1;
            }
        }

        /// <summary>
        /// 初始化数据表
        /// </summary>
        private void InitDataTable()
        {
            this.dtBatch = new DataTable();
            this.dtBatch.Columns.AddRange(new DataColumn[] {
                new DataColumn("科室编码",typeof(string)),
                new DataColumn("药品性质编码",typeof(string)),
                new DataColumn("药品性质",typeof(string)),
                new DataColumn("盘点方式编码",typeof(string)),
                new DataColumn("盘点方式",typeof(string)),
                new DataColumn("备注",typeof(string))
            });
            this.neuFpEnter1_Sheet1.DataSource = this.dtBatch;
            this.neuFpEnter1.EditModePermanent = false;
            this.neuFpEnter1_Sheet1.Columns[0].Visible = false;
            this.neuFpEnter1_Sheet1.Columns[1].Visible = false;
            this.neuFpEnter1_Sheet1.Columns[3].Visible = false;
            this.neuFpEnter1_Sheet1.DefaultStyle.Locked = true;
            this.neuFpEnter1_Sheet1.Columns[2].Locked = false;
            this.neuFpEnter1_Sheet1.Columns[5].Locked = false;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="deptCode"></param>
        private void QueryData(string deptCode)
        {
            List<CheckSpecial> specialList = this.itemManager.QueryCheckSpecial(deptCode);
            if (specialList == null)
            {
                MessageBox.Show("查询特殊盘点记录错误：" + this.itemManager.Err);
                return;
            }
            this.dtBatch.Clear();
            foreach (CheckSpecial checkSp in specialList)
            {
                DataRow dr = this.dtBatch.NewRow();
                this.dtBatch.Rows.Add(dr);
                dr["科室编码"] = checkSp.Storage.ID;
                dr["药品性质编码"] = checkSp.DrugQuality.ID;
                dr["药品性质"] = checkSp.DrugQuality.Name;
                dr["盘点方式编码"] = checkSp.CheckType;
                dr["盘点方式"] = ((CheckTypeEnum)NConvert.ToInt32(checkSp.CheckType)).ToString();
                dr["备注"] = checkSp.Memo;
            }
            this.AddNewRow();
            this.dtBatch.AcceptChanges();
        }

        /// <summary>
        /// 初始化farpoint下拉列表
        /// </summary>
        private void InitFpList()
        {
            ArrayList alQuality = this.consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);
            this.neuFpEnter1.SetColumnList(this.neuFpEnter1_Sheet1, 2, alQuality);

            FarPoint.Win.Spread.InputMap im;
            im = this.neuFpEnter1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        /// <summary>
        /// 增加新行
        /// </summary>
        private void AddNewRow()
        {
            if (this.tvDept.SelectedNode == null)
            {
                return;
            }
            DataRow drNew = this.dtBatch.NewRow();
            this.dtBatch.Rows.Add(drNew);
            drNew["科室编码"] = (this.tvDept.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject).ID;
            drNew["盘点方式编码"] = ((int)(CheckTypeEnum.按批次盘点)).ToString();
            drNew["盘点方式"] = CheckTypeEnum.按批次盘点.ToString();
        }

        /// <summary>
        /// 校验变化
        /// </summary>
        /// <returns></returns>
        private bool CheckChange()
        {
            if (this.dtBatch == null)
            {
                return true;
            }
            DataTable dtChange = this.dtBatch.GetChanges(DataRowState.Unchanged);
            if (dtChange != null && dtChange.Rows.Count != this.dtBatch.Rows.Count)
            {
                if (MessageBox.Show("数据已经修改，是否继续？继续将丢失所作修改", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        private void DeleteData()
        {
            if (this.neuFpEnter1_Sheet1.Rows.Count == 0)
            {
                return;
            }
            this.neuFpEnter1.StopCellEditing();
            this.neuFpEnter1_Sheet1.Rows.Remove(this.neuFpEnter1_Sheet1.ActiveRowIndex, 1);
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void SaveData()
        {
            if (this.tvDept.SelectedNode == null)
            {
                return;
            }
            this.neuFpEnter1.StopCellEditing();
            foreach (DataRow dr in this.dtBatch.Rows)
            {
                dr.EndEdit();
            }
            this.dtBatch.AcceptChanges();
            List<CheckSpecial> specList = this.GetListFromDataTable();
            string operDept = (this.tvDept.SelectedNode.Tag as NeuObject).ID;
            FrameWork.Management.PublicTrans.BeginTransaction();
            this.itemManager.SetTrans(FrameWork.Management.PublicTrans.Trans);
            if (this.itemManager.SetCheckSpecial(operDept, specList) < 0)
            {
                FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存失败:" + this.itemManager.Err);
                return;
            }
            FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功");
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        private List<CheckSpecial> GetListFromDataTable()
        {
            List<CheckSpecial> specList = new List<CheckSpecial>();
            foreach (DataRow dr in this.dtBatch.Rows)
            {
                if (string.IsNullOrEmpty(dr["药品性质编码"].ToString()))
                {
                    continue;
                }
                CheckSpecial checkSpecial = new CheckSpecial();
                checkSpecial.Storage.ID = dr["科室编码"].ToString();
                checkSpecial.DrugQuality.ID = dr["药品性质编码"].ToString();
                checkSpecial.DrugQuality.Name = dr["药品性质"].ToString();
                checkSpecial.CheckType = dr["盘点方式编码"].ToString();
                checkSpecial.Memo = dr["备注"].ToString();
                checkSpecial.Oper.ID = this.operCode;
                specList.Add(checkSpecial);
            }
            return specList;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCheckSpecial_Load(object sender, EventArgs e)
        {
            this.InitDataTable();
            this.InitDeptTree();
            this.InitFpList();
        }

        /// <summary>
        /// 选中记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int neuFpEnter1_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
        {
            for (int i = 0; i < this.neuFpEnter1_Sheet1.Rows.Count; i++)
            {
                if (this.neuFpEnter1_Sheet1.Cells[i, 1].Text == obj.ID)
                {
                    MessageBox.Show("该药品性质已经添加");
                    return -1;
                }
            }
            int index = this.neuFpEnter1_Sheet1.ActiveRowIndex;
            if (string.IsNullOrEmpty(this.neuFpEnter1_Sheet1.Cells[index, 1].Text.Trim()))
            {
                this.AddNewRow();
            }
            this.neuFpEnter1_Sheet1.Cells[index, 1].Text = obj.ID;
            this.neuFpEnter1_Sheet1.Cells[index, 2].Text = obj.Name;

            return 1;
        }

        /// <summary>
        /// 选中节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string deptCode = (e.Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID;
            this.QueryData(deptCode);
        }

        /// <summary>
        /// 选中前处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDept_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (!this.CheckChange())
            {
                e.Cancel = true;
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveData();
            return 1;
        }

        private int neuFpEnter1_KeyEnter(Keys key)
        {
            if (key != Keys.Enter)
            {
                return 1;
            }
            if (this.neuFpEnter1_Sheet1.ActiveColumnIndex == 2)
            {
                Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.neuFpEnter1.getCurrentList(this.neuFpEnter1_Sheet1, 2);
                Neusoft.FrameWork.Models.NeuObject obj = listBox.GetSelectedItem() as Neusoft.FrameWork.Models.NeuObject;
                this.neuFpEnter1_SetItem(obj);
                listBox.Visible = false;
            }
            return 1;
        }

        #endregion

        #region 接口实现

        #region IPreArrange 成员

        public int PreArrange()
        {
            this.operCode = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID;
            //加载基础信息维护权限科室-0301
            this.privDeptList = this.interManager.QueryUserPriv(this.operCode, "0301");
            if (this.privDeptList == null)
            {
                MessageBox.Show("查询用户权限出错：" + this.interManager.Err);
                return -1;
            }
            if (this.privDeptList.Count == 0)
            {
                MessageBox.Show("您没有药品基础信息维护的权限");
                return -1;
            }
            return 1;
        }

        #endregion

        #endregion

        #region 枚举

        /// <summary>
        /// 盘点方式枚举
        /// </summary>
        private enum CheckTypeEnum
        {
            正常盘点 = 1,
            按批次盘点 = 2
        }

        #endregion

    }
}

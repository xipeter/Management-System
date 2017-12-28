using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    /// <summary>
    /// [功能描述: 入出库科室维护]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// 
    /// <说明>
    ///     1 科室编码存储在实体ID字段内 入出库科室编码存储Dept字段内
    /// </说明>
    /// </summary>
    public partial class ucInOutDept : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucInOutDept()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 科室类型帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptTypeHelper = null;

        /// <summary>
        /// 待选择科室
        /// </summary>
        private ArrayList alChooseDept = null;

        /// <summary>
        /// 模块功能类型
        /// </summary>
        private Neusoft.HISFC.Models.IMA.EnumModuelType moduelType = Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy;

        /// <summary>
        /// 大类统计编码
        /// </summary>
        private string statCode = "03";

        /// <summary>
        /// 标志入库出库 10 入库 20 出库
        /// </summary>
        private string inOutFlag = "10";

        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.PrivInOutDept privInOutManager = new Neusoft.HISFC.BizLogic.Manager.PrivInOutDept();

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        #endregion

        #region 属性

        /// <summary>
        /// 模块功能类型
        /// </summary>
        public Neusoft.HISFC.Models.IMA.EnumModuelType ModuelType
        {
            get
            {
                return this.moduelType;
            }
            set
            {
                this.moduelType = value;

                switch (value)
                {
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy:
                        this.statCode = "03";
                        break;
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Material:
                        this.statCode = "05";
                        break;
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Equipment:
                        this.statCode = "06";
                        break;
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Blood:
                        this.statCode = "04";
                        break;
                }
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {          
            toolBarService.AddToolButton("增加科室", "增加入出库科室", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolBarService.AddToolButton("删除", "删除入出库科室", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删除")
            {
                this.DelInOutDept();
            }
            if (e.ClickedItem.Text == "增加科室")
            {
                this.AddInOutDept();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveInOut();

            return 1;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void Init()
        {            
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deptStatManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
            this.alChooseDept = deptStatManager.LoadChildrenUnionDept(this.statCode, "AAAA");
            if (this.alChooseDept == null)
            {
                MessageBox.Show(Language.Msg("取科室列表错误:" + deptStatManager.Err));
                return;
            }

            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            this.deptTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
            this.deptTypeHelper.ArrayObject = this.alChooseDept;
            //{CFC740A1-77C6-4722-A6BF-DCDC94171838} by nxy
            this.SetColumnFormat();

        }

        /// <summary>
        /// 清空
        /// </summary>
        protected void Clear()
        {
            this.fpInSheet.Rows.Count = 0;
            this.fpOutSheet.Rows.Count = 0;
        }

        /// <summary>
        /// 向Fp内加入实体
        /// </summary>
        /// <param name="sv">需加入数据的SheetView</param>
        /// <param name="iRowIndex">行索引</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddDataToFp(FarPoint.Win.Spread.SheetView sv, int iRowIndex,Neusoft.HISFC.Models.Base.PrivInOutDept info)
        {
            sv.Rows.Add(iRowIndex, 1);

            sv.Cells[iRowIndex, (int)ColumnSet.ColSortID].Text = info.SortID.ToString();    //排序
            sv.Cells[iRowIndex, (int)ColumnSet.ColDeptID].Text = info.Dept.ID;              //部门编码
            sv.Cells[iRowIndex, (int)ColumnSet.ColDeptName].Text = info.Dept.Name;
            if (this.deptTypeHelper.GetObjectFromID(info.Dept.ID) != null)
            {
                sv.Cells[iRowIndex, (int)ColumnSet.ColeDeptType].Text = this.deptTypeHelper.GetObjectFromID(info.Dept.ID).User02;
            }
            sv.Cells[iRowIndex, (int)ColumnSet.ColMemo].Text = info.Memo;                   //备注
            sv.Rows[iRowIndex].Tag = info;

            return 1;
        }

        /// <summary>
        /// 增加新科室
        /// </summary>
        /// <param name="sv">需加入数据的SheetView</param>
        /// <param name="iRowIndex">行索引</param>
        /// <param name="dept">科室编码</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddDataToFp(FarPoint.Win.Spread.SheetView sv, int iRowIndex, Neusoft.HISFC.Models.Base.Department dept)
        {
            Neusoft.HISFC.Models.Base.PrivInOutDept privObj = new Neusoft.HISFC.Models.Base.PrivInOutDept();

            privObj.ID = this.privDept.ID;
            privObj.Name = this.privDept.Name;
            privObj.Role.Grade2.ID = this.statCode + this.inOutFlag;
            privObj.Dept = dept;

            sv.Rows.Add(iRowIndex, 1);

            sv.Cells[iRowIndex, (int)ColumnSet.ColSortID].Value = 0;			        //排序
            sv.Cells[iRowIndex, (int)ColumnSet.ColDeptID].Value = dept.ID;		        //部门编码
            sv.Cells[iRowIndex, (int)ColumnSet.ColDeptName].Value = dept.Name;		    //部门名称
            if (dept.DeptType != null)
            {
                sv.Cells[iRowIndex, (int)ColumnSet.ColeDeptType].Value = dept.DeptType.Name;	//部门类型
            }

            sv.Rows[iRowIndex].Tag = privObj;

            return 1;
        }     

        /// <summary>
        /// 入出库科室显示
        /// </summary>
        /// <returns></returns>
        protected int ShowInOutDept()
        {
            if (this.neuTabControl1.SelectedTab == this.tpInDept)
            {
                return this.ShowInOutDept(this.fpInSheet, this.statCode + this.inOutFlag);
            }
            else
            {
                return this.ShowInOutDept(this.fpOutSheet, this.statCode + this.inOutFlag);
            }            
        }

        /// <summary>
        /// 加载显示入出库科室
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="privType"></param>
        /// <returns></returns>
        private int ShowInOutDept(FarPoint.Win.Spread.SheetView sv, string privType)
        {
            sv.Rows.Count = 0;
            ArrayList alPrivInOut = this.privInOutManager.GetPrivInOutDeptList(this.privDept.ID, privType);
            if (alPrivInOut == null)
            {
                MessageBox.Show(Language.Msg("获取" + this.privDept.Name + "  " +privType + "权限失败 " + this.privInOutManager.Err));
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Base.PrivInOutDept info in alPrivInOut)
            {
                this.AddDataToFp(sv, 0,info);
            }

            return 1;
        }

        /// <summary>
        /// 增加入出库科室
        /// </summary>
        /// <returns></returns>
        protected int AddInOutDept()
        {
            //根节点科室 不能添加
            Neusoft.FrameWork.Models.NeuObject temp = this.tv.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
            if (temp == null)
            {
                return 1;
            }

            if (temp.ID.Substring(0, 1) == "S")
            {
                return 1;
            }

            if (this.privDept.ID.Substring(0, 1) == "S")
            {
                return 1;
            }

            if (this.neuTabControl1.SelectedTab == this.tpInDept)
            {
                return this.AddInOutDept(this.fpInSheet);
            }
            else
            {
                return this.AddInOutDept(this.fpOutSheet);
            }
        }

        /// <summary>
        /// 增加入出库科室
        /// </summary>
        /// <param name="sv">需添加的SheetView</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int AddInOutDept(FarPoint.Win.Spread.SheetView sv)
        {
            //弹出窗口,让用户选择要添加的科室
            List<Neusoft.HISFC.Models.Base.Department> alList = Neusoft.HISFC.Components.Common.Classes.Function.ChooseMultiDept();
            if (alList == null || alList.Count == 0)
            {
                return -1;
            }

            System.Collections.Hashtable hsExits = new Hashtable();
            for (int i = 0; i < sv.Rows.Count; i++)
            {
                hsExits.Add(sv.Cells[i, (int)ColumnSet.ColDeptID].Text,null);
            }

            foreach (Neusoft.HISFC.Models.Base.Department obj in alList)
            {
                if (hsExits.ContainsKey(obj.ID))
                {
                    continue;
                }

                this.AddDataToFp(sv, sv.Rows.Count, obj);
            }

            return 1;
        }

        /// <summary>
        /// 入出库科室删除
        /// </summary>
        /// <returns></returns>
        protected int DelInOutDept()
        {
            if (this.neuTabControl1.SelectedTab == this.tpInDept)
            {
                return this.DelInOutDept(this.fpInSheet);
            }
            else
            {
                return this.DelInOutDept(this.fpOutSheet);
            }
        }

        /// <summary>
        /// 入出库科室数据删除当前行
        /// </summary>
        /// <param name="sv"></param>
        /// <returns></returns>
        protected int DelInOutDept(FarPoint.Win.Spread.SheetView sv)
        {
            if (sv.Rows.Count <= 0)
            {
                return 1;
            }

            string deptName = sv.Cells[sv.ActiveRowIndex, (int)ColumnSet.ColDeptName].Text;
            if (MessageBox.Show(Language.Msg("确定要把科室“" + deptName + "”删除吗？"), "确认科室删除", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return 1;
            }

            string deptCode = sv.Cells[sv.ActiveRowIndex, (int)ColumnSet.ColDeptID].Text;
            //在数据库中删除此记录
            if (this.privInOutManager.DeletePrivInOutDept(this.statCode + this.inOutFlag, this.privDept.ID, deptCode) == -1)
            {
                MessageBox.Show(this.privInOutManager.Err);
                return -1;
            }

            //在控件中删除此记录
            sv.ActiveRow.Remove();

            MessageBox.Show(Language.Msg("删除成功"));

            return 1;
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns></returns>
        private bool IsValid(FarPoint.Win.Spread.SheetView sv)
        {
            for (int i = 0; i < sv.Rows.Count; i++)
            {
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(sv.Cells[i, (int)ColumnSet.ColMemo].Text, 128))
                {
                    MessageBox.Show(Language.Msg("备注字段超长 请适当简略"));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int SaveInOut()
        {
            if (this.neuTabControl1.SelectedTab == this.tpInDept)
            {
                return this.SaveInOut(this.fpInSheet);
            }
            else
            {
                return this.SaveInOut(this.fpOutSheet);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sv">保存行</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int SaveInOut(FarPoint.Win.Spread.SheetView sv)
        {
            if (!this.IsValid(sv))
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.privInOutManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.privInOutManager.DeletePrivInOutDeptAll(this.statCode + this.inOutFlag, this.privDept.ID) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show(Language.Msg("数据删除失败" + this.privInOutManager.Err));
                return -1;
            }

            for (int i = 0; i < sv.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Base.PrivInOutDept privInOut = sv.Rows[i].Tag as Neusoft.HISFC.Models.Base.PrivInOutDept;

                privInOut.SortID = NConvert.ToInt32(sv.Cells[i, (int)ColumnSet.ColSortID].Text);
                privInOut.Memo = sv.Cells[i, (int)ColumnSet.ColMemo].Text;

                if (this.privInOutManager.InsertPrivInOutDept(privInOut) != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Language.Msg("插入数据失败" + this.privInOutManager.Err));
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();;
            MessageBox.Show(Language.Msg("保存成功"));

            this.ShowInOutDept();

            return 1;
        }

        #endregion

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuTabControl1.SelectedTab == this.tpInDept)
            {
                this.inOutFlag = "10";
            }
            else
            {
                this.inOutFlag = "20";
            }

            this.ShowInOutDept();
        }

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.Clear();

            if (e.Parent == null || e.Tag == null)
            {
                return -1;
            }

            Neusoft.FrameWork.Models.NeuObject temp = e.Tag as Neusoft.FrameWork.Models.NeuObject;
            if (temp == null)
            {
                return -1;
            }

            if (temp.ID.Substring(0, 1) == "S")
            {
                return -1;
            }

            this.privDept = temp;

            this.ShowInOutDept();

            return base.OnSetValue(neuObject, e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType markNumCell = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
                markNumCell.DecimalPlaces = 0;
                this.fpInSheet.Columns[(int)ColumnSet.ColSortID].CellType = markNumCell;
                this.fpOutSheet.Columns[(int)ColumnSet.ColSortID].CellType = markNumCell;

                tvDepartmentLevelTree tvLevel = this.tv as tvDepartmentLevelTree;

                if (tvLevel != null)
                {
                    tvLevel.HideSelection = false;

                    tvLevel.BeforeLoad(this.statCode);

                    tvLevel.ExpandAll();
                }
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// 设置显示格式 {CFC740A1-77C6-4722-A6BF-DCDC94171838} by nxy
        /// </summary>
        private void SetColumnFormat()
        {
            FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();

            this.fpInSheet.Columns[(int)ColumnSet.ColDeptID].CellType = textType;

            this.fpOutSheet.Columns[(int)ColumnSet.ColDeptID].CellType = textType;
        }
        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            ColSortID,
            ColDeptName,
            ColeDeptType,
            ColMemo,
            ColDeptID
        }      
    }
}

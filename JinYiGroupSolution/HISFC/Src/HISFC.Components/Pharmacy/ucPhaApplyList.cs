using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品申请单据列表显示]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// 
    /// {C77D4120-D4BF-4770-8B8F-973F52EB5056}
    /// </summary>
    public partial class ucPhaApplyList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPhaApplyList()
        {
            InitializeComponent();
        }

        #region 委托

        /// <summary>
        /// 双击委托
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public delegate int DoubleClickDelegate(object doubleClickRowTag);

        /// <summary>
        /// 委托方法实例
        /// </summary>
        private DoubleClickDelegate doubleClickInstanceMethod = null;

        /// <summary>
        /// 委托方法实例
        /// </summary>
        public DoubleClickDelegate DoubleClickInstanceMethod
        {
            set
            {
                this.doubleClickInstanceMethod = value;
            }
        }

        #endregion

        #region 域成员变量

        /// <summary>
        /// 科室帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 申请信息集合
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> applyListCollection = new List<Neusoft.FrameWork.Models.NeuObject>();

        /// <summary>
        /// 操作结果
        /// </summary>
        private DialogResult rs = DialogResult.Cancel;
        #endregion

        #region 属性

        /// <summary>
        /// 所选择的申请单据信息集合
        /// </summary>
        public List<Neusoft.FrameWork.Models.NeuObject> ApplyListCollection
        {
            get
            {
                return this.applyListCollection;
            }
        }

        /// <summary>
        /// 操作结果
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.rs;
            }
            set
            {
                this.rs = value;
            }
        }

        /// <summary>
        /// 设置List Sheet 页显示名称
        /// </summary>
        public string DisplaySheetName
        {
            set
            {
                this.fsApplyData_List.SheetName = value;
            }
        }

        /// <summary>
        /// 设置界面提示信息
        /// </summary>
        public string DisplayNotice
        {
            set
            {
                this.lbNotice.Text = value;
            }
        }

        /// <summary>
        /// 明细信息显示 Sheet 页
        /// </summary>
        public FarPoint.Win.Spread.SheetView DetailSheet
        {
            get
            {
                return this.fsApplyData_Detail;
            }
        }

        /// <summary>
        /// 是否显示作废按钮
        /// </summary>
        public bool IsShowCancelButton
        {
            set
            {
                this.btnCancel.Visible = value;
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public int Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList alDept = deptManager.GetDeptmentAll();
            if (alDept != null)
            {
                this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);
            }

            return 1;
        }

        /// <summary>
        /// 数据清空
        /// </summary>
        protected void Clear()
        {
            this.fsApplyData_List.Rows.Count = 0;
            this.fsApplyData_Detail.Rows.Count = 0;
        }

        /// <summary>
        /// 申请信息数据加载
        /// </summary>
        /// <param name="alApplyList">科室申请信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        internal int ShowData(ArrayList alApplyList)
        {
            this.Clear();

            int iRowIndex = 0;
            foreach (Neusoft.FrameWork.Models.NeuObject info in alApplyList)
            {
                this.fsApplyData_List.Rows.Add(iRowIndex, 1);
                this.fsApplyData_List.Cells[iRowIndex, 0].Value = false;
                this.fsApplyData_List.Cells[iRowIndex, 1].Text = info.ID;       //单据号
                this.fsApplyData_List.Cells[iRowIndex, 2].Text = info.Name;     //目标单位名称                

                this.fsApplyData_List.Rows[iRowIndex].Tag = info;
            }
            return 1;
        }

        /// <summary>
        /// 申请列表信息检索
        /// </summary>
        /// <returns></returns>
        public int QueryApplyListByTarget(Neusoft.FrameWork.Models.NeuObject stockDept,string class3MeaningCode,string applyState)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            ArrayList alList = itemManager.QueryApplyOutListByTargetDept(stockDept.ID, class3MeaningCode, applyState);
            if (alList == null)
            {
                MessageBox.Show("加载药品申请信息列表发生错误！" + itemManager.Err);
                return -1;
            }

            foreach (Neusoft.FrameWork.Models.NeuObject info in alList)
            {
                info.User03 = stockDept.ID;
            }

            this.ShowData(alList);

            return 1;
        }

        /// <summary>
        /// 申请列表信息检索
        /// </summary>
        /// <returns></returns>
        public int QueryApplyListByApply(Neusoft.FrameWork.Models.NeuObject applyDept, string class3MeaningCode, string applyState)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            ArrayList alList = itemManager.QueryApplyOutList(applyDept.ID, class3MeaningCode, applyState);
            if (alList == null)
            {
                MessageBox.Show("加载药品申请信息列表发生错误！" + itemManager.Err);
                return -1;
            }

            foreach (Neusoft.FrameWork.Models.NeuObject info in alList)
            {
                info.User03 = info.Memo;        //库存单位编码
            }

            this.ShowData(alList);

            return 1;
        }

        /// <summary>
        /// 申请明细信息加载
        /// </summary>
        /// <returns></returns>
        protected int QueryApplyDetail(int rowIndex)
        {
            Neusoft.FrameWork.Models.NeuObject info = this.fsApplyData_List.Rows[rowIndex].Tag as Neusoft.FrameWork.Models.NeuObject;
            string listNO = this.fsApplyData_List.Cells[rowIndex, 1].Text;

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            ArrayList alDetail = itemManager.QueryApplyOutInfoByListCode(info.Memo, listNO, "0");
            if (alDetail == null)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("未正确获取内部入库申请信息" + itemManager.Err));
                return -1;
            }

            this.fsApplyData_Detail.Rows.Count = 0;
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alDetail)
            {
                this.fsApplyData_Detail.Rows.Add(0, 1);
                this.fsApplyData_Detail.Cells[0, 0].Text = applyOut.Item.Name;
                this.fsApplyData_Detail.Cells[0, 1].Text = applyOut.Item.Specs;
                this.fsApplyData_Detail.Cells[0, 2].Text = applyOut.Operation.ApplyQty.ToString();
                this.fsApplyData_Detail.Cells[0, 3].Text = applyOut.Operation.ApproveQty.ToString();
                this.fsApplyData_Detail.Cells[0,4].Text = applyOut.Item.MinUnit;
            }

            return 1;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        protected void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.applyListCollection.Clear();

            for (int i = 0; i < this.fsApplyData_List.Rows.Count; i++)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fsApplyData_List.Cells[i, 0].Value))
                {
                    this.applyListCollection.Add(this.fsApplyData_List.Rows[i].Tag as Neusoft.FrameWork.Models.NeuObject);
                }
            }

            this.rs = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.rs = DialogResult.Cancel;

            this.Close();
        }

        private void fsApplyData_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.doubleClickInstanceMethod != null)
            {
                this.doubleClickInstanceMethod( this.fsApplyData_List.Rows[this.fsApplyData_List.ActiveRowIndex].Tag );
            }
            else
            {
                this.QueryApplyDetail( this.fsApplyData_List.ActiveRowIndex );
            }

            this.fsApplyData.ActiveSheet = this.fsApplyData_Detail;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Models;
namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class ucCheckInvoice : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCheckInvoice()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 发票业务层
        /// </summary>
        //{6A6FDD3F-ACBB-4ff7-80BC-6AD0FF69360E}
        //protected Neusoft.HISFC.BizLogic.Fee.InvoiceService invoiceServiceManager = new Neusoft.HISFC.BizLogic.Fee.InvoiceService();
        protected Neusoft.HISFC.BizLogic.Fee.InvoiceServiceNoEnum invoiceServiceManager = new Neusoft.HISFC.BizLogic.Fee.InvoiceServiceNoEnum();
        /// <summary>
        /// 工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 发票类型
        /// </summary>
        /// 
        //{6A6FDD3F-ACBB-4ff7-80BC-6AD0FF69360E}
        //Neusoft.HISFC.Models.Fee.EnumInvoiceType enumType ;
        private string enumType = string.Empty;
        /// <summary>
        /// 开始时间
        /// </summary>
        private string begin = string.Empty;
        /// <summary>
        /// 结束时间
        /// </summary>
        private string end = string.Empty;
        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerInteger = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 收款员ID
        /// </summary>
        string casher = string.Empty;
        #endregion

        #region 工具栏
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("全选", "将全部数据设置为选中状态", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, null);
            this.toolBarService.AddToolButton("取消", "将全部数据设置为未选中状态", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "全选":
                    {
                        IsSelectAll(true);
                        break;
                    }
                case "取消":
                    {
                        IsSelectAll(false);
                        break;
                    }
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            return base.OnSave(sender, neuObject);
        }

        #endregion

        #region 方法
        /// <summary>
        /// 是否将Farpoint数据设置为选种状态
        /// </summary>
        /// <param name="bl">true :选中 false:未选中</param>
        protected virtual void IsSelectAll(bool bl)
        {
            int count = this.neuSpread1_Sheet1.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    this.neuSpread1_Sheet1.Cells[i, 0].Text = bl.ToString();
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            InitTree();
            //初始化人员信息
            ArrayList al = managerInteger.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.F);
            if (al != null)
            {
                NeuObject obj = new NeuObject();
                obj.ID = "ALL";
                obj.Name = "全部";
                al.Insert(0, obj);
                this.cbsky.AddItems(al);
                this.cbsky.Tag = "ALL";
            }
            
        }

        /// <summary>
        /// 初始化TreeView
        /// </summary>
        private void InitTree()
        {
            if (tree.Nodes.Count > 0)
            {
                tree.Nodes.Clear();
            }
            TreeNode root = new TreeNode();
            root.Text = "发票类型";
            root.ImageIndex = 2;
            tree.Nodes.Add(root);
            //{6A6FDD3F-ACBB-4ff7-80BC-6AD0FF69360E}
            //ArrayList al = Neusoft.HISFC.Models.Fee.InvoiceTypeEnumService.List();
            Neusoft.HISFC.BizLogic.Manager.Constant myCont = new Neusoft.HISFC.BizLogic.Manager.Constant ();
            ArrayList al = myCont.GetList("GetInvoiceType");
            if (al == null || al.Count == 0)
            {
                return;
            }
            TreeNode node ;
            foreach (NeuObject obj in al)
            {
                //{6A6FDD3F-ACBB-4ff7-80BC-6AD0FF69360E}
                //if (obj.ID == Neusoft.HISFC.Models.Fee.EnumInvoiceType.C.ToString() || obj.ID == Neusoft.HISFC.Models.Fee.EnumInvoiceType.I.ToString())
                if (obj.ID == "C" || obj.ID == "I")
                {
                    node = new TreeNode();
                    node.Text = obj.Name;
                    node.Tag = obj;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 1;
                    root.Nodes.Add(node);
                }
            }
            this.tree.ExpandAll();

        }

        /// <summary>
        /// 获取门诊发票数据
        /// </summary>
        private void GetOutpatientFeeInvoice(string begin,string end,string casher)
        {
            
            List<NeuObject> list = new List<NeuObject>();
            if (invoiceServiceManager.GetOutpatientFeeInvoice(begin, end,casher, ref list) == -1)
            {
                MessageBox.Show(invoiceServiceManager.Err);
                return;
            }
            int count = list.Count;
            this.neuSpread1_Sheet1.Rows.Count = count;
            for (int i = 0; i < count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Text = "true";
                this.neuSpread1_Sheet1.Cells[i, 1].Text = list[i].ID;
                this.neuSpread1_Sheet1.Cells[i, 2].Text = list[i].Name;
                this.neuSpread1_Sheet1.Cells[i, 3].Text = list[i].Memo;
                this.neuSpread1_Sheet1.Rows[i].Tag = list[i];
            }
        }

        /// <summary>
        /// 获取住院发票数据
        /// </summary>
        private void GetInpatientFeeInvoice(string begin, string end, string casher)
        {
            List<NeuObject> list = new List<NeuObject>();
            if (invoiceServiceManager.GetInpatientFeeInvoice(begin, end,casher, ref list) == -1)
            {
                MessageBox.Show(invoiceServiceManager.Err);
                return;
            }
            int count = list.Count;
            this.neuSpread1_Sheet1.Rows.Count = count;
            for (int i = 0; i < count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Text = "true";
                this.neuSpread1_Sheet1.Cells[i, 1].Text = list[i].ID;
                this.neuSpread1_Sheet1.Cells[i, 2].Text = list[i].Name;
                this.neuSpread1_Sheet1.Cells[i, 3].Text = list[i].Memo;
                this.neuSpread1_Sheet1.Rows[i].Tag = list[i];
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected virtual void Save()
        {
            if (this.tree.SelectedNode.Tag == null) return;
            int count=this.neuSpread1_Sheet1.Rows.Count;
            if (count == 0) return;
            //操作员
            NeuObject oper = invoiceServiceManager.Operator;
            //操作时间
            string operTime = invoiceServiceManager.GetDateTimeFromSysDateTime().ToString();
            int resultValue = 0;
            //开始事物
            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.invoiceServiceManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                for (int i = 0; i < count; i++)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 0].Text.ToLower() == "false") continue;
                    NeuObject obj = this.neuSpread1_Sheet1.Rows[i].Tag as NeuObject;
                    //门诊发票数据{6A6FDD3F-ACBB-4ff7-80BC-6AD0FF69360E}
                    //if (enumType == Neusoft.HISFC.Models.Fee.EnumInvoiceType.C)
                    if (enumType == "C")
                    {
                        resultValue=this.invoiceServiceManager.SaveCheckOutPatientFeeInvoice(obj, operTime.ToString(), oper.ID, begin, end);
                    }
                    //住院发票数据{6A6FDD3F-ACBB-4ff7-80BC-6AD0FF69360E}
                    //if (enumType == Neusoft.HISFC.Models.Fee.EnumInvoiceType.I)
                    if (enumType == "I")
                    {
                        resultValue=this.invoiceServiceManager.SaveCheckInpatientFeeInvoice(obj, operTime.ToString(), oper.ID, begin, end);
                    }
                    if (resultValue <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("保存数据失败！" + this.invoiceServiceManager.Err);
                        return;
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存数据成功！");

                this.GetInvoiceData(begin, end, casher);
            }
            catch(Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 加载发票数据
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        private void GetInvoiceData(string begin, string end,string casher)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据请稍后^-^");
            Application.DoEvents();
            switch (enumType)
            {
                //门诊发票 {6A6FDD3F-ACBB-4ff7-80BC-6AD0FF69360E}
                //case Neusoft.HISFC.Models.Fee.EnumInvoiceType.C:
                //    {
                //        GetOutpatientFeeInvoice(begin, end, casher);
                //        break;
                //    }
                //case Neusoft.HISFC.Models.Fee.EnumInvoiceType.I:
                //    {
                //        GetInpatientFeeInvoice(begin, end, casher);
                //        break;
                //    }
                case "C":
                    {
                        GetOutpatientFeeInvoice(begin, end, casher);
                        break;
                    }
                case "I":
                    {
                        GetInpatientFeeInvoice(begin, end, casher);
                        break;
                    }
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        #endregion

        #region 事件
        private void ucCheckInvoice_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            object obj = e.Node.Tag;
            if (obj == null) return;
            //起止时间
            begin = this.dtBegin.Value.Date.ToString("yyyy-MM-dd") + " 00:00:00";
            end = this.dtEnd.Value.Date.ToString("yyyy-MM-dd") + " 23:59:59";

            string indexStr = (obj as NeuObject).ID;
            enumType = indexStr;
            //{6A6FDD3F-ACBB-4ff7-80BC-6AD0FF69360E}
                //(Neusoft.HISFC.Models.Fee.EnumInvoiceType)Enum.Parse(typeof(Neusoft.HISFC.Models.Fee.EnumInvoiceType),indexStr);
            if (this.cbsky.Tag == null)
            {
                casher = "ALL";
            }
            else
            {
                casher = cbsky.Tag.ToString();
            }
            GetInvoiceData(begin, end, casher);
        }
        #endregion

        private void cbsky_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.casher = this.cbsky.Tag.ToString();
            begin = this.dtBegin.Value.Date.ToString("yyyy-MM-dd") + " 00:00:00";
            end = this.dtEnd.Value.Date.ToString("yyyy-MM-dd") + " 23:59:59";
            this.GetInvoiceData(this.begin, this.end, casher);
        }
    }
}

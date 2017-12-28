using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class ucChangeInvoiceAll : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 变量
        Neusoft.HISFC.BizLogic.Fee.InvoiceServiceNoEnum invoiceManager = new Neusoft.HISFC.BizLogic.Fee.InvoiceServiceNoEnum();

        #endregion

        public ucChangeInvoiceAll()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取操作员在用和未用的发票类型
        /// </summary>
        /// <param name="operCode"></param>
        /// <returns></returns>
        public int SetTreeView(string operCode)
        {
            if (this.neuTreeView1.Nodes.Count > 0)
            {
                this.neuTreeView1.Nodes.Clear();
            }

            ArrayList alInvoice = invoiceManager.GetInvoiceTypeByOperIDORFinGroupID(operCode, "");
         
            if (alInvoice == null)
            {
                MessageBox.Show("查询发票类型出错");
                return -1;
            }
            TreeNode rootNode = new TreeNode();
            rootNode.Text = Neusoft.FrameWork.Management.Connection.Operator.Name;
            rootNode.Tag = Neusoft.FrameWork.Management.Connection.Operator.ID;
            rootNode.SelectedImageIndex = (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.R人员;
            rootNode.ImageIndex = (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.R人员;



            for (int i = 0; i < alInvoice.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj = alInvoice[i] as Neusoft.FrameWork.Models.NeuObject;

                TreeNode node = new TreeNode();
                node.Text = obj.Name;
                node.Tag = obj;
                node.ImageIndex =(int) Neusoft.FrameWork.WinForms.Classes.EnumImageList.M明细;
                node.SelectedImageIndex = (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.M明细;
                rootNode.Nodes.Add(node);
            }
            rootNode.ExpandAll();
            this.neuTreeView1.Nodes.Add(rootNode);

            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            if (this.neuTreeView1.SelectedNode.Level == 0)
            {
                this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeName = "";
                this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeID = "";
                this.ucInvoiceChangeNOInitInvoiceType1.QueryInvoices("", "");
                return -1;
            }
            this.QueryInvoice(Neusoft.FrameWork.Management.Connection.Operator.ID, (Neusoft.FrameWork.Models.NeuObject)this.neuTreeView1.SelectedNode.Tag);

            return base.OnQuery(sender, neuObject);
        }

        /// <summary>
        ///查询收据信息
        /// </summary>
        /// <param name="operCode"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected int QueryInvoice(string operCode,Neusoft.FrameWork.Models.NeuObject obj)
        {
            if (this.neuTreeView1.SelectedNode.Level == 0)
            {
                this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeName = "";
                this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeID = "";
                this.ucInvoiceChangeNOInitInvoiceType1.QueryInvoices("", "");
                return -1;
            }
            this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeID = obj.ID;
            this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeName = obj.Name;
            int returnValue =  this.ucInvoiceChangeNOInitInvoiceType1.QueryInvoices(operCode, obj.ID);
            if (returnValue < 0)
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
           
            this.SetTreeView(Neusoft.FrameWork.Management.Connection.Operator.ID);

            this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeName = "";

            base.OnLoad(e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.ucInvoiceChangeNOInitInvoiceType1.SaveResult();
            return base.OnSave(sender, neuObject);
        }

        private void neuTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.neuTreeView1.SelectedNode.Level == 0)
            {
                this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeName = "";
                this.ucInvoiceChangeNOInitInvoiceType1.InvoiceTypeID = "";
                this.ucInvoiceChangeNOInitInvoiceType1.QueryInvoices("", "");
                return ;
            }
            this.QueryInvoice(Neusoft.FrameWork.Management.Connection.Operator.ID, (Neusoft.FrameWork.Models.NeuObject)e.Node.Tag);
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 麻醉登记控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucRegistrationAnae : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucRegistrationAnae()
        {
            InitializeComponent();
        }

        #region 字段

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 事件

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("取消", "取消", 1, true, false, null);
            return this.toolBarService;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            if (neuDateTimePicker1.Value > neuDateTimePicker2.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间");
                return -1;
            }
            string strBegin = neuDateTimePicker1.Value.Year.ToString() + "-" + neuDateTimePicker1.Value.Month.ToString() + "-" + neuDateTimePicker1.Value.Day.ToString() + " 00:00:00";
            string strEnd = neuDateTimePicker2.Value.Year.ToString() + "-" + neuDateTimePicker2.Value.Month.ToString() + "-" + neuDateTimePicker2.Value.Day.ToString() + " 23:59:59";
            this.ucRegistrationTree1.RefreshList(Neusoft.FrameWork.Function.NConvert.ToDateTime(strBegin), Neusoft.FrameWork.Function.NConvert.ToDateTime(strEnd));
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            TreeNode currentSelectNode = new TreeNode();
            currentSelectNode = this.ucRegistrationTree1.SelectedNode;
            if (currentSelectNode == null)
                return -1;
            if (currentSelectNode.Tag == null)
                return -1;
            if (currentSelectNode.Parent == null || currentSelectNode.Parent.Tag == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择登记患者"));
                return -1;
            }
            if (currentSelectNode.Parent.Tag.ToString() == "NO_Register" || currentSelectNode.Parent.Tag.ToString() == "Cancel")
            {
                if (this.ucRegistrationAnaeForm1.Save(ucRegistrationAnaeForm.OperType.Reco) >= 0)
                {
                    this.OnQuery(sender, neuObject);
                }
            }
            else if (currentSelectNode.Parent.Tag.ToString() == "Register")
            {

                if (this.ucRegistrationAnaeForm1.Save(ucRegistrationAnaeForm.OperType.Modify) >= 0)
                {
                    this.OnQuery(sender, neuObject);
                }
            }
            return base.OnSave(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.ucRegistrationAnaeForm1.Print();
            return base.OnPrint(sender, neuObject);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "取消")
            {

            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        #endregion

        private void ucRegistrationTree1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode select = this.ucRegistrationTree1.SelectedNode;

            if (select == null)
                return;
            if (select.Tag == null)
                return;

            TreeNode parent = select.Parent;
            if (parent == null) return;

            if (parent.Tag.ToString() == "NO_Register" || parent.Tag.ToString() == "Cancel")
            {
                this.ucRegistrationAnaeForm1.OperationApplication = select.Tag as OperationAppllication;
                this.ucRegistrationAnaeForm1.Focus();
            }
            else if (parent.Tag.ToString() == "Register")
            {
                this.ucRegistrationAnaeForm1.AnaeRecord = select.Tag as AnaeRecord;
                this.ucRegistrationAnaeForm1.Focus();
            }
        }

        private void neuDateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (this.neuDateTimePicker2.Value < this.neuDateTimePicker1.Value)
            {
                neuDateTimePicker2.Value = this.neuDateTimePicker1.Value;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            //{8DA8B1D6-DDD6-4329-B661-F4BDAE45DB66}
            this.ucRegistrationTree1.Init();
            base.OnLoad(e);
        }
    }
}

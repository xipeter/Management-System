using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Operation
{
    public partial class ucTabulation : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucTabulation()
        {
            InitializeComponent();
            Init();
        }
        private Neusoft.HISFC.BizProcess.Integrate.Registration.Tabulation tabMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Tabulation();
       
        private Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

        private ArrayList al = null;
        private ucTabular tabular = null;
        private Neusoft.HISFC.Models.Base.Employee var = null;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            var = (Neusoft.HISFC.Models.Base.Employee)this.dataManager.Operator; 
            InitDept();
            this.ucTabular1.Init(var);
            this.ucTabular1.Clear();

            this.dateTimePicker1.Value = this.dataManager.GetDateTimeFromSysDateTime();

            return 0;
        }
        /// <summary>
        /// 生成操作员负责科室列表
        /// </summary>
        /// <returns></returns>
        private int InitDept()
        {
            this.tvDept.Nodes.Clear();

            TreeNode root = new TreeNode("分管科室");
            root.SelectedImageIndex = 22;
            root.ImageIndex = 22;
            this.tvDept.Nodes.Add(root);
            //List al <Neusoft.FrameWork.Models.NeuObject>
            //根据权限获得操作员所在科室
            al= new ArrayList(Neusoft.HISFC.Components.Common.Classes.Function.QueryPrivList("0601",true).ToArray()); 
            if (al == null) return -1;
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                TreeNode node = new TreeNode();
                node.Text = obj.Name;
                node.SelectedImageIndex = 41;
                node.ImageIndex = 40;
                node.Tag = obj;
                root.Nodes.Add(node);
            }

            this.tvDept.ExpandAll();

            return 0;
        }

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("上周", "上周", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S上一个, true, false, null);
            toolBarService.AddToolButton("下周", "下周", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X下一个, true, false, null);
            toolBarService.AddToolButton( "向上", "向上", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S上一个, true, false, null );
            toolBarService.AddToolButton( "向下", "向下", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X下一个, true, false, null ); 
            return toolBarService;
        }
        #endregion

        #region 工具栏增加按钮单击事件
        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "上周":
                    this.ucTabular1.PriorWeek();
                    break;
                case "下周":
                    this.ucTabular1.NextWeek();
                    break; 
                case "向上":
                    this.ucTabular1.Up();
                    break;
                case "向下":
                    this.ucTabular1.Down();
                    break; 
                default:
                    break;
            }
        }
        #endregion

        #endregion 

        #region 保存
        protected override int OnSave(object sender, object neuObject)
        {
            this.ucTabular1.Save();
            return base.OnSave(sender, neuObject);
        }
        #endregion 

        private void tvDept_DoubleClick(object sender, System.EventArgs e)
        {
            TreeNode node = this.tvDept.SelectedNode;
            if (node == null || node.Tag == null) return;

            this.ucTabular1.QueryCurrent((node.Tag as Neusoft.FrameWork.Models.NeuObject).ID);
            //添加本月排班记录
            QueryTabular((node.Tag as Neusoft.FrameWork.Models.NeuObject).ID);
            //记录当前科室
            this.treeView1.Tag = (node.Tag as Neusoft.FrameWork.Models.NeuObject).ID;
        }
        /// <summary>
        /// 查询已排班序号
        /// </summary>
        /// <param name="deptID"></param>
        private void QueryTabular(string deptID)
        {
            string order = "";

            DateTime begin = DateTime.Parse(this.dateTimePicker1.Value.Year.ToString() + "-" +
                this.dateTimePicker1.Value.Month.ToString() + "-1");
            al = tabMgr.Query(begin, deptID);

            this.treeView1.Nodes[0].Nodes.Clear();
            if (al != null)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    order = al[i].ToString();//排班序号
                    TreeNode node = new TreeNode();
                    node.Text = order.Substring(4, 2) + "月" + order.Substring(6, 2) + "日～" + order.Substring(12, 2) + "月" + order.Substring(14, 2) + "日";
                    node.SelectedImageIndex = 21;
                    node.ImageIndex = 20;
                    node.Tag = order;
                    this.treeView1.Nodes[0].Nodes.Add(node);
                }
            }
            this.treeView1.Nodes[0].Expand();
        }

        /// <summary>
        /// 刷新排班信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
        {
            if (this.treeView1.Tag == null) return;
            this.QueryTabular(this.treeView1.Tag.ToString());
        }
        //调用排班模板
        private void treeView1_DoubleClick(object sender, System.EventArgs e)
        {
            TreeNode select = this.treeView1.SelectedNode;
            if (select == null) return;
            if (select.Parent == null) return;
            if (this.treeView1.Tag == null || this.treeView1.Tag.ToString() == "") return;

            #region 生成窗体
            System.Windows.Forms.Form f = new Form();
            f.MinimizeBox = false;
            f.MaximizeBox = false;
            f.Text = "排班";
            f.StartPosition = FormStartPosition.CenterParent;
            f.Size = new Size(600, 450);

            Panel p1 = new Panel();
            p1.TabIndex = 0;


            Panel p2 = new Panel();
            p2.TabIndex = 1;
            p2.Height = 50;
            p2.Dock = DockStyle.Bottom;
            f.Controls.Add(p1);
            f.Controls.Add(p2);

            tabular = new ucTabular();
            tabular.Init(var);
            p1.Controls.Add(tabular);
            p1.Dock = DockStyle.Fill;
            tabular.Dock = DockStyle.Fill;

            Button bOK = new Button();
            Button bExit = new Button();
            p2.Controls.Add(bOK);
            p2.Controls.Add(bExit);
            bOK.Text = "调用";
            bOK.DialogResult = DialogResult.OK;
            bExit.Text = "取消";
            bOK.Location = new Point(p2.Width - 220, 13);
            bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            bExit.Location = new Point(p2.Width - 120, 13);
            bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            f.AcceptButton = bOK;
            f.CancelButton = bExit;
            tabular.Query(select.Tag.ToString(), this.treeView1.Tag.ToString());

            bOK.Click += new EventHandler(bOK_Click);
            f.ShowDialog();
            f.Dispose();
            #endregion

        }

        //调用模板
        private void bOK_Click(object sender, EventArgs e)
        {
            ArrayList al = this.tabular.getTabular();
            if (al == null) return;
            this.ucTabular1.LoadTemplate(al);
        }
    }
}

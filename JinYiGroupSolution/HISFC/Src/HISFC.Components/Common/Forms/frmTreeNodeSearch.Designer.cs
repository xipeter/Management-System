using System.Collections;
using System.Windows.Forms;
namespace Neusoft.HISFC.Components.Common.Forms
{
    partial class frmTreeNodeSearch
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button tbNext;
        private System.Windows.Forms.Button tbCancel;
        private System.Windows.Forms.CheckBox cbExact;
        private System.Windows.Forms.CheckBox cbUper;
        private System.Windows.Forms.GroupBox groupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comSearchText;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbTag;
        private System.ComponentModel.IContainer components;
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comSearchText = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.cbExact = new System.Windows.Forms.CheckBox();
            this.tbNext = new System.Windows.Forms.Button();
            this.tbCancel = new System.Windows.Forms.Button();
            this.cbUper = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTag = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找内容(N)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comSearchText
            // 
            //this.comSearchText.ArrowBackColor = System.Drawing.Color.Silver;
            this.comSearchText.IsFlat = false;
            this.comSearchText.IsLike = true;
            this.comSearchText.Location = new System.Drawing.Point(112, 16);
            this.comSearchText.Name = "comSearchText";
            this.comSearchText.PopForm = null;
            this.comSearchText.ShowCustomerList = false;
            this.comSearchText.ShowID = false;
            this.comSearchText.Size = new System.Drawing.Size(136, 20);
            this.comSearchText.TabIndex = 1;
            this.comSearchText.Tag = "";
            this.comSearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comSearchText_KeyDown);
            // 
            // cbExact
            // 
            this.cbExact.Location = new System.Drawing.Point(16, 48);
            this.cbExact.Name = "cbExact";
            this.cbExact.Size = new System.Drawing.Size(96, 24);
            this.cbExact.TabIndex = 3;
            this.cbExact.Text = "精确查找";
            this.cbExact.CheckedChanged += new System.EventHandler(this.cbExact_CheckedChanged);
            // 
            // tbNext
            // 
            this.tbNext.Location = new System.Drawing.Point(264, 16);
            this.tbNext.Name = "tbNext";
            this.tbNext.Size = new System.Drawing.Size(96, 23);
            this.tbNext.TabIndex = 2;
            this.tbNext.Text = "查找下一个(&F)";
            this.tbNext.Click += new System.EventHandler(this.tbNext_Click);
            // 
            // tbCancel
            // 
            this.tbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tbCancel.Location = new System.Drawing.Point(264, 48);
            this.tbCancel.Name = "tbCancel";
            this.tbCancel.Size = new System.Drawing.Size(96, 23);
            this.tbCancel.TabIndex = 6;
            this.tbCancel.Text = "取消";
            this.tbCancel.Click += new System.EventHandler(this.tbCancel_Click);
            // 
            // cbUper
            // 
            this.cbUper.Location = new System.Drawing.Point(16, 80);
            this.cbUper.Name = "cbUper";
            this.cbUper.TabIndex = 4;
            this.cbUper.Text = "区分大小写";
            this.cbUper.CheckedChanged += new System.EventHandler(this.cbUper_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTag);
            this.groupBox1.Controls.Add(this.rbText);
            this.groupBox1.Location = new System.Drawing.Point(112, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 56);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类型";
            // 
            // rbTag
            // 
            this.rbTag.Location = new System.Drawing.Point(72, 24);
            this.rbTag.Name = "rbTag";
            this.rbTag.Size = new System.Drawing.Size(48, 24);
            this.rbTag.TabIndex = 1;
            this.rbTag.Text = "键值";
            this.rbTag.CheckedChanged += new System.EventHandler(this.rbTag_CheckedChanged);
            // 
            // rbText
            // 
            this.rbText.Checked = true;
            this.rbText.Location = new System.Drawing.Point(16, 24);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(48, 24);
            this.rbText.TabIndex = 0;
            this.rbText.TabStop = true;
            this.rbText.Text = "文本";
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // frmTreeNodeSearch
            // 
            this.AcceptButton = this.tbNext;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.tbCancel;
            this.ClientSize = new System.Drawing.Size(376, 117);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbUper);
            this.Controls.Add(this.tbCancel);
            this.Controls.Add(this.tbNext);
            this.Controls.Add(this.cbExact);
            this.Controls.Add(this.comSearchText);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(384, 144);
            this.Name = "frmTreeNodeSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        Neusoft.FrameWork.WinForms.Classes.Function fun = new Neusoft.FrameWork.WinForms.Classes.Function();
        System.Windows.Forms.TreeView treeView = null;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="tv"></param>
        /// <returns></returns>
        public int Init(System.Windows.Forms.TreeView tv)
        {
            treeView = tv;
            treeView.HideSelection = false;
            this.comSearchText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            return 0;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="ItemList"></param>
        public int Init(System.Windows.Forms.TreeView tv, ArrayList ItemList)
        {
            this.treeView = tv;
            treeView.HideSelection = false;
            ArrayList list = new ArrayList();
            Neusoft.HISFC.Models.Base.Spell obj = null;
            if (ItemList == null)
            {

                foreach (TreeNode node in tv.Nodes)
                {
                    obj = new Neusoft.HISFC.Models.Base.Spell();
                    obj.ID = node.Text;
                    obj.Name = node.Text;
                    list.Add(obj);
                }
            }
            else if (ItemList.Count == 0)
            {
                foreach (TreeNode node in tv.Nodes)
                {
                    obj = new Neusoft.HISFC.Models.Base.Spell();
                    obj.ID = node.Text;
                    obj.Name = node.Text;
                    list.Add(obj);
                }
            }
            else
            {
                list = ItemList;
            }
            this.comSearchText.AddItems(list);
            return 0;
        }
        /// <summary>
        /// 查找下一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbNext_Click(object sender, System.EventArgs e)
        {
            //指示查询 名称还是tag 默认查名称
            bool TextOrTag = false;
            //查询的字符串
            string strSearch = "";
            if (this.rbTag.Checked)
            {
                TextOrTag = true;
            }
            if (comSearchText.DropDownStyle == System.Windows.Forms.ComboBoxStyle.Simple)
            {
                strSearch = comSearchText.Text;
            }
            else
            {
                #region 下拉框选择
                if (this.rbText.Checked)
                {
                    strSearch = comSearchText.Text;
                }
                else
                {
                    if (comSearchText.Tag != null)
                    {
                        strSearch = comSearchText.Tag.ToString();
                    }
                    else
                    {
                        strSearch = "";
                    }
                }
                #endregion
            }
            this.treeView.SelectedNode = fun.FindTreeNodeByDepth(treeView.Nodes, strSearch, TextOrTag, cbExact.Checked, this.cbUper.Checked);
            if (fun.CurrentNode >= treeView.GetNodeCount(true))
            {
                if (fun.LaserNode == 0 && treeView.SelectedNode == null)
                {
                    MessageBox.Show("查找不到 (" + comSearchText.Text + ")");
                }
                else if (fun.LaserNode != 0 && treeView.SelectedNode == null)
                {
                    MessageBox.Show("查找回到起始点");
                    fun.CurrentNode = 0;
                    fun.LaserNode = 0;
                }

            }
            fun.LaserNode = fun.CurrentNode;
            fun.CurrentNode = 0;
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCancel_Click(object sender, System.EventArgs e)
        {
            this.Visible = false;
        }
        #region 恢复起始位置
        private void cbExact_CheckedChanged(object sender, System.EventArgs e)
        {
            //恢复从起始位置开始查
            fun.CurrentNode = 0;
            fun.LaserNode = 0;
        }

        private void cbUper_CheckedChanged(object sender, System.EventArgs e)
        {
            //恢复从起始位置开始查
            fun.CurrentNode = 0;
            fun.LaserNode = 0;
        }

        private void rbText_CheckedChanged(object sender, System.EventArgs e)
        {
            //恢复从起始位置开始查
            fun.CurrentNode = 0;
            fun.LaserNode = 0;
        }

        private void rbTag_CheckedChanged(object sender, System.EventArgs e)
        {
            //恢复从起始位置开始查
            fun.CurrentNode = 0;
            fun.LaserNode = 0;
        }
        #endregion

        private void comSearchText_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                tbNext_Click(new object(), new System.EventArgs());
            }
        }

    }
}
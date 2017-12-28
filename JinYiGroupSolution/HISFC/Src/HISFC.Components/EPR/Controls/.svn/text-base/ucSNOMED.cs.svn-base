using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.EPR.Controls
{
    public partial class ucSNOMED : UserControl
    {
        private System.Windows.Forms.ListView listView1;
        public event System.EventHandler Selected;
        public ucSNOMED()
        {
            InitializeComponent();
        }

        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(180, 280);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ucSNOPMED
            // 
            this.Controls.Add(this.listView1);
            this.Name = "ucSNOPMED";
            this.Size = new System.Drawing.Size(180, 280);
            this.Load += new System.EventHandler(this.ucSNOPMED_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void ucSNOPMED_Load(object sender, System.EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(ucSNOPMED_KeyDown);
            this.listView1.HideSelection = false;
            this.listView1.MultiSelect = false;
        }


        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            this.Get();
        }
        //待添加
        private void addItem(Neusoft.FrameWork.Models.NeuObject obj)//Neusoft.HISFC.Models.EPR.SNOMED obj)
        {
            ListViewItem item = new ListViewItem(obj.Name);
            item.Tag = obj;
            this.listView1.Items.Add(item);
        }

        /// <summary>
        /// 获得当前
        /// </summary>
        /// <returns></returns>
        public void Get()
        {
            this.FindForm().Hide();
            if (this.listView1.SelectedItems.Count == 0) return;
            if (Selected != null)
            {
                Selected(this.listView1.SelectedItems[0].Tag, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void AddKey(string key)
        {
            filter = filter + key;
            foreach (ListViewItem item in this.listView1.Items)
            {
                Neusoft.HISFC.Models.Base.ISpell spell = item.Tag as Neusoft.HISFC.Models.Base.ISpell;
                if (spell.SpellCode.StartsWith(filter))
                {
                    item.Selected = true;
                    return;
                }
            }
        }
        private string filter = "";
        /// <summary>
        /// 管理SNOPMED
        /// </summary>
        public string FLAG = "@^";
        private string oldIndex = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Filter(string id)
        {
            filter = "";

            if (oldIndex == id) return;
            oldIndex = id;
            this.listView1.Items.Clear();
            ArrayList al = null;

            if (id.IndexOf(FLAG) >= 0)
            {
                id = id.Replace(FLAG, "");
                al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSNOMED(id, true);
            }
            else
            {
                al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSNOMED();
            }
            foreach (Neusoft.HISFC.Models.EPR.SNOMED obj in al)
            {
                this.addItem(obj);
            }
            alObject = al;

        }
        private ArrayList alObject = null;
        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="id"></param>
        public void ShowWindow()
        {
            Neusoft.FrameWork.WinForms.Forms.frmEasyChoose easyChoose = new Neusoft.FrameWork.WinForms.Forms.frmEasyChoose(alObject);
            easyChoose.SelectedItem += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(easyChoose_SelectedItem);
            easyChoose.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            this.AddKey(e.KeyData.ToString());
            if (e.KeyData == Keys.Enter)
            {
                this.Get();
            }
            else if (e.KeyData == Keys.Space)
            {
                this.Get();
            }
        }

        private void ucSNOPMED_KeyDown(object sender, KeyEventArgs e)
        {
            this.AddKey(e.KeyData.ToString());
        }

        public void MoveNext()
        {
            try
            {
                this.listView1.Items[this.listView1.SelectedItems[0].Index + 1].Selected = true;
            }
            catch { }
        }
        public void MovePre()
        {
            try
            {
                this.listView1.Items[this.listView1.SelectedItems[0].Index - 1].Selected = true;
            }
            catch { }
        }

        public Size DefaultSize = new Size(180, 280);

        private void easyChoose_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        {
            if (Selected != null)
            {
                Selected(sender, null);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.RADT.Controls
{
    /// <summary>
    /// [功能描述: 护理组维护]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    public partial class ucNurseTendGroupManager : UserControl
    {
        public ucNurseTendGroupManager()
        {
            InitializeComponent();
        }

        private Neusoft.FrameWork.Models.NeuObject nurseCell = null;

        /// <summary>
        /// 
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NurseCell
        {
            get
            {
                return this.nurseCell;
            }
            set
            {
                this.nurseCell = value;
            }
        }
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 刷新列表
        /// </summary>
        public void RefreshList()
        {
            if (this.nurseCell == null || this.nurseCell.ID == "") return;

            //清空节点
            this.listView1.Items.Clear();

            //取本护理站床位和护理组信息
            ArrayList al = manager.QueryBedNurseTendGroupList(this.nurseCell.ID);
            if (al == null)
            {
                MessageBox.Show(manager.Err);
                return;
            }

            //显示床位和护理组
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(obj.ID);				//床号
                item.SubItems.Add(obj.Name);			//护理组
                item.Text = "【" + obj.ID.Substring(4) + "】" + obj.Name;	//显示文本
                item.ImageIndex = 0;
                item.Tag = obj.ID;
                this.listView1.Items.Add(item);
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            if (this.listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择个床位！");
                return -1;
            }

            //取当前选中的节点
            ListViewItem item = this.listView1.SelectedItems[0];
            if (manager.UpdateNurseTendGroup(item.Tag.ToString(), this.txtGroup.Text) == -1)
            {
                MessageBox.Show(manager.Err);
                return -1;
            }
            else
            {
                item.Text = "【" + item.Tag.ToString().Substring(4) + "】" + this.txtGroup.Text;
            }
            return 1;
        }


        private void btnOKClick(object sender, System.EventArgs e)
        {
            this.Save();
        }

        private void txtGroup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Save();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.listView1.SelectedItems.Count <= 0) return;
            //取当前选中的节点
            ListViewItem item = this.listView1.SelectedItems[0];
            string s = item.Text;
            try
            {
                //取护理组信息,并显示在维护栏中
                s = s.Substring(s.LastIndexOf("】") + 1);
                this.txtGroup.Text = s;
                this.txtGroup.Focus();
            }
            catch { }
        }


    }
}

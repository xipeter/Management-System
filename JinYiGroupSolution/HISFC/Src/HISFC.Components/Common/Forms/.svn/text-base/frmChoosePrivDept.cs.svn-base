using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Common.Forms
{
    public partial class frmChoosePrivDept : Form
    {
        /// <summary>
        /// 根据传入的二级/三级权限码 显示有权限的信息
        /// </summary>
        /// <param name="class2Code">二级权限码</param>
        /// <param name="class3Code">三级权限码 如不需判断三级权限 则传入null</param>
        public frmChoosePrivDept()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择提示信息
        /// </summary>
        public string NoticeTitle
        {
            set
            {
                this.lbNotice.Text = value;
            }
        }

        /// <summary>
        /// 获取当前选中信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SelectData
        {
            get
            {
                return this.GetSelectItem();
            }
        }

        /// <summary>
        /// 根据权限码获取权限信息
        /// </summary>
        /// <param name="userCode">权限人员编码</param>
        /// <param name="class2Code">二级权限码</param>
        /// <param name="class3Code">三级权限码 如不需判断三级权限 则传入null</param>
        /// <returns>成功返回拥有1 失败返回0</returns>
        public virtual int GetPrivDept(string userCode,string class2Code, string class3Code)
        {
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager privManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();

            List<Neusoft.FrameWork.Models.NeuObject> alPrivDept = new List<Neusoft.FrameWork.Models.NeuObject>();
            if (class3Code != null && class3Code != "")         //取操作员拥有权限的科室
            {
                alPrivDept = privManager.QueryUserPriv(userCode, class2Code, class3Code);              
            }
            else
            {
                alPrivDept = privManager.QueryUserPriv(userCode, class2Code);
            }

            if (alPrivDept == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取权限科室集合失败"));
                return 0;
            }
            this.SetPriv(alPrivDept, true);
            return 1;
        }

        /// <summary>
        /// 根据权限人员编码/科室编码/二级权限码 获取所拥有的三级权限集合
        /// </summary>
        /// <param name="userCode">权限人员编码</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="class2Code">二级权限编码</param>
        /// <returns>成功返回所拥有的权限1 失败返回0</returns>
        public virtual int GetUserPriv(string userCode, string deptCode, string class2Code)
        {
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager privManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
            List<Neusoft.FrameWork.Models.NeuObject> alPriv = privManager.QueryUserPrivCollection(userCode, class2Code, deptCode);
            if (alPriv == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取三级权限集合失败"));
                return 0;
            }
            this.SetPriv(alPriv, false);

            return 1;
        }

        /// <summary>
        /// 显示权限集合信息
        /// </summary>
        /// <param name="alPriv">权限集合信息</param>
        /// <param name="isPrivDept">权限集合信息 True 权限科室 False 权限集合</param>
        public virtual void SetPriv(List<Neusoft.FrameWork.Models.NeuObject> alPriv, bool isPrivDept)
        {
            this.nlvPrivInfo.Items.Clear();

            foreach (Neusoft.FrameWork.Models.NeuObject info in alPriv)            
            {
                ListViewItem lv = new ListViewItem(info.Name);
                
                if (isPrivDept)
                    lv.ImageIndex = 1;
                else
                    lv.ImageIndex = 0;

                if (info.User02 != "")
                {
                    this.NoticeTitle = info.User02 + " － 权限选择";
                }

                lv.Tag = info;

                this.nlvPrivInfo.Items.Add(lv);
            }
        }

        /// <summary>
        /// 返回当前选中节点信息
        /// </summary>
        /// <returns>成功返回选中节点信息 是不返回null</returns>
        protected Neusoft.FrameWork.Models.NeuObject GetSelectItem()
        {
            ListView.SelectedListViewItemCollection selectItemCollection = this.nlvPrivInfo.SelectedItems;
            if (selectItemCollection != null && selectItemCollection.Count > 0)
                return selectItemCollection[0].Tag as Neusoft.FrameWork.Models.NeuObject;
            else
                return null;
        }

        private void nlvPrivInfo_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectData != null)
                this.DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SelectData != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
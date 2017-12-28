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
    /// [功能描述: 药品入出库类型处理类插件设置]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// </summary>
    public partial class ucIMAInterface : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucIMAInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 一级权限码
        /// </summary>
        private string class1Code = "03";

        /// <summary>
        /// 三级权限管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.PowerLevelManager class3Manager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();
      

        /// <summary>
        /// 一级权限码
        /// </summary>
        public string Class1Code
        {
            get
            {
                return this.class1Code;
            }
            set
            {
                this.class1Code = value;
            }
        }

        /// <summary>
        ///  初始化权限树
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected virtual int InitPrivTree()
        {
            Neusoft.HISFC.BizLogic.Manager.PowerLevel2Manager pLevel2Manager = new Neusoft.HISFC.BizLogic.Manager.PowerLevel2Manager();
            //取二级权限
            ArrayList alLevel2 = pLevel2Manager.LoadLevel2All(this.class1Code);
            if (alLevel2 == null)
            {
                MessageBox.Show(Language.Msg(pLevel2Manager.Err));
                return -1;
            }

            this.tvPrivTree.Nodes.Clear();

            foreach (Neusoft.HISFC.Models.Admin.PowerLevelClass2 level2 in alLevel2)
            {
                TreeNode level2Node = new TreeNode(level2.Class2Name);
                level2Node.Tag = level2;

                //取系统权限
                ArrayList alClass3Meaning = this.class3Manager.LoadLevel3Meaning(level2.Class2Code);
                if (alClass3Meaning == null)
                {
                    MessageBox.Show(Language.Msg(this.class3Manager.Err));
                    return -1;
                }

                foreach (Neusoft.FrameWork.Models.NeuObject level3 in alClass3Meaning)
                {
                    TreeNode level3Node = new TreeNode(level3.Name);
                    level3Node.Tag = level3;

                    level2Node.Nodes.Add(level3Node);
                }

                this.tvPrivTree.Nodes.Add(level2Node);
            }            

            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.InitPrivTree();
            }

            base.OnLoad(e);
        }

        private void tvPrivTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}

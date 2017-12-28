using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Privilege
{
    /// <summary>
    /// [功能描述: Config管理]<br></br>
    /// [创建者:   张凯钧]<br></br>
    /// [创建时间: 2008.6.12]<br></br>
    /// <说明>
    ///  选择类的对话框
    /// </说明>
    /// </summary>
    public partial class SelectClassForm : Form
    {
        public delegate void GetClassName(string Name);
        public event GetClassName GetName;
        public ArrayList classNameList = null;

        public SelectClassForm(ArrayList list)
        {
            InitializeComponent();
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            classNameList = list;

        }

        private void SelectClassForm_Load(object sender, EventArgs e)
        {
            if (classNameList.Count != 0)
            {
                for (int i = 0; i < classNameList.Count; i++)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = classNameList[i].ToString();
                    treeView1.Nodes.Add(newNode);
                }
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            GetName(e.Node.Text);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetName(textBox1.Text.Trim());
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = e.Node.Text.Trim();
        }


    }
}

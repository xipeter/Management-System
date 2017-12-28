using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HIS
{
    /// <summary>
    /// 代码 郁阳 2008.3.25
    /// </summary>
    public partial class frmSkinManager : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmSkinManager()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            if (Program.mainForm.UseDefaultSkin == true)
            {
                this.ckb_default.Checked = false;
                this.skinEngineS.SkinFile = Program.mainForm.SkinFile;
            }
            else
            {
                this.ckb_default.Checked = true;
            }
            this.lblBak1.Text = Program.mainForm.SkinFile;
            this.lblBak2.Text = Program.mainForm.SkinFile;
            this.neuLabel1.Text = Path.GetFileNameWithoutExtension(Program.mainForm.SkinFile);
            string[] fileAll = Directory.GetDirectories("皮肤/");
            this.treeView2.Nodes.Clear();
            for (int i = 0; i < fileAll.Length; i++)
            {
                this.treeView2.Nodes.Add(fileAll[i].Remove(0,3));
                string[] nameAll = Directory.GetFiles(fileAll[i] + "/");
                for (int j = 0; j < nameAll.Length;j++ )
                {
                    string xx=nameAll[j].Remove(0,nameAll[j].Length-4);
                    if(xx==".ssk")
                    {
                        this.treeView2.Nodes[i].Nodes.Add(nameAll[j], Path.GetFileNameWithoutExtension(nameAll[j]));
                    }
                }
            }

            
        }
        /// <summary>
        /// 点击树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Index >=0)
            {
                if (e.Node.Level == 1)
                {
                    this.lblBak1.Text = this.skinEngineS.SkinFile = e.Node.Name;
                    this.neuLabel1.Text = e.Node.Text;
                    //this.lblBak1.Text = Program.mainForm.SkinFile = e.Node.Name;
                }
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 移动滑块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTrackBar1_Scroll(object sender, EventArgs e)
        {
            this.neuProgressBar1.Value = this.neuTrackBar1.Value;

        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuButton6_Click(object sender, EventArgs e)
        {
            Program.mainForm.SkinFile = this.lblBak1.Text;
           //Program.mainForm.MainMenuStrip.Refresh();
            this.Close();
        }
        /// <summary>
        /// 恢复默认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuCheckBox4_CheckedChanged(object sender, EventArgs e)
        {

            Program.mainForm.UseDefaultSkin = !Program.mainForm.UseDefaultSkin;
         
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你好！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void neuButton5_Click(object sender, EventArgs e)
        {

        }

        private void cb_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
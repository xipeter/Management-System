using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    /// <summary>
    /// 语言设置
    /// </summary>
    public partial class frmLanguage : Form
    {
        public frmLanguage()
        {
            InitializeComponent();
        }

        private void frmLanguage_Load(object sender, EventArgs e)
        {
            string path = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.LanguagePath;

            string[] files = System.IO.Directory.GetFiles(path, "*.xml");

            foreach (string s in files)
            {
                string ss = s.Substring(s.LastIndexOf(@"\")+1);
                if (ss == Neusoft.FrameWork.WinForms.Classes.Function.LanguageFileName)
                {
                    this.cmdLanguage.Items.Add("Default Language");
                }
                else
                {
                    string fileName = ss.Substring(0, ss.IndexOf(".") );
                    this.cmdLanguage.Items.Add(fileName);
                }

            }
            if (this.cmdLanguage.Items.Count > 0 && (Neusoft.FrameWork.Management.Language.CurrentLanguage == ""
                || Neusoft.FrameWork.Management.Language.CurrentLanguage == "Language")
                )
                this.cmdLanguage.Text = "Default Language";
            else
            {
                this.cmdLanguage.Text = Neusoft.FrameWork.Management.Language.CurrentLanguage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = "";
            if (this.cmdLanguage.Text == "Default Language")
            {
                filename = Neusoft.FrameWork.WinForms.Classes.Function.LanguageFileName;
            }
            else
            {
                filename = this.cmdLanguage.Text+".xml";
            }
            filename = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.LanguagePath + filename;
            Neusoft.FrameWork.Management.Language l = new Neusoft.FrameWork.Management.Language(filename);
            Program.mainForm.Text =  "医院信息管理系统(" + Neusoft.FrameWork.Management.Language.CurrentLanguage+")";
            this.Close();
        }
    }
}
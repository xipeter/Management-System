using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizLogic.Privilege.Service;
using Neusoft.HISFC.BizLogic.Privilege.Model;

namespace HIS
{
    public partial class frmLogin : Neusoft.FrameWork.WinForms.Forms.BaseForm 
    {
        public frmLogin()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmLogin_Load);
            
        }

        protected override void OnClosed(EventArgs e)
        {
                Application.Exit();
            base.OnClosed(e);
        }
        void frmLogin_Load(object sender, EventArgs e)
        {
            #region �ж��Զ������Ƿ���Ҫ����
            if (System.IO.File.Exists("AutoUpdate.exe") && System.IO.File.Exists("���� AutoUpdate.exe"))
            {
                System.IO.File.Delete("AutoUpdate.exe");
                System.IO.File.Copy("���� AutoUpdate.exe", "AutoUpdate.exe");
                System.IO.File.Delete("���� AutoUpdate.exe");
            }
            #endregion 

            this.DisignControl.IsAllowToNextControl = false;

            //{5313B8E5-709F-4741-A6E3-2186702DAC6C}
            this.lbLicence.Text = "��ϵͳ��Ȩ��:  " + Program.HosName;

            if (Program.IsTestDB)
            {
                this.lbLicence.Text = this.lbLicence.Text + " - ���Կ�";
            }
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            //ȷ��
            if (this.txtUserID.Text.Trim() == "")
            {
                this.txtUserID.Focus();
                Program.isMessageShow = false;
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("�������û�����"),Neusoft.FrameWork.Management.Language.Msg("��ʾ"));
                Program.isMessageShow = true;
                return;
            }
            if (this.txtPWD.Text.Trim() == "")
            {
                this.txtUserID.Focus();
                Program.isMessageShow = false;
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("���������룡"), Neusoft.FrameWork.Management.Language.Msg("��ʾ"));
                Program.isMessageShow = true;
                return;
            }

            string _account = this.txtUserID.Text.Trim();
            string _pass = this.txtPWD.Text.Trim();

            if (LoginFunction.Login(_account, _pass) == -1)
            {
                this.txtPWD.Focus();
                return;
            }

            this.Hide();

            if (HIS.Program.MainForm == null)
                HIS.Program.MainForm = new frmMain();

            HIS.Program.MainForm.InitMenu(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).CurrentGroup.ID);
            if (Program.IsTestDB)
            {
                HIS.Program.MainForm.Text = HIS.Program.MainForm.Text + " - ���Կ�";
            }
            HIS.Program.MainForm.Show();

            ////�����ӵĴ�������;�����ж��û���״̬
            //int retv = 0;//
            ////if ((retv = Program.ShowMainForm(this.txtUserID.Text, this.txtPWD.Text, "", "")) == 0)
            ////{
            ////    this.txtPWD.Clear();
            ////    this.Hide();
            ////}
            //if ((retv =Login(_account,_pass) )== 0)
            //{
            //    this.txtPWD.Clear();
            //    this.Hide();
            //}
            //else
            //{
            //    if (retv == -1)
            //    {
            //        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("�û��������벻��ȷ�������ԣ�"), Neusoft.FrameWork.Management.Language.Msg("��ʾ"));
            //        this.txtUserID.Focus();
            //        this.txtUserID.SelectAll();
            //    }
            //    else if (retv == -2)
            //    {
            //        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("�û����Ѿ�ͣ�ã��������"), Neusoft.FrameWork.Management.Language.Msg("��ʾ"));
            //        this.txtUserID.Focus();
            //        this.txtUserID.SelectAll();
            //    }
            //    else
            //    {
            //        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("�û����Ѿ�����������ģ�"), Neusoft.FrameWork.Management.Language.Msg("��ʾ"));
            //        this.txtUserID.Focus();
            //        this.txtUserID.SelectAll();
            //    }
            //}
            //�����ӵĴ������;
        }
        
        private void txtPWD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                this.neuButton1_Click(null, e);
            }
        }

        private void txtUserID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPWD.Focus();
                e.Handled = true;
                //System.Windows.Forms.SendKeys.Send("{tab}");
            }
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            this.txtUserID.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
         
            
            #region 2013.02.20 ע��
            ////{57CC110D-2CF8-4704-93F3-3BFA247FB41C}
            //if (System.Configuration.ConfigurationSettings.AppSettings["Theme"] == "1")         //������
            //{
            //    this.BackgroundImage = HIS.Properties.Resources.������_��½����;
                
            //    this.neuButton1.BackgroundImage = HIS.Properties.Resources.������_��ť;
            //    this.neuButton2.BackgroundImage = HIS.Properties.Resources.������_��ť;
            //}
            //else if (System.Configuration.ConfigurationSettings.AppSettings["Theme"] == "2")    //������
            //{
            //    this.BackgroundImage = HIS.Properties.Resources.������_��½����;
                
            //    this.neuButton1.BackgroundImage = HIS.Properties.Resources.������_����;
            //    this.neuButton2.BackgroundImage = HIS.Properties.Resources.������_����;
            //}
            #endregion


            base.OnLoad(e);
        }
    }
}
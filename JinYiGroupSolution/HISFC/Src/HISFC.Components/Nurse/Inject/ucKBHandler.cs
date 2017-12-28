using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse.Inject
{
    public delegate void UpdateSuccessHandler();

    public partial class ucKBHandler : UserControl
    {
        private Neusoft.HISFC.BizLogic.Nurse.InjectManager.KickbackMgr kbManager = new Neusoft.HISFC.BizLogic.Nurse.InjectManager.KickbackMgr();
        private bool isAdd;

        public event UpdateSuccessHandler UpdateEvent;

        /// <summary>
        /// 是否新添加
        /// </summary>
        public bool IsAdd
        {
            get
            {
                return this.isAdd;
            }
            set
            {
                this.isAdd = value;
            }
        }

        public ucKBHandler()
        {
            InitializeComponent();
        }

        private string GetSequenceID()
        {
            try
            {
                return this.kbManager.GetKBSequence();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void ucKBHandler_Load(object sender, EventArgs e)
        {
        }

        //private void ClearForm(Neusoft.HISFC.Models.Nurse.Kickback kb)
        //{
        //    this.tbID.Text = kb.ID;
        //    this.tbID.ReadOnly = true;

        //    this.tbName.Text = kb.Name;
        //    this.tbSpell.Text = kb.SpellCode;
        //    this.tbWb.Text = kb.WBCode;
        //    this.tbUser.Text = kb.UserCode;
        //    this.chkValid.Checked = kb.IsValid;
        //    this.tbMemo.Text = kb.Memo;

        //}

        //private Neusoft.HISFC.Models.Nurse.Kickback GenerateKB()
        //{
        //    Neusoft.HISFC.Models.Nurse.Kickback kb = new Neusoft.HISFC.Models.Nurse.Kickback();
        //    kb.ID = this.tbID.Text;
        //    kb.Name = this.tbName.Text;
        //    kb.SpellCode = this.tbSpell.Text;
        //    kb.WBCode = this.tbWb.Text;
        //    kb.UserCode = this.tbUser.Text;
        //    kb.IsValid = this.chkValid.Checked;
        //    kb.Memo = this.tbMemo.Text;
        //    kb.OperEnv.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID;
        //    kb.OperEnv.Name = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name;
        //    kb.OperEnv.OperTime = this.kbManager.GetDateTimeFromSysDateTime();

        //    return kb;
        //}

        private void ClearForm()
        {
            this.tbID.Text = this.GetSequenceID();
            this.tbID.ReadOnly = true;

            this.tbName.Text = "";
            this.tbSpell.Text = "";
            this.tbWb.Text = "";
            this.tbUser.Text = "";
            this.chkValid.Checked = true;
            this.tbMemo.Text = "";
        }

        private Neusoft.HISFC.Models.Nurse.Kickback GetForm()
        {
            Neusoft.HISFC.Models.Nurse.Kickback kb = new Neusoft.HISFC.Models.Nurse.Kickback();
            kb.ID = this.tbID.Text;
            kb.Name = this.tbName.Text;
            kb.SpellCode = this.tbSpell.Text;
            kb.WBCode = this.tbWb.Text;
            kb.UserCode = this.tbUser.Text;
            kb.Memo = this.tbMemo.Text;
            kb.IsValid = this.chkValid.Checked;
            kb.OperEnv.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID;
            kb.OperEnv.Name = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name;
            kb.OperEnv.OperTime = this.kbManager.GetDateTimeFromSysDateTime();
            return kb;
        }

        /// <summary>
        /// 新增行
        /// </summary>
        /// <param name="kb">实体</param>
        /// <returns>-1失败，1成功</returns>
        private int Insert(Neusoft.HISFC.Models.Nurse.Kickback kb)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.kbManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.kbManager.InsertKBItem(kb) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }

        /// <summary>
        /// 修改行
        /// </summary>
        /// <param name="kb">实体</param>
        /// <returns>-1失败，1成功</returns>
        private int Modify(Neusoft.HISFC.Models.Nurse.Kickback kb)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.kbManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.kbManager.UpdateKBItem(kb) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }

        public void UpdateItem(Neusoft.HISFC.Models.Nurse.Kickback kb)
        {
            this.tbID.Text = kb.ID;
            this.tbID.ReadOnly = true;
            this.tbName.Text = kb.Name;
            this.tbSpell.Text = kb.SpellCode;
            this.tbWb.Text = kb.WBCode;
            this.tbUser.Text = kb.UserCode;
            this.tbMemo.Text = kb.Memo;
        }

        public void InsertItem()
        {
            this.ClearForm();
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            if (this.tbName.Text.Trim().Equals(""))
            {
                return;
            }
            Neusoft.HISFC.BizProcess.Integrate.Manager spell = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            Neusoft.HISFC.Models.Base.ISpell s = spell.Get(this.tbName.Text);
            this.tbSpell.Text = s.SpellCode;
            this.tbWb.Text = s.WBCode;
            this.tbUser.Text = s.UserCode;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.isAdd)
            {
                if (this.Insert(this.GetForm()) == -1)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存失败"));
                    return;
                }
            }
            else
            {
                if (this.Modify(this.GetForm()) == -1)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存失败"));
                    return;
                }
            }

            if (this.UpdateEvent != null)
            {
                this.UpdateEvent();
            }

            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));
            this.ClearForm();

            if (!this.isAdd)
            {
                this.FindForm().Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

    }
}
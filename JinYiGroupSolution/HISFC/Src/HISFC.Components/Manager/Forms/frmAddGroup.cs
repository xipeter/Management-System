using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Forms
{
    public partial class frmAddGroup : Form
    {
        public frmAddGroup()
        {
            InitializeComponent();
        }

        protected Neusoft.HISFC.Models.Admin.SysGroup sysgroup = null;
 
        /// <summary>
        /// OK事件
        /// </summary>
        public event Neusoft.FrameWork.WinForms.Forms.OKHandler OkEvent;

        /// <summary>
        /// 系统组
        /// </summary>
        public Neusoft.HISFC.Models.Admin.SysGroup SysGroup
        {
            set
            {
                
                this.txtParentGroupCode.Text = value.ID;
                this.txtParentGroupName.Text = value.Name;
                this.sysgroup = new Neusoft.HISFC.Models.Admin.SysGroup();
                this.sysgroup.ParentGroup.ID = value.ID;
                this.sysgroup.ParentGroup.Name = value.Name;
                try
                {
                    int i = this.sysgroup.SortID + 1;
                    this.txtSortID.Text = i.ToString();
                }
                catch { }
            }
        }
        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidateValue()
        {
            if (this.txtGroupCode.Text.Trim() == "")
            {
                MessageBox.Show("组别代码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.txtGroupName.Text.Trim() == "")
            {
                MessageBox.Show("组别名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            this.sysgroup.ID = this.txtGroupCode.Text;
            this.sysgroup.Name = this.txtGroupName.Text;
            this.sysgroup.ParentGroup.ID = this.txtParentGroupCode.Text;
            this.sysgroup.ParentGroup.Name = this.txtParentGroupName.Text;
            this.sysgroup.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtSortID.Text);
            //
            //判断主键是否重复。
            //
            if (manager.Get(this.sysgroup) != null)
            {
                MessageBox.Show("已经存在相同的ID组，请选择其他ID!");
                return false;
            }
            return true;
        }

        Neusoft.HISFC.BizLogic.Manager.SysGroup manager = new Neusoft.HISFC.BizLogic.Manager.SysGroup();
        private bool Save()
        {
            if (ValidateValue())
            {
                if (manager.Insert(this.sysgroup) != -1)
                {
                    return true;
                }
                else
                {
                    if (manager.DBErrCode == 1 )//.Err.LastIndexOf("ORA-00001")
                    {
                        MessageBox.Show("此编号已经存在");
                    }
                    else
                    {
                        MessageBox.Show("数据保存失败！" + manager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return false;
                }
            }

            return false;
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Save())
                {
                    this.FindForm().DialogResult = DialogResult.OK;
                    
                    if(OkEvent !=null)    OkEvent(sender,this.sysgroup);
                    
                    this.FindForm().Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.FindForm().DialogResult = DialogResult.Cancel;
                this.FindForm().Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
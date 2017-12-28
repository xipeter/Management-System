using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class frmSelectGroup : Form
    {
        public frmSelectGroup()
        {
            InitializeComponent();
        }
        Neusoft.HISFC.Models.Base.Employee person = null;
        bool isEnterToLogin = false;
        protected override void OnLoad(EventArgs e)
        {

            person = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
            if (person.PermissionGroup == null)
                return;
            this.lvGroup.Items.Clear();
            foreach (Neusoft.FrameWork.Models.NeuObject obj in person.PermissionGroup)
            {
                if (obj.Name.Trim() != "")
                {
                    ListViewItem item = new ListViewItem(obj.Name, 0);
                    item.Text = obj.Name;
                    item.ImageIndex = 0;
                    item.Tag = obj;
                    this.lvGroup.Items.Add(item);
                }
            }

            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager manager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
            //System.Collections.ArrayList alDepts = manager.GetMultiDept(person.ID);
            System.Collections.ArrayList alDepts = manager.GetMultiDeptNew(person.ID);
            this.cmbDept.AddItems(alDepts);
            this.cmbDept.Tag = person.Dept.ID;
            this.lvGroup.Items[0].Selected = true;
            if (person.PermissionGroup.Count <= 1 && alDepts.Count <= 1)
            {
                isEnterToLogin = true;
            }
            base.OnLoad(e);

            this.SetCurrentGroup(person.CurrentGroup, person.Dept);
            
        }
       
        private void neuButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.lvGroup.SelectedItems.Count <= 0)
            {
                person.CurrentGroup = this.lvGroup.Items[0].Tag as Neusoft.FrameWork.Models.NeuObject;
            }
            else
            {
                person.CurrentGroup = this.lvGroup.SelectedItems[0].Tag as Neusoft.FrameWork.Models.NeuObject;
            }
            if (this.cmbDept.Text != "" && this.cmbDept.Tag.ToString() != "")
            {
                person.Dept.ID = this.cmbDept.Tag.ToString();
                person.Dept.Name = this.cmbDept.Text;
                try
                {
                    Neusoft.HISFC.BizLogic.Manager.Department manager = new Neusoft.HISFC.BizLogic.Manager.Department();
                    #region {8A3560B5-9AAD-40fd-B876-3E98BB6B4386}
                    //当登录科室为病区时，病区代码就是选择的病区
                    Neusoft.HISFC.Models.Base.Department mydept = manager.GetDeptmentById(person.Dept.ID);

                    if (mydept.DeptType.ID.ToString() == "N")
                    {
                        person.Nurse.ID = this.cmbDept.Tag.ToString();
                        person.Nurse.Name = this.cmbDept.Text;
                    }
                    else
                    {
                        System.Collections.ArrayList alNurse = manager.GetNurseStationFromDept(person.Dept);
                        if (alNurse != null && alNurse.Count > 0)
                        {
                            person.Nurse = alNurse[0] as Neusoft.FrameWork.Models.NeuObject;
                        }
                    }
                    #endregion
                }
                catch
                {
                }
            }
            foreach (Form f in Program.mainForm.MdiChildren)
            {
                f.Close();
            }
            Program.mainForm.Show();
            Program.mainForm.InitMenu();

            Program.mainForm.Text = "医院信息管理系统   －   " + Program.HosName;

           Neusoft.HISFC.Components.Manager.Classes.Function.HISMonitor();

            this.Close();

        }

        private void lvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isEnterToLogin == true)
                {
                    btnOK_Click(null, null);
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{TAB}");
                }
            }
            if (e.KeyCode==Keys.Up)
            {
                if (lvGroup.SelectedIndices[0]==0)
                {
                    lvGroup.Items[lvGroup.Items.Count - 1].Selected = true;
                    lvGroup.Items[lvGroup.Items.Count - 1].Focused = true;
                    lvGroup.Items[lvGroup.Items.Count - 1].EnsureVisible();
                    e.Handled = true;
                }
            }
            if (e.KeyCode == Keys.Down )
            {
                if (lvGroup.SelectedIndices[0] == lvGroup.Items.Count - 1)
                {
                    lvGroup.Items[0].Selected = true;
                    lvGroup.Items[0].Focused = true;
                    lvGroup.Items[0].EnsureVisible();
                    e.Handled = true;
                }
            }
        }
        

        private void lvGroup_DoubleClick(object sender, EventArgs e)
        {
            this.btnOK_Click(null, null);
        }

        private void frmSelectGroup_Load(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = Program.mainForm.SkinFile;
        }

        internal void SetCurrentGroup(Neusoft.FrameWork.Models.NeuObject currentGroup, Neusoft.FrameWork.Models.NeuObject currentDept)
        {
            if (currentGroup != null)
            {
                foreach (ListViewItem lvItem in this.lvGroup.Items)
                {
                    if (lvItem.Tag != null && (lvItem.Tag as Neusoft.FrameWork.Models.NeuObject).ID == currentGroup.ID)
                    {
                        lvItem.Selected = true;
                        break;
                    }
                }
            }

            if (currentDept != null)
            {
                this.cmbDept.Tag = currentDept.ID;
                this.cmbDept.Text = currentDept.Name;
            }
        }

        private void cmbDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                //{
                //    if (isEnterToLogin == true)
                //    {
                btnOK_Click(null, null);
            //    }
            //    else
            //    {
            //        System.Windows.Forms.SendKeys.Send("{TAB}");
            //    }
            //}
        }


    }
}
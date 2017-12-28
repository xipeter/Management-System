using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    internal partial class ucEmployeeRecord : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 变量

        //人员实体
        private Neusoft.HISFC.Models.Base.Employee myPerson = new Neusoft.HISFC.Models.Base.Employee();

        //人员管理类
        private Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();

        //科室管理类
        private Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();

        //定义人员属性变动管理类
        private Neusoft.HISFC.BizLogic.Manager.EmployeeRecord recordManager = new Neusoft.HISFC.BizLogic.Manager.EmployeeRecord();

        //单条人员属性变动记录
        private Neusoft.HISFC.Models.Base.EmployeeRecord myEmployeeRecord = new Neusoft.HISFC.Models.Base.EmployeeRecord();

        //当前操作是否申请操作
        private bool myIsApply;

        #endregion

        #region 属性

        public bool IsApply
        {
            get 
            { 
                return this.myIsApply; 
            }
            set 
            { 
                this.myIsApply = value; 
            }
        }

        public Neusoft.HISFC.Models.Base.EmployeeRecord EmployeeRecord
        {
            get
            {
                this.myEmployeeRecord.Employee.ID = this.txtEmplCode.Text;              //人员编码
                this.myEmployeeRecord.Employee.Name = this.txtEmplName.Text;              //人员姓名
                this.myEmployeeRecord.ShiftType.ID = this.txtShiftType.Tag.ToString();   //变动类型编码
                this.myEmployeeRecord.ShiftType.Name = this.txtShiftType.Text;           //变动类型名称
                this.myEmployeeRecord.OldData.ID = this.txtOldDataID.Text;            //变动前数据编码
                this.myEmployeeRecord.OldData.Name = this.txtOldDataName.Text;           //变动前数据名称
                this.myEmployeeRecord.NewData.ID = this.txtNewDataID.Text;           //变动后数据编码
                this.myEmployeeRecord.NewData.Name = this.txtNewDataName.Text;           //变动后数据名称
                this.myEmployeeRecord.Memo = this.txtMark.Text;                              //备注
                return myEmployeeRecord;
            }
            set
            {
                this.myEmployeeRecord = value;
                if (this.myEmployeeRecord.Employee.ID == "") return;
                if (this.myEmployeeRecord.ShiftType.ID == "DEPT")
                {
                    this.myEmployeeRecord.ShiftType.Name = "科室变更";
                    this.txtNewDataName.AddItems(deptManager.GetDeptNoNurse());
                }

                this.txtEmplCode.Text = this.myEmployeeRecord.Employee.ID;        //人员编码
                this.txtEmplName.Text = this.myEmployeeRecord.Employee.Name;      //人员姓名
                this.txtShiftType.Tag = this.myEmployeeRecord.ShiftType.ID;   //变动类型编码
                this.txtShiftType.Text = this.myEmployeeRecord.ShiftType.Name; //变动类型名称
                this.txtOldDataID.Text = this.myEmployeeRecord.OldData.ID;    //变动前数据编码
                this.txtOldDataName.Tag = this.myEmployeeRecord.OldData.ID;    //变动前数据编码
                this.txtOldDataName.Text = this.myEmployeeRecord.OldData.Name;    //变动前数据名称
                this.txtNewDataID.Text = this.myEmployeeRecord.NewData.ID;    //变动后数据编码
                this.txtNewDataName.Text = this.myEmployeeRecord.NewData.Name;    //变动后数据名称
                this.txtMark.Text = this.myEmployeeRecord.Memo;                  //备注


            }
        }

        #endregion

        #region 辅助函数

        /// <summary>
        /// 删除人员变动数据
        /// </summary>
        public void Delete()
        {
            //如果没有选中数据，则返回
            if (this.myEmployeeRecord.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择你要取消的专科申请记录"));
                return;
            }
            //验证数据是否允许删除，只有未核准的数据允许删除
            if (this.myEmployeeRecord.State == "1")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该条数据已生效不能删除"));
                return;
            }

            if (MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("确定要删除此记录吗？"), Neusoft.FrameWork.Management.Language.Msg("确认删除"), MessageBoxButtons.YesNo) == DialogResult.No) return;

            //删除人员属性变动记录	
            int parm = recordManager.DeleteEmployeeRecord(this.myEmployeeRecord.ID);
            
            if (parm == -1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(recordManager.Err));
                return;
            }

            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("删除成功！"));
        }


        /// <summary>
        /// 保存人员数据
        /// </summary>
        public void Save()
        {
            //如果变动后名称的tag属性有数据，则将此数据付给变动后的编码
            if (this.txtNewDataName.Tag.ToString() != "")
                this.txtNewDataID.Text = this.txtNewDataName.Tag.ToString();

            //取控件中的数据
            Neusoft.HISFC.Models.Base.EmployeeRecord record = this.EmployeeRecord;
            //验证数据是否有效
            //人员编码
            if (record.Employee.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("人员编码不能为空"));
                return;
            }
            //变动类型
            if (record.ShiftType.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("变动类型不能为空"));
                return;
            }
            //变动前编码
            if (record.OldData.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("变动前编码不能为空"));
                return;
            }
            //变动后编码
            if (record.NewData.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("变动后编码不能为空"));
                return;
            }
            //变动后名称
            if (record.NewData.Name == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("变动后名称不能为空"));
                return;
            }

            if (record.OldData.ID == record.NewData.ID || record.OldData.Name == record.NewData.Name)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("变动前后的数据不能相同"));
                return;
            }


            if (this.myIsApply)
            {
                //科室和护理站变动时需要先申请，后审核
                if (this.myEmployeeRecord.ShiftType.ID == "DEPT" || this.myEmployeeRecord.ShiftType.ID == "NURSE")
                    this.myEmployeeRecord.State = "0";
                else
                    this.myEmployeeRecord.State = "1";
            }
            else
            {
                //核准状态
                this.myEmployeeRecord.State = "1";
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            recordManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            
            //保存变动数据（如果state="1"即核准状态，程序会同时用变动后的数据更新人员基本信息）		

            if (this.myIsApply)//申请
            {
                if (/*recordManager.SetEmployeeRecord(record)*/recordManager.InsertEmployeeRecord(record) != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(recordManager.Err));
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();;
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("转科申请成功"));
            }
            else
            {
                if (recordManager.UpdateEmployeeRecord(record) != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(recordManager.Err));
                    return;
                }
                if( recordManager.Update(record) != 1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(personManager.Err));
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();;
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("确认转科成功"));
            }

            this.FindForm().DialogResult = DialogResult.OK;

        }


        /// <summary>
        /// 根据传入的人员属性变动数组，显示在ListView中
        /// </summary>
        /// <param name="alRecord"></param>
        public void ShowListView(ArrayList alRecord)
        {
            //清空当前的数据
            this.lvEmployeeRecord.Items.Clear();
            ListViewItem lvi = null;
            foreach (Neusoft.HISFC.Models.Base.EmployeeRecord info in alRecord)
            {
                //设置插入的节点信息
                lvi = new ListViewItem();
                lvi.Text = info.Employee.Name;
                lvi.ImageIndex = 0;
                //Tag属性保存摆药单分类实体
                lvi.Tag = info;
                //设置listView的子节点
                lvi.SubItems.Add(info.State == "1" ? Neusoft.FrameWork.Management.Language.Msg("已生效") : Neusoft.FrameWork.Management.Language.Msg("未生效"));       //状态
                lvi.SubItems.Add(info.OldData.ID); //变动前编码
                lvi.SubItems.Add(info.OldData.Name); //变动前名称
                lvi.SubItems.Add(info.NewData.ID); //变动后编码
                lvi.SubItems.Add(info.NewData.Name); //变动后名称
                lvi.SubItems.Add(info.Memo);
                //lvi.SubItems.Add(info.ShiftType.Name);
                lvi.SubItems.Add(Neusoft.FrameWork.Management.Language.Msg("科室变动")); //临时使用
                this.lvEmployeeRecord.Items.Add(lvi);
            }
            if (this.lvEmployeeRecord.Items.Count > 0) this.lvEmployeeRecord.Items[0].Selected = true;
        }


        /// <summary>
        /// 控件初始化
        /// </summary>
        private void Init()
        {
            //根据是否申请操作，设置控件是否可用。申请时可用，审核时不可用。
            if (this.myIsApply)
            {
                this.txtNewDataID.Enabled = true;
                this.txtNewDataName.Enabled = true;
                this.txtMark.Enabled = true;
                this.lblNotice.Visible = false;

                //申请操作只需要看见维护页
                this.neuTabControl1.TabPages.Remove(this.tabPage1);
            }
            else
            {
                this.txtNewDataID.Enabled = false;
                this.txtNewDataName.Enabled = false;
                this.txtMark.Enabled = false;
                this.lblNotice.Visible = true;

                //取本科室待核准的科室变动记录，显示在ListView中。
                ArrayList al = this.recordManager.GetEmployeeRecordList(this.myEmployeeRecord.NewData.ID, this.myEmployeeRecord.ShiftType.ID, "0");
                if (al == null)
                {
                    return;
                }
                this.ShowListView(al);
            }
            if (this.myEmployeeRecord.ShiftType.ID.ToString() == "")
            {

            }
        }

        #endregion

        public ucEmployeeRecord()
        {
            InitializeComponent();
        }

        private void ucEmployeeRecord_Load(object sender, EventArgs e)
        {
            try
            {
                this.Init();
            }
            catch
            {
                
            }
        }

        private void txtNewDataName_Validated(object sender, EventArgs e)
        {
            if (this.txtNewDataName.Tag.ToString() != "")
                this.txtNewDataID.Text = this.txtNewDataName.Tag.ToString();
        }

        private void lvEmployeeRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            //取当前选中的人员变动记录
            if (this.lvEmployeeRecord.SelectedItems.Count == 0)
                this.EmployeeRecord = new Neusoft.HISFC.Models.Base.EmployeeRecord();
            else
                this.EmployeeRecord = this.lvEmployeeRecord.SelectedItems[0].Tag as Neusoft.HISFC.Models.Base.EmployeeRecord;
        }

        private void lvEmployeeRecord_ItemActivate(object sender, EventArgs e)
        {
            if (!this.IsApply)
            {
                this.neuTabControl1.SelectedIndex = 1;
            }
        }

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuTabControl1.SelectedIndex == 1)
            {
                if (this.myEmployeeRecord.State != "0")
                {
                    this.btnOK.Visible = false;
                    this.btnCancel.Visible = false;
                }
                else
                {
                    this.btnOK.Visible = true;
                    this.btnCancel.Visible = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Save();
        }

    }
}

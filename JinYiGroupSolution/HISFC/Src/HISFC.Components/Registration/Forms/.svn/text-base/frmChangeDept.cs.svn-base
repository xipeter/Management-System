using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Registration.Forms
{
    public partial class frmChangeDept : Form
    {
        public event EventHandler ChangeDeptEvent;
        public frmChangeDept()
        {
            InitializeComponent();
            if (this.DesignMode) return;
            this.Init();
        }
        #region 变量
        /// <summary>
        /// 挂号实体
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Register myRegObj = new Neusoft.HISFC.Models.Registration.Register();

        private Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private Neusoft.FrameWork.Management.ControlParam conMgr = new Neusoft.FrameWork.Management.ControlParam();

        ArrayList alDeptOrDoct = new ArrayList();

        bool isUpdateRegDt = false;

        #endregion

        #region 属性
        /// <summary>
        /// 挂号实体
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register MyRegObj
        {
            set
            {
                this.myRegObj = value;
                this.setValue();
            }
            get
            {
                return this.myRegObj;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            //初始化科室
            ArrayList al = new ArrayList();
            al = this.managerMgr.QueryRegDepartment();
            if (al == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("查询科室失败") + this.managerMgr.Err);
                return -1;
            }

            this.cmbDept.AddItems(al);
            //初始化医生
            al = new ArrayList();
            al = this.managerMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (al == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("查询医生失败") + this.managerMgr.Err);
                return -1;
            }
            this.cmbDoct.AddItems(al);

            isUpdateRegDt = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.conMgr.QueryControlerInfo("400031"));

          

            return 1;
        }

        /// <summary>
        /// 界面赋值
        /// </summary>
        private void setValue()
        {
            this.txtCurrentDept.Text = this.myRegObj.DoctorInfo.Templet.Dept.Name;
            this.txtCurrentDoct.Text = this.myRegObj.DoctorInfo.Templet.Doct.Name;
            this.cmbDoct.Tag = this.myRegObj.DoctorInfo.Templet.Doct.ID;
            this.cmbDept.Tag = this.myRegObj.DoctorInfo.Templet.Dept.ID;
        }

        private int Save()
        {
            int returnValue = this.valid();
            if (returnValue < 0)
            {
                return -1;
            }
            Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            Neusoft.FrameWork.Models.NeuObject myObj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject myDeptObj = new Neusoft.FrameWork.Models.NeuObject();

            for (int i = 0; i < this.cmbDoct.alItems.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj = this.cmbDoct.alItems[i] as Neusoft.FrameWork.Models.NeuObject;
                if (obj.ID == this.cmbDoct.Tag.ToString())
                {
                    myObj.ID = obj.ID;
                    myObj.Name = obj.Name;
                    break;
                }

            }

            if (this.cmbDept.SelectedItem != null)
            {
                myDeptObj = this.cmbDept.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
            }

            //if (this.cmbDoct.SelectedItem != null)
            //{
            //    myObj = this.cmbDoct.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
            //}
            //else
            //{
            //    myObj.ID = "";
            //    myObj.Name = "";
            //}

            if (isUpdateRegDt)
            {
                this.myRegObj.DoctorInfo.SeeDate = regMgr.GetDateTimeFromSysDateTime();
            }
            returnValue = regMgr.UpdateDeptAndDoct(this.myRegObj.ID, this.cmbDept.Tag.ToString(), this.cmbDept.Text,
                myObj.ID, myObj.Name,this.myRegObj.DoctorInfo.SeeDate.ToString());
            if (returnValue < 0)
            {
                MessageBox.Show("换科失败！" + regMgr.Err);
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            returnValue=regMgr.CancelTriage(this.myRegObj.ID);
            if (returnValue < 0)
            {
                MessageBox.Show("取消分诊失败！" + regMgr.Err);
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("换科成功！");

            this.alDeptOrDoct.Add(myDeptObj);
            this.alDeptOrDoct.Add(myObj);
            return 1;

        }

        private int valid()
        {
            if (this.cmbDept.Tag == null || this.cmbDept.SelectedItem == null)
            {
                MessageBox.Show("科室不能为空,请选择");
                this.cmbDept.Focus();
                return -1;
            }
            return 1;
        }

        private void frmChangeDept_Load(object sender, EventArgs e)
        {
            //this.Init();
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            int returnValue = this.Save();
            if (returnValue < 0)
            {
                return;
            }
            else
            {
                this.neuButton1.DialogResult = DialogResult.OK;
                if (ChangeDeptEvent != null)
                {
                    this.ChangeDeptEvent(alDeptOrDoct, null);
                }
                this.FindForm().Close();
            }
        }

    }
}
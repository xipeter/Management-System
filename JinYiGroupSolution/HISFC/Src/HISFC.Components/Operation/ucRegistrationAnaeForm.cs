using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Operation;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 麻醉登记单]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucRegistrationAnaeForm : UserControl
    {
        public ucRegistrationAnaeForm()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
            {
                this.InitCtrl();
            }
        }

        #region 字段
        private OperationRecord operationRecord = new OperationRecord();
        private AnaeRecord anaeRecord = new AnaeRecord();
        private Neusoft.HISFC.BizProcess.Interface.Operation.IAnaeFormPrint anaeFormPrint;
        ////{B9DDCC10-3380-4212-99E5-BB909643F11B}
        private Neusoft.FrameWork.Public.ObjectHelper anaeWayHelper = null;
        #endregion

        #region 属性
        /// <summary>
        ///  麻醉单
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AnaeRecord AnaeRecord
        {
            set
            {
                this.Clear();
                if (value == null)
                {

                    return;
                }

                this.anaeRecord = value;
                this.OperationApplication = value.OperationApplication;

                //是否记帐
                this.cmbCharge.Tag = Neusoft.FrameWork.Function.NConvert.ToInt32(value.IsCharged).ToString();

                //麻醉时间
                if (value.AnaeDate != DateTime.MinValue)
                    this.dtpAnaeDate.Value = value.AnaeDate;
                else
                    this.dtpAnaeDate.Value = Environment.AnaeManager.GetDateTimeFromSysDateTime();
                //麻醉效果
                this.cmbAnaeResult.Tag = value.AnaeResult.ID.ToString();
                //是否入PACU
                this.cbxIsPacu.Checked = value.IsPACU;
                //入室时间
                if (value.InPacuDate != DateTime.MinValue)
                    this.dtpInPacuDate.Value = value.InPacuDate;
                else
                    this.dtpInPacuDate.Value = Environment.AnaeManager.GetDateTimeFromSysDateTime().Date;
                //出室时间
                if (value.OutPacuDate != DateTime.MinValue)
                    this.dtpOutPacuDate.Value = value.OutPacuDate;
                else
                    this.dtpOutPacuDate.Value = Environment.AnaeManager.GetDateTimeFromSysDateTime().Date;
                //入室状态
                this.cmbInStatus.Tag = value.InPacuStatus.ID.ToString();
                //出室状态
                this.cmbOutStatus.Tag = value.OutPacuStatus.ID.ToString();
                //是否术后镇痛
                this.cbxIsDemulcent.Checked = value.IsDemulcent;
                //镇痛方式
                this.cmbDemuKind.Tag = value.DemulcentType.ID.ToString();
                //泵型
                this.cmbDemuModel.Tag = value.DemulcentModel.ID.ToString();
                //镇痛天数
                this.txtDemuDays.Text = value.DemulcentDays.ToString();
                //拔管时间
                if (value.PullOutDate != DateTime.MinValue)
                    this.dtpPullOutDate.Value = value.PullOutDate;
                else
                    this.dtpPullOutDate.Value = Environment.AnaeManager.GetDateTimeFromSysDateTime().Date;
                //拔管人
                this.txtPullOutOpcd.Tag = value.PullOutOperator.ID.ToString();
                // this.txtPullOutOpcd.Text = value.PullOutOperator.Name;
                //镇痛效果
                this.cmbDemuResult.Tag = value.DemulcentEffect.ID.ToString();
                this.txtRemark.Text = value.Memo;


                //for (int i = 0; i < value.OperationApplication.RoleAl.Count; i++)
                //{
                //    ArrangeRole role = value.OperationApplication.RoleAl[i] as ArrangeRole;
                //    if (role.RoleType.ID.ToString() == EnumOperationRole.AnaeTmpHelper1.ToString())
                //    {
                //        this.txtTmpHelper1.Text = role.Name;
                //    }
                //    if (role.RoleType.ID.ToString() == EnumOperationRole.AnaeTmpHelper2.ToString()) 
                //    {
                //        this.txtTmpHelper2.Text = role.Name;
                //    }
                //}



            }
        }

        /// <summary>
        ///  新建患者
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OperationAppllication OperationApplication
        {
            set
            {
                this.Clear();

                if (value == null)
                {
                    return;
                }
                this.anaeRecord = new AnaeRecord();
                this.anaeRecord.ExecDept.ID = Environment.OperatorDeptID;
                this.anaeRecord.OperationApplication = value;
                //麻醉方式
                this.cmbAnaeType.Tag = value.AnesType.ID;
                #region 显示患者基本信息
                //住院号/门诊号
                this.txtPatient.Text = value.PatientInfo.PID.ID.ToString();
                //姓名
                this.txtName.Text = value.PatientInfo.Name;
                //性别
                this.txtSex.Text = value.PatientInfo.Sex.Name;
                //出生日期
                this.txtBirthday.Text = value.PatientInfo.Birthday.ToString();
                //科室
                this.txtDept.Text = Environment.GetDept(value.PatientInfo.PVisit.PatientLocation.Dept.ID.ToString()).Name;
                //病床号
                this.txtBedNo.Text = value.PatientInfo.PVisit.PatientLocation.Bed.ID.ToString();
                
                //{B9DDCC10-3380-4212-99E5-BB909643F11B}

                if (anaeWayHelper == null)
                {
                    anaeWayHelper = new Neusoft.FrameWork.Public.ObjectHelper();
                    Neusoft.HISFC.BizProcess.Integrate.Manager mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                    ArrayList al = mgr.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ANESWAY);
                    anaeWayHelper.ArrayObject = al;

                }

                this.lblAnaeWay.Text = this.anaeWayHelper.GetName(value.AnesWay);

                #endregion

                //麻醉人员信息
                this.InitAnaeDoct(value);
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 控件初始化
        /// </summary>
        public void InitCtrl()
        {
            this.Clear();
            this.imageList1.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.R人员));
            //麻醉方式combox
            try
            {
                this.cmbAnaeType.Items.Clear();
                ArrayList alAnaeType = Environment.IntegrateManager.GetConstantList(EnumConstant.ANESTYPE);
                this.cmbAnaeType.AddItems(alAnaeType);
            }
            catch { }
            //麻醉效果combox
            try
            {
                this.cmbAnaeResult.Items.Clear();
                ArrayList alAnaeResult = Environment.IntegrateManager.GetConstantList(EnumConstant.EFFECT);
                this.cmbAnaeResult.AddItems(alAnaeResult);
            }
            catch { }
            //入(PACU)室状态combox
            try
            {
                this.cmbInStatus.Items.Clear();
                ArrayList alInStatus = Environment.IntegrateManager.GetConstantList(EnumConstant.PACUSTATUS);
                this.cmbInStatus.AddItems(alInStatus);
            }
            catch { }
            //出(PACU)室状态combox
            try
            {
                this.cmbOutStatus.Items.Clear();
                ArrayList alOutStatus = Environment.IntegrateManager.GetConstantList(EnumConstant.PACUSTATUS);
                this.cmbOutStatus.AddItems(alOutStatus);
            }
            catch { }
            //镇痛方式
            try
            {
                this.cmbDemuKind.Items.Clear();
                ArrayList alDemuKind = Environment.IntegrateManager.GetConstantList(EnumConstant.DEMUKIND);
                this.cmbDemuKind.AddItems(alDemuKind);
            }
            catch { }
            //泵型
            try
            {
                this.cmbDemuModel.Items.Clear();
                ArrayList alDemuModel = Environment.IntegrateManager.GetConstantList(EnumConstant.DEMUMODEL);
                this.cmbDemuModel.AddItems(alDemuModel);
            }
            catch { }
            //镇痛效果combox
            try
            {
                this.cmbDemuResult.Items.Clear();
                ArrayList alDemuResult = Environment.IntegrateManager.GetConstantList(EnumConstant.EFFECT);
                this.cmbDemuResult.AddItems(alDemuResult);
            }
            catch { }
            //一些标志Combox赋值
            ArrayList alFlag = new ArrayList();
            NeuObject obj = new NeuObject();
            obj.ID = "1";
            obj.Name = "是";
            alFlag.Add(obj.Clone());
            obj.ID = "0";
            obj.Name = "否";
            alFlag.Add(obj.Clone());
            cmbCharge.AddItems((ArrayList)(alFlag.Clone()));		//是否记帐
            Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizLogic.Operation.OpsTableManage opsTable = new Neusoft.HISFC.BizLogic.Operation.OpsTableManage();
            Neusoft.HISFC.Models.Base.Employee objEmp = (Neusoft.HISFC.Models.Base.Employee)opsTable.Operator;
            
            //原来的
            //txtPullOutOpcd.AddItems(managerMgr.QueryEmployeeByDeptID(objEmp.Dept.ID));

            #region donggq--2010.10.04--{C5C20361-3B0F-4f36-AA28-D7861E9236D3}

            ArrayList alPullDoc = managerMgr.QueryEmployeeByDeptID("2600");
            alPullDoc.AddRange(managerMgr.QueryEmployeeByDeptID("2603"));
            txtPullOutOpcd.AddItems(alPullDoc); 


            #endregion
            

            //初始化麻醉科人员列表		
            //this.lvPersons.Dept = this.ParentForm.var.User.Dept.Clone();
            //this.lvPersons.ShowDeptPerson();
            //Neusoft.HISFC.Components.Common.Controls.l
            //this.UcCtrlEnabled(false);
            
            
            //this.lvPersons.DeptID = Environment.OperatorDeptID;

            //this.lvPersons.DeptID = "2600";
            //this.lvPersons.DeptID = "2603";

        }
        /// <summary>
        /// 清空控件中的内容
        /// </summary>
        public void Clear()
        {

            txtPatient.Text = "";
            txtName.Text = "";
            txtSex.Text = "";
            txtBirthday.Text = "";
            txtDept.Text = "";
            txtBedNo.Text = "";
            cmbCharge.SelectedIndex = -1;
            //门诊手术、住院手术标志
            //rdbIn.Visible = false;
            //rdbOut.Visible = false;
            //this.m_objAnaeRec.m_objOpsApp.Pasource = "2";//住院
            DateTime now = Environment.AnaeManager.GetDateTimeFromSysDateTime();

            this.cmbAnaeType.SelectedIndex = -1;
            this.dtpAnaeDate.Value = now;
            this.cmbAnaeResult.SelectedIndex = -1;
            this.cbxIsPacu.Checked = false;
            this.dtpInPacuDate.Value = Environment.AnaeManager.GetDateTimeFromSysDateTime();
            this.dtpOutPacuDate.Value = Environment.AnaeManager.GetDateTimeFromSysDateTime();
            this.cmbInStatus.SelectedIndex = -1;
            this.cmbOutStatus.SelectedIndex = -1;
            this.cbxIsDemulcent.Checked = false;
            this.cmbDemuKind.SelectedIndex = -1;
            this.cmbDemuModel.SelectedIndex = -1;
            this.txtDemuDays.Text = "";
            this.dtpPullOutDate.Value = Environment.AnaeManager.GetDateTimeFromSysDateTime();
            this.txtPullOutOpcd.Text = "";
            this.cmbDemuResult.SelectedIndex = -1;
            this.txtRemark.Text = "";
            this.lvAnaeDoct.Items.Clear();
            this.lvAnaeHelper.Items.Clear();
            this.lvPersons.Refresh();

            this.txtTmpHelper1.Text = string.Empty;
            this.txtTmpHelper2.Text = string.Empty;
        }

        /// <summary>
        /// 初始化麻醉人员信息
        /// </summary>
        /// <param name="myOpsApp"></param>		
        public void InitAnaeDoct(OperationAppllication myOpsApp)
        {
            this.lvAnaeDoct.Items.Clear();
            this.lvAnaeHelper.Items.Clear();

            //添加麻醉角色显示
            foreach (ArrangeRole role in myOpsApp.RoleAl)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = role;
                item.ImageIndex = 0;
                item.Text = role.Name;
                //人员状态：正班、直落、接班等
                try
                {
                    if (role.RoleOperKind.ID != null)
                    {
                        //直落
                        if (role.RoleOperKind.ID.ToString() == EnumRoleOperKind.ZL.ToString())
                            item.Text = item.Text + "|▲";
                        //接班
                        else if (role.RoleOperKind.ID.ToString() == EnumRoleOperKind.JB.ToString())
                            item.Text = item.Text + "|△";
                    }

                    //根据角色编码给不同listView中插入项
                    if (role.RoleType.ID.ToString() == EnumOperationRole.Anaesthetist.ToString())
                    {
                        this.lvAnaeDoct.Items.Add(item);
                        this.lvPersons.RemoveEmployee(role.ID);
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.AnaesthesiaHelper.ToString())//麻醉助手
                    {
                        this.lvAnaeHelper.Items.Add(item);
                        this.lvPersons.RemoveEmployee(role.ID);
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.AnaeTmpHelper1.ToString())
                    {
                        this.txtTmpHelper1.Text = role.Name;
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.AnaeTmpHelper2.ToString())
                    {
                        this.txtTmpHelper2.Text = role.Name;
                    }


                }
                catch { }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="strStatus">操作中状态："NULL"无操作，"RECO"登记，"NEW"补登，"MODIFY"修改</param>
        /// <returns>0 success -1 fail</returns>
        public int Save(OperType operType)
        {
            try
            {
                if (this.GetCtrlInfo() == -1)
                    return -1;
            }
            catch { }
            //数据库事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new
            //    Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);             
            //trans.BeginTransaction();

            Environment.AnaeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            Environment.OperationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //麻醉登记后申请单的两个状态：
            this.anaeRecord.OperationApplication.IsAnesth = true;//已麻醉
            switch (operType)
            {
                case OperType.Reco://登记
                    //增加手术记录
                    if (Environment.AnaeManager.AddAnaeRecord(this.anaeRecord) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("设置麻醉登记记录时发生错误！\n请与系统管理员联系。", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -1;
                    }

                    //更新手术申请单的麻醉标记-------add by sunm
                    if (Environment.OperationManager.DoAnaeRecord(this.anaeRecord.OperationApplication.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新麻醉单信息时发生错误！\n请与系统管理员联系。", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -1;
                    }

                    //将修改过的麻醉登记记录中的手术申请单信息更新
                    if (Environment.OperationManager.UpdateApplication(this.anaeRecord.OperationApplication) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新麻醉单信息时发生错误！\n请与系统管理员联系。", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -1;
                    }
                    break;
                case OperType.New://补登
                    if (this.txtPatient.Text != "")
                    {
                        //增加麻醉记录
                        if (Environment.AnaeManager.AddAnaeRecord(this.anaeRecord) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("增加麻醉登记记录时发生错误！\n请与系统管理员联系。", "提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                        }

                        //增加补登的手术申请记录
                        if (Environment.OperationManager.CreateApplication(this.anaeRecord.OperationApplication) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("补登麻醉申请记录时发生错误！\n请与系统管理员联系。", "提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                        }
                    }
                    break;
                case OperType.Modify:
                    //修改麻醉登记记录
                    if (Environment.AnaeManager.UpdateAnaeRecord(this.anaeRecord) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新麻醉登记记录时发生错误！\n请与系统管理员联系。", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -1;
                    }
                    //将修改过的手术登记记录中的手术申请单信息更新
                    if (Environment.OperationManager.UpdateApplication(this.anaeRecord.OperationApplication) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新麻醉单信息时发生错误！\n请与系统管理员联系。", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -1;
                    }
                    break;
               

            }
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 0;
        }

        /// <summary>
        /// 将界面中显示的信息传入到m_objAnaeRec成员对象中
        /// </summary>
        /// <return>0 success -1 fail</return>
        private int GetCtrlInfo()
        {
            try
            {
                if (this.txtPatient.Text.Trim() == "")
                {
                    MessageBox.Show("请输入手术患者住院号或门诊号！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPatient.Focus();
                    return -1;
                }
                //是否记帐
                if (this.cmbCharge.Tag.ToString() != "")
                    this.anaeRecord.IsCharged = Neusoft.FrameWork.Function.NConvert.ToBoolean(int.Parse(this.cmbCharge.Tag.ToString()));
                //麻醉方式
                this.anaeRecord.OperationApplication.AnesType.ID = this.cmbAnaeType.Tag.ToString();
                this.anaeRecord.OperationApplication.AnesType.Name = this.cmbAnaeType.Text;
                //麻醉时间
                this.anaeRecord.AnaeDate = this.dtpAnaeDate.Value;
                //麻醉效果
                this.anaeRecord.AnaeResult.ID = this.cmbAnaeResult.Tag.ToString();
                this.anaeRecord.AnaeResult.Name = this.cmbAnaeResult.Text;
                //麻醉医师
                ArrayList alRole = new ArrayList();

                foreach (ListViewItem lviAnae in this.lvAnaeDoct.Items)
                {
                    ArrangeRole role = lviAnae.Tag as ArrangeRole;
                    alRole.Add(lviAnae.Tag);
                }
                //麻醉助手
                foreach (ListViewItem lviAnaeHelper in this.lvAnaeHelper.Items)
                {
                    ArrangeRole role = lviAnaeHelper.Tag as ArrangeRole;
                    alRole.Add(lviAnaeHelper.Tag);
                }

                //添加临时麻醉助手1
                string tmpHelper1 = this.txtTmpHelper1.Text;
                if (tmpHelper1 != null && tmpHelper1 != "")
                {
                    ArrangeRole role = new ArrangeRole();
                    role.ID = "777777";
                    role.RoleType.ID = EnumOperationRole.AnaeTmpHelper1;//角色编码
                    role.Name = tmpHelper1;
                    role.OperationNo = this.anaeRecord.OperationApplication.ID;
                    role.ForeFlag = "0";//术前安排				
                    alRole.Add(role);//加入人员角色对象
                }

                //添加临时麻醉助手2
                string tmpHelper2 = this.txtTmpHelper2.Text;
                if (tmpHelper2 != null && tmpHelper2 != "")
                {
                    ArrangeRole role = new ArrangeRole();
                    role.ID = "777777";
                    role.RoleType.ID = EnumOperationRole.AnaeTmpHelper2;//角色编码
                    role.Name = tmpHelper2;
                    role.OperationNo = this.anaeRecord.OperationApplication.ID;
                    role.ForeFlag = "0";//术前安排				
                    alRole.Add(role);//加入人员角色对象
                }

                ArrayList al = new ArrayList();

                //先清空主麻、助手
                for (int i = 0; i < this.anaeRecord.OperationApplication.RoleAl.Count; i++)
                {
                    ArrangeRole role = this.anaeRecord.OperationApplication.RoleAl[i] as ArrangeRole;
                    if (
                        role.RoleType.ID.ToString() != EnumOperationRole.Anaesthetist.ToString() &&
                        role.RoleType.ID.ToString() != EnumOperationRole.AnaesthesiaHelper.ToString() &&
                        role.RoleType.ID.ToString() != EnumOperationRole.AnaeTmpHelper1.ToString() &&
                        role.RoleType.ID.ToString() != EnumOperationRole.AnaeTmpHelper2.ToString()
                        )
                    {
                        al.Add(role.Clone());
                    }
                }

                al.AddRange(alRole);

                this.anaeRecord.OperationApplication.RoleAl = al;


                //是否入PACU
                this.anaeRecord.IsPACU = this.cbxIsPacu.Checked;
                //判断出入PACU室时间的合理性：
                if (this.dtpInPacuDate.Value > this.dtpOutPacuDate.Value)
                {
                    MessageBox.Show("出PACU室时间 不应小于 进PACU室时间", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dtpOutPacuDate.Focus();
                    return -1;
                }
                //入室时间
                this.anaeRecord.InPacuDate = this.dtpInPacuDate.Value;
                //出室时间
                this.anaeRecord.OutPacuDate = this.dtpOutPacuDate.Value;
                //入室状态
                this.anaeRecord.InPacuStatus.ID = this.cmbInStatus.Tag.ToString();
                this.anaeRecord.InPacuStatus.Name = this.cmbInStatus.Text;
                //出室状态
                this.anaeRecord.OutPacuStatus.ID = this.cmbOutStatus.Tag.ToString();
                this.anaeRecord.OutPacuStatus.Name = this.cmbOutStatus.Text;
                //是否镇痛
                this.anaeRecord.IsDemulcent = this.cbxIsDemulcent.Checked;
                //镇痛方式
                this.anaeRecord.DemulcentType.ID = this.cmbDemuKind.Tag.ToString();
                this.anaeRecord.DemulcentType.Name = this.cmbDemuKind.Text;
                //泵型
                this.anaeRecord.DemulcentModel.ID = this.cmbDemuModel.Tag.ToString();
                this.anaeRecord.DemulcentModel.Name = this.cmbDemuModel.Text;
                //镇痛天数
                if (this.txtDemuDays.Text != "")
                    this.anaeRecord.DemulcentDays = int.Parse(this.txtDemuDays.Text);
                //拔管时间
                this.anaeRecord.PullOutDate = this.dtpPullOutDate.Value;
                //拔管人
                if (this.txtPullOutOpcd.Tag != null)
                {
                    this.anaeRecord.PullOutOperator.ID = this.txtPullOutOpcd.Tag.ToString();
                    this.anaeRecord.PullOutOperator.Name = this.txtPullOutOpcd.Text;
                }
                //镇痛效果
                this.anaeRecord.DemulcentEffect.ID = this.cmbDemuResult.Tag.ToString();
                this.anaeRecord.DemulcentEffect.Name = this.cmbDemuResult.Text;
                //备注
                this.anaeRecord.Memo = this.txtRemark.Text;




            }
            catch { return -1; }
            return 0;
        }

        public int Print()
        {
            if (this.anaeFormPrint == null)
            {
                this.anaeFormPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Operation.IAnaeFormPrint)) as Neusoft.HISFC.BizProcess.Interface.Operation.IAnaeFormPrint;
                if (this.anaeFormPrint == null)
                {
                    MessageBox.Show("获得接口IanaeFormPrint错误，请与系统管理员联系。");

                    return -1;
                }
            }
            if (this.GetCtrlInfo() == -1)
                return -1;

            this.anaeFormPrint.AnaeRecord = this.anaeRecord;
            return this.anaeFormPrint.Print();
        }

        public enum OperType
        {
            /// <summary>
            /// 补登
            /// </summary>
            New,
            /// <summary>
            /// 登记
            /// </summary>
            Reco,
            /// <summary>
            /// 修改
            /// </summary>
            Modify,
            /// <summary>
            /// 无操作
            /// </summary>
            Null,
            
           
        }
        #endregion

        private void lvPersons_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item == null)
                return;

            if (e.Button == MouseButtons.Left)
            {

                DragDropEffects dropEffect = (sender as ListView).DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void lvAnaeDoct_DragDrop(object sender, DragEventArgs e)
        {

            ListViewItem item = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;

            if (sender == this.lvAnaeDoct)
            {
                //对象属性赋值
                ArrangeRole myRole = new ArrangeRole(item.Tag as NeuObject);
                //角色对象

                myRole.RoleType.ID = EnumOperationRole.Anaesthetist;//角色编码
                myRole.OperationNo = this.anaeRecord.OperationApplication.ID;
                myRole.ForeFlag = "1";//术后录入			
                item.Tag = myRole;

                this.anaeRecord.OperationApplication.RoleAl.Add(myRole);//加入人员角色对象				
                this.anaeRecord.OperationApplication.User = Neusoft.FrameWork.Management.Connection.Operator as Employee;//操作员
            }
            else if (sender == this.lvAnaeHelper)
            {
                //对象属性赋值
                ArrangeRole myRole = new ArrangeRole(item.Tag as NeuObject);
                //角色对象

                myRole.RoleType.ID = EnumOperationRole.AnaesthesiaHelper;//角色编码
                myRole.OperationNo = this.anaeRecord.OperationApplication.ID;
                myRole.ForeFlag = "1";//术后录入			
                item.Tag = myRole;

                this.anaeRecord.OperationApplication.RoleAl.Add(myRole);//加入人员角色对象				
                this.anaeRecord.OperationApplication.User = Neusoft.FrameWork.Management.Connection.Operator as Employee;//操作员
            }
            else if (sender == this.lvPersons)
            {
                EnumOperationRole role;
                if (item.ListView == this.lvAnaeDoct)
                    role = EnumOperationRole.Anaesthetist;
                else
                    role = EnumOperationRole.AnaesthesiaHelper;

                this.anaeRecord.OperationApplication.RemoveRole((item.Tag as NeuObject).ID, role);
            }

            item.ListView.Items.Remove(item);

            (sender as ListView).Items.Add(item);
        }

        private void lvAnaeDoct_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
}

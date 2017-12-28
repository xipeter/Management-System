using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.HISFC.Models.Operation;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using System.Collections;

namespace Neusoft.HISFC.Components.Operation
{
 
    public partial class ucRegistrationQuick :  Neusoft.FrameWork.WinForms.Controls.ucBaseControl 
    {

        private OperationRecord record;
        private OperationAppllication apply;
        private Neusoft.HISFC.BizLogic.Operation.OpsTableManage opsTableMgr;
        private Neusoft.HISFC.Models.Base.Employee currentOperator;

        public ucRegistrationQuick()
        {
            InitializeComponent();

            record = new OperationRecord();
            apply = new OperationAppllication();
            opsTableMgr = new Neusoft.HISFC.BizLogic.Operation.OpsTableManage();

            InitControl();
        }

        public OperationAppllication OperationApplication
        {
            set
            {
                apply = value;
                this.record.OperationAppllication = apply;


                if (apply.PatientInfo.ID.Length == 0)
                {
                    MessageBox.Show("传入申请单为空!", "提示");
                    return;
                }


                #region 赋值

                this.lbName.Text = apply.PatientInfo.Name;//姓名
                this.lbPatient.Text = apply.PatientInfo.PID.PatientNO;//住院号

                Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = Environment.RadtManager.GetPatientInfomation(apply.PatientInfo.ID);
                if (patientInfo == null || patientInfo.ID.Length == 0)
                {
                    MessageBox.Show("无此患者信息!", "提示");
                    return;
                }

                this.dtBeginDate.Value = apply.PreDate;//手术开始时间
                this.dtEndDate.Value = System.DateTime.Now;//手术结束时间


                this.cmbDoctor.Tag = apply.OperationDoctor.ID;//手术者

                #region 助手

                foreach (ArrangeRole role in apply.RoleAl)
                {
                    if (role.RoleType.ID.ToString() == EnumOperationRole.Helper1.ToString())
                    {
                        this.cmbHelper1.Tag = role.ID;//一助
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.Helper2.ToString())
                    {
                        this.cmbHelper2.Tag = role.ID;//二助
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.WashingHandNurse.ToString())
                    {
                        if (this.cmbWash1.Tag == null || this.cmbWash1.Tag.ToString() == "")
                        {
                            this.cmbWash1.Tag = role.ID;//洗手护士1
                        }
                        else if (this.cmbWash2.Tag == null || this.cmbWash2.Tag.ToString() == "")
                        {
                            this.cmbWash2.Tag = role.ID;//洗手护士2
                        }
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.ItinerantNurse.ToString())
                    {
                        if (this.cmbXH1.Tag == null || this.cmbXH1.Tag.ToString() == "")
                        {
                            this.cmbXH1.Tag = role.ID;//巡回护士1
                        }
                        else if (this.cmbXH2.Tag == null || this.cmbXH2.Tag.ToString() == "")
                        {
                            this.cmbXH2.Tag = role.ID;//巡回护士2
                        }
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpHelper1.ToString())
                    {
                        if (this.txtTmpHelper1.Tag == null || this.txtTmpHelper1.Tag.ToString() == "")
                        {
                            this.txtTmpHelper1.Tag = role.ID;
                            this.txtTmpHelper1.Text = role.Name;
                        }

                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpHelper2.ToString())
                    {
                        if (this.txtTmpHelper2.Tag == null || this.txtTmpHelper2.Tag.ToString() == "")
                        {
                            this.txtTmpHelper2.Tag = role.ID;
                            this.txtTmpHelper2.Text = role.Name;
                        }

                    }
                    #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpStudent1.ToString())
                    {
                        if (this.txtTmpStudent1.Tag == null || this.txtTmpStudent1.Tag.ToString() == "")
                        {
                            this.txtTmpStudent1.Tag = role.ID;
                            this.txtTmpStudent1.Text = role.Name;
                        }

                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpStudent2.ToString())
                    {
                        if (this.txtTmpStudent2.Tag == null || this.txtTmpStudent2.Tag.ToString() == "")
                        {
                            this.txtTmpStudent2.Tag = role.ID;
                            this.txtTmpStudent2.Text = role.Name;
                        }

                    } 
                    #endregion
                }

                #endregion

                //手术规模
                if (string.IsNullOrEmpty(apply.OperationType.ID))
                {
                    this.cmbOpType.SelectedIndex = 0;
                }
                else
                {
                    this.cmbOpType.Tag = apply.OperationType.ID;
                }

                //手术分类
                if (this.cmbOperKind.Items.Count>=3)
                {
                    this.cmbOperKind.SelectedIndex = 2;
                }
                //else
                //{
                //    this.cmbOperKind.Tag = apply.OperateKind;
                //}

                //切口类型
                if (string.IsNullOrEmpty(this.record.OperationAppllication.InciType.ID)) 
                {
                    this.cmbIncityep.SelectedIndex = 1;
                }
                else
                {
                    this.cmbIncityep.Tag = this.record.OperationAppllication.InciType.ID;
                }

                #endregion

                comDept.Tag = this.record.OperationAppllication.OperationDoctor.Dept.ID;


            }
        }

        public void InitControl()
        {
            currentOperator = (Neusoft.HISFC.Models.Base.Employee)opsTableMgr.Operator;

            //手术规模
            ArrayList altype = Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.OPERATETYPE);
            if (altype == null)
            {
                altype = new ArrayList();
            }

            this.cmbOpType.AddItems(altype);
            //if (altype.Count >= 3) 
            //{
            //    this.cmbOpType.Tag = (altype[0] as NeuObject).ID;
            //}

            this.cmbOpType.IsListOnly = true;

            //手术分类
            ArrayList alKind = Environment.IntegrateManager.GetConstantList("OPERATEKIND");
            if (alKind == null)
            {
                alKind = new ArrayList();
            }
            this.cmbOperKind.AddItems(alKind);
            //if (alKind.Count >= 3) 
            //{
            //    this.cmbOperKind.Tag = (alKind[2] as NeuObject).ID;
            //}
            this.cmbOperKind.IsListOnly = true;

            //切口类型
            ArrayList alInci = Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.INCITYPE);
            if (alInci == null)
            {
                alInci = new ArrayList();
            }
            this.cmbIncityep.AddItems(alInci);
            //if (alInci.Count>= 3) 
            //{
            //    this.cmbIncityep.Tag = (alInci[1] as NeuObject).ID;
            //}
            this.cmbIncityep.IsListOnly = true;


            //加载科室
            ArrayList alDept = Environment.IntegrateManager.QueryDeptmentsInHos(true);
            if (alDept == null)
            {
                alDept = new ArrayList();
            }
            this.comDept.AddItems(alDept);


            //
            ArrayList alDoc = Environment.IntegrateManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (alDoc == null) 
            {
                alDoc = new ArrayList();
            }

            //医生术者
            this.cmbDoctor.AddItems(alDoc);
            this.cmbDoctor.IsListOnly = true;

            //一助
            this.cmbHelper1.AddItems(alDoc);
            this.cmbHelper1.IsListOnly = true;

            //二助
            this.cmbHelper2.AddItems(alDoc);
            this.cmbHelper2.IsListOnly = true;


            //护士
            ArrayList alNurse = Environment.IntegrateManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.N, currentOperator.Dept.ID);
            if (alNurse == null) 
            {
                alNurse = new ArrayList(); 
            } 
            
            //巡回1
            this.cmbXH1.AddItems(alNurse);
            this.cmbXH1.IsListOnly = true;

            //巡回2
            this.cmbXH2.AddItems(alNurse);
            this.cmbXH2.IsListOnly = true;

            //洗手1
            this.cmbWash1.AddItems(alNurse);
            this.cmbWash1.IsListOnly = true;

            //洗手2
            this.cmbWash2.AddItems(alNurse);
            this.cmbWash2.IsListOnly = true;

           

        }

        private string Conobj(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 有效性验证
        /// </summary>
        /// <returns></returns>
        private int Valid()
        {

            if (dtBeginDate.Value > dtEndDate.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间");
                dtBeginDate.Focus();
                return -1;
            }

            if (this.cmbDoctor.Tag == null || this.cmbDoctor.Tag.ToString() == "")
            {
                MessageBox.Show("术者不能为空!", "提示");
                cmbDoctor.Focus();
                return -1;
            }

            if (this.comDept.Tag == null || this.comDept.Tag.ToString() == "" || this.comDept.Text.Trim() == "")
            {
                MessageBox.Show("术者科室不能为空");
                comDept.Focus();
                return -1;
            }

            if (this.cmbOpType.Tag == null || this.cmbOpType.Tag.ToString() == "")
            {
                MessageBox.Show("手术规模不能为空!", "提示");
                cmbOpType.Focus();
                return -1;
            }


            if (this.cmbHelper1.Tag == null || this.cmbHelper1.Tag.ToString() == "")
            {
                MessageBox.Show("一助不能为空!", "提示");
                return -1;
            }

            if (cmbXH1.Tag == null || string.IsNullOrEmpty(cmbXH1.Tag.ToString()))
            {
                MessageBox.Show("巡回一不能为空!", "提示");
                return -1;
            }

            string XH1 = Conobj(cmbXH1.Tag); //巡回护士
            string XH2 = Conobj(cmbXH2.Tag); //巡回护士
            if (XH1 == XH2 && XH1 != "")
            {
                MessageBox.Show("巡回护士不能重复");
                cmbXH2.Focus();
                return -1;
            }

            string Helper1 = Conobj(cmbHelper1.Tag); //一助
            string Helper2 = Conobj(cmbHelper2.Tag); //一助
            if (Helper1 == Helper2 && Helper1 != "")
            {
                MessageBox.Show("助手不能重复");
                cmbHelper2.Focus();
                return -1;
            }

            string Wash1 = Conobj(cmbWash1.Tag); //洗手1
            string Wash2 = Conobj(cmbWash2.Tag); //洗手2

            if (Wash1==Wash2 && Wash1!="")
            {
                MessageBox.Show("洗手护士不能重复");
                cmbWash2.Focus();
                return -1;
            }

            if ((!string.IsNullOrEmpty(txtTmpHelper1.Text)) && (!string.IsNullOrEmpty(txtTmpHelper2.Text)))
            {
                if (txtTmpHelper1.Text == txtTmpHelper2.Text)
                {
                    MessageBox.Show("临时助手不能重复!", "提示");
                    return -1;
                }
            }

            #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
            if ((!string.IsNullOrEmpty(txtTmpStudent1.Text)) && (!string.IsNullOrEmpty(txtTmpStudent2.Text)))
            {
                if (txtTmpStudent1.Text == txtTmpStudent2.Text)
                {
                    MessageBox.Show("进修人员不能重复!", "提示");
                    return -1;
                }
            } 
            #endregion

            return 0;
        }


        /// <summary>
        /// 实体赋值
        /// </summary>
        /// <returns></returns>
        private int GetValue()
        {
            //this.record.OperationAppllication.ID = Environment.OperationManager.GetNewOperationNo();

            this.record.OpsDate = this.dtBeginDate.Value;//开始时间 
            this.record.OutDate = this.dtEndDate.Value;//结束时间 
            
            this.record.OperationAppllication.OperationDoctor.Dept = Environment.IntegrateManager.GetEmployeeInfo(cmbDoctor.Tag.ToString()).Dept;
            this.record.OperationAppllication.OperationDoctor.Dept.ID = this.comDept.Tag.ToString();
            
            ArrayList roleArrayList = new ArrayList();

            for (int i = 0; i < this.record.OperationAppllication.RoleAl.Count; i++)
            {
                ArrangeRole tmprole = this.record.OperationAppllication.RoleAl[i] as ArrangeRole;
                #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
                if (
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.Operator.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.Helper1.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.Helper2.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.WashingHandNurse.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.ItinerantNurse.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.TmpHelper1.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.TmpHelper2.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.TmpStudent1.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.TmpStudent2.ToString()
                            )
                {
                    roleArrayList.Add(tmprole);
                } 
                #endregion
            }

            this.record.OperationAppllication.RoleAl.Clear();

            #region 手术医生

            ArrangeRole role = new ArrangeRole();
            role.OperationNo = this.record.OperationAppllication.ID;//申请号
            role.ID = this.cmbDoctor.Tag.ToString();//人员代码
            role.Name = this.cmbDoctor.Text;
            role.RoleType.ID = EnumOperationRole.Operator;//角色编码
            role.ForeFlag = "1";//术后录入
            roleArrayList.Add(role);

            this.record.OperationAppllication.OperationDoctor.ID = role.ID;
            this.record.OperationAppllication.OperationDoctor.Name = role.Name;
           
            #endregion

            //第一诊断
            if (this.record.OperationAppllication.DiagnoseAl.Count > 0)
            {
                this.record.BloodPressureIn= (record.OperationAppllication.DiagnoseAl[0] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ICD10.Name;//诊断
            }

            #region 助手

            //一助
            role = new ArrangeRole();
            role.OperationNo = this.record.OperationAppllication.ID;//申请号
            role.ID = this.cmbHelper1.Tag.ToString();//人员代码
            role.Name = this.cmbHelper1.Text;
            role.RoleType.ID = EnumOperationRole.Helper1;//角色编码
            role.ForeFlag = "1";//术后录入
            roleArrayList.Add(role);

            this.record.OperationAppllication.HelperAl.Clear();
            this.record.OperationAppllication.HelperAl.Add(role);
            
            //二助
            if (this.cmbHelper2.Tag != null && this.cmbHelper2.Tag.ToString() != "")
            {
                role = new ArrangeRole();
                role.OperationNo = this.record.OperationAppllication.ID;//申请号
                role.ID = this.cmbHelper2.Tag.ToString();//人员代码
                role.Name = this.cmbHelper2.Text;
                role.RoleType.ID = EnumOperationRole.Helper2;//角色编码
                role.ForeFlag = "1";//术后录入
                roleArrayList.Add(role);

                this.record.OperationAppllication.HelperAl.Add(role);
            }

            if (!string.IsNullOrEmpty(txtTmpHelper1.Text))
            {
                role = new ArrangeRole();
                role.OperationNo = this.record.OperationAppllication.ID;//申请号
                role.ID = "888888";//人员代码
                role.Name = this.txtTmpHelper1.Text;
                role.RoleType.ID = EnumOperationRole.TmpHelper1.ToString();//角色编码
                role.ForeFlag = "1";//术后录入
                roleArrayList.Add(role);
            }

            if (!string.IsNullOrEmpty(txtTmpHelper2.Text))
            {
                role = new ArrangeRole();
                role.OperationNo = this.record.OperationAppllication.ID;//申请号
                role.ID = "888888";//人员代码
                role.Name = this.txtTmpHelper2.Text;
                role.RoleType.ID = EnumOperationRole.TmpHelper2.ToString();//角色编码
                role.ForeFlag = "1";//术后录入
                roleArrayList.Add(role);
            }

            #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
            if (!string.IsNullOrEmpty(txtTmpStudent1.Text))
            {
                role = new ArrangeRole();
                role.OperationNo = this.record.OperationAppllication.ID;//申请号
                role.ID = "888888";//人员代码
                role.Name = this.txtTmpStudent1.Text;
                role.RoleType.ID = EnumOperationRole.TmpStudent1.ToString();//角色编码
                role.ForeFlag = "1";//术后录入
                //this.operationRecord.OperationAppllication.RoleAl.Add(role);

                //this.operationRecord.OperationAppllication.HelperAl.Add(role);
                roleArrayList.Add(role);
            }

            if (!string.IsNullOrEmpty(txtTmpStudent2.Text))
            {
                role = new ArrangeRole();
                role.OperationNo = this.record.OperationAppllication.ID;//申请号
                role.ID = "888888";//人员代码
                role.Name = this.txtTmpStudent2.Text;
                role.RoleType.ID = EnumOperationRole.TmpStudent2.ToString();//角色编码
                role.ForeFlag = "1";//术后录入
                //this.operationRecord.OperationAppllication.RoleAl.Add(role);

                //this.operationRecord.OperationAppllication.HelperAl.Add(role);
                roleArrayList.Add(role);
            }
            
            #endregion

            #endregion 
            
            #region 巡回护士

            if (this.cmbXH1.Tag != null && this.cmbXH1.Tag.ToString() != "")
            {
                this.record.OperationAppllication.AddRole(this.cmbXH1.Tag.ToString(), this.cmbXH1.Text, "1",
                    EnumOperationRole.ItinerantNurse);
            }
            if (this.cmbXH2.Tag != null && this.cmbXH2.Tag.ToString() != "")
            {
                this.record.OperationAppllication.AddRole(this.cmbXH2.Tag.ToString(), this.cmbXH2.Text, "1",
                    EnumOperationRole.ItinerantNurse);
            }

            #endregion

            #region 洗手护士

            if (this.cmbWash1.Tag != null && this.cmbWash1.Tag.ToString() != "")
            {
                this.record.OperationAppllication.AddRole(this.cmbWash1.Tag.ToString(), this.cmbWash1.Text, "1",
                    EnumOperationRole.WashingHandNurse);
            }

            if (this.cmbWash2.Tag != null && this.cmbWash2.Tag.ToString() != "")
            {
                this.record.OperationAppllication.AddRole(this.cmbWash2.Tag.ToString(), this.cmbWash2.Text, "1",
                    EnumOperationRole.WashingHandNurse);
            }

            #endregion
            
            this.record.OperationAppllication.RoleAl.AddRange(roleArrayList);

            //手术规模
            this.record.OperationAppllication.OperationType.ID = this.cmbOpType.Tag.ToString();
            //手术分类
            this.record.OperationAppllication.OperateKind = System.Convert.ToString(this.cmbOperKind.SelectedItem.ID);
            //切口类型
            this.record.OperationAppllication.InciType.ID = this.cmbIncityep.Tag.ToString();
            
            //是否感染
            this.record.IsInfected = this.cbxInfect.Checked;
            //是否有菌
            this.record.OperationAppllication.IsGermCarrying = this.cbxGerm.Checked;

            this.record.OperationAppllication.IsFinished = true;
            this.record.OperationAppllication.PatientInfo.Weight = "0";//体重
            this.record.OperationAppllication.ExecStatus = "4";//登记完成
           
            return 0;
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            try
            {
                //验证
                if (Valid() == -1)
                {
                    return -1;
                }

                //赋值
                if (this.GetValue() == -1)
                {
                    return -1;
                }

                //数据库事务
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                Environment.OperationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                Environment.RecordManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                int UpdateApplication = 0;

                //获取数据库系统时间，使手术登记和病案登记的操作时间相一致。——Add By Maokb
                DateTime inTime;
                inTime = Environment.OperationManager.GetDateTimeFromSysDateTime();
                this.record.OperDate = inTime;

                try
                {
                    #region 插入手术登记表

                    if (Environment.RecordManager.AddOperatorRecord(this.record) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Environment.RecordManager.Err, "提示");
                        return -1;
                    }
                    
                    #endregion
                    
                    #region 更新手术申请表状态

                    UpdateApplication = Environment.OperationManager.DoOperatorRecord(this.record.OperationAppllication.ID);
                    if (UpdateApplication == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Environment.OperationManager.Err, "提示");
                        return -1;
                    }
                    if (UpdateApplication == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("该申请单状态已经改变,请刷新屏幕重新录入!", "提示");
                        return -1;
                    } 

                    #endregion
                    
                    #region 登记手术项目

                    if (Environment.OperationManager.DelOperationInfo(this.record.OperationAppllication) == -1)//删除手术项目
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Environment.OperationManager.Err, "提示");
                        return -1;
                    }
                    //针对本申请单中涉及到的手术添加手术项目信息
                    foreach (OperationInfo OperateInfo in this.record.OperationAppllication.OperationInfos)
                    {
                        //添加手术项目信息
                        if (Environment.OperationManager.AddOperationInfo(this.record.OperationAppllication, OperateInfo) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Environment.OperationManager.Err, "提示");
                            return -1;
                        }
                    }

                    #endregion

                    #region 登记人员信息

                    if (Environment.OperationManager.ProcessRoleForApply(this.record.OperationAppllication) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Environment.OperationManager.Err, "提示");
                        return -1;
                    }

                    #endregion

                    Neusoft.FrameWork.Management.PublicTrans.Commit();

                }
                catch (Exception e)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(e.Message, "提示");
                    return -1;
                }

                MessageBox.Show("登记成功!", "提示");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        #region 按键顺序

        private void dtBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtEndDate.Focus();
            }
        }

        private void dtEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDoctor.Focus();
            }
        }

        private void cmbDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comDept.Focus();
            }
        }

        private void comDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbOpType.Focus();
            }
        }

        private void cmbOpType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbOperKind.Focus();
            }
        }

        private void cmbOperKind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbIncityep.Focus();
            }
        }

        private void cbxInfect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbxGerm.Focus();
            }
        }

        private void cbxGerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.cmbHelper1.Focus();
            }
        }
        private void cmbHelper1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHelper2.Focus();
            }
        }

        private void cmbHelper2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbXH1.Focus();
            }
        }

        private void cmbXH1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbXH2.Focus();
            }
        }

        private void cmbXH2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWash1.Focus();
            }
        }

        private void cmbWash1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbWash2.Focus();
            }
        }

        private void cmbWash2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTmpHelper1.Focus();
            }
        }

        private void txtTmpHelper1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtTmpHelper2.Focus();
            }
        }

        private void txtTmpHelper2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOk.Focus();
            }
        }


        
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Save() >= 0)
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

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
    /// [功能描述: 手术登记单]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucRegistrationForm : UserControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucRegistrationForm()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
            {
                this.InitControl();
                this.Clear();
            }
        }

        #region 字段

        /// <summary>
        /// 当前操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee currentOperator = new Employee(); 

        private OperationRecord operationRecord = new OperationRecord();
        /// <summary>
        /// 手术申请或登记科室
        /// </summary>
        //private string dept;
        /// <summary>
        /// 是否新录入
        /// </summary>
        public bool IsNew = true;
        /// <summary>
        /// 是否补录
        /// </summary>
        private bool isRenew = false;

        private bool isCancled = false;
        private Neusoft.HISFC.BizProcess.Interface.Operation.IRecordFormPrint recordFormPrint;
        Neusoft.FrameWork.Public.ObjectHelper employHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.HISFC.BizLogic.Operation.OpsTableManage opsTableMgr = new Neusoft.HISFC.BizLogic.Operation.OpsTableManage();
        Neusoft.HISFC.BizProcess.Integrate.Operation.OpsDiagnose opsDiagnose = new Neusoft.HISFC.BizProcess.Integrate.Operation.OpsDiagnose();
       
        
        
        #endregion

        #region 属性

        /// <summary>
        /// 手术是否已被取消
        /// </summary>
        public bool IsCancled
        {
            set
            {
                isCancled = value;
            }
        }
        /// <summary>
        /// 是否是手工登记手术 
        /// </summary>
        public bool HandInput
        {
            get
            {
                return isRenew;
            }
            set
            {
                try
                {
                    this.Clear();
                    isRenew = value;
                    this.SetEnable(isRenew);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                this.Clear();//清空
                if (this.IsNew)
                    this.operationRecord = new OperationRecord();

                OperationAppllication apply = value;

                if (apply.PatientInfo.ID.Length == 0)
                {
                    MessageBox.Show("传入申请单为空!", "提示");
                    return;
                }
                #region 赋值
                this.lbName.Text = apply.PatientInfo.Name;//姓名
                this.lbSex.Text = apply.PatientInfo.Sex.Name;//性别

                //int age = Environment.OperationManager.GetDateTimeFromSysDateTime().Year - apply.PatientInfo.Birthday.Year;
                //if (age == 0)
                //    age = 1;
                this.lbAge.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(apply.PatientInfo.Birthday);//age.ToString() + "岁";//年龄

                this.lbPatient.Text = apply.PatientInfo.PID.PatientNO;//住院号

                Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = Environment.RadtManager.GetPatientInfomation(apply.PatientInfo.ID);
                if (patientInfo == null || patientInfo.ID.Length == 0)
                {
                    MessageBox.Show("无此患者信息!", "提示");
                    return;
                }
                #region 结算类别

                NeuObject kind = Environment.GetPayKind(patientInfo.Pact.PayKind.ID);
                if (kind == null)
                    this.lbPaykind.Text = patientInfo.Pact.PayKind.ID;
                else
                    this.lbPaykind.Text = kind.Name;
                #endregion
                //by zlw 2006-5-24 取手术申请科室
                this.lbDept.Text = apply.PatientInfo.PVisit.PatientLocation.Dept.Name;
                this.lbDept.Tag = apply.PatientInfo.PVisit.PatientLocation.Dept.ID;
                //this.lbDept.Tag = this.operationRecord.OperationAppllication.PatientInfo.PVisit.PatientLocation.Dept.ID;
                //			this.lbDept.Text=p.PVisit.PatientLocation.Dept.Name;//住院科室
                this.lbBed.Text = apply.PatientInfo.PVisit.PatientLocation.Bed.ID;//床号
                this.lbFree.Text = patientInfo.FT.LeftCost.ToString();//余额
                this.lbOpsDept.Text = apply.ExeDept.Name;//手术室
                
                //#region 台类型
                //if (apply.TableType == "1")
                //{
                //    this.lbTableType.Text = "正台";
                //}//正台
                //else if (apply.TableType == "2")
                //{
                //    this.lbTableType.Text = "加台";
                //}//加台
                //else
                //{
                //    this.lbTableType.Text = "点台";
                //}//点台
                //#endregion
                
                
                this.lbOpsDept.Text = Environment.GetDept(apply.ExeDept.ID).Name;//手术室
                lbOpsDept.Tag = apply.ExeDept.ID;//科室编码
                neuLabel27.Tag = apply.ApplyDoctor.ID;
                this.lbApplyDoct.Text = employHelper.GetName(apply.ApplyDoctor.ID);//申请医生
                this.lbPreDate.Text = apply.PreDate.Date.ToString("yyyy-MM-dd");//预定手术时间
                #region 诊断
                // TODO: 添加诊断
                if (apply.DiagnoseAl.Count > 0)
                {
                    this.txtDiag.Text = (apply.DiagnoseAl[0] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ICD10.Name;//诊断
                    this.txtDiag.Tag = (apply.DiagnoseAl[0] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ICD10;//诊断

                    if (apply.DiagnoseAl.Count > 1)
                    {
                        this.txtDiag2.Text = (apply.DiagnoseAl[1] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ICD10.Name;//诊断
                        this.txtDiag2.Tag = (apply.DiagnoseAl[1] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ICD10;//诊断
                        if (apply.DiagnoseAl.Count > 2)
                        {
                            this.txtDiag3.Text = (apply.DiagnoseAl[2] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ICD10.Name;//诊断
                            this.txtDiag3.Tag = (apply.DiagnoseAl[2] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ICD10;//诊断
                        }
                    }
                }

                #endregion
                #region 麻醉方式
                if (apply.AnesType.ID != null && apply.AnesType.ID != "")
                {
                    NeuObject obj = Environment.GetAnes(apply.AnesType.ID);
                    if (obj != null)
                    {
                        this.lbAnae.Text = obj.Name;
                        this.lbAnae.Tag = obj.ID;
                    }
                }
                #endregion
                #region 手术名称
                if (apply.OperationInfos.Count > 0)
                {
                    this.txtOperation.Text = (apply.OperationInfos[0] as OperationInfo).OperationItem.Name;
                    this.txtOperation.Tag = (OperationInfo)apply.OperationInfos[0];

                    if (apply.OperationInfos.Count > 1)
                    {
                        this.txtOperation2.Text = (apply.OperationInfos[1] as OperationInfo).OperationItem.Name;
                        this.txtOperation2.Tag = (OperationInfo)apply.OperationInfos[1];
                        if (apply.OperationInfos.Count > 2)
                        {
                            this.txtOperation3.Text = (apply.OperationInfos[2] as OperationInfo).OperationItem.Name;
                            this.txtOperation3.Tag = (OperationInfo)apply.OperationInfos[2];
                        }
                    }
                }
                #endregion

                if (this.isCancled==false && this.IsNew==false && this.HandInput==false)
                {
                    this.dtBeginDate.Value = this.operationRecord.OpsDate;
                }
                else 
                {
                    this.dtBeginDate.Value = apply.PreDate;//手术开始时间
                }
                this.dtEndDate.Value = System.DateTime.Now;
                this.cmbRoom.Tag = apply.RoomID;//房号
                ArrayList al = Environment.TableManager.GetOpsTable(apply.RoomID);
                if (al == null)
                {
                    MessageBox.Show("获取房间" + apply.RoomID + "内的手术台号出错");
                }
                this.cmbOrder.Items.Clear();
                this.cmbOrder.AddItems(al);

                this.cmbOrder.Tag = apply.OpsTable.ID;//台序

                this.cmbDoctor.Tag = apply.OperationDoctor.ID;//手术者
                #region 护士
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
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.Helper3.ToString())
                    {
                        this.cmbHelper3.Tag = role.ID;//三助
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.WashingHandNurse.ToString())
                    {
                        if (this.cmbWash1.Tag == null || this.cmbWash1.Tag.ToString() == "")
                        {
                            this.cmbWash1.Tag = role.ID;
                        }//洗手护士}
                        else if (this.cmbWash2.Tag == null || this.cmbWash2.Tag.ToString() == "")
                        {
                            this.cmbWash2.Tag = role.ID;
                        }
                        else if (this.cmbWash3.Tag == null || this.cmbWash3.Tag.ToString() == "")
                        {
                            this.cmbWash3.Tag = role.ID;
                        }
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.ItinerantNurse.ToString())
                    {
                        if (this.cmbXH1.Tag == null || this.cmbXH1.Tag.ToString() == "")
                        {
                            this.cmbXH1.Tag = role.ID;
                        }//巡回护士
                        else if (this.cmbXH2.Tag == null || this.cmbXH2.Tag.ToString() == "")
                        {
                            this.cmbXH2.Tag = role.ID;
                        }
                        else if (this.cmbXH3.Tag == null || this.cmbXH3.Tag.ToString() == "")
                        {
                            this.cmbXH3.Tag = role.ID;
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
                this.cmbOpType.Tag = apply.OperationType.ID;
                //手术分类
                this.cmbOperKind.Tag = apply.OperateKind;

                //if ( == "1")
                //{ this.cmbOperKind.SelectedIndex = 0; }//普通
                //else if (apply.OperateKind == "2")
                //{ this.cmbOperKind.SelectedIndex = 1; }//急诊
                //else
                //{
                //    this.cmbOperKind.SelectedIndex = 0;//感染
                //    this.cbxInfect.Checked = true;
                //}
                 
                this.rtbApplyNote.Text = apply.ApplyNote; 
                #endregion

                this.operationRecord.OperationAppllication = apply;
                comDept.Tag = this.operationRecord.OperationAppllication.OperationDoctor.Dept.ID;
                //this.IsNew = true;//新增 


                this.isRenew = false;
                this.ucDiag1.Visible = false;
                this.ucOpItem1.Visible = false;
                //{B9DDCC10-3380-4212-99E5-BB909643F11B}
                this.cmbAnseWay.Tag = apply.AnesWay;
                //{37A0B524-70DB-413c-8C33-AAC69C40EAC6}
                this.cmbIncityep.Tag = this.operationRecord.OperationAppllication.InciType.ID;


            }
        }

        /// <summary>
        /// 修改申请单
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OperationRecord OperationRecord
        {
            set
            {

                this.operationRecord = value;
                this.OperationApplication = value.OperationAppllication;
                if (value.OutDate != System.DateTime.MinValue)
                {
                    this.dtEndDate.Value = value.OutDate;
                }
                this.cbxInfect.Checked = this.operationRecord.IsInfected;
                this.cbxGerm.Checked = this.operationRecord.OperationAppllication.IsGermCarrying;
            }
        }
        #endregion

        #region 方法


        public void InitControl()
        {
            currentOperator = (Neusoft.HISFC.Models.Base.Employee)opsTableMgr.Operator;

            Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            employHelper.ArrayObject = managerMgr.QueryEmployeeAll();

            //房间号
            this.cmbRoom.Items.Clear();
            ArrayList al = Environment.TableManager.GetRoomsByDept(Environment.OperatorDeptID);
            if (al != null)
            {
                this.cmbRoom.AddItems(al);
                this.cmbRoom.IsListOnly = true;
            }

            //手术室 
            lbOpsDept.AddItems(Environment.IntegrateManager.QueryDepartment("1"));//手术室
            
            //麻醉类型
            this.lbAnae.AddItems(Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ANESTYPE));
            
            //加载科室
            ArrayList deptList = Environment.IntegrateManager.QueryDeptmentsInHos(true);
            this.comDept.AddItems(deptList); 
            
            //申请医生
            al = Environment.IntegrateManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);

            //术者
            this.cmbDoctor.Items.Clear();
            this.cmbDoctor.AddItems(al);
            this.cmbDoctor.IsListOnly = true;
            //一助
            this.cmbHelper1.Items.Clear();
            this.cmbHelper1.AddItems(al);
            this.cmbHelper1.IsListOnly = true;
            //二助
            this.cmbHelper2.Items.Clear();
            this.cmbHelper2.AddItems(al);
            this.cmbHelper2.IsListOnly = true;
            //三助手
            this.cmbHelper3.Items.Clear();
            this.cmbHelper3.AddItems(al);
            this.cmbHelper3.IsListOnly = true;

            //洗手1
            al = Environment.IntegrateManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.N, currentOperator.Dept.ID);
            if (al == null) al = new ArrayList();
            this.cmbWash1.Items.Clear();
            this.cmbWash1.AddItems(al);
            this.cmbWash1.IsListOnly = true;

            //洗手2
            this.cmbWash2.AddItems(al);
            this.cmbWash2.IsListOnly = true;

            //洗手3
            this.cmbWash3.AddItems(al);
            this.cmbWash3.IsListOnly = true;

            //巡回1
            this.cmbXH1.AddItems(al);
            this.cmbXH1.IsListOnly = true;

            //巡回2
            this.cmbXH2.AddItems(al);
            this.cmbXH2.IsListOnly = true;

            //巡回3
            this.cmbXH3.AddItems(al);
            this.cmbXH3.IsListOnly = true;

            //手术规模
            al = Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.OPERATETYPE);
            if (al == null) al = new ArrayList();
            this.cmbOpType.AddItems(al);
            this.cmbOpType.IsListOnly = true;

            //手术分类
            ArrayList alKind = Environment.IntegrateManager.GetConstantList("OPERATEKIND");
            if (alKind == null) alKind = new ArrayList();
            this.cmbOperKind.AddItems(alKind);
            this.cmbOperKind.IsListOnly = true;



            #region 诊断
            ucDiag1 = new Neusoft.HISFC.Components.Common.Controls.ucDiagnose();
            this.Controls.Add(ucDiag1);
            ucDiag1.Size = new Size(456, 312);
            ucDiag1.SelectItem += new Neusoft.HISFC.Components.Common.Controls.ucDiagnose.MyDelegate(ucDiag1_SelectItem);
            ucDiag1.Init();
            ucDiag1.Visible = false;
            #endregion

            #region 手术
            ucOpItem1 = new ucOpItem();
            this.Controls.Add(ucOpItem1);
            ucOpItem1.Size = new Size(518, 338);
            ucOpItem1.SelectItem += new ucOpItem.MyDelegate(ucOpItem1_SelectItem);
            ucOpItem1.Init();
            ucOpItem1.Visible = false;
            #endregion

            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
            //麻醉类别'麻醉类别（局麻或选麻，医生申请时填写）//{B9DDCC10-3380-4212-99E5-BB909643F11B}
            ArrayList alRet = Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ANESWAY);
            this.cmbAnseWay.AddItems(alRet);
            this.cmbAnseWay.IsListOnly = true;

            alRet = Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.INCITYPE);

            this.cmbIncityep.AddItems(alRet);
            this.cmbIncityep.IsListOnly = true;
        }


        #region 手术

        Neusoft.HISFC.Components.Operation.ucOpItem ucOpItem1 = null;
        private System.Windows.Forms.Control contralActive = new Control();
        int ucOpItem1_SelectItem(Keys key)
        {
            this.ProcessOps();
            this.txtOperation.Focus(); 
            return 1;
        }
        private int ProcessOps()
        {
            Neusoft.HISFC.Models.Fee.Item.Undrug item = null;
            if (this.ucOpItem1.GetItem(ref item) == -1)
            {
                //MessageBox.Show("获取项目出错!","提示");
                return -1;
            }
            this.contralActive.Text = (item as Neusoft.HISFC.Models.Fee.Item.Undrug).Name;
            this.contralActive.Tag = item;
            this.ucOpItem1.Visible = false;
            return 0;
        }
        private void txtOperation_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtOperation;
            this.ucDiag1.Visible = false;
        }

        private void txtOperation2_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtOperation2;
            this.ucDiag1.Visible = false;
        }

        private void txtOperation3_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtOperation3;
            this.ucDiag1.Visible = false;
        }

        private void txtOperation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ucOpItem1.Visible)
                {
                    if (this.ProcessOps() == -1)
                        return;
                }

                this.txtOperation2.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucOpItem1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucOpItem1.NextRow();
            }
        }

        private void txtOperation2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ucOpItem1.Visible)
                {
                    if (this.ProcessOps() == -1)
                        return;
                }

                this.txtOperation3.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucOpItem1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucOpItem1.NextRow();
            }
        }

        private void txtOperation3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ucOpItem1.Visible)
                {
                    if (this.ProcessOps() == -1)
                        return;
                }

                //{B9DDCC10-3380-4212-99E5-BB909643F11B}
                //this.lbAnae.Focus();
                this.cmbAnseWay.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucOpItem1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucOpItem1.NextRow();
            }
        }

        private void txtOperation_TextChanged(object sender, EventArgs e)
        {
            if (!txtOperation.Focused)
            {
                return;
            }
            string text = this.txtOperation.Text;

            if (this.ucOpItem1.Visible == false) this.ucOpItem1.Visible = true;
            this.ucOpItem1.Location = new System.Drawing.Point(txtOperation.Location.X, txtOperation.Location.Y + txtOperation.Height + 2);
            ucOpItem1.BringToFront();
            this.ucOpItem1.Filter(text);
            this.txtOperation.Tag = null;
        }

        private void txtOperation2_TextChanged(object sender, EventArgs e)
        {
            if (!txtOperation2.Focused)
            {
                return;
            }
            string text = this.txtOperation2.Text;

            if (this.ucOpItem1.Visible == false) this.ucOpItem1.Visible = true;
            this.ucOpItem1.Location = new System.Drawing.Point(txtOperation2.Location.X, txtOperation2.Location.Y + txtOperation2.Height + 2);
            ucOpItem1.BringToFront();
            this.ucOpItem1.Filter(text);
            this.txtOperation2.Tag = null;
        }

        private void txtOperation3_TextChanged(object sender, EventArgs e)
        {
            if (!txtOperation3.Focused)
            {
                return;
            }
            string text = this.txtOperation3.Text;

            if (this.ucOpItem1.Visible == false) this.ucOpItem1.Visible = true;
            this.ucOpItem1.Location = new System.Drawing.Point(txtOperation3.Location.X, txtOperation3.Location.Y + txtOperation3.Height + 2);
            ucOpItem1.BringToFront();
            this.ucOpItem1.Filter(text);
            this.txtOperation3.Tag = null;
        }
        private void txtOperation3_Leave(object sender, EventArgs e)
        {
            //if (!ucOpItem1.Focused)
            //{
            //    this.ucOpItem1.Visible = false;
            //}
        }
        #endregion 
        #region 诊断
        Neusoft.HISFC.Components.Common.Controls.ucDiagnose ucDiag1 = null;
        int ucDiag1_SelectItem(Keys key)
        {
            return 1;
        }
        private void txtDiag1_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtDiag;
            this.ucOpItem1.Visible = false;
        }

        private void txtDiag2_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtDiag2;
            this.ucOpItem1.Visible = false;
        }

        private void txtDiag3_Enter(object sender, EventArgs e)
        {
            contralActive = this.txtDiag3;
            this.ucOpItem1.Visible = false;
        }
        private void txtDiag1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtDiag.Visible)
                {
                    if (this.ProcessDiag() == -1) return;
                }

                this.txtDiag2.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucDiag1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucDiag1.NextRow();
            }
        }

        private void txtDiag2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtDiag2.Visible)
                {
                    if (this.ProcessDiag() == -1) return;
                }

                this.txtDiag3.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucDiag1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucDiag1.NextRow();
            }
        }

        private void txtDiag3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtDiag3.Visible)
                {
                    if (this.ProcessDiag() == -1) return;
                }

                this.txtOperation.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ucDiag1.PriorRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ucDiag1.NextRow();
            }
        }
        private void txtDiag1_TextChanged(object sender, EventArgs e)
        {
            if (!txtDiag.Focused)
            {
                return;
            }
            contralActive = this.txtDiag;
            string text = this.txtDiag.Text;
            this.ucDiag1.Location = new System.Drawing.Point(txtDiag.Location.X, txtDiag.Location.Y + txtDiag.Height + 2);
            ucDiag1.BringToFront();
            if (this.ucDiag1.Visible == false) this.ucDiag1.Visible = true;

            this.ucDiag1.Filter(text);
            this.txtDiag.Tag = null;
        }

        private void txtDiag2_TextChanged(object sender, EventArgs e)
        {
            if (!txtDiag2.Focused)
            {
                return;
            }
            contralActive = this.txtDiag;
            string text = this.txtDiag2.Text;
            this.ucDiag1.Location = new System.Drawing.Point(txtDiag2.Location.X, txtDiag2.Location.Y + txtDiag2.Height + 2);
            txtDiag2.BringToFront();
            if (this.txtDiag2.Visible == false) this.txtDiag2.Visible = true;

            this.ucDiag1.Filter(text);
            this.txtDiag2.Tag = null;
        }

        private void txtDiag3_TextChanged(object sender, EventArgs e)
        {
            if (!txtDiag3.Focused)
            {
                return;
            }
            contralActive = this.txtDiag3;
            string text = this.txtDiag3.Text;
            this.ucDiag1.Location = new System.Drawing.Point(txtDiag3.Location.X, txtDiag3.Location.Y + txtDiag3.Height + 2);
            txtDiag2.BringToFront();
            if (this.txtDiag3.Visible == false) this.txtDiag3.Visible = true;

            this.ucDiag1.Filter(text);
            this.txtDiag3.Tag = null;
        }
        private int ProcessDiag()
        {
            Neusoft.HISFC.Models.HealthRecord.ICD item = null;
            if (this.ucDiag1.GetItem(ref item) == -1)
            {
                //MessageBox.Show("获取项目出错!","提示");
                return -1;
            } 
            this.contralActive.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name; 
            this.contralActive.Tag = item;
            this.ucDiag1.Visible = false;

            return 0;
        }
        #endregion 
        /// <summary>
        /// 清屏
        /// </summary>
        /// <returns></returns>
        public int Clear()
        {
            this.lbAge.Text = "";//年龄
            this.lbBed.Text = "";//床号
            this.lbDept.Text = "";//科室
            this.lbFree.Text = "";//余额
            this.lbName.Text = "";//姓名
            this.lbPaykind.Text = "";
            this.lbSex.Text = "";
            this.lbPatient.Text = "";//住院号
            this.lbOpsDept.Text = "";//手术室
            //this.lbTableType.Text = "";//台类型
            this.lbApplyDoct.Text = "";//申请医生
            this.lbPreDate.Text = "";//预约日期
            this.lbAnae.Text = "";//麻醉方式
            txtDiag.Text = "";
            txtDiag.Tag = null;
            txtDiag2.Text = "";
            txtDiag2.Tag = null;
            txtDiag3.Text = "";
            txtDiag3.Tag = null;
            this.txtDiag.Text = "";
            this.txtDiag2.Text = "";
            this.txtDiag3.Text = "";
            this.txtDiag.Tag = null;
            this.txtDiag2.Tag = null;
            this.txtDiag3.Tag = null; 
            this.txtOperation.Text = "";//手术名称
            this.txtOperation.Tag = null;
            this.txtOperation2.Text = "";
            this.txtOperation2.Tag = null;
            this.txtOperation3.Text = "";
            this.txtOperation3.Tag = null; 

            DateTime dtNow = Environment.OperationManager.GetDateTimeFromSysDateTime();
            this.dtBeginDate.Value = dtNow;//开始时间
            this.dtEndDate.Value = dtNow;//结束时间

            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
            this.cmbAnseWay.Text = "";//麻醉方式
            this.cmbAnseWay.Tag = null;

            this.lbOpsDept.Text = "";//房号
            this.lbOpsDept.Tag = null;
            //this.cmbOrder.Text = "";//台序

            this.cmbDoctor.Text = "";//手术者
            this.cmbDoctor.Tag = null;
            this.cmbHelper1.Text = "";//一助
            this.cmbHelper1.Tag = null;
            this.cmbHelper2.Text = "";//二助
            this.cmbHelper2.Tag = null;
            this.cmbHelper3.Text = "";//三助
            this.cmbHelper3.Tag = null;
            this.cmbWash1.Text = "";//洗手1
            this.cmbWash1.Tag = null;
            this.cmbWash2.Text = "";//洗手2
            this.cmbWash2.Tag = null;
            this.cmbWash3.Text = "";//洗手3
            this.cmbWash3.Tag = null;
            this.cmbXH1.Text = "";//巡回1
            this.cmbXH1.Tag = null;
            this.cmbXH2.Text = "";//巡回2
            this.cmbXH2.Tag = null;
            this.cmbXH3.Text = "";//巡回3
            this.cmbXH3.Tag = null;


            this.txtTmpHelper1.Text = string.Empty;
            this.txtTmpHelper1.Tag = null;
            this.txtTmpHelper2.Text = string.Empty;
            this.txtTmpHelper2.Tag = null;

            #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
            this.txtTmpStudent1.Text = string.Empty;
            this.txtTmpStudent1.Tag = null;
            this.txtTmpStudent2.Text = string.Empty;
            this.txtTmpStudent2.Tag = null;
            
            #endregion

            this.cmbOpType.Text = "";//手术规模
            this.cmbOpType.Tag = null;
            this.cmbOperKind.Text = "";//分类			
            this.cbxInfect.Checked = false;
            //有菌
            this.cbxGerm.Checked = true;
            
            

            this.cmbIncityep.Tag = null;

            this.rtbApplyNote.Text = "";//

            return 0;
        }


        /// <summary>
        /// 实体赋值
        /// </summary>
        /// <returns></returns>
        private int GetValue()
        {
            if (HandInput)
            {

                if (this.lbPatient.Text == "")
                {
                    MessageBox.Show("请输入住院/门诊号");
                }

                //if (this.lbTableType.Text == "正台")
                //{
                //    this.operationRecord.OperationAppllication.TableType = "1";
                //}
                //else if (this.lbTableType.Text == "加台")
                //{
                //    this.operationRecord.OperationAppllication.TableType = "2";
                //}
                if (lbOpsDept.Tag != null)
                {
                    this.operationRecord.OperationAppllication.ExeDept.Name = this.lbOpsDept.Text;//手术室
                    this.operationRecord.OperationAppllication.ExeDept.ID = this.lbOpsDept.Tag.ToString();//手术室
                }

                isRenew = true;
            }
            operationRecord.OperationAppllication.ApplyDoctor.ID = neuLabel27.Tag.ToString();
            operationRecord.OperationAppllication.ApplyDoctor.Name = this.lbApplyDoct.Text;//申请医生
            if (this.IsNew && this.isRenew)
            {
                this.operationRecord.OperationAppllication.OperationDoctor.Dept = Environment.IntegrateManager.GetEmployeeInfo(cmbDoctor.Tag.ToString()).Dept;
                this.operationRecord.OperationAppllication.ID = Environment.OperationManager.GetNewOperationNo();
            }
            //新登记、非补录、非修改申请获得诊断
            //if (this.IsNew && !this.isRenew)
            //{
            //    foreach (Neusoft.HISFC.Models.HealthRecord.DiagnoseBase diag in this.operationRecord.OperationAppllication.DiagnoseAl)
            //    {
            //        //用术前血压属性记录诊断名称
            //        if (diag.IsMain) this.opRecord.ForePress = diag.Name;
            //    }
            //}
            //if (this.HandInput)
            //{
            // TODO: 添加诊断
            #region 诊断
            Neusoft.HISFC.Models.HealthRecord.DiagnoseBase diag = new Neusoft.HISFC.Models.HealthRecord.DiagnoseBase();
            diag.OperationNo = operationRecord.OperationAppllication.ID;//申请号
            diag.ICD10 = (Neusoft.HISFC.Models.HealthRecord.ICD)this.txtDiag.Tag;
            diag.ID = this.txtDiag.Tag.ToString(); 
            diag.Name = this.txtDiag.Text; 
            diag.Patient = operationRecord.OperationAppllication.PatientInfo.Clone();
            diag.DiagType.ID = "7";//诊断类型
            diag.DiagType.Name = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType.OTHER.ToString();//术前诊断
            diag.DiagDate = opsTableMgr.GetDateTimeFromSysDateTime();//诊断时间
            diag.Doctor.ID = currentOperator.ID;//诊断医生
            diag.Doctor.Name = currentOperator.Name;//诊断医生
            diag.Dept.ID = currentOperator.Dept.ID;//诊断科室
            diag.IsValid = true;//是否有效
            diag.IsMain = true;//主诊断

            if (operationRecord.OperationAppllication.DiagnoseAl.Count == 0)
                diag.HappenNo = opsDiagnose.GetNewDignoseNo();//序号
            else
                diag.HappenNo = (operationRecord.OperationAppllication.DiagnoseAl[0] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).HappenNo;

            operationRecord.OperationAppllication.DiagnoseAl.Clear();
            operationRecord.OperationAppllication.DiagnoseAl.Add(diag);
            #region 第二诊断
            if (txtDiag2.Tag != null)
            {
                diag = new Neusoft.HISFC.Models.HealthRecord.DiagnoseBase();
                diag.OperationNo = operationRecord.OperationAppllication.ID;//申请号
                diag.ICD10 = (Neusoft.HISFC.Models.HealthRecord.ICD)this.txtDiag2.Tag;
                diag.ID = (this.txtDiag2.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).ID;
                diag.Name = (this.txtDiag2.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                diag.Patient = operationRecord.OperationAppllication.PatientInfo.Clone();
                diag.DiagType.ID = "7";//诊断类型
                diag.DiagType.Name = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType.OTHER.ToString();//术前诊断
                diag.DiagDate = opsTableMgr.GetDateTimeFromSysDateTime();//诊断时间
                diag.Doctor.ID = currentOperator.ID;//诊断医生
                diag.Doctor.Name = currentOperator.Name;//诊断医生
                diag.Dept.ID = currentOperator.Dept.ID;//诊断科室
                diag.IsValid = true;//是否有效
                diag.IsMain = false;//主诊断

                if (operationRecord.OperationAppllication.DiagnoseAl.Count == 1)
                    diag.HappenNo = opsDiagnose.GetNewDignoseNo();//序号
                else
                    diag.HappenNo = (operationRecord.OperationAppllication.DiagnoseAl[1] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).HappenNo;
                operationRecord.OperationAppllication.DiagnoseAl.Add(diag);
            }
            #endregion
            #region 第三诊断
            if (txtDiag3.Tag != null)
            {
                diag = new Neusoft.HISFC.Models.HealthRecord.DiagnoseBase();
                diag.OperationNo = operationRecord.OperationAppllication.ID;//申请号
                diag.ICD10 = (Neusoft.HISFC.Models.HealthRecord.ICD)this.txtDiag3.Tag;
                diag.ID = (this.txtDiag3.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).ID;
                diag.Name = (this.txtDiag3.Tag as Neusoft.HISFC.Models.HealthRecord.ICD).Name;
                diag.Patient = operationRecord.OperationAppllication.PatientInfo.Clone();
                diag.DiagType.ID = "7";//诊断类型
                diag.DiagType.Name = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType.OTHER.ToString();//术前诊断
                diag.DiagDate = opsTableMgr.GetDateTimeFromSysDateTime();//诊断时间
                diag.Doctor.ID = currentOperator.ID;//诊断医生
                diag.Doctor.Name = currentOperator.Name;//诊断医生
                diag.Dept.ID = currentOperator.Dept.ID;//诊断科室
                diag.IsValid = true;//是否有效
                diag.IsMain = false;//主诊断

                if (operationRecord.OperationAppllication.DiagnoseAl.Count == 2)
                    diag.HappenNo = opsDiagnose.GetNewDignoseNo();//序号
                else
                    diag.HappenNo = (operationRecord.OperationAppllication.DiagnoseAl[2] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).HappenNo;
                operationRecord.OperationAppllication.DiagnoseAl.Add(diag);
            }
            #endregion

            #endregion
            //}

            #region 麻醉方式
            //麻醉方式
            this.operationRecord.OperationAppllication.AnesType.ID = this.lbAnae.Tag.ToString();
            this.operationRecord.OperationAppllication.AnesType.Name = this.lbAnae.Text;
            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
            this.operationRecord.OperationAppllication.AnesWay = this.cmbAnseWay.Tag.ToString();
            #endregion

            #region 手术项目
            this.operationRecord.OperationAppllication.OperationInfos.Clear();

            if (this.txtOperation.Tag != null)
            {
                this.operationRecord.OperationAppllication.AddOperation(this.txtOperation.Tag, true);
            }

            if (this.txtOperation2.Tag != null)
            {
                this.operationRecord.OperationAppllication.AddOperation(this.txtOperation2.Tag);
            }
            if (this.txtOperation3.Tag != null)
            {
                this.operationRecord.OperationAppllication.AddOperation(this.txtOperation3.Tag);
            }

            this.operationRecord.OperationAppllication.OperationType.ID = this.cmbOpType.Tag.ToString();
            #endregion

            this.operationRecord.OpsDate = this.dtBeginDate.Value;//开始时间 
            this.operationRecord.OperationAppllication.RoomID = this.cmbRoom.Tag.ToString();//房号
            if (this.cmbOrder.Tag != null)
            {
                this.operationRecord.OperationAppllication.BloodUnit = this.cmbOrder.Tag.ToString();
            }
            else
            {
                this.operationRecord.OperationAppllication.BloodUnit = "";
            }

            //特殊说明
            this.operationRecord.Memo = this.rtbApplyNote.Text.Trim();
            this.operationRecord.OutDate = this.dtEndDate.Value;

            ArrayList roleArrayList = new ArrayList();

            for (int i = 0; i < this.operationRecord.OperationAppllication.RoleAl.Count; i++) 
            {
                ArrangeRole tmprole = this.operationRecord.OperationAppllication.RoleAl[i] as ArrangeRole;
                #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
                if (
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.Operator.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.Helper1.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.Helper2.ToString() &&
                            tmprole.RoleType.ID.ToString() != EnumOperationRole.Helper3.ToString() &&
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

            this.operationRecord.OperationAppllication.RoleAl.Clear();

            #region 术者
            ArrangeRole role = new ArrangeRole();
            role.OperationNo = this.operationRecord.OperationAppllication.ID;//申请号
            role.ID = this.cmbDoctor.Tag.ToString();//人员代码
            role.Name = this.cmbDoctor.Text;
            role.RoleType.ID = EnumOperationRole.Operator;//角色编码
            role.ForeFlag = "1";//术后录入
           
            //this.operationRecord.OperationAppllication.RoleAl.Add(role);

            roleArrayList.Add(role);

            this.operationRecord.OperationAppllication.OperationDoctor.ID = role.ID;
            this.operationRecord.OperationAppllication.OperationDoctor.Name = role.Name;
            this.operationRecord.BloodPressureIn = this.txtDiag.Text; //第一诊断
            #endregion

            #region 一助
            role = new ArrangeRole();
            role.OperationNo = this.operationRecord.OperationAppllication.ID;//申请号
            role.ID = this.cmbHelper1.Tag.ToString();//人员代码
            role.Name = this.cmbHelper1.Text;
            role.RoleType.ID = EnumOperationRole.Helper1;//角色编码
            role.ForeFlag = "1";//术后录入
            //this.operationRecord.OperationAppllication.RoleAl.Add(role);
            roleArrayList.Add(role);

            this.operationRecord.OperationAppllication.HelperAl.Clear();
            this.operationRecord.OperationAppllication.HelperAl.Add(role);
            #endregion

            #region 二助
            if (this.cmbHelper2.Tag != null && this.cmbHelper2.Tag.ToString() != "")
            {
                role = new ArrangeRole();
                role.OperationNo = this.operationRecord.OperationAppllication.ID;//申请号
                role.ID = this.cmbHelper2.Tag.ToString();//人员代码
                role.Name = this.cmbHelper2.Text;
                role.RoleType.ID = EnumOperationRole.Helper2;//角色编码
                role.ForeFlag = "1";//术后录入
                //this.operationRecord.OperationAppllication.RoleAl.Add(role);
                roleArrayList.Add(role);

                this.operationRecord.OperationAppllication.HelperAl.Add(role);
            }
            #endregion

            #region 三助
            if (this.cmbHelper3.Tag != null && this.cmbHelper3.Tag.ToString() != "")
            {
                role = new ArrangeRole();
                role.OperationNo = this.operationRecord.OperationAppllication.ID;//申请号
                role.ID = this.cmbHelper3.Tag.ToString();//人员代码
                role.Name = this.cmbHelper3.Text;
                role.RoleType.ID = EnumOperationRole.Helper3;//角色编码
                role.ForeFlag = "1";//术后录入
                //this.operationRecord.OperationAppllication.RoleAl.Add(role);
                roleArrayList.Add(role);

                this.operationRecord.OperationAppllication.HelperAl.Add(role);
            }
            #endregion

            #region 洗手护士
            if (this.cmbWash1.Tag != null && this.cmbWash1.Tag.ToString() != "")
            {
                this.operationRecord.OperationAppllication.AddRole(this.cmbWash1.Tag.ToString(), this.cmbWash1.Text, "1",
                    EnumOperationRole.WashingHandNurse);
            }
            if (this.cmbWash2.Tag != null && this.cmbWash2.Tag.ToString() != "")
            {
                this.operationRecord.OperationAppllication.AddRole(this.cmbWash2.Tag.ToString(), this.cmbWash2.Text, "1",
                    EnumOperationRole.WashingHandNurse);
            }
            if (this.cmbWash3.Tag != null && this.cmbWash3.Tag.ToString() != "")
            {
                this.operationRecord.OperationAppllication.AddRole(this.cmbWash3.Tag.ToString(), this.cmbWash3.Text, "1",
                    EnumOperationRole.WashingHandNurse);
            }
            #endregion

            #region 巡回护士
            if (this.cmbXH1.Tag != null && this.cmbXH1.Tag.ToString() != "")
            {
                this.operationRecord.OperationAppllication.AddRole(this.cmbXH1.Tag.ToString(), this.cmbXH1.Text, "1",
                    EnumOperationRole.ItinerantNurse);
            }
            if (this.cmbXH2.Tag != null && this.cmbXH2.Tag.ToString() != "")
            {
                this.operationRecord.OperationAppllication.AddRole(this.cmbXH2.Tag.ToString(), this.cmbXH2.Text, "1",
                    EnumOperationRole.ItinerantNurse);
            }
            if (this.cmbXH3.Tag != null && this.cmbXH3.Tag.ToString() != "")
            {
                this.operationRecord.OperationAppllication.AddRole(this.cmbXH3.Tag.ToString(), this.cmbXH3.Text, "1",
                    EnumOperationRole.ItinerantNurse);
            }

            if(!string.IsNullOrEmpty(txtTmpHelper1.Text))
            {
                role = new ArrangeRole();
                role.OperationNo = this.operationRecord.OperationAppllication.ID;//申请号
                role.ID = "888888";//人员代码
                role.Name = this.txtTmpHelper1.Text;
                role.RoleType.ID = EnumOperationRole.TmpHelper1.ToString();//角色编码
                role.ForeFlag = "1";//术后录入
                //this.operationRecord.OperationAppllication.RoleAl.Add(role);

                //this.operationRecord.OperationAppllication.HelperAl.Add(role);
                roleArrayList.Add(role);
            }

            if (!string.IsNullOrEmpty(txtTmpHelper2.Text))
            {
                role = new ArrangeRole();
                role.OperationNo = this.operationRecord.OperationAppllication.ID;//申请号
                role.ID = "888888";//人员代码
                role.Name = this.txtTmpHelper2.Text;
                role.RoleType.ID = EnumOperationRole.TmpHelper2.ToString();//角色编码
                role.ForeFlag = "1";//术后录入
                //this.operationRecord.OperationAppllication.RoleAl.Add(role);

                //this.operationRecord.OperationAppllication.HelperAl.Add(role);
                roleArrayList.Add(role);
            }

            #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
            if (!string.IsNullOrEmpty(txtTmpStudent1.Text))
            {
                role = new ArrangeRole();
                role.OperationNo = this.operationRecord.OperationAppllication.ID;//申请号
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
                role.OperationNo = this.operationRecord.OperationAppllication.ID;//申请号
                role.ID = "888888";//人员代码
                role.Name = this.txtTmpStudent2.Text;
                role.RoleType.ID = EnumOperationRole.TmpStudent2.ToString();//角色编码
                role.ForeFlag = "1";//术后录入
                //this.operationRecord.OperationAppllication.RoleAl.Add(role);

                //this.operationRecord.OperationAppllication.HelperAl.Add(role);
                roleArrayList.Add(role);
            } 
            #endregion


            this.operationRecord.OperationAppllication.RoleAl.AddRange(roleArrayList);

            #endregion
            //手术分类
            this.operationRecord.OperationAppllication.OperateKind = System.Convert.ToString(this.cmbOperKind.SelectedItem.ID);
            //是否感染
            this.operationRecord.IsInfected = this.cbxInfect.Checked;
            //是否有菌
            this.operationRecord.OperationAppllication.IsGermCarrying = this.cbxGerm.Checked;

            this.operationRecord.OperationAppllication.IsFinished = true;
            this.operationRecord.OperationAppllication.PatientInfo.Weight = "0";//体重
            this.operationRecord.OperationAppllication.ExecStatus = "4";//登记完成
            this.operationRecord.OperationAppllication.OperationDoctor.Dept.ID  = this.comDept.Tag.ToString();
            //{37A0B524-70DB-413c-8C33-AAC69C40EAC6}
            this.operationRecord.OperationAppllication.InciType.ID = this.cmbIncityep.Tag.ToString();

            return 0;
        }

        /// <summary>
        /// 有效性验证
        /// </summary>
        /// <returns></returns>
        private int Valid()
        {
            if (this.IsNew)
            {
                if (this.operationRecord.OperationAppllication.IsValid == false)
                {
                    MessageBox.Show("该申请单已经作废!", "提示");
                    return -1;
                }
            }

            if (operationRecord.OperationAppllication.PatientInfo.ID.Length == 0)
            {
                MessageBox.Show("请选择申请患者!", "提示");
                return -1;
            }

            if (this.txtOperation.Tag == null && this.txtOperation2.Tag == null && this.txtOperation3.Tag == null)
            {
                MessageBox.Show("拟手术名称不能为空!", "提示");
                txtOperation.Focus();
                return -1;
            }
            if (dtBeginDate.Value > dtEndDate.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间");
                dtBeginDate.Focus();
                return -1;
            }
            if (this.cmbRoom.Tag == null || this.cmbRoom.Tag.ToString() == "")
            {
                MessageBox.Show("房号不能为空!", "提示");
                cmbRoom.Focus();
                return -1;
            }

            if (this.dtBeginDate.Value > this.dtEndDate.Value)
            {
                MessageBox.Show("手术开始时间必须小于结束时间!", "提示");
                return -1;
            }

            //if (this.cmbOrder.Text == "")
            //{
            //    MessageBox.Show("台序不能为空!", "提示");
            //    cmbOrder.Focus();
            //    return -1;
            //}
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
            if (this.cmbHelper1.Tag == null || this.cmbHelper1.Tag.ToString() == "")
            {
                MessageBox.Show("一助不能为空!", "提示");
                return -1;
            }

            //if ((this.cmbWash1.Tag == null || this.cmbWash1.Tag.ToString() == "") &&
            //    (this.cmbWash2.Tag == null || this.cmbWash2.Tag.ToString() == "") &&
            //    (this.cmbWash3.Tag == null || this.cmbWash3.Tag.ToString() == ""))
            //{
            //    MessageBox.Show("洗手护士不能为空!", "提示");
            //    cmbWash1.Focus();
            //    return -1;
            //}

            if (this.cmbOpType.Tag == null || this.cmbOpType.Tag.ToString() == "")
            {
                MessageBox.Show("手术规模不能为空!", "提示");
                cmbOpType.Focus();
                return -1;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.rtbApplyNote.Text.Trim(), 200) == false)
            {
                MessageBox.Show("特殊说明必须小于100个汉字!", "提示");
                rtbApplyNote.Focus();
                return -1;
            }
            string Oper1 = Conobj(txtOperation.Tag); //第一手术
            string Oper2 = Conobj(txtOperation2.Tag); //第二手术
            string Oper3 = Conobj(txtOperation3.Tag); //第三手术
            if ((Oper1 == Oper2 && Oper1 != "") || (Oper1 == Oper3 && Oper3 != "") || (Oper2 == Oper3 && Oper3 != ""))
            {
                MessageBox.Show("手术项目不能重复");
                txtOperation.Focus();
                return -1;
            }
            string Oper11 = Conobj(txtOperation.Text); //第一手术
            string Oper12 = Conobj(txtOperation2.Text); //第二手术
            string Oper13 = Conobj(txtOperation3.Text); //第三手术
            if ((Oper11 == Oper12 && Oper11 != "") || (Oper11 == Oper13 && Oper13 != "") || (Oper12 == Oper13 && Oper13 != ""))
            {
                MessageBox.Show("手术项目不能重复");
                txtOperation.Focus();
                return -1;
            }
            string Helper1 = Conobj(cmbHelper1.Tag); //一助
            string Helper2 = Conobj(cmbHelper2.Tag); //一助
            string Helper3 = Conobj(cmbHelper3.Tag); //一助
            if ((Helper1 == Helper2 && Helper1 != "") || (Helper1 == Helper3 && Helper3 != "") || (Helper2 == Helper3 && Helper3 != ""))
            {
                MessageBox.Show("一助二助三助不能重复");
                cmbHelper2.Focus();
                return -1;
            }
            string Wash1 = Conobj(cmbWash1.Tag); //洗手护士
            string Wash2 = Conobj(cmbWash2.Tag); //洗手护士
            string Wash3 = Conobj(cmbWash3.Tag); //洗手护士
            if ((Wash1 == Wash2 && Wash1 != "") || (Wash1 == Wash3 && Wash3 != "") || (Wash2 == Wash3 && Wash3 != ""))
            {
                MessageBox.Show("三个洗手护士不能重复");
                cmbWash2.Focus();
                return -1;
            }

            if (cmbXH1.Tag == null || string.IsNullOrEmpty(cmbXH1.Tag.ToString())) 
            {
                MessageBox.Show("巡回一不能为空!", "提示");
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

            string XH1 = Conobj(cmbXH1.Tag); //巡回护士
            string XH2 = Conobj(cmbXH2.Tag); //巡回护士
            string XH3 = Conobj(cmbXH3.Tag); //巡回护士
            if ((XH1 == XH2 && XH1 != "") || (XH1 == XH3 && XH3 != "") || (XH2 == XH3 && XH3 != ""))
            {
                MessageBox.Show("三个巡回护士不能重复");
                cmbXH2.Focus();
                return -1;
            }
            return 0;
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
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            try
            {
                PreSave();

                //int CaseReturn = 0;


                if (Valid() == -1)
                    return -1;

                if (this.GetValue() == -1)
                    return -1;

                //数据库事务
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction trans = new
                //    Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //trans.BeginTransaction();

                Environment.OperationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                Environment.RecordManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //this.opdMgr.SetTrans(trans.Trans);
                //this.icdMgr.SetTrans(trans.Trans);
                //this.iteMgr.SetTrans(trans.Trans);
                int rtn = 0;

                //获取数据库系统时间，使手术登记和病案登记的操作时间相一致。——Add By Maokb
                DateTime inTime;
                inTime = Environment.OperationManager.GetDateTimeFromSysDateTime();
                // TODO: 添加病案
                //this.opDetail.OperDate = inTime;
                this.operationRecord.OperDate = inTime;

                //判断是否插入病案手术信息
                //CaseReturn = GetDetail(inTime);

                try
                {
                    this.operationRecord.OperationAppllication.PatientInfo.PVisit.PatientLocation.Dept.ID = this.lbDept.Tag.ToString();
                    if (this.IsNew)//新增
                    {
                        #region new
                        if (Environment.RecordManager.AddOperatorRecord(this.operationRecord) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Environment.RecordManager.Err, "提示");
                            return -1;
                        }

                        //更新申请单状态
                        if (this.isRenew == false)
                        {
                            rtn = Environment.OperationManager.DoOperatorRecord(this.operationRecord.OperationAppllication.ID);
                            if (rtn == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(Environment.OperationManager.Err, "提示");
                                return -1;
                            }
                            if (rtn == 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("该申请单状态已经改变,请刷新屏幕重新录入!", "提示");
                                return -1;
                            }
                        }
                        #region 登记手术项目
                        if (Environment.OperationManager.DelOperationInfo(this.operationRecord.OperationAppllication) == -1)//删除手术项目
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Environment.OperationManager.Err, "提示");
                            return -1;
                        }
                        //针对本申请单中涉及到的手术添加手术项目信息
                        foreach (OperationInfo OperateInfo in this.operationRecord.OperationAppllication.OperationInfos)
                        {
                            //添加手术项目信息
                            if (Environment.OperationManager.AddOperationInfo(this.operationRecord.OperationAppllication, OperateInfo) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(Environment.OperationManager.Err, "提示");
                                return -1;
                            }
                        }
                        #endregion
                        #region 登记人员信息
                        if (Environment.OperationManager.ProcessRoleForApply(this.operationRecord.OperationAppllication) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Environment.OperationManager.Err, "提示");
                            return -1;
                        }
                        #endregion 
                        #endregion
                    }
                    else//修改
                    {
                        #region modify

                        if (Environment.RecordManager.GetModifyEnabled() != "1")
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("您没有修改手术登记记录的权限!", "提示");
                            return -1;
                        }

                        //先判断状态
                        if (this.operationRecord.IsValid == false)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("该申请单已经作废!", "提示");
                            return -1;
                        }

                        if (Environment.RecordManager.UpdateOperatorRecord(this.operationRecord) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Environment.RecordManager.Err, "提示");
                            return -1;
                        }

                        #region 登记手术项目
                        if (Environment.OperationManager.DelOperationInfo(this.operationRecord.OperationAppllication) == -1)//删除手术项目
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Environment.OperationManager.Err, "提示");
                            return -1;
                        }
                        //针对本申请单中涉及到的手术添加手术项目信息
                        foreach (OperationInfo OperateInfo in this.operationRecord.OperationAppllication.OperationInfos)
                        {
                            //添加手术项目信息
                            if (Environment.OperationManager.AddOperationInfo(this.operationRecord.OperationAppllication, OperateInfo) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(Environment.OperationManager.Err, "提示");
                                return -1;
                            }
                        }
                        #endregion
                        #region 登记人员信息
                        if (Environment.OperationManager.ProcessRoleForApply(this.operationRecord.OperationAppllication) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Environment.OperationManager.Err, "提示");
                            return -1;
                        }
                        #endregion

                        // TODO: 添加病案
                        #region 登记病案信息 --Add By maokb

                        //if (CaseReturn == 0)
                        //{
                        //    //删除原来纪录
                        //    if (opdMgr.DeleteByCodeAndTime(operDate, this.opDetail.InpatientNO) == -1)
                        //    {
                        //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //        MessageBox.Show(this.opdMgr.Err, "提示");
                        //        return -1;
                        //    }

                        //    //添加更改后的记录
                        //    if (this.alDetail != null)
                        //    {
                        //        foreach (neusoft.HISFC.Object.Case.OperationDetail opdinfo in alDetail)
                        //        {
                        //            if (opdMgr.Insert(neusoft.HISFC.Management.Case.frmTypes.DOC, opdinfo) == -1)
                        //            {
                        //                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //                MessageBox.Show(this.opdMgr.Err, "提示");
                        //                return -1;
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //        MessageBox.Show("没有要登记的手术项目", "提示");
                        //        return -1;
                        //    }
                        //}

                        #endregion
                        #endregion
                    }
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    this.isRenew = false;
                }
                catch (Exception e)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(e.Message, "提示");
                    return -1;
                }

                MessageBox.Show("登记成功!", "提示");
                this.ucDiag1.Visible = false;
                this.ucOpItem1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        /// <summary>
        /// 作废登记单
        /// </summary>
        /// <returns></returns>
        public int Cancel()
        {


            if (this.isCancled)
            {
                MessageBox.Show("该手术病区已做废!", "提示");
                return -1;
            }
            if (this.IsNew)
            {
                MessageBox.Show("该手术还没有做登记,不能作废,或者没有双击手术申请信息!", "提示");
                return -1;
            }

            DialogResult dr = MessageBox.Show("【作废】操作将把该手术置为“作废”状态，该状态不可恢复\n，是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No)
            {
                return -1;
            }

            //开始事务

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            int rtn = 0;
            Environment.RecordManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                //没有作废手术项目,如果统计需要自己添加作废功能,或者关联一下
                rtn = Environment.RecordManager.CancelRecord(this.operationRecord.OperationAppllication.ID);
                if (rtn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Environment.RecordManager.Err, "提示");
                    return -1;
                }

                rtn = Environment.RecordManager.CacelApply(this.operationRecord.OperationAppllication.ID);
                if (rtn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该登记单作废失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

                if (rtn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该登记单已经作废!", "提示");
                    return -1;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }
            MessageBox.Show("作废成功!", "提示");

            return 0;
        }
        //{80D89813-7B64-4acf-A2CD-55BFD9F1E7C6}
        public int DeleleteRegInfo()
        {
            //删除登记信息

            DialogResult dr = MessageBox.Show("【取消】操作将把该手术申请恢复到“未登记”状态\n，是否继续", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No)
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            int returnValue = Environment.RecordManager.DeleteOpsRecord(this.operationRecord.OperationAppllication.ID);

            //returnValue =  Environment.OperationManager.DelOperationInfo(this.operationRecord.OperationAppllication);
            //returnValue =  Environment.OperationManager.DelArrangeRoleAll(this.operationRecord.OperationAppllication);

            returnValue = Environment.OperationManager.DoAnaeRecord(this.operationRecord.OperationAppllication.ID,"3");

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            return 1;

        }
        /// <summary>
        /// 锁定
        /// </summary>
        public void SetEnable(bool type)
        {
            lbName.Enabled = type;
            //			lbName.BackColor = System.Drawing.Color.MintCream;
            lbSex.Enabled = type;
            //			lbSex.BackColor = System.Drawing.Color.MintCream;
            lbAge.Enabled = type;
            //			lbAge.BackColor = System.Drawing.Color.MintCream;
            lbPatient.Enabled = type;
            //			lbPatient.BackColor = System.Drawing.Color.MintCream;
            lbPaykind.Enabled = type;
            //			lbPaykind.BackColor = System.Drawing.Color.MintCream;

            //允许进行科室修改
            //			lbDept.Enabled = type;
            //			lbDept.BackColor = System.Drawing.Color.MintCream;

            lbBed.Enabled = type;
            //			lbBed.BackColor = System.Drawing.Color.MintCream;
            lbFree.Enabled = type;
            //			lbFree.BackColor = System.Drawing.Color.MintCream;
            lbOpsDept.Enabled = type;
            //			lbOpsDept.BackColor = System.Drawing.Color.MintCream;
            //lbTableType.Enabled = type;
            //			lbTableType.BackColor = System.Drawing.Color.MintCream;
            lbApplyDoct.Enabled = type;
            //			lbApplyDoct.BackColor = System.Drawing.Color.MintCream;
            lbPreDate.Enabled = type;
            //			lbPreDate.BackColor = System.Drawing.Color.MintCream;
            txtDiag.Enabled = type;
            txtDiag.BackColor = System.Drawing.Color.MintCream;
            txtDiag2.Enabled = type;
            txtDiag2.BackColor = System.Drawing.Color.MintCream;
            txtDiag3.Enabled = type;
            txtDiag3.BackColor = System.Drawing.Color.MintCream;
        }

        public int Print()
        {
            if (this.recordFormPrint == null)
            {
                this.recordFormPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Operation.IRecordFormPrint)) as Neusoft.HISFC.BizProcess.Interface.Operation.IRecordFormPrint;
                if (this.recordFormPrint == null)
                {
                    MessageBox.Show("获得接口IRecordFormPrint错误，请与系统管理员联系。");

                    return -1;
                }
            }
            if (this.GetValue() == -1)
                return -1;

            this.recordFormPrint.OperationRecord = this.operationRecord;
            return this.recordFormPrint.Print();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Escape.GetHashCode())
            {
                this.ucOpItem1.Visible = false;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { typeof(Neusoft.HISFC.BizProcess.Interface.Operation.IRecordFormPrint) };
            }
        }

        #endregion   


        #region 按键顺序

        private void lbAnae_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtBeginDate.Focus();
            }
        }

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
                cmbRoom.Focus();
            }
        }

        private void cmbRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbOrder.Focus();
            }
        }

        private void cmbOrder_KeyDown(object sender, KeyEventArgs e)
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
                cmbHelper1.Focus();
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
                cmbHelper3.Focus();
            }
        }

        private void cmbHelper3_KeyDown(object sender, KeyEventArgs e)
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
                cmbWash3.Focus();
            }
        }

        private void cmbWash3_KeyDown(object sender, KeyEventArgs e)
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
                cmbXH3.Focus();
            }
        }

        private void cmbXH3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbOpType.Focus();
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
            ////{37A0B524-70DB-413c-8C33-AAC69C40EAC6}
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbIncityep.Focus();
            }
        }

        private void cbxInfect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rtbApplyNote.Focus();
            }
        }
        //{B9DDCC10-3380-4212-99E5-BB909643F11B}
        private void cmbAnseWay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.lbAnae.Focus();
            }
        }

        private void cmbIncityep_KeyDown(object sender, KeyEventArgs e)
        {
            ////{37A0B524-70DB-413c-8C33-AAC69C40EAC6}
            if (e.KeyCode == Keys.Enter)
            {
                cbxInfect.Focus();
            }
        } 

        #endregion


        #region  自定义 手术 和 诊断

        private void cbxCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCustom.Checked)
            {
                this.txtDiag.IsEnter2Tab = true;
                this.txtDiag.TextChanged -= new EventHandler(txtDiag1_TextChanged);
                this.txtDiag.KeyDown -= new KeyEventHandler(txtDiag1_KeyDown);

                this.txtDiag2.IsEnter2Tab = true;
                this.txtDiag2.TextChanged -= new EventHandler(txtDiag2_TextChanged);
                this.txtDiag2.KeyDown -= new KeyEventHandler(txtDiag2_KeyDown);

                this.txtDiag3.IsEnter2Tab = true;
                this.txtDiag3.TextChanged -= new EventHandler(txtDiag3_TextChanged);
                this.txtDiag3.KeyDown -= new KeyEventHandler(txtDiag3_KeyDown);



                this.txtOperation.IsEnter2Tab = true;
                this.txtOperation.TextChanged -= new EventHandler(txtOperation_TextChanged);
                this.txtOperation.KeyDown -= new KeyEventHandler(txtOperation_KeyDown);

                this.txtOperation2.IsEnter2Tab = true;
                this.txtOperation2.TextChanged -= new EventHandler(txtOperation2_TextChanged);
                this.txtOperation2.KeyDown -= new KeyEventHandler(txtOperation2_KeyDown);

                this.txtOperation3.IsEnter2Tab = true;
                this.txtOperation3.TextChanged -= new EventHandler(txtOperation3_TextChanged);
                this.txtOperation3.KeyDown -= new KeyEventHandler(txtOperation3_KeyDown);
            }
            else
            {
                this.txtDiag.IsEnter2Tab = false;
                this.txtDiag2.IsEnter2Tab = false;
                this.txtDiag3.IsEnter2Tab = false;

                this.txtOperation.IsEnter2Tab = false;
                this.txtOperation2.IsEnter2Tab = false;
                this.txtOperation3.IsEnter2Tab = false;

                this.txtDiag.TextChanged -= new EventHandler(txtDiag1_TextChanged);
                this.txtDiag.KeyDown -= new KeyEventHandler(txtDiag1_KeyDown);

                this.txtDiag2.TextChanged -= new EventHandler(txtDiag2_TextChanged);
                this.txtDiag2.KeyDown -= new KeyEventHandler(txtDiag2_KeyDown);

                this.txtDiag3.TextChanged -= new EventHandler(txtDiag3_TextChanged);
                this.txtDiag3.KeyDown -= new KeyEventHandler(txtDiag3_KeyDown);


                this.txtOperation.TextChanged -= new EventHandler(txtOperation_TextChanged);
                this.txtOperation.KeyDown -= new KeyEventHandler(txtOperation_KeyDown);

                this.txtOperation2.TextChanged -= new EventHandler(txtOperation2_TextChanged);
                this.txtOperation2.KeyDown -= new KeyEventHandler(txtOperation2_KeyDown);

                this.txtOperation3.TextChanged -= new EventHandler(txtOperation3_TextChanged);
                this.txtOperation3.KeyDown -= new KeyEventHandler(txtOperation3_KeyDown);


                this.txtDiag.TextChanged += new EventHandler(txtDiag1_TextChanged);
                this.txtDiag.KeyDown += new KeyEventHandler(txtDiag1_KeyDown);

                this.txtDiag2.TextChanged += new EventHandler(txtDiag2_TextChanged);
                this.txtDiag2.KeyDown += new KeyEventHandler(txtDiag2_KeyDown);

                this.txtDiag3.TextChanged += new EventHandler(txtDiag3_TextChanged);
                this.txtDiag3.KeyDown += new KeyEventHandler(txtDiag3_KeyDown);


                this.txtOperation.TextChanged += new EventHandler(txtOperation_TextChanged);
                this.txtOperation.KeyDown += new KeyEventHandler(txtOperation_KeyDown);

                this.txtOperation2.TextChanged += new EventHandler(txtOperation2_TextChanged);
                this.txtOperation2.KeyDown += new KeyEventHandler(txtOperation2_KeyDown);

                this.txtOperation3.TextChanged += new EventHandler(txtOperation3_TextChanged);
                this.txtOperation3.KeyDown += new KeyEventHandler(txtOperation3_KeyDown);
            }
        }


        private void PreSave()
        {
            if (!this.cbxCustom.Checked)
            {
                return;
            }

            if (!string.IsNullOrEmpty(txtDiag.Text.Trim()))
            {
                #region donggq

                Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtDiag.Text;

                this.txtDiag.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;

                this.txtDiag.Tag = item;

                #endregion
            }

            if (!string.IsNullOrEmpty(txtDiag2.Text.Trim()))
            {
                #region donggq

                Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtDiag2.Text;

                this.txtDiag2.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;

                this.txtDiag2.Tag = item;

                #endregion
            }


            if (!string.IsNullOrEmpty(txtDiag3.Text.Trim()))
            {
                #region donggq

                Neusoft.HISFC.Models.HealthRecord.ICD item = new Neusoft.HISFC.Models.HealthRecord.ICD();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtDiag3.Text;

                this.txtDiag3.Text = (item as Neusoft.HISFC.Models.HealthRecord.ICD).Name;

                this.txtDiag3.Tag = item;

                #endregion
            }


            if (!string.IsNullOrEmpty(txtOperation.Text.Trim()))
            {
                #region donggq
                Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtOperation.Text;

                this.txtOperation.Text = (item as Neusoft.HISFC.Models.Fee.Item.Undrug).Name;

                this.txtOperation.Tag = item;

                #endregion
            }

            if (!string.IsNullOrEmpty(txtOperation2.Text.Trim()))
            {
                #region donggq
                Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();



                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtOperation2.Text;

                this.txtOperation2.Text = (item as Neusoft.HISFC.Models.Fee.Item.Undrug).Name;

                this.txtOperation2.Tag = item;

                #endregion
            }

            if (!string.IsNullOrEmpty(txtOperation3.Text.Trim()))
            {
                #region donggq
                Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();

                item.ID = GetCustomOpitemNo();
                if (string.IsNullOrEmpty(item.ID))
                {
                    item.ID = GetCustomOpitemNo();
                }
                item.Name = this.txtOperation3.Text;

                this.txtOperation3.Text = (item as Neusoft.HISFC.Models.Fee.Item.Undrug).Name;

                this.txtOperation3.Tag = item;

                #endregion
            }

        }



        public string GetCustomOpitemNo()
        {
            Neusoft.HISFC.BizProcess.Integrate.Operation.Operation op = new Neusoft.HISFC.BizProcess.Integrate.Operation.Operation();

            string strSql = "SELECT  Seq_local_itemno.NEXTVAL FROM dual";
            string val = string.Empty;

            if (op.ExecQuery(strSql) == -1)
            {
                return val;
            }
            try
            {
                if (op.Reader.Read())
                {
                    return op.Reader.GetValue(0).ToString();
                }
                else
                {
                    return val;
                }
            }
            catch
            {
                return val;
            }

            return val;
        }

        private void ucRegistrationForm_Load(object sender, EventArgs e)
        {
            this.cbxCustom.Checked = true;
        }


        #endregion

    }
}

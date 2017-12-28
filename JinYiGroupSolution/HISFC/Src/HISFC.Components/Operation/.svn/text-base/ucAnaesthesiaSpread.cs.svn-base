using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 麻醉安排表格控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-11]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucAnaesthesiaSpread : UserControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucAnaesthesiaSpread()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
            {
                this.Init();
            }
        }

        #region 字段
        /// <summary>
        /// 本科人员列表
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbDoctor = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbAnaetype = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();

        private Neusoft.HISFC.BizProcess.Interface.Operation.IArrangePrint arrangePrint;
        private DateTime date;

        public event ApplicationSelectedEventHandler applictionSelected;

        //{B9DDCC10-3380-4212-99E5-BB909643F11B}
        Neusoft.FrameWork.Public.ObjectHelper anneObjectHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #endregion

        #region 属性
        public DateTime Date
        {
            set
            {
                this.date = value;
            }
        }

        private string queryTime;
        public string QueryTime 
        {
            get 
            {
                return this.queryTime;
            }
            set 
            {
                this.queryTime = value;
                this.fpSpread1_Sheet1.ColumnHeader.Cells[1, 0].Text = this.queryTime;
                this.fpSpread1_Sheet1.ColumnHeader.Cells[1, 8].Text = string.Format("科室：{0}", ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.Name);
            }
        }


        #endregion


        #region 方法

        private void Init()
        {
            this.fpSpread1.SetInputMap();
            this.RefreshEmployeeList();
            this.InitTypeList();
            this.fpSpread1.AddListBoxPopup(this.lbDoctor, (int)Cols.anaeDoct);
            this.fpSpread1.AddListBoxPopup(this.lbDoctor, (int)Cols.anaeHelper);
            this.fpSpread1.AddListBoxPopup(this.lbAnaetype, (int)Cols.anaeType);

            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
           System.Collections.ArrayList al= this.managerIntegrate.GetConstantList(EnumConstant.ANESWAY);
           this.anneObjectHelper.ArrayObject = al;
            
        }
        //刷新本科人员列表
        private int RefreshEmployeeList()
        {
            //treeView2.Nodes.Clear();
            //TreeNode root = new TreeNode();
            //root.Text = "本科人员";
            //root.ImageIndex = 22;
            //root.SelectedImageIndex = 22;
            //treeView2.Nodes.Add(root);

            //获取本科人员集
            //MessageBox.Show(EnumEmployeeType.D.ToString(),Environment.OperatorDeptID);
            //ArrayList persons = Environment.IntegrateManager.QueryEmployee(EnumEmployeeType.D, Environment.OperatorDeptID);

            //ArrayList persons = Environment.IntegrateManager.QueryEmployee(EnumEmployeeType.D, Environment.OperatorDeptID);

            #region donggq--2010.10.04--{C031EA11-9A8C-4c97-B9B3-026320DE2BD7}

            ArrayList persons = Environment.IntegrateManager.QueryEmployee(EnumEmployeeType.D, "2600");
            persons.AddRange(Environment.IntegrateManager.QueryEmployee(EnumEmployeeType.D, "2603")); 

            #endregion

            //ArrayList persons = Environment.IntegrateManager.QueryEmployeeAll();
            //添加到树形列表
            //if (persons != null)
            //{
            //    foreach (Neusoft.HISFC.Models.Base.Employee person in persons)
            //    {
            //        TreeNode node = new TreeNode();
            //        node.Tag = person;
            //        node.Text = "[" + person.ID + "]" + person.Name;
            //        node.ImageIndex = 25;
            //        node.SelectedImageIndex = 25;
            //        root.Nodes.Add(node);
            //    }
            //}
            //root.Expand();
            //生成医生listbox列表
            this.InitDoctListBox(persons);
            persons = null;

            return 0;
        }

        /// <summary>
        /// 添加医生listbox列表
        /// </summary>
        /// <param name="doctors"></param>
        /// <returns></returns>
        private int InitDoctListBox(ArrayList doctors)
        {
            //ArrayList al = new ArrayList();
            //if (doctors != null)
            //{
            //    foreach (Neusoft.HISFC.Models.Base.Employee doctor in doctors)
            //    {
            //        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            //        obj = (Neusoft.FrameWork.Models.NeuObject)doctor;
            //        al.Add(obj);
            //    }
            //}
            lbDoctor.AddItems(doctors);

            //this.Controls.Add(this.lbDoctor);
            //this.lbDoctor.Visible = false;
            //lbDoctor.BorderStyle = BorderStyle.FixedSingle;
            //lbDoctor.BringToFront();
            //lbDoctor.ItemSelected += new EventHandler(lbDoctor_ItemSelected);
            return 0;
        }

        /// <summary>
        /// 生成麻醉类别列表
        /// </summary>
        /// <returns></returns>
        private int InitTypeList()
        {
            ArrayList types = Environment.IntegrateManager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ANESTYPE);

            lbAnaetype.AddItems(types);

            //this.Controls.Add(this.lbAnaetype);
            //this.lbAnaetype.Visible = false;
            //this.lbAnaetype.BorderStyle = BorderStyle.FixedSingle;
            //this.lbAnaetype.BringToFront();
            //this.lbAnaetype.ItemSelected+=new EventHandler(lbAnaetype_ItemSelected);
            return 0;
        }
        /// <summary>
        /// 设置护士、手术台列表位置
        /// </summary>
        /// <returns></returns>
        //private int SetLocation()
        //{
        //    Control _cell = fpSpread1.EditingControl;
        //    if (_cell == null) return 0;

        //    //助手、主麻
        //    if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.anaeDoct ||
        //        fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.anaeHelper)
        //    {
        //        lbDoctor.Location = new Point( _cell.Location.X,
        //            _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
        //        lbDoctor.Size = new Size(110, 150);
        //    }
        //    else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.anaeType)
        //    {
        //        lbAnaetype.Location = new Point(_cell.Location.X,
        //            _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
        //        lbAnaetype.Size = new Size(110, 150);
        //    }
        //    return 0;
        //}
        /// <summary>
        /// 选择医生
        /// </summary>
        /// <param name="Column"></param>
        /// <returns></returns>
        //private int SelectDoctor(int Column)
        //{
        //    int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
        //    if (CurrentRow < 0) return 0;

        //    fpSpread1.StopCellEditing();
        //    NeuObject item = null;
        //    item = lbDoctor.GetSelectedItem();

        //    if (item == null) return -1;

        //    fpSpread1_Sheet1.Cells[CurrentRow, Column].Tag = item;
        //    fpSpread1_Sheet1.SetValue(CurrentRow, Column, item.Name, false);

        //    lbDoctor.Visible = false;

        //    return 0;
        //}

        /// <summary>
        /// 选择麻醉类型
        /// </summary>
        /// <returns></returns>
        //private int SelectType()
        //{
        //    int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
        //    if (CurrentRow < 0) return 0;

        //    fpSpread1.StopCellEditing();
        //    NeuObject item = null;
        //    item = lbAnaetype.GetSelectedItem();

        //    if (item == null) return -1;

        //    fpSpread1_Sheet1.Cells[CurrentRow, (int)Cols.anaeType].Tag= item;
        //    fpSpread1_Sheet1.SetValue(CurrentRow, (int)Cols.anaeType, item.Name, false);

        //    lbAnaetype.Visible = false;

        //    return 0;
        //}
        /// <summary>
        /// 添加手术申请信息
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        public int AddOperationApplication(Neusoft.HISFC.Models.Operation.OperationAppllication apply)
        {
            this.fpSpread1_Sheet1.Rows.Add(fpSpread1_Sheet1.RowCount, 1);
            int row = fpSpread1_Sheet1.RowCount - 1;

            FarPoint.Win.Spread.CellType.TextCellType txtType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtType.StringTrim = System.Drawing.StringTrimming.EllipsisWord;
            txtType.ReadOnly = true;
            fpSpread1_Sheet1.Rows[row].Tag = apply;
            //护士站            
            Department dept = Environment.IntegrateManager.GetDepartment(apply.PatientInfo.PVisit.PatientLocation.Dept.ID);
            if (dept != null)
            {
                fpSpread1_Sheet1.SetValue(row, (int)Cols.nurseID, dept.Name, false);
            }
            //床号
            fpSpread1_Sheet1.SetValue(row, (int)Cols.bedID, apply.PatientInfo.PVisit.PatientLocation.Bed.ID, false);
            //患者姓名
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Name, apply.PatientInfo.Name, false);
            //是否已安排
            if (apply.IsAnesth)
                fpSpread1_Sheet1.Cells[row, (int)Cols.Name].Note = "已安排";
            else
                fpSpread1_Sheet1.Cells[row, (int)Cols.Name].Note = "";
            //性别
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Sex, apply.PatientInfo.Sex.Name, false);
            //年龄
            //int interval = DateTime.Now.Year - apply.PatientInfo.Birthday.Year;
            string age = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(apply.PatientInfo.Birthday);//interval + "岁";
            //if (interval == 0)
            //{
            //    interval = DateTime.Now.Month - apply.PatientInfo.Birthday.Month;
            //    age = interval + "月";
            //}
            //if (interval == 0)
            //{
            //    interval = DateTime.Now.Day - apply.PatientInfo.Birthday.Day;
            //    age = interval + "天";
            //}
            fpSpread1_Sheet1.SetValue(row, (int)Cols.age, age, false);
            //术前诊断
            if (apply.DiagnoseAl != null && apply.DiagnoseAl.Count > 0)
            {
                // TODO: 添加术前诊断

                fpSpread1_Sheet1.SetValue(row, (int)Cols.Diagnose, (apply.DiagnoseAl[0] as Neusoft.HISFC.Models.HealthRecord.DiagnoseBase).ICD10.Name, false);
            }
            else
                fpSpread1_Sheet1.SetValue(row, (int)Cols.Diagnose, "", false);
            //主手术名称
            string opName = "";
            if (apply.OperationInfos != null && apply.OperationInfos.Count > 0)
            {
                foreach (OperationInfo item in apply.OperationInfos)
                {
                    if (item.IsMainFlag)
                    {
                        opName = item.OperationItem.Name;
                        break;
                    }
                }
                if (opName == "")
                    opName = (apply.OperationInfos[0] as OperationInfo).OperationItem.Name;
            }
            fpSpread1_Sheet1.SetValue(row, (int)Cols.opItemName, opName, false);

            //手术医生
            fpSpread1_Sheet1.SetValue(row, (int)Cols.opDoc, apply.OperationDoctor.Name, false);
            //合并疾病
            fpSpread1_Sheet1.SetValue(row, (int)Cols.anaeNote, apply.AneNote, false);


            //麻醉方式
            if (apply.AnesType.ID != null && apply.AnesType.ID != "")
            {
                NeuObject obj = Environment.GetAnes(apply.AnesType.ID.ToString());

                if (obj != null)
                {
                    fpSpread1_Sheet1.SetValue(row, (int)Cols.anaeType, obj.Name, false);
                    fpSpread1_Sheet1.SetTag(row, (int)Cols.anaeType, obj);
                }
            }



            //是否急诊
            if (apply.OperateKind == "2")
            {
                fpSpread1_Sheet1.RowHeader.Cells[row, 0].BackColor = Color.Red;
                fpSpread1_Sheet1.RowHeader.Cells[row, 0].Text = "急";
            }
            fpSpread1_Sheet1.Cells[row, 0, row, 8].CellType = txtType;

            if (apply.RoleAl != null && apply.RoleAl.Count != 0)
            {
                foreach (ArrangeRole role in apply.RoleAl)
                {
                    if (role.RoleType.ID.ToString() == EnumOperationRole.Anaesthetist.ToString())//主麻
                    {
                        string name = role.Name;
                        if (role.RoleOperKind.ID != null)
                        {
                            //直落
                            if (role.RoleOperKind.ID.ToString() == EnumRoleOperKind.ZL.ToString())
                                name = name + "|▲";
                            //接班
                            else if (role.RoleOperKind.ID.ToString() == EnumRoleOperKind.JB.ToString())
                                name = name + "|△";
                        }
                        fpSpread1_Sheet1.SetValue(row, (int)Cols.anaeDoct, name, false);
                        NeuObject obj = (NeuObject)role;
                        obj.Memo = role.RoleOperKind.ID.ToString();
                        fpSpread1_Sheet1.Cells[row, (int)Cols.anaeDoct].Tag = obj;
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.AnaesthesiaHelper.ToString())//助手
                    {
                        string name = role.Name;
                        if (role.RoleOperKind.ID != null)
                        {
                            //直落
                            if (role.RoleOperKind.ID.ToString() == EnumRoleOperKind.ZL.ToString())
                                name = name + "|▲";
                            //接班
                            else if (role.RoleOperKind.ID.ToString() == EnumRoleOperKind.JB.ToString())
                                name = name + "|△";
                        }
                        fpSpread1_Sheet1.SetValue(row, (int)Cols.anaeHelper, name, false);
                        NeuObject obj = (NeuObject)role;
                        obj.Memo = role.RoleOperKind.ID.ToString();
                        fpSpread1_Sheet1.Cells[row, (int)Cols.anaeHelper].Tag = obj;
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.AnaeTmpHelper1.ToString()) 
                    {
                        fpSpread1_Sheet1.SetValue(row, (int)Cols.anaeTmpHelper1, role.Name, false);
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.AnaeTmpHelper2.ToString())
                    {
                        fpSpread1_Sheet1.SetValue(row, (int)Cols.anaeTmpHelper2, role.Name, false);

                    }
                }
            }
            //手术台
            if (apply.OpsTable != null)
            {
                fpSpread1_Sheet1.SetValue(row, (int)Cols.TableID, apply.OpsTable.Name, false);
                NeuObject obj = new NeuObject();
                obj.ID = apply.OpsTable.ID;
                obj.Name = apply.OpsTable.Name;
                fpSpread1_Sheet1.Cells[row, (int)Cols.TableID].Tag = obj;
            }

            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
            fpSpread1_Sheet1.Cells[row, (int)Cols.anaeWay].CellType = txtType;
            fpSpread1_Sheet1.SetValue(row, (int)Cols.anaeWay, this.anneObjectHelper.GetName(apply.AnesWay));
            fpSpread1_Sheet1.Cells[row, (int)Cols.TableID].CellType = txtType;

            return 0;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Reset()
        {
            this.fpSpread1_Sheet1.RowCount = 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {

            //数据库事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new 
            //    Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();

            List<int> succeed = new List<int>();        //成功安排的

            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                //麻醉方式
                NeuObject type = fpSpread1_Sheet1.GetTag(i, (int)Cols.anaeType) as NeuObject;
                //没有录入麻醉方式，不处理
                if (type == null || type.ID.Length == 0)
                    continue;
                //主麻
                NeuObject anaeDoct = fpSpread1_Sheet1.GetTag(i, (int)Cols.anaeDoct) as NeuObject;
                //没有主麻，不处理
                if (anaeDoct == null || anaeDoct.ID.Length == 0)
                    continue;

                NeuObject tt = fpSpread1_Sheet1.GetTag(i, (int)Cols.anaeHelper) as NeuObject;
                if (tt != null && tt.ID != "" && anaeDoct.ID == tt.ID)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("主麻和助手不能是同一个人");
                    return -1;
                }
                //手术申请实体
                //OperationAppllication apply = fpSpread1_Sheet1.Rows[i].Tag as OperationAppllication;
                //{3DC153BD-1E9B-40c4-AAFC-3C27607A8945}
                OperationAppllication applyOriginal = fpSpread1_Sheet1.Rows[i].Tag as OperationAppllication;
                if (applyOriginal == null)
                {
                    MessageBox.Show("实体转换出错！");
                    return -1;
                }
                OperationAppllication apply = Environment.OperationManager.GetOpsApp(applyOriginal.ID);
                if (apply == null)
                {
                    MessageBox.Show("获取手术信息出错！");
                    return -1;
                }
                if (apply.ID == "")
                {
                    continue;
                }

                //trans.BeginTransaction();
                Environment.OperationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                try
                {
                    //添加麻醉方式到手术实体
                    apply.AnesType = type;
                    //添加主麻、助手
                    this.AddRole(apply, i);
                    //标志为已安排麻醉
                    //apply.bAnesth=true;

                    if (Environment.OperationManager.UpdateApplication(apply) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("保存麻醉(" + apply.ID + ")安排信息失败！\n请与系统管理员联系。" + Environment.OperationManager.Err, "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -1;
                    }
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    succeed.Add(i);
                }
                catch (Exception e)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存麻醉(" + apply.ID + ")安排信息出错!" + e.Message, "提示");
                    return -1;
                }
                //更新界面显示
                fpSpread1_Sheet1.Rows[i].Tag = apply;
                //fpSpread1_Sheet1.Cells[i,(int)Cols.Name].Note="已安排";

                //////////////////////////////////////////////////////////////////////////                
                // Robin认为下面这个函数没有用
                //this.UpdateFlag(apply);
                //////////////////////////////////////////////////////////////////////////


            }

            if (succeed.Count > 0)
            {
                string line = string.Empty;
                int temp = 0;
                for (int i = 0; i < succeed.Count; i++)
                {
                    line += i.ToString() + ",";
                }
                line = line.Substring(0, line.Length - 1);
                //temp = Neusoft.FrameWork.Function.NConvert.ToInt32 (line) + 1;
                //MessageBox.Show(string.Format("第{0}行手术安排成功。", temp.ToString()), "提示");
                MessageBox.Show("麻醉安排成功", "提示");
                fpSpread1.Focus();
            }
            else
            {
                MessageBox.Show("没有可安排的手术申请!", "提示");
                fpSpread1.Focus();
            }

            return 0;
        }

        /// <summary>
        /// 添加主麻、助手
        /// </summary>
        /// <param name="apply"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private int AddRole(OperationAppllication apply, int row)
        {
            ArrayList roles = new ArrayList();
            //先清空主麻、助手
            for (int i = 0; i < apply.RoleAl.Count; i++)
            {
                ArrangeRole role = apply.RoleAl[i] as ArrangeRole;
                if (
                    role.RoleType.ID.ToString() != EnumOperationRole.Anaesthetist.ToString()      &&
                    role.RoleType.ID.ToString() != EnumOperationRole.AnaesthesiaHelper.ToString() &&
                    role.RoleType.ID.ToString() != EnumOperationRole.AnaeTmpHelper1.ToString()    &&
                    role.RoleType.ID.ToString() != EnumOperationRole.AnaeTmpHelper2.ToString()
                    )
                {
                    roles.Add(role.Clone());
                }
            }

            //添加主麻
            NeuObject obj = fpSpread1_Sheet1.GetTag(row, (int)Cols.anaeDoct) as NeuObject;
            if (obj != null)
            {
                ArrangeRole role = new ArrangeRole(obj);
                role.RoleType.ID = EnumOperationRole.Anaesthetist;//角色编码
                if (obj.Memo == "ZL")
                    role.RoleOperKind.ID = EnumRoleOperKind.ZL;
                else if (obj.Memo == "JB")
                    role.RoleOperKind.ID = EnumRoleOperKind.JB;

                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象	
            }
            //添加助手
            obj = fpSpread1_Sheet1.GetTag(row, (int)Cols.anaeHelper) as NeuObject;
            if (obj != null)
            {
                ArrangeRole role = new ArrangeRole(obj);

                role.RoleType.ID = EnumOperationRole.AnaesthesiaHelper;//角色编码
                if (obj.Memo == "ZL")
                    role.RoleOperKind.ID = EnumRoleOperKind.ZL;
                else if (obj.Memo == "JB")
                    role.RoleOperKind.ID = EnumRoleOperKind.JB;

                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象	
            }

            //添加临时麻醉助手1
            string tmpHelper1 = fpSpread1_Sheet1.GetText(row, (int)Cols.anaeTmpHelper1);
            if (tmpHelper1 != null && tmpHelper1 != "")
            {
                ArrangeRole role = new ArrangeRole();
                role.ID = "777777";
                role.RoleType.ID = EnumOperationRole.AnaeTmpHelper1;//角色编码
                role.Name = tmpHelper1;
                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象
            }

            //添加临时麻醉助手2
            string tmpHelper2 = fpSpread1_Sheet1.GetText(row, (int)Cols.anaeTmpHelper2);
            if (tmpHelper2 != null && tmpHelper2 != "")
            {
                ArrangeRole role = new ArrangeRole();
                role.ID = "777777";
                role.RoleType.ID = EnumOperationRole.AnaeTmpHelper2;//角色编码
                role.Name = tmpHelper2;
                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象
            }


            apply.RoleAl = roles;

            return 0;
        }
        //更新实体的安排标志
        //private int UpdateFlag(OpsApplication apply)
        //{
        //    for (int index = 0; index < alApplys.Count; index++)
        //    {
        //        neusoft.HISFC.Object.Operator.OpsApplication obj = alApplys[index] as neusoft.HISFC.Object.Operator.OpsApplication;
        //        if (obj.OperationNo == apply.OperationNo)
        //        {
        //            alApplys.Remove(obj);
        //            alApplys.Insert(index, apply);
        //            break;
        //        }
        //    }
        //    return 0;
        //}
        /// <summary>
        /// 更新数据
        /// </summary>
        private OperationAppllication UpdateData(int rowIndex)
        {
            //麻醉方式
            NeuObject type = fpSpread1_Sheet1.GetTag(rowIndex, (int)Cols.anaeType) as NeuObject;
            //没有录入麻醉方式，不处理
            //if (type == null || type.ID.Length == 0)
            //return null;
            //主麻
            //NeuObject anaeDoct = fpSpread1_Sheet1.GetTag(rowIndex, (int)Cols.anaeDoct) as NeuObject;
            //没有主麻，不处理
            //if (anaeDoct == null || anaeDoct.ID.Length == 0)
            //return null;

            //NeuObject tt = fpSpread1_Sheet1.GetTag(rowIndex, (int)Cols.anaeHelper) as NeuObject;
            //if (tt != null && tt.ID != "" && anaeDoct.ID == tt.ID)
            //{
            //    MessageBox.Show("主麻和助手不能是同一个人");
            //    return null;
            //}
            //手术申请实体
            OperationAppllication apply = fpSpread1_Sheet1.Rows[rowIndex].Tag as OperationAppllication;


            try
            {
                //添加麻醉方式到手术实体
                apply.AnesType = type;
                //添加主麻、助手
                this.AddRole(apply, rowIndex);
            }
            catch
            {
                return null;
            }
            //更新界面显示
            fpSpread1_Sheet1.Rows[rowIndex].Tag = apply;

            return apply;
        }
        public int Print()
        {
            //if (this.arrangePrint == null)
            //{
            //    //this.arrangePrint = new ucArrangePrint();
            //    this.arrangePrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Operation.IArrangePrint)) as Neusoft.HISFC.BizProcess.Interface.Operation.IArrangePrint;
            //    if (this.arrangePrint == null)
            //    {
            //        MessageBox.Show("获得接口IArrangePrint错误，请与系统管理员联系。");

            //        return -1;
            //    }
            //}

            //this.arrangePrint.Title = "麻醉安排一览表";
            //this.arrangePrint.Date = this.date;
            //this.arrangePrint.ArrangeType = Neusoft.HISFC.BizProcess.Interface.Operation.EnumArrangeType.Anaesthesia;
            //this.arrangePrint.Reset();
            //for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            //{
            //    this.arrangePrint.AddAppliction(this.UpdateData(i));
            //}
            //return this.arrangePrint.PrintPreview();
            if (this.fpSpread1_Sheet1.RowCount > 0)
            {
                try
                {
                    this.fpSpread1_Sheet1.PrintInfo.ShowBorder = false;
                    this.fpSpread1_Sheet1.PrintInfo.Preview = true;

                    this.fpSpread1_Sheet1.PrintInfo.UseMax = false;
                    //this.fpSpread1_Sheet1.PrintInfo.PrintType = FarPoint.Win.Spread.PrintType.All;
                    
                    this.fpSpread1.PrintSheet(this.fpSpread1.ActiveSheetIndex);
                    //MessageBox.Show("打印成功");
                    return 1;
                }
                catch
                {
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("没有可以打印的数据！");
                return -1;
            }
        }

        public int Export()
        {
            if (this.fpSpread1_Sheet1.RowCount > 0)
            {
                if (this.fpSpread1.Export() == 1)
                {
                    MessageBox.Show("导出成功");
                    return 1;
                }

                return -1;
            }
            else 
            {
                MessageBox.Show("没有可以导出的数据！");
                return -1;
            }
        }
        #endregion

        #region columns
        private enum Cols
        {
            nurseID,
            bedID,
            Name,
            Sex,
            age,
            Diagnose,
            opItemName,
            opDoc,
            anaeNote,
            //麻醉类型
            anaeWay,
            /// <summary>
            /// 麻醉方式
            /// </summary>
            anaeType,
            /// <summary>
            /// 主麻
            /// </summary>
            anaeDoct,
            /// <summary>
            /// 助手
            /// </summary>
            anaeHelper,
            /// <summary>
            /// 手术台
            /// </summary>
            TableID,
            /// <summary>
            /// 麻醉临时助手1
            /// </summary>
            anaeTmpHelper1,
            /// <summary>
            /// 麻醉临时助手2
            /// </summary>
            anaeTmpHelper2
        }
        #endregion

        #region 事件
        private void fpSpread1_EditModeOn(object sender, EventArgs e)
        {
            //fpSpread1.EditingControl.KeyDown += new KeyEventHandler(EditingControl_KeyDown);
            //this.SetLocation();
            //if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.anaeType)
            //    this.lbAnaetype.Visible = true;
            //else
            //    lbAnaetype.Visible = false;

            //if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.anaeDoct ||
            //    fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.anaeHelper)
            //    this.lbDoctor.Visible = true;
            //else
            //    lbDoctor.Visible = false;
        }


        private void fpSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            //string _Text;
            ////麻醉方式
            //if (e.Column == (int)Cols.anaeType)
            //{
            //    _Text = fpSpread1_Sheet1.ActiveCell.Text;
            //    lbAnaetype.Filter(_Text);

            //    if (lbAnaetype.Visible == false) lbAnaetype.Visible = true;
            //    fpSpread1_Sheet1.SetTag(e.Row, e.Column, null);
            //}
            ////助手、主麻
            //else if (e.Column == (int)Cols.anaeDoct || e.Column == (int)Cols.anaeHelper)
            //{
            //    //if (IsChange) return;
            //    _Text = fpSpread1_Sheet1.ActiveCell.Text;
            //    lbDoctor.Filter(_Text);

            //    if (lbDoctor.Visible == false) 
            //        lbDoctor.Visible = true;
            //    fpSpread1_Sheet1.SetTag(e.Row, e.Column, null);
            //}
        }
        #endregion

        private void fpSpread1_EditModeOff(object sender, EventArgs e)
        {

        }

        private void fpSpread1_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            if (this.applictionSelected != null)
            {
                this.applictionSelected(this, this.fpSpread1_Sheet1.Rows[e.Row].Tag as OperationAppllication);
            }
        }

        //private void lbDoctor_ItemSelected(object sender, System.EventArgs e)
        //{
        //    this.SelectDoctor(fpSpread1_Sheet1.ActiveColumnIndex);

        //}

        //private void lbAnaetype_ItemSelected(object sender, System.EventArgs e)
        //{
        //    this.SelectType();
        //}

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get { return new Type[] { typeof(Neusoft.HISFC.BizProcess.Interface.Operation.IArrangePrint) }; }
        }

        #endregion
    }
}

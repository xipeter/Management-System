using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using Neusoft.HISFC.Models.Operation;
using Neusoft.FrameWork.Models;
using Neusoft.FrameWork;

namespace Neusoft.HISFC.Components.Operation
{
    public delegate void ApplicationSelectedEventHandler(object sender, OperationAppllication e);
    /// <summary>
    /// [功能描述: 手术安排设置信息]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-04]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucArrangementSpread : UserControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucArrangementSpread()
        {
            InitializeComponent();
            if (!Environment.DesignMode)
            {
                this.Init();
                this.InitNurseListBox();
                this.InitRoomListBox();
                //this.InitTableListBox();
            }
        }

        #region 字段

        public event ApplicationSelectedEventHandler applictionSelected;
        Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

        /// <summary>
        /// 手术列表
        /// </summary>
        private ArrayList alApplys = new ArrayList();
        private ArrayList alRooms = new ArrayList();
        //private ArrayList alAnes;   //麻醉方式列表

        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbNurse = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbRoom = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbTable = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();

        private Neusoft.HISFC.BizProcess.Interface.Operation.IArrangePrint arrangePrint;
        private DateTime date;

        private EnumFilter filter = EnumFilter.All;
        private int rowindex;

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

        public EnumFilter Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                this.filter = value;
                if (value == EnumFilter.All)
                {
                    for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                    {
                        this.fpSpread1_Sheet1.Rows[i].Visible = true;
                    }
                }
                else if (value == EnumFilter.NotYet)
                {
                    for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                    {
                        if ((this.fpSpread1_Sheet1.Rows[i].Tag as OperationAppllication).ExecStatus != "3")
                            this.fpSpread1_Sheet1.Rows[i].Visible = true;
                        else
                            this.fpSpread1_Sheet1.Rows[i].Visible = false;
                    }
                }
                else
                {
                    for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                    {
                        if ((this.fpSpread1_Sheet1.Rows[i].Tag as OperationAppllication).ExecStatus == "3")
                            this.fpSpread1_Sheet1.Rows[i].Visible = true;
                        else
                            this.fpSpread1_Sheet1.Rows[i].Visible = false;
                    }
                }
            }
        }
        public enum EnumFilter
        {
            /// <summary>
            /// 全部
            /// </summary>
            All,
            /// <summary>
            /// 未安排
            /// </summary>
            NotYet,
            /// <summary>
            /// 已安排
            /// </summary>
            Already
        }


        #endregion

        #region 方法

        private void Init()
        {

            this.fpSpread1.SetInputMap();
            //this.fpSpread1.AddListBoxPopup(lbNurse, 10);
            //this.fpSpread1.AddListBoxPopup(lbNurse, 11);
            //this.fpSpread1.AddListBoxPopup(this.lbRoom, 12);
            //this.fpSpread1.AddListBoxPopup(lbTable, 13);
            //this.fpSpread1.AddListBoxPopup(lbNurse, 15);
            //this.fpSpread1.AddListBoxPopup(lbNurse, 16);

            this.fpSpread1.AddListBoxPopup(lbNurse, (int)Cols.WNR);
            this.fpSpread1.AddListBoxPopup(lbNurse, (int)Cols.INR);
            this.fpSpread1.AddListBoxPopup(this.lbRoom, (int)Cols.RoomID);
            //this.fpSpread1.AddListBoxPopup(lbTable, (int)Cols.TableID);
            this.fpSpread1.AddListBoxPopup(lbNurse, (int)Cols.WNR2);
            this.fpSpread1.AddListBoxPopup(lbNurse, (int)Cols.INR2);
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.DateTimeCellType dtCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.DateTimeCellType();
            dtCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
            this.fpSpread1_Sheet1.Columns[(int)Cols.opDate].CellType = dtCellType;

            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
            System.Collections.ArrayList al = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ANESWAY);
            this.anneObjectHelper.ArrayObject = al;
        }
        /// <summary>
        /// 添加护士listbox列表
        /// </summary>
        /// <returns></returns>
        private int InitNurseListBox()
        {
            ArrayList nurses = Environment.IntegrateManager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.N, Environment.OperatorDeptID);

            //ArrayList al = new ArrayList();
            //if (nurses != null)
            //{
            //    foreach (neusoft.HISFC.Object.RADT.Person nurse in nurses)
            //    {
            //        NeuObject obj = (NeuObject)nurse;
            //        al.Add(obj);
            //    }
            //}
            lbNurse.AddItems(nurses);

            this.Controls.Add(lbNurse);
            this.lbNurse.Hide();
            this.lbNurse.BorderStyle = BorderStyle.FixedSingle;
            this.lbNurse.BringToFront();
            this.lbNurse.ItemSelected += new System.EventHandler(this.lbNurse_ItemSelected);

            return 0;
        }

        private void InitRoomListBox()
        {
            this.RefreshRoomListBox();

            this.Controls.Add(this.lbRoom);
            this.lbRoom.Hide();
            this.lbRoom.BorderStyle = BorderStyle.FixedSingle;
            this.lbRoom.BringToFront();
            this.lbRoom.ItemSelected += new System.EventHandler(this.lbRoom_ItemSelected);

        }
        //生成手术间列表
        private void RefreshRoomListBox()
        {
            ArrayList al = new ArrayList();

            ArrayList rooms = Environment.TableManager.GetRoomsByDept(Environment.OperatorDeptID);
            if (rooms != null)
            {
                foreach (Neusoft.HISFC.Models.Operation.OpsRoom room in rooms)
                {
                    alRooms.Add(room);
                    if (room.IsValid == false)
                        continue;
                    //因为table类没有实现ISpell接口，所以借用department类
                    Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
                    //dept.ID = room.ID;
                    //dept.Name = room.Name;
                    //dept.SpellCode = room.InputCode;
                    dept.ID = room.Name;
                    dept.Name = room.Name;
                    dept.Memo = room.ID;
                    al.Add(dept);
                }
            }
            lbRoom.AddItems(al);
        }

        //private void InitTableListBox()
        //{


        //    this.Controls.Add(this.lbTable);
        //    this.lbTable.Hide();
        //    this.lbTable.BorderStyle = BorderStyle.FixedSingle;
        //    this.lbTable.BringToFront();
        //    this.lbTable.ItemSelected += new System.EventHandler(this.lbTable_ItemSelected);

        //}
        //添加手术台listbox列表
        //private int RefreshTableListBox(string roomID)
        //{
        //    ArrayList al = Environment.TableManager.GetOpsTable(roomID);
        //    ArrayList tables = new ArrayList();
        //    if (al != null)
        //    {
        //        foreach (OpsTable table in al)
        //        {
        //            if (table.IsValid == false) continue;
        //            //因为table类没有实现ISpell接口，所以借用department类
        //            Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
        //            dept.ID = table.ID;
        //            dept.Name = table.Name;
        //            dept.SpellCode = table.InputCode;
        //            tables.Add(dept);
        //        }
        //    }

        //    lbTable.AddItems(tables);

        //    return 0;
        //}
        /// <summary>
        ///  选择护士
        /// </summary>
        /// <param name="Column"></param>
        /// <returns></returns>
        private int SelectNurse(int Column)
        {
            int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
            if (CurrentRow < 0) return 0;

            fpSpread1.StopCellEditing();
            NeuObject item = this.lbNurse.GetSelectedItem();

            if (item == null)
                return -1;

            fpSpread1_Sheet1.Cells[CurrentRow, Column].Tag = item;
            fpSpread1_Sheet1.SetValue(CurrentRow, Column, item.Name, false);

            lbNurse.Visible = false;

            return 0;
        }

        //选择房号
        private int SelectRoom()
        {
            int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
            if (CurrentRow < 0) return 0;

            fpSpread1.StopCellEditing();
            NeuObject item = null;
            item = lbRoom.GetSelectedItem();

            if (item == null) return -1;

            NeuObject tmp = new NeuObject(item.Memo, item.Name, "");

            fpSpread1_Sheet1.Cells[CurrentRow, (int)Cols.RoomID].Tag = tmp;
            fpSpread1_Sheet1.SetValue(CurrentRow, (int)Cols.RoomID, tmp.Name, false);

            //this.refreshTableListBox(item.ID);

            lbRoom.Visible = false;

            return 0;
        }

        //选择手术台
        //private int SelectTable()
        //{
        //    int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;

        //    if (CurrentRow < 0) return 0;

        //    fpSpread1.StopCellEditing();
        //    NeuObject item = null;
        //    item = lbTable.GetSelectedItem();

        //    if (item == null) return -1;

        //    fpSpread1_Sheet1.Cells[CurrentRow, (int)Cols.TableID].Tag = item;
        //    fpSpread1_Sheet1.SetValue(CurrentRow, (int)Cols.TableID, item.Name, false);

        //    lbTable.Visible = false;

        //    NeuObject tab = null;
        //    fpSpread1_Sheet1.Cells[CurrentRow, (int)Cols.TableID].Tag = tab;
        //    fpSpread1_Sheet1.SetValue(CurrentRow, (int)Cols.TableID, tab.Name, false);


        //    ArrayList al = Environment.TableManager.GetOpsTable(roomID);
        //    ArrayList tables = new ArrayList();
        //    if (al != null)
        //    {
        //        foreach (OpsTable table in al)
        //        {
        //            if (table.IsValid == false) continue;
        //            //因为table类没有实现ISpell接口，所以借用department类
        //            Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
        //            dept.ID = table.ID;
        //            dept.Name = table.Name;
        //            dept.SpellCode = table.InputCode;
        //            tables.Add(dept);
        //        }
        //    }

        //    lbTable.AddItems(tables);

        //    return 0;
        //}


        /// <summary>
        /// 设置护士、手术台列表位置
        /// </summary>
        /// <returns></returns>
        private int SetLocation()
        {

            Control _cell = fpSpread1.EditingControl;
            if (_cell == null) return 0;

            //洗手、巡回护士
            int Column = fpSpread1_Sheet1.ActiveColumnIndex;
            if (Column == (int)Cols.WNR || Column == (int)Cols.INR || Column == (int)Cols.WNR2)
            {
                lbNurse.Location = new Point(_cell.Location.X,
                    _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                lbNurse.Size = new Size(110, 150);
            }
            else if (Column == (int)Cols.INR2)
            {
                lbNurse.Location = new Point(_cell.Location.X + _cell.Width - 110,
                     _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                lbNurse.Size = new Size(110, 150);
            }
            else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.TableID)
            {
                lbTable.Location = new Point(_cell.Location.X,
                    _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                lbTable.Size = new Size(110, 150);
            }
            else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.RoomID)
            {
                lbRoom.Location = new Point(_cell.Location.X,
                    _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                lbRoom.Size = new Size(110, 150);
            }

            return 0;
        }
        /// <summary>
        /// 添加手术申请信息
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        public int AddOperationApplication(Neusoft.HISFC.Models.Operation.OperationAppllication apply)
        {
            //放入动态数组
            this.alApplys.Add(apply);

            fpSpread1_Sheet1.Rows.Add(fpSpread1_Sheet1.RowCount, 1);
            int row = fpSpread1_Sheet1.RowCount - 1;

            FarPoint.Win.Spread.CellType.TextCellType txtType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtType.StringTrim = System.Drawing.StringTrimming.EllipsisWord;
            txtType.ReadOnly = true;
            fpSpread1_Sheet1.Rows[row].Tag = apply;
            //护士站
            if (deptManager == null)
                deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            Neusoft.HISFC.Models.Base.Department dept = deptManager.GetDepartment(apply.PatientInfo.PVisit.PatientLocation.Dept.ID);
            apply.PatientInfo.PVisit.PatientLocation.Name = dept.Name;
            if (dept != null)
            {
                fpSpread1_Sheet1.SetValue(row, (int)Cols.nurseID, dept.Name, false);
            }
            //患者姓名
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Name, apply.PatientInfo.Name, false);
            //性别
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Sex, apply.PatientInfo.Sex.Name, false);
            //年龄
            //int age = this.dataManager.GetDateTimeFromSysDateTime().Year - apply.PatientInfo.Birthday.Year;
            //if (age == 0) age = 1;
            string age = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(apply.PatientInfo.Birthday);
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Age, age, false);
            //是否已安排
            if (apply.ExecStatus == "3")
                fpSpread1_Sheet1.Cells[row, (int)Cols.Name].Note = "已安排";
            else
                fpSpread1_Sheet1.Cells[row, (int)Cols.Name].Note = "";
            //台序
            //fpSpread1_Sheet1.SetValue(row, (int)Cols.Order, apply.BloodUnit, false);
            //手术台类型
            //switch (apply.TableType)
            //{
            //    case "1":
            //        fpSpread1_Sheet1.SetValue(row, (int)Cols.Desk, "正台", false);
            //        break;
            //    case "2":
            //        fpSpread1_Sheet1.SetValue(row, (int)Cols.Desk, "加台", false);
            //        break;
            //    case "3":
            //        fpSpread1_Sheet1.SetValue(row, (int)Cols.Desk, "点台", false);
            //        break;
            //}

            //主手术名称            
            fpSpread1_Sheet1.SetValue(row, (int)Cols.opItemName, apply.MainOperationName, false);

            Neusoft.FrameWork.Models.NeuObject obj = null;
            //麻醉方式
            if (apply.AnesType.ID != null && apply.AnesType.ID.Length != 0)
            {
                obj = Environment.GetAnes(apply.AnesType.ID);
                if (obj != null)
                {
                    fpSpread1_Sheet1.SetValue(row, (int)Cols.anaeType, obj.Name, false);
                    apply.AnesType.Name = obj.Name;
                }
            }
            else
            {
                fpSpread1_Sheet1.Cells[row, (int)Cols.anaeType].Note = "未安排麻醉";
            }

            //手术医生
            fpSpread1_Sheet1.SetValue(row, (int)Cols.opDoctID, apply.OperationDoctor.Name, false);
            //是否急诊
            if (apply.OperateKind == "2")
            {
                fpSpread1_Sheet1.RowHeader.Cells[row, 0].BackColor = Color.Red;
                fpSpread1_Sheet1.RowHeader.Cells[row, 0].Text = "急";
            }
            fpSpread1_Sheet1.Cells[row, 0, row, 7].CellType = txtType;

            //手术时间
            fpSpread1_Sheet1.SetValue(row, (int)Cols.opDate, apply.PreDate, false);
            #region 护士
            if (apply.RoleAl != null && apply.RoleAl.Count != 0)
            {
                foreach (Neusoft.HISFC.Models.Operation.ArrangeRole role in apply.RoleAl)
                {
                    if (role.RoleType.ID.ToString() == EnumOperationRole.WashingHandNurse.ToString()) //洗手护士                        
                    {
                        if (fpSpread1_Sheet1.Cells[row, (int)Cols.WNR].Text == "") //第一洗手护士
                        {
                            fpSpread1_Sheet1.SetValue(row, (int)Cols.WNR, role.Name, false);
                            obj = (Neusoft.FrameWork.Models.NeuObject)role;
                            fpSpread1_Sheet1.SetTag(row, (int)Cols.WNR, obj);
                        }
                        else
                        {   //第二洗手护士
                            fpSpread1_Sheet1.SetValue(row, (int)Cols.WNR2, role.Name, false);
                            obj = (NeuObject)role;
                            fpSpread1_Sheet1.SetTag(row, (int)Cols.WNR2, obj);
                        }
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.ItinerantNurse.ToString())//巡回护士
                    {
                        if (fpSpread1_Sheet1.Cells[row, (int)Cols.INR].Text == "")
                        {   //第一巡回护士 
                            fpSpread1_Sheet1.SetValue(row, (int)Cols.INR, role.Name, false);
                            obj = (NeuObject)role;
                            fpSpread1_Sheet1.SetTag(row, (int)Cols.INR, obj);
                        }
                        else
                        {
                            //第二巡回护士
                            fpSpread1_Sheet1.SetValue(row, (int)Cols.INR2, role.Name, false);
                            obj = (NeuObject)role;
                            fpSpread1_Sheet1.SetTag(row, (int)Cols.INR2, obj);
                        }

                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpHelper1.ToString())
                    {
                        if (string.IsNullOrEmpty(fpSpread1_Sheet1.Cells[row, (int)Cols.TmpHelper1].Text))
                        {
                            fpSpread1_Sheet1.SetValue(row, (int)Cols.TmpHelper1, role.Name, false);
                            obj = (NeuObject)role;
                            fpSpread1_Sheet1.SetTag(row, (int)Cols.TmpHelper1, obj);
                        }
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpHelper2.ToString())
                    {
                        if (string.IsNullOrEmpty(fpSpread1_Sheet1.Cells[row, (int)Cols.TmpHelper2].Text))
                        {
                            fpSpread1_Sheet1.SetValue(row, (int)Cols.TmpHelper2, role.Name, false);
                            obj = (NeuObject)role;
                            fpSpread1_Sheet1.SetTag(row, (int)Cols.TmpHelper2, obj);
                        }
                    }
                    #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpStudent1.ToString())
                    {
                        if (string.IsNullOrEmpty(fpSpread1_Sheet1.Cells[row, (int)Cols.TmpStudent1].Text))
                        {
                            fpSpread1_Sheet1.SetValue(row, (int)Cols.TmpStudent1, role.Name, false);
                            obj = (NeuObject)role;
                            fpSpread1_Sheet1.SetTag(row, (int)Cols.TmpStudent1, obj);
                        }
                    }
                    else if (role.RoleType.ID.ToString() == EnumOperationRole.TmpStudent2.ToString())
                    {
                        if (string.IsNullOrEmpty(fpSpread1_Sheet1.Cells[row, (int)Cols.TmpStudent2].Text))
                        {
                            fpSpread1_Sheet1.SetValue(row, (int)Cols.TmpStudent2, role.Name, false);
                            obj = (NeuObject)role;
                            fpSpread1_Sheet1.SetTag(row, (int)Cols.TmpStudent2, obj);
                        }
                    } 
                    #endregion
                }
            }
            #endregion
            //手术间
            if (apply.RoomID != null && apply.RoomID != "")
            {
                obj = GetRoom(apply.RoomID);
                fpSpread1_Sheet1.SetValue(row, (int)Cols.RoomID, obj.Name, false);
                fpSpread1_Sheet1.SetTag(row, (int)Cols.RoomID, obj);
            }
            #region 手术台
            if (apply.OpsTable.ID != null && apply.OpsTable.ID != "")
            {
                fpSpread1_Sheet1.SetValue(row, (int)Cols.TableID, apply.OpsTable.Name, false);
                obj = new NeuObject();
                obj.ID = apply.OpsTable.ID;
                obj.Name = apply.OpsTable.Name;
                fpSpread1_Sheet1.SetTag(row, (int)Cols.TableID, obj);
            }

            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
            fpSpread1_Sheet1.Cells[row, (int)Cols.anaeWay].CellType = txtType;
            fpSpread1_Sheet1.SetValue(row, (int)Cols.anaeWay, this.anneObjectHelper.GetName(apply.AnesWay));
            fpSpread1_Sheet1.Cells[row, (int)Cols.TableID].CellType = txtType;

            #endregion

            return 0;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Reset()
        {
            this.fpSpread1_Sheet1.RowCount = 0;
            this.alApplys.Clear();
        }
        /// <summary>
        /// 获取手术房间
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        private NeuObject GetRoom(string roomID)
        {
            NeuObject obj = new NeuObject();
            foreach (OpsRoom room in alRooms)
            {
                if (roomID == room.ID)
                {
                    obj.ID = room.ID;
                    obj.Name = room.Name;
                    return obj;
                }
            }
            obj.ID = roomID;
            obj.Name = "无";
            return obj;
        }

        public int SetStop() 
        {
            OperationAppllication apply = fpSpread1_Sheet1.Rows[fpSpread1_Sheet1.ActiveRowIndex].Tag as OperationAppllication;

            if (apply != null)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                Environment.OperationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                try
                {

                    if (Environment.OperationManager.SetOpsStop(apply.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("置手术(" + apply.ID + ")停信息失败！\n请与系统管理员联系。" + Environment.OperationManager.Err, "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -1;
                    }
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    

                }
                catch (Exception e)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("置手术(" + apply.ID + ")停信息出错!" + e.Message, "提示");
                    return -1;
                }
            }
            else 
            {
                MessageBox.Show("没有手术信息");
                return -1;
            }

            return 1;
        }



        /// <summary>
        /// 校对数据 
        /// </summary>
        /// <returns></returns>
        private int ValueState()
        {
            for (int row = 0; row < this.fpSpread1_Sheet1.RowCount; row++)
            {
                NeuObject obj = fpSpread1_Sheet1.GetTag(row, (int)Cols.WNR) as NeuObject;
                NeuObject obj2 = fpSpread1_Sheet1.GetTag(row, (int)Cols.WNR2) as NeuObject;
                if (obj != null && obj2 != null)
                {
                    if (obj.ID == obj2.ID)
                    {
                        MessageBox.Show("洗手护士不能重复");
                        return -1;
                    }
                }
                NeuObject obj3 = fpSpread1_Sheet1.GetTag(row, (int)Cols.INR) as NeuObject;
                NeuObject obj4 = fpSpread1_Sheet1.GetTag(row, (int)Cols.INR2) as NeuObject;
                if (obj3 != null && obj4 != null)
                {
                    if (obj3.ID == obj4.ID)
                    {
                        MessageBox.Show("巡回护士不能重复");
                        return -1;
                    }
                }
                NeuObject tabRoom = fpSpread1_Sheet1.GetTag(row, (int)Cols.RoomID) as NeuObject;
                NeuObject tabTable = null; //= fpSpread1_Sheet1.GetTag(row, (int)Cols.TableID) as NeuObject;

                //if (tabRoom == null)
                //{
                //    MessageBox.Show("手术房间不能为空");
                //    return -1;
                //}

                

                #region {42CDE890-24B3-4d6f-A52B-988F62E226B8}
                if (obj != null || obj2 != null || obj3 != null || obj4 != null || tabRoom != null || tabTable != null)
                {

                    //没有录入手术台，不处理
                    if (tabRoom == null)
                    {
                        MessageBox.Show("请选择手术房间");
                        return -1;
                    }

                    ArrayList al = Environment.TableManager.GetOpsTable(tabRoom.ID);
                    if (al != null && al.Count > 0)
                    {
                        tabTable = al[0] as OpsTable;
                    }


                    //没有录入手术台，不处理
                    if (tabTable == null)
                    {
                        MessageBox.Show("请选择手术台号");
                        return -1;
                    }
                }
                #endregion
            }
            return 0;
        }

        /// <summary>
        /// 添加各类护士
        /// </summary>
        /// <param name="apply"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private int AddRole(OperationAppllication apply, int row)
        {
            ArrayList roles = new ArrayList();
            //先清空护士
            for (int i = 0; i < apply.RoleAl.Count; i++)
            {
                ArrangeRole role = apply.RoleAl[i] as ArrangeRole;
                #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
                if (
                            role.RoleType.ID.ToString() != EnumOperationRole.WashingHandNurse.ToString()
                             && role.RoleType.ID.ToString() != EnumOperationRole.ItinerantNurse.ToString()
                             && role.RoleType.ID.ToString() != EnumOperationRole.TmpHelper1.ToString()
                             && role.RoleType.ID.ToString() != EnumOperationRole.TmpHelper2.ToString()
                             && role.RoleType.ID.ToString() != EnumOperationRole.TmpStudent1.ToString()
                             && role.RoleType.ID.ToString() != EnumOperationRole.TmpStudent2.ToString()
                            )
                {
                    roles.Add(role.Clone());
                } 
                #endregion
            }

            //添加洗手护士
            NeuObject obj = fpSpread1_Sheet1.GetTag(row, (int)Cols.WNR) as NeuObject;
            if (obj != null)
            {
                ArrangeRole role = new ArrangeRole(obj);
                role.RoleType.ID = EnumOperationRole.WashingHandNurse;//角色编码
                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象	
                //第二洗手护士  可以不填
                if (fpSpread1_Sheet1.Cells[row, (int)Cols.WNR2].Tag != null)
                {
                    NeuObject obj2 = fpSpread1_Sheet1.GetTag(row, (int)Cols.WNR2) as NeuObject;
                    if (obj2 != null)
                    {
                        ArrangeRole role2 = new ArrangeRole(obj2);
                        role2.RoleType.ID = EnumOperationRole.WashingHandNurse;//角色编码
                        role2.OperationNo = apply.ID;
                        role2.ForeFlag = "0";//术前安排				
                        roles.Add(role2);//加入人员角色对象	
                    }
                }
            }
            //添加巡回护士
            NeuObject obj3 = fpSpread1_Sheet1.GetTag(row, (int)Cols.INR) as NeuObject;
            if (obj3 != null)
            {
                ArrangeRole role = new ArrangeRole(obj3);
                role.RoleType.ID = EnumOperationRole.ItinerantNurse;//角色编码
                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象
                if (fpSpread1_Sheet1.Cells[row, (int)Cols.INR2].Tag != null)
                {
                    //添加第二巡回护士
                    NeuObject obj4 = fpSpread1_Sheet1.GetTag(row, (int)Cols.INR2) as NeuObject;
                    if (obj4 != null)
                    {
                        ArrangeRole role2 = new ArrangeRole(obj4);
                        role2.RoleType.ID = role.RoleType.ID = EnumOperationRole.ItinerantNurse; ;//角色编码
                        role2.OperationNo = apply.ID;
                        role2.ForeFlag = "0";//术前安排				
                        roles.Add(role2);//加入人员角色对象
                    }
                }
            }

            //添加临时助手1
            string tmpHelper1 = fpSpread1_Sheet1.GetText(row, (int)Cols.TmpHelper1);
            if (tmpHelper1 != null && tmpHelper1 != "")
            {
                ArrangeRole role = new ArrangeRole();
                role.ID = "777777";
                role.RoleType.ID = EnumOperationRole.TmpHelper1;//角色编码
                role.Name = tmpHelper1;
                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象
            }

            //添加临时助手2
            string tmpHelper2 = fpSpread1_Sheet1.GetText(row, (int)Cols.TmpHelper2);
            if (tmpHelper2 != null && tmpHelper2 != "")
            {
                ArrangeRole role = new ArrangeRole();
                role.ID = "777777";
                role.RoleType.ID = EnumOperationRole.TmpHelper2;//角色编码
                role.Name = tmpHelper2;
                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象
            }

            #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
            //添加临时进修1
            string tmpStudent1 = fpSpread1_Sheet1.GetText(row, (int)Cols.TmpStudent1);
            if (tmpStudent1 != null && tmpStudent1 != "")
            {
                ArrangeRole role = new ArrangeRole();
                role.ID = "777777";
                role.RoleType.ID = EnumOperationRole.TmpStudent1;//角色编码
                role.Name = tmpStudent1;
                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象
            }

            //添加临时进修2
            string tmpStudent2 = fpSpread1_Sheet1.GetText(row, (int)Cols.TmpStudent2);
            if (tmpStudent2 != null && tmpStudent2 != "")
            {
                ArrangeRole role = new ArrangeRole();
                role.ID = "777777";
                role.RoleType.ID = EnumOperationRole.TmpStudent2;//角色编码
                role.Name = tmpStudent2;
                role.OperationNo = apply.ID;
                role.ForeFlag = "0";//术前安排				
                roles.Add(role);//加入人员角色对象
            } 
            #endregion



            apply.RoleAl = roles;

            return 0;
        }

        /// <summary>
        /// 更新实体的安排标志
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        private int UpdateFlag(OperationAppllication apply)
        {
            for (int index = 0; index < alApplys.Count; index++)
            {
                OperationAppllication obj = alApplys[index] as OperationAppllication;
                if (obj.ID == apply.ID)
                {
                    alApplys.Remove(obj);
                    alApplys.Insert(index, apply);
                    break;
                }
            }
            return 0;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        private OperationAppllication UpdateData(int rowIndex)
        {
            NeuObject tabRoom = fpSpread1_Sheet1.GetTag(rowIndex, (int)Cols.RoomID) as NeuObject;
            //没有录入手术台，不处理
            if (tabRoom == null)
                return null;

            OperationAppllication apply = fpSpread1_Sheet1.Rows[rowIndex].Tag as OperationAppllication;

            try
            {
                OpsTable tabTable = null; //= fpSpread1_Sheet1.GetTag(row, (int)Cols.TableID) as NeuObject;

                ArrayList al = Environment.TableManager.GetOpsTable(tabRoom.ID);
                if (al != null && al.Count > 0)
                {
                    tabTable = al[0] as OpsTable;
                }

                //添加手术台

                apply.OpsTable = tabTable;
                //添加手术房间
                NeuObject tab = fpSpread1_Sheet1.GetTag(rowIndex, (int)Cols.RoomID) as NeuObject;
                if (tab != null)
                    apply.RoomID = tab.ID;
                else
                    fpSpread1_Sheet1.SetValue(rowIndex, (int)Cols.RoomID, "", false);

                //手术时间
                string dt = fpSpread1_Sheet1.GetText(rowIndex, (int)Cols.opDate);
                dt = apply.PreDate.Year.ToString() + "-" + apply.PreDate.Month.ToString() + "-" + apply.PreDate.Day.ToString() + " " + dt;
                apply.PreDate = DateTime.Parse(dt);
                //添加各类护士
                this.AddRole(apply, rowIndex);

            }
            catch (Exception e)
            {

                return null;
            }

            return apply;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            if (this.ValueState() == -1)
            {
                return -1;

            }

            //数据库事务
            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);


            List<int> succeed = new List<int>();        //成功安排的
            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {

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


                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //trans.BeginTransaction();
                Environment.OperationManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                try
                {

                    ////////////////////////////////////////////////////////////////////////////////////////////////////
                    //添加手术房间
                    NeuObject room = fpSpread1_Sheet1.GetTag(i, (int)Cols.RoomID) as NeuObject;
                    if (room != null)
                        apply.RoomID = room.ID;
                    else
                        fpSpread1_Sheet1.SetValue(i, (int)Cols.RoomID, "", false);

                    //添加手术台
                    OpsTable tab = null;
                    if (room != null && !string.IsNullOrEmpty(room.ID))
                    {
                        ArrayList al = Environment.TableManager.GetOpsTable(room.ID);
                        if (al != null && al.Count > 0)
                        {
                            tab = al[0] as OpsTable;
                            apply.OpsTable = tab; //添加手术台
                        }
                        else //没有录入手术台，不处理
                        {
                            fpSpread1_Sheet1.Cells[i, (int)Cols.TableID].Text = "";
                            continue;
                        }
                    }
                    else 
                    {
                            fpSpread1_Sheet1.Cells[i, (int)Cols.TableID].Text = "";
                            continue;
                    }

                    //手术时间
                    string dt = fpSpread1_Sheet1.GetText(i, (int)Cols.opDate);
                    dt = apply.PreDate.Year.ToString() + "-" + apply.PreDate.Month.ToString() + "-" + apply.PreDate.Day.ToString() + " " + dt;
                    apply.PreDate = DateTime.Parse(dt);
                    //添加各类护士
                    this.AddRole(apply, i);
                    //标志为已安排
                    apply.ExecStatus = "3";

                    if (Environment.OperationManager.UpdateApplication(apply) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("保存手术(" + apply.ID + ")安排信息失败！\n请与系统管理员联系。" + Environment.OperationManager.Err, "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -1;
                    }
                    succeed.Add(i);
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                }
                catch (Exception e)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存手术(" + apply.ID + ")安排信息出错!" + e.Message, "提示");
                    return -1;
                }
                //更新界面显示
                fpSpread1_Sheet1.Rows[i].Tag = apply;
                fpSpread1_Sheet1.Cells[i, (int)Cols.Name].Note = "已安排";
                this.UpdateFlag(apply);

            }

            if (succeed.Count > 0)
            {
                string line = string.Empty;
                for (int i = 0; i < succeed.Count; i++)
                {
                    line += i.ToString() + ",";
                }
                line = line.Substring(0, line.Length - 1);
                MessageBox.Show(string.Format("手术安排成功。", line), "提示");
                fpSpread1.Focus();
                if (lbTable != null)
                {
                    lbTable.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("没有如入安排信息，无需保存");
            }

            return 0;
        }

        public int Print()
        {
            if (this.arrangePrint == null)
            {
                this.arrangePrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Operation.IArrangePrint)) as Neusoft.HISFC.BizProcess.Interface.Operation.IArrangePrint;
                if (this.arrangePrint == null)
                {
                    MessageBox.Show("获得接口IArrangePrint错误，请与系统管理员联系。");

                    return -1;
                }
            }

            this.arrangePrint.Title = "手术安排一览表";
            this.arrangePrint.Date = this.date;
            this.arrangePrint.ArrangeType = Neusoft.HISFC.BizProcess.Interface.Operation.EnumArrangeType.Operation;
            this.arrangePrint.Reset();
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                this.arrangePrint.AddAppliction(this.UpdateData(i));
            }
            return this.arrangePrint.PrintPreview();

        }

        /// <summary>
        /// 过滤
        /// </summary>
        public void SetFilter()
        {
            this.Filter = this.filter;
        }
        #endregion


        #region 事件
        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                #region enter
                if (fpSpread1.ContainsFocus)
                {
                    //洗手
                    if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.WNR)
                    {
                        if (lbNurse.Visible)
                            SelectNurse((int)Cols.WNR);

                        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.INR, false);
                    }
                    else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.WNR2) //洗手护士2 
                    {
                        if (lbNurse.Visible)
                            SelectNurse((int)Cols.WNR2);
                        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.INR2, false);
                    }
                    //巡回
                    else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.INR)
                    {
                        if (lbNurse.Visible)
                            SelectNurse((int)Cols.INR);
                        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.RoomID, false);
                    }
                    else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.INR2) //巡回护士2 
                    {
                        if (lbNurse.Visible)
                            SelectNurse((int)Cols.INR2);
                        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.RoomID, false);
                    }
                    //房号
                    else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.RoomID)
                    {
                        //if (lbRoom.Visible) 
                            SelectRoom();
                        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.TableID, false);
                    }
                    //手术台
                    //else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.TableID)
                    //{
                    //    if (lbTable.Visible) SelectTable();
                    //    if (fpSpread1_Sheet1.RowCount != fpSpread1_Sheet1.ActiveRowIndex + 1)
                    //    {
                    //        fpSpread1_Sheet1.ActiveRowIndex++;
                    //        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.opDate, true);
                    //        FarPoint.Win.Spread.LeaveCellEventArgs e = new FarPoint.Win.Spread.LeaveCellEventArgs
                    //            (new FarPoint.Win.Spread.SpreadView(fpSpread1), 0, 0,
                    //            fpSpread1_Sheet1.ActiveRowIndex, fpSpread1_Sheet1.ActiveColumnIndex);
                    //        fpSpread1_LeaveCell(fpSpread1, e);
                    //    }
                    //}
                    else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.opDate)
                    {
                        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.WNR, false);
                    }
                }
                #endregion
            }

            else if (keyData == Keys.Up)
            {

                //#region Up
                //if (fpSpread1.ContainsFocus)
                //{                  

                //    if (lbNurse.Visible)
                //    {                                       
                //        lbNurse.PriorRow();
                //    }
                //    else if (lbTable.Visible)
                //    {
                //        lbTable.PriorRow();

                //    }
                //    else if (lbRoom.Visible)
                //    {
                //        lbRoom.PriorRow();
                //    }
                //    else
                //    {
                //        int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                //        if (CurrentRow > 0)
                //        {
                //            fpSpread1_Sheet1.ActiveRowIndex = CurrentRow - 1;
                //            fpSpread1_Sheet1.AddSelection(CurrentRow - 1, 0, 1, 0);
                //            FarPoint.Win.Spread.LeaveCellEventArgs e = new FarPoint.Win.Spread.LeaveCellEventArgs
                //                (new FarPoint.Win.Spread.SpreadView(fpSpread1), 0, 0, CurrentRow - 1, fpSpread1_Sheet1.ActiveColumnIndex);
                //            fpSpread1_LeaveCell(fpSpread1, e);
                //        }
                //        //fpSpread1_Sheet1.ActiveRowIndex++;
                //    }
                //    return true;
                //}
                //#endregion
            }
            else if (keyData == Keys.Down)
            {
                //#region Down
                //if (fpSpread1.ContainsFocus)
                //{
                //    if (lbNurse.Visible)
                //    {
                //        lbNurse.NextRow();

                //    }
                //    else if (lbTable.Visible)
                //    {
                //        lbTable.NextRow();
                //    }
                //    else if (lbRoom.Visible)
                //    {
                //        lbRoom.NextRow();
                //    }
                //    else
                //    {
                //        int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                //        if (CurrentRow < fpSpread1_Sheet1.RowCount - 1)
                //        {
                //            fpSpread1_Sheet1.ActiveRowIndex = CurrentRow + 1;
                //            fpSpread1_Sheet1.AddSelection(CurrentRow + 1, 0, 1, 0);
                //            FarPoint.Win.Spread.LeaveCellEventArgs e = new FarPoint.Win.Spread.LeaveCellEventArgs
                //                (new FarPoint.Win.Spread.SpreadView(fpSpread1), 0, 0, CurrentRow + 1, fpSpread1_Sheet1.ActiveColumnIndex);
                //            fpSpread1_LeaveCell(fpSpread1, e);
                //        }
                //        fpSpread1_Sheet1.ActiveRowIndex--;

                //        //int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                //        //if (CurrentRow >= 0 && CurrentRow <= fpSpread1_Sheet1.RowCount - 2)
                //        //{
                //        //    fpSpread1_Sheet1.ActiveRowIndex = CurrentRow + 1;
                //        //    fpSpread1_Sheet1.AddSelection(CurrentRow + 1, 0, 1, 0);
                //        //}
                //    }
                //    return true;
                //}
                //#endregion
            }
            else if (keyData == Keys.Escape)
            {
                if (lbNurse.Visible)
                    lbNurse.Visible = false;
                if (lbTable.Visible)
                    lbTable.Visible = false;
                if (lbRoom.Visible)
                    lbRoom.Visible = false;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void fpSpread1_EditModeOn(object sender, System.EventArgs e)
        {
            fpSpread1.EditingControl.KeyDown += new KeyEventHandler(EditingControl_KeyDown);
            SetLocation();

            //if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.TableID)
            //{
            //    string roomid = "";

            //    if (this.fpSpread1_Sheet1.GetTag(this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.RoomID)
            //        != null)
            //    {
            //        roomid = (this.fpSpread1_Sheet1.GetTag(this.fpSpread1_Sheet1.ActiveRowIndex,
            //            (int)Cols.RoomID) as NeuObject).ID;
            //    }
            //    else
            //    {
            //        roomid = "no_room";
            //    }
            //    this.RefreshTableListBox(roomid);
            //}
            try
            {
                if (fpSpread1_Sheet1.ActiveColumnIndex != (int)Cols.TableID)
                {
                    lbTable.Visible = false;
                }
                else
                {
                    lbTable.Visible = true;
                    lbTable.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                }
                int ColumnIndex = fpSpread1_Sheet1.ActiveColumnIndex;
                if (ColumnIndex != (int)Cols.WNR && ColumnIndex != (int)Cols.INR && ColumnIndex != (int)Cols.WNR2 && ColumnIndex != (int)Cols.INR2)
                {
                    lbNurse.Visible = false;
                }
                else
                {
                    lbNurse.Visible = true;
                    lbNurse.Filter(fpSpread1_Sheet1.ActiveCell.Text);
                }

                if (fpSpread1_Sheet1.ActiveColumnIndex != (int)Cols.RoomID)
                {
                    lbRoom.Visible = false;
                }
                else
                {
                    lbRoom.Visible = true;
                    lbRoom.Filter(fpSpread1_Sheet1.ActiveCell.Text);

                }
            }
            catch { }
        }

        private void fpSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

            string _Text;
            if (e.Column == (int)Cols.TableID)
            {
                _Text = fpSpread1_Sheet1.ActiveCell.Text;
                lbTable.Filter(_Text);

                if (lbTable.Visible == false) lbTable.Visible = true;
                fpSpread1_Sheet1.SetTag(e.Row, e.Column, null);
            }
            //洗手、循环护士
            else if (e.Column == (int)Cols.INR || e.Column == (int)Cols.INR2 || e.Column == (int)Cols.WNR2 ||
                e.Column == (int)Cols.WNR)
            {
                _Text = fpSpread1_Sheet1.ActiveCell.Text;
                lbNurse.Filter(_Text);

                if (lbNurse.Visible == false)
                    lbNurse.Visible = true;
                fpSpread1_Sheet1.SetTag(e.Row, e.Column, null);
            }
            else if (e.Column == (int)Cols.RoomID)
            {
                _Text = fpSpread1_Sheet1.ActiveCell.Text;
                lbRoom.Filter(_Text);

                if (lbRoom.Visible == false) lbRoom.Visible = true;
                fpSpread1_Sheet1.SetTag(e.Row, e.Column, null);
            }
            //else if (e.Column == (int)Cols.TmpHelper1 || e.Column == (int)Cols.TmpHelper2)
            //{

            //    fpSpread1_Sheet1.SetTag(e.Row, e.Column, null);
            //}
        }

        private void fpSpread1_EditModeOff(object sender, System.EventArgs e)
        {
            int col = this.fpSpread1_Sheet1.ActiveColumnIndex;
            if (col == (int)Cols.WNR || col == (int)Cols.INR || col == (int)Cols.WNR2 || col == (int)Cols.INR2)
            {
                //TODO: 刷新护士列表
                //this.RefreshNurseList(this.alTabulars);
            }
        }
        //左、右键实现光标在cell间跳转
        private void EditingControl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Left)
            //{
            //    FarPoint.Win.Spread.CellType.GeneralEditor t = fpSpread1.EditingControl as FarPoint.Win.Spread.CellType.GeneralEditor;
            //    if (t.SelectionStart == 0 && t.SelectionLength == 0)
            //    {
            //        int row = 0, column = 0;
            //        if (fpSpread1_Sheet1.ActiveColumnIndex == 0 && fpSpread1_Sheet1.ActiveRowIndex != 0)
            //        {
            //            row = fpSpread1_Sheet1.ActiveRowIndex - 1;
            //            column = fpSpread1_Sheet1.Columns.Count - 1;
            //        }
            //        else if (fpSpread1_Sheet1.ActiveColumnIndex != 0)
            //        {
            //            row = fpSpread1_Sheet1.ActiveRowIndex;
            //            column = fpSpread1_Sheet1.ActiveColumnIndex - 1;
            //        }
            //        fpSpread1_Sheet1.SetActiveCell(row, column, true);
            //    }
            //}
            //if (e.KeyCode == Keys.Right)
            //{
            //    FarPoint.Win.Spread.CellType.GeneralEditor t = fpSpread1.EditingControl as FarPoint.Win.Spread.CellType.GeneralEditor;

            //    if (t.Text == null || t.Text == "" || t.SelectionStart == t.Text.Length)
            //    {
            //        int row = fpSpread1_Sheet1.RowCount - 1, column = fpSpread1_Sheet1.ColumnCount - 1;
            //        if (fpSpread1_Sheet1.ActiveColumnIndex == column && fpSpread1_Sheet1.ActiveRowIndex != row)
            //        {
            //            row = fpSpread1_Sheet1.ActiveRowIndex + 1;
            //            column = 0;
            //        }
            //        else if (fpSpread1_Sheet1.ActiveColumnIndex != column)
            //        {
            //            row = fpSpread1_Sheet1.ActiveRowIndex;
            //            column = fpSpread1_Sheet1.ActiveColumnIndex + 1;
            //        }
            //        fpSpread1_Sheet1.SetActiveCell(row, column, true);
            //    }
            //}
        }

        private void lbNurse_ItemSelected(object sender, System.EventArgs e)
        {
            this.SelectNurse(fpSpread1_Sheet1.ActiveColumnIndex);
        }
        private void lbTable_ItemSelected(object sender, System.EventArgs e)
        {
            //SelectTable();

        }

        private void lbRoom_ItemSelected(object sender, System.EventArgs e)
        {
            SelectRoom();

        }
        #endregion

        #region columns--{3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
        private enum Cols
        {
            nurseID,
            Name,
            Sex,
            Age,
            /// <summary>
            /// 台序
            /// </summary>
            //Order,
            /// <summary>
            /// 是否正台
            /// </summary>
            //Desk,
            opItemName,
            //{B9DDCC10-3380-4212-99E5-BB909643F11B}
            /// <summary>
            /// 麻醉方式
            /// </summary>
            anaeWay,
            anaeType,
            opDoctID,
            opDate,
            /// <summary>
            /// 房号
            /// </summary>
            RoomID,
            /// <summary>
            /// 巡回护士
            /// </summary>
            INR,
            /// <summary>
            /// 洗手护士
            /// </summary>
            WNR,
            /// <summary>
            /// 进修1
            /// </summary>
            TmpStudent1,
            
            /// <summary>
            /// 巡回护士2 
            /// </summary>
            INR2,
            /// <summary>
            /// 洗手护士2
            /// </summary>
            WNR2,
            /// <summary>
            /// 进修2
            /// </summary>
            TmpStudent2,
            /// <summary>
            /// 手术台
            /// </summary>
            TableID,
            /// <summary>
            /// 临时1
            /// </summary>
            TmpHelper1,
            /// <summary>
            /// 临时2
            /// </summary>
            TmpHelper2
             
        }

        #endregion

        private void fpSpread1_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            //if (this.applictionSelected != null)
            //{
            //    this.applictionSelected(this, this.fpSpread1_Sheet1.Rows[e.Row].Tag as OperationAppllication);
            //}
        }


        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get { return new Type[] { typeof(Neusoft.HISFC.BizProcess.Interface.Operation.IArrangePrint) }; }
        }

        #endregion



        private void fpSpread1_CellClick(object sender, CellClickEventArgs e)
        {
            if (this.applictionSelected != null)
            {
                this.applictionSelected(this, this.fpSpread1_Sheet1.Rows[e.Row].Tag as OperationAppllication);
            }
        }

        /// <summary>
        ///更换手术室
        /// </summary>
        /// <returns></returns>
        public int ChangeDept()
        {

            try
            {
                int row = fpSpread1_Sheet1.ActiveRowIndex;
                if (fpSpread1_Sheet1.RowCount == 0) return -1;

                //neusoft.HISFC.Object.Operator.OpsApplication apply = new neusoft.HISFC.Object.Operator.OpsApplication();
                Neusoft.HISFC.Models.Operation.OperationAppllication apply = new OperationAppllication();
                apply = fpSpread1_Sheet1.Rows[row].Tag as Neusoft.HISFC.Models.Operation.OperationAppllication;
                string strOldOpsRoom = apply.OperateRoom.ID;//执行科室

                frmChangeOpsRoom dlg = new frmChangeOpsRoom(apply);
                //dlg.m_objOpsApp = apply;
                dlg.InitWin();
                DialogResult result = dlg.ShowDialog();
                //窗口点了“确定”按钮
                if (result == DialogResult.OK)
                {
                    //两个值不同表明更换了手术室
                    if (dlg.strNewOpsRoomID != strOldOpsRoom)
                    {
                        //刷新窗口的控件列表(通过更改查询截至时间的值触发相关事件达到这个目的)
                        //将更换了手术室的申请单从列表中消失显示。
                        //RefreshApplys();
                        dlg.Dispose();
                    }
                }
                else
                {
                    return -1;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }




    }




}

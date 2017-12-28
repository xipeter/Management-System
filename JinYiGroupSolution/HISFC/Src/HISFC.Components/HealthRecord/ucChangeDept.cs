using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace UFC.HealthRecord
{
    public partial class ucChangeDept : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucChangeDept()
        {
            InitializeComponent();
        }

        #region  全局变量
        //配置文件路径
        private System.Data.DataTable dtTable = new DataTable("科室");
        private Neusoft.HISFC.Object.RADT.PatientInfo patient = new Neusoft.HISFC.Object.RADT.PatientInfo();
        private Neusoft.HISFC.Management.HealthRecord.DeptShift deptShift = new Neusoft.HISFC.Management.HealthRecord.DeptShift();
        private string inPatientNO = "";
        #endregion

        #region 属性
        #endregion

        #region 函数

        #region 增加一行 
        //添加一行项目
        private int AddRow()
        {
            try
            {
                if (fpEnter1_Sheet1.Rows.Count < 1)
                {
                    //增加一行空值
                    DataRow row = dtTable.NewRow();
                    row["序号"] = "1";
                    row["转科日期"] = System.DateTime.Now;
                    dtTable.Rows.Add(row);
                }
                else
                {
                    //增加一行
                    int j = fpEnter1_Sheet1.Rows.Count;
                    this.fpEnter1_Sheet1.Rows.Add(j, 1);
                    for (int i = 0; i < fpEnter1_Sheet1.Columns.Count; i++)
                    {
                        fpEnter1_Sheet1.Cells[j, i].Value = fpEnter1_Sheet1.Cells[j - 1, i].Value;
                    }
                }
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.Rows.Count, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        #endregion 

        #region   删除一行
        /// <summary>
        /// 删除当前行 
        /// </summary>
        /// <returns></returns>
        private int DeleteActiveRow()
        {
            if (fpEnter1_Sheet1.Rows.Count > 0)
            {
                this.fpEnter1_Sheet1.Rows.Remove(fpEnter1_Sheet1.ActiveRowIndex, 1);
            }
            if (fpEnter1_Sheet1.Rows.Count == 0)
            {
                this.fpEnter1.SetAllListBoxUnvisible();
            }
            return 1;
        }
        #endregion 


        #region 保存
        public override int Save(object sender, object neuObject)
        {
            Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction(deptShift.Connection);
            #region 转科信息

            //删除的
            ArrayList deptDel = new ArrayList();
            //增加的 
            ArrayList deptAdd = new ArrayList();
            //修改过的 
            ArrayList deptMod = new ArrayList();

            #region 基本信息界面上的转科信息
            //#region 第一次转科信息

            //if (firstDept.Tag != null) //有三中情况 1。tag不为空 （firDept为空 或着病案从来没有维护过 是新增加的 2。tag不为空 firDept不为空 firDept.Dept.ID 不等于tag 是修改的
            //{						  //3 。firDept不为空  tag 为空 是删除的 。
            //    if (firDept == null || CaseBase.PatientInfo.CaseState == "1")//新增加的
            //    {
            //        firDept = new Neusoft.HISFC.Object.RADT.Location();
            //        firDept.User02 = CaseBase.PatientInfo.ID;
            //        firDept.Dept.Name = firstDept.Text;
            //        firDept.Dept.ID = firstDept.Tag.ToString();
            //        firDept.User01 = this.dateTimePicker3.Value.ToString();

            //        deptAdd.Add(firDept);
            //    }
            //    else //修改过的
            //    {
            //        firDept.User02 = CaseBase.PatientInfo.ID;
            //        firDept.Dept.Name = firstDept.Text;
            //        firDept.Dept.ID = firstDept.Tag.ToString();
            //        firDept.User01 = this.dateTimePicker3.Value.ToString();

            //        deptMod.Add(firDept);
            //    }

            //}
            //else if (firDept != null && firstDept.Tag == null) //删除的
            //{
            //    deptDel.Add(firDept);
            //}
            //#endregion
            //#region  第二次转科信息
            //if (deptSecond.Tag != null)
            //{
            //    if (secDept == null || CaseBase.PatientInfo.CaseState == "1") //增加的 
            //    {
            //        secDept = new Neusoft.HISFC.Object.RADT.Location();
            //        secDept.User02 = CaseBase.PatientInfo.ID;
            //        this.secDept.Dept.Name = deptSecond.Text;
            //        this.secDept.Dept.ID = deptSecond.Tag.ToString();
            //        secDept.User01 = this.dateTimePicker3.Value.ToString();

            //        deptAdd.Add(secDept);
            //    }
            //    else //修改过的 
            //    {
            //        secDept.User02 = CaseBase.PatientInfo.ID;
            //        this.secDept.Dept.Name = deptSecond.Text;
            //        this.secDept.Dept.ID = deptSecond.Tag.ToString();
            //        secDept.User01 = this.dateTimePicker3.Value.ToString();

            //        deptMod.Add(secDept);
            //    }
            //}
            //else if (secDept != null && deptSecond.Tag == null)
            //{
            //    deptDel.Add(secDept);
            //}
            //#endregion
            //#region 第三次转科
            //if (deptThird.Tag != null)
            //{
            //    if (thirDept == null || CaseBase.PatientInfo.CaseState == "1")
            //    {
            //        thirDept = new Neusoft.HISFC.Object.RADT.Location();
            //        thirDept.User02 = CaseBase.PatientInfo.ID;
            //        this.thirDept.Dept.Name = deptThird.Text;
            //        this.thirDept.Dept.ID = deptThird.Tag.ToString();
            //        thirDept.User01 = this.dateTimePicker3.Value.ToString();

            //        deptAdd.Add(thirDept);
            //    }
            //    else
            //    {
            //        thirDept.User02 = CaseBase.PatientInfo.ID;
            //        this.thirDept.Dept.Name = deptThird.Text;
            //        this.thirDept.Dept.ID = deptThird.Tag.ToString();
            //        thirDept.User01 = this.dateTimePicker3.Value.ToString();

            //        deptMod.Add(thirDept);
            //    }
            //}
            //else if (thirDept != null && deptThird.Tag == null) //删除的
            //{
            //    deptDel.Add(thirDept);
            //}
            //#endregion
            #endregion

            //删除空白行
            deleteRow();
            GetList("D", deptDel);
            GetList("A", deptAdd);
            GetList("M", deptMod);

            if (ValueState(deptDel) == -1 || ValueState(deptAdd) == -1 || ValueState(deptMod) == -1)
            {
                trans.RollBack();
                return -3;
            }
            if (deptDel != null)
            {
                foreach (Neusoft.HISFC.Object.RADT.Location obj in deptDel)
                {
                    if (deptShift.DeleteChangeDept(obj) < 1)
                    {
                        trans.RollBack();
                        MessageBox.Show("转科信息保存失败" + deptShift.Err);
                        return -1;
                    }
                }
            }
            if (deptAdd != null)
            {
                foreach (Neusoft.HISFC.Object.RADT.Location obj in deptAdd)
                {
                    if (deptShift.InsertChangeDept(obj) < 1)
                    {
                        trans.RollBack();
                        MessageBox.Show("转科信息保存失败" + deptShift.Err);
                        return -1;
                    }
                }
            }
            if (deptMod != null)
            {
                foreach (Neusoft.HISFC.Object.RADT.Location obj in deptMod)
                {
                    if (deptShift.UpdateChangeDept(obj) < 1)
                    {
                        trans.RollBack();
                        MessageBox.Show("转科信息保存失败" + deptShift.Err);
                        return -1;
                    }
                }
            }
            //查询保存过的信息
            ArrayList tempChangeDept = deptShift.QueryChangeDeptFromShiftApply(inPatientNO, "2");
            #endregion 

            trans.Commit();
            MessageBox.Show("保存成功");
            return 1;
        }
        #endregion 

        /// <summary>
        /// 设置活动单元格
        /// </summary>
        public void SetActiveCells()
        {
            try
            {
                this.fpEnter1_Sheet1.SetActiveCell(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 限定格的宽度很可见性 
        /// </summary>
        private void LockFpEnter()
        {
            this.fpEnter1_Sheet1.Columns[0].Width = 220; //科室编码
            this.fpEnter1_Sheet1.Columns[1].Width = 129;//科室名称
            this.fpEnter1_Sheet1.Columns[1].Locked = true;
            this.fpEnter1_Sheet1.Columns[2].Width = 119;//转科日期
            this.fpEnter1_Sheet1.Columns[3].Visible = false; //序号
        }
        /// <summary>
        /// 清空原有的数据
        /// </summary>
        /// <returns></returns>
        public int ClearInfo()
        {
            if (this.dtTable != null)
            {
                this.dtTable.Clear();
                LockFpEnter();
            }
            else
            {
                MessageBox.Show("转科表为null");
            }
            return 1;
        }
        public int SetReadOnly(bool type)
        {
            if (type)
            {
                this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            }
            else
            {
                this.fpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
            }
            return 0;
        }
        /// <summary>
        /// 校验数据的合法性。
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int ValueState(ArrayList list)
        {
            if (list == null)
            {
                return -2;
            }
            foreach (Neusoft.HISFC.Object.RADT.Location obj in list)
            {
                if (obj.User02 == "" || obj.User02 == null)
                {
                    MessageBox.Show("转科信息住院流水号不能为空");
                    return -1;
                }
                if (obj.User02.Length > 14)
                {
                    MessageBox.Show("转科信息住院流水号过长");
                    return -1;
                }
                if (obj.Dept.ID == "" || obj.Dept.ID == null)
                {
                    MessageBox.Show("转科信息科室编码不能为空");
                    return -1;
                }
                if (obj.Dept.ID.Length > 4)
                {
                    MessageBox.Show("转科信息 科室编码过长");
                    return -1;
                }
                //				if(obj.Dept.Name == "" ||obj.Dept.Name == null)
                //				{
                //					MessageBox.Show("转科信息科室名称不能为空");
                //					return -1;
                //				}
                if (obj.Dept.Name.Length > 16)
                {
                    MessageBox.Show("转科信息 科室名称过长");
                    return -1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 保存对表做的所有修改
        /// </summary>
        /// <returns></returns>
        public int fpEnterSaveChanges()
        {
            try
            {
                this.dtTable.AcceptChanges();
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 返回当前行数
        /// </summary>
        /// <returns></returns>
        public int GetfpSpreadRowCount()
        {
            return fpEnter1_Sheet1.Rows.Count;
        }
        /// <summary>
        /// 如果reset 为真 则清空现有数据 并保存更改  为假 只是保存当前更改
        /// creator:zhangjunyi@Neusoft.com
        /// </summary>
        /// <param name="reset"></param>
        /// <returns></returns>
        public bool Reset(bool reset)
        {
            if (reset)
            {
                //清空数据 保存更改 
                if (dtTable != null)
                {
                    dtTable.Clear();
                    dtTable.AcceptChanges();
                }
            }
            else
            {
                //保存更改
                dtTable.AcceptChanges();
            }
            return true;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitInfo()
        {
            try
            {
                //初始化表
                InitDatedtTable();
                //设置下拉列表
                this.initList();
                fpEnter1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool GetList(string strType, ArrayList list)
        {
            try
            {
                this.fpEnter1.StopCellEditing();
                switch (strType)
                {
                    case "A":
                        //增加的数据
                        DataTable AddTable = this.dtTable.GetChanges(DataRowState.Added);
                        GetChangeInfo(AddTable, list);
                        break;
                    case "M":
                        DataTable ModTable = this.dtTable.GetChanges(DataRowState.Modified);
                        GetChangeInfo(ModTable, list);
                        break;
                    case "D":
                        DataTable DelTable = this.dtTable.GetChanges(DataRowState.Deleted);
                        if (DelTable != null)
                        {
                            DelTable.RejectChanges();
                        }
                        GetChangeInfo(DelTable, list);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除空白的行
        /// </summary>
        /// <returns></returns>
        public int deleteRow()
        {
            if (fpEnter1_Sheet1.Rows.Count == 1)
            {
                if (fpEnter1_Sheet1.Cells[0, 0].Text == "" || fpEnter1_Sheet1.Cells[0, 1].Text == "")
                {
                    fpEnter1_Sheet1.Rows.Remove(0, 1);
                }
            }
            return 1;
        }
        /// <summary>
        /// 获取修改过的信息
        /// </summary>
        /// <returns></returns>
        private bool GetChangeInfo(DataTable tempTable, ArrayList list)
        {
            if (tempTable == null)
            {
                return true;
            }
            try
            {
                Neusoft.HISFC.Object.RADT.Location info = null;
                foreach (DataRow row in tempTable.Rows)
                {
                    info = new Neusoft.HISFC.Object.RADT.Location();
                    info.User02 = this.patient.ID;
                    info.Dept.ID = row["科室编码"].ToString(); //0
                    info.Dept.Name = row["科室名称"].ToString();//1
                    info.User01 = row["转科日期"].ToString();//2
                    info.User03 = row["序号"].ToString(); //3
                    info.Floor = "0"; //在科日期
                    list.Add(info);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 加载数据 
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="deptList"></param>
        /// <returns></returns>
        public int LoadInfo(Neusoft.HISFC.Object.RADT.PatientInfo patientInfo, ArrayList deptList)
        {
            if (deptList == null || patientInfo == null)
            {
                return -1;
            }
            patient = patientInfo;
            if (deptList.Count <= 3)
            {
                return 0;
            }
            AddInfoToTable(deptList);
            return 1;

        }
        /// <summary>
        /// 将保存完的数据回写到表中
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int fpEnterSaveChanges(ArrayList list)
        {
            AddInfoToTable(list);
            dtTable.AcceptChanges();
            return 0;
        }
        /// <summary>
        /// 查询诊断信息并且填充的表中
        /// </summary>
        private void AddInfoToTable(ArrayList alReturn)
        {
            if (this.dtTable != null)
            {
                this.dtTable.Clear();
                this.dtTable.AcceptChanges();
            }
            //循环插入信息
            int i = 0;
            foreach (Neusoft.HISFC.Object.RADT.Location obj in alReturn)
            {
                if (i > 2) //开头三个在基本信息界面上已经显示了 这里存储除界面上显示的之外的
                {
                    DataRow row = dtTable.NewRow();
                    SetRow(obj, row);
                    dtTable.Rows.Add(row);
                }
                else
                {
                    i++;
                }
            }
            if ((this.patient.CaseState == "2") || (this.patient.CaseState == "3"))
            {
                //清空表的标志位
                dtTable.AcceptChanges();
            }
            LockFpEnter();
        }
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="info"></param>
        private void SetRow(Neusoft.HISFC.Object.RADT.Location info, DataRow row)
        {
            row["科室编码"] = info.Dept.ID;//0
            row["科室名称"] = info.Dept.Name;//1
            if (info.User01 == "")
            {
                row["转科日期"] = System.DateTime.Now; //2
            }
            else
            {
                row["转科日期"] = info.User01;
            }
            row["序号"] = info.User03;
        }
        private void InitDatedtTable()
        {
            try
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);
                Type floatType = typeof(System.Single);

                dtTable.Columns.AddRange(new DataColumn[]{
														   new DataColumn("科室编码", strType),	//0
														   new DataColumn("科室名称", strType),	 //1
														   new DataColumn("转科日期", dtType),//2
														   new DataColumn("序号", strType)//3
														 });//14
                //绑定数据源
                this.fpEnter1_Sheet1.DataSource = dtTable;
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 设置列下拉列表
        /// </summary>
        private void initList()
        {
            try
            {
                Neusoft.HISFC.Management.Manager.Department dept = new Neusoft.HISFC.Management.Manager.Department();
                this.fpEnter1.SelectNone = true;
                //获取科室
                ArrayList al = dept.GetDeptmentAll();
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 0, al);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 1, al);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ucChangeDept_Load(object sender, System.EventArgs e)
        {
            //定义响应按键事件
            fpEnter1.KeyEnter += new Neusoft.NFC.Interface.Controls.NeuFpEnter.keyDown(fpEnter1_KeyEnter);
            fpEnter1.SetItem += new Neusoft.NFC.Interface.Controls.NeuFpEnter.setItem(fpEnter1_SetItem);
            fpEnter1.ShowListWhenOfFocus = true;
        }
        /// <summary>
        /// 按键响应处理
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int fpEnter1_KeyEnter(Keys key)
        {
            if (key == Keys.Enter)
            {
                //				MessageBox.Show("Enter,可以自己添加处理事件，比如跳到下一cell");
                //回车
                if (this.fpEnter1.ContainsFocus)
                {
                    int i = this.fpEnter1_Sheet1.ActiveColumnIndex;
                    if (i == 0 || i == 1)
                    {
                        ProcessDept();
                    }
                    else if (i == 2)
                    {
                        if (fpEnter1_Sheet1.ActiveRowIndex < fpEnter1_Sheet1.Rows.Count - 1)
                        {
                            fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex + 1, 0);
                        }
                        else
                        {
                            //增加一行
                            this.AddRow();
                        }
                    }
                }
            }
            else if (key == Keys.Up)
            {
                //				MessageBox.Show("Up,可以自己添加处理事件，比如无下拉列表时，跳到下列，显示下拉控件时，在下拉控件上下移动");
            }
            else if (key == Keys.Down)
            {
                //				MessageBox.Show("Down，可以自己添加处理事件，比如无下拉列表时，跳到上列，显示下拉控件时，在下拉控件上下移动");
            }
            else if (key == Keys.Escape)
            {
                //				MessageBox.Show("Escape,取消列表可见");
            }
            return 0;
        }
        private int fpEnter1_SetItem(Neusoft.NFC.Object.NeuObject obj)
        {
            this.ProcessDept();
            return 0;
        }
        /// <summary>
        /// 处理回车操作 ，并且取出数据
        /// </summary>
        /// <returns></returns>
        private int ProcessDept()
        {
            int CurrentRow = fpEnter1_Sheet1.ActiveRowIndex;
            if (CurrentRow < 0) return 0;

            if (fpEnter1_Sheet1.ActiveColumnIndex == 0)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, 0);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //科室编码
                fpEnter1_Sheet1.ActiveCell.Text = item.ID;
                //科室名称
                fpEnter1_Sheet1.Cells[CurrentRow, 1].Text = item.Name;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, 2);
                return 0;
            }

            else if (fpEnter1_Sheet1.ActiveColumnIndex == 1)
            {
                Neusoft.NFC.Interface.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, 1);
                //获取选中的信息
                Neusoft.NFC.Object.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                //				if(rtn==-1)return -1;
                if (item == null) return -1;
                //科室名称 
                fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                //科室编码 
                fpEnter1_Sheet1.Cells[CurrentRow, 0].Text = item.ID;
                fpEnter1.Focus();
                fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, 2);
                return 0;
            }
            return 0;
        }


        private void fpEnter1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            ////设置fpSpread1 的属性
            //if (System.IO.File.Exists(filePath))
            //{
            //    Neusoft.NFC.Interface.Classes.CustomerFp.SaveColumnProperty(this.fpEnter1_Sheet1, filePath);
            //}
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            //Neusoft.UFC.Common.Controls.ucSetColumn uc = new Neusoft.UFC.Common.Controls.ucSetColumn();
            //uc.FilePath = this.filePath;
            //uc.GoDisplay += new Neusoft.UFC.Common.Controls.ucSetColumn.DisplayNow(uc_GoDisplay);
            //Neusoft.NFC.Interface.Classes.Function.PopShowControl(uc);
        }
        /// <summary>
        /// 调整fpSpread1_Sheet1的宽度等 保存后触发的事件
        /// </summary>
        private void uc_GoDisplay()
        {
            //			LoadInfo(inpatientNo,operType); //重新加载数据

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            DeleteRow();
        }
        /// <summary>
        /// 删除 
        /// </summary>
        /// <returns></returns>
        public int DeleteRow()
        {
            this.fpEnter1_Sheet1.Rows.Remove(fpEnter1_Sheet1.ActiveRowIndex, 1);
            return 1;
        }
        #endregion 
    }
}

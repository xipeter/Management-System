using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord
{
    public partial class ucBabyCard : UserControl
    {
        public ucBabyCard()
        {
            InitializeComponent();
        }
        #region 全局变量
        public DataTable dtBaby = new DataTable("妇婴卡");
        //		//ICD 诊断信息 列表
        //		private Neusoft.FrameWork.WinForms.Controls.PopUpListBox ICDType = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
        //呼吸
        //		private Neusoft.FrameWork.WinForms.Controls.PopUpListBox BreathType = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
        private Neusoft.FrameWork.Public.ObjectHelper BreathTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //转归
        //		private Neusoft.FrameWork.WinForms.Controls.PopUpListBox BabyStateType = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
        private Neusoft.FrameWork.Public.ObjectHelper BabyStateTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //分娩结果
        //		private Neusoft.FrameWork.WinForms.Controls.PopUpListBox BirthEndType = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
        private Neusoft.FrameWork.Public.ObjectHelper BirthEndTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //性别
        //		private Neusoft.FrameWork.WinForms.Controls.PopUpListBox SexType = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
        private Neusoft.FrameWork.Public.ObjectHelper SexTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //标识是医生站 还是 病案室
        //		private string frmType = "";
        //配置文件路径
        private string filePath = Application.StartupPath + "\\profile\\ucBabyCardInput.xml";
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        #endregion

        #region  属性
        #endregion

        #region  函数
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
            this.fpEnter1_Sheet1.Columns[0].Width = 38; //性别
            this.fpEnter1_Sheet1.Columns[1].Width = 59;//分娩结果
            this.fpEnter1_Sheet1.Columns[2].Width = 40;//体重
            this.fpEnter1_Sheet1.Columns[3].Width = 40; //转归
            this.fpEnter1_Sheet1.Columns[4].Width = 80; //呼吸
            this.fpEnter1_Sheet1.Columns[5].Width = 40; //院内感染次数
            this.fpEnter1_Sheet1.Columns[6].Width = 150; //医院感染名称
            this.fpEnter1_Sheet1.Columns[7].Width = 80; //ICD-10编码
            this.fpEnter1_Sheet1.Columns[7].Locked = true; //ICD-10编码
            this.fpEnter1_Sheet1.Columns[8].Width = 40; //抢救次数 
            this.fpEnter1_Sheet1.Columns[9].Width = 40; //感染次数 
            this.fpEnter1_Sheet1.Columns[10].Visible = false; //序号
        }
        /// <summary>
        /// 清空原有的数据
        /// </summary>
        /// <returns></returns>
        public int ClearInfo()
        {
            if (this.dtBaby != null)
            {
                this.dtBaby.Clear();
                LockFpEnter();
            }
            else
            {
                MessageBox.Show("妇婴表为null");
            }
            return 1;
        }
        /// <summary>
        /// 将farpoint 设置为只读
        /// </summary>
        /// <returns></returns>
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
            foreach (Neusoft.HISFC.Models.HealthRecord.Baby obj in list)
            {
                if (obj.InpatientNo == "" || obj.InpatientNo == null)
                {
                    MessageBox.Show("妇婴信息 住院号不能为空");
                    return -1;
                }
                if (obj.InpatientNo.Length > 14)
                {
                    MessageBox.Show("妇婴信息 住院流水号过长");
                    return -1;
                }
                if (obj.Weight <= 0)
                {
                    MessageBox.Show("妇婴信息 体重不能小于或等于零");
                    return -1;
                }
                else if (obj.Weight > 99999.99)
                {
                    MessageBox.Show("妇婴信息 体重数字过大");
                    return -1;
                }

                if (obj.InfectNum < 0)
                {
                    MessageBox.Show("妇婴信息 感染次数不能小于零");
                    return -1;
                }
                else if (obj.InfectNum > 999)
                {
                    MessageBox.Show("妇婴信息 感染次数过大");
                    return -1;
                }
                if (obj.SalvNum < 0)
                {
                    MessageBox.Show("妇婴信息 抢救次数不能小于零");
                    return -1;
                }
                else if (obj.SalvNum > 99)
                {
                    MessageBox.Show("妇婴信息 抢救次数过大");
                    return -1;
                }

                if (obj.SuccNum < 0)
                {
                    MessageBox.Show("妇婴信息 成功次数不能小于零");
                    return -1;
                }
                else if (obj.SuccNum > 99)
                {
                    MessageBox.Show("妇婴信息 成功次数过大");
                    return -1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 删除当前行 
        /// </summary>
        /// <returns></returns>
        public int DeleteActiveRow()
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
        /// <summary>
        /// 删除空白的行
        /// </summary>
        /// <returns></returns>
        public int deleteRow()
        {
            if (fpEnter1_Sheet1.Rows.Count == 1)
            {
                //第一行编码为空 
                if (fpEnter1_Sheet1.Cells[0, 0].Text == "" && fpEnter1_Sheet1.Cells[0, 1].Text == "")
                {
                    fpEnter1_Sheet1.Rows.Remove(0, 1);
                }
            }
            return 1;
        }
        /// <summary>
        /// 保存对表做的所有修改
        /// </summary>
        /// <returns></returns>
        public int fpEnterSaveChanges()
        {
            try
            {
                this.dtBaby.AcceptChanges();
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
        /// 将保存完的数据回写到表中
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int fpEnterSaveChanges(ArrayList list)
        {
            AddInfoToTable(list);
            dtBaby.AcceptChanges();
            LockFpEnter();
            return 0;
        }
        /// <summary>
        /// 返回当前行数
        /// </summary>
        /// <returns></returns>
        public int GetfpSpreadRowCount()
        {
            return fpEnter1_Sheet1.Rows.Count;
        }
        private int AddInfoToTable(ArrayList list)
        {
            if (this.dtBaby != null)
            {
                this.dtBaby.Clear();
                this.dtBaby.AcceptChanges();
            }
            if (list == null)
            {
                return -1;
            }
            //循环插入数据
            foreach (Neusoft.HISFC.Models.HealthRecord.Baby info in list)
            {
                DataRow row = dtBaby.NewRow();
                SetRow(row, info);
                dtBaby.Rows.Add(row);
            }
            if ((this.patientInfo.CaseState == "2" || this.patientInfo.CaseState == "3"))
            {
                //更改标志
                dtBaby.AcceptChanges();
            }
            LockFpEnter();
            return 0;
        }
        /// <summary>
        /// 查询并显示数据
        /// </summary>
        /// <returns>出错返回 －1 正常 0 不允许有病案1  </returns>
        public int LoadInfo(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            if (patient == null)
            {
                return -1;
            }
            patientInfo = patient;
            if (patientInfo.CaseState == "0")
            {
                //不允许有病案
                return 1;
            }
            Neusoft.HISFC.BizLogic.HealthRecord.Baby ba = new Neusoft.HISFC.BizLogic.HealthRecord.Baby();

            //查询符合条件的数据
            ArrayList list = ba.QueryBabyByInpatientNo(patientInfo.ID);
            AddInfoToTable(list);
            return 0;
        }
        /// <summary>
        /// 查询更改过的数据数据 
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool GetList(string strType, ArrayList list)
        {
            try
            {
                this.fpEnter1.StopCellEditing();
                switch (strType)
                {
                    case "A":
                        //增加的数据
                        DataTable AddTable = this.dtBaby.GetChanges(DataRowState.Added);
                        GetChangeInfo(AddTable, list);
                        break;
                    case "M":
                        DataTable ModTable = this.dtBaby.GetChanges(DataRowState.Modified);
                        GetChangeInfo(ModTable, list);
                        break;
                    case "D":
                        DataTable DelTable = this.dtBaby.GetChanges(DataRowState.Deleted);
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
                Neusoft.HISFC.Models.HealthRecord.Baby info = null;
                foreach (DataRow row in tempTable.Rows)
                {
                    info = new Neusoft.HISFC.Models.HealthRecord.Baby();
                    //住院流水号
                    info.InpatientNo = this.patientInfo.ID;
                    if (row["性别"] != DBNull.Value)
                    {
                        info.SexCode = this.SexTypeHelper.GetID(row["性别"].ToString());
                    }
                    if (row["分娩结果"] != DBNull.Value)
                    {
                        info.BirthEnd = this.BirthEndTypeHelper.GetID(row["分娩结果"].ToString());
                    }
                    if (row["体重"] != DBNull.Value)
                    {
                        info.Weight = Neusoft.FrameWork.Function.NConvert.ToInt32(row["体重"].ToString());
                    }
                    if (row["转归"] != DBNull.Value)
                    {
                        string sss = this.BabyStateTypeHelper.GetID(row["转归"].ToString());
                        info.BabyState = this.BabyStateTypeHelper.GetID(row["转归"].ToString());
                    }
                    if (row["呼吸"] != DBNull.Value)
                    {
                        info.Breath = this.BreathTypeHelper.GetID(row["呼吸"].ToString());
                    }
                    if (row["院内感染次"] != DBNull.Value)
                    {
                        info.InfectNum = Neusoft.FrameWork.Function.NConvert.ToInt32(row["院内感染次"].ToString());
                    }
                    if (row["医院感染名称"] != DBNull.Value)
                    {
                        info.Infect.Name = row["医院感染名称"].ToString();
                    }
                    if (row["ICD-10编码"] != DBNull.Value)
                    {
                        info.Infect.ID = row["ICD-10编码"].ToString();
                    }
                    if (row["抢救次数"] != DBNull.Value)
                    {
                        info.SalvNum = Neusoft.FrameWork.Function.NConvert.ToInt32(row["抢救次数"].ToString());
                    }
                    if (row["抢救成功次数"] != DBNull.Value)
                    {
                        info.SuccNum = Neusoft.FrameWork.Function.NConvert.ToInt32(row["抢救成功次数"].ToString());
                    }
                    if (row["序号"] != DBNull.Value)
                    {
                        info.HappenNum = Neusoft.FrameWork.Function.NConvert.ToInt32(row["序号"].ToString());
                    }
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
        /// 将实体中的值赋值到row中
        /// </summary>
        /// <param name="row">传入的row</param>
        /// <param name="info">传入的实体</param>
        private void SetRow(DataRow row, Neusoft.HISFC.Models.HealthRecord.Baby info)
        {
            row["性别"] = this.SexTypeHelper.GetName(info.SexCode);
            row["分娩结果"] = this.BirthEndTypeHelper.GetName(info.BirthEnd);
            row["体重"] = info.Weight;
            row["转归"] = this.BabyStateTypeHelper.GetName(info.BabyState);
            row["呼吸"] = this.BreathTypeHelper.GetName(info.Breath);
            row["院内感染次"] = info.InfectNum;
            row["医院感染名称"] = info.Infect.Name;
            row["ICD-10编码"] = info.Infect.ID;
            row["抢救次数"] = info.SalvNum;
            row["抢救成功次数"] = info.SuccNum;
            row["序号"] = info.HappenNum;
        }

        /// <summary>
        /// 初始化下拉列表 查询数据等
        /// </summary>
        /// <returns> -1 出错</returns>
        public int InitInfo()
        {
            //初始化表，并绑定数据源
            InitDateTable();
            InitList();
            fpEnter1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            return 0;
        }
        public int InitICDList(ArrayList list)
        {
            if (list == null)
            {
                return -1;
            }
            this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 6, list);
            this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 7, list);
            return 0;
        }
        private int InitList()
        {
            try
            {
                Neusoft.HISFC.BizLogic.HealthRecord.Baby cbaby = new Neusoft.HISFC.BizLogic.HealthRecord.Baby();
                Neusoft.HISFC.BizLogic.Manager.Constant conMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();
                this.fpEnter1.SelectNone = true;
                //性别
                ArrayList listSex = Neusoft.HISFC.Models.Base.SexEnumService.List(); 
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 0, listSex);
                SexTypeHelper.ArrayObject = listSex;
                //分娩结果
                ArrayList listbaby = conMgr.GetList(Neusoft.HISFC.Models.Base.EnumConstant.CHILDBEARINGRESULT);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 1, listbaby);
                BirthEndTypeHelper.ArrayObject = listbaby;

                //转归
                ArrayList listBabyState = conMgr.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ZG);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 3, listBabyState);
                BabyStateTypeHelper.ArrayObject = listBabyState;

                //呼吸
                ArrayList listbreath = conMgr.GetList(Neusoft.HISFC.Models.Base.EnumConstant.BREATHSTATE);
                this.fpEnter1.SetColumnList(this.fpEnter1_Sheet1, 4, listbreath);
                BreathTypeHelper.ArrayObject = listbreath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 0;

        }
        private void InitDateTable()
        {
            try
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);
                Type floatType = typeof(System.Single);

                dtBaby.Columns.AddRange(new DataColumn[]{
															new DataColumn("性别", strType),	//0
															new DataColumn("分娩结果", strType),	 //1
															new DataColumn("体重", floatType),//2
															new DataColumn("转归", strType),//3
															new DataColumn("呼吸", strType),//4
															new DataColumn("院内感染次", intType),//5
															new DataColumn("医院感染名称", strType),//6
															new DataColumn("ICD-10编码", strType), //7
															new DataColumn("抢救次数", intType),//8
															new DataColumn("抢救成功次数", intType),//9
															new DataColumn("序号", intType)});//10
                //绑定数据源
                this.fpEnter1_Sheet1.DataSource = dtBaby;
                //				//设置fpSpread1 的属性
                //				if(System.IO.File.Exists(filePath))
                //				{
                //					Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpEnter1_Sheet1,filePath);
                //				}
                //				else
                //				{
                //					Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpEnter1_Sheet1,filePath);
                //				}
                LockFpEnter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ucBabyCardInput_Load(object sender, System.EventArgs e)
        {
            //定义响应按键事件
            fpEnter1.KeyEnter += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.keyDown(fpEnter1_KeyEnter);
            fpEnter1.SetItem += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.setItem(fpEnter1_SetItem);
            fpEnter1.ShowListWhenOfFocus = true;
        }
        private int fpEnter1_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
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
            try
            {
                int CurrentRow = fpEnter1_Sheet1.ActiveRowIndex;
                if (CurrentRow < 0) return 0;

                if (fpEnter1_Sheet1.ActiveColumnIndex == 0)
                {
                    //获取选中的信息
                    Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, 0);
                    Neusoft.FrameWork.Models.NeuObject item = null;
                    int rtn = listBox.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //性别
                    fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                    fpEnter1.Focus();
                    fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, 1);
                    return 0;
                }
                else if (fpEnter1_Sheet1.ActiveColumnIndex == 1)
                {
                    Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, 1);
                    //获取选中的信息
                    Neusoft.FrameWork.Models.NeuObject item = null;
                    int rtn = listBox.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    // 分娩结果
                    fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                    fpEnter1.Focus();
                    fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, 2);
                    return 0;
                }
                else if (fpEnter1_Sheet1.ActiveColumnIndex == 3)
                {
                    Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, 3);
                    //获取选中的信息
                    Neusoft.FrameWork.Models.NeuObject item = null;
                    int rtn = listBox.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //转归
                    fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                    fpEnter1.Focus();
                    fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, 4);
                    return 0;
                }
                else if (fpEnter1_Sheet1.ActiveColumnIndex == 4)
                {
                    Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, 4);
                    //获取选中的信息
                    Neusoft.FrameWork.Models.NeuObject item = null;
                    int rtn = listBox.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //分期
                    fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                    fpEnter1.Focus();
                    fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, 5);
                    return 0;
                }
                else if (fpEnter1_Sheet1.ActiveColumnIndex == 6)
                {
                    Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, 6);
                    //获取选中的信息
                    Neusoft.FrameWork.Models.NeuObject item = null;
                    int rtn = listBox.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //ICD诊断名称 
                    fpEnter1_Sheet1.ActiveCell.Text = item.Name;
                    //ICD诊断编码 
                    fpEnter1_Sheet1.Cells[CurrentRow, 7].Text = item.ID;
                    fpEnter1.Focus();
                    fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, 8);
                    return 0;
                }
                else if (fpEnter1_Sheet1.ActiveColumnIndex == 7)
                {
                    Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpEnter1.getCurrentList(this.fpEnter1_Sheet1, 7);
                    //获取选中的信息
                    Neusoft.FrameWork.Models.NeuObject item = null;
                    int rtn = listBox.GetSelectedItem(out item);
                    //					if(rtn==-1)return -1;
                    if (item == null) return -1;
                    //ICD编码
                    fpEnter1_Sheet1.ActiveCell.Text = item.ID;
                    //ICD名称
                    fpEnter1_Sheet1.Cells[CurrentRow, 6].Text = item.Name;
                    fpEnter1.Focus();
                    fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, 8);
                    return 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
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
                    if (i == 0 || i == 1 || i == 3 || i == 4 || i == 6 || i == 7)
                    {
                        ProcessDept();
                    }
                    else if (i == 9)
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
                    else
                    {
                        if (i <= 8)
                        {
                            fpEnter1_Sheet1.SetActiveCell(fpEnter1_Sheet1.ActiveRowIndex, i + 1);
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
        protected override bool ProcessDialogKey(Keys keyData)
        {
            return base.ProcessDialogKey(keyData);
        }

        //添加一行项目
        public int AddRow()
        {
            try
            {
                if (fpEnter1_Sheet1.Rows.Count < 1)
                {
                    //增加一行空值
                    DataRow row = dtBaby.NewRow();
                    row["体重"] = 0;
                    row["抢救次数"] = 0;
                    row["抢救成功次数"] = 0;
                    dtBaby.Rows.Add(row);
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

        private void fpEnter1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            ////设置fpSpread1 的属性
            //if (System.IO.File.Exists(filePath))
            //{
            //    Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpEnter1_Sheet1, filePath);
            //}

        }
        /// <summary>
        /// 调整fpSpread1_Sheet1的宽度等 保存后触发的事件
        /// </summary>
        private void uc_GoDisplay()
        {
            //			LoadInfo(inpatientNo,operType); //重新加载数据

        }
        /// <summary>
        /// 设置网格宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            //Common.Controls.ucSetColumn uc = new Common.Controls.ucSetColumn();
            //uc.FilePath = this.filePath;
            //uc.GoDisplay += new Common.Controls.ucSetColumn.DisplayNow(uc_GoDisplay);
            //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            if (fpEnter1_Sheet1.Rows.Count > 0)
            {
                fpEnter1_Sheet1.Rows.Remove(fpEnter1_Sheet1.ActiveRowIndex, 1);
            }
        }
        #endregion 
    }
}

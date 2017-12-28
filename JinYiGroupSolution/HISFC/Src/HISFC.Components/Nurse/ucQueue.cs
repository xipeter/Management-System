using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse
{
    /// <summary>
    /// 分诊队列维护主窗口
    /// </summary>
    public partial class ucQueue : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 工具条处理程序

        /// <summary>
        /// 工具条
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("添加", "添加", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            this.toolBarService.AddToolButton("删除", "删除", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            this.toolBarService.AddToolButton("编辑", "编辑", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            this.toolBarService.AddToolButton("模板", "模板", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A安排, true, false, null);

            return this.toolBarService;
            //return base.OnInit(sender, neuObject, param);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "添加":
                    this.AddData();
                    break;
                case "删除":
                    this.DelData();
                    break;
                case "编辑":
                    this.EditData();
                    break;
                case "模板":
                    this.PopWin("2");
                    break;
                default:
                    break;
            }
        }

        #endregion
        

        public ucQueue()
        {
            InitializeComponent();
        }

        #region 定义域

        /// <summary>
        /// 增加编辑队列控件
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Registration.Registration myMgr = null;

        /// <summary>
        /// 分诊管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Nurse.Assign assignMgr = new Neusoft.HISFC.BizLogic.Nurse.Assign();

        private Neusoft.HISFC.BizProcess.Integrate.Manager personMgr = null;

        private ArrayList alNurse = new ArrayList();
        private ArrayList al = new ArrayList();
        private Hashtable htNoon = new Hashtable();
        private Hashtable htDoct = new Hashtable();

        private Neusoft.HISFC.BizLogic.Nurse.Queue myQueue = new Neusoft.HISFC.BizLogic.Nurse.Queue();
        private Neusoft.HISFC.Models.Nurse.Queue Queue = new Neusoft.HISFC.Models.Nurse.Queue();
        private Neusoft.HISFC.BizProcess.Integrate.Manager cDept = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.FrameWork.Models.NeuObject neuobj = new Neusoft.FrameWork.Models.NeuObject();
        private Nurse.cResult myResult = new cResult();

        #endregion

        #region 方法
        /// <summary>
        /// 校验日期
        /// </summary>
        /// <returns></returns>
        public int myValidDate()
        {
            if (this.dtDate.Value.Date < this.assignMgr.GetDateTimeFromSysDateTime().Date)
            {
                MessageBox.Show("待维护队列的日期不能小于当前日期");
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 1"编辑窗体"
        /// 2"模板窗体"
        /// </summary>
        /// <param name="strTag"></param>
        private void PopWin(string strTag)
        {
            try
            {
                if (this.myValidDate() < 0)
                {
                    return;
                }
                if (this.tabPage1.Tag == null)
                {
                    MessageBox.Show("请选择病区!!");
                    return;
                }
                neuobj = this.tabPage1.Tag as Neusoft.FrameWork.Models.NeuObject;
                this.myResult.Queue.QueueDate = this.dtDate.Value;
                this.myResult.Queue.Dept.ID = neuobj.ID;
                this.myResult.Queue.Dept.Name = neuobj.Name;
                Neusoft.FrameWork.Models.NeuObject obj = (Neusoft.FrameWork.Models.NeuObject)this.tvPatientList1.SelectedNode.Tag;
                if (obj == null)
                {
                    MessageBox.Show("请选择病区");
                    return;
                }
                this.myResult.Nurse = obj;
                if (strTag == "1")
                {
                    ucAddQueue ucaddQueue = new ucAddQueue(this.myResult);

                    this.myResult.QueueList = new List<Neusoft.HISFC.Models.Nurse.Queue>();
                    for (int i = 0, j = this.neuSpread1_Sheet1.RowCount; i < j; i++)
                    {
                        this.myResult.QueueList.Add(this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Nurse.Queue);
                    }
                    
                    ucaddQueue.RefList +=new ucAddQueue.ClickSave(ucQueue_RefList); 
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucaddQueue);

                    #region {B3E7633A-D9FB-492f-9D62-D2F7188D5643}
                    if (ucaddQueue.AddQueDiagResult == DialogResult.OK)
                    {
                        //重新加载界面上当前行的数据
                        #region //需要新添加1行{7F5DF30E-AB9C-439f-A7A3-F0FEC05BBF2B}
                        if (this.myResult.strTab == "ADD")
                        {
                            this.neuSpread1_Sheet1.AddRows(0, 1);
                        }
                        #endregion
                        this.ReLoadFpData(this.neuSpread1_Sheet1.ActiveRowIndex, ucaddQueue.Queue);
                    }
                    #endregion
                }
                if (strTag == "2")
                {
                    ucQueueQuery uc = new ucQueueQuery(this.myResult.Queue.Dept);
                    uc.RefList += new Nurse.ucQueueQuery.RefQueue(uc_RefList);
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        private void AddData()
        {
            if (this.btnRefresh.Tag != null && this.btnRefresh.Tag.ToString() == "SAVE")
            {
                MessageBox.Show("添加新数据之前需要把之前导入的数据保存！");
                return;
            }

            myResult = new cResult();
            myResult.Queue.IsValid = true;
            this.myResult.strTab = "ADD";
            this.PopWin("1");
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="alQueue"></param>
        private void uc_RefList(ArrayList alQueue)
        {
            try
            {
                this.al = new ArrayList();
                this.al = alQueue;
                if (alQueue == null)
                    return;
                this.LoadFp(alQueue, "2");
                this.btnRefresh.Text = "保 存";
                this.btnRefresh.Tag = "SAVE";
            }
            catch { }
        }

        private void ucQueue_RefList(Neusoft.FrameWork.Models.NeuObject obj)
        {
            this.RefreshList(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string GetNoonNameByID(string ID)
        {
            IDictionaryEnumerator dict = this.htNoon.GetEnumerator();
            while (dict.MoveNext())
            {
                if (dict.Key.ToString() == ID)
                    return dict.Value.ToString();
            }
            return ID;
        }

        private string GetDoctNameByID(string ID)
        {
            IDictionaryEnumerator dict = this.htDoct.GetEnumerator();
            while (dict.MoveNext())
            {
                if (dict.Key.ToString() == ID)
                    return dict.Value.ToString();
            }
            return ID;
        }

        /// <summary>
        /// 刷新FarPoint列表
        /// </summary>
        /// <param name="nurse"></param>
        private void RefreshList(Neusoft.FrameWork.Models.NeuObject nurse)
        {
            try
            {
                if (this.neuSpread1_Sheet1.RowCount > 0)
                    this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);

                //检索病区的维护信息
                this.alNurse = this.myQueue.Query(nurse.ID, this.dtDate.Value.ToShortDateString());

                this.tabPage1.Text = nurse.Name;

                this.neuSpread1_Sheet1.Tag = nurse;

                if (alNurse != null)
                {
                    this.LoadFp(alNurse, "1");
                }
                this.SetFP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + this.myQueue.Err);
            }
        }

        /// <summary>
        /// 数据添加到farpoint中
        /// </summary>
        /// <param name="al">队列集合</param>
        /// <param name="strNew">传入2表示导入模板，1为从数据库中取</param>
        private void LoadFp(ArrayList al, string strNew)
        {
            foreach (Neusoft.HISFC.Models.Nurse.Queue obj in al)
            {
                #region {4BC497AF-5A35-485f-9F5F-A58139E1BDFD}
                //对模板导入的数据队列日期置为界面选择的日期,以方便于判断是否重复
                //导入时ID也置为空，要不删除时会按照这个ID检索数据库
                if (strNew == "2")
                {
                    obj.ID = "";
                    obj.QueueDate = this.dtDate.Value;
                }
                #endregion
                if (this.FilterExistQueue(obj))
                {
                    continue;
                }

                this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);
                int row = this.neuSpread1_Sheet1.RowCount - 1;
                this.neuSpread1_Sheet1.Rows[row].Tag = obj;

                //队列名称
                this.neuSpread1_Sheet1.SetValue(row, 0, obj.Name, false);
                //午别
                obj.Noon.Name = this.GetNoonNameByID(obj.Noon.ID);
                this.neuSpread1_Sheet1.SetValue(row, 1, obj.Noon.Name, false);
                //显示顺序
                this.neuSpread1_Sheet1.SetValue(row, 2, obj.Order, false);
                //是否有效
                this.neuSpread1_Sheet1.SetValue(row, 3, obj.IsValid ? "有效" : "无效", false);
                //队列日期

                //传入2表示导入模板，1为从数据库中取
                if (strNew == "2")
                {
                    this.neuSpread1_Sheet1.SetValue(row, 4, this.dtDate.Value.ToString("yyyy-MM-dd"), false);
                }
                else
                {
                    this.neuSpread1_Sheet1.SetValue(row, 4, obj.QueueDate.ToString("yyyy-MM-dd"), false);
                }
                //看诊科室
                this.neuSpread1_Sheet1.SetValue(row, 5, obj.AssignDept.Name);
                //看诊医生
                obj.Doctor.Name = this.GetDoctNameByID(obj.Doctor.ID);
                this.neuSpread1_Sheet1.SetValue(row, 6, obj.Doctor.Name, false);
                //诊室
                this.neuSpread1_Sheet1.SetValue(row, 7, obj.SRoom.Name, false);
                //诊台
                this.neuSpread1_Sheet1.SetValue(row, 8, obj.Console.Name, false);
                //是否专家
                if (obj.ExpertFlag == "1")
                {
                    this.neuSpread1_Sheet1.SetValue(row, 9, "是", false);
                }
                else
                {
                    this.neuSpread1_Sheet1.SetValue(row, 9, "否", false);
                }
                //备注
                this.neuSpread1_Sheet1.SetValue(row, 10, obj.Memo, false);
                //操作员
                this.neuSpread1_Sheet1.SetValue(row, 11, obj.Oper.ID, false);
                //操作时间
                this.neuSpread1_Sheet1.SetValue(row, 12, this.myQueue.GetDateTimeFromSysDateTime(), false);
                //队列类型
                this.neuSpread1_Sheet1.SetValue(row, 13, obj.User01);
            }
            this.SetFP();
        }

        /// <summary>
        /// 如果队列已经存在则返回true
        /// </summary>
        /// <param name="queue">队列实体,用于比较</param>
        /// <returns>true,已经存在</returns>
        private bool FilterExistQueue(Neusoft.HISFC.Models.Nurse.Queue queue)
        {
            Neusoft.HISFC.Models.Nurse.Queue temp = null;

            for (int i = 0, j = this.neuSpread1_Sheet1.RowCount; i < j; i++)
            {
                temp = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Nurse.Queue;
                if (queue.Noon.ID == temp.Noon.ID && 
                    queue.QueueDate.Date == temp.QueueDate.Date &&
                    queue.AssignDept.ID == temp.AssignDept.ID && 
                    queue.Doctor.ID == temp.Doctor.ID &&
                    queue.Console.ID == temp.Console.ID &&
                    queue.IsValid == temp.IsValid)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 保存队列模板
        /// </summary>
        /// <param name="alQueue"></param>
        private void SaveQueue(ArrayList alQueue)
        {
            //Neusoft.FrameWork.Management.Transaction tran = new Neusoft.FrameWork.Management.Transaction(this.myQueue.Connection);
            //开始事务
            try
            {
                //tran.BeginTransaction();

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                this.myQueue.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                foreach (Neusoft.HISFC.Models.Nurse.Queue obj in alQueue)
                {
                    obj.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.myQueue.GetDateTimeFromSysDateTime());
                    obj.QueueDate = this.dtDate.Value;
                    if (this.myQueue.InsertQueue(obj) == -1)
                    {
                        MessageBox.Show("保存失败!!" + this.myQueue.Err);
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存失败!!" + ex.ToString());
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功!!");
            this.btnRefresh.Text = "刷 新";
            this.btnRefresh.Tag = "REF";
            this.SetFP();
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        private void EditData()
        {
            try
            {
                this.myResult = new cResult();
                int iRow = this.neuSpread1_Sheet1.ActiveRowIndex;
                this.SetEdit(iRow);
                this.myResult.strTab = "EDIT";
                this.PopWin("1");
            }
            catch { }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void DelData()
        {
            try
            {
                int row = this.neuSpread1_Sheet1.ActiveRowIndex;
                if (row < 0 || this.neuSpread1_Sheet1.RowCount == 0) return;
                string strNo = ((Neusoft.HISFC.Models.Nurse.Queue)this.neuSpread1_Sheet1.Rows[row].Tag).ID;

                //队列有未诊出患者则不能删除
                ArrayList alTemp = new ArrayList();
                alTemp = this.assignMgr.QueryByQueueCode(strNo);
                if (alTemp != null && alTemp.Count > 0)
                {
                    MessageBox.Show("该队列中还有未诊出患者，不能删除!", "队列中患者全部诊出后才能删除!");
                    return;
                }
                if (MessageBox.Show("是否要删除该记录?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                //已经保存的项目,从数据库中删除
                if (this.neuSpread1_Sheet1.Rows[row].Tag != null)
                {
                    if (this.myQueue.DelQueue(strNo) == -1)
                    {
                        MessageBox.Show("删除失败!!" + this.myQueue.Err);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("删除成功!");
                        if (this.tabPage1.Tag != null)
                        {
                            #region {58E77C58-5FC4-4b5e-A3DF-2BCB952B340E}
                            //当界面上的数据都是未保存的，删除数据时不应该刷新界面，导致未保存的数据全部消失

                            this.neuSpread1_Sheet1.Rows.Remove(row, 1);
                            //this.RefreshList(((Neusoft.FrameWork.Models.NeuObject)this.tabPage1.Tag));
                            #endregion
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + this.myQueue.Err);
            }
        }

        /// <summary>
        /// 初始化左面树
        /// </summary>
        private void InitTree()
        {
            this.tvPatientList1.Nodes.Clear();

            TreeNode root = new TreeNode("护士站");
            this.tvPatientList1.Nodes.Add(root);

            Neusoft.HISFC.Models.Base.Employee e = (Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator;
            //if (this.Tag != null && this.Tag.ToString() == "ALL")
            if( e.IsManager )
            {
                //获全部护士站列表(全部权限的维护)
                this.alNurse = cDept.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
                if (alNurse != null)
                {
                    foreach (Neusoft.FrameWork.Models.NeuObject obj in alNurse)
                    {
                        TreeNode node = new TreeNode(obj.Name);
                        node.Tag = obj;
                        root.Nodes.Add(node);
                    }
                }
            }
            else
            {
                //只维护自己护理站----------------------------------
                //TreeNode node = new TreeNode(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.Name);
                //node.Tag = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse;
                TreeNode node = new TreeNode(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.Name);
                node.Tag = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept;
                root.Nodes.Add(node);
                //end-----------------------------------------------
            }
            root.Expand();
        }

        /// <summary>
        /// 重新加载界面某一行的数据
        /// {B3E7633A-D9FB-492f-9D62-D2F7188D5643}
        /// </summary>
        /// <param name="activeRow">行号</param>
        /// <param name="obj">队列实体</param>
        private void ReLoadFpData(int activeRow,Neusoft.HISFC.Models.Nurse.Queue obj)
        {
            //队列名称
            this.neuSpread1_Sheet1.SetValue(activeRow, 0, obj.Name, false);
            //午别
            obj.Noon.Name = this.GetNoonNameByID(obj.Noon.ID);
            this.neuSpread1_Sheet1.SetValue(activeRow, 1, obj.Noon.Name, false);
            //显示顺序
            this.neuSpread1_Sheet1.SetValue(activeRow, 2, obj.Order, false);
            //是否有效
            this.neuSpread1_Sheet1.SetValue(activeRow, 3, obj.IsValid ? "有效" : "无效", false);
            //队列日期
            this.neuSpread1_Sheet1.SetValue(activeRow, 4, obj.QueueDate.ToString("yyyy-MM-dd"), false);
            
            //看诊科室
            this.neuSpread1_Sheet1.SetValue(activeRow, 5, obj.AssignDept.Name);
            //看诊医生
            obj.Doctor.Name = this.GetDoctNameByID(obj.Doctor.ID);
            this.neuSpread1_Sheet1.SetValue(activeRow, 6, obj.Doctor.Name, false);
            //诊室
            this.neuSpread1_Sheet1.SetValue(activeRow, 7, obj.SRoom.Name, false);
            //诊台
            this.neuSpread1_Sheet1.SetValue(activeRow, 8, obj.Console.Name, false);
            //是否专家
            if (obj.ExpertFlag == "1")
            {
                this.neuSpread1_Sheet1.SetValue(activeRow, 9, "是", false);
            }
            else
            {
                this.neuSpread1_Sheet1.SetValue(activeRow, 9, "否", false);
            }
            //备注
            this.neuSpread1_Sheet1.SetValue(activeRow, 10, obj.Memo, false);
            //操作员
            this.neuSpread1_Sheet1.SetValue(activeRow, 11, obj.Oper.ID, false);
            //操作时间
            this.neuSpread1_Sheet1.SetValue(activeRow, 12, this.myQueue.GetDateTimeFromSysDateTime(), false);
            //队列类型
            this.neuSpread1_Sheet1.SetValue(activeRow, 13, obj.User01);

            this.neuSpread1_Sheet1.Rows[activeRow].Tag = obj;
        }

        #endregion

        private void ucQueue_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitTree();

                this.Init();
            }
            catch { }
        }

        private void Init()
        {
            if (this.myMgr == null) this.myMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
            al = this.myMgr.Query();
            foreach (Neusoft.HISFC.Models.Registration.Noon noon in al)
            {
                this.htNoon.Add(noon.ID, noon.Name);
            }

            if (this.personMgr == null) this.personMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //得到医生列表
            al = new ArrayList();
            al = this.personMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            foreach (Neusoft.HISFC.Models.Base.Employee person in al)
            {
                this.htDoct.Add(person.ID, person.Name);
            }
            this.btnRefresh.Text = "刷 新";
            this.btnRefresh.Tag = "REF";
            this.SetFP();
            this.dtDate.Value = this.myQueue.GetDateTimeFromSysDateTime();
        }

        private void SetRef()
        {
            this.btnRefresh.Text = "刷 新";
            this.btnRefresh.Tag = "REF";
        }
        private void SetSave()
        {
            this.btnRefresh.Text = "保 存";
            this.btnRefresh.Tag = "SAVE";
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            int altKey = Keys.Alt.GetHashCode();

            //if (keyData == Keys.Add || keyData == Keys.Oemplus)
            //{
            //    this.AddData();
            //    return true;
            //}
            //else if (keyData == Keys.Subtract || keyData == Keys.OemMinus)
            //{
            //    this.DelData();
            //    return true;
            //}
            //if (keyData.GetHashCode() == altKey + Keys.E.GetHashCode())
            //{
            //    this.EditData();
            //    return true;
            //}
            //if (keyData.GetHashCode() == altKey + Keys.X.GetHashCode())
            //{
            //    this.FindForm().Close();
            //    return true;
            //}

            return base.ProcessDialogKey(keyData);
        }

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (neuSpread1_Sheet1.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可选择修改");
                return;
            }
        }

        private void SetEdit(int iRow)
        {
            if (this.myResult == null) this.myResult = new cResult();
#region {231F627C-1215-4024-AE4A-6E06F7D20FC1}
            this.myResult.Queue = (this.neuSpread1_Sheet1.Rows[iRow].Tag as Neusoft.HISFC.Models.Nurse.Queue).Clone(); 
            #endregion
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.btnRefresh.Tag != null && this.btnRefresh.Tag.ToString() == "SAVE")
            {
                #region {B3E7633A-D9FB-492f-9D62-D2F7188D5643}
                ArrayList alSave = new ArrayList();
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Nurse.Queue obj = new Neusoft.HISFC.Models.Nurse.Queue();
                    obj = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Nurse.Queue;
                    alSave.Add(obj);
                }
                this.SaveQueue(alSave);

                //this.SaveQueue(this.al);
                #endregion
            }

            if (this.tabPage1.Tag != null && this.btnRefresh.Tag.ToString() == "REF")
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj = this.tabPage1.Tag as Neusoft.FrameWork.Models.NeuObject;
                this.RefreshList(obj);
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.EditData();
        }

        private void SetFP()
        {
            this.neuSpread1_Sheet1.Columns[11].Visible = false;
            this.neuSpread1_Sheet1.Columns[12].Visible = false;
            this.neuSpread1_Sheet1.Columns[13].Visible = false;
        }

        private void tvPatientList1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode current = this.tvPatientList1.SelectedNode;

                if (current == null || current.Parent == null)
                {
                    if (this.neuSpread1_Sheet1.RowCount > 0)
                        this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.RowCount);

                    this.neuSpread1_Sheet1.Tag = null;
                }
                else
                {
                    Neusoft.FrameWork.Models.NeuObject nurse = (Neusoft.FrameWork.Models.NeuObject)current.Tag;
                    this.tabPage1.Tag = nurse;
                    this.RefreshList(nurse);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }




    #region 类

    public class cResult
    {
        public string Result1 = "";
        public string Result2 = "";
        public string strTab = "";
        public ArrayList arrFee = new ArrayList();
        public Neusoft.FrameWork.Models.NeuObject Nurse = new Neusoft.FrameWork.Models.NeuObject();
        public Neusoft.HISFC.Models.Nurse.Queue Queue = new Neusoft.HISFC.Models.Nurse.Queue();
        public List<Neusoft.HISFC.Models.Nurse.Queue> QueueList = new List<Neusoft.HISFC.Models.Nurse.Queue>();
    }
    #endregion
}

using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
namespace Neusoft.HISFC.Components.Nurse.Controls
{

    /// <summary>
    /// [功能描述: 急诊留观患者列表树]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class tvEmergencyBasePatientList : Neusoft.HISFC.Components.Common.Controls.tvPatientList
    {

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public tvEmergencyBasePatientList()
        {
            // Windows.Forms 类撰写设计器支持所必需的
            InitializeComponent();
            //初始化
            this.Init();
        }

        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;

        #region 组件设计器生成的代码

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tvEmergencyBasePatientList));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            // 
            // tvEmergencyBasePatientList
            // 
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.LineColor = System.Drawing.Color.Black;
            this.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvEmergencyObservePatientList_AfterCheck);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvEmergencyObservePatientList_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvEmergencyObservePatientList_MouseDown);
            this.ResumeLayout(false);

        }
        #endregion

        #region 枚举
        /// <summary>
        /// 显示其他信息-住院号，科室，病床，在院状态
        /// </summary>
        public enum enuShowType
        {
            None = 0,
            InpatientNo = 1,
            Dept = 3,
            Bed = 5,
            Status = 7
        }

        /// <summary>
        /// 显示信息方向，前面，后面(姓名放在相反的方向)
        /// </summary>
        public enum enuShowDirection
        {
            Ahead,
            Behind
        }

        /// <summary>
        /// 选择类型
        /// </summary>
        public enum enuChecked
        {
            None,
            Radio,
            MultiSelect
        }
        #endregion

        #region 变量
        private ArrayList myPatients = new ArrayList();
        private enuShowType myShowType = enuShowType.Bed;   //默认显示床号
        private enuChecked myChecked = enuChecked.None;     //默认不显示CheckBox
        private enuShowDirection myDirection = enuShowDirection.Ahead; //默认其他信息放在前面,姓名放在后面
        private bool bIsShowNewPatient = true;  //默认如果是当天入院的患者,显示【新】
        private bool bControlChecked = false;
        private DateTime dtToday;
        protected bool bIsShowPatientNo = true;
        protected bool bIsShowCount = true;
        public int RootImageIndex = 0;
        public int RootSelectedImageIndex = 1;
        public int BranchImageIndex = 2;
        public int BranchSelectedImageIndex = 3;
        public int MaleImageIndex = 4;
        public int MaleSelectedImageIndex = 5;
        public int FemaleImageIndex = 6;
        public int FemaleSelectedImageIndex = 7;
        public int BabyImageIndex = 8;
        public int GirlImageIndex = 10;
        public int LeaveImageIndex = 12;

        #endregion

        #region 函数
        /// <summary>
        /// 是否显示新的患者
        /// </summary>
        public bool IsShowNewPatient
        {
            get
            {
                return this.bIsShowNewPatient;
            }
            set
            {
                this.bIsShowNewPatient = value;
            }
        }

        /// <summary>
        /// 显示类型
        /// </summary>
        public enuShowType ShowType
        {
            get
            {
                return this.myShowType;
            }
            set
            {
                this.myShowType = value;
            }
        }

        /// <summary>
        /// 患者数组，包含分割object
        /// </summary>
        public void SetPatient(ArrayList alPatients)
        {
            if (alPatients == null) return;
            this.myPatients = alPatients;
            this.RefreshList();

        }

        /// <summary>
        /// 显示选择类型
        /// </summary>
        public enuChecked Checked
        {
            get
            {
                return this.myChecked;
            }
            set
            {
                this.myChecked = value;
                if (this.myChecked == enuChecked.MultiSelect)
                {
                    this.CheckBoxes = true;
                }
                else
                {
                    this.CheckBoxes = false;
                }
            }
        }

        /// <summary>
        /// 显示其他信息位置
        /// </summary>
        public enuShowDirection Direction
        {
            get
            {
                return this.myDirection;
            }
            set
            {
                this.myDirection = value;
            }
        }

        /// <summary>
        /// 是否显示nodeCount
        /// </summary>
        public bool IsShowCount
        {
            get
            {
                return this.bIsShowCount;
            }
            set
            {
                this.bIsShowCount = value;
            }
        }
        /// <summary>
        /// 是否显示tooltip住院号
        /// </summary>
        public bool IsShowPatientNo
        {
            get
            {
                return this.bIsShowPatientNo;
            }
            set
            {
                this.bIsShowPatientNo = value;
            }
        }
        // by zlw 2006-5-1
        private bool bIsShowContextMenu = true;
        /// <summary>
        /// 是否弹出右键菜单，显示患者属性,默认值为 true 显示 
        /// </summary>
        public bool IsShowContextMenu
        {
            get
            {
                return this.bIsShowContextMenu;
            }
            set
            {
                this.bIsShowContextMenu = value;
            }
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void RefreshList()
        {
            this.Nodes.Clear();
            int Branch = 0;
            if (this.myPatients.Count == 0) this.AddRootNode();
            for (int i = 0; i < this.myPatients.Count; i++)
            {
                System.Windows.Forms.TreeNode newNode = new System.Windows.Forms.TreeNode();
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                //类型为叶
                if (this.myPatients[i].GetType().ToString() == "Neusoft.HISFC.Models.Registration.Register")
                {
                    try
                    {
                        
                        Neusoft.HISFC.Models.Registration.Register PatientInfo = (Neusoft.HISFC.Models.Registration.Register)this.myPatients[i];
                        obj.ID = PatientInfo.PID.PatientNO;
                        obj.Name = PatientInfo.Name;
                        try
                        {
                            obj.Memo = PatientInfo.PVisit.PatientLocation.Bed.ID;
                            try
                            {	//请假
                                if (PatientInfo.PVisit.PatientLocation.Bed.Status.ID.ToString() == "R")
                                {
                                    obj.Name = obj.Name + "【请假】";
                                }
                            }
                            catch { }
                        }
                        catch
                        {//无病床信息
                        }
                        obj.User01 = PatientInfo.PVisit.PatientLocation.Dept.Name;
                        obj.User02 = PatientInfo.PVisit.InState.Name;
                        obj.User03 = PatientInfo.Sex.ID.ToString();
                        //入院不超过24小时,显示(新)
                        if (this.bIsShowNewPatient)
                        {
                            if (dtToday < PatientInfo.PVisit.InTime.Date.AddDays(1)) obj.Name = obj.Name + "(新)";
                        }
                        this.AddTreeNode(Branch, obj, PatientInfo);
                    }
                    catch { }
                }
                else if (this.myPatients[i].GetType().ToString() == "Neusoft.HISFC.Models.RADT.Patient")
                {
                    Neusoft.HISFC.Models.RADT.Patient PatientInfo = (Neusoft.HISFC.Models.RADT.Patient)this.myPatients[i];
                    obj.ID = PatientInfo.PID.PatientNO;
                    obj.Name = PatientInfo.Name;
                    obj.Memo = "";
                    obj.User01 = "";
                    obj.User02 = "";
                    obj.User03 = PatientInfo.Sex.ID.ToString();
                    this.AddTreeNode(Branch, obj, PatientInfo);
                }
                else if (this.myPatients[i].GetType().ToString() == "Neusoft.FrameWork.Models.NeuObject")
                {
                    obj = (Neusoft.FrameWork.Models.NeuObject)this.myPatients[i];
                    this.AddTreeNode(Branch, obj, obj);
                }
                else
                {//为干
                    //分割字符串 text|tag 标识结点
                    string all = this.myPatients[i].ToString();
                    string[] s = all.Split('|');

                    newNode.Text = s[0];

                    try
                    {
                        newNode.Tag = s[1];
                    }
                    catch { newNode.Tag = ""; }
                    try
                    {
                        newNode.ImageIndex = this.BranchImageIndex;
                        newNode.SelectedImageIndex = this.BranchSelectedImageIndex;
                    }
                    catch { }
                    Branch = this.Nodes.Add(newNode);
                }
            }
            if (this.bIsShowCount)
            {
                foreach (System.Windows.Forms.TreeNode node in this.Nodes)
                {

                    if (node.Tag == null || node.Tag.GetType().ToString() == "System.String")
                    {//结点
                        int count = 0;
                        count = node.GetNodeCount(false);
                        node.Text = node.Text + "(" + count.ToString() + ")";
                    }
                }
            }
            this.ExpandAll();
            try//wolf added ensure node visible 
            {
                if (this.SelectedNode == null)
                {
                    try
                    {
                        this.SelectedNode = this.Nodes[0];
                    }
                    catch { }
                }
                this.SelectedNode.EnsureVisible();
            }
            catch { }

        }


        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="branch">父级节点索引</param>
        /// <param name="nodeIndex">要删除节点索引</param>
        public void DeleteNode(int branch, int nodeIndex)
        {
            //移除节点
            this.Nodes[branch].Nodes[nodeIndex].Remove();
        }


        /// <summary>
        /// 根据传入参数,修改指定的节点信息
        /// </summary>
        /// <param name="node">待修改的节点</param>
        /// <param name="nodeTextInfo">节点信息</param>
        /// <param name="nodeTag">节点的tag属性</param>
        public void ModifiyNode(System.Windows.Forms.TreeNode node, Neusoft.FrameWork.Models.NeuObject nodeTextInfo, object nodeTag)
        {
            try
            {
                //生成节点信息
                this.CreateNodeInfo(nodeTextInfo, nodeTag, ref node);
            }
            catch { }
        }


        /// <summary>
        /// 根据传入参数,修改指定的节点信息
        /// </summary>
        /// <param name="node">待修改的节点</param>
        /// <param name="patientInfo">患者信息</param>
        public void ModifiyNode(System.Windows.Forms.TreeNode node, Neusoft.HISFC.Models.Registration.Register patientInfo)
        {
            try
            {
                Neusoft.FrameWork.Models.NeuObject nodeTextInfo = new Neusoft.FrameWork.Models.NeuObject();
                nodeTextInfo.ID = patientInfo.PID.PatientNO;
                nodeTextInfo.Name = patientInfo.Name;
                try
                {
                    nodeTextInfo.Memo = patientInfo.PVisit.PatientLocation.Bed.ID;
                }
                catch
                {//无病床信息
                }

                nodeTextInfo.User01 = patientInfo.PVisit.PatientLocation.Dept.Name;
                nodeTextInfo.User02 = patientInfo.PVisit.InState.Name;
                nodeTextInfo.User03 = patientInfo.Sex.ID.ToString();
                if (this.bIsShowNewPatient)
                {
                    if (dtToday.Date == patientInfo.PVisit.InTime.Date)
                        nodeTextInfo.Name = nodeTextInfo.Name + "(新)";
                }

                //定义节点的引用,指向要修改的节点
                this.ModifiyNode(node, nodeTextInfo, patientInfo);
            }
            catch { }
        }


        /// <summary>
        /// 根据传入的信息,增加一个新节点
        /// </summary>
        /// <param name="branch">一级节点索引</param>
        /// <param name="nodeTextInfo">节点信息</param>
        /// <param name="nodeTag">节点Tag属性</param>
        public void AddTreeNode(int branch, Neusoft.FrameWork.Models.NeuObject nodeTextInfo, object nodeTag)
        {
            System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode();
            //生产要添加的节点
            this.CreateNodeInfo(nodeTextInfo, nodeTag, ref node);

            //指定当前选中的节点
            try
            {
                //this.SelectedNode=this.Nodes[branch];
                //在父级节点下增加新节点
                this.Nodes[branch].Nodes.Add(node);
            }
            catch
            {
                this.Nodes.Add(new System.Windows.Forms.TreeNode("患者"));
                //this.SelectedNode=this.Nodes[0];
                //在选中的节点上增加新节点
                this.Nodes[0].Nodes.Add(node);
            }

            //在选中的节点上增加新节点
            //this.SelectedNode.Nodes.Add(node);

        }


        /// <summary>
        /// 根据传入参数,插入新节点
        /// </summary>
        /// <param name="branch">一级节点索引</param>
        /// <param name="patientInfo">患者信息</param>
        public void AddTreeNode(int branch, Neusoft.HISFC.Models.Registration.Register patientInfo)
        {
            try
            {

                //节点信息
                Neusoft.FrameWork.Models.NeuObject nodeTextInfo = new Neusoft.FrameWork.Models.NeuObject();
                nodeTextInfo.ID = patientInfo.PID.PatientNO;				//住院号
                nodeTextInfo.Name = patientInfo.Name;								//患者姓名
                nodeTextInfo.Memo = patientInfo.PVisit.PatientLocation.Bed.ID;		//床号
                nodeTextInfo.User01 = patientInfo.PVisit.PatientLocation.Dept.Name;	//科室名称
                nodeTextInfo.User02 = patientInfo.PVisit.InState.Name;				//在院状态
                nodeTextInfo.User03 = patientInfo.Sex.ID.ToString();		//性别
                //根据患者的入院日期,判断是否显示"(新)"
                if (this.bIsShowNewPatient)
                {
                    if (dtToday.Date == patientInfo.PVisit.InTime.Date)
                        nodeTextInfo.Name = nodeTextInfo.Name + "(新)";
                }

                //定义节点的引用,指向要修改的节点
                this.AddTreeNode(branch, nodeTextInfo, patientInfo);
            }
            catch { }
        }


        /// <summary>
        /// 根据传入参数,创建节点信息
        /// </summary>
        /// <param name="neuObj">节点Text信息:obj.id ,name,memo=bed,user01=dept,user02=status user03=sex </param>
        /// <param name="obj">节点的Tag属性</param>
        /// <param name="node">返回参数:节点</param>
        private void CreateNodeInfo(Neusoft.FrameWork.Models.NeuObject neuObj, object obj, ref System.Windows.Forms.TreeNode node)
        {
            //如果传入节点为空,则新建一个节点
            if (node == null)
                node = new System.Windows.Forms.TreeNode();

            #region 生成节点的Text
            string strText = neuObj.Name; //患者姓名
            string strMemo = "";
            switch (this.myShowType.GetHashCode())
            {
                case 1:
                    //住院号
                    strMemo = "【" + neuObj.ID + "】";
                    break;
                case 3:
                    //科室
                    if (neuObj.User01 != "" || neuObj.User01 != null) strMemo = "【" + neuObj.User01 + "】";
                    break;
                case 5:
                    //病床
                    if (neuObj.Memo != "" || neuObj.Memo != null)
                    {
                        strMemo = neuObj.Memo;

                        if (strMemo.Length > 4)
                        {
                            strMemo = strMemo.Substring(4);
                        }
                        #region

                        #endregion
                        strMemo = "【" + strMemo + "】";
                    }
                    break;
                case 7:
                    //状态
                    strMemo = "【" + neuObj.User02 + "】";
                    break;
                case 4:
                    //科室+住院号
                    strMemo = "【" + neuObj.User01 + "】" + "【" + neuObj.ID + "】";
                    break;
                case 6:
                    //病床+住院号
                    if (neuObj.Memo != "" || neuObj.Memo != null)
                        strMemo = "【" + neuObj.Memo.Substring(4) + "】" + "【" + neuObj.ID + "】";
                    else
                        strMemo = "【" + neuObj.ID + "】";
                    break;
                case 8:
                    //住院号+状态
                    strMemo = "【" + neuObj.ID + "】" + "【" + neuObj.User02 + "】";
                    break;
                case 10:
                    //科室+状态
                    strMemo = "【" + neuObj.User01 + "】" + "【" + neuObj.User02 + "】";
                    break;
                case 12:
                    //病床+状态
                    if (neuObj.Memo != "" || neuObj.Memo != null)
                        strMemo = "【" + neuObj.Memo.Substring(4) + "】" + "【" + neuObj.User02 + "】";
                    else
                        strMemo = "【" + neuObj.User02 + "】";
                    break;
                default:
                    strMemo = "";
                    break;
            }

            //根据显示位置,确定最终的名称
            if (this.myDirection == enuShowDirection.Behind)
            {
                strText = strText + strMemo;
            }
            else
            {
                strText = strMemo + strText;
            }
            node.Text = strText;
            #endregion

            //生产节点的ImageIndex
            switch (neuObj.User03)
            {
                case "F":
                    //男
                    if (((Neusoft.FrameWork.Models.NeuObject)obj).ID.IndexOf("B") > 0)
                        node.ImageIndex = this.GirlImageIndex;	//婴儿女
                    else
                        node.ImageIndex = this.FemaleImageIndex;	//成年女
                    break;
                case "M":
                    if (((Neusoft.FrameWork.Models.NeuObject)obj).ID.IndexOf("B") > 0)
                        node.ImageIndex = this.BabyImageIndex;	//婴儿男
                    else
                        node.ImageIndex = this.MaleImageIndex;	//成年男
                    break;
                default:
                    node.ImageIndex = this.MaleImageIndex;
                    break;
            }
            //生产节点的SelectedImageIndex
            node.SelectedImageIndex = node.ImageIndex + 1;

            //生产节点的Tag属性
            node.Tag = obj;
        }


        /// <summary>
        /// 根据患者信息和一级节点,查找其子节点中患者所在的节点Index
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="patientInfo"></param>
        /// <returns></returns>
        public System.Windows.Forms.TreeNode FindNode(int branch, Neusoft.HISFC.Models.Registration.Register patientInfo)
        {
            Neusoft.HISFC.Models.Registration.Register findPatient = null;
            foreach (System.Windows.Forms.TreeNode node in this.Nodes[branch].Nodes)
            {
                //取节点上的患者信息
                findPatient = node.Tag as Neusoft.HISFC.Models.Registration.Register;
                //如果不能转换为患者信息,则继续查找下一个节点
                if (findPatient == null) continue;
                //如果找到,则返回此节点
                if (findPatient.ID == patientInfo.ID) return node;
            }

            //如果没有找到,则返回null
            return null;
        }


        /// <summary>
        /// 添加根节点
        /// </summary>
        private void AddRootNode()
        {
            this.Nodes.Add(new System.Windows.Forms.TreeNode("患者"));
        }


        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.ImageList = this.imageList1;
            this.HideSelection = false;

            try
            {
                if (this.IsShowContextMenu == true)//显示属性
                {
                    // 加入右键菜单  by zlw 2006-5-1
                    System.Windows.Forms.ContextMenu cmPatientPro = new System.Windows.Forms.ContextMenu();
                    System.Windows.Forms.MenuItem miPatientPro = new System.Windows.Forms.MenuItem();

                    cmPatientPro.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { miPatientPro });

                    miPatientPro.Text = "查看患者信息";
                    this.ContextMenu = cmPatientPro;

                    miPatientPro.Click += new System.EventHandler(this.miPatientPro_Click);
                }

                Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

                this.dtToday = dataManager.GetDateTimeFromSysDateTime();
            }
            catch
            {
                this.dtToday = DateTime.Today;
            }
        }
        #endregion

        #region 事件
        private void miPatientPro_Click(object sender, System.EventArgs e)
        {
            Neusoft.HISFC.Models.Registration.Register findPatient = null;
            System.Windows.Forms.TreeNode node = this.SelectedNode;
            findPatient = node.Tag as Neusoft.HISFC.Models.Registration.Register;
            if (findPatient == null)
            {
                return;
            }
            else
            {
                ucEmergencyPatientProperty ucPatientpro = new ucEmergencyPatientProperty();
                ucPatientpro.Patient = findPatient;
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucPatientpro);
            }
        }

        private void tvEmergencyObservePatientList_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (this.CheckBoxes && this.bControlChecked == false)
            {
                foreach (System.Windows.Forms.TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }
        System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
        private void tvEmergencyObservePatientList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.bIsShowPatientNo)
            {
                System.Windows.Forms.TreeNode node = null;
                Neusoft.HISFC.Models.Registration.Register info = null;
                System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);
                node = this.GetNodeAt(p);
                if (node == null) return;
                info = node.Tag as Neusoft.HISFC.Models.Registration.Register;
                if (info == null) return;
                if (this.toolTip1.GetToolTip(this) != info.PID.ID)
                    this.toolTip1.SetToolTip(this, info.PID.ID);
            }
        }

        private void tvEmergencyObservePatientList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (this.bIsShowContextMenu == false && this.ContextMenu != null)
                {
                    this.ContextMenu = null;
                    return;
                }

                System.Windows.Forms.TreeNode node = this.GetNodeAt(e.X, e.Y);
                this.SelectedNode = node;
            }

        }
        #endregion


    }
}

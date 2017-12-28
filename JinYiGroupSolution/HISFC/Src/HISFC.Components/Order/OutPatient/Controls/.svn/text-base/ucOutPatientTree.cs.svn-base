using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    public partial class ucOutPatientTree : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucOutPatientTree()
        {
            InitializeComponent();
            
        }

        #region 变量

        private const string More = "..";//自己用的
        private bool bAlreadyState = false;//是否已诊状态
        private string pValue = "";//是否启用分诊系统 1 启用 其他 不启用
        private Forms.frmSelectRoom froom = null;//诊室选择窗口
        private ArrayList alFZDept = new ArrayList();//分诊科室

        private Neusoft.HISFC.Models.Base.Employee employee = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        private Neusoft.FrameWork.Models.NeuObject currentRoom = null;//当前诊台
        /// <summary>
        /// 挂号管理业务
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regManagement = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        /// <summary>
        /// 门诊医嘱业务
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManagement = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
        /// <summary>
        /// 分诊业务
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerAssign = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 参数管理业务
        /// {6A929C8E-2A8A-4626-B2DF-1F5EFA45A476}
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        private Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper();

        private Neusoft.HISFC.Models.Registration.Register patInfo = new Neusoft.HISFC.Models.Registration.Register();

        #region 定义传出事件
        public delegate void TreeDoubleClickHandler(object sender, ClickEventArgs e);
        public event TreeDoubleClickHandler TreeDoubleClick;
        #endregion

        #region {6A929C8E-2A8A-4626-B2DF-1F5EFA45A476}

        /// <summary>
        /// 历史信息查看方式
        /// </summary>
        private int iSeeHistoryMode = 0;

        #endregion

        #endregion

        #region 初始化

        private void ucOutPatientTree_Load(object sender, EventArgs e)
        {
            //{B17077E6-7E65-45fb-BA25-F2883EB6BA27}  保证诊台、诊室不维护时窗口可以关闭
            //if (!this.DesignMode)
            //{
            //    this.InitControl();
            //}
        }

        public void InitControl()
        {
            this.neuTreeView1.AfterSelect += new TreeViewEventHandler(neuTreeView1_AfterSelect);
            this.neuTreeView1.DoubleClick += new EventHandler(neuTreeView1_DoubleClick);
            this.neuTreeView2.AfterSelect += new TreeViewEventHandler(neuTreeView1_AfterSelect);
            this.neuTreeView2.DoubleClick += new EventHandler(neuTreeView1_DoubleClick);
            this.neuTreeView1.MouseUp += new MouseEventHandler(neuTreeView1_MouseUp);
            this.neuTreeView2.MouseUp += new MouseEventHandler(neuTreeView1_MouseUp);
            this.neuTreeView2.Visible = false;

            this.ucQuerySeeNoByCardNo1.myEvents += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(ucQuerySeeNoByCardNo1_myEvents);
            //获取分诊科室
            this.alFZDept = this.managerAssign.QueryFZDept();
            this.helper.ArrayObject = alFZDept;
            //获取控制参数
            #region {6A929C8E-2A8A-4626-B2DF-1F5EFA45A476}
            this.pValue = controlManager.GetControlParam<string>("200018");
            this.iSeeHistoryMode = controlManager.GetControlParam<int>("200301", false, 0);
            this.ucQuerySeeNoByCardNo1.IsICCard = controlManager.GetControlParam<bool>("MZ0203");//{18DEBFA3-0364-4730-8416-ECA87F3235FF}
            #endregion
            this.SelectRoom();
        }

        #endregion

        
        protected void DoTreeDoubleClick()
        {
            if (this.TreeDoubleClick != null)
            {
                this.TreeDoubleClick(this, new ClickEventArgs(patInfo));
            }
        }

        private void ucQuerySeeNoByCardNo1_myEvents()
        {

            Neusoft.HISFC.Models.Registration.Register reg = new Neusoft.HISFC.Models.Registration.Register();

            if (this.ucQuerySeeNoByCardNo1.Register == null)
            {
                MessageBox.Show("不能查询到患者在有效时间内的有效信息！");
                return;
            }
            //重新获得患者的基本信息
            reg = this.regManagement.GetByClinic(this.ucQuerySeeNoByCardNo1.Register.ID);
            reg.DoctorInfo.SeeNO = this.ucQuerySeeNoByCardNo1.Register.DoctorInfo.SeeNO;
            
            if (this.linkLabel1.Text == "待诊")
            {
                PatientStateConvert();
                
            }

            foreach (TreeNode node in this.neuTreeView1.Nodes[0].Nodes)
            {
                if (node.Tag != null)
                {
                    Neusoft.HISFC.Models.Registration.Register regtmp = node.Tag as Neusoft.HISFC.Models.Registration.Register;
                    if (reg.ID == regtmp.ID)
                    {
                        //MessageBox.Show("该患者已经在列表中！");
                        #region {6E95A004-5A76-4fb7-9217-81DE7897F079} 门诊医生站读卡操作--选中患者 by guanyx
                        this.neuTreeView1.SelectedNode = node;
                        //this.neuTreeView1_DoubleClick(reg, null);
                        #endregion
                        return;
                    }
                }
            }

            AddPatientToTree(reg);    

        }

        #region 方法

        /// <summary>
        /// 添加患者信息
        /// </summary>
        /// <param name="obj"></param>
        private void AddPatientToTree(Neusoft.HISFC.Models.Registration.Register obj)
        {
            #region donggq--原来的加载当前医生患者的判断是不对的，这个是新改的---{ED85797A-9B62-40a7-8BB9-1C74929B85A8}

            if (obj == null) 
            {
                return;
            }

            if (obj.DoctorInfo.Templet.Doct.ID != Neusoft.FrameWork.Management.Connection.Operator.ID) 
            {
                return;
            }

            #endregion

            TreeNode patientNode = new TreeNode();

            int image = 0;
            if (obj.Sex.ID.ToString() == "F")//女
            {
                if (obj.IsBaby)
                {
                    image = 10;
                }
                else
                {
                    image = 6;
                }
            }
            else //男
            {
                if (obj.IsBaby)
                {
                    image = 8;
                }
                else
                {
                    image = 4;
                }
            }
            patientNode.ImageIndex = image;
            patientNode.SelectedImageIndex = image + 1;

            string before = "";
            bool isExpert = false;
            Neusoft.HISFC.Models.Registration.RegLevel reglv = null;
            reglv = this.regManagement.QueryRegLevelByCode(obj.DoctorInfo.Templet.RegLevel.ID);
            isExpert = reglv.IsExpert;
            if (obj.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)
            {
                before = "预约";
            }
            if (obj.DoctorInfo.Templet.Doct.ID != "" && isExpert)
            {
                patientNode.Text = "*专*" + obj.Name + "【" + before + obj.DoctorInfo.SeeNO + "】" + More;
            }
            else
            {
                patientNode.Text = obj.Name + "【" + before + obj.DoctorInfo.SeeNO + "】" + More;
            }
            obj.DoctorInfo.SeeNO = -1;
            patientNode.Tag = obj;

            this.neuTreeView1.Nodes[0].Nodes.Add(patientNode);

            #region {6E95A004-5A76-4fb7-9217-81DE7897F079} 门诊医生站读卡操作--选中患者 by guanyx
            this.neuTreeView1.SelectedNode = patientNode;
            #endregion

            this.neuTreeView1.ExpandAll();
        }

        /// <summary>
        /// 患者基本信息
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            get
            {
                return this.patInfo;
            }
            set
            {
                this.patInfo = value;
            }
        }

        /// <summary>
        /// 当前诊台
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CurrRoom
        {
            get
            {
                return this.currentRoom;
            }
            set
            {
                this.currentRoom = value;
            }
        }

        /// <summary>
        /// 选择诊室
        /// </summary>
        private void SelectRoom()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager managerRoom = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            try
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                ArrayList alNurse = deptManager.QueryNurseStationByDept(this.employee.Dept);
                if (alNurse == null || alNurse.Count <= 0)
                {
                    return;
                }
                ArrayList al = managerRoom.QueryRoomByDeptID((alNurse[0] as Neusoft.FrameWork.Models.NeuObject).ID);
                
                Neusoft.FrameWork.Models.NeuObject obj = this.helper.GetObjectFromID(this.employee.Dept.ID);
                if (pValue == "1" && obj != null)//不分诊科室
                {

                }
                else
                {
                    al = new ArrayList();
                }
                if (al == null || al.Count == 0) return;
                if (froom == null) froom = new Forms.frmSelectRoom(al);
                froom.pValue = this.pValue;
                froom.alFZDepts = this.alFZDept;
                froom.OKEvent += new Neusoft.FrameWork.WinForms.Forms.OKHandler(froom_OKEvent);
                DialogResult r = froom.ShowDialog();
                if (r == DialogResult.OK)
                {
                    
                }
                else
                {
                    
                    MessageBox.Show("请选择坐诊诊室！");
                }

            }
            catch
            {
                MessageBox.Show("获得科室所属护理站出错", "提示");
            }
        }
        /// <summary>
        /// 诊室窗口选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void froom_OKEvent(object sender, Neusoft.FrameWork.Models.NeuObject e)
        {
            try
            {
                currentRoom = e;
            }
            catch { }
        }

        #region 患者列表

        /// <summary>
        /// 刷新待诊患者列表
        /// 
        /// {B17077E6-7E65-45fb-BA25-F2883EB6BA27}  保证诊台、诊室不维护时窗口可以关闭 
        /// 修改返回值类型为Init
        /// </summary>
        public int RefreshTreeView()
        {
            string sTemp = "";

            try
            {
                sTemp = this.employee.Dept.Name;
            }
            catch { }
            if (sTemp == "") sTemp = "待诊患者";
            else sTemp = "待诊患者【" + sTemp + "】";

            TreeNode nodeRoot = new TreeNode(sTemp);//待诊患者根
            nodeRoot.ImageIndex = 3;
            nodeRoot.SelectedImageIndex = 2;

            TreeNode nodeRoot1 = new TreeNode("已诊患者");//已诊患者根
            nodeRoot1.ImageIndex = 3;
            nodeRoot1.SelectedImageIndex = 2;

            ArrayList al = null;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在刷新待诊患者信息..");
            Application.DoEvents();

            //查询所有当天，本科室 的待诊及已诊患者信息
            DateTime dt = this.orderManagement.GetDateTimeFromSysDateTime();
            
            if (pValue == "1" && this.helper.GetObjectFromID(this.employee.Dept.ID) != null)
            {
                if (this.currentRoom != null)
                {
                    al = managerAssign.QueryPatient(dt.Date, dt.AddDays(1), this.currentRoom.ID, "1", this.employee.ID);
                }
                else
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("获得诊室和诊台出错,请维护诊室和诊台！", "提示");
                    return -1;
                }
            }
            else
            {
                if (this.currentRoom == null)
                    al = regManagement.QueryByDept(this.employee.Dept.ID, dt.Date, dt.AddDays(1), false);
                else
                {

                    al = managerAssign.QueryPatient(this.employee.Dept.ID, this.currentRoom.ID);
                }
            }
            //查询以前患者的就诊信息
            if (al == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("获得患者列表出错！" + regManagement.Err);
                return -1;
            }
            foreach (object obj in al)
            {
                if (obj.GetType() == typeof(Neusoft.HISFC.Models.Nurse.Assign))
                {
                    AddPatientToRoot(nodeRoot, ((Neusoft.HISFC.Models.Nurse.Assign)obj).Register);
                }
                else
                {
                    AddPatientToRoot(nodeRoot, (Neusoft.HISFC.Models.Registration.Register)obj);
                }
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            this.neuTreeView1.Nodes.Clear();
            this.neuTreeView1.Nodes.Add(nodeRoot);
            //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
            GetEnEmergencyPatient(neuTreeView1);
            this.neuTreeView1.ExpandAll();

            return 1;
        }

        /// <summary>
        /// 刷新已诊患者列表
        /// </summary>
        public void RefreshTreePatientDone()
        {
            string sTemp = "";

            try
            {
                sTemp = this.employee.Dept.Name;
            }
            catch { }
            if (sTemp == "") sTemp = "已诊患者";
            else sTemp = "已诊患者【" + sTemp + "】";

            TreeNode nodeRoot = new TreeNode(sTemp);//已诊患者根
            nodeRoot.ImageIndex = 3;
            nodeRoot.SelectedImageIndex = 2;


            ArrayList al = null;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在更新已诊患者信息..");
            Application.DoEvents();

            //查询所有当天，已诊患者信息
            DateTime dt = this.orderManagement.GetDateTimeFromSysDateTime();

            al = regManagement.QueryBySeeDocAndSeeDate(this.employee.ID, dt.Date, dt.AddDays(1), true);
            //查询以前患者的就诊信息
            if (al == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(regManagement.Err);
                return;
            }
            
            foreach (Neusoft.HISFC.Models.Registration.Register obj in al)
            {
                if (obj.IsSee)//已经看诊
                {
                    AddPatientToRoot(nodeRoot, obj);
                }
                else//待看诊
                {
                    
                }
            }
            
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            this.neuTreeView2.Nodes.Clear();
            this.neuTreeView2.Nodes.Add(nodeRoot);
            //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
            GetEnEmergencyPatient(neuTreeView2);
            this.neuTreeView2.ExpandAll();
        }

        /// <summary>
        /// 刷新已诊患者列表
        /// </summary>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        private void RefreshTreePatientDone(DateTime dtBegin, DateTime dtEnd)
        {
            string sTemp = "";

            try
            {
                sTemp = this.employee.Dept.Name;
            }
            catch { }
            if (sTemp == "") sTemp = "已诊患者";
            else sTemp = "已诊患者【" + sTemp + "】";

            TreeNode nodeRoot = new TreeNode(sTemp);//已诊患者根
            nodeRoot.ImageIndex = 3;
            nodeRoot.SelectedImageIndex = 2;


            ArrayList al = null;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在更新已诊患者信息..");
            Application.DoEvents();

            //查询所有当天，本科室 的已诊及已诊患者信息
            DateTime dt = this.orderManagement.GetDateTimeFromSysDateTime();
            
            //al = management.QueryBySeeDoc(this.var.User.ID, dtBegin, dtEnd, true);
            //查询以前患者的就诊信息
            if (al == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(regManagement.Err);
                return;
            }
            
            foreach (Neusoft.HISFC.Models.Registration.Register obj in al)
            {
                if (obj.IsSee)//已经看诊
                {
                    AddPatientToRoot(nodeRoot, obj);
                }
                else//待看诊
                {
                    
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            this.neuTreeView2.Nodes.Clear();
            this.neuTreeView2.Nodes.Add(nodeRoot);
            this.neuTreeView2.ExpandAll();
        }

        /// <summary>
        /// 添加患者信息 
        /// </summary>
        /// <param name="rootNode"></param>
        private void AddPatientToRoot(TreeNode rootNode, Neusoft.HISFC.Models.Registration.Register obj)
        {
            #region donggq--原来的加载当前医生患者的判断是不对的，这个是新改的---{ED85797A-9B62-40a7-8BB9-1C74929B85A8}
            if (obj == null)
            {
                return;
            }

            if (obj.DoctorInfo.Templet.Doct.ID != this.employee.ID)
            {
                return;
            } 
            #endregion


            ///原来是显示所有挂到科室的患者,现在改为挂到该科室所有普通患者和挂到该医生的专家号,对于挂到其他
            ///医生的专家号不显示
            ///

            if (obj.DoctorInfo.Templet.Doct.ID != null && obj.DoctorInfo.Templet.Doct.ID != ""/*不是普通号*/
                && (obj.DoctorInfo.Templet.Doct.Name.IndexOf("教授") < 0 && obj.DoctorInfo.Templet.Doct.ID != this.employee.ID)
                && !obj.IsSee)//挂号医生不是当前医生,返回
                return;

            TreeNode patientNode = new TreeNode();
            
            int image = 0;
            if (obj.Sex.ID.ToString() == "F")//女
            {
                if (obj.IsBaby)
                {
                    image = 10;
                }
                else
                {
                    image = 6;
                }
            }
            else //男
            {
                if (obj.IsBaby)
                {
                    image = 8;
                }
                else
                {
                    image = 4;
                }
            }
            patientNode.ImageIndex = image;
            patientNode.SelectedImageIndex = image + 1;

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            string accountType = "";
            string feeType = "";
            if (obj.IsAccount)
            {
                accountType = "账户挂号";
            }
            if (obj.IsFee == false)
            {
                feeType = "未收费";
            }

            string before = "";

            if (obj.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)
            {
                before = "预约";
            }
            if (obj.DoctorInfo.Templet.Doct.ID != "" && obj.DoctorInfo.Templet.RegLevel.IsExpert)
            {

                patientNode.Text = accountType + feeType + "*专*" + obj.Name + "【" + before + obj.DoctorInfo.SeeNO + "】" + More;
            }
            else
            {
                patientNode.Text = accountType + feeType + obj.Name + "【" + before + obj.DoctorInfo.SeeNO + "】" + More;
            }
            obj.DoctorInfo.SeeNO = -1;
            patientNode.Tag = obj;

            rootNode.Nodes.Add(patientNode);

        }

        /// <summary>
        ///  返回以前患者的就诊信息 
        /// </summary>
        /// <param name="patientNode"></param>
        private void getOldSeeInfo(TreeNode patientNode)
        {
            ArrayList al = null;
            string sTemp = "【{0}】【{1}】";
            #region {6A929C8E-2A8A-4626-B2DF-1F5EFA45A476}
            //al = orderManagement.QuerySeeNoListByCardNo(((Neusoft.HISFC.Models.Registration.Register)patientNode.Tag).ID, ((Neusoft.HISFC.Models.Registration.Register)patientNode.Tag).PID.CardNO);
            DateTime dtNow = this.orderManagement.GetDateTimeFromSysDateTime();
            if (this.iSeeHistoryMode == 0)
            {
                al = orderManagement.QuerySeeNoListByCardNo(((Neusoft.HISFC.Models.Registration.Register)patientNode.Tag).ID, ((Neusoft.HISFC.Models.Registration.Register)patientNode.Tag).PID.CardNO);
            }
            else
            {
                ArrayList alOldTmp = orderManagement.QuerySeeNoListByCardNo(((Neusoft.HISFC.Models.Registration.Register)patientNode.Tag).PID.CardNO);
                al = new ArrayList();
                foreach (Neusoft.FrameWork.Models.NeuObject obj in alOldTmp)
                {
                    if (Neusoft.FrameWork.Function.NConvert.ToDateTime(obj.Memo) > dtNow.Date.AddDays(-this.iSeeHistoryMode))
                    {
                        al.Add(obj);
                    }
                }
            }

            #endregion
            if (al == null)
            {
                MessageBox.Show(orderManagement.Err);
                return;
            }
            if (patientNode.Nodes.Count > 0)
            {
                patientNode.Nodes.Clear();
            }
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                TreeNode node = new TreeNode();

                try
                {
                    node.Text = string.Format(sTemp, obj.Memo.Substring(0, obj.Memo.IndexOf(" ")), obj.User02);
                }
                catch { node.Text = string.Format(sTemp, obj.Memo, obj.User02); }
                node.ImageIndex = 12;
                node.SelectedImageIndex = 13;
                Neusoft.HISFC.Models.Registration.Register r = ((Neusoft.HISFC.Models.Registration.Register)patientNode.Tag).Clone() as Neusoft.HISFC.Models.Registration.Register;
                r.DoctorInfo.SeeNO = int.Parse(obj.ID);
                node.Tag = r;
                patientNode.Nodes.Add(node);
                patientNode.ExpandAll();
            }

        }

        /// <summary>
        /// 选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void neuTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                Neusoft.HISFC.Models.Registration.Register reg = (Neusoft.HISFC.Models.Registration.Register)((TreeView)sender).SelectedNode.Tag;
                if (e.Node.Text.IndexOf(More) > 0)
                {
                    e.Node.Text = e.Node.Text.Replace(More, "");
                    reg.DoctorInfo.SeeNO = -1;
                    this.getOldSeeInfo(e.Node);
                    this.patInfo = reg;
                    DoTreeDoubleClick();
                }
                else
                {
                    #region {CC515E52-1D4E-4be2-9632-6F56639B330E}
                    //屏蔽此段代码，避免重复执行DoTreeDoubleClick（）
                    //if (((TreeView)sender).SelectedNode.Parent.Parent == null && reg != null)
                    //{
                    //    this.patInfo = reg;
                    //    DoTreeDoubleClick();
                    //}
                    #endregion
                    this.patInfo = reg;
                    DoTreeDoubleClick();
                }
            }
            catch { }
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void neuTreeView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
                Neusoft.HISFC.Models.Registration.Register reg = (Neusoft.HISFC.Models.Registration.Register)((TreeView)sender).SelectedNode.Tag;
                if (((TreeView)sender).SelectedNode.Parent.Parent == null && reg != null)
                {
                    reg.DoctorInfo.SeeNO = -1;
                    this.getOldSeeInfo(((TreeView)sender).SelectedNode);
                    patInfo = reg;
                    DoTreeDoubleClick();
                }
                this.patInfo = reg;
                                
            }
            catch { }
        }
        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            PatientStateConvert();
        }

        /// <summary>
        /// 患者状态 待诊/已诊转换
        /// </summary>
        private void PatientStateConvert()
        {
            bAlreadyState = !bAlreadyState;
            this.neuTreeView1.Visible = !bAlreadyState;
            this.neuTreeView2.Visible = bAlreadyState;
            if (bAlreadyState)//已诊
            {
                this.RefreshTreePatientDone();
                this.linkLabel1.Text = "待诊";
            }
            else//待诊
            {
                this.RefreshTreeView();
                this.linkLabel1.Text = "已诊";
            }
            

        }

        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        /// <summary>
        /// 加载留观患者
        /// </summary>
        private void GetEnEmergencyPatient(Neusoft.FrameWork.WinForms.Controls.NeuTreeView tree)
        {
            TreeNode nodeRoot = new TreeNode("留观患者");//留观患者根
            nodeRoot.ImageIndex = 3;
            nodeRoot.SelectedImageIndex = 2;
            nodeRoot.Tag = "Observance";
            ArrayList alPatient = regManagement.PatientQueryByNurseCell(this.employee.Dept.ID);
            if (alPatient == null)
            {
                MessageBox.Show("加载留观患者信息失败！");
                return;
            }
            if (alPatient.Count == 0)
            {
                return;
            }

            foreach (Neusoft.HISFC.Models.Registration.Register r in alPatient)
            {
                AddPatientToRoot(nodeRoot, r);
            }
            tree.Nodes.Add(nodeRoot);
        }

        #endregion

        /// <summary>
        /// 诊出
        /// </summary>
        /// <returns></returns>
        public int DiagOut()
        {
            if (this.patInfo == null || string.IsNullOrEmpty(this.patInfo.ID))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("您没有选择患者！"));
                return -1;
            }
            int iReturn = -1;
            DateTime now = this.orderManagement.GetDateTimeFromSysDateTime();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(orderManagement.Connection);
            //t.BeginTransaction();
            //设置事务
            this.managerAssign.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.regManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 更新分诊
            if (pValue == "1" && this.helper.GetObjectFromID(this.employee.Dept.ID) != null)
            {
                iReturn = this.managerAssign.UpdateAssign(this.currentRoom.ID, this.patInfo.ID, now, this.orderManagement.Operator.ID);
                if (iReturn < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show("更新分诊标志出错！");

                    return -1;
                }
            }
            #endregion

            #region 更新看诊
            iReturn = this.regManagement.UpdateSeeDone(this.patInfo.ID);
            if (iReturn < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show("更新看诊标志出错！");
                
                return -1;
            }
            iReturn = this.regManagement.UpdateDept(this.patInfo.ID, this.employee.Dept.ID, this.employee.ID);
            if (iReturn < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新看诊科室、医生出错！");

                return -1;
            }
            #endregion

            //{44832DAC-80CF-41e6-BD54-6E8DB45E4790} 修正最后没有提交的bug
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            
            return iReturn;

        }

        /// <summary>
        /// 医生叫号进诊
        /// </summary>
        /// <param name="reg"></param>
        public void DiagIn(Neusoft.HISFC.Models.Registration.Register reg)
        {
            Neusoft.HISFC.BizProcess.Interface.IDiagInDisplay o = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.OutPatient.Controls.ucOutPatientTree), typeof(Neusoft.HISFC.BizProcess.Interface.IDiagInDisplay)) as Neusoft.HISFC.BizProcess.Interface.IDiagInDisplay;
            if (o == null)
            {
                MessageBox.Show("接口未实现");
            }
            else
            {
                o.RegInfo = reg;
                o.ObjRoom = currentRoom;

                o.DiagInDisplay();
            }
        }

        #endregion

        #region 事件

        private void neuTreeView1_MouseUp(object sender, MouseEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip contextMenu1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
            contextMenu1.Items.Clear();
            if (e.Button == MouseButtons.Right)
            {
                Neusoft.HISFC.Models.Registration.Register mnuSelectRegister = null;
                if (this.neuTreeView1.Visible == true && this.neuTreeView1.SelectedNode != null)
                {
                    mnuSelectRegister = this.neuTreeView1.SelectedNode.Tag as Neusoft.HISFC.Models.Registration.Register;
                }
                if (this.neuTreeView2.Visible == true && this.neuTreeView2.SelectedNode != null)
                {
                    mnuSelectRegister = this.neuTreeView2.SelectedNode.Tag as Neusoft.HISFC.Models.Registration.Register;
                }
                if (mnuSelectRegister != null)
                {
                    ToolStripMenuItem mnuPatientInfo = new ToolStripMenuItem();//院注次数
                    mnuPatientInfo.Click += new EventHandler(mnuPatientInfo_Click);

                    mnuPatientInfo.Text = "查看患者信息";
                    contextMenu1.Items.Add(mnuPatientInfo);
                }
                if (this.neuTreeView1.Visible == true)
                {
                    contextMenu1.Show(this.neuTreeView1, e.X, e.Y);
                }
                if (this.neuTreeView2.Visible == true)
                {
                    contextMenu1.Show(this.neuTreeView2, e.X, e.Y);
                }
            }
            
        }

        private void mnuPatientInfo_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Models.Registration.Register mnuSelectRegister = null;
            if (this.neuTreeView1.Visible == true && this.neuTreeView1.SelectedNode != null)
            {
                mnuSelectRegister = this.neuTreeView1.SelectedNode.Tag as Neusoft.HISFC.Models.Registration.Register;
            }
            if (this.neuTreeView2.Visible == true && this.neuTreeView2.SelectedNode != null)
            {
                mnuSelectRegister = this.neuTreeView2.SelectedNode.Tag as Neusoft.HISFC.Models.Registration.Register;
            }

            if (mnuSelectRegister == null)
            {
                return;
            }
            else
            {
                Neusoft.HISFC.Components.Common.Controls.ucPatientPropertyForClinic ucPatientpro = new Neusoft.HISFC.Components.Common.Controls.ucPatientPropertyForClinic();
                ucPatientpro.PatientInfo = mnuSelectRegister;
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "患者基本信息";
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucPatientpro);
            }
        }

        #endregion


        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get 
            {
                Type[] t = new Type[1];
                t[0] = typeof(Neusoft.HISFC.BizProcess.Interface.IDiagInDisplay);

                return t;
            }
        }

        #endregion
    }

    /// <summary>
    /// 事件传出参数
    /// </summary>
    public class ClickEventArgs : EventArgs
    {
        private Neusoft.HISFC.Models.Registration.Register reg;
        public Neusoft.HISFC.Models.Registration.Register Message
        {
            get
            {
                return reg;
            }
            set
            {
                reg=value;
            }
        }
        public ClickEventArgs(Neusoft.HISFC.Models.Registration.Register obj)
        {
            Message=obj;
        }
    
    }

}


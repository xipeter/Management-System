using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class ucSetFeeAlert : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 局部变量
        /// <summary>
        /// 科室管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 入出转业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        /// <summary>
        /// 患者信息实体
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        ////{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 设置类型枚举服务类
        /// </summary>
        Neusoft.HISFC.Models.Base.EnumAlertTypeService alerTypeService = new Neusoft.HISFC.Models.Base.EnumAlertTypeService();
        /// <summary>
        /// 中间量实体
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject Object = new Neusoft.FrameWork.Models.NeuObject();

        private Neusoft.FrameWork.Models.NeuObject nurseOjbect = null;

        //判断是否选择了listview中的项

        private bool islistView = false;
        
        /// <summary>
        /// 节点
        /// </summary>
        private TreeNode tNode = null;

        private ListViewItem lListView = null;
        /// <summary>
        /// 默认选责全院（//选择的：0全院：1:病区2：科室3：个人）
        /// </summary>
        private int level = 0;
        /// <summary>
        /// 是否显示全部护理站

        /// </summary>
        private bool isAllNurse = true;

        #endregion
        //是否允许设置金额警戒线
        private bool isallowset = false;
        #region 属性

        [Category("设置"),Description("设置显示全院或本护理站")]
        public bool IsAllNurse
        {
            set
            {
                this.isAllNurse = value;
            }
            get
            {

                return this.isAllNurse;
            }
        }
        [Category("控件设置"), Description("是否允许按照金额设置警戒线"), DefaultValue(false)]
        public bool AllowSet
        {
            get { return this.isallowset; }
            set { isallowset = value; }
        }
        #endregion

        #region 枚举
        private enum enuFP
        {
            //住院号

            PatientNO = 0,
            //姓名
            Name,
            //住院科室
            DeptCode,
            //住院护理站

            NurseCellCode,
            //花费总额
            TotCost,
            //余额
            FreeCost,
            //警戒线

            Money_Alert

        }
        #endregion

        #region 方法
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        public ucSetFeeAlert()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int init()
        {
            this.FindForm().Text = "警戒线设置";
            this.initTreeView();
            return 1;
        }
        /// <summary>
        /// 添加护士站列表
        ///跟据属性判断是全院还是本科室
        /// </summary>
        /// <returns></returns>
        private int initTreeView()
        {
            Neusoft.FrameWork.Models.NeuObject myobject = new Neusoft.FrameWork.Models.NeuObject();
            this.neuTreeView1.ImageList = this.neuTreeView1.deptImageList;
            TreeNode root = new TreeNode("全院");
            root.ImageIndex = 0;
            root.SelectedImageIndex = 1;
            myobject.ID = "all";
            myobject.Name = "全院";
              
            root.Tag = myobject;
            ArrayList alNures = new ArrayList();
            ArrayList alDept = new ArrayList();
            TreeNode  node = new TreeNode();
            this.neuTreeView1.Nodes.Add(root);

            if (this.IsAllNurse == true)
            {
                alNures = new ArrayList();
                alNures = this.managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
                if (alNures == null || alNures.Count == 0)
                {
                    return -1;
                }
                //添加病区信息
                foreach (Neusoft.FrameWork.Models.NeuObject neuObject in alNures)
                {
                    node = new TreeNode();
                    node.Text = neuObject.Name;
                    node.Tag = neuObject;
                    node.SelectedImageIndex = 2;
                    node.ImageIndex = 3;
                    root.Nodes.Add(node);
                }
            }
            else //显示本护理站
            {
                alNures = new ArrayList();
                Neusoft.FrameWork.Models.NeuObject objectTemp = new Neusoft.FrameWork.Models.NeuObject ();
                objectTemp = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept;
             
                if (objectTemp == null)
                {
                    return -1;
                }
                node = new TreeNode();
                node.Text = objectTemp.Name;
                node.Tag = objectTemp;
                node.SelectedImageIndex = 2;
                node.ImageIndex = 3;
                root.Nodes.Add(node);
            }
           
            
            //全部展开
            root.Expand();
            return 1;
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// farpoint显示患者信息
        /// </summary>
        /// <param name="alPatientinfo"></param>
        /// <returns></returns>
        private int setFarPoint(ArrayList alPatientinfo)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { 
                 new DataColumn("住院号", typeof(string)), 
                 new DataColumn("姓名", typeof(string)) ,
                 new DataColumn("住院科室", typeof(string)),
                 new DataColumn("住院护理站", typeof(string)),
                 new DataColumn("预交金",typeof(string)),
                 new DataColumn("花费总额", typeof(string)),
                 new DataColumn("余额", typeof(string)),
                 new DataColumn("警戒线类别",typeof(string)),
                 new DataColumn("警戒线", typeof(string)),
                 new DataColumn("开始时间",typeof(string)),
                 new DataColumn("结束时间",typeof(string))   
                 });
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patientInfo in alPatientinfo)
            {
                DataRow dr = dt.NewRow();
                dr[0] = patientInfo.PID.PatientNO;
                dr[1] = patientInfo.Name;
                dr[2] = patientInfo.PVisit.PatientLocation.Dept.Name;
                dr[3] = patientInfo.PVisit.PatientLocation.NurseCell.Name;
                dr[4] = patientInfo.FT.PrepayCost;
                dr[5] = patientInfo.FT.TotCost.ToString();
                dr[6] = patientInfo.FT.LeftCost.ToString();
                dr[7] = patientInfo.PVisit.AlertType.Name;
                if (patientInfo.PVisit.AlertType.ID.ToString() == "M")
                {
                    dr[8] = patientInfo.PVisit.MoneyAlert.ToString();
                }
                else
                {
                    dr[9] = patientInfo.PVisit.BeginDate.ToString("yyyy-MM-dd");
                    dr[10] = patientInfo.PVisit.EndDate.ToString("yyyy-MM-dd");
                }
                dt.Rows.Add(dr); 
            }
            DataView dv = new DataView(dt);
         
            this.neuSpread1_Sheet1.DataSource = dv;
            this.neuSpread1_Sheet1.Columns[0].Width = 70;
            this.neuSpread1_Sheet1.Columns[1].Width = 70;
            this.neuSpread1_Sheet1.Columns[2].Width = 80;
            this.neuSpread1_Sheet1.Columns[3].Width = 80;
            this.neuSpread1_Sheet1.Columns[4].Width = 60;
            this.neuSpread1_Sheet1.Columns[4].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment .Right;
            this.neuSpread1_Sheet1.Columns[5].Width = 60;
            this.neuSpread1_Sheet1.Columns[5].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.Columns[6].Width = 60;
            this.neuSpread1_Sheet1.Columns[6].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.Columns[7].Width = 80;
            this.neuSpread1_Sheet1.Columns[7].HorizontalAlignment= FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.neuSpread1_Sheet1.Columns[8].Width = 60;
            this.neuSpread1_Sheet1.Columns[9].Width = 80;
            this.neuSpread1_Sheet1.Columns[10].Width = 80;
 
            return 1;
        }

        /// <summary>
        /// 设置警戒线
        /// </summary>
        /// <returns></returns>
        private int setAlert()
        {
            frmSetFeeAlert frmSFA = new frmSetFeeAlert();
            frmSFA.Level = this.level;
            //if (this.patientInfo == null)
            //{
            //    return -1;
            //}
            frmSFA.PatientInfo = this.patientInfo;
            frmSFA.MyObject = this.Object;
            frmSFA.IsAll = this.IsAllNurse;
            frmSFA.AllowSet = this.AllowSet;
            frmSFA.NurseCellObject = this.nurseOjbect;
            if ((this.IsAllNurse == false && this.level == 0) || /*(this.IsAllNurse == false && this.level == 1) || */(this.IsAllNurse == false && this.level == 2) || ((this.IsAllNurse == false && this.level == 4)))
            {
                return -1;
            }
            else
            {
                DialogResult result = frmSFA.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //刷新患者

                    if (this.islistView == false)
                    {
                        this.SetPatient(this.tNode);
                    }
                    else
                    {
                        this.SetPatient(this.tNode);
                        this.SetPatient(this.lListView);
                        for (int i = 0; i < this.lvPatient.Items.Count; i++)
                        {
                             ListViewItem lvItem = this.lvPatient.Items[i];
                             if ((lListView.Tag as Neusoft.HISFC.Models.RADT.PatientInfo).ID == (lvItem.Tag as Neusoft.HISFC.Models.RADT.PatientInfo).ID)
                             {
                                 lvItem.Selected = true;
                             }
                        }
                    }
                }
            }
           
            return 1;
        }
        /// <summary>
        /// 根据节刷新患者

        /// </summary>
        /// <param name="Node"></param>
        private void SetPatient(TreeNode Node)
        {
            //清空患者基本信息

            if (this.patientInfo != null)
            {
                this.patientInfo = null;
            }
            if (this.Object != null)
            {
                this.Object = null;
            }
            if (this.nurseOjbect != null)
            {
                this.nurseOjbect = null;
            }
            //清空lvPatient
            if (this.lvPatient.Items.Count > 0)
            {
                this.lvPatient.Clear();
            }

            this.level = Node.Level;

            islistView = false;//选择treeview
            //传入病区
            this.Object = this.neuTreeView1.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
            //清空neuSpread1_Sheet1
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                this.neuSpread1_Sheet1.RemoveRows(0, this.neuSpread1_Sheet1.RowCount);
            }
            DateTime beginDateTime = Neusoft.FrameWork.Function.NConvert.ToDateTime("1900-01-01 00:00:00");
            DateTime EndDateTime = Neusoft.FrameWork.Function.NConvert.ToDateTime("4000-01-01 00:00:00");
            ArrayList alPatientInfo = new ArrayList();
            ArrayList alPatientInfoReg = new ArrayList();//刚登记入院未接诊的患者

            #region //全院设置
            if (this.IsAllNurse == true) 
            {
                if (Node.Level == 0)
                {
                    //查找所有在院患者（按照住院状态）
                    alPatientInfo = this.radtIntegrate.QueryPatient(Neusoft.HISFC.Models.Base.EnumInState.I);
                    alPatientInfoReg = this.radtIntegrate.QueryPatient(Neusoft.HISFC.Models.Base.EnumInState.R);
                    
                    if (alPatientInfoReg.Count > 0)
                    {
                        alPatientInfo.AddRange(alPatientInfoReg);
                    }

                }
                else if (Node.Level == 1)
                {

                    //查找病区所有患者

                    alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndState((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                    this.nurseOjbect = Node.Tag as Neusoft.FrameWork.Models.NeuObject;
                }
                else
                {
                    //查找科室所有患者

                    alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndDept((Node.Parent.Tag as Neusoft.FrameWork.Models.NeuObject).ID, (Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                    alPatientInfoReg = this.radtIntegrate.QueryPatient((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.R);
                    if (alPatientInfoReg.Count > 0)
                    {
                        alPatientInfo.AddRange(alPatientInfoReg);
                    }
                    this.nurseOjbect = Node.Parent.Tag as Neusoft.FrameWork.Models.NeuObject;
                }
                

            }
            #endregion

            #region 按登陆科室设置

            else
            {
                if (Node.Level == 0)
                {
                    return;

                }
                else if (Node.Level == 1)
                {
                    //F0BF027A-9C8A-4bb7-AA23-26A5F3539586
                    //if (Node.Nodes.Count > 0)
                    //{
                    //    alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndDept((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, (Node.Nodes[0].Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);

                    //}
                    alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndState((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                    this.nurseOjbect = Node.Tag as Neusoft.FrameWork.Models.NeuObject;
                   
                }
                else
                {
                    //查找科室所有患者


                    alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndDept((Node.Parent.Tag as Neusoft.FrameWork.Models.NeuObject).ID, (Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                    alPatientInfoReg = this.radtIntegrate.QueryPatient((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.R);
                    if (alPatientInfoReg.Count > 0)
                    {
                        alPatientInfo.AddRange(alPatientInfoReg);
                    }
                }

            }
            #endregion
            if (alPatientInfo == null || alPatientInfo.Count == 0)
            {
                MessageBox.Show("没有患者信息");
                return;
            }
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patientInfo in alPatientInfo)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = patientInfo.Name;
                lvItem.ImageIndex = 5;
                lvItem.Tag = patientInfo;
                //if (patientInfo.PID.CardNO == Tag.ToString())
                //{
                //    lvItem.Selected = true;
                //}
                this.lvPatient.Items.Add(lvItem);
            }
            this.setFarPoint(alPatientInfo);
            //设置范围
           
        }
        /// <summary>
        /// 根据lisView节刷新患者
        /// </summary>
        /// <param name="lvItem"></param>
        private void SetPatient(ListViewItem lvItem)
        {
            this.patientInfo = lvItem.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
            ArrayList alpatient = new ArrayList();
            alpatient.Add(this.patientInfo);
            this.setFarPoint(alpatient);
            this.level = 3;
        }
        
        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolbarService.AddToolButton("警戒线", "按所选设置", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            this.toolbarService.AddToolButton("合同单位", "按合同单位设置", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            return toolbarService;
        }

       
        #endregion

        #region 事件 
        
        
        private void lvPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            islistView = true;
            ListViewItem lvItem = new ListViewItem();
            if (this.lvPatient.SelectedItems.Count <= 0)
            {
                return;
            }

            this.level = 3;
            lvItem = this.lvPatient.SelectedItems[0];
            //Neusoft.HISFC.Models.RADT.PatientInfo pInfo = this.radtIntegrate.QueryPatientInfoByInpatientNO(((Neusoft.FrameWork.Models.NeuObject)lvItem.Tag).ID);
            //lvItem.Tag = pInfo;
            this.lListView = lvItem;
            this.SetPatient(lvItem);


        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "警戒线":
                    {
                        if (this.neuTreeView1.SelectedNode != null)
                        {
                            if (lvPatient.SelectedItems.Count>0)
                            {
                                this.level = 3;
                            }
                            else
                            {
                                //this.level = this.neuTreeView1.SelectedNode.Level;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("请选择需要设置的节点");
                            return;
                        }
                        this.setAlert();
                        break;
                    }
                case "合同单位":
                    {
                        this.level = 4; //表示合同单位
                        this.setAlert();
                        break;
                    }
                default:
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        private void ucSetFeeAlert_Load(object sender, EventArgs e)
        {
            this.init();
        }
        public override int Query(object sender, object neuObject)
        {
            #region  {DB3B44F0-B049-4644-B599-82456C9CFC31}  按住院号查找患者
            //Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch frm = new Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch();
            //frm.Init(neuTreeView1);
            //frm.Show();
            ucInput uc = new ucInput();

            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "患者查找";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            string patientno = uc.PatientNo.Trim();
            Boolean findFlag = false;
         
            foreach (ListViewItem lvPerson in this.lvPatient.Items)
            {
                Neusoft.HISFC.Models.RADT.PatientInfo personInfo = lvPerson.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
               
                if(patientno==personInfo.ID.Substring(4))
                {
                    lvPatient.Focus();
                    lvPatient.Items[lvPerson.Index].Focused = true ;
                    lvPatient.Select();
                    lvPatient.Items[lvPerson.Index].Selected = true;
                 
                    this.lListView = lvPerson;
                    this.SetPatient(lvPerson);
                    findFlag = true;
                    this.level = 3;
                    break;
                }           
            }

            if (!findFlag)
            {
                MessageBox.Show("住院号为"+patientno+"患者未找到！");
                return 0;
            }
            #endregion
            return base.Query(sender, neuObject);
        }
        private void neuTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //设置患者基本信息
            //病人比较多的情况下，速度不可忍受
            if (e.Node.Level == 0) {
                return;
            }
            this.SetPatient(e.Node);
            this.tNode = e.Node;
        } 
        #endregion

       
    }
}

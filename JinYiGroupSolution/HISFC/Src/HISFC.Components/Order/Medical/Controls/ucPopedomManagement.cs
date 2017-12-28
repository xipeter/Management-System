using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Order.Medical.Controls
{
    public partial class ucPopedomManagement : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPopedomManagement()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 资质业务类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.Medical.Ability aby = new Neusoft.HISFC.BizLogic.Order.Medical.Ability();

        private List<Neusoft.HISFC.Models.Order.Medical.Popedom> popAdd = new List<Neusoft.HISFC.Models.Order.Medical.Popedom>();

        /// <summary>
        /// 帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper ehSpeciality = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper ehLevel = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper ehOperate = new Neusoft.FrameWork.Public.ObjectHelper();
        //private Neusoft.FrameWork.Public.ObjectHelper ehDrugLevel = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper ehDrugType = new Neusoft.FrameWork.Public.ObjectHelper();

        //增加组套权限维护
        //{C0C116F2-E66F-41e7-AA16-8C410196C606}
        private Neusoft.FrameWork.Public.ObjectHelper ehGroupType = new Neusoft.FrameWork.Public.ObjectHelper();
        /// <summary>
        /// 工具条
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 于洋加入的变量


        /// <summary>
        /// Fp数据源DataSet
        /// </summary>
        private DataTable dtCheck = null;

        private Neusoft.HISFC.BizProcess.Integrate.Order termOrder = new Neusoft.HISFC.BizProcess.Integrate.Order();

        private Neusoft.FrameWork.Public.ObjectHelper ehCheckInfo = new Neusoft.FrameWork.Public.ObjectHelper();

        #endregion

        #region 工具条处理


        /// <summary>
        /// 注册工具条

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("删除", "删除权限", 2, true, false, null);
            return this.toolBarService;
        }

        /// <summary>
        /// 重写保存按钮实现方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Save(object sender, object neuObject)
        {
            #region 原来的代码


            //SavePopedom();

            #endregion

            #region 于洋修改的代码


            if (fpPopedom.Rows.Count > 0)
            {
                SavePopedom();
            }

            //StringBuilder message = new StringBuilder();
            //List<Neusoft.HISFC.Models.Order.MedicalTerm> lCheckInfo = this.termOrder.QueryMedicalTermBySysClass("UC");
            //foreach (Neusoft.HISFC.Models.Order.MedicalTerm medicalTerm in lCheckInfo)
            //{
            //    if (medicalTerm.Name == "胸部侧位")
            //    {
            //        message.Append(medicalTerm.Name + ":" + medicalTerm.ID);
            //        MessageBox.Show(message.ToString());
            //        string str = string.Empty;
            //        int result = aby.CheckPopedom("009527", "UC", medicalTerm.ID, ref str);
            //        MessageBox.Show("result=" + result);
            //        break;
            //    }
            //}

            #endregion

            return base.Save(sender, neuObject);
        }

        /// <summary>
        /// 处理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "删除":
                    DeletePopedom();
                    break;
                default: break;
            }

        }

        #endregion


        #region 树形控件相关方法

        /// <summary>
        /// 在一个节点下加载专业节点
        /// </summary>
        /// <param name="Anode">父节点</param>
        /// <returns>子节点个数</returns>
        private int AddSpecNodes(TreeNode Anode)
        {
            foreach (Neusoft.HISFC.Models.Base.Const cons in ehSpeciality.ArrayObject)
            {
                TreeNode pNode = new TreeNode();

                pNode.Tag = cons.ID;
                pNode.Text = cons.Name;
                pNode.ToolTipText = "专业";
                pNode.ImageIndex = 3;

                int childCount = AddDoctorNodes(pNode, Anode);

                if (childCount > 0)
                {
                    Anode.Nodes.Add(pNode);
                }
            }

            return Anode.Nodes.Count;
        }

        /// <summary>
        /// 在一个节点下加载医生节点
        /// </summary>
        /// <param name="Anode">父节点</param>
        /// <param name="parentNode">父节点的父节点</param>
        /// <returns>子节点个数</returns>
        private int AddDoctorNodes(TreeNode Anode, TreeNode parentNode)
        {
            List<Neusoft.HISFC.Models.Order.Medical.Ability> aList = aby.QueryDoctorListBySpecLevl(Anode.Tag.ToString(), parentNode.Tag.ToString());
            foreach (Neusoft.HISFC.Models.Order.Medical.Ability ability in aList)
            {
                TreeNode pNode = new TreeNode();

                pNode.Tag = ability.Employee.ID;
                pNode.Text = ability.Employee.Name;
                pNode.ToolTipText = "医生";
                pNode.ImageIndex = 3;

                Anode.Nodes.Add(pNode);
            }

            return Anode.Nodes.Count;
        }

        /// <summary>
        /// 初始化左树节点

        /// </summary>
        private void InitTreeViewNodesLeft()
        {
            tvDoctor.Nodes[0].Tag = "全部医生";
            tvDoctor.Nodes[0].Text = "全部医生";

            //加载医生职级节点
            foreach (Neusoft.HISFC.Models.Base.Const cons in ehLevel.ArrayObject)
            {
                TreeNode pNode = new TreeNode();

                pNode.Tag = cons.ID;
                pNode.Text = cons.Name;
                pNode.ToolTipText = "医师职级";
                pNode.ImageIndex = 3;

                int childCount = AddSpecNodes(pNode);

                if (childCount > 0)
                {
                    tvDoctor.Nodes[0].Nodes.Add(pNode);
                }
            }
        }

        /// <summary>
        /// 初始化右树节点

        /// </summary>
        private void InitTreeViewNodesRight()
        {
            //加载手术规模节点
            foreach (Neusoft.HISFC.Models.Base.Const cons in ehOperate.ArrayObject)
            {
                TreeNode pNode = new TreeNode();
                pNode.Tag = cons.ID;
                pNode.Text = cons.Name;
                pNode.ImageIndex = 4;
                pNode.ToolTipText = "权限";
                tvPopedom.Nodes[0].Nodes[0].Nodes.Add(pNode);
            }

            //加载药品性质节点
            foreach (Neusoft.HISFC.Models.Base.Const cons in ehDrugType.ArrayObject)
            {
                TreeNode pNode = new TreeNode();
                pNode.Tag = cons.ID;
                pNode.Text = cons.Name;
                pNode.ImageIndex = 4;
                pNode.ToolTipText = "权限";
                tvPopedom.Nodes[0].Nodes[1].Nodes.Add(pNode);
            }

            #region 修改前的代码

            ////加载药品等级节点
            //foreach (Neusoft.HISFC.Models.Base.Const cons in ehDrugLevel.ArrayObject)
            //{
            //    TreeNode pNode = new TreeNode();
            //    pNode.Tag = cons.ID;
            //    pNode.Text = cons.Name;
            //    pNode.ImageIndex = 4;
            //    pNode.ToolTipText = "权限";
            //    tvPopedom.Nodes[0].Nodes[2].Nodes.Add(pNode);
            //}

            #endregion

            #region 于洋修改的代码


            //加载药品等级节点
            foreach (Neusoft.HISFC.Models.Base.Const cons in this.ehGroupType.ArrayObject)
            {
                TreeNode pNode = new TreeNode();
                pNode.Tag = cons.ID;
                pNode.Text = cons.Name;
                pNode.ImageIndex = 4;
                pNode.ToolTipText = "权限";
                tvPopedom.Nodes[0].Nodes[2].Nodes.Add(pNode);
            }

            //设备权限维护
            //Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookingMgr = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking();
            //ArrayList alEquipment = new ArrayList (); // = bookingMgr.QueryMedTechEquipment("ALL", "1");

            //Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //ArrayList alDept = manager.GetDepartment();
            //foreach (Neusoft.HISFC.Models.Terminal.TerminalCarrier equipment in alEquipment)
            //{
            //    TreeNode pNode = new TreeNode();

            //    string deptName = string.Empty;
            //    foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
            //    {
            //        if (dept.ID == equipment.Dept.ID)
            //        {
            //            deptName = dept.Name;
            //        }
            //    }

            //    pNode.Tag = equipment.Dept.ID + "_" + equipment.CarrierCode;
            //    pNode.Text = deptName + "_" + equipment.CarrierName;
            //    pNode.ImageIndex = 4;
            //    pNode.ToolTipText = "权限";
            //    tvPopedom.Nodes[0].Nodes[4].Nodes.Add(pNode);
            //}

            #endregion

            tvPopedom.ExpandAll();
        }


        #endregion


        #region 方法与事件



        /// <summary>
        /// 初始化Helper类型
        /// </summary>
        private void IniHelper()
        {
            ehSpeciality.ArrayObject = GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.SPECIALITY);//专业
            ehLevel.ArrayObject = GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.LEVEL);//职级
            ehOperate.ArrayObject = GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.OPERATETYPE);//手术规模
            ehDrugType.ArrayObject = GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);//药品性质
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            //ehDrugLevel.ArrayObject = consManager.GetList("DRUGGRADE"); ;//药品等级

            //增加组套权限维护
            //{C0C116F2-E66F-41e7-AA16-8C410196C606}
            ehGroupType.ArrayObject = consManager.GetList("GROUPMANAGER");
        }

        /// <summary>
        /// 根据参数类型获得ArrayList
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private ArrayList GetConstant(Neusoft.HISFC.Models.Base.EnumConstant type)
        {
            //常数管理类


            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

            ArrayList constList = consManager.GetList(type);
            if (constList == null)
                throw new Neusoft.FrameWork.Exceptions.ReturnNullValueException();

            return constList;
        }

        private void ucPopedomManagement_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            IniHelper();
            InitTreeViewNodesLeft();
            InitTreeViewNodesRight();

            #region 于洋添加的代码


            this.fpPopedom.RowCount = 0;
            this.InitCheckInfoDataSet();
            this.QueryCheckInfo();

            #endregion
        }

        private void tvPopedom_DoubleClick(object sender, EventArgs e)
        {
            //原代码

            //if (tvDoctor.SelectedNode.ToolTipText != "医生")
            //{
            //    MessageBox.Show("没有选择医生！");
            //    return;
            //}

            #region 于洋修改的代码

            if (CheckDoctTreeValid() == false)
            {
                return;
            }

            #endregion

            if (tvPopedom.SelectedNode.ToolTipText == "权限")
            {
                //填充数组
                Neusoft.HISFC.Models.Order.Medical.Popedom popedomOne = new Neusoft.HISFC.Models.Order.Medical.Popedom();

                popedomOne.EmplCode = tvDoctor.SelectedNode.Tag.ToString();
                popedomOne.EmplName = tvDoctor.SelectedNode.Text;
                popedomOne.Popedoms.Name = tvPopedom.SelectedNode.Text;
                if (tvPopedom.SelectedNode.Tag == null)
                {
                    popedomOne.PopedomType.Name = tvPopedom.SelectedNode.Text;
                    popedomOne.Popedoms.ID = tvPopedom.SelectedNode.Index.ToString();
                    popedomOne.PopedomType.ID = tvPopedom.SelectedNode.Index.ToString();
                }
                else
                {
                    popedomOne.PopedomType.Name = tvPopedom.SelectedNode.Parent.Text;
                    popedomOne.PopedomType.ID = tvPopedom.SelectedNode.Parent.Index.ToString();
                    popedomOne.Popedoms.ID = tvPopedom.SelectedNode.Tag.ToString();
                }

                for (int i = 0; i < fpPopedom.RowCount; i++)
                {
                    if ((popedomOne.PopedomType.ID == fpPopedom.Cells[i, 7].Text.Trim()) && (popedomOne.Popedoms.ID == fpPopedom.Cells[i, 6].Text.Trim()))
                    {
                        MessageBox.Show("该权限已经添加");

                        return;
                    }
                }

                fpPopedom.Rows[fpPopedom.RowCount - 1].Tag = popedomOne;
                //popAdd.Add(popedomOne);

                //填充farPoint控件
                fpPopedom.RowCount = fpPopedom.RowCount + 1;
                fpPopedom.Cells[fpPopedom.RowCount - 1, 0].Text = tvDoctor.SelectedNode.Tag.ToString();
                fpPopedom.Cells[fpPopedom.RowCount - 1, 1].Text = tvDoctor.SelectedNode.Text;
                if (tvPopedom.SelectedNode.Tag == null)
                {
                    fpPopedom.Cells[fpPopedom.RowCount - 1, 2].Text = tvPopedom.SelectedNode.Text;
                    fpPopedom.Cells[fpPopedom.RowCount - 1, 6].Text = tvPopedom.SelectedNode.Index.ToString();
                    fpPopedom.Cells[fpPopedom.RowCount - 1, 7].Text = tvPopedom.SelectedNode.Index.ToString();
                }
                else
                {
                    fpPopedom.Cells[fpPopedom.RowCount - 1, 2].Text = tvPopedom.SelectedNode.Parent.Text;
                    fpPopedom.Cells[fpPopedom.RowCount - 1, 6].Text = tvPopedom.SelectedNode.Tag.ToString();
                    fpPopedom.Cells[fpPopedom.RowCount - 1, 7].Text = tvPopedom.SelectedNode.Parent.Index.ToString();
                }
                fpPopedom.Cells[fpPopedom.RowCount - 1, 3].Text = tvPopedom.SelectedNode.Text;
                fpPopedom.Cells[fpPopedom.RowCount - 1, 4].Text = "否";
                fpPopedom.Cells[fpPopedom.RowCount - 1, 8].Text = "1";
            }
        }

        /// <summary>
        /// 左树选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDoctor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Query();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void Query()
        {
            popAdd.Clear();
            if (tvDoctor.SelectedNode.ToolTipText == "医生")
            {
                List<Neusoft.HISFC.Models.Order.Medical.Popedom> PopedomShow = aby.QueryPopedomByEmplID(tvDoctor.SelectedNode.Tag.ToString());
                FillFp(PopedomShow);
            }
            else
            {
                this.fpPopedom.RowCount = 0;
            }
        }

        /// <summary>
        /// 实现保存的方法

        /// </summary>
        private void SavePopedom()
        {
            //{EC320C77-250E-4f44-863D-2E47B9F2FA22}
            if (tvDoctor.SelectedNode == null)
            {
                return;
            }


            popAdd.Clear();
            //{EC320C77-250E-4f44-863D-2E47B9F2FA22}
            AddDataOfChildDoctToSaveList(this.tvDoctor.SelectedNode);

            try
            {
                //事务开始


                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                foreach (Neusoft.HISFC.Models.Order.Medical.Popedom pdm in popAdd)
                {
                    //先检查是否已经维护过权限了
                    //{EC320C77-250E-4f44-863D-2E47B9F2FA22}
                    if (aby.CheckByEmplRight(pdm.EmplCode, pdm.PopedomType.ID, pdm.Popedoms.ID) <= 0)
                    {
                        if (pdm.User03 == "0")
                        {
                            if (aby.UpdatePopedom(pdm) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("保存失败");
                            }
                        }
                        else
                        {
                            if (aby.InsertPopedom(pdm) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("保存失败");
                            }
                        }
                    }
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功");
                Query();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 把选择好的权限数据加入到准备保存的数据列表中
        /// {EC320C77-250E-4f44-863D-2E47B9F2FA22}
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int AddDataOfChildDoctToSaveList(TreeNode node)
        {
            if (node.ToolTipText == "医生")
            {
                for (int i = 0; i < fpPopedom.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Order.Medical.Popedom spo = new Neusoft.HISFC.Models.Order.Medical.Popedom();
                    spo.EmplCode = node.Tag.ToString();
                    spo.EmplName = node.Text;
                    spo.PopedomType.Name = fpPopedom.Cells[i, 2].Text;
                    spo.Popedoms.Name = fpPopedom.Cells[i, 3].Text;
                    if (fpPopedom.Cells[i, 4].Text == "是")
                    {
                        spo.CheckFlag = "1";
                    }
                    else
                    {
                        spo.CheckFlag = "0";
                    }

                    spo.ID = fpPopedom.Cells[i, 5].Text;
                    spo.Popedoms.ID = fpPopedom.Cells[i, 6].Text;
                    spo.PopedomType.ID = fpPopedom.Cells[i, 7].Text;
                    spo.User03 = fpPopedom.Cells[i, 8].Text;
                    popAdd.Add(spo);
                }
            }
            else
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    AddDataOfChildDoctToSaveList(childNode);
                }
            }
            return 1;
        }
        /// <summary>
        /// 删除一条权限

        /// </summary>
        private void DeletePopedom()
        {
            #region 原来的代码

            //if (aby.DeletePopedom(fpPopedom.Cells[fpPopedom.ActiveRow.Index, 5].Text) == -1)
            //{
            //    MessageBox.Show("删除失败");
            //}
            //else
            //{
            //    fpPopedom.ActiveRow.Remove();
            //    MessageBox.Show("删除成功");
            //} 
            #endregion

            #region 于洋修改的代码


            if (fpPopedom.Rows.Count > 0)
            {
                if (aby.DeletePopedom(fpPopedom.Cells[fpPopedom.ActiveRow.Index, 5].Text) == -1)
                {
                    MessageBox.Show("删除失败");
                }
                else
                {
                    fpPopedom.ActiveRow.Remove();
                    MessageBox.Show("删除成功");
                }
            }

            #endregion
        }

        /// <summary>
        /// 填充FP控件
        /// </summary>
        /// <param name="addFp"></param>
        private void FillFp(List<Neusoft.HISFC.Models.Order.Medical.Popedom> addFp)
        {
            if (addFp == null)
            {
                this.fpPopedom.RowCount = 0;

                return;
            }
            this.fpPopedom.RowCount = 0;
            for (int rowCount = 0; rowCount < addFp.Count; rowCount++)
            {
                this.fpPopedom.Rows.Add(rowCount, 1);
                //赋值查询结果到FarPoint对应的单元格中


                this.fpPopedom.Cells[rowCount, 0].Text = addFp[rowCount].EmplCode;
                this.fpPopedom.Cells[rowCount, 1].Text = tvDoctor.SelectedNode.Text;
                switch (addFp[rowCount].PopedomType.ID)
                {
                    case "0":
                        this.fpPopedom.Cells[rowCount, 2].Text = "手术权限";
                        this.fpPopedom.Cells[rowCount, 3].Text = ehOperate.GetName(addFp[rowCount].Popedoms.ID);
                        break;
                    case "1":
                        this.fpPopedom.Cells[rowCount, 2].Text = "处方权限";
                        this.fpPopedom.Cells[rowCount, 3].Text = ehDrugType.GetName(addFp[rowCount].Popedoms.ID);
                        break;
                    case "2"://{C0C116F2-E66F-41e7-AA16-8C410196C606}
                        this.fpPopedom.Cells[rowCount, 2].Text = "组套权限";
                        this.fpPopedom.Cells[rowCount, 3].Text = this.ehGroupType.GetName(addFp[rowCount].Popedoms.ID);
                        break;
                    case "3":
                        this.fpPopedom.Cells[rowCount, 2].Text = "会诊权限";
                        this.fpPopedom.Cells[rowCount, 3].Text = "会诊权限";
                        break;

                    #region 于洋添加的代码


                    case "4":
                        this.fpPopedom.Cells[rowCount, 2].Text = "大型仪器";
                        this.fpPopedom.Cells[rowCount, 3].Text = "大型仪器";
                        break;
                    case "9":
                        this.fpPopedom.Cells[rowCount, 2].Text = "特殊检查";
                        this.fpPopedom.Cells[rowCount, 3].Text = ehCheckInfo.GetName(addFp[rowCount].Popedoms.ID);
                        break;

                    #endregion
                }
                if (addFp[rowCount].CheckFlag == "1")
                {
                    this.fpPopedom.Cells[rowCount, 4].Text = "是";
                }
                else
                {
                    this.fpPopedom.Cells[rowCount, 4].Text = "否";
                }
                this.fpPopedom.Cells[rowCount, 5].Text = addFp[rowCount].ID;
                this.fpPopedom.Cells[rowCount, 6].Text = addFp[rowCount].Popedoms.ID;
                this.fpPopedom.Cells[rowCount, 7].Text = addFp[rowCount].PopedomType.ID;
                this.fpPopedom.Cells[rowCount, 8].Text = "0";
            }
        }

        #endregion

        private void neuContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "item0")
            {
                Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch frm = new Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch();
                frm.Init(this.tvDoctor);
                frm.ShowDialog();
            }
        }

        #region 于洋的添加的方法

        /// <summary>
        /// 查询特殊检查信息
        /// </summary>
        /// <returns>1：成功，-1：失败</returns>
        private int QueryCheckInfo()
        {
            //List<Neusoft.HISFC.Models.Order.MedicalTerm> lCheckInfo = this.termOrder.QueryMedicalTermBySysClass("UC");

            //if (lCheckInfo == null)
            //{
            //    MessageBox.Show(Language.Msg("加载特殊检查列表数据发生错误" + this.termOrder.Err));
            //    return -1;
            //}

            //ArrayList alCheckInfo = new ArrayList();

            ////清空数据
            //this.dtCheck.Rows.Clear();
            //DataRow newRow;

            //foreach (Neusoft.HISFC.Models.Order.MedicalTerm medicalTerm in lCheckInfo)
            //{
            //    newRow = this.dtCheck.NewRow();

            //    newRow["特殊检查ID"] = medicalTerm.ID;
            //    newRow["特殊检查"] = medicalTerm.Name;
            //    newRow["拼音码"] = medicalTerm.SpellCode;
            //    newRow["五笔码"] = medicalTerm.WBCode;
            //    newRow["自定义码"] = medicalTerm.UserCode;

            //    this.dtCheck.Rows.Add(newRow);

            //    alCheckInfo.Add(medicalTerm);
            //}

            ////提交DataTable中的变化。

            //this.dtCheck.AcceptChanges();

            //this.SpreadCheck_Sheet1.Visible = true;

            //ehCheckInfo.ArrayObject = alCheckInfo;

            return 1;
        }


        /// <summary>
        /// 初始化特殊检查数据集
        /// </summary>
        private void InitCheckInfoDataSet()
        {
            this.SpreadCheck_Sheet1.DataAutoSizeColumns = false;

            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");

            this.dtCheck = new DataTable();

            //在myDataTable中定义列
            this.dtCheck.Columns.AddRange(new DataColumn[] {													
                                                    new DataColumn("特殊检查ID",      dtStr),
                                                    new DataColumn("特殊检查",      dtStr),
                                                    new DataColumn("拼音码",     dtStr),
													new DataColumn("五笔码",     dtStr),
													new DataColumn("自定义码",   dtStr),
											        });

            this.dtCheck.Columns["特殊检查"].ReadOnly = true;

            //隐藏不显示的信息
            this.SpreadCheck_Sheet1.Visible = false;
            this.SpreadCheck_Sheet1.DataSource = this.dtCheck.DefaultView;

            this.SpreadCheck_Sheet1.Columns[0].Visible = false;
            this.SpreadCheck_Sheet1.Columns[2].Visible = false;
            this.SpreadCheck_Sheet1.Columns[3].Visible = false;
            this.SpreadCheck_Sheet1.Columns[4].Visible = false;

            this.SpreadCheck_Sheet1.Columns[1].Width = 160;
        }


        /// <summary>
        /// 通过输入的查询码，过滤数据列表

        /// </summary>
        private void FilterCheck()
        {
            if (this.dtCheck.Rows.Count == 0) return;

            try
            {
                string queryCode = "";

                string filterData = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtCheck.Text);

                queryCode = "%" + filterData + "%";

                string filter = "(特殊检查 LIKE '" + queryCode + "') OR " +
                    "(拼音码 LIKE '" + queryCode + "') OR " +
                    "(五笔码 LIKE '" + queryCode + "') OR " +
                    "(自定义码 LIKE '" + queryCode + "') ";

                //设置过滤条件
                this.dtCheck.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
            }
        }

        /// <summary>
        /// 特殊检查过滤框输入值变化事件的处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCheck_TextChanged(object sender, EventArgs e)
        {
            //过滤信息
            this.FilterCheck();
        }

        /// <summary>
        /// 特殊检查列表中双击事件的处理方法

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpreadCheck_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //if (tvDoctor.SelectedNode.ToolTipText != "医生")
            //{
            //    MessageBox.Show("没有选择医生！");
            //    return;
            //}

            if (CheckDoctTreeValid() == false)
            {
                return;
            }

            //填充数组
            Neusoft.HISFC.Models.Order.Medical.Popedom popedomOne = new Neusoft.HISFC.Models.Order.Medical.Popedom();

            popedomOne.EmplCode = tvDoctor.SelectedNode.Tag.ToString();
            popedomOne.EmplName = tvDoctor.SelectedNode.Text;

            popedomOne.PopedomType.ID = "9";
            popedomOne.PopedomType.Name = "特殊检查";
            popedomOne.Popedoms.ID = this.SpreadCheck_Sheet1.Cells[e.Row, 0].Text;
            popedomOne.Popedoms.Name = this.SpreadCheck_Sheet1.Cells[e.Row, 1].Text;

            for (int i = 0; i < fpPopedom.RowCount; i++)
            {
                if ((popedomOne.PopedomType.ID == fpPopedom.Cells[i, 7].Text.Trim()) && (popedomOne.Popedoms.ID == fpPopedom.Cells[i, 6].Text.Trim()))
                {
                    MessageBox.Show("该权限已经添加");

                    return;
                }
            }

            fpPopedom.Rows[fpPopedom.RowCount - 1].Tag = popedomOne;
            //popAdd.Add(popedomOne);

            //填充farPoint控件
            fpPopedom.RowCount = fpPopedom.RowCount + 1;

            fpPopedom.Cells[fpPopedom.RowCount - 1, 0].Text = tvDoctor.SelectedNode.Tag.ToString();
            fpPopedom.Cells[fpPopedom.RowCount - 1, 1].Text = tvDoctor.SelectedNode.Text;
            fpPopedom.Cells[fpPopedom.RowCount - 1, 2].Text = "特殊检查";
            fpPopedom.Cells[fpPopedom.RowCount - 1, 3].Text = this.SpreadCheck_Sheet1.Cells[e.Row, 1].Text;
            fpPopedom.Cells[fpPopedom.RowCount - 1, 4].Text = "否";

            fpPopedom.Cells[fpPopedom.RowCount - 1, 6].Text = this.SpreadCheck_Sheet1.Cells[e.Row, 0].Text;
            fpPopedom.Cells[fpPopedom.RowCount - 1, 7].Text = "9";
            fpPopedom.Cells[fpPopedom.RowCount - 1, 8].Text = "1";

        }

        /// <summary>
        /// 检查医生树控件是否合法
        /// </summary>
        /// <returns></returns>
        protected bool CheckDoctTreeValid()
        {
            if (tvDoctor.Nodes[0].Nodes.Count <= 0)
            {
                MessageBox.Show("没有任何的医生信息！");
                return false;
            }

            //{EC320C77-250E-4f44-863D-2E47B9F2FA22}
            if (tvDoctor.SelectedNode == null)
            {
                MessageBox.Show("没有选择医生或者专业！");
                return false;
            }
            return true;
        }
        #endregion
    }
}

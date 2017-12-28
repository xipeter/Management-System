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
    public partial class ucFeeAlertQueryPrint :Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucFeeAlertQueryPrint()
        {
            InitializeComponent();
        }
        #region 变量
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        private bool isAllNurse = false;
        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        #endregion
        #region 属性

        [Category("设置"), Description("设置显示全院或本护理站")]
        public bool ISAllNurse
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
        #endregion

       
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
            TreeNode node = new TreeNode();
            this.neuTreeView1.Nodes.Add(root);

            if (this.ISAllNurse == true)
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
                    //F0BF027A-9C8A-4bb7-AA23-26A5F3539586
                    //添加病区包含的科室

                    //alDept = new ArrayList();
                    //alDept = this.managerIntegrate.QueryDepartment(neuObject.ID);

                    //if (alDept == null || alDept.Count == 0)
                    //{
                    //    continue;
                    //}

                    //foreach (Neusoft.FrameWork.Models.NeuObject myOjbect in alDept)
                    //{
                    //    TreeNode secendNode = new TreeNode();
                    //    secendNode.Text = myOjbect.Name;
                    //    secendNode.Tag = myOjbect;
                    //    secendNode.ImageIndex = 4;
                    //    secendNode.SelectedImageIndex = 5;
                    //    node.Nodes.Add(secendNode);
                    //}

                }
            }
            else //显示本护理站
            {
                alNures = new ArrayList();
                Neusoft.FrameWork.Models.NeuObject objectTemp = new Neusoft.FrameWork.Models.NeuObject();
                objectTemp = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept;

                if (objectTemp == null)
                {
                    return -1;
                }
                //F0BF027A-9C8A-4bb7-AA23-26A5F3539586
                //alNures = this.managerIntegrate.QueryNurseStationByDept(objectTemp, "01");


                //if (alNures == null || alNures.Count == 0)
                //{
                //    return -1;
                //}
                //foreach (Neusoft.FrameWork.Models.NeuObject neuObject in alNures)
                //{
                    //node = new TreeNode();
                    //node.Text = neuObject.Name;
                    //node.Tag = neuObject;
                    //node.SelectedImageIndex = 2;
                    //node.ImageIndex = 3;
                    //root.Nodes.Add(node);

                    ////添加病区包含的科室

                    //TreeNode secendNode = new TreeNode();
                    //secendNode.Text = objectTemp.Name;
                    //secendNode.Tag = objectTemp;
                    //secendNode.ImageIndex = 4;
                    //secendNode.SelectedImageIndex = 5;
                    //node.Nodes.Add(secendNode);


                //}
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
        /// <summary>
        /// 查询患者信息
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        protected ArrayList GetPatient(TreeNode Node)
        {
            ArrayList alPatientInfo = new ArrayList();
            #region //全院设置
            if (this.ISAllNurse == true)
            {
                if (Node.Level == 0)
                {
                    //查找所有在院患者（按照住院状态）
                    //alPatientInfo = this.radtIntegrate.QueryPatient(Neusoft.HISFC.Models.Base.EnumInState.I);
                    return null;

                }
                else if (Node.Level == 1)
                {

                    //查找病区所有患者

                    //{62EAD92D-49F6-45d5-B378-1E573EC27728}
                    //alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndState((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                    //F0BF027A-9C8A-4bb7-AA23-26A5F3539586
                    alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndStateForAlert((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                   // this.nurseOjbect = Node.Tag as Neusoft.FrameWork.Models.NeuObject;
                }
                else
                {
                    //查找科室所有患者

                    //{62EAD92D-49F6-45d5-B378-1E573EC27728}
                    //alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndDept((Node.Parent.Tag as Neusoft.FrameWork.Models.NeuObject).ID, (Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                    alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndDeptForAlert((Node.Parent.Tag as Neusoft.FrameWork.Models.NeuObject).ID, (Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                    //this.nurseOjbect = Node.Parent.Tag as Neusoft.FrameWork.Models.NeuObject;
                }


            }
            #endregion

            #region 按登陆科室设置

            else
            {
                if (Node.Level == 0)
                {
                    return null;
                }
                if (Node.Level == 1)//护士站
                {
                    //F0BF027A-9C8A-4bb7-AA23-26A5F3539586
                    //if (Node.Nodes.Count > 0)
                    //{
                        //{62EAD92D-49F6-45d5-B378-1E573EC27728}
                        //alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndDept((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, (Node.Nodes[0].Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                        //alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndDeptForAlert((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, (Node.Nodes[0].Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                        alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndStateForAlert((Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                    //}

                }
                else
                {
                    if (Node.Level == 2)//科室
                    {
                        //{62EAD92D-49F6-45d5-B378-1E573EC27728}
                        alPatientInfo = this.radtIntegrate.QueryPatientByNurseCellAndDeptForAlert((Node.Parent.Tag as Neusoft.FrameWork.Models.NeuObject).ID, (Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                    }

                }

            }
            #endregion
            return alPatientInfo;
        }

        protected void SetPatientToFP(ArrayList AlPatientInfo)
        {
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                this.neuSpread1_Sheet1.RemoveRows(0,this.neuSpread1_Sheet1.RowCount);
            }
            if (AlPatientInfo == null || AlPatientInfo.Count == 0)
            {
                return;
            }
            for (int i = 0; i < AlPatientInfo.Count; i++)
            {
                Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo ();
                patientInfo = (Neusoft.HISFC.Models.RADT.PatientInfo)AlPatientInfo[i];
                this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount,1);
                this.neuSpread1_Sheet1.Cells[i, 0].Value = false;
                this.neuSpread1_Sheet1.Cells[i, 1].Value = patientInfo.PID.PatientNO;
                this.neuSpread1_Sheet1.Cells[i, 2].Value = patientInfo.Name;
                this.neuSpread1_Sheet1.Cells[i, 3].Value = patientInfo.Pact.Name;
                this.neuSpread1_Sheet1.Cells[i, 4].Value = patientInfo.PVisit.PatientLocation.Dept.Name ;
                this.neuSpread1_Sheet1.Cells[i, 5].Value = patientInfo.PVisit.PatientLocation.NurseCell.Name;
                this.neuSpread1_Sheet1.Cells[i, 6].Value = patientInfo.FT.TotCost;
                this.neuSpread1_Sheet1.Cells[i, 7].Value = patientInfo.FT.LeftCost;
                this.neuSpread1_Sheet1.Cells[i, 8].Value = patientInfo.FT.PrepayCost;
                this.neuSpread1_Sheet1.Cells[i, 9].Value = patientInfo.PVisit.MoneyAlert;
                this.neuSpread1_Sheet1.Cells[i, 10].Value = patientInfo.PVisit.InTime;
                this.neuSpread1_Sheet1.Rows[i].Tag = patientInfo;
                //this.neuSpread1_Sheet1.Cells[i, 2].Value = patientInfo.Name;
                //this.neuSpread1_Sheet1.Cells[i, 2].Value = patientInfo.Name;
                
            }
        }

        protected void InitFp()
        {
            DataTable dtMaint = new DataTable();
            dtMaint.Columns.AddRange(new DataColumn[]{
                new DataColumn("选择",typeof(bool)),
                new DataColumn ("住院号",typeof(string)),
                new DataColumn ("姓名",typeof (string)),
                new DataColumn("合同单位",typeof(string)),
                new DataColumn ("住院科室",typeof (string)),
                new DataColumn ("所在病区",typeof (string)),
                new DataColumn ("花费总额",typeof (decimal)),
                new DataColumn ("余额",typeof (decimal)),
                new DataColumn ("预交金",typeof (decimal)),
                new DataColumn ("警戒线",typeof (decimal)),
                new DataColumn ("入院日期",typeof (DateTime))
                //new DataColumn ("住院科室",typeof (string)),
                //new DataColumn ("住院科室",typeof (string)),
                //new DataColumn ("住院科室",typeof (string)),
            });
            this.neuSpread1_Sheet1.DataSource = dtMaint;
            this.neuSpread1_Sheet1.Columns[0].Width = 30;
            this.neuSpread1_Sheet1.Columns[1].Width = 100;
            this.neuSpread1_Sheet1.Columns[2].Width = 80;
            this.neuSpread1_Sheet1.Columns[3].Width = 100;
            this.neuSpread1_Sheet1.Columns[4].Width = 100;
            for (int i = 0; i < this.neuSpread1_Sheet1.ColumnCount; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                this.neuSpread1_Sheet1.Columns[i].Locked = true;
            }
        }

        protected int Init()
        {
            this.initTreeView();
            this.InitFp();
            return 1;
        }
        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrintPreview(object sender, object neuObject)
        {
            ArrayList alPatientInfo = new ArrayList();
            alPatientInfo = this.SelectPatient();
            if (alPatientInfo.Count == 0)
            {
                return -1;
            }
            ucFeeAlertQueryPrintPanel ucPanel = new ucFeeAlertQueryPrintPanel();
            ucPanel.AlPatientInfo = alPatientInfo;
            ucPanel.PrintView();
            return 1;
            //return base.PrintPreview(sender, neuObject);
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {

            ArrayList alPatientInfo = new ArrayList();
            alPatientInfo = this.SelectPatient();
            if (alPatientInfo.Count == 0)
            {
                MessageBox.Show("请选择需打印通知单的患者");
                return -1;
            }
            ucFeeAlertQueryPrintPanel ucPanel = new ucFeeAlertQueryPrintPanel();
            ucPanel.AlPatientInfo = alPatientInfo;
            ucPanel.Print();
            return 1;
            //return base.OnPrint(sender, neuObject);
        }
        /// <summary>
        /// 选择患者
        /// </summary>
        /// <returns></returns>
        protected ArrayList SelectPatient()
        {
            ArrayList alPatientInfo = new ArrayList();
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                bool isSelected = Neusoft.FrameWork.Function.NConvert.ToBoolean( this.neuSpread1_Sheet1.Cells[i, 0].Value);
                if (isSelected)
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                    patientInfo = (Neusoft.HISFC.Models.RADT.PatientInfo)this.neuSpread1_Sheet1.Rows[i].Tag;
                    alPatientInfo.Add(patientInfo);
                }
            }
            return alPatientInfo;
 
        }
        /// <summary>
        /// 全选或全不选
        /// </summary>
        /// <param name="isAll"></param>
        private void selectItem(bool isAll)
        {
            if (isAll)
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    this.neuSpread1_Sheet1.Cells[i, 0].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    this.neuSpread1_Sheet1.Cells[i, 0].Value = false;
                }
            }
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("全选","全选",(int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选,true,false,null);
            toolBarService.AddToolButton("取消", "全不选", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true,false,null);
            return toolBarService;
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "全选":
                    this.selectItem(true);
                    break;
                case "取消":
                    this.selectItem(false);
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        private void ucFeeAlertQueryPrint_Load(object sender, EventArgs e)
        {
            //初始化
            this.Init();
        }

        private void neuTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载患者信息,请稍后");
            Application.DoEvents();
            this.SetPatientToFP(this.GetPatient(e.Node) );
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucMedicalTeam : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMedicalTeam()
        {
            InitializeComponent();
        }
        #region 域
        /// <summary>
        /// 管理综合业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 医疗组业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Order.MedicalTeam medicalTeamLogic = new Neusoft.HISFC.BizLogic.Order.MedicalTeam();

        /// <summary>
        /// 医疗组对应医生业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct medicalTeamForDoctLogic = new Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct();
        #endregion
        #region 属性

        #endregion

        #region 方法
        /// <summary>
        /// 初始化树
        /// </summary>
        /// <returns></returns>
        private int InitTreeView()
        {
            this.tvDept.Nodes.Clear();

            ArrayList alDeptListInhos = this.managerIntegrate.GetDeptmentIn(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            if (alDeptListInhos == null)
            {
                MessageBox.Show("查询住院科室出错");
                return 1;
            }


            this.tvDept.ImageList = this.tvDept.deptImageList;

            TreeNode rootNode = new TreeNode("住院科室", 1, 1);
            rootNode.Tag = "AAAA";

            for (int i = 0; i < alDeptListInhos.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject deptObj = alDeptListInhos[i] as Neusoft.FrameWork.Models.NeuObject;

                TreeNode node = new TreeNode();
                node.Tag = deptObj;
                node.Text = deptObj.Name;
                node.SelectedImageIndex = 0;
                node.ImageIndex = 0;

                rootNode.Nodes.Add(node);


            }
            rootNode.ExpandAll();
            this.tvDept.Nodes.Add(rootNode);

            return 1;
        }

        /// <summary>
        /// 根据科室查询医疗组信息
        /// </summary>
        /// <returns></returns>
        private int QueryMedicalTeamByDept(string deptCode)
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;
            List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam> medicalTeamList = this.medicalTeamLogic.QueryMedicalTeamByDept(deptCode);

            if (medicalTeamLogic == null)
            {
                MessageBox.Show("查询科室的医疗组失败!\n" + this.medicalTeamLogic.Err);
                return -1;
            }

            this.SetFarpointValue(medicalTeamList);


            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicalTeamList"></param>
        private void SetFarpointValue(List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam> medicalTeamList)
        {

            for (int i = 0; i < medicalTeamList.Count; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam obj = medicalTeamList[i];

                int count = this.neuSpread1_Sheet1.Rows.Count;
                this.neuSpread1_Sheet1.Rows.Add(count, 1);

                this.neuSpread1_Sheet1.Cells[count, 1].Text = obj.ID;
                this.neuSpread1_Sheet1.Cells[count, 2].Text = obj.Name;
                this.neuSpread1_Sheet1.Cells[count, 3].Value = obj.IsValid;
                this.neuSpread1_Sheet1.Cells[count, 4].Text = obj.Dept.Name;
                this.neuSpread1_Sheet1.Rows[count].Tag = obj;

            }

            
        }

        /// <summary>
        /// 根据科室和医疗组信息查询医生信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="medicalTeamCode"></param>
        /// <returns></returns>
        private int QueryDoctByDeptAndMedicalTeam(string deptCode, string medicalTeamCode)
        {
            this.neuSpread2_Sheet1.Rows.Count = 0;
            List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> medicalTeamForDoctList = this.medicalTeamForDoctLogic.QueryQueryMedicalTeamForDoctInfo(deptCode, medicalTeamCode,"All");
            if (medicalTeamForDoctList == null)
            {
                MessageBox.Show("查询医生出错!\n" + this.medicalTeamForDoctLogic.Err);
                return -1;
            }

            for (int i = 0; i < medicalTeamForDoctList.Count; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct obj = medicalTeamForDoctList[i];
                this.neuSpread2_Sheet1.Rows.Add(0, 1);
                this.neuSpread2_Sheet1.Cells[0, 1].Text = obj.Doct.Name;
                this.neuSpread2_Sheet1.Cells[0, 2].Value = obj.IsValid;
                this.neuSpread2_Sheet1.Rows[0].Tag = obj;
            }



            return 1;
        }

        /// <summary>
        /// 添加医疗组
        /// </summary>
        private int AddMedicalTeam()
        {
            if (this.tvDept.SelectedNode.Level == 0) return -1;
            Forms.frmMedcialTeam frmMedcialTeam = new Neusoft.HISFC.Components.Order.Forms.frmMedcialTeam();

            Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam medicalTeam = new Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam();

            medicalTeam.Dept = this.tvDept.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
            frmMedcialTeam.MedicalTeam = medicalTeam;

            frmMedcialTeam.ShowDialog();

            //重新刷新
            this.QueryMedicalTeamByDept(medicalTeam.Dept.ID);

            return 1;
        }


        /// <summary>
        /// 添加医疗组
        /// </summary>
        private int ModifyMedicalTeam()
        {
            if (this.tvDept.SelectedNode.Level == 0) return -1;
            Forms.frmMedcialTeam frmMedcialTeam = new Neusoft.HISFC.Components.Order.Forms.frmMedcialTeam();

            Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam medicalTeam = this.neuSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam;

            medicalTeam.Dept = this.tvDept.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
            frmMedcialTeam.MedicalTeam = medicalTeam;

            frmMedcialTeam.ShowDialog();

            //重新刷新
            this.QueryMedicalTeamByDept(medicalTeam.Dept.ID);

            return 1;
        }

        /// <summary>
        /// 添加医生
        /// </summary>
        /// <returns></returns>
        private int AddDoct()
        {
            Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam obj = this.neuSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam;
            if (obj == null)
            {
                MessageBox.Show("请选择医疗组信息");
                return -1;
            }

            Forms.frmAddDoct frmAddDoct = new Neusoft.HISFC.Components.Order.Forms.frmAddDoct();
            
            if (obj == null) return -1;
            frmAddDoct.MedicalTeam = obj;
            frmAddDoct.ShowDialog();
            this.QueryDoctByDeptAndMedicalTeam(obj.Dept.ID, obj.ID);

            return 1;
        }

        /// <summary>
        /// 停用启用医疗组
        /// </summary>
        /// <returns></returns>
        private int ProcessMedicalTeamValidFlag(bool isValid )
        {
            int returnValue = 0;
            string errText = string.Empty;
            
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
               
                bool isSelectecd = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value);

                if (isSelectecd)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam medcialTeamObj = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam;

                    //更新医疗组标记
                   returnValue =  this.medicalTeamLogic.UpdateValidFlag(Neusoft.FrameWork.Function.NConvert.ToInt32( isValid).ToString(), medcialTeamObj.Dept.ID, medcialTeamObj.ID);
                   if (returnValue < 0)
                   {
                       Neusoft.FrameWork.Management.PublicTrans.RollBack();
                       MessageBox.Show("更新医疗组状态失败!" + this.medicalTeamLogic.Err);
                       return -1;
                   }
                   if (isValid)
                   {
                       continue; //停用一起停，启用不一起启用
                   }
                    //更新医疗组内的医生
                    returnValue = ProcessDoctValidFlag(medcialTeamObj.Dept.ID, medcialTeamObj.ID, false, ref errText);
                    if (returnValue < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);
                        return -1;
                    }
                }
                
            }
            
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (isValid)
            {

                MessageBox.Show("启用成功！");
            }
            else
            {
                MessageBox.Show("停用成功！");
            }
            this.QueryMedicalTeamByDept((this.tvDept.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject).ID);

            return 1;
        }

        private int ProcessDoctValidFlag(string deptCode, string medicalTeamCode, bool isValid,ref string errText)
        {
            int returnValue = this.medicalTeamForDoctLogic.UpdateValidFlag(Neusoft.FrameWork.Function.NConvert.ToInt32(isValid).ToString(), deptCode, medicalTeamCode);
            if (returnValue < 0)
            {
                errText = "更细医生状态出错!\n" + this.medicalTeamForDoctLogic.Err ;
                return -1;
            }


            return 1;
        }

        /// <summary>
        /// 停用启用医生
        /// </summary>
        /// <param name="isValidFlag"></param>
        /// <returns></returns>
        private int ProcessDoctValidFlag(bool isValidFlag)
        {
            Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam obj = this.neuSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam;
            int returnValue = 0;
            string errText = string.Empty;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            int j = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                bool isSelectecd = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread2_Sheet1.Cells[i, 0].Value);

                if (isSelectecd)
                {
                    j++;
                    Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct medcialTeamForDoctObj = this.neuSpread2_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct;

                    returnValue = this.medicalTeamForDoctLogic.UpdateValidFlag(medcialTeamForDoctObj.MedcicalTeam.Dept.ID, medcialTeamForDoctObj.MedcicalTeam.ID, medcialTeamForDoctObj.Doct.ID);
                    if (returnValue < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新医生状态出错!\n" + this.medicalTeamForDoctLogic.Err);
                        return -1;
                    }
                }

            }
            if (j == 0) //没有选择
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("请选择要更新的医生");
                return -1;
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();

                if (isValidFlag)
                {
                    MessageBox.Show("启用成功");
                }
                else
                {
                    MessageBox.Show("停用成功");
                }

            }
            this.QueryDoctByDeptAndMedicalTeam(obj.Dept.ID,obj.ID);
            return 1;
        }
        /// <summary>
        /// 删除科室下所有医疗组信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        private int DeleteMedicalTeamAll()
        {
            if (this.tvDept.SelectedNode.Level == 0)
            {
                return -1;
            }

            Neusoft.FrameWork.Models.NeuObject deptObj = this.tvDept.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
            string deptCode = deptObj.ID;
            int returnValue = 1;
            string errText = string.Empty;
            int j = 0;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                bool isSelectecd = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value);
                
                if (isSelectecd)
                {


                    j++;
                    Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam medcialTeamObj = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam;

                    List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> doctList = this.medicalTeamForDoctLogic.QueryQueryMedicalTeamForDoctInfo(medcialTeamObj.Dept.ID, medcialTeamObj.ID, "All");

                    if (doctList == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("查询护理组下医生失败！\n" + this.medicalTeamForDoctLogic.Err);
                        return -1;

                    }

                    if (doctList.Count > 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("护理组:" + medcialTeamObj.Name +"有医生信息，不能删除！\n请先删除医生信息！");
                        return -1;
                        
                    }

                    returnValue = this.medicalTeamLogic.DeleteMedicalTeam(deptCode, medcialTeamObj.ID);
                    if (returnValue < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);
                        return -1;
                    }
                }
                 
            }

            if (j == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("请选择要删除的医疗组信息");
                return -1;
            }
            else
            {

                Neusoft.FrameWork.Management.PublicTrans.Commit();

                MessageBox.Show("删除成功");
            }
            this.QueryMedicalTeamByDept(deptCode);
            this.neuSpread2_Sheet1.Rows.Count = 0;
            return 1;
        }

        private int DeleteMedicalTeamForDoctAll()
        {
            Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam obj = this.neuSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam;
            int returnValue = 0;
            string errText = string.Empty;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            int j = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                bool isSelectecd = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread2_Sheet1.Cells[i, 0].Value);
                
                if (isSelectecd)
                {
                    j++;
                    Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct medcialTeamForDoctObj = this.neuSpread2_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct;

                    returnValue = this.medicalTeamForDoctLogic.DeleteMedicalTeamMedicalTeamForDoct(medcialTeamForDoctObj.MedcicalTeam.Dept.ID, medcialTeamForDoctObj.MedcicalTeam.ID, medcialTeamForDoctObj.Doct.ID);
                    if (returnValue < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("删除医生出错!\n" + this.medicalTeamForDoctLogic.Err);
                        return -1;
                    }
                }

            }
            if (j == 0) //没有选择
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("请选择要删除的医疗组信息");
                return -1;
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();

                MessageBox.Show("删除成功");
               
            }
            this.QueryDoctByDeptAndMedicalTeam(obj.Dept.ID,obj.ID);
            return 1;

        }


        #endregion

        #region 重载方法
        protected override void OnLoad(EventArgs e)
        {
            this.InitTreeView();
            base.OnLoad(e);
        }

        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarServic = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarServic.AddToolButton("增加医疗组", "增加医疗组", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarServic.AddToolButton("修改医疗组", "增加医疗组", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarServic.AddToolButton("删除医疗组", "删除医疗组", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
           // toolBarServic.AddToolButton("全删医疗组", "全删医疗组", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarServic.AddToolButton("增加医生", "增加医生", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarServic.AddToolButton("删除医生", "删除医生", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarServic.AddToolButton("停用医疗组", "停用医疗组", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarServic.AddToolButton("启用医疗组", "启用医疗组", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarServic.AddToolButton("停用医生", "停用医生", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarServic.AddToolButton("启用停用", "启用停用", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);


            return this.toolBarServic;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加医疗组":
                    {
                        this.AddMedicalTeam();
                        break;
                    }
                case "删除医疗组":
                    {
                        this.DeleteMedicalTeamAll();
                        break;
                    }
                case "修改医疗组":
                    {
                        this.ModifyMedicalTeam();
                        break;
                    }
                case "增加医生":
                    {
                        this.AddDoct();
                        break;
                    }
                case "删除医生":
                    {
                        this.DeleteMedicalTeamForDoctAll();
                        break;
                    }
                case "停用医疗组":
                    {
                        this.ProcessMedicalTeamValidFlag(false);
                        break;
                    }
                case "启用医疗组":
                    {
                        this.ProcessMedicalTeamValidFlag(true);
                        break;
                    }
                case "停用医生":
                    {
                        this.ProcessDoctValidFlag(false);
                        break;
                    }
                case "启用停用":
                    {
                        this.ProcessDoctValidFlag(true);
                        break;
                    }

                default:
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        #endregion

        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread2_Sheet1.RowCount = 0;
            if (e.Node.Level == 0)
            {
                this.tabPage1.Text = "住院科室";
                
                return;
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject obj = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;
                this.QueryMedicalTeamByDept(obj.ID);
                this.tabPage1.Text = "科室名称:" + obj.Name;
            }
        }

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader) return;
           

            Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam obj = this.neuSpread1_Sheet1.Rows[e.Row].Tag as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam;

            this.tabPage2.Text = obj.Name;

            if (obj == null) return;

            this.QueryDoctByDeptAndMedicalTeam(obj.Dept.ID, obj.ID);


        }
    }
}

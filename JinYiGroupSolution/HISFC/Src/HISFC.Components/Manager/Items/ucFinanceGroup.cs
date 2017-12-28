using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Manager.Items
{
    public partial class ucFinanceGroup : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
     
        public ucFinanceGroup()
        {
            InitializeComponent();
        }

        #region 变量
                  
        //科室缓存
        private Hashtable htDept = new Hashtable();        
        //科室人员        
        private DataTable dtDeptEmp;
        //人员财务组
        private DataTable dtFinanceEmployee;
        //人员财务组数据集
        private DataSet dsFinanceEmployee;

        //fpGroupEmployee行计数       
        private int countEmplFinance; 

        //人员财务组类
        Neusoft.HISFC.BizLogic.Fee.EmployeeFinanceGroup feeEmplFinanceGroup = new Neusoft.HISFC.BizLogic.Fee.EmployeeFinanceGroup();
        //财务组类
        Neusoft.HISFC.Models.Fee.FinanceGroup feeFinanceGroup = new Neusoft.HISFC.Models.Fee.FinanceGroup();
        //人员类
        Neusoft.HISFC.BizLogic.Manager.Person managerPerson = new Neusoft.HISFC.BizLogic.Manager.Person();
        //ToolBar
        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion
        
        #region 方法

        /// <summary>
        /// 生成ToolBar按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("新建", "新建财务组",(int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建,true,false,null);
            toolBarService.AddToolButton("删除","删除人员",(int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除,true,false,null);
            toolBarService.AddToolButton("保存", "保存人员", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);   

            return this.toolBarService;

        }

        /// <summary>
        /// ToolBar事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
            {
                case "新建":
                    this.NewGroup();
                    break;
                case "删除":
                    this.DeleteGroup();
                    break;
                case "保存":
                    this.SaveAll();
                    break;
            }

            base.ToolStrip_ItemClicked(sender,e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveAll();
            return 1;
            //return base.OnSave(sender, neuObject);
        }

        /// <summary>
        /// 获取科室信息
        /// </summary>
        private void GetDept()
        {
            Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();

            ArrayList alDept = dept.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.F);
            //ArrayList alDept = dept.GetDeptmentAll();

            if (alDept == null)
            {
                return;
            }

            for (int i = 0, j = alDept.Count; i < j; i++)
            {
                this.htDept.Add(((Neusoft.FrameWork.Models.NeuObject)alDept[i]).ID, ((Neusoft.FrameWork.Models.NeuObject)alDept[i]).Name);
            }

            this.cbDepartment.AddItems(alDept);
        }

        /// <summary>
        /// 获取科室内人员信息
        /// </summary>
        /// <param name="strDeptId">科室编号</param>
        private void GetDeptEmployee(string deptId)
        {

            ArrayList alEmployee = managerPerson.GetEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.F, deptId);

            DataSet dsEmployee = new DataSet();

            DataTable dtEmployee = new DataTable("dtEmployee");

            DataColumn[] colEmployee = {new DataColumn("人员编码"),
						               new DataColumn("人员姓名"),
						               new DataColumn("科室代码")};

            dtEmployee.Columns.AddRange(colEmployee);

            dtEmployee.Rows.Clear();

            foreach (Neusoft.HISFC.Models.Base.Employee pInfo in alEmployee)
            {
                DataRow row = dtEmployee.NewRow();

                row["人员编码"] = pInfo.ID;
                row["人员姓名"] = pInfo.Name;
                row["科室代码"] = pInfo.Dept;

                dtEmployee.Rows.Add(row);
            }

            this.fpEmployee_Sheet1.DataSource = dtEmployee;

        }

        /// <summary>
        /// 获取财务组列表
        /// </summary>
        private void GetFinanceGroup()
        {

            ArrayList alFinance = feeEmplFinanceGroup.QueryFinaceGroupIDAndNameAll();

            DataSet dsFinance = new DataSet();

            DataTable dtFinance = new DataTable();

            DataColumn[] colFinance = {new DataColumn("财务组编码"),
                                    new DataColumn("财务组名称")};

            dtFinance.Columns.AddRange(colFinance);

            dtFinance.Rows.Clear();

            foreach (Neusoft.HISFC.Models.Fee.FinanceGroup fg in alFinance)
            {
                DataRow row = dtFinance.NewRow();

                row["财务组编码"] = fg.ID;
                row["财务组名称"] = fg.Name;

                dtFinance.Rows.Add(row);
            }

            this.fpGroup_Sheet1.DataSource = dtFinance;

        }

        /// <summary>
        /// 获取财务组内人员列表
        /// </summary>
        /// <param name="strFinance">财务组编码</param>
        private void GetFinanceEmployee(string strFinance)
        {
            ArrayList alFinanceEmployee = feeEmplFinanceGroup.GetFinaceGroupInfo(strFinance);

            dsFinanceEmployee = new DataSet();

            dtFinanceEmployee = new DataTable();

            DataColumn[] colFinanceEmployee = {new DataColumn("财务组编码"),
                                               new DataColumn("财务组名称"),
                                               new DataColumn("人员编码"),
                                               new DataColumn("人员姓名"),
                                               new DataColumn("有效性状态"),
                                               new DataColumn("序号"),
                                               new DataColumn("唯一标识")};

            dtFinanceEmployee.Columns.AddRange(colFinanceEmployee);

            dtFinanceEmployee.Rows.Clear();

            foreach (Neusoft.HISFC.Models.Fee.FinanceGroup fe in alFinanceEmployee)
            {
                DataRow row = dtFinanceEmployee.NewRow();

                row["财务组编码"] = fe.ID;
                row["财务组名称"] = fe.Name;
                row["人员编码"] = fe.Employee.ID;
                row["人员姓名"] = fe.Employee.Name;
                row["有效性状态"] = ((int)fe.ValidState).ToString();
                row["序号"] = fe.SortID;
                row["唯一标识"] = fe.PkID;

                dtFinanceEmployee.Rows.Add(row);
            }

            this.fpGroupEmployee_Sheet1.DataSource = dtFinanceEmployee;

        }

        /// <summary>
        /// 检索人员信息
        /// </summary>
        protected virtual void ChangeFinanceEmployee(int flag)
        {
            string strFinanceId;

            strFinanceId = "";

            try
            {
                if (flag == 0)
                {
                    strFinanceId = this.fpGroup_Sheet1.Cells[0, 0].Text;
                }
                else
                {
                    strFinanceId = this.fpGroup_Sheet1.Cells[this.fpGroup_Sheet1.ActiveRowIndex, 0].Text;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            if (this.fpGroupEmployee_Sheet1.Rows.Count > 0)
            {
                this.fpGroupEmployee_Sheet1.Rows.Remove(0, this.fpGroupEmployee_Sheet1.Rows.Count);
            }

            this.GetFinanceEmployee(strFinanceId);
            countEmplFinance = fpGroupEmployee_Sheet1.Rows.Count;

            if (fpGroupEmployee_Sheet1.Rows.Count > 0)
            {
                string ValidState;

                FarPoint.Win.Spread.CellType.ComboBoxCellType comboState = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

                comboState.Items = new String[] { "有效", "停用", "废弃" };

                comboState.ItemData = new String[] { "0", "1", "2" };


                for (int i = 0; i < fpGroupEmployee_Sheet1.Rows.Count; i++)
                {
                    ValidState = fpGroupEmployee_Sheet1.Cells[i, 4].Text;
                    //MessageBox.Show("ValidState" + ValidState);
                    switch (ValidState)
                    {
                        case "1":
                            ValidState = "有效";
                            break;
                        case "0":
                            ValidState = "停用";
                            break;
                        case "2":
                            ValidState = "废弃";
                            break;
                    }
                    fpGroupEmployee_Sheet1.Cells[i, 4].CellType = comboState;

                    fpGroupEmployee_Sheet1.SetText(i, 4, ValidState);
                }

                //this.fpGroupEmployee_Sheet1.Columns[4].CellType = comboState;
            }
            else
            {
                return;
            }

        }

        /// <summary>
        /// 增加财务组
        /// </summary>
        protected virtual void NewGroup()
        {
            try
            {
                int intGroupCode;

                intGroupCode = feeEmplFinanceGroup.GetMaxPkID();

                if (intGroupCode != -1 && intGroupCode != 0)
                {
                    fpGroup.AddRow();                            
                    fpGroup_Sheet1.Cells[fpGroup_Sheet1.ActiveRowIndex, 0].Text = intGroupCode.ToString();
                    fpGroup_Sheet1.Cells[fpGroup_Sheet1.ActiveRowIndex, 1].Text = "财务组" + intGroupCode.ToString();
                    fpGroup_Sheet1.SetActiveCell(fpGroup_Sheet1.ActiveRowIndex, 1);
                    
                }
                else if (intGroupCode == 0)
                {
                    int index = fpGroup_Sheet1.Rows.Count;
                    fpGroup_Sheet1.AddRows(index, 1);
                    fpGroup_Sheet1.Cells[0, 0].Text = intGroupCode.ToString();
                    fpGroup_Sheet1.Cells[0, 1].Text = "财务组" + intGroupCode.ToString();
                    fpGroup_Sheet1.SetActiveCell(0, 1);

                }
                fpGroup.ScrollBarMaxAlign = true;
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            this.fpGroup_Sheet1.Columns[0].Locked = true;


        }


        protected virtual void DeleteGroup()
        {
            if (fpGroupEmployee_Sheet1.Rows.Count == 0)
            {
                MessageBox.Show("该财务组内没有人员,请删除其他财务组！");
                return;
            }
            string GroupName=this.fpGroup_Sheet1.Cells[this.fpGroup_Sheet1.ActiveRowIndex,1].Text;
            if (MessageBox.Show("请确认删除" + GroupName + "？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction Tran = new Neusoft.FrameWork.Management.Transaction(feeEmplFinanceGroup.Connection);
            //Tran.BeginTransaction();

            feeEmplFinanceGroup.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                string delText;
                for (int i = 0; i < this.fpGroupEmployee_Sheet1.Rows.Count; i++)
                {
                    delText = fpGroupEmployee_Sheet1.GetText(i, 6);
                    if (feeEmplFinanceGroup.Delete(delText) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("当前财务组内人员删除失败！") + this.feeEmplFinanceGroup.Err);
                        return;
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("当前财务组内人员删除成功！") /*+ this.feeEmplFinanceGroup.Err*/);
                ChangeFinanceEmployee(1);
            }
            catch
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("当前财务组内人员删除失败！") );
            }
        }

        #region 废弃代码

        /// <summary>
        /// 删除财务组
        /// </summary>
        //protected virtual void DeleteGroup()
        //{
        //    int index;
        //    string delText;

        //    try
        //    {

        //        index = fpGroupEmployee_Sheet1.ActiveRow.Index;
        //        delText = fpGroupEmployee_Sheet1.GetText(index, 6);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("请选择财务组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    try
        //    {

        //        //删除前台数据
        //        //fpGroup.DelRow(fpGroup_Sheet1.ActiveRowIndex);

        //        for (int i = 0; i < this.fpGroupEmployee_Sheet1.Rows.Count; i++)
        //        { 

        //        }

        //        //删除后台数据
        //        if (feeEmplFinanceGroup.Delete(delText) != -1)
        //        {
        //            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("当前财务组内人员删除成功！") /*+ this.feeEmplFinanceGroup.Err*/);
        //            ChangeFinanceEmployee(1);
        //        }
        //        else
        //        {
        //            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("当前财务组内人员删除失败！") + this.feeEmplFinanceGroup.Err);
        //            return;
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message);
        //    }
        //}
        #endregion
        /// <summary>
        /// 保存
        /// </summary>
        protected virtual void SaveAll()
        {
            this.fpGroup.EditMode = false;
            if (fpGroupEmployee_Sheet1.Rows.Count < 1)
            {
                return;
            }

            //Neusoft.FrameWork.Management.Transaction Tran = new Neusoft.FrameWork.Management.Transaction(feeEmplFinanceGroup.Connection);
            try
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Tran.BeginTransaction();

                feeEmplFinanceGroup.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                string tempStr = string.Empty;
                //1保存新增加的记录
                if ((fpGroupEmployee_Sheet1.Rows.Count - countEmplFinance) > 0)
                {
                    //从新增加的行开始循环插入
                    for (int i = countEmplFinance, j = fpGroupEmployee_Sheet1.Rows.Count; i < j; i++)
                    {
                        feeFinanceGroup.ID = fpGroupEmployee_Sheet1.Cells[i, 0].Text;
                        feeFinanceGroup.Name = fpGroupEmployee_Sheet1.Cells[i, 1].Text;
                        feeFinanceGroup.Employee.ID = fpGroupEmployee_Sheet1.Cells[i, 2].Text;
                        feeFinanceGroup.Employee.Name = fpGroupEmployee_Sheet1.Cells[i, 3].Text;
                        tempStr = fpGroupEmployee_Sheet1.Cells[i, 4].Text;
                                                
                        //状态值转换
                        switch (tempStr)
                        {
                            case "有效":
                                feeFinanceGroup.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;
                                break;

                            case "停用":
                                feeFinanceGroup.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
                                break;

                            case "废弃":
                                feeFinanceGroup.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Ignore;
                                break;
                        }

                        feeFinanceGroup.SortID = 0;

                        feeFinanceGroup.PkID = fpGroupEmployee_Sheet1.GetText(i, 6);

                        //调用保存方法
                        if (feeEmplFinanceGroup.Insert(feeFinanceGroup) > 0)
                        {
                        }
                        else
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("增加当前财务组内人员失败！") + this.feeEmplFinanceGroup.Err);
                            return;
                        }

                    }
                }//1

                //2更新修改的记录
                if ((fpGroupEmployee_Sheet1.Rows.Count - countEmplFinance) == 0)
                {
                    //按照主键值循环更新修改记录
                    for (int i = 0, j = fpGroupEmployee_Sheet1.Rows.Count; i < j; i++)
                    {
                        feeFinanceGroup.ID = fpGroupEmployee_Sheet1.Cells[i, 0].Text;
                        feeFinanceGroup.Name = fpGroupEmployee_Sheet1.Cells[i, 1].Text;
                        feeFinanceGroup.Employee.ID = fpGroupEmployee_Sheet1.Cells[i, 2].Text;
                        feeFinanceGroup.Employee.Name = fpGroupEmployee_Sheet1.Cells[i, 3].Text;
                        tempStr = fpGroupEmployee_Sheet1.Cells[i, 4].Text;

                        //状态值转换
                        switch (tempStr)
                        {
                            case "有效":
                                feeFinanceGroup.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;
                                break;

                            case "停用":
                                feeFinanceGroup.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
                                break;

                            case "废弃":
                                feeFinanceGroup.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Ignore;
                                break;
                        }


                        feeFinanceGroup.SortID = Convert.ToInt32(fpGroupEmployee_Sheet1.GetText(i, 5));

                        feeFinanceGroup.PkID = fpGroupEmployee_Sheet1.GetText(i, 6);

                        //调用更新方法
                        if (feeEmplFinanceGroup.Update(feeFinanceGroup.PkID, feeFinanceGroup) > 0)
                        {
                        }
                        else
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新当前财务组内人员信息失败！") + this.feeEmplFinanceGroup.Err);
                            return;
                        }

                    }
                }//2
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("人员财务组信息保存成功！") + this.feeEmplFinanceGroup.Err);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Neusoft.FrameWork.Management.Language.Msg("人员财务组信息保存失败！") + this.feeEmplFinanceGroup.Err);
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
            }
            
        }

        #endregion
                
        #region 事件

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucFinanceGroup_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            //取得科室列表
            this.GetDept();
            //取得财务组列表
            this.GetFinanceGroup();
            //取得财务组内人员列表
            if (fpGroup_Sheet1.Rows.Count > 0)
            {
                ChangeFinanceEmployee(0);
            }
            else
            {
                //{8C1F1BED-7D98-46ef-B36F-5D37DC04A6B1} 当初始没有数据时，使用Rows.Clear() 会发生错误
                //fpGroupEmployee_Sheet1.Rows.Clear();
                this.fpGroupEmployee_Sheet1.Rows.Count = 0;
            }
        }

        /// <summary>
        /// 科室选择
        /// </summary>
        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbDepartment.Tag != null)
                {
                    this.GetDeptEmployee(this.cbDepartment.Tag.ToString());

                    fpEmployee_Sheet1.Columns[0].Width = 80;
                    fpEmployee_Sheet1.Columns[1].Width = 80;
                    fpEmployee_Sheet1.Columns[2].Visible = false;

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 财务组选择
        /// </summary>
        private void fpGroup_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            ChangeFinanceEmployee(1);
        }

        /// <summary>
        /// 双击鼠标增加当前财务组内人员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpEmployee_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                int ActiveFinance;//当前财务组行
                int ActiveEmployee;//当前人员行

                ActiveFinance = 0;
                ActiveEmployee = 0;

                //提取人员列表活动行索引
                if (fpEmployee_Sheet1.RowCount > 0)
                {
                    ActiveEmployee = fpEmployee_Sheet1.ActiveRow.Index;
                }
                else
                {
                    MessageBox.Show("当前人员列表中没有记录，请检查！");
                }

                //提取财务组列表活动行索引
                if (fpGroup_Sheet1.RowCount > 0)
                {
                    ActiveFinance = fpGroup_Sheet1.ActiveRow.Index;

                    if (ActiveFinance == null)
                    {
                        ActiveFinance = 1;
                    }
                }
                else
                {
                    MessageBox.Show("当前财务组列表中没有记录，请检查！");
                }


                feeFinanceGroup.Employee.ID = fpEmployee_Sheet1.Cells[ActiveEmployee, 0].Text.Trim().ToString();
                feeFinanceGroup.Employee.Name = fpEmployee_Sheet1.Cells[ActiveEmployee, 1].Text.Trim().ToString();

                feeFinanceGroup.ID = fpGroup_Sheet1.Cells[ActiveFinance, 0].Text.Trim().ToString();
                feeFinanceGroup.Name = fpGroup_Sheet1.Cells[ActiveFinance, 1].Text.Trim().ToString();

                string pkId = Convert.ToString(feeEmplFinanceGroup.GetMaxPkID());

                dtFinanceEmployee.Rows.Add(new object[] { feeFinanceGroup.ID, feeFinanceGroup.Name, feeFinanceGroup.Employee.ID, feeFinanceGroup.Employee.Name, "有效", "0", pkId });

                FarPoint.Win.Spread.CellType.ComboBoxCellType comboValidState = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

                comboValidState.Items = new String[] { "有效", "停用", "废弃" };

                fpGroupEmployee_Sheet1.Cells[dtFinanceEmployee.Rows.Count - 1, 4].CellType = comboValidState;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        #endregion

        private void fpGroup_EditModeOff(object sender, EventArgs e)
        {
            int rowIndex = this.fpGroup_Sheet1.ActiveRowIndex;
            if (this.fpGroup_Sheet1.ActiveColumnIndex == 1)
            {
                int count = this.fpGroupEmployee_Sheet1.Rows.Count;
                string groupName=this.fpGroup_Sheet1.Cells[rowIndex,1].Text;
                if (count> 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        this.fpGroupEmployee_Sheet1.Cells[i, 1].Text = groupName;
                    }
                }
            }
            
        }
               

        

       
    }
}

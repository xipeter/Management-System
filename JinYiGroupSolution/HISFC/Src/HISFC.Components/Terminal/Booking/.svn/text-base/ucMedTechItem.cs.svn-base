using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Terminal.Booking
{
    public partial class ucMedTechItem : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMedTechItem()
        {
            InitializeComponent();
        }

        #region 定义全局变量
        //定义变量存储非药品信息
        private DataTable UndrugTable = null;
        private DataView UndrugView = null;　
        //定义变量 存储科室预约项目的信息
        private DataTable DeptItemTable = null;
        private DataView DeptItemView = null;
        //定义业务层操纵类
        Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookMgr = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking();
        //
        Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private bool IsTextFocus = false;
        //定义下拉数据窗的内容
        //科室

        private ArrayList Deptlist = new ArrayList();
        private Neusoft.FrameWork.Public.ObjectHelper OperListHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //系统类别
        private ArrayList Classlist = new ArrayList();
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PrintDialog printDialog1;
        /// <summary>
        /// 操作员信息
        /// </summary>
        //private Neusoft.HISFC.BizLogic.Manager.Person controlMgr = new Neusoft.HISFC.BizLogic.Manager.Person();
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbQuery;
        Neusoft.FrameWork.Management.DataBaseManger dbMgr = new Neusoft.FrameWork.Management.DataBaseManger();
        //private Neusoft.HISFC.Models.RADT.Person p = new Neusoft.HISFC.Models.RADT.Person();
        private ArrayList alALL = new ArrayList();
        Neusoft.HISFC.Models.Base.Employee var = null;
        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("删除", "删除", 0, true, false, null);
            toolBarService.AddToolButton("查找", "查找", 1, true, false, null);
            toolBarService.AddToolButton("取消组合", "取消组合", 4, true, false, null);
            return toolBarService;
        }
        #endregion

        #region 工具栏增加按钮单击事件
        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "删除":
                    this.DeleteInfo();
                    break;
                default:
                    break;
            }
        }
        #endregion


        #endregion

        #region 增加，修改，删除，保存  的操作
        public override int Save(object sender, object neuObject)
        {
             SaveInfo();
             return 1;
        }
        /// <summary>
        /// 保存增加和修改的数据
        /// </summary>
        protected  void SaveInfo()
        {
            
            //原来没有科室,只能维护自己科室的项目,暂时增加一个...
            string strDept = var.Dept.ID;
            if (this.cmbDept.Tag != null)
            {
                strDept = this.cmbDept.Tag.ToString();
            }
            //Neusoft.HISFC.BizLogic.MedTech.MedTech item = new Neusoft.HISFC.BizLogic.MedTech.MedTech();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction Addtrans = new Neusoft.FrameWork.Management.Transaction(dbMgr.Connection);
            //Addtrans.BeginTransaction();
            feeMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            bookMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                this.fpSpread2.StopCellEditing();
                //获取增加的科室项目的信息

                ArrayList list = GetInfo();
                if (list == null || list.Count <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("没有获得科室预约项目信息");
                    return;
                }

                //保存增加的科室项目的信息
                bool Result = true;
                foreach (Neusoft.HISFC.Models.Terminal.MedTechItem info in list)
                {
                    info.ItemExtend.Dept.ID = strDept;
                    //向科室项目表中插入新的记录 MET_TEC_DEPTITEM
                    if (bookMgr.UpdateMedTechItem(info) <= 0)
                    {
                        //向科室项目表中更新新的记录 MET_TEC_DEPTITEM
                        if (bookMgr.InsertMedTechItem(info) <= 0)
                        {
                            Result = false;
                            break;
                        }
                    }
                }
                if (Result)
                {
                    //提交数据
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show("保存成功");
                }
                else
                {
                    //回退信息
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存科室项目信息失败" + bookMgr.Err);
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(ex.Message);
            }
            this.LockFp();
        }

        /// <summary>
        /// 增加一行数据到科室项目预约窗口
        /// </summary>
        private void AddDataInfo()
        {
            //判断该项目是否已经添加。
            ArrayList list = GetInfo();
            if (list != null && list.Count > 0)
            {
                foreach (Neusoft.HISFC.Models.Terminal.MedTechItem oninfo in list)
                {
                    if (oninfo.Item.ID == this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.DeptID].Text)
                    {
                        MessageBox.Show(oninfo.Item.Name + "已经在该科室预约项目表中了,请直接维护即可");
                        return;
                    }
                }
            }
            string zt = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, GetColumnKey("标识")].Text;
            if (zt == "1")
            {
                try
                {
                    if (fpSpread1_Sheet1.RowCount < 1)
                    {
                        return; //如果没有数据返回空 
                    }
                    Neusoft.HISFC.Models.Fee.Item.Undrug feeinfo = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                    Neusoft.HISFC.Models.Terminal.MedTechItem deptinfo = new Neusoft.HISFC.Models.Terminal.MedTechItem();
                    //					//从数据库获取要修改的信息
                    //					feeinfo = item.GetItemAll(fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex,GetColumnKey("项目代码")].Text);
                    //					if(feeinfo ==null)
                    //					{
                    //						MessageBox.Show("获取非药品信息出错");
                    //						return ;
                    //					}
                    feeinfo.ID = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, GetColumnKey("项目代码")].Text;
                    feeinfo.Name = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, GetColumnKey("项目名称")].Text;
                    Neusoft.HISFC.Models.Terminal.MedTechItem tail = new Neusoft.HISFC.Models.Terminal.MedTechItem();
                    //p = controlMgr.GetEmployeeInfo(controlMgr.Operator.ID);
                    tail.Item.ID = feeinfo.ID; //非药品编码
                    tail.Item.Name = feeinfo.Name;//非药品名称
                    tail.ItemExtend.UnitFlag = "明细"; //组套还是明细
                    tail.ItemExtend.Dept.ID = var.Dept.ID;  //科室代码
                    tail.Item.SysClass.ID = feeinfo.SysClass.ID;//feeinfo.SysClass.ID;  //系统类别
                    tail.ItemExtend.ReasonableFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(feeinfo.IsConsent).ToString();//知情同意书
                    tail.Item.Notice = feeinfo.Notice;//注意事项
                    tail.Item.Oper.ID = var.ID;//操作员
                    //增加
                    DataRow row = DeptItemTable.NewRow();
                    //填充数据
                    SetNewRow(tail, row);
                    //增加到表中
                    DeptItemTable.Rows.Add(row);
                    //保存更改
                    DeptItemTable.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (zt == "2")
            {
                try
                {
                    if (fpSpread1_Sheet1.RowCount < 1)
                    {
                        return; //如果没有数据返回空 
                    }
                    Neusoft.HISFC.Models.Fee.Item.Undrug ztinfo = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                    //Neusoft.HISFC.BizLogic.Manager.ComGroup feeMgr = new Neusoft.HISFC.BizLogic.Manager.ComGroup();
                    Neusoft.HISFC.Models.Terminal.MedTechItem deptinfo = new Neusoft.HISFC.Models.Terminal.MedTechItem();
                    //从数据库获取要修改的信息
                    ztinfo = feeMgr.GetItem(fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, GetColumnKey("项目代码")].Text);
                    if (ztinfo == null)
                    {
                        MessageBox.Show("获取非药品信息出错");
                        return;
                    }
                    Neusoft.HISFC.Models.Terminal.MedTechItem tail = new Neusoft.HISFC.Models.Terminal.MedTechItem();
                    //p = this.controlMgr.GetEmployeeInfo(controlMgr.Operator.ID);
                    tail.Item.ID = ztinfo.ID; //非药品编码
                    tail.Item.Name = ztinfo.Name;//非药品名称
                    tail.ItemExtend.UnitFlag = "组套"; //组套还是明细
                    tail.ItemExtend.Dept.ID = var.Dept.ID;  //科室代码
                    tail.Item.SysClass.ID = ztinfo.SysClass.ID;  //系统类别
                    //					tail.ItemExtend.ReasonableFlag = this.getStringValue(ztinfo.);//知情同意书
                    tail.Item.Notice = ztinfo.Notice;//注意事项
                    tail.Item.Oper.ID = var.ID;//操作员
                    //增加
                    DataRow row = DeptItemTable.NewRow();
                    //填充数据
                    SetNewRow(tail, row);
                    //增加到表中
                    DeptItemTable.Rows.Add(row);
                    //保存更改
                    DeptItemTable.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.LockFp();
        }

        /// <summary>
        /// 删除所选择的行
        /// </summary>
        private void DeleteInfo()
        {
            try
            {
                ArrayList list = this.GetDelInfo();
                if (list == null)  //数据库中没有的行
                {
                    fpSpread2_Sheet1.Rows.Remove(this.fpSpread2_Sheet1.ActiveRowIndex, 1);
                }
                else  //数据库中存在的
                {
                    //提示用户永久性删除
                    string message = "删除后将不能恢复，您确定要删除吗？";
                    string caption = "提示：";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult re;

                    re = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (re == DialogResult.Yes)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        //Neusoft.FrameWork.Management.Transaction Addtrans = new Neusoft.FrameWork.Management.Transaction(dbMgr.Connection);
                        //Addtrans.BeginTransaction();
                        bookMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        try
                        {
                            bool result = true;
                            foreach (Neusoft.HISFC.Models.Terminal.MedTechItem info in list)
                            {
                                if (bookMgr.DeleteMedTechItem(info.ItemExtend.Dept.ID, info.Item.ID) <= 0)
                                {
                                    result = false;
                                    break;
                                }
                            }
                            if (result)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.Commit();
                                //{0E428A94-08F0-4b88-B78C-41C3490718C7}
                                fpSpread2.EditMode = false;
                                fpSpread2_Sheet1.Rows.Remove(this.fpSpread2_Sheet1.ActiveRowIndex, 1);
                            }
                            else
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("数据库删除操作失败");
                            }
                        }
                        catch (Exception ex)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DeptItemTable.AcceptChanges();
            this.LockFp();
        }


        /// <summary>
        /// 找到预约项目表中需要删除数据的信息
        /// </summary>
        /// <param name="iteminfo"></param>
        /// <returns></returns>
        private ArrayList GetDelInfo()
        {
            ArrayList ItemList = new ArrayList();
            if (DeptItemTable == null)
            {
                return null;
            }
            Neusoft.HISFC.Models.Terminal.MedTechItem item = new Neusoft.HISFC.Models.Terminal.MedTechItem();

            item.ItemExtend.Dept.ID = this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.DeptID].Text;
            item.Item.ID = this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.ItemID].Text;
            Neusoft.HISFC.Models.Terminal.MedTechItem info = bookMgr.GetMedTechItem(var.Dept.ID, item.Item.ID);
            if (info.ItemExtend.Dept.ID == null)
            {
                return null;
            }
            else
            {
                ItemList.Add(item);
            }
            return ItemList;
        }


        /// <summary>
        /// 得到到要科室预约项目的信息 返回列表 准备插入操作
        /// </summary>
        /// <returns></returns>
        private ArrayList GetInfo()
        {
            ArrayList ItemList = new ArrayList();
            if (DeptItemTable == null)
            {
                return null;
            }
            Neusoft.HISFC.Models.Terminal.MedTechItem item = null;
            //循环取数据 
            if (this.fpSpread2_Sheet1.RowCount <= 0) return null;
            for (int k = 0; k < this.fpSpread2_Sheet1.RowCount; k++)
            {
                item = new Neusoft.HISFC.Models.Terminal.MedTechItem();
                item.ItemExtend.Dept.ID = var.Dept.ID;
                item.Item.ID = this.fpSpread2_Sheet1.Cells[k, (int)Cols.ItemID].Text;//项目代码	
                item.Item.Name = this.fpSpread2_Sheet1.Cells[k, (int)Cols.ItemName].Text;//项目名称
                item.Item.SysClass.ID = "";//this.GetSysClassFromName(this.fpSpread2_Sheet1.Cells[k,(int)Cols.SysClass].Text);//系统类别
                item.ItemExtend.UnitFlag = this.getUnitIDByName(this.fpSpread2_Sheet1.Cells[k, (int)Cols.UnitFlag].Text);//单位标识
                item.ItemExtend.BookLocate = this.fpSpread2_Sheet1.Cells[k, (int)Cols.BookLocate].Text;//预约地
                item.ItemExtend.BookTime = this.fpSpread2_Sheet1.Cells[k, (int)Cols.BookTime].Text;//预约固定时间
                item.ItemExtend.ExecuteLocate = this.fpSpread2_Sheet1.Cells[k, (int)Cols.ExecuteLocate].Text;//执行地点
                item.ItemExtend.ReportTime = this.fpSpread2_Sheet1.Cells[k, (int)Cols.ReportTime].Text;//取报告时间
                item.ItemExtend.HurtFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread2_Sheet1.Cells[k, (int)Cols.HurtFlag].Text.ToUpper()).ToString();//有创/无创
                item.ItemExtend.SelfBookFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread2_Sheet1.Cells[k, (int)Cols.SelfBookFlag].Text.ToUpper()).ToString();//是否科内预约
                item.ItemExtend.ReasonableFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread2_Sheet1.Cells[k, (int)Cols.ReasonableFlag].Text.ToUpper()).ToString();//知情同意书
                item.ItemExtend.Speciality = this.fpSpread2_Sheet1.Cells[k, (int)Cols.Speciality].Text;//所属专业
                item.ItemExtend.ClinicMeaning = this.fpSpread2_Sheet1.Cells[k, (int)Cols.ClinicMeaning].Text;//临床意义
                item.ItemExtend.SimpleKind = this.fpSpread2_Sheet1.Cells[k, (int)Cols.SimpleKind].Text;//标本
                string strway = "";
                if (this.fpSpread2_Sheet1.Cells[k, (int)Cols.SimpleWay].Tag == null)
                {
                    strway = "";
                }
                else
                {
                    strway = this.fpSpread2_Sheet1.Cells[k, (int)Cols.SimpleWay].Tag.ToString();
                }
                item.ItemExtend.SimpleWay = strway;//采样方法
                item.ItemExtend.SimpleUnit = this.fpSpread2_Sheet1.Cells[k, (int)Cols.SimpleUnit].Text;//标本单位
                item.ItemExtend.SimpleQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread2_Sheet1.Cells[k, (int)Cols.SimpleQty].Text);//标本量
                item.ItemExtend.Container = this.fpSpread2_Sheet1.Cells[k, (int)Cols.Container].Text;//容器
                item.ItemExtend.Scope = this.fpSpread2_Sheet1.Cells[k, (int)Cols.Scope].Text;//正常值范围
                item.ItemExtend.MachineType = this.fpSpread2_Sheet1.Cells[k, (int)Cols.MachineType].Text;//设备类型
                item.ItemExtend.BloodWay = this.fpSpread2_Sheet1.Cells[k, (int)Cols.BloodWay].Text;//抽血方法
                item.Item.Notice = this.fpSpread2_Sheet1.Cells[k, (int)Cols.Notice].Text;//注意事项
                item.Item.Oper.ID = this.fpSpread2_Sheet1.Cells[k, (int)Cols.OperID].Text;//操作员
                item.Item.Oper.OperTime = this.dateTimePicker1.Value;//操作日期

                ItemList.Add(item);
            }
            return ItemList;
        }
        #endregion
        #region 枚举
        private enum Cols
        {
            DeptID, //科室0
            ItemID, //项目编码1
            ItemName,//项目名称2
            SysClass, //系统类别3
            UnitFlag,//药品/非药品/复合项目4
            BookLocate,//预约地点5
            BookTime,//预约时间6
            ExecuteLocate,//执行地点7
            ReportTime,//取报告时间8
            HurtFlag,//有创/无创 9
            SelfBookFlag,//是否科内预约10
            ReasonableFlag,//知情同意书11
            Speciality,//所属专业 12
            ClinicMeaning,//临床意义 13
            SimpleKind,//标本 14
            SimpleWay,//采样方法 15
            SimpleUnit,//标本单位 16
            SimpleQty,//标本量 17
            Container,//容器 18
            Scope,//正常值范围 19
            MachineType,//设备类型 20
            BloodWay,//抽血方法 21
            Notice,//注意事项 22
            OperID,//操作员 23
            OperTime//操作日期 24
        }
         #endregion 
        #region  下拉列表的生成及其事件

        //下拉列表
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitInfo()
        {
            try
            {
                //设置下拉列表
                this.initList();
                fpSpread2_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
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
                //Neusoft.HISFC.BizProcess.Integrate.Manager dept = new Neusoft.HISFC.BizLogic.Manager.Department();
                this.fpSpread2.SelectNone = true;
                //获取科室
                ArrayList al = this.managerMgr.GetDepartment();
                //				this.fpSpread2.SetColumnList(this.fpSpread2_Sheet1,0,al);   //用于下拉框的生成
                //				this.fpSpread2.SetColumnList(this.fpSpread2_Sheet1,1,al);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 按键响应处理
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int fpSpread2_KeyEnter(Keys key)
        {
            if (key == Keys.Enter)
            {
                //回车
                if (this.fpSpread2.ContainsFocus)
                {
                    int i = this.fpSpread2_Sheet1.ActiveColumnIndex;
                    if (i == 0)
                    {
                        ProcessDept();
                    }
                    else if (i == 2)
                    {
                        if (fpSpread2_Sheet1.ActiveRowIndex < fpSpread2_Sheet1.Rows.Count - 1)
                        {
                            fpSpread2_Sheet1.SetActiveCell(fpSpread2_Sheet1.ActiveRowIndex + 1, 0);
                        }
                        else
                        {
                            //增加一行
                            //							this.AddRow();
                        }
                    }
                }
            }
            else if (key == Keys.Up)
            {

            }
            else if (key == Keys.Down)
            {

            }
            else if (key == Keys.Escape)
            {

            }
            return 0;
        }
        private int fpSpread2_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
        {
            this.ProcessDept();
            return 0;
        }

        private int ProcessDept()
        {
            int CurrentRow = fpSpread2_Sheet1.ActiveRowIndex;
            if (CurrentRow < 0) return 0;

            if (fpSpread2_Sheet1.ActiveColumnIndex == 0)
            {
                Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpSpread2.getCurrentList(this.fpSpread2_Sheet1, 0);
                //获取选中的信息
                Neusoft.FrameWork.Models.NeuObject item = null;
                int rtn = listBox.GetSelectedItem(out item);
                if (item == null) return -1;
                //科室编码
                fpSpread2_Sheet1.ActiveCell.Text = item.ID;
                fpSpread2_Sheet1.SetActiveCell(fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.SysClass);
                return 0;
            }

            else if (fpSpread2_Sheet1.ActiveColumnIndex == 3)
            {
                return 0;
            }
            return 0;
        }
        #endregion

        #region 打开窗口的事件
        private void frmTecDeptItem_Load(object sender, System.EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
            Application.DoEvents();
            this.fpSpread2_Sheet1.DataAutoSizeColumns = false;
            var = (Neusoft.HISFC.Models.Base.Employee)dbMgr.Operator;
            //定义响应按键事件
            fpSpread2.KeyEnter += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.keyDown(fpSpread2_KeyEnter);
            fpSpread2.SetItem += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.setItem(fpSpread2_SetItem);
            fpSpread2.ShowListWhenOfFocus = true;
            InitInfo();
            //初始化非药品列表
            loadUndrug();
            //初始化科室表
            loadDeptItem();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            retrieveDeptItemAll();
            this.InitComb();

            this.LockFp();
            this.initList();
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void loadUndrug()
        {
            try
            {
                UndrugTable = new DataTable();
                System.Type dtStr = System.Type.GetType("System.String");
                System.Type dtDec = System.Type.GetType("System.Decimal");
                System.Type dtDTime = System.Type.GetType("System.DateTime");
                System.Type dtBool = System.Type.GetType("System.Boolean");
                UndrugTable = new DataTable();
                UndrugTable.Columns.AddRange(new DataColumn[] {
																   new DataColumn( "项目代码",  dtStr ),		//0
																   new DataColumn("项目名称",    dtStr),		//1
																   new DataColumn("拼音码",  dtStr),		//2
																   new DataColumn("五笔",	 dtStr),		//3
																   new DataColumn("输入码",	 dtStr)	,	//4
																   new DataColumn("标识",dtStr)
				});

                //设置主键为编码
                //				CreateKeys(UndrugTable);
                UndrugView = new DataView(UndrugTable);
                this.fpSpread1_Sheet1.DataSource = UndrugView;
                this.LockFp();

                ArrayList alReturn = new ArrayList();//返回的非药品信息;

                alReturn = this.bookMgr.GetAllList("MEDTECHITEM");
                //循环插入信息
                foreach (Neusoft.HISFC.Models.Base.Const obj in alReturn)
                {
                    if (obj.IsValid)
                    {
                        DataRow row = UndrugTable.NewRow();
                        SetRow(obj, row);
                        UndrugTable.Rows.Add(row);
                    }
                }
                alALL.AddRange(alReturn);

                UndrugTable.AcceptChanges(); //保存更改
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.fpSpread1_Sheet1.Columns[(int)Cols.DeptID].Width = 80F;
            this.fpSpread1_Sheet1.Columns[(int)Cols.ItemName].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)Cols.SysClass].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)Cols.UnitFlag].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)Cols.BookLocate].Visible = false;
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void loadDeptItem()
        {
            try
            {
                DeptItemTable = new DataTable();
                System.Type dtStr = System.Type.GetType("System.String");
                System.Type dtDec = System.Type.GetType("System.Decimal");
                System.Type dtDTime = System.Type.GetType("System.DateTime");
                System.Type dtBool = System.Type.GetType("System.Boolean");
                DeptItemTable = new DataTable();
                DeptItemTable.Columns.AddRange(new DataColumn[] {
																	 new DataColumn("科室代码",  dtStr ),		//0
																	 new DataColumn("项目代码",    dtStr),		//1
																	 new DataColumn("项目名称",  dtStr),		//2
																	 new DataColumn("系统类别",	 dtStr),		//3
																	 new DataColumn("单位标识",	 dtStr),		//4
																	 new DataColumn("预约地",  dtStr),		//5
																	 new DataColumn("预约固定时间",  dtStr),		//6
																	 new DataColumn("执行地点",  dtStr) ,		//7
																	 new DataColumn("取报告时间",  dtStr) ,		//8
																	 new DataColumn("有创/无创",  dtStr), 		//9
																	 new DataColumn("是否科内预约",  dtStr) ,		//10
																	 new DataColumn("知情同意书",  dtStr) ,		//11
																	 new DataColumn("所属专业",  dtStr) ,		//12
																	 new DataColumn("临床意义",  dtStr) ,		//13
																	 new DataColumn("标本",  dtStr) ,		//14
																	 new DataColumn("采样方法",  dtStr) ,		//15
																	 new DataColumn("标本单位",  dtStr) ,		//16
																	 new DataColumn("标本量",  dtStr) ,		//17
																	 new DataColumn("容器",  dtStr), //18
																	 new DataColumn("正常值范围",  dtStr),//19
																	 new DataColumn("设备类型",  dtStr),//20
																	 new DataColumn("抽血方法",  dtStr),//21
																	 new DataColumn("注意事项",  dtStr) ,		//22
																	 new DataColumn("操作员",  dtStr) ,		//23
																	 new DataColumn("操作日期",  dtStr)		//24
																   
																 });

                //设置主键为编码
                //				CreateKeys(DeptItemTable);
                DeptItemView = new DataView(DeptItemTable);
                this.fpSpread2_Sheet1.DataSource = DeptItemView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        /// <summary>
        /// 填充信息
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="row"></param>

        /// <summary>
        /// 将预约项目表 根据科室 刷新到窗口中
        /// </summary>
        private void retrieveDeptItemAll()
        {
            if (this.fpSpread2_Sheet1.RowCount > 0)
            {
                this.fpSpread2_Sheet1.RemoveRows(0, this.fpSpread2_Sheet1.RowCount);
            }
            //Neusoft.HISFC.BizLogic.Manager.Person controlMgr = new Neusoft.HISFC.BizLogic.Manager.Person();
            //Neusoft.HISFC.Models.RADT.Person p = controlMgr.GetEmployeeInfo(controlMgr.Operator.ID);
            //Neusoft.HISFC.BizLogic.MedTech.MedTech dp = new Neusoft.HISFC.BizLogic.MedTech.MedTech();
            //Neusoft.HISFC.BizLogic.Manager.Constant controlMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList allInfo = new ArrayList();
            string strdept = var.Dept.ID;
            if (this.cmbDept.Tag != null && this.cmbDept.Tag.ToString() != "")
            {
                strdept = this.cmbDept.Tag.ToString();
            }
            allInfo = this.bookMgr.QueryMedTechItem(strdept);

            foreach (Neusoft.HISFC.Models.Terminal.MedTechItem info in allInfo)
            {
                if (info.ItemExtend.Dept.ID == null)
                {
                    return;
                }
                else
                {
                    this.fpSpread2_Sheet1.Rows.Add(0, 1);
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.DeptID].Text = info.ItemExtend.Dept.ID;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.ItemID].Text = info.Item.ID;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.ItemName].Text = info.Item.Name;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.SysClass].Text = info.Item.SysClass.Name;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.UnitFlag].Text = this.getUnitNameById(info.ItemExtend.UnitFlag);
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.BookLocate].Text = info.ItemExtend.BookLocate;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.BookTime].Text = info.ItemExtend.BookTime;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.ExecuteLocate].Text = info.ItemExtend.ExecuteLocate;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.ReportTime].Text = info.ItemExtend.ReportTime;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.HurtFlag].Value = Neusoft.FrameWork.Function.NConvert.ToBoolean(info.ItemExtend.HurtFlag);
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.SelfBookFlag].Value = Neusoft.FrameWork.Function.NConvert.ToBoolean(info.ItemExtend.SelfBookFlag);
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.ReasonableFlag].Value = Neusoft.FrameWork.Function.NConvert.ToBoolean(info.ItemExtend.ReasonableFlag);
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.Speciality].Text = info.ItemExtend.Speciality;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.ClinicMeaning].Text = info.ItemExtend.ClinicMeaning;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.SimpleKind].Text = info.ItemExtend.SimpleKind;
                    string strWay = "";
                    if (info.ItemExtend.SimpleWay == null || info.ItemExtend.SimpleWay == "")
                    {
                        strWay = "";
                    }
                    else
                    {
                        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                        obj = bookMgr.GetConstant("USAGE", info.ItemExtend.SimpleWay);
                        if (obj == null || obj.Name == null || obj.Name == "")
                        {
                            strWay = "";
                        }
                        else
                        {
                            strWay = obj.Name;
                        }
                    }
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.SimpleWay].Text = strWay;//采样方法
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.SimpleUnit].Text = info.ItemExtend.SimpleUnit;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.SimpleQty].Text = info.ItemExtend.SimpleQty.ToString();
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.Container].Text = info.ItemExtend.Container;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.Scope].Text = info.ItemExtend.Scope;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.MachineType].Text = info.ItemExtend.MachineType;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.BloodWay].Text = info.ItemExtend.BloodWay;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.Notice].Text = info.Item.Notice;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.OperID].Text = info.Item.Oper.ID;
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, (int)Cols.OperTime].Text = dbMgr.GetDateTimeFromSysDateTime().ToString();
                }
            }
        }
        #region 填充左面信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="row"></param>
        private void SetRow(Neusoft.HISFC.Models.Fee.Item.Undrug obj, DataRow row)
        {
            row["项目代码"] = obj.ID;					//0                                             
            row["项目名称"] = obj.Name;					//1
            row["拼音码"] = obj.SpellCode;			//2											
            row["五笔"] = obj.WBCode;				//3											
            row["输入码"] = obj.UserCode;			//4
            row["标识"] = "1";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="row"></param>
        private void SetRow(Neusoft.FrameWork.Models.NeuObject obj, DataRow row)
        {
            row["项目代码"] = obj.ID;					//0                                             
            row["项目名称"] = obj.Name;					//1
            row["拼音码"] = obj.User01;			//2											
            row["五笔"] = obj.User02;				//3											
            row["输入码"] = obj.User03;			//4
            row["标识"] = "1";
        }
        /// <summary>
        /// 组套
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="row"></param>
        private void SetRowZt(Neusoft.HISFC.Models.Base.Group obj, DataRow row)
        {
            row["项目代码"] = obj.ID;					//0                                             
            row["项目名称"] = obj.Name;					//1
            row["拼音码"] = obj.SpellCode;			//2											
            row["五笔"] = obj.WBCode;				//3											
            row["输入码"] = obj.UserCode;			//4		
            row["标识"] = "2";
        }
        #endregion

        #region 填充右面窗口信息
        /// <summary>
        /// 填充 科室项目信息
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="row"></param>
        private void SetNewRow(Neusoft.HISFC.Models.Terminal.MedTechItem obj, DataRow row)
        {
            row["科室代码"] = obj.ItemExtend.Dept.ID;
            row["项目代码"] = obj.Item.ID;			//0                                             
            row["项目名称"] = obj.Item.Name;				//1																	
            row["单位标识"] = obj.ItemExtend.UnitFlag;			//2
            row["系统类别"] = obj.Item.SysClass.Name;			//3
            row["知情同意书"] = Neusoft.FrameWork.Function.NConvert.ToBoolean(obj.ItemExtend.ReasonableFlag);			//4
            row["注意事项"] = obj.Item.Notice;			//5
            row["操作员"] = obj.Item.Oper.ID;			//6
            row["操作日期"] = System.DateTime.Now;			//7
        }
        #endregion

        /// <summary>
        /// 初始化下拉控件
        /// </summary>
        private void InitComb()
        {
            //科室
            //Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();

            ArrayList al = managerMgr.GetDepartment();
            if (al == null) al = new ArrayList();

            this.cmbDept.AddItems(al);
            //this.cmbDept.isItemOnly = true;

            this.cmbDept.Tag = var.Dept.ID;
            this.cmbDept.Text = var.Dept.Name;

            if (this.Tag == null || this.Tag.ToString() != "ALL")
            {
                this.cmbDept.Enabled = false;
            }

            if (this.alALL.Count > 0)
            {
                this.cmbQuery.AddItems(alALL);
            }
        }
        #endregion

        #region 对窗口的操作事件的处理
        /// <summary>
        /// 左面窗口的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //			fpSpread1_Sheet1.SetActiveCell(1,0);
            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex,
                this.fpSpread1_Sheet1.ActiveColumnIndex);
        }
        /// <summary>
        /// 定义双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex,
                this.fpSpread1_Sheet1.ActiveColumnIndex);
            try
            {
                //增加一行数据到科室预约项目窗口
                AddDataInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        /// <summary>
        /// 设置快捷键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            int AltKey = Keys.Alt.GetHashCode();
            if (keyData.GetHashCode() == AltKey + Keys.S.GetHashCode())
            {
                //保存
                SaveInfo();
                //				retrieveDeptItemAll();
            }

            if (keyData.GetHashCode() == AltKey + Keys.A.GetHashCode())
            {
                //删除
                DeleteInfo();
            }

            if (keyData.GetHashCode() == AltKey + Keys.X.GetHashCode())
            {
                //退出
                //this.Close();
            }
            return base.ProcessDialogKey(keyData);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!IsTextFocus) //查询框没有获得焦点 
            {
                if (keyData.GetHashCode() == Keys.Enter.GetHashCode())
                {
                    //回车操作 
                    if (fpSpread2_Sheet1.Rows.Count > 0)
                    {
                        //当前活动行
                        int i = fpSpread2_Sheet1.ActiveRowIndex;
                        int j = fpSpread2_Sheet1.ActiveColumnIndex;
                        while ((j + 1 <= fpSpread2_Sheet1.ColumnCount - 1) && !this.fpSpread2_Sheet1.Columns[j + 1].Visible)
                        {
                            j++;
                        }
                        if (j + 1 <= fpSpread2_Sheet1.ColumnCount - 1)
                        {
                            //不是最后一列 则向后移动一格
                            fpSpread2_Sheet1.SetActiveCell(i, j + 1);
                        }
                        else if (i < fpSpread2_Sheet1.Rows.Count)
                        {
                            //已经是最后一格  如果不是最后一行 则跳到下一行
                            fpSpread2_Sheet1.SetActiveCell(i + 1, 5);
                        }
                        else
                        {
                            this.fpSpread2_Sheet1.SetActiveCell(i, j);
                        }
                    }
                }
                else if (keyData.GetHashCode() == Keys.Space.GetHashCode())
                {
                    if (fpSpread2_Sheet1.ActiveColumnIndex == 20)
                    {
                        int m = this.fpSpread2_Sheet1.ActiveRowIndex;
                        Neusoft.FrameWork.Models.NeuObject neuObj = new Neusoft.FrameWork.Models.NeuObject();
                        if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(bookMgr.GetAllList("MACHINETYPE"), ref neuObj) == 1)
                        {
                            this.fpSpread2_Sheet1.SetValue(m, 20, neuObj.Name);
                        }
                    }
                    else if (fpSpread2_Sheet1.ActiveColumnIndex == 15)
                    {
                        int m = this.fpSpread2_Sheet1.ActiveRowIndex;
                        Neusoft.FrameWork.Models.NeuObject neuObj = new Neusoft.FrameWork.Models.NeuObject();
                        if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(bookMgr.GetAllList("USAGE"), ref neuObj) == 1)
                        {
                            this.fpSpread2_Sheet1.SetValue(m, 15, neuObj.Name);
                            this.fpSpread2_Sheet1.Cells[m, (int)Cols.SimpleWay].Tag = neuObj.ID;
                        }
                    }
                    else if (fpSpread2_Sheet1.ActiveColumnIndex == 22)
                    {
                        int m = this.fpSpread2_Sheet1.ActiveRowIndex;
                        Neusoft.FrameWork.Models.NeuObject neuObj = new Neusoft.FrameWork.Models.NeuObject();
                        if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(bookMgr.GetAllList("UNDRUGEXTENDMARK"), ref neuObj) == 1)
                        {
                            FarPoint.Win.Spread.CellType.TextCellType text3 = new FarPoint.Win.Spread.CellType.TextCellType();
                            text3.Multiline = true;
                            this.fpSpread2_Sheet1.Columns[(int)Cols.Notice].CellType = text3;
                            this.fpSpread2_Sheet1.SetValue(m, 22, this.bookMgr.GetConstant("UNDRUGEXTENDMARK", neuObj.ID).Memo);
                        }
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void fpSpread2_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
        }
        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {

        }

        /// <summary>
        /// 科室的转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.retrieveDeptItemAll();
        }
        #endregion

        #region 其他公共定义
        /// <summary>
        /// 查询主键列位置
        /// </summary>
        /// <returns></returns>
        private int GetColumnKey(string str)
        {
            foreach (FarPoint.Win.Spread.Column col in this.fpSpread1_Sheet1.Columns)
            {
                if (col.Label == str)
                {
                    return col.Index;
                }
            }
            return 0;
        }

        /// <summary>
        /// 设置主键为编码
        /// </summary>
        private void CreateKeys(DataTable table)
        {
            DataColumn[] keys = new DataColumn[] { table.Columns["项目代码"] };
            table.PrimaryKey = keys;
        }

        /// <summary>
        /// 调整列宽
        /// </summary>
        private void LockFp()
        {
            FarPoint.Win.Spread.CellType.TextCellType txttype = new FarPoint.Win.Spread.CellType.TextCellType();
            txttype.Multiline = true;
            FarPoint.Win.Spread.CellType.CheckBoxCellType cbxtype = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numtype = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            txttype.ReadOnly = true;
            this.fpSpread2_Sheet1.Columns[(int)Cols.DeptID].CellType = txttype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.ItemID].CellType = txttype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.ItemName].CellType = txttype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.SysClass].CellType = txttype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.UnitFlag].CellType = txttype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.SysClass].Visible = false;
            this.fpSpread2_Sheet1.Columns[(int)Cols.UnitFlag].Visible = false;
            this.fpSpread2_Sheet1.Columns[(int)Cols.OperID].CellType = txttype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.OperTime].CellType = txttype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.HurtFlag].CellType = cbxtype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.SelfBookFlag].CellType = cbxtype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.ReasonableFlag].CellType = cbxtype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.SimpleWay].CellType = txttype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.SimpleQty].CellType = numtype;
            this.fpSpread2_Sheet1.Columns[(int)Cols.DeptID].Visible = false;	//科室代码
            this.fpSpread2_Sheet1.Columns[(int)Cols.ItemID].Visible = false; //项目代码
            //this.fpSpread2_Sheet1.Columns[(int)Cols.ItemName].Visible = false;//项目名称
            this.fpSpread2_Sheet1.Columns[(int)Cols.UnitFlag].Visible = false;  //单位标识
            this.fpSpread2_Sheet1.Columns[(int)Cols.OperID].Visible = false; //操作员
            this.fpSpread2_Sheet1.Columns[(int)Cols.OperTime].Visible = false; //操作时间

        }
        /// <summary>
        /// 对数据库中已经有数据的进行检索
        /// </summary>
        private Neusoft.HISFC.Models.Terminal.MedTechItem find(string deptcode, string itemcode)
        {
            try
            {
                Neusoft.HISFC.Models.Terminal.MedTechItem info = bookMgr.GetMedTechItem(deptcode, itemcode);
                if (info.ItemExtend.Dept.ID == null)
                {
                    return null;
                }
                else
                {
                    return info;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 定义数组用来放置科室预约项目记录信息
        /// </summary>
        private ArrayList deptItemInfo = new ArrayList();
        public ArrayList DeptItemInfo
        {
            get
            {
                return this.deptItemInfo;
            }
            set
            {
                this.deptItemInfo = value;
            }
        }

        ///// <summary>
        ///// CheckBox中对象值的转换。
        ///// </summary>
        //private string getStringValue(bool bl)
        //{
        //    string str = "1";
        //    if (bl)
        //    {
        //        str = "0";
        //    }
        //    return str;
        //}
        //private bool getBoolValue(string str)
        //{
        //    bool bl = true;
        //    if (str == "1" || str == "" || str == "FALSE")
        //    {
        //        bl = false;
        //    }
        //    return bl;
        //}

        /// <summary>
        /// 获取单位标识代码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string getUnitIDByName(string name)
        {
            string unitId;
            if (name == "组套")
            {
                unitId = "2";
                return unitId;
            }
            else if (name == "明细")
            {
                unitId = "1";
                return unitId;
            }
            return "0";
        }

        private string getUnitNameById(string id)
        {
            string unitName;
            if (id == "2")
            {
                unitName = "组套";
                return unitName;
            }
            else if (id == "1")
            {
                unitName = "明细";
                return unitName;
            }
            return "未知";
        }

        #endregion

        #region 筛选
        private void cmbQuery_Leave(object sender, System.EventArgs e)
        {
            IsTextFocus = false;
        }

        private void cmbQuery_TextChanged(object sender, System.EventArgs e)
        {
            string temp = " like  '%" + this.cmbQuery.Text + "%' ";
            UndrugView.RowFilter = "拼音码" + temp + " or " + "五笔" + temp + " or " + "输入码" + temp + " or " + "五笔" + temp + " or " + "项目名称" + temp;
            IsTextFocus = true;
        }

        private void chbAll_CheckedChanged(object sender, System.EventArgs e)
        {
            //			this.loadUndrug();
            //			this.InitComb();
        }
        #endregion 

    }
}
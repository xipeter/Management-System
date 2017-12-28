using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Base;
namespace Neusoft.HISFC.Components.RADT.Controls
{
    /// <summary>
    /// [功能描述: 包床，解开]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    public partial class ucBedChange : UserControl
    {
        public ucBedChange()
        {
            InitializeComponent();
        }

        #region 变量
        protected BedType bedtype;
        private DataSet constantData = new DataSet();
        private string Err;
        private Neusoft.HISFC.Models.RADT.PatientInfo mypatientinfo = null;
        private Bed myBed = new Bed();
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizLogic.RADT.InPatient radtManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        Neusoft.FrameWork.Public.ObjectHelper helper = null;
        #endregion

        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            set
            {
                this.mypatientinfo = value;
                this.cmbInpatientNo.Text = value.PID.PatientNO;
                this.lblShow.Text = value.Name;
            }
        }
        /// <summary>
        /// 床位操作类别
        /// </summary>
        public BedType SetType
        {
            set
            {
                this.bedtype = value;
                this.cmbInpatientNo.Enabled = true;
                this.btnOK.Visible = true;
                this.btnCancel.Visible = false;
                if (bedtype.ToString() == "Wap")
                {
                    this.GroupBox1.Text = "包床管理";
                }
                else if (bedtype.ToString() == "Hang")
                {
                    this.GroupBox1.Text = "挂床管理";
                }
                else if (bedtype.ToString() == "Unlock")
                {
                    this.GroupBox1.Text = "解挂床处理";
                    this.cmbInpatientNo.Enabled = false;
                    this.btnOK.Visible = false;
                    this.btnCancel.Visible = true;
                }
            }
        }
        #region 函数
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
            constantData = InitDataSet();
            this.fpSpread1_Sheet1.DataSource = constantData.Tables[0];
            this.fpSpread1_Sheet1.Columns[0].Width = 40;
            this.fpSpread1_Sheet1.Columns[1].Width = 60;
            this.fpSpread1_Sheet1.Columns[2].Width = 80;
            this.fpSpread1_Sheet1.Columns[3].Width = 80;
            this.fpSpread1_Sheet1.Columns[4].Width = 40;
            this.fpSpread1_Sheet1.Columns[5].Width = 100;
            this.fpSpread1_Sheet1.Columns[6].Width = 80;
            this.fpSpread1_Sheet1.Columns[7].Width = 80;
            this.fpSpread1_Sheet1.Columns[8].Width = 40;
            this.fpSpread1_Sheet1.Columns[9].Width = 40;
            this.fpSpread1_Sheet1.Columns[10].Width = 75;

            helper = new Neusoft.FrameWork.Public.ObjectHelper(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.BEDGRADE));
        }


        /// <summary>
        /// 初始化表格
        /// </summary>
        private DataSet InitDataSet()
        {

            DataSet dataSet = new DataSet();
            DataTable table = new DataTable("Bedinfo");

            DataColumn column1 = new DataColumn("BED_NO");
            column1.DataType = typeof(System.String);
            table.Columns.Add(column1);


            DataColumn column2 = new DataColumn("WARD_NO");
            column2.DataType = typeof(System.String);
            table.Columns.Add(column2);

            DataColumn column3 = new DataColumn("FEE_GRADE_CODE");
            column3.DataType = typeof(System.String);
            table.Columns.Add(column3);

            DataColumn column4 = new DataColumn("BED_WEAVE");
            column4.DataType = typeof(System.String);
            table.Columns.Add(column4);
            //
            DataColumn column5 = new DataColumn("BED_STATE");
            column5.DataType = typeof(System.String);
            table.Columns.Add(column5);

            DataColumn column6 = new DataColumn("CLINIC_NO");
            column6.DataType = typeof(System.String);
            table.Columns.Add(column6);
            //
            DataColumn column7 = new DataColumn("BED_PHONECODE");
            column7.DataType = typeof(System.String);
            table.Columns.Add(column7);

            DataColumn column8 = new DataColumn("OWNER_PC");
            column8.DataType = typeof(System.String);
            table.Columns.Add(column8);

            DataColumn column9 = new DataColumn("VALID_STATE");
            column9.DataType = typeof(System.String);
            table.Columns.Add(column9);
            //
            DataColumn column10 = new DataColumn("PREPAY_FLAG");
            column10.DataType = typeof(System.String);
            table.Columns.Add(column10);

            DataColumn column11 = new DataColumn("PREPAY_OUTDATE");
            column11.DataType = typeof(System.String);
            table.Columns.Add(column11);



            dataSet.Tables.Add(table);

            return dataSet;
        }


        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="NurseID"></param>
        private void LoadData(string nurseID)
        {

            if (constantData == null)
                constantData = InitDataSet();
            DataTable table = constantData.Tables[0];
            if (table != null)
            {
                if (table.Rows.Count > 0)
                    table.Rows.Clear();
                ArrayList list = new ArrayList();
                try
                {
                    #region {8ADDE7FC-0CF5-4e86-9B0A-41DFD058A400}
                    if (this.bedtype.ToString() == "Wap" || this.bedtype.ToString() == "Unlock")
                    {
                        list = manager.QueryUnoccupiedBed(nurseID);
                    }
                    else if (this.bedtype.ToString() == "Hang" || this.bedtype.ToString() == "Change")
                    {
                        list = manager.QueryBedList(nurseID);
                    }
                    #endregion
                    if (list.Count > 0)
                    {

                        AddConstsToTable(list, table);
                        constantData.AcceptChanges();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }


        /// <summary>
        /// 更新显示数据信息
        /// </summary>
        /// <param name="myNurse"></param>
        protected void RefreshList(string myNurse)
        {
            this.LoadData(myNurse);

        }


        private void AddConstsToTable(ArrayList list, DataTable table)
        {
            table.Clear();
            int i = 0;

            foreach (Neusoft.HISFC.Models.Base.Bed myBed in list)
            {
                //string strTrue = "是", strFalse = "否";
                string strOutDate = "";

                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                try
                {
                    myBed.BedGrade.Name = helper.GetName(myBed.BedGrade.ID);
                }
                catch { }
                if (myBed.PrepayOutdate == DateTime.MinValue)
                {
                    strOutDate = "";
                }
                else
                {
                    strOutDate = myBed.PrepayOutdate.ToString();
                }
               
                table.Rows.Add(new Object[] { myBed.ID,
                    myBed.SickRoom,
                    myBed.BedGrade.Name, 
                    myBed.BedRankEnumService.Name,
                    myBed.Status.Name, 
                    myBed.InpatientNO, 
                    myBed.Phone, 
                    myBed.OwnerPc,
                    myBed.IsValid,
                    myBed.IsPrepay,
                    strOutDate });
                this.fpSpread1_Sheet1.Rows[i].Tag = myBed;
                i++;
            }
            for (int k = i; k <= 15; k++)
            {
                table.Rows.Add(new object[] { });
            }
        }


        private void ListPatient()
        {
          
            //this.cmbInpatientNo.AddItems(radtManager.QueryPatient.PatientQuery(myLocation, Status));
        }


        private Bed GetInfoFromRow(int row)
        {
            Bed myBed = new Bed();
            myBed = (Bed)this.fpSpread1_Sheet1.Rows[row].Tag;
            return myBed;
        }


        private void ShowInfo(Bed obj)
        {
            this.lblShow.Text = cmbInpatientNo.Text + " 选择 " + obj.ID + " 床";
        }


        protected Neusoft.FrameWork.Models.NeuObject objNurse = null;
        private Neusoft.FrameWork.Models.NeuObject nurseCell
        {
            get
            {

                if (objNurse == null)
                    objNurse = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.Clone();
                return objNurse;
            }
            set
            {
                objNurse = value;
            }
        }

        /// <summary>
        /// 显示床位列表
        /// </summary>
        public void ShowBedList()
        {
            this.lblShow.Text = "";
            //取床位信息
            #region {8ADDE7FC-0CF5-4e86-9B0A-41DFD058A400}
            ArrayList al = new ArrayList();
            if (this.bedtype.ToString() == "Wap" || this.bedtype.ToString() == "Unlock")
            {
                al = this.manager.QueryUnoccupiedBed(this.nurseCell.ID);
            }
            else if (this.bedtype.ToString() == "Hang" || this.bedtype.ToString() == "Change")
            {
                al = this.manager.QueryBedList(this.nurseCell.ID);
            }
            #endregion
            if (al == null)
            {
                MessageBox.Show(this.manager.Err, "提示");
                return;
            }

            //显示数据总行数
            this.fpSpread1_Sheet1.Rows.Count = 0;
            this.fpSpread1_Sheet1.Rows.Count = al.Count;

            //逐行显示数据
            Neusoft.HISFC.Models.Base.Bed bed = null;
            for (int i = 0; i < al.Count; i++)
            {
                bed = al[i] as Neusoft.HISFC.Models.Base.Bed;
                if (bed == null) return;
                //赋值
                this.fpSpread1_Sheet1.Cells[i, 0].Value = bed.ID.Substring(4);	//床号
                this.fpSpread1_Sheet1.Cells[i, 1].Value = bed.SickRoom;			//房间号
                this.fpSpread1_Sheet1.Cells[i, 2].Value = bed.BedGrade.Name;		//床位等级
                this.fpSpread1_Sheet1.Cells[i, 3].Value = bed.BedRankEnumService.Name;		//床位编制
                this.fpSpread1_Sheet1.Cells[i, 4].Value = bed.Status.Name;	//床位状态
                this.fpSpread1_Sheet1.Cells[i, 5].Value = bed.InpatientNO == "N" ? "" : bed.InpatientNO.Substring(4);		//住院号
                this.fpSpread1_Sheet1.Cells[i, 6].Value = bed.Phone;				//床位电话
                this.fpSpread1_Sheet1.Cells[i, 7].Value = bed.OwnerPc;			//归属
                this.fpSpread1_Sheet1.Cells[i, 8].Value = bed.IsValid;			//是否有效
                this.fpSpread1_Sheet1.Cells[i, 9].Value = bed.IsPrepay;			//是否预约
                this.fpSpread1_Sheet1.Rows[i].Tag = bed;
            }

            //选中第一行
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.ActiveRowIndex = 0;
            this.fpSpread1.Focus();
        }

        #endregion

        #region 事件
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {

                //列出患者
                this.ListPatient();
                //显示床位
                this.ShowBedList();
                #region {8ADDE7FC-0CF5-4e86-9B0A-41DFD058A400}
                if (this.bedtype.ToString() == "Wap")
                {
                    this.GroupBox1.Text = "包床";
                }
                else if (this.bedtype.ToString() == "Hang" || this.bedtype.ToString() == "Change")
                {
                    this.GroupBox1.Text = "换床";
                }
                else
                {
                    this.GroupBox1.Text = "";
                }
                #endregion
            }
            catch { }

        }

        private void fpSpread1_Click(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.myBed = this.fpSpread1_Sheet1.Rows[e.Row].Tag as Neusoft.HISFC.Models.Base.Bed;
            #region {8ADDE7FC-0CF5-4e86-9B0A-41DFD058A400}
            if (!string.IsNullOrEmpty(this.myBed.InpatientNO) && this.myBed.Status.ID.ToString() != "W")
            {
                this.selectPatient = this.radtManager.QueryPatientInfoByInpatientNO(this.myBed.InpatientNO);
            }
            #endregion
            if (this.myBed == null)
                this.lblShow.Text = "";
            else
                this.lblShow.Text = this.mypatientinfo.Name + " 选择 " + this.myBed.ID.Substring(4) + " 床";//{8ADDE7FC-0CF5-4e86-9B0A-41DFD058A400}
        }

        private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            this.myBed = this.fpSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Base.Bed;
            if (this.myBed == null)
                this.lblShow.Text = "";
            else
                this.lblShow.Text = this.mypatientinfo.Name + " 选择 " + this.myBed.ID.Substring(4) + " 床";//{8ADDE7FC-0CF5-4e86-9B0A-41DFD058A400}

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            string kind = "";//1挂床 2  包床 
            if (myBed.ID == "")
            {
                this.Err = "请选择床位！";
                return;
            }
            if (this.bedtype.ToString() == "Hang")
            {
                kind = "1";
                //选择的床位已经被占用
                if (myBed.InpatientNO != "")
                {
                    if (this.mypatientinfo.ID == myBed.InpatientNO)
                    {
                        this.Err = "该人已经选择该床位！";
                        return;
                    }
                    try
                    {
                        if (this.radtManager.ChangeBedInfo(this.mypatientinfo.ID, myBed.ID, kind) == 0)
                        {
                            this.Err = "保存成功！";
                          
                        }
                        else
                        {
                            this.Err = "保存失败！" + this.radtManager.Err;
                        }
                    }
                    catch { }
                   
                    return;
                }
            }
            else if (this.bedtype.ToString() == "Wap")
            {
                kind = "2";
            }
            #region {8ADDE7FC-0CF5-4e86-9B0A-41DFD058A400}
            else if (this.bedtype.ToString() == "Change")
            {


                if (this.mypatientinfo.ID == myBed.InpatientNO)
                {
                    this.Err = "该人已经选择该床位！";
                    return;
                }
                try
                {
                    if (this.ChangeItems() > 0)
                    {
                        this.Err = "保存成功！";

                        this.FindForm().DialogResult = DialogResult.OK;
                        this.FindForm().Close();
                    }
                    else
                    {
                        this.Err = "保存失败！" + this.Err;
                    }
                }
                catch { }

                return;

            }
            #endregion
            //insert  or update
            try
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(this.radtManager.Connection);
                //SQLCA.BeginTransaction();

                this.radtManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.radtManager.SwapPatientBed(this.mypatientinfo, myBed.ID, kind) == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    this.Err = "保存成功！";
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "保存失败！" + this.radtManager.Err;
                }
            }
            catch { }
            this.FindForm().DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.FindForm().Close();
        }

        
        #endregion

        #region {8ADDE7FC-0CF5-4e86-9B0A-41DFD058A400}

        private Neusoft.HISFC.Models.RADT.PatientInfo selectPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 换床处理
        /// </summary>
        /// <returns></returns>
        private int ChangeItems()
        {
            int parm;
            Neusoft.HISFC.Models.RADT.PatientInfo obj_a, obj_b;

            //如果是同一个人,则返回
            if (this.selectPatient != null)
            {
                if (!string.IsNullOrEmpty(this.selectPatient.ID) && this.mypatientinfo.ID == this.selectPatient.ID)
                {
                    return -1;
                }

                //两人对调床位
                if (!string.IsNullOrEmpty(this.selectPatient.ID))
                {
                    obj_a = this.mypatientinfo;
                    obj_b = this.selectPatient;

                    if (obj_a.PVisit.PatientLocation.Bed.Status.ID.ToString() == "W" || obj_b.PVisit.PatientLocation.Bed.Status.ID.ToString() == "W")
                    {
                        MessageBox.Show("被调换的床位其一状态为包床，不能调换！", "提示：");
                        return -1;
                    }
                    //
                    if (MessageBox.Show("是否预将“" + obj_a.Name + "”与“" + obj_b.Name + "”调床", "提示：", System.Windows.Forms.MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Cancel) return -1;
                    //
                    try
                    {
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                        this.radtManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        //两患者床位对调处理
                        parm = this.radtManager.SwapPatientBed(obj_a, obj_b);
                        if (parm == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.Err = "换床失败！\n" + this.radtManager.Err;
                            return -1;
                        }
                        else if (parm == 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.Err = "换床失败! \n患者信息有变动,请刷新当前窗口";
                            return -1;
                        }

                        Neusoft.FrameWork.Management.PublicTrans.Commit();

                    }
                    catch (Exception ex)
                    {
                        this.Err = ex.Message;
                        return -1;
                    }

                    return 1;

                }
            }
            else
            {
                //患者a换到b床
                return (this.TransPatientToBed());

            }
            
            return 1;
        }


        /// <summary>
        /// 单人换床处理
        /// </summary>
        /// <returns></returns>
        private int TransPatientToBed()
        {
            int parm = 0;
            Neusoft.HISFC.Models.RADT.Location obj_location = new Neusoft.HISFC.Models.RADT.Location();
            Neusoft.HISFC.Models.RADT.PatientInfo obj_a;

            //取床位和患者信息
            obj_a = this.mypatientinfo;
            obj_location.Bed = this.myBed;

            //床号除去前四位
            string bedNo = obj_location.Bed.ID.Length > 4 ? obj_location.Bed.ID.Substring(4) : obj_location.Bed.ID;

            if (obj_location.Bed.Status.ID.ToString() == "W")
            {
                MessageBox.Show("床号为 [" + bedNo + " ]的床位状态为包床，不能占用！", "提示：");
                return -1;
            }
            else if (obj_location.Bed.Status.ID.ToString() == "C")
            {
                MessageBox.Show("床号为 [" + bedNo + " ]的床位状态为关闭，不能占用！", "提示：");
                return -1;
            }
            else if (obj_location.Bed.IsPrepay)
            {
                MessageBox.Show("床号为 [" + bedNo + " ]的床位已经预约，不能占用！", "提示：");
                return -1;
            }
            else if (!obj_location.Bed.IsValid)
            {
                MessageBox.Show("床号为 [" + bedNo + " ]的床位已经停用，不能占用！", "提示：");
                return -1;
            }
            else if (obj_location.Bed.Status.ID.ToString() == "I")
            {
                MessageBox.Show("床号为 [" + bedNo + " ]的床位状态为隔离，不能占用！", "提示：");
                return -1;
            }
            else if (obj_location.Bed.Status.ID.ToString() == "K")
            {
                MessageBox.Show("床号为 [" + bedNo + " ]的床位状态为污染，不能占用！", "提示：");
                return -1;
            }
            
            if (MessageBox.Show("是否预将“" + obj_a.Name + "”转移到[" + bedNo + "]号床", "提示：", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return -1;
            
            try
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                this.radtManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                //单人换床处理
                parm = this.radtManager.TransferPatient(obj_a, obj_location);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "换床失败！\n" + this.radtManager.Err;
                    return -1;
                }
                else if (parm == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "换床失败! \n患者信息有变动或者已经出院,请刷新当前窗口";
                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
                
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 1;
        }
        #endregion

    }
    	
    /// <summary>
    /// 接诊类型
    /// </summary>
    public enum BedType {
	    /// <summary>
	    /// 包床
	    /// </summary>
	    Wap,
	    /// <summary>
	    /// 挂床
	    /// </summary>
	    Hang,
	    /// <summary>
	    /// 解挂床
	    /// </summary>
	    Unlock,
        /// <summary>
        /// 换床
        /// {8ADDE7FC-0CF5-4e86-9B0A-41DFD058A400}
        /// </summary>
        Change
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Base;
namespace Neusoft.HISFC.Components.Nurse.Controls
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

        Neusoft.HISFC.BizLogic.RADT.InPatient radtInpatientManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();

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
                    if (this.bedtype.ToString() == "Wap" || this.bedtype.ToString() == "Unlock")
                    {
                        list = manager.QueryUnoccupiedBed(nurseID);
                    }
                    else if (this.bedtype.ToString() == "Hang")
                    {
                        list = manager.QueryBedList(nurseID);
                    }

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
            ArrayList al = this.manager.QueryUnoccupiedBed(this.nurseCell.ID);
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

            }
            catch { }

        }

        private void fpSpread1_Click(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.myBed = this.fpSpread1_Sheet1.Rows[e.Row].Tag as Neusoft.HISFC.Models.Base.Bed;
            if (this.myBed == null)
                this.lblShow.Text = "";
            else
                this.lblShow.Text = cmbInpatientNo.Text + " 选择 " + this.myBed.ID + " 床";
        }

        private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            this.myBed = this.fpSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Base.Bed;
            if (this.myBed == null)
                this.lblShow.Text = "";
            else
                this.lblShow.Text = cmbInpatientNo.Text + " 选择 " + this.myBed.ID + " 床";

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
                        if (this.radtInpatientManager.ChangeBedInfo( this.mypatientinfo.ID, myBed.ID, kind ) == 0)
                        {
                            this.Err = "保存成功！";
                          
                        }
                        else
                        {
                            this.Err = "保存失败！" + this.radtInpatientManager.Err;
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
            //insert  or update
            try
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(this.radtManager.Connection);
                //SQLCA.BeginTransaction();

                this.radtInpatientManager.SetTrans( Neusoft.FrameWork.Management.PublicTrans.Trans );

                if (this.radtInpatientManager.SwapPatientBed( this.mypatientinfo, myBed.ID, kind ) == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    this.Err = "保存成功！";
                   

                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "保存失败！" + this.radtInpatientManager.Err;
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            ////解挂床
            //if (this.bedtype.ToString() == "Unlock")
            //{
            //    int Err = 0;

            //    try
            //    {
            //        Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(this.Patient.Connection);
            //        SQLCA.BeginTransaction();
            //        this.Patient.SetTrans(SQLCA.Trans);
            //        Err = this.Patient.PatientUnWapBed(mypatientinfo, mypatientinfo.PVisit.PatientLocation.Bed.ID, "1");
            //        if (Err == 0)
            //        {
            //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //            this.Err = "该患者无挂床信息！";
            //            MessageBox.Show(this.Err, "提示：");
            //        }
            //        else if (Err < 0)
            //        {
            //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //            this.Err = "解挂床失败！";
            //            MessageBox.Show(this.Err, "提示：");
            //        }
            //        myBed.InpatientNo = mypatientinfo.ID;
            //        myBed.BedStatus.ID = Neusoft.HISFC.Models.RADT.BedStatus.enuBedStatus.O;

            //        if (this.Patient.UpdateBedStatus(myBed) <= 0)
            //        {
            //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //            this.Err = "解挂床失败！";
            //            MessageBox.Show(this.Err, "提示：");
            //        }
            //        mypatientinfo.PVisit.PatientLocation.Bed = myBed;

            //        if (this.Patient.ArrivePatient(mypatientinfo, "I") <= 0)
            //        {
            //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //            this.Err = "解挂床失败！";
            //            MessageBox.Show(this.Err, "提示：");
            //        }
            //        SQLCA.Commit();
            //        this.Err = "解挂床成功！";

            //        this.FindForm().DialogResult = DialogResult.OK;

            //    }
            //    catch { }
            //}
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
	    Unlock
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.RADT.Controls
{
    /// <summary>
    /// [功能描述: 护士站床位管理]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人='张琦'
    ///		修改时间='2007-08-29'
    ///		修改目的='增添床位医生'
    ///		修改描述='修改原来默认的床位医生(即住院医生)'
    ///  />
    /// </summary>
    public partial class ucBedManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucBedManager()
        {
            InitializeComponent();
        }

        protected Neusoft.FrameWork.Models.NeuObject objNurse = null;
        private Neusoft.FrameWork.Models.NeuObject nurseCell
        {
            get
            {

                if(objNurse==null)
                    objNurse = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.Clone();
                return objNurse;
            }
            set
            {
                objNurse = value;
            }
        }

        #region 变量
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        int patientnum = 0;
        private DataSet constantData = new DataSet();
        private Neusoft.HISFC.Models.Base.Bed myBed = null;	//当前操作的床位信息
        string Err = "";
        #endregion

        #region {5DF40042-300D-49b8-BB8D-4E4E906B7BAF}
        private bool isAllBedWave = false;
        [Category("床位维护设置"), Description("是否可以添加所有床位编制病床")]
        public bool IsAllBedWave
        {
            get
            {
                return this.isAllBedWave;
            }
            set
            {
                this.isAllBedWave = value;
                this.cmbWeave.Enabled = this.isAllBedWave;
            }
        }
        #endregion

        #region 函数

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            try
            {
                if (this.nurseCell !=null  && 
                    this.nurseCell.ID != null &&
                    this.nurseCell.ID != "")
                {
                    //加载医生,护士列表
                   
                    //根据护士站得到科室信息
                    ArrayList alDepts = manager.QueryDepartment(this.nurseCell.ID);
                    if (alDepts == null) return;

                    //取科室中的医生列表
                    ArrayList alDoc = new ArrayList();
                    for (int i = 0; i < alDepts.Count; i++)
                    {
                        alDoc.AddRange(manager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, ((Neusoft.FrameWork.Models.NeuObject)alDepts[i]).ID));
                    }

                    //将取得的医生列表添加到医生控件中
                    this.cmbAdmittingDoctor.AddItems(alDoc);
                    this.cmbAttendingDoctor.AddItems(alDoc);
                    this.cmbConsultingDoctor.AddItems(alDoc);
                    this.cmbBedDoctor.AddItems(alDoc);

                    ArrayList alNurse = manager.QueryNurse(this.nurseCell.ID);
                    if (alNurse == null) return;

                    //将取得的护士列表添加到医生控件中
                    this.cmbAdmittingNurse.AddItems(alNurse);

                    //加载床位编制列表

                    this.cmbWeave.AddItems(Neusoft.HISFC.Models.Base.BedRankEnumService.List());
                    this.cmbGrade.AddItems(manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.BEDGRADE));
                    this.cmbIsValid.AddItems(InitComboxList());
                    this.cmbIsprepay.AddItems(InitComboxList());

                  
                    //清空数据
                    this.ClearInfo();

                    //显示床位列表
                    this.ShowBedList();

                    #region {5DF40042-300D-49b8-BB8D-4E4E906B7BAF}
                    
                    #endregion
                }
            }
            catch { }
        }


        /// <summary>
        /// 初始化Combox下拉列表
        /// </summary>
        /// <returns></returns>
        private ArrayList InitComboxList()
        {
            ArrayList list = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj;
            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "True";
            obj.Name = "是";
            list.Add(obj);
            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "False";
            obj.Name = "否";
            list.Add(obj);
            return list;
        }


        /// <summary>
        /// 显示床位列表
        /// </summary>
        public void ShowBedList()
        {
            //清屏
            this.ClearInfo();

            //取床位信息
            ArrayList al = this.manager.QueryBedList(this.nurseCell.ID);
            if (al == null)
            {
                MessageBox.Show(this.manager.Err, "提示");
                return;
            }

            //显示数据总行数
            this.fpSpread1_Sheet1.RowCount = al.Count;

            //逐行显示数据
            Neusoft.HISFC.Models.Base.Bed bed = null;
            this.patientnum = 0; //用于计算占用床位数
            for (int i = 0; i < al.Count; i++)
            {
                bed = al[i] as Neusoft.HISFC.Models.Base.Bed;
                if (bed == null) return;
                //赋值
                this.fpSpread1_Sheet1.Cells[i, 0].Value = bed.ID.Substring(4);	//床号
                this.fpSpread1_Sheet1.Cells[i, 1].Value = bed.TendGroup;			//护理组
                this.fpSpread1_Sheet1.Cells[i, 2].Value = bed.BedGrade.Name;		//床位等级
                this.fpSpread1_Sheet1.Cells[i, 3].Value = bed.User03;			//床位费
                this.fpSpread1_Sheet1.Cells[i, 4].Value = bed.BedRankEnumService.Name;		//床位编制
                this.fpSpread1_Sheet1.Cells[i, 5].Value = bed.Status.Name;	//床位状态
                this.fpSpread1_Sheet1.Cells[i, 6].Value = bed.InpatientNO== "N" ? "" : bed.InpatientNO.Substring(4);		//住院号
                this.fpSpread1_Sheet1.Cells[i, 7].Value = bed.Phone;				//床位电话
                this.fpSpread1_Sheet1.Cells[i, 8].Value = bed.OwnerPc;			//归属
                this.fpSpread1_Sheet1.Cells[i, 9].Value = bed.IsValid;			//是否停用
                this.fpSpread1_Sheet1.Cells[i, 10].Value = bed.IsPrepay;			//是否预约
                this.fpSpread1_Sheet1.Rows[i].Tag = bed;
                //计算床位占用数(占用,挂床,包床)
                if (bed.Status.ID.ToString() == "O" || bed.Status.ID.ToString() == "H" || bed.Status.ID.ToString() == "W")
                    this.patientnum++;
            }

            decimal rate = Neusoft.FrameWork.Public.String.FormatNumber(this.patientnum / Neusoft.FrameWork.Function.NConvert.ToDecimal(al.Count) * 100, 2);

            this.txtshow.Text = "占用床数：" + patientnum.ToString() + "   病床总数：" + al.Count.ToString() + "   占用率：" + rate.ToString() + "%";

            //选中第一行
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.ActiveRowIndex = 0;
            this.fpSpread1.Focus();
        }


        /// <summary>
        /// 显示要修改的床位信息,并控制各控件是否可用
        /// </summary>
        /// <param name="bed"></param>
        private void ShowInfoForModify(Neusoft.HISFC.Models.Base.Bed bed)
        {
            //取当前行中的数据
            this.myBed = this.fpSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.Base.Bed;
            if (this.myBed == null) return;

            //this.cmbStatus.Items.Clear();
            //如果是占用O,请假R,挂床H,包床W,则显示全部的床位状态.并控制控件是否可用
            if (this.myBed.Status.ID.ToString() == "O" || 
                this.myBed.Status.ID.ToString() == "R" || 
                this.myBed.Status.ID.ToString() == "H" || 
                this.myBed.Status.ID.ToString() == "W")
            {
                this.cmbStatus.AddItems(Neusoft.HISFC.Models.Base.BedStatusEnumService.List());
                this.cmbStatus.Enabled = false;	//床位状态
                this.cmbIsprepay.Enabled = false;	//是否预约
                this.cmbIsValid.Enabled = false;	//是否有效
                //{8EA2FE76-AF13-4a83-8EDD-2067016038B2}
                //this.cmbGrade.Enabled = false;	//床位等级
                this.btnDelete.Enabled = false;	//不允许删除
            }
            else
            {
                this.cmbStatus.AddItems(Neusoft.HISFC.Models.Base.BedStatusEnumService.UnoccupiedList());
                this.cmbStatus.Enabled = true;	//床位状态
                //this.cmbWeave.Enabled    = true;	//床位编制
                this.cmbIsprepay.Enabled = true;	//是否预约
                this.cmbIsValid.Enabled = true;	//是否有效
                //{8EA2FE76-AF13-4a83-8EDD-2067016038B2}
                //this.cmbGrade.Enabled = false;	//床位等级
                if (this.myBed.BedRankEnumService.ID.ToString() == "A")
                    this.btnDelete.Enabled = true;	//加床可以删除
                else
                    this.btnDelete.Enabled = false;	//其他床位不允许删除

            }

            //显示信息
            this.txtBedNo.Text = this.myBed.ID.Substring(4);	//床号
            this.txtBedNo.Tag = this.myBed.ID;					//床号
            this.txtOwnPc.Text = this.myBed.OwnerPc;			//归属
            this.txtPhone.Text = this.myBed.Phone;				//床位电话
            this.txtSortId.Text = this.myBed.SortID.ToString();	//排序
            this.txtWardNo.Text = this.myBed.SickRoom.ID;			//房号
            this.cmbGrade.Tag = this.myBed.BedGrade.ID;		//床位等级
            this.cmbWeave.Tag = this.myBed.BedRankEnumService.ID;		//床位编制
            this.cmbStatus.Tag = this.myBed.Status.ID;		//床位状态
            this.cmbIsValid.Tag = this.myBed.IsValid.ToString();	//是否有效
            if( this.myBed.PrepayOutdate != DateTime.MinValue)
                this.dtOutDate.Value = this.myBed.PrepayOutdate;	//预约出院时间(不需要用户维护)
            this.cmbIsprepay.Tag = this.myBed.IsPrepay.ToString();			//是否预约
            this.cmbAdmittingDoctor.Tag = this.myBed.AdmittingDoctor.ID;	//住院医生
            this.cmbAttendingDoctor.Tag = this.myBed.AttendingDoctor.ID;	//主治医生
            this.cmbConsultingDoctor.Tag = this.myBed.ConsultingDoctor.ID;	//主任医生
            this.cmbAdmittingNurse.Tag = this.myBed.AdmittingNurse.ID;		//责任护士
            this.txtTendGroup.Text = this.myBed.TendGroup;		//护理组
            //{255E2A05-2A48-4d50-B05E-0E0AA225B9B4}
            this.cmbBedDoctor.Tag = this.myBed.Doctor.ID;    //床位医生
            //修改床位信息时,不允许修改床号
            this.txtBedNo.Enabled = false;
        }


        /// <summary>
        /// 取控件中维护的床位信息
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Bed GetBedInfo()
        {
            //如果是新增床位,则取床号信息
            if (this.myBed == null)
            {
                this.myBed = new Neusoft.HISFC.Models.Base.Bed();
                this.myBed.ID = this.txtBedNo.Text;
                this.myBed.InpatientNO= "N";
            }

            this.myBed.OwnerPc = this.txtOwnPc.Text;									//归属
            this.myBed.Phone = this.txtPhone.Text;									//电话
            this.myBed.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtSortId.Text);	//序号(不用了)
            this.myBed.SickRoom.ID = this.txtWardNo.Text;									//房号
            //this.myBed.Doctor.ID = this.cmbAdmittingDoctor.Tag.ToString();			//医生姓名
            this.myBed.BedGrade.ID = this.cmbGrade.Tag.ToString();						//床位等级编码
            this.myBed.BedRankEnumService.ID = this.cmbWeave.Tag.ToString();						//床位编制编码
            this.myBed.Status.ID = this.cmbStatus.Tag.ToString();					//床位状态编码
            //是否有效:0有效,1无效---跟实际正好相反
            this.myBed.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.cmbIsValid.Tag.ToString());
            this.myBed.IsPrepay = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.cmbIsprepay.Tag.ToString());	//是否有效
            this.myBed.NurseStation.ID = this.nurseCell.ID;							//护理站编码
            this.myBed.PrepayOutdate = this.dtOutDate.Value;							//预约出院时间
            this.myBed.AdmittingDoctor.ID = this.cmbAdmittingDoctor.Tag.ToString();		//住院医生
            this.myBed.AttendingDoctor.ID = this.cmbAttendingDoctor.Tag.ToString();		//住院医生
            this.myBed.ConsultingDoctor.ID = this.cmbConsultingDoctor.Tag.ToString();	//住院医生
            this.myBed.AdmittingNurse.ID = this.cmbAdmittingNurse.Tag.ToString();		//住院医生
            this.myBed.TendGroup = this.txtTendGroup.Text;								//护理组
           this.myBed.Doctor.ID=this.cmbBedDoctor.Tag.ToString()  ;    //床位医生
            //返回床位信息
            return this.myBed;
        }


        /// <summary>
        /// 清屏
        /// </summary>
        private void ClearInfo()
        {
            //清空床位信息
            this.myBed = null;
            this.cmbStatus.AddItems(Neusoft.HISFC.Models.Base.BedStatusEnumService.UnoccupiedList());
            this.cmbStatus.Enabled = true;
            this.txtBedNo.Enabled = false;
            this.dtOutDate.Enabled = false;
            this.cmbIsprepay.Enabled = false;
            this.btnDelete.Enabled = true;

            this.txtBedNo.Text = "";
            this.txtBedNo.Tag = "";
            this.txtOwnPc.Text = "";
            this.txtPhone.Text = "";
            this.txtSortId.Text = "";
            this.txtWardNo.Text = "";
            this.cmbGrade.SelectedIndex = 0;
            this.cmbWeave.Tag = "A";
            //this.cmbWeave.SelectedIndex = 0;
            this.cmbStatus.Tag = "U";
            this.cmbIsValid.Tag = "True";
            this.dtOutDate.Text = "";
            this.cmbIsprepay.Tag = "False";
            this.cmbAdmittingDoctor.Tag = "";
            this.cmbAttendingDoctor.Tag = "";
            this.cmbConsultingDoctor.Tag = "";
            this.cmbAdmittingNurse.Tag = "";
            this.cmbBedDoctor.Tag = "";
        }


        /// <summary>
        /// 检查输入是否有效
        /// </summary>
        /// <returns></returns>
        private int CheckValid()
        {
            if (this.txtBedNo.Text == "")
            {
                this.Err = "床号不能为空，请填写！";
                return -1;
            }
            if (this.txtBedNo.Text.Trim().Length>6)
            {
                this.Err = "床号过长，请重新填写！";
                return -1;
            }
            if (this.txtWardNo.Text.Trim().Length > 10)
            {
                this.Err = "房间号过长，请重新填写！";
                return -1;
            }
            if (this.txtWardNo.Text == "")
            {
                this.Err = "病房号不能为空，请填写！";
                return -1;
            }
            if (this.cmbGrade.Text == "")
            {
                this.Err = "床位等级为空，请选择！";
                return -1;
            }
            if (this.cmbWeave.Text == "")
            {
                this.Err = "床位编制为空，请选择！";
                return -1;
            }
            if (this.cmbStatus.Text == "")
            {
                this.Err = "床位状态为空，请选择！";
                return -1;
            }
            return 1;
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            //检查录入是否有效
            if (this.CheckValid() == -1)
            {
                MessageBox.Show(this.Err);
                return;
            }

            //取用户录入的床位信息
            this.GetBedInfo();

            //保存床位信息
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();

            this.manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int parm = this.manager.SetBed(this.myBed);
            if (parm != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                if (this.manager.DBErrCode == 1)
                    MessageBox.Show("床号为【" + this.myBed.ID.Substring(4) + "】的床位已经存在,请维护其他的床位.");
                else
                    MessageBox.Show(this.manager.Err, "错误提示");

                //清屏
                this.ClearInfo();
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功", "提示");
            //刷新床位列表
            this.ShowBedList();
        }

        #endregion

        #region 事件

        private void fpSpread1_Click(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpSpread1_Sheet1.RowCount == 0 || this.fpSpread1_Sheet1.ActiveRowIndex < 0) return;

            //显示床位信息
            this.ShowInfoForModify(this.myBed);
        }


        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            //清空床位信息
            ClearInfo();
            this.txtBedNo.Enabled = true;
            this.txtBedNo.Focus();
            this.btnDelete.Enabled = false; //新增床位不允许删除

            /*
             * [2007/02/01] 测试人员提出的,原来是 false 的,不知道有没有什么特殊用,
             *              以后要改就改这个地方
             */
            this.cmbGrade.Enabled = true;
            this.cmbIsValid.Enabled = true;
            #region {5DF40042-300D-49b8-BB8D-4E4E906B7BAF}
            this.cmbWeave.Tag = Neusoft.HISFC.Models.Base.EnumBedRank.A.ToString();
            #endregion

        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (this.myBed == null)
            {
                MessageBox.Show("请选择要删除的床位", "提示");
                return;
            }

            //如果是新增床位,则清空数据
            if (this.myBed.ID == "")
            {
                this.ClearInfo();
                return;
            }

            if (this.myBed.Status.ID.ToString() == "O" || 
                this.myBed.Status.ID.ToString() == "W" ||
                this.myBed.Status.ID.ToString() == "R" ||
                this.myBed.Status.ID.ToString() == "H")
            {
                MessageBox.Show("该床已经被占用，不能删除！", "提示");
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();

            this.manager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.manager.DeleteBed(this.myBed.ID) >= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("删除成功！", "提示");
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("删除失败！" + this.manager.Err, "提示");
            }

            this.ClearInfo();
            this.ShowBedList();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //保存
            this.Save();
        }

        private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (this.fpSpread1_Sheet1.RowCount == 0 || this.fpSpread1_Sheet1.ActiveRowIndex < 0) return;

            //显示床位信息
            this.ShowInfoForModify(this.myBed);
        }

        #endregion

        #region 重写
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.Init();
            return null;
        }

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (neuObject == null) return 0;
            if (neuObject.GetType() == typeof(Neusoft.HISFC.Models.Base.Department))
            {
                this.nurseCell = neuObject as Neusoft.FrameWork.Models.NeuObject;
                this.Init();
            }
            return 0;
        }
        #endregion
    }
}

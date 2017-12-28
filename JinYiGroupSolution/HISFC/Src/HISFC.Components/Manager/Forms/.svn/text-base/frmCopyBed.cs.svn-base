using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Forms
{
    /// <summary>
    /// 床位维护
    /// </summary>
    public partial class frmCopyBed : Form
    {
        //护理站编号  在增加时用
        protected string bedRoomNO = string.Empty;
        public string BedRoomNO
        {
            set
            {
                bedRoomNO = value;
            }
        }

        //护理站编号  在增加时用
        protected string nurseStation = string.Empty;
        public string NurseStation
        {
            set
            {
                nurseStation = value;
            }
        }

        public frmCopyBed(bool isUpdate)
        {
            InitializeComponent();
            if (isUpdate)
            {
                txtBedNo.Enabled = true ;
                this.cmbNurse.Enabled = true ;
            }
            this.isUpdate = isUpdate;
            this.Init();
        }

        protected void Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Department Dept = new Neusoft.HISFC.BizLogic.Manager.Department();
            Neusoft.HISFC.BizLogic.Manager.Constant content = new Neusoft.HISFC.BizLogic.Manager.Constant();
            this.cmbNurse.AddItems(Dept.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.N));//护士站列表
            this.cmdBedGrade.AddItems(content.GetList(Neusoft.HISFC.Models.Base.EnumConstant.BEDGRADE));//床位等级
            this.cmbBedWeave.AddItems(Neusoft.HISFC.Models.Base.BedRankEnumService.List());//床位编制
            this.cmbBedStatus.AddItems(Neusoft.HISFC.Models.Base.BedStatusEnumService.List());//床位状态
        }
        protected bool isUpdate = false;
        public string Err = "";
        Neusoft.HISFC.BizLogic.Manager.Bed bed = new Neusoft.HISFC.BizLogic.Manager.Bed();
        protected int CheckValid()
        {
            if (this.cmbNurse.SelectedItem == null)
            {
                this.Err = "护理站号不存在";
                return -1;
            }
            if (this.txtBedNo.Text == "")
            {
                this.Err = "床号为空，请填写！";
                return -1;
            }
            if (txtBedNo.Enabled)
            {
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtBedNo.Text, 6))
                {
                    this.Err = "床号过长，请重新填写！";
                    return -1;
                }
            }
            
            if (txtBedNo.Text != "")
            {
                int temp = bed.IsExistBedNo(this.cmbNurse.SelectedItem.ID + txtBedNo.Text);
                if (temp == 0)
                {
                    //没有
                }
                else if (temp == 1)
                {
                    this.Err = "已经存在床位号 " + txtBedNo.Text;
                    txtBedNo.Focus();
                    return -1;
                }
            }

            if (this.txtWardNo.Text == "")
            {
                this.Err = "病房号为空，请填写！";
                return -1;
            }
            if (this.cmdBedGrade.Text == "")
            {
                this.Err = "床位等级为空，请选择！";
                return -1;
            }
            if (this.cmbBedWeave.Text == "")
            {
                this.Err = "床位编制为空，请选择！";
                return -1;
            }
            if (this.cmbBedStatus.Text == "")
            {
                this.Err = "床位状态为空，请选择！";
                return -1;
            }
            
            if(!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtPhone.Text,14))
            {
                this.Err = "床位电话最长为14位,请重新输入";
                return -1;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtWardNo.Text, 10))
            {
                this.Err = "病室号过长,请重新输入";
                return -1;
            }
            return 0;
        }

        public void SetBedInfo(Neusoft.HISFC.Models.Base.Bed bedInfo)
        {
            if (bedInfo != null)
            {

                this.cmbNurse.Tag = bedInfo.NurseStation.ID;//护士站编号
                this.txtWardNo.Text = bedInfo.SickRoom.ID;//病区号
                this.txtBedNo.Text = bedInfo.ID;//病床号
                this.cmdBedGrade.Tag = bedInfo.BedGrade.ID.ToString();//病床等级
                this.cmdBedGrade.Text = bedInfo.BedGrade.Name;
                this.cmbBedStatus.Tag = bedInfo.Status.ID.ToString();//病床状态
                this.cmbBedStatus.Text = bedInfo.Status.Name;
                this.cmbBedWeave.Tag = bedInfo.BedRankEnumService.ID.ToString();//病床编制
                this.cmbBedWeave.Text = bedInfo.BedRankEnumService.Name;
                this.txtPhone.Text = bedInfo.Phone;//电话
                this.txtSort.Text = bedInfo.SortID.ToString();//顺序号
                this.txtOwn.Text = bedInfo.OwnerPc.Trim();//归属
                if (isUpdate)
                {
                    if (bedInfo.Status.ID.ToString() == "O" ||
                        bedInfo.Status.ID.ToString() == "R" ||
                        bedInfo.Status.ID.ToString() == "W") //占用床位不能修改状态
                    {
                        this.cmbBedStatus.Enabled = true ;
                    }
                }
            }
        }
        Neusoft.HISFC.Models.Base.Bed BedInfo = null;
        public void GetBedInfo()
        {
            if (BedInfo == null)
            {
                BedInfo = new Neusoft.HISFC.Models.Base.Bed();
            }
            if (BedInfo.InpatientNO == "" || BedInfo.InpatientNO == null)
            {
                BedInfo.InpatientNO = "N";
            }
            BedInfo.NurseStation.ID = cmbNurse.Tag.ToString();//护士站编号
            
            BedInfo.SickRoom.ID = this.txtWardNo.Text.Trim();//病区号
            
            BedInfo.ID = txtBedNo.Text.Trim();//病床号
            BedInfo.BedGrade.ID = this.cmdBedGrade.Tag.ToString();//病床等级
            BedInfo.Status.ID = this.cmbBedStatus.Tag.ToString();//病床状态
            BedInfo.BedRankEnumService.ID = this.cmbBedWeave.Tag.ToString();//病床编制
            BedInfo.Phone = txtPhone.Text.Trim();//电话
            BedInfo.SortID = int.Parse(this.txtSort.Text);//顺序号
            BedInfo.OwnerPc = this.txtOwn.Text.Trim();//归属


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValid() != -1)
                {
                    
                    int iParm;

                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                    bed.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    this.GetBedInfo();
                    //if (isUpdate)
                    //{
                    //    iParm = bed.UpdateBedInfo(BedInfo);
                    //}
                    //else
                    //{
                    iParm = bed.CreatBedInfo(BedInfo);
                    //}
                    if (iParm <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        MessageBox.Show(this.bed.Err);
                    }
                    else
                    {
                        Neusoft.FrameWork.Management.PublicTrans.Commit();;
                        MessageBox.Show("保存成功！");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(Err);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
            }
        }

        private void frmBedManager_Load(object sender, EventArgs e)
        {
            if (!isUpdate)
            {
                this.cmbNurse.Tag = this.nurseStation;
                this.txtWardNo.Text = this.bedRoomNO;
            }  
        }
    }
}
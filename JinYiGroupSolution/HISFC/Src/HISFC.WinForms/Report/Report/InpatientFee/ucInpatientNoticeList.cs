using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.InpatientFee
{
    /// <summary>
    /// [功能描述: 入院通知单 ]<br></br>
    /// [创 建 者: 张雪松]<br></br>
    /// [创建时间: 2009-09-14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucInpatientNoticeList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.IPrintInHosNotice
    {
        public ucInpatientNoticeList()
        {
            InitializeComponent();
            
        }

        #region 变量
        /// <summary>
        /// 打印
        /// </summary>
        Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        #endregion

        #region 方法

        /// <summary>
        /// 设置打印时控件的可见性
        /// </summary>
        /// <param name="isSee"></param>
        private void SetVisible(bool isSee)
        {
            foreach (Control c in this.neuPanel1.Controls)
            {
                if (c is Neusoft.FrameWork.WinForms.Controls.NeuLabel && (!c.Name.StartsWith("lblPri") || c.Tag=="1"))
                {
                    c.Visible = isSee;
                }
            }
        }
        /// <summary>
        /// 设置入院通知单打印值
        /// </summary>
        /// <param name="prePatientInfo"></param>
        /// <returns></returns>
        public int SetValue(Neusoft.HISFC.Models.RADT.PatientInfo prePatientInfo)
        {
            this.neuLabel466.Text = this.manager.GetHospitalName() + "入院通知单";
            this.SetVisible(false);
            this.lblPriName.Text = prePatientInfo.Name;
            if (!string.IsNullOrEmpty(prePatientInfo.ID))
            {
                this.ID.Text = prePatientInfo.ID.Substring(4);
            }
            this.lblPriSex.Text = prePatientInfo.Sex.Name;
            this.lblPriAge.Text = inpatientManager.GetAge(prePatientInfo.Birthday);
            this.lblPriDeptName.Text = prePatientInfo.PVisit.PatientLocation.Dept.Name;
            this.ID.Text = prePatientInfo.PID.CardNO;
            //this.lblPriClinicDiag.Text = prePatientInfo.ClinicDiagnose;
            ////this.lblPriDoc.Text = prePatientInfo.PatientInfo.DoctorReceiver.Name;
            //if (prePatientInfo.PVisit.Circs.ID == "1")
            //{
            //    this.lblPriCommon.Text = "一般";
            //    this.lblPriEmergency.Text = "";
            //    this.lblPriDanger.Text = "";
            //}
            //else if (prePatientInfo.PVisit.Circs.ID == "2")
            //{
            //    this.lblPriCommon.Text = "";
            //    this.lblPriEmergency.Text = "急";
            //    this.lblPriDanger.Text = "";
            //}
            //else
            //{
            //    this.lblPriCommon.Text = "";
            //    this.lblPriEmergency.Text = "";
            //    this.lblPriDanger.Text = "危";
            //}
            //this.lblName.Text = prePatientInfo.Name;//姓名
            //this.lblBirth.Text = prePatientInfo.Birthday.ToShortDateString();//出生日期
            //this.lblProfession.Text = prePatientInfo.Profession.Name;//职业
            //this.lblPriPreCost.Text = prePatientInfo.FT.PrepayCost.ToString();//预交金
                       
            if (prePatientInfo.PVisit.InTime>DateTime.MinValue)
            {
                this.lblPriYear.Text = (prePatientInfo.PVisit.InTime.Year.ToString()).Substring(2, 2); //入院年份
                this.lblPriMonth.Text = prePatientInfo.PVisit.InTime.Month.ToString();//入院月份
                this.lblPriDay.Text = prePatientInfo.PVisit.InTime.Day.ToString();//入院日期
            }
            else
            {
                this.lblPriYear.Text = (DateTime.Now.Year.ToString()).Substring(2, 2); //入院年份
                this.lblPriMonth.Text = DateTime.Now.Month.ToString();//入院月份
                this.lblPriDay.Text = DateTime.Now.Day.ToString();//入院日期
            }
           
            this.lblDocName.Text = "";//Neusoft.NFC.Management.Connection.Operator.Name; //医生签名
            //this.lblID.Text = prePatientInfo.IDCard; //身份证
            //this.lblTelephone.Text = prePatientInfo.PhoneHome; //家庭电话
            //this.lblWorkStationAndAddr.Text = prePatientInfo.CompanyName; //工作单位

            Neusoft.HISFC.BizLogic.Manager.Constant constant = new Neusoft.HISFC.BizLogic.Manager.Constant();
            Neusoft.FrameWork.Models.NeuObject birthArea = constant.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.AREA,prePatientInfo.AreaCode);
            //if (!string.IsNullOrEmpty(birthArea.Name))
            //{
            //    this.lblBirthArea.Text = birthArea.Name; //出生地
            //}
           
            //this.lblPeople.Text = prePatientInfo.Nationality.Name; //民族

            //if (string.IsNullOrEmpty(prePatientInfo.Nationality.Name))//有的地方传入的民族只有id没有名字
            //{
            //    Neusoft.FrameWork.Models.NeuObject nationality = constant.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.NATION, prePatientInfo.Nationality.ID);
               
            //    this.lblPeople.Text = nationality.Name;
            //}

            Neusoft.FrameWork.Models.NeuObject pact = constant.GetConstant("PACTUNIT", prePatientInfo.Pact.ID);

            this.lblPactName.Text = pact.Name; //身份类型

            //this.lblNational.Text = prePatientInfo.Country.Name;// 国籍
            //this.lblHomeZip.Text = prePatientInfo.HomeZip; //家庭邮编
            //this.lblTel.Text = prePatientInfo.Kin.RelationPhone; //联系电话
            //this.relaName.Text = prePatientInfo.Kin.ID; //联系人姓名
            
            //this.neuLabel8.Text = pact.Name;

            //this.lblRelations.Text = prePatientInfo.Kin.Relation.Name; //与患者关系

            //this.lblProvice.Text = prePatientInfo.AddressHome;

            //if (!string.IsNullOrEmpty(prePatientInfo.MaritalStatus.Name))
            //{
            //    this.isMarried.Text = prePatientInfo.MaritalStatus.Name;
            //}
            //else
            //{
            //    this.isMarried.Text = "未知";
            //}
            return 1;
        }
        
        public int Print()
        {
            this.SetVisible(true);
            p.PrintPage(100, 50, this.neuPanel1);
            return 1;
        }

        public int PrintView()
        {
            this.SetVisible(true);
            p.PrintPreview(100, 50, this.neuPanel1);
            return 1;
        }
        #endregion

        #region 事件
        private void ucInpatientNoticeList_Load(object sender, EventArgs e)
        {
            //加载济南中心医院图片
            
        }
        #endregion
    }
}

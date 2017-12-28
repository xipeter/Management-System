using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace UFC.HealthRecord
{
    public partial class ucCaseMainInfo : System.Windows.Forms.UserControl
    {
        public ucCaseMainInfo()
        {
            InitializeComponent();
        }

        #region  全局变量

        //icd10诊断下拉列表
        private Neusoft.NFC.Interface.Controls.PopUpListBox ICDListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        //但前活动控件
        private System.Windows.Forms.Control contralActive = new Control();
        //当前活动下拉列表
        private Neusoft.NFC.Interface.Controls.PopUpListBox listBoxActive = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        //标志 标识是医生站用还是病案调用
        private Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes frmType;
        //暂存当前修改人的病案基本信息
        private Neusoft.HISFC.Object.HealthRecord.Base CaseBase = new Neusoft.HISFC.Object.HealthRecord.Base();
        //病案基本信息操作类
        private Neusoft.HISFC.Management.HealthRecord.Base baseDml = new Neusoft.HISFC.Management.HealthRecord.Base();
        private Neusoft.HISFC.Management.HealthRecord.DeptShift deptShift = new Neusoft.HISFC.Management.HealthRecord.DeptShift();
        private Neusoft.HISFC.Integrate.Fee  feeMgr = new Neusoft.HISFC.Integrate.Fee();
        //定义变量
        Neusoft.HISFC.Management.Manager.Constant con = new Neusoft.HISFC.Management.Manager.Constant();
        #region 下拉列表
        //性别
        private Neusoft.NFC.Interface.Controls.PopUpListBox SexListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper SexTypeHelper = new Neusoft.NFC.Public.ObjectHelper();
        //国籍
        private Neusoft.NFC.Interface.Controls.PopUpListBox CountryListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper CountryHelper = new Neusoft.NFC.Public.ObjectHelper();
        //民族列表
        private Neusoft.NFC.Interface.Controls.PopUpListBox NationalListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper NationalHelper = new Neusoft.NFC.Public.ObjectHelper();
        //职业列表
        private Neusoft.NFC.Interface.Controls.PopUpListBox ProfessionListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper ProfessionHelper = new Neusoft.NFC.Public.ObjectHelper();
        //血型编码
        private Neusoft.NFC.Interface.Controls.PopUpListBox BloodTypeListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper BloodTypeHelper = new Neusoft.NFC.Public.ObjectHelper();
        //婚姻
        private Neusoft.NFC.Interface.Controls.PopUpListBox MaritalStatusListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper MaritalStatusHelper = new Neusoft.NFC.Public.ObjectHelper();
        //结算类别
        private Neusoft.NFC.Interface.Controls.PopUpListBox pactKindListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper pactKindHelper = new Neusoft.NFC.Public.ObjectHelper();
        //与联系人关系
        private Neusoft.NFC.Interface.Controls.PopUpListBox RelationListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper RelationHelper = new Neusoft.NFC.Public.ObjectHelper();
        //医生护士等人员列表
        private Neusoft.NFC.Interface.Controls.PopUpListBox DoctorListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper DoctorHelper = new Neusoft.NFC.Public.ObjectHelper();
        //病人来源
        private Neusoft.NFC.Interface.Controls.PopUpListBox InAvenueListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper InAvenueHelper = new Neusoft.NFC.Public.ObjectHelper();
        //入院情况
        private Neusoft.NFC.Interface.Controls.PopUpListBox CircsListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper CircsHelper = new Neusoft.NFC.Public.ObjectHelper();
        //药物过敏 
        private Neusoft.NFC.Interface.Controls.PopUpListBox HbsagListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper HbsagHelper = new Neusoft.NFC.Public.ObjectHelper();
        //诊断符合
        private Neusoft.NFC.Interface.Controls.PopUpListBox diagAccordListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper diagAccordHelper = new Neusoft.NFC.Public.ObjectHelper();
        //病案质量 
        private Neusoft.NFC.Interface.Controls.PopUpListBox CaseQCListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper CaseQCHelper = new Neusoft.NFC.Public.ObjectHelper();
        //RH 性质
        private Neusoft.NFC.Interface.Controls.PopUpListBox RHListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper RHListHelper = new Neusoft.NFC.Public.ObjectHelper();
        //科室下拉列表
        private Neusoft.NFC.Interface.Controls.PopUpListBox DeptListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        //血液反应
        private Neusoft.NFC.Interface.Controls.PopUpListBox ReactionBloodListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper ReactionBloodHelper = new Neusoft.NFC.Public.ObjectHelper();
        //籍贯 家庭住址 联系人地址
        private Neusoft.NFC.Interface.Controls.PopUpListBox AddressHomeListBox = new Neusoft.NFC.Interface.Controls.PopUpListBox();
        private Neusoft.NFC.Public.ObjectHelper AddressHomeListHelper = new Neusoft.NFC.Public.ObjectHelper();
        #endregion
        //门诊诊断 
        private Neusoft.HISFC.Object.HealthRecord.Diagnose clinicDiag = null;
        //入院诊断 
        private Neusoft.HISFC.Object.HealthRecord.Diagnose InDiag = null;
        //转科信息
        ArrayList changeDept = new ArrayList();
        //第一次转科
        private Neusoft.HISFC.Object.RADT.Location firDept = null;
        //第二次转科信息
        private Neusoft.HISFC.Object.RADT.Location secDept = null;
        //第三次转科信息
        private Neusoft.HISFC.Object.RADT.Location thirDept = null;
        //标识手工输入的状态是插入还是更新  0默认状态  1  插入 2更新  
        private int HandCraft = 0;

        //		//入院诊断的标志位  0 默认， 1 修改 ，2 插入， 3 删除 
        //		public int RuDiag = 0;
        //		//门诊诊断的标志位  0 默认， 1 修改 ，2 插入， 3 删除 
        //		public int menDiag = 0;
        //保存病案的状态
        private int CaseFlag = 0;
        //提示窗体
        //ucDiagNoseCheck frm = null; //zjy
        private Neusoft.NFC.Object.NeuObject localObj = new Neusoft.NFC.Object.NeuObject();
        #endregion 

        public int InitCaseMainInfo()
        {
            //ICD10 诊断
            InitSexList(); //性别
            InitCountryList();//国际
            return 1;
        }

        #region  所有的下拉列表
       
        //初始化性别下拉菜单
        private int InitSexList()
        {	//获取列表
            ArrayList list = Neusoft.HISFC.Object.Base.SexEnumService.List();
            SexTypeHelper.ArrayObject = list;
            return 1;
        }
        private int InitCountryList()
        {
            //g查询国家列表
            ArrayList list = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.COUNTRY);
            CountryHelper.ArrayObject = list;
            this.Country.AddItems(list);

            //查询民族列表
            ArrayList Nationallist1 = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.NATION);
            NationalHelper.ArrayObject = Nationallist1;
            this.Nationality.AddItems(Nationallist1);

            //查询职业列表
            ArrayList Professionlist = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.PROFESSION);
            ProfessionHelper.ArrayObject = Professionlist;
            this.Profession.AddItems(Professionlist);
            //血型列表
            ArrayList BloodTypeList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.BLOODTYPE);
            BloodTypeHelper.ArrayObject = BloodTypeList;
            this.BloodType.AddItems(BloodTypeList);
            //婚姻列表
            ArrayList MaritalStatusList = Neusoft.HISFC.Object.RADT.MaritalStatusEnumService.List();
            MaritalStatusHelper.ArrayObject = MaritalStatusList;
            this.MaritalStatus.AddItems(MaritalStatusList);
            //结算类别
            ArrayList pactKindlist = feeMgr.QueryPactUnitAll();
            pactKindHelper.ArrayObject = pactKindlist;
            this.pactKind.AddItems(pactKindlist);
            //与联系人关系
            ArrayList RelationList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.RELATIVE);
            RelationHelper.ArrayObject = RelationList;
            this.Relation.AddItems(RelationList);

            Neusoft.HISFC.Management.Manager.Person person = new Neusoft.HISFC.Management.Manager.Person();
            //获取医生列表
            ArrayList DoctorList = person.GetEmployeeAll();//.GetEmployee(Neusoft.HISFC.Object.RADT.PersonType.enuPersonType.D);
            DoctorHelper.ArrayObject = DoctorList;
            ClinicDocd.AddItems(DoctorList);//门诊医生 
            AdmittingDoctor.AddItems(DoctorList);//住院医生
            RefresherDocd.AddItems(DoctorList);//进修医师 
            GraDocCode.AddItems(DoctorList);//研究生实习医师 
            PraDocCode.AddItems(DoctorList);//实习医生 
            AttendingDoctor.AddItems(DoctorList); //主治医师
            ConsultingDoctor.AddItems(DoctorList);//主任医师
            QcNucd.AddItems(DoctorList);//质控护士
            QcDocd.AddItems(DoctorList);//质控医生
            CodingCode.AddItems(DoctorList);//编码员
            textBox33.AddItems(DoctorList);//整理员

            //获取病人来源
            //			ArrayList InAvenuelist = baseDml.GetPatientSource();
            ArrayList InAvenuelist = con.GetAllList(Neusoft.HISFC.Object.Base.EnumConstant.INAVENUE);
            InAvenueHelper.ArrayObject = InAvenuelist;
            InAvenue.AddItems(InAvenuelist); 

            //入院情况
            ArrayList CircsList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.INCIRCS);
            CircsHelper.ArrayObject = CircsList;
            this.Circs.AddItems(CircsList);
            //药物过敏
            ArrayList arraylist = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.PHARMACYALLERGIC);
            HbsagHelper.ArrayObject = arraylist;
            this.Hbsag.AddItems(arraylist);

            //诊断符合情况
            ArrayList diagAccord = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.DIAGNOSEACCORD);
            diagAccordHelper.ArrayObject = diagAccord;
            CePi.AddItems(diagAccord);
            PiPo.AddItems(diagAccord);
            OpbOpa.AddItems(diagAccord);
            ClPa.AddItems(diagAccord);
            FsBl.AddItems(diagAccord);

            //病案质量
            ArrayList qcList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.CASEQUALITY);
            CaseQCHelper.ArrayObject = qcList;
            MrQual.AddItems(qcList);

            //RH性质 
            ArrayList RHList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.RHSTATE); 
            RHListHelper.ArrayObject = RHList;
            RhBlood.AddItems(RHList);

            //科室下拉列表
            Neusoft.HISFC.Management.Manager.Department dept = new Neusoft.HISFC.Management.Manager.Department();
            ArrayList deptList = dept.GetInHosDepartment();
            firstDept.AddItems(deptList);
            deptSecond.AddItems(deptList);
            deptThird.AddItems(deptList);
            DeptInHospital.AddItems(deptList);
            deptOut.AddItems(deptList);

            //血液反应

            ArrayList ReactionBloodList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.BLOODREACTION); 
            ReactionBloodHelper.ArrayObject = ReactionBloodList;
            //籍贯 家庭住址 联系人地址
            ArrayList AddressHomeList = con.GetList(Neusoft.HISFC.Object.Base.EnumConstant.AREA);
            AddressHomeListHelper.ArrayObject = AddressHomeList;

            return 1;
        }

        #endregion

        #region 事件

        #region 性别
        private void PatientSex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                patientBirthday.Focus();
            }
        }
        #endregion
        #region 门诊诊断
        private void ClinicDiag_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ClinicDocd.Focus();
            }
        }
        #endregion
        #region 国籍
        private void Country_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DIST.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                CountryListBox.PriorRow();
            }
            else if (e.KeyData == Keys.Down)
            {
                CountryListBox.NextRow();
            }
        }
        #endregion
        #region  民族
        private void Nationality_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Country.Focus();
            }
        }
        #endregion
        #region  血型
        private void BloodType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.RhBlood.Focus();
            }
        }
        #endregion
        #region 婚姻
        private void MaritalStatus_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Profession.Focus();
            } 
        }
        #endregion
        #region 职业
        private void Profession_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AreaCode.Focus();
            } 
        }
        #endregion
        #region 联系人关系
        private void Relation_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                LinkmanTel.Focus();
            } 
        }
        #endregion
        #region  入院情况 
        private void Circs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                firstDept.Focus();
            } 
        } 
        #endregion
        #region 门诊医生 
        private void ClinicDocd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.PiDays.Focus();
            } 
        }
        #endregion
        #region 病人来源
        private void InAvenue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.infectNum.Focus();
            } 
        }
        #endregion
        #region 药物过敏 
        private void Hbsag_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                HcvAb.Focus();
            } 
        }  
        private void HcvAb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                HivAb.Focus();
            }
        }  
        private void HivAb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.CePi.Focus();
            } 
        }
        #endregion
        #region 诊断符合

        private void CePi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PiPo.Focus();
            } 
        }  
        private void PiPo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OpbOpa.Focus();
            } 
        } 
        private void OpbOpa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.ClPa.Focus();
            } 
        }  
        private void ClPa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                FsBl.Focus();
            } 
        }  
        private void FsBl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SalvTimes.Focus();
            } 
        } 
        #endregion
        #region  住院医生 
        private void AdmittingDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                RefresherDocd.Focus();
            } 
        }
        #endregion
        #region 进修医师 
        private void RefresherDocd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                GraDocCode.Focus();
            } 
        } 
        #endregion
        #region 研究生实习医师 
        private void GraDocCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CheckDate.Focus();
            } 
        }
        #endregion
        #region 实习医生 
        private void PraDocCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CodingCode.Focus();
            } 
        }

        #endregion
        #region  主治医师 
        private void AttendingDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AdmittingDoctor.Focus();
            } 
        }
        #endregion
        #region 主任医师
        private void ConsultingDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AttendingDoctor.Focus();
            } 
        }
        #endregion
        #region  质控护士 
        private void QcNucd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ConsultingDoctor.Focus();
            } 
        } 
        #endregion
        #region 质控医生 
        private void QcDocd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                QcNucd.Focus();
            } 
        } 
        #endregion
        #region 编码员 
        private void CodingCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox33.Focus();
            } 
        }
        #endregion
        #region 整理员
        private void textBox33_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OperationCode.Focus();
            } 
        } 
        #endregion
        #region 病案质量 
        private void MrQual_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                QcDocd.Focus();
            } 
        } 
        #endregion
        #region  输血反映 
        private void ReactionBlood_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (ReactionBlood.Tag != null)
                {
                    if (ReactionBlood.Tag.ToString() != "2")
                    {
                        BloodRed.Focus();
                    }
                    else
                    {
                        //院际会诊次数
                        InconNum.Focus();
                    }
                }
                else
                {
                    BloodRed.Focus();
                }
            } 
        } 
        #endregion
        #region 输入员 
        private void InputDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //单独判断 先跳到诊断吧
                //this.tab1.SelectedIndex = 1;
            } 
        } 
        #endregion
        #region  入院诊断 
        private void RuyuanDiagNose_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //单独判断 先跳到诊断
                this.ComeFrom.Focus();
            } 
        } 
        #endregion
        #region  入院科室 
        private void DeptInHospital_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Date_In.Focus();
            } 
        }
        #endregion
        #region  RH反应
        private void RhBlood_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.ReactionBlood.Focus();
            } 
        } 
        #endregion
        #region  出生地 
        private void AreaCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Nationality.Focus();
            } 
        } 
        #endregion
        #region 转科1
        private void firstDept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.dateTimePicker3.Focus();
            } 
        } 
        #endregion
        #region 转科 2 
        private void deptSecond_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.dateTimePicker4.Focus();
            } 
        } 
        #endregion
        #region  转科3 
        private void deptThird_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.dateTimePicker5.Focus();
            } 
        } 
        #endregion
        #region 出院科室 
        private void deptOut_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Date_Out.Focus();
            } 
        } 
        #endregion
        #region 结算类别 
        private void pactKind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SSN.Focus();
            } 
        }

        #endregion
        #endregion

        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public int SaveInfo()
        {
            #region  判断诊断是否符合约束
            Neusoft.HISFC.Management.HealthRecord.Diagnose diagNose = new Neusoft.HISFC.Management.HealthRecord.Diagnose();
            if (this.frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC) //医生站提示 病案室不需要提示
            {
                if (DiagValueState(diagNose) != 1)
                {
                    return -1;
                }
            }

            System.DateTime dt = diagNose.GetDateTimeFromSysDateTime(); //获取系统时间
            #endregion
            #region  判断住院号和住院次数是否已经存在
            int intI = baseDml.ExistCase(this.CaseBase.PatientInfo.ID, caseNum.Text, InTimes.Text);
            if (intI == -1)
            {
                MessageBox.Show("查询数据失败");
                return -1;
            }
            if (intI == 2)
            {
                MessageBox.Show(caseNum.Text + " 的" + "第 " + InTimes.Text + " 次入院已经存在,请更改入院次数");
                return -1;
            }
            #endregion
            //建立事务
            Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction(baseDml.Connection);
            try
            {

                if (CaseBase == null)
                {
                    return -2;
                }
                if (CaseBase.PatientInfo.ID == "")
                {
                    MessageBox.Show("请指定要保存病案的病人");
                    return -2;
                }
                if (CaseBase.PatientInfo.CaseState == "0")
                {
                    MessageBox.Show("病人不允许有病案");
                    return 0;
                }
                if (this.frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC && CaseBase.PatientInfo.CaseState == "3")
                {
                    MessageBox.Show("病案室已经存档不允许再修改");
                    return -3;
                }
                if (this.frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC && (HandCraft == 1 || HandCraft == 2))
                {
                    MessageBox.Show("病案室已经存档不允许修改");
                    return -3;
                }
                if (CaseBase.PatientInfo.CaseState == "4")
                {
                    MessageBox.Show("病人病案已经封存，不允许保存");
                    return -4;
                }
                if (HandCraft == 1) //手工录入 插入
                {
                    CaseBase.PatientInfo.CaseState = "1";
                }
                if (HandCraft == 2) //手工录入修改 
                {
                    CaseBase.PatientInfo.CaseState = "2";
                }
                trans.BeginTransaction();
                baseDml.SetTrans(trans.Trans);
                diagNose.SetTrans(trans.Trans);

                #region 病案基本信息
                Neusoft.HISFC.Object.HealthRecord.Base info = new Neusoft.HISFC.Object.HealthRecord.Base();
                int i = this.GetInfoFromPanel(info);
                if (ValidState(info) == -1)
                {
                    trans.RollBack();
                    return -1;
                }
                //先执行更新操作 
                if (baseDml.UpdateBaseInfo(info) < 1)
                {
                    //更新失败 则执行插入操作 
                    if (baseDml.InsertBaseInfo(info) < 1)
                    {
                        //回退
                        trans.RollBack();
                        MessageBox.Show("保存病人基本信息失败 :" + baseDml.Err);
                        return -1;
                    }
                }

                #endregion

                #region  保存成功

                //根据目前病案标志 修改住院主表的病案信息
                if (this.frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC)
                {
                    //医生站录入病案
                    if (baseDml.UpdateMainInfoCaseFlag(CaseBase.PatientInfo.ID, "2") < 1)
                    {
                        trans.RollBack();
                        MessageBox.Show("更新主表失败" + baseDml.Err);
                        return -1;
                    }
                    CaseBase.PatientInfo.CaseState = "2";
                }
                else if (this.frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS) //病案室录入病案
                {
                    if (baseDml.UpdateMainInfoCaseFlag(CaseBase.PatientInfo.ID, "3") < 1)
                    {
                        trans.RollBack();
                        MessageBox.Show("更新主表 case_flag 失败" + baseDml.Err);
                        return -1;
                    }
                    if (baseDml.UpdateMainInfoCaseSendFlag(CaseBase.PatientInfo.ID, "1") < 1)
                    {
                        trans.RollBack();
                        MessageBox.Show("更新主表casesend_flag 失败" + baseDml.Err);
                        return -1;
                    }
                    CaseBase.PatientInfo.CaseState = "3";
                }

                //费用信息
                trans.Commit();

                #region 后续工作
                //更新病案基本表中 门诊诊断，入院诊断，出院诊断 ，手术 （第一诊断 或手术）
                if (baseDml.UpdateBaseDiagAndOperation(CaseBase.PatientInfo.ID, frmType) == -1)
                {
                    trans.RollBack();
                    MessageBox.Show("更新病案主表诊断手术信息失败.");
                    return -1;
                }
                localObj.User01 = CaseBase.PatientInfo.PVisit.OutTime.ToString(); //出院一起
                localObj.User02 = CaseBase.PatientInfo.PVisit.PatientLocation.ID; //出院科室 
                if (baseDml.DiagnoseAndOperation(localObj, CaseBase.PatientInfo.ID) == -1)
                {
                    trans.RollBack();
                    MessageBox.Show("更新病案主表诊断手术信息失败.");
                    return -1;
                }
                trans.Commit();
                #endregion
                //手工录入病案标志置成默认标志 
                this.HandCraft = 0;
                #endregion
            }
            catch (Exception ex)
            {
                trans.RollBack();
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;
        }
        #endregion 

        /// <summary>
        /// 将数据显示到界面上
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int ConvertInfoToPanel(Neusoft.HISFC.Object.HealthRecord.Base info)
        {
            try
            {
                #region  入院科室，出院科室
                if (CaseBase.PatientInfo.CaseState == "1")
                {
                    Neusoft.HISFC.Object.RADT.Location indept = baseDml.GetDeptIn(CaseBase.PatientInfo.ID);
                    Neusoft.HISFC.Object.RADT.Location outdept = baseDml.GetDeptOut(CaseBase.PatientInfo.ID);
                    if (indept != null) //入院科室 
                    {
                        CaseBase.InDept.ID = indept.Dept.ID;
                        CaseBase.InDept.Name = indept.Dept.Name;
                        //入院科室代码
                        DeptInHospital.Tag = indept.Dept.ID;
                        //入院科室名称
                        DeptInHospital.Text = indept.Dept.Name;

                    }
                    //出院科室
                    CaseBase.OutDept.ID = info.PatientInfo.PVisit.PatientLocation.Dept.ID;
                    CaseBase.OutDept.Name = info.PatientInfo.PVisit.PatientLocation.Dept.Name;
                    //出院科室代码
                    deptOut.Tag = info.PatientInfo.PVisit.PatientLocation.Dept.ID;
                    //出院科室名称
                    deptOut.Text = info.PatientInfo.PVisit.PatientLocation.Dept.Name;
                }
                else
                {
                    //入院科室代码
                    DeptInHospital.Tag = info.InDept.ID;
                    //入院科室名称
                    DeptInHospital.Text = info.InDept.Name;
                    //出院科室代码
                    deptOut.Tag = info.OutDept.ID;
                    //出院科室名称
                    deptOut.Text = info.OutDept.Name;
                }

                #endregion

                //住院号  病历号
                caseNum.Text = info.PatientInfo.PID.PatientNO;
                //就诊卡号  门诊号
                clinicNo.Text = info.PatientInfo.PID.CardNO;
                //姓名
                this.PatientName.Text = info.PatientInfo.Name;
                //曾用名
                Nomen.Text = info.Nomen;
                //性别
                if (info.PatientInfo.Sex.ID != null)
                {
                    PatientSex.Tag = info.PatientInfo.Sex.ID.ToString();
                    PatientSex.Text = SexTypeHelper.GetName(info.PatientInfo.Sex.ID.ToString());
                }
                //生日
                if (info.PatientInfo.Birthday != System.DateTime.MinValue)
                {
                    patientBirthday.Value = info.PatientInfo.Birthday;
                }
                else
                {
                    patientBirthday.Value = System.DateTime.Now;
                }
                //国籍 编码
                Country.Tag = info.PatientInfo.Country.ID;
                //国籍名称
                Country.Text = CountryHelper.GetName(info.PatientInfo.Country.ID);
                //民族 
                Nationality.Tag = info.PatientInfo.Nationality.ID;
                Nationality.Text = NationalHelper.GetName(info.PatientInfo.Nationality.ID);
                //职业
                Profession.Tag = info.PatientInfo.Profession.ID;
                Profession.Text = ProfessionHelper.GetName(info.PatientInfo.Profession.ID);

                //血型编码
                if (info.PatientInfo.BloodType.ID != null)
                {
                    BloodType.Text = info.PatientInfo.BloodType.ID.ToString();
                }
                //婚姻
                if (info.PatientInfo.MaritalStatus.ID != null)
                {
                    MaritalStatus.Tag = info.PatientInfo.MaritalStatus.ID;
                    MaritalStatus.Text = MaritalStatusHelper.GetName(info.PatientInfo.MaritalStatus.ID.ToString());
                }
                //年龄 如果是从病案表里读出来的 要 拼凑
                if (info.PatientInfo.CaseState == "2" || info.PatientInfo.CaseState == "3" || info.PatientInfo.CaseState == "4")
                {
                    PatientAge.Text = info.PatientInfo.Age.ToString() + info.AgeUnit;
                }
                else
                {
                    //如果是从住院主表里读出来的不用拼凑
                    PatientAge.Text = info.PatientInfo.Age;
                }
                //身份证号
                IDNo.Text = info.PatientInfo.IDCard;
                //结算类别号
                pactKind.Tag = info.PatientInfo.Pact.PayKind.ID;
                pactKind.Text = pactKindHelper.GetName(info.PatientInfo.Pact.PayKind.ID);
                //医保公费号
                SSN.Text = info.PatientInfo.SSN;
                //籍贯
                DIST.Text = info.PatientInfo.DIST;
                //出生地
                AreaCode.Tag = info.PatientInfo.AreaCode;
                AreaCode.Text = AddressHomeListHelper.GetName(info.PatientInfo.AreaCode);
                if (AreaCode.Text == "")
                {
                    AreaCode.Text = info.PatientInfo.AreaCode;
                }
                //家庭住址
                AddressHome.Text = info.PatientInfo.AddressHome;
                //家庭电话
                PhoneHome.Text = info.PatientInfo.PhoneHome;
                //住址邮编
                if (info.PatientInfo.CaseState == "1")
                {
                    HomeZip.Text = info.PatientInfo.User02;
                }
                else
                {
                    HomeZip.Text = info.PatientInfo.HomeZip;
                }
                //单位地址
                if (info.PatientInfo.CaseState == "1")
                {
                    AddressBusiness.Text = info.PatientInfo.CompanyName;
                }
                else
                {
                    AddressBusiness.Text = info.PatientInfo.AddressBusiness;
                }
                //单位电话
                PhoneBusiness.Text = info.PatientInfo.PhoneBusiness;
                //单位邮编
                if (info.PatientInfo.CaseState == "1")
                {
                    BusinessZip.Text = info.PatientInfo.User01;
                }
                else
                {
                    BusinessZip.Text = info.PatientInfo.BusinessZip;
                }
                //联系人名称
                Kin.Text = info.PatientInfo.Kin.Name;
                Kin.Tag = info.PatientInfo.Kin.ID;
                //与患者关系
                Relation.Tag = info.PatientInfo.Kin.Relation.ID;
                Relation.Text = RelationHelper.GetName(info.PatientInfo.Kin.Relation.ID);
                //联系电话
                if (info.PatientInfo.CaseState == "1")
                {
                    LinkmanTel.Text = info.PatientInfo.Kin.Memo;
                }
                else
                {
                    LinkmanTel.Text = info.PatientInfo.Kin.RelationPhone;
                }
                //联系地址
                if (info.PatientInfo.CaseState == "1")
                {
                    LinkmanAdd.Text = info.PatientInfo.Kin.User01;
                }
                else
                {
                    LinkmanAdd.Text = info.PatientInfo.Kin.RelationAddress;
                }
                //门诊诊断医生 ID
                ClinicDocd.Tag = info.ClinicDoc.ID;
                //门诊诊断医生姓名
                ClinicDocd.Text = info.ClinicDoc.Name;
                //转来医院
                ComeFrom.Text = info.ComeFrom;
                //入院日期
                if (info.PatientInfo.PVisit.InTime != System.DateTime.MinValue)
                {
                    Date_In.Value = info.PatientInfo.PVisit.InTime;
                }
                else
                {
                    Date_In.Value = System.DateTime.Now;
                }
                if (info.PatientInfo.CaseState == "1")
                {
                    //院感次数 
                    infectNum.Text = "0";
                }
                else
                {
                    //院感次数 
                    infectNum.Text = info.InfectionNum.ToString();
                }
                //住院次数
                InTimes.Text = info.PatientInfo.InTimes.ToString();
                //入院来源

                InAvenue.Tag = info.PatientInfo.PVisit.InSource.ID;
                InAvenue.Text = InAvenueHelper.GetName(info.PatientInfo.PVisit.InSource.ID);

                //入院状态                  
                Circs.Tag = info.PatientInfo.PVisit.Circs.ID;
                Circs.Text = this.CircsHelper.GetName(info.PatientInfo.PVisit.Circs.ID);
                //确诊日期
                if (info.DiagDate != System.DateTime.MinValue)
                {
                    DiagDate.Value = info.DiagDate;
                }
                else
                {
                    DiagDate.Value = System.DateTime.Now;
                }
                //手术日期
                //			info.OperationDate 
                //出院日期
                if (info.PatientInfo.PVisit.OutTime != System.DateTime.MinValue)
                {
                    Date_Out.Value = info.PatientInfo.PVisit.OutTime;
                }
                else
                {
                    Date_Out.Value = System.DateTime.Now;
                }

                //转归代码
                //			info.PatientInfo.PVisit.Zg.ID 
                //确诊天数
                //			info.DiagDays
                //住院天数
                PiDays.Text = info.InHospitalDays.ToString();
                //死亡日期
                //			info.DeadDate = 
                //死亡原因
                //			info.DeadReason
                //尸检
                if (info.CadaverCheck == "1")
                {
                    BodyCheck.Checked = true;
                }
                //死亡种类
                //			info.DeadKind 
                //尸体解剖号
                //			info.BodyAnotomize
                //乙肝表面抗原
                Hbsag.Tag = info.Hbsag;
                Hbsag.Text = HbsagHelper.GetName(info.Hbsag);
                if (Hbsag.Tag == null)
                {
                    Hbsag.Tag = "0";
                    Hbsag.Text = "未做";
                }
                //丙肝病毒抗体
                HcvAb.Tag = info.HcvAb;
                HcvAb.Text = HbsagHelper.GetName(info.HcvAb);
                if (HcvAb.Tag == null)
                {
                    HcvAb.Tag = "0";
                    HcvAb.Text = "未做";
                }
                //获得性人类免疫缺陷病毒抗体
                HivAb.Tag = info.HivAb;
                HivAb.Text = HbsagHelper.GetName(info.HivAb);
                if (HivAb.Tag == null)
                {
                    HivAb.Tag = "0";
                    HivAb.Text = "未做";
                }
                //门急_出院符合
                CePi.Tag = info.CePi;
                CePi.Text = diagAccordHelper.GetName(info.CePi);
                if (CePi.Tag == null)
                {
                    CePi.Tag = "0";
                    CePi.Text = "未做";
                }
                //入出_院符合
                PiPo.Tag = info.PiPo;
                PiPo.Text = diagAccordHelper.GetName(info.PiPo);
                if (PiPo.Tag == null)
                {
                    PiPo.Tag = "0";
                    PiPo.Text = "未做";
                }
                //术前_后符合
                OpbOpa.Tag = info.OpbOpa;
                OpbOpa.Text = diagAccordHelper.GetName(info.OpbOpa);
                if (OpbOpa.Tag == null)
                {
                    OpbOpa.Tag = "0";
                    OpbOpa.Text = "未做";
                }
                //临床_病理符合

                //临床_CT符合
                //临床_MRI符合
                //临床_病理符合
                ClPa.Tag = info.ClPa;
                ClPa.Text = diagAccordHelper.GetName(info.ClPa);
                if (ClPa.Tag == null)
                {
                    ClPa.Tag = "0";
                    ClPa.Text = "未做";
                }
                //放射_病理符合
                FsBl.Tag = info.FsBl;
                FsBl.Text = diagAccordHelper.GetName(info.ClPa);
                if (FsBl.Tag == null)
                {
                    FsBl.Tag = "0";
                    FsBl.Text = "未做";
                }
                //抢救次数
                SalvTimes.Text = info.SalvTimes.ToString();
                //成功次数
                SuccTimes.Text = info.SuccTimes.ToString();
                //示教科研
                if (info.TechSerc == "1")
                {
                    TechSerc.Checked = true;
                }
                //是否随诊
                if (info.VisiStat == "1")
                {
                    VisiStat.Checked = true;
                }
                //随访期限 周
                if (info.VisiPeriodWeek == "")
                {
                    VisiPeriWeek.Text = "0";
                }
                else
                {
                    VisiPeriWeek.Text = info.VisiPeriodWeek;
                }
                //随访期限 月
                if (info.VisiPeriodMonth == "")
                {
                    VisiPeriMonth.Text = "0";
                }
                else
                {
                    VisiPeriMonth.Text = info.VisiPeriodMonth;
                }
                //随访期限 年
                if (info.VisiPeriodYear == "")
                {
                    VisiPeriYear.Text = "0";
                }
                else
                {
                    VisiPeriYear.Text = info.VisiPeriodYear;
                }
                //院际会诊次数
                InconNum.Text = info.InconNum.ToString();
                //远程会诊
                outOutconNum.Text = info.OutconNum.ToString();
                //药物过敏
                //			info.AnaphyFlag 
                //过敏药物名称
                //			info.AnaphyName1
                //过敏药物名称
                //			info.AnaphyName2
                //更改后出院日期
                //			info.CoutDate
                //住院医师代码
                AdmittingDoctor.Tag = info.PatientInfo.PVisit.AdmittingDoctor.ID;
                //住院医师姓名
                AdmittingDoctor.Text = info.PatientInfo.PVisit.AdmittingDoctor.Name;
                //主治医师代码
                AttendingDoctor.Tag = info.PatientInfo.PVisit.AttendingDoctor.ID;
                AttendingDoctor.Text = info.PatientInfo.PVisit.AttendingDoctor.Name;
                //主任医师代码
                ConsultingDoctor.Tag = info.PatientInfo.PVisit.ConsultingDoctor.ID;
                ConsultingDoctor.Text = info.PatientInfo.PVisit.ConsultingDoctor.Name;
                //科主任代码
                //			info.PatientInfo.PVisit.ReferringDoctor.ID
                //进修医师代码
                RefresherDocd.Tag = info.RefresherDoc.ID;
                RefresherDocd.Text = info.RefresherDoc.Name;
                //研究生实习医师代码
                GraDocCode.Tag = info.GraduateDoc.ID;
                GraDocCode.Text = info.GraduateDoc.Name;
                //实习医师代码
                PraDocCode.Tag = info.PatientInfo.PVisit.TempDoctor.ID;
                PraDocCode.Text = info.PatientInfo.PVisit.TempDoctor.Name;
                //编码员
                CodingCode.Tag = info.CodingOper.ID;
                CodingCode.Text = info.CodingOper.Name;
                //病案质量
                MrQual.Tag = info.MrQuality;
                MrQual.Text = CaseQCHelper.GetName(info.MrQuality);
                //合格病案
                //			info.MrElig
                //质控医师代码
                QcDocd.Tag = info.QcDoc.ID;
                QcDocd.Text = info.QcDoc.Name;
                //质控护士代码
                QcNucd.Tag = info.QcNurse.ID;
                QcNucd.Text = info.QcNurse.Name;
                //检查时间
                if (info.CheckDate != System.DateTime.MinValue)
                {
                    CheckDate.Value = info.CheckDate;
                }
                else
                {
                    CheckDate.Value = System.DateTime.Now;
                }
                //手术操作治疗检查诊断为本院第一例项目
                if (info.YnFirst == "1")
                {
                    YnFirst.Checked = true;
                }
                //Rh血型(阴阳)
                RhBlood.Tag = info.RhBlood;
                RhBlood.Text = RHListHelper.GetName(info.RhBlood);
                //输血反应（有无）
                ReactionBlood.Tag = info.ReactionBlood;
                ReactionBlood.Text = ReactionBloodHelper.GetName(info.ReactionBlood);
                //红细胞数
                if (info.BloodRed == "" || info.BloodRed == null)
                {
                    BloodRed.Text = "0";
                }
                else
                {
                    BloodRed.Text = info.BloodRed;
                }
                //血小板数
                if (info.BloodPlatelet == "" || info.BloodPlatelet == null)
                {
                    BloodPlatelet.Text = "0";
                }
                else
                {
                    BloodPlatelet.Text = info.BloodPlatelet;
                }
                //血浆数
                if (info.BodyAnotomize == "" || info.BodyAnotomize == null)
                {
                    BodyAnotomize.Text = "0";
                }
                else
                {
                    BodyAnotomize.Text = info.BodyAnotomize;
                }
                //全血数
                if (info.BloodWhole == "" || info.BodyAnotomize == null)
                {
                    BloodWhole.Text = "0";
                }
                else
                {
                    BloodWhole.Text = info.BloodWhole;
                }
                //其他输血数
                if (info.BloodOther == "" || info.BodyAnotomize == null)
                {
                    BloodOther.Text = "0";
                }
                else
                {
                    BloodOther.Text = info.BloodOther;
                }
                //X光号
                XNumb.Text = info.XQty.ToString();
                //CT号
                CtNumb.Text = info.CTQty.ToString();
                //MRI号
                MriNumb.Text = info.MRQty.ToString();
                //病理号
                PathNumb.Text = info.PathNum;
                //DSA号
                //			info.DsaNumb
                //PET号
                //			info.PetNumb
                //ECT号
                //			info.EctNumb
                //X线次数
                //			info.XTimes
                //CT次数
                //			info.CtTimes
                //MR次数
                //			info.MrTimes;
                //DSA次数
                //			info.DsaTimes
                //PET次数
                //			info.PetTimes
                //ECT次数
                //			info.EctTimes
                //说明
                //			info.Memo
                //归档条码号
                //			info.BarCode
                //病案借阅状态(O借出 I在架)
                //			info.LendStus
                //病案状态1科室质检2登记保存3整理4病案室质检5无效
                //			info.CaseStus 
                //特级护理时间
                SuperNus.Text = info.SuperNus.ToString();
                //I级护理时间
                INus.Text = info.INus.ToString();
                //II级护理时间
                IINus.Text = info.IINus.ToString();
                //III级护理时间
                IIINus.Text = info.IIINus.ToString();
                //重症监护时间
                StrictNuss.Text = info.StrictNuss.ToString();
                //特殊护理
                SPecalNus.Text = info.SpecalNus.ToString();
                //输入员
                InputDoc.Tag = info.OperInfo.ID;
                InputDoc.Text = DoctorHelper.GetName(info.OperInfo.ID);
                //整理员 
                textBox33.Tag = info.PackupMan.ID;
                textBox33.Text = DoctorHelper.GetName(info.PackupMan.ID);
                //手术编码员 
                this.OperationCode.Tag = info.OperationCoding.ID;
                this.OperationCode.Text = DoctorHelper.GetName(info.OperationCoding.ID);
                //单病种 
                checkBox8.Checked = Neusoft.NFC.Function.NConvert.ToBoolean(info.Disease30);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
        /// <summary>
        /// 从控制面板上获取数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int GetInfoFromPanel(Neusoft.HISFC.Object.HealthRecord.Base info)
        {

            //住院流水号
            info.PatientInfo.ID = CaseBase.PatientInfo.ID;
            //住院号  病历号
            info.PatientInfo.PID.PatientNO = caseNum.Text;
            info.CaseNO = caseNum.Text;
            //就诊卡号  门诊号
            info.PatientInfo.PID.CardNO = clinicNo.Text;
            //姓名
            info.PatientInfo.Name = PatientName.Text;
            //曾用名
            info.Nomen = Nomen.Text;
            //性别
            if (PatientSex.Tag != null)
            {
                info.PatientInfo.Sex.ID = PatientSex.Tag;
            }
            else
            {
                info.PatientInfo.Sex.ID = CaseBase.PatientInfo.Sex.ID;
            }
            //生日
            info.PatientInfo.Birthday = patientBirthday.Value;
            //国籍
            if (Country.Tag != null)
            {
                info.PatientInfo.Country.ID = Country.Tag.ToString();
            }
            //民族 
            if (Nationality.Tag != null)
            {
                info.PatientInfo.Nationality.ID = Nationality.Tag.ToString();
            }
            //职业
            if (Profession.Tag != null)
            {
                info.PatientInfo.Profession.ID = Profession.Tag.ToString();
            }
            //血型编码
            info.PatientInfo.BloodType.ID = BloodType.Text;
            //婚姻
            if (MaritalStatus.Tag != null)
            {
                info.PatientInfo.MaritalStatus.ID = MaritalStatus.Tag;
            }
            if (PatientAge.Text.Length > 1)
            {
                //年龄单位
                info.AgeUnit = PatientAge.Text.Substring(PatientAge.Text.Length - 1);
                //年龄
                info.PatientInfo.Age = Neusoft.NFC.Function.NConvert.ToInt32(PatientAge.Text.Substring(0, PatientAge.Text.Length - 1)).ToString();
            }
            //身份证号
            info.PatientInfo.IDCard = IDNo.Text;
            //入院途径
            //			if( InSource.Tag != null)
            //			{
            //				info.PatientInfo.PVisit.InSource.ID =  InSource.Tag.ToString();
            //			}
            //结算类别号
            if (pactKind.Tag != null)
            {
                info.PatientInfo.Pact.PayKind.ID = pactKind.Tag.ToString();
                info.PatientInfo.Pact.ID = pactKind.Tag.ToString();
            }
            //医保公费号
            info.PatientInfo.SSN = SSN.Text;
            //籍贯
            info.PatientInfo.DIST = DIST.Text;
            //出生地
            info.PatientInfo.AreaCode = AreaCode.Text;
            //家庭住址
            info.PatientInfo.AddressHome = AddressHome.Text;
            //家庭电话
            info.PatientInfo.PhoneHome = PhoneHome.Text;
            //住址邮编
            info.PatientInfo.HomeZip = HomeZip.Text;
            //单位地址
            info.PatientInfo.AddressBusiness = AddressBusiness.Text;
            //单位电话
            info.PatientInfo.PhoneBusiness = PhoneBusiness.Text;
            //单位邮编
            info.PatientInfo.BusinessZip = BusinessZip.Text;
            //联系人名称
            info.PatientInfo.Kin.Name = Kin.Text;
            //与患者关系
            if (Relation.Tag != null)
            {
                info.PatientInfo.Kin.Relation.ID = Relation.Tag.ToString();
            }
            //联系电话
            info.PatientInfo.Kin.RelationPhone = LinkmanTel.Text;
            //联系地址
            info.PatientInfo.Kin.RelationAddress = LinkmanAdd.Text;
            //门诊诊断医生 ID
            if (ClinicDocd.Tag != null)
            {
                info.ClinicDoc.ID = ClinicDocd.Tag.ToString();
            }
            //门诊诊断医生姓名
            info.ClinicDoc.Name = ClinicDocd.Text;
            //转来医院
            info.ComeFrom = ComeFrom.Text;
            //入院日期
            info.PatientInfo.PVisit.InTime = Date_In.Value;
            //住院次数
            info.PatientInfo.InTimes = Neusoft.NFC.Function.NConvert.ToInt32(InTimes.Text);
            //入院科室代码
            if (DeptInHospital.Tag != null)
            {
                info.InDept.ID = DeptInHospital.Tag.ToString();
            }
            //入院科室名称
            info.InDept.Name = DeptInHospital.Text;
            //入院来源
            if (InAvenue.Tag != null)
            {
                info.PatientInfo.PVisit.InSource.ID = InAvenue.Tag.ToString();
                info.PatientInfo.PVisit.InSource.Name = InAvenue.Text;
            }
            //入院状态
            if (Circs.Tag != null)
            {
                info.PatientInfo.PVisit.Circs.ID = Circs.Tag.ToString();
            }
            //确诊日期
            info.DiagDate = DiagDate.Value;
            //手术日期
            //			info.OperationDate 
            //出院日期
            info.PatientInfo.PVisit.OutTime = Date_Out.Value;
            //出院科室代码
            if (deptOut.Tag != null)
            {
                info.OutDept.ID = deptOut.Tag.ToString();
            }
            //出院科室名称
            info.OutDept.Name = deptOut.Text;
            //转归代码
            //			info.PatientInfo.PVisit.Zg.ID 
            //确诊天数
            //			info.DiagDays
            //住院天数
            info.InHospitalDays = Neusoft.NFC.Function.NConvert.ToInt32(PiDays.Text);
            //死亡日期
            //			info.DeadDate = 
            //死亡原因
            //			info.DeadReason
            //尸检
            if (BodyCheck.Checked)
            {
                info.CadaverCheck = "1";
            }
            else
            {
                info.CadaverCheck = "0";
            }
            //死亡种类
            //			info.DeadKind 
            //尸体解剖号
            //			info.BodyAnotomize
            //乙肝表面抗原
            if (Hbsag.Tag != null)
            {
                info.Hbsag = Hbsag.Tag.ToString();
            }
            //丙肝病毒抗体
            if (HcvAb.Tag != null)
            {
                info.HcvAb = HcvAb.Tag.ToString();
            }
            //获得性人类免疫缺陷病毒抗体
            if (HivAb.Tag != null)
            {
                info.HivAb = HivAb.Tag.ToString();
            }
            //门急_入院符合
            if (CePi.Tag != null)
            {
                info.CePi = CePi.Tag.ToString();
            }
            //入出_院符合
            if (PiPo.Tag != null)
            {
                info.PiPo = PiPo.Tag.ToString();
            }
            //术前_后符合
            if (OpbOpa.Tag != null)
            {
                info.OpbOpa = OpbOpa.Tag.ToString();
            }
            //临床_病理符合

            //临床_CT符合
            //临床_MRI符合
            //临床_病理符合
            if (ClPa.Tag != null)
            {
                info.ClPa = ClPa.Tag.ToString();
            }
            //放射_病理符合
            if (FsBl.Tag != null)
            {
                info.FsBl = FsBl.Tag.ToString();
            }
            //抢救次数
            info.SalvTimes = Neusoft.NFC.Function.NConvert.ToInt32(SalvTimes.Text.Trim());
            //成功次数
            info.SuccTimes = Neusoft.NFC.Function.NConvert.ToInt32(SuccTimes.Text.Trim());
            //示教科研
            if (TechSerc.Checked)
            {
                info.TechSerc = "1";
            }
            else
            {
                info.TechSerc = "0";
            }
            //是否随诊
            if (VisiStat.Checked)
            {
                info.VisiStat = "1";
            }
            else
            {
                info.VisiStat = "0";
            }
            //随访期限 周
            info.VisiPeriodWeek = VisiPeriWeek.Text;
            //随访期限 月
            info.VisiPeriodMonth = VisiPeriMonth.Text;
            //随访期限 年
            info.VisiPeriodYear = VisiPeriMonth.Text;
            //院际会诊次数
            info.InconNum = Neusoft.NFC.Function.NConvert.ToInt32(InconNum.Text.Trim());
            //远程会诊
            info.OutconNum = Neusoft.NFC.Function.NConvert.ToInt32(outOutconNum.Text.Trim());
            //药物过敏
            //			info.AnaphyFlag 
            //过敏药物名称
            //			info.AnaphyName1
            //过敏药物名称
            //			info.AnaphyName2
            //更改后出院日期
            //			info.CoutDate
            //住院医师代码
            if (AdmittingDoctor.Tag != null)
            {
                info.PatientInfo.PVisit.AdmittingDoctor.ID = AdmittingDoctor.Tag.ToString();
                //住院医师姓名
                info.PatientInfo.PVisit.AdmittingDoctor.Name = AdmittingDoctor.Text;
            }
            //主治医师代码
            if (AttendingDoctor.Tag != null)
            {
                info.PatientInfo.PVisit.AttendingDoctor.ID = AttendingDoctor.Tag.ToString();
                info.PatientInfo.PVisit.AttendingDoctor.Name = AttendingDoctor.Text;
            }
            //主任医师代码
            if (ConsultingDoctor.Tag != null)
            {
                info.PatientInfo.PVisit.ConsultingDoctor.ID = ConsultingDoctor.Tag.ToString();
                info.PatientInfo.PVisit.ConsultingDoctor.Name = ConsultingDoctor.Text;
            }
            //科主任代码
            //			info.PatientInfo.PVisit.ReferringDoctor.ID
            //进修医师代码
            if (RefresherDocd.Tag != null)
            {
                info.RefresherDoc.ID = RefresherDocd.Tag.ToString();
                info.RefresherDoc.Name = RefresherDocd.Text;
            }
            //研究生实习医师代码
            if (GraDocCode.Tag != null)
            {
                info.PatientInfo.PVisit.TempDoctor.ID = GraDocCode.Tag.ToString();
                info.PatientInfo.PVisit.TempDoctor.Name = GraDocCode.Text.Trim();
            }
            //实习医师代码
            if (PraDocCode.Tag != null)
            {
                info.GraduateDoc.ID = PraDocCode.Tag.ToString();
                info.GraduateDoc.Name = PraDocCode.Text.Trim();
            }
            //编码员
            if (CodingCode.Tag != null)
            {
                info.CodingOper.ID = CodingCode.Tag.ToString();
                info.CodingOper.Name = CodingCode.Text.Trim();
            }
            //病案质量
            if (MrQual.Tag != null)
            {
                info.MrQuality = MrQual.Tag.ToString();
            }
            //合格病案
            //			info.MrElig
            //质控医师代码
            if (QcDocd.Tag != null)
            {
                info.QcDoc.ID = QcDocd.Tag.ToString();
                info.QcDoc.Name = QcDocd.Text.Trim();
            }
            //质控护士代码
            if (QcNucd.Tag != null)
            {
                info.QcNurse.ID = QcNucd.Tag.ToString();
                info.QcNurse.Name = QcNucd.Text.Trim();
            }
            //检查时间
            info.CheckDate = CheckDate.Value;
            //手术操作治疗检查诊断为本院第一例项目
            if (YnFirst.Checked)
            {
                info.YnFirst = "1";
            }
            else
            {
                info.YnFirst = "0";
            }
            //Rh血型(阴阳)
            if (RhBlood.Tag != null)
            {
                info.RhBlood = RhBlood.Tag.ToString();
            }
            //输血反应（有无）
            if (ReactionBlood.Tag != null)
            {
                info.ReactionBlood = ReactionBlood.Tag.ToString();
            }
            //红细胞数
            info.BloodRed = BloodRed.Text;
            //血小板数
            info.BloodPlatelet = BloodPlatelet.Text;
            //血浆数
            info.BodyAnotomize = BodyAnotomize.Text;
            //全血数
            info.BloodWhole = BloodWhole.Text;
            //其他输血数
            info.BloodOther = BloodOther.Text;
            //X光号
            info.XQty = Neusoft.NFC.Function.NConvert.ToInt32(XNumb.Text);
            //CT号
            info.CTQty = Neusoft.NFC.Function.NConvert.ToInt32(CtNumb.Text);
            //MRI号
            info.MRQty = Neusoft.NFC.Function.NConvert.ToInt32(MriNumb.Text);
            // UFCT 
            info.PathNum = PathNumb.Text;
            if (bchao.Checked)
            {
                info.DsaNum = "1";
            }
            //DSA号
            //			info.DsaNumb
            //PET号
            //			info.PetNumb
            //ECT号
            //			info.EctNumb
            //X线次数
            //			info.XTimes
            //CT次数
            //			info.CtTimes
            //MR次数
            //			info.MrTimes;
            //DSA次数
            //			info.DsaTimes
            //PET次数
            //			info.PetTimes
            //ECT次数
            //			info.EctTimes
            //说明
            //			info.Memo
            //归档条码号
            //			info.BarCode
            //病案借阅状态(O借出 I在架)
            //			info.LendStus
            //病案状态1科室质检2登记保存3整理4病案室质检5无效
            //			info.CaseStus 
            //特级护理时间
            info.SuperNus = Neusoft.NFC.Function.NConvert.ToInt32(SuperNus.Text);
            //I级护理时间
            info.INus = Neusoft.NFC.Function.NConvert.ToInt32(INus.Text);
            //II级护理时间
            info.IINus = Neusoft.NFC.Function.NConvert.ToInt32(IINus.Text);
            //III级护理时间
            info.IIINus = Neusoft.NFC.Function.NConvert.ToInt32(IIINus.Text);
            //重症监护时间
            info.StrictNuss = Neusoft.NFC.Function.NConvert.ToInt32(StrictNuss.Text);
            //特殊护理
            info.SpecalNus = Neusoft.NFC.Function.NConvert.ToInt32(SPecalNus.Text);
            if (InputDoc.Tag != null)
            {
                info.OperInfo.ID = InputDoc.Tag.ToString();
            }
            //整理员 
            if (textBox33.Tag != null)
            {
                info.PackupMan.ID = textBox33.Tag.ToString();
            }
            if (this.OperationCode.Tag != null)
            {
                info.OperationCoding.ID = this.OperationCode.Tag.ToString();
            }
            //单病种 
            if (checkBox8.Checked)
            {
                info.Disease30 = "1";
            }
            else
            {
                info.Disease30 = "0";
            }
            info.LendStat = "1"; //病案借阅状态 0 为借出 1为在架 
            if (this.frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC)
            {
                info.PatientInfo.CaseState = "2";
            }
            else if (this.frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS) //病案室录入病案
            {
                info.PatientInfo.CaseState = "3";
            }
            //是否有并发症
            //info.SyndromeFlag = this.ucDiagNoseInput1.GetSyndromeFlag(); // zjy
            info.InfectionNum = Neusoft.NFC.Function.NConvert.ToInt32(infectNum.Text);  //感染次数
            if (this.CaseBase.LendStat == null || this.CaseBase.LendStat == "") //病案借阅状态 
            {
                info.LendStat = "I";
            }
            else
            {
                info.LendStat = this.CaseBase.LendStat;
            }
            return 0;
        }

        /// <summary>
        /// 根据传入的病人信息的病案状态,加载病案信息 
        /// </summary>
        /// <param name="InpatientNo">病人住院流水号</param>
        /// <param name="Type">类型</param>
        /// <returns>-1 程序出错,或传入的病人信息为空 0 病人不允许有病案 1 手工录入信息 </returns>
        public int LoadInfo(string InpatientNo, Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes Type)
        {
            try
            {
                if (InpatientNo == null || InpatientNo == "")
                {
                    MessageBox.Show("传入的住院流水号为空");
                    return -1;
                }
                Neusoft.HISFC.Integrate.RADT pa = new Neusoft.HISFC.Integrate.RADT();
                Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
                //从住院主表中查旬
                patientInfo = pa.GetPatientInfoByPatientNO(InpatientNo);
                if (patientInfo == null)
                {
                    patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
                }
                //1. 如果 住院主表中有记录则提取信息 写到界面上. 
                //2. 如果住院主表中没有信息 则去病案表中去查询 1如果病案表中有记录 提取信息 加载到界面上  2. 如果病案表中没有记录 则 提示可以手工录入,
                if (patientInfo.ID == "")//住院主表中没有记录
                {
                    //查询病案主表  病人基本信息
                    CaseBase = baseDml.GetCaseBaseInfo(InpatientNo);
                    if (CaseBase.PatientInfo.ID == "") //病案主表中也没有相关基本信息
                    {
                        //赋值住院流水号
                        CaseBase.PatientInfo.ID = InpatientNo;
                        //退出 手工录入信息
                        CaseBase.IsHandCraft = "1";
                        //第一次维护,插入操作 
                        HandCraft = 1;
                        return 1;
                    }
                    else
                    {
                        //以前维护过,更新操作 
                        HandCraft = 2;
                        //手工录病案
                        CaseBase.IsHandCraft = "1";
                    }
                }
                else //住院主表里有记录 
                {
                    CaseBase.PatientInfo =  patientInfo;
                }
                //如果是手工录入病案 可能查询出来的信息都为空 只有传入的InpatientNo 不为空
                this.frmType = Type;
                if (CaseBase.PatientInfo.CaseState == "0")
                {
                    MessageBox.Show("该病人不允许有病案");
                    return 0;
                }
                //保存病案的状态
                CaseFlag = Neusoft.NFC.Function.NConvert.ToInt32(CaseBase.PatientInfo.CaseState);

                #region  转科信息
                //保存转科信息的列表
                ArrayList changeDept = new ArrayList();
                //获取转科信息
                changeDept = deptShift.QueryChangeDeptFromShiftApply(CaseBase.PatientInfo.ID, "2");
                firDept = null;
                secDept = null;
                thirDept = null;
                if (changeDept != null)
                {
                    if (changeDept.Count == 0)
                    {
                        changeDept = deptShift.QueryChangeDeptFromShiftApply(CaseBase.PatientInfo.ID, "1");
                    }
                    //加载 
                    LoadChangeDept(changeDept);
                }
                #endregion
                if (frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC) // 医生站录入病历
                {
                    #region  医生站录入病历

                    //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                    if (CaseBase.PatientInfo.CaseState == "1")
                    {
                        //从住院主表中获取信息 并显示在界面上 
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    // 医生站录入过病历 
                    else if (CaseBase.PatientInfo.CaseState == "2")
                    {
                        //从病案基本表中获取信息 并显示在界面上 
                        CaseBase = baseDml.GetCaseBaseInfo(CaseBase.PatientInfo.ID);
                        CaseBase.PatientInfo.CaseState = CaseFlag.ToString();
                        if (CaseBase == null)
                        {
                            MessageBox.Show("查询病案失败" + baseDml.Err);
                            return -1;
                        }
                        //填充数据 
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    else
                    {
                        // 病案已经封存已经不允许医生修改
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(true);
                    }

                    #endregion
                }
                else if (frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS)//病案室录入病历
                {
                    #region 病案室录入病历
                    //目前允许有病历 并且目前没有录入病历  或者标志位位空（默认是允许录入病历） 
                    if (CaseBase.PatientInfo.CaseState == "1")
                    {
                        //从住院主表中获取信息 并显示在界面上 
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    else if (CaseBase.PatientInfo.CaseState == "2" || CaseBase.PatientInfo.CaseState == "3")
                    {
                        //					//医生站已经录入病案
                        ////					list = diag.QueryCaseDiagnose(patientInfo.ID,"%","1");
                        //				}
                        //				else if( patientInfo.Patient.CaseState == "3")
                        //				{
                        //从病案基本表中获取信息 并显示在界面上 
                        CaseBase = baseDml.GetCaseBaseInfo(CaseBase.PatientInfo.ID);
                        CaseBase.PatientInfo.CaseState = CaseFlag.ToString();
                        if (CaseBase == null)
                        {
                            MessageBox.Show("查询病案失败" + baseDml.Err);
                            return -1;
                        }
                        //填充数据 
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    else if ((CaseBase.PatientInfo.CaseState == "" || CaseBase.PatientInfo.CaseState == null) && CaseBase.IsHandCraft == "1")
                    {
                        //填充数据
                        ConvertInfoToPanel(CaseBase);
                        SetReadOnly(false);
                    }
                    else if (CaseBase.PatientInfo.CaseState == "4")
                    {
                        //病案已经封存 不允许修改。
                        //					MessageBox.Show("病案已经封存,不允许修改");
                        ConvertInfoToPanel(CaseBase);
                        this.SetReadOnly(true); //设为只读 
                    }

                    #endregion
                }
                else
                {
                    //没有传入参数 不作任何处理
                }

                //显示基本信息
                //this.tab1.SelectedIndex = 0;
                //病案号
                this.caseNum.Focus();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
        /// <summary>
        /// 加载前三次转科信息
        /// </summary>
        /// <param name="list"></param>
        private void LoadChangeDept(ArrayList list)
        {
            if (list == null)
            {
                return;
            }

            #region 转科信息的前三个在界面上显示
            if (list.Count > 0) //有转科信息
            {
                //转科信息的前三个在界面上显示
                int j = 0;
                if (list.Count >= 3)
                {
                    j = 3;
                }
                else
                {
                    j = list.Count;
                }
                for (int i = 0; i < j; i++)
                {
                    switch (i)
                    {
                        case 0:
                            firDept = (Neusoft.HISFC.Object.RADT.Location)list[0];
                            break;
                        case 1:
                            secDept = (Neusoft.HISFC.Object.RADT.Location)list[1];
                            break;
                        case 2:
                            thirDept = (Neusoft.HISFC.Object.RADT.Location)list[2];
                            break;
                    }
                }
            }
            #endregion

            #region 转科信息
            if (this.firDept != null)
            {
                firstDept.Text = firDept.Dept.Name;
                firstDept.Tag = firDept.Dept.ID;
                this.dateTimePicker3.Value = Neusoft.NFC.Function.NConvert.ToDateTime(firDept.User01);
            }
            if (this.secDept != null)
            {
                deptSecond.Text = this.secDept.Dept.Name;
                deptSecond.Tag = this.secDept.Dept.ID;
                this.dateTimePicker3.Value = Neusoft.NFC.Function.NConvert.ToDateTime(secDept.User01);
            }
            if (this.thirDept != null)
            {
                deptThird.Text = this.thirDept.Dept.Name;
                deptThird.Tag = this.thirDept.Dept.ID;
                this.dateTimePicker3.Value = Neusoft.NFC.Function.NConvert.ToDateTime(thirDept.User01);
            }
            #endregion
        }

        private void ucCaseMainInfo_Load(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// 加载 入院诊断和门诊诊断
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private int LoadDiag(ArrayList list)
        {
            if (list == null)
            {
                return -1;
            }
            clinicDiag = null;
            InDiag = null;
            #region 先默认输入一个门诊主诊断
            foreach (Neusoft.HISFC.Object.HealthRecord.Diagnose obj in list)
            {
                if (obj.DiagInfo.DiagType.ID == "10" && obj.DiagInfo.IsMain)
                {	//门诊诊断 
                    this.ClinicDiag.Tag = obj.DiagInfo.ICD10.ID;
                    this.ClinicDiag.Text = obj.DiagInfo.ICD10.Name;
                    this.ClinicDocd.Tag = obj.DiagInfo.Doctor.ID;
                    this.ClinicDocd.Text = obj.DiagInfo.Doctor.Name;
                    clinicDiag = obj;
                }
                else if (obj.DiagInfo.DiagType.ID == "11" && obj.DiagInfo.IsMain)
                {	//入院诊断
                    RuyuanDiagNose.Tag = obj.DiagInfo.ICD10.ID;
                    RuyuanDiagNose.Text = obj.DiagInfo.ICD10.Name;
                    InDiag = obj;
                }
            }
            #endregion

            #region 如果没有主诊断 则输入非主诊断诊断
            foreach (Neusoft.HISFC.Object.HealthRecord.Diagnose obj in list)
            {
                if (obj.DiagInfo.DiagType.ID == "10")
                {	//门诊诊断 
                    if (this.ClinicDiag.Tag == null)
                    {
                        this.ClinicDiag.Tag = obj.DiagInfo.ICD10.ID;
                        this.ClinicDiag.Text = obj.DiagInfo.ICD10.Name;
                        this.ClinicDocd.Tag = obj.DiagInfo.Doctor.ID;
                        this.ClinicDocd.Text = obj.DiagInfo.Doctor.Name;
                        clinicDiag = obj;
                    }
                }
                else if (obj.DiagInfo.DiagType.ID == "11")
                {	//入院诊断
                    if (RuyuanDiagNose.Tag == null)
                    {
                        RuyuanDiagNose.Tag = obj.DiagInfo.ICD10.ID;
                        RuyuanDiagNose.Text = obj.DiagInfo.ICD10.Name;
                        InDiag = obj;
                    }
                }
            }
            #endregion
            return 0;
        }

        /// <summary>
        /// 检验数据的合法性
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int ValidState(Neusoft.HISFC.Object.HealthRecord.Base info)
        {
            if (info.PatientInfo.ID.Length > 14)
            {
                MessageBox.Show("住院流水号过长");
                return -1;
            }
            if (info.PatientInfo.PID.PatientNO.Length > 10)
            {
                caseNum.Focus();
                MessageBox.Show("住院号过长");
                return -1;
            }
            if (info.PatientInfo.PID.CardNO.Length > 10)
            {
                clinicNo.Focus();
                MessageBox.Show("就诊卡号过长");
                return -1;
            }
            if (info.PatientInfo.Name.Length > 20)
            {
                PatientName.Focus();
                MessageBox.Show("姓名过长");
                return -1;
            }
            if (info.Nomen.Length > 16)
            {
                Nomen.Focus();
                MessageBox.Show("曾用名过长");
                return -1;
            }
            if (info.PatientInfo.Sex.ID.ToString().Length > 1)
            {
                PatientSex.Focus();
                MessageBox.Show("性别编码过长");
                return -1;
            }

            if (info.PatientInfo.Country.ID.Length > 3)
            {
                Country.Focus();
                MessageBox.Show("国籍编码过长");
                return -1;
            }

            if (info.PatientInfo.Nationality.ID.Length > 2)
            {
                Nationality.Focus();
                MessageBox.Show("民族编码过长");
                return -1;
            }
            if (info.PatientInfo.Profession.ID.Length > 2)
            {
                Profession.Focus();
                MessageBox.Show("职业编码过长");
                return -1;
            }
            if (info.PatientInfo.BloodType.ID != null)
            {
                if (info.PatientInfo.BloodType.ID.ToString().Length > 2)
                {
                    BloodType.Focus();
                    MessageBox.Show("血型编码过长");
                    return -1;
                }
            }
            if (info.PatientInfo.MaritalStatus.ID != null)
            {
                if (info.PatientInfo.MaritalStatus.ID.ToString().Length > 1)
                {
                    MaritalStatus.Focus();
                    MessageBox.Show("婚姻编码过长");
                    return -1;
                }
            }
            if (info.AgeUnit != null)
            {
                if (info.AgeUnit.Length > 1)
                {
                    PatientAge.Focus();
                    MessageBox.Show("年龄单位过长");
                    return -1;
                }
            }

            if (Neusoft.NFC.Function.NConvert.ToInt32(info.PatientInfo.Age) > 999)
            {
                PatientAge.Focus();
                MessageBox.Show("年龄过长");
                return -1;
            }
            if (info.PatientInfo.IDCard.Length > 18)
            {
                IDNo.Focus();
                MessageBox.Show("身份证过长");
                return -1;
            }
            //			if(info.PatientInfo.PVisit.InSource.ID.Length  > 1 )
            //			{
            //				In.Focus();
            //				MessageBox.Show("地区来源编码过长");
            //				return -1;
            //			} 
            if (info.PatientInfo.Pact.PayKind.ID.Length > 02)
            {
                pactKind.Focus();
                MessageBox.Show("结算类别编码过长");
                return -1;
            }

            if (info.PatientInfo.Pact.ID.Length > 10)
            {
                pactKind.Focus();
                MessageBox.Show("合同单位编码过长");
                return -1;
            }

            if (info.PatientInfo.SSN.Length > 18)
            {
                SSN.Focus();
                MessageBox.Show("医保公费号过长");
                return -1;
            }

            if (info.PatientInfo.DIST.Length > 50)
            {
                DIST.Focus();
                MessageBox.Show("籍贯过长");
                return -1;
            }

            if (info.PatientInfo.AddressHome.Length > 50)
            {
                AddressHome.Focus();
                MessageBox.Show("家庭住址过长");
                return -1;
            }

            if (info.PatientInfo.PhoneHome.Length > 25)
            {
                PhoneHome.Focus();
                MessageBox.Show("家庭电话过长");
                return -1;
            }

            if (info.PatientInfo.HomeZip.Length > 25)
            {
                HomeZip.Focus();
                MessageBox.Show("住址邮编过长");
                return -1;
            }

            if (info.PatientInfo.AddressBusiness.Length > 25)
            {
                AddressBusiness.Focus();
                MessageBox.Show("单位地址过长");
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 设置为只读
        /// </summary>
        /// <param name="type"></param>
        public void SetReadOnly(bool type)
        {
            //病案号 
            caseNum.ReadOnly = type;
            caseNum.BackColor = System.Drawing.Color.White;
            //住院次数
            InTimes.ReadOnly = type;
            InTimes.BackColor = System.Drawing.Color.White;
            //费用类别
            pactKind.ReadOnly = type;
            pactKind.BackColor = System.Drawing.Color.White;
            //医保号
            SSN.ReadOnly = type;
            SSN.BackColor = System.Drawing.Color.White;
            //门诊号
            clinicNo.ReadOnly = type;
            clinicNo.BackColor = System.Drawing.Color.White;
            //姓名
            PatientName.ReadOnly = type;
            PatientName.BackColor = System.Drawing.Color.White;
            //性别
            PatientSex.ReadOnly = type;
            PatientSex.BackColor = System.Drawing.Color.White;
            //生日
            patientBirthday.Enabled = !type;
            //年龄
            PatientAge.ReadOnly = type;
            PatientAge.BackColor = System.Drawing.Color.White;
            //婚姻
            MaritalStatus.ReadOnly = type;
            MaritalStatus.BackColor = System.Drawing.Color.White;
            //职业
            Profession.ReadOnly = type;
            Profession.BackColor = System.Drawing.Color.White;
            //出生地
            AreaCode.ReadOnly = type;
            AreaCode.BackColor = System.Drawing.Color.White;
            //民族
            Nationality.ReadOnly = type;
            Nationality.BackColor = System.Drawing.Color.White;
            //国籍
            Country.ReadOnly = type;
            Country.BackColor = System.Drawing.Color.White;
            //籍贯
            DIST.ReadOnly = type;
            DIST.BackColor = System.Drawing.Color.White;
            //身份证
            IDNo.ReadOnly = type;
            IDNo.BackColor = System.Drawing.Color.White;
            //工作单位
            AddressBusiness.ReadOnly = type;
            AddressBusiness.BackColor = System.Drawing.Color.White;
            //单位邮编
            BusinessZip.ReadOnly = type;
            BusinessZip.BackColor = System.Drawing.Color.White;
            //单位电话
            PhoneBusiness.ReadOnly = type;
            PhoneBusiness.BackColor = System.Drawing.Color.White;
            //户口地址
            AddressHome.ReadOnly = type;
            AddressHome.BackColor = System.Drawing.Color.White;
            //户口邮编
            HomeZip.ReadOnly = type;
            HomeZip.BackColor = System.Drawing.Color.White;
            //家庭电话
            PhoneHome.ReadOnly = type;
            PhoneHome.BackColor = System.Drawing.Color.White;
            //联系人 
            Kin.ReadOnly = type;
            Kin.BackColor = System.Drawing.Color.White;
            //关系
            Relation.ReadOnly = type;
            Relation.BackColor = System.Drawing.Color.White;
            //联系电话
            LinkmanTel.ReadOnly = type;
            LinkmanTel.BackColor = System.Drawing.Color.White;
            //l联系人地址
            LinkmanAdd.ReadOnly = type;
            LinkmanAdd.BackColor = System.Drawing.Color.White;
            //入院科室
            DeptInHospital.ReadOnly = type;
            DeptInHospital.BackColor = System.Drawing.Color.White;
            //入院时间 
            Date_In.Enabled = !type;
            //入院情况
            Circs.ReadOnly = type;
            Circs.BackColor = System.Drawing.Color.White;
            //转入科室
            firstDept.ReadOnly = type;
            firstDept.BackColor = System.Drawing.Color.White;
            //转科时间
            dateTimePicker3.Enabled = !type;
            dateTimePicker3.BackColor = System.Drawing.Color.White;
            //转入科室
            deptSecond.ReadOnly = type;
            deptSecond.BackColor = System.Drawing.Color.White;
            //转科时间
            dateTimePicker4.Enabled = !type;
            //转入科室
            deptThird.ReadOnly = type;
            deptThird.BackColor = System.Drawing.Color.White;
            //转科时间
            dateTimePicker5.Enabled = !type;
            //出院科室
            deptOut.ReadOnly = type;
            deptOut.BackColor = System.Drawing.Color.White;
            //出院时间
            Date_Out.Enabled = !type;
            //门诊诊断
            //			ClinicDiag.ReadOnly = type;
            ClinicDiag.BackColor = System.Drawing.Color.Gainsboro;
            //诊断医生
            ClinicDocd.ReadOnly = type;
            ClinicDocd.BackColor = System.Drawing.Color.White;
            //住院天数
            PiDays.ReadOnly = type;
            PiDays.BackColor = System.Drawing.Color.White;
            //确证时间
            DiagDate.Enabled = !type;
            //入院诊断
            //			RuyuanDiagNose.ReadOnly = type;
            RuyuanDiagNose.BackColor = System.Drawing.Color.Gainsboro;
            //由何医院转来
            ComeFrom.ReadOnly = type;
            ComeFrom.BackColor = System.Drawing.Color.White;
            //曾用名
            Nomen.ReadOnly = type;
            Nomen.BackColor = System.Drawing.Color.White;
            //病人来源
            InAvenue.ReadOnly = type;
            InAvenue.BackColor = System.Drawing.Color.White;
            //院感次数
            infectNum.ReadOnly = type;
            infectNum.BackColor = System.Drawing.Color.White;
            //hbsag
            Hbsag.ReadOnly = type;
            Hbsag.BackColor = System.Drawing.Color.White;
            HcvAb.ReadOnly = type;
            HcvAb.BackColor = System.Drawing.Color.White;
            HivAb.ReadOnly = type;
            HivAb.BackColor = System.Drawing.Color.White;
            //门诊与出院
            CePi.ReadOnly = type;
            CePi.BackColor = System.Drawing.Color.White;
            //入院与出院 
            PiPo.ReadOnly = type;
            PiPo.BackColor = System.Drawing.Color.White;
            //术前与术后
            OpbOpa.ReadOnly = type;
            OpbOpa.BackColor = System.Drawing.Color.White;
            //临床与病理
            ClPa.ReadOnly = type;
            ClPa.BackColor = System.Drawing.Color.White;
            //放射与病理
            FsBl.ReadOnly = type;
            FsBl.BackColor = System.Drawing.Color.White;
            //抢救次数
            SalvTimes.ReadOnly = type;
            SalvTimes.BackColor = System.Drawing.Color.White;
            //成功次数
            SuccTimes.ReadOnly = type;
            SuccTimes.BackColor = System.Drawing.Color.White;
            //病案质量
            MrQual.ReadOnly = type;
            MrQual.BackColor = System.Drawing.Color.White;
            //质控医师
            QcDocd.ReadOnly = type;
            QcDocd.BackColor = System.Drawing.Color.White;
            //质控护士
            QcNucd.ReadOnly = type;
            QcNucd.BackColor = System.Drawing.Color.White;
            //主任医师
            ConsultingDoctor.ReadOnly = type;
            ConsultingDoctor.BackColor = System.Drawing.Color.White;
            //主治医师
            AttendingDoctor.ReadOnly = type;
            AttendingDoctor.BackColor = System.Drawing.Color.White;
            //住院医师
            AdmittingDoctor.ReadOnly = type;
            AdmittingDoctor.BackColor = System.Drawing.Color.White;
            //进修医师
            RefresherDocd.ReadOnly = type;
            RefresherDocd.BackColor = System.Drawing.Color.White;
            //研究生实习医师
            GraDocCode.ReadOnly = type;
            GraDocCode.BackColor = System.Drawing.Color.White;
            //质控时间
            CheckDate.Enabled = !type;
            //实习医生
            PraDocCode.ReadOnly = type;
            PraDocCode.BackColor = System.Drawing.Color.White;
            //编码员
            CodingCode.ReadOnly = type;
            CodingCode.BackColor = System.Drawing.Color.White;
            //整理员 
            textBox33.ReadOnly = type;
            textBox33.BackColor = System.Drawing.Color.White;
            this.OperationCode.ReadOnly = type;
            this.OperationCode.BackColor = System.Drawing.Color.White;
            //尸蹇
            BodyCheck.Enabled = !type;
            //手术、治疗、检查、诊断、是否本院首例
            YnFirst.Enabled = !type;
            //随诊
            VisiStat.Enabled = !type;
            //随诊期限
            VisiPeriWeek.ReadOnly = type;
            VisiPeriWeek.BackColor = System.Drawing.Color.White;
            VisiPeriMonth.ReadOnly = type;
            VisiPeriMonth.BackColor = System.Drawing.Color.White;
            VisiPeriYear.ReadOnly = type;
            VisiPeriYear.BackColor = System.Drawing.Color.White;
            //示教病案
            TechSerc.Enabled = !type;
            //单病种
            checkBox8.Enabled = !type;
            //血型
            BloodType.ReadOnly = type;
            BloodType.BackColor = System.Drawing.Color.White;
            RhBlood.ReadOnly = type;
            RhBlood.BackColor = System.Drawing.Color.White;
            //输血反应
            ReactionBlood.ReadOnly = type;
            ReactionBlood.BackColor = System.Drawing.Color.White;
            //红细胞
            BloodRed.ReadOnly = type;
            BloodRed.BackColor = System.Drawing.Color.White;
            //血小板
            BloodPlatelet.ReadOnly = type;
            BloodPlatelet.BackColor = System.Drawing.Color.White;
            //血浆
            BodyAnotomize.ReadOnly = type;
            BodyAnotomize.BackColor = System.Drawing.Color.White;
            //全血
            BloodWhole.ReadOnly = type;
            BloodWhole.BackColor = System.Drawing.Color.White;
            //其他
            BloodOther.ReadOnly = type;
            BloodOther.BackColor = System.Drawing.Color.White;
            //院际会诊
            InconNum.ReadOnly = type;
            InconNum.BackColor = System.Drawing.Color.White;
            //远程会诊
            outOutconNum.ReadOnly = type;
            outOutconNum.BackColor = System.Drawing.Color.White;
            //SuperNus 特级护理
            SuperNus.ReadOnly = type;
            SuperNus.BackColor = System.Drawing.Color.White;
            //一级护理
            INus.ReadOnly = type;
            INus.BackColor = System.Drawing.Color.White;
            //二级护理
            IINus.ReadOnly = type;
            IINus.BackColor = System.Drawing.Color.White;
            //三级护理
            IIINus.ReadOnly = type;
            IIINus.BackColor = System.Drawing.Color.White;
            //重症监护
            StrictNuss.ReadOnly = type;
            StrictNuss.BackColor = System.Drawing.Color.White;
            //特殊护理
            SPecalNus.ReadOnly = type;
            SPecalNus.BackColor = System.Drawing.Color.White;
            //ct
            CtNumb.ReadOnly = type;
            CtNumb.BackColor = System.Drawing.Color.White;
            //UCFT
            PathNumb.ReadOnly = type;
            PathNumb.BackColor = System.Drawing.Color.White;
            //MR
            MriNumb.ReadOnly = type;
            MriNumb.BackColor = System.Drawing.Color.White;
            //X光
            XNumb.ReadOnly = type;
            XNumb.BackColor = System.Drawing.Color.White;
            //B超
            bchao.Enabled = !type;
            //输入员
            InputDoc.ReadOnly = type;
            InputDoc.BackColor = System.Drawing.Color.White;
        }
        /// <summary>
        /// 清空所有数据
        /// </summary>
        public void ClearInfo()
        {
            //病案号 
            caseNum.Text = "";
            //住院次数
            InTimes.Text = "";
            //费用类别
            pactKind.Text = "";
            //医保号
            SSN.Text = "";
            //门诊号
            clinicNo.Text = "";
            //姓名
            PatientName.Text = "";
            //性别
            PatientSex.Text = "";
            //生日
            //			patientBirthday.Enabled = !type;
            //年龄
            PatientAge.Text = "";
            //婚姻
            MaritalStatus.Text = "";
            //职业
            Profession.Text = "";
            //出生地
            AreaCode.Text = "";
            //民族
            Nationality.Text = "";
            //国籍
            Country.Text = "";
            //籍贯
            DIST.Text = "";
            //身份证
            IDNo.Text = "";
            //工作单位
            AddressBusiness.Text = "";
            //单位邮编
            BusinessZip.Text = "";
            //单位电话
            PhoneBusiness.Text = "";
            //户口地址
            AddressHome.Text = "";
            //户口邮编
            HomeZip.Text = "";
            //家庭电话
            PhoneHome.Text = "";
            //联系人 
            Kin.Text = "";
            //关系
            Relation.Text = "";
            //联系电话
            LinkmanTel.Text = "";
            //l联系人地址
            LinkmanAdd.Text = "";
            //入院科室
            DeptInHospital.Text = "";
            //入院时间 
            //			Date_In.Enabled = !type;
            //入院情况
            Circs.Text = "";
            //转入科室
            firstDept.Text = "";
            //转科时间
            dateTimePicker3.Value = System.DateTime.Now;
            //转入科室
            deptSecond.Text = "";
            //转科时间
            dateTimePicker4.Value = System.DateTime.Now;
            //转入科室
            deptThird.Text = "";
            //转科时间
            dateTimePicker5.Value = System.DateTime.Now;
            //出院科室
            deptOut.Text = "";
            //出院时间
            Date_Out.Value = System.DateTime.Now;
            //门诊诊断
            ClinicDiag.Text = "";
            //诊断医生
            ClinicDocd.Text = "";
            //住院天数
            PiDays.Text = "";
            //确证时间
            DiagDate.Value = System.DateTime.Now;
            //入院诊断
            RuyuanDiagNose.Text = "";
            //由何医院转来
            ComeFrom.Text = "";
            //曾用名
            Nomen.Text = "";
            //病人来源
            InAvenue.Text = "";
            //院感次数
            infectNum.Text = "";
            //hbsag
            Hbsag.Text = "";
            HcvAb.Text = "";
            HivAb.Text = "";
            //门诊与出院
            CePi.Text = "";
            //入院与出院 
            PiPo.Text = "";
            //术前与术后
            OpbOpa.Text = "";
            //临床与病理
            ClPa.Text = "";
            //放射与病理
            FsBl.Text = "";
            //抢救次数
            SalvTimes.Text = "";
            //成功次数
            SuccTimes.Text = "";
            //病案质量
            MrQual.Text = "";
            //质控医师
            QcDocd.Text = "";
            //质控护士
            QcNucd.Text = "";
            //主任医师
            ConsultingDoctor.Text = "";
            //主治医师
            AttendingDoctor.Text = "";
            //住院医师
            AdmittingDoctor.Text = "";
            //进修医师
            RefresherDocd.Text = "";
            //研究生实习医师
            GraDocCode.Text = "";
            //质控时间
            CheckDate.Value = System.DateTime.Now;
            //实习医生
            PraDocCode.Text = "";
            //编码员
            CodingCode.Text = "";
            //整理员 
            textBox33.Text = "";
            this.OperationCode.Tag = null;
            this.OperationCode.Text = "";
            //尸蹇
            BodyCheck.Checked = false;
            //手术、治疗、检查、诊断、是否本院首例
            YnFirst.Checked = false;
            //随诊
            VisiStat.Checked = false;
            //随诊期限
            VisiPeriWeek.Text = "";
            VisiPeriMonth.Text = "";
            VisiPeriYear.Text = "";
            //示教病案
            TechSerc.Checked = false;
            //单病种
            checkBox8.Checked = false;
            //血型
            BloodType.Text = "";
            RhBlood.Text = "";
            //输血反应
            ReactionBlood.Text = "";
            //红细胞
            BloodRed.Text = "";
            //血小板
            BloodPlatelet.Text = "";
            //血浆
            BodyAnotomize.Text = "";
            //全血
            BloodWhole.Text = "";
            //其他
            BloodOther.Text = "";
            //院际会诊
            InconNum.Text = "";
            //远程会诊
            outOutconNum.Text = "";
            //SuperNus 特级护理
            SuperNus.Text = "";
            //一级护理
            INus.Text = "";
            //二级护理
            IINus.Text = "";
            //三级护理
            IIINus.Text = "";
            //重症监护
            StrictNuss.Text = "";
            //特殊护理
            SPecalNus.Text = "";
            //ct
            CtNumb.Text = "";
            //UCFT
            PathNumb.Text = "";
            //MR
            MriNumb.Text = "";
            //X光
            XNumb.Text = "";
            //B超
            bchao.Checked = false;
            //输入员
            InputDoc.Text = "";
        }
        private void patientBirthday_ValueChanged(object sender, System.EventArgs e)
        {
            if (patientBirthday.Value > System.DateTime.Now)
            {
                patientBirthday.Value = System.DateTime.Now;
            }
            if (patientBirthday.Value.Year == System.DateTime.Now.Year)
            {
                if (patientBirthday.Value.Month == System.DateTime.Now.Month)
                {
                    System.TimeSpan span = System.DateTime.Now - patientBirthday.Value;
                    if (span.Days != 0) //天
                    {
                        PatientAge.Text = span.Days + "天";
                    }
                    else
                    {
                        PatientAge.Text = span.Hours + "小时";
                    }
                }
                else //月
                {
                    PatientAge.Text = Convert.ToString(System.DateTime.Now.Month - patientBirthday.Value.Month) + "月"; ;
                }
            }
            else //岁
            {
                PatientAge.Text = Convert.ToString(System.DateTime.Now.Year - patientBirthday.Value.Year) + "岁";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="diag"></param>
        /// <returns></returns>
        public int DiagValueState(Neusoft.HISFC.Management.HealthRecord.Diagnose diag)
        {
            //ArrayList allList = new ArrayList();
            //this.ucDiagNoseInput1.GetAllDiagnose(allList);
            //if (allList == null)
            //{
            //    return -1;
            //}
            //if (allList.Count == 0)
            //{
            //    return 1;
            //}
            //Neusoft.HISFC.Object.Base.EnumSex sex;
            //if (CaseBase.Patient.Sex.ID.ToString() == "F")
            //{
            //    sex = Neusoft.HISFC.Object.Base.EnumSex.F;
            //}
            //else if (CaseBase.Patient.Sex.ID.ToString() == "M")
            //{
            //    sex = Neusoft.HISFC.Object.Base.EnumSex.M;
            //}
            //else
            //{
            //    sex = Neusoft.HISFC.Object.Base.EnumSex.U;
            //}
            ////待定
            //ArrayList diagCheckList = diag.DiagnoseValueState(allList, sex);
            //Neusoft.Common.Controls.ucDiagnoseCheck ucdia = new Neusoft.Common.Controls.ucDiagnoseCheck();
            //if (diagCheckList == null)
            //{
            //    MessageBox.Show("提取约束出错");
            //    return -1;
            //}
            //if (diagCheckList.Count == 0)
            //{
            //    return 1;
            //}
            //try
            //{
            //    if (frm != null)
            //    {
            //        frm.Close();
            //    }
            //}
            //catch { }

            //frm = new ucDiagNoseCheck();
            //frm.initDiangNoseCheck(diagCheckList);
            //if (frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.DOC)
            //{
            //    frm.Show();
            //    if (frm.GetRedALarm())
            //    {
            //        return -1;
            //    }
            //}
            ////			else if(frmType == Neusoft.HISFC.Object.HealthRecord.EnumServer.frmTypes.CAS)
            ////			{
            ////				frm.ShowDialog();
            ////				if(frm.GetRedALarm() )
            ////				{
            ////					return -1;
            ////				}
            ////			}
            return 1;
        }

        #region  废弃函数

        [Obsolete("废弃", true)]
        private void tab1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //切换tab页时 当前的下拉框不显示
            //if (listBoxActive != null)
            //{
            //    this.listBoxActive.Visible = false;
            //}
            //switch (tab1.SelectedTab.Text)
            //{
            //    case "肿瘤信息":
            //        //如果小于零 ，增加一行
            //        if (this.ucTumourCard2.GetfpSpreadRowCount() == 0)
            //        {
            //            this.ucTumourCard2.AddRow();
            //            this.ucTumourCard2.SetActiveCells();
            //        }
            //        break;
            //    case "手术信息":
            //        //如果小于零 ，增加一行
            //        if (this.ucOperation1.GetfpSpread1RowCount() == 0)
            //        {
            //            this.ucOperation1.AddRow();
            //            this.ucOperation1.SetActiveCells();
            //        }
            //        break;
            //    case "费用信息":
            //        break;
            //    case "诊断信息":
            //        if (this.ucDiagNoseInput1.GetfpSpreadRowCount() == 0)
            //        {
            //            this.ucDiagNoseInput1.AddRow();
            //            this.ucDiagNoseInput1.SetActiveCells();
            //        }
            //        break;
            //    case "妇婴信息":
            //        if (this.ucBabyCardInput1.GetfpSpreadRowCount() == 0)
            //        {
            //            this.ucBabyCardInput1.AddRow();
            //            this.ucBabyCardInput1.SetActiveCells();
            //        }
            //        break;
            //    case "转科信息":
            //        if (this.ucChangeDept1.GetfpSpreadRowCount() == 0)
            //        {
            //            this.ucChangeDept1.AddRow();
            //            this.ucChangeDept1.SetActiveCells();
            //        }
            //        break;
            //}
        }
        /// <summary>
        ///删除当前行
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃", true)]
        public int DeleteActiveRow()
        {
            //string strName = this.tab1.SelectedTab.Text;
            //switch (strName)
            //{
            //    case "手术信息":
            //        this.ucOperation1.DeleteActiveRow();
            //        break;
            //    case "诊断信息":
            //        this.ucDiagNoseInput1.DeleteActiveRow();
            //        break;
            //    case "转科信息":
            //        this.ucChangeDept1.DeleteActiveRow();
            //        break;
            //    case "肿瘤信息":
            //        this.ucTumourCard2.DeleteActiveRow();
            //        break;
            //    case "妇婴信息":
            //        this.ucBabyCardInput1.DeleteActiveRow();
            //        break;
            //    case "基本信息":
            //        MessageBox.Show("基本信息不允许删除");
            //        break;
            //}
            return 1;
        }
        /// <summary>
        /// 初始化TreeView
        /// </summary>
        [Obsolete("废弃", true)]
        public void InitTreeView()
        {
            //			ArrayList al = new ArrayList();
            //			TreeNode tnParent;
            //			this.patientTreeView.HideSelection = false;
            //			Neusoft.HISFC.Management.RADT.InPatient pQuery = new Neusoft.HISFC.Management.RADT.InPatient();
            //			this.patientTreeView.BeginUpdate();
            //			this.patientTreeView.Nodes.Clear();
            //			//画树头
            //			tnParent = new TreeNode();
            //			tnParent.Text = "未登记病案患者";
            //			tnParent.Tag = "%";
            //			try
            //			{
            //				tnParent.ImageIndex = 0;
            //				tnParent.SelectedImageIndex = 1;
            //			}
            //			catch{}
            //			this.patientTreeView.Nodes.Add( tnParent );
            //			
            //			//获得结算未登记患者信息
            //			al = pQuery.PatientsHavingCase( "I" );
            //
            //			foreach( Neusoft.HISFC.Object.RADT.PatientInfo pInfo in al )
            //			{
            //				TreeNode tnPatient = new TreeNode();
            //
            //				tnPatient.Text = pInfo.Name + "[" + pInfo.Patient.PID.PatientNO + "]";
            //				tnPatient.Tag = pInfo;
            //				try
            //				{
            //					tnPatient.ImageIndex = 2;
            //					tnPatient.SelectedImageIndex = 3;
            //				}
            //				catch{}
            //				tnParent.Nodes.Add( tnPatient );
            //			}
            //
            //			tnParent.Expand();
            //			this.patientTreeView.EndUpdate();
        }

        [Obsolete("废弃", true)]
        private void patientTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.Tag.GetType() == typeof(Neusoft.HISFC.Object.RADT.PatientInfo))
            {
                //				this.Reset();
                //				caseBase.PatientInfo = ((Neusoft.HISFC.Object.RADT.PatientInfo)e.Node.Tag).Clone();
                //				this.ucCaseFirstPage1.Item = caseBase.Clone();
                //				ArrayList alOrg = new ArrayList();
                //				ArrayList alNew = new ArrayList();
                //				alOrg = myBaseDML.GetInhosDiagInfo( caseBase.PatientInfo.ID, "%");
                //				Neusoft.HISFC.Object.HealthRecord.Diagnose dg;
                //				for(int i = 0; i < alOrg.Count; i++)
                //				{
                //					dg = new Neusoft.HISFC.Object.HealthRecord.Diagnose();
                //					dg.DiagInfo = ((Neusoft.HISFC.Object.Case.DiagnoseBase)alOrg[i]).Clone();
                //					alNew.Add( dg );
                //				}
                //				this.ucCaseFirstPage1.AlDiag = alNew;
            }
        }
        #endregion 
    }
}

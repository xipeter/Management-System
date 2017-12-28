using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Common.Controls
{
    public partial class ucPatient : UserControl
    {
        public ucPatient()
        {
            InitializeComponent();
        }

        private int ContralCount()
        {

            ICount = 0;
            if (bs1 == true)
            {
                ICount++;

            }
            if (bs2 == true)
            {
                ICount++;

            }
            if (bs3 == true)
            {
                ICount++;
            }
            if (bs4 == true)
            {
                ICount++;
            }
            if (bs5 == true)
            {
                ICount++;
            }
            if (bs6 == true)
            {
                ICount++;
            }
            if (bs7 == true)
            {
                ICount++;
            }
            if (bs8 == true)
            {
                ICount++;
            }
            if (bs9 == true)
            {
                ICount++;
            }
            if (bs10 == true)
            {
                ICount++;
            }
            if (bs11 == true)
            {
                ICount++;
            }
            if (bs12 == true)
            {
                ICount++;
            }
            if (bs13 == true)
            {
                ICount++;
            }
            if (bs14 == true)
            {
                ICount++;
            }
            if (bs15 == true)
            {
                ICount++;
            }
            if (bs16 == true)
            {
                ICount++;
            }
            return ICount;

        }

        public void LoadContralState()
        {

        }

        public void InitializeContral(bool[] bArray)
        {
            this.init();
            this.initLabel();
            try
            {
                int j = 0;
                for (int i = 0; i < 16; i++)
                {
                    if (bArray[i] == true)
                    {
                        int ilocId = 0;
                        arrObj[j] = (Neusoft.NFC.Interface.Controls.NeuPanel)myALContral[i];
                        ilocId = j;
                        LocationContral(arrObj[j], ilocId);
                        j++;
                    }

                }

            }
            catch { }


        }

        public void InitializeXY()
        {
            int x = 0, y = 8, id = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //					label3.Text += x.ToString()+" " +y.ToString()+" "+id.ToString()+" ";
                    InitializeIndex(x, y, id);
                    id = id + 1;
                    x = x + 192;
                }
                x = 0;
                y = y + 32;
            }
        }

        public void InitializeIndex(int x, int y, int iID)
        {

            oIndexerClass[iID, 0] = x;//576;
            oIndexerClass[iID, 1] = y;//72;

        }

        private void LocationContral(Panel obj, int iPoint)
        {
            obj.Location = new Point(oIndexerClass[iPoint, 0], oIndexerClass[iPoint, 1]);
        }

        public void SetContralLocation(bool bs, int iSerial, int iNum)
        {
            if (panLabel.Visible == true)
            {
                if (bs == false)
                {
                    for (int i = 0; i < ContralCount(); i++)
                    {
                        LocationContral(arrObj[i + 1], i);
                    }
                }
            }
        }

        protected int iColumnWidth = 192;
        protected int iColumnHeight = 32;

        public int ColumnHeight
        {
            get
            {
                return this.panel1.Height;
            }
            set
            {
                this.panel1.Height = value;
                this.panel2.Height = value;
                this.panel3.Height = value;
                this.panel4.Height = value;
                this.panel5.Height = value;
                this.panel6.Height = value;
                this.panel7.Height = value;
                this.panel8.Height = value;
                this.panel9.Height = value;
                this.panel10.Height = value;
                this.panel11.Height = value;
                this.panel12.Height = value;
                this.panel13.Height = value;
                this.panel14.Height = value;
                this.panel15.Height = value;
                this.panel16.Height = value;
                iColumnHeight = value;
                InitializeContral(this.bArray);
            }
        }

        public int ColumnWidth
        {
            get
            {
                return this.panel1.Width;
            }
            set
            {
                this.panel1.Width = value;
                this.panel2.Width = value;
                this.panel3.Width = value;
                this.panel4.Width = value;
                this.panel5.Width = value;
                this.panel6.Width = value;
                this.panel7.Width = value;
                this.panel8.Width = value;
                this.panel9.Width = value;
                this.panel10.Width = value;
                this.panel11.Width = value;
                this.panel12.Width = value;
                this.panel13.Width = value;
                this.panel14.Width = value;
                this.panel15.Width = value;
                this.panel16.Width = value;
                iColumnWidth = value;
                InitializeContral(this.bArray);
            }
        }

        protected bool bIsShowDetail = false;
        public bool IsShowDetail
        {
            get
            {
                return this.bIsShowDetail;
            }
            set
            {
                this.bIsShowDetail = value;
                this.panLabel.Visible = !bIsShowDetail;
                //				this.panDetail.Visible = bIsShowDetail;	
                SetPanState(bIsShowDetail);
                this.SetPatientInfo(myPatientInfo);
            }

        }

        private void SetPanState(bool bState)
        {
            panel1.Visible = bState;
            panel2.Visible = bState;
            panel3.Visible = bState;
            panel4.Visible = bState;
            panel5.Visible = bState;
            panel6.Visible = bState;
            panel7.Visible = bState;
            panel8.Visible = bState;
            panel9.Visible = bState;
            panel10.Visible = bState;
            panel11.Visible = bState;
            panel12.Visible = bState;
            panel13.Visible = bState;
            panel14.Visible = bState;
            panel15.Visible = bState;
            panel16.Visible = bState;
        }

        private void initBoolArray()
        {
            bArray[0] = bs1;
            bArray[1] = bs2;
            bArray[2] = bs3;
            bArray[3] = bs4;
            bArray[4] = bs5;
            bArray[5] = bs6;
            bArray[6] = bs7;
            bArray[7] = bs8;
            bArray[8] = bs9;
            bArray[9] = bs10;
            bArray[10] = bs11;
            bArray[11] = bs12;
            bArray[12] = bs13;
            bArray[13] = bs14;
            bArray[14] = bs15;
            bArray[15] = bs16;
        }
        private void initArrayList()
        {
            myALContral.Add(panel1);
            myALContral.Add(panel2);
            myALContral.Add(panel3);
            myALContral.Add(panel4);
            myALContral.Add(panel5);
            myALContral.Add(panel6);
            myALContral.Add(panel7);
            myALContral.Add(panel8);
            myALContral.Add(panel9);
            myALContral.Add(panel10);
            myALContral.Add(panel11);
            myALContral.Add(panel12);
            myALContral.Add(panel13);
            myALContral.Add(panel14);
            myALContral.Add(panel15);
            myALContral.Add(panel16);

        }
        private void initPanel()
        {
            this.panel1.Visible = bs1;
            this.panel2.Visible = bs2;
            this.panel3.Visible = bs3;
            this.panel4.Visible = bs4;
            this.panel5.Visible = bs5;
            this.panel6.Visible = bs6;
            this.panel7.Visible = bs7;
            this.panel8.Visible = bs8;
            this.panel9.Visible = bs9;
            this.panel10.Visible = bs10;
            this.panel11.Visible = bs11;
            this.panel12.Visible = bs12;
            this.panel13.Visible = bs13;
            this.panel14.Visible = bs14;
            this.panel15.Visible = bs15;
            this.panel16.Visible = bs16;
        }
        private void initLabel()
        {
            lblTitle.Width = this.Width;
            lblTitle.Height = this.Height;
        }
        private void init()
        {
            int w = 0;
            int h = 0;
            for (int i = 0; i < 16; i++) 
            {
                InitializeIndex(iColumnWidth * w + 8, h * iColumnHeight + 8, i);
                w++;
                if ((w + 1) * iColumnWidth + 8 >= this.Width + 8)
                {
                    h++;
                    w = 0;
                }
            }
        }

        public void SetPatientInfo(Neusoft.HISFC.Object.RADT.PatientInfo pInfo)
        {

            if (pInfo == null)
            {
                pInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
            }
            try
            {
                this.txtName.Text = pInfo.Name;//姓名
                this.cmbSex.Text = pInfo.Sex.Name;//性别
                if (pInfo.PVisit.InTime != DateTime.MinValue) this.dtpIndate.Value = pInfo.PVisit.InTime;//.Date_In;//住院日期
                if (pInfo.PVisit.PatientLocation != null) this.txtPatientDept.Text = pInfo.PVisit.PatientLocation.Dept.Name;//住院科室
                this.txtRemain.Text = pInfo.FT.LeftCost.ToString();//余额

                if (pInfo.Birthday != DateTime.MinValue) this.dtpBirthday.Value = pInfo.Birthday;//出生日期
                this.txtCautioner.Text = pInfo.Caution.Name;//担保人
                this.cmbBalanceType.Tag = pInfo.Pact.ID;//费用类型

                this.txtMoneyAlert.Text = pInfo.PVisit.MoneyAlert.ToString();//警戒线

                this.txtPactName.Text = pInfo.Pact.Name;//单位合同
                this.txtCautionMoney.Text = pInfo.Caution.Money.ToString();//担保金额
                this.txtBill.Text = pInfo.FT.TotCost.ToString();//以往费用
                this.txtAvailable.Text = pInfo.FT.BloodLateFeeCost.ToString();//血滞纳金

                this.txtAttendingDoctor.Text = pInfo.PVisit.AttendingDoctor.Name;//主治医生
                this.txtAdmittingDoctor.Text = pInfo.PVisit.AdmittingDoctor.Name;//住院医生
                this.txtAdmittingNurse.Text = pInfo.PVisit.AdmittingNurse.Name;			//责任护士
            }
            catch { }
            try
            {
                this.lblTitle.Text = GetStrPatientInfo(pInfo);
                //				this.lblTitle.Text = "姓名:"+pInfo.Name +" "+pInfo.Patient.Sex.Name+" "+
                //					pInfo.PVisit.PatientLocation.Dept.Name+
                //					" 剩余金额："+pInfo.Fee.Left_Cost.ToString() +
                //					" 结算方式："+pInfo.PayKind.Name+
                //					" 警戒线："+ pInfo.PVisit.MoneyAlert.ToString();
            }
            catch { }
        }


        private string GetStrPatientInfo(Neusoft.HISFC.Object.RADT.PatientInfo pInfo)
        {
            string strPatientInfo = "";
            if (bs1)
                strPatientInfo += "姓名:" + pInfo.Name + " " + pInfo.Sex.Name + " ";
            if (bs17)
                strPatientInfo += "床号：" + pInfo.PVisit.PatientLocation.Bed.ID;
            if (bs2)
                strPatientInfo += "入院日期：" + pInfo.InTimes + " ";
            if (bs3)
                strPatientInfo += "住院科室：" + pInfo.PVisit.PatientLocation.Dept.Name + " ";
            if (bs4)
                strPatientInfo += "余额：" + pInfo.FT.LeftCost.ToString() + " ";
            if (bs5)
                strPatientInfo += "出生年月：" + pInfo.Birthday.ToShortDateString() + " ";
            if (bs6)
                strPatientInfo += "担保人：" + pInfo.Caution.Name + " ";
            if (bs7)
                strPatientInfo += "结算方式：" + this.cmbBalanceType.Text + " ";//结算方式
            if (bs8)
                strPatientInfo += "警戒线：" + pInfo.PVisit.MoneyAlert.ToString() + " ";
            if (bs9)
                strPatientInfo += "结算方式：" + pInfo.Pact.Name + " ";
            if (bs10)
                strPatientInfo += "担保金额：" + pInfo.Caution.Money.ToString() + " ";
            if (bs11)
                strPatientInfo += "以往费用：" + pInfo.FT.TotCost.ToString() + " ";
            if (bs12)
                strPatientInfo += "血滞纳金：" + pInfo.FT.BloodLateFeeCost.ToString();
            if (bs13)
                strPatientInfo += "主治医生：" + pInfo.PVisit.AttendingDoctor.Name + " ";
            if (bs14)
                strPatientInfo += "住院医生：" + pInfo.PVisit.AdmittingDoctor.Name + " ";
            if (bs15)
                strPatientInfo += "责任护士：" + pInfo.PVisit.AdmittingNurse.Name + " ";
            if (bs15)
                strPatientInfo += "血滞纳金：" + pInfo.FT.BloodLateFeeCost.ToString();

            return strPatientInfo;
        }
        
        public void GetPatientInfo()
        {
            try
            {
                myPatientInfo.Name = this.txtName.Text;
                //myPatientInfo.Patient.Sex.ID=this.cmbSex.Text;
                myPatientInfo.PVisit.InTime = this.dtpIndate.Value;
                myPatientInfo.PVisit.PatientLocation.Dept.Name = this.txtPatientDept.Text;
                myPatientInfo.FT.LeftCost = decimal.Parse(this.txtRemain.Text);

                myPatientInfo.Birthday = this.dtpBirthday.Value;
                myPatientInfo.Caution.Name = this.txtCautioner.Text;
                myPatientInfo.Pact.PayKind.Name = this.cmbBalanceType.Text;
                myPatientInfo.PVisit.MoneyAlert = decimal.Parse(this.txtMoneyAlert.Text);

                myPatientInfo.Pact.Name = this.txtPactName.Text;
            }
            catch { }

        }

        private Neusoft.HISFC.Object.RADT.PatientInfo myPatientInfo;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo
        {
            get
            {
                return myPatientInfo;
            }
            set
            {
                try
                {
                    if (value == null)
                        myPatientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
                    else
                        myPatientInfo = value;
                    this.SetPatientInfo(myPatientInfo);
                }
                catch { }
            }
        }

        private void ucPatient_Load(object sender, EventArgs e)
        {
            try
            {
                this.BackColor = this.Parent.BackColor;

                this.IsShowDetail = this.bIsShowDetail;

                Neusoft.HISFC.Management.Manager.Constant Constant = new Neusoft.HISFC.Management.Manager.Constant();
                //初始化结算方式
                this.cmbBalanceType.AddItems(Constant.GetList(Neusoft.HISFC.Object.Base.EnumConstant.PAYKIND));

                initPanel();
                initArrayList();
                initBoolArray();

                if (!IsShowDetail)
                {
                    SetPanState(false);
                }
                base.Resize += new EventHandler(ucLoation_Resize);
                init();
                initLabel();
            }
            catch { }
        }

        private void ucLoation_Resize(object sender, EventArgs e)
        {
            InitializeContral(this.bArray);
            this.initLabel();
        }

        #region panel属性
        private bool bs1 = true;
        private bool bs2 = true;
        private bool bs3 = true;
        private bool bs4 = true;
        private bool bs5 = true;
        private bool bs6 = true;
        private bool bs7 = true;
        private bool bs8 = true;
        private bool bs9 = true;
        private bool bs10 = true;
        private bool bs11 = true;
        private bool bs12 = true;
        private bool bs13 = true;
        private bool bs14 = true;
        private bool bs15 = true;
        private bool bs16 = true;
        /// <summary>
        /// 属性定义
        /// </summary>
        /// 
        [Category("控件定位"), Description("患者姓名"),]//Browsable(false)
        public bool S1_Name
        {
            get
            {
                return bs1;
            }
            set
            {
                bs1 = value;
                bArray[0] = bs1;
                myALContral.Add(panel1);

                init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel1.Visible = bs1;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }

            }
        }
        [Category("控件定位"), Description("住院日期")]
        public bool S2_DateIn
        {
            get
            {
                return bs2;
            }
            set
            {
                bs2 = value;
                bArray[1] = bs2;
                myALContral.Add(panel2);
                //
                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel2.Visible = bs2;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("住院科室")]//,Browsable(false)
        public bool S3_PatientDept
        {
            get
            {
                return bs3;
            }
            set
            {
                bs3 = value;
                bArray[2] = bs3;
                myALContral.Add(panel3);

                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel3.Visible = bs3;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("余额")]
        public bool S4_Remain
        {
            get
            {
                return bs4;
            }
            set
            {
                bs4 = value;
                bArray[3] = bs4;
                myALContral.Add(panel4);
                //
                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel4.Visible = bs4;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("出生年月")]
        public bool S5_Birthday
        {
            get
            {
                return bs5;
            }
            set
            {
                bs5 = value;
                bArray[4] = bs5;
                myALContral.Add(panel5);

                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel5.Visible = bs5;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("担保人")]
        public bool S6_Cautioner
        {
            get
            {
                return bs6;
            }
            set
            {
                bs6 = value;
                bArray[5] = bs6;
                myALContral.Add(panel6);

                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel6.Visible = bs6;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("结算方式")]
        public bool S7_PayKind
        {
            get
            {
                return bs7;
            }
            set
            {
                bs7 = value;
                bArray[6] = bs7;
                myALContral.Add(panel7);

                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel7.Visible = bs7;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("警戒线")]
        public bool S8_MoneyAlert
        {
            get
            {
                return bs8;
            }
            set
            {
                bs8 = value;
                bArray[7] = bs8;
                myALContral.Add(panel8);
                //
                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel8.Visible = bs8;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("合同单位")]
        public bool S9_PactName
        {
            get
            {
                return bs9;
            }
            set
            {
                bs9 = value;
                bArray[8] = bs9;
                myALContral.Add(panel9);

                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel9.Visible = bs9;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("担保金额")]
        public bool Sa_CautionMoney
        {
            get
            {
                return bs10;
            }
            set
            {
                bs10 = value;
                bArray[9] = bs10;
                myALContral.Add(panel10);

                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel10.Visible = bs10;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }

            }
        }


        [Category("控件定位"), Description("以往费用")]
        public bool Sb_Bill
        {
            get
            {
                return bs11;
            }
            set
            {
                bs11 = value;
                bArray[10] = bs11;
                myALContral.Add(panel11);

                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel11.Visible = bs11;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("血滞纳金")]
        public bool Sc_Available
        {
            get
            {
                return bs12;
            }
            set
            {
                bs12 = value;
                bArray[11] = bs12;
                myALContral.Add(panel12);

                //				init();
                //				initLabel();
                //				this.IsShowDetail =this.bIsShowDetail;

                if (IsShowDetail == true)
                {
                    panel12.Visible = bs12;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("主治医生")]
        public bool Sd_AttendingDoctor
        {
            get
            {
                return bs13;
            }
            set
            {
                bs13 = value;
                bArray[12] = bs13;
                myALContral.Add(panel13);



                if (IsShowDetail == true)
                {
                    panel13.Visible = bs13;
                    InitializeContral(bArray); ;
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("住院医生")]
        public bool Se_AdmittingDoctor
        {
            get
            {
                return bs14;
            }
            set
            {
                bs14 = value;
                bArray[13] = bs14;
                myALContral.Add(panel14);

                if (IsShowDetail == true)
                {
                    panel14.Visible = bs14;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("责任护士")]
        public bool Sf_AdmittingNurse
        {
            get
            {
                return bs15;
            }
            set
            {
                bs15 = value;
                bArray[14] = bs15;

                myALContral.Add(panel15);

                if (IsShowDetail == true)
                {
                    panel15.Visible = bs15;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }

        [Category("控件定位"), Description("此次金额")]
        public bool Sg_ThisBill
        {
            get
            {
                return bs16;
            }
            set
            {
                bs16 = value;
                bArray[15] = bs16;
                myALContral.Add(panel16);
                if (IsShowDetail == true)
                {
                    panel16.Visible = bs16;
                    InitializeContral(bArray);
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }
            }
        }
        protected bool bs17 = false;
        /// <summary>
        /// 病床号
        /// </summary>
        public bool SF_BedNo
        {
            set
            {
                bs17 = value;
                if (IsShowDetail == true)
                {
                }
                else
                {
                    this.SetPatientInfo(myPatientInfo);
                }

            }
        }
        #endregion
    }

    public class Index
    {
        private int[] myArray = new int[100];
        public int this[int x]
        {
            get
            {
                if (x < 0 || x >= 100)
                    return 0;
                else
                    return myArray[x];
            }
            set
            {
                if (!(x < 0 || x >= 100))
                    myArray[x] = value;

            }
        }
    }

    public class IndexerClass
    {
        private int[,] myArray = new int[100, 2];
        public int this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= 100 || y < 0 || y >= 2)
                    return 0;
                else
                    return myArray[x, y];
            }
            set
            {
                if (!(x < 0 || x >= 100 || y < 0 || y >= 2))
                    myArray[x, y] = value;
            }
        }
    }

    public class CNode
    {
        ArrayList myAL = new ArrayList();
        public object data;
        public CNode next;
        public CNode()
        {
            next = null;
        }

    }

    public class QueueCnode
    {
        public QueueCnode()
        {
        }

        public void Insert(object data, int i)
        {
            //置入X//
            //修改表长//

            if (i >= 100)
                MessageBox.Show("超出数组长度");//('表满');
            if (i < 1 || i > 100)
                MessageBox.Show("非法位置"); //('非法位置');


        }
        public void Remove(object data, int i)
        {

        }

    }
}

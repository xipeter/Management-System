using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace Neusoft.HISFC.Components.Registration
{
    /// <summary>
    /// 账户流程挂号
    /// </summary>
    public partial class ucAccountRegister : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.Registration.INurseArrayRegister
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucAccountRegister()
        {
            InitializeComponent();
        }

        #region 变量
        private ArrayList al = new ArrayList();

        /// <summary>
        /// 门诊科室列表
        /// </summary>
        private ArrayList alDept = new ArrayList();

        /// <summary>
        /// 医生列表
        /// </summary>
        private ArrayList alDoct = new ArrayList();

        /// <summary>
        /// 常数管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager conMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 挂号级别管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.RegLevel RegLevelMgr = new Neusoft.HISFC.BizLogic.Registration.RegLevel();

        /// <summary>
        /// 挂号管理业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Register registerManager = new Neusoft.HISFC.BizLogic.Registration.Register();

        /// <summary>
        /// 排班管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Schema SchemaMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();

        /// <summary>
        /// 挂号费管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.RegLvlFee regFeeMgr = new Neusoft.HISFC.BizLogic.Registration.RegLvlFee();
        
        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.Patient patient = null;
        private DataSet dsItems;

        Neusoft.HISFC.Models.Registration.Register regObj = null;

        ArrayList alNoon = null;
        #endregion

        #region 初始化挂号级别initRegLevel()

        /// <summary>
        /// 初始化挂号级别
        /// </summary>
        /// <returns></returns>
        private int initRegLevel()
        {
            al = this.getRegLevelFromXML();
            if (al == null) return -1;
            ///如果本地没有配置,从数据库中读取 
            if (al.Count == 0)
            {
                al = this.RegLevelMgr.Query(true);
            }

            if (al == null)
            {
                MessageBox.Show("查询挂号级别出错!" + this.RegLevelMgr.Err, "提示");
                return -1;
            }

            this.cmbRegLevel.AddItems(al);
            
            return 0;
        }
        #endregion

        #region 从XML读取挂号级别和权限getRegLevelFromXML()
        /// <summary>
        /// 从本地读取挂号级别,权限控制
        /// </summary>
        /// <returns></returns>
        private ArrayList getRegLevelFromXML()
        {
            ArrayList alLists = new ArrayList();
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/RegLevelList.xml");
            }
            catch { return alLists; }
            try
            {
                XmlNodeList nodes = doc.SelectNodes(@"//Level");
                foreach (XmlNode node in nodes)
                {
                    Neusoft.HISFC.Models.Registration.RegLevel level = new Neusoft.HISFC.Models.Registration.RegLevel();
                    level.ID = node.Attributes["ID"].Value;//
                    level.Name = node.Attributes["Name"].Value;
                    level.IsExpert = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["IsExpert"].Value);
                    level.IsFaculty = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["IsFaculty"].Value);
                    level.IsSpecial = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["IsSpecial"].Value);
                    level.IsDefault = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["IsDefault"].Value);
                    alLists.Add(level);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("获取挂号级别出错!" + e.Message);
                return null;
            }

            return alLists;
        }
        #endregion

        private void initdept()
        {
            //获取所有门诊科室
            this.alDept = this.GetClinicDepts();
            cmbDept.AddItems(alDept);
        }

        private ArrayList GetClinicDepts()
        {
            al = this.conMgr.QueryRegDepartment();
            if (al == null)
            {
                MessageBox.Show("获取门诊科室时出错!" + this.conMgr.Err, "提示");
                return null;
            }

            return al;
        }

        private void InitDoct()
        {
            alDoct = this.conMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (alDoct == null)
            {
                MessageBox.Show("获取门诊医生列表时出错!" + conMgr.Err, "提示");
                alDoct = new ArrayList();
            }

            this.cmbDoctor.AddItems(alDoct);
        
        }

        private void initCombox()
        {
            initRegLevel();
            initdept();
            InitDoct();
        }

        private int valid()
        {
            if (this.cmbRegLevel.Tag == null || this.cmbRegLevel.Tag.ToString() == "")
            {
                MessageBox.Show("请选择挂号级别!", "提示");
                this.cmbRegLevel.Focus();
                return -1;
            }
            //得到挂号级别情况
            Neusoft.HISFC.Models.Registration.RegLevel level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;

            if ((this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == ""))
            {
                MessageBox.Show("请输入挂号科室!", "提示");
                this.cmbDept.Focus();
                return -1;
            }

            if (this.cmbDept.SelectedItem == null)
            {
                MessageBox.Show("请选择挂号科室!", "提示");
                this.cmbDept.Focus();
                return -1;
            }
            //感觉挂号科室不应该让手写，应该是选择得到的
            if (this.cmbDept.Text != this.cmbDept.SelectedItem.Name && this.cmbDept.Text != this.cmbDept.Tag.ToString())
            {
                MessageBox.Show("请输入正确的挂号科室!", "提示");
                this.cmbDept.Focus();
                return -1;
            }
            //专家号或者特诊号必须指定医生
            if ((level.IsExpert || level.IsSpecial) &&
                (this.cmbDoctor.Tag == null || this.cmbDoctor.Tag.ToString() == ""))
            {
                //提示应该是专家号或者特诊号必须指定看诊医生
                MessageBox.Show("专家号必须指定看诊医生!", "提示");
                this.cmbDoctor.Focus();
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 设置相应挂号信息(模板,已挂,剩余等信息)
        /// </summary>
        private void QueryRegLevl()
        {
            //恢复初始状态
            this.cmbDept.Tag = "";
            this.cmbDoctor.Tag = "";

            #region 生成挂号级别对应的科室、医生列表
            Neusoft.HISFC.Models.Registration.RegLevel Level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
            if (Level == null)
            {
                return;
            }
            if (Level.IsExpert || Level.IsSpecial)//专家、特诊
            {
                #region 专家
                //生成右侧出诊专家的科室列表
                this.GetSchemaDept(Neusoft.HISFC.Models.Base.EnumSchemaType.Doct);

                //生成Combox下拉列表
                //{920686B9-AD51-496e-9240-5A6DA098404E}
                this.addRegDeptToCombox();
  

                //清空医生列表,等选择科室后再检索出诊专家
                ArrayList al = new ArrayList();
                this.cmbDoctor.AddItems(al);
               
                #endregion
            }
            else if (Level.IsFaculty)//专科
            {
                #region 专科
                //获取出诊专科列表
                this.GetSchemaDept(Neusoft.HISFC.Models.Base.EnumSchemaType.Dept);

                 this.addRegDeptToCombox();

                //清空医生列表,专科不需要选择医生
                ArrayList al = new ArrayList();
                this.cmbDoctor.AddItems(al);
                #endregion
            }
            else//普通
            {
                //显示科室列表
                this.cmbDept.AddItems(this.al);

            }
            #endregion

        }

        /// <summary>
        /// 获取出诊科室
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private int GetSchemaDept(Neusoft.HISFC.Models.Base.EnumSchemaType type)
        {
            DataSet ds = new DataSet();

            ds = this.SchemaMgr.QueryDept(this.dtBookingDate.Value.Date,
                                        this.registerManager.GetDateTimeFromSysDateTime(), type);
            if (ds == null)
            {
                MessageBox.Show(this.SchemaMgr.Err, "提示");
                return -1;
            }

            this.addDeptToDataSet(ds, type);

            return 0;
        }

        /// <summary>
        /// 将专科、专家出诊科室添加到DataSet
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="type"></param>
        private void addDeptToDataSet(DataSet ds, Neusoft.HISFC.Models.Base.EnumSchemaType type)
        {
            dsItems.Tables[0].Rows.Clear();
            //DateTime current = this.regMgr.GetDateTimeFromSysDateTime() ;

            if (type == Neusoft.HISFC.Models.Base.EnumSchemaType.Dept)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dsItems.Tables["Dept"].Rows.Add(new object[]
                        {
                            row[0],//科室代码
                            row[1],//科室名称
                            row[10],//拼音吗
                            row[11],//五笔码
                            row[12],//自定义码
                            row[5],//挂号限额
                            row[6],//已挂号数
                            row[7],//预约限额
                            row[8],//已预约数
                            row[3],//开始时间
                            row[4],//结束时间
                            row[2],//午别
                            Neusoft.FrameWork.Function.NConvert.ToBoolean(row[9])
                        });
                }
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dsItems.Tables["Dept"].Rows.Add(new object[]
                        {
                            row[0],//科室代码
                            row[1],//科室名称
                            row[2],//拼音吗
                            row[3],//五笔码
                            row[4],//自定义码
                            0,//挂号限额
                            0,//已挂号数
                            0,//预约限额
                            0,//已预约数
                            DateTime.MinValue,//开始时间
                            DateTime.MinValue,//结束时间
                            "",//午别
                            false
                        });
                }
            }
        }


        /// <summary>
        /// init Reg department combox
        /// </summary>
        private void addRegDeptToCombox()
        {
            DataRow row;
            al = new ArrayList();

            for (int i = 0; i < this.dsItems.Tables["Dept"].Rows.Count; i++)
            {
                row = this.dsItems.Tables["Dept"].Rows[i];
                //重复的不添加
                if (i > 0 && row["ID"].ToString() == dsItems.Tables["Dept"].Rows[i - 1]["ID"].ToString()) continue;

                Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
                dept.ID = row["ID"].ToString();
                dept.Name = row["Name"].ToString();
                dept.SpellCode = row["Spell_Code"].ToString();
                dept.WBCode = row["Wb_Code"].ToString();
                dept.UserCode = row["Input_Code"].ToString();

                this.al.Add(dept);
            }

            this.cmbDept.AddItems(this.al);
        }

        private void ucAccountRegister_Load(object sender, EventArgs e)
        {
            initCombox();
            InitNoon();
            this.Clear();
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            if (this.valid() != -1)
            {
                if (GetReg() < 0) return;
                if (OnGetRegister != null)
                {
                    this.OnGetRegister(ref this.regObj);
                }
                this.FindForm().Close();
            }


        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            //this.isfinish = false;
            this.FindForm().Close();
        }

        #region INurseArrayRegister 成员

        public event Neusoft.HISFC.BizProcess.Interface.Registration.GetRegisterHander OnGetRegister;

        public Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
            }
        }

        #endregion

        private int GetReg()
        {
            this.regObj = new Neusoft.HISFC.Models.Registration.Register();

            Neusoft.FrameWork.Models.NeuObject regDept = this.cmbDept.SelectedItem;

            Neusoft.FrameWork.Models.NeuObject regLevel = this.cmbRegLevel.SelectedItem;

            //获取门诊流水号
            regObj.ID = this.registerManager.GetSequence("Registration.Register.ClinicID");

            //正交易
            regObj.TranType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
            //病历号
            regObj.PID.CardNO = patient.PID.CardNO;
            //挂号日期
            regObj.DoctorInfo.SeeDate = this.registerManager.GetDateTimeFromSysDateTime();
            //挂号午别编码
            regObj.DoctorInfo.Templet.Noon.ID = this.getNoon(this.registerManager.GetDateTimeFromSysDateTime());
            //挂号级别
            regObj.DoctorInfo.Templet.RegLevel.ID = regLevel.ID;
            //挂号级别名称
            regObj.DoctorInfo.Templet.RegLevel.Name = regLevel.Name;
            //结算类别编码自费
            regObj.Pact.PayKind.ID = "01";
            //结算类别自费
            regObj.Pact.PayKind.Name = "自费";
            //挂号科室编码
            regObj.DoctorInfo.Templet.Dept.ID = regDept.ID;
            //挂号科室名称
            regObj.DoctorInfo.Templet.Dept.Name = regDept.Name;
            //医生编码
            if (this.cmbDoctor.SelectedIndex == -1)
            {
                regObj.DoctorInfo.Templet.Doct.ID = "";
                regObj.DoctorInfo.Templet.Doct.Name = "";
            }
            else
            {
                regObj.DoctorInfo.Templet.Doct.ID = this.cmbDoctor.SelectedItem.ID;
                regObj.DoctorInfo.Templet.Doct.Name = this.cmbDoctor.SelectedItem.Name;
            }
            //出诊医生名称


            regObj.Name = patient.Name;//患者姓名

            regObj.Sex.ID = patient.Sex.ID;//性别

            regObj.Birthday = patient.Birthday;//出生日期

            //现场挂号 
            regObj.RegType = Neusoft.HISFC.Models.Base.EnumRegType.Reg;

            //账户支付的合同单位是否为现金类型

            regObj.Pact.ID = "1";//合同单位

            regObj.Pact.Name = "现金";

            regObj.SSN = "";//医疗证号

            regObj.PhoneHome =  patient.PhoneHome;//联系电话

            regObj.AddressHome = patient.AddressHome;//联系地址

            regObj.CardType.ID = patient.IDCardType.ID;//证件类型

            #region 挂号费
            int rtn = ConvertRegFeeToObject(regObj);
            if (rtn == -1)
            {
                MessageBox.Show("获取挂号费出错!", "提示");
                return -1;
            }
            if (rtn == 1)
            {
                MessageBox.Show("该挂号级别未维护挂号费,请先维护挂号费!", "提示");
                return -1;
            }

            //获得患者应收、报销
            ConvertCostToObject(regObj);
            #endregion

            //处方号

            //this.txtRecipeNo.Text = "";
            //给txtRecipeNo.Text赋处方号

            regObj.RecipeNO = this.GetRecipeNo(this.registerManager.Operator.ID);

            //是否收费
            regObj.IsFee = false;
            //挂号状态
            regObj.Status = Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid;
            //是否看诊
            regObj.IsSee = false;
            //挂号操作员
            regObj.InputOper.ID = this.registerManager.Operator.ID;
            //挂号操作员操作日期
            regObj.InputOper.OperTime = this.registerManager.GetDateTimeFromSysDateTime();

            // add by niuxinyuan
            //作废操作员
            regObj.CancelOper.ID = "";
            regObj.CancelOper.OperTime = DateTime.MinValue;
            //身份证号
            regObj.IDCard = patient.IDCard;

            regObj.IsAccount = true;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            DateTime current = this.registerManager.GetDateTimeFromSysDateTime();
            #region 更新看诊序号
            int orderNo = 0;
            string Err = string.Empty;
            //2看诊序号		
            if (this.UpdateSeeID(this.regObj.DoctorInfo.Templet.Dept.ID, this.regObj.DoctorInfo.Templet.Doct.ID,
                this.regObj.DoctorInfo.Templet.Noon.ID, this.regObj.DoctorInfo.SeeDate, ref orderNo,
                ref Err) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Err, "提示");
                return -1;
            }

            regObj.DoctorInfo.SeeNO = orderNo;

            //专家、专科、特诊、预约号更新排班限额

            #region schema

            if (this.UpdateSchema(this.regObj.RegType, ref orderNo, ref Err, regObj.DoctorInfo.Templet.RegLevel) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                if (Err != "") MessageBox.Show(Err, "提示");
                return -1;
            }

            regObj.DoctorInfo.SeeNO = orderNo;

            #endregion

            //1全院流水号			
            if (this.Update(current, ref orderNo, ref Err) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Err, "提示");
                return -1;
            }

            regObj.OrderNO = orderNo;

            #endregion

            if (this.registerManager.Insert(regObj) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(this.registerManager.Err, "提示");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }


        #region 将应缴金额转为挂号实体ConvertCostToObject
        /// <summary>
        /// 将应缴金额转为挂号实体,
        /// 属性不能作为ref参数传递
        /// </summary>
        /// <param name="obj"></param>
        private void ConvertCostToObject(Neusoft.HISFC.Models.Registration.Register obj)
        {
            //ownCost自费金额,pubCost报销金额
            decimal othFee = 0, ownCost = 0, pubCost = 0;
            //附加费
            othFee = obj.RegLvlFee.OthFee; //add by niux

            //得到患者应付金额
            this.getCost(obj.RegLvlFee.RegFee, obj.RegLvlFee.ChkFee, obj.RegLvlFee.OwnDigFee,
                    ref othFee, ref ownCost, ref pubCost, this.regObj.PID.CardNO);

            obj.RegLvlFee.OthFee = othFee;
            obj.OwnCost = ownCost;
            obj.PubCost = pubCost;

        }
        #endregion

        #region 获得患者应交金额、报销金额getCost
        /// <summary>
        /// 获得患者应交金额、报销金额
        /// </summary>
        /// <param name="regFee"></param>
        /// <param name="chkFee"></param>
        /// <param name="digFee"></param>
        /// <param name="othFee"></param>
        /// <param name="digPub"></param>
        /// <param name="ownCost"></param>
        /// <param name="pubCost"></param>
        /// <param name="cardNo"></param>		
        private void getCost(decimal regFee, decimal chkFee, decimal digFee, ref decimal othFee,
            ref decimal ownCost, ref decimal pubCost, string cardNo)
        {
            ownCost = regFee + chkFee + othFee + digFee;
            pubCost = 0;
        }
        #endregion

        #region 将应缴金额转为挂号实体ConvertRegFeeToObject
        /// <summary>
        /// 将应缴金额转为挂号实体,
        /// 属性不能作为ref参数传递
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int ConvertRegFeeToObject(Neusoft.HISFC.Models.Registration.Register obj)
        {
            decimal regFee = 0, chkFee = 0, digFee = 0, othFee = 0;

            //按合同单位和挂号级别得到挂号费
            int rtn = this.GetRegFee(obj.Pact.ID, obj.DoctorInfo.Templet.RegLevel.ID,
                          ref regFee, ref chkFee, ref digFee, ref othFee);

            //挂号费，检查费，诊察费，其他费
            obj.RegLvlFee.RegFee = regFee;
            obj.RegLvlFee.ChkFee = chkFee;
            obj.RegLvlFee.OwnDigFee = digFee;
            obj.RegLvlFee.OthFee = othFee;

            return rtn;
        }

        #endregion

        #region 获取挂号费GetRegFee
        /// <summary>
        /// 获取挂号费
        /// </summary>
        /// <param name="pactID"></param>
        /// <param name="regLvlID"></param>
        /// <param name="regFee"></param>
        /// <param name="chkFee"></param>
        /// <param name="digFee"></param>
        /// <param name="othFee"></param>
        /// <param name="digPubFee"></param>
        /// <returns></returns>
        private int GetRegFee(string pactID, string regLvlID, ref decimal regFee, ref decimal chkFee,
            ref decimal digFee, ref decimal othFee)
        {
            Neusoft.HISFC.Models.Registration.RegLvlFee p = this.regFeeMgr.Get(pactID, regLvlID);
            if (p == null)//出错
            {
                return -1;
            }
            if (p.ID == null || p.ID == "")//没有维护挂号费
            {
                return 1;
            }

            regFee = p.RegFee;
            chkFee = p.ChkFee;
            digFee = p.OwnDigFee;
            othFee = p.OthFee;

            return 0;
        }
        #endregion

        #region 更新看诊限额
        /// <summary>
        /// 更新看诊限额
        /// </summary>
        /// <param name="SchMgr"></param>
        /// <param name="regType"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int UpdateSchema(Neusoft.HISFC.Models.Base.EnumRegType regType, ref int seeNo, ref string Err, Neusoft.HISFC.Models.Registration.RegLevel level)
        {
            int rtn = 1;
            //挂号级别

            if (level.IsFaculty || level.IsExpert)//专家、专科,扣挂号限额
            {


                //判断限额是否允许挂号

                if (this.IsPermitOverrun(regType, (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.ID,
                                            level, ref seeNo, ref Err) == -1)
                {
                    return -1;
                }
            }
            else if (level.IsSpecial)//特诊扣特诊限额
            {
                rtn = SchemaMgr.Increase(
                    (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.ID,
                    false, false, false, true);

                //判断限额是否允许挂号

                if (this.IsPermitOverrun(regType, (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.ID,
                                    level, ref seeNo, ref Err) == -1)
                {
                    return -1;
                }
            }

            if (rtn == -1)
            {
                Err = "更新排班看诊限额时出错!" + SchemaMgr.Err;
                return -1;
            }

            if (rtn == 0)
            {
                Err = "医生排班信息已经改变,请重新选择看诊时段!";
                return -1;
            }

            return 0;
        }
        #endregion

        #region 判断超出挂号限额是否允许挂号
        /// <summary>
        /// 判断超出挂号限额是否允许挂号
        /// </summary>
        /// <param name="schMgr"></param>
        /// <param name="regType"></param>
        /// <param name="schemaID"></param>
        /// <param name="level"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int IsPermitOverrun(Neusoft.HISFC.Models.Base.EnumRegType regType,
                    string schemaID, Neusoft.HISFC.Models.Registration.RegLevel level,
                    ref int seeNo, ref string Err)
        {
            bool isOverrun = false;//是否超额

            Neusoft.HISFC.Models.Registration.Schema schema = this.SchemaMgr.GetByID(schemaID);
            if (schema == null || schema.Templet.ID == "")
            {
                Err = "查询排班信息出错!" + SchemaMgr.Err;
                return -1;
            }
            if (level.IsExpert || level.IsFaculty)//专家、专科判断限额是否大于已挂号
            {
                if (schema.Templet.RegQuota - schema.RegedQTY < 0)
                {
                    isOverrun = true;
                }
                seeNo = schema.SeeNO;
            }
            else if (level.IsSpecial)//特诊判断特诊限额是否超表
            {
                if (schema.Templet.SpeQuota - schema.SpedQTY < 0)
                {
                    isOverrun = true;
                }
                seeNo = schema.SeeNO;
            }

            if (isOverrun)
            {
                //加号不用提示
                if (schema.Templet.IsAppend) return 0;
                Err = "已经超出出诊排班限额,不能挂号!";
                return -1;
           
            }

            return 0;
        }
        #endregion

        #region 更新看诊序号
        /// <summary>
        /// 更新全院看诊序号
        /// </summary>
        /// <param name="rMgr"></param>
        /// <param name="current"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int Update(DateTime current, ref int seeNo,
            ref string Err)
        {
            //更新看诊序号
            //全院是全天大排序，所以午别不生效，默认 1
            if (this.registerManager.UpdateSeeNo("4", current, "ALL", "1") == -1)
            {
                Err = registerManager.Err;
                return -1;
            }

            //获取全院看诊序号
            if (registerManager.GetSeeNo("4", current, "ALL", "1", ref seeNo) == -1)
            {
                Err = registerManager.Err;
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 更新医生或科室的看诊序号
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="doctID"></param>
        /// <param name="noonID"></param>
        /// <param name="regDate"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int UpdateSeeID(string deptID, string doctID, string noonID, DateTime regDate,
            ref int seeNo, ref string Err)
        {
            string Type = "", Subject = "";

            #region ""

            if (doctID != null && doctID != "")
            {
                Type = "1";//医生
                Subject = doctID;
            }
            else
            {
                Type = "2";//科室
                Subject = deptID;
            }

            #endregion

            //更新看诊序号
            if (this.registerManager.UpdateSeeNo(Type, regDate, Subject, noonID) == -1)
            {
                Err = this.registerManager.Err;
                return -1;
            }

            //获取看诊序号		
            if (this.registerManager.GetSeeNo(Type, regDate, Subject, noonID, ref seeNo) == -1)
            {
                Err = this.registerManager.Err;
                return -1;
            }

            return 0;
        }

        #endregion

        #region 获取当前处方号private void GetRecipeNo(string OperID)
        /// <summary>
        /// 获取当前处方号
        /// </summary>
        /// <param name="OperID"></param>		
        private string GetRecipeNo(string OperID)
        {
            Neusoft.FrameWork.Models.NeuObject obj = this.conMgr.GetConstansObj("RegRecipeNo", OperID);
            if (obj == null)
            {
                MessageBox.Show("获取处方号出错!" + this.conMgr.Err, "提示");
                return null;
            }
            string recipeNo = string.Empty;
            if (obj.Name == "")
            {
                recipeNo = "0";
            }
            else
            {
                recipeNo = obj.Name;
            }
            return recipeNo;
        }

        #endregion

        #region 初始化午别InitNoon()
        /// <summary>
        /// 初始化午别
        /// </summary>
        private void InitNoon()
        {
            Neusoft.HISFC.BizLogic.Registration.Noon noonMgr = new Neusoft.HISFC.BizLogic.Registration.Noon();
            this.alNoon = noonMgr.Query();
            if (alNoon == null)
            {
                MessageBox.Show("获取午别信息时出错!" + noonMgr.Err, "提示");
                return;
            }
        }
        #endregion

        #region 根据当前时间获取午别 private string getNoon(DateTime current)
        /// <summary>
        /// 获取午别
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private string getNoon(DateTime current)
        {
            if (this.alNoon == null) return "";
            /*
             * 理解错误：以为午别应该是包含一天全部时间上午：06~12,下午:12~18其余为晚上,
             * 实际午别为医生出诊时间段,上午可能为08~11:30，下午为14~17:30
             * 所以如果挂号员如果不在这个时间段挂号,就有可能提示午别未维护
             * 所以改为根据传人时间所在的午别例如：9：30在06~12之间，那么就判断是否有午别在
             * 06~12之间，全包含就说明9:30是那个午别代码
             */
            //			foreach(neusoft.HISFC.Object.Registration.Noon obj in alNoon)
            //			{
            //				if(int.Parse(current.ToString("HHmmss"))>=int.Parse(obj.BeginTime.ToString("HHmmss"))&&
            //					int.Parse(current.ToString("HHmmss"))<int.Parse(obj.EndTime.ToString("HHmmss")))
            //				{
            //					return obj.ID;
            //				}
            //			}

            int[,] zones = new int[,] { { 0, 120000 }, { 120000, 180000 }, { 180000, 235959 } };
            int time = int.Parse(current.ToString("HHmmss"));
            int begin = 0, end = 0;

            for (int i = 0; i < 3; i++)
            {
                if (zones[i, 0] <= time && zones[i, 1] > time)
                {
                    begin = zones[i, 0];
                    end = zones[i, 1];
                    break;
                }
            }

            foreach (Neusoft.HISFC.Models.Base.Noon obj in alNoon)
            {
                if (int.Parse(obj.StartTime.ToString("HHmmss")) >= begin &&
                    int.Parse(obj.EndTime.ToString("HHmmss")) <= end)
                {
                    return obj.ID;
                }
            }

            return "";
        }
        #endregion

        private void cmbRegLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            this.cmbRegLevel.Tag = string.Empty;
            this.cmbDept.Tag = string.Empty;
            this.cmbDoctor.Tag = string.Empty;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    public partial class ucPatientCase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.Terminal.IOutpatientCase
    {
        public ucPatientCase()
        {
            InitializeComponent();
        }

        //路志鹏

        #region 变量
        ArrayList alText = new ArrayList();//TEXT数组
        ArrayList alChoose = new ArrayList();//转换后的数组
        private string Mod_No = null;//模板NO
        private string Mod_Name = null;//模板名称
        Neusoft.FrameWork.Models.NeuObject obj = null;//返回的实体
        /// <summary>
        ///Update、Insert操作后时间(用来修改的时候进行判断)
        /// </summary>
        private string newOperTime = string.Empty;
        /// <summary>
        /// Update操作前的时间
        /// </summary>
        private string oldOperTime = string.Empty;

        /// <summary>
        /// 用来判断是修改还是新增加病历
        /// </summary>
        private bool isNew = true;

        #endregion

        #region 属性
        /// <summary>
        /// 模板信息
        /// </summary>
        private string Module_No
        {
            get
            {
                return Mod_No;
            }
            set
            {
                this.Mod_No = value;
            }

        }

        /// <summary>
        /// 模板Name
        /// </summary>
        private string Module_Name
        {
            get
            {
                return Mod_Name;
            }
            set
            {
                Mod_Name = value;
            }
        }
        /// <summary>
        /// 用来判断是修改还是新增加病历
        /// </summary>
        private bool IsNew
        {
            get
            {
                return isNew;
            }
            set
            {
                isNew = value;
            }

        }
        /// <summary>
        /// 操作后的时间
        /// </summary>
        private string NewOperTime
        {
            get
            {
                return newOperTime;
            }
            set
            {
                newOperTime = value;
            }
        }
        /// <summary>
        /// 操作前的时间
        /// </summary>
        private string OldOperTime
        {
            get
            {
                return oldOperTime;
            }
            set
            {
                oldOperTime = value;
            }
        }

        #region {FAEDC7CD-81B3-4fe2-BFF0-65D4ACE52CF7}

        private bool isUseFilter = false;

        /// <summary>
        /// 常用语是否分组过滤
        /// </summary>
        [Category("控件设置"), Description("常用语是否分组过滤")]
        public bool IsUseFilter
        {
            set
            {
                this.isUseFilter = value;
            }
            get
            {
                return this.isUseFilter;
            }
        }

        #endregion

        #endregion

        #region 系统层管理类
        //Neusoft.HISFC.BizLogic.Manager.UserText textManager = null;
        //Neusoft.HISFC.BizLogic.Manager.Spell spell = new Neusoft.HISFC.BizLogic.Manager.Spell();
        Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManager =
                                                new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();


        Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory tempCaseModule = null;
        Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory caseHistory = null;
        //患者信息
        private Neusoft.HISFC.Models.Registration.Register myReg = null;
        #endregion

        #region 患者信息

        public Neusoft.HISFC.Models.Registration.Register Reg
        {
            get
            {
                return this.myReg;
            }
            set
            {
                this.myReg = value;

                this.SetPatientInfo();
                this.SetCaseHistory(myReg.ID);
                this.initTreeCase();
                //诊断录入
                //this.ucCaseInputForClinic1.PatientId = myReg.ID;
            }
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        private void SetPatientInfo()
        {
            if (this.myReg == null)
                return;
            this.lblname.Text = this.myReg.Name;
            this.lblmzh.Text = this.myReg.PID.CardNO;//门诊号{86FF08AA-88E5-42e9-AEDB-DA9AF4E6F456}
            //this.lblCardNo.Text = this.myReg.ID;//门诊号

            this.lblsex.Text = this.myReg.Sex.Name;//性别
            this.lblage.Text = this.GetAge(myReg.Birthday);//年龄
            if (this.myReg.Pact.PayKind.Name != "")
            {
                this.lbllb.Text = this.myReg.Pact.PayKind.Name;//结算类别
            }
            else
            {
                this.lbllb.Text = this.myReg.Pact.Name;//合同单位
            }
            this.lblks.Text = this.myReg.DoctorInfo.Templet.Dept.Name; //挂号科室
        }

        /// <summary>
        /// 获得年龄
        /// </summary>
        /// <param name="dtBirthday"></param>
        /// <returns></returns>
        private string GetAge(DateTime dtBirthday)
        {
            //DateTime age = new DateTime(System.DateTime.Now.Ticks - dtBirthday.Ticks);
            string strAge = "";
            //if (age.Year <= 0)
            //{
            //    if (age.Month <= 0)
            //    {
            //        strAge = age.Day.ToString() + "天";
            //    }
            //    else
            //    {
            //        strAge = age.Month.ToString() + "月";
            //    }
            //}
            //else
            //{
            //    strAge = age.Year + "岁";
            //}
            strAge = this.orderManager.GetAge(dtBirthday);
            return strAge;
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
                SetUeserText();
                this.initTree();
                SetVisble(true);
                this.neuTabControl1.SelectedIndex = 1;
                InitucDiagnose();
            }
            catch
            {
            }

            try
            {
                components = new Container();
                components.Add(this.txtMain, "备注");
                components.Add(this.txtMemo);
                components.Add(this.txtNow);
                components.Add(this.txtOld);
                components.Add(this.txtgms);
                this.ucUserText1.SetControl(this.components);
                this.ucUserText1.OnChange += new EventHandler(ucUserText1_OnChange);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 设置常用语
        /// </summary>
        private void SetUeserText()
        {
            try
            {
                //if (this.textManager == null)
                //    this.textManager = new Neusoft.HISFC.BizLogic.Manager.UserText();

                //string id = (this.textManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                string id = (this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                this.alText.Clear();
                this.alChoose.Clear();

                //根据科室获得常用语
                this.alText = this.managerIntegrate.GetList(id, 1);
                //this.alText = this.textManager.GetList(id, 1);
                //个人常用语
                //this.alText.AddRange(this.textManager.GetList(this.textManager.Operator.ID, 0));
                this.alText.AddRange(this.managerIntegrate.GetList((this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).ID, 0));

                for (int i = 0; i < this.alText.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.UserText txt = alText[i] as Neusoft.HISFC.Models.Base.UserText;
                    if (txt == null)
                        continue;
                    //转换所有的文本的拼音码
                    //txt.SpellCode = this.spell.Get(txt.Text).SpellCode;
                    #region 修改取名称拼音码 {C8B64A7F-A732-40c6-9577-BDE3DD90D521}
                    txt.SpellCode = this.managerIntegrate.Get(txt.Name).SpellCode;
                    txt.User01 = txt.Text;
                    this.alChoose.Add(txt);
                    #endregion

                }
            }
            catch
            {
            }
        }

        private void ucUserText1_OnChange(Object sender, EventArgs e)
        {
            SetUeserText();
        }

        private void InitucDiagnose()
        {
            this.ucDiagnose1.Visible = false;
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载诊断信息 请稍候.....");
            Application.DoEvents();
            this.ucDiagnose1.Init();
            this.ucDiagnose1.SelectItem += new Neusoft.HISFC.Components.Common.Controls.ucDiagnose.MyDelegate(ucDiagnose1_SelectItem);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }


        /// <summary>
        /// 判断病历是否为空
        /// </summary>
        /// <returns></returns>
        private bool Valid()
        {
            foreach (Control c in this.neuGroupBox3.Controls)
            {
                if (c.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox))
                {
                    if (c.Text.Trim() != "")
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 保存病历
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            if (!Valid())
            {
                MessageBox.Show("病历信息不能为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //获得病历信息
            this.newOperTime = this.orderManager.GetDateTimeFromSysDateTime().ToString();
            this.GetCaseHistory();
            if (this.myReg == null || this.myReg.ID == null || this.myReg.ID == "")
            {
                this.ShowErr("请选择一个患者！");
                return;
            }
            int i;
            if (isNew)
            {
                //保存
                i = this.orderManager.InsertCaseHistory(this.Reg, this.caseHistory);
            }
            else
            {
                i = this.orderManager.UpdateCaseHistory(this.Reg, this.caseHistory, this.OldOperTime);
            }
            if (i == -1)
            {
                if (this.orderManager.DBErrCode == 1)
                {
                    MessageBox.Show("该患者已存在门诊病历,不能重复生成!" , "提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("门诊病历保存失败" + this.orderManager.Err, "提示");
                return;
            }
            else if (i == 1)
            {
                MessageBox.Show("门诊病历保存成功", "提示");
                this.oldOperTime = this.newOperTime;
                this.initTreeCase();
                //保存成功后变为Update状态
                this.isNew = false;
                return;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initTree()
        {
            ArrayList al = null;//所有模板

            if (this.trvblmb.Nodes.Count > 0)
            {
                this.trvblmb.Nodes.Clear();
            }

            //添加科室模板
            TreeNode deptModule = new TreeNode("科室模板");
            deptModule.Tag = "DeptModule";
            deptModule.ImageIndex = 1;
            deptModule.SelectedImageIndex = 1;

            this.trvblmb.Nodes.Add(deptModule);
            try
            {
                al = this.orderManager.QueryAllCaseModule("1", (this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID);
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory module = al[i] as Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory;
                    if (module == null)
                        continue;
                    TreeNode node = new TreeNode(module.Name);
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                    node.Tag = module;
                    node.ContextMenu = this.cMenu;
                    deptModule.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                this.ShowErr("获得科室模板出错!" + ex.Message);
                return;
            }

            //个人模板
            TreeNode perModule = new TreeNode("个人模板");
            perModule.Tag = "PerModule";
            perModule.ImageIndex = 2;
            perModule.SelectedImageIndex = 2;

            this.trvblmb.Nodes.Add(perModule);
            try
            {
                al = this.orderManager.QueryAllCaseModule("2", this.orderManager.Operator.ID);
                for (int i = 0; i < al.Count; i++)
                {

                    Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory module = al[i] as Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory;
                    if (module == null)
                        continue;

                    TreeNode node = new TreeNode(module.Name);
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                    node.Tag = module;
                    node.ContextMenu = this.cMenu;
                    perModule.Nodes.Add(node);
                }
            }
            catch
            {
                this.ShowErr("获得个人模板出错!");
                return;
            }

            //展开
            this.trvblmb.ExpandAll();
        }

        /// <summary>
        /// 初始化历史病历
        /// </summary>
        private void initTreeCase()
        {
            ArrayList al = new ArrayList();
            try
            {
                if (this.trvlsbl.Nodes.Count > 0)
                {
                    this.trvlsbl.Nodes.Clear();
                }

                TreeNode root = new TreeNode();
                root.Text = "历史病历";
                root.ImageIndex = 1;
                root.SelectedImageIndex = 1;
                root.Tag = null;
                this.trvlsbl.Nodes.Add(root);
                al = this.orderManager.QueryAllCaseHistory(this.myReg.PID.CardNO);
                if (al == null || al.Count < 0)
                {
                    return;
                }
                else
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        Neusoft.FrameWork.Models.NeuObject obj = al[i] as Neusoft.FrameWork.Models.NeuObject;
                        if (obj == null)
                        {
                            continue;
                        }
                        TreeNode node = new TreeNode();
                        node.ImageIndex = 4;
                        node.SelectedImageIndex = 4;
                        node.Tag = obj;
                        if (obj.Memo != null)
                        {
                            node.Text = obj.Name + "[" + Neusoft.FrameWork.Function.NConvert.ToDateTime(obj.User01).ToShortDateString() + "]";
                        }
                        else
                        {
                            node.Text = obj.Name + "[" + obj.ID + "]";
                        }
                        root.Nodes.Add(node);
                    }
                    this.trvlsbl.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "获得历史模板出错！");
                return;
            }
        }

        /// <summary>
        /// 弹出错误
        /// </summary>
        /// <param name="Err"></param>
        private void ShowErr(string Err)
        {
            MessageBox.Show(Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 保存为模板
        /// </summary>
        public void SaveModule()
        {

            try
            {
                Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory module
                        = new Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory();
                //如果不为空则代表是Update
                string ID;
                if (this.Module_No != null)
                    ID = this.Module_No;
                else
                {
                    ID = this.orderManager.GetModuleSeq();//编号
                }

                #region 诊断
                ////this.ucCaseInputForClinic1.PatientId = "MB" + ID;//编号
                //try
                //{
                //    int i = -1;
                //    i = this.ucCaseInputForClinic1.Save();
                //    if (i < 0)
                //    {
                //        this.ShowErr("保存模板诊断时出现错误！");
                //        return;
                //    }
                //}
                //catch
                //{
                //    this.ShowErr("保存模板诊断时出现错误！");
                //    return;
                //}
                #endregion
                module = this.GetCaseHistory();
                //判断是否存为科室模板
                module.ModuleType = this.chkIsPerson.Checked ? "1" : "2";
                //医生
                module.DoctID = this.orderManager.Operator.ID;
                module.ID = ID;
                //科室
                Neusoft.HISFC.Models.Base.Employee p = orderManager.Operator as Neusoft.HISFC.Models.Base.Employee;
                module.DeptID = p.Dept.ID;
                //在update的时候不用弹出输入模板名称窗体
                if (this.Module_No == null)
                {
                    HISFC.Components.Order.OutPatient.Forms.frmPopShow frm = new HISFC.Components.Order.OutPatient.Forms.frmPopShow();
                    frm.ShowDialog();
                    #region {CAEC0986-5DE9-4fed-9112-65C7E3B812AE}
                    //DialogResult r = frm.ShowDialog();
                    //{0DE339CF-3DE4-4b84-BE70-FD55E1509789}
                    //if (r == DialogResult.Cancel)
                    //{
                    //    return;
                    //}
                    if (frm.IsCancel)
                    {
                        return;
                    }
                    #endregion
                    if (frm.ModuleName == "")
                    {
                        module.Name = "新建病历模板";
                    }
                    else
                    {
                        module.Name = frm.ModuleName;
                    }
                }
                else
                {
                    module.Name = this.Module_Name;
                }
                try
                {
                    int i = -1;
                    //i = this.orderManager.SetCaseModule(this.orderManager.Operator as Neusoft.HISFC.Models.RADT.Person, module);
                    i = this.orderManager.SetCaseModule(module);
                    if (i < 0)
                    {
                        this.ShowErr("保存为病历模板时出现错误！");
                        return;
                    }
                    else
                    {
                        this.ShowErr("保存病历模板成功！");
                    }
                }
                catch (Exception ex)
                {
                    this.ShowErr("保存为病历模板时出现错误！" + ex.Message);
                    return;
                }
                this.initTree();
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
            }
        }

        // <summary>
        /// 得到病历信息
        /// </summary>
        /// <returns></returns>

        private Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory GetCaseHistory()
        {
            this.caseHistory = new Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory();
            this.caseHistory.CaseMain = this.txtMain.Text.Trim();//主诉
            this.caseHistory.CaseNow = this.txtNow.Text.Trim();//现病史
            this.caseHistory.CaseOld = this.txtOld.Text.Trim();//既往史
            this.caseHistory.CheckBody = this.txtCheck.Text.Trim();//查体
            string strDiag = this.txtDiagnose.Text.Trim();
            if (this.txtDiagnose2.Text.Trim() != "")
            {
                strDiag += "|" + txtDiagnose2.Text.Trim();
            }
            if (this.txtDiagnose3.Text.Trim() != "")
            {
                strDiag += "|" + txtDiagnose3.Text.Trim();
            }
            this.caseHistory.CaseDiag = strDiag;//诊断
            this.caseHistory.Memo = this.txtMemo.Text.Trim();//备注
            this.caseHistory.CaseAllery = this.txtgms.Text.Trim();
            this.caseHistory.IsInfect = this.chkCrb.Checked;//是否传染病
            this.caseHistory.IsAllery = this.chkGm.Checked;//是否过敏
            this.caseHistory.CaseOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.NewOperTime);//操作时间
            return this.caseHistory;
        }

        /// <summary>
        /// 得到过敏史
        /// </summary>
        /// <returns></returns>
        private string GetAllery()
        {
            return "";
        }

        /// <summary>
        /// 设置显示
        /// </summary>
        /// <param name="regId"></param>
        private void SetCaseHistory(string regId)
        {
            this.caseHistory = this.orderManager.QueryCaseHistoryByClinicCode(regId);//.SelectCaseHistory(regId);
            if (this.caseHistory != null)
            {
                this.txtMain.Text = caseHistory.CaseMain;//主诉
                this.txtNow.Text = caseHistory.CaseNow;//现病史
                this.txtOld.Text = caseHistory.CaseOld;//既往史
                this.txtCheck.Text = caseHistory.CheckBody;//查体
                this.txtMemo.Text = caseHistory.Memo;//备注
                this.txtgms.Text = caseHistory.CaseAllery;//过敏史
                this.chkCrb.Checked = caseHistory.IsInfect;
                this.chkGm.Checked = caseHistory.IsAllery;
                string[] s = caseHistory.CaseDiag.Split('|');
                if (s.Length > 0)
                {
                    this.txtDiagnose.Text = s[0];
                }
                if (s.Length > 1)
                {
                    this.txtDiagnose2.Text = s[1];
                }
                if (s.Length > 2)
                {
                    this.txtDiagnose3.Text = s[2];
                }
                this.OldOperTime = caseHistory.CaseOper.OperTime.ToString();
                this.isNew = false;
            }
            else
            {
                this.isNew = true;
                this.Claar();
            }
            this.txtMain.Focus();
            if (this.ucDiagnose1.Visible)
            {
                this.ucDiagnose1.Visible = false;
            }
        }

        private void SetCaseHistory(string regId, string operTime)
        {
            this.caseHistory = this.orderManager.QueryCaseHistoryByClinicCode(regId, operTime);//.SelectCaseHistory(regId);
            if (this.caseHistory != null)
            {
                this.txtMain.Text = caseHistory.CaseMain;//主诉
                this.txtNow.Text = caseHistory.CaseNow;//现病史
                this.txtOld.Text = caseHistory.CaseOld;//既往史
                this.txtCheck.Text = caseHistory.CheckBody;//查体
                this.txtMemo.Text = caseHistory.Memo;//备注
                this.txtgms.Text = caseHistory.CaseAllery;//过敏史
                this.chkCrb.Checked = caseHistory.IsInfect;
                this.chkGm.Checked = caseHistory.IsAllery;
                string[] s = caseHistory.CaseDiag.Split('|');
                if (s.Length > 0)
                {
                    this.txtDiagnose.Text = s[0];
                }
                if (s.Length > 1)
                {
                    this.txtDiagnose2.Text = s[1];
                }
                if (s.Length > 2)
                {
                    this.txtDiagnose3.Text = s[2];
                }
                //this.txtDiagnose.Text = caseHistory.CaseDiag;
                this.OldOperTime = caseHistory.CaseOper.OperTime.ToString();//操作时间
                this.isNew = false;
            }
            else
            {
                this.isNew = true;
                this.Claar();
            }
            this.txtMain.Focus();
            if (this.ucDiagnose1.Visible)
            {
                this.ucDiagnose1.Visible = false;
            }
        }

        /// <summary>
        /// 根据模板设置
        /// </summary>
        /// <param name="module"></param>
        private void SetCaseHistory(Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory module)
        {
            this.txtMain.Text = module.CaseMain;
            this.txtNow.Text = module.CaseNow;
            this.txtOld.Text = module.CaseOld;
            this.txtCheck.Text = module.CheckBody;
            this.txtMemo.Text = module.Memo;
            this.txtgms.Text = module.CaseAllery;
            this.chkCrb.Checked = module.IsInfect;
            this.chkGm.Checked = module.IsAllery;
            string[] s = module.CaseDiag.Split('|');
            if (s.Length > 0)
            {
                this.txtDiagnose.Text = s[0];
            }
            if (s.Length > 1)
            {
                this.txtDiagnose2.Text = s[1];
            }
            if (s.Length > 2)
            {
                this.txtDiagnose3.Text = s[2];
            }
            //this.txtDiagnose.Text = module.CaseDiag;
            //选择节点后得到ModuleNo
            this.Module_No = module.ID;
            this.Module_Name = module.Name;
            if (module.ModuleType == "1")
            {
                this.chkIsPerson.Checked = true;
            }
            else
            {
                this.chkIsPerson.Checked = false;
            }
            this.txtMain.Focus();
            if (this.ucDiagnose1.Visible)
            {
                this.ucDiagnose1.Visible = false;
            }
        }

        /// <summary>
        /// 清屏
        /// </summary>
        private void Claar()
        {
            this.txtMain.Clear();
            this.txtNow.Clear();
            this.txtOld.Clear();
            this.txtMemo.Clear();
            this.txtCheck.Clear();
            this.txtgms.Clear();
            this.chkCrb.Checked = false;
            this.chkGm.Checked = false;
            this.txtMain.Focus();
            if (this.ucDiagnose1.Visible)
            {
                this.ucDiagnose1.Visible = false;
            }
        }

        /// <summary>
        /// 模板病历操作显示
        /// </summary>
        /// <param name="bl">是否可见</param>
        private void SetVisble(bool bl)
        {
            this.grmb.Visible = bl;
            this.grbl.Visible = !bl;
        }

        /// <summary>
        /// 得到目的节点
        /// </summary>
        /// <param name="aimNode">目的节点</param>
        /// <param name="moveNode">要移动的节点</param>
        /// <returns></returns>
        private TreeNode GetaimNode(TreeNode aimNode, TreeNode moveNode)
        {
            try
            {
                //存放移动前节点是个人模板还是科室模板标识
                string tag = moveNode.Parent.Tag.ToString();
                //存放目的节点是个人模板还是科室模板
                string aimtag = string.Empty;
                TreeNode tempNode = null;
                //如果子节点为0则判断是子节点还是跟节点
                if (aimNode.Nodes.Count == 0)
                {
                    if (aimNode.Tag.ToString().Trim() == "DeptModule" || aimNode.Tag.ToString().Trim() == "PerModule")
                    {
                        tempNode = aimNode;
                        aimtag = aimNode.Tag.ToString().Trim();
                    }
                    else
                    {
                        tempNode = aimNode.Parent;
                        aimtag = aimNode.Parent.Tag.ToString().Trim();
                    }
                }
                else
                {
                    tempNode = aimNode;
                    aimtag = aimNode.Tag.ToString().Trim();
                }
                if (aimtag == tag)
                    return null;
                return tempNode;
            }
            catch
            {
                return null;
            }

        }

        private void IsShowPrint(bool bl)
        {
            this.groupBox2.Visible = bl;
            this.groupBox3.Visible = bl;
            this.groupBox4.Visible = bl;
            this.groupBox5.Visible = bl;
            this.groupBox6.Visible = bl;
            if (bl)
            {
                this.txtMain.BorderStyle = BorderStyle.Fixed3D;
                this.txtNow.BorderStyle = BorderStyle.Fixed3D;
                this.txtOld.BorderStyle = BorderStyle.Fixed3D;
                this.txtgms.BorderStyle = BorderStyle.Fixed3D;
                this.txtCheck.BorderStyle = BorderStyle.Fixed3D;
                this.txtDiagnose.BorderStyle = BorderStyle.Fixed3D;
                this.txtDiagnose2.BorderStyle = BorderStyle.Fixed3D;
                this.txtDiagnose3.BorderStyle = BorderStyle.Fixed3D;
                this.txtMemo.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                this.txtMain.BorderStyle = BorderStyle.None;
                this.txtNow.BorderStyle = BorderStyle.None;
                this.txtOld.BorderStyle = BorderStyle.None;
                this.txtgms.BorderStyle = BorderStyle.None;
                this.txtCheck.BorderStyle = BorderStyle.None;
                this.txtDiagnose.BorderStyle = BorderStyle.None;
                this.txtDiagnose2.BorderStyle = BorderStyle.None;
                this.txtDiagnose3.BorderStyle = BorderStyle.None;
                this.txtMemo.BorderStyle = BorderStyle.None;
            }
        }

        #region {11610001-5803-4728-9FE9-BD255BCCAB81}
        /// <summary>
        /// 重写
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (neuObject != null && neuObject.GetType() == typeof(Neusoft.HISFC.Models.Registration.Register))
            {
                this.Reg = neuObject as Neusoft.HISFC.Models.Registration.Register;
            }
            return base.OnSetValue(neuObject, e);
        }
        #endregion

        #endregion

        #region 事件
        private void ucPatientCase_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.Init();

                this.btnNewbl.Visible = false;
            }
            //this.initDockManager();
        }

        private void lnkMain_Click(object sender, EventArgs e)
        {
            this.txtMain.Undo();
        }

        private void lnkNow_Click(object sender, EventArgs e)
        {
            this.txtNow.Undo();

        }

        private void lnkOld_Click(object sender, EventArgs e)
        {
            this.txtOld.Undo();
        }

        #region {FA68A56B-643E-4586-A57F-ADC603B7D490}
        private void lnkCheck_Click(object sender, EventArgs e)
        {
            this.txtCheck.Undo();
        }

        private void lnkMemo_Click(object sender, EventArgs e)
        {
            this.txtMemo.Undo();
        }

        #endregion

        /// <summary>
        /// 节点修改名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            TreeNode node = this.trvblmb.SelectedNode;
            if (node.Tag == null)
            {
                return;
            }
            this.tempCaseModule = node.Tag as Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory;

            if (this.tempCaseModule == null)
            {
                return;
            }

            HISFC.Components.Order.OutPatient.Forms.frmPopShow frm = new HISFC.Components.Order.OutPatient.Forms.frmPopShow();
            frm.ShowDialog();
            //{CAEC0986-5DE9-4fed-9112-65C7E3B812AE}
            if(frm.IsCancel)
            {
                return;
            }
            string name = frm.ModuleName;
            if (name == null || name == "")
            {
                this.ShowErr("病历模板名称不能为空！请修改");
                return;
            }
            this.tempCaseModule.Name = name;
            try
            {
                int i = -1;
                // Neusoft.HISFC.Models.RADT.Person                                                                 
                //i = this.orderManager.SetCaseModule((this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee), this.tempCaseModule);
                i = this.orderManager.SetCaseModule(this.tempCaseModule);
                if (i < 0)
                {
                    this.ShowErr("修改名称失败！" + this.orderManager.Err);
                    return;
                }
                else
                {
                    this.ShowErr("修改名称成功！");
                    this.initTree();
                }
            }
            catch
            {
                this.ShowErr("修改名称失败！" + this.orderManager.Err);
                return;
            }
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Drsult = MessageBox.Show("确认删除该模板？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (Drsult == DialogResult.OK)
                {
                    int result = this.orderManager.DeleteCaseModule(this.Module_No);
                    if (result < 0)
                    {
                        this.ShowErr("删除失败！");
                    }
                    else
                    {
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.trvblmb.Nodes.Remove(this.trvblmb.SelectedNode);
                    }
                }

            }
            catch (Exception ex)
            {

                this.ShowErr("删除失败！" + "错误：" + ex.Message);
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveModule();
        }

        /// <summary>
        /// 选中模板节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void trvblmb_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.trvblmb.SelectedNode == null)
            {
                return;
            }

            if (this.trvblmb.SelectedNode.Tag.ToString() == "DeptModule" || this.trvblmb.SelectedNode.Tag.ToString() == "PerModule")
                return;

            Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory module = this.trvblmb.SelectedNode.Tag
                        as Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory;
            if (module == null)
            {
                return;
            }
            this.SetCaseHistory(module);
        }

        private void trvlsbl_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.trvlsbl.SelectedNode != null && this.trvlsbl.SelectedNode.Tag != null)
            {
                Neusoft.FrameWork.Models.NeuObject obj = this.trvlsbl.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
                if (obj == null)
                {
                    return;
                }
                #region 关键属性不能在此修改 {5B0AF949-EE51-4f59-A09D-4BB483530C42} xuc
                //this.myReg.ID = obj.ID;
                this.SetPatientInfo();
                this.SetCaseHistory(obj.ID, obj.User01);
                #endregion
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            this.Claar();
            this.Module_No = null;
            this.Module_Name = null;
            this.txtMain.Focus();
        }

        private void btnSavebl_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        #region RichTextBox事件

        private void txtMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space || !this.chkMain.Checked)
            {
                return;
            }

            obj = new Neusoft.FrameWork.Models.NeuObject();

            #region {FAEDC7CD-81B3-4fe2-BFF0-65D4ACE52CF7}

            //Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);

            if (this.isUseFilter)
            {
                ArrayList alMyChoose = new ArrayList();
                foreach (Neusoft.HISFC.Models.Base.UserText userText in alChoose)
                {
                    if (userText.Memo == "主诉")
                    {
                        alMyChoose.Add(userText);

                    }
                }
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alMyChoose, ref obj);
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);
            }
            #endregion

            if (obj == null || obj.ID == "")
            {
                return;
            }

            this.txtMain.AppendText(obj.User01 + "。");
            this.txtMain.SelectionStart = this.txtMain.Text.Length;
            this.txtMain.ScrollToCaret();
            this.txtMain.Focus();

            //更新使用频次
            this.managerIntegrate.UpdateFrequency(obj.Memo, (this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).ID);
        }

        private void txtNow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space || !this.chkNow.Checked)
            {
                return;
            }

            obj = new Neusoft.FrameWork.Models.NeuObject();
            #region {FAEDC7CD-81B3-4fe2-BFF0-65D4ACE52CF7}

            //Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);

            if (this.isUseFilter)
            {
                ArrayList alMyChoose = new ArrayList();
                foreach (Neusoft.HISFC.Models.Base.UserText userText in alChoose)
                {
                    if (userText.Memo == "现病史")
                    {
                        alMyChoose.Add(userText);

                    }
                }
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alMyChoose, ref obj);
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);
            }
            #endregion

            //buffer = new System.Text.StringBuilder();
            if (obj == null || obj.ID == "")
            {
                return;
            }

            this.txtNow.AppendText(obj.User01 + "。");
            this.txtNow.SelectionStart = this.txtNow.Text.Length;
            this.txtNow.ScrollToCaret();
            this.txtNow.Focus();
            this.managerIntegrate.UpdateFrequency(obj.Memo, (this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).ID);
        }

        private void txtOld_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space || !this.chkOld.Checked)
            {
                return;
            }

            obj = new Neusoft.FrameWork.Models.NeuObject();
            #region {FAEDC7CD-81B3-4fe2-BFF0-65D4ACE52CF7}

            //Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);

            if (this.isUseFilter)
            {
                ArrayList alMyChoose = new ArrayList();
                foreach (Neusoft.HISFC.Models.Base.UserText userText in alChoose)
                {
                    if (userText.Memo == "既往史")
                    {
                        alMyChoose.Add(userText);

                    }
                }
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alMyChoose, ref obj);
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);
            }
            #endregion
            if (obj == null || obj.ID == "")
            {
                return;
            }
            this.txtOld.AppendText(obj.User01 + "。");
            this.txtOld.SelectionStart = this.txtOld.Text.Length;
            this.txtOld.ScrollToCaret();
            this.txtOld.Focus();

            this.managerIntegrate.UpdateFrequency(obj.Memo, (this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).ID);
        }

        private void txtgms_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space || !this.chkCheck.Checked)
            {
                return;
            }

            #region {4D7B2AB9-A15C-4c07-9BA4-0D20F0E18D3A}

            //obj = new Neusoft.FrameWork.Models.NeuObject();
            //Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);


            //if (obj == null || obj.ID == "")
            //{
            //    return;
            //}
            //this.txtgms.AppendText(obj.User01 + "。");
            //this.txtgms.SelectionStart = this.txtCheck.Text.Length;
            //this.txtgms.ScrollToCaret();
            //this.txtgms.Focus();

            //this.managerIntegrate.UpdateFrequency(obj.Memo, (this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).ID);
            #endregion
        }

        private void txtCheck_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space || !this.chkCheck.Checked)
            {
                return;
            }

            obj = new Neusoft.FrameWork.Models.NeuObject();
            #region {FAEDC7CD-81B3-4fe2-BFF0-65D4ACE52CF7}

            //Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);

            if (this.isUseFilter)
            {
                ArrayList alMyChoose = new ArrayList();
                foreach (Neusoft.HISFC.Models.Base.UserText userText in alChoose)
                {
                    if (userText.Memo == "查体")
                    {
                        alMyChoose.Add(userText);

                    }
                }
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alMyChoose, ref obj);
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);
            }
            #endregion

            if (obj == null || obj.ID == "")
            {
                return;
            }
            this.txtCheck.AppendText(obj.User01 + "。");
            this.txtCheck.SelectionStart = this.txtCheck.Text.Length;
            this.txtCheck.ScrollToCaret();
            this.txtCheck.Focus();

            this.managerIntegrate.UpdateFrequency(obj.Memo, (this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).ID);
        }

        private void txtMemo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space || !this.chkMemo.Checked)
            {
                return;
            }
            obj = new Neusoft.FrameWork.Models.NeuObject();
            #region {FAEDC7CD-81B3-4fe2-BFF0-65D4ACE52CF7}

            //Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);

            if (this.isUseFilter)
            {
                ArrayList alMyChoose = new ArrayList();
                foreach (Neusoft.HISFC.Models.Base.UserText userText in alChoose)
                {
                    if (userText.Memo == "备注")
                    {
                        alMyChoose.Add(userText);

                    }
                }
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(alMyChoose, ref obj);
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alChoose, ref obj);
            }
            #endregion

            if (obj == null || obj.ID == "")
            {
                return;
            }

            this.txtMemo.AppendText(obj.Name + "。");
            this.txtMemo.SelectionStart = this.txtMemo.Text.Length;
            this.txtMemo.ScrollToCaret();
            this.txtMemo.Focus();

            //update 
            this.managerIntegrate.UpdateFrequency(obj.Memo, (this.orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).ID);
            this.chkMemo.Checked = false;
        }

        #endregion

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuTabControl1.SelectedIndex == 0)
            {
                this.SetVisble(true);
            }
            else
            {
                this.SetVisble(false);
            }
        }

        #region Drop模板TreeView节点
        private void trvblmb_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void trvblmb_DragOver(object sender, DragEventArgs e)
        {
            Point p = new Point();
            p.X = e.X;
            p.Y = e.Y;
            TreeNode node = this.trvblmb.GetNodeAt(p);
            this.trvblmb.SelectedNode = node;
            this.trvblmb.Focus();
        }

        private void trvblmb_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //如果是跟接点(科室模板或个人模板)则return
                TreeNode node = (TreeNode)e.Item;
                string tag = node.Tag.ToString().Trim();
                if (tag == " PerModule" || tag == "DeptModule")
                    return;
                //开始进行"Drag"操作
                DoDragDrop((TreeNode)e.Item, DragDropEffects.Move);

            }
        }

        private void trvblmb_DragDrop(object sender, DragEventArgs e)
        {

            string Mess = null;

            TreeNode temp = new TreeNode();
            //得到要移动的节点
            TreeNode moveNode = (TreeNode)e.Data.GetData(temp.GetType());

            //转换坐标为控件treeview的坐标
            Point position = new Point(0, 0);
            position.X = e.X;
            position.Y = e.Y;
            position = this.trvblmb.PointToClient(position);

            //得到移动的目的地的节点
            TreeNode aimNode = this.trvblmb.GetNodeAt(position);
            if (aimNode == null)
                return;
            //得到要将移动节点加如到哪个节点下面
            TreeNode MdNode = GetaimNode(aimNode, moveNode);
            if (MdNode == null)
                return;
            string Modtype = string.Empty;//要移动的节点的模板类型
            string ModNumer = string.Empty;//要移动的节点的模板ID
            Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory MoveModule = moveNode.Tag as Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory;
            ModNumer = MoveModule.ID;
            //如果是科室模板则改为个人模板
            if (MoveModule.ModuleType == "1")
            {
                Mess = "确认要将科室模板改为个人模板？";
                Modtype = "2";
            }
            else
            {
                Mess = "确认要将个人模板改为科室模板？";
                Modtype = "1";
            }

            DialogResult Result = MessageBox.Show(Mess, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.OK)
            {
                //更新模板类型
                if (this.orderManager.UpdateCaseModuleType(Modtype, ModNumer) < 0)
                {
                    this.ShowErr("更新模板类型失败！");
                    return;
                }
                //Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory obj = moveNode.Tag as Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory;
                MoveModule.ModuleType = Modtype;
                moveNode.Tag = MoveModule;
                this.trvblmb.Nodes.Remove(moveNode);
                MdNode.Nodes.Add(moveNode);
            }
        }
        #endregion

        private void btnprint_Click(object sender, EventArgs e)
        {
            this.IsShowPrint(false);
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            this.ucDiagnose1.Visible = false;
            print.IsDataAutoExtend = false;
            print.PrintDocument.PrinterSettings.FromPage = 1;
            print.PrintDocument.PrinterSettings.ToPage = 1;
            print.PrintPreview(this.neuPanel3);
            this.IsShowPrint(true);
        }

        private int ucDiagnose1_SelectItem(Keys KeyData)
        {
            //{3D672433-A2BF-4d83-BB37-DF3E52074898}  诊断录入
            Neusoft.HISFC.Models.HealthRecord.ICD icd = new Neusoft.HISFC.Models.HealthRecord.ICD();
            this.ucDiagnose1.GetItem(ref icd);

            if (icd != null)
            {
                //以下处理比较恶心了。

                //if (this.ucDiagnose1.Tag.ToString() == "1") {9D436FA6-7D1D-4170-AB59-1C9CA7A70088}
                if(this.ucDiagnose1.Location==new Point(71,296))
                {
                    this.txtDiagnose.Text = icd.Name;
                    this.txtDiagnose2.Focus();
                }
                else if (this.ucDiagnose1.Location == new Point(71, 337))
                {
                    this.txtDiagnose2.Text = icd.Name;
                    this.txtDiagnose3.Focus();
                }
                else
                {
                    this.txtDiagnose3.Text = icd.Name;
                }
            }

            this.ucDiagnose1.Visible = false;

            return 1;
        }

        private void txtDiagnose_TextChanged(object sender, EventArgs e)
        {
            if (this.ucDiagnose1.Visible == false)
            {
                this.ucDiagnose1.Visible = true;
            }

            this.ucDiagnose1.Filter(this.txtDiagnose.Text);
            if (this.txtDiagnose.Text.Trim() == "")
                this.ucDiagnose1.Visible = true;
        }

        private void txtDiagnose_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Up)
            {
                this.ucDiagnose1.PriorRow();
                this.ucDiagnose1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                this.ucDiagnose1.NextRow();
                this.ucDiagnose1.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.ucDiagnose1.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                Neusoft.HISFC.Models.HealthRecord.ICD icd = new Neusoft.HISFC.Models.HealthRecord.ICD();
                this.ucDiagnose1.GetItem(ref icd);
                if (icd != null)
                {
                    this.txtDiagnose.Text = icd.Name;
                }
                this.ucDiagnose1.Visible = false;

                e.Handled = true;
                txtDiagnose2.Focus();
            }
        }

        private void txtDiagnose_Enter(object sender, EventArgs e)
        {
            this.ucDiagnose1.Location = new Point(71, 296);
            this.ucDiagnose1.Filter(this.txtDiagnose.Text);
            this.ucDiagnose1.Visible = true;
            this.ucDiagnose1.Tag = "1";

            this.ucDiagnose1.Visible = true;
        }

        private void txtDiagnose_Leave(object sender, EventArgs e)
        {
           // this.ucDiagnose1.Visible = false;
        }

        private void btnNewbl_Click(object sender, EventArgs e)
        {
            isNew = true;
            this.Claar();
        }

        #endregion

        private void txtDiagnose2_Leave(object sender, EventArgs e)
        {
            //{3D672433-A2BF-4d83-BB37-DF3E52074898}  诊断录入
            //this.ucDiagnose1.Visible = false;
        }
        private void txtDiagnose2_TextChanged(object sender, EventArgs e)
        {
            ////{3D672433-A2BF-4d83-BB37-DF3E52074898}  诊断录入
            if (this.ucDiagnose1.Visible == false)
            {
                this.ucDiagnose1.Visible = true;
            }

            this.ucDiagnose1.Filter(this.txtDiagnose2.Text);
            if (this.txtDiagnose2.Text.Trim() == "")
                this.ucDiagnose1.Visible = true;
        }
        private void txtDiagnose2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ucDiagnose1.PriorRow();
                this.ucDiagnose1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                this.ucDiagnose1.NextRow();
                this.ucDiagnose1.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.ucDiagnose1.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                Neusoft.HISFC.Models.HealthRecord.ICD icd = new Neusoft.HISFC.Models.HealthRecord.ICD();
                this.ucDiagnose1.GetItem(ref icd);
                if (icd != null)
                {
                    this.txtDiagnose2.Text = icd.Name;
                }
                this.ucDiagnose1.Visible = false;

                e.Handled = true;
                txtDiagnose3.Focus();
            }
        }
        private void txtDiagnose2_Enter(object sender, EventArgs e)
        {
            this.ucDiagnose1.Location = new Point(71, 337);
            this.ucDiagnose1.Filter(this.txtDiagnose2.Text);
            this.ucDiagnose1.Visible = true;
            ////{3D672433-A2BF-4d83-BB37-DF3E52074898}  诊断录入
            this.ucDiagnose1.Tag = "2";

            this.ucDiagnose1.Visible = true;
        }

        private void txtDiagnose3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.ucDiagnose1.PriorRow();
                this.ucDiagnose1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                this.ucDiagnose1.NextRow();
                this.ucDiagnose1.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.ucDiagnose1.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                Neusoft.HISFC.Models.HealthRecord.ICD icd = new Neusoft.HISFC.Models.HealthRecord.ICD();
                this.ucDiagnose1.GetItem(ref icd);
                if (icd != null)
                {
                    this.txtDiagnose3.Text = icd.Name;
                }
                this.ucDiagnose1.Visible = false;

                e.Handled = true;
            }
        }

        private void txtDiagnose3_Leave(object sender, EventArgs e)
        {
            ////{3D672433-A2BF-4d83-BB37-DF3E52074898}  诊断录入
            //this.ucDiagnose1.Visible = false;
        }


        private void txtDiagnose3_Enter(object sender, EventArgs e)
        {
            this.ucDiagnose1.Location = new Point(71, 387);
            this.ucDiagnose1.Filter(this.txtDiagnose3.Text);
            this.ucDiagnose1.Visible = true;
            //{3D672433-A2BF-4d83-BB37-DF3E52074898}  诊断录入
            this.ucDiagnose1.Tag = "3";

            this.ucDiagnose1.Visible = true;
        }

        private void txtDiagnose3_TextChanged(object sender, EventArgs e)
        {
            //{3D672433-A2BF-4d83-BB37-DF3E52074898}  诊断录入
            if (this.ucDiagnose1.Visible == false)
            {
                this.ucDiagnose1.Visible = true;
            }

            this.ucDiagnose1.Filter(this.txtDiagnose3.Text);
            if (this.txtDiagnose3.Text.Trim() == "")
                this.ucDiagnose1.Visible = true;
        }

        #region IOutpatientCase 成员 {967CA656-AB9D-4841-8BFE-9A2EC7E8F886}

        private bool isBrowse = false;

        public int InitUC()
        {
            return 1;
        }

        public Neusoft.HISFC.Models.Registration.Register Register
        {
            set
            {
                this.Reg = value;
            }
        }

        public bool IsBrowse
        {
            set
            {
                this.isBrowse = value;

                this.Width = this.neuPanel3.Width;
                this.neuPanel1.Visible = !value;
                this.neuPanel2.Visible = !value;
            }
        }

        /// <summary>
        /// 数据显示
        /// </summary>
        public void Show()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this);
        }

        #endregion


    }
}

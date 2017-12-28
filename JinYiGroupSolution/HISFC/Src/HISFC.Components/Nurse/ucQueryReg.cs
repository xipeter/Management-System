using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse
{
    public partial class ucQueryReg : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 定义

        /// <summary>
        /// 待诊患者刷新频率，默认不刷新
        /// </summary>
        private string frequence = "None";
        /// <summary>
        /// 挂号函数
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        /// <summary>
        /// 分诊函数
        /// </summary>
        Neusoft.HISFC.BizLogic.Nurse.Assign assignMgr = new Neusoft.HISFC.BizLogic.Nurse.Assign();
        /// <summary>
        /// 科室函数
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager deptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
     

        ArrayList alDept = new ArrayList();
        ArrayList alDoct = new ArrayList();

        #endregion

        public ucQueryReg()
        {
            InitializeComponent();
            this.Init();
        }

        #region 初始

        /// <summary>
        /// 完全初始化
        /// </summary>
        private void Init()
        {
            if (this.InitTreeView1() == -1)
            {
                this.FindForm().Close();
            }
        }
        /// <summary>
        /// 初始化树(待分诊,已分诊)
        /// </summary>
        private int InitTreeView1()
        {
            this.neuTreeView1.Nodes.Clear();

            TreeNode root = new TreeNode("患者类别");
            root.Tag = null;
            this.neuTreeView1.Nodes.Add(root);

            TreeNode node1 = new TreeNode("未看诊患者");
            node1.Tag = "1";
            root.Nodes.Add(node1);

            TreeNode node2 = new TreeNode("已看诊患者");
            node2.Tag = "2";
            root.Nodes.Add(node2);
            this.neuTreeView1.ExpandAll();

            //添加医生列表
            Neusoft.HISFC.BizProcess.Integrate.Manager personMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizProcess.Integrate.Manager depMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.Models.Base.Employee ps = new Neusoft.HISFC.Models.Base.Employee();
            Neusoft.HISFC.Models.Base.Department deptinfo = new Neusoft.HISFC.Models.Base.Department();

            //获取分诊的科室列表
            //alDept = depMgr.QueryDepartment(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID);
            alDept = depMgr.QueryDepartment(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID);
            if (alDept == null || alDept.Count <= 0)
            {
                MessageBox.Show("操作员没有维护护理站，或者护理站没有维护对应的分诊科室!", "初始化，获取科室列表出错!");
                return -1;
            }

            #region 获取分诊科室的医生列表
            //foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
            //{
            //    //科室
            //    ArrayList altmp = personMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, dept.ID);
            //    if (altmp != null && altmp.Count > 0)
            //    {
            //        foreach (Neusoft.HISFC.Models.Base.Employee psinfo in altmp)
            //        {
            //            alDoct.Add(psinfo);
            //        }
            //    }
            //}
            ////界面
            //if (alDoct == null || alDoct.Count < 0)
            //{
            //    return -1;
            //}

            //foreach (Neusoft.HISFC.Models.Base.Employee psinfo in alDoct)
            //{
            //    TreeNode node = new TreeNode();
            //    node.Text = psinfo.Name;
            //    node.Tag = psinfo;
            //    //node.ImageIndex = 26;
            //    //node.SelectedImageIndex = 35;

            //    node2.Nodes.Add(node);

            //}
            #endregion

            return 0;
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("刷新", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, null);
            return this.toolBarService;
        }        

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "刷新":
                    this.RefreshPatient();
                    break;
                default: break;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 检索已诊患者
        /// </summary>
        /// <param name="state"></param>
        /// <param name="doct"></param>
        private void QueryAlready(string doct)
        {
            //根据医生
            this.lvPatient.Items.Clear();
            this.neuLabel3.Text = "已看诊患者";
            //
            ArrayList al = assignMgr.QueryOrder(assignMgr.GetDateTimeFromSysDateTime().Date,
                                assignMgr.GetDateTimeFromSysDateTime().Date.AddDays(1), doct);
            if (al == null || al.Count <= 0) return;

            //
            foreach (Neusoft.HISFC.Models.Registration.Register reginfo in al)
            {
                //----------把不属于本科的过滤掉---------------------------------------------------
                Neusoft.FrameWork.Public.ObjectHelper helpMgr = new Neusoft.FrameWork.Public.ObjectHelper();
                helpMgr.ArrayObject = alDept;
                if (helpMgr.GetObjectFromID(reginfo.SeeDPCD) == null)
                {
                    continue;
                }
                //------------------end------------------------------------------------------------


                if (doct == "ALL")
                {
                    this.AddWaitDetail(reginfo);
                }
                else if (doct == reginfo.SeeDOCD)
                {
                    this.AddWaitDetail(reginfo);
                }
            }
        }

        /// <summary>
        /// 检索未诊患者
        /// </summary>
        private void QueryWait(string doct)
        {
            this.lvPatient.Items.Clear();
            this.neuLabel3.Text = "未看诊患者";

            //ArrayList pstemp = regMgr.QueryNoTriagebyDept(assignMgr.GetDateTimeFromSysDateTime().Date/* regMgr.GetDateTimeFromSysDateTime().Date*/, ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID);
            ArrayList pstemp = this.regMgr.QueryNoTriagebyDeptUnSee(assignMgr.GetDateTimeFromSysDateTime().Date/* regMgr.GetDateTimeFromSysDateTime().Date*/, ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID);
            if (pstemp != null && pstemp.Count > 0)
            {
                foreach (Neusoft.HISFC.Models.Registration.Register reginfo in pstemp)
                {
                    if (doct == "ALL")
                    {
                        this.AddWaitDetail(reginfo);
                    }
                    else if (doct == reginfo.DoctorInfo.Templet.Doct.ID)
                    {
                        this.AddWaitDetail(reginfo);
                    }
                }
            }
        }

        /// <summary>
        /// 挂号实体赋值界面
        /// </summary>
        /// <param name="reginfo"></param>
        private void AddWaitDetail(Neusoft.HISFC.Models.Registration.Register reginfo)
        {
            if (reginfo == null || reginfo.PID.CardNO == null)
            {
                return;
            }

            ListViewItem item = new ListViewItem();
            item.SubItems[0].Text = reginfo.PID.CardNO;

            item.SubItems.Add(reginfo.Name);
            item.SubItems.Add(reginfo.Sex.Name);
            item.SubItems.Add(reginfo.OrderNO.ToString());
            item.SubItems.Add(reginfo.DoctorInfo.Templet.Dept.Name);
            item.SubItems.Add(reginfo.DoctorInfo.SeeDate.ToString("yyyy-MM-dd HH:mm:ss"));
            //看诊医生
            //if (reginfo.DoctorInfo.Templet.Doct.ID != null && reginfo.DoctorInfo.Templet.Doct.ID != "")
            //{
                //item.SubItems.Add(reginfo.DoctorInfo.Templet.Doct.Name);
            if (reginfo.SeeDOCD == null || reginfo.SeeDOCD == "")
            {
                item.SubItems.Add("");
            }
            else
            {
                item.SubItems.Add(this.deptMgr.GetEmployeeInfo(reginfo.SeeDOCD).Name);
            }
            
        
            if (reginfo.SeeDOCD == null || reginfo.SeeDOCD == "")
            {
                item.SubItems.Add("");
            }
            else
            {
                string deptname = this.deptMgr.GetDepartment(reginfo.SeeDPCD).Name;
                if (deptname != null)
                {
                    item.SubItems.Add(deptname);
                }
            }
            
            item.Tag = reginfo;
            this.lvPatient.Items.Add(item);
        }

        /// <summary>
        /// 医嘱信息放入
        /// </summary>
        /// <param name="orderinfo"></param>
        private void AddAlreadyDetail(Neusoft.HISFC.Models.Order.OutPatient.Order orderinfo)
        {
            //能否根据医生,时间查询clinic_code
        }

        /// <summary>
        /// 刷新患者列表
        /// </summary>
        private void RefreshPatient()
        {
            try
            {
                TreeNode select = this.neuTreeView1.SelectedNode;
                if (select == null)
                {
                    return;
                }
                //没有选中
                if (select.Tag == null)
                {
                    return;
                }
                //未看诊患者
                if (select.Tag.ToString() == "1")
                {
                    this.QueryWait("ALL");
                }
                //已看诊患者
                else if (select.Tag.ToString() == "2")
                {
                    this.QueryAlready("ALL");
                }
                else if (select.Tag.GetType() == typeof(Neusoft.HISFC.Models.Base.Employee))
                {
                    Neusoft.HISFC.Models.Base.Employee ps = (Neusoft.HISFC.Models.Base.Employee)select.Tag;
                    this.QueryAlready(ps.ID);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 所有RadioButton的
        /// </summary>
        private void SetRadioFalse()
        {
            this.rbNo.Checked = false;
            this.rb10.Checked = false;
            this.rb30.Checked = false;
            this.rb60.Checked = false;
        }

        #endregion

        #region 公共

        private string AvoidNull(string str)
        {
            if (str == null)
            {
                str = "";
            }
            return str;
        }

        #endregion

        private void txtCard_KeyDown(object sender, KeyEventArgs e)
        {
            this.lvPatient.Items.Clear();
            if (e.KeyData == Keys.Enter)
            {
                //先查找挂号表
                string cardNo = this.txtCard.Text.PadLeft(10, '0');
                ArrayList alReg = this.regMgr.Query(cardNo, this.assignMgr.GetDateTimeFromSysDateTime().Date);
                if (alReg == null || alReg.Count == 0)
                {
                    MessageBox.Show("没有该患者的挂号信息");
                    return;
                }
                if (alReg != null || alReg.Count > 0)
                {
                    foreach (Neusoft.HISFC.Models.Registration.Register reginfo in alReg)
                    {
                        if (reginfo.IsSee)
                        {
                            continue;
                        }
                        else
                        {
                            this.AddWaitDetail(reginfo);
                        }
                    }
                }
               
                //然后查找遗嘱表
                alReg = this.assignMgr.QueryOrder(cardNo, this.assignMgr.GetDateTimeFromSysDateTime().Date,
                                            this.assignMgr.GetDateTimeFromSysDateTime().Date.AddDays(1));
                if (alReg != null || alReg.Count > 0)
                {
                    foreach (Neusoft.HISFC.Models.Registration.Register reginfo in alReg)
                    {
                        this.AddWaitDetail(reginfo);
                    }
                }
            }
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbNo.Checked)
            {
                RefreshFrequence rf = new RefreshFrequence();
                System.IO.FileStream fs = new System.IO.FileStream((Application.StartupPath + "/profile/patientQuery.xml"), System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                rf.RefreshTime = "no";
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(RefreshFrequence));
                x.Serialize(fs, rf);
                fs.Close();

                this.timer1.Enabled = false;
            }
        }

        private void rb10_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb10.Checked)
            {
                RefreshFrequence rf = new RefreshFrequence();
                System.IO.FileStream fs = new System.IO.FileStream((Application.StartupPath + "/profile/patientQuery.xml"), System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                rf.RefreshTime = "10";
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(RefreshFrequence));
                x.Serialize(fs, rf);
                fs.Close();

                this.timer1.Interval = 10000;
                this.timer1.Enabled = true;
            }
        }

        private void rb30_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb30.Checked)
            {
                RefreshFrequence rf = new RefreshFrequence();
                System.IO.FileStream fs = new System.IO.FileStream((Application.StartupPath + "/profile/patientQuery.xml"), System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                rf.RefreshTime = "30";
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(RefreshFrequence));
                x.Serialize(fs, rf);
                fs.Close();

                this.timer1.Interval = 30000;
                this.timer1.Enabled = true;
            }
        }

        private void rb60_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb60.Checked)
            {
                RefreshFrequence rf = new RefreshFrequence();
                System.IO.FileStream fs = new System.IO.FileStream((Application.StartupPath + "/profile/patientQuery.xml"), System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                rf.RefreshTime = "60";
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(RefreshFrequence));
                x.Serialize(fs, rf);
                fs.Close();

                this.timer1.Interval = 60000;
                this.timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.RefreshPatient();
        }

        private void ucQueryReg_Load(object sender, EventArgs e)
        {
            // [2007/03/13] 读配置文件,如果存在(患者就诊信息查询)
            if (System.IO.File.Exists(Application.StartupPath + "/profile/patientQuery.xml"))
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(RefreshFrequence));
                System.IO.FileStream fs = new System.IO.FileStream(Application.StartupPath + "/profile/patientQuery.xml", System.IO.FileMode.Open);
                
                RefreshFrequence refres = (RefreshFrequence)xs.Deserialize(fs);
                switch (refres.RefreshTime.Trim())
                {
                    case "no":
                        this.SetRadioFalse();
                        fs.Close();
                        this.rbNo.Checked = true;
                        break;
                    case "10":
                        this.SetRadioFalse();
                        fs.Close();
                        this.rb10.Checked = true;
                        break;
                    case "30":
                        this.SetRadioFalse();
                        fs.Close();
                        this.rb30.Checked = true;
                        break;
                    case "60":
                        this.SetRadioFalse();
                        fs.Close();
                        this.rb60.Checked = true;
                        break;
                    default:
                        this.SetRadioFalse();
                        fs.Close();
                        this.rbNo.Checked = true;
                        break;
                }
            }
            else
            {
                this.SetRadioFalse();
                this.rbNo.Checked = true;
            }
            // [2007/03/13] 结束
        }

        private void neuTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            //刷新查询患者信息
            this.RefreshPatient();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace HeNanProvinceSI.Control
{
    public partial class frmSICondition : Form
    {
        public frmSICondition()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
            try
            {
                this.InitDiagnose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private Neusoft.FrameWork.Models.NeuObject desease = new Neusoft.FrameWork.Models.NeuObject();

        private HeNanProvinceSI.LocalManager localManager = new LocalManager();

        private Neusoft.HISFC.Models.RADT.PatientInfo p = null;

        private Neusoft.HISFC.Models.Registration.Register r = null;

        private bool isSaveDiag = false;

        /// <summary>
        /// 合同单位
        /// </summary>
        private string pactCode = "";

        /// <summary>
        /// 合同单位
        /// </summary>
        public string PactCode
        {
            get { return this.pactCode; }
            set { this.pactCode = value; }
        }

        /// <summary>
        /// 是否在弹出窗体内保存医保诊断true点确定就直接保存false点确定了不保存，返回选择的诊断
        /// </summary>
        public bool IsSaveDiag
        {
            get { return this.isSaveDiag; }
            set { this.isSaveDiag = value; }
        }

        private string type = "";

        /// <summary>
        /// 设置患者信息 1门诊2住院
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        public void SetPatient(Neusoft.FrameWork.Models.NeuObject o, string type)
        {
            p = null;
            r = null;
            this.type = type;
            if (type == "1")
            {
                r = o as Neusoft.HISFC.Models.Registration.Register;
            }
            if (type == "2")
            {
                p = o as Neusoft.HISFC.Models.RADT.PatientInfo;
            }
        }

        /// <summary>
        /// 病情信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Desease
        {
            get { return this.desease; }
        }

        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <returns></returns>
        private int InitDiagnose()
        {
            ArrayList al = new ArrayList();
            al = this.localManager.GetDiagnoseByPactCode(this.pactCode);
            if (al != null && al.Count != 0)
            {
                this.cmbDesease.AddItems(al);
            }
            return 1;
        }

        private void ShowHistoryDiag()
        {
            if (this.type == "1")
            {
                r = this.localManager.GetSIPersonInfoOutPatient(r.ID);
                if (r != null)
                {
                    this.cmbDesease.Tag = r.SIMainInfo.OutDiagnose.ID;
                }
            }
            if (this.type == "2")
            {
                p = this.localManager.GetSIPersonInfo(p.ID, "0");
                if (p != null)
                {
                    this.cmbDesease.Tag = p.SIMainInfo.OutDiagnose.ID;
                }
            }
        }

        private int SaveDiag()
        {
            if (this.cmbDesease.SelectedItem == null)
            {
                MessageBox.Show("请选择项目！");
                return -1;
            }
            if (this.type == "1")
            {
                try
                {
                    //string sql = "update fin_ipr_siinmaininfo i set i.out_diagnose='{2}',i.out_diagnosename='{3}' where i.inpatient_no='{0}' and i.balance_no='{1}'";
                    //sql = string.Format(sql, r.ID, r.SIMainInfo.BalNo, this.cmbDesease.SelectedItem.ID, this.cmbDesease.SelectedItem.Name);
                    string sql = "update fin_ipr_siinmaininfo i set i.out_diagnose='{1}',i.out_diagnosename='{2}' where i.inpatient_no='{0}'";
                    sql = string.Format(sql, r.ID, this.cmbDesease.SelectedItem.ID, this.cmbDesease.SelectedItem.Name);
                    return this.localManager.ExecNoQuery(sql);
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
            if (this.type == "2")
            {
                try
                {
                    string sql = "update fin_ipr_siinmaininfo i set i.out_diagnose='{2}',i.out_diagnosename='{3}' where i.inpatient_no='{0}' and i.balance_no='{1}'";
                    sql = string.Format(sql, p.ID, p.SIMainInfo.BalNo, this.cmbDesease.SelectedItem.ID, this.cmbDesease.SelectedItem.Name);
                    return this.localManager.ExecNoQuery(sql);
                }
                catch (Exception e)
                {
                    return -1;
                }
            }

            return 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            desease = new Neusoft.FrameWork.Models.NeuObject();
            desease.ID = "";
            desease.Name = "";
            if (this.cmbDesease.SelectedItem != null)
            {
                desease.ID = this.cmbDesease.SelectedItem.ID; 
                desease.Name = this.cmbDesease.SelectedItem.Name;
            }
            else
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            if (this.isSaveDiag == false)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (this.SaveDiag() != 1)
                {
                    MessageBox.Show("保存医保诊断失败！");
                }
                else
                {
                    //MessageBox.Show("保存医保诊断成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmSICondition_Load(object sender, EventArgs e)
        {
            try
            {
                this.ShowHistoryDiag();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获取医保诊断出错:" + ee.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord.CaseLend
{
    /// <summary>
    /// frmCaseCard<br></br>
    /// [功能描述: 病案借阅卡信息录入]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-20]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class frmCaseCard : Form
    {
        public frmCaseCard()
        {
            InitializeComponent();
        }
        #region 全局变量
        Neusoft.HISFC.BizLogic.HealthRecord.CaseCard card = new Neusoft.HISFC.BizLogic.HealthRecord.CaseCard();
        private Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes editType;
        #endregion
        /// <summary>
        /// 设置标志
        /// </summary>
        public Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes EditType
        {
            set
            {
                editType = value;
                if (editType == Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes.Add)
                {
                    this.ckValue.Checked = true;
                    this.ckContinue.Enabled = true;
                    //{19AB39F1-B0A0-4d74-A4BF-DB026DE9E832} 病案借阅修改
                    //this.txCardNo.ReadOnly = false;
                }
                else if (editType == Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes.Modify)
                {
                    this.txCardNo.ReadOnly = true;
                    this.ckContinue.Enabled = false;
                }
            }
            get
            {
                return editType;
            }
        }
        /// <summary>
        /// 保存 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {

            if (CheckValue() == -1)
            {
                return;
            }
            Neusoft.HISFC.Models.HealthRecord.ReadCard obj = this.Getinfo();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(card.Connection);
            //trans.BeginTransaction();

            card.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int iReturn = 0;
            #region 保存数据
            //如果是增加的 则插入
            if (editType == Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes.Add)
            {
                //插入I信息
                iReturn = card.Insert(obj);

                if (iReturn < 0)
                {
                    //回退数据
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存失败 " + card.Err);
                }
            }
            else if (editType == Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes.Modify) //其他的执行更新操作。
            {
                iReturn = card.Update(obj);
                if (iReturn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新信息失败! " + card.Err);
                }
                if (iReturn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("没有找到可更新的信息");
                }
            }
            #endregion
            //提交数据
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功");
            if (this.ckContinue.Checked && this.ckContinue.Enabled)
            {
                this.ClearInfo();
            }
            else
            {
                this.Visible = false;
            }
            SaveHandle(obj);
        }
        private int CheckValue()

        {
            if (this.comperson.Tag == null || comperson.Tag.ToString() == "")
            {
                this.comperson.Focus();
                MessageBox.Show("请选择人员");
                return -1;
            }
            if (this.comDept.Tag == null || comDept.Tag.ToString() == "")
            {
                this.comDept.Focus();
                MessageBox.Show("请选择科室");
                return -1;
            }
            if (this.txCardNo.Text == "")
            {
                this.txCardNo.Focus();
                MessageBox.Show("请选择输入借阅证号");
                return -1;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(txCardNo.Text, 14))
            {
                this.txCardNo.Focus();
                MessageBox.Show("卡号输入过长");
                return -1;
            }
            if (this.editType == Neusoft.HISFC.Models.HealthRecord.EnumServer.EditTypes.Add)
            {
                Neusoft.HISFC.Models.HealthRecord.ReadCard obj1 = card.GetCardInfo(txCardNo.Text);
                if (obj1 == null)
                {
                    this.txCardNo.Focus();
                    MessageBox.Show("查询出错");
                    return -1;
                }
                if (obj1.CardID != "")
                {
                    this.txCardNo.Focus();
                    MessageBox.Show("借阅证号已经存在");
                    return -1;
                }
            }
            return 1;
        }
        /// <summary>
        /// 获取界面上的信息
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.HealthRecord.ReadCard Getinfo()
        {
            Neusoft.HISFC.Models.HealthRecord.ReadCard info = new Neusoft.HISFC.Models.HealthRecord.ReadCard();
            info.CardID = this.txCardNo.Text;
            info.EmployeeInfo.Name = this.comperson.Text;
            if (this.comperson.Tag != null)
            {
                info.EmployeeInfo.ID = this.comperson.Tag.ToString();
            }
            if (this.comDept.Tag != null)
            {
                info.DeptInfo.ID = this.comDept.Tag.ToString();
            }
            info.DeptInfo.Name = this.comDept.Text;
            info.User01 = this.card.Operator.ID;
            info.EmployeeInfo.OperTime = System.DateTime.Now; //ftp每天同步服务器和本地的时间,所以这样写没有关系
            if (this.ckValue.Checked)
            {
                info.ValidFlag = "1";
            }
            else
            {
                info.ValidFlag = "2";
                info.CancelDate = System.DateTime.Now;//ftp每天同步服务器和本地的时间,所以这样写没有关系
                info.CancelOperInfo.ID = card.Operator.ID;
                info.CancelOperInfo.Name = card.Operator.Name;
            }
            return info;
        }
        private void frmCaseCard_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsClose)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }
        /// <summary>
        /// 清空数据
        /// </summary>
        public void ClearInfo()
        {
            this.comperson.Text = "";
            this.comDept.Text = "";
            this.txCardNo.Text = "";
            this.ckValue.Checked = false;
        }
        /// <summary>
        /// 加载数据 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int SetInfo(Neusoft.HISFC.Models.HealthRecord.ReadCard obj)
        {
            this.txCardNo.Text = obj.CardID; //卡号
            this.comperson.Tag = obj.EmployeeInfo.ID; //员工号
            this.comperson.Text = obj.EmployeeInfo.Name;//员工姓名
            this.comDept.Tag = obj.DeptInfo.ID;//科室代码
            this.comDept.Text = obj.DeptInfo.Name;//科室名称
            if (obj.ValidFlag == "1" || obj.ValidFlag == "有效")
            {
                this.ckValue.Checked = true;
            }
            else
            {
                this.ckValue.Checked = false;
            }
            return 1;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Visible = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deptList"></param>
        /// <returns></returns>
        public void SetDeptList(ArrayList deptList)
        {
            this.comDept.AppendItems(deptList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PersonList"></param>
        /// <returns></returns>
        public void SetPersonList(ArrayList PersonList)
        {

            this.comperson.AppendItems(PersonList);
        }

        private void comperson_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.comDept.Focus();
            }
        }

        private void comDept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txCardNo.Focus();
            }
        }

        private void txCardNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.ckValue.Focus();
            }
        }

        private void ckValue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void frmCaseCard_Load(object sender, System.EventArgs e)
        {
            this.comperson.Focus();
        }

        /// <summary>
        /// {19AB39F1-B0A0-4d74-A4BF-DB026DE9E832} 病案借阅修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comperson_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txCardNo.Text = this.comperson.Tag.ToString();
            Neusoft.HISFC.Models.Base.Employee emp = this.comperson.SelectedItem as Neusoft.HISFC.Models.Base.Employee;
            if (emp != null)
            {
                this.comDept.Tag = emp.Dept.ID;
            }
        }
    }
}
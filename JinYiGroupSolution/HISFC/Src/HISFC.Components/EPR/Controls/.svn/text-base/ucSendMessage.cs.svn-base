using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.EPR.Controls
{
    public partial class ucSendMessage : UserControl
    {
        public ucSendMessage()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// 整合的管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Factory.ManagerManagement managerManager = new Neusoft.HISFC.BizProcess.Factory.ManagerManagement();
        /// <summary>
        /// 当前消息
        /// </summary>
        private Neusoft.HISFC.Models.Base.Message message = null;

        private ArrayList lis = new ArrayList();
 

        
       
        public ucSendMessage(Neusoft.FrameWork.Models.NeuObject patient,string eprId,string eprName,Neusoft.FrameWork.Models.NeuObject oper)
        {
            InitializeComponent();
           
            this.InitialCombox();

            lis.Add(eprId);
            lis.Add(patient.Name);
            lis.Add(eprName);
            lis.Add(patient.ID);

            if (patient == null) return;
            if (eprName == "" && patient.Name == "")
            {
            }
            else if (eprName == "")
            {
                this.lblInfo.Text = string.Format("患者：{0} ", patient.Name);
                this.textBox1.Text = string.Format("{0}的病历有问题，需要更改!", patient.Name);

            }
            else
            {
                this.lblInfo.Text = string.Format("患者：{0} 的病历{1}", patient.Name, eprName);
                this.textBox1.Text = string.Format("{0}的{1}有问题，需要更改!", patient.Name, eprName);

            }

            if(oper !=null)
                this.comboBox1.Text = oper.Name;
            this.richTextBox1.Text = "请及时更改！\n" + Neusoft.FrameWork.Management.Connection.Operator.Name ;
        }
       

        #region 事件
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "")
            {
                MessageBox.Show("请选择发送人！", "提示");

                this.comboBox1.Focus();

                return;
            }
            this.Save();

            DialogResult dr = MessageBox.Show("消息发送成功！是否继续发消息？", "提示", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                this.ClearUp();
            }
            else if (dr == DialogResult.No)
            {
                this.FindForm().Close();
            }

            
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        #endregion 

        #region 方法
        /// <summary>
        /// 初始化人员列表
        /// </summary>
        private void InitialCombox()
        {
            ArrayList personLis = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.QueryEmployeeAll();

            this.comboBox1.AddItems(personLis);

        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        private int Save()
        {
            message = GetMessage();

            try
            {
                Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();

                int returnValue = 0;

                returnValue = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.InsertMessage(message);

                if (returnValue == -1)
                {
                    Neusoft.HISFC.BizProcess.Factory.Function.RollBack();

                    MessageBox.Show("插入失败！" + Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.Err);

                    return -1;
                }
                else
                {
                    Neusoft.HISFC.BizProcess.Factory.Function.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 1;
        }
        /// <summary>
        /// 获取页面上的数据
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Message GetMessage()
        {

            Neusoft.HISFC.Models.Base.Message message = new Neusoft.HISFC.Models.Base.Message();

            message.Receiver.Name = this.comboBox1.Text;

            message.Receiver.ID = this.comboBox1.Tag.ToString();

            Neusoft.HISFC.Models.Base.Employee receiver = managerManager.GetPersonByID(message.Receiver.ID);

            message.ReceiverDept.ID = receiver.Dept.ID;

            message.ReceiverDept.Name = receiver.Dept.Name;

            message.Name = this.textBox1.Text.Trim();

            message.Text = this.richTextBox1.Text.Trim();

            message.Oper.OperTime = System.DateTime.Now;

            message.Oper.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;

            message.Oper.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;

            Neusoft.HISFC.Models.Base.Employee oper = managerManager.GetPersonByID(message.Oper.ID);

            message.SenderDept.ID = oper.Dept.ID;

            message.SenderDept.Name = oper.Dept.Name;

            message.ReplyType = -1;
            message.InpatientNo = lis[3].ToString();//eprId
            message.Emr.User01 = lis[1].ToString();// patient.Name
            message.Emr.Name = lis[2].ToString();//emrname
            message.Emr.ID = lis[0].ToString();
            
           


            return message;

        }
        /// <summary>
        /// 清空数据
        /// </summary>
        private void ClearUp()
        {
            this.comboBox1.Text = "";

            this.textBox1.Text = "";

            this.richTextBox1.Text = "";
        }
        #endregion 
    }
}

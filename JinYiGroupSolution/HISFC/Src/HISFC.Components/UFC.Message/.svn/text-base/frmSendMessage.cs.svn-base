using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Message
{
    public partial class frmSendMessage : Form
    {
        public frmSendMessage()
        {
            InitializeComponent();
        }

        private void frmSendMessage_Load(object sender, EventArgs e)
        {
            InitialCombox();
        }
        
        private Neusoft.HISFC.Models.Base.Message message = null;
       

        /// <summary>
        /// 整合的管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Factory.ManagerManagement managerManager = new Neusoft.HISFC.BizProcess.Factory.ManagerManagement();

        /// <summary>
        /// 当前消息
        /// </summary>
        public Neusoft.HISFC.Models.Base.Message Message
        {
            get { return message; }
            set { message = value; }
        }
        #region 初始化人员列表
        private void InitialCombox()
        {
            ArrayList personLis = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.QueryEmployeeAll();

            this.ComboBox1.AddItems(personLis);
            
        }
        #endregion 
        #region 事件
        /// <summary>
        /// 发送消息，把消息存入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValueValidated()) return;
            
            this.Save();

            DialogResult dr = MessageBox.Show("消息发送成功！是否继续发消息？", "提示",MessageBoxButtons.YesNo);
          
            if (dr == DialogResult.Yes)
            {
                this.ClearUp();
            }
            else if(dr == DialogResult.No)
            {
                this.Close();
            }


            
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
       
        #region 方法
        /// <summary>
        /// 把数据存入实体中
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Message GetMessage()
        {

            Neusoft.HISFC.Models.Base.Message message = new Neusoft.HISFC.Models.Base.Message();

            message.Receiver.Name = this.ComboBox1.Text;

            message.Receiver.ID = this.ComboBox1.Tag.ToString();

            Neusoft.HISFC.Models.Base.Employee receiver = managerManager.GetPersonByID( message.Receiver.ID);

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


            return message;
            
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
        /// 清空数据
        /// </summary>
        private void ClearUp()
        {
            this.ComboBox1.Text = "";

            this.textBox1.Text = "";

            this.richTextBox1.Text = "";
        }
        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns></returns>
        private bool ValueValidated()
        {
            if (this.ComboBox1.Text == "")
            {
                MessageBox.Show("请选择发送人！", "提示");

                this.ComboBox1.Focus();

                return false;
            }

            else
            {
                return true;
            }
        }
        #endregion 


    }
}
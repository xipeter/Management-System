using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace Neusoft.HISFC.Components.Message
{
    public partial class ucMessage : UserControl
    {
        #region 变量

        private DataView dv = null;

        private DataTable dt = new DataTable();
        #endregion


        public ucMessage()
        {
            InitializeComponent();

        }

        #region 初始化

        private void InitFpColumn()
        {

            dt.Columns.Add("", typeof(Image));
            dt.Columns.Add("发件人", typeof(string));
            dt.Columns.Add("主题", typeof(string));
            dt.Columns.Add("日期", typeof(DateTime));
            dt.Columns.Add("回复状态", typeof(string));
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("阅读状态", typeof(string));
            this.dv = new DataView(dt);
            this.fpSpread1_Sheet1.DataAutoSizeColumns = false;
            this.fpSpread1_Sheet1.DataSource = dv;
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 17F;
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 77F;
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 164F;
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 141F;
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 59F;
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 59F;
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 59F;




        }
        /// <summary>
        /// 设置列的类型
        /// </summary>
        private void InitColumnsType()
        {
            FarPoint.Win.Spread.CellType.ImageCellType imageCellType = new FarPoint.Win.Spread.CellType.ImageCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).CellType = imageCellType;
            this.fpSpread1_Sheet1.Columns.Get(0).CellType = imageCellType;
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = dateTimeCellType2;
            dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
            
        }
        /// <summary>
        /// 初始化fp
        /// </summary>
        /// <returns></returns>
        private int InitMessageData()
        {


            ArrayList messageLis =
                Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryMessage( Neusoft.FrameWork.Management.Connection.Operator.ID );

            if (messageLis == null) return 0;


            this.dt.Rows.Clear();

            foreach (Neusoft.HISFC.Models.Base.Message message in messageLis)
            {
                DataRow row = this.dt.NewRow();

                if (message.IsRecieved == false)
                {

                    row[0] = Properties.Resources.close;

                }
                else
                {

                    row[0] = Properties.Resources.open;
                }


                row[1] = message.Oper.Name;
                row[2] = message.Name;
                row[3] = message.Oper.OperTime;
                if (message.ReplyType == 0)
                {
                    row[4] = "已阅读";
                }
                else if (message.ReplyType == 1)
                {
                    row[4] = "已回复";
                }
                else if (message.ReplyType == 2)
                {
                    row[4] = "已完成";
                }
                else
                {
                    row[4] = "";
                }
                row[5] = message.ID;
                row[6] = message.IsRecieved;
                this.dt.Rows.Add(row);
            }

            this.InitColumnsType();

            return 1;
        }

        private void InitCombo()
        {

            this.neuComboBox1.Items.Add("显示全部");
            this.neuComboBox1.Items.Add("已阅读的");
            this.neuComboBox1.Items.Add("未阅读的");
            this.neuComboBox1.Text = "未阅读的";

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucMessage_Load(object sender, EventArgs e)
        {

            this.InitFpColumn();
            InitMessageData();
            this.InitCombo();

        }



        #endregion
        #region 事件

        /// <summary>
        /// 双击回复事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            string messageId = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 5].Text;

            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 0].Value = Properties.Resources.open;

            try
            {
                Neusoft.HISFC.Models.Base.Message message = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryMessageById(messageId);

                message.IsRecieved = true;

                message.ReplyType = 0;

                this.UpdateState(message);

                frmReply reply = new frmReply(message, this.FindForm());

                reply.ShowDialog();

                InitMessageData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 写消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            frmSendMessage sendMessage = new frmSendMessage();

            sendMessage.Show();
        }
        /// <summary>
        /// 收消息（刷新列表）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            InitMessageData();

            this.neuComboBox1.Text = "未阅读的";

        }
        /// <summary>
        /// 选择一条消息，回复消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1_Sheet1.RowCount == 0) return;

            string messageId = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 5].Text;

            try
            {
                Neusoft.HISFC.Models.Base.Message message = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryMessageById( messageId );

                message.IsRecieved = true;

                message.ReplyType = 0;

                this.UpdateState(message);

                frmReply reply = new frmReply(message, this.FindForm());

                reply.ShowDialog();

                InitMessageData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        #endregion
        #region 方法
        /// <summary>
        /// 修改消息状态
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private int UpdateState(Neusoft.HISFC.Models.Base.Message message)
        {
            try
            {
                Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();

                int returnValue = 0;

                returnValue = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.UpdateMessage( message );

                if (returnValue == -1)
                {
                    Neusoft.HISFC.BizProcess.Factory.Function.RollBack();

                    MessageBox.Show( "更新失败！" + Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.Err );

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
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {

            string messageId = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 5].Text;
            if (messageId == "")
            {
                MessageBox.Show("请选择一条记录", "提示");
                return;
            }

            if (MessageBox.Show("确实要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int returnvalue = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DeleteMessage(messageId);

                if (returnvalue == 1)
                {

                    MessageBox.Show("删除成功！");
                    this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.ActiveRowIndex].Remove();

                }
                else
                {
                    MessageBox.Show("删除失败！");

                    return;
                }
            }


        }
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterStr = "";


            string queryCode = this.neuComboBox1.Text;

            if (queryCode == "未阅读的")
            {
                filterStr = "阅读状态 = 'false'";
                this.dv.RowFilter = filterStr;
            }

            else if (queryCode == "已阅读的")
            {
                filterStr = "阅读状态 = 'true'";
                this.dv.RowFilter = filterStr;
            }
            else if (queryCode == "显示全部")
            {
                filterStr = "(阅读状态 = 'true') OR (阅读状态 = 'false')";
                this.dv.RowFilter = filterStr;
 
            }
            this.dv.Sort = "日期 DESC";
            this.InitColumnsType();

        }



















    }
}

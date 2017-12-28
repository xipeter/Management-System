using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
    /// <summary>
    /// 消息管理类


    /// </summary>
    public class Message : Neusoft.FrameWork.Management.Database
    {
        public Message()
        {

        }
       

        #region 消息管理
        /// <summary>
        /// 根据收件人查询所有消息
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryMessage(string oper)
        {
            string strSql = "";

            Neusoft.HISFC.Models.Base.Message message = null;

            ArrayList lis = new ArrayList();

            if (this.Sql.GetSql("EPR.MESSAGE.QUERY", ref strSql) == -1) return null;

            try
            {
                strSql = string.Format(strSql, oper);

                this.ExecQuery(strSql);

                while (this.Reader.Read())
                {
                    message = new Neusoft.HISFC.Models.Base.Message();
                    message.ID = this.Reader[0].ToString();
                    message.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString());
                    message.Oper.ID = this.Reader[2].ToString();
                    message.Oper.Name = this.Reader[3].ToString();
                    message.Text = this.Reader[4].ToString();
                    message.Receiver.ID = this.Reader[5].ToString();
                    message.Receiver.Name = this.Reader[6].ToString();
                    message.ReceiverDept.ID = this.Reader[7].ToString();
                    message.ReceiverDept.Name = this.Reader[8].ToString();
                    message.IsRecieved = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[9].ToString());
                    message.Emr.ID = this.Reader[10].ToString();
                    message.InpatientNo = this.Reader[11].ToString();
                    message.Emr.User01 = this.Reader[12].ToString();
                    message.ReplyType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13].ToString());
                    message.Emr.Name = this.Reader[14].ToString();
                    message.SenderDept.ID = this.Reader[15].ToString();
                    message.SenderDept.Name = this.Reader[16].ToString();
                    message.Name = this.Reader[17].ToString();
                    lis.Add(message);
                }
                
                this.Reader.Close();
            }
            catch(Exception ex)
            {
                this.WriteErr();

                return null;
            }
            
            return lis;

        }
        /// <summary>
        /// 查询所有消息
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryEmrId(string InpatientNo)
        {
            string strSql = "";

            Neusoft.HISFC.Models.Base.Message message = null;

            ArrayList lis = new ArrayList();

            if (this.Sql.GetSql("EPR.MESSAGE.QUERY1", ref strSql) == -1) return null;

            try
            {
                strSql = string.Format(strSql, InpatientNo);

                this.ExecQuery(strSql);

                while (this.Reader.Read())
                {
                    message = new Neusoft.HISFC.Models.Base.Message();
                    message.ID = this.Reader[0].ToString();
                    message.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString());
                    message.Oper.ID = this.Reader[2].ToString();
                    message.Oper.Name = this.Reader[3].ToString();
                    message.Text = this.Reader[4].ToString();
                    message.Receiver.ID = this.Reader[5].ToString();
                    message.Receiver.Name = this.Reader[6].ToString();
                    message.ReceiverDept.ID = this.Reader[7].ToString();
                    message.ReceiverDept.Name = this.Reader[8].ToString();
                    message.IsRecieved = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[9].ToString());
                    message.Emr.ID = this.Reader[10].ToString();
                    message.InpatientNo = this.Reader[11].ToString();
                    message.Emr.User01 = this.Reader[12].ToString();
                    message.ReplyType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13].ToString());
                    message.Emr.Name = this.Reader[14].ToString();
                    message.SenderDept.ID = this.Reader[15].ToString();
                    message.SenderDept.Name = this.Reader[16].ToString();
                    message.Name = this.Reader[17].ToString();
                    lis.Add(message);
                }

                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.WriteErr();

                return null;
            }

            return lis;

        }

        public Neusoft.HISFC.Models.Base.Message QueryMessageById(string id)
        {
            string strSql = "";

            Neusoft.HISFC.Models.Base.Message message =  new Neusoft.HISFC.Models.Base.Message();

            
            if (this.Sql.GetSql("EPR.MESSAGE.QUERYBYID", ref strSql) == -1) return null;

            try
            {
                strSql = string.Format(strSql, id);

                this.ExecQuery(strSql);

                if (this.Reader.Read())
                {
                   
                    message.ID = this.Reader[0].ToString();
                    message.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString());
                    message.Oper.ID = this.Reader[2].ToString();
                    message.Oper.Name = this.Reader[3].ToString();
                    message.Text = this.Reader[4].ToString();
                    message.Receiver.ID = this.Reader[5].ToString();
                    message.Receiver.Name = this.Reader[6].ToString();
                    message.ReceiverDept.ID = this.Reader[7].ToString();
                    message.ReceiverDept.Name = this.Reader[8].ToString();
                    message.IsRecieved = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[9].ToString());
                    message.Emr.ID = this.Reader[10].ToString();
                    message.InpatientNo = this.Reader[11].ToString();
                    message.Emr.User01 = this.Reader[12].ToString();
                    message.ReplyType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13].ToString());
                    message.Emr.Name = this.Reader[14].ToString();
                    message.SenderDept.ID = this.Reader[15].ToString();
                    message.SenderDept.Name = this.Reader[16].ToString();
                    message.Name = this.Reader[17].ToString();
                    
                }
                   this.Reader.Close();

                   
            }
            catch (Exception ex)
            {
                this.WriteErr();

                return null;
            }

            return message;

        }
       /// <summary>
       /// 插入一条消息

       /// </summary>
       /// <param name="message"></param>
       /// <returns></returns>
        public int InsertMessage(Neusoft.HISFC.Models.Base.Message message)
        {
            string strSql = "";
            
            if (this.Sql.GetSql("EPR.MESSAGE.INSERT", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, message.Oper.OperTime, message.Oper.ID, message.Oper.Name, message.Text, message.Receiver.ID, message.Receiver.Name, message.ReceiverDept.ID, message.ReceiverDept.Name,false
                    , message.Emr.ID, message.InpatientNo, message.Emr.User01,-1, message.Emr.Name, message.Oper.ID, message.Oper.Name, message.Name);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "接口错误！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 修改消息状态

        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int UpdateMessage(Neusoft.HISFC.Models.Base.Message message)
        {
            string strSql = "";

            if (this.Sql.GetSql("EPR.MESSAGE.UPDATE", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, message.IsRecieved,message.ReplyType,message.ID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "接口错误！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSql);
            
           
        }
         /// <summary>
         /// 根据病历号修改消息状态
         /// </summary>
         /// <param name="type"></param>
         /// <param name="eprid"></param>
         /// <returns></returns>
        public int UpdateMessage(int type,string eprid)
        {
            string strSql = "";

            if (this.Sql.GetSql("EPR.MESSAGE.UPDATE1", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql,type,eprid);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "接口错误！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSql);
            
           
        }
        
        /// <summary>
        /// 删除一条消息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteMessage(string id)
        {

            string strSql = "";

            if (this.Sql.GetSql("EPR.MESSAGE.DELETE", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, id);

                if (this.ExecNoQuery(strSql) == -1)
                {
                    return -1;
                }


            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;

                this.WriteErr();

                return -1;
            }
            return 1;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// ID编码，Name消息标题
    /// </summary>
    [Serializable]
    public class Message : Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        /// <summary>
        /// 发送人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject sender = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        /// <summary>
        /// 接收人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject receiver = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }
        /// <summary>
        /// 发送人科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject senderDept = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject SenderDept
        {
            get { return senderDept; }
            set { senderDept = value; }
        }
        /// <summary>
        /// 接收人科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject receiverDept = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject ReceiverDept
        {
            get { return receiverDept; }
            set { receiverDept = value; }
        }
        /// <summary>
        /// 是否接收状态 1已阅读 0未阅读
        /// </summary>
        private bool isRecieved = false;

        public bool IsRecieved
        {
            get { return isRecieved; }
            set { isRecieved = value; }
        }
        /// <summary>
        /// 消息处理类型  0已阅读 1 已回复 2 已处理
        /// </summary>
        private int replyType;

        public int ReplyType
        {
            get { return replyType; }
            set { replyType = value; }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        private OperEnvironment oper = new OperEnvironment();

        public OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }

        /// <summary>
        /// 患者病例
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject emr = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject Emr
        {
            get { return emr; }
            set { emr = value; }
        }
        /// <summary>
        /// 患者住院流水号
        /// </summary>
        private string inpatientNo;

        public string InpatientNo
        {
            get { return inpatientNo; }
            set { inpatientNo = value; }
        }

        
    }
}
